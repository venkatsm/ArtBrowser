CREATE TABLE [dbo].[Artists] (
    [Artist_ID]   INT            IDENTITY (1, 1) NOT NULL,
    [User_ID]     NVARCHAR (128) NULL,
    [PhoneNumber] NVARCHAR (20)  NULL,
    [Gender]      NVARCHAR (10)  NULL,
    [Profile_Pic] NVARCHAR (MAX) NULL,
    [Cover_Pic]   NVARCHAR (MAX) NULL,
    [Location]    NVARCHAR (500) NULL,
    [Statement]   NVARCHAR (MAX) NULL,
    [Price_Range] NVARCHAR (500) NULL,
    [DOB]         DATETIME       NULL,
    [Expertise]   NVARCHAR (500) NULL,
    [Education]   NVARCHAR (500) NULL,
    [Work]        NVARCHAR (500) NULL,
    [Position]    NVARCHAR (10)  NULL,
    PRIMARY KEY CLUSTERED ([Artist_ID] ASC),
    FOREIGN KEY ([User_ID]) REFERENCES [dbo].[AspNetUsers] ([Id])
);

