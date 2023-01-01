-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Värd: 127.0.0.1
-- Tid vid skapande: 01 jan 2023 kl 16:52
-- Serverversion: 10.4.25-MariaDB
-- PHP-version: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Databas: `mini_operan`
--

DELIMITER $$
--
-- Procedurer
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertPassword` (IN `newpassword` VARCHAR(32), IN `id` INT(32))   BEGIN
	UPDATE customers SET password = newpassword WHERE customers.id = id;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Tabellstruktur `customers`
--

CREATE TABLE `customers` (
  `id` int(32) NOT NULL,
  `first_name` varchar(32) NOT NULL,
  `last_name` varchar(32) NOT NULL,
  `email` varchar(32) NOT NULL,
  `phonenumber` varchar(32) NOT NULL,
  `password` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumpning av Data i tabell `customers`
--

INSERT INTO `customers` (`id`, `first_name`, `last_name`, `email`, `phonenumber`, `password`) VALUES
(1, 'Krister', 'Trangius', 'apa123@mail.com', '0701020371', 'tr@ngis@urius123'),
(2, 'Gustav', 'Bodell', 'gusbod@mail.com', '0703726318', ''),
(3, 'Elin', 'Nyman', 'elinym@mail.com', '0702736125', ''),
(4, 'Ariel', 'Sjövåg', 'mermaid@mail.com', '0702837126', ''),
(5, 'Eira', 'Snöflinga', 'eirisen@mail.com', '0702738126', ''),
(6, 'Robin', 'Katt', 'kissemiss@mjau.com', '070372816', 'huml@2016'),
(7, 'Mimmi', 'Pigg', 'mimmi.pigg@mail.com', '0702736157', 'mortimer<3mus'),
(8, 'Daniel', 'Johannesson', 'dajo@mail.com', '0703726194', ''),
(9, 'Rick', 'Sanchez', 'picklerick@mail.com', '0702726615', 'wubbalubbadub2'),
(10, 'Grogu', 'Yoda', 'baby_yoda@mail.com', '0706527318', ''),
(11, 'Elin', 'Nyman', 'nyman@mail.com', '0702726612', ''),
(12, 'Gramse', 'Bumbibjörn', 'gramse@bumbi.com', '0703726619', ''),
(13, 'Tomten', 'Nikolaus', 'hohoho@mail.com', '0708692637', 'bad$anta'),
(14, 'Grinchen', 'Who', 'grinchen@mail.com', '0702642918', 'm@xdog'),
(15, 'Ebenezer', 'Scrooge', 'scrooge.eb@mail.com', '0706124528', 'humbug');

-- --------------------------------------------------------

--
-- Tabellstruktur `performers`
--

CREATE TABLE `performers` (
  `id` int(32) NOT NULL,
  `first_name` varchar(32) NOT NULL,
  `last_name` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumpning av Data i tabell `performers`
--

INSERT INTO `performers` (`id`, `first_name`, `last_name`) VALUES
(1, 'Fred', 'Johansson'),
(2, 'Joa', 'Helgesson'),
(3, 'Sofie', 'Asplund'),
(4, 'Frida', 'Engström'),
(5, 'John Martin', 'Bengtsson'),
(6, 'Tobias', 'Ahlsell'),
(7, 'David', 'Lundqvist'),
(8, 'Anders', 'Wängdahl'),
(9, 'Karolina', 'Andersson'),
(10, 'Mia', 'Karlsson'),
(11, 'Iwar', 'Bergkwist'),
(12, 'Erika', 'Sax'),
(13, 'Peter', 'Loguin'),
(14, 'Aaron', 'Elijah'),
(15, 'Sebastian', 'Goffin'),
(16, 'Shakeel', 'Kimotho'),
(17, 'Jacinta', 'Whyte'),
(18, 'Hal', 'Fowler'),
(19, 'Lottie', 'Stephens'),
(20, 'Sarah-Marie', 'Maxwell'),
(21, 'Martin', 'Callaghan'),
(22, 'Milan', 'Cacacie'),
(23, 'Ed', 'Wade'),
(24, 'Maiya', 'Hikasa'),
(25, 'Julian', 'Bigg'),
(26, 'John', 'Williams'),
(27, 'Anton', 'Lundqvist'),
(28, 'Andreas T', 'Olsson'),
(29, 'Per', 'Andersson'),
(30, 'Pernilla', 'Wahlgren'),
(31, 'Ola', 'Forssmed'),
(32, 'Hampus', 'Nessvold'),
(33, 'Clara', 'Henry'),
(34, 'David', 'Batra');

-- --------------------------------------------------------

--
-- Tabellstruktur `reservations`
--

CREATE TABLE `reservations` (
  `id` int(32) NOT NULL,
  `customer_id` int(32) NOT NULL,
  `shows_dates_id` int(32) NOT NULL,
  `shows_id` int(32) NOT NULL,
  `price` int(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumpning av Data i tabell `reservations`
--

INSERT INTO `reservations` (`id`, `customer_id`, `shows_dates_id`, `shows_id`, `price`) VALUES
(1, 6, 17, 2, 2250),
(3, 4, 17, 2, 900),
(4, 4, 17, 2, 900),
(5, 4, 17, 2, 900),
(6, 4, 17, 2, 1350),
(7, 4, 17, 2, 1350),
(8, 4, 17, 2, 1350),
(9, 12, 17, 2, 2700),
(10, 12, 17, 2, 2700),
(11, 12, 17, 2, 2700),
(12, 12, 17, 2, 450),
(13, 12, 17, 2, 900),
(14, 12, 17, 2, 900),
(15, 13, 17, 2, 900),
(16, 12, 17, 2, 2700),
(17, 12, 17, 2, 2700),
(18, 12, 17, 2, 2700),
(19, 3, 49, 4, 1800),
(20, 12, 49, 4, 2700),
(21, 6, 49, 4, 900),
(22, 9, 33, 3, 1350),
(23, 10, 41, 3, 900),
(24, 10, 37, 3, 900),
(25, 10, 33, 3, 900),
(26, 3, 46, 4, 1800),
(27, 7, 34, 3, 900),
(28, 7, 36, 3, 450),
(29, 7, 26, 2, 900),
(30, 1, 50, 4, 1350),
(31, 14, 46, 4, 1800),
(32, 15, 5, 1, 2250),
(33, 6, 25, 2, 2700),
(34, 6, 44, 3, 2250),
(35, 6, 51, 4, 2250),
(36, 6, 59, 4, 2700),
(37, 6, 1, 1, 2250),
(38, 6, 16, 2, 450),
(39, 6, 58, 4, 2250),
(41, 6, 16, 2, 2250);

-- --------------------------------------------------------

--
-- Tabellstruktur `roles`
--

CREATE TABLE `roles` (
  `id` int(32) NOT NULL,
  `name` varchar(32) NOT NULL,
  `shows_id` int(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumpning av Data i tabell `roles`
--

INSERT INTO `roles` (`id`, `name`, `shows_id`) VALUES
(1, 'The Phantom', 1),
(2, 'Christine Daaé', 1),
(3, 'Raoul, Greve de Chagny', 1),
(4, 'Monsieur Firmin', 1),
(5, 'Monsieur André', 1),
(6, 'Charlotta Giudicelli', 1),
(7, 'Ubaldo Piangi', 1),
(8, 'Madame Giry', 1),
(9, 'Don Attilo', 1),
(10, 'Admetus', 2),
(11, 'Alonzo', 2),
(12, 'Coricopat', 2),
(13, 'Grizabella', 2),
(14, 'Rumpus cat', 2),
(15, 'Jemima', 2),
(16, 'Gumbie cat', 2),
(17, 'Old Deuteronomy', 2),
(18, 'Tantomile', 2),
(19, 'Rum Tum Tugger', 2),
(20, 'White cat', 2),
(21, 'Conductor', 3),
(22, 'Composer', 3),
(23, 'Peter Pan', 4),
(24, 'Storyteller', 4),
(25, 'Peter Pans shadow', 4),
(26, 'Tingeling', 4),
(27, 'Captene Hook', 4),
(28, 'The Crocodile', 4),
(29, 'Wendy Darling', 4),
(30, 'John Darling', 4);

-- --------------------------------------------------------

--
-- Tabellstruktur `roles_to_performers`
--

CREATE TABLE `roles_to_performers` (
  `roles_id` int(32) NOT NULL,
  `performers_id` int(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumpning av Data i tabell `roles_to_performers`
--

INSERT INTO `roles_to_performers` (`roles_id`, `performers_id`) VALUES
(1, 1),
(1, 2),
(2, 3),
(2, 4),
(3, 5),
(3, 6),
(4, 7),
(5, 8),
(6, 9),
(6, 10),
(7, 11),
(8, 12),
(9, 13),
(10, 14),
(11, 15),
(12, 16),
(13, 17),
(14, 18),
(15, 19),
(16, 20),
(17, 21),
(18, 22),
(19, 23),
(20, 24),
(21, 25),
(22, 26),
(23, 27),
(24, 28),
(25, 29),
(26, 30),
(27, 31),
(28, 32),
(29, 33),
(30, 34);

-- --------------------------------------------------------

--
-- Tabellstruktur `seats`
--

CREATE TABLE `seats` (
  `id` int(32) NOT NULL,
  `section` varchar(32) NOT NULL,
  `row` int(32) NOT NULL,
  `price` int(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumpning av Data i tabell `seats`
--

INSERT INTO `seats` (`id`, `section`, `row`, `price`) VALUES
(1, 'Parkett', 1, 450),
(2, 'Parkett', 1, 450),
(3, 'Parkett', 1, 450),
(4, 'Parkett', 1, 450),
(5, 'Parkett', 1, 450),
(6, 'Parkett', 1, 450),
(7, 'Parkett', 2, 450),
(8, 'Parkett', 2, 450),
(9, 'Parkett', 2, 450),
(10, 'Parkett', 2, 450),
(11, 'Parkett', 2, 450),
(12, 'Parkett', 2, 450),
(13, 'Parkett', 3, 450),
(14, 'Parkett', 3, 450),
(15, 'Parkett', 3, 450),
(16, 'Parkett', 3, 450),
(17, 'Parkett', 3, 450),
(18, 'Parkett', 3, 450),
(19, 'Parkett', 4, 450),
(20, 'Parkett', 4, 450),
(21, 'Parkett', 4, 450),
(22, 'Parkett', 4, 450),
(23, 'Parkett', 4, 450),
(24, 'Parkett', 4, 450),
(25, 'Parkett', 5, 450),
(26, 'Parkett', 5, 450),
(27, 'Parkett', 5, 450),
(28, 'Parkett', 5, 450),
(29, 'Parkett', 5, 450),
(30, 'Parkett', 5, 450),
(31, 'Parkett', 6, 450),
(32, 'Parkett', 6, 450),
(33, 'Parkett', 6, 450),
(34, 'Parkett', 6, 450),
(35, 'Parkett', 6, 450),
(36, 'Parkett', 6, 450),
(37, 'Balkong A', 1, 380),
(38, 'Balkong A', 1, 380),
(39, 'Balkong A', 1, 380),
(40, 'Balkong A', 1, 380),
(41, 'Balkong A', 1, 380),
(42, 'Balkong A', 1, 380),
(43, 'Balkong A', 1, 380),
(44, 'Balkong B', 1, 380),
(45, 'Balkong B', 1, 380),
(46, 'Balkong B', 1, 380),
(47, 'Balkong B', 1, 380),
(48, 'Balkong B', 1, 380),
(49, 'Balkong B', 1, 380),
(50, 'Balkong B', 1, 380),
(51, 'Balkong B', 1, 380),
(52, 'Balkong B', 1, 380),
(53, 'Balkong B', 1, 380),
(54, 'Balkong B', 1, 380),
(55, 'Balkong C', 1, 380),
(56, 'Balkong C', 1, 380),
(57, 'Balkong C', 1, 380),
(58, 'Balkong C', 1, 380),
(59, 'Balkong C', 1, 380),
(60, 'Balkong C', 1, 380),
(61, 'Balkong C', 1, 380),
(62, 'Balkong C', 1, 350),
(63, 'Balkong C', 1, 350),
(64, 'Balkong C', 1, 350),
(65, 'Balkong C', 1, 350),
(66, 'Balkong C', 1, 350),
(67, 'Balkong C', 1, 350),
(68, 'Balkong C', 1, 350),
(69, 'Balkong B', 1, 350),
(70, 'Balkong B', 1, 350),
(71, 'Balkong B', 1, 350),
(72, 'Balkong B', 1, 350),
(73, 'Balkong B', 1, 350),
(74, 'Balkong B', 1, 350),
(75, 'Balkong B', 1, 350),
(76, 'Balkong B', 1, 350),
(77, 'Balkong B', 1, 350),
(78, 'Balkong B', 1, 350),
(79, 'Balkong B', 1, 350),
(80, 'Balkong A', 1, 350),
(81, 'Balkong A', 1, 350),
(82, 'Balkong A', 1, 350),
(83, 'Balkong A', 1, 350),
(84, 'Balkong A', 1, 350),
(85, 'Balkong A', 1, 350),
(86, 'Balkong A', 1, 350);

-- --------------------------------------------------------

--
-- Tabellstruktur `seats_to_reservations`
--

CREATE TABLE `seats_to_reservations` (
  `seats_id` int(32) NOT NULL,
  `reservation_id` int(32) NOT NULL,
  `shows_dates_id` int(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumpning av Data i tabell `seats_to_reservations`
--

INSERT INTO `seats_to_reservations` (`seats_id`, `reservation_id`, `shows_dates_id`) VALUES
(13, 1, 17),
(14, 1, 17),
(15, 1, 17),
(16, 1, 17),
(17, 1, 17),
(10, 5, 17),
(11, 5, 17),
(12, 5, 17),
(28, 12, 17),
(19, 18, 17),
(20, 18, 17),
(21, 18, 17),
(22, 18, 17),
(23, 18, 17),
(24, 18, 17),
(19, 19, 49),
(20, 19, 49),
(21, 19, 49),
(22, 19, 49),
(9, 20, 49),
(10, 20, 49),
(11, 20, 49),
(12, 20, 49),
(8, 20, 49),
(7, 20, 49),
(35, 21, 49),
(36, 21, 49),
(9, 22, 33),
(10, 22, 33),
(11, 22, 33),
(36, 23, 41),
(35, 23, 41),
(15, 24, 37),
(16, 24, 37),
(19, 25, 33),
(20, 25, 33),
(13, 26, 46),
(14, 26, 46),
(15, 26, 46),
(16, 26, 46),
(16, 27, 34),
(15, 27, 34),
(13, 28, 36),
(8, 29, 26),
(9, 29, 26),
(15, 30, 50),
(16, 30, 50),
(17, 30, 50),
(8, 31, 46),
(9, 31, 46),
(10, 31, 46),
(11, 31, 46),
(26, 32, 5),
(27, 32, 5),
(28, 32, 5),
(29, 32, 5),
(30, 32, 5),
(1, 33, 25),
(2, 33, 25),
(3, 33, 25),
(4, 33, 25),
(5, 33, 25),
(6, 33, 25),
(14, 34, 44),
(15, 34, 44),
(16, 34, 44),
(17, 34, 44),
(18, 34, 44),
(7, 35, 51),
(8, 35, 51),
(9, 35, 51),
(10, 35, 51),
(11, 35, 51),
(1, 36, 59),
(2, 36, 59),
(3, 36, 59),
(4, 36, 59),
(5, 36, 59),
(6, 36, 59),
(25, 37, 1),
(26, 37, 1),
(27, 37, 1),
(28, 37, 1),
(29, 37, 1),
(1, 38, 16),
(1, 39, 58),
(2, 39, 58),
(3, 39, 58),
(4, 39, 58),
(5, 39, 58),
(2, 41, 16),
(3, 41, 16),
(4, 41, 16),
(5, 41, 16),
(6, 41, 16);

-- --------------------------------------------------------

--
-- Tabellstruktur `shows`
--

CREATE TABLE `shows` (
  `id` int(32) NOT NULL,
  `title` varchar(64) NOT NULL,
  `type` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumpning av Data i tabell `shows`
--

INSERT INTO `shows` (`id`, `title`, `type`) VALUES
(1, 'Phantom of the Opera', 'Musical'),
(2, 'Cats', 'Musical'),
(3, 'Star Wars : The Empire Strikes Back', 'Live Concert'),
(4, 'Peter Pan går åt helvete', 'Teater');

-- --------------------------------------------------------

--
-- Tabellstruktur `show_dates`
--

CREATE TABLE `show_dates` (
  `dateid` int(32) NOT NULL,
  `date` date NOT NULL,
  `time` time(6) NOT NULL,
  `shows_id` int(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumpning av Data i tabell `show_dates`
--

INSERT INTO `show_dates` (`dateid`, `date`, `time`, `shows_id`) VALUES
(1, '2023-01-13', '18:00:00.000000', 1),
(2, '2023-01-14', '15:00:00.000000', 1),
(3, '2023-01-14', '18:00:00.000000', 1),
(4, '2023-01-15', '15:00:00.000000', 1),
(5, '2023-01-15', '18:00:00.000000', 1),
(6, '2023-01-20', '18:00:00.000000', 1),
(7, '2023-01-21', '15:00:00.000000', 1),
(8, '2023-01-21', '18:00:00.000000', 1),
(9, '2023-01-22', '15:00:00.000000', 1),
(10, '2023-01-22', '18:00:00.000000', 1),
(11, '2023-01-27', '18:00:00.000000', 1),
(12, '2023-01-28', '15:00:00.000000', 1),
(13, '2023-01-28', '18:00:00.000000', 1),
(14, '2023-01-29', '15:00:00.000000', 1),
(15, '2023-01-29', '18:00:00.000000', 1),
(16, '2023-02-10', '18:00:00.000000', 2),
(17, '2023-02-11', '15:00:00.000000', 2),
(18, '2023-02-11', '18:00:00.000000', 2),
(19, '2023-02-12', '15:00:00.000000', 2),
(20, '2023-02-12', '18:00:00.000000', 2),
(21, '2023-02-17', '18:00:00.000000', 2),
(22, '2023-02-18', '15:00:00.000000', 2),
(23, '2023-02-18', '18:00:00.000000', 2),
(24, '2023-02-19', '15:00:00.000000', 2),
(25, '2023-02-19', '18:00:00.000000', 2),
(26, '2023-02-24', '18:00:00.000000', 2),
(27, '2023-02-25', '15:00:00.000000', 2),
(28, '2023-02-25', '18:00:00.000000', 2),
(29, '2023-02-26', '15:00:00.000000', 2),
(30, '2023-02-26', '18:00:00.000000', 2),
(31, '2023-03-10', '18:00:00.000000', 3),
(32, '2023-03-11', '15:00:00.000000', 3),
(33, '2023-03-11', '18:00:00.000000', 3),
(34, '2023-03-12', '15:00:00.000000', 3),
(35, '2023-03-12', '18:00:00.000000', 3),
(36, '2023-03-17', '18:00:00.000000', 3),
(37, '2023-03-18', '15:00:00.000000', 3),
(38, '2023-03-18', '18:00:00.000000', 3),
(39, '2023-03-19', '15:00:00.000000', 3),
(40, '2023-03-19', '18:00:00.000000', 3),
(41, '2023-03-24', '18:00:00.000000', 3),
(42, '2023-03-25', '15:00:00.000000', 3),
(43, '2023-03-25', '18:00:00.000000', 3),
(44, '2023-03-26', '15:00:00.000000', 3),
(45, '2023-03-26', '18:00:00.000000', 3),
(46, '2023-04-14', '18:00:00.000000', 4),
(47, '2023-04-15', '15:00:00.000000', 4),
(48, '2023-04-15', '18:00:00.000000', 4),
(49, '2023-04-16', '15:00:00.000000', 4),
(50, '2023-04-16', '18:00:00.000000', 4),
(51, '2023-04-21', '18:00:00.000000', 4),
(52, '2023-04-22', '15:00:00.000000', 4),
(53, '2023-04-22', '18:00:00.000000', 4),
(54, '2023-04-23', '15:00:00.000000', 4),
(55, '2023-04-23', '18:00:00.000000', 4),
(56, '2023-04-28', '18:00:00.000000', 4),
(57, '2023-04-29', '15:00:00.000000', 4),
(58, '2023-04-29', '18:00:00.000000', 4),
(59, '2023-04-30', '15:00:00.000000', 4),
(60, '2023-04-30', '18:00:00.000000', 4);

--
-- Index för dumpade tabeller
--

--
-- Index för tabell `customers`
--
ALTER TABLE `customers`
  ADD PRIMARY KEY (`id`);

--
-- Index för tabell `performers`
--
ALTER TABLE `performers`
  ADD PRIMARY KEY (`id`);

--
-- Index för tabell `reservations`
--
ALTER TABLE `reservations`
  ADD PRIMARY KEY (`id`),
  ADD KEY `customer_id` (`customer_id`),
  ADD KEY `shows_dates_id` (`shows_dates_id`),
  ADD KEY `shows_id` (`shows_id`);

--
-- Index för tabell `roles`
--
ALTER TABLE `roles`
  ADD PRIMARY KEY (`id`),
  ADD KEY `shows_id` (`shows_id`);

--
-- Index för tabell `roles_to_performers`
--
ALTER TABLE `roles_to_performers`
  ADD KEY `performers_id` (`performers_id`),
  ADD KEY `roles_id` (`roles_id`);

--
-- Index för tabell `seats`
--
ALTER TABLE `seats`
  ADD PRIMARY KEY (`id`);

--
-- Index för tabell `seats_to_reservations`
--
ALTER TABLE `seats_to_reservations`
  ADD KEY `reservation_id` (`reservation_id`),
  ADD KEY `seats_id` (`seats_id`),
  ADD KEY `shows_dates_id` (`shows_dates_id`);

--
-- Index för tabell `shows`
--
ALTER TABLE `shows`
  ADD PRIMARY KEY (`id`);

--
-- Index för tabell `show_dates`
--
ALTER TABLE `show_dates`
  ADD PRIMARY KEY (`dateid`),
  ADD KEY `shows_id` (`shows_id`);

--
-- AUTO_INCREMENT för dumpade tabeller
--

--
-- AUTO_INCREMENT för tabell `customers`
--
ALTER TABLE `customers`
  MODIFY `id` int(32) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT för tabell `performers`
--
ALTER TABLE `performers`
  MODIFY `id` int(32) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=35;

--
-- AUTO_INCREMENT för tabell `reservations`
--
ALTER TABLE `reservations`
  MODIFY `id` int(32) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=44;

--
-- AUTO_INCREMENT för tabell `roles`
--
ALTER TABLE `roles`
  MODIFY `id` int(32) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- AUTO_INCREMENT för tabell `seats`
--
ALTER TABLE `seats`
  MODIFY `id` int(32) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=87;

--
-- AUTO_INCREMENT för tabell `shows`
--
ALTER TABLE `shows`
  MODIFY `id` int(32) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT för tabell `show_dates`
--
ALTER TABLE `show_dates`
  MODIFY `dateid` int(32) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=61;

--
-- Restriktioner för dumpade tabeller
--

--
-- Restriktioner för tabell `reservations`
--
ALTER TABLE `reservations`
  ADD CONSTRAINT `reservations_ibfk_1` FOREIGN KEY (`customer_id`) REFERENCES `customers` (`id`),
  ADD CONSTRAINT `reservations_ibfk_2` FOREIGN KEY (`shows_dates_id`) REFERENCES `show_dates` (`dateid`),
  ADD CONSTRAINT `reservations_ibfk_3` FOREIGN KEY (`shows_id`) REFERENCES `shows` (`id`);

--
-- Restriktioner för tabell `roles`
--
ALTER TABLE `roles`
  ADD CONSTRAINT `roles_ibfk_1` FOREIGN KEY (`shows_id`) REFERENCES `shows` (`id`);

--
-- Restriktioner för tabell `roles_to_performers`
--
ALTER TABLE `roles_to_performers`
  ADD CONSTRAINT `roles_to_performers_ibfk_1` FOREIGN KEY (`performers_id`) REFERENCES `performers` (`id`),
  ADD CONSTRAINT `roles_to_performers_ibfk_2` FOREIGN KEY (`roles_id`) REFERENCES `roles` (`id`);

--
-- Restriktioner för tabell `seats_to_reservations`
--
ALTER TABLE `seats_to_reservations`
  ADD CONSTRAINT `seats_to_reservations_ibfk_1` FOREIGN KEY (`reservation_id`) REFERENCES `reservations` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `seats_to_reservations_ibfk_2` FOREIGN KEY (`seats_id`) REFERENCES `seats` (`id`),
  ADD CONSTRAINT `seats_to_reservations_ibfk_3` FOREIGN KEY (`shows_dates_id`) REFERENCES `show_dates` (`dateid`);

--
-- Restriktioner för tabell `show_dates`
--
ALTER TABLE `show_dates`
  ADD CONSTRAINT `show_dates_ibfk_1` FOREIGN KEY (`shows_id`) REFERENCES `shows` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
