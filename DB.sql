create database QuanLyThueKhachSan
go

USE [QuanLyThueKhachSan]
GO

/****** Object:  Table [dbo].[CHITIETDATPHONG]    Script Date: 06/01/20 10:29:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETDATPHONG](
	[PHONG_ID] [int] NOT NULL,
	[DATPHONG_ID] [int] NOT NULL,
	[tenkhachhang] [nvarchar](100) NULL,
	[socmt] [varchar](20) NULL,
	[sodienthoai] [varchar](20) NULL,
	[email] [varchar](100) NULL,
	[ngaydukienden] [datetime] NULL,
	[ngaydukiendi] [datetime] NULL,
 CONSTRAINT [PK_CHITIETDATPHONG] PRIMARY KEY CLUSTERED 
(
	[PHONG_ID] ASC,
	[DATPHONG_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHITIETPHANQUYEN]    Script Date: 06/01/20 10:29:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETPHANQUYEN](
	[NHOMNGUOIDUNG_ID] [int] NOT NULL,
	[QUYEN_ID] [int] NOT NULL,
 CONSTRAINT [PK_CHITIETPHANQUYEN] PRIMARY KEY CLUSTERED 
(
	[NHOMNGUOIDUNG_ID] ASC,
	[QUYEN_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHITIETTHUEPHONG]    Script Date: 06/01/20 10:29:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETTHUEPHONG](
	[PHONG_ID] [int] NOT NULL,
	[THUEPHONG_ID] [int] NOT NULL,
	[ngayvao] [datetime] NULL,
	[ngayra] [datetime] NULL,
	[maktra] [varchar](20) NULL,
	[NGUOIDUNG_ID] [int] NULL,
 CONSTRAINT [PK_CHITIETTHUEPHONG] PRIMARY KEY CLUSTERED 
(
	[PHONG_ID] ASC,
	[THUEPHONG_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DATPHONG]    Script Date: 06/01/20 10:29:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DATPHONG](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[KHACHHANG_ID] [int] NULL,
	[ma] [varchar](20) NULL,
 CONSTRAINT [PK_DATPHONG] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DICHVU]    Script Date: 06/01/20 10:29:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DICHVU](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[tendichvu] [nvarchar](50) NOT NULL,
	[dongia] [int] NULL,
	[ma] [varchar](10) NULL,
 CONSTRAINT [PK_DICHVU] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 06/01/20 10:29:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ma] [varchar](20) NULL,
	[tenkhachhang] [nvarchar](100) NOT NULL,
	[gioitinh] [bit] NULL,
	[socmt] [varchar](20) NULL,
	[sodienthoai] [varchar](20) NULL,
	[email] [varchar](100) NULL,
 CONSTRAINT [PK_KHACHHANG] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAIPHONG]    Script Date: 06/01/20 10:29:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAIPHONG](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[tenloaiphong] [nvarchar](50) NOT NULL,
	[ghichu] [nvarchar](max) NULL,
	[ma] [varchar](20) NULL,
	[anh] [char](500) NULL,
	[khungnhin] [nvarchar](100) NULL,
	[dientich] [int] NULL,
	[giuong] [nvarchar](100) NULL,
	[nguoilon] [int] NULL,
	[trecon] [int] NULL,
	[thongtin] [nvarchar](max) NULL,
 CONSTRAINT [PK_LOAIPHONG] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAITINHTRANG]    Script Date: 06/01/20 10:29:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAITINHTRANG](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ma] [varchar](20) NULL,
	[ten] [nvarchar](50) NULL,
 CONSTRAINT [PK_LOAITINHTRANG] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LUUTRU]    Script Date: 06/01/20 10:29:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LUUTRU](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ngaychinhsua] [datetime] NULL,
	[NGUOIDUNG_ID] [int] NULL,
	[loaihanhdong] [nvarchar](50) NULL,
	[ghichu] [nvarchar](max) NULL,
 CONSTRAINT [PK_LUUTRU] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NGUOIDUNG]    Script Date: 06/01/20 10:29:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NGUOIDUNG](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[tendangnhap] [varchar](50) NULL,
	[hash] [varchar](max) NULL,
	[tennguoidung] [nvarchar](100) NULL,
	[sodienthoai] [varchar](20) NULL,
	[ngaysinh] [date] NULL,
	[diachi] [nvarchar](max) NULL,
	[gioitinh] [bit] NULL,
	[avatar] [nvarchar](max) NULL,
	[malaymatkhau] [varchar](5) NULL,
	[NHOMNGUOIDUNG_ID] [int] NULL,
 CONSTRAINT [PK_NGUOIDUNG] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHOMNGUOIDUNG]    Script Date: 06/01/20 10:29:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHOMNGUOIDUNG](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ten] [nvarchar](50) NOT NULL,
	[ma] [varchar](20) NULL,
 CONSTRAINT [PK_NHOMNGUOIDUNG] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHONG]    Script Date: 06/01/20 10:29:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHONG](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ma] [varchar](20) NULL,
	[giathue] [int] NULL,
	[sotang] [int] NULL,
	[ghichu] [nvarchar](max) NULL,
	[LOAIPHONG_ID] [int] NULL,
	[LOAITINHTRANG_ID] [int] NULL,
 CONSTRAINT [PK_PHONG] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QUYEN]    Script Date: 06/01/20 10:29:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QUYEN](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ten] [nvarchar](50) NULL,
	[ma] [varchar](10) NULL,
	[ngaytao] [datetime] NULL,
	[nguoitao] [int] NULL,
	[ipchinhsua] [varchar](50) NULL,
	[ngaychinhsua] [datetime] NULL,
	[nguoisua] [int] NULL,
 CONSTRAINT [PK_QUYEN] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SUDUNGDICHVU]    Script Date: 06/01/20 10:29:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SUDUNGDICHVU](
	[THUEPHONG_ID] [int] NOT NULL,
	[DICHVU_ID] [int] NOT NULL,
	[ngaysudung] [date] NULL,
	[soluong] [int] NULL,
	[thanhtien] [int] NULL,
	[NGUOIDUNG_ID] [int] NULL,
 CONSTRAINT [PK_SUDUNGDICHVU] PRIMARY KEY CLUSTERED 
(
	[THUEPHONG_ID] ASC,
	[DICHVU_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THANHTOAN]    Script Date: 06/01/20 10:29:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THANHTOAN](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ngaytra] [date] NULL,
	[tienphong] [int] NULL,
	[maktra] [varchar](20) NULL,
	[NGUOIDUNG_ID] [int] NULL,
	[THUEPHONG_ID] [int] NOT NULL,
 CONSTRAINT [PK_THANHTOAN] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THUEPHONG]    Script Date: 06/01/20 10:29:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THUEPHONG](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ma] [varchar](20) NULL,
	[NGUOIDUNG_ID] [int] NULL,
	[KHACHHANG_ID] [int] NULL,
 CONSTRAINT [PK_THUEPHONG] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VATTU]    Script Date: 06/01/20 10:29:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VATTU](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ten] [nvarchar](100) NULL,
	[ngaymua] [date] NULL,
	[ngaysudung] [date] NULL,
	[soluong] [int] NULL,
	[mota] [nvarchar](max) NULL,
	[sotien] [int] NULL,
	[PHONG_ID] [int] NULL,
 CONSTRAINT [PK_VATTU] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[CHITIETDATPHONG]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETDATPHONG_DATPHONG] FOREIGN KEY([DATPHONG_ID])
REFERENCES [dbo].[DATPHONG] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CHITIETDATPHONG] CHECK CONSTRAINT [FK_CHITIETDATPHONG_DATPHONG]
GO
ALTER TABLE [dbo].[CHITIETDATPHONG]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETDATPHONG_PHONG] FOREIGN KEY([PHONG_ID])
REFERENCES [dbo].[PHONG] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CHITIETDATPHONG] CHECK CONSTRAINT [FK_CHITIETDATPHONG_PHONG]
GO
ALTER TABLE [dbo].[CHITIETPHANQUYEN]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETPHANQUYEN_NHOMNGUOIDUNG] FOREIGN KEY([NHOMNGUOIDUNG_ID])
REFERENCES [dbo].[NHOMNGUOIDUNG] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CHITIETPHANQUYEN] CHECK CONSTRAINT [FK_CHITIETPHANQUYEN_NHOMNGUOIDUNG]
GO
ALTER TABLE [dbo].[CHITIETPHANQUYEN]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETPHANQUYEN_QUYEN] FOREIGN KEY([QUYEN_ID])
REFERENCES [dbo].[QUYEN] ([ID])
GO
ALTER TABLE [dbo].[CHITIETPHANQUYEN] CHECK CONSTRAINT [FK_CHITIETPHANQUYEN_QUYEN]
GO
ALTER TABLE [dbo].[CHITIETTHUEPHONG]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETTHUEPHONG_NGUOIDUNG] FOREIGN KEY([NGUOIDUNG_ID])
REFERENCES [dbo].[NGUOIDUNG] ([ID])
GO
ALTER TABLE [dbo].[CHITIETTHUEPHONG] CHECK CONSTRAINT [FK_CHITIETTHUEPHONG_NGUOIDUNG]
GO
ALTER TABLE [dbo].[CHITIETTHUEPHONG]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETTHUEPHONG_PHONG] FOREIGN KEY([PHONG_ID])
REFERENCES [dbo].[PHONG] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CHITIETTHUEPHONG] CHECK CONSTRAINT [FK_CHITIETTHUEPHONG_PHONG]
GO
ALTER TABLE [dbo].[CHITIETTHUEPHONG]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETTHUEPHONG_THUEPHONG] FOREIGN KEY([THUEPHONG_ID])
REFERENCES [dbo].[THUEPHONG] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CHITIETTHUEPHONG] CHECK CONSTRAINT [FK_CHITIETTHUEPHONG_THUEPHONG]
GO
ALTER TABLE [dbo].[DATPHONG]  WITH CHECK ADD  CONSTRAINT [FK_DATPHONG_KHACHHANG] FOREIGN KEY([KHACHHANG_ID])
REFERENCES [dbo].[KHACHHANG] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DATPHONG] CHECK CONSTRAINT [FK_DATPHONG_KHACHHANG]
GO
ALTER TABLE [dbo].[LUUTRU]  WITH CHECK ADD  CONSTRAINT [FK_LUUTRU_NGUOIDUNG] FOREIGN KEY([NGUOIDUNG_ID])
REFERENCES [dbo].[NGUOIDUNG] ([ID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[LUUTRU] CHECK CONSTRAINT [FK_LUUTRU_NGUOIDUNG]
GO
ALTER TABLE [dbo].[NGUOIDUNG]  WITH CHECK ADD  CONSTRAINT [FK_NGUOIDUNG_NHOMNGUOIDUNG] FOREIGN KEY([NHOMNGUOIDUNG_ID])
REFERENCES [dbo].[NHOMNGUOIDUNG] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NGUOIDUNG] CHECK CONSTRAINT [FK_NGUOIDUNG_NHOMNGUOIDUNG]
GO
ALTER TABLE [dbo].[PHONG]  WITH CHECK ADD  CONSTRAINT [FK_PHONG_LOAIPHONG] FOREIGN KEY([LOAIPHONG_ID])
REFERENCES [dbo].[LOAIPHONG] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PHONG] CHECK CONSTRAINT [FK_PHONG_LOAIPHONG]
GO
ALTER TABLE [dbo].[PHONG]  WITH CHECK ADD  CONSTRAINT [FK_PHONG_LOAITINHTRANG] FOREIGN KEY([LOAITINHTRANG_ID])
REFERENCES [dbo].[LOAITINHTRANG] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PHONG] CHECK CONSTRAINT [FK_PHONG_LOAITINHTRANG]
GO
ALTER TABLE [dbo].[QUYEN]  WITH CHECK ADD  CONSTRAINT [FK_QUYEN_NGUOIDUNG] FOREIGN KEY([nguoitao])
REFERENCES [dbo].[NGUOIDUNG] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[QUYEN] CHECK CONSTRAINT [FK_QUYEN_NGUOIDUNG]
GO
ALTER TABLE [dbo].[QUYEN]  WITH CHECK ADD  CONSTRAINT [FK_QUYEN_NGUOIDUNG1] FOREIGN KEY([nguoisua])
REFERENCES [dbo].[NGUOIDUNG] ([ID])
GO
ALTER TABLE [dbo].[QUYEN] CHECK CONSTRAINT [FK_QUYEN_NGUOIDUNG1]
GO
ALTER TABLE [dbo].[SUDUNGDICHVU]  WITH CHECK ADD  CONSTRAINT [FK_SUDUNGDICHVU_DICHVU] FOREIGN KEY([DICHVU_ID])
REFERENCES [dbo].[DICHVU] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SUDUNGDICHVU] CHECK CONSTRAINT [FK_SUDUNGDICHVU_DICHVU]
GO
ALTER TABLE [dbo].[SUDUNGDICHVU]  WITH CHECK ADD  CONSTRAINT [FK_SUDUNGDICHVU_NGUOIDUNG] FOREIGN KEY([NGUOIDUNG_ID])
REFERENCES [dbo].[NGUOIDUNG] ([ID])
GO
ALTER TABLE [dbo].[SUDUNGDICHVU] CHECK CONSTRAINT [FK_SUDUNGDICHVU_NGUOIDUNG]
GO
ALTER TABLE [dbo].[SUDUNGDICHVU]  WITH CHECK ADD  CONSTRAINT [FK_SUDUNGDICHVU_THUEPHONG] FOREIGN KEY([THUEPHONG_ID])
REFERENCES [dbo].[THUEPHONG] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SUDUNGDICHVU] CHECK CONSTRAINT [FK_SUDUNGDICHVU_THUEPHONG]
GO
ALTER TABLE [dbo].[THANHTOAN]  WITH CHECK ADD  CONSTRAINT [FK_THANHTOAN_NGUOIDUNG] FOREIGN KEY([NGUOIDUNG_ID])
REFERENCES [dbo].[NGUOIDUNG] ([ID])
GO
ALTER TABLE [dbo].[THANHTOAN] CHECK CONSTRAINT [FK_THANHTOAN_NGUOIDUNG]
GO
ALTER TABLE [dbo].[THANHTOAN]  WITH CHECK ADD  CONSTRAINT [FK_THANHTOAN_THUEPHONG] FOREIGN KEY([THUEPHONG_ID])
REFERENCES [dbo].[THUEPHONG] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[THANHTOAN] CHECK CONSTRAINT [FK_THANHTOAN_THUEPHONG]
GO
ALTER TABLE [dbo].[THUEPHONG]  WITH CHECK ADD  CONSTRAINT [FK_THUEPHONG_KHACHHANG] FOREIGN KEY([KHACHHANG_ID])
REFERENCES [dbo].[KHACHHANG] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[THUEPHONG] CHECK CONSTRAINT [FK_THUEPHONG_KHACHHANG]
GO
ALTER TABLE [dbo].[THUEPHONG]  WITH CHECK ADD  CONSTRAINT [FK_THUEPHONG_NGUOIDUNG] FOREIGN KEY([NGUOIDUNG_ID])
REFERENCES [dbo].[NGUOIDUNG] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[THUEPHONG] CHECK CONSTRAINT [FK_THUEPHONG_NGUOIDUNG]
GO
ALTER TABLE [dbo].[VATTU]  WITH CHECK ADD  CONSTRAINT [FK_VATTU_PHONG] FOREIGN KEY([PHONG_ID])
REFERENCES [dbo].[PHONG] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VATTU] CHECK CONSTRAINT [FK_VATTU_PHONG]
GO

USE [QuanLyThueKhachSan]
GO
USE [QuanLyThueKhachSan]
GO
SET IDENTITY_INSERT [dbo].[LOAIPHONG] ON 

INSERT [dbo].[LOAIPHONG] ([ID], [tenloaiphong], [ghichu], [ma], [anh], [khungnhin], [dientich], [giuong], [nguoilon], [trecon], [thongtin]) VALUES (1, N'Standard', NULL, N'LP-0000001', N'07062020_095044_AM_standard-room-twin.jpg                                                                                                                                                                                                                                                                                                                                                                                                                                                                           ', NULL, NULL, NULL, 1, 0, NULL)
INSERT [dbo].[LOAIPHONG] ([ID], [tenloaiphong], [ghichu], [ma], [anh], [khungnhin], [dientich], [giuong], [nguoilon], [trecon], [thongtin]) VALUES (2, N'Standard Twins', NULL, N'LP-0000002', N'07062020_095116_AM_standard-room-twin.jpg                                                                                                                                                                                                                                                                                                                                                                                                                                                                           ', NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[LOAIPHONG] ([ID], [tenloaiphong], [ghichu], [ma], [anh], [khungnhin], [dientich], [giuong], [nguoilon], [trecon], [thongtin]) VALUES (3, N'Deluxe', NULL, N'LP-0000003', N'07062020_095146_AM_phong-deluxe.jpg                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 ', NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[LOAIPHONG] ([ID], [tenloaiphong], [ghichu], [ma], [anh], [khungnhin], [dientich], [giuong], [nguoilon], [trecon], [thongtin]) VALUES (4, N'Deluxe Twins', NULL, N'LP-0000004', N'07062020_095305_AM_Deluxe-Twin.jpg                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  ', NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[LOAIPHONG] ([ID], [tenloaiphong], [ghichu], [ma], [anh], [khungnhin], [dientich], [giuong], [nguoilon], [trecon], [thongtin]) VALUES (5, N'Superior', NULL, N'LP-0000005', N'07062020_095337_AM_phong-superior.jpg                                                                                                                                                                                                                                                                                                                                                                                                                                                                               ', NULL, NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[LOAIPHONG] ([ID], [tenloaiphong], [ghichu], [ma], [anh], [khungnhin], [dientich], [giuong], [nguoilon], [trecon], [thongtin]) VALUES (6, N'Superior Double', NULL, N'LP-0000006', N'07062020_095357_AM_superior-double.jpg                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', NULL, NULL, NULL, 2, NULL, NULL)
SET IDENTITY_INSERT [dbo].[LOAIPHONG] OFF
SET IDENTITY_INSERT [dbo].[LOAITINHTRANG] ON 

INSERT [dbo].[LOAITINHTRANG] ([ID], [ma], [ten]) VALUES (1, N'TT-0000001', N'TRONG')
INSERT [dbo].[LOAITINHTRANG] ([ID], [ma], [ten]) VALUES (2, N'TT-0000002', N'DATHUE')
INSERT [dbo].[LOAITINHTRANG] ([ID], [ma], [ten]) VALUES (3, N'TT-0000003', N'DATTRUOC')
INSERT [dbo].[LOAITINHTRANG] ([ID], [ma], [ten]) VALUES (4, N'TT-0000004', N'BAN')
INSERT [dbo].[LOAITINHTRANG] ([ID], [ma], [ten]) VALUES (5, N'TT-0000005', N'CHUATHANHTOAN')
INSERT [dbo].[LOAITINHTRANG] ([ID], [ma], [ten]) VALUES (6, N'TT-0000006', N'DATHANHTOAN')
SET IDENTITY_INSERT [dbo].[LOAITINHTRANG] OFF
SET IDENTITY_INSERT [dbo].[NHOMNGUOIDUNG] ON 

INSERT [dbo].[NHOMNGUOIDUNG] ([ID], [ten], [ma]) VALUES (1, N'admin', N'NHOM-0000001')
INSERT [dbo].[NHOMNGUOIDUNG] ([ID], [ten], [ma]) VALUES (2, N'nhanvien_letan', N'NHOM-0000002')
INSERT [dbo].[NHOMNGUOIDUNG] ([ID], [ten], [ma]) VALUES (3, N'nhanvien_ketoan', N'NHOM-0000003')
INSERT [dbo].[NHOMNGUOIDUNG] ([ID], [ten], [ma]) VALUES (4, N'nhanvien_phong', N'NHOM-0000004')
SET IDENTITY_INSERT [dbo].[NHOMNGUOIDUNG] OFF

SET IDENTITY_INSERT [dbo].[QUYEN] ON 

INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (1, N'KHACHHANG_THEM', N'Q-0000001', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (2, N'KHACHHANG_SUA', N'Q-0000002', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (3, N'KHACHHANG_XOA', N'Q-0000003', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (4, N'KHACHHANG_XEM', N'Q-0000004', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (5, N'LOAIPHONG_THEM', N'Q-0000005', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (6, N'LOAIPHONG_SUA', N'Q-0000006', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (7, N'LOAIPHONG_XOA', N'Q-0000007', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (8, N'LOAIPHONG_XEM', N'Q-0000008', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (9, N'PHONG_THEM', N'Q-0000009', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (10, N'PHONG_SUA', N'Q-0000010', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (11, N'PHONG_XOA', N'Q-0000011', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (12, N'PHONG_XEM', N'Q-0000012', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (13, N'THUEPHONG_THEM', N'Q-0000013', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (14, N'THUEPHONG_SUA', N'Q-0000014', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (15, N'THUEPHONG_XOA', N'Q-0000015', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (16, N'THUEPHONG_XEM', N'Q-0000016', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (17, N'THANHTOAN_THEM', N'Q-0000017', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (18, N'THANHTOAN_SUA', N'Q-0000018', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (19, N'THANHTOAN_XOA', N'Q-0000019', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (20, N'THANHTOAN_XEM', N'Q-0000020', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (21, N'DICHVU_THEM', N'Q-0000021', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (22, N'DICHVU_SUA', N'Q-0000022', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (23, N'DICHVU_XOA', N'Q-0000023', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (24, N'DICHVU_XEM', N'Q-0000024', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (25, N'SUDUNGDICHVU_THEM', N'Q-0000025', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (26, N'SUDUNGDICHVU_SUA', N'Q-0000026', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (27, N'SUDUNGDICHVU_XOA', N'Q-0000027', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (28, N'SUDUNGDICHVU_XEM', N'Q-0000028', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (29, N'VATTU_THEM', N'Q-0000029', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (30, N'VATTU_SUA', N'Q-0000030', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (31, N'VATTU_XOA', N'Q-0000031', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (32, N'VATTU_XEM', N'Q-0000032', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (33, N'DATPHONG_THEM', N'Q-0000033', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (34, N'DATPHONG_SUA', N'Q-0000034', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (35, N'DATPHONG_XOA', N'Q-0000035', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (36, N'DATPHONG_XEM', N'Q-0000036', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (37, N'CHITIETDATPHONG_THEM', N'Q-0000037', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (38, N'CHITIETDATPHONG_SUA', N'Q-0000038', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (39, N'CHITIETDATPHONG_XOA', N'Q-0000039', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (40, N'CHITIETDATPHONG_XEM', N'Q-0000040', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (41, N'CHITIETTHUEPHONG_THEM', N'Q-0000041', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (42, N'CHITIETTHUEPHONG_SUA', N'Q-0000042', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (43, N'CHITIETTHUEPHONG_XOA', N'Q-0000043', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (44, N'CHITIETTHUEPHONG_XEM', N'Q-0000044', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (45, N'NHOMNGUOIDUNG_THEM', N'Q-0000045', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (46, N'NHOMNGUOIDUNG_SUA', N'Q-0000046', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (47, N'NHOMNGUOIDUNG_XOA', N'Q-0000047', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (48, N'NHOMNGUOIDUNG_XEM', N'Q-0000048', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (49, N'NGUOIDUNG_THEM', N'Q-0000049', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (50, N'NGUOIDUNG_SUA', N'Q-0000050', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (51, N'NGUOIDUNG_XOA', N'Q-0000051', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (52, N'NGUOIDUNG_XEM', N'Q-0000052', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (53, N'TRAPHONG_THEM', N'Q-0000053', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (54, N'TRAPHONG_SUA', N'Q-0000054', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (55, N'TRAPHONG_XOA', N'Q-0000055', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (56, N'TRAPHONG_XEM', N'Q-0000056', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (57, N'LICHSU_XEM', N'Q-0000057', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (58, N'LOAITINHTRANG_THEM', N'Q-0000058', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (59, N'LOAITINHTRANG_SUA', N'Q-0000059', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (60, N'LOAITINHTRANG_XOA', N'Q-0000060', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (61, N'LOAITINHTRANG_XEM', N'Q-0000061', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (62, N'THONGKEDOANHTHU_XEM', N'Q-0000062', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (63, N'THONGKESOLUONGDATPHONG_XEM', N'Q-0000063', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (64, N'THONGKEDOANHTHUDICHVU_XEM', N'Q-0000064', NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[QUYEN] OFF

INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 1)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 2)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 3)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 4)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 5)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 6)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 8)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 9)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 10)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 12)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 16)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 20)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 21)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 22)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 23)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 24)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 28)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 29)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 30)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 31)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 32)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 36)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 37)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 38)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 39)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 40)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 41)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 42)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 43)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 44)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 45)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 46)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 47)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 48)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 49)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 50)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 51)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 52)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 56)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 57)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 58)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 59)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 60)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 61)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 62)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 63)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (1, 64)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (2, 1)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (2, 2)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (2, 4)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (2, 8)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (2, 12)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (2, 13)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (2, 14)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (2, 16)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (2, 20)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (2, 24)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (2, 25)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (2, 28)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (2, 36)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (2, 40)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (2, 41)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (2, 42)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (2, 43)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (2, 44)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (3, 20)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (3, 25)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (3, 26)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (3, 28)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (3, 32)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (3, 62)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (3, 63)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (3, 64)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (4, 8)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (4, 12)
INSERT [dbo].[CHITIETPHANQUYEN] ([NHOMNGUOIDUNG_ID], [QUYEN_ID]) VALUES (4, 32)

insert into NGUOIDUNG (tendangnhap, hash, tennguoidung, NHOMNGUOIDUNG_ID) values ('admin', N'$2a$11$TNCWZrg1BV2/KiqvQPSIxuDgM.g0tZkdVr6KwKHKbHA/5a/FljTWm', 'admin', 1)

SET IDENTITY_INSERT [dbo].[NGUOIDUNG] ON 
INSERT [dbo].[NGUOIDUNG] ([ID], [tendangnhap], [hash], [tennguoidung], [sodienthoai], [ngaysinh], [diachi], [gioitinh], [avatar], [malaymatkhau], [NHOMNGUOIDUNG_ID]) VALUES (2, N'letan01', N'$2a$11$4mN7DDrWXuv02FRTYCpdD.DFW3gKZGSkw3kgYOE7HYGoGc8e.KqSy', N'Lễ tân 01', N'0326373667', CAST(N'1981-02-13' AS Date), N'asdasd', 1, NULL, NULL, 2)
INSERT [dbo].[NGUOIDUNG] ([ID], [tendangnhap], [hash], [tennguoidung], [sodienthoai], [ngaysinh], [diachi], [gioitinh], [avatar], [malaymatkhau], [NHOMNGUOIDUNG_ID]) VALUES (3, N'buongphong01', N'$2a$11$nQQhpD6nyGMm1pbMTuno7emC1ew6vFBG6cMK5pF13I/3u14OEYub2', N'Buồng phòng 01', N'0124123123', CAST(N'2020-06-17' AS Date), N'asdasd', 0, NULL, NULL, 4)
INSERT [dbo].[NGUOIDUNG] ([ID], [tendangnhap], [hash], [tennguoidung], [sodienthoai], [ngaysinh], [diachi], [gioitinh], [avatar], [malaymatkhau], [NHOMNGUOIDUNG_ID]) VALUES (4, N'ketoan01', N'$2a$11$62KBPLedYbi9eeba5wloJ.7cyhsdH1T2Zk0ovoH8.SZBlzISTMPoa', N'Kế toán 01', N'567657', CAST(N'2020-06-09' AS Date), N'aaaa', 1, NULL, NULL, 3)
SET IDENTITY_INSERT [dbo].[NGUOIDUNG] OFF