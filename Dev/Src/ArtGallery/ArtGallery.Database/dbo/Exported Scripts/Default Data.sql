INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1', N'Administrator')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2', N'Artist')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3', N'Institution')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'4', N'Buyer')


SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [Name], [Created], [Modified], [ImagePath], [DisplayInHomePage]) VALUES (1, N'Category 1', CAST(N'2016-01-16 11:12:16.137' AS DateTime), CAST(N'2016-04-19 07:51:11.433' AS DateTime), NULL, 0)
INSERT [dbo].[Categories] ([CategoryId], [Name], [Created], [Modified], [ImagePath], [DisplayInHomePage]) VALUES (2, N'Category 2', CAST(N'2016-01-16 11:12:22.013' AS DateTime), CAST(N'2016-01-16 11:12:22.013' AS DateTime), NULL, 0)
INSERT [dbo].[Categories] ([CategoryId], [Name], [Created], [Modified], [ImagePath], [DisplayInHomePage]) VALUES (3, N'Category 3', CAST(N'2016-01-16 11:12:28.623' AS DateTime), CAST(N'2016-01-16 11:12:28.623' AS DateTime), NULL, 0)
INSERT [dbo].[Categories] ([CategoryId], [Name], [Created], [Modified], [ImagePath], [DisplayInHomePage]) VALUES (10, N'Category 4', CAST(N'2016-04-09 05:32:41.000' AS DateTime), CAST(N'2016-04-09 05:32:41.000' AS DateTime), NULL, 0)
SET IDENTITY_INSERT [dbo].[Categories] OFF

SET IDENTITY_INSERT [dbo].[Configurations] ON 

INSERT [dbo].[Configurations] ([ConfigurationId], [Key], [Value]) VALUES (2, N'FAQ', N'<h2>FAQ</h2>

<p><strong>1. Will my money be safe?</strong><br />
Yes! We will hold the money securely for you, and only once you have received your item will the money be transferred to the artist.</p>

<p><strong>2. Does this cover insurance for my purchased item?</strong><br />
The money you have paid covers the cost of the artwork and shipping. If damages occur during the delivery process, you can contact us about returning the item.</p>

<p><strong>3. What is your returns policy?</strong><br />
You may return any item within 30 working days. However, the item must be returned in the condition you received it.</p>

<p><strong>4. I am an artist, how can I sign up?</strong><br />
That&#39;s great! Please contact us via the form below.</p>

<p><strong>5. I want to advertise an event, is this possible?</strong><br />
Yes, for more information please contact us directly using the form below.</p>

<p><strong>6. How can I contact the artist directly?</strong><br />
On the Artist&#39;s Profile there is a contact form. For privacy reasons we do not give out personal emails or contact numbers.</p>

<p><strong>7. I find a picture or comment offensive, how can I report it?</strong><br />
Please get in touch giving as much detail on the incident, including the profile on which it occurred.</p>

<p><strong>8. How can I purchase a work that is not local?</strong><br />
This depends on whether the artist or gallery has stated whether the item can feasibly be shipped. If so, then yes go ahead! However, sometimes items may be too big or fragile be sent via postage.</p>

<p><strong>9. I liked an item and now it has disappeared, where has it gone?</strong><br />
This will happen when an item has been sold. If you really love a piece, why not follow the artist so you can be the first to know when they release a new artwork.</p>

<p><strong>10. How can a restrict my searches to certain categories?</strong><br />
You can search artwork either through &#39;tags&#39; or &#39;categories&#39;.</p>
')
INSERT [dbo].[Configurations] ([ConfigurationId], [Key], [Value]) VALUES (3, N'About', N'<h2>About Us</h2>

<p>ArtBrowser is a global marketplace for art lovers. We are a digital platform that will help artists and independent art galleries promote their artworks and connect with art enthusiasts around the world.</p>

<p>ArtBrowser is partnering with artists, galleries and other organisations to create a genuine marketplace for art lovers. We help our partners promote their artworks, events and exhibitions to a wider audience.</p>

<p>Our team at ArtBrowser specialises in organising and promoting events in the art industry and connecting people through arts.</p>
')
INSERT [dbo].[Configurations] ([ConfigurationId], [Key], [Value]) VALUES (5, N'Main', N'<h2>Help</h2>

<p><strong>Add your content here</strong></p>
')
SET IDENTITY_INSERT [dbo].[Configurations] OFF

SET IDENTITY_INSERT [dbo].[Locations] ON 

INSERT [dbo].[Locations] ([LocationID], [Name], [Created], [Modified]) VALUES (1, N'Birmingham', CAST(N'2016-01-16 11:11:40.543' AS DateTime), CAST(N'2016-04-09 03:27:31.620' AS DateTime))
INSERT [dbo].[Locations] ([LocationID], [Name], [Created], [Modified]) VALUES (2, N'Manchester', CAST(N'2016-01-16 11:11:48.497' AS DateTime), CAST(N'2016-04-09 03:27:22.293' AS DateTime))
INSERT [dbo].[Locations] ([LocationID], [Name], [Created], [Modified]) VALUES (3, N'London', CAST(N'2016-01-16 11:11:58.980' AS DateTime), CAST(N'2016-04-09 03:27:12.997' AS DateTime))
INSERT [dbo].[Locations] ([LocationID], [Name], [Created], [Modified]) VALUES (6, N'Edinburgh', CAST(N'2016-04-05 05:01:10.900' AS DateTime), CAST(N'2016-04-05 05:01:10.900' AS DateTime))
INSERT [dbo].[Locations] ([LocationID], [Name], [Created], [Modified]) VALUES (8, N'Cambridge', CAST(N'2016-04-09 03:27:42.700' AS DateTime), CAST(N'2016-04-09 03:27:42.700' AS DateTime))
INSERT [dbo].[Locations] ([LocationID], [Name], [Created], [Modified]) VALUES (9, N'Bristol', CAST(N'2016-04-09 03:27:52.653' AS DateTime), CAST(N'2016-04-09 03:27:52.653' AS DateTime))
INSERT [dbo].[Locations] ([LocationID], [Name], [Created], [Modified]) VALUES (10, N'Glasgow', CAST(N'2016-04-09 03:28:24.200' AS DateTime), CAST(N'2016-04-09 03:28:24.200' AS DateTime))
INSERT [dbo].[Locations] ([LocationID], [Name], [Created], [Modified]) VALUES (12, N'Aberdeen', CAST(N'2016-04-09 05:35:20.583' AS DateTime), CAST(N'2016-04-09 05:35:20.583' AS DateTime))
SET IDENTITY_INSERT [dbo].[Locations] OFF
