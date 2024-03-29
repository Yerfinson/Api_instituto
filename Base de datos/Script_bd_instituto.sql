USE [master]
GO
/****** Object:  Database [instituto]    Script Date: 4/03/2024 11:23:36 p. m. ******/
CREATE DATABASE [instituto]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Colegio', FILENAME = N'E:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\instituto.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Colegio_log', FILENAME = N'E:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\instituto_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [instituto] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [instituto].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [instituto] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [instituto] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [instituto] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [instituto] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [instituto] SET ARITHABORT OFF 
GO
ALTER DATABASE [instituto] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [instituto] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [instituto] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [instituto] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [instituto] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [instituto] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [instituto] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [instituto] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [instituto] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [instituto] SET  DISABLE_BROKER 
GO
ALTER DATABASE [instituto] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [instituto] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [instituto] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [instituto] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [instituto] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [instituto] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [instituto] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [instituto] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [instituto] SET  MULTI_USER 
GO
ALTER DATABASE [instituto] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [instituto] SET DB_CHAINING OFF 
GO
ALTER DATABASE [instituto] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [instituto] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [instituto] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [instituto] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [instituto] SET QUERY_STORE = OFF
GO
USE [instituto]
GO
/****** Object:  Table [dbo].[estudents]    Script Date: 4/03/2024 11:23:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[estudents](
	[estu_id] [int] IDENTITY(1,1) NOT NULL,
	[estu_name] [varchar](30) NULL,
	[estu_surname] [varchar](30) NULL,
	[estu_course] [int] NULL,
	[estu_identification_number] [int] NULL,
	[estu_status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[estu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_courses]    Script Date: 4/03/2024 11:23:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_courses](
	[cour_id] [int] IDENTITY(1,1) NOT NULL,
	[cour_name] [varchar](100) NULL,
	[cour_description] [varchar](100) NULL,
 CONSTRAINT [PK__Course__1234EC0739BC17BD] PRIMARY KEY CLUSTERED 
(
	[cour_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_quialification]    Script Date: 4/03/2024 11:23:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_quialification](
	[cua_id] [int] IDENTITY(1,1) NOT NULL,
	[cua_value] [decimal](18, 1) NULL,
 CONSTRAINT [PK_quialification_2056780] PRIMARY KEY CLUSTERED 
(
	[cua_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[estudents] ON 

INSERT [dbo].[estudents] ([estu_id], [estu_name], [estu_surname], [estu_course], [estu_identification_number], [estu_status]) VALUES (1, N'David', N'Capera', 8, 1007161220, 1)
INSERT [dbo].[estudents] ([estu_id], [estu_name], [estu_surname], [estu_course], [estu_identification_number], [estu_status]) VALUES (5, N'fabio', N'll', 9, 1008987667, 0)
INSERT [dbo].[estudents] ([estu_id], [estu_name], [estu_surname], [estu_course], [estu_identification_number], [estu_status]) VALUES (6, N'luiz', N'gomez', NULL, 10034567, 1)
INSERT [dbo].[estudents] ([estu_id], [estu_name], [estu_surname], [estu_course], [estu_identification_number], [estu_status]) VALUES (7, N'felix', N'sanchez', NULL, 1005678, 1)
SET IDENTITY_INSERT [dbo].[estudents] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_courses] ON 

INSERT [dbo].[tbl_courses] ([cour_id], [cour_name], [cour_description]) VALUES (1, N'SEXTO', N'Curso primero de bachiller')
SET IDENTITY_INSERT [dbo].[tbl_courses] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_quialification] ON 

INSERT [dbo].[tbl_quialification] ([cua_id], [cua_value]) VALUES (1, CAST(1.0 AS Decimal(18, 1)))
SET IDENTITY_INSERT [dbo].[tbl_quialification] OFF
GO
USE [master]
GO
ALTER DATABASE [instituto] SET  READ_WRITE 
GO
