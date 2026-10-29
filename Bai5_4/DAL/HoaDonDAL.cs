using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Bai5_4.DTO;

namespace Bai5_4.DAL
{
    public class HoaDonDAL
    {
        public void NhanPhong(string soPhong, KhachHangDTO kh)
        {
            using SqlConnection conn = Database.GetConnection();
            conn.Open();

            using SqlTransaction tran = conn.BeginTransaction();

            try
            {
                using (SqlCommand kiemTra = new SqlCommand(
                    @"SELECT COUNT(*) FROM Phong
                      WHERE SoPhong = @SoPhong AND TrangThai = N'Trống'",
                    conn, tran))
                {
                    kiemTra.Parameters.AddWithValue("@SoPhong", soPhong);

                    if ((int)kiemTra.ExecuteScalar()! == 0)
                        throw new Exception("Phòng không tồn tại hoặc đang được sử dụng.");
                }

                int maKhachHang;

                using (SqlCommand cmdKhach = new SqlCommand(
                    @"SELECT MaKhachHang FROM KhachHang WHERE CCCD = @CCCD",
                    conn, tran))
                {
                    cmdKhach.Parameters.AddWithValue("@CCCD", kh.CCCD);
                    object? ketQua = cmdKhach.ExecuteScalar();

                    if (ketQua != null)
                    {
                        maKhachHang = Convert.ToInt32(ketQua);

                        using SqlCommand capNhat = new SqlCommand(
                            @"UPDATE KhachHang
                              SET HoTen = @HoTen, SDT = @SDT
                              WHERE MaKhachHang = @Ma",
                            conn, tran);

                        capNhat.Parameters.AddWithValue("@HoTen", kh.HoTen);
                        capNhat.Parameters.AddWithValue("@SDT", kh.SDT);
                        capNhat.Parameters.AddWithValue("@Ma", maKhachHang);
                        capNhat.ExecuteNonQuery();
                    }
                    else
                    {
                        using SqlCommand themKhach = new SqlCommand(
                            @"INSERT INTO KhachHang(CCCD, HoTen, SDT)
                              VALUES(@CCCD, @HoTen, @SDT);
                              SELECT CAST(SCOPE_IDENTITY() AS INT);",
                            conn, tran);

                        themKhach.Parameters.AddWithValue("@CCCD", kh.CCCD);
                        themKhach.Parameters.AddWithValue("@HoTen", kh.HoTen);
                        themKhach.Parameters.AddWithValue("@SDT", kh.SDT);

                        maKhachHang = Convert.ToInt32(themKhach.ExecuteScalar());
                    }
                }

                using (SqlCommand cmdPhieu = new SqlCommand(
                    @"INSERT INTO PhieuDatPhong
                      (MaKhachHang, SoPhong, ThoiGianNhan, TongTien)
                      VALUES (@MaKH, @SoPhong, GETDATE(), 0)",
                    conn, tran))
                {
                    cmdPhieu.Parameters.AddWithValue("@MaKH", maKhachHang);
                    cmdPhieu.Parameters.AddWithValue("@SoPhong", soPhong);
                    cmdPhieu.ExecuteNonQuery();
                }

                using (SqlCommand cmdPhong = new SqlCommand(
                    @"UPDATE Phong SET TrangThai = N'Đang sử dụng'
                      WHERE SoPhong = @SoPhong",
                    conn, tran))
                {
                    cmdPhong.Parameters.AddWithValue("@SoPhong", soPhong);
                    cmdPhong.ExecuteNonQuery();
                }

                tran.Commit();
            }
            catch
            {
                tran.Rollback();
                throw;
            }
        }

        public void ThemDichVu(string soPhong, int maDichVu, int soLuong)
        {
            using SqlConnection conn = Database.GetConnection();
            conn.Open();

            using SqlTransaction tran = conn.BeginTransaction();

            try
            {
                int maPhieu;
                using (SqlCommand cmd = new SqlCommand(
                    @"SELECT TOP 1 MaPhieu FROM PhieuDatPhong
                      WHERE SoPhong = @SoPhong AND ThoiGianTra IS NULL
                      ORDER BY MaPhieu DESC",
                    conn, tran))
                {
                    cmd.Parameters.AddWithValue("@SoPhong", soPhong);
                    object? result = cmd.ExecuteScalar();

                    if (result == null)
                        throw new Exception("Phòng chưa được nhận.");

                    maPhieu = Convert.ToInt32(result);
                }

                decimal donGia;
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT DonGia FROM DichVu WHERE MaDichVu = @Ma",
                    conn, tran))
                {
                    cmd.Parameters.AddWithValue("@Ma", maDichVu);
                    object? result = cmd.ExecuteScalar();

                    if (result == null)
                        throw new Exception("Dịch vụ không tồn tại.");

                    donGia = Convert.ToDecimal(result);
                }

                using (SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO SuDungDichVu(MaPhieu, MaDichVu, SoLuong, DonGia)
                      VALUES(@MaPhieu, @MaDichVu, @SoLuong, @DonGia)",
                    conn, tran))
                {
                    cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
                    cmd.Parameters.AddWithValue("@MaDichVu", maDichVu);
                    cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                    cmd.Parameters.AddWithValue("@DonGia", donGia);
                    cmd.ExecuteNonQuery();
                }

                tran.Commit();
            }
            catch
            {
                tran.Rollback();
                throw;
            }
        }

        public decimal TraPhong(string soPhong)
        {
            using SqlConnection conn = Database.GetConnection();
            conn.Open();

            using SqlTransaction tran = conn.BeginTransaction();

            try
            {
                int maPhieu;
                DateTime thoiGianNhan;

                using (SqlCommand cmd = new SqlCommand(
                    @"SELECT TOP 1 MaPhieu, ThoiGianNhan
                      FROM PhieuDatPhong
                      WHERE SoPhong = @SoPhong AND ThoiGianTra IS NULL
                      ORDER BY MaPhieu DESC",
                    conn, tran))
                {
                    cmd.Parameters.AddWithValue("@SoPhong", soPhong);

                    using SqlDataReader reader = cmd.ExecuteReader();

                    if (!reader.Read())
                        throw new Exception("Phòng chưa được nhận hoặc đã trả.");

                    maPhieu = reader.GetInt32(0);
                    thoiGianNhan = reader.GetDateTime(1);
                }

                decimal donGiaPhong;

                using (SqlCommand cmd = new SqlCommand(
                    "SELECT DonGia FROM Phong WHERE SoPhong = @SoPhong",
                    conn, tran))
                {
                    cmd.Parameters.AddWithValue("@SoPhong", soPhong);
                    donGiaPhong = Convert.ToDecimal(cmd.ExecuteScalar());
                }

                DateTime thoiGianTra = DateTime.Now;

                double soGio = Math.Ceiling(
                    (thoiGianTra - thoiGianNhan).TotalHours);

                if (soGio < 1)
                    soGio = 1;

                decimal tienPhong = donGiaPhong *
                    (decimal)Math.Ceiling(soGio / 24.0);

                decimal tienDichVu;

                using (SqlCommand cmd = new SqlCommand(
                    @"SELECT ISNULL(SUM(SoLuong * DonGia), 0)
                      FROM SuDungDichVu WHERE MaPhieu = @MaPhieu",
                    conn, tran))
                {
                    cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
                    tienDichVu = Convert.ToDecimal(cmd.ExecuteScalar());
                }

                decimal tongTien = tienPhong + tienDichVu;

                using (SqlCommand cmd = new SqlCommand(
                    @"UPDATE PhieuDatPhong
                      SET ThoiGianTra = @ThoiGianTra, TongTien = @TongTien
                      WHERE MaPhieu = @MaPhieu",
                    conn, tran))
                {
                    cmd.Parameters.AddWithValue("@ThoiGianTra", thoiGianTra);
                    cmd.Parameters.AddWithValue("@TongTien", tongTien);
                    cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd = new SqlCommand(
                    @"UPDATE Phong SET TrangThai = N'Trống'
                      WHERE SoPhong = @SoPhong",
                    conn, tran))
                {
                    cmd.Parameters.AddWithValue("@SoPhong", soPhong);
                    cmd.ExecuteNonQuery();
                }

                tran.Commit();
                return tongTien;
            }
            catch
            {
                tran.Rollback();
                throw;
            }
        }
    }
}