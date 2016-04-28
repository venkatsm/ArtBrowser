CREATE TABLE [dbo].[Locations] (
    [LocationID] INT           IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (50) NOT NULL,
    [Created]    DATETIME      CONSTRAINT [DF_Locations_Created] DEFAULT (getdate()) NOT NULL,
    [Modified]   DATETIME      CONSTRAINT [DF_Locations_Modified] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED ([LocationID] ASC)
);

