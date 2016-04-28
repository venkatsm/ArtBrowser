CREATE TABLE [dbo].[FeaturedPartners] (
    [FeaturedPartnerId] INT            IDENTITY (1, 1) NOT NULL,
    [Created]           DATETIME       NULL,
    [Modified]          DATETIME       NULL,
    [DisplayInHomePage] BIT            NULL,
    [PartnerId]         NVARCHAR (128) NULL,
    [IsExternal]        BIT            DEFAULT ((0)) NULL,
    [Name]              NVARCHAR (255) NULL,
    [Image]             NTEXT          NULL,
    [ExternalLink]      NTEXT          NULL,
    CONSTRAINT [PK_FeaturedPartners] PRIMARY KEY CLUSTERED ([FeaturedPartnerId] ASC),
    CONSTRAINT [FK_FeaturedPartners_ToAspNetUsers] FOREIGN KEY ([PartnerId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);

