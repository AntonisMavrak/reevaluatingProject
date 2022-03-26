-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Φιλοξενητής: 127.0.0.1
-- Χρόνος δημιουργίας: 26 Μαρ 2022 στις 12:47:13
-- Έκδοση διακομιστή: 10.4.13-MariaDB
-- Έκδοση PHP: 7.4.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Βάση δεδομένων: `project_db`
--

-- --------------------------------------------------------

--
-- Δομή πίνακα για τον πίνακα `answer`
--

CREATE TABLE `answer` (
  `id` int(11) NOT NULL,
  `question_id` int(11) NOT NULL,
  `answer` varchar(50) NOT NULL,
  `thema_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Δομή πίνακα για τον πίνακα `mathima`
--

CREATE TABLE `mathima` (
  `id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Δομή πίνακα για τον πίνακα `questions`
--

CREATE TABLE `questions` (
  `id` int(11) NOT NULL,
  `title` varchar(30) NOT NULL,
  `body` varchar(250) NOT NULL,
  `corrct_answer` int(11) NOT NULL,
  `thema_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Δομή πίνακα για τον πίνακα `quiz`
--

CREATE TABLE `quiz` (
  `id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL,
  `thema_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Δομή πίνακα για τον πίνακα `thema`
--

CREATE TABLE `thema` (
  `id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL,
  `thema_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Δομή πίνακα για τον πίνακα `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `first_name` int(25) NOT NULL,
  `last_name` int(25) NOT NULL,
  `username` varchar(25) NOT NULL,
  `password` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL,
  `role` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Δομή πίνακα για τον πίνακα `users_grades`
--

CREATE TABLE `users_grades` (
  `id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `quiz_id` int(11) NOT NULL,
  `mathima_id` int(11) NOT NULL,
  `grade` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Δομή πίνακα για τον πίνακα `user_subjects`
--

CREATE TABLE `user_subjects` (
  `id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `mathima_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Ευρετήρια για άχρηστους πίνακες
--

--
-- Ευρετήρια για πίνακα `answer`
--
ALTER TABLE `answer`
  ADD PRIMARY KEY (`id`),
  ADD KEY `thema_id2` (`thema_id`),
  ADD KEY `question_id` (`question_id`);

--
-- Ευρετήρια για πίνακα `mathima`
--
ALTER TABLE `mathima`
  ADD PRIMARY KEY (`id`);

--
-- Ευρετήρια για πίνακα `questions`
--
ALTER TABLE `questions`
  ADD PRIMARY KEY (`id`),
  ADD KEY `questions` (`thema_id`),
  ADD KEY `corrct_answer` (`corrct_answer`);

--
-- Ευρετήρια για πίνακα `quiz`
--
ALTER TABLE `quiz`
  ADD PRIMARY KEY (`id`),
  ADD KEY `thema_idQuiz` (`thema_id`);

--
-- Ευρετήρια για πίνακα `thema`
--
ALTER TABLE `thema`
  ADD PRIMARY KEY (`id`),
  ADD KEY `mathima_connect` (`thema_id`);

--
-- Ευρετήρια για πίνακα `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- Ευρετήρια για πίνακα `users_grades`
--
ALTER TABLE `users_grades`
  ADD PRIMARY KEY (`id`),
  ADD KEY `grades` (`user_id`),
  ADD KEY `quiz_id` (`quiz_id`),
  ADD KEY `mathima_id` (`mathima_id`);

--
-- Ευρετήρια για πίνακα `user_subjects`
--
ALTER TABLE `user_subjects`
  ADD PRIMARY KEY (`id`),
  ADD KEY `user_id` (`user_id`),
  ADD KEY `mathima_id_subjTab` (`mathima_id`);

--
-- AUTO_INCREMENT για άχρηστους πίνακες
--

--
-- AUTO_INCREMENT για πίνακα `answer`
--
ALTER TABLE `answer`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT για πίνακα `mathima`
--
ALTER TABLE `mathima`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT για πίνακα `questions`
--
ALTER TABLE `questions`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT για πίνακα `quiz`
--
ALTER TABLE `quiz`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT για πίνακα `thema`
--
ALTER TABLE `thema`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT για πίνακα `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT για πίνακα `users_grades`
--
ALTER TABLE `users_grades`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT για πίνακα `user_subjects`
--
ALTER TABLE `user_subjects`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Περιορισμοί για άχρηστους πίνακες
--

--
-- Περιορισμοί για πίνακα `answer`
--
ALTER TABLE `answer`
  ADD CONSTRAINT `question_id` FOREIGN KEY (`question_id`) REFERENCES `questions` (`id`),
  ADD CONSTRAINT `thema_id2` FOREIGN KEY (`thema_id`) REFERENCES `thema` (`id`);

--
-- Περιορισμοί για πίνακα `questions`
--
ALTER TABLE `questions`
  ADD CONSTRAINT `corrct_answer` FOREIGN KEY (`corrct_answer`) REFERENCES `answer` (`id`),
  ADD CONSTRAINT `questions` FOREIGN KEY (`thema_id`) REFERENCES `thema` (`id`),
  ADD CONSTRAINT `thema_id` FOREIGN KEY (`thema_id`) REFERENCES `thema` (`id`);

--
-- Περιορισμοί για πίνακα `quiz`
--
ALTER TABLE `quiz`
  ADD CONSTRAINT `thema_idQuiz` FOREIGN KEY (`thema_id`) REFERENCES `thema` (`id`);

--
-- Περιορισμοί για πίνακα `thema`
--
ALTER TABLE `thema`
  ADD CONSTRAINT `mathima_connect` FOREIGN KEY (`thema_id`) REFERENCES `mathima` (`id`);

--
-- Περιορισμοί για πίνακα `users_grades`
--
ALTER TABLE `users_grades`
  ADD CONSTRAINT `grades` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`),
  ADD CONSTRAINT `mathima_id` FOREIGN KEY (`mathima_id`) REFERENCES `mathima` (`id`),
  ADD CONSTRAINT `quiz_id` FOREIGN KEY (`quiz_id`) REFERENCES `quiz` (`id`);

--
-- Περιορισμοί για πίνακα `user_subjects`
--
ALTER TABLE `user_subjects`
  ADD CONSTRAINT `mathima_id_subjTab` FOREIGN KEY (`mathima_id`) REFERENCES `mathima` (`id`),
  ADD CONSTRAINT `user_id` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
