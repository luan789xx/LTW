USE [master]
GO
CREATE DATABASE [QLBanDoChoi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLBanDoChoi', FILENAME = N'D:\Web\DoAnWebBanDoChoi\QLBanDoChoi.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QLBanDoChoi_log', FILENAME = N'D:\Web\DoAnWebBanDoChoi\QLBanDoChoi_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QLBanDoChoi] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLBanDoChoi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLBanDoChoi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLBanDoChoi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLBanDoChoi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLBanDoChoi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLBanDoChoi] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLBanDoChoi] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QLBanDoChoi] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLBanDoChoi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLBanDoChoi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLBanDoChoi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLBanDoChoi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLBanDoChoi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLBanDoChoi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLBanDoChoi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLBanDoChoi] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QLBanDoChoi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLBanDoChoi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLBanDoChoi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLBanDoChoi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLBanDoChoi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLBanDoChoi] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLBanDoChoi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLBanDoChoi] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLBanDoChoi] SET  MULTI_USER 
GO
ALTER DATABASE [QLBanDoChoi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLBanDoChoi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLBanDoChoi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLBanDoChoi] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [QLBanDoChoi] SET DELAYED_DURABILITY = DISABLED 
GO
USE [QLBanDoChoi]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Admin](
	[UserAdmin] [varchar](50) NOT NULL,
	[PassAdmin] [varchar](50) NOT NULL,
	[Hoten] [nvarchar](50) NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[UserAdmin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChatLieu](
	[MaCL] [int] IDENTITY(1,1) NOT NULL,
	[TenCL] [nvarchar](50) NULL,
 CONSTRAINT [PK_ChatLieu] PRIMARY KEY CLUSTERED 
(
	[MaCL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDonHang](
	[MaDH] [int] NOT NULL,
	[MaDC] [int] NOT NULL,
	[SoLuong] [int] NULL,
	[DonGia] [decimal](18, 0) NULL,
 CONSTRAINT [PK_ChiTietDonHang] PRIMARY KEY CLUSTERED 
(
	[MaDH] ASC,
	[MaDC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoChoi](
	[MaDC] [int] IDENTITY(1,1) NOT NULL,
	[TenDC] [nvarchar](50) NULL,
	[GiaBan] [decimal](18, 0) NULL,
	[MoTa] [nvarchar](max) NULL,
	[NgayCapNhat] [date] NULL,
	[AnhBia] [nvarchar](max) NULL,
	[SoLuongTon] [int] NULL,
	[MaTH] [int] NULL,
	[MaCL] [int] NULL,
	[MaXX] [int] NULL,
	[MaLoai] [int] NULL,
 CONSTRAINT [PK_DoChoi] PRIMARY KEY CLUSTERED 
(
	[MaDC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHang](
	[MaDH] [int] IDENTITY(1,1) NOT NULL,
	[NgayDat] [date] NULL,
	[DaThanhToan] [int] NULL,
	[NgayGiao] [date] NULL,
	[TinhTrangGiao] [int] NULL,
	[MaKH] [int] NULL,
 CONSTRAINT [PK_DonHang] PRIMARY KEY CLUSTERED 
(
	[MaDH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [int] IDENTITY(1,1) NOT NULL,
	[TenKH] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[DienThoai] [char](15) NULL,
	[TaiKhoan] [varchar](50) NULL,
	[MatKhau] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loai](
	[MaLoai] [int] IDENTITY(1,1) NOT NULL,
	[TenLoai] [nvarchar](50) NULL,
 CONSTRAINT [PK_Loai] PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThuongHieu](
	[MaTH] [int] IDENTITY(1,1) NOT NULL,
	[TenTH] [nvarchar](50) NULL,
 CONSTRAINT [PK_ThuongHieu] PRIMARY KEY CLUSTERED 
(
	[MaTH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XuatXu](
	[MaXX] [int] IDENTITY(1,1) NOT NULL,
	[TenXX] [nvarchar](50) NULL,
 CONSTRAINT [PK_XuatXu] PRIMARY KEY CLUSTERED 
(
	[MaXX] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Admin] ([UserAdmin], [PassAdmin], [Hoten]) VALUES (N'admin', N'admin', N'admin')
SET IDENTITY_INSERT [dbo].[ChatLieu] ON 

INSERT [dbo].[ChatLieu] ([MaCL], [TenCL]) VALUES (1, N'Nhựa')
INSERT [dbo].[ChatLieu] ([MaCL], [TenCL]) VALUES (2, N'Đất sét')
INSERT [dbo].[ChatLieu] ([MaCL], [TenCL]) VALUES (3, N'Gỗ')
INSERT [dbo].[ChatLieu] ([MaCL], [TenCL]) VALUES (4, N'Vải')
SET IDENTITY_INSERT [dbo].[ChatLieu] OFF
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaDC], [SoLuong], [DonGia]) VALUES (1, 3, 1, CAST(200000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaDC], [SoLuong], [DonGia]) VALUES (2, 1, 4, CAST(20000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaDC], [SoLuong], [DonGia]) VALUES (2, 2, 5, CAST(100000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaDC], [SoLuong], [DonGia]) VALUES (2, 3, 1, CAST(200000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaDC], [SoLuong], [DonGia]) VALUES (3, 2, 2, CAST(100000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaDC], [SoLuong], [DonGia]) VALUES (4, 2, 2, CAST(100000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaDC], [SoLuong], [DonGia]) VALUES (5, 1, 1, CAST(20000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaDC], [SoLuong], [DonGia]) VALUES (5, 2, 5, CAST(100000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaDC], [SoLuong], [DonGia]) VALUES (6, 1, 3, CAST(20000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaDC], [SoLuong], [DonGia]) VALUES (7, 1, 2, CAST(20000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaDC], [SoLuong], [DonGia]) VALUES (8, 2, 2, CAST(100000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaDC], [SoLuong], [DonGia]) VALUES (9, 1, 2, CAST(20000 AS Decimal(18, 0)))
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaDC], [SoLuong], [DonGia]) VALUES (10, 3, 2, CAST(200000 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[DoChoi] ON 

INSERT [dbo].[DoChoi] ([MaDC], [TenDC], [GiaBan], [MoTa], [NgayCapNhat], [AnhBia], [SoLuongTon], [MaTH], [MaCL], [MaXX], [MaLoai]) VALUES (1, N'YoYo', CAST(20000 AS Decimal(18, 0)), N'1 loại đồ chơi đòi hỏi kỹ thuật và sáng tạo', CAST(N'2018-01-01' AS Date), N'yoyo1.jpg', 100, 1, 1, 1, 1)
INSERT [dbo].[DoChoi] ([MaDC], [TenDC], [GiaBan], [MoTa], [NgayCapNhat], [AnhBia], [SoLuongTon], [MaTH], [MaCL], [MaXX], [MaLoai]) VALUES (2, N'Búp bê', CAST(100000 AS Decimal(18, 0)), N'Đồ chơi cho các bé gái', CAST(N'2018-01-02' AS Date), N'bupbe1.jpg', 100, 2, 1, 2, 2)
INSERT [dbo].[DoChoi] ([MaDC], [TenDC], [GiaBan], [MoTa], [NgayCapNhat], [AnhBia], [SoLuongTon], [MaTH], [MaCL], [MaXX], [MaLoai]) VALUES (3, N'Lego', CAST(200000 AS Decimal(18, 0)), N'Đồ chơi giúp bé sáng tạo hơn', CAST(N'2018-03-01' AS Date), N'lego1.jpg', 100, 3, 1, 3, 3)
INSERT [dbo].[DoChoi] ([MaDC], [TenDC], [GiaBan], [MoTa], [NgayCapNhat], [AnhBia], [SoLuongTon], [MaTH], [MaCL], [MaXX], [MaLoai]) VALUES (9, N'Búp bê loại 2', CAST(40000 AS Decimal(18, 0)), N'do choi cho be', CAST(N'2019-10-16' AS Date), N'bupbe1.jpg', 123, 2, 1, 1, 2)
SET IDENTITY_INSERT [dbo].[DoChoi] OFF
SET IDENTITY_INSERT [dbo].[DonHang] ON 

INSERT [dbo].[DonHang] ([MaDH], [NgayDat], [DaThanhToan], [NgayGiao], [TinhTrangGiao], [MaKH]) VALUES (1, CAST(N'2019-11-06' AS Date), NULL, NULL, NULL, 1)
INSERT [dbo].[DonHang] ([MaDH], [NgayDat], [DaThanhToan], [NgayGiao], [TinhTrangGiao], [MaKH]) VALUES (2, CAST(N'2019-11-06' AS Date), NULL, NULL, NULL, 1)
INSERT [dbo].[DonHang] ([MaDH], [NgayDat], [DaThanhToan], [NgayGiao], [TinhTrangGiao], [MaKH]) VALUES (3, CAST(N'2019-11-06' AS Date), NULL, NULL, NULL, 1)
INSERT [dbo].[DonHang] ([MaDH], [NgayDat], [DaThanhToan], [NgayGiao], [TinhTrangGiao], [MaKH]) VALUES (4, CAST(N'2019-11-06' AS Date), NULL, NULL, NULL, 1)
INSERT [dbo].[DonHang] ([MaDH], [NgayDat], [DaThanhToan], [NgayGiao], [TinhTrangGiao], [MaKH]) VALUES (5, CAST(N'2019-11-06' AS Date), NULL, NULL, NULL, 1)
INSERT [dbo].[DonHang] ([MaDH], [NgayDat], [DaThanhToan], [NgayGiao], [TinhTrangGiao], [MaKH]) VALUES (6, CAST(N'2019-11-06' AS Date), NULL, NULL, NULL, 1)
INSERT [dbo].[DonHang] ([MaDH], [NgayDat], [DaThanhToan], [NgayGiao], [TinhTrangGiao], [MaKH]) VALUES (7, CAST(N'2019-11-06' AS Date), NULL, CAST(N'2019-11-20' AS Date), NULL, 1)
INSERT [dbo].[DonHang] ([MaDH], [NgayDat], [DaThanhToan], [NgayGiao], [TinhTrangGiao], [MaKH]) VALUES (8, CAST(N'2019-11-06' AS Date), NULL, CAST(N'2019-11-01' AS Date), NULL, 1)
INSERT [dbo].[DonHang] ([MaDH], [NgayDat], [DaThanhToan], [NgayGiao], [TinhTrangGiao], [MaKH]) VALUES (9, CAST(N'2019-11-09' AS Date), NULL, CAST(N'2019-11-22' AS Date), NULL, 2)
INSERT [dbo].[DonHang] ([MaDH], [NgayDat], [DaThanhToan], [NgayGiao], [TinhTrangGiao], [MaKH]) VALUES (10, CAST(N'2019-11-11' AS Date), NULL, CAST(N'2019-11-07' AS Date), NULL, 7)
SET IDENTITY_INSERT [dbo].[DonHang] OFF
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [NgaySinh], [DienThoai], [TaiKhoan], [MatKhau], [Email], [DiaChi]) VALUES (1, N'Ly Thac Ninh', CAST(N'1999-12-14' AS Date), N'0123456789     ', N'ninh', N'123', N'ltn@gmail.com', N'TP HCM')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [NgaySinh], [DienThoai], [TaiKhoan], [MatKhau], [Email], [DiaChi]) VALUES (2, N'Le Chi Cuong', CAST(N'1998-11-30' AS Date), N'01234589       ', N'cuongdola', N'abcxyz', N'cuong@mail.com', N'adsadasd')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [NgaySinh], [DienThoai], [TaiKhoan], [MatKhau], [Email], [DiaChi]) VALUES (3, N'Le Chi Cuong A', CAST(N'2019-11-20' AS Date), N'0123456789     ', N'cuong', N'123', N'a@gmail.com', N'adsadasd')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [NgaySinh], [DienThoai], [TaiKhoan], [MatKhau], [Email], [DiaChi]) VALUES (4, N'nguyen van a', CAST(N'2019-11-30' AS Date), N'0123456789     ', N'van', N'abc', N'a@gmail.com', N'adsadasd')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [NgaySinh], [DienThoai], [TaiKhoan], [MatKhau], [Email], [DiaChi]) VALUES (5, N'Ronaldo', CAST(N'2019-11-07' AS Date), N'0123456789     ', N'ro', N'123', N'a@gmail.com', N'adsadasd')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [NgaySinh], [DienThoai], [TaiKhoan], [MatKhau], [Email], [DiaChi]) VALUES (6, N'messi', CAST(N'2019-11-01' AS Date), N'0123456789     ', N'messi', N'123', N'a@gmail.com', N'adsadasd')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [NgaySinh], [DienThoai], [TaiKhoan], [MatKhau], [Email], [DiaChi]) VALUES (7, N'ly van a', CAST(N'2019-11-07' AS Date), N'0123456789     ', N'lya', N'123', N'a@gmail.com', N'adsadasd')
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
SET IDENTITY_INSERT [dbo].[Loai] ON 

INSERT [dbo].[Loai] ([MaLoai], [TenLoai]) VALUES (1, N'YOYO')
INSERT [dbo].[Loai] ([MaLoai], [TenLoai]) VALUES (2, N'BÚP BÊ')
INSERT [dbo].[Loai] ([MaLoai], [TenLoai]) VALUES (3, N'LEGO')
SET IDENTITY_INSERT [dbo].[Loai] OFF
SET IDENTITY_INSERT [dbo].[ThuongHieu] ON 

INSERT [dbo].[ThuongHieu] ([MaTH], [TenTH]) VALUES (1, N'Fisher Price')
INSERT [dbo].[ThuongHieu] ([MaTH], [TenTH]) VALUES (2, N'Mattel')
INSERT [dbo].[ThuongHieu] ([MaTH], [TenTH]) VALUES (3, N'Lego')
INSERT [dbo].[ThuongHieu] ([MaTH], [TenTH]) VALUES (4, N'Little Tikes

')
SET IDENTITY_INSERT [dbo].[ThuongHieu] OFF
SET IDENTITY_INSERT [dbo].[XuatXu] ON 

INSERT [dbo].[XuatXu] ([MaXX], [TenXX]) VALUES (1, N'Hoa Kỳ')
INSERT [dbo].[XuatXu] ([MaXX], [TenXX]) VALUES (2, N'Trung Quốc')
INSERT [dbo].[XuatXu] ([MaXX], [TenXX]) VALUES (3, N'Đan Mạch')
INSERT [dbo].[XuatXu] ([MaXX], [TenXX]) VALUES (4, N'Việt Nam')
SET IDENTITY_INSERT [dbo].[XuatXu] OFF
ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDonHang_DoChoi] FOREIGN KEY([MaDC])
REFERENCES [dbo].[DoChoi] ([MaDC])
GO
ALTER TABLE [dbo].[ChiTietDonHang] CHECK CONSTRAINT [FK_ChiTietDonHang_DoChoi]
GO
ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDonHang_DonHang] FOREIGN KEY([MaDH])
REFERENCES [dbo].[DonHang] ([MaDH])
GO
ALTER TABLE [dbo].[ChiTietDonHang] CHECK CONSTRAINT [FK_ChiTietDonHang_DonHang]
GO
ALTER TABLE [dbo].[DoChoi]  WITH CHECK ADD  CONSTRAINT [FK_DoChoi_ChatLieu] FOREIGN KEY([MaCL])
REFERENCES [dbo].[ChatLieu] ([MaCL])
GO
ALTER TABLE [dbo].[DoChoi] CHECK CONSTRAINT [FK_DoChoi_ChatLieu]
GO
ALTER TABLE [dbo].[DoChoi]  WITH CHECK ADD  CONSTRAINT [FK_DoChoi_Loai] FOREIGN KEY([MaLoai])
REFERENCES [dbo].[Loai] ([MaLoai])
GO
ALTER TABLE [dbo].[DoChoi] CHECK CONSTRAINT [FK_DoChoi_Loai]
GO
ALTER TABLE [dbo].[DoChoi]  WITH CHECK ADD  CONSTRAINT [FK_DoChoi_ThuongHieu] FOREIGN KEY([MaTH])
REFERENCES [dbo].[ThuongHieu] ([MaTH])
GO
ALTER TABLE [dbo].[DoChoi] CHECK CONSTRAINT [FK_DoChoi_ThuongHieu]
GO
ALTER TABLE [dbo].[DoChoi]  WITH CHECK ADD  CONSTRAINT [FK_DoChoi_XuatXu] FOREIGN KEY([MaXX])
REFERENCES [dbo].[XuatXu] ([MaXX])
GO
ALTER TABLE [dbo].[DoChoi] CHECK CONSTRAINT [FK_DoChoi_XuatXu]
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_DonHang_KhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_DonHang_KhachHang]
GO
USE [master]
GO
ALTER DATABASE [QLBanDoChoi] SET  READ_WRITE 
GO
