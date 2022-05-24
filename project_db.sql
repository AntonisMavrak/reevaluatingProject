-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 24, 2022 at 12:53 PM
-- Server version: 10.4.24-MariaDB
-- PHP Version: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `project_db`
--

DELIMITER $$
--
-- Procedures
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `POMELO_BEFORE_DROP_PRIMARY_KEY` (IN `SCHEMA_NAME_ARGUMENT` VARCHAR(255), IN `TABLE_NAME_ARGUMENT` VARCHAR(255))   BEGIN
	DECLARE HAS_AUTO_INCREMENT_ID TINYINT(1);
	DECLARE PRIMARY_KEY_COLUMN_NAME VARCHAR(255);
	DECLARE PRIMARY_KEY_TYPE VARCHAR(255);
	DECLARE SQL_EXP VARCHAR(1000);
	SELECT COUNT(*)
		INTO HAS_AUTO_INCREMENT_ID
		FROM `information_schema`.`COLUMNS`
		WHERE `TABLE_SCHEMA` = (SELECT IFNULL(SCHEMA_NAME_ARGUMENT, SCHEMA()))
			AND `TABLE_NAME` = TABLE_NAME_ARGUMENT
			AND `Extra` = 'auto_increment'
			AND `COLUMN_KEY` = 'PRI'
			LIMIT 1;
	IF HAS_AUTO_INCREMENT_ID THEN
		SELECT `COLUMN_TYPE`
			INTO PRIMARY_KEY_TYPE
			FROM `information_schema`.`COLUMNS`
			WHERE `TABLE_SCHEMA` = (SELECT IFNULL(SCHEMA_NAME_ARGUMENT, SCHEMA()))
				AND `TABLE_NAME` = TABLE_NAME_ARGUMENT
				AND `COLUMN_KEY` = 'PRI'
			LIMIT 1;
		SELECT `COLUMN_NAME`
			INTO PRIMARY_KEY_COLUMN_NAME
			FROM `information_schema`.`COLUMNS`
			WHERE `TABLE_SCHEMA` = (SELECT IFNULL(SCHEMA_NAME_ARGUMENT, SCHEMA()))
				AND `TABLE_NAME` = TABLE_NAME_ARGUMENT
				AND `COLUMN_KEY` = 'PRI'
			LIMIT 1;
		SET SQL_EXP = CONCAT('ALTER TABLE `', (SELECT IFNULL(SCHEMA_NAME_ARGUMENT, SCHEMA())), '`.`', TABLE_NAME_ARGUMENT, '` MODIFY COLUMN `', PRIMARY_KEY_COLUMN_NAME, '` ', PRIMARY_KEY_TYPE, ' NOT NULL;');
		SET @SQL_EXP = SQL_EXP;
		PREPARE SQL_EXP_EXECUTE FROM @SQL_EXP;
		EXECUTE SQL_EXP_EXECUTE;
		DEALLOCATE PREPARE SQL_EXP_EXECUTE;
	END IF;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `anwsers`
--

CREATE TABLE `anwsers` (
  `id` int(11) NOT NULL,
  `text` longtext NOT NULL,
  `questionId` int(11) NOT NULL,
  `isCorrect` tinyint(1) NOT NULL,
  `CreatedDateTime` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `anwsers`
--

INSERT INTO `anwsers` (`id`, `text`, `questionId`, `isCorrect`, `CreatedDateTime`) VALUES
(1, 'Ο Θεόδωρος', 1, 1, '2022-05-22 21:20:49.986656'),
(2, 'Ο Νίκος', 1, 0, '2022-05-22 21:20:55.827503'),
(3, 'Η Ηλιάννα', 1, 0, '2022-05-22 21:21:01.076316'),
(4, 'Η Μαρία', 1, 0, '2022-05-22 21:21:04.371068'),
(5, 'δφσγηα', 2, 0, '2022-05-22 21:21:58.060250'),
(6, 'ασφδ', 2, 1, '2022-05-22 21:22:00.758399'),
(7, 'γδ', 2, 0, '2022-05-22 21:22:02.699099'),
(8, 'γσαδ', 3, 0, '2022-05-22 21:22:22.745813'),
(9, 'σγδασδγαησφ', 3, 1, '2022-05-22 21:22:26.674244'),
(10, 'ασδγασδγ', 5, 0, '2022-05-22 21:22:50.328809');

-- --------------------------------------------------------

--
-- Table structure for table `branches`
--

CREATE TABLE `branches` (
  `id` int(11) NOT NULL,
  `name` longtext NOT NULL,
  `CreatedDateTime` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `branches`
--

INSERT INTO `branches` (`id`, `name`, `CreatedDateTime`) VALUES
(1, 'Βόρεια', '2022-05-22 21:20:09.404438'),
(2, 'Κέντο', '2022-05-22 21:20:13.045255'),
(3, 'Νότια', '2022-05-22 21:20:17.824944'),
(4, 'Προάστια', '2022-05-22 21:20:21.659448'),
(5, 'Δυτικά', '2022-05-22 21:20:26.253120'),
(6, 'Ανατολικά', '2022-05-22 21:20:33.556105');

-- --------------------------------------------------------

--
-- Table structure for table `questionawsers`
--

CREATE TABLE `questionawsers` (
  `id` int(11) NOT NULL,
  `questionId` int(11) NOT NULL,
  `anwserId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `questions`
--

CREATE TABLE `questions` (
  `id` int(11) NOT NULL,
  `text` longtext NOT NULL,
  `subjectId` int(11) NOT NULL,
  `madeBy` int(11) NOT NULL,
  `CreatedDateTime` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `questions`
--

INSERT INTO `questions` (`id`, `text`, `subjectId`, `madeBy`, `CreatedDateTime`) VALUES
(1, 'Ποίος ήταν ο βασιλειάς της Γεωργίας το 1865', 5, 1, '2022-05-22 21:21:37.367564'),
(2, 'Η ερώτηση 54', 2, 1, '2022-05-22 21:22:15.924450'),
(3, 'Ερώτηση 3', 5, 1, '2022-05-22 21:22:33.642722'),
(4, 'add ασγ', 3, 1, '2022-05-22 21:22:45.130383'),
(5, 'γασδγσαδ', 2, 1, '2022-05-22 21:22:53.834983'),
(6, 'I am a quessgsda', 5, 0, '2022-05-23 19:12:30.408314'),
(7, 'asgdagsd', 3, 0, '2022-05-23 19:12:33.431916'),
(8, 'asgasgd', 3, 0, '2022-05-23 19:12:36.212883'),
(9, 'ashfash', 2, 0, '2022-05-23 19:12:39.392134');

-- --------------------------------------------------------

--
-- Table structure for table `quizquestions`
--

CREATE TABLE `quizquestions` (
  `id` int(11) NOT NULL,
  `quizId` int(11) NOT NULL,
  `questionId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `quizquestions`
--

INSERT INTO `quizquestions` (`id`, `quizId`, `questionId`) VALUES
(3, 1, 4),
(4, 1, 3),
(5, 2, 4),
(6, 2, 2),
(7, 2, 1),
(8, 3, 1),
(9, 3, 2),
(10, 2, 5),
(11, 2, 3),
(12, 7, 1),
(18, 1, 1),
(20, 8, 1),
(23, 6, 1),
(24, 6, 3),
(25, 6, 2),
(26, 6, 4),
(27, 6, 5),
(28, 6, 6),
(29, 6, 7),
(30, 6, 8),
(31, 6, 9);

-- --------------------------------------------------------

--
-- Table structure for table `quizzes`
--

CREATE TABLE `quizzes` (
  `id` int(11) NOT NULL,
  `title` varchar(60) NOT NULL,
  `subjectId` int(11) NOT NULL,
  `minutes` int(11) NOT NULL,
  `numberOfQuestions` int(11) NOT NULL,
  `madeBy` int(11) NOT NULL,
  `CreatedDateTime` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `quizzes`
--

INSERT INTO `quizzes` (`id`, `title`, `subjectId`, `minutes`, `numberOfQuestions`, `madeBy`, `CreatedDateTime`) VALUES
(1, 'I am the quiz', 3, 5, 4, 1, '2022-05-22 21:44:08.923830'),
(6, 'I think it works', 3, 5, 5, 1, '2022-05-23 19:03:49.675525'),
(7, 'One question', 2, 3, 1, 1, '2022-05-22 22:30:54.506221'),
(8, 'gdfs', 2, 34, 0, 1, '2022-05-23 15:19:56.009477');

-- --------------------------------------------------------

--
-- Table structure for table `subjects`
--

CREATE TABLE `subjects` (
  `id` int(11) NOT NULL,
  `name` longtext NOT NULL,
  `CreatedDateTime` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `subjects`
--

INSERT INTO `subjects` (`id`, `name`, `CreatedDateTime`) VALUES
(1, 'Maths', '2022-05-22 21:18:47.562752'),
(2, 'English', '2022-05-22 21:19:09.485141'),
(3, 'Art', '2022-05-22 21:19:15.476787'),
(4, 'Science', '2022-05-22 21:19:18.685023'),
(5, 'History', '2022-05-22 21:19:24.083946'),
(6, 'Music', '2022-05-22 21:19:29.712335'),
(7, 'Geography', '2022-05-22 21:19:35.912333'),
(8, 'P.E (Physical Education)', '2022-05-22 21:19:41.280221'),
(9, 'Biology', '2022-05-22 21:19:46.943465'),
(10, 'I.T (Information Technology)', '2022-05-22 21:19:54.495312');

-- --------------------------------------------------------

--
-- Table structure for table `userconnectssubjects`
--

CREATE TABLE `userconnectssubjects` (
  `id` int(11) NOT NULL,
  `userId` int(11) NOT NULL,
  `subjectId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `first_name` longtext NOT NULL,
  `last_name` longtext NOT NULL,
  `email` varchar(150) NOT NULL,
  `password` varchar(150) NOT NULL,
  `username` longtext NOT NULL,
  `role` int(11) NOT NULL,
  `validated` tinyint(1) NOT NULL,
  `branchId` int(11) NOT NULL,
  `CreatedDateTime` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `first_name`, `last_name`, `email`, `password`, `username`, `role`, `validated`, `branchId`, `CreatedDateTime`) VALUES
(1, 'Antonios', 'Mavrakis', 'antonis@mavrakis.com', 'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', 'antonismavrakis', 6, 0, 0, '2022-05-22 22:16:27.165930');

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20220522181643_Second', '6.0.5');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `anwsers`
--
ALTER TABLE `anwsers`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `branches`
--
ALTER TABLE `branches`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `questionawsers`
--
ALTER TABLE `questionawsers`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `questions`
--
ALTER TABLE `questions`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `quizquestions`
--
ALTER TABLE `quizquestions`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `quizzes`
--
ALTER TABLE `quizzes`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `subjects`
--
ALTER TABLE `subjects`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `userconnectssubjects`
--
ALTER TABLE `userconnectssubjects`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`) USING HASH;

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `anwsers`
--
ALTER TABLE `anwsers`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `branches`
--
ALTER TABLE `branches`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `questionawsers`
--
ALTER TABLE `questionawsers`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `questions`
--
ALTER TABLE `questions`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `quizquestions`
--
ALTER TABLE `quizquestions`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=32;

--
-- AUTO_INCREMENT for table `quizzes`
--
ALTER TABLE `quizzes`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `subjects`
--
ALTER TABLE `subjects`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `userconnectssubjects`
--
ALTER TABLE `userconnectssubjects`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
