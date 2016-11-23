USE [Blogging]
GO

/****** Object: Table [dbo].[Blog] Script Date: 11/23/2016 9:03:11 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Blog];


GO
CREATE TABLE [dbo].[Blog] (
    [BlogId] INT            IDENTITY (1, 1) NOT NULL,
    [Url]    NVARCHAR (MAX) NOT NULL
);




USE [Blogging]
GO

/****** Object: Table [dbo].[Post] Script Date: 11/23/2016 9:02:52 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Post];


GO
CREATE TABLE [dbo].[Post] (
    [PostId]  INT            IDENTITY (1, 1) NOT NULL,
    [BlogId]  INT            NOT NULL,
    [Content] NVARCHAR (MAX) NULL,
    [Title]   NVARCHAR (MAX) NULL
);


