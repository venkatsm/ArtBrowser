CREATE TABLE [dbo].[Configurations] (
    [ConfigurationId] INT            IDENTITY (1, 1) NOT NULL,
    [Key]             NVARCHAR (50)  NULL,
    [Value]           NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([ConfigurationId] ASC)
);

