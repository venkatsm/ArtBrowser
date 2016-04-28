CREATE TABLE [dbo].[Exhibitions] (
    [ExhibitionId] INT            IDENTITY (1, 1) NOT NULL,
    [UserId]       NVARCHAR (128) NOT NULL,
    [Title]        NVARCHAR (255) NULL,
    [Location]     NVARCHAR (255) NULL,
    [Address]      NTEXT          NULL,
    [Statement]    NTEXT          NULL,
    [StartDate]    DATETIME       NULL,
    [EndDate]      DATETIME       NULL,
    [Created]      DATETIME       NULL,
    [Modified]     DATETIME       NULL,
    [ImagePath]    NVARCHAR (255) NULL,
    CONSTRAINT [PK_Exhibitions] PRIMARY KEY CLUSTERED ([ExhibitionId] ASC),
    CONSTRAINT [FK_Exhibitions_AspNetUsers] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);

