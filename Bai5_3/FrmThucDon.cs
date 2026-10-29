
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Bai5_3
{
    public class FrmThucDon : Form
    {
        TabControl tabs;
        DataGridView dgvDanhMuc, dgvMon;
        TextBox txtTenDanhMuc, txtTenMon, txtDonGia;
        ComboBox cboDanhMuc;

        public FrmThucDon()
        {
            Text = "Quản lý thực đơn";
            Size = new Size(900, 600);
            StartPosition = FormStartPosition.CenterParent;
            KhoiTaoGiaoDien();
            LoadDanhMuc();
            LoadMon();
        }

        void KhoiTaoGiaoDien()
        {
            tabs = new TabControl { Dock = DockStyle.Fill };
            Controls.Add(tabs);

            TabPage tabDanhMuc = new TabPage("Danh mục");
            TabPage tabMon = new TabPage("Món ăn");
            tabs.TabPages.Add(tabDanhMuc);
            tabs.TabPages.Add(tabMon);

            dgvDanhMuc = new DataGridView
            {
                Dock = DockStyle.Top,
                Height = 300,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            txtTenDanhMuc = new TextBox
            {
                Left = 15,
                Top = 320,
                Width = 250
            };

            Button btnThemDM = new Button
            {
                Text = "Thêm",
                Left = 280,
                Top = 318,
                Width = 80
            };
            btnThemDM.Click += (s, e) => ThemDanhMuc();

            Button btnSuaDM = new Button
            {
                Text = "Sửa",
                Left = 370,
                Top = 318,
                Width = 80
            };
            btnSuaDM.Click += (s, e) => SuaDanhMuc();

            Button btnXoaDM = new Button
            {
                Text = "Xóa",
                Left = 460,
                Top = 318,
                Width = 80
            };
            btnXoaDM.Click += (s, e) => XoaDanhMuc();

            dgvDanhMuc.SelectionChanged += (s, e) =>
            {
                if (dgvDanhMuc.CurrentRow != null &&
                    dgvDanhMuc.CurrentRow.Cells["TenDanhMuc"].Value != null)
                {
                    txtTenDanhMuc.Text =
                        dgvDanhMuc.CurrentRow.Cells["TenDanhMuc"].Value.ToString();
                }
            };

            tabDanhMuc.Controls.Add(dgvDanhMuc);
            tabDanhMuc.Controls.Add(txtTenDanhMuc);
            tabDanhMuc.Controls.Add(btnThemDM);
            tabDanhMuc.Controls.Add(btnSuaDM);
            tabDanhMuc.Controls.Add(btnXoaDM);

            dgvMon = new DataGridView
            {
                Dock = DockStyle.Top,
                Height = 260,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            Label lblTen = new Label
            {
                Text = "Tên món",
                Left = 15,
                Top = 275,
                Width = 100
            };

            txtTenMon = new TextBox
            {
                Left = 120,
                Top = 270,
                Width = 220
            };

            Label lblDM = new Label
            {
                Text = "Danh mục",
                Left = 360,
                Top = 275,
                Width = 100
            };

            cboDanhMuc = new ComboBox
            {
                Left = 460,
                Top = 270,
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            Label lblGia = new Label
            {
                Text = "Đơn giá",
                Left = 15,
                Top = 315,
                Width = 100
            };

            txtDonGia = new TextBox
            {
                Left = 120,
                Top = 310,
                Width = 220
            };

            Button btnThemMon = new Button
            {
                Text = "Thêm",
                Left = 360,
                Top = 310,
                Width = 80
            };
            btnThemMon.Click += (s, e) => ThemMon();

            Button btnSuaMon = new Button
            {
                Text = "Sửa",
                Left = 450,
                Top = 310,
                Width = 80
            };
            btnSuaMon.Click += (s, e) => SuaMon();

            Button btnXoaMon = new Button
            {
                Text = "Xóa",
                Left = 540,
                Top = 310,
                Width = 80
            };
            btnXoaMon.Click += (s, e) => XoaMon();

            dgvMon.SelectionChanged += (s, e) => ChonMon();

            tabMon.Controls.Add(dgvMon);
            tabMon.Controls.Add(lblTen);
            tabMon.Controls.Add(txtTenMon);
            tabMon.Controls.Add(lblDM);
            tabMon.Controls.Add(cboDanhMuc);
            tabMon.Controls.Add(lblGia);
            tabMon.Controls.Add(txtDonGia);
            tabMon.Controls.Add(btnThemMon);
            tabMon.Controls.Add(btnSuaMon);
            tabMon.Controls.Add(btnXoaMon);
        }

        void LoadDanhMuc()
        {
            using (SqlConnection conn = Db.TaoKetNoi())
            using (SqlDataAdapter da = new SqlDataAdapter(
                "SELECT MaDanhMuc, TenDanhMuc FROM DanhMuc ORDER BY MaDanhMuc", conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvDanhMuc.DataSource = dt;

                if (dgvDanhMuc.Columns.Count > 0)
                {
                    dgvDanhMuc.Columns["MaDanhMuc"].HeaderText = "Mã danh mục";
                    dgvDanhMuc.Columns["TenDanhMuc"].HeaderText = "Tên danh mục";
                }

                cboDanhMuc.DataSource = dt.Copy();
                cboDanhMuc.DisplayMember = "TenDanhMuc";
                cboDanhMuc.ValueMember = "MaDanhMuc";
            }
        }

        void LoadMon()
        {
            using (SqlConnection conn = Db.TaoKetNoi())
            using (SqlDataAdapter da = new SqlDataAdapter(
                @"SELECT m.MaMon, m.TenMon, m.MaDanhMuc,
                         d.TenDanhMuc, m.DonGia
                  FROM MonAn m
                  JOIN DanhMuc d ON m.MaDanhMuc=d.MaDanhMuc
                  ORDER BY m.MaMon", conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvMon.DataSource = dt;

                if (dgvMon.Columns.Count > 0)
                {
                    dgvMon.Columns["MaMon"].HeaderText = "Mã món";
                    dgvMon.Columns["TenMon"].HeaderText = "Tên món";
                    dgvMon.Columns["MaDanhMuc"].Visible = false;
                    dgvMon.Columns["TenDanhMuc"].HeaderText = "Danh mục";
                    dgvMon.Columns["DonGia"].HeaderText = "Đơn giá";
                    dgvMon.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                }
            }
        }

        void ThemDanhMuc()
        {
            string ten = txtTenDanhMuc.Text.Trim();

            if (ten == "")
            {
                MessageBox.Show("Vui lòng nhập tên danh mục.");
                return;
            }

            using (SqlConnection conn = Db.TaoKetNoi())
            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO DanhMuc(TenDanhMuc) VALUES(@Ten)", conn))
            {
                cmd.Parameters.AddWithValue("@Ten", ten);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            txtTenDanhMuc.Clear();
            LoadDanhMuc();
            LoadMon();
        }

        void SuaDanhMuc()
        {
            if (dgvDanhMuc.CurrentRow == null)
                return;

            int ma = Convert.ToInt32(
                dgvDanhMuc.CurrentRow.Cells["MaDanhMuc"].Value);
            string ten = txtTenDanhMuc.Text.Trim();

            if (ten == "")
            {
                MessageBox.Show("Vui lòng nhập tên danh mục.");
                return;
            }

            using (SqlConnection conn = Db.TaoKetNoi())
            using (SqlCommand cmd = new SqlCommand(
                "UPDATE DanhMuc SET TenDanhMuc=@Ten WHERE MaDanhMuc=@Ma", conn))
            {
                cmd.Parameters.AddWithValue("@Ten", ten);
                cmd.Parameters.AddWithValue("@Ma", ma);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadDanhMuc();
            LoadMon();
        }

        void XoaDanhMuc()
        {
            if (dgvDanhMuc.CurrentRow == null)
                return;

            int ma = Convert.ToInt32(
                dgvDanhMuc.CurrentRow.Cells["MaDanhMuc"].Value);

            using (SqlConnection conn = Db.TaoKetNoi())
            using (SqlCommand cmd = new SqlCommand(
                "DELETE FROM DanhMuc WHERE MaDanhMuc=@Ma", conn))
            {
                cmd.Parameters.AddWithValue("@Ma", ma);
                conn.Open();

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    MessageBox.Show(
                        "Không thể xóa danh mục đang có món ăn. Hãy xóa các món trước.");
                }
            }

            LoadDanhMuc();
            LoadMon();
        }

        void ChonMon()
        {
            if (dgvMon.CurrentRow == null ||
                dgvMon.CurrentRow.Cells["MaMon"].Value == null)
                return;

            txtTenMon.Text =
                dgvMon.CurrentRow.Cells["TenMon"].Value.ToString();

            txtDonGia.Text =
                dgvMon.CurrentRow.Cells["DonGia"].Value.ToString();

            cboDanhMuc.SelectedValue =
                dgvMon.CurrentRow.Cells["MaDanhMuc"].Value;
        }

        bool LayThongTinMon(out string ten, out int maDanhMuc, out decimal gia)
        {
            ten = txtTenMon.Text.Trim();
            maDanhMuc = 0;
            gia = 0;

            if (ten == "")
            {
                MessageBox.Show("Vui lòng nhập tên món.");
                return false;
            }

            if (cboDanhMuc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục.");
                return false;
            }

            if (!decimal.TryParse(txtDonGia.Text.Trim(), out gia) || gia < 0)
            {
                MessageBox.Show("Đơn giá phải là số không âm.");
                return false;
            }

            maDanhMuc = Convert.ToInt32(cboDanhMuc.SelectedValue);
            return true;
        }

        void ThemMon()
        {
            if (!LayThongTinMon(out string ten, out int maDM, out decimal gia))
                return;

            using (SqlConnection conn = Db.TaoKetNoi())
            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO MonAn(TenMon,MaDanhMuc,DonGia)
                  VALUES(@Ten,@MaDM,@Gia)", conn))
            {
                cmd.Parameters.AddWithValue("@Ten", ten);
                cmd.Parameters.AddWithValue("@MaDM", maDM);
                cmd.Parameters.AddWithValue("@Gia", gia);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadMon();
            MessageBox.Show("Đã thêm món ăn.");
        }

        void SuaMon()
        {
            if (dgvMon.CurrentRow == null)
                return;

            if (!LayThongTinMon(out string ten, out int maDM, out decimal gia))
                return;

            int ma = Convert.ToInt32(dgvMon.CurrentRow.Cells["MaMon"].Value);

            using (SqlConnection conn = Db.TaoKetNoi())
            using (SqlCommand cmd = new SqlCommand(
                @"UPDATE MonAn
                  SET TenMon=@Ten, MaDanhMuc=@MaDM, DonGia=@Gia
                  WHERE MaMon=@Ma", conn))
            {
                cmd.Parameters.AddWithValue("@Ten", ten);
                cmd.Parameters.AddWithValue("@MaDM", maDM);
                cmd.Parameters.AddWithValue("@Gia", gia);
                cmd.Parameters.AddWithValue("@Ma", ma);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadMon();
            MessageBox.Show("Đã cập nhật món ăn.");
        }

        void XoaMon()
        {
            if (dgvMon.CurrentRow == null)
                return;

            int ma = Convert.ToInt32(dgvMon.CurrentRow.Cells["MaMon"].Value);

            if (MessageBox.Show("Bạn có chắc muốn xóa món này?",
                "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            using (SqlConnection conn = Db.TaoKetNoi())
            using (SqlCommand cmd = new SqlCommand(
                "DELETE FROM MonAn WHERE MaMon=@Ma", conn))
            {
                cmd.Parameters.AddWithValue("@Ma", ma);
                conn.Open();

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    MessageBox.Show(
                        "Không thể xóa món đã xuất hiện trong hóa đơn.");
                }
            }

            LoadMon();
        }
    }
}
