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

INSERT [dbo].[NHOMNGUOIDUNG] ([ID], [ten], [ma]) VALUES (1, N'admin', NULL)
INSERT [dbo].[NHOMNGUOIDUNG] ([ID], [ten], [ma]) VALUES (2, N'nhanvien_letan', NULL)
INSERT [dbo].[NHOMNGUOIDUNG] ([ID], [ten], [ma]) VALUES (3, N'nhanvien_dichvu', NULL)
INSERT [dbo].[NHOMNGUOIDUNG] ([ID], [ten], [ma]) VALUES (4, N'nhanvien_phong', NULL)
SET IDENTITY_INSERT [dbo].[NHOMNGUOIDUNG] OFF
SET IDENTITY_INSERT [dbo].[QUYEN] ON 

INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (1, N'admin', N'Q-0000001', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (2, N'sua_danhmuc', N'Q-0000002', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (3, N'sua_hethong', N'Q-0000003', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (4, N'lap_baocao', N'Q-0000004', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (5, N'lap_thanhtoan', N'Q-0000005', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (6, N'lap_thuephong', N'Q-0000006', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (7, N'lap_datphong', N'Q-0000007', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (8, N'lap_traphong', N'Q-0000008', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[QUYEN] ([ID], [ten], [ma], [ngaytao], [nguoitao], [ipchinhsua], [ngaychinhsua], [nguoisua]) VALUES (9, N'lap_thanhtoan', N'Q-0000009', NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[QUYEN] OFF

insert into NGUOIDUNG(tendangnhap, hash, tennguoidung) values ('admin', '$2a$11$TNCWZrg1BV2/KiqvQPSIxuDgM.g0tZkdVr6KwKHKbHA/5a/FljTWm', 'admin') 