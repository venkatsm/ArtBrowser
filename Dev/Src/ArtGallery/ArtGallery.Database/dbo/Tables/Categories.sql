CREATE TABLE [dbo].[Categories] (
    [CategoryId]        INT            IDENTITY (1, 1) NOT NULL,
    [Name]              NVARCHAR (50)  NOT NULL,
    [Created]           DATETIME       CONSTRAINT [DF_Categories_Created] DEFAULT (getdate()) NOT NULL,
    [Modified]          DATETIME       CONSTRAINT [DF_Categories_Modified] DEFAULT (getdate()) NOT NULL,
    [ImagePath]         NVARCHAR (MAX) NULL,
    [DisplayInHomePage] BIT            DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([CategoryId] ASC)
);

