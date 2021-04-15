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
-- Table structure for table `cadeau`
--

DROP TABLE IF EXISTS `cadeau`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cadeau` (
  `CadeauId` int NOT NULL AUTO_INCREMENT,
  `Cadeaunaam` varchar(45) NOT NULL,
  `Prioriteit` int DEFAULT NULL,
  `Koper` varchar(100) DEFAULT NULL,
  `Done` tinyint DEFAULT NULL,
  `WensenlijstId` int NOT NULL,
  PRIMARY KEY (`CadeauId`),
  KEY `fk_Cadeau_Wensenlijst_idx` (`WensenlijstId`),
  CONSTRAINT `fk_Cadeau_Wensenlijst` FOREIGN KEY (`WensenlijstId`) REFERENCES `wensenlijst` (`WensenlijstId`)
) ENGINE=InnoDB AUTO_INCREMENT=115 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cadeau`
--

LOCK TABLES `cadeau` WRITE;
/*!40000 ALTER TABLE `cadeau` DISABLE KEYS */;
INSERT INTO `cadeau` VALUES (1,'Telefoon',1,NULL,0,11),(3,'Boot',2,NULL,0,11),(4,'Computer',3,NULL,0,11),(68,'asd',0,'hoi',1,13),(73,'hoi',-1,'Tjerk',0,13),(74,'hoisdfsdf',-2,'Tjerk',0,13),(76,'zxc',-3,'Tjerk',0,13),(77,'yujfg',-4,'Tjerk',0,13),(78,'hoisdfsdf',-5,NULL,0,13),(82,'zxc',0,NULL,0,14),(84,'fghws',-1,NULL,0,14),(85,'hoi',-2,NULL,0,14),(87,'hoisdfsdf',0,'Tjerk',1,1),(93,'hoiasd',-1,'Tjerk Venema',1,1),(96,'hoi',-2,'Tjerk Venema',1,1),(97,'hoi',0,NULL,0,23),(98,'auto',-2,NULL,0,23),(99,'hoisdfsdf',-1,NULL,0,23),(100,'qwe',-3,NULL,0,23),(101,'hoi',-1,'Tjerk',1,25),(104,'dfgas',-2,NULL,0,25),(105,'sdf',0,NULL,0,25),(110,'auto',-1,NULL,0,26),(111,'telefoon',0,'Joris',1,26),(112,'boot',-2,'Joris',1,26),(114,'geld',-3,NULL,0,26);
/*!40000 ALTER TABLE `cadeau` ENABLE KEYS */;
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
