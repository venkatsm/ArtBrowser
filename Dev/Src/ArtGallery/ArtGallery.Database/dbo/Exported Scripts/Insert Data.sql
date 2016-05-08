USE [ArtBrowser]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1', N'Administrator')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2', N'Artist')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3', N'Institution')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'4', N'Buyer')
INSERT [dbo].[AspNetUsers] ([Id], [Hometown], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Name]) VALUES (N'21a17870-630e-4fe1-89f2-aa5fbff7e6c8', NULL, N'artist1@gmail.com', 0, N'ACjZrVopyLELs4I4SUtkOM6pdnHh5lLFcAI8V6Zh6C40JMwSJx0VdVeUw0LfjTaxkQ==', N'92adf014-c0c9-45f6-8653-5221ebff55ad', NULL, 0, 0, NULL, 1, 0, N'artist1@gmail.com', N'Artist 1')
INSERT [dbo].[AspNetUsers] ([Id], [Hometown], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Name]) VALUES (N'e9b512af-2748-4bf0-8de4-1ce1c212630a', NULL, N'institution1@gmail.com', 0, N'ANY/So4WZDk2FJ6ICxPL6t9Gg5A6bLChFUWnXr9T2VlqZr2aByXYEiL099+e88zMQQ==', N'2042f396-cada-4e1f-8b03-3171eaf92994', NULL, 0, 0, NULL, 1, 0, N'institution1@gmail.com', N'Institution 1')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'21a17870-630e-4fe1-89f2-aa5fbff7e6c8', N'2')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e9b512af-2748-4bf0-8de4-1ce1c212630a', N'3')
SET IDENTITY_INSERT [dbo].[Artists] ON 

INSERT [dbo].[Artists] ([Artist_ID], [User_ID], [PhoneNumber], [Gender], [Profile_Pic], [Cover_Pic], [Location], [Statement], [Price_Range], [DOB], [Expertise], [Education], [Work]) VALUES (1, N'21a17870-630e-4fe1-89f2-aa5fbff7e6c8', N'9966003499', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Artists] OFF
SET IDENTITY_INSERT [dbo].[Institutions] ON 

INSERT [dbo].[Institutions] ([Institution_ID], [User_ID], [PhoneNumber], [Aboutus], [InstitutionType], [Profile_Pic], [Cover_Pic], [Location], [Price_Range], [Exhibition], [ContactUs]) VALUES (1, N'e9b512af-2748-4bf0-8de4-1ce1c212630a', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Institutions] OFF
