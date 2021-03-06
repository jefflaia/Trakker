USE [master]
GO
/****** Object:  Database [Trakker]    Script Date: 07/18/2010 22:16:19 ******/
CREATE DATABASE [Trakker] ON  PRIMARY 
( NAME = N'Trakker', FILENAME = N'H:\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\Trakker.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Trakker_log', FILENAME = N'H:\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\Trakker_log.LDF' , SIZE = 768KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Trakker] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Trakker].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Trakker] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Trakker] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Trakker] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Trakker] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Trakker] SET ARITHABORT OFF
GO
ALTER DATABASE [Trakker] SET AUTO_CLOSE ON
GO
ALTER DATABASE [Trakker] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Trakker] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Trakker] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Trakker] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Trakker] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Trakker] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Trakker] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Trakker] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Trakker] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Trakker] SET  ENABLE_BROKER
GO
ALTER DATABASE [Trakker] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Trakker] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Trakker] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Trakker] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Trakker] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Trakker] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [Trakker] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [Trakker] SET  READ_WRITE
GO
ALTER DATABASE [Trakker] SET RECOVERY SIMPLE
GO
ALTER DATABASE [Trakker] SET  MULTI_USER
GO
ALTER DATABASE [Trakker] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Trakker] SET DB_CHAINING OFF
GO
USE [Trakker]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 07/18/2010 22:16:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[StatusId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_dbo.Status] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Status] ON
INSERT [dbo].[Status] ([StatusId], [Name], [Description]) VALUES (1, N'Status 1', N'Status')
SET IDENTITY_INSERT [dbo].[Status] OFF
/****** Object:  Table [dbo].[Severity]    Script Date: 07/18/2010 22:16:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Severity](
	[SeverityId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](250) NOT NULL,
	[HexColor] [char](6) NOT NULL,
 CONSTRAINT [PK_dbo.Severity] PRIMARY KEY CLUSTERED 
(
	[SeverityId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Severity] ON
INSERT [dbo].[Severity] ([SeverityId], [Name], [Description], [HexColor]) VALUES (1, N'Severity 1', N'tests', N'AF123D')
SET IDENTITY_INSERT [dbo].[Severity] OFF
/****** Object:  Table [dbo].[Role]    Script Date: 07/18/2010 22:16:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[Description] [text] NOT NULL,
 CONSTRAINT [PK_dbo.Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON
INSERT [dbo].[Role] ([RoleId], [Name], [Description]) VALUES (2, N'Administrator', N'Admin')
SET IDENTITY_INSERT [dbo].[Role] OFF
/****** Object:  Table [dbo].[Category]    Script Date: 07/18/2010 22:16:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](250) NOT NULL,
 CONSTRAINT [PK_dbo.Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON
INSERT [dbo].[Category] ([CategoryId], [Name], [Description]) VALUES (1, N'Category 1', N'adadasd')
SET IDENTITY_INSERT [dbo].[Category] OFF
/****** Object:  Table [dbo].[Priority]    Script Date: 07/18/2010 22:16:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Priority](
	[PriorityId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](250) NOT NULL,
	[HexColor] [char](10) NOT NULL,
 CONSTRAINT [PK_dbo.Priority] PRIMARY KEY CLUSTERED 
(
	[PriorityId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Priority] ON
INSERT [dbo].[Priority] ([PriorityId], [Name], [Description], [HexColor]) VALUES (1, N'Priority 1', N'adlkajdkla ', N'FF43F1    ')
SET IDENTITY_INSERT [dbo].[Priority] OFF
/****** Object:  Table [dbo].[User]    Script Date: 07/18/2010 22:16:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](250) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Salt] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[LastLogin] [datetime] NOT NULL,
	[TotalComments] [int] NOT NULL,
	[FailedPasswordAttemptCount] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[LastFailedLoginAttempt] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.[User]]] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON
INSERT [dbo].[User] ([UserId], [Email], [Password], [Salt], [Created], [LastLogin], [TotalComments], [FailedPasswordAttemptCount], [RoleId], [LastFailedLoginAttempt]) VALUES (2, N'justin', N'justin', N'justin', CAST(0x00009CF100000000 AS DateTime), CAST(0x00009CF100000000 AS DateTime), 0, 0, 2, CAST(0x00009CF100000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[User] OFF
/****** Object:  Table [dbo].[Project]    Script Date: 07/18/2010 22:16:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Project](
	[ProjectId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](250) NOT NULL,
	[Lead] [int] NOT NULL,
	[KeyName] [varchar](20) NOT NULL,
	[Due] [datetime] NOT NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Project] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [Project_Unique_KeyName] UNIQUE NONCLUSTERED 
(
	[KeyName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [Project_Unique_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Project] ON
INSERT [dbo].[Project] ([ProjectId], [Name], [Lead], [KeyName], [Due], [Created]) VALUES (1, N'I has lots of ticketss', 2, N'IHLThh', CAST(0x00009CF100000000 AS DateTime), CAST(0x00009D7201836AF0 AS DateTime))
INSERT [dbo].[Project] ([ProjectId], [Name], [Lead], [KeyName], [Due], [Created]) VALUES (2, N'Sara Romano', 2, N'SR', CAST(0x00009D72000D8DAF AS DateTime), CAST(0x00009D72000D8DAF AS DateTime))
INSERT [dbo].[Project] ([ProjectId], [Name], [Lead], [KeyName], [Due], [Created]) VALUES (9, N'Clean Up', 2, N'CU', CAST(0x00009D72001140CC AS DateTime), CAST(0x00009D7200114129 AS DateTime))
SET IDENTITY_INSERT [dbo].[Project] OFF
/****** Object:  Table [dbo].[Ticket]    Script Date: 07/18/2010 22:16:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ticket](
	[TicketId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Summary] [nvarchar](150) NOT NULL,
	[PriorityId] [int] NOT NULL,
	[Description] [text] NOT NULL,
	[Created] [datetime] NOT NULL,
	[DueDate] [datetime] NOT NULL,
	[StatusId] [int] NOT NULL,
	[SeverityId] [int] NOT NULL,
	[IsClosed] [bit] NOT NULL,
	[AssignedToUserId] [int] NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
	[AssignedByUserId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[KeyName] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_dbo.Ticket] PRIMARY KEY CLUSTERED 
(
	[TicketId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Ticket] ON
INSERT [dbo].[Ticket] ([TicketId], [CategoryId], [Summary], [PriorityId], [Description], [Created], [DueDate], [StatusId], [SeverityId], [IsClosed], [AssignedToUserId], [CreatedByUserId], [AssignedByUserId], [ProjectId], [KeyName]) VALUES (21, 1, N'asd', 1, N'dadadasd', CAST(0x00009D66017B459C AS DateTime), CAST(0x00009D6600000000 AS DateTime), 1, 1, 0, 2, 2, 2, 1, N'IHLT-1')
INSERT [dbo].[Ticket] ([TicketId], [CategoryId], [Summary], [PriorityId], [Description], [Created], [DueDate], [StatusId], [SeverityId], [IsClosed], [AssignedToUserId], [CreatedByUserId], [AssignedByUserId], [ProjectId], [KeyName]) VALUES (22, 1, N'lalalaa', 1, N'lalala', CAST(0x00009D66017B76AF AS DateTime), CAST(0x00009D6600000000 AS DateTime), 1, 1, 0, 2, 2, 2, 1, N'IHLT-2')
INSERT [dbo].[Ticket] ([TicketId], [CategoryId], [Summary], [PriorityId], [Description], [Created], [DueDate], [StatusId], [SeverityId], [IsClosed], [AssignedToUserId], [CreatedByUserId], [AssignedByUserId], [ProjectId], [KeyName]) VALUES (23, 1, N'Shit has hit the fan', 1, N'fix it!', CAST(0x00009D7B00041907 AS DateTime), CAST(0x00009D7B00000000 AS DateTime), 1, 1, 0, 2, 2, 2, 1, N'IHLThh-1')
INSERT [dbo].[Ticket] ([TicketId], [CategoryId], [Summary], [PriorityId], [Description], [Created], [DueDate], [StatusId], [SeverityId], [IsClosed], [AssignedToUserId], [CreatedByUserId], [AssignedByUserId], [ProjectId], [KeyName]) VALUES (25, 1, N'More shit hit the fan', 1, N'adasd', CAST(0x00009D7B00042F6C AS DateTime), CAST(0x00009D7B00000000 AS DateTime), 1, 1, 0, 2, 2, 2, 1, N'IHLThh-2')
INSERT [dbo].[Ticket] ([TicketId], [CategoryId], [Summary], [PriorityId], [Description], [Created], [DueDate], [StatusId], [SeverityId], [IsClosed], [AssignedToUserId], [CreatedByUserId], [AssignedByUserId], [ProjectId], [KeyName]) VALUES (29, 1, N'sadadas', 1, N'', CAST(0x00009D7B000A3CB6 AS DateTime), CAST(0x00009D7B00000000 AS DateTime), 1, 1, 0, 2, 2, 2, 1, N'IHLThh-3')
INSERT [dbo].[Ticket] ([TicketId], [CategoryId], [Summary], [PriorityId], [Description], [Created], [DueDate], [StatusId], [SeverityId], [IsClosed], [AssignedToUserId], [CreatedByUserId], [AssignedByUserId], [ProjectId], [KeyName]) VALUES (31, 1, N'sadadasdada', 1, N'', CAST(0x00009D7B000BC701 AS DateTime), CAST(0x00009D7B00000000 AS DateTime), 1, 1, 0, 2, 2, 2, 1, N'IHLThh-4')
INSERT [dbo].[Ticket] ([TicketId], [CategoryId], [Summary], [PriorityId], [Description], [Created], [DueDate], [StatusId], [SeverityId], [IsClosed], [AssignedToUserId], [CreatedByUserId], [AssignedByUserId], [ProjectId], [KeyName]) VALUES (32, 1, N'asdadas', 1, N'', CAST(0x00009D7B0012BEE0 AS DateTime), CAST(0x00009D7B00000000 AS DateTime), 1, 1, 0, 2, 2, 2, 1, N'IHLThh-5')
INSERT [dbo].[Ticket] ([TicketId], [CategoryId], [Summary], [PriorityId], [Description], [Created], [DueDate], [StatusId], [SeverityId], [IsClosed], [AssignedToUserId], [CreatedByUserId], [AssignedByUserId], [ProjectId], [KeyName]) VALUES (33, 1, N'sadadads', 1, N'', CAST(0x00009D7B00141CDE AS DateTime), CAST(0x00009D7B00000000 AS DateTime), 1, 1, 0, 2, 2, 2, 1, N'IHLThh-6')
SET IDENTITY_INSERT [dbo].[Ticket] OFF
/****** Object:  Table [dbo].[Component]    Script Date: 07/18/2010 22:16:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Component](
	[ComponentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Description] [text] NOT NULL,
	[TicketId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Component] PRIMARY KEY CLUSTERED 
(
	[ComponentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WorkLog]    Script Date: 07/18/2010 22:16:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkLog](
	[WorkLogId] [int] IDENTITY(1,1) NOT NULL,
	[DoneBy] [int] NOT NULL,
	[Description] [text] NOT NULL,
	[Created] [datetime] NOT NULL,
	[TimeSpent] [int] NOT NULL,
	[TicketId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.WorkLog] PRIMARY KEY CLUSTERED 
(
	[WorkLogId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Resolution]    Script Date: 07/18/2010 22:16:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resolution](
	[ResolutionId] [int] IDENTITY(1,1) NOT NULL,
	[ResolvedBy] [int] NOT NULL,
	[Created] [datetime] NOT NULL,
	[Description] [text] NOT NULL,
	[TicketId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Resolution] PRIMARY KEY CLUSTERED 
(
	[ResolutionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComponentTicket]    Script Date: 07/18/2010 22:16:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComponentTicket](
	[ComponentTicketId] [int] IDENTITY(1,1) NOT NULL,
	[ComponentId] [int] NOT NULL,
	[TicketId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ComponentTicket] PRIMARY KEY CLUSTERED 
(
	[ComponentTicketId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 07/18/2010 22:16:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[CommentId] [int] IDENTITY(1,1) NOT NULL,
	[Body] [text] NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modified] [datetime] NOT NULL,
	[TicketId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Comment] PRIMARY KEY CLUSTERED 
(
	[CommentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Default [DF_Project_Created]    Script Date: 07/18/2010 22:16:19 ******/
ALTER TABLE [dbo].[Project] ADD  CONSTRAINT [DF_Project_Created]  DEFAULT (getdate()) FOR [Created]
GO
/****** Object:  Default [DF_Ticket_Description]    Script Date: 07/18/2010 22:16:19 ******/
ALTER TABLE [dbo].[Ticket] ADD  CONSTRAINT [DF_Ticket_Description]  DEFAULT ('') FOR [Description]
GO
/****** Object:  ForeignKey [Role_User]    Script Date: 07/18/2010 22:16:19 ******/
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [Role_User] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [Role_User]
GO
/****** Object:  ForeignKey [User_Project]    Script Date: 07/18/2010 22:16:19 ******/
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [User_Project] FOREIGN KEY([Lead])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [User_Project]
GO
/****** Object:  ForeignKey [Category_Ticket]    Script Date: 07/18/2010 22:16:19 ******/
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [Category_Ticket] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [Category_Ticket]
GO
/****** Object:  ForeignKey [Priority_Ticket]    Script Date: 07/18/2010 22:16:19 ******/
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [Priority_Ticket] FOREIGN KEY([PriorityId])
REFERENCES [dbo].[Priority] ([PriorityId])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [Priority_Ticket]
GO
/****** Object:  ForeignKey [Project_Ticket]    Script Date: 07/18/2010 22:16:19 ******/
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [Project_Ticket] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([ProjectId])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [Project_Ticket]
GO
/****** Object:  ForeignKey [Severity_Ticket]    Script Date: 07/18/2010 22:16:19 ******/
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [Severity_Ticket] FOREIGN KEY([SeverityId])
REFERENCES [dbo].[Severity] ([SeverityId])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [Severity_Ticket]
GO
/****** Object:  ForeignKey [Status_Ticket]    Script Date: 07/18/2010 22:16:19 ******/
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [Status_Ticket] FOREIGN KEY([SeverityId])
REFERENCES [dbo].[Status] ([StatusId])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [Status_Ticket]
GO
/****** Object:  ForeignKey [User_Ticket]    Script Date: 07/18/2010 22:16:19 ******/
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [User_Ticket] FOREIGN KEY([AssignedToUserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [User_Ticket]
GO
/****** Object:  ForeignKey [User_Ticket1]    Script Date: 07/18/2010 22:16:19 ******/
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [User_Ticket1] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [User_Ticket1]
GO
/****** Object:  ForeignKey [User_Ticket2]    Script Date: 07/18/2010 22:16:19 ******/
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [User_Ticket2] FOREIGN KEY([AssignedByUserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [User_Ticket2]
GO
/****** Object:  ForeignKey [Project_Component]    Script Date: 07/18/2010 22:16:19 ******/
ALTER TABLE [dbo].[Component]  WITH CHECK ADD  CONSTRAINT [Project_Component] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([ProjectId])
GO
ALTER TABLE [dbo].[Component] CHECK CONSTRAINT [Project_Component]
GO
/****** Object:  ForeignKey [Ticket_WorkLog]    Script Date: 07/18/2010 22:16:19 ******/
ALTER TABLE [dbo].[WorkLog]  WITH CHECK ADD  CONSTRAINT [Ticket_WorkLog] FOREIGN KEY([TicketId])
REFERENCES [dbo].[Ticket] ([TicketId])
GO
ALTER TABLE [dbo].[WorkLog] CHECK CONSTRAINT [Ticket_WorkLog]
GO
/****** Object:  ForeignKey [Ticket_Resolution]    Script Date: 07/18/2010 22:16:19 ******/
ALTER TABLE [dbo].[Resolution]  WITH CHECK ADD  CONSTRAINT [Ticket_Resolution] FOREIGN KEY([TicketId])
REFERENCES [dbo].[Ticket] ([TicketId])
GO
ALTER TABLE [dbo].[Resolution] CHECK CONSTRAINT [Ticket_Resolution]
GO
/****** Object:  ForeignKey [Component_ComponentTicket]    Script Date: 07/18/2010 22:16:19 ******/
ALTER TABLE [dbo].[ComponentTicket]  WITH CHECK ADD  CONSTRAINT [Component_ComponentTicket] FOREIGN KEY([ComponentId])
REFERENCES [dbo].[Component] ([ComponentId])
GO
ALTER TABLE [dbo].[ComponentTicket] CHECK CONSTRAINT [Component_ComponentTicket]
GO
/****** Object:  ForeignKey [Ticket_ComponentTicket]    Script Date: 07/18/2010 22:16:19 ******/
ALTER TABLE [dbo].[ComponentTicket]  WITH CHECK ADD  CONSTRAINT [Ticket_ComponentTicket] FOREIGN KEY([TicketId])
REFERENCES [dbo].[Ticket] ([TicketId])
GO
ALTER TABLE [dbo].[ComponentTicket] CHECK CONSTRAINT [Ticket_ComponentTicket]
GO
/****** Object:  ForeignKey [Ticket_Comment]    Script Date: 07/18/2010 22:16:19 ******/
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [Ticket_Comment] FOREIGN KEY([TicketId])
REFERENCES [dbo].[Ticket] ([TicketId])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [Ticket_Comment]
GO
/****** Object:  ForeignKey [User_Comment]    Script Date: 07/18/2010 22:16:19 ******/
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [User_Comment] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [User_Comment]
GO
