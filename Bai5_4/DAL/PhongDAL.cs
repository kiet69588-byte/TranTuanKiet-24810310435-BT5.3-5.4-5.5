using System.Data;
using Microsoft.Data.SqlClient;

namespace Bai5_4.DAL
{
    public class PhongDAL
    {
        public DataTable LayDanhSachPhong()
        {
            using SqlConnection conn = Database.GetConnection();
            using SqlDataAdapter adapter = new SqlDataAdapter(
                @"SELECT SoPhong, LoaiPhong, DonGia, TrangThai
                  FROM Phong ORDER BY SoPhong", conn);

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
    }
}