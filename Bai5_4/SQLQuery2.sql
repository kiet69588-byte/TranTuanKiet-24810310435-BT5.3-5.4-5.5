USE master;
GO

IF DB_ID(N'HotelDB') IS NOT NULL
BEGIN
    ALTER DATABASE HotelDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE HotelDB;
END
GO

CREATE DATABASE HotelDB;
GO

USE HotelDB;
GO

CREATE TABLE Phong
(
    SoPhong VARCHAR(10) PRIMARY KEY,
    LoaiPhong NVARCHAR(50) NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL,
    TrangThai NVARCHAR(30) NOT NULL DEFAULT N'Trống'
);
GO

CREATE TABLE KhachHang
(
    MaKhachHang INT IDENTITY(1,1) PRIMARY KEY,
    CCCD VARCHAR(20) NOT NULL UNIQUE,
    HoTen NVARCHAR(100) NOT NULL,
    SDT VARCHAR(20) NOT NULL
);
GO

CREATE TABLE DichVu
(
    MaDichVu INT IDENTITY(1,1) PRIMARY KEY,
    TenDichVu NVARCHAR(100) NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL
);
GO

CREATE TABLE PhieuDatPhong
(
    MaPhieu INT IDENTITY(1,1) PRIMARY KEY,
    MaKhachHang INT NOT NULL,
    SoPhong VARCHAR(10) NOT NULL,
    ThoiGianNhan DATETIME NOT NULL DEFAULT GETDATE(),
    ThoiGianTra DATETIME NULL,
    TongTien DECIMAL(18,2) NOT NULL DEFAULT 0,
    CONSTRAINT FK_Phieu_KhachHang
        FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang),
    CONSTRAINT FK_Phieu_Phong
        FOREIGN KEY (SoPhong) REFERENCES Phong(SoPhong)
);
GO

CREATE TABLE SuDungDichVu
(
    MaSuDung INT IDENTITY(1,1) PRIMARY KEY,
    MaPhieu INT NOT NULL,
    MaDichVu INT NOT NULL,
    SoLuong INT NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_SuDung_Phieu
        FOREIGN KEY (MaPhieu) REFERENCES PhieuDatPhong(MaPhieu),
    CONSTRAINT FK_SuDung_DichVu
        FOREIGN KEY (MaDichVu) REFERENCES DichVu(MaDichVu)
);
GO

INSERT INTO Phong (SoPhong, LoaiPhong, DonGia, TrangThai)
VALUES
('101', N'Thường', 300000, N'Trống'),
('102', N'Thường', 300000, N'Trống'),
('103', N'Thường', 350000, N'Trống'),
('201', N'VIP', 600000, N'Trống'),
('202', N'VIP', 700000, N'Trống'),
('301', N'Gia đình', 900000, N'Trống'),
('302', N'Gia đình', 1000000, N'Trống');S
GO

INSERT INTO DichVu (TenDichVu, DonGia)
VALUES
(N'Nước suối', 10000),
(N'Nước ngọt', 15000),
(N'Khăn tắm', 20000),
(N'Giặt ủi', 50000),
(N'Ăn sáng', 80000);
GO