CREATE TABLE [dbo].[Users] (
    [UserID]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (20)  NULL,
    [FacebookToken]  NVARCHAR (MAX) NULL,
    [InstagramToken] NVARCHAR (MAX) NULL,
    [Password]       NVARCHAR (MAX) NULL,
    [Login]          NVARCHAR (20)  NULL,
    CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED ([UserID] ASC)
);

