USE [master]
GO
/****** Object:  Database [BanHang]    Script Date: 06/11/2018 9:19:55 SA ******/
CREATE DATABASE [BanHang]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BanHang', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\BanHang.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BanHang_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\BanHang_log.ldf' , SIZE = 15680KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BanHang] SET COMPATIBILITY_LEVEL = 90
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BanHang].[dbo].[sp_fulltext_database] @action = 'disable'
end
GO
ALTER DATABASE [BanHang] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BanHang] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BanHang] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BanHang] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BanHang] SET ARITHABORT OFF 
GO
ALTER DATABASE [BanHang] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BanHang] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [BanHang] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BanHang] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BanHang] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BanHang] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BanHang] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BanHang] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BanHang] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BanHang] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BanHang] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BanHang] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BanHang] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BanHang] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BanHang] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BanHang] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BanHang] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BanHang] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BanHang] SET RECOVERY FULL 
GO
ALTER DATABASE [BanHang] SET  MULTI_USER 
GO
ALTER DATABASE [BanHang] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BanHang] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BanHang] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BanHang] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BanHang', N'ON'
GO
USE [BanHang]
GO
/****** Object:  Table [dbo].[tblChiTietHDN]    Script Date: 06/11/2018 9:19:55 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblChiTietHDN](
	[MaHD] [nvarchar](20) NOT NULL,
	[MaMatH] [nvarchar](20) NOT NULL,
	[SoLuong] [float] NOT NULL,
	[DonGia] [decimal](18, 1) NULL,
 CONSTRAINT [PK_tblChiTietHDN] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC,
	[MaMatH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblChiTietHDX]    Script Date: 06/11/2018 9:19:55 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblChiTietHDX](
	[MaMatH] [nvarchar](20) NOT NULL,
	[MaHD] [nvarchar](20) NOT NULL,
	[SoLuong] [float] NOT NULL,
	[DonGia] [decimal](18, 1) NOT NULL,
 CONSTRAINT [PK_tblChiTietHDX] PRIMARY KEY CLUSTERED 
(
	[MaMatH] ASC,
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblDangNhap]    Script Date: 06/11/2018 9:19:55 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblDangNhap](
	[TaiKhoan] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](50) NOT NULL,
	[DiaChi] [nvarchar](200) NOT NULL,
	[DienThoai] [varchar](15) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblGiaBan]    Script Date: 06/11/2018 9:19:55 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblGiaBan](
	[MaMatH] [nvarchar](20) NOT NULL,
	[MaKH] [nvarchar](20) NOT NULL,
	[GiaBan] [decimal](18, 1) NULL,
 CONSTRAINT [PK_tblGiaBan] PRIMARY KEY CLUSTERED 
(
	[MaMatH] ASC,
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblHoaDonNhap]    Script Date: 06/11/2018 9:19:55 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblHoaDonNhap](
	[MaHD] [nvarchar](20) NOT NULL,
	[NgayNhap] [datetime] NOT NULL,
	[TongTien] [decimal](18, 1) NULL,
	[GhiChu] [nvarchar](255) NULL,
 CONSTRAINT [PK__tblHoaDonNhap__023D5A04] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblHoaDonXuat]    Script Date: 06/11/2018 9:19:55 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblHoaDonXuat](
	[MaHD] [nvarchar](20) NOT NULL,
	[MaNhanVien] [nvarchar](20) NOT NULL,
	[NgayXuat] [datetime] NOT NULL,
	[TongTien] [decimal](18, 1) NULL,
	[GhiChu] [nvarchar](255) NULL,
	[TongTienGoc] [decimal](18, 0) NULL,
 CONSTRAINT [PK__tblHoaDonXuat__09DE7BCC] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblKhachHang]    Script Date: 06/11/2018 9:19:55 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblKhachHang](
	[MaKH] [nvarchar](20) NOT NULL,
	[TenKH] [nvarchar](50) NOT NULL,
	[DiaChi] [nvarchar](50) NULL,
	[SoDT] [nvarchar](50) NULL,
	[NoCu] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblKhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblMatHang]    Script Date: 06/11/2018 9:19:55 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMatHang](
	[MaMatH] [nvarchar](20) NOT NULL,
	[TenMatH] [nvarchar](50) NOT NULL,
	[SoLuong] [float] NOT NULL,
	[DonGia] [decimal](18, 1) NOT NULL,
 CONSTRAINT [PK__tblMatHang__78B3EFCA] PRIMARY KEY CLUSTERED 
(
	[MaMatH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblNhanVien]    Script Date: 06/11/2018 9:19:55 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblNhanVien](
	[MaNhanVien] [nvarchar](20) NOT NULL,
	[TenNhanVien] [nvarchar](50) NOT NULL,
	[DiaChi] [nvarchar](100) NOT NULL,
	[DienThoai] [nvarchar](15) NULL,
 CONSTRAINT [PK_tblNhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[v_doanhthu]    Script Date: 06/11/2018 9:19:55 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create view [dbo].[v_doanhthu]
as
	select Month(tblHoaDonNhap.NgayNhap) Tháng,Year(tblHoaDonNhap.NgayNhap) Năm,sum(tblChiTietHDN.SoLuong*tblChiTietHDN.DonGia) Tổng_nhập,sum(tblChiTietHDX.SoLuong*tblChiTietHDX.DonGia) Tổng_xuất
	from ((((tblChiTietHDN inner join tblHoaDonNhap on tblChiTietHDN.MaHD=tblHoaDonNhap.MaHD) 
	inner join tblMatHang on tblMatHang.MaMatH=tblChiTietHDN.MaMatH)
	inner join tblChiTietHDX on tblChiTietHDX.MaMatH=tblMatHang.MaMatH)
	inner join tblHoaDonXuat on tblChiTietHDX.MaHD=tblHoaDonXuat.MaHD)
	where (Month(tblHoaDonNhap.NgayNhap)=Month(tblHoaDonXuat.NgayXuat)) 
	and (Year(tblHoaDonNhap.NgayNhap)=Year(tblHoaDonXuat.NgayXuat))
	group by tblHoaDonNhap.NgayNhap





GO
/****** Object:  View [dbo].[v_GiaBan]    Script Date: 06/11/2018 9:19:55 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[v_GiaBan]
AS
SELECT DISTINCT(tblMatHang.TenMatH) [Tên mặt hàng],tblMatHang.SoLuong [Số lượng tồn],tblChiTietHDN.SoLuong [Số lượng nhập thêm],tblMatHang.DonGia [Giá cũ],tblChiTietHDN.DonGia [Giá nhập],ROUND((((tblMatHang.SoLuong*(tblMatHang.DonGia+20000))+(tblChiTietHDN.SoLuong*(tblChiTietHDN.DonGia+20000)))/(tblMatHang.SoLuong+tblChiTietHDN.SoLuong)),-4) [Giá bán]
FROM tblMatHang INNER JOIN tblChiTietHDN
	ON tblMatHang.MaMatH=tblChiTietHDN.MaMatH
GROUP BY tblMatHang.TenMatH,tblMatHang.SoLuong,tblChiTietHDN.SoLuong,tblMatHang.DonGia,tblChiTietHDN.DonGia





GO
INSERT [dbo].[tblDangNhap] ([TaiKhoan], [MatKhau], [DiaChi], [DienThoai]) VALUES (N'admin', N'admin', N'TQD', N'0915458345')
ALTER TABLE [dbo].[tblChiTietHDN]  WITH CHECK ADD  CONSTRAINT [FK_tblChiTietHDN_tblHoaDonNhap_MaHD] FOREIGN KEY([MaHD])
REFERENCES [dbo].[tblHoaDonNhap] ([MaHD])
GO
ALTER TABLE [dbo].[tblChiTietHDN] CHECK CONSTRAINT [FK_tblChiTietHDN_tblHoaDonNhap_MaHD]
GO
ALTER TABLE [dbo].[tblChiTietHDN]  WITH CHECK ADD  CONSTRAINT [FK_tblChiTietHDN_tblMatHang] FOREIGN KEY([MaMatH])
REFERENCES [dbo].[tblMatHang] ([MaMatH])
GO
ALTER TABLE [dbo].[tblChiTietHDN] CHECK CONSTRAINT [FK_tblChiTietHDN_tblMatHang]
GO
ALTER TABLE [dbo].[tblChiTietHDX]  WITH CHECK ADD  CONSTRAINT [FK_tblChiTietHDX_tblHoaDonXuat] FOREIGN KEY([MaHD])
REFERENCES [dbo].[tblHoaDonXuat] ([MaHD])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tblChiTietHDX] CHECK CONSTRAINT [FK_tblChiTietHDX_tblHoaDonXuat]
GO
ALTER TABLE [dbo].[tblChiTietHDX]  WITH CHECK ADD  CONSTRAINT [FK_tblChiTietHDX_tblMatHang] FOREIGN KEY([MaMatH])
REFERENCES [dbo].[tblMatHang] ([MaMatH])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tblChiTietHDX] CHECK CONSTRAINT [FK_tblChiTietHDX_tblMatHang]
GO
ALTER TABLE [dbo].[tblGiaBan]  WITH CHECK ADD  CONSTRAINT [FK_tblGiaBan_tblKhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[tblKhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[tblGiaBan] CHECK CONSTRAINT [FK_tblGiaBan_tblKhachHang]
GO
ALTER TABLE [dbo].[tblGiaBan]  WITH CHECK ADD  CONSTRAINT [FK_tblGiaBan_tblMatHang] FOREIGN KEY([MaMatH])
REFERENCES [dbo].[tblMatHang] ([MaMatH])
GO
ALTER TABLE [dbo].[tblGiaBan] CHECK CONSTRAINT [FK_tblGiaBan_tblMatHang]
GO
ALTER TABLE [dbo].[tblHoaDonXuat]  WITH CHECK ADD  CONSTRAINT [FK_tblHoaDonXuat_tblNhanVien_MaNhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[tblNhanVien] ([MaNhanVien])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tblHoaDonXuat] CHECK CONSTRAINT [FK_tblHoaDonXuat_tblNhanVien_MaNhanVien]
GO
ALTER TABLE [dbo].[tblChiTietHDN]  WITH CHECK ADD  CONSTRAINT [CK__tblChiTie__SoLuo__07F6335A] CHECK  (([SoLuong]>(0)))
GO
ALTER TABLE [dbo].[tblChiTietHDN] CHECK CONSTRAINT [CK__tblChiTie__SoLuo__07F6335A]
GO
ALTER TABLE [dbo].[tblChiTietHDX]  WITH CHECK ADD  CONSTRAINT [CK__tblChiTie__SoLuo__0F975522] CHECK  (([SoLuong]>(0)))
GO
ALTER TABLE [dbo].[tblChiTietHDX] CHECK CONSTRAINT [CK__tblChiTie__SoLuo__0F975522]
GO
USE [master]
GO
ALTER DATABASE [BanHang] SET  READ_WRITE 
GO
