ALTER TABLE [dbo].[FollowersInfo] ADD  CONSTRAINT [DF_FollowersInfo_Subscribed]  DEFAULT (getdate()) FOR [Subscribed]
GO
ALTER TABLE [dbo].[Announcements]  WITH CHECK ADD FOREIGN KEY([User_ID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Artists]  WITH CHECK ADD FOREIGN KEY([User_ID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Arts]  WITH CHECK ADD FOREIGN KEY([User_ID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Arts]  WITH NOCHECK ADD  CONSTRAINT [FK_Arts_Categories] FOREIGN KEY([Category_ID])
REFERENCES [dbo].[Categories] ([CategoryId])
GO
ALTER TABLE [dbo].[Arts] CHECK CONSTRAINT [FK_Arts_Categories]
GO
ALTER TABLE [dbo].[Arts]  WITH CHECK ADD  CONSTRAINT [FK_Arts_Locations] FOREIGN KEY([Location_ID])
REFERENCES [dbo].[Locations] ([LocationID])
GO
ALTER TABLE [dbo].[Arts] CHECK CONSTRAINT [FK_Arts_Locations]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Exhibitions]  WITH CHECK ADD  CONSTRAINT [FK_Exhibitions_AspNetUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Exhibitions] CHECK CONSTRAINT [FK_Exhibitions_AspNetUsers]
GO
ALTER TABLE [dbo].[FeaturedPartners]  WITH CHECK ADD  CONSTRAINT [FK_FeaturedPartners_ToAspNetUsers] FOREIGN KEY([PartnerId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[FeaturedPartners] CHECK CONSTRAINT [FK_FeaturedPartners_ToAspNetUsers]
GO
ALTER TABLE [dbo].[FollowersInfo]  WITH CHECK ADD  CONSTRAINT [FK_Follower_AspNetUsers] FOREIGN KEY([Follower])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[FollowersInfo] CHECK CONSTRAINT [FK_Follower_AspNetUsers]
GO
ALTER TABLE [dbo].[FollowersInfo]  WITH CHECK ADD  CONSTRAINT [FK_Following_AspNetUsers] FOREIGN KEY([Following])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[FollowersInfo] CHECK CONSTRAINT [FK_Following_AspNetUsers]
GO
ALTER TABLE [dbo].[Images]  WITH CHECK ADD  CONSTRAINT [FK_Images_Arts] FOREIGN KEY([Art_ID])
REFERENCES [dbo].[Arts] ([Art_ID])
GO
ALTER TABLE [dbo].[Images] CHECK CONSTRAINT [FK_Images_Arts]
GO
ALTER TABLE [dbo].[Institutions]  WITH CHECK ADD FOREIGN KEY([User_ID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[LikesDislikes]  WITH CHECK ADD  CONSTRAINT [FK_LikesDislikes_AspNetUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[LikesDislikes] CHECK CONSTRAINT [FK_LikesDislikes_AspNetUsers]
GO
ALTER TABLE [dbo].[LikesDislikes]  WITH CHECK ADD  CONSTRAINT [FK_LikesDislikes_Arts] FOREIGN KEY([ArtId])
REFERENCES [dbo].[Arts] ([Art_Id])
GO
ALTER TABLE [dbo].[LikesDislikes] CHECK CONSTRAINT [FK_LikesDislikes_Arts]
GO
