CREATE DATABASE  IF NOT EXISTS `siag-db` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `siag-db`;

DROP TABLE IF EXISTS `matematica`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `matematica` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `fecha` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `rut` varchar(10) NOT NULL,
  `nombre_estudiante` varchar(50) DEFAULT ' ',
  `folio` varchar(100) NOT NULL,
  `num_serie_lector` varchar(100) DEFAULT ' ',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8;


DROP TABLE IF EXISTS `fisica`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `fisica` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `fecha` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `rut` varchar(10) NOT NULL,
  `nombre_estudiante` varchar(50) DEFAULT ' ',
  `folio` varchar(100) NOT NULL,
  `num_serie_lector` varchar(100) DEFAULT ' ',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8;


DROP TABLE IF EXISTS `quimica`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `quimica` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `fecha` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `rut` varchar(10) NOT NULL,
  `nombre_estudiante` varchar(50) DEFAULT ' ',
  `folio` varchar(100) NOT NULL,
  `num_serie_lector` varchar(100) DEFAULT ' ',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8;

-- Dump completed on 2014-09-23 16:35:43
