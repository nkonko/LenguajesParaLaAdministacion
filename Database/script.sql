USE [Tatooine]
GO
/****** Object:  Table [dbo].[Family]    Script Date: 28/4/2020 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Family](
	[Id] [int] NOT NULL,
	[Description] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patent]    Script Date: 28/4/2020 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patent](
	[Id] [int] NOT NULL,
	[Description] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PatentFamily]    Script Date: 28/4/2020 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatentFamily](
	[Id] [int] NOT NULL,
	[FamilyId] [int] NOT NULL,
	[PatentId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Userdb]    Script Date: 28/4/2020 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Userdb](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserFamily]    Script Date: 28/4/2020 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserFamily](
	[UserId] [int] NOT NULL,
	[FamilyId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserPatent]    Script Date: 28/4/2020 16:14:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPatent](
	[UserId] [int] NOT NULL,
	[PatentId] [int] NOT NULL,
	[Active] [bit] NOT NULL
) ON [PRIMARY]
GO
