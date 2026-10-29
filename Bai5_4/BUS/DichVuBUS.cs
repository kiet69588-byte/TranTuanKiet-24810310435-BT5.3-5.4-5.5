using System.Data;
using Bai5_4.DAL;

namespace Bai5_4.BUS
{
    public class DichVuBUS
    {
        private readonly DichVuDAL dal = new DichVuDAL();

        public DataTable LayDanhSachDichVu()
        {
            return dal.LayDanhSachDichVu();
        }
    }
}