# Host: localhost  (Version: 5.6.22-log)
# Date: 2017-01-17 14:54:01
# Generator: MySQL-Front 5.3  (Build 4.43)

/*!40101 SET NAMES utf8 */;

#
# Structure for table "final"
#

DROP TABLE IF EXISTS `final`;
CREATE TABLE `final` (
  `Barcode` bigint(16) DEFAULT NULL,
  `Egreso_Media` varchar(255) DEFAULT '',
  `Nombre_del_Establecimiento` varchar(255) DEFAULT '',
  `Ciudad_del_Establecimiento` varchar(255) DEFAULT '',
  `Rut` varchar(255) DEFAULT '',
  `Verificador` varchar(255) DEFAULT '',
  `Apellido_Paterno` varchar(255) DEFAULT '',
  `Apellido_Materno` varchar(255) DEFAULT '',
  `Nombres` varchar(255) DEFAULT '',
  `Dia` varchar(255) DEFAULT '',
  `Mes` varchar(255) DEFAULT '',
  `Anio` varchar(255) DEFAULT '',
  `Genero` varchar(255) DEFAULT '',
  `Modalidad_del_Establecimiento` varchar(255) DEFAULT '',
  `Regimen` varchar(255) DEFAULT '',
  `Electivo_Media` varchar(255) DEFAULT '',
  `Pregunta1` varchar(255) DEFAULT '',
  `Pregunta2` varchar(255) DEFAULT '',
  `Pregunta3` varchar(255) DEFAULT '',
  `Pregunta4` varchar(255) DEFAULT '',
  `Pregunta5` varchar(255) DEFAULT '',
  `Pregunta6` varchar(255) DEFAULT '',
  `Pregunta7` varchar(255) DEFAULT '',
  `Pregunta8` varchar(255) DEFAULT '',
  `Pregunta9` varchar(255) DEFAULT '',
  `Pregunta10` varchar(255) DEFAULT '',
  `Pregunta11` varchar(255) DEFAULT '',
  `Pregunta12` varchar(255) DEFAULT '',
  `Pregunta13` varchar(255) DEFAULT '',
  `Pregunta14` varchar(255) DEFAULT '',
  `Pregunta15` varchar(255) DEFAULT '',
  `Pregunta16` varchar(255) DEFAULT '',
  `Pregunta17` varchar(255) DEFAULT '',
  `Pregunta18` varchar(255) DEFAULT '',
  `Pregunta19` varchar(255) DEFAULT '',
  `Pregunta20` varchar(255) DEFAULT '',
  `Pregunta21` varchar(255) DEFAULT '',
  `Pregunta22` varchar(255) DEFAULT '',
  `Pregunta23` varchar(255) DEFAULT '',
  `Pregunta24` varchar(255) DEFAULT '',
  `Pregunta25` varchar(255) DEFAULT '',
  `Pregunta26` varchar(255) DEFAULT '',
  `Pregunta27` varchar(255) DEFAULT '',
  `Pregunta28` varchar(255) DEFAULT '',
  `Pregunta29` varchar(255) DEFAULT '',
  `Pregunta30` varchar(255) DEFAULT ''
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
