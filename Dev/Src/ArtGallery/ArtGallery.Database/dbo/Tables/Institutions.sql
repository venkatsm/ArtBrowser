CREATE TABLE [dbo].[Institutions] (
    [Institution_ID]  INT            IDENTITY (1, 1) NOT NULL,
    [User_ID]         NVARCHAR (128) NULL,
    [PhoneNumber]     NVARCHAR (20)  NULL,
    [Aboutus]         NVARCHAR (MAX) NULL,
    [InstitutionType] NVARCHAR (500) NULL,
    [Profile_Pic]     NVARCHAR (MAX) NULL,
    [Cover_Pic]       NVARCHAR (MAX) NULL,
    [Location]        NVARCHAR (500) NULL,
    [Price_Range]     NVARCHAR (500) NULL,
    [Exhibition]      NVARCHAR (500) NULL,
    [ContactUs]       NVARCHAR (500) NULL,
    [Position]        NVARCHAR (10)  NULL,
    [OpeningTimes]    NVARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([Institution_ID] ASC),
    FOREIGN KEY ([User_ID]) REFERENCES [dbo].[AspNetUsers] ([Id])
);

