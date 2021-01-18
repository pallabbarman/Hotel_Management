-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 18, 2021 at 11:21 AM
-- Server version: 10.4.8-MariaDB
-- PHP Version: 7.3.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `hotel_management`
--

-- --------------------------------------------------------

--
-- Table structure for table `clients`
--

CREATE TABLE `clients` (
  `Clientid` int(11) NOT NULL,
  `Firstname` varchar(100) NOT NULL,
  `Lastname` varchar(100) NOT NULL,
  `Phone` int(11) NOT NULL,
  `Country` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `clients`
--

INSERT INTO `clients` (`Clientid`, `Firstname`, `Lastname`, `Phone`, `Country`) VALUES
(5, 'Ganesh', 'Gaitonde', 2147483647, 'India'),
(6, 'Heisenberg', 'Walt', 213547865, 'America'),
(7, 'Arthur', 'Fleck', 754123658, 'America'),
(8, 'Scooby', 'Doo', 214589635, 'America'),
(9, 'Professor', 'Álvaro', 456321789, 'Spain'),
(10, 'Jhon', 'Wick', 12365478, 'America'),
(12, 'arthur', 'fleck', 754123658, 'amero'),
(13, 'arthur', 'fleck', 754123658, 'amero');

-- --------------------------------------------------------

--
-- Table structure for table `menu`
--

CREATE TABLE `menu` (
  `biriyani` int(11) NOT NULL,
  `bread` int(11) NOT NULL,
  `water` int(11) NOT NULL,
  `drinks` int(11) NOT NULL,
  `tandori` int(11) NOT NULL,
  `sweet` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `reports`
--

CREATE TABLE `reports` (
  `id` int(11) NOT NULL,
  `report` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `reservation`
--

CREATE TABLE `reservation` (
  `Reservid` int(11) NOT NULL,
  `Roomno` int(11) NOT NULL,
  `Clientid` int(11) NOT NULL,
  `Payment` varchar(100) NOT NULL,
  `Datein` date NOT NULL,
  `Dateout` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `reservation`
--

INSERT INTO `reservation` (`Reservid`, `Roomno`, `Clientid`, `Payment`, `Datein`, `Dateout`) VALUES
(4, 1, 5, '2000', '2020-01-14', '2020-01-20'),
(5, 6, 6, '4000', '2020-01-15', '2020-01-18'),
(6, 11, 7, '8000', '2020-01-14', '2020-01-30'),
(7, 16, 8, '15000', '2020-01-14', '2020-01-31');

-- --------------------------------------------------------

--
-- Table structure for table `rooms`
--

CREATE TABLE `rooms` (
  `Roomno` int(11) NOT NULL,
  `Type` int(11) NOT NULL,
  `Free` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `rooms`
--

INSERT INTO `rooms` (`Roomno`, `Type`, `Free`) VALUES
(1, 1, 'No'),
(2, 1, 'Yes'),
(3, 1, 'Yes'),
(4, 1, 'Yes'),
(5, 1, 'Yes'),
(6, 2, 'No'),
(7, 2, 'No'),
(8, 2, 'Yes'),
(9, 2, 'Yes'),
(10, 2, 'Yes'),
(11, 3, 'No'),
(12, 3, 'Yes'),
(13, 3, 'Yes'),
(14, 3, 'Yes'),
(15, 3, 'Yes'),
(16, 4, 'No'),
(17, 4, 'Yes'),
(18, 4, 'Yes'),
(19, 4, 'Yes'),
(20, 4, 'Yes'),
(21, 4, 'Yes');

-- --------------------------------------------------------

--
-- Table structure for table `rooms_category`
--

CREATE TABLE `rooms_category` (
  `Type` int(11) NOT NULL,
  `Label` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `rooms_category`
--

INSERT INTO `rooms_category` (`Type`, `Label`) VALUES
(1, 'single'),
(2, 'double'),
(3, 'family'),
(4, 'suite');

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `Id` int(11) NOT NULL,
  `Firstname` varchar(100) NOT NULL,
  `Lastname` varchar(100) NOT NULL,
  `Email` text NOT NULL,
  `Username` varchar(100) NOT NULL,
  `Password` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`Id`, `Firstname`, `Lastname`, `Email`, `Username`, `Password`) VALUES
(1, 'user', 'user', 'user@gmail.com', 'user', 'user'),
(2, 'Ganesh', 'Gaitonde', 'gaito@gmail.com', 'gaito', 'gaito');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`Clientid`);

--
-- Indexes for table `menu`
--
ALTER TABLE `menu`
  ADD PRIMARY KEY (`biriyani`);

--
-- Indexes for table `reports`
--
ALTER TABLE `reports`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `reservation`
--
ALTER TABLE `reservation`
  ADD PRIMARY KEY (`Reservid`),
  ADD KEY `fk_room_number` (`Roomno`),
  ADD KEY `fk_client_id` (`Clientid`);

--
-- Indexes for table `rooms`
--
ALTER TABLE `rooms`
  ADD PRIMARY KEY (`Roomno`),
  ADD KEY `fk_type_id` (`Type`);

--
-- Indexes for table `rooms_category`
--
ALTER TABLE `rooms_category`
  ADD PRIMARY KEY (`Type`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`Id`,`Username`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `clients`
--
ALTER TABLE `clients`
  MODIFY `Clientid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `menu`
--
ALTER TABLE `menu`
  MODIFY `biriyani` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `reports`
--
ALTER TABLE `reports`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `reservation`
--
ALTER TABLE `reservation`
  MODIFY `Reservid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `rooms`
--
ALTER TABLE `rooms`
  MODIFY `Roomno` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT for table `rooms_category`
--
ALTER TABLE `rooms_category`
  MODIFY `Type` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `reservation`
--
ALTER TABLE `reservation`
  ADD CONSTRAINT `fk_client_id` FOREIGN KEY (`clientid`) REFERENCES `clients` (`Clientid`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_room_number` FOREIGN KEY (`roomno`) REFERENCES `rooms` (`Roomno`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `rooms`
--
ALTER TABLE `rooms`
  ADD CONSTRAINT `fk_type_id` FOREIGN KEY (`Type`) REFERENCES `rooms_category` (`Type`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
