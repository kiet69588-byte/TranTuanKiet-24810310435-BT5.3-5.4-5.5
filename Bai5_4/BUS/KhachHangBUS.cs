using Bai5_4.DAL;

namespace Bai5_4.BUS
{
    public class KhachHangBUS
    {
        private readonly KhachHangDAL dal = new KhachHangDAL();

        public int TimHoacThem(string hoTen, string cccd, string sdt)
        {
            if (string.IsNullOrWhiteSpace(hoTen))
                throw new Exception("Vui lòng nhập họ tên.");

            if (string.IsNullOrWhiteSpace(cccd))
                throw new Exception("Vui lòng nhập CCCD.");

            return dal.TimHoacThem(hoTen.Trim(), cccd.Trim(), sdt.Trim());
        }
    }
}