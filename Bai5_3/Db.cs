using Microsoft.Data.SqlClient;

namespace Bai5_3
{
    public static class Db
    {
        public static string ChuoiKetNoi =
            @"Server=(localdb)\MSSQLLocalDB;Database=CafePOSDB;Integrated Security=True;TrustServerCertificate=True;";

        public static SqlConnection TaoKetNoi()
        {
            return new SqlConnection(ChuoiKetNoi);
        }
    }
}