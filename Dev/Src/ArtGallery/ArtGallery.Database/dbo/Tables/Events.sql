CREATE TABLE [dbo].[Events] (
    [EventId]           INT            IDENTITY (1, 1) NOT NULL,
    [Title]             NVARCHAR (255) NULL,
    [Location]          NVARCHAR (255) NULL,
    [Address]           NTEXT          NULL,
    [Statement]         NTEXT          NULL,
    [StartDate]         DATETIME       NULL,
    [EndDate]           DATETIME       NULL,
    [Created]           DATETIME       NULL,
    [Modified]          DATETIME       NULL,
    [ImagePath]         NVARCHAR (255) NULL,
    [DisplayInHomePage] BIT            DEFAULT ((0)) NULL,
    [IsExternal]        BIT            DEFAULT ((0)) NULL,
    [ExternalLink]      NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED ([EventId] ASC)
);

