USE [WebEnteprise]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 05/02/2021 19:19:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[admID] [int] IDENTITY(1,1) NOT NULL,
	[admin_username] [varchar](30) NOT NULL,
	[admin_password] [varchar](30) NOT NULL,
	[admin_fullname] [varchar](50) NOT NULL,
	[admin_mail] [varchar](50) NOT NULL,
	[admin_gender] [varchar](1) NOT NULL,
	[admin_doB] [date] NULL,
	[admin_phone] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[admID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Closure Day]    Script Date: 05/02/2021 19:19:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Closure Day](
	[csdID] [int] IDENTITY(1,1) NOT NULL,
	[startDay] [date] NOT NULL,
	[endDay] [date] NOT NULL,
	[finalDay] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[csdID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contributions]    Script Date: 05/02/2021 19:19:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contributions](
	[consID] [int] IDENTITY(1,1) NOT NULL,
	[cons_Name] [varchar](100) NOT NULL,
	[cons_FileName] [varchar](100) NOT NULL,
	[cons_comment] [varchar](100) NULL,
	[cons_submit] [date] NULL,
	[cons_status] [varchar](10) NOT NULL,
	[imgID] [int] NOT NULL,
	[stdID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[consID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Faculty]    Script Date: 05/02/2021 19:19:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculty](
	[facID] [int] IDENTITY(1,1) NOT NULL,
	[facName] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[facID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Guest]    Script Date: 05/02/2021 19:19:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Guest](
	[gstID] [int] IDENTITY(1,1) NOT NULL,
	[gst_username] [varchar](30) NOT NULL,
	[gst_password] [varchar](30) NOT NULL,
	[gst_fullname] [varchar](50) NOT NULL,
	[gst_mail] [varchar](50) NULL,
	[gst_gender] [varchar](1) NOT NULL,
	[gst_doB] [date] NULL,
	[gst_phone] [varchar](10) NULL,
	[facID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[gstID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Image]    Script Date: 05/02/2021 19:19:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[imgID] [int] IDENTITY(1,1) NOT NULL,
	[img_Title] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[imgID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marketing Coordinator]    Script Date: 05/02/2021 19:19:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marketing Coordinator](
	[mkcID] [int] IDENTITY(1,1) NOT NULL,
	[mkc_username] [varchar](30) NOT NULL,
	[mkc_password] [varchar](30) NOT NULL,
	[mkc_fullname] [varchar](50) NOT NULL,
	[mkc_mail] [varchar](50) NOT NULL,
	[mkc_gender] [varchar](1) NOT NULL,
	[mkc_doB] [date] NULL,
	[mkc_phone] [varchar](10) NULL,
	[facID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[mkcID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marketing Manager]    Script Date: 05/02/2021 19:19:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marketing Manager](
	[mkmID] [int] IDENTITY(1,1) NOT NULL,
	[mkm_username] [varchar](30) NOT NULL,
	[mkm_password] [varchar](30) NOT NULL,
	[mkm_fullname] [varchar](50) NOT NULL,
	[mkm_mail] [varchar](50) NOT NULL,
	[mkm_gender] [varchar](1) NOT NULL,
	[mkm_doB] [date] NULL,
	[mkm_phone] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[mkmID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 05/02/2021 19:19:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[stdID] [int] IDENTITY(1,1) NOT NULL,
	[std_username] [varchar](30) NOT NULL,
	[std_password] [varchar](30) NOT NULL,
	[std_fullname] [varchar](50) NOT NULL,
	[std_mail] [varchar](50) NOT NULL,
	[std_gender] [varchar](1) NOT NULL,
	[std_doB] [date] NULL,
	[std_phone] [varchar](10) NULL,
	[facID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[stdID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Admin] ON 

INSERT [dbo].[Admin] ([admID], [admin_username], [admin_password], [admin_fullname], [admin_mail], [admin_gender], [admin_doB], [admin_phone]) VALUES (1, N'beba123', N'tuduong123', N'Tu Duong Be Ba', N'tuduongbeba@fpt.edu.vn', N'M', CAST(N'2000-01-19' AS Date), N'0881257952')
INSERT [dbo].[Admin] ([admID], [admin_username], [admin_password], [admin_fullname], [admin_mail], [admin_gender], [admin_doB], [admin_phone]) VALUES (2, N'smithjohn159', N'dateofbirth02', N'John Smith', N'johnsmith@fpt.edu.vn', N'M', CAST(N'1990-08-26' AS Date), N'0908129548')
INSERT [dbo].[Admin] ([admID], [admin_username], [admin_password], [admin_fullname], [admin_mail], [admin_gender], [admin_doB], [admin_phone]) VALUES (3, N'marryjane207', N'jannie0702', N'Marry Jane	', N'marryjane@fpt.edu.vn', N'F', CAST(N'1994-12-30' AS Date), N'0886482192')
INSERT [dbo].[Admin] ([admID], [admin_username], [admin_password], [admin_fullname], [admin_mail], [admin_gender], [admin_doB], [admin_phone]) VALUES (4, N'williejohn1998', N'williebuddy123', N'Willie John', N'williejohn@fpt.edu.vn', N'M', CAST(N'1997-05-27' AS Date), N'0906259485')
INSERT [dbo].[Admin] ([admID], [admin_username], [admin_password], [admin_fullname], [admin_mail], [admin_gender], [admin_doB], [admin_phone]) VALUES (5, N'parksonmax189', N'maxiepark123', N'Max Parkson', N'maxparkson@fpt.edu.vn', N'M', CAST(N'1998-05-14' AS Date), N'0903648574')
INSERT [dbo].[Admin] ([admID], [admin_username], [admin_password], [admin_fullname], [admin_mail], [admin_gender], [admin_doB], [admin_phone]) VALUES (6, N'allegriwillum', N'willingmemory', N'William Allegri', N'williamallegri@fpt.edu.vn', N'M', CAST(N'1992-02-16' AS Date), N'0906158249')
INSERT [dbo].[Admin] ([admID], [admin_username], [admin_password], [admin_fullname], [admin_mail], [admin_gender], [admin_doB], [admin_phone]) VALUES (7, N'thenewone159', N'badasspassword', N'Miliano Mary', N'milianomary@fpt.edu.vn', N'F', CAST(N'1989-03-16' AS Date), N'0901054896')
INSERT [dbo].[Admin] ([admID], [admin_username], [admin_password], [admin_fullname], [admin_mail], [admin_gender], [admin_doB], [admin_phone]) VALUES (8, N'jurgenlopper987', N'mophringmumbai', N'Jurgen Looper', N'jurgenlopper@fpt.edu.vn', N'M', CAST(N'1986-07-27' AS Date), N'0904725852')
SET IDENTITY_INSERT [dbo].[Admin] OFF
GO
SET IDENTITY_INSERT [dbo].[Closure Day] ON 

INSERT [dbo].[Closure Day] ([csdID], [startDay], [endDay], [finalDay]) VALUES (1, CAST(N'2020-01-17' AS Date), CAST(N'2021-02-03' AS Date), CAST(N'2021-02-05' AS Date))
INSERT [dbo].[Closure Day] ([csdID], [startDay], [endDay], [finalDay]) VALUES (2, CAST(N'2020-07-25' AS Date), CAST(N'2020-08-12' AS Date), CAST(N'2020-08-14' AS Date))
INSERT [dbo].[Closure Day] ([csdID], [startDay], [endDay], [finalDay]) VALUES (3, CAST(N'2018-05-28' AS Date), CAST(N'2018-06-14' AS Date), CAST(N'2018-06-18' AS Date))
INSERT [dbo].[Closure Day] ([csdID], [startDay], [endDay], [finalDay]) VALUES (4, CAST(N'2019-09-26' AS Date), CAST(N'2019-10-15' AS Date), CAST(N'2019-10-17' AS Date))
SET IDENTITY_INSERT [dbo].[Closure Day] OFF
GO
SET IDENTITY_INSERT [dbo].[Contributions] ON 

INSERT [dbo].[Contributions] ([consID], [cons_Name], [cons_FileName], [cons_comment], [cons_submit], [cons_status], [imgID], [stdID]) VALUES (1, N'How to become a developer', N'cc', N'Good', CAST(N'2021-02-04' AS Date), N'Available', 1, 1)
SET IDENTITY_INSERT [dbo].[Contributions] OFF
GO
SET IDENTITY_INSERT [dbo].[Faculty] ON 

INSERT [dbo].[Faculty] ([facID], [facName]) VALUES (3, N'Business Administration')
INSERT [dbo].[Faculty] ([facID], [facName]) VALUES (4, N'Event Management')
INSERT [dbo].[Faculty] ([facID], [facName]) VALUES (2, N'Graphic Design')
INSERT [dbo].[Faculty] ([facID], [facName]) VALUES (1, N'Information Technology')
SET IDENTITY_INSERT [dbo].[Faculty] OFF
GO
SET IDENTITY_INSERT [dbo].[Guest] ON 

INSERT [dbo].[Guest] ([gstID], [gst_username], [gst_password], [gst_fullname], [gst_mail], [gst_gender], [gst_doB], [gst_phone], [facID]) VALUES (2, N'guest00950', N'randompassword01', N'Guest 01', N'guest00950@fpt.edu.vn', N'F', CAST(N'2020-05-18' AS Date), N'0945852485', 1)
INSERT [dbo].[Guest] ([gstID], [gst_username], [gst_password], [gst_fullname], [gst_mail], [gst_gender], [gst_doB], [gst_phone], [facID]) VALUES (3, N'guest12350', N'weaknesspassword', N'Guest 02', N'guest12350@fpt.edu.vn', N'M', CAST(N'2021-01-29' AS Date), N'0894563215', 1)
INSERT [dbo].[Guest] ([gstID], [gst_username], [gst_password], [gst_fullname], [gst_mail], [gst_gender], [gst_doB], [gst_phone], [facID]) VALUES (4, N'guest0350', N'justforsecurity', N'Guest 03', N'guest0350@fpt.edu.vn', N'F', CAST(N'2020-02-18' AS Date), N'0489115623', 2)
SET IDENTITY_INSERT [dbo].[Guest] OFF
GO
SET IDENTITY_INSERT [dbo].[Image] ON 

INSERT [dbo].[Image] ([imgID], [img_Title]) VALUES (1, N'Untitle.png')
INSERT [dbo].[Image] ([imgID], [img_Title]) VALUES (2, N'picture01.png')
INSERT [dbo].[Image] ([imgID], [img_Title]) VALUES (3, N'picture02.png')
INSERT [dbo].[Image] ([imgID], [img_Title]) VALUES (4, N'picture03.png')
INSERT [dbo].[Image] ([imgID], [img_Title]) VALUES (5, N'itpic.png')
INSERT [dbo].[Image] ([imgID], [img_Title]) VALUES (6, N'itpc02.png')
SET IDENTITY_INSERT [dbo].[Image] OFF
GO
SET IDENTITY_INSERT [dbo].[Marketing Coordinator] ON 

INSERT [dbo].[Marketing Coordinator] ([mkcID], [mkc_username], [mkc_password], [mkc_fullname], [mkc_mail], [mkc_gender], [mkc_doB], [mkc_phone], [facID]) VALUES (1, N'honghahoi00', N'nnhonghann', N'Nguyen Hong Ha', N'hongha@fpt.edu.vn', N'F', CAST(N'1998-04-19' AS Date), N'0254852585', 1)
INSERT [dbo].[Marketing Coordinator] ([mkcID], [mkc_username], [mkc_password], [mkc_fullname], [mkc_mail], [mkc_gender], [mkc_doB], [mkc_phone], [facID]) VALUES (2, N'duonghieuhoi', N'00harryhuy00', N'Tu Duong Hieu', N'duonghieutu@fpt.edu.vn', N'F', CAST(N'1992-02-25' AS Date), N'0125252852', 3)
INSERT [dbo].[Marketing Coordinator] ([mkcID], [mkc_username], [mkc_password], [mkc_fullname], [mkc_mail], [mkc_gender], [mkc_doB], [mkc_phone], [facID]) VALUES (3, N'khanhdang02', N'onemoretime123', N'Tran Khanh Dang', N'khanhdang@fpt.edu.vn', N'M', CAST(N'1991-05-13' AS Date), N'0252584522', 2)
INSERT [dbo].[Marketing Coordinator] ([mkcID], [mkc_username], [mkc_password], [mkc_fullname], [mkc_mail], [mkc_gender], [mkc_doB], [mkc_phone], [facID]) VALUES (4, N'messagernumber', N'morderkaiser1', N'Smithy Carthy', N'smithycarthy@fpt.edu.vn', N'F', CAST(N'1986-02-27' AS Date), N'0254885689', 4)
SET IDENTITY_INSERT [dbo].[Marketing Coordinator] OFF
GO
SET IDENTITY_INSERT [dbo].[Marketing Manager] ON 

INSERT [dbo].[Marketing Manager] ([mkmID], [mkm_username], [mkm_password], [mkm_fullname], [mkm_mail], [mkm_gender], [mkm_doB], [mkm_phone]) VALUES (1, N'thanhlongpham', N'shinnystar123', N'Pham Thanh Long', N'thanhlongpham@fpt.edu.vn', N'M', CAST(N'1999-08-24' AS Date), N'0915485258')
INSERT [dbo].[Marketing Manager] ([mkmID], [mkm_username], [mkm_password], [mkm_fullname], [mkm_mail], [mkm_gender], [mkm_doB], [mkm_phone]) VALUES (2, N'khoadang2059', N'mycomputer2059', N'Dang Anh Khoa', N'danganhkhoa@fpt.edu.vn', N'M', CAST(N'1991-04-15' AS Date), N'0524852943')
INSERT [dbo].[Marketing Manager] ([mkmID], [mkm_username], [mkm_password], [mkm_fullname], [mkm_mail], [mkm_gender], [mkm_doB], [mkm_phone]) VALUES (3, N'marlianny123', N'crocodile20123', N'Max Marlian', N'maxmarlian@fpt.edu.vn', N'M', CAST(N'1987-04-14' AS Date), N'0945878529')
INSERT [dbo].[Marketing Manager] ([mkmID], [mkm_username], [mkm_password], [mkm_fullname], [mkm_mail], [mkm_gender], [mkm_doB], [mkm_phone]) VALUES (4, N'kimngan980', N'iamthebest', N'Tran Kim Ngan', N'kimngantran@fpt.edu.vn', N'F', CAST(N'1997-03-24' AS Date), N'0948582592')
INSERT [dbo].[Marketing Manager] ([mkmID], [mkm_username], [mkm_password], [mkm_fullname], [mkm_mail], [mkm_gender], [mkm_doB], [mkm_phone]) VALUES (5, N'huyhoang89', N'darlingbubble', N'Dang Hoang Huy', N'huydang@fpt.edu.vn', N'M', CAST(N'1993-05-16' AS Date), N'0954825489')
INSERT [dbo].[Marketing Manager] ([mkmID], [mkm_username], [mkm_password], [mkm_fullname], [mkm_mail], [mkm_gender], [mkm_doB], [mkm_phone]) VALUES (6, N'ngocvy2908', N'beyerischemotoren123', N'Nguyen Ngoc Vy', N'ngocvy@fpt.edu.vn', N'F', CAST(N'1996-04-15' AS Date), N'0542589525')
INSERT [dbo].[Marketing Manager] ([mkmID], [mkm_username], [mkm_password], [mkm_fullname], [mkm_mail], [mkm_gender], [mkm_doB], [mkm_phone]) VALUES (7, N'phuonglien1997', N'suongsao!@', N'Nguyen Ngoc Phuong Lien', N'phuonglien@fpt.edu.vn', N'F', CAST(N'1997-07-19' AS Date), N'0958252585')
INSERT [dbo].[Marketing Manager] ([mkmID], [mkm_username], [mkm_password], [mkm_fullname], [mkm_mail], [mkm_gender], [mkm_doB], [mkm_phone]) VALUES (8, N'thaian1902', N'pepsivscoke', N'Tran Nguyen Thai An', N'thaian@fpt.edu.vn', N'F', CAST(N'1992-02-19' AS Date), N'0254852589')
SET IDENTITY_INSERT [dbo].[Marketing Manager] OFF
GO
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([stdID], [std_username], [std_password], [std_fullname], [std_mail], [std_gender], [std_doB], [std_phone], [facID]) VALUES (1, N'demonsking', N'morphling123', N'Nguyen Dang Khanh', N'khanhnd@fpt.edu.vn', N'M', CAST(N'2000-07-15' AS Date), N'0548452585', 3)
INSERT [dbo].[Student] ([stdID], [std_username], [std_password], [std_fullname], [std_mail], [std_gender], [std_doB], [std_phone], [facID]) VALUES (2, N'archerskeleton', N'vaynerbu123', N'Tran Ngoc An', N'antn@fpt.edu.vn', N'F', CAST(N'2001-12-18' AS Date), N'0264859456', 1)
INSERT [dbo].[Student] ([stdID], [std_username], [std_password], [std_fullname], [std_mail], [std_gender], [std_doB], [std_phone], [facID]) VALUES (3, N'bloodyshield', N'aatroxi01', N'Nguyen Minh Hieu', N'hieunm@fpt.edu.vn', N'M', CAST(N'2002-02-23' AS Date), N'0256489456', 2)
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Admin__0CEDD55F68EC0F2E]    Script Date: 05/02/2021 19:19:59 ******/
ALTER TABLE [dbo].[Admin] ADD UNIQUE NONCLUSTERED 
(
	[admin_username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Contribu__0BA674F08030F3CC]    Script Date: 05/02/2021 19:19:59 ******/
ALTER TABLE [dbo].[Contributions] ADD UNIQUE NONCLUSTERED 
(
	[cons_FileName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Contribu__D0E4C38FB3B4E039]    Script Date: 05/02/2021 19:19:59 ******/
ALTER TABLE [dbo].[Contributions] ADD UNIQUE NONCLUSTERED 
(
	[cons_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Faculty__688F72A83AD00EE4]    Script Date: 05/02/2021 19:19:59 ******/
ALTER TABLE [dbo].[Faculty] ADD UNIQUE NONCLUSTERED 
(
	[facName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Guest__D90AA331105F7D27]    Script Date: 05/02/2021 19:19:59 ******/
ALTER TABLE [dbo].[Guest] ADD UNIQUE NONCLUSTERED 
(
	[gst_username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Marketin__5E2CF2EDB2E009FC]    Script Date: 05/02/2021 19:19:59 ******/
ALTER TABLE [dbo].[Marketing Coordinator] ADD UNIQUE NONCLUSTERED 
(
	[mkc_username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Marketin__A9944DC1EDB149B3]    Script Date: 05/02/2021 19:19:59 ******/
ALTER TABLE [dbo].[Marketing Manager] ADD UNIQUE NONCLUSTERED 
(
	[mkm_username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Student__9C33A405F5F021A4]    Script Date: 05/02/2021 19:19:59 ******/
ALTER TABLE [dbo].[Student] ADD UNIQUE NONCLUSTERED 
(
	[std_username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Contributions]  WITH CHECK ADD  CONSTRAINT [fk_cons_imgID] FOREIGN KEY([imgID])
REFERENCES [dbo].[Image] ([imgID])
GO
ALTER TABLE [dbo].[Contributions] CHECK CONSTRAINT [fk_cons_imgID]
GO
ALTER TABLE [dbo].[Contributions]  WITH CHECK ADD  CONSTRAINT [fk_cons_stdID] FOREIGN KEY([stdID])
REFERENCES [dbo].[Student] ([stdID])
GO
ALTER TABLE [dbo].[Contributions] CHECK CONSTRAINT [fk_cons_stdID]
GO
ALTER TABLE [dbo].[Guest]  WITH CHECK ADD  CONSTRAINT [fk_gst_facID] FOREIGN KEY([facID])
REFERENCES [dbo].[Faculty] ([facID])
GO
ALTER TABLE [dbo].[Guest] CHECK CONSTRAINT [fk_gst_facID]
GO
ALTER TABLE [dbo].[Marketing Coordinator]  WITH CHECK ADD  CONSTRAINT [fk_mkc_facID] FOREIGN KEY([facID])
REFERENCES [dbo].[Faculty] ([facID])
GO
ALTER TABLE [dbo].[Marketing Coordinator] CHECK CONSTRAINT [fk_mkc_facID]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [fk_std_facID] FOREIGN KEY([facID])
REFERENCES [dbo].[Faculty] ([facID])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [fk_std_facID]
GO
ALTER TABLE [dbo].[Admin]  WITH CHECK ADD CHECK  (([admin_gender]='F' OR [admin_gender]='M'))
GO
ALTER TABLE [dbo].[Guest]  WITH CHECK ADD CHECK  (([gst_gender]='F' OR [gst_gender]='M'))
GO
ALTER TABLE [dbo].[Marketing Coordinator]  WITH CHECK ADD CHECK  (([mkc_gender]='F' OR [mkc_gender]='M'))
GO
ALTER TABLE [dbo].[Marketing Manager]  WITH CHECK ADD CHECK  (([mkm_gender]='F' OR [mkm_gender]='M'))
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD CHECK  (([std_gender]='F' OR [std_gender]='M'))
GO
