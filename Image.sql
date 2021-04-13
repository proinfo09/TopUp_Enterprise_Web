CREATE TABLE [dbo].[tbl_file](  
 [file_id] [int] IDENTITY(1,1) NOT NULL,  
 [file_name] [nvarchar](max) NOT NULL,  
 [file_ext] [nvarchar](max) NOT NULL,  
 [file_base6] [nvarchar](max) NOT NULL,  
 CONSTRAINT [PK_tbl_file] PRIMARY KEY CLUSTERED   
(  
 [file_id] ASC  
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]  
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]  
  
GO 

CREATE PROCEDURE [dbo].[sp_get_all_files]  
   
AS  
BEGIN  
/****** Script for SelectTopNRows command from SSMS  ******/  
 SELECT [file_id]  
    ,[file_name]  
    ,[file_ext]  
 FROM [db_img].[dbo].[tbl_file]  
END  
  
GO  

CREATE PROCEDURE [dbo].[sp_get_file_details]   
 @file_id INT  
AS  
BEGIN  
/****** Script for SelectTopNRows command from SSMS  ******/  
 SELECT [file_id]  
    ,[file_name]  
    ,[file_ext]  
    ,[file_base6]  
 FROM [db_img].[dbo].[tbl_file]  
 WHERE [tbl_file].[file_id] = @file_id  
END  
  
GO  

CREATE PROCEDURE [dbo].[sp_insert_file]  
 @file_name NVARCHAR(MAX),  
 @file_ext NVARCHAR(MAX),  
 @file_base64 NVARCHAR(MAX)  
AS  
BEGIN  
/****** Script for SelectTopNRows command from SSMS  ******/  
 INSERT INTO [dbo].[tbl_file]  
           ([file_name]  
           ,[file_ext]  
           ,[file_base6])  
     VALUES  
           (@file_name  
           ,@file_ext  
           ,@file_base64)  
END  
  
GO 