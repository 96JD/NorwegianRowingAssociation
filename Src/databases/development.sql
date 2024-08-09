DROP DATABASE IF EXISTS Norwegian_Rowing_Association;
CREATE DATABASE Norwegian_Rowing_Association;
USE Norwegian_Rowing_Association;

CREATE TABLE User_Classes (
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(25) NOT NULL UNIQUE
);

CREATE TABLE User_Clubs (
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(30) NOT NULL UNIQUE
);

CREATE TABLE User_Roles (
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(15) NOT NULL UNIQUE CHECK (LENGTH(name) >= 5)
);

CREATE TABLE Users (
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  image_url VARCHAR(255) NOT NULL CHECK (LENGTH(image_url) >= 10),
  first_name VARCHAR(25) NOT NULL,
  last_name VARCHAR(25) NOT NULL,
  email VARCHAR(255) UNIQUE NOT NULL CHECK (email REGEXP "^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Z|a-z]{2,}$"),
  year_of_birth INT NOT NULL,
  password VARCHAR(255) NOT NULL,
  created_date DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  updated_date DATETIME NULL,
  user_class_id INT NULL,
  user_club_id INT NULL,
  user_role_id INT NOT NULL,
  FOREIGN KEY (user_class_id) REFERENCES User_Classes(id),
  FOREIGN KEY (user_club_id) REFERENCES User_Clubs(id),
  FOREIGN KEY (user_role_id) REFERENCES User_Roles(id)
);

CREATE TABLE Test_Weeks (
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  number INT NOT NULL UNIQUE
);

CREATE TABLE Tests (
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(25) NOT NULL UNIQUE CHECK (LENGTH(name) >= 5)
);

CREATE TABLE Test_Results (
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  score float DEFAULT NULL,
  time VARCHAR(25) NULL UNIQUE CHECK (LENGTH(time) >= 5),
  created_date DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  updated_date DATETIME NULL,
  test_id INT NOT NULL,
  test_week_id INT NOT NULL,
  user_id INT NOT NULL,
  FOREIGN KEY (test_id) REFERENCES Tests(id),
  FOREIGN KEY (test_week_id) REFERENCES Test_Weeks(id),
  FOREIGN KEY (user_id) REFERENCES Users(id)
);

INSERT INTO User_Classes VALUES (1, "Senior Men");
INSERT INTO User_Classes VALUES (2, "Senior Women");
INSERT INTO User_Classes VALUES (3, "Junior A Boys");
INSERT INTO User_Classes VALUES (4, "Junior A Girls");
INSERT INTO User_Classes VALUES (5, "Junior B Boys");
INSERT INTO User_Classes VALUES (6, "Junior B Girls");
INSERT INTO User_Classes VALUES (7, "Junior C Boys");
INSERT INTO User_Classes VALUES (8, "Junior C Girls");

INSERT INTO User_Clubs VALUES (1, "Arbeidernes");
INSERT INTO User_Clubs VALUES (2, "Bestumkilen");
INSERT INTO User_Clubs VALUES (3, "Bærum");
INSERT INTO User_Clubs VALUES (4, "Christiania");
INSERT INTO User_Clubs VALUES (5, "Fornebu");
INSERT INTO User_Clubs VALUES (6, "NSR");
INSERT INTO User_Clubs VALUES (7, "Ormsund");
INSERT INTO User_Clubs VALUES (8, "Oslo");
INSERT INTO User_Clubs VALUES (9, "Skullerud");
INSERT INTO User_Clubs VALUES (10, "Drammen");
INSERT INTO User_Clubs VALUES (11, "Horten");
INSERT INTO User_Clubs VALUES (12, "Larvik");
INSERT INTO User_Clubs VALUES (13, "Porsgrunn");
INSERT INTO User_Clubs VALUES (14, "Risør");
INSERT INTO User_Clubs VALUES (15, "Sandefjord");
INSERT INTO User_Clubs VALUES (16, "Tønsberg");
INSERT INTO User_Clubs VALUES (17, "Fredriksstad");
INSERT INTO User_Clubs VALUES (18, "Haldens");
INSERT INTO User_Clubs VALUES (19, "Moss");
INSERT INTO User_Clubs VALUES (20, "Sarpsborg");
INSERT INTO User_Clubs VALUES (21, "Årungen");
INSERT INTO User_Clubs VALUES (22, "Hamar");
INSERT INTO User_Clubs VALUES (23, "Kongsvinger");
INSERT INTO User_Clubs VALUES (24, "Lillehammer");
INSERT INTO User_Clubs VALUES (25, "Randsfjorden");
INSERT INTO User_Clubs VALUES (26, "Alvøen");
INSERT INTO User_Clubs VALUES (27, "Askøy");
INSERT INTO User_Clubs VALUES (28, "Bergens");
INSERT INTO User_Clubs VALUES (29, "Brønnøy");
INSERT INTO User_Clubs VALUES (30, "Fana");
INSERT INTO User_Clubs VALUES (31, "Holmen");
INSERT INTO User_Clubs VALUES (32, "Kvinneherad");
INSERT INTO User_Clubs VALUES (33, "Os");
INSERT INTO User_Clubs VALUES (34, "Voss");
INSERT INTO User_Clubs VALUES (35, "Terje Viken");
INSERT INTO User_Clubs VALUES (36, "Stavanger");
INSERT INTO User_Clubs VALUES (37, "Aalesunds");
INSERT INTO User_Clubs VALUES (38, "Kristiansund");
INSERT INTO User_Clubs VALUES (39, "Namsos");
INSERT INTO User_Clubs VALUES (40, "Nidaros");
INSERT INTO User_Clubs VALUES (41, "Trondhjems");
INSERT INTO User_Clubs VALUES (42, "Arendals");
INSERT INTO User_Clubs VALUES (43, "Kristiansand");
INSERT INTO User_Clubs VALUES (44, "BSI");
INSERT INTO User_Clubs VALUES (45, "Bergen Medisinsk");
INSERT INTO User_Clubs VALUES (46, "NHH Crew");
INSERT INTO User_Clubs VALUES (47, "NTNUI");
INSERT INTO User_Clubs VALUES (48, "Oktagon");
INSERT INTO User_Clubs VALUES (49, "Oslostudentenes Idrettsklubb");
INSERT INTO User_Clubs VALUES (50, "Sjøkrigsskolen");

INSERT INTO User_Roles VALUES (1, "Admin");
INSERT INTO User_Roles VALUES (2, "Trainer");
INSERT INTO User_Roles VALUES (3, "Practitioner");

INSERT INTO Users (id, image_url, first_name, last_name, email, year_of_birth, user_role_id, password)
VALUES (1, "images/users/nr.jpg", "NR", "NR", "nr@nr.no", 1980, 1, "kzGHJcYM46dU+c+wtMQb3XGp5LF3xrxi/dvxIsTn5h5dl5IE1//r7HkEpg5xXNs7hbudZd+JST03oggnRd5INg==");

INSERT INTO Users (id, image_url, first_name, last_name, email, year_of_birth, user_club_id, user_role_id, password)
VALUES (2, "images/default.jpg", "Ola", "Nordmann", "ola@gmail.com", 1990, 43, 2, "kzGHJcYM46dU+c+wtMQb3XGp5LF3xrxi/dvxIsTn5h5dl5IE1//r7HkEpg5xXNs7hbudZd+JST03oggnRd5INg==");

INSERT INTO Users (id, image_url, first_name, last_name, email, year_of_birth, user_class_id, user_club_id, user_role_id, password)
VALUES (3, "images/default.jpg", "Hans", "Hansen", "hans@gmail.com", 1992, 1, 43, 3, "kzGHJcYM46dU+c+wtMQb3XGp5LF3xrxi/dvxIsTn5h5dl5IE1//r7HkEpg5xXNs7hbudZd+JST03oggnRd5INg==");

INSERT INTO Users (id, image_url, first_name, last_name, email, year_of_birth, user_class_id, user_club_id, user_role_id, password)
VALUES (4, "images/default.jpg", "Thomas", "Thomsen", "thomas@gmail.com", 1994, 3, 43, 3, "kzGHJcYM46dU+c+wtMQb3XGp5LF3xrxi/dvxIsTn5h5dl5IE1//r7HkEpg5xXNs7hbudZd+JST03oggnRd5INg==");

INSERT INTO Users (id, image_url, first_name, last_name, email, year_of_birth, user_class_id, user_club_id, user_role_id, password)
VALUES (5, "images/default.jpg", "Kari", "Nordmann", "kari@gmail.com", 1990, 2, 8, 3, "kzGHJcYM46dU+c+wtMQb3XGp5LF3xrxi/dvxIsTn5h5dl5IE1//r7HkEpg5xXNs7hbudZd+JST03oggnRd5INg==");

INSERT INTO Users (id, image_url, first_name, last_name, email, year_of_birth, user_class_id, user_club_id, user_role_id, password)
VALUES (6, "images/default.jpg", "Sara", "Sørensen", "sara@gmail.com", 1992, 2, 8, 3, "kzGHJcYM46dU+c+wtMQb3XGp5LF3xrxi/dvxIsTn5h5dl5IE1//r7HkEpg5xXNs7hbudZd+JST03oggnRd5INg==");

INSERT INTO Users (id, image_url, first_name, last_name, email, year_of_birth, user_class_id, user_club_id, user_role_id, password)
VALUES (7, "images/default.jpg", "Helene", "Helensen", "helene@gmail.com", 1994, 4, 8, 3, "kzGHJcYM46dU+c+wtMQb3XGp5LF3xrxi/dvxIsTn5h5dl5IE1//r7HkEpg5xXNs7hbudZd+JST03oggnRd5INg==");

INSERT INTO Test_Weeks VALUES (1, 2);
INSERT INTO Test_Weeks VALUES (2, 11);
INSERT INTO Test_Weeks VALUES (3, 46);

INSERT INTO Tests VALUES (1, "5000 (Watt)");
INSERT INTO Tests VALUES (2, "2000 (Watt)");
INSERT INTO Tests VALUES (3, "60 (Watt)");
INSERT INTO Tests VALUES (4, "5000 (Time)");
INSERT INTO Tests VALUES (5, "3000 (Time)");
INSERT INTO Tests VALUES (6, "2000 (Time)");
INSERT INTO Tests VALUES (7, "Squat (%)");
INSERT INTO Tests VALUES (8, "Squat (Kg)");
INSERT INTO Tests VALUES (9, "Sergeant (Cm)");
INSERT INTO Tests VALUES (10, "Number of Moves");

INSERT INTO Test_Results (id, score, test_id, test_week_id, user_id) VALUES (1, 90.2, 1, 1, 3);
INSERT INTO Test_Results (id, score, test_id, test_week_id, user_id) VALUES (2, 87.1, 2, 1, 3);
INSERT INTO Test_Results (id, time, test_id, test_week_id, user_id) VALUES (3, "01:35:22", 4, 1, 3);
INSERT INTO Test_Results (id, time, test_id, test_week_id, user_id) VALUES (4, "00:22:31", 5, 1, 3);
INSERT INTO Test_Results (id, score, test_id, test_week_id, user_id) VALUES (5, 88.6, 3, 2, 4);
INSERT INTO Test_Results (id, score, test_id, test_week_id, user_id) VALUES (6, 80.3, 1, 2, 4);
INSERT INTO Test_Results (id, time, test_id, test_week_id, user_id) VALUES (7, "00:51:45", 6, 2, 4);
INSERT INTO Test_Results (id, time, test_id, test_week_id, user_id) VALUES (8, "00:34:33", 4, 2, 4);
INSERT INTO Test_Results (id, score, test_id, test_week_id, user_id) VALUES (9, 77.8, 2, 3, 5);
INSERT INTO Test_Results (id, score, test_id, test_week_id, user_id) VALUES (10, 75.7, 3, 3, 5);
INSERT INTO Test_Results (id, time, test_id, test_week_id, user_id) VALUES (11, "00:25:42", 5, 3, 5);
INSERT INTO Test_Results (id, time, test_id, test_week_id, user_id) VALUES (12, "00:46:55", 6, 3, 5);

INSERT INTO Test_Results (id, score, test_id, test_week_id, user_id) VALUES (13, 80.2, 1, 1, 6);
INSERT INTO Test_Results (id, score, test_id, test_week_id, user_id) VALUES (14, 77.1, 2, 1, 6);
INSERT INTO Test_Results (id, time, test_id, test_week_id, user_id) VALUES (15, "00:55:22", 4, 1, 6);
INSERT INTO Test_Results (id, time, test_id, test_week_id, user_id) VALUES (16, "00:42:31", 5, 1, 6);
INSERT INTO Test_Results (id, score, test_id, test_week_id, user_id) VALUES (17, 78.6, 3, 2, 7);
INSERT INTO Test_Results (id, score, test_id, test_week_id, user_id) VALUES (18, 70.3, 1, 2, 7);
INSERT INTO Test_Results (id, time, test_id, test_week_id, user_id) VALUES (19, "00:41:45", 6, 2, 7);
INSERT INTO Test_Results (id, time, test_id, test_week_id, user_id) VALUES (20, "00:54:33", 4, 2, 7);
