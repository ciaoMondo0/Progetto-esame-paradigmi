CREATE TABLE [dbo].[DistributionList](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[OwnerId] [int] NOT NULL,
	[RecipientsEmails] [nvarchar](max) NULL,
 CONSTRAINT [PK_DistributionList] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recipients]    Script Date: 21/03/2024 15:01:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recipients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](100) NULL,
 CONSTRAINT [PK_Recipients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecipientsList]    Script Date: 21/03/2024 15:01:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecipientsList](
	[RecipientId] [int] NOT NULL,
	[DistributionListId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utenti]    Script Date: 21/03/2024 15:01:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utenti](
	[Email] [varchar](100) NULL,
	[Password] [varchar](100) NULL,
	[Name] [varchar](100) NULL,
	[Surname] [varchar](100) NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Utenti] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DistributionList]  WITH CHECK ADD  CONSTRAINT [FK_DistributionList_Utenti] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[Utenti] ([Id])
GO
ALTER TABLE [dbo].[DistributionList] CHECK CONSTRAINT [FK_DistributionList_Utenti]
GO
ALTER TABLE [dbo].[RecipientsList]  WITH CHECK ADD  CONSTRAINT [FK_RecipientsList_DistributionList] FOREIGN KEY([DistributionListId])
REFERENCES [dbo].[DistributionList] ([Id])
GO
ALTER TABLE [dbo].[RecipientsList] CHECK CONSTRAINT [FK_RecipientsList_DistributionList]
GO
ALTER TABLE [dbo].[RecipientsList]  WITH CHECK ADD  CONSTRAINT [FK_RecipientsList_Recipients] FOREIGN KEY([RecipientId])
REFERENCES [dbo].[Recipients] ([Id])
GO
ALTER TABLE [dbo].[RecipientsList] CHECK CONSTRAINT [FK_RecipientsList_Recipients]
GO
USE [master]
GO
ALTER DATABASE [Paradigmi] SET  READ_WRITE 
GO

