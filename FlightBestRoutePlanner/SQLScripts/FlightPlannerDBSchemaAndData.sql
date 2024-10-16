USE [master]
GO
/****** Object:  Database [FlightPlanner]    Script Date: 16/10/2024 22:33:43 ******/
CREATE DATABASE [FlightPlanner]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FlightPlanner', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\FlightPlanner.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FlightPlanner_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\FlightPlanner_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [FlightPlanner] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FlightPlanner].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FlightPlanner] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FlightPlanner] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FlightPlanner] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FlightPlanner] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FlightPlanner] SET ARITHABORT OFF 
GO
ALTER DATABASE [FlightPlanner] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FlightPlanner] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FlightPlanner] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FlightPlanner] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FlightPlanner] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FlightPlanner] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FlightPlanner] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FlightPlanner] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FlightPlanner] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FlightPlanner] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FlightPlanner] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FlightPlanner] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FlightPlanner] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FlightPlanner] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FlightPlanner] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FlightPlanner] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FlightPlanner] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FlightPlanner] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FlightPlanner] SET  MULTI_USER 
GO
ALTER DATABASE [FlightPlanner] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FlightPlanner] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FlightPlanner] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FlightPlanner] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FlightPlanner] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FlightPlanner] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [FlightPlanner] SET QUERY_STORE = ON
GO
ALTER DATABASE [FlightPlanner] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [FlightPlanner]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 16/10/2024 22:33:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Flights]    Script Date: 16/10/2024 22:33:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flights](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SourceCityId] [int] NOT NULL,
	[DestinationCityId] [int] NOT NULL,
	[Distance] [int] NOT NULL,
	[BasePrice] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cities] ON 

INSERT [dbo].[Cities] ([Id], [Name]) VALUES (1, N'City_A')
INSERT [dbo].[Cities] ([Id], [Name]) VALUES (2, N'City_B')
INSERT [dbo].[Cities] ([Id], [Name]) VALUES (3, N'City_C')
INSERT [dbo].[Cities] ([Id], [Name]) VALUES (4, N'City_D')
INSERT [dbo].[Cities] ([Id], [Name]) VALUES (5, N'City_E')
SET IDENTITY_INSERT [dbo].[Cities] OFF
GO
SET IDENTITY_INSERT [dbo].[Flights] ON 

INSERT [dbo].[Flights] ([Id], [SourceCityId], [DestinationCityId], [Distance], [BasePrice]) VALUES (1, 1, 2, 500, CAST(50.00 AS Decimal(10, 2)))
INSERT [dbo].[Flights] ([Id], [SourceCityId], [DestinationCityId], [Distance], [BasePrice]) VALUES (2, 2, 3, 300, CAST(30.00 AS Decimal(10, 2)))
INSERT [dbo].[Flights] ([Id], [SourceCityId], [DestinationCityId], [Distance], [BasePrice]) VALUES (3, 1, 3, 800, CAST(80.00 AS Decimal(10, 2)))
INSERT [dbo].[Flights] ([Id], [SourceCityId], [DestinationCityId], [Distance], [BasePrice]) VALUES (4, 3, 4, 400, CAST(40.00 AS Decimal(10, 2)))
INSERT [dbo].[Flights] ([Id], [SourceCityId], [DestinationCityId], [Distance], [BasePrice]) VALUES (5, 4, 5, 200, CAST(20.00 AS Decimal(10, 2)))
INSERT [dbo].[Flights] ([Id], [SourceCityId], [DestinationCityId], [Distance], [BasePrice]) VALUES (6, 2, 5, 600, CAST(60.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Flights] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Cities__737584F62DA3E12C]    Script Date: 16/10/2024 22:33:44 ******/
ALTER TABLE [dbo].[Cities] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Flights_DestinationCityId]    Script Date: 16/10/2024 22:33:44 ******/
CREATE NONCLUSTERED INDEX [IX_Flights_DestinationCityId] ON [dbo].[Flights]
(
	[DestinationCityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Flights_SourceCityId]    Script Date: 16/10/2024 22:33:44 ******/
CREATE NONCLUSTERED INDEX [IX_Flights_SourceCityId] ON [dbo].[Flights]
(
	[SourceCityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Flights]  WITH CHECK ADD FOREIGN KEY([DestinationCityId])
REFERENCES [dbo].[Cities] ([Id])
GO
ALTER TABLE [dbo].[Flights]  WITH CHECK ADD FOREIGN KEY([SourceCityId])
REFERENCES [dbo].[Cities] ([Id])
GO
USE [master]
GO
ALTER DATABASE [FlightPlanner] SET  READ_WRITE 
GO
