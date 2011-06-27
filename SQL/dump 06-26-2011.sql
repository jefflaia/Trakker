USE [Trakker]
GO
/****** Object:  User [Trakker]    Script Date: 06/26/2011 21:49:47 ******/
CREATE USER [Trakker] FOR LOGIN [Trakker] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 06/26/2011 21:49:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Body] [nvarchar](50) NOT NULL,
	[CreationDate] [nvarchar](50) NOT NULL,
	[IsPublic] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostCategory]    Script Date: 06/26/2011 21:49:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostCategory](
	[idPost] [int] NOT NULL,
	[idCategory] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TicketType]    Script Date: 06/26/2011 21:49:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TicketType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](250) NOT NULL,
 CONSTRAINT [PK_dbo.Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_TicketType_UniqueName] ON [dbo].[TicketType] 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TicketType] ON
INSERT [dbo].[TicketType] ([Id], [Name], [Description]) VALUES (1, N'Task', N'adadasd')
INSERT [dbo].[TicketType] ([Id], [Name], [Description]) VALUES (2, N'Bug', N'This ticket represents a bug with the application.')
INSERT [dbo].[TicketType] ([Id], [Name], [Description]) VALUES (3, N'Improvement', N'This ticket represents an improvement that needs to happen with the application.')
INSERT [dbo].[TicketType] ([Id], [Name], [Description]) VALUES (4, N'Code Review', N'saaa')
SET IDENTITY_INSERT [dbo].[TicketType] OFF
/****** Object:  Table [dbo].[TicketStatus]    Script Date: 06/26/2011 21:49:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TicketStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](250) NOT NULL,
	[IsClosedState] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Status] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TicketStatus] ON
INSERT [dbo].[TicketStatus] ([Id], [Name], [Description], [IsClosedState]) VALUES (1, N'Code Review', N'This ticket has been assigned for code review.', 0)
INSERT [dbo].[TicketStatus] ([Id], [Name], [Description], [IsClosedState]) VALUES (2, N'Complete', N'The ticket is complete', 0)
INSERT [dbo].[TicketStatus] ([Id], [Name], [Description], [IsClosedState]) VALUES (4, N'Completed', N'This status is complete', 0)
INSERT [dbo].[TicketStatus] ([Id], [Name], [Description], [IsClosedState]) VALUES (5, N'Closed', N'The ticket is no longer open.', 0)
INSERT [dbo].[TicketStatus] ([Id], [Name], [Description], [IsClosedState]) VALUES (6, N'Open', N'The ticket is openss', 0)
SET IDENTITY_INSERT [dbo].[TicketStatus] OFF
/****** Object:  Table [dbo].[TicketResolution]    Script Date: 06/26/2011 21:49:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TicketResolution](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [text] NOT NULL,
 CONSTRAINT [PK_dbo.Resolution] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_TicketResolution_UniqueName] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TicketResolution] ON
INSERT [dbo].[TicketResolution] ([Id], [Name], [Description]) VALUES (1, N'Fixed', N'The ticket was fixed.')
INSERT [dbo].[TicketResolution] ([Id], [Name], [Description]) VALUES (2, N'Won''t Fix', N'This ticket will not get fixed.')
INSERT [dbo].[TicketResolution] ([Id], [Name], [Description]) VALUES (3, N'Broke it more', N'Oh noes :(')
INSERT [dbo].[TicketResolution] ([Id], [Name], [Description]) VALUES (4, N'Duplicate', N'This ticket is the same as another ticket')
SET IDENTITY_INSERT [dbo].[TicketResolution] OFF
/****** Object:  Table [dbo].[TicketPriority]    Script Date: 06/26/2011 21:49:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TicketPriority](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](250) NOT NULL,
	[HexColor] [char](6) NOT NULL,
 CONSTRAINT [PK_dbo.Priority] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_TicketPriority_UniqueNAme] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[TicketPriority] ON
INSERT [dbo].[TicketPriority] ([Id], [Name], [Description], [HexColor]) VALUES (1, N'Priority 1', N'adlkajdkla ', N'FF43F1')
INSERT [dbo].[TicketPriority] ([Id], [Name], [Description], [HexColor]) VALUES (4, N'High', N'This is high priority', N'hF34H5')
INSERT [dbo].[TicketPriority] ([Id], [Name], [Description], [HexColor]) VALUES (5, N'Very Very Low', N'Just ignore it really.', N'123322')
INSERT [dbo].[TicketPriority] ([Id], [Name], [Description], [HexColor]) VALUES (6, N'Very High', N'Very high description', N'676767')
SET IDENTITY_INSERT [dbo].[TicketPriority] OFF
/****** Object:  Table [dbo].[Ticket]    Script Date: 06/26/2011 21:49:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ticket](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Summary] [nvarchar](150) NOT NULL,
	[PriorityId] [int] NOT NULL,
	[Description] [text] NOT NULL,
	[Created] [datetime] NOT NULL,
	[DueDate] [datetime] NULL,
	[StatusId] [int] NOT NULL,
	[ResolutionId] [int] NOT NULL,
	[IsClosed] [bit] NOT NULL,
	[AssignedToUserId] [int] NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
	[AssignedByUserId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[KeyName] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_dbo.Ticket] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Ticket] ON
INSERT [dbo].[Ticket] ([Id], [CategoryId], [Summary], [PriorityId], [Description], [Created], [DueDate], [StatusId], [ResolutionId], [IsClosed], [AssignedToUserId], [CreatedByUserId], [AssignedByUserId], [ProjectId], [KeyName]) VALUES (21, 1, N'asd asdkja kdja dkaljd akldj akldj akdlaj dkald jakld jakldj akldj akldj aklda dkla jdklajd akldj akldj akldj k', 1, N'Yeah!', CAST(0x00009D66017B459C AS DateTime), CAST(0x00009D6600000000 AS DateTime), 1, 1, 0, 2, 2, 2, 1, N'IHLThh-10')
INSERT [dbo].[Ticket] ([Id], [CategoryId], [Summary], [PriorityId], [Description], [Created], [DueDate], [StatusId], [ResolutionId], [IsClosed], [AssignedToUserId], [CreatedByUserId], [AssignedByUserId], [ProjectId], [KeyName]) VALUES (22, 1, N'lalalaa', 1, N'lalala', CAST(0x00009D66017B76AF AS DateTime), CAST(0x00009D6600000000 AS DateTime), 1, 1, 0, 2, 2, 2, 1, N'IHLT-2')
INSERT [dbo].[Ticket] ([Id], [CategoryId], [Summary], [PriorityId], [Description], [Created], [DueDate], [StatusId], [ResolutionId], [IsClosed], [AssignedToUserId], [CreatedByUserId], [AssignedByUserId], [ProjectId], [KeyName]) VALUES (23, 1, N'Shit has hit the fan', 1, N'fix it!', CAST(0x00009D7B00041907 AS DateTime), CAST(0x00009D7B00000000 AS DateTime), 1, 1, 0, 2, 2, 2, 1, N'IHLThh-1')
INSERT [dbo].[Ticket] ([Id], [CategoryId], [Summary], [PriorityId], [Description], [Created], [DueDate], [StatusId], [ResolutionId], [IsClosed], [AssignedToUserId], [CreatedByUserId], [AssignedByUserId], [ProjectId], [KeyName]) VALUES (25, 1, N'More shit hit the fan', 1, N'adasd', CAST(0x00009D7B00042F6C AS DateTime), CAST(0x00009D7B00000000 AS DateTime), 1, 1, 0, 2, 2, 2, 1, N'IHLThh-2')
INSERT [dbo].[Ticket] ([Id], [CategoryId], [Summary], [PriorityId], [Description], [Created], [DueDate], [StatusId], [ResolutionId], [IsClosed], [AssignedToUserId], [CreatedByUserId], [AssignedByUserId], [ProjectId], [KeyName]) VALUES (29, 1, N'sadadas', 1, N'', CAST(0x00009D7B000A3CB6 AS DateTime), CAST(0x00009D7B00000000 AS DateTime), 1, 1, 0, 2, 2, 2, 1, N'IHLThh-3')
INSERT [dbo].[Ticket] ([Id], [CategoryId], [Summary], [PriorityId], [Description], [Created], [DueDate], [StatusId], [ResolutionId], [IsClosed], [AssignedToUserId], [CreatedByUserId], [AssignedByUserId], [ProjectId], [KeyName]) VALUES (31, 1, N'sadadasdada', 1, N'', CAST(0x00009D7B000BC701 AS DateTime), CAST(0x00009D7B00000000 AS DateTime), 1, 1, 0, 2, 2, 2, 1, N'IHLThh-4')
INSERT [dbo].[Ticket] ([Id], [CategoryId], [Summary], [PriorityId], [Description], [Created], [DueDate], [StatusId], [ResolutionId], [IsClosed], [AssignedToUserId], [CreatedByUserId], [AssignedByUserId], [ProjectId], [KeyName]) VALUES (32, 1, N'asdadas', 1, N'', CAST(0x00009D7B0012BEE0 AS DateTime), CAST(0x00009D7B00000000 AS DateTime), 1, 1, 0, 2, 2, 2, 1, N'IHLThh-5')
INSERT [dbo].[Ticket] ([Id], [CategoryId], [Summary], [PriorityId], [Description], [Created], [DueDate], [StatusId], [ResolutionId], [IsClosed], [AssignedToUserId], [CreatedByUserId], [AssignedByUserId], [ProjectId], [KeyName]) VALUES (33, 1, N'sadadads', 1, N'asdad', CAST(0x00009D7B00141CDE AS DateTime), CAST(0x00009D7B00000000 AS DateTime), 1, 1, 0, 2, 2, 2, 1, N'IHLThh-19')
INSERT [dbo].[Ticket] ([Id], [CategoryId], [Summary], [PriorityId], [Description], [Created], [DueDate], [StatusId], [ResolutionId], [IsClosed], [AssignedToUserId], [CreatedByUserId], [AssignedByUserId], [ProjectId], [KeyName]) VALUES (36, 1, N'Test after styling', 1, N'sad asdajhd adj akdj akd jada da', CAST(0x00009E140001A0B6 AS DateTime), CAST(0x00009E1400000000 AS DateTime), 1, 1, 0, 2, 2, 2, 1, N'IHLThh-7')
INSERT [dbo].[Ticket] ([Id], [CategoryId], [Summary], [PriorityId], [Description], [Created], [DueDate], [StatusId], [ResolutionId], [IsClosed], [AssignedToUserId], [CreatedByUserId], [AssignedByUserId], [ProjectId], [KeyName]) VALUES (37, 1, N'adad', 1, N'', CAST(0x00009E160158E61A AS DateTime), CAST(0x00009CF100000000 AS DateTime), 1, 1, 0, 2, 2, 2, 1, N'IHLThh-8')
INSERT [dbo].[Ticket] ([Id], [CategoryId], [Summary], [PriorityId], [Description], [Created], [DueDate], [StatusId], [ResolutionId], [IsClosed], [AssignedToUserId], [CreatedByUserId], [AssignedByUserId], [ProjectId], [KeyName]) VALUES (38, 1, N'sadasd', 1, N'', CAST(0x00009E16015F991D AS DateTime), NULL, 1, 1, 0, 2, 2, 2, 1, N'IHLThh-9')
INSERT [dbo].[Ticket] ([Id], [CategoryId], [Summary], [PriorityId], [Description], [Created], [DueDate], [StatusId], [ResolutionId], [IsClosed], [AssignedToUserId], [CreatedByUserId], [AssignedByUserId], [ProjectId], [KeyName]) VALUES (39, 1, N'Yay dates work with nulls', 1, N'', CAST(0x00009E16015FA923 AS DateTime), NULL, 1, 1, 0, 2, 2, 2, 1, N'IHLThh-11')
INSERT [dbo].[Ticket] ([Id], [CategoryId], [Summary], [PriorityId], [Description], [Created], [DueDate], [StatusId], [ResolutionId], [IsClosed], [AssignedToUserId], [CreatedByUserId], [AssignedByUserId], [ProjectId], [KeyName]) VALUES (40, 1, N'Ticket test', 1, N'', CAST(0x00009E1800CBD1A1 AS DateTime), CAST(0x00009D2E00000000 AS DateTime), 1, 1, 0, 2, 2, 2, 1, N'IHLThh-12')
INSERT [dbo].[Ticket] ([Id], [CategoryId], [Summary], [PriorityId], [Description], [Created], [DueDate], [StatusId], [ResolutionId], [IsClosed], [AssignedToUserId], [CreatedByUserId], [AssignedByUserId], [ProjectId], [KeyName]) VALUES (41, 1, N'dsadasd', 1, N'', CAST(0x00009E1800FD5749 AS DateTime), NULL, 1, 1, 0, 2, 2, 2, 1, N'IHLThh-13')
INSERT [dbo].[Ticket] ([Id], [CategoryId], [Summary], [PriorityId], [Description], [Created], [DueDate], [StatusId], [ResolutionId], [IsClosed], [AssignedToUserId], [CreatedByUserId], [AssignedByUserId], [ProjectId], [KeyName]) VALUES (42, 1, N'ZOMG ANOTHER TICKET', 1, N'dsadsa', CAST(0x00009E1800FD74F6 AS DateTime), NULL, 1, 1, 0, 2, 2, 2, 1, N'IHLThh-14')
INSERT [dbo].[Ticket] ([Id], [CategoryId], [Summary], [PriorityId], [Description], [Created], [DueDate], [StatusId], [ResolutionId], [IsClosed], [AssignedToUserId], [CreatedByUserId], [AssignedByUserId], [ProjectId], [KeyName]) VALUES (43, 1, N'yeah!', 1, N'asdasd', CAST(0x00009E19018A71C6 AS DateTime), CAST(0x00009E0800000000 AS DateTime), 1, 1, 0, 12, 12, 12, 1, N'IHLThh-15')
INSERT [dbo].[Ticket] ([Id], [CategoryId], [Summary], [PriorityId], [Description], [Created], [DueDate], [StatusId], [ResolutionId], [IsClosed], [AssignedToUserId], [CreatedByUserId], [AssignedByUserId], [ProjectId], [KeyName]) VALUES (44, 1, N'sadadad adsa ', 1, N'asd adas', CAST(0x00009E1A00093430 AS DateTime), NULL, 1, 1, 0, 12, 12, 12, 1, N'IHLThh-16')
INSERT [dbo].[Ticket] ([Id], [CategoryId], [Summary], [PriorityId], [Description], [Created], [DueDate], [StatusId], [ResolutionId], [IsClosed], [AssignedToUserId], [CreatedByUserId], [AssignedByUserId], [ProjectId], [KeyName]) VALUES (45, 1, N'test resolution and assigned to', 1, N'asdasda', CAST(0x00009E1A0009A341 AS DateTime), CAST(0x00009E1600000000 AS DateTime), 1, 1, 0, 12, 12, 12, 1, N'IHLThh-17')
INSERT [dbo].[Ticket] ([Id], [CategoryId], [Summary], [PriorityId], [Description], [Created], [DueDate], [StatusId], [ResolutionId], [IsClosed], [AssignedToUserId], [CreatedByUserId], [AssignedByUserId], [ProjectId], [KeyName]) VALUES (46, 1, N'clean some stuff', 4, N'asdasd', CAST(0x00009E21018359C7 AS DateTime), CAST(0x00009E2900000000 AS DateTime), 1, 1, 0, 2, 12, 12, 9, N'CU-1')
INSERT [dbo].[Ticket] ([Id], [CategoryId], [Summary], [PriorityId], [Description], [Created], [DueDate], [StatusId], [ResolutionId], [IsClosed], [AssignedToUserId], [CreatedByUserId], [AssignedByUserId], [ProjectId], [KeyName]) VALUES (47, 1, N'testing keyname', 1, N'', CAST(0x00009E24018B41C3 AS DateTime), NULL, 1, 1, 0, 2, 12, 12, 1, N'IHLThh-18')
INSERT [dbo].[Ticket] ([Id], [CategoryId], [Summary], [PriorityId], [Description], [Created], [DueDate], [StatusId], [ResolutionId], [IsClosed], [AssignedToUserId], [CreatedByUserId], [AssignedByUserId], [ProjectId], [KeyName]) VALUES (48, 1, N'testing keyname', 1, N'sadad', CAST(0x00009E2500008592 AS DateTime), CAST(0x00009E2100000000 AS DateTime), 1, 1, 0, 2, 12, 12, 1, N'IHLThh-21')
INSERT [dbo].[Ticket] ([Id], [CategoryId], [Summary], [PriorityId], [Description], [Created], [DueDate], [StatusId], [ResolutionId], [IsClosed], [AssignedToUserId], [CreatedByUserId], [AssignedByUserId], [ProjectId], [KeyName]) VALUES (49, 1, N'adasdas', 1, N'asdasdsa', CAST(0x00009E250182F6A9 AS DateTime), NULL, 1, 1, 0, 6, 12, 12, 10, N'ddd-22')
INSERT [dbo].[Ticket] ([Id], [CategoryId], [Summary], [PriorityId], [Description], [Created], [DueDate], [StatusId], [ResolutionId], [IsClosed], [AssignedToUserId], [CreatedByUserId], [AssignedByUserId], [ProjectId], [KeyName]) VALUES (50, 1, N'test', 1, N'', CAST(0x00009E26011D7ED0 AS DateTime), CAST(0x00009E2A00000000 AS DateTime), 1, 1, 0, 2, 12, 12, 1, N'IHLThh-24')
INSERT [dbo].[Ticket] ([Id], [CategoryId], [Summary], [PriorityId], [Description], [Created], [DueDate], [StatusId], [ResolutionId], [IsClosed], [AssignedToUserId], [CreatedByUserId], [AssignedByUserId], [ProjectId], [KeyName]) VALUES (51, 1, N'ANother summary', 1, N'', CAST(0x00009E3A00091A24 AS DateTime), NULL, 1, 1, 0, 2, 13, 13, 1, N'IHLTHH-25')
INSERT [dbo].[Ticket] ([Id], [CategoryId], [Summary], [PriorityId], [Description], [Created], [DueDate], [StatusId], [ResolutionId], [IsClosed], [AssignedToUserId], [CreatedByUserId], [AssignedByUserId], [ProjectId], [KeyName]) VALUES (52, 1, N'asldkjas lkdj akdj ', 1, N'', CAST(0x00009E420029D985 AS DateTime), NULL, 1, 1, 0, 2, 13, 13, 1, N'IHLTHH-26')
INSERT [dbo].[Ticket] ([Id], [CategoryId], [Summary], [PriorityId], [Description], [Created], [DueDate], [StatusId], [ResolutionId], [IsClosed], [AssignedToUserId], [CreatedByUserId], [AssignedByUserId], [ProjectId], [KeyName]) VALUES (53, 1, N'Must hit that', 1, N'then cuddle!!1!1!!1!!!', CAST(0x00009E8C0188EF90 AS DateTime), CAST(0x00009E8C00000000 AS DateTime), 1, 1, 0, 13, 13, 13, 2, N'SR-21')
SET IDENTITY_INSERT [dbo].[Ticket] OFF
/****** Object:  Table [dbo].[Role]    Script Date: 06/26/2011 21:49:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[Description] [text] NOT NULL,
 CONSTRAINT [PK_dbo.Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON
INSERT [dbo].[Role] ([Id], [Name], [Description]) VALUES (2, N'Administrator', N'Admin')
SET IDENTITY_INSERT [dbo].[Role] OFF
/****** Object:  Table [dbo].[Property]    Script Date: 06/26/2011 21:49:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Property](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Identifier] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Value] [nvarchar](100) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Type] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_SystemSetting] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [Property_Unique_Identifier] ON [dbo].[Property] 
(
	[Identifier] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Property] ON
INSERT [dbo].[Property] ([Id], [Identifier], [Name], [Value], [Created], [Type]) VALUES (1, N'ColorPaletteId', N'Color Palette Id', N'5', CAST(0x00009E0B00000000 AS DateTime), N'integer')
SET IDENTITY_INSERT [dbo].[Property] OFF
/****** Object:  Table [dbo].[ColorPalette]    Script Date: 06/26/2011 21:49:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ColorPalette](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NavBackgroundColor] [nvarchar](6) NOT NULL,
	[SubNavBackgroundColor] [nvarchar](6) NOT NULL,
	[HighlightColor] [nvarchar](6) NOT NULL,
	[NavTextColor] [nvarchar](6) NOT NULL,
	[SubNavTextColor] [nvarchar](6) NOT NULL,
	[LinkColor] [nvarchar](6) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ColorPalette] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ColorPalette] ON
INSERT [dbo].[ColorPalette] ([Id], [NavBackgroundColor], [SubNavBackgroundColor], [HighlightColor], [NavTextColor], [SubNavTextColor], [LinkColor], [Name]) VALUES (3, N'23558F', N'86B6EF', N'EFF6FF', N'ffffff', N'ffffff', N'3F4FFF', N'Cuddle')
INSERT [dbo].[ColorPalette] ([Id], [NavBackgroundColor], [SubNavBackgroundColor], [HighlightColor], [NavTextColor], [SubNavTextColor], [LinkColor], [Name]) VALUES (5, N'777', N'222', N'222', N'222', N'222', N'222', N'Rainbow')
INSERT [dbo].[ColorPalette] ([Id], [NavBackgroundColor], [SubNavBackgroundColor], [HighlightColor], [NavTextColor], [SubNavTextColor], [LinkColor], [Name]) VALUES (12, N'123123', N'123123', N'123123', N'123123', N'123123', N'123123', N'Rainbowsss')
INSERT [dbo].[ColorPalette] ([Id], [NavBackgroundColor], [SubNavBackgroundColor], [HighlightColor], [NavTextColor], [SubNavTextColor], [LinkColor], [Name]) VALUES (13, N'7f4f2d', N'123', N'123', N'123', N'123', N'123', N'Asdas A Daaadasd Asdadsda')
INSERT [dbo].[ColorPalette] ([Id], [NavBackgroundColor], [SubNavBackgroundColor], [HighlightColor], [NavTextColor], [SubNavTextColor], [LinkColor], [Name]) VALUES (14, N'123', N'123', N'123', N'123', N'123', N'123', N'Rainbows')
SET IDENTITY_INSERT [dbo].[ColorPalette] OFF
/****** Object:  Table [dbo].[Categories]    Script Date: 06/26/2011 21:49:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (1, N'test')
SET IDENTITY_INSERT [dbo].[Categories] OFF
/****** Object:  Table [dbo].[WorkLog]    Script Date: 06/26/2011 21:49:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DoneBy] [int] NOT NULL,
	[Description] [text] NOT NULL,
	[Created] [datetime] NOT NULL,
	[TimeSpent] [int] NOT NULL,
	[TicketId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.WorkLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 06/26/2011 21:49:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Password] [varchar](200) NOT NULL,
	[Salt] [char](10) NOT NULL,
	[Created] [datetime] NOT NULL,
	[LastLogin] [datetime] NULL,
	[TotalComments] [int] NOT NULL,
	[FailedPasswordAttemptCount] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[LastFailedLoginAttempt] [datetime] NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.[User]]] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON
INSERT [dbo].[User] ([Id], [Email], [Password], [Salt], [Created], [LastLogin], [TotalComments], [FailedPasswordAttemptCount], [RoleId], [LastFailedLoginAttempt], [FirstName], [LastName]) VALUES (2, N'justinsss@gmail.com', N'justin', N'jS-5{6GdxH', CAST(0x00009CF100000000 AS DateTime), CAST(0x00009CF100000000 AS DateTime), 0, 6, 2, CAST(0x00009E1901720A13 AS DateTime), N'Another', N'Lady')
INSERT [dbo].[User] ([Id], [Email], [Password], [Salt], [Created], [LastLogin], [TotalComments], [FailedPasswordAttemptCount], [RoleId], [LastFailedLoginAttempt], [FirstName], [LastName]) VALUES (6, N'12554@gmail.com', N'5X4YGcMgV6Ldms6ccVeT2E+tIIhyoGirrq/L5GYjbOnYg3CZZZlTE6qWg4wgO9Zv9p//oywIwBAXQk/V+2VeCEYrcTRtNj1YUGQ=', N'F+q4m6=XPd', CAST(0x00009DD4017BADE5 AS DateTime), CAST(0x00009DD4017BADE5 AS DateTime), 0, 0, 2, CAST(0x00009DD4017BADE5 AS DateTime), N'Dave', N'Guy')
INSERT [dbo].[User] ([Id], [Email], [Password], [Salt], [Created], [LastLogin], [TotalComments], [FailedPasswordAttemptCount], [RoleId], [LastFailedLoginAttempt], [FirstName], [LastName]) VALUES (7, N'sara@gmail.com', N'Y0YwrnErqNcR8qjoI5IQnMSYrqucFZB4gr6f9xsK5LjgqfPxyjw+plut9ioafGkeLnKaCbyVcd5GkmjgiZQ8mWRGXzhYJjdxYk4=', N'dF_8X&7qbN', CAST(0x00009E19011A44F5 AS DateTime), CAST(0x00009E190172ABC6 AS DateTime), 0, 0, 2, CAST(0x00009E19011A44F5 AS DateTime), N'Sara', N'Girl')
INSERT [dbo].[User] ([Id], [Email], [Password], [Salt], [Created], [LastLogin], [TotalComments], [FailedPasswordAttemptCount], [RoleId], [LastFailedLoginAttempt], [FirstName], [LastName]) VALUES (8, N'bob@bob.ca', N'qv3oRVFYxGtA4LHhudcvmje3lmxpazdt9PWmkk/b3DD9rl3/TJZIerHL56Vjw4tc29VJc/Nhify0Av9MbQmkCDlaZyokYzZCeTc=', N'9Zg*$c6By7', CAST(0x00009E1901431D7E AS DateTime), CAST(0x00009E1901431D7E AS DateTime), 0, 0, 2, CAST(0x00009E1901431D7E AS DateTime), N'Bob ', N'Guy')
INSERT [dbo].[User] ([Id], [Email], [Password], [Salt], [Created], [LastLogin], [TotalComments], [FailedPasswordAttemptCount], [RoleId], [LastFailedLoginAttempt], [FirstName], [LastName]) VALUES (9, N'1111', N'reTLt4iVq0sg1ubXDkjILN0vcRHzTueg8zRevyOzVmQMeQmkpUPpxoCT293n1ILPc1tifYRubMapS9sX+FW09DVwP1JZMmF9IXc=', N'5p?RY2a}!w', CAST(0x00009E19014782D4 AS DateTime), NULL, 0, 0, 2, NULL, N'Harry', N'Guy')
INSERT [dbo].[User] ([Id], [Email], [Password], [Salt], [Created], [LastLogin], [TotalComments], [FailedPasswordAttemptCount], [RoleId], [LastFailedLoginAttempt], [FirstName], [LastName]) VALUES (10, N'ghj@gmail.ca', N'oQpPsJ1loxODsdgIW1lhEjxoPDE4npoPEiZe7BSPYq2JdVg4K4aalKFdd3SqDgMMrmzXm3rKXEmCdLpvqGHx4DdjKlF0RTJ7RyE=', N'7c*QtE2{G!', CAST(0x00009E19014ADC04 AS DateTime), NULL, 0, 0, 2, NULL, N'Naked', N'Girl')
INSERT [dbo].[User] ([Id], [Email], [Password], [Salt], [Created], [LastLogin], [TotalComments], [FailedPasswordAttemptCount], [RoleId], [LastFailedLoginAttempt], [FirstName], [LastName]) VALUES (12, N'justin', N'w3ek2Rw5Jaj7vHr3ywjT4IEIbg8wiY2zMy9VpKmp+hJKPx55dMMG9go2NwcenlpttP7G2WO1fpTi4Cas67ykdDhrJVhRITV6NGk=', N'8k%XQ!5z4i', CAST(0x00009E1901730EAB AS DateTime), CAST(0x00009E3400FA297D AS DateTime), 0, 7, 2, CAST(0x00009E330186600E AS DateTime), N'Buzz', N'Killington')
INSERT [dbo].[User] ([Id], [Email], [Password], [Salt], [Created], [LastLogin], [TotalComments], [FailedPasswordAttemptCount], [RoleId], [LastFailedLoginAttempt], [FirstName], [LastName]) VALUES (13, N'justin.arvay@gmail.com', N'uO3Rgc3JAoHOcyDfAvVn2mgp9h9VMwvXGUOuHZ0FIfS7fjH6w3rssxzFeGKGKHfRg6E7OrVAfUWB8QKywsf2K3IqNUY3RV9reCU=', N'r*5F7E_kx%', CAST(0x00009E29014D80F4 AS DateTime), CAST(0x00009F0701366C5C AS DateTime), 0, 23, 2, CAST(0x00009F07013667AC AS DateTime), N'Justin', N'Arvay')
INSERT [dbo].[User] ([Id], [Email], [Password], [Salt], [Created], [LastLogin], [TotalComments], [FailedPasswordAttemptCount], [RoleId], [LastFailedLoginAttempt], [FirstName], [LastName]) VALUES (14, N'some.guy@gmail.com', N'p/M1qrfBsVxKdIsEZlEYlHAeNOShvdXbqCpohqMhLOxKiKr6K4MqH37aY0H7Xcfca2SHdqsz1jLs4rll4OFLVksqcDZrRDQmL20=', N'K*p6kD4&/m', CAST(0x00009E3300096431 AS DateTime), CAST(0x00009E3501153744 AS DateTime), 0, 0, 2, NULL, N'Some', N'Guy')
INSERT [dbo].[User] ([Id], [Email], [Password], [Salt], [Created], [LastLogin], [TotalComments], [FailedPasswordAttemptCount], [RoleId], [LastFailedLoginAttempt], [FirstName], [LastName]) VALUES (15, N'some.guy2@gmail.com', N'12345678', N'e*6P-4Qca{', CAST(0x00009E33000AA39B AS DateTime), NULL, 0, 0, 2, NULL, N'some', N'guy2')
INSERT [dbo].[User] ([Id], [Email], [Password], [Salt], [Created], [LastLogin], [TotalComments], [FailedPasswordAttemptCount], [RoleId], [LastFailedLoginAttempt], [FirstName], [LastName]) VALUES (17, N'sara.romano@gmail.com', N'uqyK8m7xx5Zi6HitvXLESTmFzYt0x15mgQuuzYInoVhrhHmoBea8lZMaOvlu2JobdklO1EopJKvg6vyCArc7nThUbV9mJEc1JTM=', N'8Tm_f$G5%3', CAST(0x00009E350121CF80 AS DateTime), NULL, 0, 0, 2, NULL, N'Sara', N'Romano')
SET IDENTITY_INSERT [dbo].[User] OFF
/****** Object:  Table [dbo].[Comment]    Script Date: 06/26/2011 21:49:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Body] [text] NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modified] [datetime] NOT NULL,
	[TicketId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Comment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Comment] ON
INSERT [dbo].[Comment] ([Id], [Body], [Created], [Modified], [TicketId], [UserId]) VALUES (2, N'asda dadada', CAST(0x00009E9600000000 AS DateTime), CAST(0x00009E9600000000 AS DateTime), 21, 13)
INSERT [dbo].[Comment] ([Id], [Body], [Created], [Modified], [TicketId], [UserId]) VALUES (3, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. In non dolor est, in ultricies urna. Sed condimentum quam nec sem iaculis quis elementum lacus vestibulum. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Aenean pretium, ante non fringilla consectetur, sapien turpis consequat arcu, eleifend pretium lectus arcu ac lectus. Aliquam erat mi, convallis vel tristique sed, congue a purus. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Suspendisse in neque et enim tempor pretium nec ac leo. Suspendisse semper adipiscing aliquam. Sed venenatis vestibulum libero, quis cursus arcu cursus quis. In hac habitasse platea dictumst. Aliquam nec urna dui, at congue risus. Fusce iaculis tempus diam sit amet gravida. Maecenas hendrerit porta arcu quis interdum. Donec consequat, justo in placerat lobortis, libero metus tempor urna, eget porta eros mi in turpis. Vivamus varius est laoreet magna fringilla ac sagittis libero sodales.

Fusce urna mauris, laoreet sit amet condimentum nec, vulputate vel dolor. Sed vitae purus in lorem sagittis venenatis. Fusce condimentum enim at sem semper dignissim. Etiam eleifend dignissim quam, et luctus mauris feugiat quis. Cras vel mauris sit amet est eleifend varius. Praesent orci est, ultrices in posuere sed, imperdiet sit amet elit. Aliquam vel sapien magna, molestie ultricies eros. Suspendisse ullamcorper, leo vitae varius auctor, libero lacus lacinia nunc, eget vestibulum elit odio id eros. Curabitur neque nisi, vulputate et scelerisque eu, malesuada vel leo. Sed quis mi nec felis semper sollicitudin at a augue. Sed non sapien id massa vehicula volutpat. Aliquam erat volutpat. Suspendisse vel massa eu sapien tincidunt malesuada non in tellus.

Sed hendrerit bibendum sem et interdum. Suspendisse porta interdum ante, in ornare orci dictum et. Quisque vestibulum laoreet leo eu laoreet. Nullam dolor lacus, feugiat in malesuada non, iaculis ultricies augue. Integer consequat purus id eros convallis vulputate suscipit tellus dapibus. Praesent vel tincidunt libero. Phasellus molestie mattis cursus. Sed vel dignissim enim. Proin elementum tempus tincidunt. In leo libero, tristique fermentum tempor et, tincidunt tristique magna. Aliquam malesuada eros vel lacus commodo gravida. Donec porta metus a ligula condimentum et pharetra arcu tempus. In euismod risus a elit pulvinar interdum. Quisque aliquam metus in risus fermentum dignissim. Phasellus nibh diam, euismod non facilisis ut, facilisis quis nisl. ', CAST(0x00009E9D00000000 AS DateTime), CAST(0x00009E9D00000000 AS DateTime), 21, 13)
INSERT [dbo].[Comment] ([Id], [Body], [Created], [Modified], [TicketId], [UserId]) VALUES (4, N'asdasd asdsad ', CAST(0x00009EA700027874 AS DateTime), CAST(0x00009EA700027874 AS DateTime), 22, 13)
INSERT [dbo].[Comment] ([Id], [Body], [Created], [Modified], [TicketId], [UserId]) VALUES (5, N'sadasd ad adas dad s', CAST(0x00009EA70003D804 AS DateTime), CAST(0x00009EA70003D804 AS DateTime), 21, 13)
INSERT [dbo].[Comment] ([Id], [Body], [Created], [Modified], [TicketId], [UserId]) VALUES (6, N'asda da  das', CAST(0x00009EA70005308B AS DateTime), CAST(0x00009EA70005308B AS DateTime), 22, 13)
INSERT [dbo].[Comment] ([Id], [Body], [Created], [Modified], [TicketId], [UserId]) VALUES (7, N'asda dads asdas', CAST(0x00009EA700061947 AS DateTime), CAST(0x00009EA700061947 AS DateTime), 21, 13)
INSERT [dbo].[Comment] ([Id], [Body], [Created], [Modified], [TicketId], [UserId]) VALUES (8, N'sdjakd akdj akdj akdj ad ad asdadads', CAST(0x00009EA70006AEB2 AS DateTime), CAST(0x00009EA70006AEB2 AS DateTime), 21, 13)
SET IDENTITY_INSERT [dbo].[Comment] OFF
/****** Object:  Table [dbo].[Project]    Script Date: 06/26/2011 21:49:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Project](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Lead] [int] NOT NULL,
	[KeyName] [varchar](20) NOT NULL,
	[Due] [datetime] NULL,
	[Created] [datetime] NOT NULL,
	[TicketIndex] [int] NOT NULL,
	[Url] [varchar](200) NOT NULL,
	[ColorPaletteId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Project] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
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
INSERT [dbo].[Project] ([Id], [Name], [Lead], [KeyName], [Due], [Created], [TicketIndex], [Url], [ColorPaletteId]) VALUES (1, N'I has lots of ticketss', 2, N'IHLTHH', CAST(0x00009CF100000000 AS DateTime), CAST(0x00009D7201836AF0 AS DateTime), 26, N'http://www.google.ca', 3)
INSERT [dbo].[Project] ([Id], [Name], [Lead], [KeyName], [Due], [Created], [TicketIndex], [Url], [ColorPaletteId]) VALUES (2, N'Sara Romano', 2, N'SR', CAST(0x00009D7200000000 AS DateTime), CAST(0x00009D72000D8DAF AS DateTime), 21, N'www.google.ca', 3)
INSERT [dbo].[Project] ([Id], [Name], [Lead], [KeyName], [Due], [Created], [TicketIndex], [Url], [ColorPaletteId]) VALUES (9, N'Clean Up', 2, N'CU', CAST(0x00009D7200000000 AS DateTime), CAST(0x00009D7200114129 AS DateTime), 20, N'zasd', 3)
INSERT [dbo].[Project] ([Id], [Name], [Lead], [KeyName], [Due], [Created], [TicketIndex], [Url], [ColorPaletteId]) VALUES (10, N'I really like it', 9, N'DDD', CAST(0x00009E0B00000000 AS DateTime), CAST(0x00009E0B00000000 AS DateTime), 22, N'asdasdad', 3)
INSERT [dbo].[Project] ([Id], [Name], [Lead], [KeyName], [Due], [Created], [TicketIndex], [Url], [ColorPaletteId]) VALUES (12, N'Molly Project', 7, N'MP', CAST(0x00009E2100000000 AS DateTime), CAST(0x00009E290008A24C AS DateTime), 0, N'lmgtfy.com/molly', 3)
INSERT [dbo].[Project] ([Id], [Name], [Lead], [KeyName], [Due], [Created], [TicketIndex], [Url], [ColorPaletteId]) VALUES (14, N'Another crappy project', 8, N'ACP', CAST(0x00009E3200000000 AS DateTime), CAST(0x00009E33000AD5D4 AS DateTime), 0, N'www.google.ca', 13)
INSERT [dbo].[Project] ([Id], [Name], [Lead], [KeyName], [Due], [Created], [TicketIndex], [Url], [ColorPaletteId]) VALUES (15, N'Test color palettes', 2, N'TCP', CAST(0x00009FB700000000 AS DateTime), CAST(0x00009F060167A588 AS DateTime), 0, N'www.google.ca', 12)
SET IDENTITY_INSERT [dbo].[Project] OFF
/****** Object:  Table [dbo].[Component]    Script Date: 06/26/2011 21:49:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Component](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Description] [text] NOT NULL,
	[TicketId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Component] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ComponentTicket]    Script Date: 06/26/2011 21:49:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComponentTicket](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ComponentId] [int] NOT NULL,
	[TicketId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ComponentTicket] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_Status_IsClosedState]    Script Date: 06/26/2011 21:49:49 ******/
ALTER TABLE [dbo].[TicketStatus] ADD  CONSTRAINT [DF_Status_IsClosedState]  DEFAULT ((0)) FOR [IsClosedState]
GO
/****** Object:  Default [DF_Ticket_Description]    Script Date: 06/26/2011 21:49:49 ******/
ALTER TABLE [dbo].[Ticket] ADD  CONSTRAINT [DF_Ticket_Description]  DEFAULT ('') FOR [Description]
GO
/****** Object:  Default [DF_Ticket_ResolutionId]    Script Date: 06/26/2011 21:49:49 ******/
ALTER TABLE [dbo].[Ticket] ADD  CONSTRAINT [DF_Ticket_ResolutionId]  DEFAULT ((0)) FOR [ResolutionId]
GO
/****** Object:  Default [DF_User_FirstName]    Script Date: 06/26/2011 21:49:49 ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_FirstName]  DEFAULT ('') FOR [FirstName]
GO
/****** Object:  Default [DF_User_LastName]    Script Date: 06/26/2011 21:49:49 ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_LastName]  DEFAULT ('') FOR [LastName]
GO
/****** Object:  Default [DF_Project_Created]    Script Date: 06/26/2011 21:49:49 ******/
ALTER TABLE [dbo].[Project] ADD  CONSTRAINT [DF_Project_Created]  DEFAULT (getdate()) FOR [Created]
GO
/****** Object:  Default [DF_Project_TicketIndex]    Script Date: 06/26/2011 21:49:49 ******/
ALTER TABLE [dbo].[Project] ADD  CONSTRAINT [DF_Project_TicketIndex]  DEFAULT ((0)) FOR [TicketIndex]
GO
/****** Object:  ForeignKey [Ticket_WorkLog]    Script Date: 06/26/2011 21:49:49 ******/
ALTER TABLE [dbo].[WorkLog]  WITH CHECK ADD  CONSTRAINT [Ticket_WorkLog] FOREIGN KEY([TicketId])
REFERENCES [dbo].[Ticket] ([Id])
GO
ALTER TABLE [dbo].[WorkLog] CHECK CONSTRAINT [Ticket_WorkLog]
GO
/****** Object:  ForeignKey [FK_User_Role]    Script Date: 06/26/2011 21:49:49 ******/
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
/****** Object:  ForeignKey [Ticket_Comment]    Script Date: 06/26/2011 21:49:49 ******/
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [Ticket_Comment] FOREIGN KEY([TicketId])
REFERENCES [dbo].[Ticket] ([Id])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [Ticket_Comment]
GO
/****** Object:  ForeignKey [User_Comment]    Script Date: 06/26/2011 21:49:49 ******/
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [User_Comment] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [User_Comment]
GO
/****** Object:  ForeignKey [FK_Project_ColorPalette]    Script Date: 06/26/2011 21:49:49 ******/
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_ColorPalette] FOREIGN KEY([ColorPaletteId])
REFERENCES [dbo].[ColorPalette] ([Id])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_ColorPalette]
GO
/****** Object:  ForeignKey [User_Project]    Script Date: 06/26/2011 21:49:49 ******/
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [User_Project] FOREIGN KEY([Lead])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [User_Project]
GO
/****** Object:  ForeignKey [Project_Component]    Script Date: 06/26/2011 21:49:49 ******/
ALTER TABLE [dbo].[Component]  WITH CHECK ADD  CONSTRAINT [Project_Component] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[Component] CHECK CONSTRAINT [Project_Component]
GO
/****** Object:  ForeignKey [Component_ComponentTicket]    Script Date: 06/26/2011 21:49:49 ******/
ALTER TABLE [dbo].[ComponentTicket]  WITH CHECK ADD  CONSTRAINT [Component_ComponentTicket] FOREIGN KEY([ComponentId])
REFERENCES [dbo].[Component] ([Id])
GO
ALTER TABLE [dbo].[ComponentTicket] CHECK CONSTRAINT [Component_ComponentTicket]
GO
/****** Object:  ForeignKey [Ticket_ComponentTicket]    Script Date: 06/26/2011 21:49:49 ******/
ALTER TABLE [dbo].[ComponentTicket]  WITH CHECK ADD  CONSTRAINT [Ticket_ComponentTicket] FOREIGN KEY([TicketId])
REFERENCES [dbo].[Ticket] ([Id])
GO
ALTER TABLE [dbo].[ComponentTicket] CHECK CONSTRAINT [Ticket_ComponentTicket]
GO
