
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/10/2021 16:58:08
-- Generated from EDMX file: D:\Study\TopUp_Enterprise_Web\Enterprise_Web\Models\WebEnterpriseModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [aspnet-Web Enterprise-20210224042248];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[fk_Admin_Detail_userId_AspNetUser_ID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User_Admin_Detail] DROP CONSTRAINT [fk_Admin_Detail_userId_AspNetUser_ID];
GO
IF OBJECT_ID(N'[dbo].[fk_AspUser_Faculty_facID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUsers] DROP CONSTRAINT [fk_AspUser_Faculty_facID];
GO
IF OBJECT_ID(N'[dbo].[FK_Cmt_BlogPost]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comment] DROP CONSTRAINT [FK_Cmt_BlogPost];
GO
IF OBJECT_ID(N'[dbo].[fk_cons_fileidID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contributions] DROP CONSTRAINT [fk_cons_fileidID];
GO
IF OBJECT_ID(N'[dbo].[fk_cons_imgID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contributions] DROP CONSTRAINT [fk_cons_imgID];
GO
IF OBJECT_ID(N'[dbo].[fk_cons_stdID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contributions] DROP CONSTRAINT [fk_cons_stdID];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[fk_User_Guest_Detail_AspNetUser_ID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User_Guest_Detail] DROP CONSTRAINT [fk_User_Guest_Detail_AspNetUser_ID];
GO
IF OBJECT_ID(N'[dbo].[fk_User_Marketing_Coordinator_Detail_AspNetUser_ID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User_Marketing_Coordinator_Detail] DROP CONSTRAINT [fk_User_Marketing_Coordinator_Detail_AspNetUser_ID];
GO
IF OBJECT_ID(N'[dbo].[fk_User_Marketing_Manager_Detail_AspNetUser_ID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User_Marketing_Manager_Detail] DROP CONSTRAINT [fk_User_Marketing_Manager_Detail_AspNetUser_ID];
GO
IF OBJECT_ID(N'[dbo].[fk_User_Student_Detail_AspNetUser_ID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User_Student_Detail] DROP CONSTRAINT [fk_User_Student_Detail_AspNetUser_ID];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[__MigrationHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[__MigrationHistory];
GO
IF OBJECT_ID(N'[dbo].[AspNetRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserClaims]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserClaims];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserLogins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserLogins];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[BlogPost]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BlogPost];
GO
IF OBJECT_ID(N'[dbo].[Closure Day]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Closure Day];
GO
IF OBJECT_ID(N'[dbo].[Comment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comment];
GO
IF OBJECT_ID(N'[dbo].[Contributions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contributions];
GO
IF OBJECT_ID(N'[dbo].[Faculty]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Faculty];
GO
IF OBJECT_ID(N'[dbo].[File]', 'U') IS NOT NULL
    DROP TABLE [dbo].[File];
GO
IF OBJECT_ID(N'[dbo].[Image]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Image];
GO
IF OBJECT_ID(N'[dbo].[User_Admin_Detail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User_Admin_Detail];
GO
IF OBJECT_ID(N'[dbo].[User_Guest_Detail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User_Guest_Detail];
GO
IF OBJECT_ID(N'[dbo].[User_Marketing_Coordinator_Detail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User_Marketing_Coordinator_Detail];
GO
IF OBJECT_ID(N'[dbo].[User_Marketing_Manager_Detail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User_Marketing_Manager_Detail];
GO
IF OBJECT_ID(N'[dbo].[User_Student_Detail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User_Student_Detail];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'C__MigrationHistory'
CREATE TABLE [dbo].[C__MigrationHistory] (
    [MigrationId] nvarchar(150)  NOT NULL,
    [ContextKey] nvarchar(300)  NOT NULL,
    [Model] varbinary(max)  NOT NULL,
    [ProductVersion] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'AspNetRoles'
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'AspNetUserClaims'
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(128)  NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL
);
GO

-- Creating table 'AspNetUserLogins'
CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] nvarchar(128)  NOT NULL,
    [ProviderKey] nvarchar(128)  NOT NULL,
    [UserId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [Email] nvarchar(256)  NULL,
    [EmailConfirmed] bit  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [PhoneNumberConfirmed] bit  NOT NULL,
    [TwoFactorEnabled] bit  NOT NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NOT NULL,
    [AccessFailedCount] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL,
    [facID] int  NOT NULL
);
GO

-- Creating table 'Closure_Days'
CREATE TABLE [dbo].[Closure_Days] (
    [csdID] int IDENTITY(1,1) NOT NULL,
    [startDay] datetime  NOT NULL,
    [endDay] datetime  NOT NULL,
    [finalDay] datetime  NOT NULL
);
GO

-- Creating table 'Contributions'
CREATE TABLE [dbo].[Contributions] (
    [consID] int IDENTITY(1,1) NOT NULL,
    [cons_Name] nvarchar(256)  NOT NULL,
    [cons_comment] nvarchar(256)  NULL,
    [cons_submit] datetime  NULL,
    [cons_status] varchar(10)  NOT NULL,
    [imgID] int  NOT NULL,
    [stdID] int  NOT NULL,
    [fileID] int  NOT NULL
);
GO

-- Creating table 'Faculties'
CREATE TABLE [dbo].[Faculties] (
    [facID] int IDENTITY(1,1) NOT NULL,
    [facName] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Files'
CREATE TABLE [dbo].[Files] (
    [fileID] int IDENTITY(1,1) NOT NULL,
    [file_Title] nvarchar(256)  NULL
);
GO

-- Creating table 'Images'
CREATE TABLE [dbo].[Images] (
    [imgID] int IDENTITY(1,1) NOT NULL,
    [img_Title] varchar(50)  NULL
);
GO

-- Creating table 'User_Admin_Detail'
CREATE TABLE [dbo].[User_Admin_Detail] (
    [userId] nvarchar(128)  NOT NULL,
    [admID] int IDENTITY(1,1) NOT NULL,
    [admin_fullname] nvarchar(50)  NOT NULL,
    [admin_mail] nvarchar(256)  NULL,
    [admin_gender] nvarchar(1)  NOT NULL,
    [admin_doB] datetime  NULL,
    [admin_phone] nvarchar(10)  NULL
);
GO

-- Creating table 'User_Guest_Detail'
CREATE TABLE [dbo].[User_Guest_Detail] (
    [userId] nvarchar(128)  NOT NULL,
    [gstID] int IDENTITY(1,1) NOT NULL,
    [gst_fullname] nvarchar(50)  NOT NULL,
    [gst_mail] nvarchar(256)  NULL,
    [gst_gender] nvarchar(1)  NOT NULL,
    [gst_doB] datetime  NULL,
    [gst_phone] nvarchar(10)  NULL
);
GO

-- Creating table 'User_Marketing_Coordinator_Detail'
CREATE TABLE [dbo].[User_Marketing_Coordinator_Detail] (
    [userId] nvarchar(128)  NOT NULL,
    [mkcID] int IDENTITY(1,1) NOT NULL,
    [mkc_fullname] nvarchar(50)  NOT NULL,
    [mkc_mail] nvarchar(256)  NOT NULL,
    [mkc_gender] nvarchar(1)  NOT NULL,
    [mkc_doB] datetime  NULL,
    [mkc_phone] nvarchar(10)  NULL
);
GO

-- Creating table 'User_Marketing_Manager_Detail'
CREATE TABLE [dbo].[User_Marketing_Manager_Detail] (
    [userId] nvarchar(128)  NOT NULL,
    [mkmID] int IDENTITY(1,1) NOT NULL,
    [mkm_fullname] nvarchar(50)  NOT NULL,
    [mkm_mail] nvarchar(256)  NOT NULL,
    [mkm_gender] nvarchar(1)  NOT NULL,
    [mkm_doB] datetime  NULL,
    [mkm_phone] nvarchar(10)  NULL
);
GO

-- Creating table 'User_Student_Detail'
CREATE TABLE [dbo].[User_Student_Detail] (
    [userId] nvarchar(128)  NOT NULL,
    [stdID] int IDENTITY(1,1) NOT NULL,
    [std_fullname] nvarchar(50)  NOT NULL,
    [std_mail] nvarchar(256)  NOT NULL,
    [std_gender] nvarchar(1)  NOT NULL,
    [std_doB] datetime  NULL,
    [std_phone] nvarchar(10)  NULL
);
GO

-- Creating table 'BlogPosts'
CREATE TABLE [dbo].[BlogPosts] (
    [BlogPostID] int  NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Body] nvarchar(max)  NULL
);
GO

-- Creating table 'Comments'
CREATE TABLE [dbo].[Comments] (
    [CommentID] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Body] nvarchar(max)  NULL,
    [BlogPostID] int  NOT NULL
);
GO

-- Creating table 'AspNetUserRoles'
CREATE TABLE [dbo].[AspNetUserRoles] (
    [AspNetRoles_Id] nvarchar(128)  NOT NULL,
    [AspNetUsers_Id] nvarchar(128)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MigrationId], [ContextKey] in table 'C__MigrationHistory'
ALTER TABLE [dbo].[C__MigrationHistory]
ADD CONSTRAINT [PK_C__MigrationHistory]
    PRIMARY KEY CLUSTERED ([MigrationId], [ContextKey] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetRoles'
ALTER TABLE [dbo].[AspNetRoles]
ADD CONSTRAINT [PK_AspNetRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [PK_AspNetUserClaims]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [LoginProvider], [ProviderKey], [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [PK_AspNetUserLogins]
    PRIMARY KEY CLUSTERED ([LoginProvider], [ProviderKey], [UserId] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [csdID] in table 'Closure_Days'
ALTER TABLE [dbo].[Closure_Days]
ADD CONSTRAINT [PK_Closure_Days]
    PRIMARY KEY CLUSTERED ([csdID] ASC);
GO

-- Creating primary key on [consID] in table 'Contributions'
ALTER TABLE [dbo].[Contributions]
ADD CONSTRAINT [PK_Contributions]
    PRIMARY KEY CLUSTERED ([consID] ASC);
GO

-- Creating primary key on [facID] in table 'Faculties'
ALTER TABLE [dbo].[Faculties]
ADD CONSTRAINT [PK_Faculties]
    PRIMARY KEY CLUSTERED ([facID] ASC);
GO

-- Creating primary key on [fileID] in table 'Files'
ALTER TABLE [dbo].[Files]
ADD CONSTRAINT [PK_Files]
    PRIMARY KEY CLUSTERED ([fileID] ASC);
GO

-- Creating primary key on [imgID] in table 'Images'
ALTER TABLE [dbo].[Images]
ADD CONSTRAINT [PK_Images]
    PRIMARY KEY CLUSTERED ([imgID] ASC);
GO

-- Creating primary key on [admID] in table 'User_Admin_Detail'
ALTER TABLE [dbo].[User_Admin_Detail]
ADD CONSTRAINT [PK_User_Admin_Detail]
    PRIMARY KEY CLUSTERED ([admID] ASC);
GO

-- Creating primary key on [gstID] in table 'User_Guest_Detail'
ALTER TABLE [dbo].[User_Guest_Detail]
ADD CONSTRAINT [PK_User_Guest_Detail]
    PRIMARY KEY CLUSTERED ([gstID] ASC);
GO

-- Creating primary key on [mkcID] in table 'User_Marketing_Coordinator_Detail'
ALTER TABLE [dbo].[User_Marketing_Coordinator_Detail]
ADD CONSTRAINT [PK_User_Marketing_Coordinator_Detail]
    PRIMARY KEY CLUSTERED ([mkcID] ASC);
GO

-- Creating primary key on [mkmID] in table 'User_Marketing_Manager_Detail'
ALTER TABLE [dbo].[User_Marketing_Manager_Detail]
ADD CONSTRAINT [PK_User_Marketing_Manager_Detail]
    PRIMARY KEY CLUSTERED ([mkmID] ASC);
GO

-- Creating primary key on [stdID] in table 'User_Student_Detail'
ALTER TABLE [dbo].[User_Student_Detail]
ADD CONSTRAINT [PK_User_Student_Detail]
    PRIMARY KEY CLUSTERED ([stdID] ASC);
GO

-- Creating primary key on [BlogPostID] in table 'BlogPosts'
ALTER TABLE [dbo].[BlogPosts]
ADD CONSTRAINT [PK_BlogPosts]
    PRIMARY KEY CLUSTERED ([BlogPostID] ASC);
GO

-- Creating primary key on [CommentID] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [PK_Comments]
    PRIMARY KEY CLUSTERED ([CommentID] ASC);
GO

-- Creating primary key on [AspNetRoles_Id], [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [PK_AspNetUserRoles]
    PRIMARY KEY CLUSTERED ([AspNetRoles_Id], [AspNetUsers_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserClaims]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserLogins]
    ([UserId]);
GO

-- Creating foreign key on [userId] in table 'User_Admin_Detail'
ALTER TABLE [dbo].[User_Admin_Detail]
ADD CONSTRAINT [fk_Admin_Detail_userId_AspNetUser_ID]
    FOREIGN KEY ([userId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_Admin_Detail_userId_AspNetUser_ID'
CREATE INDEX [IX_fk_Admin_Detail_userId_AspNetUser_ID]
ON [dbo].[User_Admin_Detail]
    ([userId]);
GO

-- Creating foreign key on [facID] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [fk_AspUser_Faculty_facID]
    FOREIGN KEY ([facID])
    REFERENCES [dbo].[Faculties]
        ([facID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_AspUser_Faculty_facID'
CREATE INDEX [IX_fk_AspUser_Faculty_facID]
ON [dbo].[AspNetUsers]
    ([facID]);
GO

-- Creating foreign key on [userId] in table 'User_Guest_Detail'
ALTER TABLE [dbo].[User_Guest_Detail]
ADD CONSTRAINT [fk_User_Guest_Detail_AspNetUser_ID]
    FOREIGN KEY ([userId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_User_Guest_Detail_AspNetUser_ID'
CREATE INDEX [IX_fk_User_Guest_Detail_AspNetUser_ID]
ON [dbo].[User_Guest_Detail]
    ([userId]);
GO

-- Creating foreign key on [userId] in table 'User_Marketing_Coordinator_Detail'
ALTER TABLE [dbo].[User_Marketing_Coordinator_Detail]
ADD CONSTRAINT [fk_User_Marketing_Coordinator_Detail_AspNetUser_ID]
    FOREIGN KEY ([userId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_User_Marketing_Coordinator_Detail_AspNetUser_ID'
CREATE INDEX [IX_fk_User_Marketing_Coordinator_Detail_AspNetUser_ID]
ON [dbo].[User_Marketing_Coordinator_Detail]
    ([userId]);
GO

-- Creating foreign key on [userId] in table 'User_Marketing_Manager_Detail'
ALTER TABLE [dbo].[User_Marketing_Manager_Detail]
ADD CONSTRAINT [fk_User_Marketing_Manager_Detail_AspNetUser_ID]
    FOREIGN KEY ([userId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_User_Marketing_Manager_Detail_AspNetUser_ID'
CREATE INDEX [IX_fk_User_Marketing_Manager_Detail_AspNetUser_ID]
ON [dbo].[User_Marketing_Manager_Detail]
    ([userId]);
GO

-- Creating foreign key on [userId] in table 'User_Student_Detail'
ALTER TABLE [dbo].[User_Student_Detail]
ADD CONSTRAINT [fk_User_Student_Detail_AspNetUser_ID]
    FOREIGN KEY ([userId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_User_Student_Detail_AspNetUser_ID'
CREATE INDEX [IX_fk_User_Student_Detail_AspNetUser_ID]
ON [dbo].[User_Student_Detail]
    ([userId]);
GO

-- Creating foreign key on [fileID] in table 'Contributions'
ALTER TABLE [dbo].[Contributions]
ADD CONSTRAINT [fk_cons_fileidID]
    FOREIGN KEY ([fileID])
    REFERENCES [dbo].[Files]
        ([fileID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_cons_fileidID'
CREATE INDEX [IX_fk_cons_fileidID]
ON [dbo].[Contributions]
    ([fileID]);
GO

-- Creating foreign key on [imgID] in table 'Contributions'
ALTER TABLE [dbo].[Contributions]
ADD CONSTRAINT [fk_cons_imgID]
    FOREIGN KEY ([imgID])
    REFERENCES [dbo].[Images]
        ([imgID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_cons_imgID'
CREATE INDEX [IX_fk_cons_imgID]
ON [dbo].[Contributions]
    ([imgID]);
GO

-- Creating foreign key on [stdID] in table 'Contributions'
ALTER TABLE [dbo].[Contributions]
ADD CONSTRAINT [fk_cons_stdID]
    FOREIGN KEY ([stdID])
    REFERENCES [dbo].[User_Student_Detail]
        ([stdID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_cons_stdID'
CREATE INDEX [IX_fk_cons_stdID]
ON [dbo].[Contributions]
    ([stdID]);
GO

-- Creating foreign key on [AspNetRoles_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRoles]
    FOREIGN KEY ([AspNetRoles_Id])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUsers]
    FOREIGN KEY ([AspNetUsers_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRoles_AspNetUsers'
CREATE INDEX [IX_FK_AspNetUserRoles_AspNetUsers]
ON [dbo].[AspNetUserRoles]
    ([AspNetUsers_Id]);
GO

-- Creating foreign key on [BlogPostID] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [FK_Cmt_BlogPost]
    FOREIGN KEY ([BlogPostID])
    REFERENCES [dbo].[BlogPosts]
        ([BlogPostID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Cmt_BlogPost'
CREATE INDEX [IX_FK_Cmt_BlogPost]
ON [dbo].[Comments]
    ([BlogPostID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------