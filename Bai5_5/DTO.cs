using System;

namespace Bai5_5
{
    public class VatTu
    {
        public int MaVT { get; set; }
        public string TenVT { get; set; }
        public string DonViTinh { get; set; }
        public decimal SoLuongTon { get; set; }
        public decimal DonGia { get; set; }
        public int? MaNCC { get; set; }
        public string TenNCC { get; set; }
    }

    public class NhaCungCap
    {
        public int MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
    }

    public class PhieuKho
    {
        public int MaPhieu { get; set; }
        public string LoaiPhieu { get; set; }
        public DateTime NgayLap { get; set; }
        public string GhiChu { get; set; }
        public string TenVT { get; set; }
        public decimal SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien => SoLuong * DonGia;
    }
}