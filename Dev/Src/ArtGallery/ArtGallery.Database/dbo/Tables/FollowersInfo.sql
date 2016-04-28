CREATE TABLE [dbo].[FollowersInfo] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Follower]   NVARCHAR (128) NOT NULL,
    [Following]  NVARCHAR (128) NULL,
    [Subscribed] DATETIME       CONSTRAINT [DF_FollowersInfo_Subscribed] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_FollowersInfo] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Follower_AspNetUsers] FOREIGN KEY ([Follower]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_Following_AspNetUsers] FOREIGN KEY ([Following]) REFERENCES [dbo].[AspNetUsers] ([Id])
);

