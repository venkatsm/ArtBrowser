CREATE TABLE [dbo].[Subscribers] (
    [SubscriberId] INT            IDENTITY (1, 1) NOT NULL,
    [IsActive]     BIT            NOT NULL,
    [Created]      DATETIME       NULL,
    [Modified]     DATETIME       NULL,
    [Email]        NVARCHAR (255) NULL,
    CONSTRAINT [PK_Subscriber] PRIMARY KEY CLUSTERED ([SubscriberId] ASC)
);

