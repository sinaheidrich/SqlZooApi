-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server Version:               5.7.11 - MySQL Community Server (GPL)
-- Server Betriebssystem:        Win32
-- HeidiSQL Version:             11.2.0.6213
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

-- Exportiere Struktur von Tabelle zoodatenbank.gast
CREATE TABLE IF NOT EXISTS `gast` (
  `ID` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `Name` text NOT NULL,
  `TierID` bigint(20) unsigned NOT NULL DEFAULT '0',
  `ZooID` bigint(20) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

-- Exportiere Daten aus Tabelle zoodatenbank.gast: ~0 rows (ungefähr)
/*!40000 ALTER TABLE `gast` DISABLE KEYS */;
INSERT INTO `gast` (`ID`, `Name`, `TierID`, `ZooID`) VALUES
	(9, 'Fiona', 29, 11),
	(10, 'Kim', 30, 11),
	(11, 'Connor', 30, 11),
	(12, 'Diana', 31, 12);
/*!40000 ALTER TABLE `gast` ENABLE KEYS */;

-- Exportiere Struktur von Tabelle zoodatenbank.gehege
CREATE TABLE IF NOT EXISTS `gehege` (
  `ID` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `Gehegeart` text NOT NULL,
  `TierID` bigint(20) unsigned NOT NULL DEFAULT '0',
  `ZooID` bigint(20) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID` (`ID`),
  UNIQUE KEY `TierID` (`TierID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- Exportiere Daten aus Tabelle zoodatenbank.gehege: ~0 rows (ungefähr)
/*!40000 ALTER TABLE `gehege` DISABLE KEYS */;
INSERT INTO `gehege` (`ID`, `Gehegeart`, `TierID`, `ZooID`) VALUES
	(1, 'Freistall', 31, 12),
	(2, 'Terrarium', 32, 12),
	(3, 'Stall', 29, 11),
	(4, 'Fischglas', 30, 11),
	(5, 'Vogelkäfig', 33, 11),
	(6, 'Sumpf', 34, 11);
/*!40000 ALTER TABLE `gehege` ENABLE KEYS */;

-- Exportiere Struktur von Tabelle zoodatenbank.mitarbeiter
CREATE TABLE IF NOT EXISTS `mitarbeiter` (
  `ID` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `Nachname` text NOT NULL,
  `Vorname` text NOT NULL,
  `Geburtsjahr` int(11) unsigned NOT NULL,
  `TierID` bigint(20) unsigned NOT NULL DEFAULT '0',
  `ZooID` bigint(20) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- Exportiere Daten aus Tabelle zoodatenbank.mitarbeiter: ~0 rows (ungefähr)
/*!40000 ALTER TABLE `mitarbeiter` DISABLE KEYS */;
INSERT INTO `mitarbeiter` (`ID`, `Nachname`, `Vorname`, `Geburtsjahr`, `TierID`, `ZooID`) VALUES
	(2, 'Mustermann', 'Max', 2000, 31, 12),
	(3, 'Doe', 'Jane', 1999, 29, 11),
	(4, 'Petterson', 'Paula', 1988, 34, 11),
	(5, 'Schmidt', 'Steffen', 1973, 30, 11),
	(6, 'Thomas', 'Tim', 1955, 29, 11),
	(7, 'Doe', 'Jane', 1999, 30, 11);
/*!40000 ALTER TABLE `mitarbeiter` ENABLE KEYS */;

-- Exportiere Struktur von Tabelle zoodatenbank.nahrung
CREATE TABLE IF NOT EXISTS `nahrung` (
  `ID` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `Name` text NOT NULL,
  `Kilokalorien` int(11) unsigned NOT NULL,
  `TierID` bigint(20) unsigned NOT NULL DEFAULT '0',
  `ZooID` bigint(20) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- Exportiere Daten aus Tabelle zoodatenbank.nahrung: ~0 rows (ungefähr)
/*!40000 ALTER TABLE `nahrung` DISABLE KEYS */;
INSERT INTO `nahrung` (`ID`, `Name`, `Kilokalorien`, `TierID`, `ZooID`) VALUES
	(2, 'Apfel', 20, 31, 12),
	(3, 'Banane', 346, 29, 11),
	(4, 'Zitrone', 455, 30, 11),
	(5, 'Mango', 800, 32, 12),
	(6, 'Hühnchen', 612, 34, 11),
	(7, 'Orange', 33, 33, 11),
	(8, 'Pflaume', 2, 31, 12),
	(9, 'Steak', 2123, 29, 11);
/*!40000 ALTER TABLE `nahrung` ENABLE KEYS */;

-- Exportiere Struktur von Tabelle zoodatenbank.tier
CREATE TABLE IF NOT EXISTS `tier` (
  `ID` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `ZooID` int(11) unsigned NOT NULL DEFAULT '0',
  `Tierart` text NOT NULL,
  `Name` text NOT NULL,
  `Vegetarier` int(11) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=latin1;

-- Exportiere Daten aus Tabelle zoodatenbank.tier: ~0 rows (ungefähr)
/*!40000 ALTER TABLE `tier` DISABLE KEYS */;
INSERT INTO `tier` (`ID`, `ZooID`, `Tierart`, `Name`, `Vegetarier`) VALUES
	(29, 11, 'Pferd', 'Polly', 0),
	(30, 11, 'Fisch', 'Fridolin', 1),
	(31, 12, 'Elefant', 'Eva', 1),
	(32, 12, 'Echse', 'Erika', 0),
	(33, 11, 'Papagei', 'Pia', 1),
	(34, 11, 'Krokodil', 'Kroko', 0);
/*!40000 ALTER TABLE `tier` ENABLE KEYS */;

-- Exportiere Struktur von Tabelle zoodatenbank.zoo
CREATE TABLE IF NOT EXISTS `zoo` (
  `ID` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `Ort` text NOT NULL,
  `Name` text NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

-- Exportiere Daten aus Tabelle zoodatenbank.zoo: ~0 rows (ungefähr)
/*!40000 ALTER TABLE `zoo` DISABLE KEYS */;
INSERT INTO `zoo` (`ID`, `Ort`, `Name`) VALUES
	(11, 'Berlin', 'Hasenheide'),
	(12, 'Köln', 'Elefantenoase');
/*!40000 ALTER TABLE `zoo` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
