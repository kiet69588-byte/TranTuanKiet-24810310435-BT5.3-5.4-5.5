using System;

namespace Bai5_5
{
    public class BUS
    {
        private readonly DAL dal = new DAL();

        public void KiemTraVatTu(VatTu vt)
        {
            if (string.IsNullOrWhiteSpace(vt.TenVT))
                throw new Exception("Vui lòng nhập tên vật tư.");

            if (string.IsNullOrWhiteSpace(vt.DonViTinh))
                throw new Exception("Vui lòng nhập đơn vị tính.");

            if (vt.DonGia < 0)
                throw new Exception("Đơn giá không được âm.");
        }

        public void ThemVatTu(VatTu vt)
        {
            KiemTraVatTu(vt);
            dal.ThemVatTu(vt);
        }

        public void SuaVatTu(VatTu vt)
        {
            KiemTraVatTu(vt);

            if (vt.MaVT <= 0)
                throw new Exception("Vui lòng chọn vật tư cần sửa.");

            dal.SuaVatTu(vt);
        }

        public void XoaVatTu(int maVT)
        {
            if (maVT <= 0)
                throw new Exception("Vui lòng chọn vật tư cần xóa.");

            dal.XoaVatTu(maVT);
        }

        public void KiemTraNCC(NhaCungCap ncc)
        {
            if (string.IsNullOrWhiteSpace(ncc.TenNCC))
                throw new Exception("Vui lòng nhập tên nhà cung cấp.");
        }

        public void ThemNCC(NhaCungCap ncc)
        {
            KiemTraNCC(ncc);
            dal.ThemNCC(ncc);
        }

        public void SuaNCC(NhaCungCap ncc)
        {
            KiemTraNCC(ncc);

            if (ncc.MaNCC <= 0)
                throw new Exception("Vui lòng chọn nhà cung cấp cần sửa.");

            dal.SuaNCC(ncc);
        }

        public void XoaNCC(int maNCC)
        {
            if (maNCC <= 0)
                throw new Exception("Vui lòng chọn nhà cung cấp cần xóa.");

            dal.XoaNCC(maNCC);
        }

        public void TaoPhieuKho(
            string loaiPhieu,
            int maVT,
            decimal soLuong,
            decimal donGia,
            string ghiChu)
        {
            if (maVT <= 0)
                throw new Exception("Vui lòng chọn vật tư.");

            if (soLuong <= 0)
                throw new Exception("Số lượng phải lớn hơn 0.");

            if (donGia < 0)
                throw new Exception("Đơn giá không được âm.");

            dal.TaoPhieuKho(loaiPhieu, maVT, soLuong, donGia, ghiChu);
        }
    }
}