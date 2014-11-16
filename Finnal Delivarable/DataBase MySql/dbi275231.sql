-- phpMyAdmin SQL Dump
-- version 3.4.10.1
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Jan 19, 2014 at 11:46 PM
-- Server version: 5.5.11
-- PHP Version: 5.3.10

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `dbi275231`
--

-- --------------------------------------------------------

--
-- Table structure for table `campingspot`
--

CREATE TABLE IF NOT EXISTS `campingspot` (
  `Camp_id` int(11) NOT NULL,
  `NumberOfGuests` int(11) DEFAULT NULL,
  `Client_AccountNumber` int(11) NOT NULL,
  PRIMARY KEY (`Camp_id`),
  KEY `fk_CampingSpot_Client1_idx` (`Client_AccountNumber`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `campingspot`
--

INSERT INTO `campingspot` (`Camp_id`, `NumberOfGuests`, `Client_AccountNumber`) VALUES
(4, 5, 1),
(5, 6, 1353535464),
(6, 4, 1353535464),
(7, 1, 1353535464),
(8, 6, 1353535465),
(9, 3, 1353535466);

-- --------------------------------------------------------

--
-- Table structure for table `campingspotguest`
--

CREATE TABLE IF NOT EXISTS `campingspotguest` (
  `CampingSpot_Camp_id` int(11) NOT NULL,
  `Client_AccountNumber` int(11) NOT NULL,
  UNIQUE KEY `fk_Guest_CampingSpot1_idx` (`CampingSpot_Camp_id`,`Client_AccountNumber`),
  KEY `fk_ListOfGuest_Client1_idx` (`Client_AccountNumber`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `campingspotguest`
--

INSERT INTO `campingspotguest` (`CampingSpot_Camp_id`, `Client_AccountNumber`) VALUES
(4, 465468);

-- --------------------------------------------------------

--
-- Table structure for table `client`
--

CREATE TABLE IF NOT EXISTS `client` (
  `AccountNumber` int(11) NOT NULL,
  `First_Name` varchar(45) DEFAULT NULL,
  `Last_Name` varchar(45) DEFAULT NULL,
  `RFID` varchar(45) DEFAULT NULL,
  `City` varchar(60) DEFAULT NULL,
  `Address` varchar(45) DEFAULT NULL,
  `ZipCode` varchar(45) DEFAULT NULL,
  `Email` varchar(45) DEFAULT NULL,
  `Gender` varchar(45) DEFAULT NULL,
  `DateOfBirth` date DEFAULT NULL,
  `MoneyBalance` double DEFAULT NULL,
  `InEvent` tinyint(1) DEFAULT NULL,
  `Password` varchar(45) DEFAULT NULL,
  `Pay` tinyint(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`AccountNumber`),
  UNIQUE KEY `RFID_UNIQUE` (`RFID`),
  UNIQUE KEY `Email` (`Email`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `client`
--

INSERT INTO `client` (`AccountNumber`, `First_Name`, `Last_Name`, `RFID`, `City`, `Address`, `ZipCode`, `Email`, `Gender`, `DateOfBirth`, `MoneyBalance`, `InEvent`, `Password`, `Pay`) VALUES
(1, 'name', 'surname', '1c00fcb1eb', 'Eindhoven', 'barrierweg', '5622CS', 'aa@aa.aa', 'female', '2014-01-17', 99, 0, 'aaa', 0),
(123456, 'Vladimir', 'Mohammed', '0a006f46d9', NULL, 'fkasfa', 'UTER 32', 'vlado@something.nl', 'male', '2013-12-11', 976.5, 1, 'vladoni', 0),
(465468, 'as', 'tu', NULL, NULL, 'asfadg', '2412 re', 'afasdgase@mail.nh', 'male', '2014-01-16', 951, 0, 'aaa', 0),
(777777, 'Tsvetomir', 'Yotov', '2800c486d8', NULL, 'bredalaan', '1341 te', 'cicone@mail.bg', 'male', '1993-04-07', 880.5, 0, 'something', 0),
(1353535461, 'Toshko', 'Kosev', '2800b3a441', NULL, 'efe', '1341 te', 'akfak@mail.bg', 'male', '2013-11-13', 741, 1, 'dagoduhash', 0),
(1353535463, 'name', 'surname', '28002b4194', 'Eindhoven', 'barrierweg', '5622CS', 'test@email.com', 'male', '2014-01-17', 0, 0, 'aaa', 0),
(1353535464, 'name', 'surname', NULL, 'Eindhoven', 'barrierweg', '5622CS', 'testuoju@test.com', 'female', '2014-01-08', -25, 0, 'aaa', 0),
(1353535465, 'Rimgaudas', 'Tamulevicius', '2300fb4525', 'eindhoven', 'schootsestraat', '5616re', 'Rymgas@yahoo.com', 'male', '2014-01-01', 38.5, 0, 'Rimgaudas', 0),
(1353535466, 'Todor', 'Kosev', '2800c4c75c', 'fefe', 'tdaef', 'rewe', 'tkosev@abv.bg', 'male', '2014-01-15', -25, 0, 'ooo', 0);

-- --------------------------------------------------------

--
-- Table structure for table `material`
--

CREATE TABLE IF NOT EXISTS `material` (
  `Material_id` int(11) NOT NULL,
  `name` varchar(45) DEFAULT NULL,
  `price` double DEFAULT NULL,
  `DateWhenBorrow` datetime DEFAULT NULL,
  `DateWhenReturn` datetime DEFAULT NULL,
  `Description` varchar(42) DEFAULT NULL,
  `IsBroken` tinyint(1) DEFAULT NULL,
  `IsBorrowed` tinyint(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Material_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `material`
--

INSERT INTO `material` (`Material_id`, `name`, `price`, `DateWhenBorrow`, `DateWhenReturn`, `Description`, `IsBroken`, `IsBorrowed`) VALUES
(1, 'Laptop', 20, '2014-01-19 21:01:15', '2013-12-10 00:00:00', 'Lenovo', 0, 1),
(2, 'Micro Storage Device', 20, '2014-01-19 14:26:38', '2013-12-03 00:00:00', 'Usb 2GB', 0, 1),
(3, 'Cable', 40, '2014-01-19 14:49:34', '2013-12-13 00:00:00', 'Ethernet cable', 0, 1),
(4, 'Cable', 32, '2014-01-08 13:08:47', '2013-12-14 00:00:00', 'Usb cable', 0, 0),
(5, 'Storage Device', 22, '2014-01-17 11:06:19', '2013-12-02 00:00:00', 'Hard Disc', 0, 1),
(6, 'Laptop', 31, '2014-01-19 21:01:15', '2013-12-09 00:00:00', 'Dell', 0, 1),
(7, 'Cable', 34, '2014-01-17 12:54:10', '2013-12-04 00:00:00', 'HDMI', 0, 1),
(8, 'Cable', 34, '2014-01-10 10:42:59', '2013-12-18 00:00:00', 'VGA ', 0, 1),
(9, 'Laptop', 34, '2014-01-08 13:06:56', '2013-12-13 00:00:00', 'Toshiba A-300', 0, 0),
(10, 'Laptop', 34, '2014-01-08 13:05:55', '2013-12-24 00:00:00', 'Sony Vaio', 0, 0),
(11, 'Cable', 34, '2014-01-17 18:15:12', '2013-12-10 00:00:00', 'Universal adapter', 0, 1),
(12, 'Storage Device', 20, '2014-01-17 18:15:19', '2013-03-21 00:00:00', 'SSD 8GB', 0, 1);

-- --------------------------------------------------------

--
-- Table structure for table `order`
--

CREATE TABLE IF NOT EXISTS `order` (
  `Order_id` int(11) NOT NULL AUTO_INCREMENT,
  `TotalPrice` double DEFAULT NULL,
  `Date` datetime DEFAULT NULL,
  `Client_AccountNumber` int(11) NOT NULL,
  `Payed` tinyint(4) NOT NULL,
  PRIMARY KEY (`Order_id`),
  KEY `fk_Order_Client1_idx` (`Client_AccountNumber`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=490 ;

--
-- Dumping data for table `order`
--

INSERT INTO `order` (`Order_id`, `TotalPrice`, `Date`, `Client_AccountNumber`, `Payed`) VALUES
(487, 0, '2014-01-19 20:59:41', 777777, 0),
(488, 6.5, '2014-01-19 00:00:00', 1353535465, 1),
(489, 51, '2014-01-19 21:01:15', 1353535465, 1);

-- --------------------------------------------------------

--
-- Table structure for table `order_line`
--

CREATE TABLE IF NOT EXISTS `order_line` (
  `Order_line_id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  `quantity` int(45) DEFAULT NULL,
  `price` double DEFAULT NULL,
  `Order_Order_id` int(11) NOT NULL,
  `Material_Material_id` int(11) DEFAULT NULL,
  `Product_Prioduct_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`Order_line_id`),
  KEY `fk_Order_line_Order1_idx` (`Order_Order_id`),
  KEY `fk_Order_line_Material1_idx` (`Material_Material_id`),
  KEY `fk_Order_line_Product1_idx` (`Product_Prioduct_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=79 ;

--
-- Dumping data for table `order_line`
--

INSERT INTO `order_line` (`Order_line_id`, `name`, `quantity`, `price`, `Order_Order_id`, `Material_Material_id`, `Product_Prioduct_id`) VALUES
(74, 'Burger with beef meat', 1, 2.5, 488, NULL, 1),
(75, 'Chicken burger', 1, 3, 488, NULL, 6),
(76, 'Burger King', 2, 0.5, 488, NULL, 11),
(77, 'Lenovo', 1, 20, 489, 1, NULL),
(78, 'Dell', 1, 31, 489, 6, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `product`
--

CREATE TABLE IF NOT EXISTS `product` (
  `Prioduct_id` int(11) NOT NULL,
  `name` varchar(45) DEFAULT NULL,
  `quantity` int(11) DEFAULT NULL,
  `price` double DEFAULT NULL,
  `IsItSnack` tinyint(1) DEFAULT NULL,
  `Imagepath` varchar(50) NOT NULL,
  PRIMARY KEY (`Prioduct_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `product`
--

INSERT INTO `product` (`Prioduct_id`, `name`, `quantity`, `price`, `IsItSnack`, `Imagepath`) VALUES
(1, 'Burger with beef meat', 90, 2.5, 1, 'C:\\Users\\Toshko\\Desktop\\New folder\\1.jpeg'),
(2, 'Hot-dog with ketchup&frite souce', 74, 3, 1, 'C:\\Users\\Toshko\\Desktop\\New folder\\2.gif'),
(3, 'Cheese Burger', 3, 3, 1, 'C:\\Users\\Toshko\\Desktop\\New folder\\3.gif'),
(4, 'Vegetarian Burger', 43, 3, 1, 'C:\\Users\\Toshko\\Desktop\\New folder\\4.gif'),
(5, 'Hot-dog', 52, 3, 1, 'C:\\Users\\Toshko\\Desktop\\New folder\\5.gif'),
(6, 'Chicken burger', 35, 3, 1, 'C:\\Users\\Toshko\\Desktop\\New folder\\6.png'),
(7, 'Pizza Salami', 33, 2, 1, 'C:\\Users\\Toshko\\Desktop\\New folder\\7.jpg'),
(8, 'Pizza Margarita', 33, 2.5, 1, 'C:\\Users\\Toshko\\Desktop\\New folder\\8.jpg'),
(9, 'Pizza Muzzarella', 53, 1.5, 1, 'C:\\Users\\Toshko\\Desktop\\New folder\\9.jpg'),
(10, 'Pizza Quatro Cheese', 37, 2, 1, 'C:\\Users\\Toshko\\Desktop\\New folder\\10.png'),
(11, 'Burger King', 5, 0.5, 1, 'C:\\Users\\Toshko\\Desktop\\New folder\\11.jpg'),
(12, 'Burger Meat and Beef', 4, 0.5, 1, 'C:\\Users\\Toshko\\Desktop\\New folder\\12.jpeg'),
(13, 'Coca Cola', 993, 1.5, 0, ''),
(14, 'Bottle Cola', 994, 1.5, 0, ''),
(15, 'Fanta', 1000, 3, 0, ''),
(16, 'Big Fanta Bottle', 997, 2, 0, ''),
(17, 'Yogurt', 1000, 2, 0, ''),
(18, 'Sprite', 997, 2, 0, ''),
(19, 'Water 0.5 Ml', 1000, 2, 0, ''),
(20, 'Water 1 Liter', 999, 2, 0, ''),
(21, 'Heineken Beer', 1000, 2, 0, ''),
(22, 'Bavaria Beer', 999, 2, 0, ''),
(23, 'Coffe', 998, 2, 0, ''),
(24, 'Tea', 994, 2, 0, '');

--
-- Constraints for dumped tables
--

--
-- Constraints for table `campingspot`
--
ALTER TABLE `campingspot`
  ADD CONSTRAINT `fk_CampingSpot_Client1` FOREIGN KEY (`Client_AccountNumber`) REFERENCES `client` (`AccountNumber`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `campingspotguest`
--
ALTER TABLE `campingspotguest`
  ADD CONSTRAINT `fk_ListOfGuest_CampingSpot1` FOREIGN KEY (`CampingSpot_Camp_id`) REFERENCES `campingspot` (`Camp_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_ListOfGuest_Client1` FOREIGN KEY (`Client_AccountNumber`) REFERENCES `client` (`AccountNumber`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `order`
--
ALTER TABLE `order`
  ADD CONSTRAINT `fk_Order_Client1` FOREIGN KEY (`Client_AccountNumber`) REFERENCES `client` (`AccountNumber`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `order_line`
--
ALTER TABLE `order_line`
  ADD CONSTRAINT `fk_Order_line_Material1` FOREIGN KEY (`Material_Material_id`) REFERENCES `material` (`Material_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Order_line_Order1` FOREIGN KEY (`Order_Order_id`) REFERENCES `order` (`Order_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Order_line_Product1` FOREIGN KEY (`Product_Prioduct_id`) REFERENCES `product` (`Prioduct_id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
