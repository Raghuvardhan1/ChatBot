
GO
ALTER DATABASE [Chatbot] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Chatbot] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Chatbot] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Chatbot] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Chatbot] SET ARITHABORT OFF 
GO
ALTER DATABASE [Chatbot] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Chatbot] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Chatbot] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Chatbot] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Chatbot] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Chatbot] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Chatbot] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Chatbot] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Chatbot] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Chatbot] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Chatbot] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Chatbot] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Chatbot] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Chatbot] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Chatbot] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Chatbot] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Chatbot] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Chatbot] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Chatbot] SET  MULTI_USER 
GO
ALTER DATABASE [Chatbot] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Chatbot] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Chatbot] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Chatbot] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Chatbot] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Chatbot] SET QUERY_STORE = OFF
GO
USE [Chatbot]
GO
/****** Object:  Table [dbo].[CustomersTbls]    Script Date: 9/26/2019 11:16:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomersTbls](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
	[contact] [bigint] NOT NULL,
	[region] [varchar](20) NOT NULL,
 CONSTRAINT [PK_CustomersTbls] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InterestsTbls]    Script Date: 9/26/2019 11:16:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InterestsTbls](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[customer_id] [int] NOT NULL,
	[monitor_id] [int] NULL,
	[timestamp] [datetime] NULL,
 CONSTRAINT [PK_InterestsTbls] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MonitorsTbls]    Script Date: 9/26/2019 11:16:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonitorsTbls](
	[monitor_id] [int] NOT NULL,
	[monitor_name] [varchar](100) NULL,
 CONSTRAINT [PK_MonitorsTbls] PRIMARY KEY CLUSTERED 
(
	[monitor_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OptionsTbls]    Script Date: 9/26/2019 11:16:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OptionsTbls](
	[option_id] [int] NOT NULL,
	[option] [varchar](100) NULL,
	[link_id] [int] NOT NULL,
	[monitor_id] [int] NOT NULL,
	[question_id] [int] NOT NULL,
 CONSTRAINT [PK_OptionsTbls] PRIMARY KEY CLUSTERED 
(
	[option_id] ASC,
	[link_id] ASC,
	[monitor_id] ASC,
	[question_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdersTbls]    Script Date: 9/26/2019 11:16:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdersTbls](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[customer_id] [int] NOT NULL,
	[monitor_id] [int] NULL,
	[timestamp] [datetime] NULL,
 CONSTRAINT [PK_OrdersTbls] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuestionsTbls]    Script Date: 9/26/2019 11:16:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionsTbls](
	[question_id] [int] NOT NULL,
	[question] [varchar](max) NULL,
 CONSTRAINT [PK_QuestionsTbls] PRIMARY KEY CLUSTERED 
(
	[question_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_InterestsTbls_CustomersTbls]    Script Date: 9/26/2019 11:16:53 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK_InterestsTbls_CustomersTbls] ON [dbo].[InterestsTbls]
(
	[customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__OptionsTb__monit__282DF8C2]    Script Date: 9/26/2019 11:16:53 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK__OptionsTb__monit__282DF8C2] ON [dbo].[OptionsTbls]
(
	[monitor_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK__OptionsTb__quest__2739D489]    Script Date: 9/26/2019 11:16:53 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK__OptionsTb__quest__2739D489] ON [dbo].[OptionsTbls]
(
	[question_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_OrdersTbl_CustomersTbl]    Script Date: 9/26/2019 11:16:53 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK_OrdersTbl_CustomersTbl] ON [dbo].[OrdersTbls]
(
	[customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[InterestsTbls]  WITH CHECK ADD  CONSTRAINT [FK_InterestsTbl_CustomersTbl] FOREIGN KEY([customer_id])
REFERENCES [dbo].[CustomersTbls] ([id])
GO
ALTER TABLE [dbo].[InterestsTbls] CHECK CONSTRAINT [FK_InterestsTbl_CustomersTbl]
GO
ALTER TABLE [dbo].[InterestsTbls]  WITH CHECK ADD  CONSTRAINT [FK_InterestsTbl_MonitorsTbl] FOREIGN KEY([monitor_id])
REFERENCES [dbo].[MonitorsTbls] ([monitor_id])
GO
ALTER TABLE [dbo].[InterestsTbls] CHECK CONSTRAINT [FK_InterestsTbl_MonitorsTbl]
GO
ALTER TABLE [dbo].[OptionsTbls]  WITH CHECK ADD  CONSTRAINT [FK__OptionsTb__monit__282DF8C2] FOREIGN KEY([monitor_id])
REFERENCES [dbo].[MonitorsTbls] ([monitor_id])
GO
ALTER TABLE [dbo].[OptionsTbls] CHECK CONSTRAINT [FK__OptionsTb__monit__282DF8C2]
GO
ALTER TABLE [dbo].[OptionsTbls]  WITH CHECK ADD  CONSTRAINT [FK__OptionsTb__quest__2739D489] FOREIGN KEY([question_id])
REFERENCES [dbo].[QuestionsTbls] ([question_id])
GO
ALTER TABLE [dbo].[OptionsTbls] CHECK CONSTRAINT [FK__OptionsTb__quest__2739D489]
GO
ALTER TABLE [dbo].[OrdersTbls]  WITH CHECK ADD  CONSTRAINT [FK_OrdersTbl_CustomersTbl] FOREIGN KEY([customer_id])
REFERENCES [dbo].[CustomersTbls] ([id])
GO
ALTER TABLE [dbo].[OrdersTbls] CHECK CONSTRAINT [FK_OrdersTbl_CustomersTbl]
GO
ALTER TABLE [dbo].[OrdersTbls]  WITH CHECK ADD  CONSTRAINT [FK_OrdersTbl_MonitorsTbl] FOREIGN KEY([monitor_id])
REFERENCES [dbo].[MonitorsTbls] ([monitor_id])
GO
ALTER TABLE [dbo].[OrdersTbls] CHECK CONSTRAINT [FK_OrdersTbl_MonitorsTbl]
GO
USE [master]
GO
ALTER DATABASE [Chatbot] SET  READ_WRITE 
GO



USE [Chatbot]
GO

INSERT INTO [dbo].[MonitorsTbls]
           ([monitor_id]
           ,[monitor_name])
     VALUES
           (0,'No Monitors'),(1,'Avalon CL'),(2,'Avalon FM20'),(3,'Avalon FM30'),(4,'Avalon FM40'),(5,'Avalon FM50'),(6,'SureSigns VM1'),(7,'SureSigns VS2+'),(8,'SureSigns VS4'),(9,'SureSigns VSi'),(10,'SureSigns VS3'),
		   (11,'SureSigns VM6'),(12,'SureSigns VM4'),(13,'SureSigns VM8'),(14,'IntelliVue MX40'),(15,'IntelliVue MP2'),(16,'IntelliVue MP5'),(17,'IntelliVue MX450'),(18,'IntelliVue MX700'),(19,'IntelliVue MMSX2'),(20,'IntelliVue MX500'),
		   (21,'IntelliVue MP90'),(22,'IntelliVue MP5SC'),(23,'IntelliVue MX550'),(24,'IntelliVue MX400'),(25,'IntelliVue MX800'),(26,'IntelliVue MP5T'),(27,'Intellivue GS'),(28,'Efficia CM series'),(29,'Efficia CMS 200')
GO




INSERT INTO [dbo].[QuestionsTbls]
           ([question_id]
           ,[question])
     VALUES
           (0,'No more questions'),(1,'What is the basic requirement of your monitor?'),(2,'Do you want a monitor with cable or cableless?'),(3,'What kind of carestage do you expect?'),(4,'Do you want video and audio interface?'),
		   (5,'Do you want video and audio interface?'),(6,'Do you require Microstream Co2 for capnography measurement ?'),(7,'How do you want to take temperature ?'),(8,'Do you need easy readibility of pleth waveforms ?'),(9,
		   'What type of portability do you require ?'),(10,'Do you require a product which can quickly capture patient data ?'),(11,'What kind of storage are you looking for ?'),(12,'Select one of the required features from the following options.'),
		   (13,'What kind of monitor do you expect ?'),(14,'Select one of the required features from the following options.'),(15,'Select the monitor size.'),(16,'Select one of the required features from the following options.'),
		   (17,'Select one of the required features from the following options.'),(18,'What kind of blood pressure monitoring do you require ?'),(19,'Do you require CO2 measurement capability ?')
GO



INSERT INTO [dbo].[OptionsTbls]
           ([option_id]
           ,[option]
           ,[link_id]
           ,[monitor_id]
           ,[question_id])
     VALUES
           (1,'Maternal and Fetal',2,0,1),(2,'Vital Signs',6,0,1),(3,'Bedside Patient Monitor',18,0,1),(4,'Central Monitoring System',0,29,1),(5,'IntelliVue(serves a wide range of care environment)',12,0,1),(1,'Cableless',0,1,2),(2,'Cable',3,0,2),(1,'Anti-Partum',4,0,3),
(2,'Intra-partum',5,0,3),(1,'Yes',0,4,4),(2,'No',0,2,4),(1,'Yes',0,5,5),(2,'No',0,3,5),(1,'Yes',0,6,6),(2,'No',7,0,6),(1,'Oral',8,0,7),(2,'Tympanic',0,10,7),(1,'Yes',0,7,8),(2,'No',9,0,8),
(1,'Easy Portable',0,9,9),(2,'Not portable',10,0,9),(1,'Yes',0,8,10),(2,'No',11,0,10),(1,'50 records',0,9,11),(2,'100 records',0,7,11),(3,'Upto 400 records',0,10,11),(4,'Upto 800 records',0,8,11),
(1,'Bedside Monitors',13,0,12),(2,'Telemetry',0,26,12),(3,'Automated Early Warning System',0,27,12),(4,'Spot Check Patient Monitor',0,22,12),(5,'Portable',0,19,12),(1,'Wearable',0,14,13),(2,'Non-Portable',14,0,13),
(3,'Portable',15,0,13),(1,'NBP Measurement',0,21,14),(2,'Integrated PC',0,18,14),(3,'Dynamic Wave Measurement',0,16,14),(1,'Small(8-10)',16,0,15),(2,'Medium(10-12)',17,0,15),(3,'Large(12-15)',0,23,15),(1,'NBP Measurement',0,15,16),
(2,'Advanced Clinical Solutions',0,24,16),(1,'Integrated PC',0,25,17),(2,'Advanced Clinical Solutions',0,17,17),(1,'Non-Invasive Blood Pressure Monitoring',0,12,18),(2,'Invasive and Non-Invasive Blood Pressure Monitoring',19,0,18),
(1,'Yes',0,13,19),(2,'No',0,11,19)
GO

INSERT INTO [dbo].[CustomersTbls]
			([name]
			,[contact]
			,[region])
		VALUES
			('Pushkaraj',8983632885,'Asia'),('Raghuvardhan',8796284836,'Europe'),('Rahul',9852343723,'Africa'),('Mayank',6341623767,'Europe'),('Sreelal',8574253647,'Asia')
GO

INSERT INTO [dbo].[InterestsTbls]
			([customer_id]
			,[monitor_id]
			,[timestamp])
		VALUES
			(2,3,'2019-09-25 00:00:01'),(2,14,'2019-09-24 00:00:01'),(3,11,'2019-09-23 00:00:01'),(1,15,'2019-09-22 00:00:01'),(4,4,'2019-09-21 00:00:01'),(5,18,'2019-09-20 05:02:09')
GO

INSERT INTO [dbo].[OrdersTbls]
			([customer_id]
			,[monitor_id]
			,[timestamp])
		VALUES
			(2,3,'2019-09-23 00:10:10')
GO