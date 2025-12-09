USE [master]
GO
/****** Object:  Database [MilkStoreManagement]    Script Date: 12/9/2025 11:19:24 PM ******/
CREATE DATABASE [MilkStoreManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MilkStoreManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.TOANDT11\MSSQL\DATA\MilkStoreManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MilkStoreManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.TOANDT11\MSSQL\DATA\MilkStoreManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [MilkStoreManagement] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MilkStoreManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MilkStoreManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MilkStoreManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MilkStoreManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MilkStoreManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MilkStoreManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [MilkStoreManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MilkStoreManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MilkStoreManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MilkStoreManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MilkStoreManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MilkStoreManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MilkStoreManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MilkStoreManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MilkStoreManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MilkStoreManagement] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MilkStoreManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MilkStoreManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MilkStoreManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MilkStoreManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MilkStoreManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MilkStoreManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MilkStoreManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MilkStoreManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [MilkStoreManagement] SET  MULTI_USER 
GO
ALTER DATABASE [MilkStoreManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MilkStoreManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MilkStoreManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MilkStoreManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MilkStoreManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MilkStoreManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'MilkStoreManagement', N'ON'
GO
ALTER DATABASE [MilkStoreManagement] SET QUERY_STORE = ON
GO
ALTER DATABASE [MilkStoreManagement] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [MilkStoreManagement]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 12/9/2025 11:19:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[category_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[description] [nvarchar](max) NULL,
	[created_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerGroups]    Script Date: 12/9/2025 11:19:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerGroups](
	[group_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[description] [nvarchar](max) NULL,
	[created_at] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[group_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 12/9/2025 11:19:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[customer_id] [int] IDENTITY(1,1) NOT NULL,
	[full_name] [nvarchar](100) NOT NULL,
	[email] [nvarchar](100) NULL,
	[phone] [nvarchar](15) NULL,
	[address] [nvarchar](max) NULL,
	[created_at] [datetime] NULL,
	[group_id] [int] NULL,
	[statusCus] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Discounts]    Script Date: 12/9/2025 11:19:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discounts](
	[discount_id] [int] IDENTITY(1,1) NOT NULL,
	[code] [nvarchar](50) NOT NULL,
	[description] [nvarchar](max) NULL,
	[discount_type] [nvarchar](20) NULL,
	[value] [decimal](10, 2) NOT NULL,
	[start_date] [datetime] NOT NULL,
	[end_date] [datetime] NOT NULL,
	[status] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[discount_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Details]    Script Date: 12/9/2025 11:19:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Details](
	[order_detail_id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [int] NOT NULL,
	[product_id] [int] NOT NULL,
	[price] [decimal](10, 2) NOT NULL,
	[quantity] [int] NOT NULL,
	[subtotal]  AS ([price]*[quantity]) PERSISTED,
PRIMARY KEY CLUSTERED 
(
	[order_detail_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 12/9/2025 11:19:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[order_id] [int] IDENTITY(1,1) NOT NULL,
	[customer_id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[total_price] [decimal](10, 2) NOT NULL,
	[order_date] [datetime] NULL,
	[status] [nvarchar](20) NULL,
	[created_at] [datetime] NULL,
	[discount_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 12/9/2025 11:19:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[payment_id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [int] NOT NULL,
	[payment_method] [nvarchar](20) NULL,
	[payment_date] [datetime] NULL,
	[amount_paid] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[payment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_Discounts]    Script Date: 12/9/2025 11:19:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Discounts](
	[product_discount_id] [int] IDENTITY(1,1) NOT NULL,
	[product_id] [int] NOT NULL,
	[discount_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[product_discount_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 12/9/2025 11:19:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[product_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[category_id] [int] NOT NULL,
	[brand] [nvarchar](50) NULL,
	[supplier_id] [int] NOT NULL,
	[price] [decimal](10, 2) NOT NULL,
	[quantity] [int] NOT NULL,
	[expiry_date] [date] NOT NULL,
	[created_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock_Tracking]    Script Date: 12/9/2025 11:19:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock_Tracking](
	[stock_id] [int] IDENTITY(1,1) NOT NULL,
	[product_id] [int] NOT NULL,
	[quantity_change] [int] NOT NULL,
	[reason] [nvarchar](max) NOT NULL,
	[timestamp] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[stock_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 12/9/2025 11:19:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[supplier_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[email] [nvarchar](100) NULL,
	[phone] [nvarchar](15) NULL,
	[address] [nvarchar](max) NULL,
	[created_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[supplier_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/9/2025 11:19:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](255) NOT NULL,
	[full_name] [nvarchar](100) NOT NULL,
	[email] [nvarchar](100) NULL,
	[phone] [nvarchar](15) NULL,
	[role] [nvarchar](10) NULL,
	[created_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([category_id], [name], [description], [created_at]) VALUES (1, N'Sữa tươi', N'Sữa tươi nguyên chất', CAST(N'2025-06-26T02:11:51.743' AS DateTime))
INSERT [dbo].[Categories] ([category_id], [name], [description], [created_at]) VALUES (2, N'Sữa đặc', N'Sữa đặc có đường', CAST(N'2025-06-26T02:11:51.743' AS DateTime))
INSERT [dbo].[Categories] ([category_id], [name], [description], [created_at]) VALUES (3, N'Sữa bột', N'Sữa bột cho trẻ em', CAST(N'2025-06-26T02:11:51.743' AS DateTime))
INSERT [dbo].[Categories] ([category_id], [name], [description], [created_at]) VALUES (4, N'Sữa chua', N'Sữa chua ăn', CAST(N'2025-06-26T02:11:51.743' AS DateTime))
INSERT [dbo].[Categories] ([category_id], [name], [description], [created_at]) VALUES (5, N'Sữa hạt', N'Các loại sữa làm từ hạt như đậu nành, hạnh nhân', CAST(N'2025-06-26T02:13:59.127' AS DateTime))
INSERT [dbo].[Categories] ([category_id], [name], [description], [created_at]) VALUES (6, N'Sữa bò organic', N'Sữa bò được nuôi theo tiêu chuẩn organic', CAST(N'2025-06-26T02:13:59.127' AS DateTime))
INSERT [dbo].[Categories] ([category_id], [name], [description], [created_at]) VALUES (7, N'Sữa không đường', N'Các loại sữa hoàn toàn không thêm đường', CAST(N'2025-06-26T02:13:59.127' AS DateTime))
INSERT [dbo].[Categories] ([category_id], [name], [description], [created_at]) VALUES (8, N'Sữa thanh trùng', N'Sữa đã qua xử lý thanh trùng', CAST(N'2025-06-26T02:13:59.127' AS DateTime))
INSERT [dbo].[Categories] ([category_id], [name], [description], [created_at]) VALUES (9, N'Sữa non', N'Sữa của bò mẹ trong 72 giờ đầu sau sinh', CAST(N'2025-06-26T02:13:59.127' AS DateTime))
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[CustomerGroups] ON 

INSERT [dbo].[CustomerGroups] ([group_id], [name], [description], [created_at]) VALUES (3, N'Bắc Từ liêm', N'', CAST(N'2025-12-06T09:43:43.847' AS DateTime))
INSERT [dbo].[CustomerGroups] ([group_id], [name], [description], [created_at]) VALUES (5, N'Khách Hàng', N'', CAST(N'2025-12-06T09:44:52.980' AS DateTime))
INSERT [dbo].[CustomerGroups] ([group_id], [name], [description], [created_at]) VALUES (13, N'Khách Hàng1', N'', CAST(N'2025-12-06T09:45:59.403' AS DateTime))
SET IDENTITY_INSERT [dbo].[CustomerGroups] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([customer_id], [full_name], [email], [phone], [address], [created_at], [group_id], [statusCus]) VALUES (1, N'Nguyễn Văn A', N'a.nguyen@example.com', N'0912345678', N'789 Đường Sữa, Đà Nẵng', CAST(N'2025-06-26T02:11:51.747' AS DateTime), NULL, N'Active')
INSERT [dbo].[Customers] ([customer_id], [full_name], [email], [phone], [address], [created_at], [group_id], [statusCus]) VALUES (2, N'Trần Thị B', N'b.tran@example.com', N'0934567890', N'321 Đường Sữa, Hải Phòng', CAST(N'2025-06-26T02:11:51.747' AS DateTime), NULL, N'Active')
INSERT [dbo].[Customers] ([customer_id], [full_name], [email], [phone], [address], [created_at], [group_id], [statusCus]) VALUES (3, N'Lê Văn C', N'c.le@example.com', N'0912345123', N'111 Lê Lợi, Hà Nội', CAST(N'2025-06-26T02:13:59.127' AS DateTime), NULL, N'Active')
INSERT [dbo].[Customers] ([customer_id], [full_name], [email], [phone], [address], [created_at], [group_id], [statusCus]) VALUES (4, N'Phạm Thị D', N'd.pham@example.com', N'0987654987', N'222 Nguyễn Huệ, TP.HCM', CAST(N'2025-06-26T02:13:59.127' AS DateTime), NULL, N'Active')
INSERT [dbo].[Customers] ([customer_id], [full_name], [email], [phone], [address], [created_at], [group_id], [statusCus]) VALUES (5, N'Hoàng Văn E', N'e.hoang@example.com', N'0905123456', N'333 Trần Phú, Đà Nẵng', CAST(N'2025-06-26T02:13:59.127' AS DateTime), NULL, N'Inactive')
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Discounts] ON 

INSERT [dbo].[Discounts] ([discount_id], [code], [description], [discount_type], [value], [start_date], [end_date], [status]) VALUES (1, N'DISCOUNT10', N'Giảm giá 10%', N'percentage', CAST(10.00 AS Decimal(10, 2)), CAST(N'2023-01-01T00:00:00.000' AS DateTime), CAST(N'2023-12-31T00:00:00.000' AS DateTime), N'active')
INSERT [dbo].[Discounts] ([discount_id], [code], [description], [discount_type], [value], [start_date], [end_date], [status]) VALUES (2, N'DISCOUNT20', N'Giảm giá 20.000 VNĐ', N'amount', CAST(20000.00 AS Decimal(10, 2)), CAST(N'2023-01-01T00:00:00.000' AS DateTime), CAST(N'2023-12-31T00:00:00.000' AS DateTime), N'active')
INSERT [dbo].[Discounts] ([discount_id], [code], [description], [discount_type], [value], [start_date], [end_date], [status]) VALUES (3, N'SUMMER20', N'Khuyến mãi hè 20%', N'percentage', CAST(20.00 AS Decimal(10, 2)), CAST(N'2023-06-01T00:00:00.000' AS DateTime), CAST(N'2023-08-31T00:00:00.000' AS DateTime), N'active')
INSERT [dbo].[Discounts] ([discount_id], [code], [description], [discount_type], [value], [start_date], [end_date], [status]) VALUES (4, N'MEMBER5', N'Giảm 5% cho thành viên', N'percentage', CAST(5.00 AS Decimal(10, 2)), CAST(N'2023-01-01T00:00:00.000' AS DateTime), CAST(N'2023-12-31T00:00:00.000' AS DateTime), N'active')
INSERT [dbo].[Discounts] ([discount_id], [code], [description], [discount_type], [value], [start_date], [end_date], [status]) VALUES (5, N'FREESHIP', N'Miễn phí vận chuyển', N'amount', CAST(20000.00 AS Decimal(10, 2)), CAST(N'2023-05-01T00:00:00.000' AS DateTime), CAST(N'2023-05-31T00:00:00.000' AS DateTime), N'inactive')
INSERT [dbo].[Discounts] ([discount_id], [code], [description], [discount_type], [value], [start_date], [end_date], [status]) VALUES (6, N'COMBO30', N'Giảm 30k combo 3 sản phẩm', N'amount', CAST(30000.00 AS Decimal(10, 2)), CAST(N'2023-04-01T00:00:00.000' AS DateTime), CAST(N'2023-06-30T00:00:00.000' AS DateTime), N'active')
INSERT [dbo].[Discounts] ([discount_id], [code], [description], [discount_type], [value], [start_date], [end_date], [status]) VALUES (7, N'FIRST10', N'Giảm 10% đơn hàng đầu', N'percentage', CAST(10.00 AS Decimal(10, 2)), CAST(N'2023-01-01T00:00:00.000' AS DateTime), CAST(N'2023-12-31T00:00:00.000' AS DateTime), N'active')
SET IDENTITY_INSERT [dbo].[Discounts] OFF
GO
SET IDENTITY_INSERT [dbo].[Order_Details] ON 

INSERT [dbo].[Order_Details] ([order_detail_id], [order_id], [product_id], [price], [quantity]) VALUES (1, 1, 1, CAST(25000.00 AS Decimal(10, 2)), 2)
INSERT [dbo].[Order_Details] ([order_detail_id], [order_id], [product_id], [price], [quantity]) VALUES (2, 1, 4, CAST(15000.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[Order_Details] ([order_detail_id], [order_id], [product_id], [price], [quantity]) VALUES (3, 2, 2, CAST(30000.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[Order_Details] ([order_detail_id], [order_id], [product_id], [price], [quantity]) VALUES (4, 3, 1, CAST(25000.00 AS Decimal(10, 2)), 4)
INSERT [dbo].[Order_Details] ([order_detail_id], [order_id], [product_id], [price], [quantity]) VALUES (5, 4, 5, CAST(35000.00 AS Decimal(10, 2)), 2)
INSERT [dbo].[Order_Details] ([order_detail_id], [order_id], [product_id], [price], [quantity]) VALUES (6, 5, 2, CAST(30000.00 AS Decimal(10, 2)), 5)
INSERT [dbo].[Order_Details] ([order_detail_id], [order_id], [product_id], [price], [quantity]) VALUES (7, 6, 3, CAST(450000.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[Order_Details] ([order_detail_id], [order_id], [product_id], [price], [quantity]) VALUES (8, 7, 4, CAST(15000.00 AS Decimal(10, 2)), 5)
INSERT [dbo].[Order_Details] ([order_detail_id], [order_id], [product_id], [price], [quantity]) VALUES (9, 8, 1, CAST(25000.00 AS Decimal(10, 2)), 2)
INSERT [dbo].[Order_Details] ([order_detail_id], [order_id], [product_id], [price], [quantity]) VALUES (10, 9, 1, CAST(25000.00 AS Decimal(10, 2)), 4)
INSERT [dbo].[Order_Details] ([order_detail_id], [order_id], [product_id], [price], [quantity]) VALUES (11, 10, 1, CAST(25000.00 AS Decimal(10, 2)), 3)
INSERT [dbo].[Order_Details] ([order_detail_id], [order_id], [product_id], [price], [quantity]) VALUES (12, 11, 3, CAST(450000.00 AS Decimal(10, 2)), 3)
INSERT [dbo].[Order_Details] ([order_detail_id], [order_id], [product_id], [price], [quantity]) VALUES (13, 12, 2, CAST(30000.00 AS Decimal(10, 2)), 6)
INSERT [dbo].[Order_Details] ([order_detail_id], [order_id], [product_id], [price], [quantity]) VALUES (1010, 1009, 3, CAST(450000.00 AS Decimal(10, 2)), 4)
INSERT [dbo].[Order_Details] ([order_detail_id], [order_id], [product_id], [price], [quantity]) VALUES (1011, 1010, 5, CAST(18000.00 AS Decimal(10, 2)), 4)
INSERT [dbo].[Order_Details] ([order_detail_id], [order_id], [product_id], [price], [quantity]) VALUES (2010, 2009, 1, CAST(25000.00 AS Decimal(10, 2)), 3)
SET IDENTITY_INSERT [dbo].[Order_Details] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([order_id], [customer_id], [user_id], [total_price], [order_date], [status], [created_at], [discount_id]) VALUES (1, 1, 1, CAST(50000.00 AS Decimal(10, 2)), CAST(N'2025-06-26T02:11:51.750' AS DateTime), N'completed', CAST(N'2025-06-26T02:11:51.750' AS DateTime), NULL)
INSERT [dbo].[Orders] ([order_id], [customer_id], [user_id], [total_price], [order_date], [status], [created_at], [discount_id]) VALUES (2, 2, 2, CAST(30000.00 AS Decimal(10, 2)), CAST(N'2025-06-26T02:11:51.750' AS DateTime), N'pending', CAST(N'2025-06-26T02:11:51.750' AS DateTime), NULL)
INSERT [dbo].[Orders] ([order_id], [customer_id], [user_id], [total_price], [order_date], [status], [created_at], [discount_id]) VALUES (3, 3, 3, CAST(100000.00 AS Decimal(10, 2)), CAST(N'2025-06-26T02:13:59.130' AS DateTime), N'completed', CAST(N'2025-06-26T02:13:59.130' AS DateTime), 3)
INSERT [dbo].[Orders] ([order_id], [customer_id], [user_id], [total_price], [order_date], [status], [created_at], [discount_id]) VALUES (4, 4, 4, CAST(75000.00 AS Decimal(10, 2)), CAST(N'2025-06-26T02:13:59.130' AS DateTime), N'completed', CAST(N'2025-06-26T02:13:59.130' AS DateTime), 1)
INSERT [dbo].[Orders] ([order_id], [customer_id], [user_id], [total_price], [order_date], [status], [created_at], [discount_id]) VALUES (5, 5, 2, CAST(150000.00 AS Decimal(10, 2)), CAST(N'2025-06-26T02:13:59.130' AS DateTime), N'pending', CAST(N'2025-06-26T02:13:59.130' AS DateTime), NULL)
INSERT [dbo].[Orders] ([order_id], [customer_id], [user_id], [total_price], [order_date], [status], [created_at], [discount_id]) VALUES (6, 1, 3, CAST(50000.00 AS Decimal(10, 2)), CAST(N'2025-06-26T02:13:59.130' AS DateTime), N'cancelled', CAST(N'2025-06-26T02:13:59.130' AS DateTime), NULL)
INSERT [dbo].[Orders] ([order_id], [customer_id], [user_id], [total_price], [order_date], [status], [created_at], [discount_id]) VALUES (7, 2, 5, CAST(80000.00 AS Decimal(10, 2)), CAST(N'2025-06-26T02:13:59.130' AS DateTime), N'completed', CAST(N'2025-06-26T02:13:59.130' AS DateTime), 5)
INSERT [dbo].[Orders] ([order_id], [customer_id], [user_id], [total_price], [order_date], [status], [created_at], [discount_id]) VALUES (8, 1, 1, CAST(50000.00 AS Decimal(10, 2)), CAST(N'2025-06-26T13:55:14.993' AS DateTime), N'completed', CAST(N'2025-06-26T13:55:14.997' AS DateTime), NULL)
INSERT [dbo].[Orders] ([order_id], [customer_id], [user_id], [total_price], [order_date], [status], [created_at], [discount_id]) VALUES (9, 5, 1, CAST(100000.00 AS Decimal(10, 2)), CAST(N'2025-11-21T14:31:14.997' AS DateTime), N'completed', CAST(N'2025-11-21T14:31:14.997' AS DateTime), NULL)
INSERT [dbo].[Orders] ([order_id], [customer_id], [user_id], [total_price], [order_date], [status], [created_at], [discount_id]) VALUES (10, 5, 1, CAST(75000.00 AS Decimal(10, 2)), CAST(N'2025-11-21T14:58:16.507' AS DateTime), N'completed', CAST(N'2025-11-21T14:58:16.520' AS DateTime), NULL)
INSERT [dbo].[Orders] ([order_id], [customer_id], [user_id], [total_price], [order_date], [status], [created_at], [discount_id]) VALUES (11, 5, 1, CAST(1350000.00 AS Decimal(10, 2)), CAST(N'2025-11-21T15:33:56.517' AS DateTime), N'completed', CAST(N'2025-11-21T15:33:56.517' AS DateTime), NULL)
INSERT [dbo].[Orders] ([order_id], [customer_id], [user_id], [total_price], [order_date], [status], [created_at], [discount_id]) VALUES (12, 5, 1, CAST(180000.00 AS Decimal(10, 2)), CAST(N'2025-11-21T16:07:00.563' AS DateTime), N'completed', CAST(N'2025-11-21T16:07:00.563' AS DateTime), NULL)
INSERT [dbo].[Orders] ([order_id], [customer_id], [user_id], [total_price], [order_date], [status], [created_at], [discount_id]) VALUES (1009, 5, 1, CAST(1800000.00 AS Decimal(10, 2)), CAST(N'2025-11-25T08:55:19.463' AS DateTime), N'completed', CAST(N'2025-11-25T08:55:19.463' AS DateTime), NULL)
INSERT [dbo].[Orders] ([order_id], [customer_id], [user_id], [total_price], [order_date], [status], [created_at], [discount_id]) VALUES (1010, 1, 1, CAST(64800.00 AS Decimal(10, 2)), CAST(N'2025-11-27T08:28:45.567' AS DateTime), N'completed', CAST(N'2025-11-27T08:28:45.567' AS DateTime), NULL)
INSERT [dbo].[Orders] ([order_id], [customer_id], [user_id], [total_price], [order_date], [status], [created_at], [discount_id]) VALUES (2009, 1, 1, CAST(37500.00 AS Decimal(10, 2)), CAST(N'2025-12-09T20:50:50.590' AS DateTime), N'completed', CAST(N'2025-12-09T20:50:50.593' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Payments] ON 

INSERT [dbo].[Payments] ([payment_id], [order_id], [payment_method], [payment_date], [amount_paid]) VALUES (1, 1, N'cash', CAST(N'2025-06-26T02:11:51.750' AS DateTime), CAST(50000.00 AS Decimal(10, 2)))
INSERT [dbo].[Payments] ([payment_id], [order_id], [payment_method], [payment_date], [amount_paid]) VALUES (2, 2, N'credit_card', CAST(N'2025-06-26T02:11:51.750' AS DateTime), CAST(30000.00 AS Decimal(10, 2)))
INSERT [dbo].[Payments] ([payment_id], [order_id], [payment_method], [payment_date], [amount_paid]) VALUES (3, 3, N'e-wallet', CAST(N'2025-06-26T02:13:59.133' AS DateTime), CAST(100000.00 AS Decimal(10, 2)))
INSERT [dbo].[Payments] ([payment_id], [order_id], [payment_method], [payment_date], [amount_paid]) VALUES (4, 4, N'bank_transfer', CAST(N'2025-06-26T02:13:59.133' AS DateTime), CAST(75000.00 AS Decimal(10, 2)))
INSERT [dbo].[Payments] ([payment_id], [order_id], [payment_method], [payment_date], [amount_paid]) VALUES (5, 5, N'cash', CAST(N'2025-06-26T02:13:59.133' AS DateTime), CAST(150000.00 AS Decimal(10, 2)))
INSERT [dbo].[Payments] ([payment_id], [order_id], [payment_method], [payment_date], [amount_paid]) VALUES (6, 6, NULL, CAST(N'2025-06-26T02:13:59.133' AS DateTime), CAST(0.00 AS Decimal(10, 2)))
INSERT [dbo].[Payments] ([payment_id], [order_id], [payment_method], [payment_date], [amount_paid]) VALUES (7, 7, N'credit_card', CAST(N'2025-06-26T02:13:59.133' AS DateTime), CAST(80000.00 AS Decimal(10, 2)))
INSERT [dbo].[Payments] ([payment_id], [order_id], [payment_method], [payment_date], [amount_paid]) VALUES (8, 8, N'cash', CAST(N'2025-06-26T13:55:15.017' AS DateTime), CAST(50000.00 AS Decimal(10, 2)))
INSERT [dbo].[Payments] ([payment_id], [order_id], [payment_method], [payment_date], [amount_paid]) VALUES (9, 9, N'cash', CAST(N'2025-11-21T14:31:15.030' AS DateTime), CAST(100000.00 AS Decimal(10, 2)))
INSERT [dbo].[Payments] ([payment_id], [order_id], [payment_method], [payment_date], [amount_paid]) VALUES (10, 10, N'cash', CAST(N'2025-11-21T14:58:16.537' AS DateTime), CAST(75000.00 AS Decimal(10, 2)))
INSERT [dbo].[Payments] ([payment_id], [order_id], [payment_method], [payment_date], [amount_paid]) VALUES (11, 11, N'cash', CAST(N'2025-11-21T15:33:56.547' AS DateTime), CAST(1350000.00 AS Decimal(10, 2)))
INSERT [dbo].[Payments] ([payment_id], [order_id], [payment_method], [payment_date], [amount_paid]) VALUES (12, 12, N'cash', CAST(N'2025-11-21T16:07:00.610' AS DateTime), CAST(180000.00 AS Decimal(10, 2)))
INSERT [dbo].[Payments] ([payment_id], [order_id], [payment_method], [payment_date], [amount_paid]) VALUES (1009, 1009, N'cash', CAST(N'2025-11-25T08:55:19.480' AS DateTime), CAST(1800000.00 AS Decimal(10, 2)))
INSERT [dbo].[Payments] ([payment_id], [order_id], [payment_method], [payment_date], [amount_paid]) VALUES (1010, 1010, N'cash', CAST(N'2025-11-27T08:28:45.600' AS DateTime), CAST(64800.00 AS Decimal(10, 2)))
INSERT [dbo].[Payments] ([payment_id], [order_id], [payment_method], [payment_date], [amount_paid]) VALUES (2009, 2009, N'cash', CAST(N'2025-12-09T20:50:50.617' AS DateTime), CAST(50000.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Payments] OFF
GO
SET IDENTITY_INSERT [dbo].[Product_Discounts] ON 

INSERT [dbo].[Product_Discounts] ([product_discount_id], [product_id], [discount_id]) VALUES (1, 1, 1)
INSERT [dbo].[Product_Discounts] ([product_discount_id], [product_id], [discount_id]) VALUES (2, 2, 2)
INSERT [dbo].[Product_Discounts] ([product_discount_id], [product_id], [discount_id]) VALUES (3, 3, 1)
INSERT [dbo].[Product_Discounts] ([product_discount_id], [product_id], [discount_id]) VALUES (4, 4, 2)
INSERT [dbo].[Product_Discounts] ([product_discount_id], [product_id], [discount_id]) VALUES (5, 5, 3)
INSERT [dbo].[Product_Discounts] ([product_discount_id], [product_id], [discount_id]) VALUES (6, 1, 4)
INSERT [dbo].[Product_Discounts] ([product_discount_id], [product_id], [discount_id]) VALUES (7, 2, 5)
SET IDENTITY_INSERT [dbo].[Product_Discounts] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([product_id], [name], [category_id], [brand], [supplier_id], [price], [quantity], [expiry_date], [created_at]) VALUES (1, N'Sữa tươi Vinamilk', 1, N'Vinamilk', 1, CAST(25000.00 AS Decimal(10, 2)), 100, CAST(N'2024-12-31' AS Date), CAST(N'2025-06-26T02:11:51.747' AS DateTime))
INSERT [dbo].[Products] ([product_id], [name], [category_id], [brand], [supplier_id], [price], [quantity], [expiry_date], [created_at]) VALUES (2, N'Sữa đặc Ông Thọ', 2, N'Ông Thọ', 1, CAST(30000.00 AS Decimal(10, 2)), 50, CAST(N'2025-06-30' AS Date), CAST(N'2025-06-26T02:11:51.747' AS DateTime))
INSERT [dbo].[Products] ([product_id], [name], [category_id], [brand], [supplier_id], [price], [quantity], [expiry_date], [created_at]) VALUES (3, N'Sữa bột Dielac', 3, N'Dielac', 2, CAST(450000.00 AS Decimal(10, 2)), 30, CAST(N'2025-01-15' AS Date), CAST(N'2025-06-26T02:11:51.747' AS DateTime))
INSERT [dbo].[Products] ([product_id], [name], [category_id], [brand], [supplier_id], [price], [quantity], [expiry_date], [created_at]) VALUES (4, N'Sữa chua Vinamilk', 4, N'Vinamilk', 1, CAST(15000.00 AS Decimal(10, 2)), 200, CAST(N'2024-11-30' AS Date), CAST(N'2025-06-26T02:11:51.747' AS DateTime))
INSERT [dbo].[Products] ([product_id], [name], [category_id], [brand], [supplier_id], [price], [quantity], [expiry_date], [created_at]) VALUES (5, N'Sữa đậu nành Fami', 5, N'Vinamilk', 3, CAST(18000.00 AS Decimal(10, 2)), 80, CAST(N'2024-10-31' AS Date), CAST(N'2025-06-26T02:13:59.130' AS DateTime))
INSERT [dbo].[Products] ([product_id], [name], [category_id], [brand], [supplier_id], [price], [quantity], [expiry_date], [created_at]) VALUES (6, N'Sữa bò Dutch Lady', 6, N'Dutch Lady', 4, CAST(32000.00 AS Decimal(10, 2)), 60, CAST(N'2024-11-30' AS Date), CAST(N'2025-06-26T02:13:59.130' AS DateTime))
INSERT [dbo].[Products] ([product_id], [name], [category_id], [brand], [supplier_id], [price], [quantity], [expiry_date], [created_at]) VALUES (7, N'Sữa tươi không đường TH', 7, N'TH True Milk', 1, CAST(28000.00 AS Decimal(10, 2)), 120, CAST(N'2024-09-15' AS Date), CAST(N'2025-06-26T02:13:59.130' AS DateTime))
INSERT [dbo].[Products] ([product_id], [name], [category_id], [brand], [supplier_id], [price], [quantity], [expiry_date], [created_at]) VALUES (8, N'Sữa thanh trùng Mộc Châu', 8, N'Mộc Châu', 2, CAST(35000.00 AS Decimal(10, 2)), 50, CAST(N'2024-08-20' AS Date), CAST(N'2025-06-26T02:13:59.130' AS DateTime))
INSERT [dbo].[Products] ([product_id], [name], [category_id], [brand], [supplier_id], [price], [quantity], [expiry_date], [created_at]) VALUES (9, N'Sữa non Colostrum', 9, N'ColosBaby', 5, CAST(550000.00 AS Decimal(10, 2)), 25, CAST(N'2025-01-10' AS Date), CAST(N'2025-06-26T02:13:59.130' AS DateTime))
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Stock_Tracking] ON 

INSERT [dbo].[Stock_Tracking] ([stock_id], [product_id], [quantity_change], [reason], [timestamp]) VALUES (1, 1, 10, N'Nhập hàng mới', CAST(N'2025-06-26T02:11:51.750' AS DateTime))
INSERT [dbo].[Stock_Tracking] ([stock_id], [product_id], [quantity_change], [reason], [timestamp]) VALUES (2, 2, -5, N'Bán hàng', CAST(N'2025-06-26T02:11:51.750' AS DateTime))
INSERT [dbo].[Stock_Tracking] ([stock_id], [product_id], [quantity_change], [reason], [timestamp]) VALUES (3, 2, 20, N'Nhập hàng lần 1', CAST(N'2025-06-26T02:13:59.133' AS DateTime))
INSERT [dbo].[Stock_Tracking] ([stock_id], [product_id], [quantity_change], [reason], [timestamp]) VALUES (4, 3, -10, N'Bán cho khách lẻ', CAST(N'2025-06-26T02:13:59.133' AS DateTime))
INSERT [dbo].[Stock_Tracking] ([stock_id], [product_id], [quantity_change], [reason], [timestamp]) VALUES (5, 4, 50, N'Nhập hàng từ nhà cung cấp mới', CAST(N'2025-06-26T02:13:59.133' AS DateTime))
INSERT [dbo].[Stock_Tracking] ([stock_id], [product_id], [quantity_change], [reason], [timestamp]) VALUES (6, 5, -2, N'Bán combo khuyến mãi', CAST(N'2025-06-26T02:13:59.133' AS DateTime))
INSERT [dbo].[Stock_Tracking] ([stock_id], [product_id], [quantity_change], [reason], [timestamp]) VALUES (7, 1, -15, N'Bán sỉ cho đại lý', CAST(N'2025-06-26T02:13:59.133' AS DateTime))
SET IDENTITY_INSERT [dbo].[Stock_Tracking] OFF
GO
SET IDENTITY_INSERT [dbo].[Suppliers] ON 

INSERT [dbo].[Suppliers] ([supplier_id], [name], [email], [phone], [address], [created_at]) VALUES (1, N'Công ty Sữa Việt Nam', N'contact@vnmilk.com', N'0123456789', N'123 Đường Sữa, Hà Nội', CAST(N'2025-06-26T02:11:51.747' AS DateTime))
INSERT [dbo].[Suppliers] ([supplier_id], [name], [email], [phone], [address], [created_at]) VALUES (2, N'Công ty Sữa Mộc', N'info@mocmilk.com', N'0987654321', N'456 Đường Sữa, TP.HCM', CAST(N'2025-06-26T02:11:51.747' AS DateTime))
INSERT [dbo].[Suppliers] ([supplier_id], [name], [email], [phone], [address], [created_at]) VALUES (3, N'Công ty TNHH Sữa Thiên Nhiên', N'thiennhan@example.com', N'0987123456', N'789 Trần Hưng Đạo, HCM', CAST(N'2025-06-26T02:13:59.127' AS DateTime))
INSERT [dbo].[Suppliers] ([supplier_id], [name], [email], [phone], [address], [created_at]) VALUES (4, N'Nông trại Sữa Xanh', N'xanhmilk@example.com', N'0918234567', N'456 Lê Duẩn, Đà Lạt', CAST(N'2025-06-26T02:13:59.127' AS DateTime))
INSERT [dbo].[Suppliers] ([supplier_id], [name], [email], [phone], [address], [created_at]) VALUES (5, N'Công ty Sữa Hữu Cơ Việt', N'organicviet@example.com', N'0905123789', N'321 Ngô Quyền, Hà Nội', CAST(N'2025-06-26T02:13:59.127' AS DateTime))
INSERT [dbo].[Suppliers] ([supplier_id], [name], [email], [phone], [address], [created_at]) VALUES (6, N'Trang trại Bò Sữa Tiên Tiến', N'tientien@example.com', N'0934567123', N'159 Lý Thường Kiệt, Bình Dương', CAST(N'2025-06-26T02:13:59.127' AS DateTime))
INSERT [dbo].[Suppliers] ([supplier_id], [name], [email], [phone], [address], [created_at]) VALUES (7, N'Công ty Xuất nhập khẩu Sữa', N'importmilk@example.com', N'0978654321', N'753 Nguyễn Văn Linh, Đà Nẵng', CAST(N'2025-06-26T02:13:59.127' AS DateTime))
SET IDENTITY_INSERT [dbo].[Suppliers] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([user_id], [username], [password], [full_name], [email], [phone], [role], [created_at]) VALUES (1, N'admin', N'admin123', N'Quản trị viên', N'admin@example.com', N'0123456789', N'admin', CAST(N'2025-06-26T02:11:51.750' AS DateTime))
INSERT [dbo].[Users] ([user_id], [username], [password], [full_name], [email], [phone], [role], [created_at]) VALUES (2, N'staff1', N'staff123', N'Nhân viên 1', N'staff1@example.com', N'0987654321', N'staff', CAST(N'2025-06-26T02:11:51.750' AS DateTime))
INSERT [dbo].[Users] ([user_id], [username], [password], [full_name], [email], [phone], [role], [created_at]) VALUES (3, N'manager', N'manager123', N'Quản lý cửa hàng', N'manager@example.com', N'0998877665', N'admin', CAST(N'2025-06-26T02:13:59.130' AS DateTime))
INSERT [dbo].[Users] ([user_id], [username], [password], [full_name], [email], [phone], [role], [created_at]) VALUES (4, N'staff2', N'staff456', N'Nhân viên 2', N'staff2@example.com', N'0988776655', N'staff', CAST(N'2025-06-26T02:13:59.130' AS DateTime))
INSERT [dbo].[Users] ([user_id], [username], [password], [full_name], [email], [phone], [role], [created_at]) VALUES (5, N'staff3', N'staff789', N'Nhân viên 3', N'staff3@example.com', N'0977665544', N'staff', CAST(N'2025-06-26T02:13:59.130' AS DateTime))
INSERT [dbo].[Users] ([user_id], [username], [password], [full_name], [email], [phone], [role], [created_at]) VALUES (6, N'cashier1', N'cashier123', N'Thu ngân 1', N'cashier1@example.com', N'0966554433', N'staff', CAST(N'2025-06-26T02:13:59.130' AS DateTime))
INSERT [dbo].[Users] ([user_id], [username], [password], [full_name], [email], [phone], [role], [created_at]) VALUES (7, N'inventory', N'inventory123', N'Quản kho', N'inventory@example.com', N'0955443322', N'staff', CAST(N'2025-06-26T02:13:59.130' AS DateTime))
INSERT [dbo].[Users] ([user_id], [username], [password], [full_name], [email], [phone], [role], [created_at]) VALUES (9, N'admin1', N'1', N'Quản lý cửa hàng', N'manager@example.com', N'0998877665', N'admin', CAST(N'2025-06-26T02:16:11.973' AS DateTime))
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Categori__72E12F1BBFB808B9]    Script Date: 12/9/2025 11:19:24 PM ******/
ALTER TABLE [dbo].[Categories] ADD UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_CustomerGroups_Name]    Script Date: 12/9/2025 11:19:24 PM ******/
ALTER TABLE [dbo].[CustomerGroups] ADD  CONSTRAINT [UQ_CustomerGroups_Name] UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Discount__357D4CF9D2CA2E3B]    Script Date: 12/9/2025 11:19:24 PM ******/
ALTER TABLE [dbo].[Discounts] ADD UNIQUE NONCLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__F3DBC5725CDA474C]    Script Date: 12/9/2025 11:19:24 PM ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Categories] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[CustomerGroups] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Customers] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Customers] ADD  CONSTRAINT [DF_Customers_Status]  DEFAULT (N'Active') FOR [statusCus]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (getdate()) FOR [order_date]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Payments] ADD  DEFAULT (getdate()) FOR [payment_date]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((0)) FOR [quantity]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Stock_Tracking] ADD  DEFAULT (getdate()) FOR [timestamp]
GO
ALTER TABLE [dbo].[Suppliers] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_CustomerGroups] FOREIGN KEY([group_id])
REFERENCES [dbo].[CustomerGroups] ([group_id])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_CustomerGroups]
GO
ALTER TABLE [dbo].[Order_Details]  WITH CHECK ADD FOREIGN KEY([order_id])
REFERENCES [dbo].[Orders] ([order_id])
GO
ALTER TABLE [dbo].[Order_Details]  WITH CHECK ADD FOREIGN KEY([product_id])
REFERENCES [dbo].[Products] ([product_id])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([customer_id])
REFERENCES [dbo].[Customers] ([customer_id])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([discount_id])
REFERENCES [dbo].[Discounts] ([discount_id])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([user_id])
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD FOREIGN KEY([order_id])
REFERENCES [dbo].[Orders] ([order_id])
GO
ALTER TABLE [dbo].[Product_Discounts]  WITH CHECK ADD FOREIGN KEY([discount_id])
REFERENCES [dbo].[Discounts] ([discount_id])
GO
ALTER TABLE [dbo].[Product_Discounts]  WITH CHECK ADD FOREIGN KEY([product_id])
REFERENCES [dbo].[Products] ([product_id])
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD FOREIGN KEY([category_id])
REFERENCES [dbo].[Categories] ([category_id])
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD FOREIGN KEY([supplier_id])
REFERENCES [dbo].[Suppliers] ([supplier_id])
GO
ALTER TABLE [dbo].[Stock_Tracking]  WITH CHECK ADD FOREIGN KEY([product_id])
REFERENCES [dbo].[Products] ([product_id])
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [CK_Customers_Status] CHECK  (([statusCus]=N'Inactive' OR [statusCus]=N'Active'))
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [CK_Customers_Status]
GO
ALTER TABLE [dbo].[Discounts]  WITH CHECK ADD CHECK  (([discount_type]=N'percentage' OR [discount_type]=N'amount'))
GO
ALTER TABLE [dbo].[Discounts]  WITH CHECK ADD CHECK  (([status]=N'active' OR [status]=N'inactive'))
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD CHECK  (([status]=N'pending' OR [status]=N'completed' OR [status]=N'cancelled'))
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD CHECK  (([payment_method]=N'cash' OR [payment_method]=N'credit_card' OR [payment_method]=N'bank_transfer' OR [payment_method]=N'e-wallet'))
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD CHECK  (([role]=N'admin' OR [role]=N'staff'))
GO
USE [master]
GO
ALTER DATABASE [MilkStoreManagement] SET  READ_WRITE 
GO
