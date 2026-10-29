namespace Bai5_5
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabVatTu;
        private System.Windows.Forms.TabPage tabNCC;
        private System.Windows.Forms.TabPage tabPhieu;
        private System.Windows.Forms.TabPage tabBaoCao;

        private System.Windows.Forms.DataGridView dgvVatTu;
        private System.Windows.Forms.DataGridView dgvNCC;
        private System.Windows.Forms.DataGridView dgvPhieu;
        private System.Windows.Forms.DataGridView dgvBaoCao;

        private System.Windows.Forms.TextBox txtTenVT;
        private System.Windows.Forms.TextBox txtDonVi;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.TextBox txtTimVT;
        private System.Windows.Forms.ComboBox cboNCC;

        private System.Windows.Forms.Button btnThemVT;
        private System.Windows.Forms.Button btnSuaVT;
        private System.Windows.Forms.Button btnXoaVT;
        private System.Windows.Forms.Button btnLamMoiVT;
        private System.Windows.Forms.Button btnTimVT;

        private System.Windows.Forms.TextBox txtTenNCC;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.TextBox txtDiaChi;

        private System.Windows.Forms.Button btnThemNCC;
        private System.Windows.Forms.Button btnSuaNCC;
        private System.Windows.Forms.Button btnXoaNCC;
        private System.Windows.Forms.Button btnLamMoiNCC;

        private System.Windows.Forms.ComboBox cboLoaiPhieu;
        private System.Windows.Forms.ComboBox cboVatTu;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.TextBox txtGiaPhieu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnLapPhieu;
        private System.Windows.Forms.Button btnTaiLichSu;
        private System.Windows.Forms.Button btnTaiBaoCao;
        private System.Windows.Forms.Label lblTonKho;
        private System.Windows.Forms.Label lblTieuDe;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            tabControl1 = new System.Windows.Forms.TabControl();
            tabVatTu = new System.Windows.Forms.TabPage();
            tabNCC = new System.Windows.Forms.TabPage();
            tabPhieu = new System.Windows.Forms.TabPage();
            tabBaoCao = new System.Windows.Forms.TabPage();

            dgvVatTu = new System.Windows.Forms.DataGridView();
            dgvNCC = new System.Windows.Forms.DataGridView();
            dgvPhieu = new System.Windows.Forms.DataGridView();
            dgvBaoCao = new System.Windows.Forms.DataGridView();

            txtTenVT = new System.Windows.Forms.TextBox();
            txtDonVi = new System.Windows.Forms.TextBox();
            txtDonGia = new System.Windows.Forms.TextBox();
            txtTimVT = new System.Windows.Forms.TextBox();
            cboNCC = new System.Windows.Forms.ComboBox();

            btnThemVT = new System.Windows.Forms.Button();
            btnSuaVT = new System.Windows.Forms.Button();
            btnXoaVT = new System.Windows.Forms.Button();
            btnLamMoiVT = new System.Windows.Forms.Button();
            btnTimVT = new System.Windows.Forms.Button();

            txtTenNCC = new System.Windows.Forms.TextBox();
            txtDienThoai = new System.Windows.Forms.TextBox();
            txtDiaChi = new System.Windows.Forms.TextBox();

            btnThemNCC = new System.Windows.Forms.Button();
            btnSuaNCC = new System.Windows.Forms.Button();
            btnXoaNCC = new System.Windows.Forms.Button();
            btnLamMoiNCC = new System.Windows.Forms.Button();

            cboLoaiPhieu = new System.Windows.Forms.ComboBox();
            cboVatTu = new System.Windows.Forms.ComboBox();
            txtSoLuong = new System.Windows.Forms.TextBox();
            txtGiaPhieu = new System.Windows.Forms.TextBox();
            txtGhiChu = new System.Windows.Forms.TextBox();

            btnLapPhieu = new System.Windows.Forms.Button();
            btnTaiLichSu = new System.Windows.Forms.Button();
            btnTaiBaoCao = new System.Windows.Forms.Button();

            lblTonKho = new System.Windows.Forms.Label();
            lblTieuDe = new System.Windows.Forms.Label();

            SuspendLayout();

            Text = "HỆ THỐNG QUẢN LÝ KHO NGUYÊN VẬT LIỆU";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            MinimumSize = new System.Drawing.Size(1000, 650);
            Font = new System.Drawing.Font("Segoe UI", 10F);

            lblTieuDe.Text = "HỆ THỐNG QUẢN LÝ XUẤT - NHẬP KHO";
            lblTieuDe.Font = new System.Drawing.Font(
                "Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
            lblTieuDe.Height = 60;

            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Controls.Add(tabVatTu);
            tabControl1.Controls.Add(tabNCC);
            tabControl1.Controls.Add(tabPhieu);
            tabControl1.Controls.Add(tabBaoCao);

            tabVatTu.Text = "Quản lý vật tư";
            tabNCC.Text = "Nhà cung cấp";
            tabPhieu.Text = "Phiếu nhập / xuất";
            tabBaoCao.Text = "Báo cáo tồn kho";

            TaoBang(dgvVatTu);
            TaoBang(dgvNCC);
            TaoBang(dgvPhieu);
            TaoBang(dgvBaoCao);

            ThemNhan(tabVatTu, "Tên vật tư", 20, 20);
            ThemNhan(tabVatTu, "Đơn vị tính", 20, 65);
            ThemNhan(tabVatTu, "Đơn giá", 20, 110);
            ThemNhan(tabVatTu, "Nhà cung cấp", 20, 155);

            ThemTextBox(tabVatTu, txtTenVT, 150, 20, 250);
            ThemTextBox(tabVatTu, txtDonVi, 150, 65, 250);
            ThemTextBox(tabVatTu, txtDonGia, 150, 110, 250);

            cboNCC.SetBounds(150, 155, 250, 30);
            cboNCC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            tabVatTu.Controls.Add(cboNCC);

            ThemNut(tabVatTu, btnThemVT, "Thêm", 430, 20);
            ThemNut(tabVatTu, btnSuaVT, "Sửa", 530, 20);
            ThemNut(tabVatTu, btnXoaVT, "Xóa", 630, 20);
            ThemNut(tabVatTu, btnLamMoiVT, "Làm mới", 730, 20);

            ThemNhan(tabVatTu, "Tìm vật tư", 430, 75);
            ThemTextBox(tabVatTu, txtTimVT, 530, 75, 200);
            ThemNut(tabVatTu, btnTimVT, "Tìm", 740, 75);

            dgvVatTu.SetBounds(20, 210, 1100, 400);
            dgvVatTu.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;
            tabVatTu.Controls.Add(dgvVatTu);

            ThemNhan(tabNCC, "Tên nhà cung cấp", 20, 20);
            ThemNhan(tabNCC, "Điện thoại", 20, 65);
            ThemNhan(tabNCC, "Địa chỉ", 20, 110);

            ThemTextBox(tabNCC, txtTenNCC, 170, 20, 280);
            ThemTextBox(tabNCC, txtDienThoai, 170, 65, 280);
            ThemTextBox(tabNCC, txtDiaChi, 170, 110, 280);

            ThemNut(tabNCC, btnThemNCC, "Thêm", 500, 20);
            ThemNut(tabNCC, btnSuaNCC, "Sửa", 600, 20);
            ThemNut(tabNCC, btnXoaNCC, "Xóa", 700, 20);
            ThemNut(tabNCC, btnLamMoiNCC, "Làm mới", 800, 20);

            dgvNCC.SetBounds(20, 170, 1100, 440);
            dgvNCC.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;
            tabNCC.Controls.Add(dgvNCC);

            ThemNhan(tabPhieu, "Loại phiếu", 20, 20);
            ThemNhan(tabPhieu, "Vật tư", 20, 65);
            ThemNhan(tabPhieu, "Số lượng", 20, 110);
            ThemNhan(tabPhieu, "Đơn giá", 20, 155);
            ThemNhan(tabPhieu, "Ghi chú", 20, 200);

            cboLoaiPhieu.SetBounds(150, 20, 250, 30);
            cboLoaiPhieu.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboLoaiPhieu.Items.AddRange(new object[] { "Nhập", "Xuất" });
            cboLoaiPhieu.SelectedIndex = 0;
            tabPhieu.Controls.Add(cboLoaiPhieu);

            cboVatTu.SetBounds(150, 65, 250, 30);
            cboVatTu.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            tabPhieu.Controls.Add(cboVatTu);

            ThemTextBox(tabPhieu, txtSoLuong, 150, 110, 250);
            ThemTextBox(tabPhieu, txtGiaPhieu, 150, 155, 250);
            ThemTextBox(tabPhieu, txtGhiChu, 150, 200, 250);

            lblTonKho.SetBounds(430, 65, 400, 30);
            lblTonKho.Text = "Tồn kho: chưa chọn vật tư";
            tabPhieu.Controls.Add(lblTonKho);

            ThemNut(tabPhieu, btnLapPhieu, "Lập phiếu", 430, 110);
            ThemNut(tabPhieu, btnTaiLichSu, "Tải lịch sử", 550, 110);

            dgvPhieu.SetBounds(20, 270, 1100, 340);
            dgvPhieu.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;
            tabPhieu.Controls.Add(dgvPhieu);

            ThemNut(tabBaoCao, btnTaiBaoCao, "Tải báo cáo tồn kho", 20, 20);

            dgvBaoCao.SetBounds(20, 75, 1100, 530);
            dgvBaoCao.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;
            tabBaoCao.Controls.Add(dgvBaoCao);

            Controls.Add(tabControl1);
            Controls.Add(lblTieuDe);

            ResumeLayout(false);
        }

        private void TaoBang(System.Windows.Forms.DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.RowHeadersVisible = false;
        }

        private void ThemNhan(
            System.Windows.Forms.Control parent,
            string noiDung,
            int x,
            int y)
        {
            System.Windows.Forms.Label lbl = new System.Windows.Forms.Label();
            lbl.Text = noiDung;
            lbl.SetBounds(x, y + 3, 140, 28);
            parent.Controls.Add(lbl);
        }

        private void ThemTextBox(
            System.Windows.Forms.Control parent,
            System.Windows.Forms.TextBox txt,
            int x,
            int y,
            int rong)
        {
            txt.SetBounds(x, y, rong, 30);
            parent.Controls.Add(txt);
        }

        private void ThemNut(
            System.Windows.Forms.Control parent,
            System.Windows.Forms.Button btn,
            string noiDung,
            int x,
            int y)
        {
            btn.Text = noiDung;
            btn.SetBounds(x, y, 90, 35);
            parent.Controls.Add(btn);
        }
    }
}