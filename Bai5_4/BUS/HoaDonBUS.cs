using Bai5_4.DAL;
using Bai5_4.DTO;

namespace Bai5_4.BUS
{
    public class HoaDonBUS
    {
        private readonly HoaDonDAL dal = new HoaDonDAL();

        public void NhanPhong(string soPhong, KhachHangDTO kh)
        {
            if (string.IsNullOrWhiteSpace(soPhong))
                throw new System.Exception("Vui lòng chọn phòng.");

            if (string.IsNullOrWhiteSpace(kh.CCCD))
                throw new System.Exception("Vui lòng nhập CCCD.");

            if (string.IsNullOrWhiteSpace(kh.HoTen))
                throw new System.Exception("Vui lòng nhập họ tên.");

            if (string.IsNullOrWhiteSpace(kh.SDT))
                throw new System.Exception("Vui lòng nhập số điện thoại.");

            dal.NhanPhong(soPhong, kh);
        }

        public void ThemDichVu(string soPhong, int maDichVu, int soLuong)
        {
            if (string.IsNullOrWhiteSpace(soPhong))
                throw new System.Exception("Vui lòng chọn phòng.");

            if (soLuong <= 0)
                throw new System.Exception("Số lượng phải lớn hơn 0.");

            dal.ThemDichVu(soPhong, maDichVu, soLuong);
        }

        public decimal TraPhong(string soPhong)
        {
            if (string.IsNullOrWhiteSpace(soPhong))
                throw new System.Exception("Vui lòng chọn phòng.");

            return dal.TraPhong(soPhong);
        }
    }
}