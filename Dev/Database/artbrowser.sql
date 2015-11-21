-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Oct 18, 2015 at 09:53 AM
-- Server version: 5.6.17
-- PHP Version: 5.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `artbrowser`
--

-- --------------------------------------------------------

--
-- Table structure for table `announcements`
--

CREATE TABLE IF NOT EXISTS `announcements` (
  `AnnouncementID` int(10) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) NOT NULL,
  `Description` text NOT NULL,
  `PartnerID` int(10) NOT NULL,
  `Created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`AnnouncementID`),
  KEY `PartnerID` (`PartnerID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Stand-in structure for view `artists`
--
CREATE TABLE IF NOT EXISTS `artists` (
`Name` varchar(50)
,`Email` varchar(50)
,`PartnerTypeID` int(3)
,`Password` varchar(50)
,`SubscriptionID` int(3)
,`Phone` bigint(10)
,`Status` tinyint(1)
,`LocationID` int(2)
,`ProfilePic` varchar(255)
,`Created` timestamp
,`ArtistID` int(10)
,`PartnerID` int(11)
,`ArtistLocation` varchar(50)
,`Statement` text
,`PriceRange` varchar(20)
,`NoOfFollowers` int(8)
,`CoverPic` varchar(255)
,`DOB` timestamp
,`Expertise` text
,`Education` varchar(255)
,`Exhibitions` text
,`Work` text
,`Gender` varchar(10)
);
-- --------------------------------------------------------

--
-- Table structure for table `arts`
--

CREATE TABLE IF NOT EXISTS `arts` (
  `ArtID` int(10) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  `Description` text NOT NULL,
  `SubCategoryID` int(8) NOT NULL,
  `PartnerID` int(8) NOT NULL,
  `Price` int(8) NOT NULL,
  `Keywords` text NOT NULL,
  `Status` tinyint(1) NOT NULL,
  `LocationID` int(2) NOT NULL,
  `AskForPrice` tinyint(1) NOT NULL,
  `AverageRating` float NOT NULL,
  `NoOfLikes` int(10) NOT NULL,
  `Created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ArtID`),
  KEY `SubCategory` (`SubCategoryID`,`PartnerID`,`LocationID`),
  KEY `LocationID` (`LocationID`),
  KEY `Partner` (`PartnerID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Arts' AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `art_images`
--

CREATE TABLE IF NOT EXISTS `art_images` (
  `ArtImageID` int(10) NOT NULL AUTO_INCREMENT,
  `Url` varchar(255) NOT NULL,
  `Alternative` text NOT NULL,
  `ArtID` int(10) NOT NULL,
  `Created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ArtImageID`),
  KEY `ArtID` (`ArtID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `cart`
--

CREATE TABLE IF NOT EXISTS `cart` (
  `CartID` int(10) NOT NULL AUTO_INCREMENT,
  `ArtID` int(10) NOT NULL,
  `SessionID` varchar(50) NOT NULL,
  `Created` timestamp NOT NULL,
  PRIMARY KEY (`CartID`),
  KEY `ArtID` (`ArtID`,`SessionID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `categories`
--

CREATE TABLE IF NOT EXISTS `categories` (
  `CategoryID` int(8) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  `Description` text NOT NULL,
  `LocationID` int(2) NOT NULL,
  `Created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`CategoryID`),
  KEY `LocationID` (`LocationID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Categories' AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `follows`
--

CREATE TABLE IF NOT EXISTS `follows` (
  `FollowID` int(10) NOT NULL AUTO_INCREMENT,
  `PartnerID` int(10) NOT NULL,
  `UserID` int(10) NOT NULL,
  `Created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`FollowID`),
  KEY `PartnerID` (`PartnerID`,`UserID`),
  KEY `UserID` (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Stand-in structure for view `galleries`
--
CREATE TABLE IF NOT EXISTS `galleries` (
`Name` varchar(50)
,`Email` varchar(50)
,`PartnerTypeID` int(3)
,`Password` varchar(50)
,`SubscriptionID` int(3)
,`Phone` bigint(10)
,`Status` tinyint(1)
,`LocationID` int(2)
,`ProfilePic` varchar(255)
,`Created` timestamp
,`GalleryID` int(10)
,`PartnerID` int(10)
,`InstitutionType` varchar(100)
,`GalleryLocation` varchar(100)
,`PriceRange` varchar(255)
,`CoverPic` text
,`AboutUs` text
,`NoOfFollowers` int(10)
,`ContactUs` text
,`Exhibitions` text
,`Work` text
);
-- --------------------------------------------------------

--
-- Table structure for table `locations`
--

CREATE TABLE IF NOT EXISTS `locations` (
  `LocationID` int(3) NOT NULL AUTO_INCREMENT,
  `Name` varchar(20) NOT NULL,
  `Created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`LocationID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 COMMENT='Locations' AUTO_INCREMENT=3 ;

--
-- Dumping data for table `locations`
--

INSERT INTO `locations` (`LocationID`, `Name`, `Created`) VALUES
(1, 'India', '2015-10-17 19:20:08'),
(2, 'UK', '2015-10-17 19:20:08');

-- --------------------------------------------------------

--
-- Table structure for table `orderdetails`
--

CREATE TABLE IF NOT EXISTS `orderdetails` (
  `OderDetailID` int(10) NOT NULL AUTO_INCREMENT,
  `OrderID` int(10) NOT NULL,
  `ArtID` int(10) NOT NULL,
  `Price` int(10) NOT NULL,
  `Discount` int(10) NOT NULL,
  `Total` int(10) NOT NULL,
  `Fullfilled` tinyint(1) NOT NULL,
  `ShipDate` timestamp NOT NULL,
  `BillDate` timestamp NOT NULL,
  PRIMARY KEY (`OderDetailID`),
  KEY `OrderID` (`OrderID`,`ArtID`),
  KEY `ArtID` (`ArtID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `orders`
--

CREATE TABLE IF NOT EXISTS `orders` (
  `OrderID` int(10) NOT NULL AUTO_INCREMENT,
  `UserID` int(10) NOT NULL,
  `OrderNumber` varchar(50) NOT NULL,
  `PaymentID` int(3) NOT NULL,
  `OrderDate` timestamp NOT NULL,
  `ShipDate` timestamp NOT NULL,
  `RequiredDate` timestamp NOT NULL,
  `ShipperID` int(11) NOT NULL,
  `Freight` int(10) NOT NULL,
  `Tax` int(10) NOT NULL,
  `Status` varchar(50) NOT NULL,
  `ErrorLoc` text NOT NULL,
  `ErrorMsg` text NOT NULL,
  `Fullfilled` tinyint(1) NOT NULL,
  `Deleted` tinyint(1) NOT NULL,
  `Paid` tinyint(1) NOT NULL,
  `PaymentDate` timestamp NOT NULL,
  PRIMARY KEY (`OrderID`),
  KEY `UserID` (`UserID`,`ShipperID`),
  KEY `PaymentID` (`PaymentID`),
  KEY `ShipperID` (`ShipperID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `partners`
--

CREATE TABLE IF NOT EXISTS `partners` (
  `PartnerID` int(10) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  `Email` varchar(50) NOT NULL,
  `PartnerTypeID` int(3) NOT NULL,
  `Password` varchar(50) NOT NULL,
  `SubscriptionID` int(3) NOT NULL,
  `Phone` bigint(10) NOT NULL,
  `Status` tinyint(1) NOT NULL,
  `LocationID` int(2) NOT NULL,
  `ProfilePic` varchar(255) NOT NULL,
  `Created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`PartnerID`),
  KEY `Subscription` (`SubscriptionID`,`LocationID`),
  KEY `Subscription_2` (`SubscriptionID`),
  KEY `Location` (`LocationID`),
  KEY `PartnerTypeID` (`PartnerTypeID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 COMMENT='Partners' AUTO_INCREMENT=6 ;

--
-- Dumping data for table `partners`
--

INSERT INTO `partners` (`PartnerID`, `Name`, `Email`, `PartnerTypeID`, `Password`, `SubscriptionID`, `Phone`, `Status`, `LocationID`, `ProfilePic`, `Created`) VALUES
(4, 'Venkatesh', 'sm.venkat@yahoo.com', 1, 'Venkatesh', 1, 9966003499, 1, 1, '', '2015-10-18 06:13:35'),
(5, 'Dinesh', 'Dinesh@gmail.com', 2, 'Dinesh', 1, 9966003499, 1, 1, '', '2015-10-18 07:30:21');

-- --------------------------------------------------------

--
-- Table structure for table `partners_artists`
--

CREATE TABLE IF NOT EXISTS `partners_artists` (
  `ArtistID` int(10) NOT NULL AUTO_INCREMENT,
  `PartnerID` int(11) NOT NULL,
  `ArtistLocation` varchar(50) NOT NULL,
  `Statement` text NOT NULL,
  `PriceRange` varchar(20) NOT NULL,
  `NoOfFollowers` int(8) NOT NULL DEFAULT '0',
  `CoverPic` varchar(255) NOT NULL,
  `DOB` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `Expertise` text NOT NULL,
  `Education` varchar(255) NOT NULL,
  `Exhibitions` text NOT NULL,
  `Work` text NOT NULL,
  `Gender` varchar(10) NOT NULL,
  PRIMARY KEY (`ArtistID`),
  UNIQUE KEY `PartnerID_2` (`PartnerID`),
  KEY `PartnerID` (`PartnerID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=7 ;

--
-- Dumping data for table `partners_artists`
--

INSERT INTO `partners_artists` (`ArtistID`, `PartnerID`, `ArtistLocation`, `Statement`, `PriceRange`, `NoOfFollowers`, `CoverPic`, `DOB`, `Expertise`, `Education`, `Exhibitions`, `Work`, `Gender`) VALUES
(6, 4, 'Hyderabad', '', '', 0, '', '2015-10-22 18:30:00', '', '', '', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `partners_gallery`
--

CREATE TABLE IF NOT EXISTS `partners_gallery` (
  `GalleryID` int(10) NOT NULL AUTO_INCREMENT,
  `PartnerID` int(10) NOT NULL,
  `InstitutionType` varchar(100) NOT NULL,
  `GalleryLocation` varchar(100) NOT NULL,
  `PriceRange` varchar(255) NOT NULL,
  `CoverPic` text NOT NULL,
  `AboutUs` text NOT NULL,
  `NoOfFollowers` int(10) NOT NULL DEFAULT '0',
  `ContactUs` text NOT NULL,
  `Exhibitions` text NOT NULL,
  `Work` text NOT NULL,
  PRIMARY KEY (`GalleryID`),
  UNIQUE KEY `PartnerID` (`PartnerID`),
  KEY `PartnerID_2` (`PartnerID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Dumping data for table `partners_gallery`
--

INSERT INTO `partners_gallery` (`GalleryID`, `PartnerID`, `InstitutionType`, `GalleryLocation`, `PriceRange`, `CoverPic`, `AboutUs`, `NoOfFollowers`, `ContactUs`, `Exhibitions`, `Work`) VALUES
(1, 5, '', '', '', '', '', 0, '', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `partner_types`
--

CREATE TABLE IF NOT EXISTS `partner_types` (
  `PartnerTypeID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  `LocationID` int(3) NOT NULL,
  `Created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`PartnerTypeID`),
  KEY `LocationID` (`LocationID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Dumping data for table `partner_types`
--

INSERT INTO `partner_types` (`PartnerTypeID`, `Name`, `LocationID`, `Created`) VALUES
(1, 'Artist', 1, '2015-10-18 06:10:13'),
(2, 'Gallery', 1, '2015-10-18 06:10:13');

-- --------------------------------------------------------

--
-- Table structure for table `payment`
--

CREATE TABLE IF NOT EXISTS `payment` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `PaymentType` varchar(20) NOT NULL,
  `Allowed` tinyint(1) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `reviews`
--

CREATE TABLE IF NOT EXISTS `reviews` (
  `ReviewID` int(10) NOT NULL AUTO_INCREMENT,
  `Rating` int(1) NOT NULL,
  `Comment` text NOT NULL,
  `ArtID` int(10) NOT NULL,
  `UserID` int(10) NOT NULL,
  `Created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ReviewID`),
  KEY `ArtID` (`ArtID`,`UserID`),
  KEY `UserID` (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Reviews' AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `roles`
--

CREATE TABLE IF NOT EXISTS `roles` (
  `RoleID` int(2) NOT NULL AUTO_INCREMENT,
  `Name` varchar(20) NOT NULL,
  `Created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`RoleID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 COMMENT='Roles' AUTO_INCREMENT=4 ;

--
-- Dumping data for table `roles`
--

INSERT INTO `roles` (`RoleID`, `Name`, `Created`) VALUES
(1, 'Buyer', '2015-10-17 19:23:23'),
(2, 'Partner', '2015-10-17 19:23:23'),
(3, 'Admin', '2015-10-17 19:23:23');

-- --------------------------------------------------------

--
-- Table structure for table `shippers`
--

CREATE TABLE IF NOT EXISTS `shippers` (
  `ShipperID` int(5) NOT NULL AUTO_INCREMENT,
  `CompanyName` varchar(50) NOT NULL,
  `Phone` bigint(20) NOT NULL,
  PRIMARY KEY (`ShipperID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `subcategories`
--

CREATE TABLE IF NOT EXISTS `subcategories` (
  `SubCategoryID` int(10) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  `Description` text NOT NULL,
  `CategoryID` int(8) NOT NULL,
  `Created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`SubCategoryID`),
  UNIQUE KEY `CategoryID` (`CategoryID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='SubCategories' AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `subscription_types`
--

CREATE TABLE IF NOT EXISTS `subscription_types` (
  `SubscriptionID` int(3) NOT NULL AUTO_INCREMENT,
  `Name` varchar(20) NOT NULL,
  `RoleID` int(2) NOT NULL,
  `Created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`SubscriptionID`),
  KEY `RoleID` (`RoleID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 COMMENT='Subscription Types' AUTO_INCREMENT=5 ;

--
-- Dumping data for table `subscription_types`
--

INSERT INTO `subscription_types` (`SubscriptionID`, `Name`, `RoleID`, `Created`) VALUES
(1, 'Standard', 2, '2015-10-17 19:24:29'),
(2, 'Premium', 2, '2015-10-17 19:24:29'),
(3, 'Standard', 1, '2015-10-17 19:24:29'),
(4, 'Premium', 1, '2015-10-17 19:24:29');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE IF NOT EXISTS `users` (
  `ID` int(8) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  `Email` varchar(50) NOT NULL,
  `Password` varchar(50) NOT NULL,
  `Subscription` int(3) NOT NULL,
  `Phone` bigint(10) NOT NULL,
  `BillingAddress` text NOT NULL,
  `BillingPincode` int(8) NOT NULL,
  `ShippingAddress` text NOT NULL,
  `ShippingPincode` int(8) NOT NULL,
  `LocationID` int(2) NOT NULL,
  `Created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `Subscription` (`Subscription`,`LocationID`),
  KEY `LocationID` (`LocationID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Buyers' AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `wishlist`
--

CREATE TABLE IF NOT EXISTS `wishlist` (
  `WishlistID` int(10) NOT NULL AUTO_INCREMENT,
  `PartnerID` int(10) NOT NULL,
  `UserID` int(10) NOT NULL,
  `Created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`WishlistID`),
  KEY `PartnerID` (`PartnerID`,`UserID`),
  KEY `UserID` (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure for view `artists`
--
DROP TABLE IF EXISTS `artists`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `artists` AS select `partners`.`Name` AS `Name`,`partners`.`Email` AS `Email`,`partners`.`PartnerTypeID` AS `PartnerTypeID`,`partners`.`Password` AS `Password`,`partners`.`SubscriptionID` AS `SubscriptionID`,`partners`.`Phone` AS `Phone`,`partners`.`Status` AS `Status`,`partners`.`LocationID` AS `LocationID`,`partners`.`ProfilePic` AS `ProfilePic`,`partners`.`Created` AS `Created`,`partners_artists`.`ArtistID` AS `ArtistID`,`partners_artists`.`PartnerID` AS `PartnerID`,`partners_artists`.`ArtistLocation` AS `ArtistLocation`,`partners_artists`.`Statement` AS `Statement`,`partners_artists`.`PriceRange` AS `PriceRange`,`partners_artists`.`NoOfFollowers` AS `NoOfFollowers`,`partners_artists`.`CoverPic` AS `CoverPic`,`partners_artists`.`DOB` AS `DOB`,`partners_artists`.`Expertise` AS `Expertise`,`partners_artists`.`Education` AS `Education`,`partners_artists`.`Exhibitions` AS `Exhibitions`,`partners_artists`.`Work` AS `Work`,`partners_artists`.`Gender` AS `Gender` from (`partners` join `partners_artists`) where (`partners`.`PartnerID` = `partners_artists`.`PartnerID`);

-- --------------------------------------------------------

--
-- Structure for view `galleries`
--
DROP TABLE IF EXISTS `galleries`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `galleries` AS select `partners`.`Name` AS `Name`,`partners`.`Email` AS `Email`,`partners`.`PartnerTypeID` AS `PartnerTypeID`,`partners`.`Password` AS `Password`,`partners`.`SubscriptionID` AS `SubscriptionID`,`partners`.`Phone` AS `Phone`,`partners`.`Status` AS `Status`,`partners`.`LocationID` AS `LocationID`,`partners`.`ProfilePic` AS `ProfilePic`,`partners`.`Created` AS `Created`,`partners_gallery`.`GalleryID` AS `GalleryID`,`partners_gallery`.`PartnerID` AS `PartnerID`,`partners_gallery`.`InstitutionType` AS `InstitutionType`,`partners_gallery`.`GalleryLocation` AS `GalleryLocation`,`partners_gallery`.`PriceRange` AS `PriceRange`,`partners_gallery`.`CoverPic` AS `CoverPic`,`partners_gallery`.`AboutUs` AS `AboutUs`,`partners_gallery`.`NoOfFollowers` AS `NoOfFollowers`,`partners_gallery`.`ContactUs` AS `ContactUs`,`partners_gallery`.`Exhibitions` AS `Exhibitions`,`partners_gallery`.`Work` AS `Work` from (`partners` join `partners_gallery`) where (`partners`.`PartnerID` = `partners_gallery`.`PartnerID`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `announcements`
--
ALTER TABLE `announcements`
  ADD CONSTRAINT `fk_announcements_partners` FOREIGN KEY (`PartnerID`) REFERENCES `partners` (`PartnerID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `arts`
--
ALTER TABLE `arts`
  ADD CONSTRAINT `fk_arts_locations` FOREIGN KEY (`LocationID`) REFERENCES `locations` (`LocationID`),
  ADD CONSTRAINT `fk_arts_partners` FOREIGN KEY (`PartnerID`) REFERENCES `partners` (`PartnerID`),
  ADD CONSTRAINT `fk_arts_subcategory` FOREIGN KEY (`SubCategoryID`) REFERENCES `subcategories` (`SubCategoryID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `art_images`
--
ALTER TABLE `art_images`
  ADD CONSTRAINT `fk_art_artimages` FOREIGN KEY (`ArtID`) REFERENCES `arts` (`ArtID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `cart`
--
ALTER TABLE `cart`
  ADD CONSTRAINT `fk_cart_art` FOREIGN KEY (`ArtID`) REFERENCES `arts` (`ArtID`);

--
-- Constraints for table `categories`
--
ALTER TABLE `categories`
  ADD CONSTRAINT `fk_categories_locations` FOREIGN KEY (`LocationID`) REFERENCES `locations` (`LocationID`);

--
-- Constraints for table `follows`
--
ALTER TABLE `follows`
  ADD CONSTRAINT `fk_follows_users` FOREIGN KEY (`UserID`) REFERENCES `users` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_follows_partners` FOREIGN KEY (`PartnerID`) REFERENCES `partners` (`PartnerID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `orderdetails`
--
ALTER TABLE `orderdetails`
  ADD CONSTRAINT `fk_orderdetails_art` FOREIGN KEY (`ArtID`) REFERENCES `arts` (`ArtID`),
  ADD CONSTRAINT `fk_oderdetails_order` FOREIGN KEY (`OrderID`) REFERENCES `orders` (`OrderID`);

--
-- Constraints for table `orders`
--
ALTER TABLE `orders`
  ADD CONSTRAINT `fk_orders_shippers` FOREIGN KEY (`ShipperID`) REFERENCES `shippers` (`ShipperID`),
  ADD CONSTRAINT `fk_orders_payments` FOREIGN KEY (`PaymentID`) REFERENCES `payment` (`ID`),
  ADD CONSTRAINT `fk_orders_user` FOREIGN KEY (`UserID`) REFERENCES `users` (`ID`);

--
-- Constraints for table `partners`
--
ALTER TABLE `partners`
  ADD CONSTRAINT `fk_partners_location` FOREIGN KEY (`LocationID`) REFERENCES `locations` (`LocationID`),
  ADD CONSTRAINT `fk_partners_partnertypes` FOREIGN KEY (`PartnerTypeID`) REFERENCES `partner_types` (`PartnerTypeID`),
  ADD CONSTRAINT `fk_partner_subscription` FOREIGN KEY (`SubscriptionID`) REFERENCES `subscription_types` (`SubscriptionID`);

--
-- Constraints for table `partners_artists`
--
ALTER TABLE `partners_artists`
  ADD CONSTRAINT `fk_artist_partner` FOREIGN KEY (`PartnerID`) REFERENCES `partners` (`PartnerID`);

--
-- Constraints for table `partners_gallery`
--
ALTER TABLE `partners_gallery`
  ADD CONSTRAINT `fk_galler_partner` FOREIGN KEY (`PartnerID`) REFERENCES `partners` (`PartnerID`);

--
-- Constraints for table `partner_types`
--
ALTER TABLE `partner_types`
  ADD CONSTRAINT `fk_partnertypes_location` FOREIGN KEY (`LocationID`) REFERENCES `locations` (`LocationID`);

--
-- Constraints for table `reviews`
--
ALTER TABLE `reviews`
  ADD CONSTRAINT `fk_reviews_art` FOREIGN KEY (`ArtID`) REFERENCES `arts` (`ArtID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_reviews_user` FOREIGN KEY (`UserID`) REFERENCES `users` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `subcategories`
--
ALTER TABLE `subcategories`
  ADD CONSTRAINT `fk_subcategory_category` FOREIGN KEY (`CategoryID`) REFERENCES `categories` (`CategoryID`);

--
-- Constraints for table `subscription_types`
--
ALTER TABLE `subscription_types`
  ADD CONSTRAINT `fk_subscription_role` FOREIGN KEY (`RoleID`) REFERENCES `roles` (`RoleID`);

--
-- Constraints for table `users`
--
ALTER TABLE `users`
  ADD CONSTRAINT `fk_users_locations` FOREIGN KEY (`LocationID`) REFERENCES `locations` (`LocationID`),
  ADD CONSTRAINT `fm_users_subscription` FOREIGN KEY (`Subscription`) REFERENCES `subscription_types` (`SubscriptionID`);

--
-- Constraints for table `wishlist`
--
ALTER TABLE `wishlist`
  ADD CONSTRAINT `fk_wishlist_user` FOREIGN KEY (`UserID`) REFERENCES `users` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_wishlist_partners` FOREIGN KEY (`PartnerID`) REFERENCES `partners` (`PartnerID`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
