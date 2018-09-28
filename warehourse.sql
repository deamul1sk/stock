/****** Chan vkl dfdeqe******/


 USE [master]
GO
/****** Object:  Database [Warehouse]    Script Date: 06/13/2018 10:35:56 ******/
CREATE DATABASE [Warehouse] ON  PRIMARY 
( NAME = N'Warehouse', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\Warehouse.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Warehouse_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\Warehouse_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Warehouse] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Warehouse].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Warehouse] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Warehouse] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Warehouse] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Warehouse] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Warehouse] SET ARITHABORT OFF
GO
ALTER DATABASE [Warehouse] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [Warehouse] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Warehouse] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Warehouse] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Warehouse] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Warehouse] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Warehouse] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Warehouse] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Warehouse] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Warehouse] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Warehouse] SET  DISABLE_BROKER
GO
ALTER DATABASE [Warehouse] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Warehouse] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Warehouse] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Warehouse] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Warehouse] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Warehouse] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [Warehouse] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [Warehouse] SET  READ_WRITE
GO
ALTER DATABASE [Warehouse] SET RECOVERY SIMPLE
GO
ALTER DATABASE [Warehouse] SET  MULTI_USER
GO
ALTER DATABASE [Warehouse] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Warehouse] SET DB_CHAINING OFF
GO
USE [Warehouse]
GO
/****** Object:  Table [dbo].[Proposal]    Script Date: 06/13/2018 10:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proposal](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idStock] [int] NULL,
	[quantity] [int] NULL,
	[isDelete] [int] NULL,
 CONSTRAINT [PK_Proposal] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Proposal] ON
INSERT [dbo].[Proposal] ([id], [idStock], [quantity], [isDelete]) VALUES (6, 9, 0, 1)
INSERT [dbo].[Proposal] ([id], [idStock], [quantity], [isDelete]) VALUES (7, 10, -12, 0)
SET IDENTITY_INSERT [dbo].[Proposal] OFF
/****** Object:  Table [dbo].[Supply]    Script Date: 06/13/2018 10:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supply](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Supply] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Supply] ON
INSERT [dbo].[Supply] ([id], [name]) VALUES (2, N'Faces')
INSERT [dbo].[Supply] ([id], [name]) VALUES (3, N'Deamz')
SET IDENTITY_INSERT [dbo].[Supply] OFF
/****** Object:  Table [dbo].[Input]    Script Date: 06/13/2018 10:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Input](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idSupply] [int] NULL,
	[idProduct] [int] NULL,
	[quantity] [int] NULL,
	[date] [date] NULL,
 CONSTRAINT [PK_Input] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Input] ON
INSERT [dbo].[Input] ([id], [idSupply], [idProduct], [quantity], [date]) VALUES (9, 2, 10, 5, CAST(0x593E0B00 AS Date))
INSERT [dbo].[Input] ([id], [idSupply], [idProduct], [quantity], [date]) VALUES (10, 2, 11, 10, CAST(0x593E0B00 AS Date))
INSERT [dbo].[Input] ([id], [idSupply], [idProduct], [quantity], [date]) VALUES (11, 3, 10, 20, CAST(0x593E0B00 AS Date))
SET IDENTITY_INSERT [dbo].[Input] OFF
/****** Object:  Table [dbo].[Stock]    Script Date: 06/13/2018 10:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idProduct] [int] NULL,
	[nhap] [int] NULL,
	[da] [int] NULL,
	[con] [int] NULL,
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Stock] ON
INSERT [dbo].[Stock] ([id], [idProduct], [nhap], [da], [con]) VALUES (9, 10, 25, 12, 0)
INSERT [dbo].[Stock] ([id], [idProduct], [nhap], [da], [con]) VALUES (10, 11, 10, 22, 0)
SET IDENTITY_INSERT [dbo].[Stock] OFF
/****** Object:  Table [dbo].[Detail_Stock]    Script Date: 06/13/2018 10:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detail_Stock](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idStock] [int] NULL,
	[dateBegin] [date] NULL,
	[dateEnd] [date] NULL,
	[nhap] [int] NULL,
	[da] [int] NULL,
	[con] [int] NULL,
 CONSTRAINT [PK_Detail_Stock] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sold]    Script Date: 06/13/2018 10:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sold](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idDetail_Product] [int] NULL,
	[quantity] [int] NULL,
	[date] [date] NULL,
 CONSTRAINT [PK_Sold] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Sold] ON
INSERT [dbo].[Sold] ([id], [idDetail_Product], [quantity], [date]) VALUES (5, 6, 12, CAST(0x593E0B00 AS Date))
INSERT [dbo].[Sold] ([id], [idDetail_Product], [quantity], [date]) VALUES (6, 7, 22, CAST(0x593E0B00 AS Date))
SET IDENTITY_INSERT [dbo].[Sold] OFF
/****** Object:  Table [dbo].[Product]    Script Date: 06/13/2018 10:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[price] [decimal](11, 2) NULL,
 CONSTRAINT [PK__Product__3213E83F03317E3D] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Product] ON
INSERT [dbo].[Product] ([id], [name], [price]) VALUES (10, N'MacBook', CAST(231.42 AS Decimal(11, 2)))
INSERT [dbo].[Product] ([id], [name], [price]) VALUES (11, N'Admed', CAST(31.58 AS Decimal(11, 2)))
SET IDENTITY_INSERT [dbo].[Product] OFF
/****** Object:  Table [dbo].[Detail_Product]    Script Date: 06/13/2018 10:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detail_Product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idProduct] [int] NULL,
	[idBill] [int] NULL,
	[price] [decimal](11, 2) NULL,
	[quantity] [int] NULL,
 CONSTRAINT [PK_Detail_Product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Detail_Product] ON
INSERT [dbo].[Detail_Product] ([id], [idProduct], [idBill], [price], [quantity]) VALUES (6, 10, 5, CAST(32.57 AS Decimal(11, 2)), 12)
INSERT [dbo].[Detail_Product] ([id], [idProduct], [idBill], [price], [quantity]) VALUES (7, 11, 4, CAST(21.21 AS Decimal(11, 2)), 22)
SET IDENTITY_INSERT [dbo].[Detail_Product] OFF
/****** Object:  Table [dbo].[Bill]    Script Date: 06/13/2018 10:35:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[address] [nvarchar](50) NULL,
	[phone] [nvarchar](50) NULL,
 CONSTRAINT [PK__Bill__3213E83F7F60ED59] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bill] ON
INSERT [dbo].[Bill] ([id], [name], [address], [phone]) VALUES (4, N'Tran Khanh', N'Lodon', N'0989245325')
INSERT [dbo].[Bill] ([id], [name], [address], [phone]) VALUES (5, N'Pham Khoa', N'Timecity', N'0934573147')
SET IDENTITY_INSERT [dbo].[Bill] OFF
/****** Object:  ForeignKey [FK_Proposal_Stock]    Script Date: 06/13/2018 10:35:57 ******/
ALTER TABLE [dbo].[Proposal]  WITH CHECK ADD  CONSTRAINT [FK_Proposal_Stock] FOREIGN KEY([idStock])
REFERENCES [dbo].[Stock] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Proposal] CHECK CONSTRAINT [FK_Proposal_Stock]
GO
/****** Object:  ForeignKey [FK_Input_Product]    Script Date: 06/13/2018 10:35:57 ******/
ALTER TABLE [dbo].[Input]  WITH CHECK ADD  CONSTRAINT [FK_Input_Product] FOREIGN KEY([idProduct])
REFERENCES [dbo].[Product] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Input] CHECK CONSTRAINT [FK_Input_Product]
GO
/****** Object:  ForeignKey [FK_Input_Supply]    Script Date: 06/13/2018 10:35:57 ******/
ALTER TABLE [dbo].[Input]  WITH CHECK ADD  CONSTRAINT [FK_Input_Supply] FOREIGN KEY([idSupply])
REFERENCES [dbo].[Supply] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Input] CHECK CONSTRAINT [FK_Input_Supply]
GO
/****** Object:  ForeignKey [FK_Stock_Product]    Script Date: 06/13/2018 10:35:57 ******/
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD  CONSTRAINT [FK_Stock_Product] FOREIGN KEY([idProduct])
REFERENCES [dbo].[Product] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [FK_Stock_Product]
GO
/****** Object:  ForeignKey [FK_Detail_Stock_Stock]    Script Date: 06/13/2018 10:35:57 ******/
ALTER TABLE [dbo].[Detail_Stock]  WITH CHECK ADD  CONSTRAINT [FK_Detail_Stock_Stock] FOREIGN KEY([idStock])
REFERENCES [dbo].[Stock] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Detail_Stock] CHECK CONSTRAINT [FK_Detail_Stock_Stock]
GO
/****** Object:  ForeignKey [FK_Sold_Detail_Product]    Script Date: 06/13/2018 10:35:57 ******/
ALTER TABLE [dbo].[Sold]  WITH CHECK ADD  CONSTRAINT [FK_Sold_Detail_Product] FOREIGN KEY([idDetail_Product])
REFERENCES [dbo].[Detail_Product] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Sold] CHECK CONSTRAINT [FK_Sold_Detail_Product]
GO
/****** Object:  ForeignKey [FK_Detail_Product_Bill]    Script Date: 06/13/2018 10:35:57 ******/
ALTER TABLE [dbo].[Detail_Product]  WITH CHECK ADD  CONSTRAINT [FK_Detail_Product_Bill] FOREIGN KEY([idBill])
REFERENCES [dbo].[Bill] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Detail_Product] CHECK CONSTRAINT [FK_Detail_Product_Bill]
GO
/****** Object:  ForeignKey [FK_Detail_Product_Product]    Script Date: 06/13/2018 10:35:57 ******/
ALTER TABLE [dbo].[Detail_Product]  WITH CHECK ADD  CONSTRAINT [FK_Detail_Product_Product] FOREIGN KEY([idProduct])
REFERENCES [dbo].[Product] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Detail_Product] CHECK CONSTRAINT [FK_Detail_Product_Product]
GO
