CREATE TABLE [dbo].[Images] (
    [Image_ID] INT   IDENTITY (1, 1) NOT NULL,
    [Art_ID]   INT   NOT NULL,
    [Path]     NTEXT NOT NULL,
    CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED ([Image_ID] ASC),
    CONSTRAINT [FK_Images_Arts] FOREIGN KEY ([Art_ID]) REFERENCES [dbo].[Arts] ([Art_ID])
);

