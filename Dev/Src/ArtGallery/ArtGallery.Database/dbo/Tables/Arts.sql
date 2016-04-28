CREATE TABLE [dbo].[Arts] (
    [Art_ID]         INT            IDENTITY (1, 1) NOT NULL,
    [User_ID]        NVARCHAR (128) NULL,
    [Title]          NVARCHAR (255) NOT NULL,
    [Category_ID]    INT            NOT NULL,
    [Subject]        NTEXT          NULL,
    [Price]          NVARCHAR (50)  NULL,
    [Location_ID]    INT            NULL,
    [Size]           NVARCHAR (50)  NULL,
    [Medium]         NVARCHAR (50)  NULL,
    [Statement]      NTEXT          NULL,
    [Created]        DATETIME       NULL,
    [Modified]       DATETIME       NULL,
    [Status]         NVARCHAR (50)  NOT NULL,
    [Cover_Pic_Path] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Arts] PRIMARY KEY CLUSTERED ([Art_ID] ASC),
    FOREIGN KEY ([User_ID]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_Arts_Categories] FOREIGN KEY ([Category_ID]) REFERENCES [dbo].[Categories] ([CategoryId]),
    CONSTRAINT [FK_Arts_Locations] FOREIGN KEY ([Location_ID]) REFERENCES [dbo].[Locations] ([LocationID])
);

