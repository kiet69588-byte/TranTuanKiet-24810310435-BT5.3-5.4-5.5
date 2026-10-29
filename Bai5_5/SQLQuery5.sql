IF DB_ID(N'InventoryDB') IS NULL
    CREATE DATABASE InventoryDB;
GO

USE InventoryDB;
GO

IF OBJECT_ID(N'ChiTietPhieuKho', N'U') IS NOT NULL
    DROP TABLE ChiTietPhieuKho;

IF OBJECT_ID(N'PhieuKho', N'U') IS NOT NULL
    DROP TABLE PhieuKho;

IF OBJECT_ID(N'VatTu', N'U') IS NOT NULL
    DROP TABLE VatTu;

IF OBJECT_ID(N'NhaCungCap', N'U') IS NOT NULL
    DROP TABLE NhaCungCap;
GO

CREATE TABLE NhaCungCap
(
    MaNCC INT IDENTITY(1,1) PRIMARY KEY,
    TenNCC NVARCHAR(150) NOT NULL,
    DienThoai VARCHAR(20),
    DiaChi NVARCHAR(250)
);

CREATE TABLE VatTu
(
    MaVT INT IDENTITY(1,1) PRIMARY KEY,
    TenVT NVARCHAR(150) NOT NULL,
    DonViTinh NVARCHAR(30) NOT NULL,
    SoLuongTon DECIMAL(18,2) NOT NULL DEFAULT 0,
    DonGia DECIMAL(18,2) NOT NULL DEFAULT 0,
    MaNCC INT NULL,
    CONSTRAINT FK_VatTu_NhaCungCap
        FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC),
    CONSTRAINT CK_VatTu_Ton CHECK (SoLuongTon >= 0),
    CONSTRAINT CK_VatTu_Gia CHECK (DonGia >= 0)
);

CREATE TABLE PhieuKho
(
    MaPhieu INT IDENTITY(1,1) PRIMARY KEY,
    LoaiPhieu NVARCHAR(10) NOT NULL,
    NgayLap DATETIME NOT NULL DEFAULT GETDATE(),
    GhiChu NVARCHAR(300),
    CONSTRAINT CK_PhieuKho_Loai
        CHECK (LoaiPhieu IN (N'Nhập', N'Xuất'))
);

CREATE TABLE ChiTietPhieuKho
(
    MaChiTiet INT IDENTITY(1,1) PRIMARY KEY,
    MaPhieu INT NOT NULL,
    MaVT INT NOT NULL,
    SoLuong DECIMAL(18,2) NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_ChiTiet_Phieu
        FOREIGN KEY (MaPhieu) REFERENCES PhieuKho(MaPhieu),
    CONSTRAINT FK_ChiTiet_VatTu
        FOREIGN KEY (MaVT) REFERENCES VatTu(MaVT),
    CONSTRAINT CK_ChiTiet_SoLuong CHECK (SoLuong > 0),
    CONSTRAINT CK_ChiTiet_DonGia CHECK (DonGia >= 0)
);
GO

INSERT INTO NhaCungCap(TenNCC, DienThoai, DiaChi)
VALUES
(N'Công ty Vật liệu An Phát', '0901234567', N'Hà Nội'),
(N'Công ty Kim khí Việt Đức', '0912345678', N'Hải Phòng'),
(N'Công ty Nguyên liệu Minh Long', '0987654321', N'Bắc Ninh');
SS
INSERT INTO VatTu(TenVT, DonViTinh, SoLuongTon, DonGia, MaNCC)
VALUES
(N'Thép xây dựng', N'Kg', 100, 18000, 1),
(N'Xi măng', N'Bao', 50, 85000, 2),
(N'Cát xây dựng', N'M3', 30, 250000, 3),
(N'Ống nhựa PVC', N'Mét', 80, 12000, 1);
GO