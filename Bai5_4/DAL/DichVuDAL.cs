using System.Data;
using Microsoft.Data.SqlClient;

namespace Bai5_4.DAL
{
    public class DichVuDAL
    {
        public DataTable LayDanhSachDichVu()
        {
            using SqlConnection conn = Database.GetConnection();
            using SqlDataAdapter adapter = new SqlDataAdapter(
                "SELECT MaDichVu, TenDichVu, DonGia FROM DichVu ORDER BY TenDichVu",
                conn);

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
    }
}