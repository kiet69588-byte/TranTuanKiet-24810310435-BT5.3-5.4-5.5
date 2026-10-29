
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Bai5_3
{
    public partial class Form1 : Form
    {
        private int maBanDangChon = 1;
        private int maHoaDon = 0;

        public Form1()
        {
            InitializeComponent();

            btnThanhToan.Click += (s, e) => ThanhToan();
            btnChuyenBan.Click += (s, e) => ChuyenBan();

            btnThucDon.Click += (s, e) =>
            {
                using (FrmThucDon f = new FrmThucDon())
                    f.ShowDialog(this);

                LoadDanhMuc();
                LoadMon();
            };

            cboDanhMuc.SelectedIndexChanged += (s, e) => LoadMon();

            LoadDanhMuc();
            LoadBan();
            ChonBan(1);
        }

        private void LoadDanhMuc()
        {
            using (SqlConnection conn = Db.TaoKetNoi())
            using (SqlDataAdapter da = new SqlDataAdapter(
                "SELECT MaDanhMuc, TenDanhMuc FROM DanhMuc ORDER BY MaDanhMuc", conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboDanhMuc.DataSource = dt;
                cboDanhMuc.DisplayMember = "TenDanhMuc";
                cboDanhMuc.ValueMember = "MaDanhMuc";
            }
        }

        private void LoadBan()
        {
            flpBan.Controls.Clear();

            using (SqlConnection conn = Db.TaoKetNoi())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT MaBan, TenBan, TrangThai FROM BanAn ORDER BY MaBan", conn))
            {
                conn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        int maBan = Convert.ToInt32(rd["MaBan"]);
                        string tenBan = rd["TenBan"].ToString();
                        string trangThai = rd["TrangThai"].ToString();

                        Button btn = new Button
                        {
                            Text = tenBan + Environment.NewLine + trangThai,
                            Width = 105,
                            Height = 70,
                            Tag = maBan,
                            BackColor = trangThai == "Trống"
                                ? Color.LightGreen : Color.LightSalmon
                        };

                        btn.Click += (s, e) => ChonBan(maBan);
                        flpBan.Controls.Add(btn);
                    }
                }
            }
        }

        private void ChonBan(int maBan)
        {
            maBanDangChon = maBan;
            lblBan.Text = "Bàn " + maBan;

            using (SqlConnection conn = Db.TaoKetNoi())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT TOP 1 MaHoaDon
                  FROM HoaDon
                  WHERE MaBan=@MaBan
                    AND TrangThai=N'Chưa thanh toán'
                  ORDER BY MaHoaDon DESC", conn))
            {
                cmd.Parameters.Add("@MaBan", SqlDbType.Int).Value = maBan;
                conn.Open();

                object kq = cmd.ExecuteScalar();
                maHoaDon = kq == null || kq == DBNull.Value
                    ? 0 : Convert.ToInt32(kq);
            }

            LoadHoaDon();
            LoadBan();
        }

        private void LoadMon()
        {
            if (cboDanhMuc.SelectedValue == null ||
                cboDanhMuc.SelectedValue is DataRowView)
                return;

            flpMon.Controls.Clear();
            int maDanhMuc = Convert.ToInt32(cboDanhMuc.SelectedValue);

            using (SqlConnection conn = Db.TaoKetNoi())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT MaMon, TenMon, DonGia
                  FROM MonAn
                  WHERE MaDanhMuc=@MaDanhMuc
                  ORDER BY TenMon", conn))
            {
                cmd.Parameters.Add("@MaDanhMuc", SqlDbType.Int).Value = maDanhMuc;
                conn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        int maMon = Convert.ToInt32(rd["MaMon"]);
                        string tenMon = rd["TenMon"].ToString();
                        decimal gia = Convert.ToDecimal(rd["DonGia"]);

                        Button btn = new Button
                        {
                            Text = tenMon + Environment.NewLine + gia.ToString("N0") + " đ",
                            Width = 135,
                            Height = 60,
                            Tag = maMon,
                            BackColor = Color.LemonChiffon
                        };

                        btn.Click += (s, e) => ThemMon(maMon);
                        flpMon.Controls.Add(btn);
                    }
                }
            }
        }

        private void ThemMon(int maMon)
        {
            int soLuong = (int)nudSoLuong.Value;

            using (SqlConnection conn = Db.TaoKetNoi())
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        if (maHoaDon == 0)
                        {
                            using (SqlCommand cmd = new SqlCommand(
                                @"INSERT INTO HoaDon(MaBan,TongTien,TrangThai)
                                  VALUES(@MaBan,0,N'Chưa thanh toán');
                                  SELECT CAST(SCOPE_IDENTITY() AS INT);",
                                conn, tran))
                            {
                                cmd.Parameters.Add("@MaBan", SqlDbType.Int)
                                    .Value = maBanDangChon;
                                maHoaDon = Convert.ToInt32(cmd.ExecuteScalar());
                            }
                        }

                        using (SqlCommand cmd = new SqlCommand(
                            @"IF EXISTS (
                                SELECT 1 FROM ChiTietHoaDon
                                WHERE MaHoaDon=@MaHoaDon AND MaMon=@MaMon
                              )
                              BEGIN
                                UPDATE ChiTietHoaDon
                                SET SoLuong=SoLuong+@SoLuong
                                WHERE MaHoaDon=@MaHoaDon AND MaMon=@MaMon
                              END
                              ELSE
                              BEGIN
                                INSERT INTO ChiTietHoaDon(MaHoaDon,MaMon,SoLuong,DonGia)
                                SELECT @MaHoaDon,MaMon,@SoLuong,DonGia
                                FROM MonAn WHERE MaMon=@MaMon
                              END",
                            conn, tran))
                        {
                            cmd.Parameters.Add("@MaHoaDon", SqlDbType.Int).Value = maHoaDon;
                            cmd.Parameters.Add("@MaMon", SqlDbType.Int).Value = maMon;
                            cmd.Parameters.Add("@SoLuong", SqlDbType.Int).Value = soLuong;
                            cmd.ExecuteNonQuery();
                        }

                        using (SqlCommand cmd = new SqlCommand(
                            @"UPDATE HoaDon
                              SET TongTien=(
                                  SELECT ISNULL(SUM(SoLuong*DonGia),0)
                                  FROM ChiTietHoaDon WHERE MaHoaDon=@MaHoaDon
                              )
                              WHERE MaHoaDon=@MaHoaDon;

                              UPDATE BanAn SET TrangThai=N'Có khách'
                              WHERE MaBan=@MaBan;",
                            conn, tran))
                        {
                            cmd.Parameters.Add("@MaHoaDon", SqlDbType.Int).Value = maHoaDon;
                            cmd.Parameters.Add("@MaBan", SqlDbType.Int).Value = maBanDangChon;
                            cmd.ExecuteNonQuery();
                        }

                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        MessageBox.Show("Lỗi thêm món: " + ex.Message);
                        return;
                    }
                }
            }

            LoadHoaDon();
            LoadBan();
        }

        private void LoadHoaDon()
        {
            DataTable dt = new DataTable();

            if (maHoaDon == 0)
            {
                dgvHoaDon.DataSource = dt;
                lblTongTien.Text = "Tổng tiền: 0 VNĐ";
                return;
            }

            using (SqlConnection conn = Db.TaoKetNoi())
            using (SqlDataAdapter da = new SqlDataAdapter(
                @"SELECT m.TenMon, c.SoLuong, c.DonGia,
                         c.SoLuong*c.DonGia AS ThanhTien
                  FROM ChiTietHoaDon c
                  JOIN MonAn m ON c.MaMon=m.MaMon
                  WHERE c.MaHoaDon=@MaHoaDon", conn))
            {
                da.SelectCommand.Parameters.Add("@MaHoaDon", SqlDbType.Int).Value = maHoaDon;
                da.Fill(dt);
            }

            dgvHoaDon.DataSource = dt;

            if (dgvHoaDon.Columns.Contains("TenMon"))
                dgvHoaDon.Columns["TenMon"].HeaderText = "Tên món";

            if (dgvHoaDon.Columns.Contains("SoLuong"))
                dgvHoaDon.Columns["SoLuong"].HeaderText = "Số lượng";

            if (dgvHoaDon.Columns.Contains("DonGia"))
            {
                dgvHoaDon.Columns["DonGia"].HeaderText = "Đơn giá";
                dgvHoaDon.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            }

            if (dgvHoaDon.Columns.Contains("ThanhTien"))
            {
                dgvHoaDon.Columns["ThanhTien"].HeaderText = "Thành tiền";
                dgvHoaDon.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            }

            using (SqlConnection conn = Db.TaoKetNoi())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT TongTien FROM HoaDon WHERE MaHoaDon=@MaHoaDon", conn))
            {
                cmd.Parameters.Add("@MaHoaDon", SqlDbType.Int).Value = maHoaDon;
                conn.Open();

                object kq = cmd.ExecuteScalar();
                decimal tong = kq == null || kq == DBNull.Value
                    ? 0 : Convert.ToDecimal(kq);

                lblTongTien.Text = "Tổng tiền: " + tong.ToString("N0") + " VNĐ";
            }
        }

        private void ThanhToan()
        {
            if (maHoaDon == 0)
            {
                MessageBox.Show("Bàn chưa có hóa đơn.");
                return;
            }

            if (MessageBox.Show("Xác nhận thanh toán hóa đơn?",
                "Thanh toán", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            using (SqlConnection conn = Db.TaoKetNoi())
            {
                conn.Open();

                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(
                            @"UPDATE HoaDon
                              SET TrangThai=N'Đã thanh toán'
                              WHERE MaHoaDon=@MaHoaDon
                                AND TrangThai=N'Chưa thanh toán';

                              UPDATE BanAn SET TrangThai=N'Trống'
                              WHERE MaBan=@MaBan;",
                            conn, tran))
                        {
                            cmd.Parameters.Add("@MaHoaDon", SqlDbType.Int).Value = maHoaDon;
                            cmd.Parameters.Add("@MaBan", SqlDbType.Int).Value = maBanDangChon;
                            cmd.ExecuteNonQuery();
                        }

                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        MessageBox.Show("Lỗi thanh toán: " + ex.Message);
                        return;
                    }
                }
            }

            MessageBox.Show("Thanh toán thành công!");
            ChonBan(maBanDangChon);
        }

        private void ChuyenBan()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = Db.TaoKetNoi())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT MaBan,TenBan FROM BanAn
                  WHERE MaBan<>@MaBan AND TrangThai=N'Trống'
                  ORDER BY MaBan", conn))
            {
                cmd.Parameters.Add("@MaBan", SqlDbType.Int).Value = maBanDangChon;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(dt);
            }

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có bàn trống.");
                return;
            }

            using (Form f = new Form())
            {
                f.Text = "Chọn bàn cần chuyển";
                f.Size = new Size(320, 150);
                f.StartPosition = FormStartPosition.CenterParent;
                f.FormBorderStyle = FormBorderStyle.FixedDialog;
                f.MaximizeBox = false;
                f.MinimizeBox = false;

                ComboBox cbo = new ComboBox
                {
                    Left = 15,
                    Top = 15,
                    Width = 270,
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    DataSource = dt,
                    DisplayMember = "TenBan",
                    ValueMember = "MaBan"
                };

                Button btn = new Button
                {
                    Text = "Xác nhận",
                    Left = 15,
                    Top = 55,
                    Width = 100
                };

                btn.Click += (s, e) =>
                {
                    if (maHoaDon == 0)
                    {
                        MessageBox.Show("Bàn hiện tại chưa có hóa đơn.");
                        return;
                    }

                    int banMoi = Convert.ToInt32(cbo.SelectedValue);

                    using (SqlConnection conn = Db.TaoKetNoi())
                    {
                        conn.Open();

                        using (SqlTransaction tran = conn.BeginTransaction())
                        {
                            try
                            {
                                using (SqlCommand cmd = new SqlCommand(
                                    @"IF EXISTS (
                                        SELECT 1 FROM HoaDon
                                        WHERE MaBan=@BanMoi
                                        AND TrangThai=N'Chưa thanh toán'
                                      )
                                      THROW 50001, N'Bàn đích đã có hóa đơn.', 1;

                                      UPDATE HoaDon SET MaBan=@BanMoi
                                      WHERE MaHoaDon=@MaHoaDon
                                      AND TrangThai=N'Chưa thanh toán';

                                      UPDATE BanAn SET TrangThai=N'Trống'
                                      WHERE MaBan=@BanCu;

                                      UPDATE BanAn SET TrangThai=N'Có khách'
                                      WHERE MaBan=@BanMoi;",
                                    conn, tran))
                                {
                                    cmd.Parameters.Add("@BanMoi", SqlDbType.Int).Value = banMoi;
                                    cmd.Parameters.Add("@MaHoaDon", SqlDbType.Int).Value = maHoaDon;
                                    cmd.Parameters.Add("@BanCu", SqlDbType.Int).Value = maBanDangChon;
                                    cmd.ExecuteNonQuery();
                                }

                                tran.Commit();
                            }
                            catch (Exception ex)
                            {
                                tran.Rollback();
                                MessageBox.Show("Lỗi chuyển bàn: " + ex.Message);
                                return;
                            }
                        }
                    }

                    f.DialogResult = DialogResult.OK;
                    f.Close();
                };

                f.Controls.Add(cbo);
                f.Controls.Add(btn);

                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    maHoaDon = 0;
                    ChonBan(maBanDangChon);
                }
            }
        }
    }
}
