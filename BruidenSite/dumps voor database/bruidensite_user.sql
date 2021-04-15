-- MySQL dump 10.13  Distrib 8.0.23, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: bruidensite
-- ------------------------------------------------------
-- Server version	8.0.23

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
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `UserId` int NOT NULL AUTO_INCREMENT,
  `UserName` varchar(45) NOT NULL,
  `PassWord` varchar(45) NOT NULL,
  `EMailAdres` varchar(100) NOT NULL,
  `TrouwDatum` date DEFAULT NULL,
  `TrouwLocatie` varchar(100) DEFAULT NULL,
  `WensenlijstId` int NOT NULL,
  PRIMARY KEY (`UserId`),
  KEY `fk_User_Wensenlijst_idx` (`WensenlijstId`),
  CONSTRAINT `fk_User_Wensenlijst` FOREIGN KEY (`WensenlijstId`) REFERENCES `wensenlijst` (`WensenlijstId`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'Tjerk Venema','12345','hoi@hoi.com','2021-04-10','mand',1),(3,'mark','hoi','hoi@hoi.com','2021-04-07','kerk',11),(4,'hoi','hoi1','hoi@hoi.com','2021-04-08','fgh',12),(5,'hallohoi','hoihoihoi','hoi@hoi.com','2021-04-22','kerk',13),(6,'123456','123456','123456@1','2021-04-15','kerk',14),(7,'Tjerk Venema','123456','hoi@hoi.com','2021-04-22','fgh',23),(8,'234','234234','hoi@hoi.com',NULL,NULL,24),(9,'Joris','12345678','hoi@hoi.com','2021-04-08','fgh',25),(10,'hoi','hoihoi','hoi@hoi.com','2021-04-30','mand',26);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-04-15 10:41:54
