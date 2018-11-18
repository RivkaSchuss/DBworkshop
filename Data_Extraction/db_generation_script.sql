-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema moodify_schema
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema moodify_schema
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `moodify_schema` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `moodify_schema` ;

-- -----------------------------------------------------
-- Table `moodify_schema`.`artists`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `moodify_schema`.`artists` (
  `artist_id` INT(11) NOT NULL AUTO_INCREMENT,
  `artist_name` VARCHAR(45) NULL DEFAULT NULL,
  `genre` VARCHAR(20) NULL DEFAULT NULL,
  `artist_hotness` FLOAT NULL DEFAULT NULL,
  PRIMARY KEY (`artist_id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `moodify_schema`.`playlist_info`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `moodify_schema`.`playlist_info` (
  `playlist_id` INT(11) NOT NULL AUTO_INCREMENT,
  `playlist_name` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`playlist_id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `moodify_schema`.`users`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `moodify_schema`.`users` (
  `user_id` INT(11) NOT NULL AUTO_INCREMENT,
  `username` VARCHAR(45) NOT NULL,
  `email` VARCHAR(45) NOT NULL,
  `password` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`user_id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `moodify_schema`.`playlist_affiliation`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `moodify_schema`.`playlist_affiliation` (
  `playlist_id` INT(11) NOT NULL,
  `user_id` INT(11) NOT NULL,
  PRIMARY KEY (`playlist_id`, `user_id`),
  INDEX `user_id_affil_fk_idx` (`user_id` ASC) VISIBLE,
  CONSTRAINT `playlist_id_affil_fk`
    FOREIGN KEY (`playlist_id`)
    REFERENCES `moodify_schema`.`playlist_info` (`playlist_id`),
  CONSTRAINT `user_id_affil_fk`
    FOREIGN KEY (`user_id`)
    REFERENCES `moodify_schema`.`users` (`user_id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `moodify_schema`.`song_info`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `moodify_schema`.`song_info` (
  `song_id` INT(11) NOT NULL AUTO_INCREMENT,
  `title` VARCHAR(45) NULL DEFAULT NULL,
  `album_name` VARCHAR(45) NULL DEFAULT NULL,
  `artist_id` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`song_id`),
  INDEX `artist_id_idx` (`artist_id` ASC) VISIBLE,
  CONSTRAINT `artist_id`
    FOREIGN KEY (`artist_id`)
    REFERENCES `moodify_schema`.`artists` (`artist_id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `moodify_schema`.`playlist_songs`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `moodify_schema`.`playlist_songs` (
  `playlist_id` INT(11) NOT NULL,
  `song_id` INT(11) NOT NULL,
  PRIMARY KEY (`playlist_id`, `song_id`),
  INDEX `playlist_id_idx` (`playlist_id` ASC) VISIBLE,
  INDEX `song_id_idx` (`song_id` ASC) VISIBLE,
  CONSTRAINT `playlist_id_fk`
    FOREIGN KEY (`playlist_id`)
    REFERENCES `moodify_schema`.`playlist_info` (`playlist_id`),
  CONSTRAINT `song_id_fk`
    FOREIGN KEY (`song_id`)
    REFERENCES `moodify_schema`.`song_info` (`song_id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `moodify_schema`.`similar_artists`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `moodify_schema`.`similar_artists` (
  `artist_id` INT(11) NOT NULL,
  `similar_to_artist_id` INT(11) NOT NULL,
  PRIMARY KEY (`artist_id`, `similar_to_artist_id`),
  CONSTRAINT `similar_artist_id1`
    FOREIGN KEY (`artist_id`)
    REFERENCES `moodify_schema`.`artists` (`artist_id`),
  CONSTRAINT `similar_artists_id2`
    FOREIGN KEY (`artist_id`)
    REFERENCES `moodify_schema`.`artists` (`artist_id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `moodify_schema`.`song_analysis`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `moodify_schema`.`song_analysis` (
  `song_id` INT(11) NOT NULL,
  `song_hotness` FLOAT NULL DEFAULT NULL,
  `tempo` FLOAT NULL DEFAULT NULL,
  `duration` FLOAT NULL DEFAULT NULL,
  `loudness` FLOAT NULL DEFAULT NULL,
  PRIMARY KEY (`song_id`),
  CONSTRAINT `song_id`
    FOREIGN KEY (`song_id`)
    REFERENCES `moodify_schema`.`song_info` (`song_id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
