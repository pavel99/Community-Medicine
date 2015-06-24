USE [master]
GO
/****** Object:  Database [CommunityMedicineDB]    Script Date: 23/06/2015 20:35:27 ******/
CREATE DATABASE [CommunityMedicineDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CommunityMedicineDB', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.PAVEL\MSSQL\DATA\CommunityMedicineDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CommunityMedicineDB_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.PAVEL\MSSQL\DATA\CommunityMedicineDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CommunityMedicineDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CommunityMedicineDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CommunityMedicineDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CommunityMedicineDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CommunityMedicineDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CommunityMedicineDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CommunityMedicineDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CommunityMedicineDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CommunityMedicineDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [CommunityMedicineDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CommunityMedicineDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CommunityMedicineDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CommunityMedicineDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CommunityMedicineDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CommunityMedicineDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CommunityMedicineDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CommunityMedicineDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CommunityMedicineDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CommunityMedicineDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CommunityMedicineDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CommunityMedicineDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CommunityMedicineDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CommunityMedicineDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CommunityMedicineDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CommunityMedicineDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CommunityMedicineDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CommunityMedicineDB] SET  MULTI_USER 
GO
ALTER DATABASE [CommunityMedicineDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CommunityMedicineDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CommunityMedicineDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CommunityMedicineDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [CommunityMedicineDB]
GO
/****** Object:  Table [dbo].[Center]    Script Date: 23/06/2015 20:35:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Center](
	[CenterId] [int] IDENTITY(1,1) NOT NULL,
	[CenterName] [varchar](200) NOT NULL,
	[CenterCode] [varchar](100) NOT NULL,
	[CenterPassword] [varchar](100) NOT NULL,
	[ThanaId] [int] NOT NULL,
 CONSTRAINT [PK_Center] PRIMARY KEY CLUSTERED 
(
	[CenterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Diesease]    Script Date: 23/06/2015 20:35:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Diesease](
	[DiseaseId] [int] IDENTITY(1,1) NOT NULL,
	[DiseaseName] [varchar](200) NOT NULL,
	[Description] [varchar](800) NOT NULL,
	[TreatementProcedure] [varchar](800) NOT NULL,
 CONSTRAINT [PK_Diesease] PRIMARY KEY CLUSTERED 
(
	[DiseaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DistributeMedicine]    Script Date: 23/06/2015 20:35:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DistributeMedicine](
	[DMedicineId] [int] IDENTITY(1,1) NOT NULL,
	[CenterId] [int] NOT NULL,
	[MedicineId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_DistributeMedicine] PRIMARY KEY CLUSTERED 
(
	[DMedicineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[District]    Script Date: 23/06/2015 20:35:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[District](
	[DistrictId] [int] IDENTITY(1,1) NOT NULL,
	[DistrictName] [varchar](100) NOT NULL,
 CONSTRAINT [PK_District] PRIMARY KEY CLUSTERED 
(
	[DistrictId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Doctor]    Script Date: 23/06/2015 20:35:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Doctor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DoctorName] [varchar](100) NOT NULL,
	[Degree] [varchar](100) NOT NULL,
	[Specialization] [varchar](100) NOT NULL,
	[CenterId] [int] NOT NULL,
 CONSTRAINT [PK_Doctor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Medicine]    Script Date: 23/06/2015 20:35:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Medicine](
	[MedicineId] [int] IDENTITY(1,1) NOT NULL,
	[MedicineName] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Medicine] PRIMARY KEY CLUSTERED 
(
	[MedicineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Thana]    Script Date: 23/06/2015 20:35:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Thana](
	[ThanaId] [int] IDENTITY(1,1) NOT NULL,
	[ThanaName] [varchar](100) NOT NULL,
	[DistrictId] [int] NOT NULL,
 CONSTRAINT [PK_Thana] PRIMARY KEY CLUSTERED 
(
	[ThanaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Center] ON 

INSERT [dbo].[Center] ([CenterId], [CenterName], [CenterCode], [CenterPassword], [ThanaId]) VALUES (1, N'Ramgoti Health Center-1', N'Ram486', N'tTFo2E', 2)
INSERT [dbo].[Center] ([CenterId], [CenterName], [CenterCode], [CenterPassword], [ThanaId]) VALUES (2, N'Ramgoti Health-2', N'Ram661', N'EJ0UgX', 2)
INSERT [dbo].[Center] ([CenterId], [CenterName], [CenterCode], [CenterPassword], [ThanaId]) VALUES (3, N'Sonagazi Health-1', N'Son228', N'ecT0zo', 5)
SET IDENTITY_INSERT [dbo].[Center] OFF
SET IDENTITY_INSERT [dbo].[Diesease] ON 

INSERT [dbo].[Diesease] ([DiseaseId], [DiseaseName], [Description], [TreatementProcedure]) VALUES (1, N'Malaria', N'Malaria is a mosquito-borne infectious disease of humans and other animals caused by parasitic protozoans (a group of single-celled microorganism) belonging to the genus Plasmodium.', N'give a loading dose of 6.25 mg base/kg (=10 mg salt/kg) of quinidine gluconate infused intravenously over 1-2 hours followed by a continuous infusion of 0.0125 mg base/kg/min (=0.02 mg salt/kg/min.')
SET IDENTITY_INSERT [dbo].[Diesease] OFF
SET IDENTITY_INSERT [dbo].[DistributeMedicine] ON 

INSERT [dbo].[DistributeMedicine] ([DMedicineId], [CenterId], [MedicineId], [Quantity]) VALUES (1, 1, 1, 200)
INSERT [dbo].[DistributeMedicine] ([DMedicineId], [CenterId], [MedicineId], [Quantity]) VALUES (2, 1, 2, 100)
INSERT [dbo].[DistributeMedicine] ([DMedicineId], [CenterId], [MedicineId], [Quantity]) VALUES (3, 1, 3, 100)
INSERT [dbo].[DistributeMedicine] ([DMedicineId], [CenterId], [MedicineId], [Quantity]) VALUES (6, 3, 1, 100)
SET IDENTITY_INSERT [dbo].[DistributeMedicine] OFF
SET IDENTITY_INSERT [dbo].[District] ON 

INSERT [dbo].[District] ([DistrictId], [DistrictName]) VALUES (1, N'Dhaka')
INSERT [dbo].[District] ([DistrictId], [DistrictName]) VALUES (2, N'Feni')
INSERT [dbo].[District] ([DistrictId], [DistrictName]) VALUES (3, N'Noakhali')
INSERT [dbo].[District] ([DistrictId], [DistrictName]) VALUES (4, N'Lakshmipur')
INSERT [dbo].[District] ([DistrictId], [DistrictName]) VALUES (5, N'Thakurgaon')
INSERT [dbo].[District] ([DistrictId], [DistrictName]) VALUES (6, N'Natore')
INSERT [dbo].[District] ([DistrictId], [DistrictName]) VALUES (7, N'Comilla')
INSERT [dbo].[District] ([DistrictId], [DistrictName]) VALUES (8, N'Pabna')
INSERT [dbo].[District] ([DistrictId], [DistrictName]) VALUES (9, N'Bogra')
INSERT [dbo].[District] ([DistrictId], [DistrictName]) VALUES (10, N'Chittagong')
INSERT [dbo].[District] ([DistrictId], [DistrictName]) VALUES (11, N'Mymensing')
SET IDENTITY_INSERT [dbo].[District] OFF
SET IDENTITY_INSERT [dbo].[Doctor] ON 

INSERT [dbo].[Doctor] ([Id], [DoctorName], [Degree], [Specialization], [CenterId]) VALUES (1, N'Ismail Hossain', N'	MBBS', N'Medicine', 1)
SET IDENTITY_INSERT [dbo].[Doctor] OFF
SET IDENTITY_INSERT [dbo].[Medicine] ON 

INSERT [dbo].[Medicine] ([MedicineId], [MedicineName]) VALUES (1, N'Napa Extra')
INSERT [dbo].[Medicine] ([MedicineId], [MedicineName]) VALUES (2, N'Saclo 500mg')
INSERT [dbo].[Medicine] ([MedicineId], [MedicineName]) VALUES (3, N'Maxpro 20mg')
SET IDENTITY_INSERT [dbo].[Medicine] OFF
SET IDENTITY_INSERT [dbo].[Thana] ON 

INSERT [dbo].[Thana] ([ThanaId], [ThanaName], [DistrictId]) VALUES (1, N'Raipur', 4)
INSERT [dbo].[Thana] ([ThanaId], [ThanaName], [DistrictId]) VALUES (2, N'Ramgoti', 4)
INSERT [dbo].[Thana] ([ThanaId], [ThanaName], [DistrictId]) VALUES (3, N'Ramgonj', 4)
INSERT [dbo].[Thana] ([ThanaId], [ThanaName], [DistrictId]) VALUES (4, N'Komalnagor', 4)
INSERT [dbo].[Thana] ([ThanaId], [ThanaName], [DistrictId]) VALUES (5, N'Sonagazi', 2)
INSERT [dbo].[Thana] ([ThanaId], [ThanaName], [DistrictId]) VALUES (6, N'Fulgazi', 2)
INSERT [dbo].[Thana] ([ThanaId], [ThanaName], [DistrictId]) VALUES (8, N'Daganbhuiyan', 2)
INSERT [dbo].[Thana] ([ThanaId], [ThanaName], [DistrictId]) VALUES (9, N'Chhagalnaiya', 2)
INSERT [dbo].[Thana] ([ThanaId], [ThanaName], [DistrictId]) VALUES (10, N'Porshuram', 2)
INSERT [dbo].[Thana] ([ThanaId], [ThanaName], [DistrictId]) VALUES (12, N'Horipur', 5)
INSERT [dbo].[Thana] ([ThanaId], [ThanaName], [DistrictId]) VALUES (13, N'Pirganj', 5)
INSERT [dbo].[Thana] ([ThanaId], [ThanaName], [DistrictId]) VALUES (14, N'Baliadangi ', 5)
INSERT [dbo].[Thana] ([ThanaId], [ThanaName], [DistrictId]) VALUES (15, N'Ranisankail ', 5)
SET IDENTITY_INSERT [dbo].[Thana] OFF
ALTER TABLE [dbo].[Center]  WITH CHECK ADD  CONSTRAINT [FK_Center_Thana] FOREIGN KEY([ThanaId])
REFERENCES [dbo].[Thana] ([ThanaId])
GO
ALTER TABLE [dbo].[Center] CHECK CONSTRAINT [FK_Center_Thana]
GO
ALTER TABLE [dbo].[Doctor]  WITH CHECK ADD  CONSTRAINT [FK_Doctor_Center] FOREIGN KEY([CenterId])
REFERENCES [dbo].[Center] ([CenterId])
GO
ALTER TABLE [dbo].[Doctor] CHECK CONSTRAINT [FK_Doctor_Center]
GO
ALTER TABLE [dbo].[Thana]  WITH CHECK ADD  CONSTRAINT [FK_Thana_District] FOREIGN KEY([DistrictId])
REFERENCES [dbo].[District] ([DistrictId])
GO
ALTER TABLE [dbo].[Thana] CHECK CONSTRAINT [FK_Thana_District]
GO
USE [master]
GO
ALTER DATABASE [CommunityMedicineDB] SET  READ_WRITE 
GO
