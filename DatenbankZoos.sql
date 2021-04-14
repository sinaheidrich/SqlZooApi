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

-- Daten Export vom Benutzer nicht ausgewählt

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

-- Daten Export vom Benutzer nicht ausgewählt

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

-- Daten Export vom Benutzer nicht ausgewählt

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

-- Daten Export vom Benutzer nicht ausgewählt

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

-- Daten Export vom Benutzer nicht ausgewählt

-- Exportiere Struktur von Tabelle zoodatenbank.zoo
CREATE TABLE IF NOT EXISTS `zoo` (
  `ID` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `Ort` text NOT NULL,
  `Name` text NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

-- Daten Export vom Benutzer nicht ausgewählt

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
