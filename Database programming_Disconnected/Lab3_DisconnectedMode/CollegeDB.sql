USE [master]
GO
/****** Object:  Database [CollegeDB]    Script Date: 10/22/2019 3:50:26 PM ******/
CREATE DATABASE [CollegeDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CollegeDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER2017\MSSQL\DATA\CollegeDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CollegeDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER2017\MSSQL\DATA\CollegeDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CollegeDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CollegeDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CollegeDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CollegeDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CollegeDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CollegeDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CollegeDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CollegeDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CollegeDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CollegeDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CollegeDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CollegeDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CollegeDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CollegeDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CollegeDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CollegeDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CollegeDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CollegeDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CollegeDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CollegeDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CollegeDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CollegeDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CollegeDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CollegeDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CollegeDB] SET RECOVERY FULL 
GO
ALTER DATABASE [CollegeDB] SET  MULTI_USER 
GO
ALTER DATABASE [CollegeDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CollegeDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CollegeDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CollegeDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CollegeDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CollegeDB] SET QUERY_STORE = OFF
GO
USE [CollegeDB]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 10/22/2019 3:50:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[CourseCode] [nvarchar](9) NOT NULL,
	[CourseTitle] [nvarchar](50) NOT NULL,
	[TotalHour] [int] NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[CourseCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentCourses]    Script Date: 10/22/2019 3:50:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentCourses](
	[StudentId] [int] NOT NULL,
	[CourseCode] [nvarchar](9) NOT NULL,
	[RegistrationDate] [datetime] NOT NULL,
	[StartingDate] [datetime] NULL,
	[EndingDate] [datetime] NULL,
 CONSTRAINT [PK_StudentCourses] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC,
	[CourseCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 10/22/2019 3:50:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentId] [int] IDENTITY(1111111,1) NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[LastName] [nvarchar](40) NOT NULL,
	[Email] [nvarchar](100) NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Courses] ([CourseCode], [CourseTitle], [TotalHour]) VALUES (N'COMP101', N'Structured Programming', 90)
INSERT [dbo].[Courses] ([CourseCode], [CourseTitle], [TotalHour]) VALUES (N'COMP102', N'Introduction to Object-Oriented Programming', 75)
INSERT [dbo].[Courses] ([CourseCode], [CourseTitle], [TotalHour]) VALUES (N'COMP201', N'Advanced Object-Oriented Programming I', 90)
INSERT [dbo].[Courses] ([CourseCode], [CourseTitle], [TotalHour]) VALUES (N'COMP202', N'Advanced Object-Oriented Programming II', 75)
INSERT [dbo].[Courses] ([CourseCode], [CourseTitle], [TotalHour]) VALUES (N'COMP301', N'Internet Programming I', 90)
INSERT [dbo].[Courses] ([CourseCode], [CourseTitle], [TotalHour]) VALUES (N'COMP302', N'Internet Programming II', 75)
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [Email]) VALUES (1111111, N'John', N'Abbot', N'john@yaho.com')
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [Email]) VALUES (1111112, N'Mary', N'Green', N'mary@gmail.com')
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [Email]) VALUES (1111113, N'Thomas', N'Moore', N'thomas@hotmail.com')
SET IDENTITY_INSERT [dbo].[Students] OFF
ALTER TABLE [dbo].[StudentCourses]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourses_Courses] FOREIGN KEY([CourseCode])
REFERENCES [dbo].[Courses] ([CourseCode])
GO
ALTER TABLE [dbo].[StudentCourses] CHECK CONSTRAINT [FK_StudentCourses_Courses]
GO
ALTER TABLE [dbo].[StudentCourses]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourses_Students] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([StudentId])
GO
ALTER TABLE [dbo].[StudentCourses] CHECK CONSTRAINT [FK_StudentCourses_Students]
GO
USE [master]
GO
ALTER DATABASE [CollegeDB] SET  READ_WRITE 
GO
