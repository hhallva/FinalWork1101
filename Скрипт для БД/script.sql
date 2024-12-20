USE [FinalWork1101]
GO
/****** Object:  Table [dbo].[ExamOrder]    Script Date: 17.12.2024 15:22:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamOrder](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[Status] [nvarchar](30) NOT NULL,
	[Date] [datetime] NOT NULL,
	[DeliveryDate] [datetime] NOT NULL,
	[PickupPointIndex] [int] NOT NULL,
	[PickupCode] [int] NOT NULL,
 CONSTRAINT [PK__ExamOrder] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExamOrderProduct]    Script Date: 17.12.2024 15:22:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamOrderProduct](
	[OrderID] [int] NOT NULL,
	[ProductArticleNumber] [nvarchar](100) NOT NULL,
	[Amount] [smallint] NOT NULL,
 CONSTRAINT [PK__ExamOrde__817A266255BBC081] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC,
	[ProductArticleNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExamPickupPoint]    Script Date: 17.12.2024 15:22:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamPickupPoint](
	[PickupPointIndex] [int] NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Street] [nvarchar](50) NOT NULL,
	[Building] [nvarchar](5) NOT NULL,
 CONSTRAINT [PK_ExamPickupPointIndex] PRIMARY KEY CLUSTERED 
(
	[PickupPointIndex] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExamProduct]    Script Date: 17.12.2024 15:22:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamProduct](
	[ProductArticleNumber] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[Category] [nvarchar](50) NOT NULL,
	[Manufacturer] [nvarchar](50) NOT NULL,
	[Cost] [decimal](19, 4) NOT NULL,
	[DiscountAmount] [tinyint] NULL,
	[QuantityInStock] [int] NOT NULL,
	[Status] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK__ExamProd__2EA7DCD5BF55BCD9] PRIMARY KEY CLUSTERED 
(
	[ProductArticleNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExamRole]    Script Date: 17.12.2024 15:22:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamRole](
	[RoleID] [tinyint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK__ExamRole__8AFACE3AA2D40FB8] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExamUser]    Script Date: 17.12.2024 15:22:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamUser](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [tinyint] NOT NULL,
	[Surname] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Patronymic] [nvarchar](100) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__ExamUser__1788CCAC0829F7A9] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ExamOrder] ON 
GO
INSERT [dbo].[ExamOrder] ([OrderID], [UserID], [Status], [Date], [DeliveryDate], [PickupPointIndex], [PickupCode]) VALUES (1, 1, N'Новый ', CAST(N'2022-05-04T00:00:00.000' AS DateTime), CAST(N'2022-05-10T00:00:00.000' AS DateTime), 443890, 201)
GO
INSERT [dbo].[ExamOrder] ([OrderID], [UserID], [Status], [Date], [DeliveryDate], [PickupPointIndex], [PickupCode]) VALUES (2, NULL, N'Новый ', CAST(N'2022-05-05T00:00:00.000' AS DateTime), CAST(N'2022-05-11T00:00:00.000' AS DateTime), 603379, 202)
GO
INSERT [dbo].[ExamOrder] ([OrderID], [UserID], [Status], [Date], [DeliveryDate], [PickupPointIndex], [PickupCode]) VALUES (3, 2, N'Новый ', CAST(N'2022-05-06T00:00:00.000' AS DateTime), CAST(N'2022-05-12T00:00:00.000' AS DateTime), 603721, 203)
GO
INSERT [dbo].[ExamOrder] ([OrderID], [UserID], [Status], [Date], [DeliveryDate], [PickupPointIndex], [PickupCode]) VALUES (4, NULL, N'Новый ', CAST(N'2022-05-07T00:00:00.000' AS DateTime), CAST(N'2022-05-13T00:00:00.000' AS DateTime), 410172, 204)
GO
INSERT [dbo].[ExamOrder] ([OrderID], [UserID], [Status], [Date], [DeliveryDate], [PickupPointIndex], [PickupCode]) VALUES (5, 3, N'Новый ', CAST(N'2022-05-08T00:00:00.000' AS DateTime), CAST(N'2022-05-14T00:00:00.000' AS DateTime), 420151, 205)
GO
INSERT [dbo].[ExamOrder] ([OrderID], [UserID], [Status], [Date], [DeliveryDate], [PickupPointIndex], [PickupCode]) VALUES (6, NULL, N'Новый ', CAST(N'2022-05-09T00:00:00.000' AS DateTime), CAST(N'2022-05-15T00:00:00.000' AS DateTime), 125061, 206)
GO
INSERT [dbo].[ExamOrder] ([OrderID], [UserID], [Status], [Date], [DeliveryDate], [PickupPointIndex], [PickupCode]) VALUES (7, NULL, N'Новый ', CAST(N'2022-05-10T00:00:00.000' AS DateTime), CAST(N'2022-05-16T00:00:00.000' AS DateTime), 630370, 207)
GO
INSERT [dbo].[ExamOrder] ([OrderID], [UserID], [Status], [Date], [DeliveryDate], [PickupPointIndex], [PickupCode]) VALUES (8, NULL, N'Новый ', CAST(N'2022-05-11T00:00:00.000' AS DateTime), CAST(N'2022-05-17T00:00:00.000' AS DateTime), 614753, 208)
GO
INSERT [dbo].[ExamOrder] ([OrderID], [UserID], [Status], [Date], [DeliveryDate], [PickupPointIndex], [PickupCode]) VALUES (9, 4, N'Новый ', CAST(N'2022-05-12T00:00:00.000' AS DateTime), CAST(N'2022-05-18T00:00:00.000' AS DateTime), 426030, 209)
GO
INSERT [dbo].[ExamOrder] ([OrderID], [UserID], [Status], [Date], [DeliveryDate], [PickupPointIndex], [PickupCode]) VALUES (10, NULL, N'Завершен', CAST(N'2022-05-13T00:00:00.000' AS DateTime), CAST(N'2022-05-19T00:00:00.000' AS DateTime), 630201, 210)
GO
SET IDENTITY_INSERT [dbo].[ExamOrder] OFF
GO
INSERT [dbo].[ExamOrderProduct] ([OrderID], [ProductArticleNumber], [Amount]) VALUES (1, N'F893T5', 2)
GO
INSERT [dbo].[ExamOrderProduct] ([OrderID], [ProductArticleNumber], [Amount]) VALUES (1, N'А112Т4', 2)
GO
INSERT [dbo].[ExamOrderProduct] ([OrderID], [ProductArticleNumber], [Amount]) VALUES (2, N'E530Y6', 1)
GO
INSERT [dbo].[ExamOrderProduct] ([OrderID], [ProductArticleNumber], [Amount]) VALUES (2, N'F346G5', 2)
GO
INSERT [dbo].[ExamOrderProduct] ([OrderID], [ProductArticleNumber], [Amount]) VALUES (3, N'D344Y7', 2)
GO
INSERT [dbo].[ExamOrderProduct] ([OrderID], [ProductArticleNumber], [Amount]) VALUES (3, N'J432E4', 1)
GO
INSERT [dbo].[ExamOrderProduct] ([OrderID], [ProductArticleNumber], [Amount]) VALUES (4, N'D378D3', 2)
GO
INSERT [dbo].[ExamOrderProduct] ([OrderID], [ProductArticleNumber], [Amount]) VALUES (4, N'E245R5', 1)
GO
INSERT [dbo].[ExamOrderProduct] ([OrderID], [ProductArticleNumber], [Amount]) VALUES (5, N'H732R5', 3)
GO
INSERT [dbo].[ExamOrderProduct] ([OrderID], [ProductArticleNumber], [Amount]) VALUES (5, N'R464G6', 2)
GO
INSERT [dbo].[ExamOrderProduct] ([OrderID], [ProductArticleNumber], [Amount]) VALUES (6, N'E573G6', 3)
GO
INSERT [dbo].[ExamOrderProduct] ([OrderID], [ProductArticleNumber], [Amount]) VALUES (6, N'K535G6', 3)
GO
INSERT [dbo].[ExamOrderProduct] ([OrderID], [ProductArticleNumber], [Amount]) VALUES (7, N'F344S4', 6)
GO
INSERT [dbo].[ExamOrderProduct] ([OrderID], [ProductArticleNumber], [Amount]) VALUES (7, N'G532R5', 5)
GO
INSERT [dbo].[ExamOrderProduct] ([OrderID], [ProductArticleNumber], [Amount]) VALUES (8, N'D526R4', 5)
GO
INSERT [dbo].[ExamOrderProduct] ([OrderID], [ProductArticleNumber], [Amount]) VALUES (8, N'S753T5', 4)
GO
INSERT [dbo].[ExamOrderProduct] ([OrderID], [ProductArticleNumber], [Amount]) VALUES (9, N'A436H7', 3)
GO
INSERT [dbo].[ExamOrderProduct] ([OrderID], [ProductArticleNumber], [Amount]) VALUES (9, N'V472S3', 3)
GO
INSERT [dbo].[ExamOrderProduct] ([OrderID], [ProductArticleNumber], [Amount]) VALUES (10, N'E479G6', 1)
GO
INSERT [dbo].[ExamOrderProduct] ([OrderID], [ProductArticleNumber], [Amount]) VALUES (10, N'O875F6', 4)
GO
INSERT [dbo].[ExamPickupPoint] ([PickupPointIndex], [City], [Street], [Building]) VALUES (125061, N'Ангарск', N'Подгорная', N'8')
GO
INSERT [dbo].[ExamPickupPoint] ([PickupPointIndex], [City], [Street], [Building]) VALUES (125703, N'Ангарск', N'Партизанская', N'49')
GO
INSERT [dbo].[ExamPickupPoint] ([PickupPointIndex], [City], [Street], [Building]) VALUES (125837, N'Ангарск', N'Шоссейная', N'40')
GO
INSERT [dbo].[ExamPickupPoint] ([PickupPointIndex], [City], [Street], [Building]) VALUES (190949, N'Ангарск', N'Мичурина', N'26')
GO
INSERT [dbo].[ExamPickupPoint] ([PickupPointIndex], [City], [Street], [Building]) VALUES (344288, N'Ангарск', N'Чехова', N'1')
GO
INSERT [dbo].[ExamPickupPoint] ([PickupPointIndex], [City], [Street], [Building]) VALUES (394060, N'Ангарск', N'Фрунзе', N'43')
GO
INSERT [dbo].[ExamPickupPoint] ([PickupPointIndex], [City], [Street], [Building]) VALUES (394242, N'Ангарск', N'Коммунистическая', N'43')
GO
INSERT [dbo].[ExamPickupPoint] ([PickupPointIndex], [City], [Street], [Building]) VALUES (394782, N'Ангарск', N'Чехова', N'3')
GO
INSERT [dbo].[ExamPickupPoint] ([PickupPointIndex], [City], [Street], [Building]) VALUES (400562, N'Ангарск', N'Зеленая', N'32')
GO
INSERT [dbo].[ExamPickupPoint] ([PickupPointIndex], [City], [Street], [Building]) VALUES (410172, N'Ангарск', N'Северная', N'13')
GO
INSERT [dbo].[ExamPickupPoint] ([PickupPointIndex], [City], [Street], [Building]) VALUES (410542, N'Ангарск', N'Светлая', N'46')
GO
INSERT [dbo].[ExamPickupPoint] ([PickupPointIndex], [City], [Street], [Building]) VALUES (410661, N'Ангарск', N'Школьная', N'50')
GO
INSERT [dbo].[ExamPickupPoint] ([PickupPointIndex], [City], [Street], [Building]) VALUES (420151, N'Ангарск', N'Вишневая', N'32')
GO
INSERT [dbo].[ExamPickupPoint] ([PickupPointIndex], [City], [Street], [Building]) VALUES (426030, N'Ангарск', N'Маяковского', N'44')
GO
INSERT [dbo].[ExamPickupPoint] ([PickupPointIndex], [City], [Street], [Building]) VALUES (443890, N'Ангарск', N'Коммунистическая', N'1')
GO
INSERT [dbo].[ExamPickupPoint] ([PickupPointIndex], [City], [Street], [Building]) VALUES (450375, N'Ангарск', N'Клубная', N'44')
GO
INSERT [dbo].[ExamPickupPoint] ([PickupPointIndex], [City], [Street], [Building]) VALUES (450558, N'Ангарск', N'Набережная', N'30')
GO
INSERT [dbo].[ExamPickupPoint] ([PickupPointIndex], [City], [Street], [Building]) VALUES (450983, N'Ангарск', N'Комсомольская', N'26')
GO
INSERT [dbo].[ExamPickupPoint] ([PickupPointIndex], [City], [Street], [Building]) VALUES (454311, N'Ангарск', N'Новая', N'19')
GO
INSERT [dbo].[ExamPickupPoint] ([PickupPointIndex], [City], [Street], [Building]) VALUES (603002, N'Ангарск', N'Дзержинского', N'28')
GO
INSERT [dbo].[ExamPickupPoint] ([PickupPointIndex], [City], [Street], [Building]) VALUES (603036, N'Ангарск', N'Садовая', N'4')
GO
INSERT [dbo].[ExamPickupPoint] ([PickupPointIndex], [City], [Street], [Building]) VALUES (603379, N'Ангарск', N'Спортивная', N'46')
GO
INSERT [dbo].[ExamPickupPoint] ([PickupPointIndex], [City], [Street], [Building]) VALUES (603721, N'Ангарск', N'Гоголя', N'41')
GO
INSERT [dbo].[ExamPickupPoint] ([PickupPointIndex], [City], [Street], [Building]) VALUES (614164, N'Ангарск', N'Степная', N'30')
GO
INSERT [dbo].[ExamPickupPoint] ([PickupPointIndex], [City], [Street], [Building]) VALUES (614510, N'Ангарск', N'Маяковского', N'47')
GO
INSERT [dbo].[ExamPickupPoint] ([PickupPointIndex], [City], [Street], [Building]) VALUES (614611, N'Ангарск', N'Молодежная', N'50')
GO
INSERT [dbo].[ExamPickupPoint] ([PickupPointIndex], [City], [Street], [Building]) VALUES (614753, N'Ангарск', N'Полевая', N'35')
GO
INSERT [dbo].[ExamPickupPoint] ([PickupPointIndex], [City], [Street], [Building]) VALUES (620839, N'Ангарск', N'Цветочная', N'8')
GO
INSERT [dbo].[ExamPickupPoint] ([PickupPointIndex], [City], [Street], [Building]) VALUES (625283, N'Ангарск', N'Победы', N'46')
GO
INSERT [dbo].[ExamPickupPoint] ([PickupPointIndex], [City], [Street], [Building]) VALUES (625560, N'Ангарск', N'Некрасова', N'12')
GO
INSERT [dbo].[ExamPickupPoint] ([PickupPointIndex], [City], [Street], [Building]) VALUES (625590, N'Ангарск', N'Коммунистическая', N'20')
GO
INSERT [dbo].[ExamPickupPoint] ([PickupPointIndex], [City], [Street], [Building]) VALUES (625683, N'Ангарск', N'8 Марта', N'8')
GO
INSERT [dbo].[ExamPickupPoint] ([PickupPointIndex], [City], [Street], [Building]) VALUES (630201, N'Ангарск', N'Комсомольская', N'17')
GO
INSERT [dbo].[ExamPickupPoint] ([PickupPointIndex], [City], [Street], [Building]) VALUES (630370, N'Ангарск', N'Шоссейная', N'24')
GO
INSERT [dbo].[ExamPickupPoint] ([PickupPointIndex], [City], [Street], [Building]) VALUES (660007, N'Ангарск', N'Октябрьская', N'19')
GO
INSERT [dbo].[ExamPickupPoint] ([PickupPointIndex], [City], [Street], [Building]) VALUES (660540, N'Ангарск', N'Солнечная', N'25')
GO
INSERT [dbo].[ExamProduct] ([ProductArticleNumber], [Name], [Description], [Category], [Manufacturer], [Cost], [DiscountAmount], [QuantityInStock], [Status]) VALUES (N'A436H7', N'Chanel No. 5', N'Легендарный женский парфюм с нежными нотами цветов и ванили.', N'Парфюмерия', N'Chanel', CAST(2399.0000 AS Decimal(19, 4)), 99, 16, N'В наличии')
GO
INSERT [dbo].[ExamProduct] ([ProductArticleNumber], [Name], [Description], [Category], [Manufacturer], [Cost], [DiscountAmount], [QuantityInStock], [Status]) VALUES (N'D344Y7', N'MAC Studio Fix Fluid Foundation', N'Тональный крем с максимальным покрытием и матовым финишем.', N'Косметика', N'MAC', CAST(31999.0000 AS Decimal(19, 4)), 13, 47, N'В наличии')
GO
INSERT [dbo].[ExamProduct] ([ProductArticleNumber], [Name], [Description], [Category], [Manufacturer], [Cost], [DiscountAmount], [QuantityInStock], [Status]) VALUES (N'D378D3', N'Dior Lip Glow', N'Уникальный бальзам для губ, который меняет свой оттенок под воздействием pH кожи.', N'Косметика', N'Dior', CAST(12799.0000 AS Decimal(19, 4)), 18, 266, N'В наличии')
GO
INSERT [dbo].[ExamProduct] ([ProductArticleNumber], [Name], [Description], [Category], [Manufacturer], [Cost], [DiscountAmount], [QuantityInStock], [Status]) VALUES (N'D526R4', N'Yves Saint Laurent Black Opium', N'Соблазнительный женский парфюм с нотами кофе и ванили.
', N'Парфюмерия', N'YSL', CAST(1499.0000 AS Decimal(19, 4)), 45, 84, N'В наличии')
GO
INSERT [dbo].[ExamProduct] ([ProductArticleNumber], [Name], [Description], [Category], [Manufacturer], [Cost], [DiscountAmount], [QuantityInStock], [Status]) VALUES (N'E245R5', N'Anastasia Beverly Hills Modern Renaissance Eyeshadow Palette', N'Палетка теней для век с нюдовыми и яркими оттенками.', N'Косметика', N'ABH', CAST(16099.0000 AS Decimal(19, 4)), 18, 100, N'В наличии')
GO
INSERT [dbo].[ExamProduct] ([ProductArticleNumber], [Name], [Description], [Category], [Manufacturer], [Cost], [DiscountAmount], [QuantityInStock], [Status]) VALUES (N'E479G6', N'Gucci Bloom', N'Женский парфюм с нотами жасмина, туберозы и розы.', N'Парфюмерия', N'Gucci', CAST(1099.0000 AS Decimal(19, 4)), 0, 0, N'Нет в наличии')
GO
INSERT [dbo].[ExamProduct] ([ProductArticleNumber], [Name], [Description], [Category], [Manufacturer], [Cost], [DiscountAmount], [QuantityInStock], [Status]) VALUES (N'E530Y6', N'Huda Beauty FauxFilter Foundation', N'Плотное покрывающее тональное средство, создающее идеальный макияж.', N'Косметика', N'Huda Beauty', CAST(4899.0000 AS Decimal(19, 4)), 7, 20, N'В наличии')
GO
INSERT [dbo].[ExamProduct] ([ProductArticleNumber], [Name], [Description], [Category], [Manufacturer], [Cost], [DiscountAmount], [QuantityInStock], [Status]) VALUES (N'E573G6', N'Marc Jacobs Daisy', N'Свежий и цветочный женский аромат, вдохновленный летними цветами.', N'Парфюмерия', N'Marc Jacobs', CAST(41999.0000 AS Decimal(19, 4)), 40, 41, N'В наличии')
GO
INSERT [dbo].[ExamProduct] ([ProductArticleNumber], [Name], [Description], [Category], [Manufacturer], [Cost], [DiscountAmount], [QuantityInStock], [Status]) VALUES (N'F344S4', N'Fenty Beauty Gloss Bomb Universal Lip Luminizer', N'Ультра-глянцевый блеск для губ с мягкой текстурой и ярким оттенком.', N'Косметика', N'Fenty Beauty', CAST(9999.0000 AS Decimal(19, 4)), 25, 18, N'В наличии')
GO
INSERT [dbo].[ExamProduct] ([ProductArticleNumber], [Name], [Description], [Category], [Manufacturer], [Cost], [DiscountAmount], [QuantityInStock], [Status]) VALUES (N'F346G5', N'Dolce & Gabbana Light Blue', N'Легкий и свежий аромат с нотами цитрусовых и арбуза.', N'Парфюмерия', N'Dolce & Gabbana', CAST(1499.0000 AS Decimal(19, 4)), 11, 45, N'В наличии')
GO
INSERT [dbo].[ExamProduct] ([ProductArticleNumber], [Name], [Description], [Category], [Manufacturer], [Cost], [DiscountAmount], [QuantityInStock], [Status]) VALUES (N'F893T5', N'NARS Radiant Creamy Concealer', N'Консилер с легкой текстурой и высоким покрытием для идеального макияжа.', N'Косметика', N'NARS', CAST(6499.0000 AS Decimal(19, 4)), 6, 19, N'В наличии')
GO
INSERT [dbo].[ExamProduct] ([ProductArticleNumber], [Name], [Description], [Category], [Manufacturer], [Cost], [DiscountAmount], [QuantityInStock], [Status]) VALUES (N'G532R5', N'Lancome La Vie Est Belle', N'Женский парфюм с нотами ириса, жасмина и апельсина.', N'Парфюмерия', N'Lancome', CAST(47199.0000 AS Decimal(19, 4)), 40, 56, N'В наличии')
GO
INSERT [dbo].[ExamProduct] ([ProductArticleNumber], [Name], [Description], [Category], [Manufacturer], [Cost], [DiscountAmount], [QuantityInStock], [Status]) VALUES (N'H732R5', N'Urban Decay Naked Heat Eyeshadow Palette', N'Палетка с теплыми оттенками теней для создания пылких образов.', N'Косметика', N'Urban Decay', CAST(32199.0000 AS Decimal(19, 4)), 18, 410, N'В наличии')
GO
INSERT [dbo].[ExamProduct] ([ProductArticleNumber], [Name], [Description], [Category], [Manufacturer], [Cost], [DiscountAmount], [QuantityInStock], [Status]) VALUES (N'J432E4', N'Tom Ford Black Orchid', N'Интенсивный и загадочный женский аромат с нотами туберозы и пачули.', N'Парфюмерия', N'Tom Ford', CAST(4899.0000 AS Decimal(19, 4)), 12, 150, N'В наличии')
GO
INSERT [dbo].[ExamProduct] ([ProductArticleNumber], [Name], [Description], [Category], [Manufacturer], [Cost], [DiscountAmount], [QuantityInStock], [Status]) VALUES (N'K535G6', N'Too Faced Better Than Sex Mascara', N'Тушь для ресниц с объемным эффектом и длительным держанием.', N'Косметика', N'Too Faced
', CAST(65099.0000 AS Decimal(19, 4)), 20, 88, N'В наличии')
GO
INSERT [dbo].[ExamProduct] ([ProductArticleNumber], [Name], [Description], [Category], [Manufacturer], [Cost], [DiscountAmount], [QuantityInStock], [Status]) VALUES (N'O875F6', N'Viktor & Rolf Flowerbomb', N'Сладкий и яркий аромат с нотами цветов, сахара и пачули.', N'Парфюмерия', N'Viktor & Rolf', CAST(2799.0000 AS Decimal(19, 4)), 30, 41, N'В наличии')
GO
INSERT [dbo].[ExamProduct] ([ProductArticleNumber], [Name], [Description], [Category], [Manufacturer], [Cost], [DiscountAmount], [QuantityInStock], [Status]) VALUES (N'R464G6', N'Benefit Hoola Matte Bronzer', N'Матовый бронзер для создания скульптуры и загара на лице.', N'Косметика', N'Benefit', CAST(12599.0000 AS Decimal(19, 4)), 18, 11, N'В наличии')
GO
INSERT [dbo].[ExamProduct] ([ProductArticleNumber], [Name], [Description], [Category], [Manufacturer], [Cost], [DiscountAmount], [QuantityInStock], [Status]) VALUES (N'S753T5', N'Chloe Eau de Parfum', N'Легкий и воздушный женский аромат с нотами розы и фрезии.', N'Парфюмерия', N'Chloe', CAST(1099.0000 AS Decimal(19, 4)), 45, 83, N'В наличии')
GO
INSERT [dbo].[ExamProduct] ([ProductArticleNumber], [Name], [Description], [Category], [Manufacturer], [Cost], [DiscountAmount], [QuantityInStock], [Status]) VALUES (N'V472S3', N'Tarte Shape Tape Concealer', N'Консилер с высоким покрытием и легкой текстурой для совершенного макияжа.', N'Косметика', N'Tarte', CAST(1999.0000 AS Decimal(19, 4)), 45, 75, N'В наличии')
GO
INSERT [dbo].[ExamProduct] ([ProductArticleNumber], [Name], [Description], [Category], [Manufacturer], [Cost], [DiscountAmount], [QuantityInStock], [Status]) VALUES (N'А112Т4', N'Giorgio Armani Si Passione', N'Страстный и чувственный женский аромат с нотами красной смородины и розы.', N'Парфюмерия', N'Giorgio Armani', CAST(1299.0000 AS Decimal(19, 4)), 5, 10, N'В наличии')
GO
SET IDENTITY_INSERT [dbo].[ExamRole] ON 
GO
INSERT [dbo].[ExamRole] ([RoleID], [Name]) VALUES (1, N'Менеджер
')
GO
INSERT [dbo].[ExamRole] ([RoleID], [Name]) VALUES (2, N'Клиент')
GO
INSERT [dbo].[ExamRole] ([RoleID], [Name]) VALUES (3, N'Администратор')
GO
SET IDENTITY_INSERT [dbo].[ExamRole] OFF
GO
SET IDENTITY_INSERT [dbo].[ExamUser] ON 
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (1, 1, N'Константинова ', N'Вероника', N'Агафоновна', N'loginDEsgg2018', N'qhgYnW')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (2, 2, N'Меркушев ', N'Мартын', N'Федотович', N'loginDEdcd2018', N'LxR6YI')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (3, 1, N'Казаков ', N'Федот', N'Кондратович', N'loginDEisg2018', N'Cp8ddU')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (4, 3, N'Карпов ', N'Улеб', N' Леонидович', N'loginDEcph2018', N'7YpE0p')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (5, 2, N'Королёв ', N'Матвей', N'Вадимович', N'loginDEgco2018', N'nMr|ss')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (6, 2, N'Юдин ', N'Герман', N' Кондратович', N'loginDEwjg2018', N'9UfqWQ')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (7, 3, N'Беляева ', N'Анна', N' Вячеславовна', N'loginDEjbz2018', N'xIAWNI')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (8, 1, N'Беляев ', N'Валентин', N'Артёмович', N'loginDEmgu2018', N'0gC3bk')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (9, 1, N'Семёнов ', N'Герман', N'Дмитрьевич', N'loginDErdg2018', N'ni0ue0')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (10, 2, N'Шестаков ', N'Илья', N'Антонинович', N'loginDEjtv2018', N'f2ZaN6')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (11, 2, N'Власов ', N'Вадим', N' Васильевич', N'loginDEtfj2018', N'{{ksPn')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (12, 3, N'Савельев ', N'Арсений', N' Авксентьевич', N'loginDEpnb2018', N'{ADBdc')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (13, 3, N'Ефимов ', N'Руслан', N'Якунович', N'loginDEzer2018', N'5&R+zs')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (14, 2, N'Бурова ', N'Марфа', N' Федотовна', N'loginDEiin2018', N'y9l*b}')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (15, 2, N'Селезнёв ', N'Александр', N' Никитевич', N'loginDEqda2018', N'|h+r}I')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (16, 2, N'Кулакова ', N'Виктория', N' Георгьевна', N'loginDEbnj2018', N'12345')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (17, 2, N'Дорофеева ', N'Кира', N'Демьяновна', N'loginDEqte2018', N'dC8bDI')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (18, 2, N'Сафонова ', N'Нинель', N'Якововна', N'loginDEfeo2018', N'8cI7vq')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (19, 2, N'Ситникова ', N'София', N'Лукьевна', N'loginDEvni2018', N'e4pVIv')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (20, 1, N'Медведев ', N'Ириней', N' Геннадьевич', N'loginDEjis2018', N'A9K++2')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (21, 1, N'Суханова ', N'Евгения', N' Улебовна', N'loginDExvv2018', N'R1zh}|')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (22, 1, N'Игнатьев ', N'Владлен', N'Дамирович', N'loginDEadl2018', N'F&IWf4')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (23, 2, N'Ефремов ', N'Христофор', N' Владиславович', N'loginDEyzn2018', N'P1v24R')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (24, 2, N'Кошелев ', N'Ростислав', N'Куприянович', N'loginDEphn2018', N'F}jGsJ')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (25, 3, N'Галкина ', N'Тамара', N'Авксентьевна', N'loginDEdvk2018', N'NKNkup')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (26, 1, N'Журавлёва ', N'Вера', N'Арсеньевна', N'loginDEtld2018', N'c+CECK')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (27, 3, N'Савина ', N'Таисия', N'Глебовна', N'loginDEima2018', N'XK3sOA')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (28, 2, N'Иванов ', N'Яков', N'Мэлорович', N'loginDEyfe2018', N'4Bbzpa')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (29, 1, N'Лыткин ', N'Ким', N' Алексеевич', N'loginDEwqc2018', N'vRtAP*')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (30, 1, N'Логинов ', N'Федот', N'Святославович', N'loginDEgtt2018', N'7YD|BR')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (31, 1, N'Русакова ', N'Марина', N'Юлиановна', N'loginDEiwl2018', N'LhlmIl')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (32, 3, N'Константинов ', N'Пётр', N'Кондратович', N'loginDEyvi2018', N'22beR}')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (33, 2, N'Поляков ', N'Анатолий', N' Игоревич', N'loginDEtfz2018', N'uQY0ZQ')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (34, 3, N'Панфилова ', N'Василиса', N'Григорьевна', N'loginDEikb2018', N'*QkUxc')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (35, 2, N'Воробьёв ', N'Герман', N' Романович', N'loginDEdmi2018', N'HOGFbU')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (36, 3, N'Андреев ', N'Ростислав', N'Федосеевич', N'loginDEtlo2018', N'58Jxrg')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (37, 3, N'Бобров ', N'Агафон', N'Владимирович', N'loginDEsnd2018', N'lLHqZf')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (38, 3, N'Лапин ', N'Алексей', N'Витальевич', N'loginDEgno2018', N'4fqLiO')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (39, 2, N'Шестаков ', N'Авдей', N'Иванович', N'loginDEgnl2018', N'wdio{u')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (40, 2, N'Гаврилова ', N'Алина', N'Эдуардовна', N'loginDEzna2018', N'yz1iMB')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (41, 1, N'Жуков ', N'Юлиан', N'Валерьянович', N'loginDEsyh2018', N'&4jYGs')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (42, 2, N'Пономарёв ', N'Максим', N'Альвианович', N'loginDExex2018', N'rnh36{')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (43, 1, N'Зиновьева ', N'Мария', N'Лаврентьевна', N'loginDEdjm2018', N'KjI1JR')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (44, 2, N'Осипов ', N'Артём', N'Мэлорович', N'loginDEgup2018', N'36|KhF')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (45, 3, N'Лапин ', N'Вячеслав', N'Геласьевич', N'loginDEdat2018', N'ussd8Q')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (46, 2, N'Зуев ', N'Ириней', N'Вадимович', N'loginDEffj2018', N'cJP+HC')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (47, 1, N'Коновалова ', N'Агафья', N' Митрофановна', N'loginDEisp2018', N'dfz5Ii')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (48, 1, N'Исаев ', N'Дмитрий', N'Аристархович', N'loginDEfrp2018', N'6dcR|9')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (49, 2, N'Белозёрова ', N'Алевтина', N'Лаврентьевна', N'loginDEaee2018', N'5&qONH')
GO
INSERT [dbo].[ExamUser] ([UserID], [RoleID], [Surname], [Name], [Patronymic], [Login], [Password]) VALUES (50, 2, N'Самсонов ', N'Агафон', N'Максимович', N'loginDEthu2018', N'|0xWzV')
GO
SET IDENTITY_INSERT [dbo].[ExamUser] OFF
GO
ALTER TABLE [dbo].[ExamOrder]  WITH CHECK ADD  CONSTRAINT [FK_ExamOrder_ExamPickupPoint] FOREIGN KEY([PickupPointIndex])
REFERENCES [dbo].[ExamPickupPoint] ([PickupPointIndex])
GO
ALTER TABLE [dbo].[ExamOrder] CHECK CONSTRAINT [FK_ExamOrder_ExamPickupPoint]
GO
ALTER TABLE [dbo].[ExamOrder]  WITH CHECK ADD  CONSTRAINT [FK_ExamOrder_ExamUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[ExamUser] ([UserID])
GO
ALTER TABLE [dbo].[ExamOrder] CHECK CONSTRAINT [FK_ExamOrder_ExamUser]
GO
ALTER TABLE [dbo].[ExamOrderProduct]  WITH CHECK ADD  CONSTRAINT [FK__ExamOrder__Order] FOREIGN KEY([OrderID])
REFERENCES [dbo].[ExamOrder] ([OrderID])
GO
ALTER TABLE [dbo].[ExamOrderProduct] CHECK CONSTRAINT [FK__ExamOrder__Order]
GO
ALTER TABLE [dbo].[ExamOrderProduct]  WITH CHECK ADD  CONSTRAINT [FK__ExamOrder__Produ__412EB0B6] FOREIGN KEY([ProductArticleNumber])
REFERENCES [dbo].[ExamProduct] ([ProductArticleNumber])
GO
ALTER TABLE [dbo].[ExamOrderProduct] CHECK CONSTRAINT [FK__ExamOrder__Produ__412EB0B6]
GO
ALTER TABLE [dbo].[ExamUser]  WITH CHECK ADD  CONSTRAINT [FK_ExamUser_ExamRole] FOREIGN KEY([RoleID])
REFERENCES [dbo].[ExamRole] ([RoleID])
GO
ALTER TABLE [dbo].[ExamUser] CHECK CONSTRAINT [FK_ExamUser_ExamRole]
GO
