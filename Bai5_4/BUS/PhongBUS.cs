using System.Data;
using Bai5_4.DAL;

namespace Bai5_4.BUS
{
    public class PhongBUS
    {
        private readonly PhongDAL dal = new PhongDAL();

        public DataTable LayDanhSachPhong()
        {
            return dal.LayDanhSachPhong();
        }
    }
}