using Microsoft.Data.SqlClient;

namespace Bai5_4.DAL
{
    public class KhachHangDAL
    {
        public int TimHoacThem(string hoTen, string cccd, string sdt)
        {
            using var conn = Database.GetConnection();
            conn.Open();

            using (var cmd = new SqlCommand(
                "SELECT MaKH FROM KhachHang WHERE CCCD = @CCCD", conn))
            {
                cmd.Parameters.Add("@CCCD",
                    System.Data.SqlDbType.VarChar, 20).Value = cccd;

                object? result = cmd.ExecuteScalar();

                if (result != null)
                    return Convert.ToInt32(result);
            }

            using (var cmd = new SqlCommand(
                @"INSERT INTO KhachHang(HoTen, CCCD, SoDienThoai)
                  VALUES(@HoTen, @CCCD, @SDT);
                  SELECT CAST(SCOPE_IDENTITY() AS INT);", conn))
            {
                cmd.Parameters.Add("@HoTen",
                    System.Data.SqlDbType.NVarChar, 100).Value = hoTen;

                cmd.Parameters.Add("@CCCD",
                    System.Data.SqlDbType.VarChar, 20).Value = cccd;

                cmd.Parameters.Add("@SDT",
                    System.Data.SqlDbType.VarChar, 15).Value =
                    string.IsNullOrWhiteSpace(sdt) ? DBNull.Value : sdt;

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}