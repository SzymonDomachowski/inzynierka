﻿CREATE TABLE [dbo].[Users] (
    [UserID]      INT            IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (MAX) NULL,
	[FacebookToken] NVARCHAR (MAX) NULL,
	[InstagramToken] NVARCHAR (MAX) NULL
    CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED ([UserID] ASC)
);