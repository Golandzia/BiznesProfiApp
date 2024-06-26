USE [master]
GO
/****** Object:  Database [BiznesProfiApp]    Script Date: 27.05.2024 9:28:15 ******/
CREATE DATABASE [BiznesProfiApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BiznesProfiApp', FILENAME = N'D:\SQLServer\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\BiznesProfiApp.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BiznesProfiApp_log', FILENAME = N'D:\SQLServer\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\BiznesProfiApp_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BiznesProfiApp] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BiznesProfiApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BiznesProfiApp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BiznesProfiApp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BiznesProfiApp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BiznesProfiApp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BiznesProfiApp] SET ARITHABORT OFF 
GO
ALTER DATABASE [BiznesProfiApp] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BiznesProfiApp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BiznesProfiApp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BiznesProfiApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BiznesProfiApp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BiznesProfiApp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BiznesProfiApp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BiznesProfiApp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BiznesProfiApp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BiznesProfiApp] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BiznesProfiApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BiznesProfiApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BiznesProfiApp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BiznesProfiApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BiznesProfiApp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BiznesProfiApp] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BiznesProfiApp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BiznesProfiApp] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BiznesProfiApp] SET  MULTI_USER 
GO
ALTER DATABASE [BiznesProfiApp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BiznesProfiApp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BiznesProfiApp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BiznesProfiApp] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BiznesProfiApp] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BiznesProfiApp] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BiznesProfiApp] SET QUERY_STORE = ON
GO
ALTER DATABASE [BiznesProfiApp] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BiznesProfiApp]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 27.05.2024 9:28:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[ID] [int] NOT NULL,
	[Full_name] [nvarchar](200) NOT NULL,
	[Organization_name] [nvarchar](100) NULL,
	[Individual_taxpayer_namber] [int] NOT NULL,
	[Phone_number] [nvarchar](15) NOT NULL,
	[Other_contact] [int] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[File]    Script Date: 27.05.2024 9:28:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[File](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Content] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_File] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Other_contacts]    Script Date: 27.05.2024 9:28:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Other_contacts](
	[ID] [int] NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Contact] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Other_contacts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 27.05.2024 9:28:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[ID] [int] NOT NULL,
	[Value] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Task]    Script Date: 27.05.2024 9:28:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[ID] [int] NOT NULL,
	[Type_of_task] [int] NOT NULL,
	[Short_description] [nvarchar](max) NOT NULL,
	[Full_task] [nvarchar](max) NOT NULL,
	[Files] [int] NULL,
	[Responsible] [int] NOT NULL,
	[Customer] [int] NOT NULL,
	[Deadline] [datetime] NOT NULL,
	[Task_status] [int] NOT NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Task_status]    Script Date: 27.05.2024 9:28:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task_status](
	[ID] [int] NOT NULL,
	[Value] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Task_status] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Type_of_task]    Script Date: 27.05.2024 9:28:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Type_of_task](
	[ID] [int] NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Type_of_task] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 27.05.2024 9:28:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Post] [int] NOT NULL,
	[Full_name] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](16) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Customer] ([ID], [Full_name], [Organization_name], [Individual_taxpayer_namber], [Phone_number], [Other_contact]) VALUES (1, N'Иванов Иван Иванович', N'ИП - Индивидуальный предпрениматель', 1000000, N'+79000000000', NULL)
INSERT [dbo].[Customer] ([ID], [Full_name], [Organization_name], [Individual_taxpayer_namber], [Phone_number], [Other_contact]) VALUES (2, N'Зубенко Михаил Петрович', N'ООО "22 век"', 1235467, N'+79000000000', NULL)
GO
INSERT [dbo].[Post] ([ID], [Value]) VALUES (1, N'Администратор')
INSERT [dbo].[Post] ([ID], [Value]) VALUES (2, N'Главный администратор')
GO
INSERT [dbo].[Task] ([ID], [Type_of_task], [Short_description], [Full_task], [Files], [Responsible], [Customer], [Deadline], [Task_status]) VALUES (0, 1, N'уцклгрывоабмнпывам', N'ыкепывпагынвапывпвапр
вап
рвапрва
пр
вапр
вап
рва
пр
вапр
вап
рвапр', NULL, 1, 2, CAST(N'2023-12-17T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Task] ([ID], [Type_of_task], [Short_description], [Full_task], [Files], [Responsible], [Customer], [Deadline], [Task_status]) VALUES (1, 1, N'Передача документов в офисе', N'Передать пакет документов лежащий на столе администратора клиенту "ИП Иванову И. И."', NULL, 1, 1, CAST(N'2024-05-15T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Task] ([ID], [Type_of_task], [Short_description], [Full_task], [Files], [Responsible], [Customer], [Deadline], [Task_status]) VALUES (2, 1, N'Передача документов в офисе', N'Передать пакет документов лежащий на столе администратора клиенту "ИП Иванову И. И."', NULL, 1, 1, CAST(N'2024-05-15T00:00:00.000' AS DateTime), 3)
GO
INSERT [dbo].[Task_status] ([ID], [Value]) VALUES (1, N'Ожидает выполнения')
INSERT [dbo].[Task_status] ([ID], [Value]) VALUES (2, N'Выполнено')
INSERT [dbo].[Task_status] ([ID], [Value]) VALUES (3, N'Просрочено')
INSERT [dbo].[Task_status] ([ID], [Value]) VALUES (4, N'Выполняется')
INSERT [dbo].[Task_status] ([ID], [Value]) VALUES (5, N'Отложено')
GO
INSERT [dbo].[Type_of_task] ([ID], [Type], [Description]) VALUES (1, N'Передача документов', N'Встретиться с клентом и передать документы')
GO
INSERT [dbo].[User] ([ID], [Login], [Password], [Post], [Full_name], [Phone]) VALUES (1, N'test', N'test', 1, N'Соловьев Д. В.', N'+79604374828')
INSERT [dbo].[User] ([ID], [Login], [Password], [Post], [Full_name], [Phone]) VALUES (2, N'tests', N'test', 2, N'Петрова Д. С.', N'+79604374828')
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Other_contacts] FOREIGN KEY([Other_contact])
REFERENCES [dbo].[Other_contacts] ([ID])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Other_contacts]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Customer] FOREIGN KEY([Customer])
REFERENCES [dbo].[Customer] ([ID])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Customer]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_File] FOREIGN KEY([Files])
REFERENCES [dbo].[File] ([ID])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_File]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Task_status] FOREIGN KEY([Task_status])
REFERENCES [dbo].[Task_status] ([ID])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Task_status]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Type_of_task_task] FOREIGN KEY([Type_of_task])
REFERENCES [dbo].[Type_of_task] ([ID])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Type_of_task_task]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_User] FOREIGN KEY([Responsible])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_User]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Post] FOREIGN KEY([Post])
REFERENCES [dbo].[Post] ([ID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Post]
GO
USE [master]
GO
ALTER DATABASE [BiznesProfiApp] SET  READ_WRITE 
GO
