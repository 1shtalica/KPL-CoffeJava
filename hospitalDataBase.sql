CREATE DATABASE  IF NOT EXISTS `hospital` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `hospital`;
-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: hospital
-- ------------------------------------------------------
-- Server version	8.0.36

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20240502150840_Initial migration','7.0.7'),('20240505141553_update migration','7.0.7'),('20240505151906_update migration 2','7.0.7'),('20240505152204_update migration 3','7.0.7'),('20240505155510_update migration 4','7.0.7'),('20240505163926_update migration 5','7.0.7'),('20240505172014_update migration 6','7.0.7'),('20240505174917_update migration 9','7.0.7'),('20240505175421_update migration 10','7.0.7'),('20240505180231_update migration 11','7.0.7'),('20240505181941_update migration 12','7.0.7'),('20240505184421_update migration 13','7.0.7'),('20240506023021_InitialMigration','7.0.7');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `admins`
--

DROP TABLE IF EXISTS `admins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `admins` (
  `AdminId` int NOT NULL AUTO_INCREMENT,
  `FirstName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LastName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Email` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `PhoneNumber` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Password` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Salt` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`AdminId`),
  UNIQUE KEY `IX_Admins_Email` (`Email`),
  UNIQUE KEY `IX_Admins_PhoneNumber` (`PhoneNumber`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `admins`
--

LOCK TABLES `admins` WRITE;
/*!40000 ALTER TABLE `admins` DISABLE KEYS */;
/*!40000 ALTER TABLE `admins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `appoimentpatients`
--

DROP TABLE IF EXISTS `appoimentpatients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `appoimentpatients` (
  `AppoimentId` int NOT NULL,
  `PatientId` int NOT NULL,
  PRIMARY KEY (`AppoimentId`,`PatientId`),
  KEY `IX_AppoimentPatients_PatientId` (`PatientId`),
  CONSTRAINT `FK_AppoimentPatients_Appoiments_AppoimentId` FOREIGN KEY (`AppoimentId`) REFERENCES `appoiments` (`AppoimentId`) ON DELETE CASCADE,
  CONSTRAINT `FK_AppoimentPatients_patients_PatientId` FOREIGN KEY (`PatientId`) REFERENCES `patients` (`PatientId`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `appoimentpatients`
--

LOCK TABLES `appoimentpatients` WRITE;
/*!40000 ALTER TABLE `appoimentpatients` DISABLE KEYS */;
/*!40000 ALTER TABLE `appoimentpatients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `appoiments`
--

DROP TABLE IF EXISTS `appoiments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `appoiments` (
  `AppoimentId` int NOT NULL AUTO_INCREMENT,
  `TimeStart` time(6) NOT NULL,
  `TimeEnd` time(6) NOT NULL,
  `Status` int NOT NULL,
  `IsCompleted` tinyint(1) NOT NULL,
  `Sapacity` int NOT NULL,
  `RoomId` int NOT NULL,
  `DoctorId` int NOT NULL,
  PRIMARY KEY (`AppoimentId`),
  KEY `IX_Appoiments_DoctorId` (`DoctorId`),
  KEY `IX_Appoiments_RoomId` (`RoomId`),
  CONSTRAINT `FK_Appoiments_doctors_DoctorId` FOREIGN KEY (`DoctorId`) REFERENCES `doctors` (`DoctorId`) ON DELETE CASCADE,
  CONSTRAINT `FK_Appoiments_rooms_RoomId` FOREIGN KEY (`RoomId`) REFERENCES `rooms` (`RoomId`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `appoiments`
--

LOCK TABLES `appoiments` WRITE;
/*!40000 ALTER TABLE `appoiments` DISABLE KEYS */;
/*!40000 ALTER TABLE `appoiments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `bloodtypes`
--

DROP TABLE IF EXISTS `bloodtypes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bloodtypes` (
  `bloodType` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`bloodType`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bloodtypes`
--

LOCK TABLES `bloodtypes` WRITE;
/*!40000 ALTER TABLE `bloodtypes` DISABLE KEYS */;
INSERT INTO `bloodtypes` VALUES ('A'),('AB'),('B'),('O');
/*!40000 ALTER TABLE `bloodtypes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `doctors`
--

DROP TABLE IF EXISTS `doctors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `doctors` (
  `DoctorId` int NOT NULL AUTO_INCREMENT,
  `firstName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `lastName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `SpecializationId` int NOT NULL,
  `Address` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `BirthDate` date NOT NULL,
  `PhoneNumber` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Email` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Password` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Salt` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`DoctorId`),
  UNIQUE KEY `IX_doctors_Email` (`Email`),
  UNIQUE KEY `IX_doctors_PhoneNumber` (`PhoneNumber`),
  KEY `IX_doctors_SpecializationId` (`SpecializationId`),
  CONSTRAINT `FK_doctors_specializations_SpecializationId` FOREIGN KEY (`SpecializationId`) REFERENCES `specializations` (`SpecializationId`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `doctors`
--

LOCK TABLES `doctors` WRITE;
/*!40000 ALTER TABLE `doctors` DISABLE KEYS */;
/*!40000 ALTER TABLE `doctors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `genders`
--

DROP TABLE IF EXISTS `genders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `genders` (
  `Name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `genders`
--

LOCK TABLES `genders` WRITE;
/*!40000 ALTER TABLE `genders` DISABLE KEYS */;
INSERT INTO `genders` VALUES ('Female'),('MALE');
/*!40000 ALTER TABLE `genders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `medicalcheckups`
--

DROP TABLE IF EXISTS `medicalcheckups`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `medicalcheckups` (
  `MedicalChekUpId` int NOT NULL AUTO_INCREMENT,
  `date` date NOT NULL,
  `NoteMedicalChekup` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Result` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DoctorId` int NOT NULL,
  `PatientId` int NOT NULL,
  PRIMARY KEY (`MedicalChekUpId`),
  KEY `IX_medicalCheckUps_DoctorId` (`DoctorId`),
  KEY `IX_medicalCheckUps_PatientId` (`PatientId`),
  CONSTRAINT `FK_medicalCheckUps_doctors_DoctorId` FOREIGN KEY (`DoctorId`) REFERENCES `doctors` (`DoctorId`) ON DELETE CASCADE,
  CONSTRAINT `FK_medicalCheckUps_patients_PatientId` FOREIGN KEY (`PatientId`) REFERENCES `patients` (`PatientId`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `medicalcheckups`
--

LOCK TABLES `medicalcheckups` WRITE;
/*!40000 ALTER TABLE `medicalcheckups` DISABLE KEYS */;
/*!40000 ALTER TABLE `medicalcheckups` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `patients`
--

DROP TABLE IF EXISTS `patients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `patients` (
  `PatientId` int NOT NULL AUTO_INCREMENT,
  `FirstName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LastName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Address` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `PhoneNumber` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Email` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Password` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `BirthDate` date NOT NULL,
  `GenderName` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `bloodType` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Salt` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`PatientId`),
  UNIQUE KEY `IX_patients_Email` (`Email`),
  UNIQUE KEY `IX_patients_PhoneNumber` (`PhoneNumber`),
  KEY `IX_patients_bloodType` (`bloodType`),
  KEY `IX_patients_GenderName` (`GenderName`),
  CONSTRAINT `FK_patients_bloodTypes_bloodType` FOREIGN KEY (`bloodType`) REFERENCES `bloodtypes` (`bloodType`),
  CONSTRAINT `FK_patients_genders_GenderName` FOREIGN KEY (`GenderName`) REFERENCES `genders` (`Name`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `patients`
--

LOCK TABLES `patients` WRITE;
/*!40000 ALTER TABLE `patients` DISABLE KEYS */;
INSERT INTO `patients` VALUES (1,'kevin','albany','bogor','082367837542','kevin.junaidi@gmail.com','C6fCg5jqMyglNWSoHlJTveMOKlU=','2024-05-06','MALE','A','96TxaDsslihi1h/K2TLl+g=='),(2,'Rindang','Bani','Karawang','08','rindang@gmail.com','PKWzBbp9kkRcBZiNW8/EC31lSaw=','2024-05-06','MALE','A','19dqUqUGtTDMzKWxXmuElw=='),(3,'Adrian','Fahren','tanggerang','0888','adrian@gmail.com','HpWhAzLP0zh/OE5UOCBIyixLDeM=','2024-05-06','MALE','A','GgSV+kj/+pCwrMh2ImXiDA==');
/*!40000 ALTER TABLE `patients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rooms`
--

DROP TABLE IF EXISTS `rooms`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rooms` (
  `RoomId` int NOT NULL AUTO_INCREMENT,
  `RoomName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `RoomFloor` int NOT NULL,
  `RoomNumber` int NOT NULL,
  PRIMARY KEY (`RoomId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rooms`
--

LOCK TABLES `rooms` WRITE;
/*!40000 ALTER TABLE `rooms` DISABLE KEYS */;
/*!40000 ALTER TABLE `rooms` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `specializations`
--

DROP TABLE IF EXISTS `specializations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `specializations` (
  `SpecializationId` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`SpecializationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `specializations`
--

LOCK TABLES `specializations` WRITE;
/*!40000 ALTER TABLE `specializations` DISABLE KEYS */;
/*!40000 ALTER TABLE `specializations` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-05-06 10:02:04
