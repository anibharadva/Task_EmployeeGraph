USE [test_carsales]
GO
/****** Object:  Table [dbo].[Carsales]    Script Date: 11/26/2019 9:18:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Carsales](
	[CarMaker] [varchar](50) NOT NULL,
	[CarModel] [varchar](50) NOT NULL,
	[SalePriceInDollar] [decimal](15, 4) NOT NULL,
	[SaleDate] [datetime] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Carsales] ([CarMaker], [CarModel], [SalePriceInDollar], [SaleDate]) VALUES (N'Maker A', N'A Model X V6', CAST(100000.0000 AS Decimal(15, 4)), CAST(0x0000AB0E00000000 AS DateTime))
GO
INSERT [dbo].[Carsales] ([CarMaker], [CarModel], [SalePriceInDollar], [SaleDate]) VALUES (N'Maker B', N'B Model Z V6', CAST(200000.0000 AS Decimal(15, 4)), CAST(0x0000AB0000000000 AS DateTime))
GO
INSERT [dbo].[Carsales] ([CarMaker], [CarModel], [SalePriceInDollar], [SaleDate]) VALUES (N'Maker C', N'C Model Y 4000', CAST(100000.0000 AS Decimal(15, 4)), CAST(0x0000AAF900000000 AS DateTime))
GO
INSERT [dbo].[Carsales] ([CarMaker], [CarModel], [SalePriceInDollar], [SaleDate]) VALUES (N'Maker A', N'A Model X V6', CAST(200000.0000 AS Decimal(15, 4)), CAST(0x0000AAF400000000 AS DateTime))
GO
INSERT [dbo].[Carsales] ([CarMaker], [CarModel], [SalePriceInDollar], [SaleDate]) VALUES (N'Maker B', N'B Model Z V6', CAST(700000.0000 AS Decimal(15, 4)), CAST(0x0000AAF400000000 AS DateTime))
GO
