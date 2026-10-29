using System.Drawing;
using System.Windows.Forms;

namespace Bai5_4.GUI
{
    partial class Form1
    {
        private System.ComponentModel.IContainer? components = null;

        private Panel pnlSidebar = null!;
        private Panel pnlHeader = null!;
        private Panel pnlMain = null!;

        private Label lblTieuDe = null!;
        private Label lblPhuDe = null!;
        private Label lblTongPhong = null!;
        private Label lblPhongTrong = null!;
        private Label lblPhongDangSuDung = null!;
        private Label lblDoanhThu = null!;

        private Label lblLocLoai = null!;
        private Label lblLocTrangThai = null!;
        private Label lblDanhSachPhong = null!;
        private Label lblCCCD = null!;
        private Label lblHoTen = null!;
        private Label lblSDT = null!;
        private Label lblDichVu = null!;
        private Label lblSoLuong = null!;

        private TextBox txtSoPhong = null!;
        private TextBox txtCCCD = null!;
        private TextBox txtHoTen = null!;
        private TextBox txtSDT = null!;

        private ComboBox cboLoaiPhong = null!;
        private ComboBox cboTrangThai = null!;
        private ComboBox cboDichVu = null!;

        private NumericUpDown nudSoLuong = null!;
        private DataGridView dgvPhong = null!;

        private Button btnNhanPhong = null!;
        private Button btnThemDichVu = null!;
        private Button btnTraPhong = null!;
        private Button btnLamMoi = null!;

        private GroupBox gbKhachHang = null!;
        private GroupBox gbDichVu = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlSidebar = new Panel();
            pnlHeader = new Panel();
            pnlMain = new Panel();

            lblTieuDe = new Label();
            lblPhuDe = new Label();

            lblTongPhong = new Label();
            lblPhongTrong = new Label();
            lblPhongDangSuDung = new Label();
            lblDoanhThu = new Label();

            lblLocLoai = new Label();
            lblLocTrangThai = new Label();
            lblDanhSachPhong = new Label();

            lblCCCD = new Label();
            lblHoTen = new Label();
            lblSDT = new Label();
            lblDichVu = new Label();
            lblSoLuong = new Label();

            txtSoPhong = new TextBox();
            txtCCCD = new TextBox();
            txtHoTen = new TextBox();
            txtSDT = new TextBox();

            cboLoaiPhong = new ComboBox();
            cboTrangThai = new ComboBox();
            cboDichVu = new ComboBox();

            nudSoLuong = new NumericUpDown();
            dgvPhong = new DataGridView();

            btnNhanPhong = new Button();
            btnThemDichVu = new Button();
            btnTraPhong = new Button();
            btnLamMoi = new Button();

            gbKhachHang = new GroupBox();
            gbDichVu = new GroupBox();

            SuspendLayout();

            // FORM
            Text = "Hotel Management System";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(1220, 800);
            MinimumSize = new Size(1100, 750);
            BackColor = Color.FromArgb(244, 247, 252);
            Font = new Font("Segoe UI", 9F);

            // SIDEBAR
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Width = 190;
            pnlSidebar.BackColor = Color.FromArgb(25, 39, 65);

            Label lblLogo = new Label();
            lblLogo.Text = "HOTEL";
            lblLogo.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(25, 30);
            lblLogo.Size = new Size(150, 50);

            Label lblMenu = new Label();
            lblMenu.Text = "QUẢN LÝ KHÁCH SẠN";
            lblMenu.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMenu.ForeColor = Color.LightSteelBlue;
            lblMenu.Location = new Point(15, 95);
            lblMenu.Size = new Size(170, 30);

            Label lblMenuPhong = new Label();
            lblMenuPhong.Text = "▣   Quản lý phòng";
            lblMenuPhong.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMenuPhong.ForeColor = Color.White;
            lblMenuPhong.BackColor = Color.FromArgb(45, 65, 100);
            lblMenuPhong.Location = new Point(10, 140);
            lblMenuPhong.Size = new Size(170, 42);
            lblMenuPhong.TextAlign = ContentAlignment.MiddleLeft;
            lblMenuPhong.Padding = new Padding(10, 0, 0, 0);

            Label lblMenuDichVu = new Label();
            lblMenuDichVu.Text = "▣   Dịch vụ";
            lblMenuDichVu.ForeColor = Color.WhiteSmoke;
            lblMenuDichVu.Location = new Point(25, 195);
            lblMenuDichVu.Size = new Size(150, 35);

            Label lblMenuHoaDon = new Label();
            lblMenuHoaDon.Text = "▣   Hóa đơn";
            lblMenuHoaDon.ForeColor = Color.WhiteSmoke;
            lblMenuHoaDon.Location = new Point(25, 240);
            lblMenuHoaDon.Size = new Size(150, 35);

            Label lblFooter = new Label();
            lblFooter.Text = "Hotel Management\nVersion 1.0";
            lblFooter.ForeColor = Color.LightSteelBlue;
            lblFooter.Location = new Point(15, 690);
            lblFooter.Size = new Size(165, 45);

            pnlSidebar.Controls.Add(lblLogo);
            pnlSidebar.Controls.Add(lblMenu);
            pnlSidebar.Controls.Add(lblMenuPhong);
            pnlSidebar.Controls.Add(lblMenuDichVu);
            pnlSidebar.Controls.Add(lblMenuHoaDon);
            pnlSidebar.Controls.Add(lblFooter);

            // HEADER
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 85;
            pnlHeader.BackColor = Color.White;

            lblTieuDe.Text = "Tổng quan khách sạn";
            lblTieuDe.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.FromArgb(30, 45, 75);
            lblTieuDe.Location = new Point(25, 10);
            lblTieuDe.Size = new Size(550, 40);

            lblPhuDe.Text = "Quản lý phòng, khách hàng và dịch vụ";
            lblPhuDe.ForeColor = Color.Gray;
            lblPhuDe.Location = new Point(28, 50);
            lblPhuDe.Size = new Size(450, 25);

            pnlHeader.Controls.Add(lblTieuDe);
            pnlHeader.Controls.Add(lblPhuDe);

            // MAIN
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.AutoScroll = true;
            pnlMain.Padding = new Padding(15);

            // STATISTIC CARDS
            TaoTheThongKe(
                "TỔNG SỐ PHÒNG", lblTongPhong,
                15, 15, "0");

            TaoTheThongKe(
                "PHÒNG TRỐNG", lblPhongTrong,
                235, 15, "0");

            TaoTheThongKe(
                "ĐANG SỬ DỤNG", lblPhongDangSuDung,
                455, 15, "0");

            TaoTheThongKe(
                "DOANH THU GẦN NHẤT", lblDoanhThu,
                675, 15, "0 VNĐ");

            // ROOM FILTERS
            lblLocLoai.Text = "Loại phòng:";
            lblLocLoai.Location = new Point(20, 125);
            lblLocLoai.Size = new Size(85, 28);

            cboLoaiPhong.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiPhong.Items.AddRange(new object[]
            {
                "Tất cả",
                "Thường",
                "VIP",
                "Gia đình"
            });
            cboLoaiPhong.SelectedIndex = 0;
            cboLoaiPhong.Location = new Point(105, 122);
            cboLoaiPhong.Size = new Size(150, 28);

            lblLocTrangThai.Text = "Trạng thái:";
            lblLocTrangThai.Location = new Point(280, 125);
            lblLocTrangThai.Size = new Size(85, 28);

            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.Items.AddRange(new object[]
            {
                "Tất cả",
                "Trống",
                "Đang sử dụng"
            });
            cboTrangThai.SelectedIndex = 0;
            cboTrangThai.Location = new Point(365, 122);
            cboTrangThai.Size = new Size(165, 28);

            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Location = new Point(550, 120);
            btnLamMoi.Size = new Size(100, 32);
            btnLamMoi.BackColor = Color.FromArgb(55, 95, 155);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.FlatAppearance.BorderSize = 0;

            pnlMain.Controls.Add(lblLocLoai);
            pnlMain.Controls.Add(cboLoaiPhong);
            pnlMain.Controls.Add(lblLocTrangThai);
            pnlMain.Controls.Add(cboTrangThai);
            pnlMain.Controls.Add(btnLamMoi);

            // ROOM LIST
            lblDanhSachPhong.Text = "DANH SÁCH PHÒNG";
            lblDanhSachPhong.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDanhSachPhong.Location = new Point(20, 165);
            lblDanhSachPhong.Size = new Size(350, 30);

            dgvPhong.Location = new Point(20, 200);
            dgvPhong.Size = new Size(880, 220);
            dgvPhong.BackgroundColor = Color.White;
            dgvPhong.BorderStyle = BorderStyle.FixedSingle;
            dgvPhong.ReadOnly = true;
            dgvPhong.AllowUserToAddRows = false;
            dgvPhong.AllowUserToDeleteRows = false;
            dgvPhong.MultiSelect = false;
            dgvPhong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhong.RowHeadersVisible = false;
            dgvPhong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhong.AutoGenerateColumns = true;
            dgvPhong.SelectionChanged += dgvPhong_SelectionChanged;

            pnlMain.Controls.Add(lblDanhSachPhong);
            pnlMain.Controls.Add(dgvPhong);

            // CUSTOMER GROUP
            gbKhachHang.Text = "Thông tin khách hàng / nhận phòng";
            gbKhachHang.Location = new Point(20, 435);
            gbKhachHang.Size = new Size(430, 250);
            gbKhachHang.BackColor = Color.White;

            lblCCCD.Text = "CCCD:";
            lblCCCD.Location = new Point(15, 35);
            lblCCCD.Size = new Size(90, 25);

            txtCCCD.Location = new Point(110, 32);
            txtCCCD.Size = new Size(295, 27);

            lblHoTen.Text = "Họ tên:";
            lblHoTen.Location = new Point(15, 75);
            lblHoTen.Size = new Size(90, 25);

            txtHoTen.Location = new Point(110, 72);
            txtHoTen.Size = new Size(295, 27);

            lblSDT.Text = "Số điện thoại:";
            lblSDT.Location = new Point(15, 115);
            lblSDT.Size = new Size(90, 25);

            txtSDT.Location = new Point(110, 112);
            txtSDT.Size = new Size(295, 27);

            txtSoPhong.Visible = false;

            btnNhanPhong.Text = "Nhận phòng";
            btnNhanPhong.Location = new Point(110, 165);
            btnNhanPhong.Size = new Size(140, 38);
            btnNhanPhong.BackColor = Color.FromArgb(35, 145, 100);
            btnNhanPhong.ForeColor = Color.White;
            btnNhanPhong.FlatStyle = FlatStyle.Flat;
            btnNhanPhong.FlatAppearance.BorderSize = 0;

            btnTraPhong.Text = "Trả phòng";
            btnTraPhong.Location = new Point(265, 165);
            btnTraPhong.Size = new Size(140, 38);
            btnTraPhong.BackColor = Color.FromArgb(205, 75, 75);
            btnTraPhong.ForeColor = Color.White;
            btnTraPhong.FlatStyle = FlatStyle.Flat;
            btnTraPhong.FlatAppearance.BorderSize = 0;

            gbKhachHang.Controls.Add(lblCCCD);
            gbKhachHang.Controls.Add(txtCCCD);
            gbKhachHang.Controls.Add(lblHoTen);
            gbKhachHang.Controls.Add(txtHoTen);
            gbKhachHang.Controls.Add(lblSDT);
            gbKhachHang.Controls.Add(txtSDT);
            gbKhachHang.Controls.Add(btnNhanPhong);
            gbKhachHang.Controls.Add(btnTraPhong);

            // SERVICE GROUP
            gbDichVu.Text = "Sử dụng dịch vụ";
            gbDichVu.Location = new Point(470, 435);
            gbDichVu.Size = new Size(430, 250);
            gbDichVu.BackColor = Color.White;

            lblDichVu.Text = "Dịch vụ:";
            lblDichVu.Location = new Point(20, 40);
            lblDichVu.Size = new Size(85, 25);

            cboDichVu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDichVu.Location = new Point(110, 37);
            cboDichVu.Size = new Size(295, 28);

            lblSoLuong.Text = "Số lượng:";
            lblSoLuong.Location = new Point(20, 85);
            lblSoLuong.Size = new Size(85, 25);

            nudSoLuong.Minimum = 1;
            nudSoLuong.Maximum = 100;
            nudSoLuong.Value = 1;
            nudSoLuong.Location = new Point(110, 82);
            nudSoLuong.Size = new Size(100, 27);

            btnThemDichVu.Text = "Thêm dịch vụ";
            btnThemDichVu.Location = new Point(110, 135);
            btnThemDichVu.Size = new Size(170, 40);
            btnThemDichVu.BackColor = Color.FromArgb(55, 95, 155);
            btnThemDichVu.ForeColor = Color.White;
            btnThemDichVu.FlatStyle = FlatStyle.Flat;
            btnThemDichVu.FlatAppearance.BorderSize = 0;

            gbDichVu.Controls.Add(lblDichVu);
            gbDichVu.Controls.Add(cboDichVu);
            gbDichVu.Controls.Add(lblSoLuong);
            gbDichVu.Controls.Add(nudSoLuong);
            gbDichVu.Controls.Add(btnThemDichVu);

            pnlMain.Controls.Add(gbKhachHang);
            pnlMain.Controls.Add(gbDichVu);

            // ADD PANELS
            Controls.Add(pnlMain);
            Controls.Add(pnlHeader);
            Controls.Add(pnlSidebar);

            ((System.ComponentModel.ISupportInitialize)nudSoLuong).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPhong).EndInit();

            ResumeLayout(false);
        }

        private void TaoTheThongKe(
            string tieuDe,
            Label lblGiaTri,
            int x,
            int y,
            string giaTriMacDinh)
        {
            Panel card = new Panel();
            card.Location = new Point(x, y);
            card.Size = new Size(205, 90);
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;

            Label lblTieuDeCard = new Label();
            lblTieuDeCard.Text = tieuDe;
            lblTieuDeCard.Location = new Point(10, 12);
            lblTieuDeCard.Size = new Size(185, 22);
            lblTieuDeCard.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblTieuDeCard.ForeColor = Color.Gray;

            lblGiaTri.Text = giaTriMacDinh;
            lblGiaTri.Location = new Point(10, 38);
            lblGiaTri.Size = new Size(185, 35);
            lblGiaTri.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblGiaTri.ForeColor = Color.FromArgb(35, 70, 125);

            card.Controls.Add(lblTieuDeCard);
            card.Controls.Add(lblGiaTri);
            pnlMain.Controls.Add(card);
        }
    }
}