USE [master]
GO
/****** Object:  Database [BlogDb]    Script Date: 2021-11-18 9:42:00 PM ******/
CREATE DATABASE [BlogDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BlogDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BlogDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BlogDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BlogDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BlogDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BlogDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BlogDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BlogDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BlogDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BlogDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [BlogDb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BlogDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BlogDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BlogDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BlogDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BlogDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BlogDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BlogDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BlogDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BlogDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BlogDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BlogDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BlogDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BlogDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BlogDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BlogDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BlogDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BlogDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BlogDb] SET  MULTI_USER 
GO
ALTER DATABASE [BlogDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BlogDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BlogDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BlogDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BlogDb] SET DELAYED_DURABILITY = DISABLED 
GO
USE [BlogDb]
GO
/****** Object:  Schema [Guide]    Script Date: 2021-11-18 9:42:01 PM ******/
CREATE SCHEMA [Guide]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2021-11-18 9:42:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Guide].[BlogGuides]    Script Date: 2021-11-18 9:42:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Guide].[BlogGuides](
	[ID] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](500) NULL,
	[Description] [nvarchar](max) NULL,
	[TagId] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_BlogGuides] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Guide].[TagGuides]    Script Date: 2021-11-18 9:42:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Guide].[TagGuides](
	[ID] [uniqueidentifier] NOT NULL,
	[TagName] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_TagGuides] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211118190901_InitDb', N'5.0.5')
GO
INSERT [Guide].[BlogGuides] ([ID], [Title], [Description], [TagId], [CreatedDate], [ModifiedDate], [IsDeleted], [IsActive], [DeletedDate]) VALUES (N'b510c04f-7552-42f3-85de-1ff5110c15dd', N'مقالة11', N'مقالة11', N'eaafe1c0-1bea-434b-b726-b59a529bb3cf', CAST(N'2021-11-18T21:33:50.7090093' AS DateTime2), CAST(N'2021-11-18T21:33:50.7258217' AS DateTime2), 0, 1, NULL)
GO
INSERT [Guide].[TagGuides] ([ID], [TagName], [CreatedDate], [ModifiedDate], [IsDeleted], [IsActive], [DeletedDate]) VALUES (N'c85b607a-812f-42b2-ac27-3cd6c45b60e4', N'وسم2', CAST(N'2021-11-18T21:28:48.9585086' AS DateTime2), CAST(N'2021-11-18T21:28:49.1636391' AS DateTime2), 0, 1, NULL)
GO
INSERT [Guide].[TagGuides] ([ID], [TagName], [CreatedDate], [ModifiedDate], [IsDeleted], [IsActive], [DeletedDate]) VALUES (N'eaafe1c0-1bea-434b-b726-b59a529bb3cf', N'وسم1', CAST(N'2021-11-18T21:32:34.0224284' AS DateTime2), NULL, 0, 1, NULL)
GO
/****** Object:  Index [IX_BlogGuides_TagId]    Script Date: 2021-11-18 9:42:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_BlogGuides_TagId] ON [Guide].[BlogGuides]
(
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [Guide].[BlogGuides]  WITH CHECK ADD  CONSTRAINT [FK_BlogGuides_TagGuides_TagId] FOREIGN KEY([TagId])
REFERENCES [Guide].[TagGuides] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [Guide].[BlogGuides] CHECK CONSTRAINT [FK_BlogGuides_TagGuides_TagId]
GO
/****** Object:  StoredProcedure [Guide].[spBlogs]    Script Date: 2021-11-18 9:42:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Guide].[spBlogs]
@DisplayLength int,
@DisplayStart int,
@SortCol int,
@SortDir nvarchar(10),
@Search nvarchar(255) = NULL

as
begin
    Declare @FirstRec int, @LastRec int
    Set @FirstRec = @DisplayStart;
    Set @LastRec = @DisplayStart + @DisplayLength;
  
    With TBL as
    (
         Select ROW_NUMBER() over (order by
        
         case when (@SortCol = 0 and @SortDir='asc')
             then ID
         end asc,
         case when (@SortCol = 0 and @SortDir='desc')
             then ID
         end desc,
		   case when (@SortCol = 1 and @SortDir='asc')
             then Title
         end asc,
         case when (@SortCol = 1 and @SortDir='desc')
             then Title
         end desc,
		    case when (@SortCol = 2 and @SortDir='asc')
             then Description
         end asc,
         case when (@SortCol = 2 and @SortDir='desc')
             then Description
         end desc,
		  case when (@SortCol = 3 and @SortDir='asc')
             then TagId
         end asc,
         case when (@SortCol = 3 and @SortDir='desc')
             then TagId
         end desc,
		   
		
		   case when (@SortCol = 4 and @SortDir='asc')
             then [CreatedDate]
         end asc,
         case when (@SortCol = 4 and @SortDir='desc')
             then [CreatedDate]
         end desc

      )
		
         as RowNum,
         COUNT(*) over() as TotalCount
      ,format( [CreatedDate],'dd/MM/yyyy hh:mm tt')AddedTime,
      [ID]
      ,Title
	  ,Description
	  ,(select t.TagName from Guide.TagGuides t where t.ID=TagId) TagName
	  
      
  FROM [Guide].BlogGuides

    
         where (@Search IS NULL
                 Or Title like '%' + @Search + '%'
				  Or Description like '%' + @Search + '%'
				 Or (select t.TagName from Guide.TagGuides t where t.ID=TagId) like '%' + @Search + '%'

				 
                 ) and IsDeleted=0
				 
				 
				 
				   )
				 					

    
    Select *
    from TBL
    where RowNum > @FirstRec and RowNum <= @LastRec
	end






GO
/****** Object:  StoredProcedure [Guide].[spTags]    Script Date: 2021-11-18 9:42:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Guide].[spTags]
@DisplayLength int,
@DisplayStart int,
@SortCol int,
@SortDir nvarchar(10),
@Search nvarchar(255) = NULL

as
begin
    Declare @FirstRec int, @LastRec int
    Set @FirstRec = @DisplayStart;
    Set @LastRec = @DisplayStart + @DisplayLength;
  
    With TBL as
    (
         Select ROW_NUMBER() over (order by
        
         case when (@SortCol = 0 and @SortDir='asc')
             then ID
         end asc,
         case when (@SortCol = 0 and @SortDir='desc')
             then ID
         end desc,
		   case when (@SortCol = 1 and @SortDir='asc')
             then TagName
         end asc,
         case when (@SortCol = 1 and @SortDir='desc')
             then TagName
         end desc
		   
		
		   

      )
		
         as RowNum,
         COUNT(*) over() as TotalCount
      ,format( [CreatedDate],'dd/MM/yyyy hh:mm tt')AddedTime,
      [ID]
     ,TagName
	  
      
  FROM [Guide].TagGuides

    
         where (@Search IS NULL
                 Or TagName like '%' + @Search + '%'
				 

				 
                 ) and IsDeleted=0
				 
				 
				 
				   )
				 					

    
    Select *
    from TBL
    where RowNum > @FirstRec and RowNum <= @LastRec
	end






GO
USE [master]
GO
ALTER DATABASE [BlogDb] SET  READ_WRITE 
GO
