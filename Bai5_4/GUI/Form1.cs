using System;
using System.Data;
using System.Windows.Forms;
using Bai5_4.BUS;
using Bai5_4.DTO;

namespace Bai5_4.GUI
{
    public partial class Form1 : Form
    {
        private readonly PhongBUS phongBUS = new PhongBUS();
        private readonly DichVuBUS dichVuBUS = new DichVuBUS();
        private readonly HoaDonBUS hoaDonBUS = new HoaDonBUS();

        private DataTable? dsPhong;

        public Form1()
        {
            InitializeComponent();

            Load += Form1_Load;
            cboLoaiPhong.SelectedIndexChanged += cboLoaiPhong_SelectedIndexChanged;
            cboTrangThai.SelectedIndexChanged += cboTrangThai_SelectedIndexChanged;
            btnLamMoi.Click += btnLamMoi_Click;
            dgvPhong.SelectionChanged += dgvPhong_SelectionChanged;
            btnNhanPhong.Click += btnNhanPhong_Click;
            btnThemDichVu.Click += btnThemDichVu_Click;
            btnTraPhong.Click += btnTraPhong_Click;
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            try
            {
                NapDanhSachPhong();
                NapDanhSachDichVu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải dữ liệu.\n" + ex.Message,
                    "Lỗi cơ sở dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void NapDanhSachPhong()
        {
            dsPhong = phongBUS.LayDanhSachPhong();
            dgvPhong.DataSource = null;
            dgvPhong.DataSource = dsPhong;

            if (dgvPhong.Columns["SoPhong"] != null)
                dgvPhong.Columns["SoPhong"]!.HeaderText = "Số phòng";

            if (dgvPhong.Columns["LoaiPhong"] != null)
                dgvPhong.Columns["LoaiPhong"]!.HeaderText = "Loại phòng";

            if (dgvPhong.Columns["DonGia"] != null)
            {
                dgvPhong.Columns["DonGia"]!.HeaderText = "Đơn giá/ngày";
                dgvPhong.Columns["DonGia"]!.DefaultCellStyle.Format = "N0";
            }

            if (dgvPhong.Columns["TrangThai"] != null)
                dgvPhong.Columns["TrangThai"]!.HeaderText = "Trạng thái";

            dgvPhong.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            LocPhong();
            CapNhatThongKe();
        }

        private void NapDanhSachDichVu()
        {
            DataTable dt = dichVuBUS.LayDanhSachDichVu();

            cboDichVu.DataSource = dt;
            cboDichVu.DisplayMember = "TenDichVu";
            cboDichVu.ValueMember = "MaDichVu";
            cboDichVu.SelectedIndex = -1;
        }

        private void LocPhong()
        {
            if (dsPhong == null)
                return;

            string loai = cboLoaiPhong.Text;
            string trangThai = cboTrangThai.Text;
            string dieuKien = "";

            if (loai != "Tất cả" && loai != "")
            {
                dieuKien = "LoaiPhong = '" +
                    loai.Replace("'", "''") + "'";
            }

            if (trangThai != "Tất cả" && trangThai != "")
            {
                if (dieuKien != "")
                    dieuKien += " AND ";

                dieuKien += "TrangThai = '" +
                    trangThai.Replace("'", "''") + "'";
            }

            DataView view = dsPhong.DefaultView;
            view.RowFilter = dieuKien;
            dgvPhong.DataSource = view;
        }

        private void CapNhatThongKe()
        {
            if (dsPhong == null)
                return;

            int tong = dsPhong.Rows.Count;
            int trong = 0;
            int dangSuDung = 0;

            foreach (DataRow row in dsPhong.Rows)
            {
                string trangThai = row["TrangThai"].ToString() ?? "";

                if (trangThai == "Trống")
                    trong++;
                else if (trangThai == "Đang sử dụng")
                    dangSuDung++;
            }

            lblTongPhong.Text = tong.ToString();
            lblPhongTrong.Text = trong.ToString();
            lblPhongDangSuDung.Text = dangSuDung.ToString();
        }

        private void cboLoaiPhong_SelectedIndexChanged(
            object? sender, EventArgs e)
        {
            LocPhong();
        }

        private void cboTrangThai_SelectedIndexChanged(
            object? sender, EventArgs e)
        {
            LocPhong();
        }

        private void btnLamMoi_Click(object? sender, EventArgs e)
        {
            try
            {
                cboLoaiPhong.SelectedIndex = 0;
                cboTrangThai.SelectedIndex = 0;
                NapDanhSachPhong();
                NapDanhSachDichVu();
            }
            catch (Exception ex)
            {
                BaoLoi(ex.Message);
            }
        }

        private void dgvPhong_SelectionChanged(
            object? sender, EventArgs e)
        {
            if (dgvPhong.CurrentRow == null ||
                dgvPhong.CurrentRow.Cells["SoPhong"].Value == null)
                return;

            txtSoPhong.Text =
                dgvPhong.CurrentRow.Cells["SoPhong"].Value.ToString() ?? "";
        }

        private void btnNhanPhong_Click(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSoPhong.Text))
                {
                    BaoLoi("Vui lòng chọn phòng.");
                    return;
                }

                KhachHangDTO kh = new KhachHangDTO
                {
                    CCCD = txtCCCD.Text.Trim(),
                    HoTen = txtHoTen.Text.Trim(),
                    SDT = txtSDT.Text.Trim()
                };

                hoaDonBUS.NhanPhong(txtSoPhong.Text.Trim(), kh);

                MessageBox.Show(
                    "Nhận phòng thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                XoaThongTinKhach();
                NapDanhSachPhong();
            }
            catch (Exception ex)
            {
                BaoLoi(ex.Message);
            }
        }

        private void btnThemDichVu_Click(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSoPhong.Text))
                {
                    BaoLoi("Vui lòng chọn phòng.");
                    return;
                }

                if (cboDichVu.SelectedValue == null)
                {
                    BaoLoi("Vui lòng chọn dịch vụ.");
                    return;
                }

                hoaDonBUS.ThemDichVu(
                    txtSoPhong.Text.Trim(),
                    Convert.ToInt32(cboDichVu.SelectedValue),
                    (int)nudSoLuong.Value);

                MessageBox.Show(
                    "Thêm dịch vụ thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                BaoLoi(ex.Message);
            }
        }

        private void btnTraPhong_Click(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSoPhong.Text))
                {
                    BaoLoi("Vui lòng chọn phòng.");
                    return;
                }

                DialogResult ketQua = MessageBox.Show(
                    "Bạn có chắc muốn trả phòng " + txtSoPhong.Text + "?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (ketQua != DialogResult.Yes)
                    return;

                decimal tongTien = hoaDonBUS.TraPhong(txtSoPhong.Text.Trim());

                lblDoanhThu.Text = tongTien.ToString("N0") + " VNĐ";

                MessageBox.Show(
                    "Trả phòng thành công!\nTổng tiền: " +
                    tongTien.ToString("N0") + " VNĐ",
                    "Hóa đơn",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                XoaThongTinKhach();
                NapDanhSachPhong();
            }
            catch (Exception ex)
            {
                BaoLoi(ex.Message);
            }
        }

        private void XoaThongTinKhach()
        {
            txtCCCD.Clear();
            txtHoTen.Clear();
            txtSDT.Clear();
            nudSoLuong.Value = 1;
            cboDichVu.SelectedIndex = -1;
        }

        private void BaoLoi(string noiDung)
        {
            MessageBox.Show(
                noiDung,
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }
}