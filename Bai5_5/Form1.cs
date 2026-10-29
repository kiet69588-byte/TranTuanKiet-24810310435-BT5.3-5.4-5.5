using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Bai5_5
{
    public partial class Form1 : Form
    {
        private readonly DAL dal = new DAL();
        private readonly BUS bus = new BUS();

        private int maVTDangChon = 0;
        private int maNCCDangChon = 0;

        public Form1()
        {
            InitializeComponent();

            Load += Form1_Load;

            dgvVatTu.CellClick += dgvVatTu_CellClick;
            dgvNCC.CellClick += dgvNCC_CellClick;

            btnThemVT.Click += btnThemVT_Click;
            btnSuaVT.Click += btnSuaVT_Click;
            btnXoaVT.Click += btnXoaVT_Click;
            btnLamMoiVT.Click += btnLamMoiVT_Click;
            btnTimVT.Click += btnTimVT_Click;

            btnThemNCC.Click += btnThemNCC_Click;
            btnSuaNCC.Click += btnSuaNCC_Click;
            btnXoaNCC.Click += btnXoaNCC_Click;
            btnLamMoiNCC.Click += btnLamMoiNCC_Click;

            btnLapPhieu.Click += btnLapPhieu_Click;
            btnTaiLichSu.Click += btnTaiLichSu_Click;
            btnTaiBaoCao.Click += btnTaiBaoCao_Click;

            cboVatTu.SelectedIndexChanged += cboVatTu_SelectedIndexChanged;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                TaiDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải dữ liệu.\n\n" + ex.Message
                    + "\n\nHãy kiểm tra SQL Server LocalDB và cơ sở dữ liệu InventoryDB.",
                    "Lỗi kết nối",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void TaiDuLieu()
        {
            TaiVatTu();
            TaiNCC();
            TaiComboVatTu();
            TaiLichSu();
            TaiBaoCao();
        }

        private void TaiVatTu()
        {
            dgvVatTu.DataSource = dal.LayDanhSachVatTu(txtTimVT.Text.Trim());

            if (dgvVatTu.Columns["MaVT"] != null)
                dgvVatTu.Columns["MaVT"].HeaderText = "Mã vật tư";

            if (dgvVatTu.Columns["TenVT"] != null)
                dgvVatTu.Columns["TenVT"].HeaderText = "Tên vật tư";

            if (dgvVatTu.Columns["DonViTinh"] != null)
                dgvVatTu.Columns["DonViTinh"].HeaderText = "Đơn vị tính";

            if (dgvVatTu.Columns["SoLuongTon"] != null)
                dgvVatTu.Columns["SoLuongTon"].HeaderText = "Số lượng tồn";

            if (dgvVatTu.Columns["DonGia"] != null)
                dgvVatTu.Columns["DonGia"].HeaderText = "Đơn giá";

            if (dgvVatTu.Columns["MaNCC"] != null)
                dgvVatTu.Columns["MaNCC"].Visible = false;

            if (dgvVatTu.Columns["TenNCC"] != null)
                dgvVatTu.Columns["TenNCC"].HeaderText = "Nhà cung cấp";
        }

        private void TaiNCC()
        {
            dgvNCC.DataSource = dal.LayDanhSachNCC();

            if (dgvNCC.Columns["MaNCC"] != null)
                dgvNCC.Columns["MaNCC"].HeaderText = "Mã NCC";

            if (dgvNCC.Columns["TenNCC"] != null)
                dgvNCC.Columns["TenNCC"].HeaderText = "Tên nhà cung cấp";

            if (dgvNCC.Columns["DienThoai"] != null)
                dgvNCC.Columns["DienThoai"].HeaderText = "Điện thoại";

            if (dgvNCC.Columns["DiaChi"] != null)
                dgvNCC.Columns["DiaChi"].HeaderText = "Địa chỉ";
        }

        private void TaiComboVatTu()
        {
            var vatTu = dal.LayDanhSachVatTu();

            cboVatTu.DataSource = null;
            cboVatTu.DisplayMember = "TenVT";
            cboVatTu.ValueMember = "MaVT";
            cboVatTu.DataSource = vatTu;

            cboNCC.DataSource = null;
            cboNCC.DisplayMember = "TenNCC";
            cboNCC.ValueMember = "MaNCC";
            cboNCC.DataSource = dal.LayDanhSachNCC();

            CapNhatTonKho();
        }

        private void TaiLichSu()
        {
            dgvPhieu.DataSource = dal.LayLichSuPhieu();

            if (dgvPhieu.Columns["MaPhieu"] != null)
                dgvPhieu.Columns["MaPhieu"].HeaderText = "Mã phiếu";

            if (dgvPhieu.Columns["LoaiPhieu"] != null)
                dgvPhieu.Columns["LoaiPhieu"].HeaderText = "Loại phiếu";

            if (dgvPhieu.Columns["NgayLap"] != null)
                dgvPhieu.Columns["NgayLap"].HeaderText = "Ngày lập";

            if (dgvPhieu.Columns["TenVT"] != null)
                dgvPhieu.Columns["TenVT"].HeaderText = "Vật tư";

            if (dgvPhieu.Columns["SoLuong"] != null)
                dgvPhieu.Columns["SoLuong"].HeaderText = "Số lượng";

            if (dgvPhieu.Columns["DonGia"] != null)
                dgvPhieu.Columns["DonGia"].HeaderText = "Đơn giá";

            if (dgvPhieu.Columns["ThanhTien"] != null)
                dgvPhieu.Columns["ThanhTien"].HeaderText = "Thành tiền";

            if (dgvPhieu.Columns["GhiChu"] != null)
                dgvPhieu.Columns["GhiChu"].HeaderText = "Ghi chú";
        }

        private void TaiBaoCao()
        {
            dgvBaoCao.DataSource = dal.LayBaoCaoTonKho();

            if (dgvBaoCao.Columns["MaVT"] != null)
                dgvBaoCao.Columns["MaVT"].HeaderText = "Mã vật tư";

            if (dgvBaoCao.Columns["TenVT"] != null)
                dgvBaoCao.Columns["TenVT"].HeaderText = "Tên vật tư";

            if (dgvBaoCao.Columns["DonViTinh"] != null)
                dgvBaoCao.Columns["DonViTinh"].HeaderText = "Đơn vị tính";

            if (dgvBaoCao.Columns["SoLuongTon"] != null)
                dgvBaoCao.Columns["SoLuongTon"].HeaderText = "Tồn kho";

            if (dgvBaoCao.Columns["DonGia"] != null)
                dgvBaoCao.Columns["DonGia"].HeaderText = "Đơn giá";

            if (dgvBaoCao.Columns["GiaTriTonKho"] != null)
                dgvBaoCao.Columns["GiaTriTonKho"].HeaderText = "Giá trị tồn";

            if (dgvBaoCao.Columns["TenNCC"] != null)
                dgvBaoCao.Columns["TenNCC"].HeaderText = "Nhà cung cấp";
        }

        private bool DocSoThapPhan(string text, out decimal giaTri)
        {
            return decimal.TryParse(
                text.Trim(),
                NumberStyles.Number,
                CultureInfo.CurrentCulture,
                out giaTri)
                ||
                decimal.TryParse(
                    text.Trim(),
                    NumberStyles.Number,
                    CultureInfo.InvariantCulture,
                    out giaTri);
        }

        private int LayMaNCC()
        {
            if (cboNCC.SelectedValue == null)
                return 0;

            if (cboNCC.SelectedValue is int ma)
                return ma;

            return int.TryParse(
                cboNCC.SelectedValue.ToString(), out ma) ? ma : 0;
        }

        private int LayMaVatTuTrongCombo()
        {
            if (cboVatTu.SelectedValue == null)
                return 0;

            if (cboVatTu.SelectedValue is int ma)
                return ma;

            return int.TryParse(
                cboVatTu.SelectedValue.ToString(), out ma) ? ma : 0;
        }

        private void dgvVatTu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvVatTu.Rows[e.RowIndex];

            maVTDangChon = Convert.ToInt32(row.Cells["MaVT"].Value);
            txtTenVT.Text = row.Cells["TenVT"].Value?.ToString();
            txtDonVi.Text = row.Cells["DonViTinh"].Value?.ToString();
            txtDonGia.Text = row.Cells["DonGia"].Value?.ToString();

            object maNCC = row.Cells["MaNCC"].Value;

            if (maNCC != null && maNCC != DBNull.Value)
                cboNCC.SelectedValue = Convert.ToInt32(maNCC);
            else
                cboNCC.SelectedIndex = -1;
        }

        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvNCC.Rows[e.RowIndex];

            maNCCDangChon = Convert.ToInt32(row.Cells["MaNCC"].Value);
            txtTenNCC.Text = row.Cells["TenNCC"].Value?.ToString();
            txtDienThoai.Text = row.Cells["DienThoai"].Value?.ToString();
            txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString();
        }

        private void btnThemVT_Click(object sender, EventArgs e)
        {
            try
            {
                if (!DocSoThapPhan(txtDonGia.Text, out decimal donGia))
                    throw new Exception("Đơn giá phải là số hợp lệ.");

                VatTu vt = new VatTu
                {
                    TenVT = txtTenVT.Text.Trim(),
                    DonViTinh = txtDonVi.Text.Trim(),
                    DonGia = donGia,
                    MaNCC = LayMaNCC() == 0 ? null : LayMaNCC()
                };

                bus.ThemVatTu(vt);

                MessageBox.Show("Thêm vật tư thành công.");

                LamMoiVatTu();
                TaiVatTu();
                TaiComboVatTu();
                TaiBaoCao();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void btnSuaVT_Click(object sender, EventArgs e)
        {
            try
            {
                if (maVTDangChon == 0)
                    throw new Exception("Vui lòng chọn vật tư cần sửa.");

                if (!DocSoThapPhan(txtDonGia.Text, out decimal donGia))
                    throw new Exception("Đơn giá phải là số hợp lệ.");

                VatTu vt = new VatTu
                {
                    MaVT = maVTDangChon,
                    TenVT = txtTenVT.Text.Trim(),
                    DonViTinh = txtDonVi.Text.Trim(),
                    DonGia = donGia,
                    MaNCC = LayMaNCC() == 0 ? null : LayMaNCC()
                };

                bus.SuaVatTu(vt);

                MessageBox.Show("Cập nhật vật tư thành công.");

                LamMoiVatTu();
                TaiVatTu();
                TaiComboVatTu();
                TaiBaoCao();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void btnXoaVT_Click(object sender, EventArgs e)
        {
            try
            {
                if (maVTDangChon == 0)
                    throw new Exception("Vui lòng chọn vật tư cần xóa.");

                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa vật tư này?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                bus.XoaVatTu(maVTDangChon);

                MessageBox.Show("Xóa vật tư thành công.");

                LamMoiVatTu();
                TaiVatTu();
                TaiComboVatTu();
                TaiBaoCao();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void btnLamMoiVT_Click(object sender, EventArgs e)
        {
            LamMoiVatTu();
            TaiVatTu();
        }

        private void LamMoiVatTu()
        {
            maVTDangChon = 0;
            txtTenVT.Clear();
            txtDonVi.Clear();
            txtDonGia.Clear();
            cboNCC.SelectedIndex = -1;
            dgvVatTu.ClearSelection();
        }

        private void btnTimVT_Click(object sender, EventArgs e)
        {
            try
            {
                dgvVatTu.DataSource =
                    dal.LayDanhSachVatTu(txtTimVT.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            try
            {
                NhaCungCap ncc = new NhaCungCap
                {
                    TenNCC = txtTenNCC.Text.Trim(),
                    DienThoai = txtDienThoai.Text.Trim(),
                    DiaChi = txtDiaChi.Text.Trim()
                };

                bus.ThemNCC(ncc);

                MessageBox.Show("Thêm nhà cung cấp thành công.");

                LamMoiNCC();
                TaiNCC();
                TaiComboVatTu();
                TaiVatTu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void btnSuaNCC_Click(object sender, EventArgs e)
        {
            try
            {
                if (maNCCDangChon == 0)
                    throw new Exception("Vui lòng chọn nhà cung cấp cần sửa.");

                NhaCungCap ncc = new NhaCungCap
                {
                    MaNCC = maNCCDangChon,
                    TenNCC = txtTenNCC.Text.Trim(),
                    DienThoai = txtDienThoai.Text.Trim(),
                    DiaChi = txtDiaChi.Text.Trim()
                };

                bus.SuaNCC(ncc);

                MessageBox.Show("Cập nhật nhà cung cấp thành công.");

                LamMoiNCC();
                TaiNCC();
                TaiComboVatTu();
                TaiVatTu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void btnXoaNCC_Click(object sender, EventArgs e)
        {
            try
            {
                if (maNCCDangChon == 0)
                    throw new Exception("Vui lòng chọn nhà cung cấp cần xóa.");

                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa nhà cung cấp này?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                bus.XoaNCC(maNCCDangChon);

                MessageBox.Show("Xóa nhà cung cấp thành công.");

                LamMoiNCC();
                TaiNCC();
                TaiComboVatTu();
                TaiVatTu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void btnLamMoiNCC_Click(object sender, EventArgs e)
        {
            LamMoiNCC();
        }

        private void LamMoiNCC()
        {
            maNCCDangChon = 0;
            txtTenNCC.Clear();
            txtDienThoai.Clear();
            txtDiaChi.Clear();
            dgvNCC.ClearSelection();
        }

        private void cboVatTu_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatTonKho();
        }

        private void CapNhatTonKho()
        {
            if (cboVatTu.SelectedValue == null)
            {
                lblTonKho.Text = "Tồn kho: chưa chọn vật tư";
                return;
            }

            try
            {
                int maVT = LayMaVatTuTrongCombo();

                VatTu vt = dal.LayDanhSachVatTu()
                    .FirstOrDefault(x => x.MaVT == maVT);

                if (vt != null)
                {
                    lblTonKho.Text =
                        "Tồn kho hiện tại: " + vt.SoLuongTon
                        + " " + vt.DonViTinh;

                    txtGiaPhieu.Text = vt.DonGia.ToString();
                }
            }
            catch
            {
                lblTonKho.Text = "Không lấy được thông tin tồn kho.";
            }
        }

        private void btnLapPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                if (!DocSoThapPhan(txtSoLuong.Text, out decimal soLuong))
                    throw new Exception("Số lượng phải là số hợp lệ.");

                if (!DocSoThapPhan(txtGiaPhieu.Text, out decimal donGia))
                    throw new Exception("Đơn giá phải là số hợp lệ.");

                int maVT = LayMaVatTuTrongCombo();

                if (maVT <= 0)
                    throw new Exception("Vui lòng chọn vật tư.");

                bus.TaoPhieuKho(
                    cboLoaiPhieu.Text,
                    maVT,
                    soLuong,
                    donGia,
                    txtGhiChu.Text.Trim());

                MessageBox.Show(
                    "Lập phiếu " + cboLoaiPhieu.Text.ToLower()
                    + " thành công.");

                txtSoLuong.Clear();
                txtGhiChu.Clear();

                TaiVatTu();
                TaiComboVatTu();
                TaiLichSu();
                TaiBaoCao();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Không thể lập phiếu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnTaiLichSu_Click(object sender, EventArgs e)
        {
            try
            {
                TaiLichSu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTaiBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                TaiBaoCao();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}