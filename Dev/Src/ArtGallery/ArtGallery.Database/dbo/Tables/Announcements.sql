CREATE TABLE [dbo].[Announcements] (
    [Announcement_ID] INT            IDENTITY (1, 1) NOT NULL,
    [User_ID]         NVARCHAR (128) NULL,
    [Title]           NVARCHAR (500) NULL,
    [Description]     NVARCHAR (MAX) NULL,
    [Status]          NVARCHAR (200) DEFAULT ('draft') NULL,
    [Published]       DATETIME       NULL,
    [Created]         DATETIME       CONSTRAINT [DF_Announcement_Created] DEFAULT (getdate()) NOT NULL,
    [Modified]        DATETIME       CONSTRAINT [DF_Announcement_Modified] DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Announcement_ID] ASC),
    FOREIGN KEY ([User_ID]) REFERENCES [dbo].[AspNetUsers] ([Id])
);

