-- MySQL dump 10.13  Distrib 8.0.33, for Win64 (x86_64)
--
-- Host: localhost    Database: mydb
-- ------------------------------------------------------
-- Server version	8.0.28

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
-- Table structure for table `circuito`
--

DROP TABLE IF EXISTS `circuito`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `circuito` (
  `idCIRCUITO` int NOT NULL,
  `NOMBRE` varchar(45) DEFAULT NULL,
  `CIUDAD` varchar(45) DEFAULT NULL,
  `PAIS` varchar(3) NOT NULL,
  `LONGITUD` decimal(10,0) DEFAULT NULL,
  `CURVAS` int DEFAULT NULL,
  PRIMARY KEY (`idCIRCUITO`),
  KEY `fk_CIRCUITO_PAIS1_idx` (`PAIS`),
  CONSTRAINT `fk_CIRCUITO_PAIS1` FOREIGN KEY (`PAIS`) REFERENCES `pais` (`idPAIS`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `circuito`
--

LOCK TABLES `circuito` WRITE;
/*!40000 ALTER TABLE `circuito` DISABLE KEYS */;
INSERT INTO `circuito` VALUES (1,'Barein','Sakhir','BAR',5412,15),(2,'Miami','Miami','EST',5410,19),(3,'Barcelona','Montmello','ESP',4675,16),(4,'Albert Park','Melbourne','AUS',5303,16),(5,'Hermanos Rodríguez','Ciudad de Mexico','MEX',4304,17);
/*!40000 ALTER TABLE `circuito` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clasificacion_carrera`
--

DROP TABLE IF EXISTS `clasificacion_carrera`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `clasificacion_carrera` (
  `EDICION` int NOT NULL,
  `PILOTO` int NOT NULL,
  `POSICION` int DEFAULT NULL,
  PRIMARY KEY (`PILOTO`,`EDICION`),
  UNIQUE KEY `uq_CLASIFICACION_CARRERA_EDI_PIL` (`EDICION`,`PILOTO`) /*!80000 INVISIBLE */,
  UNIQUE KEY `uq_CLASIFICACION_CARRERA_EDI_POS` (`EDICION`,`POSICION`),
  KEY `fk_CLASIFICACION_CARRERA_EDICION1_idx` (`EDICION`),
  KEY `fk_CLASIFICACION_CARRERA_PILOTO1_idx` (`PILOTO`),
  CONSTRAINT `fk_CLASIFICACION_CARRERA_EDICION1` FOREIGN KEY (`EDICION`) REFERENCES `edicion` (`idEDICION`) ON UPDATE CASCADE,
  CONSTRAINT `fk_CLASIFICACION_CARRERA_PILOTO1` FOREIGN KEY (`PILOTO`) REFERENCES `piloto` (`idPILOTO`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clasificacion_carrera`
--

LOCK TABLES `clasificacion_carrera` WRITE;
/*!40000 ALTER TABLE `clasificacion_carrera` DISABLE KEYS */;
INSERT INTO `clasificacion_carrera` VALUES (1,9,1),(1,10,2),(1,4,3),(1,5,4),(1,13,5),(1,1,6),(1,12,7),(1,14,8),(1,8,9),(1,2,10),(1,7,11),(1,15,12),(1,11,13),(1,3,14),(1,6,15),(2,15,1),(2,13,2),(2,3,3),(2,10,4),(2,14,5),(2,4,6),(2,7,7),(2,1,8),(2,12,9),(2,9,10),(2,2,11),(2,8,12),(2,5,13),(2,6,14),(2,11,15),(3,1,1),(3,6,2),(3,7,3),(3,5,4),(3,15,5),(3,14,6),(3,8,7),(3,4,8),(3,3,9),(3,2,10),(3,12,11),(3,10,12),(3,11,13),(3,13,14),(3,9,15),(4,4,1),(4,3,2),(4,10,3),(4,1,4),(4,9,5),(4,15,6),(4,6,7),(4,13,8),(4,7,9),(4,5,10),(4,14,11),(4,11,12),(4,8,13),(4,2,14),(4,12,15),(5,11,1),(5,14,2),(5,12,3),(5,1,4),(5,7,5),(5,15,6),(5,5,7),(5,9,8),(5,6,9),(5,8,10),(5,4,11),(5,3,12),(5,10,13),(5,2,14),(5,13,15),(6,15,1),(6,1,2),(6,7,3),(6,6,4),(6,9,5),(6,3,6),(6,10,7),(6,5,8),(6,12,9),(6,11,10),(6,2,11),(6,14,12),(6,8,13),(6,13,14),(6,4,15),(7,12,1),(7,7,2),(7,11,3),(7,9,4),(7,14,5),(7,1,6),(7,3,7),(7,2,8),(7,4,9),(7,6,10),(7,5,11),(7,8,12),(7,13,13),(7,15,14),(7,10,15),(8,2,1),(8,4,2),(8,11,3),(8,8,4),(8,6,5),(8,3,6),(8,13,7),(8,15,8),(8,9,9),(8,1,10),(8,12,11),(8,7,12),(8,10,13),(8,5,14),(8,14,15),(9,2,1),(9,10,2),(9,4,3),(9,15,4),(9,3,5),(9,8,6),(9,6,7),(9,13,8),(9,12,9),(9,5,10),(9,11,11),(9,7,12),(9,1,13),(9,9,14),(9,14,15),(10,5,1),(10,4,2),(10,9,3),(10,6,4),(10,7,5),(10,1,6),(10,11,7),(10,3,8),(10,15,9),(10,12,10),(10,13,11),(10,14,12),(10,2,13),(10,10,14),(10,8,15);
/*!40000 ALTER TABLE `clasificacion_carrera` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `edicion`
--

DROP TABLE IF EXISTS `edicion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `edicion` (
  `idEDICION` int NOT NULL,
  `idGRAN_PREMIO` int NOT NULL,
  `NOMBRE` varchar(45) DEFAULT NULL,
  `CIRCUITO` int DEFAULT NULL,
  `FECHA` date DEFAULT NULL,
  `ANIO` int DEFAULT NULL,
  `PILOTO_VR` int DEFAULT NULL,
  PRIMARY KEY (`idEDICION`,`idGRAN_PREMIO`),
  KEY `fk_GRAN_PREMIO_CIRCUITO1_idx` (`CIRCUITO`),
  KEY `fk_EDICION_PILOTO1_idx` (`PILOTO_VR`),
  KEY `fk_EDICION_GRAN_PREMIO1` (`idGRAN_PREMIO`),
  CONSTRAINT `fk_EDICION_GRAN_PREMIO1` FOREIGN KEY (`idGRAN_PREMIO`) REFERENCES `gran_premio` (`idGRAN_PREMIO`) ON UPDATE CASCADE,
  CONSTRAINT `fk_EDICION_PILOTO1` FOREIGN KEY (`PILOTO_VR`) REFERENCES `piloto` (`idPILOTO`) ON UPDATE CASCADE,
  CONSTRAINT `fk_GRAN_PREMIO_CIRCUITO1` FOREIGN KEY (`CIRCUITO`) REFERENCES `circuito` (`idCIRCUITO`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `edicion`
--

LOCK TABLES `edicion` WRITE;
/*!40000 ALTER TABLE `edicion` DISABLE KEYS */;
INSERT INTO `edicion` VALUES (1,1,'Mexico 2023',5,'2023-05-16',2023,11),(2,1,'Mexico 2022',5,'2022-05-10',2022,9),(3,2,'Australia 2023',4,'2023-05-17',2023,5),(4,2,'Australia 2022',4,'2022-05-10',2022,10),(5,3,'España 2023',3,'2023-05-10',2023,9),(6,3,'España 2022',3,'2022-05-19',2022,4),(7,4,'Barein 2023',1,'2023-05-17',2023,2),(8,4,'Barein 2022',1,'2022-05-10',2022,13),(9,5,'Miami 2023',2,'2023-05-17',2023,5),(10,5,'Miami 2022',2,'2022-05-10',2022,12);
/*!40000 ALTER TABLE `edicion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `gran_premio`
--

DROP TABLE IF EXISTS `gran_premio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `gran_premio` (
  `idGRAN_PREMIO` int NOT NULL,
  `PAIS` varchar(3) DEFAULT NULL,
  `NOMBRE` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idGRAN_PREMIO`),
  UNIQUE KEY `NOMBRE_UNIQUE` (`NOMBRE`),
  KEY `fk_GRAN_PREMIO_PAIS2_idx` (`PAIS`),
  CONSTRAINT `fk_GRAN_PREMIO_PAIS2` FOREIGN KEY (`PAIS`) REFERENCES `pais` (`idPAIS`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gran_premio`
--

LOCK TABLES `gran_premio` WRITE;
/*!40000 ALTER TABLE `gran_premio` DISABLE KEYS */;
INSERT INTO `gran_premio` VALUES (1,'MEX','Mexico'),(2,'AUS','Australia'),(3,'ESP','España'),(4,'BAR','Barein'),(5,'EST','Miami');
/*!40000 ALTER TABLE `gran_premio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `inscripcion_mundial`
--

DROP TABLE IF EXISTS `inscripcion_mundial`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `inscripcion_mundial` (
  `PILOTO` int NOT NULL,
  `TEMPORADA` int NOT NULL,
  PRIMARY KEY (`PILOTO`,`TEMPORADA`),
  KEY `fk_INSCRIPCION_MUNDIAL_PILOTO1_idx` (`PILOTO`),
  CONSTRAINT `fk_INSCRIPCION_MUNDIAL_PILOTO1` FOREIGN KEY (`PILOTO`) REFERENCES `piloto` (`idPILOTO`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inscripcion_mundial`
--

LOCK TABLES `inscripcion_mundial` WRITE;
/*!40000 ALTER TABLE `inscripcion_mundial` DISABLE KEYS */;
INSERT INTO `inscripcion_mundial` VALUES (1,2022),(1,2023),(2,2022),(2,2023),(3,2022),(3,2023),(4,2022),(4,2023),(5,2022),(5,2023),(6,2022),(6,2023),(7,2022),(7,2023),(8,2022),(8,2023),(9,2022),(9,2023),(10,2022),(10,2023),(11,2022),(11,2023),(12,2022),(12,2023),(13,2022),(13,2023),(14,2022),(14,2023),(15,2022),(15,2023);
/*!40000 ALTER TABLE `inscripcion_mundial` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pais`
--

DROP TABLE IF EXISTS `pais`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pais` (
  `idPAIS` varchar(3) NOT NULL,
  `NOMBRE` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idPAIS`),
  UNIQUE KEY `NOMBRE_UNIQUE` (`NOMBRE`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pais`
--

LOCK TABLES `pais` WRITE;
/*!40000 ALTER TABLE `pais` DISABLE KEYS */;
INSERT INTO `pais` VALUES ('ALE','Alemania'),('AUS','Australia'),('BAR','Barein'),('CAN','Canada'),('CHI','China'),('DIN','Dinamarca'),('ESP','España'),('EST','Estados Unidos'),('FIN','Finlandia'),('FRA','Francia'),('HOL','Holanda'),('JAP','Japon'),('MEX','Mexico'),('MON','Monaco'),('PAI','Paises Bajos'),('REI','Reino Unido'),('TAI','Tailandia');
/*!40000 ALTER TABLE `pais` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `piloto`
--

DROP TABLE IF EXISTS `piloto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `piloto` (
  `idPILOTO` int NOT NULL,
  `NOMBRE` varchar(25) DEFAULT NULL,
  `FECHA_NACIMIENTO` datetime DEFAULT NULL,
  `PAIS` varchar(3) NOT NULL,
  PRIMARY KEY (`idPILOTO`),
  KEY `fk_PILOTO_PAIS_idx` (`PAIS`),
  CONSTRAINT `fk_PILOTO_PAIS` FOREIGN KEY (`PAIS`) REFERENCES `pais` (`idPAIS`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `piloto`
--

LOCK TABLES `piloto` WRITE;
/*!40000 ALTER TABLE `piloto` DISABLE KEYS */;
INSERT INTO `piloto` VALUES (1,'Fernando Alonso Díaz','1981-07-29 00:00:00','ESP'),(2,'Lewis Hamilton','1985-01-07 00:00:00','REI'),(3,'Valtteri Bottas','1989-08-28 00:00:00','FIN'),(4,'George Russell','1998-02-15 00:00:00','REI'),(5,'Esteban Ocon','1996-09-17 00:00:00','FRA'),(6,'Pierre Gasly','1996-02-07 00:00:00','FRA'),(7,'Nico Hulkenberg','1987-08-19 00:00:00','ALE'),(8,'Kevin Magnussen','1992-10-05 00:00:00','DIN'),(9,'Lando Norris','1999-11-13 00:00:00','REI'),(10,'Oscar Piastri','2001-04-06 00:00:00','AUS'),(11,'Max Verstappen','1997-09-30 00:00:00','HOL'),(12,'Sergio Pérez','1990-01-26 00:00:00','MEX'),(13,'Lance Stroll','1998-10-29 00:00:00','CAN'),(14,'Yuki Tsunoda','2000-05-11 00:00:00','JAP'),(15,'Nyck de Vries','1995-02-06 00:00:00','PAI'),(16,'Charles Leclerc','1997-10-16 00:00:00','MON'),(17,'Carlos Sainz','1994-09-01 00:00:00','ESP'),(18,'Guanyu Zhou','1999-05-30 00:00:00','CHI'),(19,'Alexander Albon','1996-03-23 00:00:00','TAI'),(20,'Logan Sargeant','2001-12-31 00:00:00','EST');
/*!40000 ALTER TABLE `piloto` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-05-19 15:44:02
