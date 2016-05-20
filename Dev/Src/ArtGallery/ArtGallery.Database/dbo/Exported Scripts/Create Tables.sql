
GO
/****** Object:  Table [dbo].[Announcements]    Script Date: 5/8/2016 5:15:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Announcements](
[Announcement_ID] [int] IDENTITY(1,1) NOT NULL,
[User_ID] [nvarchar](128) NULL,
[Title] [nvarchar](500) NULL,
[Description] [nvarchar](max) NULL,
[Status] [nvarchar](200) NULL DEFAULT ('draft'),
[Published] [datetime] NULL,
[Created] [datetime] NOT NULL CONSTRAINT [DF_Announcement_Created]  DEFAULT (getdate()),
[Modified] [datetime] NOT NULL CONSTRAINT [DF_Announcement_Modified]  DEFAULT (getdate()),
PRIMARY KEY CLUSTERED
(
[Announcement_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Artists]    Script Date: 5/8/2016 5:15:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artists](
[Artist_ID] [int] IDENTITY(1,1) NOT NULL,
[User_ID] [nvarchar](128) NULL,
[PhoneNumber] [nvarchar](20) NULL,
[Gender] [nvarchar](10) NULL,
[Profile_Pic] [nvarchar](max) NULL,
[Cover_Pic] [nvarchar](max) NULL,
[Location] [nvarchar](500) NULL,
[Statement] [nvarchar](max) NULL,
[Price_Range] [nvarchar](500) NULL,
[DOB] [datetime] NULL,
[Expertise] [nvarchar](500) NULL,
[Education] [nvarchar](500) NULL,
[Work] [nvarchar](500) NULL,
[Position] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED
(
[Artist_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Arts]    Script Date: 5/8/2016 5:15:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Arts](
[Art_ID] [int] IDENTITY(1,1) NOT NULL,
[User_ID] [nvarchar](128) NULL,
[Title] [nvarchar](255) NOT NULL,
[Category_ID] [int] NOT NULL,
[Subject] [ntext] NULL,
[Price] [nvarchar](50) NULL,
[Location_ID] [int] NULL,
[Size] [nvarchar](50) NULL,
[Medium] [nvarchar](50) NULL,
[Statement] [ntext] NULL,
[Created] [datetime] NULL,
[Modified] [datetime] NULL,
[Status] [nvarchar](50) NOT NULL,
[Cover_Pic_Path] [nvarchar](max) NULL,
CONSTRAINT [PK_Arts] PRIMARY KEY CLUSTERED
(
[Art_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 5/8/2016 5:15:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
[Id] [nvarchar](128) NOT NULL,
[Name] [nvarchar](256) NOT NULL,
CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 5/8/2016 5:15:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
[Id] [int] IDENTITY(1,1) NOT NULL,
[UserId] [nvarchar](128) NOT NULL,
[ClaimType] [nvarchar](max) NULL,
[ClaimValue] [nvarchar](max) NULL,
CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 5/8/2016 5:15:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
[LoginProvider] [nvarchar](128) NOT NULL,
[ProviderKey] [nvarchar](128) NOT NULL,
[UserId] [nvarchar](128) NOT NULL,
CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED
(
[LoginProvider] ASC,
[ProviderKey] ASC,
[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 5/8/2016 5:15:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
[UserId] [nvarchar](128) NOT NULL,
[RoleId] [nvarchar](128) NOT NULL,
CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED
(
[UserId] ASC,
[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 5/8/2016 5:15:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
[Id] [nvarchar](128) NOT NULL,
[Hometown] [nvarchar](max) NULL,
[Email] [nvarchar](256) NULL,
[EmailConfirmed] [bit] NOT NULL,
[PasswordHash] [nvarchar](max) NULL,
[SecurityStamp] [nvarchar](max) NULL,
[PhoneNumber] [nvarchar](max) NULL,
[PhoneNumberConfirmed] [bit] NOT NULL,
[TwoFactorEnabled] [bit] NOT NULL,
[LockoutEndDateUtc] [datetime] NULL,
[LockoutEnabled] [bit] NOT NULL,
[AccessFailedCount] [int] NOT NULL,
[UserName] [nvarchar](256) NOT NULL,
[Name] [nvarchar](50) NULL,
[ApprovalStatus] [nvarchar](50) NULL DEFAULT ('Pending'),
CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categories]    Script Date: 5/8/2016 5:15:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
[CategoryId] [int] IDENTITY(1,1) NOT NULL,
[Name] [nvarchar](50) NOT NULL,
[Created] [datetime] NOT NULL CONSTRAINT [DF_Categories_Created]  DEFAULT (getdate()),
[Modified] [datetime] NOT NULL CONSTRAINT [DF_Categories_Modified]  DEFAULT (getdate()),
[ImagePath] [nvarchar](max) NULL,
[DisplayInHomePage] [bit] NOT NULL DEFAULT ((0)),
CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED
(
[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Configurations]    Script Date: 5/8/2016 5:15:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Configurations](
[ConfigurationId] [int] IDENTITY(1,1) NOT NULL,
[Key] [nvarchar](50) NULL,
[Value] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED
(
[ConfigurationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Events]    Script Date: 5/8/2016 5:15:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
[EventId] [int] IDENTITY(1,1) NOT NULL,
[Title] [nvarchar](255) NULL,
[Location] [nvarchar](255) NULL,
[Address] [ntext] NULL,
[Statement] [ntext] NULL,
[StartDate] [datetime] NULL,
[EndDate] [datetime] NULL,
[Created] [datetime] NULL,
[Modified] [datetime] NULL,
[ImagePath] [nvarchar](255) NULL,
[DisplayInHomePage] [bit] NULL DEFAULT ((0)),
[IsExternal] [bit] NULL DEFAULT ((0)),
[ExternalLink] [nvarchar](max) NULL,
CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED
(
[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Exhibitions]    Script Date: 5/8/2016 5:15:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exhibitions](
[ExhibitionId] [int] IDENTITY(1,1) NOT NULL,
[UserId] [nvarchar](128) NOT NULL,
[Title] [nvarchar](255) NULL,
[Location] [nvarchar](255) NULL,
[Address] [ntext] NULL,
[Statement] [ntext] NULL,
[StartDate] [datetime] NULL,
[EndDate] [datetime] NULL,
[Created] [datetime] NULL,
[Modified] [datetime] NULL,
[ImagePath] [nvarchar](255) NULL,
CONSTRAINT [PK_Exhibitions] PRIMARY KEY CLUSTERED
(
[ExhibitionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FeaturedPartners]    Script Date: 5/8/2016 5:15:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeaturedPartners](
[FeaturedPartnerId] [int] IDENTITY(1,1) NOT NULL,
[Created] [datetime] NULL,
[Modified] [datetime] NULL,
[DisplayInHomePage] [bit] NULL,
[PartnerId] [nvarchar](128) NULL,
[IsExternal] [bit] NULL DEFAULT ((0)),
[Name] [nvarchar](255) NULL,
[Image] [ntext] NULL,
[ExternalLink] [ntext] NULL,
CONSTRAINT [PK_FeaturedPartners] PRIMARY KEY CLUSTERED
(
[FeaturedPartnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FollowersInfo]    Script Date: 5/8/2016 5:15:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FollowersInfo](
[Id] [int] IDENTITY(1,1) NOT NULL,
[Follower] [nvarchar](128) NOT NULL,
[Following] [nvarchar](128) NULL,
[Subscribed] [datetime] NOT NULL,
CONSTRAINT [PK_FollowersInfo] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Images]    Script Date: 5/8/2016 5:15:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
[Image_ID] [int] IDENTITY(1,1) NOT NULL,
[Art_ID] [int] NOT NULL,
[Path] [ntext] NOT NULL,
CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED
(
[Image_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Institutions]    Script Date: 5/8/2016 5:15:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Institutions](
[Institution_ID] [int] IDENTITY(1,1) NOT NULL,
[User_ID] [nvarchar](128) NULL,
[PhoneNumber] [nvarchar](20) NULL,
[Aboutus] [nvarchar](max) NULL,
[InstitutionType] [nvarchar](500) NULL,
[Profile_Pic] [nvarchar](max) NULL,
[Cover_Pic] [nvarchar](max) NULL,
[Location] [nvarchar](500) NULL,
[Price_Range] [nvarchar](500) NULL,
[Exhibition] [nvarchar](500) NULL,
[ContactUs] [nvarchar](500) NULL,
[Position] [nvarchar](10) NULL,
[OpeningTimes] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED
(
[Institution_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Locations]    Script Date: 5/8/2016 5:15:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Locations](
[LocationID] [int] IDENTITY(1,1) NOT NULL,
[Name] [nvarchar](50) NOT NULL,
[Created] [datetime] NOT NULL CONSTRAINT [DF_Locations_Created]  DEFAULT (getdate()),
[Modified] [datetime] NOT NULL CONSTRAINT [DF_Locations_Modified]  DEFAULT (getdate()),
CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED
(
[LocationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Subscribers]    Script Date: 5/8/2016 5:15:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subscribers](
[SubscriberId] [int] IDENTITY(1,1) NOT NULL,
[IsActive] [bit] NOT NULL,
[Created] [datetime] NULL,
[Modified] [datetime] NULL,
[Email] [nvarchar](255) NULL,
CONSTRAINT [PK_Subscriber] PRIMARY KEY CLUSTERED
(
[SubscriberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[LikesDislikes](
[Id] [int] IDENTITY(1,1) NOT NULL,
[UserId] [nvarchar](128) NOT NULL,
[ArtId] [int] NOT NULL,
[IsLike] [bit] NULL,
PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]