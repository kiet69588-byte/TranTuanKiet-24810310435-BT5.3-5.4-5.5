
namespace Bai5_3
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblPhuDe;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pnlBan;
        private System.Windows.Forms.Label lblDanhSachBan;
        private System.Windows.Forms.FlowLayoutPanel flpBan;
        private System.Windows.Forms.Panel pnlBanHang;
        private System.Windows.Forms.Label lblBan;
        private System.Windows.Forms.ComboBox cboDanhMuc;
        private System.Windows.Forms.FlowLayoutPanel flpMon;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Panel pnlThanhToan;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnChuyenBan;
        private System.Windows.Forms.Button btnThucDon;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new System.Windows.Forms.Panel();
            lblTieuDe = new System.Windows.Forms.Label();
            lblPhuDe = new System.Windows.Forms.Label();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            pnlBan = new System.Windows.Forms.Panel();
            lblDanhSachBan = new System.Windows.Forms.Label();
            flpBan = new System.Windows.Forms.FlowLayoutPanel();
            pnlBanHang = new System.Windows.Forms.Panel();
            lblBan = new System.Windows.Forms.Label();
            cboDanhMuc = new System.Windows.Forms.ComboBox();
            flpMon = new System.Windows.Forms.FlowLayoutPanel();
            dgvHoaDon = new System.Windows.Forms.DataGridView();
            pnlThanhToan = new System.Windows.Forms.Panel();
            lblTongTien = new System.Windows.Forms.Label();
            nudSoLuong = new System.Windows.Forms.NumericUpDown();
            btnThanhToan = new System.Windows.Forms.Button();
            btnChuyenBan = new System.Windows.Forms.Button();
            btnThucDon = new System.Windows.Forms.Button();

            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            pnlBan.SuspendLayout();
            pnlBanHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).BeginInit();
            pnlThanhToan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoLuong).BeginInit();
            SuspendLayout();

            // Header
            pnlHeader.BackColor = System.Drawing.Color.FromArgb(76, 47, 35);
            pnlHeader.Controls.Add(lblPhuDe);
            pnlHeader.Controls.Add(lblTieuDe);
            pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            pnlHeader.Height = 82;

            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 22F,
                System.Drawing.FontStyle.Bold);
            lblTieuDe.ForeColor = System.Drawing.Color.White;
            lblTieuDe.Location = new System.Drawing.Point(22, 8);
            lblTieuDe.Text = "CAFE POS";

            lblPhuDe.AutoSize = true;
            lblPhuDe.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblPhuDe.ForeColor = System.Drawing.Color.FromArgb(235, 213, 194);
            lblPhuDe.Location = new System.Drawing.Point(27, 52);
            lblPhuDe.Text = "QUẢN LÝ BÁN HÀNG";

            // Main split
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.BackColor = System.Drawing.Color.FromArgb(230, 222, 212);
            splitContainer1.Panel1MinSize = 280;
            splitContainer1.Panel2MinSize = 450;
            splitContainer1.Size = new System.Drawing.Size(1200, 650);
            splitContainer1.SplitterDistance = 350;
            splitContainer1.SplitterWidth = 6;

            // Left panel
            pnlBan.BackColor = System.Drawing.Color.FromArgb(250, 247, 242);
            pnlBan.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlBan.Padding = new System.Windows.Forms.Padding(12);
            pnlBan.Controls.Add(flpBan);
            pnlBan.Controls.Add(lblDanhSachBan);

            lblDanhSachBan.Dock = System.Windows.Forms.DockStyle.Top;
            lblDanhSachBan.Height = 48;
            lblDanhSachBan.Font = new System.Drawing.Font("Segoe UI", 13F,
                System.Drawing.FontStyle.Bold);
            lblDanhSachBan.ForeColor = System.Drawing.Color.FromArgb(76, 47, 35);
            lblDanhSachBan.Text = "SƠ ĐỒ BÀN";
            lblDanhSachBan.TextAlign =
                System.Drawing.ContentAlignment.MiddleLeft;

            flpBan.Dock = System.Windows.Forms.DockStyle.Fill;
            flpBan.AutoScroll = true;
            flpBan.BackColor = System.Drawing.Color.FromArgb(250, 247, 242);
            flpBan.Padding = new System.Windows.Forms.Padding(4);

            splitContainer1.Panel1.Controls.Add(pnlBan);

            // Right panel
            pnlBanHang.BackColor = System.Drawing.Color.White;
            pnlBanHang.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlBanHang.Controls.Add(dgvHoaDon);
            pnlBanHang.Controls.Add(pnlThanhToan);
            pnlBanHang.Controls.Add(flpMon);
            pnlBanHang.Controls.Add(cboDanhMuc);
            pnlBanHang.Controls.Add(lblBan);

            lblBan.Dock = System.Windows.Forms.DockStyle.Top;
            lblBan.Height = 48;
            lblBan.Font = new System.Drawing.Font("Segoe UI", 15F,
                System.Drawing.FontStyle.Bold);
            lblBan.ForeColor = System.Drawing.Color.FromArgb(76, 47, 35);
            lblBan.BackColor = System.Drawing.Color.FromArgb(250, 247, 242);
            lblBan.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            lblBan.Text = "Bàn 1";
            lblBan.TextAlign =
                System.Drawing.ContentAlignment.MiddleLeft;

            cboDanhMuc.Dock = System.Windows.Forms.DockStyle.Top;
            cboDanhMuc.Height = 38;
            cboDanhMuc.Font = new System.Drawing.Font("Segoe UI", 10F);
            cboDanhMuc.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboDanhMuc.Margin = new System.Windows.Forms.Padding(10);

            flpMon.Dock = System.Windows.Forms.DockStyle.Top;
            flpMon.Height = 170;
            flpMon.AutoScroll = true;
            flpMon.BackColor = System.Drawing.Color.FromArgb(250, 247, 242);
            flpMon.Padding = new System.Windows.Forms.Padding(10);

            dgvHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvHoaDon.BackgroundColor = System.Drawing.Color.White;
            dgvHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvHoaDon.ReadOnly = true;
            dgvHoaDon.AllowUserToAddRows = false;
            dgvHoaDon.AllowUserToDeleteRows = false;
            dgvHoaDon.RowHeadersVisible = false;
            dgvHoaDon.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvHoaDon.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoaDon.Font = new System.Drawing.Font("Segoe UI", 10F);
            dgvHoaDon.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(76, 47, 35);
            dgvHoaDon.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.White;
            dgvHoaDon.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 10F,
                    System.Drawing.FontStyle.Bold);
            dgvHoaDon.EnableHeadersVisualStyles = false;
            dgvHoaDon.RowTemplate.Height = 32;
            dgvHoaDon.AlternatingRowsDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(250, 247, 242);

            // Bottom payment panel
            pnlThanhToan.BackColor = System.Drawing.Color.FromArgb(250, 247, 242);
            pnlThanhToan.Dock = System.Windows.Forms.DockStyle.Bottom;
            pnlThanhToan.Height = 155;
            pnlThanhToan.Padding = new System.Windows.Forms.Padding(12);
            pnlThanhToan.Controls.Add(lblTongTien);
            pnlThanhToan.Controls.Add(nudSoLuong);
            pnlThanhToan.Controls.Add(btnThanhToan);
            pnlThanhToan.Controls.Add(btnChuyenBan);
            pnlThanhToan.Controls.Add(btnThucDon);

            lblTongTien.Dock = System.Windows.Forms.DockStyle.Top;
            lblTongTien.Height = 48;
            lblTongTien.Font = new System.Drawing.Font("Segoe UI", 16F,
                System.Drawing.FontStyle.Bold);
            lblTongTien.ForeColor = System.Drawing.Color.FromArgb(173, 73, 42);
            lblTongTien.Text = "Tổng tiền: 0 VNĐ";
            lblTongTien.TextAlign =
                System.Drawing.ContentAlignment.MiddleLeft;

            nudSoLuong.Location = new System.Drawing.Point(14, 72);
            nudSoLuong.Minimum = 1;
            nudSoLuong.Maximum = 100;
            nudSoLuong.Value = 1;
            nudSoLuong.Width = 70;
            nudSoLuong.Height = 32;
            nudSoLuong.Font = new System.Drawing.Font("Segoe UI", 11F);

            btnThanhToan.Location = new System.Drawing.Point(95, 68);
            btnThanhToan.Size = new System.Drawing.Size(125, 40);
            btnThanhToan.Text = "Thanh toán";
            btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 10F,
                System.Drawing.FontStyle.Bold);
            btnThanhToan.ForeColor = System.Drawing.Color.White;
            btnThanhToan.BackColor = System.Drawing.Color.FromArgb(57, 128, 85);
            btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnThanhToan.FlatAppearance.BorderSize = 0;

            btnChuyenBan.Location = new System.Drawing.Point(230, 68);
            btnChuyenBan.Size = new System.Drawing.Size(115, 40);
            btnChuyenBan.Text = "Chuyển bàn";
            btnChuyenBan.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnChuyenBan.BackColor = System.Drawing.Color.White;
            btnChuyenBan.ForeColor = System.Drawing.Color.FromArgb(76, 47, 35);
            btnChuyenBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            btnThucDon.Location = new System.Drawing.Point(355, 68);
            btnThucDon.Size = new System.Drawing.Size(145, 40);
            btnThucDon.Text = "Quản lý thực đơn";
            btnThucDon.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnThucDon.BackColor = System.Drawing.Color.FromArgb(238, 224, 208);
            btnThucDon.ForeColor = System.Drawing.Color.FromArgb(76, 47, 35);
            btnThucDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            splitContainer1.Panel2.Controls.Add(pnlBanHang);

            // Form
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(250, 247, 242);
            ClientSize = new System.Drawing.Size(1200, 732);
            MinimumSize = new System.Drawing.Size(1000, 650);
            Controls.Add(splitContainer1);
            Controls.Add(pnlHeader);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Cafe POS - Quản lý bán hàng";

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            pnlBan.ResumeLayout(false);
            pnlBanHang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).EndInit();
            pnlThanhToan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudSoLuong).EndInit();
            ResumeLayout(false);
        }
    }
}
S