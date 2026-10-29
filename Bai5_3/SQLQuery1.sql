
IF DB_ID(N'CafePOSDB') IS NOT NULL
BEGIN
    ALTER DATABASE CafePOSDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE CafePOSDB;
END;
GO

CREATE DATABASE CafePOSDB;
GO

USE CafePOSDB;
GO

CREATE TABLE BanAn
(
    MaBan INT IDENTITY(1,1) PRIMARY KEY,
    TenBan NVARCHAR(50) NOT NULL,
    TrangThai NVARCHAR(30) NOT NULL DEFAULT N'Trống'
);

CREATE TABLE DanhMuc
(
    MaDanhMuc INT IDENTITY(1,1) PRIMARY KEY,
    TenDanhMuc NVARCHAR(100) NOT NULL
);

CREATE TABLE MonAn
(
    MaMon INT IDENTITY(1,1) PRIMARY KEY,
    TenMon NVARCHAR(100) NOT NULL,
    MaDanhMuc INT NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL CHECK (DonGia >= 0),
    FOREIGN KEY (MaDanhMuc) REFERENCES DanhMuc(MaDanhMuc)
);

CREATE TABLE HoaDon
(
    MaHoaDon INT IDENTITY(1,1) PRIMARY KEY,
    MaBan INT NOT NULL,
    NgayLap DATETIME NOT NULL DEFAULT GETDATE(),
    TongTien DECIMAL(18,2) NOT NULL DEFAULT 0,
    TrangThai NVARCHAR(30) NOT NULL DEFAULT N'Chưa thanh toán',
    FOREIGN KEY (MaBan) REFERENCES BanAn(MaBan)
);

CREATE TABLE ChiTietHoaDon
(
    MaHoaDon INT NOT NULL,
    MaMon INT NOT NULL,
    SoLuong INT NOT NULL CHECK (SoLuong > 0),
    DonGia DECIMAL(18,2) NOT NULL,
    ThanhTien AS (SoLuong * DonGia) PERSISTED,
    PRIMARY KEY (MaHoaDon, MaMon),
    FOREIGN KEY (MaHoaDon) REFERENCES HoaDon(MaHoaDon),
    FOREIGN KEY (MaMon) REFERENCES MonAn(MaMon)
);

INSERT INTO BanAn(TenBan)
VALUES
(N'Bàn 1'), (N'Bàn 2'), (N'Bàn 3'), (N'Bàn 4'),
(N'Bàn 5'), (N'Bàn 6'), (N'Bàn 7'), (N'Bàn 8'),
(N'Bàn 9'), (N'Bàn 10'), (N'Bàn 11'), (N'Bàn 12');

INSERT INTO DanhMuc(TenDanhMuc)
VALUES
(N'Cà phê'), (N'Trà'), (N'Nước ép'), (N'Đá xay');

INSERT INTO MonAn(TenMon, MaDanhMuc, DonGia)
VALUES
(N'Cà phê đen', 1, 20000),
(N'Cà phê sữa', 1, 25000),
(N'Bạc xỉu', 1, 30000),
(N'Espresso', 1, 30000),
(N'Trà đào', 2, 35000),
(N'Trà chanh', 2, 25000),
(N'Trà vải', 2, 35000),
(N'Nước cam', 3, 35000),
(N'Nước ép dưa hấu', 3, 30000),
(N'Sinh tố bơ', 4, 40000),
(N'Đá xay chocolate', 4, 45000);
GO
