using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Bai5_5
{
    public static class Db
    {
        public static string ConnectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=InventoryDB;Integrated Security=True;TrustServerCertificate=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }

    public class DAL
    {
        public List<VatTu> LayDanhSachVatTu(string tuKhoa = "")
        {
            List<VatTu> ds = new List<VatTu>();

            using (SqlConnection conn = Db.GetConnection())
            {
                string sql = @"
                    SELECT v.MaVT, v.TenVT, v.DonViTinh,
                           v.SoLuongTon, v.DonGia, v.MaNCC,
                           n.TenNCC
                    FROM VatTu v
                    LEFT JOIN NhaCungCap n ON v.MaNCC = n.MaNCC
                    WHERE v.TenVT LIKE @TuKhoa
                       OR CONVERT(VARCHAR(20), v.MaVT) LIKE @TuKhoa
                    ORDER BY v.MaVT DESC";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@TuKhoa", SqlDbType.NVarChar, 200)
                        .Value = "%" + tuKhoa + "%";

                    conn.Open();

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            ds.Add(new VatTu
                            {
                                MaVT = Convert.ToInt32(rd["MaVT"]),
                                TenVT = rd["TenVT"].ToString(),
                                DonViTinh = rd["DonViTinh"].ToString(),
                                SoLuongTon = Convert.ToDecimal(rd["SoLuongTon"]),
                                DonGia = Convert.ToDecimal(rd["DonGia"]),
                                MaNCC = rd["MaNCC"] == DBNull.Value
                                    ? null
                                    : Convert.ToInt32(rd["MaNCC"]),
                                TenNCC = rd["TenNCC"] == DBNull.Value
                                    ? ""
                                    : rd["TenNCC"].ToString()
                            });
                        }
                    }
                }
            }

            return ds;
        }

        public List<NhaCungCap> LayDanhSachNCC()
        {
            List<NhaCungCap> ds = new List<NhaCungCap>();

            using (SqlConnection conn = Db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT * FROM NhaCungCap ORDER BY MaNCC DESC", conn))
            {
                conn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        ds.Add(new NhaCungCap
                        {
                            MaNCC = Convert.ToInt32(rd["MaNCC"]),
                            TenNCC = rd["TenNCC"].ToString(),
                            DienThoai = rd["DienThoai"] == DBNull.Value
                                ? ""
                                : rd["DienThoai"].ToString(),
                            DiaChi = rd["DiaChi"] == DBNull.Value
                                ? ""
                                : rd["DiaChi"].ToString()
                        });
                    }
                }
            }

            return ds;
        }

        public void ThemVatTu(VatTu vt)
        {
            using (SqlConnection conn = Db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(@"
                INSERT INTO VatTu
                    (TenVT, DonViTinh, SoLuongTon, DonGia, MaNCC)
                VALUES
                    (@TenVT, @DonViTinh, 0, @DonGia, @MaNCC)", conn))
            {
                cmd.Parameters.Add("@TenVT", SqlDbType.NVarChar, 150)
                    .Value = vt.TenVT;
                cmd.Parameters.Add("@DonViTinh", SqlDbType.NVarChar, 30)
                    .Value = vt.DonViTinh;
                cmd.Parameters.Add("@DonGia", SqlDbType.Decimal)
                    .Value = vt.DonGia;
                cmd.Parameters.Add("@MaNCC", SqlDbType.Int)
                    .Value = (object)vt.MaNCC ?? DBNull.Value;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void SuaVatTu(VatTu vt)
        {
            using (SqlConnection conn = Db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(@"
                UPDATE VatTu
                SET TenVT = @TenVT,
                    DonViTinh = @DonViTinh,
                    DonGia = @DonGia,
                    MaNCC = @MaNCC
                WHERE MaVT = @MaVT", conn))
            {
                cmd.Parameters.Add("@MaVT", SqlDbType.Int).Value = vt.MaVT;
                cmd.Parameters.Add("@TenVT", SqlDbType.NVarChar, 150)
                    .Value = vt.TenVT;
                cmd.Parameters.Add("@DonViTinh", SqlDbType.NVarChar, 30)
                    .Value = vt.DonViTinh;
                cmd.Parameters.Add("@DonGia", SqlDbType.Decimal)
                    .Value = vt.DonGia;
                cmd.Parameters.Add("@MaNCC", SqlDbType.Int)
                    .Value = (object)vt.MaNCC ?? DBNull.Value;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void XoaVatTu(int maVT)
        {
            using (SqlConnection conn = Db.GetConnection())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(@"
                    DELETE FROM VatTu
                    WHERE MaVT = @MaVT
                    AND NOT EXISTS
                    (
                        SELECT 1 FROM ChiTietPhieuKho
                        WHERE ChiTietPhieuKho.MaVT = VatTu.MaVT
                    )", conn))
                {
                    cmd.Parameters.Add("@MaVT", SqlDbType.Int).Value = maVT;

                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        throw new Exception(
                            "Không thể xóa vật tư này. Vật tư có thể đã được sử dụng trong phiếu kho.");
                    }
                }
            }
        }

        public void ThemNCC(NhaCungCap ncc)
        {
            using (SqlConnection conn = Db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(@"
                INSERT INTO NhaCungCap(TenNCC, DienThoai, DiaChi)
                VALUES(@TenNCC, @DienThoai, @DiaChi)", conn))
            {
                cmd.Parameters.Add("@TenNCC", SqlDbType.NVarChar, 150)
                    .Value = ncc.TenNCC;
                cmd.Parameters.Add("@DienThoai", SqlDbType.VarChar, 20)
                    .Value = ncc.DienThoai;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 250)
                    .Value = ncc.DiaChi;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void SuaNCC(NhaCungCap ncc)
        {
            using (SqlConnection conn = Db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(@"
                UPDATE NhaCungCap
                SET TenNCC = @TenNCC,
                    DienThoai = @DienThoai,
                    DiaChi = @DiaChi
                WHERE MaNCC = @MaNCC", conn))
            {
                cmd.Parameters.Add("@MaNCC", SqlDbType.Int).Value = ncc.MaNCC;
                cmd.Parameters.Add("@TenNCC", SqlDbType.NVarChar, 150)
                    .Value = ncc.TenNCC;
                cmd.Parameters.Add("@DienThoai", SqlDbType.VarChar, 20)
                    .Value = ncc.DienThoai;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 250)
                    .Value = ncc.DiaChi;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void XoaNCC(int maNCC)
        {
            using (SqlConnection conn = Db.GetConnection())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(@"
                    DELETE FROM NhaCungCap
                    WHERE MaNCC = @MaNCC
                    AND NOT EXISTS
                    (
                        SELECT 1 FROM VatTu
                        WHERE VatTu.MaNCC = NhaCungCap.MaNCC
                    )", conn))
                {
                    cmd.Parameters.Add("@MaNCC", SqlDbType.Int).Value = maNCC;

                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        throw new Exception(
                            "Không thể xóa nhà cung cấp đang được vật tư sử dụng.");
                    }
                }
            }
        }

        public void TaoPhieuKho(
            string loaiPhieu,
            int maVT,
            decimal soLuong,
            decimal donGia,
            string ghiChu)
        {
            if (loaiPhieu != "Nhập" && loaiPhieu != "Xuất")
                throw new Exception("Loại phiếu không hợp lệ.");

            if (soLuong <= 0)
                throw new Exception("Số lượng phải lớn hơn 0.");

            if (donGia < 0)
                throw new Exception("Đơn giá không được âm.");

            using (SqlConnection conn = Db.GetConnection())
            {
                conn.Open();

                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        decimal tonKho;

                        using (SqlCommand cmd = new SqlCommand(@"
                            SELECT SoLuongTon
                            FROM VatTu WITH (UPDLOCK, ROWLOCK)
                            WHERE MaVT = @MaVT", conn, transaction))
                        {
                            cmd.Parameters.Add("@MaVT", SqlDbType.Int).Value = maVT;

                            object result = cmd.ExecuteScalar();

                            if (result == null || result == DBNull.Value)
                                throw new Exception("Không tìm thấy vật tư.");

                            tonKho = Convert.ToDecimal(result);
                        }

                        if (loaiPhieu == "Xuất" && soLuong > tonKho)
                        {
                            throw new Exception(
                                "Số lượng xuất vượt quá tồn kho. Tồn hiện tại: "
                                + tonKho);
                        }

                        int maPhieu;

                        using (SqlCommand cmd = new SqlCommand(@"
                            INSERT INTO PhieuKho(LoaiPhieu, NgayLap, GhiChu)
                            OUTPUT INSERTED.MaPhieu
                            VALUES(@LoaiPhieu, GETDATE(), @GhiChu)",
                            conn, transaction))
                        {
                            cmd.Parameters.Add("@LoaiPhieu", SqlDbType.NVarChar, 10)
                                .Value = loaiPhieu;
                            cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 300)
                                .Value = ghiChu ?? "";

                            maPhieu = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        using (SqlCommand cmd = new SqlCommand(@"
                            INSERT INTO ChiTietPhieuKho
                                (MaPhieu, MaVT, SoLuong, DonGia)
                            VALUES
                                (@MaPhieu, @MaVT, @SoLuong, @DonGia)",
                            conn, transaction))
                        {
                            cmd.Parameters.Add("@MaPhieu", SqlDbType.Int)
                                .Value = maPhieu;
                            cmd.Parameters.Add("@MaVT", SqlDbType.Int)
                                .Value = maVT;
                            cmd.Parameters.Add("@SoLuong", SqlDbType.Decimal)
                                .Value = soLuong;
                            cmd.Parameters.Add("@DonGia", SqlDbType.Decimal)
                                .Value = donGia;

                            cmd.ExecuteNonQuery();
                        }

                        string phepTinh = loaiPhieu == "Nhập" ? "+" : "-";

                        using (SqlCommand cmd = new SqlCommand(
                            "UPDATE VatTu SET SoLuongTon = SoLuongTon "
                            + phepTinh + " @SoLuong WHERE MaVT = @MaVT",
                            conn, transaction))
                        {
                            cmd.Parameters.Add("@SoLuong", SqlDbType.Decimal)
                                .Value = soLuong;
                            cmd.Parameters.Add("@MaVT", SqlDbType.Int)
                                .Value = maVT;

                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public DataTable LayLichSuPhieu()
        {
            using (SqlConnection conn = Db.GetConnection())
            using (SqlDataAdapter adapter = new SqlDataAdapter(@"
                SELECT p.MaPhieu, p.LoaiPhieu, p.NgayLap,
                       v.TenVT, ct.SoLuong, ct.DonGia,
                       ct.SoLuong * ct.DonGia AS ThanhTien,
                       p.GhiChu
                FROM PhieuKho p
                INNER JOIN ChiTietPhieuKho ct
                    ON p.MaPhieu = ct.MaPhieu
                INNER JOIN VatTu v
                    ON ct.MaVT = v.MaVT
                ORDER BY p.MaPhieu DESC", conn))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public DataTable LayBaoCaoTonKho()
        {
            using (SqlConnection conn = Db.GetConnection())
            using (SqlDataAdapter adapter = new SqlDataAdapter(@"
                SELECT v.MaVT, v.TenVT, v.DonViTinh,
                       v.SoLuongTon, v.DonGia,
                       v.SoLuongTon * v.DonGia AS GiaTriTonKho,
                       n.TenNCC
                FROM VatTu v
                LEFT JOIN NhaCungCap n ON v.MaNCC = n.MaNCC
                ORDER BY v.TenVT", conn))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
    }
}