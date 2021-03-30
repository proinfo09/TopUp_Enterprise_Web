create table [User_Admin_Detail]
(
	userId [nvarchar](128) NOT NULL,
	admID          int identity(1,1) primary key,
	admin_fullname nvarchar(50) not null,
	admin_mail	   nvarchar(256),
	admin_gender   nvarchar(1) not null check (admin_gender in ('M', 'F')),
	admin_doB      date null,
	admin_phone    nvarchar(10) null,
	constraint fk_Admin_Detail_userId_AspNetUser_ID foreign key (userID) references [AspNetUsers](ID)
)
go
	

create table [User_Marketing_Manager_Detail]
(
	userId [nvarchar](128) NOT NULL,
	mkmID        int identity(1,1) primary key,
	mkm_fullname nvarchar(50) not null,
	mkm_mail	 nvarchar(256) not null,
	mkm_gender   nvarchar(1) not null check (mkm_gender in ('M', 'F')),
	mkm_doB      date null,
	mkm_phone    nvarchar(10) null,
	constraint fk_User_Marketing_Manager_Detail_AspNetUser_ID foreign key (userID) references [AspNetUsers](ID)
)
go

create table [Faculty]
(
	facID int identity(1,1) primary key,
	facName nvarchar(50) not null unique,
)
go

create table [Image]
(
	imgID int identity(1,1) primary key,
	img_Title varchar(50) null, 
)
go

create table [File]
(
	fileID int identity(1,1) primary key,
	file_Title nvarchar(256) null, 
)
go

create table [User_Student_Detail]
(
	userId [nvarchar](128) NOT NULL,
	stdID        int identity(1,1) primary key,
	std_fullname nvarchar(50) not null,
	std_mail	 nvarchar(256) not null,
	std_gender   nvarchar(1) not null check (std_gender in ('M', 'F')),
	std_doB      date null,
	std_phone    nvarchar(10) null,
	constraint fk_User_Student_Detail_AspNetUser_ID foreign key (userID) references [AspNetUsers](ID),
)
go

create table [User_Marketing_Coordinator_Detail]
(
	userId [nvarchar](128) NOT NULL,
	mkcID        int identity(1,1) primary key,
	mkc_fullname nvarchar(50) not null,
	mkc_mail	 nvarchar(256) not null,
	mkc_gender   nvarchar(1) not null check (mkc_gender in ('M', 'F')),
	mkc_doB      date null,
	mkc_phone    nvarchar(10) null,
	constraint fk_User_Marketing_Coordinator_Detail_AspNetUser_ID foreign key (userID) references [AspNetUsers](ID),
)
go

create table [Contributions]
(
	consID        int identity(1,1) primary key,
	cons_Name     nvarchar(256) not null unique,
	cons_comment  nvarchar(256) null,
	cons_submit   date null,
	cons_status   varchar(10)  not null,
	imgID         int not null,
	stdID		  int not null,
	fileID		  int not null,
	constraint fk_cons_imgID foreign key (imgID) references [Image](imgID),
	constraint fk_cons_stdID foreign key (stdID) references [User_Student_Detail](stdID),
	constraint fk_cons_fileidID foreign key (fileID) references [File](fileID),
)
go

create table [User_Guest_Detail]
(
	userId [nvarchar](128) NOT NULL,
	gstID        int identity(1,1) primary key,
	gst_fullname nvarchar(50) not null,
	gst_mail	 nvarchar(256) null,
	gst_gender   nvarchar(1) not null check (gst_gender in ('M', 'F')),
	gst_doB      date null,
	gst_phone    nvarchar(10) null,
	constraint fk_User_Guest_Detail_AspNetUser_ID foreign key (userID) references [AspNetUsers](ID),
)
go

create table [Closure Day]
(
	csdID int identity(1,1) not null primary key,
	startDay date not null,
	endDay   date not null,
	finalDay date not null,
)
go

ALTER TABLE [dbo].[AspNetUsers]		
ADD CONSTRAINT fk_AspUser_Faculty_facID  FOREIGN KEY (facID) REFERENCES Faculty(facID);