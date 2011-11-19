# --------------------------------------------------------
# Host:                         lenovo77
# Server version:               4.1.22-community-nt-log
# Server OS:                    Win32
# HeidiSQL version:             6.0.0.3603
# Date/time:                    2011-11-19 14:55:13
# --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

# Dumping database structure for caofaktura
CREATE DATABASE IF NOT EXISTS `caofaktura` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `caofaktura`;


# Dumping structure for table caofaktura.adressen
CREATE TABLE IF NOT EXISTS `adressen` (
  `REC_ID` int(11) NOT NULL auto_increment,
  `MATCHCODE` varchar(255) NOT NULL default '',
  `KUNDENGRUPPE` int(11) NOT NULL default '0',
  `SPRACH_ID` int(11) NOT NULL default '2',
  `GESCHLECHT` char(1) NOT NULL default '-',
  `KUNNUM1` varchar(20) default NULL,
  `KUNNUM2` varchar(20) default NULL,
  `NAME1` varchar(40) default NULL,
  `PLZ` varchar(10) default NULL,
  `ORT` varchar(40) default NULL,
  `LAND` varchar(5) default NULL,
  `NAME2` varchar(40) default NULL,
  `NAME3` varchar(40) default NULL,
  `ABTEILUNG` varchar(40) default NULL,
  `ANREDE` varchar(40) default NULL,
  `STRASSE` varchar(40) default NULL,
  `POSTFACH` varchar(40) default NULL,
  `PF_PLZ` varchar(10) default NULL,
  `DEFAULT_LIEFANSCHRIFT_ID` int(11) NOT NULL default '-1',
  `GRUPPE` varchar(4) default NULL,
  `TELE1` varchar(100) default NULL,
  `TELE2` varchar(100) default NULL,
  `FAX` varchar(100) default NULL,
  `FUNK` varchar(100) default NULL,
  `EMAIL` varchar(100) default NULL,
  `EMAIL2` varchar(100) default NULL,
  `INTERNET` varchar(100) default NULL,
  `DIVERSES` varchar(100) default NULL,
  `BRIEFANREDE` varchar(100) default NULL,
  `BLZ` varchar(20) default NULL,
  `KTO` varchar(20) default NULL,
  `BANK` varchar(40) default NULL,
  `IBAN` varchar(100) default NULL,
  `SWIFT` varchar(100) default NULL,
  `KTO_INHABER` varchar(40) default NULL,
  `DEB_NUM` int(11) default NULL,
  `KRD_NUM` int(11) default NULL,
  `STATUS` int(11) default NULL,
  `NET_SKONTO` decimal(5,2) default NULL,
  `NET_TAGE` tinyint(4) default NULL,
  `BRT_TAGE` tinyint(4) default NULL,
  `WAEHRUNG` varchar(5) NOT NULL default '',
  `UST_NUM` varchar(25) default NULL,
  `VERTRETER_ID` int(11) unsigned NOT NULL default '0',
  `PROVIS_PROZ` decimal(5,2) NOT NULL default '0.00',
  `INFO` text,
  `GRABATT` decimal(5,2) default NULL,
  `KUN_KRDLIMIT` decimal(10,2) default NULL,
  `KUN_LIEFART` int(11) NOT NULL default '-1',
  `KUN_ZAHLART` int(11) NOT NULL default '-1',
  `KUN_PRLISTE` enum('N','Y') NOT NULL default 'N',
  `KUN_LIEFSPERRE` enum('N','Y') NOT NULL default 'N',
  `LIEF_LIEFART` int(11) NOT NULL default '-1',
  `LIEF_ZAHLART` int(11) NOT NULL default '-1',
  `LIEF_PRLISTE` enum('N','Y') NOT NULL default 'N',
  `LIEF_TKOSTEN` decimal(10,2) NOT NULL default '0.00',
  `LIEF_MBWERT` decimal(10,2) NOT NULL default '0.00',
  `PR_EBENE` tinyint(1) default '5',
  `BRUTTO_FLAG` enum('N','Y') NOT NULL default 'N',
  `MWST_FREI_FLAG` enum('N','Y') NOT NULL default 'N',
  `KUNPREIS_AUTO` enum('N','Y') NOT NULL default 'N',
  `KUN_SEIT` date default NULL,
  `KUN_GEBDATUM` date default NULL,
  `ENTFERNUNG` int(10) unsigned default NULL,
  `ERSTELLT` date default NULL,
  `ERST_NAME` varchar(20) default NULL,
  `GEAEND` date default NULL,
  `GEAEND_NAME` varchar(20) default NULL,
  `SHOP_KUNDE` enum('N','Y') NOT NULL default 'N',
  `SHOP_ID` tinyint(3) NOT NULL default '-1',
  `SHOP_NEWSLETTER` enum('N','Y') NOT NULL default 'N',
  `SHOP_KUNDE_ID` int(11) NOT NULL default '-1',
  `SHOP_CHANGE_FLAG` tinyint(1) unsigned NOT NULL default '0',
  `SHOP_DEL_FLAG` enum('N','Y') NOT NULL default 'N',
  `SHOP_PASSWORD` varchar(20) default NULL,
  `USERFELD_01` varchar(255) default NULL,
  `USERFELD_02` varchar(255) default NULL,
  `USERFELD_03` varchar(255) default NULL,
  `USERFELD_04` varchar(255) default NULL,
  `USERFELD_05` varchar(255) default NULL,
  `USERFELD_06` varchar(255) default NULL,
  `USERFELD_07` varchar(255) default NULL,
  `USERFELD_08` varchar(255) default NULL,
  `USERFELD_09` varchar(255) default NULL,
  `USERFELD_10` varchar(255) default NULL,
  PRIMARY KEY  (`REC_ID`),
  KEY `IDX_KUNNUM1` (`KUNNUM1`),
  KEY `IDX_MATCH` (`MATCHCODE`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.adressen_asp
CREATE TABLE IF NOT EXISTS `adressen_asp` (
  `ADDR_ID` int(11) NOT NULL default '0',
  `REC_ID` int(11) NOT NULL auto_increment,
  `NAME` varchar(40) NOT NULL default '',
  `VORNAME` varchar(40) NOT NULL default '',
  `ANREDE` varchar(40) default NULL,
  `STRASSE` varchar(40) default NULL,
  `LAND` varchar(5) default 'D',
  `PLZ` varchar(10) default NULL,
  `ORT` varchar(40) default NULL,
  `FUNKTION` varchar(40) default NULL,
  `TELEFON` varchar(100) default NULL,
  `TELEFAX` varchar(100) default NULL,
  `MOBILFUNK` varchar(100) default NULL,
  `TELEPRIVAT` varchar(100) default NULL,
  `EMAIL` varchar(100) default NULL,
  `EMAIL2` varchar(100) NOT NULL default '',
  `INFO` text,
  `GEBDATUM` date default NULL,
  `USERFELD_01` varchar(255) default NULL,
  `USERFELD_02` varchar(255) default NULL,
  `USERFELD_03` varchar(255) default NULL,
  `USERFELD_04` varchar(255) default NULL,
  `USERFELD_05` varchar(255) default NULL,
  `USERFELD_06` varchar(255) default NULL,
  `USERFELD_07` varchar(255) default NULL,
  `USERFELD_08` varchar(255) default NULL,
  `USERFELD_09` varchar(255) default NULL,
  `USERFELD_10` varchar(255) default NULL,
  PRIMARY KEY  (`REC_ID`),
  KEY `NAME` (`ADDR_ID`,`NAME`,`VORNAME`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.adressen_lief
CREATE TABLE IF NOT EXISTS `adressen_lief` (
  `REC_ID` int(11) NOT NULL auto_increment,
  `ADDR_ID` int(11) NOT NULL default '0',
  `ANREDE` varchar(40) default NULL,
  `NAME1` varchar(40) NOT NULL default '',
  `NAME2` varchar(40) default NULL,
  `NAME3` varchar(40) default NULL,
  `ABTEILUNG` varchar(40) default NULL,
  `STRASSE` varchar(40) NOT NULL default '',
  `LAND` varchar(5) default NULL,
  `PLZ` varchar(10) NOT NULL default '',
  `ORT` varchar(40) NOT NULL default '',
  `INFO` text,
  PRIMARY KEY  (`REC_ID`,`ADDR_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.adressen_merk
CREATE TABLE IF NOT EXISTS `adressen_merk` (
  `MERKMAL_ID` int(11) NOT NULL auto_increment,
  `NAME` varchar(100) NOT NULL default '',
  PRIMARY KEY  (`MERKMAL_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.adressen_to_merk
CREATE TABLE IF NOT EXISTS `adressen_to_merk` (
  `MERKMAL_ID` int(11) unsigned NOT NULL default '0',
  `ADDR_ID` int(11) unsigned NOT NULL default '0',
  PRIMARY KEY  (`MERKMAL_ID`,`ADDR_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.anrufe
CREATE TABLE IF NOT EXISTS `anrufe` (
  `LFD_NR` int(11) unsigned NOT NULL auto_increment,
  `DATUM_ZEIT` datetime NOT NULL default '0000-00-00 00:00:00',
  `EMPFAENGER_NR` varchar(20) default NULL,
  `ABSENDER_NR` varchar(20) default NULL,
  `ADDR_ID` int(11) NOT NULL default '-1',
  `ASP_ID` int(11) NOT NULL default '-1',
  `MA_ID` int(11) NOT NULL default '-1',
  `ERLEDIGT` enum('N','Y') NOT NULL default 'N',
  `BEMERKUNG` mediumtext,
  PRIMARY KEY  (`LFD_NR`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.artikel
CREATE TABLE IF NOT EXISTS `artikel` (
  `REC_ID` int(11) NOT NULL auto_increment,
  `ARTNUM` varchar(20) default NULL,
  `ERSATZ_ARTNUM` varchar(20) default NULL,
  `ERSATZ_ARTIKEL_ID` int(11) NOT NULL default '-1',
  `MATCHCODE` varchar(255) default NULL,
  `WARENGRUPPE` int(11) NOT NULL default '0',
  `RABGRP_ID` varchar(10) NOT NULL default '-',
  `BARCODE` varchar(20) default NULL,
  `BARCODE2` varchar(20) default NULL,
  `BARCODE3` varchar(20) default NULL,
  `ARTIKELTYP` char(1) NOT NULL default 'N',
  `KURZNAME` varchar(80) default NULL,
  `LANGNAME` text,
  `KAS_NAME` varchar(80) default NULL,
  `INFO` text,
  `ME_ID` int(11) NOT NULL default '1',
  `VPE` decimal(10,3) NOT NULL default '1.000',
  `VPE_EK` decimal(10,3) NOT NULL default '1.000',
  `PR_EINHEIT` decimal(10,2) NOT NULL default '1.00',
  `LAENGE` varchar(20) default NULL,
  `BREITE` varchar(20) default NULL,
  `HOEHE` varchar(20) default NULL,
  `GROESSE` varchar(20) default NULL,
  `DIMENSION` varchar(20) default NULL,
  `GEWICHT` decimal(10,3) NOT NULL default '0.000',
  `INVENTUR_WERT` decimal(5,2) NOT NULL default '100.00',
  `EK_PREIS` decimal(12,4) NOT NULL default '0.0000',
  `VK1` decimal(12,4) NOT NULL default '0.0000',
  `VK1B` decimal(12,4) NOT NULL default '0.0000',
  `VK2` decimal(12,4) NOT NULL default '0.0000',
  `VK2B` decimal(12,4) NOT NULL default '0.0000',
  `VK3` decimal(12,4) NOT NULL default '0.0000',
  `VK3B` decimal(12,4) NOT NULL default '0.0000',
  `VK4` decimal(12,4) NOT NULL default '0.0000',
  `VK4B` decimal(12,4) NOT NULL default '0.0000',
  `VK5` decimal(12,4) NOT NULL default '0.0000',
  `VK5B` decimal(12,4) NOT NULL default '0.0000',
  `BASISPR_FAKTOR` decimal(10,5) NOT NULL default '1.00000',
  `BASISPR_ME_ID` int(11) NOT NULL default '1',
  `MAXRABATT` decimal(5,2) NOT NULL default '0.00',
  `MINGEWINN` decimal(5,2) NOT NULL default '0.00',
  `PROVIS_PROZ` decimal(5,2) NOT NULL default '0.00',
  `STEUER_CODE` tinyint(4) NOT NULL default '2',
  `ALTTEIL_FLAG` enum('N','Y') NOT NULL default 'N',
  `NO_RABATT_FLAG` enum('N','Y') NOT NULL default 'N',
  `NO_PROVISION_FLAG` enum('N','Y') NOT NULL default 'N',
  `NO_BEZEDIT_FLAG` enum('N','Y') NOT NULL default 'N',
  `NO_EK_FLAG` enum('N','Y') NOT NULL default 'N',
  `NO_VK_FLAG` enum('N','Y') NOT NULL default 'N',
  `SN_FLAG` enum('N','Y') NOT NULL default 'N',
  `FSK18_FLAG` enum('N','Y') NOT NULL default 'N',
  `AUTODEL_FLAG` enum('N','Y') NOT NULL default 'N',
  `KOMMISION_FLAG` enum('N','Y') default NULL,
  `LIZENZ_FLAG` enum('N','Y') NOT NULL default 'N',
  `PRODUKTION_FLAG` enum('N','Y') NOT NULL default 'N',
  `PROD_DAUER` int(5) unsigned NOT NULL default '14',
  `VK_LIEFERZEIT_ID` int(11) unsigned NOT NULL default '1',
  `EK_LIEFERZEIT_ID` int(11) unsigned NOT NULL default '1',
  `MENGE_START` decimal(12,4) NOT NULL default '0.0000',
  `MENGE_AKT` decimal(12,4) NOT NULL default '0.0000',
  `MENGE_MIN` decimal(12,4) NOT NULL default '0.0000',
  `MENGE_BVOR` decimal(12,4) NOT NULL default '0.0000',
  `DEFAULT_LIEF_ID` int(11) NOT NULL default '-1',
  `ERLOES_KTO` int(11) default NULL,
  `AUFW_KTO` int(11) default NULL,
  `HERKUNFTSLAND` char(3) default NULL,
  `HERSTELLER_ID` int(11) NOT NULL default '-1',
  `HERST_ARTNUM` varchar(100) default NULL,
  `LAGERORT` varchar(20) default NULL,
  `PFAND1_ARTIKEL_ID` int(11) NOT NULL default '-1',
  `PFAND1_MENGE` decimal(10,3) NOT NULL default '1.000',
  `PFAND2_ARTIKEL_ID` int(11) NOT NULL default '-1',
  `PFAND2_MENGE` decimal(10,3) NOT NULL default '0.000',
  `ZOLLNUMMER` varchar(250) default NULL,
  `ETIKETT_PRINT` tinyint(3) unsigned NOT NULL default '0',
  `LIEFSTATUS` enum('LAGER','AUSLAUF','AUSGELAUFEN') NOT NULL default 'LAGER',
  `DIM_A` varchar(30) default NULL,
  `DIM_B` varchar(30) default NULL,
  `DIM_C` varchar(30) default NULL,
  `NE_ZUSCHLAG_FLAG` enum('N','Y') NOT NULL default 'N',
  `NE_GEWICHT` decimal(10,3) NOT NULL default '0.000',
  `NE_TYP` varchar(10) default NULL,
  `ERSTELLT` date default NULL,
  `ERST_NAME` varchar(20) default NULL,
  `GEAEND` date default NULL,
  `GEAEND_NAME` varchar(20) default NULL,
  `SHOP_ID` tinyint(4) NOT NULL default '-1',
  `SHOP_ARTIKEL_ID` int(11) NOT NULL default '-1',
  `SHOP_KURZTEXT` text,
  `SHOP_LANGTEXT` text,
  `SHOP_IMAGE` varchar(100) default NULL,
  `SHOP_IMAGE_MED` varchar(100) default NULL,
  `SHOP_IMAGE_LARGE` varchar(100) default NULL,
  `SHOP_DATENBLATT` varchar(100) default NULL,
  `SHOP_KATALOG` varchar(100) default NULL,
  `SHOP_ZEICHNUNG` varchar(100) default NULL,
  `SHOP_HANDBUCH` varchar(100) default NULL,
  `AUSSCHREIBUNGSTEXT` varchar(100) default NULL,
  `SHOP_PREIS_LISTE` decimal(12,4) NOT NULL default '0.0000',
  `SHOP_VISIBLE` int(1) default NULL,
  `SHOP_DATE_NEU` date default NULL,
  `SHOP_FAELLT_WEG_AB` date default NULL,
  `SHOP_CLICK_COUNT` int(11) default NULL,
  `SHOP_SYNC` tinyint(1) unsigned default NULL,
  `SHOP_ZUB` tinyint(1) unsigned default NULL,
  `SHOP_CHANGE_DATE` datetime default NULL,
  `SHOP_CHANGE_FLAG` tinyint(1) unsigned NOT NULL default '0',
  `SHOP_DEL_FLAG` enum('N','Y') NOT NULL default 'N',
  `SHOP_PASSWORD` varchar(20) default NULL,
  `SHOP_META_TITEL` varchar(255) default NULL,
  `SHOP_META_BESCHR` text,
  `SHOP_META_KEY` varchar(255) default NULL,
  `USERFELD_01` varchar(255) default NULL,
  `USERFELD_02` varchar(255) default NULL,
  `USERFELD_03` varchar(255) default NULL,
  `USERFELD_04` varchar(255) default NULL,
  `USERFELD_05` varchar(255) default NULL,
  `USERFELD_06` varchar(255) default NULL,
  `USERFELD_07` varchar(255) default NULL,
  `USERFELD_08` varchar(255) default NULL,
  `USERFELD_09` varchar(255) default NULL,
  `USERFELD_10` varchar(255) default NULL,
  PRIMARY KEY  (`REC_ID`),
  KEY `IDX_WARENGR` (`WARENGRUPPE`),
  KEY `IDX_ARTNUM` (`ARTNUM`),
  KEY `IDX_MATCHCODE` (`MATCHCODE`),
  KEY `IDX_BARCODE` (`BARCODE`),
  KEY `IDX_SHOP_CHANGE` (`SHOP_ID`,`SHOP_CHANGE_FLAG`,`SHOP_DEL_FLAG`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.artikel_bdaten
CREATE TABLE IF NOT EXISTS `artikel_bdaten` (
  `ARTIKEL_ID` int(11) NOT NULL default '-1',
  `QUELLE` tinyint(2) unsigned NOT NULL default '0',
  `JAHR` int(4) unsigned NOT NULL default '0',
  `MONAT` tinyint(2) unsigned NOT NULL default '0',
  `SUM_MENGE` decimal(12,4) NOT NULL default '0.0000',
  PRIMARY KEY  (`ARTIKEL_ID`,`QUELLE`,`JAHR`,`MONAT`),
  KEY `IDX_QUELLE` (`QUELLE`,`ARTIKEL_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COMMENT='Bewegungsdaten der Artikel';

# Data exporting was unselected.


# Dumping structure for table caofaktura.artikel_etikett
CREATE TABLE IF NOT EXISTS `artikel_etikett` (
  `REC_ID` int(11) unsigned NOT NULL auto_increment,
  `ARTIKEL_ID` int(11) unsigned NOT NULL default '0',
  `ANZAHL` tinyint(3) unsigned default '1',
  `ADDR_ID` int(11) NOT NULL default '-1',
  `GEDRUCKT` enum('N','Y') default 'N',
  PRIMARY KEY  (`REC_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COMMENT='Artikel-Etikettendruck';

# Data exporting was unselected.


# Dumping structure for table caofaktura.artikel_inventur
CREATE TABLE IF NOT EXISTS `artikel_inventur` (
  `INVENTUR_ID` int(5) unsigned NOT NULL default '0',
  `ARTIKEL_ID` int(11) unsigned NOT NULL default '0',
  `WARENGRUPPE` int(11) unsigned NOT NULL default '0',
  `ARTNUM` varchar(250) default NULL,
  `SN_FLAG` enum('N','Y') NOT NULL default 'N',
  `MATCHCODE` varchar(250) default NULL,
  `BARCODE` varchar(250) default NULL,
  `KURZTEXT` varchar(250) default NULL,
  `MENGE_IST` decimal(12,4) NOT NULL default '0.0000',
  `MENGE_SOLL` decimal(12,4) NOT NULL default '0.0000',
  `MENGE_DIFF` decimal(12,4) NOT NULL default '0.0000',
  `INVENTUR_WERT` decimal(6,3) NOT NULL default '0.000',
  `EK_PREIS` decimal(12,4) NOT NULL default '0.0000',
  `STATUS` tinyint(1) unsigned NOT NULL default '0',
  `BEARBEITER` varchar(50) default NULL,
  PRIMARY KEY  (`INVENTUR_ID`,`ARTIKEL_ID`),
  KEY `IDX_KURZTEXT` (`INVENTUR_ID`,`WARENGRUPPE`,`KURZTEXT`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COMMENT='Artikeldaten für Inventur';

# Data exporting was unselected.


# Dumping structure for table caofaktura.artikel_inventur_sn
CREATE TABLE IF NOT EXISTS `artikel_inventur_sn` (
  `INVENTUR_ID` int(5) unsigned NOT NULL default '0',
  `ARTIKEL_ID` int(11) unsigned NOT NULL default '0',
  `ID` int(11) NOT NULL auto_increment,
  `SNUM_ID` int(11) NOT NULL default '0',
  `SERNUMMER_ALT` varchar(255) NOT NULL default '',
  `SERNUMMER_NEU` varchar(255) NOT NULL default '',
  `STATUS` enum('NO_CHANGE','DELETED','ADDED','CHANGED') NOT NULL default 'NO_CHANGE',
  PRIMARY KEY  (`ID`),
  UNIQUE KEY `IDX_SN_NEU` (`SERNUMMER_NEU`,`ARTIKEL_ID`,`INVENTUR_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.artikel_kat
CREATE TABLE IF NOT EXISTS `artikel_kat` (
  `SHOP_ID` tinyint(3) NOT NULL default '-1',
  `ID` int(11) NOT NULL auto_increment,
  `TOP_ID` int(11) NOT NULL default '-1',
  `SORT_NUM` int(3) unsigned NOT NULL default '0',
  `NAME` varchar(250) NOT NULL default '',
  `URL` varchar(250) default NULL,
  `BESCHREIBUNG` text,
  `IMAGE` varchar(250) default NULL,
  `META_TITEL` varchar(250) default NULL,
  `META_BESCHR` text,
  `META_KEY` text,
  `VISIBLE_FLAG` enum('N','Y') NOT NULL default 'Y',
  `LIEF_ID` int(13) default '-1',
  `ARTIKEL_TEMPLATE` varchar(250) default 'normal.tpl',
  `GRUPPEN_TEMPLATE` varchar(250) default 'grp_normal.tpl',
  `CLICK_COUNT` int(11) default '0',
  `LAST_IP` varchar(16) default NULL,
  `SYNC_FLAG` enum('N','Y') NOT NULL default 'N',
  `CHANGE_FLAG` enum('N','Y') NOT NULL default 'Y',
  `DEL_FLAG` enum('N','Y') NOT NULL default 'N',
  PRIMARY KEY  (`SHOP_ID`,`ID`),
  KEY `IDX_ID` (`ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.artikel_ltext
CREATE TABLE IF NOT EXISTS `artikel_ltext` (
  `ARTIKEL_ID` int(11) NOT NULL default '0',
  `SPRACHE_ID` int(11) NOT NULL default '0',
  `KURZNAME` varchar(80) default NULL,
  `LANGNAME` text,
  `KAS_NAME` varchar(80) default NULL,
  `SHOP_KURZTEXT` text,
  `SHOP_LANGTEXT` text,
  `SHOP_DATENBLATT` varchar(100) default NULL,
  `SHOP_KATALOG` varchar(100) default NULL,
  `SHOP_ZEICHNUNG` varchar(100) default NULL,
  `SHOP_HANDBUCH` varchar(100) default NULL,
  `SHOP_META_TITEL` varchar(255) default NULL,
  `SHOP_META_KEY` varchar(255) default NULL,
  `SHOP_META_BESCHR` text,
  `CHANGE_FLAG` tinyint(1) unsigned NOT NULL default '0',
  PRIMARY KEY  (`ARTIKEL_ID`,`SPRACHE_ID`),
  KEY `IDX_ARTIKEL_ID` (`ARTIKEL_ID`),
  KEY `IDX_SPRACHE_ID` (`SPRACHE_ID`),
  KEY `IDX_ARTIKEL_SPRACHE` (`ARTIKEL_ID`,`SPRACHE_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.artikel_merk
CREATE TABLE IF NOT EXISTS `artikel_merk` (
  `MERKMAL_ID` int(11) NOT NULL auto_increment,
  `NAME` varchar(100) NOT NULL default '',
  PRIMARY KEY  (`MERKMAL_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.artikel_preis
CREATE TABLE IF NOT EXISTS `artikel_preis` (
  `ARTIKEL_ID` int(11) NOT NULL default '-1',
  `ADRESS_ID` int(11) NOT NULL default '-1',
  `PREIS_TYP` tinyint(2) unsigned NOT NULL default '0',
  `PT2` enum('EK','VK','VK1','VK2','VK3','VK4','VK5','AP') NOT NULL default 'EK',
  `BESTNUM` varchar(50) default NULL,
  `LIEFERZEIT_ID` int(11) unsigned NOT NULL default '1',
  `VPE` decimal(10,3) NOT NULL default '0.000',
  `PREIS` decimal(12,4) NOT NULL default '0.0000',
  `RABATT` decimal(5,2) NOT NULL default '0.00',
  `MENGE2` int(6) unsigned NOT NULL default '0',
  `PREIS2` decimal(12,4) NOT NULL default '0.0000',
  `PREIS2_AUTO` enum('N','Y') NOT NULL default 'Y',
  `FAKTOR2` decimal(8,5) NOT NULL default '0.00000',
  `MENGE3` int(6) unsigned NOT NULL default '0',
  `PREIS3` decimal(12,4) NOT NULL default '0.0000',
  `PREIS3_AUTO` enum('N','Y') NOT NULL default 'Y',
  `FAKTOR3` decimal(8,5) NOT NULL default '0.00000',
  `MENGE4` int(6) unsigned NOT NULL default '0',
  `PREIS4` decimal(12,4) NOT NULL default '0.0000',
  `PREIS4_AUTO` enum('N','Y') NOT NULL default 'Y',
  `FAKTOR4` decimal(8,5) NOT NULL default '0.00000',
  `MENGE5` int(6) unsigned NOT NULL default '0',
  `PREIS5` decimal(12,4) NOT NULL default '0.0000',
  `PREIS5_AUTO` enum('N','Y') NOT NULL default 'Y',
  `FAKTOR5` decimal(8,5) NOT NULL default '0.00000',
  `GUELTIG_VON` date default NULL,
  `GUELTIG_BIS` date default NULL,
  `INFO` text,
  `GEAEND` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  `GEAEND_NAME` varchar(20) default NULL,
  PRIMARY KEY  (`ARTIKEL_ID`,`ADRESS_ID`,`PREIS_TYP`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.artikel_sernum
CREATE TABLE IF NOT EXISTS `artikel_sernum` (
  `ARTIKEL_ID` int(11) NOT NULL default '0',
  `SERNUMMER` varchar(255) NOT NULL default '',
  `SNUM_ID` int(11) NOT NULL auto_increment,
  `AT_SNUM_ID` int(11) NOT NULL default '1',
  `STATUS` enum('LAGER','VK_LIEF','VK_RECH','RMA_IH','RMA_AH','RMA_AT','INV_DIV','EK_EDI','AUSTAUSCH') NOT NULL default 'LAGER',
  PRIMARY KEY  (`SNUM_ID`),
  UNIQUE KEY `SERNUMMER` (`SERNUMMER`,`ARTIKEL_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.artikel_stuecklist
CREATE TABLE IF NOT EXISTS `artikel_stuecklist` (
  `REC_ID` int(11) NOT NULL default '0',
  `ART_ID` int(11) NOT NULL default '0',
  `ARTIKEL_ART` enum('STL','SET','ZUB','ERS') NOT NULL default 'STL',
  `POSITION` varchar(10) NOT NULL default '',
  `MENGE` decimal(10,4) NOT NULL default '0.0000',
  `ERSTELLT` date default NULL,
  `ERST_NAME` varchar(20) default NULL,
  `GEAEND` date default NULL,
  `GEAEND_NAME` varchar(20) default NULL,
  PRIMARY KEY  (`REC_ID`,`ART_ID`,`ARTIKEL_ART`),
  KEY `IDX_ART_ID` (`ART_ID`,`ARTIKEL_ART`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.artikel_to_kat
CREATE TABLE IF NOT EXISTS `artikel_to_kat` (
  `SHOP_ID` tinyint(3) NOT NULL default '-1',
  `ARTIKEL_ID` int(13) NOT NULL default '-1',
  `KAT_ID` int(13) NOT NULL default '-1',
  `CHANGE_FLAG` enum('N','Y') NOT NULL default 'Y',
  `DEL_FLAG` enum('N','Y') NOT NULL default 'N',
  PRIMARY KEY  (`SHOP_ID`,`ARTIKEL_ID`,`KAT_ID`),
  KEY `KAT_TO_ARTIKEL` (`SHOP_ID`,`KAT_ID`,`ARTIKEL_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.artikel_to_merk
CREATE TABLE IF NOT EXISTS `artikel_to_merk` (
  `MERKMAL_ID` int(11) unsigned NOT NULL default '0',
  `ARTIKEL_ID` int(11) unsigned NOT NULL default '0',
  PRIMARY KEY  (`MERKMAL_ID`,`ARTIKEL_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.artikel_var
CREATE TABLE IF NOT EXISTS `artikel_var` (
  `MASTER_ARTIKEL_ID` int(11) unsigned NOT NULL default '0',
  `SLAVE_ARTIKEL_ID` int(11) unsigned NOT NULL default '0',
  `DIM_A` varchar(30) NOT NULL default '',
  `DIM_B` varchar(30) default NULL,
  `DIM_C` varchar(30) default NULL,
  `SHOP_ID` tinyint(3) NOT NULL default '-1',
  `SHOP_CHANGE_FLAG` enum('N','Y') NOT NULL default 'Y',
  PRIMARY KEY  (`MASTER_ARTIKEL_ID`),
  UNIQUE KEY `SLAVE_ARTIKEL_ID` (`SLAVE_ARTIKEL_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_adressen
CREATE TABLE IF NOT EXISTS `back_adressen` (
  `REC_ID` int(11) NOT NULL auto_increment,
  `MATCHCODE` varchar(255) NOT NULL default '',
  `KUNDENGRUPPE` int(11) NOT NULL default '0',
  `SPRACH_ID` int(11) NOT NULL default '2',
  `GESCHLECHT` char(1) NOT NULL default '-',
  `KUNNUM1` varchar(20) default NULL,
  `KUNNUM2` varchar(20) default NULL,
  `NAME1` varchar(40) default NULL,
  `PLZ` varchar(10) default NULL,
  `ORT` varchar(40) default NULL,
  `LAND` varchar(5) default NULL,
  `NAME2` varchar(40) default NULL,
  `NAME3` varchar(40) default NULL,
  `ABTEILUNG` varchar(40) default NULL,
  `ANREDE` varchar(40) default NULL,
  `STRASSE` varchar(40) default NULL,
  `POSTFACH` varchar(40) default NULL,
  `PF_PLZ` varchar(10) default NULL,
  `DEFAULT_LIEFANSCHRIFT_ID` int(11) NOT NULL default '-1',
  `GRUPPE` varchar(4) default NULL,
  `TELE1` varchar(100) default NULL,
  `TELE2` varchar(100) default NULL,
  `FAX` varchar(100) default NULL,
  `FUNK` varchar(100) default NULL,
  `EMAIL` varchar(100) default NULL,
  `EMAIL2` varchar(100) default NULL,
  `INTERNET` varchar(100) default NULL,
  `DIVERSES` varchar(100) default NULL,
  `BRIEFANREDE` varchar(100) default NULL,
  `BLZ` varchar(20) default NULL,
  `KTO` varchar(20) default NULL,
  `BANK` varchar(40) default NULL,
  `IBAN` varchar(100) default NULL,
  `SWIFT` varchar(100) default NULL,
  `KTO_INHABER` varchar(40) default NULL,
  `DEB_NUM` int(11) default NULL,
  `KRD_NUM` int(11) default NULL,
  `STATUS` int(11) default NULL,
  `NET_SKONTO` decimal(5,2) default NULL,
  `NET_TAGE` tinyint(4) default NULL,
  `BRT_TAGE` tinyint(4) default NULL,
  `WAEHRUNG` varchar(5) NOT NULL default '',
  `UST_NUM` varchar(25) default NULL,
  `VERTRETER_ID` int(11) unsigned NOT NULL default '0',
  `PROVIS_PROZ` decimal(5,2) NOT NULL default '0.00',
  `INFO` text,
  `GRABATT` decimal(5,2) default NULL,
  `KUN_KRDLIMIT` decimal(10,2) default NULL,
  `KUN_LIEFART` int(11) NOT NULL default '-1',
  `KUN_ZAHLART` int(11) NOT NULL default '-1',
  `KUN_PRLISTE` enum('N','Y') NOT NULL default 'N',
  `KUN_LIEFSPERRE` enum('N','Y') NOT NULL default 'N',
  `LIEF_LIEFART` int(11) NOT NULL default '-1',
  `LIEF_ZAHLART` int(11) NOT NULL default '-1',
  `LIEF_PRLISTE` enum('N','Y') NOT NULL default 'N',
  `LIEF_TKOSTEN` decimal(10,2) NOT NULL default '0.00',
  `LIEF_MBWERT` decimal(10,2) NOT NULL default '0.00',
  `PR_EBENE` tinyint(1) default '5',
  `BRUTTO_FLAG` enum('N','Y') NOT NULL default 'N',
  `MWST_FREI_FLAG` enum('N','Y') NOT NULL default 'N',
  `KUNPREIS_AUTO` enum('N','Y') NOT NULL default 'N',
  `KUN_SEIT` date default NULL,
  `KUN_GEBDATUM` date default NULL,
  `ENTFERNUNG` int(10) unsigned default NULL,
  `ERSTELLT` date default NULL,
  `ERST_NAME` varchar(20) default NULL,
  `GEAEND` date default NULL,
  `GEAEND_NAME` varchar(20) default NULL,
  `SHOP_KUNDE` enum('N','Y') NOT NULL default 'N',
  `SHOP_ID` tinyint(3) NOT NULL default '-1',
  `SHOP_NEWSLETTER` enum('N','Y') NOT NULL default 'N',
  `SHOP_KUNDE_ID` int(11) NOT NULL default '-1',
  `SHOP_CHANGE_FLAG` tinyint(1) unsigned NOT NULL default '0',
  `SHOP_DEL_FLAG` enum('N','Y') NOT NULL default 'N',
  `SHOP_PASSWORD` varchar(20) default NULL,
  `USERFELD_01` varchar(255) default NULL,
  `USERFELD_02` varchar(255) default NULL,
  `USERFELD_03` varchar(255) default NULL,
  `USERFELD_04` varchar(255) default NULL,
  `USERFELD_05` varchar(255) default NULL,
  `USERFELD_06` varchar(255) default NULL,
  `USERFELD_07` varchar(255) default NULL,
  `USERFELD_08` varchar(255) default NULL,
  `USERFELD_09` varchar(255) default NULL,
  `USERFELD_10` varchar(255) default NULL,
  PRIMARY KEY  (`REC_ID`),
  KEY `IDX_KUNNUM1` (`KUNNUM1`),
  KEY `IDX_MATCH` (`MATCHCODE`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_adressen_asp
CREATE TABLE IF NOT EXISTS `back_adressen_asp` (
  `ADDR_ID` int(11) NOT NULL default '0',
  `REC_ID` int(11) NOT NULL auto_increment,
  `NAME` varchar(40) NOT NULL default '',
  `VORNAME` varchar(40) NOT NULL default '',
  `ANREDE` varchar(40) default NULL,
  `STRASSE` varchar(40) default NULL,
  `LAND` varchar(5) default 'D',
  `PLZ` varchar(10) default NULL,
  `ORT` varchar(40) default NULL,
  `FUNKTION` varchar(40) default NULL,
  `TELEFON` varchar(100) default NULL,
  `TELEFAX` varchar(100) default NULL,
  `MOBILFUNK` varchar(100) default NULL,
  `TELEPRIVAT` varchar(100) default NULL,
  `EMAIL` varchar(100) default NULL,
  `EMAIL2` varchar(100) NOT NULL default '',
  `INFO` text,
  `GEBDATUM` date default NULL,
  `USERFELD_01` varchar(255) default NULL,
  `USERFELD_02` varchar(255) default NULL,
  `USERFELD_03` varchar(255) default NULL,
  `USERFELD_04` varchar(255) default NULL,
  `USERFELD_05` varchar(255) default NULL,
  `USERFELD_06` varchar(255) default NULL,
  `USERFELD_07` varchar(255) default NULL,
  `USERFELD_08` varchar(255) default NULL,
  `USERFELD_09` varchar(255) default NULL,
  `USERFELD_10` varchar(255) default NULL,
  PRIMARY KEY  (`REC_ID`),
  KEY `NAME` (`ADDR_ID`,`NAME`,`VORNAME`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_adressen_lief
CREATE TABLE IF NOT EXISTS `back_adressen_lief` (
  `REC_ID` int(11) NOT NULL auto_increment,
  `ADDR_ID` int(11) NOT NULL default '0',
  `ANREDE` varchar(40) default NULL,
  `NAME1` varchar(40) NOT NULL default '',
  `NAME2` varchar(40) default NULL,
  `NAME3` varchar(40) default NULL,
  `ABTEILUNG` varchar(40) default NULL,
  `STRASSE` varchar(40) NOT NULL default '',
  `LAND` varchar(5) default NULL,
  `PLZ` varchar(10) NOT NULL default '',
  `ORT` varchar(40) NOT NULL default '',
  `INFO` text,
  PRIMARY KEY  (`REC_ID`,`ADDR_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_adressen_merk
CREATE TABLE IF NOT EXISTS `back_adressen_merk` (
  `MERKMAL_ID` int(11) NOT NULL auto_increment,
  `NAME` varchar(100) NOT NULL default '',
  PRIMARY KEY  (`MERKMAL_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_adressen_to_merk
CREATE TABLE IF NOT EXISTS `back_adressen_to_merk` (
  `MERKMAL_ID` int(11) unsigned NOT NULL default '0',
  `ADDR_ID` int(11) unsigned NOT NULL default '0',
  PRIMARY KEY  (`MERKMAL_ID`,`ADDR_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_anrufe
CREATE TABLE IF NOT EXISTS `back_anrufe` (
  `LFD_NR` int(11) unsigned NOT NULL auto_increment,
  `DATUM_ZEIT` datetime NOT NULL default '0000-00-00 00:00:00',
  `EMPFAENGER_NR` varchar(20) default NULL,
  `ABSENDER_NR` varchar(20) default NULL,
  `ADDR_ID` int(11) NOT NULL default '-1',
  `ASP_ID` int(11) NOT NULL default '-1',
  `MA_ID` int(11) NOT NULL default '-1',
  `ERLEDIGT` enum('N','Y') NOT NULL default 'N',
  `BEMERKUNG` mediumtext,
  PRIMARY KEY  (`LFD_NR`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_artikel
CREATE TABLE IF NOT EXISTS `back_artikel` (
  `REC_ID` int(11) NOT NULL auto_increment,
  `ARTNUM` varchar(20) default NULL,
  `ERSATZ_ARTNUM` varchar(20) default NULL,
  `ERSATZ_ARTIKEL_ID` int(11) NOT NULL default '-1',
  `MATCHCODE` varchar(255) default NULL,
  `WARENGRUPPE` int(11) NOT NULL default '0',
  `RABGRP_ID` varchar(10) NOT NULL default '-',
  `BARCODE` varchar(20) default NULL,
  `BARCODE2` varchar(20) default NULL,
  `BARCODE3` varchar(20) default NULL,
  `ARTIKELTYP` char(1) NOT NULL default 'N',
  `KURZNAME` varchar(80) default NULL,
  `LANGNAME` text,
  `KAS_NAME` varchar(80) default NULL,
  `INFO` text,
  `ME_ID` int(11) NOT NULL default '1',
  `VPE` decimal(10,3) NOT NULL default '1.000',
  `VPE_EK` decimal(10,3) NOT NULL default '1.000',
  `PR_EINHEIT` decimal(10,2) NOT NULL default '1.00',
  `LAENGE` varchar(20) default NULL,
  `BREITE` varchar(20) default NULL,
  `HOEHE` varchar(20) default NULL,
  `GROESSE` varchar(20) default NULL,
  `DIMENSION` varchar(20) default NULL,
  `GEWICHT` decimal(10,3) NOT NULL default '0.000',
  `INVENTUR_WERT` decimal(5,2) NOT NULL default '100.00',
  `EK_PREIS` decimal(12,4) NOT NULL default '0.0000',
  `VK1` decimal(12,4) NOT NULL default '0.0000',
  `VK1B` decimal(12,4) NOT NULL default '0.0000',
  `VK2` decimal(12,4) NOT NULL default '0.0000',
  `VK2B` decimal(12,4) NOT NULL default '0.0000',
  `VK3` decimal(12,4) NOT NULL default '0.0000',
  `VK3B` decimal(12,4) NOT NULL default '0.0000',
  `VK4` decimal(12,4) NOT NULL default '0.0000',
  `VK4B` decimal(12,4) NOT NULL default '0.0000',
  `VK5` decimal(12,4) NOT NULL default '0.0000',
  `VK5B` decimal(12,4) NOT NULL default '0.0000',
  `BASISPR_FAKTOR` decimal(10,5) NOT NULL default '1.00000',
  `BASISPR_ME_ID` int(11) NOT NULL default '1',
  `MAXRABATT` decimal(5,2) NOT NULL default '0.00',
  `MINGEWINN` decimal(5,2) NOT NULL default '0.00',
  `PROVIS_PROZ` decimal(5,2) NOT NULL default '0.00',
  `STEUER_CODE` tinyint(4) NOT NULL default '2',
  `ALTTEIL_FLAG` enum('N','Y') NOT NULL default 'N',
  `NO_RABATT_FLAG` enum('N','Y') NOT NULL default 'N',
  `NO_PROVISION_FLAG` enum('N','Y') NOT NULL default 'N',
  `NO_BEZEDIT_FLAG` enum('N','Y') NOT NULL default 'N',
  `NO_EK_FLAG` enum('N','Y') NOT NULL default 'N',
  `NO_VK_FLAG` enum('N','Y') NOT NULL default 'N',
  `SN_FLAG` enum('N','Y') NOT NULL default 'N',
  `FSK18_FLAG` enum('N','Y') NOT NULL default 'N',
  `AUTODEL_FLAG` enum('N','Y') NOT NULL default 'N',
  `KOMMISION_FLAG` enum('N','Y') default NULL,
  `LIZENZ_FLAG` enum('N','Y') NOT NULL default 'N',
  `PRODUKTION_FLAG` enum('N','Y') NOT NULL default 'N',
  `PROD_DAUER` int(5) unsigned NOT NULL default '14',
  `VK_LIEFERZEIT_ID` int(11) unsigned NOT NULL default '1',
  `EK_LIEFERZEIT_ID` int(11) unsigned NOT NULL default '1',
  `MENGE_START` decimal(12,4) NOT NULL default '0.0000',
  `MENGE_AKT` decimal(12,4) NOT NULL default '0.0000',
  `MENGE_MIN` decimal(12,4) NOT NULL default '0.0000',
  `MENGE_BVOR` decimal(12,4) NOT NULL default '0.0000',
  `DEFAULT_LIEF_ID` int(11) NOT NULL default '-1',
  `ERLOES_KTO` int(11) default NULL,
  `AUFW_KTO` int(11) default NULL,
  `HERKUNFTSLAND` char(3) default NULL,
  `HERSTELLER_ID` int(11) NOT NULL default '-1',
  `HERST_ARTNUM` varchar(100) default NULL,
  `LAGERORT` varchar(20) default NULL,
  `PFAND1_ARTIKEL_ID` int(11) NOT NULL default '-1',
  `PFAND1_MENGE` decimal(10,3) NOT NULL default '1.000',
  `PFAND2_ARTIKEL_ID` int(11) NOT NULL default '-1',
  `PFAND2_MENGE` decimal(10,3) NOT NULL default '0.000',
  `ZOLLNUMMER` varchar(250) default NULL,
  `ETIKETT_PRINT` tinyint(3) unsigned NOT NULL default '0',
  `LIEFSTATUS` enum('LAGER','AUSLAUF','AUSGELAUFEN') NOT NULL default 'LAGER',
  `DIM_A` varchar(30) default NULL,
  `DIM_B` varchar(30) default NULL,
  `DIM_C` varchar(30) default NULL,
  `NE_ZUSCHLAG_FLAG` enum('N','Y') NOT NULL default 'N',
  `NE_GEWICHT` decimal(10,3) NOT NULL default '0.000',
  `NE_TYP` varchar(10) default NULL,
  `ERSTELLT` date default NULL,
  `ERST_NAME` varchar(20) default NULL,
  `GEAEND` date default NULL,
  `GEAEND_NAME` varchar(20) default NULL,
  `SHOP_ID` tinyint(4) NOT NULL default '-1',
  `SHOP_ARTIKEL_ID` int(11) NOT NULL default '-1',
  `SHOP_KURZTEXT` text,
  `SHOP_LANGTEXT` text,
  `SHOP_IMAGE` varchar(100) default NULL,
  `SHOP_IMAGE_MED` varchar(100) default NULL,
  `SHOP_IMAGE_LARGE` varchar(100) default NULL,
  `SHOP_DATENBLATT` varchar(100) default NULL,
  `SHOP_KATALOG` varchar(100) default NULL,
  `SHOP_ZEICHNUNG` varchar(100) default NULL,
  `SHOP_HANDBUCH` varchar(100) default NULL,
  `AUSSCHREIBUNGSTEXT` varchar(100) default NULL,
  `SHOP_PREIS_LISTE` decimal(12,4) NOT NULL default '0.0000',
  `SHOP_VISIBLE` int(1) default NULL,
  `SHOP_DATE_NEU` date default NULL,
  `SHOP_FAELLT_WEG_AB` date default NULL,
  `SHOP_CLICK_COUNT` int(11) default NULL,
  `SHOP_SYNC` tinyint(1) unsigned default NULL,
  `SHOP_ZUB` tinyint(1) unsigned default NULL,
  `SHOP_CHANGE_DATE` datetime default NULL,
  `SHOP_CHANGE_FLAG` tinyint(1) unsigned NOT NULL default '0',
  `SHOP_DEL_FLAG` enum('N','Y') NOT NULL default 'N',
  `SHOP_PASSWORD` varchar(20) default NULL,
  `SHOP_META_TITEL` varchar(255) default NULL,
  `SHOP_META_BESCHR` text,
  `SHOP_META_KEY` varchar(255) default NULL,
  `USERFELD_01` varchar(255) default NULL,
  `USERFELD_02` varchar(255) default NULL,
  `USERFELD_03` varchar(255) default NULL,
  `USERFELD_04` varchar(255) default NULL,
  `USERFELD_05` varchar(255) default NULL,
  `USERFELD_06` varchar(255) default NULL,
  `USERFELD_07` varchar(255) default NULL,
  `USERFELD_08` varchar(255) default NULL,
  `USERFELD_09` varchar(255) default NULL,
  `USERFELD_10` varchar(255) default NULL,
  PRIMARY KEY  (`REC_ID`),
  KEY `IDX_WARENGR` (`WARENGRUPPE`),
  KEY `IDX_ARTNUM` (`ARTNUM`),
  KEY `IDX_MATCHCODE` (`MATCHCODE`),
  KEY `IDX_BARCODE` (`BARCODE`),
  KEY `IDX_SHOP_CHANGE` (`SHOP_ID`,`SHOP_CHANGE_FLAG`,`SHOP_DEL_FLAG`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_artikel_bdaten
CREATE TABLE IF NOT EXISTS `back_artikel_bdaten` (
  `ARTIKEL_ID` int(11) NOT NULL default '-1',
  `QUELLE` tinyint(2) unsigned NOT NULL default '0',
  `JAHR` int(4) unsigned NOT NULL default '0',
  `MONAT` tinyint(2) unsigned NOT NULL default '0',
  `SUM_MENGE` decimal(12,4) NOT NULL default '0.0000',
  PRIMARY KEY  (`ARTIKEL_ID`,`QUELLE`,`JAHR`,`MONAT`),
  KEY `IDX_QUELLE` (`QUELLE`,`ARTIKEL_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COMMENT='Bewegungsdaten der Artikel';

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_artikel_etikett
CREATE TABLE IF NOT EXISTS `back_artikel_etikett` (
  `REC_ID` int(11) unsigned NOT NULL auto_increment,
  `ARTIKEL_ID` int(11) unsigned NOT NULL default '0',
  `ANZAHL` tinyint(3) unsigned default '1',
  `ADDR_ID` int(11) NOT NULL default '-1',
  `GEDRUCKT` enum('N','Y') default 'N',
  PRIMARY KEY  (`REC_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COMMENT='Artikel-Etikettendruck';

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_artikel_inventur
CREATE TABLE IF NOT EXISTS `back_artikel_inventur` (
  `INVENTUR_ID` int(5) unsigned NOT NULL default '0',
  `ARTIKEL_ID` int(11) unsigned NOT NULL default '0',
  `WARENGRUPPE` int(11) unsigned NOT NULL default '0',
  `ARTNUM` varchar(250) default NULL,
  `SN_FLAG` enum('N','Y') NOT NULL default 'N',
  `MATCHCODE` varchar(250) default NULL,
  `BARCODE` varchar(250) default NULL,
  `KURZTEXT` varchar(250) default NULL,
  `MENGE_IST` decimal(12,4) NOT NULL default '0.0000',
  `MENGE_SOLL` decimal(12,4) NOT NULL default '0.0000',
  `MENGE_DIFF` decimal(12,4) NOT NULL default '0.0000',
  `INVENTUR_WERT` decimal(6,3) NOT NULL default '0.000',
  `EK_PREIS` decimal(12,4) NOT NULL default '0.0000',
  `STATUS` tinyint(1) unsigned NOT NULL default '0',
  `BEARBEITER` varchar(50) default NULL,
  PRIMARY KEY  (`INVENTUR_ID`,`ARTIKEL_ID`),
  KEY `IDX_KURZTEXT` (`INVENTUR_ID`,`WARENGRUPPE`,`KURZTEXT`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COMMENT='Artikeldaten für Inventur';

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_artikel_inventur_sn
CREATE TABLE IF NOT EXISTS `back_artikel_inventur_sn` (
  `INVENTUR_ID` int(5) unsigned NOT NULL default '0',
  `ARTIKEL_ID` int(11) unsigned NOT NULL default '0',
  `ID` int(11) NOT NULL auto_increment,
  `SNUM_ID` int(11) NOT NULL default '0',
  `SERNUMMER_ALT` varchar(255) NOT NULL default '',
  `SERNUMMER_NEU` varchar(255) NOT NULL default '',
  `STATUS` enum('NO_CHANGE','DELETED','ADDED','CHANGED') NOT NULL default 'NO_CHANGE',
  PRIMARY KEY  (`ID`),
  UNIQUE KEY `IDX_SN_NEU` (`SERNUMMER_NEU`,`ARTIKEL_ID`,`INVENTUR_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_artikel_kat
CREATE TABLE IF NOT EXISTS `back_artikel_kat` (
  `SHOP_ID` tinyint(3) NOT NULL default '-1',
  `ID` int(11) NOT NULL auto_increment,
  `TOP_ID` int(11) NOT NULL default '-1',
  `SORT_NUM` int(3) unsigned NOT NULL default '0',
  `NAME` varchar(250) NOT NULL default '',
  `URL` varchar(250) default NULL,
  `BESCHREIBUNG` text,
  `IMAGE` varchar(250) default NULL,
  `META_TITEL` varchar(250) default NULL,
  `META_BESCHR` text,
  `META_KEY` text,
  `VISIBLE_FLAG` enum('N','Y') NOT NULL default 'Y',
  `LIEF_ID` int(13) default '-1',
  `ARTIKEL_TEMPLATE` varchar(250) default 'normal.tpl',
  `GRUPPEN_TEMPLATE` varchar(250) default 'grp_normal.tpl',
  `CLICK_COUNT` int(11) default '0',
  `LAST_IP` varchar(16) default NULL,
  `SYNC_FLAG` enum('N','Y') NOT NULL default 'N',
  `CHANGE_FLAG` enum('N','Y') NOT NULL default 'Y',
  `DEL_FLAG` enum('N','Y') NOT NULL default 'N',
  PRIMARY KEY  (`SHOP_ID`,`ID`),
  KEY `IDX_ID` (`ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_artikel_ltext
CREATE TABLE IF NOT EXISTS `back_artikel_ltext` (
  `ARTIKEL_ID` int(11) NOT NULL default '0',
  `SPRACHE_ID` int(11) NOT NULL default '0',
  `KURZNAME` varchar(80) default NULL,
  `LANGNAME` text,
  `KAS_NAME` varchar(80) default NULL,
  `SHOP_KURZTEXT` text,
  `SHOP_LANGTEXT` text,
  `SHOP_DATENBLATT` varchar(100) default NULL,
  `SHOP_KATALOG` varchar(100) default NULL,
  `SHOP_ZEICHNUNG` varchar(100) default NULL,
  `SHOP_HANDBUCH` varchar(100) default NULL,
  `SHOP_META_TITEL` varchar(255) default NULL,
  `SHOP_META_KEY` varchar(255) default NULL,
  `SHOP_META_BESCHR` text,
  `CHANGE_FLAG` tinyint(1) unsigned NOT NULL default '0',
  PRIMARY KEY  (`ARTIKEL_ID`,`SPRACHE_ID`),
  KEY `IDX_ARTIKEL_ID` (`ARTIKEL_ID`),
  KEY `IDX_SPRACHE_ID` (`SPRACHE_ID`),
  KEY `IDX_ARTIKEL_SPRACHE` (`ARTIKEL_ID`,`SPRACHE_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_artikel_merk
CREATE TABLE IF NOT EXISTS `back_artikel_merk` (
  `MERKMAL_ID` int(11) NOT NULL auto_increment,
  `NAME` varchar(100) NOT NULL default '',
  PRIMARY KEY  (`MERKMAL_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_artikel_preis
CREATE TABLE IF NOT EXISTS `back_artikel_preis` (
  `ARTIKEL_ID` int(11) NOT NULL default '-1',
  `ADRESS_ID` int(11) NOT NULL default '-1',
  `PREIS_TYP` tinyint(2) unsigned NOT NULL default '0',
  `PT2` enum('EK','VK','VK1','VK2','VK3','VK4','VK5','AP') NOT NULL default 'EK',
  `BESTNUM` varchar(50) default NULL,
  `LIEFERZEIT_ID` int(11) unsigned NOT NULL default '1',
  `VPE` decimal(10,3) NOT NULL default '0.000',
  `PREIS` decimal(12,4) NOT NULL default '0.0000',
  `RABATT` decimal(5,2) NOT NULL default '0.00',
  `MENGE2` int(6) unsigned NOT NULL default '0',
  `PREIS2` decimal(12,4) NOT NULL default '0.0000',
  `PREIS2_AUTO` enum('N','Y') NOT NULL default 'Y',
  `FAKTOR2` decimal(8,5) NOT NULL default '0.00000',
  `MENGE3` int(6) unsigned NOT NULL default '0',
  `PREIS3` decimal(12,4) NOT NULL default '0.0000',
  `PREIS3_AUTO` enum('N','Y') NOT NULL default 'Y',
  `FAKTOR3` decimal(8,5) NOT NULL default '0.00000',
  `MENGE4` int(6) unsigned NOT NULL default '0',
  `PREIS4` decimal(12,4) NOT NULL default '0.0000',
  `PREIS4_AUTO` enum('N','Y') NOT NULL default 'Y',
  `FAKTOR4` decimal(8,5) NOT NULL default '0.00000',
  `MENGE5` int(6) unsigned NOT NULL default '0',
  `PREIS5` decimal(12,4) NOT NULL default '0.0000',
  `PREIS5_AUTO` enum('N','Y') NOT NULL default 'Y',
  `FAKTOR5` decimal(8,5) NOT NULL default '0.00000',
  `GUELTIG_VON` date default NULL,
  `GUELTIG_BIS` date default NULL,
  `INFO` text,
  `GEAEND` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  `GEAEND_NAME` varchar(20) default NULL,
  PRIMARY KEY  (`ARTIKEL_ID`,`ADRESS_ID`,`PREIS_TYP`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_artikel_sernum
CREATE TABLE IF NOT EXISTS `back_artikel_sernum` (
  `ARTIKEL_ID` int(11) NOT NULL default '0',
  `SERNUMMER` varchar(255) NOT NULL default '',
  `SNUM_ID` int(11) NOT NULL auto_increment,
  `AT_SNUM_ID` int(11) NOT NULL default '1',
  `STATUS` enum('LAGER','VK_LIEF','VK_RECH','RMA_IH','RMA_AH','RMA_AT','INV_DIV','EK_EDI','AUSTAUSCH') NOT NULL default 'LAGER',
  PRIMARY KEY  (`SNUM_ID`),
  UNIQUE KEY `SERNUMMER` (`SERNUMMER`,`ARTIKEL_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_artikel_stuecklist
CREATE TABLE IF NOT EXISTS `back_artikel_stuecklist` (
  `REC_ID` int(11) NOT NULL default '0',
  `ART_ID` int(11) NOT NULL default '0',
  `ARTIKEL_ART` enum('STL','SET','ZUB','ERS') NOT NULL default 'STL',
  `POSITION` varchar(10) NOT NULL default '',
  `MENGE` decimal(10,4) NOT NULL default '0.0000',
  `ERSTELLT` date default NULL,
  `ERST_NAME` varchar(20) default NULL,
  `GEAEND` date default NULL,
  `GEAEND_NAME` varchar(20) default NULL,
  PRIMARY KEY  (`REC_ID`,`ART_ID`,`ARTIKEL_ART`),
  KEY `IDX_ART_ID` (`ART_ID`,`ARTIKEL_ART`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_artikel_to_kat
CREATE TABLE IF NOT EXISTS `back_artikel_to_kat` (
  `SHOP_ID` tinyint(3) NOT NULL default '-1',
  `ARTIKEL_ID` int(13) NOT NULL default '-1',
  `KAT_ID` int(13) NOT NULL default '-1',
  `CHANGE_FLAG` enum('N','Y') NOT NULL default 'Y',
  `DEL_FLAG` enum('N','Y') NOT NULL default 'N',
  PRIMARY KEY  (`SHOP_ID`,`ARTIKEL_ID`,`KAT_ID`),
  KEY `KAT_TO_ARTIKEL` (`SHOP_ID`,`KAT_ID`,`ARTIKEL_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_artikel_to_merk
CREATE TABLE IF NOT EXISTS `back_artikel_to_merk` (
  `MERKMAL_ID` int(11) unsigned NOT NULL default '0',
  `ARTIKEL_ID` int(11) unsigned NOT NULL default '0',
  PRIMARY KEY  (`MERKMAL_ID`,`ARTIKEL_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_artikel_var
CREATE TABLE IF NOT EXISTS `back_artikel_var` (
  `MASTER_ARTIKEL_ID` int(11) unsigned NOT NULL default '0',
  `SLAVE_ARTIKEL_ID` int(11) unsigned NOT NULL default '0',
  `DIM_A` varchar(30) NOT NULL default '',
  `DIM_B` varchar(30) default NULL,
  `DIM_C` varchar(30) default NULL,
  `SHOP_ID` tinyint(3) NOT NULL default '-1',
  `SHOP_CHANGE_FLAG` enum('N','Y') NOT NULL default 'Y',
  PRIMARY KEY  (`MASTER_ARTIKEL_ID`),
  UNIQUE KEY `SLAVE_ARTIKEL_ID` (`SLAVE_ARTIKEL_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_benutzerrechte
CREATE TABLE IF NOT EXISTS `back_benutzerrechte` (
  `GRUPPEN_ID` int(11) NOT NULL default '0',
  `USER_ID` int(11) NOT NULL default '0',
  `MODUL_ID` int(11) unsigned NOT NULL default '0',
  `MODUL_NAME` varchar(100) default NULL,
  `SUBMODUL_ID` int(11) NOT NULL default '0',
  `SUBMODUL_NAME` varchar(100) default NULL,
  `RECHTE` bigint(16) unsigned NOT NULL default '0',
  `BEMERKUNG` varchar(250) default NULL,
  PRIMARY KEY  (`GRUPPEN_ID`,`USER_ID`,`MODUL_ID`,`SUBMODUL_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_blz
CREATE TABLE IF NOT EXISTS `back_blz` (
  `LAND` varchar(5) NOT NULL default 'DE',
  `BLZ` int(10) NOT NULL default '0',
  `BANK_NAME` varchar(255) NOT NULL default '',
  `PRZ` char(2) NOT NULL default '',
  PRIMARY KEY  (`LAND`,`BLZ`),
  KEY `IDX_NAME` (`LAND`,`BANK_NAME`,`BLZ`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_ekbestell
CREATE TABLE IF NOT EXISTS `back_ekbestell` (
  `REC_ID` int(11) NOT NULL auto_increment,
  `TERM_ID` int(11) unsigned NOT NULL default '1',
  `MA_ID` int(11) NOT NULL default '-1',
  `PREISANFRAGE` enum('N','Y') NOT NULL default 'N',
  `ADDR_ID` int(11) NOT NULL default '-1',
  `ASP_ID` int(11) NOT NULL default '-1',
  `LIEF_ADDR_ID` int(11) NOT NULL default '-1',
  `PROJEKT_ID` int(11) NOT NULL default '-1',
  `BELEGNUM` varchar(20) NOT NULL default '',
  `BELEGDATUM` date NOT NULL default '0000-00-00',
  `TERMIN` date default NULL,
  `LIEFART` tinyint(2) NOT NULL default '-1',
  `ZAHLART` tinyint(2) NOT NULL default '-1',
  `GLOBRABATT` float(10,2) NOT NULL default '0.00',
  `GEWICHT` float(10,3) NOT NULL default '0.000',
  `MWST_0` decimal(5,2) NOT NULL default '0.00',
  `MWST_1` decimal(5,2) NOT NULL default '0.00',
  `MWST_2` decimal(5,2) NOT NULL default '0.00',
  `MWST_3` decimal(5,2) NOT NULL default '0.00',
  `NSUMME_0` decimal(10,2) NOT NULL default '0.00',
  `NSUMME_1` decimal(10,2) NOT NULL default '0.00',
  `NSUMME_2` decimal(10,2) NOT NULL default '0.00',
  `NSUMME_3` decimal(10,2) NOT NULL default '0.00',
  `NSUMME` decimal(10,2) NOT NULL default '0.00',
  `MSUMME_0` decimal(10,2) NOT NULL default '0.00',
  `MSUMME_1` decimal(10,2) NOT NULL default '0.00',
  `MSUMME_2` decimal(10,2) NOT NULL default '0.00',
  `MSUMME_3` decimal(10,2) NOT NULL default '0.00',
  `MSUMME` decimal(10,2) NOT NULL default '0.00',
  `BSUMME_0` decimal(10,2) NOT NULL default '0.00',
  `BSUMME_1` decimal(10,2) NOT NULL default '0.00',
  `BSUMME_2` decimal(10,2) NOT NULL default '0.00',
  `BSUMME_3` decimal(10,2) NOT NULL default '0.00',
  `BSUMME` decimal(10,2) NOT NULL default '0.00',
  `ATSUMME` decimal(10,2) NOT NULL default '0.00',
  `ATMSUMME` decimal(10,2) NOT NULL default '0.00',
  `WAEHRUNG` varchar(5) NOT NULL default '',
  `KURS` decimal(16,4) NOT NULL default '1.0000',
  `GEGENKONTO` int(11) NOT NULL default '-1',
  `SOLL_STAGE` int(4) unsigned NOT NULL default '0',
  `SOLL_SKONTO` float(5,2) NOT NULL default '0.00',
  `SOLL_NTAGE` int(4) unsigned NOT NULL default '0',
  `STADIUM` tinyint(4) NOT NULL default '0',
  `ERSTELLT` date default NULL,
  `ERST_NAME` varchar(20) default NULL,
  `KUN_NUM` varchar(20) default NULL,
  `KUN_ANREDE` varchar(40) default NULL,
  `KUN_NAME1` varchar(40) default NULL,
  `KUN_NAME2` varchar(40) default NULL,
  `KUN_NAME3` varchar(40) default NULL,
  `KUN_ABTEILUNG` varchar(40) default NULL,
  `KUN_STRASSE` varchar(40) default NULL,
  `KUN_LAND` varchar(5) default NULL,
  `KUN_PLZ` varchar(10) default NULL,
  `KUN_ORT` varchar(40) default NULL,
  `USR1` varchar(80) default NULL,
  `USR2` varchar(80) default NULL,
  `KOPFTEXT` text,
  `FUSSTEXT` text,
  `PROJEKT` varchar(80) default NULL,
  `ORGNUM` varchar(20) default NULL,
  `BEST_NAME` varchar(40) default NULL,
  `BEST_CODE` tinyint(4) default NULL,
  `BEST_DATUM` date default NULL,
  `INFO` text,
  `FREIGABE1_FLAG` enum('N','Y') NOT NULL default 'N',
  `PRINT_FLAG` enum('N','Y') NOT NULL default 'N',
  `BRUTTO_FLAG` enum('N','Y') NOT NULL default 'N',
  `MWST_FREI_FLAG` enum('N','Y') NOT NULL default 'N',
  PRIMARY KEY  (`REC_ID`),
  KEY `IDX_BELEGNUM` (`PREISANFRAGE`,`BELEGNUM`),
  KEY `IDX_QUELLE_RDATUM` (`PREISANFRAGE`,`BELEGDATUM`),
  KEY `IDX_ADDR_ID` (`ADDR_ID`,`PREISANFRAGE`,`BELEGDATUM`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_ekbestell_op
CREATE TABLE IF NOT EXISTS `back_ekbestell_op` (
  `ARTIKEL_ID` int(11) unsigned NOT NULL default '0',
  `EKBESTPOS_ID` int(11) unsigned NOT NULL default '0',
  `MENGE_BEST` decimal(10,2) NOT NULL default '0.00',
  `MENGE_OFFEN` decimal(10,2) NOT NULL default '0.00',
  PRIMARY KEY  (`EKBESTPOS_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_ekbestell_pos
CREATE TABLE IF NOT EXISTS `back_ekbestell_pos` (
  `EKBESTELL_ID` int(11) NOT NULL default '0',
  `PREISANFRAGE` enum('N','Y') NOT NULL default 'N',
  `BELEGNUM` varchar(20) NOT NULL default '',
  `ADDR_ID` int(11) NOT NULL default '-1',
  `LIEF_ADDR_ID` int(11) NOT NULL default '-1',
  `PROJEKT_ID` int(11) NOT NULL default '-1',
  `REC_ID` int(11) NOT NULL auto_increment,
  `POSITION` int(11) NOT NULL default '0',
  `VIEW_POS` char(3) default NULL,
  `WARENGRUPPE` int(11) NOT NULL default '-1',
  `ARTIKELTYP` char(1) NOT NULL default '',
  `ARTIKEL_ID` int(11) NOT NULL default '-1',
  `MATCHCODE` varchar(20) default NULL,
  `ARTNUM` varchar(20) default NULL,
  `BARCODE` varchar(20) default NULL,
  `LAENGE` varchar(20) default NULL,
  `BREITE` varchar(20) default NULL,
  `HOEHE` varchar(20) default NULL,
  `GROESSE` varchar(20) default NULL,
  `DIMENSION` varchar(20) default NULL,
  `GEWICHT` decimal(10,3) NOT NULL default '0.000',
  `ME_EINHEIT` varchar(10) default NULL,
  `PR_EINHEIT` decimal(10,3) NOT NULL default '1.000',
  `VPE` decimal(10,3) NOT NULL default '1.000',
  `MENGE` decimal(10,3) NOT NULL default '0.000',
  `EPREIS` decimal(10,4) NOT NULL default '0.0000',
  `GPREIS` decimal(10,2) NOT NULL default '0.00',
  `RABATT1` decimal(10,2) NOT NULL default '0.00',
  `RABATT2` decimal(10,2) NOT NULL default '0.00',
  `RABATT3` decimal(10,2) NOT NULL default '0.00',
  `E_RABATT_BETRAG` decimal(10,4) NOT NULL default '0.0000',
  `G_RABATT_BETRAG` decimal(10,2) NOT NULL default '0.00',
  `STEUER_CODE` tinyint(1) unsigned NOT NULL default '0',
  `ALTTEIL_PROZ` decimal(10,2) NOT NULL default '0.10',
  `ALTTEIL_STCODE` tinyint(4) NOT NULL default '0',
  `GEGENKTO` int(11) NOT NULL default '-1',
  `BEZEICHNUNG` text,
  `ALTTEIL_FLAG` enum('N','Y') NOT NULL default 'N',
  `BRUTTO_FLAG` enum('N','Y') NOT NULL default 'N',
  `STADIUM` tinyint(3) unsigned NOT NULL default '0',
  PRIMARY KEY  (`REC_ID`),
  KEY `IDX_ARTIKEL_ID` (`ARTIKEL_ID`),
  KEY `IDX_ADDR_ID` (`ADDR_ID`),
  KEY `IDX_EKBESTELL_ID` (`EKBESTELL_ID`,`POSITION`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_export
CREATE TABLE IF NOT EXISTS `back_export` (
  `ID` int(11) NOT NULL auto_increment,
  `KURZBEZ` varchar(255) NOT NULL default '',
  `INFO` text NOT NULL,
  `QUERY` text NOT NULL,
  `FELDER` text,
  `FORMULAR` blob,
  `FORMAT` char(3) default NULL,
  `FILENAME` varchar(255) default NULL,
  `EINSTELLUNGEN` text,
  `LAST_CHANGE` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  `CHANGE_NAME` varchar(100) default NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_fibu_konten
CREATE TABLE IF NOT EXISTS `back_fibu_konten` (
  `KONTORAHMEN` varchar(10) NOT NULL default '',
  `KONTO` bigint(5) unsigned NOT NULL default '0',
  `KONTONAME` varchar(100) NOT NULL default '',
  `KONTOART` int(3) unsigned NOT NULL default '0',
  `NEBENKONTO` bigint(5) unsigned NOT NULL default '0',
  `STEUERSATZ` decimal(6,0) NOT NULL default '0',
  `BILANZKONTO` enum('N','Y') NOT NULL default 'N',
  `NK_AUSWAHL` enum('N','Y') NOT NULL default 'N',
  `USTVA_ZEILE` bigint(5) unsigned NOT NULL default '0',
  `BWA_GRUPPE` bigint(5) unsigned default '0',
  `BANK_BLZ` varchar(15) default NULL,
  `BANK_KONTO` varchar(15) default NULL,
  `BANK_NAME` varchar(255) default NULL,
  `KONTO_INHABER` varchar(255) default NULL,
  PRIMARY KEY  (`KONTORAHMEN`,`KONTO`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_firma
CREATE TABLE IF NOT EXISTS `back_firma` (
  `ANREDE` varchar(250) default NULL,
  `NAME1` varchar(250) default NULL,
  `NAME2` varchar(250) default NULL,
  `NAME3` varchar(250) default NULL,
  `STRASSE` varchar(250) default NULL,
  `LAND` varchar(10) default NULL,
  `PLZ` varchar(10) default NULL,
  `ORT` varchar(250) default NULL,
  `VORWAHL` varchar(250) default NULL,
  `TELEFON1` varchar(250) default NULL,
  `TELEFON2` varchar(250) default NULL,
  `MOBILFUNK` varchar(250) default NULL,
  `FAX` varchar(250) default NULL,
  `EMAIL` varchar(250) default NULL,
  `WEBSEITE` varchar(250) default NULL,
  `BANK1_BLZ` varchar(20) default NULL,
  `BANK1_KONTONR` varchar(20) default NULL,
  `BANK1_NAME` varchar(250) default NULL,
  `BANK1_IBAN` varchar(100) default NULL,
  `BANK1_SWIFT` varchar(100) default NULL,
  `BANK2_BLZ` varchar(20) default NULL,
  `BANK2_KONTONR` varchar(20) default NULL,
  `BANK2_NAME` varchar(250) default NULL,
  `BANK2_IBAN` varchar(100) default NULL,
  `BANK2_SWIFT` varchar(100) default NULL,
  `KOPFTEXT` text,
  `FUSSTEXT` text,
  `ABSENDER` varchar(250) default NULL,
  `STEUERNUMMER` varchar(25) default NULL,
  `UST_ID` varchar(25) default NULL,
  `IMAGE1` blob,
  `IMAGE2` blob,
  `IMAGE3` blob
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COMMENT='Allgemeine Firmendaten für Formulare';

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_hersteller
CREATE TABLE IF NOT EXISTS `back_hersteller` (
  `SHOP_ID` tinyint(3) NOT NULL default '-1',
  `HERSTELLER_ID` int(11) NOT NULL auto_increment,
  `ADDR_ID` int(11) NOT NULL default '-1',
  `HERSTELLER_NAME` varchar(32) NOT NULL default '',
  `HERSTELLER_IMAGE` varchar(64) default NULL,
  `LAST_CHANGE` datetime default NULL,
  `SHOP_DATE_ADDED` datetime default NULL,
  `SHOP_DATE_CHANGE` datetime default NULL,
  `SYNC_FLAG` enum('N','Y') NOT NULL default 'N',
  `CHANGE_FLAG` enum('N','Y') NOT NULL default 'N',
  `DEL_FLAG` enum('N','Y') NOT NULL default 'N',
  PRIMARY KEY  (`SHOP_ID`,`HERSTELLER_ID`),
  KEY `IDX_HERSTELLER_NAME` (`HERSTELLER_NAME`),
  KEY `IDX_HERSTELLER_ID` (`HERSTELLER_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_hersteller_info
CREATE TABLE IF NOT EXISTS `back_hersteller_info` (
  `SHOP_ID` tinyint(3) NOT NULL default '-1',
  `HERSTELLER_ID` int(11) NOT NULL default '0',
  `SPRACHE_ID` int(11) NOT NULL default '0',
  `HERSTELLER_URL` varchar(255) NOT NULL default '',
  `URL_CLICKED` int(5) NOT NULL default '0',
  `DATE_LAST_CLICK` datetime default NULL,
  PRIMARY KEY  (`SHOP_ID`,`HERSTELLER_ID`,`SPRACHE_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_info
CREATE TABLE IF NOT EXISTS `back_info` (
  `LFD_NR` int(11) NOT NULL auto_increment,
  `MA_ID` int(11) NOT NULL default '-1',
  `PRIVAT` enum('N','Y') NOT NULL default 'N',
  `QUELLE` tinyint(4) NOT NULL default '0',
  `QUELL_ID` int(11) NOT NULL default '-1',
  `DATUM` date NOT NULL default '0000-00-00',
  `WV_DATUM` date default NULL,
  `WV_FLAG` enum('N','Y') NOT NULL default 'N',
  `ERLEDIGT_FLAG` enum('N','Y') NOT NULL default 'N',
  `ERST_VON` varchar(20) default NULL,
  `KURZTEXT` varchar(100) default NULL,
  `MEMO` text,
  PRIMARY KEY  (`LFD_NR`,`QUELLE`,`DATUM`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_inventur
CREATE TABLE IF NOT EXISTS `back_inventur` (
  `ID` int(5) NOT NULL auto_increment,
  `DATUM` date NOT NULL default '0000-00-00',
  `BESCHREIBUNG` varchar(250) default NULL,
  `INFO` text,
  `STATUS` tinyint(3) unsigned NOT NULL default '0',
  PRIMARY KEY  (`ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COMMENT='Kopfdaten für Inventuren';

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_journal
CREATE TABLE IF NOT EXISTS `back_journal` (
  `TERM_ID` int(11) unsigned NOT NULL default '1',
  `MA_ID` int(11) NOT NULL default '-1',
  `QUELLE` tinyint(4) NOT NULL default '0',
  `REC_ID` int(11) NOT NULL auto_increment,
  `QUELLE_SUB` tinyint(4) default NULL,
  `ADDR_ID` int(11) NOT NULL default '-1',
  `ASP_ID` int(11) NOT NULL default '-1',
  `LIEF_ADDR_ID` int(11) NOT NULL default '-1',
  `PROJEKT_ID` int(11) NOT NULL default '-1',
  `ATRNUM` varchar(20) default '',
  `VRENUM` varchar(20) NOT NULL default '',
  `VLSNUM` varchar(20) default NULL,
  `FOLGENR` int(11) NOT NULL default '-1',
  `KM_STAND` int(11) default NULL,
  `KFZ_ID` int(11) NOT NULL default '-1',
  `VERTRETER_ID` int(11) NOT NULL default '-1',
  `VERTRETER_ABR_ID` int(11) NOT NULL default '-1',
  `GLOBRABATT` float(10,2) NOT NULL default '0.00',
  `ADATUM` date default NULL,
  `RDATUM` datetime NOT NULL default '0000-00-00 00:00:00',
  `LDATUM` date default NULL,
  `KLASSE_ID` tinyint(3) unsigned NOT NULL default '0',
  `TERMIN` date default NULL,
  `PR_EBENE` tinyint(4) default NULL,
  `LIEFART` tinyint(2) NOT NULL default '-1',
  `ZAHLART` tinyint(2) NOT NULL default '-1',
  `GEWICHT` float(10,3) NOT NULL default '0.000',
  `KOST_NETTO` decimal(10,2) NOT NULL default '0.00',
  `WERT_NETTO` decimal(10,2) NOT NULL default '0.00',
  `LOHN` decimal(10,2) NOT NULL default '0.00',
  `WARE` decimal(10,2) NOT NULL default '0.00',
  `TKOST` decimal(10,2) NOT NULL default '0.00',
  `ROHGEWINN` decimal(10,2) NOT NULL default '0.00',
  `MWST_0` decimal(5,2) NOT NULL default '0.00',
  `MWST_1` decimal(5,2) NOT NULL default '0.00',
  `MWST_2` decimal(5,2) NOT NULL default '0.00',
  `MWST_3` decimal(5,2) NOT NULL default '0.00',
  `NSUMME_0` decimal(10,2) NOT NULL default '0.00',
  `NSUMME_1` decimal(10,2) NOT NULL default '0.00',
  `NSUMME_2` decimal(10,2) NOT NULL default '0.00',
  `NSUMME_3` decimal(10,2) NOT NULL default '0.00',
  `NSUMME` decimal(10,2) NOT NULL default '0.00',
  `MSUMME_0` decimal(10,2) NOT NULL default '0.00',
  `MSUMME_1` decimal(10,2) NOT NULL default '0.00',
  `MSUMME_2` decimal(10,2) NOT NULL default '0.00',
  `MSUMME_3` decimal(10,2) NOT NULL default '0.00',
  `MSUMME` decimal(10,2) NOT NULL default '0.00',
  `BSUMME_0` decimal(10,2) NOT NULL default '0.00',
  `BSUMME_1` decimal(10,2) NOT NULL default '0.00',
  `BSUMME_2` decimal(10,2) NOT NULL default '0.00',
  `BSUMME_3` decimal(10,2) NOT NULL default '0.00',
  `BSUMME` decimal(10,2) NOT NULL default '0.00',
  `ATSUMME` decimal(10,2) NOT NULL default '0.00',
  `ATMSUMME` decimal(10,2) NOT NULL default '0.00',
  `PROVIS_WERT` decimal(10,2) NOT NULL default '0.00',
  `WAEHRUNG` varchar(5) NOT NULL default '',
  `KURS` decimal(16,4) NOT NULL default '1.0000',
  `GEGENKONTO` int(11) NOT NULL default '-1',
  `SOLL_NTAGE` int(4) unsigned NOT NULL default '0',
  `SOLL_SKONTO` float(5,2) NOT NULL default '0.00',
  `SOLL_STAGE` int(4) unsigned NOT NULL default '0',
  `SOLL_RATEN` tinyint(4) NOT NULL default '1',
  `SOLL_RATBETR` decimal(10,2) NOT NULL default '0.00',
  `SOLL_RATINTERVALL` int(11) NOT NULL default '0',
  `STADIUM` tinyint(4) NOT NULL default '0',
  `POS_TA_ID` int(11) NOT NULL default '-1',
  `ERSTELLT` date default NULL,
  `ERST_NAME` varchar(20) default NULL,
  `KUN_NUM` varchar(20) default NULL,
  `KUN_ANREDE` varchar(40) default NULL,
  `KUN_NAME1` varchar(40) default NULL,
  `KUN_NAME2` varchar(40) default NULL,
  `KUN_NAME3` varchar(40) default NULL,
  `KUN_ABTEILUNG` varchar(40) default NULL,
  `KUN_STRASSE` varchar(40) default NULL,
  `KUN_LAND` varchar(5) default NULL,
  `KUN_PLZ` varchar(10) default NULL,
  `KUN_ORT` varchar(40) default NULL,
  `USR1` varchar(80) default NULL,
  `USR2` varchar(80) default NULL,
  `KOPFTEXT` text,
  `FUSSTEXT` text,
  `PROJEKT` varchar(80) default NULL,
  `ORGNUM` varchar(20) default NULL,
  `BEST_NAME` varchar(40) default NULL,
  `BEST_CODE` tinyint(4) default NULL,
  `BEST_DATUM` date default NULL,
  `INFO` text,
  `FREIGABE1_FLAG` enum('N','Y') NOT NULL default 'N',
  `PRINT_FLAG` enum('N','Y') NOT NULL default 'N',
  `BRUTTO_FLAG` enum('N','Y') NOT NULL default 'N',
  `MWST_FREI_FLAG` enum('N','Y') NOT NULL default 'N',
  `PROVIS_BERECHNET` enum('N','Y') NOT NULL default 'N',
  `SHOP_ID` tinyint(3) NOT NULL default '-1',
  `SHOP_ORDERID` int(11) NOT NULL default '-1',
  `SHOP_STATUS` tinyint(3) unsigned NOT NULL default '0',
  `SHOP_CHANGE_FLAG` enum('N','Y') NOT NULL default 'N',
  `AUSLAND_TYP` tinyint(1) unsigned NOT NULL default '0',
  PRIMARY KEY  (`REC_ID`),
  KEY `RJ_RENUM` (`QUELLE`,`VRENUM`),
  KEY `ADDR_ID` (`ADDR_ID`,`RDATUM`),
  KEY `IDX_QUELLE_RDATUM` (`QUELLE`,`QUELLE_SUB`,`RDATUM`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_journalpos
CREATE TABLE IF NOT EXISTS `back_journalpos` (
  `REC_ID` int(11) NOT NULL auto_increment,
  `QUELLE` tinyint(4) NOT NULL default '0',
  `QUELLE_SUB` tinyint(4) NOT NULL default '0',
  `QUELLE_SRC` int(11) NOT NULL default '-1',
  `PROJEKT_ID` int(11) NOT NULL default '-1',
  `JOURNAL_ID` int(11) NOT NULL default '0',
  `WARENGRUPPE` int(11) NOT NULL default '-1',
  `ARTIKELTYP` char(1) NOT NULL default '',
  `ARTIKEL_ID` int(11) NOT NULL default '-1',
  `TOP_POS_ID` int(11) NOT NULL default '-1',
  `ADDR_ID` int(11) NOT NULL default '-1',
  `LTERMIN` date default NULL,
  `ATRNUM` varchar(20) default '',
  `VRENUM` varchar(20) NOT NULL default '',
  `POSITION` int(11) NOT NULL default '0',
  `VIEW_POS` char(3) default NULL,
  `MATCHCODE` varchar(20) default NULL,
  `ARTNUM` varchar(20) default NULL,
  `BARCODE` varchar(20) default NULL,
  `MENGE` decimal(10,3) NOT NULL default '0.000',
  `LAENGE` varchar(20) default NULL,
  `BREITE` varchar(20) default NULL,
  `HOEHE` varchar(20) default NULL,
  `GROESSE` varchar(20) default NULL,
  `DIMENSION` varchar(20) default NULL,
  `GEWICHT` decimal(10,3) NOT NULL default '0.000',
  `ME_EINHEIT` varchar(10) default NULL,
  `PR_EINHEIT` decimal(10,3) NOT NULL default '1.000',
  `VPE` decimal(10,3) NOT NULL default '1.000',
  `EK_PREIS` decimal(10,4) NOT NULL default '0.0000',
  `CALC_FAKTOR` decimal(6,5) NOT NULL default '0.00000',
  `EPREIS` decimal(10,4) NOT NULL default '0.0000',
  `GPREIS` decimal(10,2) NOT NULL default '0.00',
  `E_RGEWINN` decimal(10,4) NOT NULL default '0.0000',
  `G_RGEWINN` decimal(10,2) NOT NULL default '0.00',
  `RABATT` decimal(10,2) NOT NULL default '0.00',
  `RABATT2` decimal(10,2) NOT NULL default '0.00',
  `RABATT3` decimal(10,2) NOT NULL default '0.00',
  `E_RABATT_BETRAG` decimal(10,4) NOT NULL default '0.0000',
  `G_RABATT_BETRAG` decimal(10,2) NOT NULL default '0.00',
  `STEUER_CODE` tinyint(4) NOT NULL default '0',
  `ALTTEIL_PROZ` decimal(10,2) NOT NULL default '0.10',
  `ALTTEIL_STCODE` tinyint(4) NOT NULL default '0',
  `PROVIS_PROZ` decimal(5,2) NOT NULL default '0.00',
  `PROVIS_WERT` decimal(10,2) NOT NULL default '0.00',
  `GEBUCHT` enum('N','Y') NOT NULL default 'N',
  `GEGENKTO` int(11) NOT NULL default '-1',
  `BEZEICHNUNG` text,
  `SN_FLAG` enum('N','Y') NOT NULL default 'N',
  `ALTTEIL_FLAG` enum('N','Y') NOT NULL default 'N',
  `BEZ_FEST_FLAG` enum('N','Y') NOT NULL default 'N',
  `BRUTTO_FLAG` enum('N','Y') NOT NULL default 'N',
  `NO_RABATT_FLAG` enum('N','Y') NOT NULL default 'N',
  `APOS_FLAG` enum('N','Y') NOT NULL default 'N',
  PRIMARY KEY  (`REC_ID`),
  KEY `ARTIKEL_ID` (`ARTIKEL_ID`),
  KEY `ADDR_ID` (`ADDR_ID`),
  KEY `JOURNAL_ID` (`JOURNAL_ID`,`POSITION`),
  KEY `QUELLE_SRC` (`QUELLE_SRC`),
  KEY `IDX_QUELLE` (`QUELLE`),
  KEY `IDX_QSRC` (`QUELLE_SRC`,`QUELLE`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_journalpos_sernum
CREATE TABLE IF NOT EXISTS `back_journalpos_sernum` (
  `QUELLE` tinyint(2) unsigned NOT NULL default '0',
  `JOURNAL_ID` int(11) NOT NULL default '-1',
  `JOURNALPOS_ID` int(11) NOT NULL default '-1',
  `ARTIKEL_ID` int(11) NOT NULL default '-1',
  `SNUM_ID` int(11) NOT NULL default '-1',
  PRIMARY KEY  (`QUELLE`,`JOURNAL_ID`,`JOURNALPOS_ID`,`ARTIKEL_ID`,`SNUM_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_journal_op
CREATE TABLE IF NOT EXISTS `back_journal_op` (
  `QUELLE` tinyint(3) unsigned NOT NULL default '0',
  `ADDR_ID` int(11) unsigned NOT NULL default '0',
  `JOURNAL_ID` int(11) unsigned NOT NULL default '0',
  `BSUMME` decimal(10,2) NOT NULL default '0.00',
  `ZAHLUNGEN_ANZ` int(3) unsigned NOT NULL default '0',
  `ZAHLUNGEN_SUM` decimal(10,2) NOT NULL default '0.00',
  `WAEHRUNG` varchar(5) NOT NULL default '',
  PRIMARY KEY  (`JOURNAL_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_journal_ssh
CREATE TABLE IF NOT EXISTS `back_journal_ssh` (
  `ID` int(11) unsigned NOT NULL auto_increment,
  `JOURNAL_ID` int(11) unsigned NOT NULL default '0',
  `DATUM` datetime NOT NULL default '0000-00-00 00:00:00',
  `KOMMENTAR` text,
  `KUNDE_BENACHRICHTIGT` enum('N','Y') NOT NULL default 'N',
  `SHOP_ID` int(3) unsigned default '0',
  `SHOP_STATUS` tinyint(3) unsigned NOT NULL default '0',
  `SHOP_ORDERID` int(3) unsigned NOT NULL default '0',
  `SHOP_CHANGE_FLAG` enum('N','Y') NOT NULL default 'Y',
  PRIMARY KEY  (`ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COMMENT='Journal-Shop-Status-Historie';

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_kfz
CREATE TABLE IF NOT EXISTS `back_kfz` (
  `KFZ_ID` int(11) NOT NULL auto_increment,
  `ADDR_ID` int(11) NOT NULL default '0',
  `FGST_NUM` varchar(20) NOT NULL default '',
  `KFZ_GRUPPE` tinyint(4) default NULL,
  `POL_KENNZ` varchar(10) NOT NULL default '',
  `SCHL_ZU_1` int(6) unsigned default NULL,
  `SCHL_ZU_2` varchar(20) default NULL,
  `SCHL_ZU_3` varchar(20) default NULL,
  `TYP_ID` int(11) default NULL,
  `TYP` varchar(25) default NULL,
  `AUSFUER` varchar(25) default NULL,
  `ANTRIEBSART_ID` int(2) NOT NULL default '0',
  `FABRIKAT_ID` int(11) default NULL,
  `FABRIKAT` varchar(25) default NULL,
  `KRAFTSTOFF_ID` int(11) default NULL,
  `GRUPPE` int(11) default NULL,
  `SCHLUES_NR_ME` varchar(20) default NULL,
  `SCHLUES_NR_EL` varchar(20) default NULL,
  `ZSCHL_NR` varchar(10) default NULL,
  `MOTOR_NR` varchar(20) default NULL,
  `KFZBRI_NR` varchar(15) default NULL,
  `MOTOR` varchar(15) default NULL,
  `GETRIEBE` varchar(10) default NULL,
  `KW` int(11) default NULL,
  `PS` int(11) default NULL,
  `KM_STAND` int(11) default NULL,
  `HUBRAUM` int(11) default NULL,
  `ZUL_GESGEWICHT` int(5) unsigned NOT NULL default '0',
  `REIFEN1` varchar(30) default NULL,
  `REIFEN2` varchar(30) default NULL,
  `REIFEN3` varchar(30) default NULL,
  `REIFEN4` varchar(30) default NULL,
  `REIFEN1_GR` varchar(10) default NULL,
  `REIFEN2_GR` varchar(30) default NULL,
  `REIFEN3_GR` varchar(30) default NULL,
  `REIFEN4_GR` varchar(30) default NULL,
  `PROFIL_VL` decimal(5,1) default NULL,
  `PROFIL_VR` decimal(5,1) default NULL,
  `PROFIL_HL` decimal(5,1) default NULL,
  `PROFIL_HR` decimal(5,1) default NULL,
  `FARBE` varchar(10) default NULL,
  `POLSTER` varchar(10) default NULL,
  `RADIO_CODE` varchar(100) default NULL,
  `ZULASSUNG` date default NULL,
  `HERSTELLUNG` date default NULL,
  `KAUFDATUM` date default NULL,
  `LE_BESUCH` date default NULL,
  `NAE_TUEV` date default NULL,
  `NAE_AU` date default NULL,
  `NAE_SP` date default NULL,
  `NAE_TP` date default NULL,
  `NAE_GASPR` date default NULL,
  `NAE_UVVPR` date default NULL,
  `EK_PREIS` double default NULL,
  `RUESTK` double default NULL,
  `VK_NETTO` double default NULL,
  `MWST_PROZ` double default NULL,
  `UMSATZ_GES` double default NULL,
  `UMSATZ_GAR` double default NULL,
  `VERTRETER_ID` int(11) NOT NULL default '-1',
  `INFO` text,
  `WKST_INFO` text,
  `USERFELD_01` varchar(255) default NULL,
  `USERFELD_02` varchar(255) default NULL,
  `USERFELD_03` varchar(255) default NULL,
  `USERFELD_04` varchar(255) default NULL,
  `USERFELD_05` varchar(255) default NULL,
  `USERFELD_06` varchar(255) default NULL,
  `USERFELD_07` varchar(255) default NULL,
  `USERFELD_08` varchar(255) default NULL,
  `USERFELD_09` varchar(255) default NULL,
  `USERFELD_10` varchar(255) default NULL,
  PRIMARY KEY  (`KFZ_ID`),
  KEY `KUNNUM` (`ADDR_ID`),
  KEY `KENNZ` (`POL_KENNZ`),
  KEY `FGST_NR` (`FGST_NUM`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_land
CREATE TABLE IF NOT EXISTS `back_land` (
  `ID` char(2) NOT NULL default '',
  `NAME` varchar(100) NOT NULL default '',
  `NAME2` varchar(255) NOT NULL default '',
  `ISO_CODE_3` char(3) NOT NULL default '',
  `POST_CODE` char(3) default NULL,
  `FORMAT` tinyint(3) NOT NULL default '1',
  `VORWAHL` varchar(10) default NULL,
  `WAEHRUNG` varchar(5) default NULL,
  `WAEHRUNG_LANG` varchar(100) default NULL,
  `SPRACHE` char(3) default NULL,
  `EU_LAND` enum('N','Y') NOT NULL default 'N',
  PRIMARY KEY  (`ID`),
  UNIQUE KEY `IDX_NAME` (`NAME`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_lieferschein
CREATE TABLE IF NOT EXISTS `back_lieferschein` (
  `TERM_ID` int(11) unsigned NOT NULL default '1',
  `MA_ID` int(11) NOT NULL default '-1',
  `REC_ID` int(11) NOT NULL auto_increment,
  `EDI_FLAG` enum('N','Y') NOT NULL default 'N',
  `STORNO_FLAG` enum('N','Y') NOT NULL default 'N',
  `ADDR_ID` int(11) NOT NULL default '-1',
  `ASP_ID` int(11) NOT NULL default '-1',
  `LIEF_ADDR_ID` int(11) NOT NULL default '-1',
  `PROJEKT_ID` int(11) NOT NULL default '-1',
  `ATRNUM` varchar(20) default NULL,
  `VLSNUM` varchar(20) NOT NULL default '',
  `KM_STAND` int(11) default NULL,
  `KFZ_ID` int(11) NOT NULL default '-1',
  `VERTRETER_ID` int(11) NOT NULL default '-1',
  `GLOBRABATT` float(10,2) NOT NULL default '0.00',
  `ADATUM` date default NULL,
  `LDATUM` date default NULL,
  `KLASSE_ID` tinyint(3) unsigned NOT NULL default '0',
  `TERMIN` date default NULL,
  `PR_EBENE` tinyint(4) default NULL,
  `LIEFART` tinyint(2) NOT NULL default '-1',
  `ZAHLART` tinyint(2) NOT NULL default '-1',
  `GEWICHT` float(10,3) NOT NULL default '0.000',
  `LOHN` decimal(10,2) NOT NULL default '0.00',
  `WARE` decimal(10,2) NOT NULL default '0.00',
  `ROHGEWINN` decimal(10,2) NOT NULL default '0.00',
  `TKOST` decimal(10,2) NOT NULL default '0.00',
  `WERT_NETTO` decimal(10,2) NOT NULL default '0.00',
  `KOST_NETTO` decimal(10,2) NOT NULL default '0.00',
  `MWST_0` decimal(10,2) NOT NULL default '0.00',
  `MWST_1` decimal(10,2) NOT NULL default '0.00',
  `MWST_2` decimal(10,2) NOT NULL default '0.00',
  `MWST_3` decimal(10,2) NOT NULL default '0.00',
  `NSUMME_0` decimal(10,2) NOT NULL default '0.00',
  `NSUMME_1` decimal(10,2) NOT NULL default '0.00',
  `NSUMME_2` decimal(10,2) NOT NULL default '0.00',
  `NSUMME_3` decimal(10,2) NOT NULL default '0.00',
  `NSUMME` decimal(10,2) NOT NULL default '0.00',
  `MSUMME_0` decimal(10,2) NOT NULL default '0.00',
  `MSUMME_1` decimal(10,2) NOT NULL default '0.00',
  `MSUMME_2` decimal(10,2) NOT NULL default '0.00',
  `MSUMME_3` decimal(10,2) NOT NULL default '0.00',
  `MSUMME` decimal(10,2) NOT NULL default '0.00',
  `BSUMME_0` decimal(10,2) NOT NULL default '0.00',
  `BSUMME_1` decimal(10,2) NOT NULL default '0.00',
  `BSUMME_2` decimal(10,2) NOT NULL default '0.00',
  `BSUMME_3` decimal(10,2) NOT NULL default '0.00',
  `BSUMME` decimal(10,2) NOT NULL default '0.00',
  `ATSUMME` decimal(10,2) NOT NULL default '0.00',
  `ATMSUMME` decimal(10,2) NOT NULL default '0.00',
  `PROVIS_WERT` decimal(10,2) NOT NULL default '0.00',
  `WAEHRUNG` varchar(5) NOT NULL default '',
  `KURS` decimal(16,4) NOT NULL default '1.0000',
  `GEGENKONTO` int(11) NOT NULL default '-1',
  `SOLL_STAGE` int(4) unsigned NOT NULL default '0',
  `SOLL_SKONTO` float(5,2) NOT NULL default '0.00',
  `SOLL_NTAGE` int(4) unsigned NOT NULL default '0',
  `SOLL_RATEN` tinyint(4) NOT NULL default '1',
  `SOLL_RATBETR` decimal(10,2) NOT NULL default '0.00',
  `SOLL_RATINTERVALL` int(11) NOT NULL default '0',
  `ERSTELLT` date default NULL,
  `ERST_NAME` varchar(20) default NULL,
  `KUN_NUM` varchar(20) default NULL,
  `KUN_ANREDE` varchar(40) default NULL,
  `KUN_NAME1` varchar(40) default NULL,
  `KUN_NAME2` varchar(40) default NULL,
  `KUN_NAME3` varchar(40) default NULL,
  `KUN_ABTEILUNG` varchar(40) default NULL,
  `KUN_STRASSE` varchar(40) default NULL,
  `KUN_LAND` varchar(5) default NULL,
  `KUN_PLZ` varchar(10) default NULL,
  `KUN_ORT` varchar(40) default NULL,
  `USR1` varchar(80) default NULL,
  `USR2` varchar(80) default NULL,
  `KOPFTEXT` text,
  `FUSSTEXT` text,
  `PROJEKT` varchar(80) default NULL,
  `ORGNUM` varchar(20) default NULL,
  `BEST_NAME` varchar(40) default NULL,
  `BEST_CODE` tinyint(4) default NULL,
  `BEST_DATUM` date default NULL,
  `INFO` text,
  `FREIGABE1_FLAG` enum('N','Y') NOT NULL default 'N',
  `PRINT_FLAG` enum('N','Y') NOT NULL default 'N',
  `BRUTTO_FLAG` enum('N','Y') NOT NULL default 'N',
  `MWST_FREI_FLAG` enum('N','Y') NOT NULL default 'N',
  PRIMARY KEY  (`REC_ID`),
  UNIQUE KEY `IDX_VLSNUM` (`VLSNUM`),
  KEY `ADDR_ID` (`ADDR_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_lieferschein_pos
CREATE TABLE IF NOT EXISTS `back_lieferschein_pos` (
  `REC_ID` int(11) NOT NULL auto_increment,
  `PROJEKT_ID` int(11) NOT NULL default '-1',
  `RECHPOS_ID` int(11) NOT NULL default '-1',
  `LIEFERSCHEIN_ID` int(11) NOT NULL default '0',
  `WARENGRUPPE` int(11) NOT NULL default '-1',
  `ARTIKELTYP` char(1) NOT NULL default '',
  `ARTIKEL_ID` int(11) NOT NULL default '-1',
  `TOP_POS_ID` int(11) NOT NULL default '-1',
  `ADDR_ID` int(11) NOT NULL default '-1',
  `ATRNUM` varchar(20) default NULL,
  `VRENUM` varchar(20) default NULL,
  `VLSNUM` varchar(20) NOT NULL default '',
  `POSITION` int(11) NOT NULL default '0',
  `VIEW_POS` char(3) default NULL,
  `MATCHCODE` varchar(20) default NULL,
  `ARTNUM` varchar(20) default NULL,
  `BARCODE` varchar(20) default NULL,
  `MENGE` decimal(10,3) NOT NULL default '0.000',
  `MENGE_BEST` decimal(10,3) NOT NULL default '0.000',
  `MENGE_REST` decimal(10,3) NOT NULL default '0.000',
  `LAENGE` varchar(20) default NULL,
  `BREITE` varchar(20) default NULL,
  `HOEHE` varchar(20) default NULL,
  `GROESSE` varchar(20) default NULL,
  `DIMENSION` varchar(20) default NULL,
  `GEWICHT` decimal(10,3) NOT NULL default '0.000',
  `ME_EINHEIT` varchar(10) default NULL,
  `PR_EINHEIT` decimal(10,3) NOT NULL default '1.000',
  `VPE` decimal(10,3) NOT NULL default '1.000',
  `EK_PREIS` decimal(10,4) NOT NULL default '0.0000',
  `CALC_FAKTOR` decimal(6,5) NOT NULL default '0.00000',
  `EPREIS` decimal(10,4) NOT NULL default '0.0000',
  `GPREIS` decimal(10,2) NOT NULL default '0.00',
  `E_RGEWINN` decimal(10,4) NOT NULL default '0.0000',
  `G_RGEWINN` decimal(10,2) NOT NULL default '0.00',
  `RABATT` decimal(10,2) NOT NULL default '0.00',
  `RABATT2` decimal(10,2) NOT NULL default '0.00',
  `RABATT3` decimal(10,2) NOT NULL default '0.00',
  `E_RABATT_BETRAG` decimal(10,4) NOT NULL default '0.0000',
  `G_RABATT_BETRAG` decimal(10,2) NOT NULL default '0.00',
  `STEUER_CODE` tinyint(4) NOT NULL default '0',
  `ALTTEIL_PROZ` decimal(10,2) NOT NULL default '0.10',
  `ALTTEIL_STCODE` tinyint(4) NOT NULL default '0',
  `PROVIS_PROZ` decimal(5,2) NOT NULL default '0.00',
  `PROVIS_WERT` decimal(10,2) NOT NULL default '0.00',
  `GEGENKTO` int(11) NOT NULL default '-1',
  `BEZEICHNUNG` text,
  `GEBUCHT` enum('N','Y') NOT NULL default 'N',
  `SN_FLAG` enum('N','Y') NOT NULL default 'N',
  `ALTTEIL_FLAG` enum('N','Y') NOT NULL default 'N',
  `BEZ_FEST_FLAG` enum('N','Y') NOT NULL default 'N',
  `BRUTTO_FLAG` enum('N','Y') NOT NULL default 'N',
  `NO_RABATT_FLAG` enum('N','Y') NOT NULL default 'N',
  PRIMARY KEY  (`REC_ID`),
  KEY `ARTIKEL_ID` (`ARTIKEL_ID`),
  KEY `JOURNAL_ID` (`LIEFERSCHEIN_ID`,`POSITION`),
  KEY `QUELLE_SRC` (`RECHPOS_ID`),
  KEY `IDX_QSRC` (`RECHPOS_ID`),
  KEY `ADDR_ID` (`ADDR_ID`),
  KEY `IDX_QUELLE_ARTID` (`ARTIKEL_ID`,`ARTIKELTYP`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_lieferzeiten
CREATE TABLE IF NOT EXISTS `back_lieferzeiten` (
  `REC_ID` int(11) unsigned NOT NULL auto_increment,
  `BEZEICHNUNG` varchar(50) NOT NULL default '',
  PRIMARY KEY  (`REC_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_link
CREATE TABLE IF NOT EXISTS `back_link` (
  `MODUL_ID` tinyint(3) NOT NULL default '-1',
  `REC_ID` int(11) NOT NULL default '-1',
  `PFAD` varchar(255) NOT NULL default '',
  `DATEI` varchar(200) NOT NULL default '',
  `BEMERKUNG` text,
  `LAST_CHANGE` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  `LAST_CHANGE_USER` varchar(50) NOT NULL default '',
  `OPEN_FLAG` enum('N','Y') NOT NULL default 'N',
  `OPEN_USER` varchar(50) NOT NULL default '',
  `OPEN_TIME` timestamp NOT NULL default '0000-00-00 00:00:00',
  PRIMARY KEY  (`MODUL_ID`,`REC_ID`,`PFAD`,`DATEI`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_mahnung
CREATE TABLE IF NOT EXISTS `back_mahnung` (
  `JOURNAL_ID` int(11) unsigned NOT NULL default '0',
  `ADDR_ID` int(11) unsigned NOT NULL default '0',
  `MAHNSTUFE` tinyint(1) unsigned NOT NULL default '1',
  `MAHNDATUM` date NOT NULL default '0000-00-00',
  `MAHNGEBUEHR` double(10,2) NOT NULL default '0.00',
  `ZIELDATUM` date NOT NULL default '0000-00-00',
  `MA_ID` int(11) NOT NULL default '-1',
  `BEMERKUNG` text,
  `ERLEDIGT` enum('N','Y') NOT NULL default 'N',
  `PRINT_FLAG` enum('N','Y') NOT NULL default 'N',
  `MAHN_STATUS` enum('O','F','S','E') NOT NULL default 'O',
  PRIMARY KEY  (`JOURNAL_ID`,`MAHNSTUFE`),
  KEY `IDX_ADDR_ID` (`ADDR_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_mail
CREATE TABLE IF NOT EXISTS `back_mail` (
  `ID` int(11) unsigned NOT NULL auto_increment,
  `MAIL_ID` varchar(255) NOT NULL default '',
  `MA_ID` int(11) unsigned NOT NULL default '0',
  `MA_KONTO_ID` int(11) unsigned NOT NULL default '0',
  `SRC_ID` int(11) unsigned NOT NULL default '0',
  `UIDL` varchar(200) default NULL,
  `TYP` tinyint(1) unsigned NOT NULL default '1',
  `ADDR_ID` int(11) NOT NULL default '-1',
  `ADDR_ASP_ID` int(11) NOT NULL default '-1',
  `GROESSE` bigint(16) unsigned NOT NULL default '0',
  `SDATUM` datetime NOT NULL default '0000-00-00 00:00:00',
  `EDATUM` datetime NOT NULL default '0000-00-00 00:00:00',
  `ORDNER_ID` int(11) unsigned NOT NULL default '1',
  `SENDER` varchar(255) NOT NULL default '',
  `EMPFAENGER` text NOT NULL,
  `CC` text,
  `BCC` text,
  `BETREFF` varchar(255) default NULL,
  `NACHRICHT_TEXT` mediumtext,
  `HEADER` text,
  `STATUS` int(5) unsigned NOT NULL default '0',
  `ANHANG_ANZ` int(3) unsigned NOT NULL default '0',
  `PRIOR` tinyint(1) unsigned NOT NULL default '2',
  `SPRACHE` varchar(100) default NULL,
  PRIMARY KEY  (`ID`),
  UNIQUE KEY `IDX_MAIL_ID` (`MA_ID`,`MA_KONTO_ID`,`MAIL_ID`),
  KEY `IDX_MA_ORDNER` (`MA_ID`,`ORDNER_ID`,`STATUS`),
  KEY `IDX_MA_KONTO_ID` (`MA_KONTO_ID`,`STATUS`),
  KEY `IDX_SRC` (`MA_ID`,`SRC_ID`),
  KEY `IDX_UIDL` (`MA_ID`,`MA_KONTO_ID`,`UIDL`),
  KEY `IDX_KTO_MAIL` (`MA_ID`,`ORDNER_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_mail_adressen
CREATE TABLE IF NOT EXISTS `back_mail_adressen` (
  `EMAIL` varchar(150) NOT NULL default '',
  `ADDR_ID` int(11) NOT NULL default '-1',
  `ASP_ID` int(11) NOT NULL default '-1',
  PRIMARY KEY  (`EMAIL`,`ADDR_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_mail_anhang
CREATE TABLE IF NOT EXISTS `back_mail_anhang` (
  `MAIL_ID` int(11) unsigned NOT NULL default '0',
  `PART_ID` int(11) unsigned NOT NULL default '0',
  `TYP` varchar(250) default NULL,
  `DATEINAME` varchar(255) default NULL,
  `DATA` longblob,
  `GROESSE` bigint(20) unsigned NOT NULL default '0',
  PRIMARY KEY  (`MAIL_ID`,`PART_ID`),
  KEY `MAIL_ID` (`MAIL_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_mail_konten
CREATE TABLE IF NOT EXISTS `back_mail_konten` (
  `MA_ID` int(11) unsigned NOT NULL default '0',
  `KONTO_ID` int(11) unsigned NOT NULL auto_increment,
  `KONTO_NAME` varchar(255) NOT NULL default '',
  `KONTO_DEFAULT` enum('N','Y') NOT NULL default 'N',
  `KONTO_GLOBAL` enum('N','Y') NOT NULL default 'N',
  `KONTO_ORDNER` enum('N','Y') NOT NULL default 'N',
  `POP3_SERVER` varchar(200) default NULL,
  `POP3_USER` varchar(100) default NULL,
  `POP3_PASSWORD` varchar(100) default NULL,
  `POP3_PORT` int(5) unsigned NOT NULL default '110',
  `POP3_EMPFANG_FLAG` enum('N','Y') NOT NULL default 'Y',
  `POP3_DELETE_FLAG` enum('N','Y') NOT NULL default 'N',
  `POP3_DELETE_TAGE` int(5) unsigned NOT NULL default '0',
  `POP3_LE_EMPFANG` datetime NOT NULL default '0000-00-00 00:00:00',
  `SMTP_SERVER` varchar(200) default NULL,
  `SMTP_USER` varchar(100) default NULL,
  `SMTP_PASSWORD` varchar(100) default NULL,
  `SMTP_USERNAME` varchar(255) default NULL,
  `SMTP_PORT` int(5) unsigned NOT NULL default '25',
  `SMTP_EMAIL` varchar(255) default NULL,
  `SMTP_DEFAULT` enum('N','Y') NOT NULL default 'N',
  `SMTP_BCC` varchar(255) default NULL,
  `SMTP_MODE` tinyint(3) unsigned NOT NULL default '1',
  PRIMARY KEY  (`MA_ID`,`KONTO_NAME`),
  UNIQUE KEY `IDX_KTO_ID` (`KONTO_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_mail_ordner
CREATE TABLE IF NOT EXISTS `back_mail_ordner` (
  `MA_ID` int(11) unsigned NOT NULL default '0',
  `ORDNER_ID` int(11) unsigned NOT NULL auto_increment,
  `KONTO_ID` int(11) unsigned NOT NULL default '0',
  `ORDNER_NAME` varchar(200) NOT NULL default '',
  `ORDNER_TYP` enum('PE','PA','GO','DE','EW','GLOB','-') NOT NULL default '-',
  `PARRENT_ORDNER` int(11) NOT NULL default '-1',
  PRIMARY KEY  (`ORDNER_ID`),
  KEY `IDX_MA_ORD` (`MA_ID`,`KONTO_ID`,`ORDNER_ID`,`ORDNER_TYP`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_mail_regeln
CREATE TABLE IF NOT EXISTS `back_mail_regeln` (
  `MA_ID` int(11) unsigned NOT NULL default '0',
  `REGELNAME` varchar(100) NOT NULL default '',
  `MA_KONTO_ID` int(11) unsigned NOT NULL default '0',
  `REGEL_AKTIV` enum('N','Y') NOT NULL default 'Y',
  `POSITION` tinyint(3) unsigned default NULL,
  `BED_KONTO_ID` int(11) unsigned NOT NULL default '0',
  `BED_SENDER` varchar(255) default NULL,
  `BED_EMPF` varchar(255) default NULL,
  `BED_EMPF_OR_CC` varchar(255) default NULL,
  `BED_BETR` varchar(255) default NULL,
  `BED_NTEXT` varchar(255) default NULL,
  `BED_BETR_OR_NTEXT` tinyint(3) unsigned default NULL,
  `BED_PRIOR` tinyint(3) NOT NULL default '-1',
  `AKTIONEN` tinyint(3) unsigned NOT NULL default '0',
  `AKT_ZIELORDNER_ID` int(11) unsigned NOT NULL default '0',
  `AKT_AUTOAW` int(11) unsigned NOT NULL default '0',
  `AKT_WL_EMAIL` varchar(255) default NULL,
  PRIMARY KEY  (`MA_ID`,`REGELNAME`,`MA_KONTO_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_mengeneinheit
CREATE TABLE IF NOT EXISTS `back_mengeneinheit` (
  `REC_ID` int(11) unsigned NOT NULL auto_increment,
  `SPRACHE_ID` int(11) unsigned NOT NULL default '0',
  `BEZEICHNUNG` varchar(50) NOT NULL default '',
  PRIMARY KEY  (`REC_ID`),
  UNIQUE KEY `BEZEICHNUNG` (`BEZEICHNUNG`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_mitarbeiter
CREATE TABLE IF NOT EXISTS `back_mitarbeiter` (
  `MA_ID` int(11) unsigned NOT NULL auto_increment,
  `MA_NUMMER` varchar(10) default NULL,
  `NAME` varchar(100) default NULL,
  `VNAME` varchar(100) default NULL,
  `LOGIN_NAME` varchar(50) NOT NULL default '',
  `ANZEIGE_NAME` varchar(50) NOT NULL default '',
  `USER_PASSWORD` varchar(32) NOT NULL default '',
  `ANREDE` varchar(15) default NULL,
  `TITEL` varchar(15) default NULL,
  `ZUSATZ` varchar(40) default NULL,
  `ZUSATZ2` varchar(40) default NULL,
  `ZUHAENDEN` varchar(40) default NULL,
  `STRASSE` varchar(40) default NULL,
  `LAND` varchar(5) default NULL,
  `PLZ` varchar(10) default NULL,
  `ORT` varchar(40) default NULL,
  `TELEFON` varchar(100) default NULL,
  `FAX` varchar(100) default NULL,
  `FUNK` varchar(100) default NULL,
  `EMAIL` varchar(100) default NULL,
  `INTERNET` varchar(100) default NULL,
  `TELEFON_INTERN` varchar(255) default NULL,
  `SPRACH_ID` smallint(6) default '2',
  `BESCHAEFTIGUNGSART` smallint(6) default NULL,
  `BESCHAEFTIGUNGSGRAD` smallint(6) default NULL,
  `JAHRESURLAUB` float default NULL,
  `GUELTIG_VON` datetime default NULL,
  `GUELTIG_BIS` datetime default NULL,
  `GEBDATUM` datetime default NULL,
  `GESCHLECHT` enum('M','W') NOT NULL default 'M',
  `FAMSTAND` smallint(6) default NULL,
  `BANK` varchar(40) default NULL,
  `BLZ` varchar(10) default NULL,
  `KTO` varchar(20) default NULL,
  `BEMERKUNG` text,
  `ERSTELLT` datetime default NULL,
  `ERSTELLT_NAME` varchar(20) default NULL,
  `GEAEND` datetime default NULL,
  `GEAEND_NAME` varchar(20) default NULL,
  `USERFELD_01` varchar(255) default NULL,
  `USERFELD_02` varchar(255) default NULL,
  `USERFELD_03` varchar(255) default NULL,
  `USERFELD_04` varchar(255) default NULL,
  `USERFELD_05` varchar(255) default NULL,
  `USERFELD_06` varchar(255) default NULL,
  `USERFELD_07` varchar(255) default NULL,
  `USERFELD_08` varchar(255) default NULL,
  `USERFELD_09` varchar(255) default NULL,
  `USERFELD_10` varchar(255) default NULL,
  PRIMARY KEY  (`MA_ID`),
  UNIQUE KEY `IDX_LOGINNAME` (`LOGIN_NAME`),
  UNIQUE KEY `IDX_MA_NUM` (`MA_NUMMER`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_pim_aufgaben
CREATE TABLE IF NOT EXISTS `back_pim_aufgaben` (
  `RECORDID` int(11) NOT NULL auto_increment,
  `RESOURCEID` int(11) NOT NULL default '0',
  `COMPLETE` enum('N','Y') default 'N',
  `DESCRIPTION` char(255) default NULL,
  `DETAILS` char(255) default NULL,
  `CREATEDON` datetime default NULL,
  `PRIORITY` int(11) default NULL,
  `CATEGORY` int(11) default NULL,
  `COMPLETEDON` datetime default NULL,
  `DUEDATE` datetime default NULL,
  `PRIVATE` enum('N','Y') NOT NULL default 'N',
  `USERFIELD0` char(100) default NULL,
  `USERFIELD1` char(100) default NULL,
  `USERFIELD2` char(100) default NULL,
  `USERFIELD3` char(100) default NULL,
  `USERFIELD4` char(100) default NULL,
  `USERFIELD5` char(100) default NULL,
  `USERFIELD6` char(100) default NULL,
  `USERFIELD7` char(100) default NULL,
  `USERFIELD8` char(100) default NULL,
  `USERFIELD9` char(100) default NULL,
  PRIMARY KEY  (`RECORDID`),
  KEY `ResID_ndx` (`RESOURCEID`),
  KEY `DueDate` (`DUEDATE`),
  KEY `CompletedOn` (`COMPLETEDON`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_pim_kontakte
CREATE TABLE IF NOT EXISTS `back_pim_kontakte` (
  `RECORDID` int(11) NOT NULL auto_increment,
  `RESOURCEID` int(11) NOT NULL default '0',
  `FIRSTNAME` char(50) default NULL,
  `LASTNAME` char(50) NOT NULL default '',
  `BIRTHDATE` date default NULL,
  `ANNIVERSARY` date default NULL,
  `TITLE` char(50) default NULL,
  `COMPANY` char(50) NOT NULL default '',
  `JOB_POSITION` char(30) default NULL,
  `ADDRESS` char(100) default NULL,
  `CITY` char(50) default NULL,
  `STATE` char(25) default NULL,
  `ZIP` char(10) default NULL,
  `COUNTRY` char(25) default NULL,
  `NOTE` char(255) default NULL,
  `PHONE1` char(25) default NULL,
  `PHONE2` char(25) default NULL,
  `PHONE3` char(25) default NULL,
  `PHONE4` char(25) default NULL,
  `PHONE5` char(25) default NULL,
  `PHONETYPE1` int(11) default NULL,
  `PHONETYPE2` int(11) default NULL,
  `PHONETYPE3` int(11) default NULL,
  `PHONETYPE4` int(11) default NULL,
  `PHONETYPE5` int(11) default NULL,
  `CATEGORY` int(11) default NULL,
  `EMAIL` char(100) default NULL,
  `CUSTOM1` char(100) default NULL,
  `CUSTOM2` char(100) default NULL,
  `CUSTOM3` char(100) default NULL,
  `CUSTOM4` char(100) default NULL,
  `USERFIELD0` char(100) default NULL,
  `USERFIELD1` char(100) default NULL,
  `USERFIELD2` char(100) default NULL,
  `USERFIELD3` char(100) default NULL,
  `USERFIELD4` char(100) default NULL,
  `USERFIELD5` char(100) default NULL,
  `USERFIELD6` char(100) default NULL,
  `USERFIELD7` char(100) default NULL,
  `USERFIELD8` char(100) default NULL,
  `USERFIELD9` char(100) default NULL,
  PRIMARY KEY  (`RECORDID`),
  KEY `ResID_ndx` (`RESOURCEID`),
  KEY `LName_ndx` (`LASTNAME`),
  KEY `Company_ndx` (`COMPANY`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_pim_termine
CREATE TABLE IF NOT EXISTS `back_pim_termine` (
  `RECORDID` int(11) NOT NULL auto_increment,
  `STARTTIME` datetime default NULL,
  `ENDTIME` datetime default NULL,
  `RESOURCEID` int(11) NOT NULL default '0',
  `DESCRIPTION` char(255) default NULL,
  `NOTES` char(255) default NULL,
  `CATEGORY` int(11) default NULL,
  `ALLDAYEVENT` enum('N','Y') NOT NULL default 'N',
  `DINGPATH` char(255) default NULL,
  `ALARMSET` enum('N','Y') NOT NULL default 'N',
  `ALARMADVANCE` int(11) default NULL,
  `ALARMADVANCETYPE` int(11) default NULL,
  `SNOOZETIME` datetime default NULL,
  `REPEATCODE` int(11) default NULL,
  `REPEATRANGEEND` datetime default NULL,
  `CUSTOMINTERVAL` int(11) default NULL,
  `PRIVATE` enum('N','Y') NOT NULL default 'N',
  `USERFIELD0` char(100) default NULL,
  `USERFIELD1` char(100) default NULL,
  `USERFIELD2` char(100) default NULL,
  `USERFIELD3` char(100) default NULL,
  `USERFIELD4` char(100) default NULL,
  `USERFIELD5` char(100) default NULL,
  `USERFIELD6` char(100) default NULL,
  `USERFIELD7` char(100) default NULL,
  `USERFIELD8` char(100) default NULL,
  `USERFIELD9` char(100) default NULL,
  PRIMARY KEY  (`RECORDID`),
  KEY `rid_st_ndx` (`RESOURCEID`,`STARTTIME`),
  KEY `st_ndx` (`STARTTIME`),
  KEY `et_ndx` (`ENDTIME`),
  KEY `ResID_ndx` (`RESOURCEID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_plz
CREATE TABLE IF NOT EXISTS `back_plz` (
  `LAND` char(3) NOT NULL default 'D',
  `PLZ` varchar(11) NOT NULL default '',
  `NAME` varchar(50) NOT NULL default '',
  `VORWAHL` varchar(12) default NULL,
  `BUNDESLAND` char(3) default NULL,
  PRIMARY KEY  (`LAND`,`PLZ`,`NAME`),
  KEY `IDX_NAME` (`LAND`,`NAME`),
  KEY `IDX_VORWAHL` (`LAND`,`VORWAHL`),
  KEY `IDX_LAND` (`LAND`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_pos_ta
CREATE TABLE IF NOT EXISTS `back_pos_ta` (
  `LFD_NR` int(11) unsigned NOT NULL default '0',
  `MA_ID` int(11) NOT NULL default '-1',
  `DATUM_START` datetime NOT NULL default '0000-00-00 00:00:00',
  `DATUM_ENDE` datetime default NULL,
  `WECHSELGELD_START` decimal(12,2) NOT NULL default '0.00',
  `WECHSELGELD_ENDE` decimal(12,2) NOT NULL default '0.00',
  `UMSATZ_ENDE` decimal(12,2) NOT NULL default '0.00',
  `BEMERKUNG` text,
  `ABGERECHNET` enum('N','Y') NOT NULL default 'N',
  `ABGERECHNET_MA` int(11) NOT NULL default '-1',
  PRIMARY KEY  (`LFD_NR`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COMMENT='Tagesabschluß, Anfangs- und Endbestand der Kasse';

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_rabattgruppen
CREATE TABLE IF NOT EXISTS `back_rabattgruppen` (
  `RABGRP_ID` varchar(10) NOT NULL default '',
  `RABGRP_TYP` tinyint(3) NOT NULL default '0',
  `MIN_MENGE` int(11) NOT NULL default '1',
  `LIEF_RABGRP` int(10) NOT NULL default '0',
  `RABATT1` decimal(5,2) NOT NULL default '0.00',
  `RABATT2` decimal(5,2) NOT NULL default '0.00',
  `RABATT3` decimal(5,2) NOT NULL default '0.00',
  `ADDR_ID` int(11) NOT NULL default '-1',
  `BESCHREIBUNG` varchar(250) default NULL,
  PRIMARY KEY  (`RABGRP_ID`,`RABGRP_TYP`,`LIEF_RABGRP`,`MIN_MENGE`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_rabmatrix
CREATE TABLE IF NOT EXISTS `back_rabmatrix` (
  `KUNDENGRUPPE` int(11) unsigned NOT NULL default '0',
  `WARENGRUPPE` int(11) unsigned NOT NULL default '0',
  `VK` tinyint(3) unsigned NOT NULL default '1',
  `RABATT1` decimal(5,2) NOT NULL default '0.00',
  `RABATT2` decimal(5,2) NOT NULL default '0.00',
  `RABATT3` decimal(5,2) NOT NULL default '0.00',
  `SCHWELLWERT` decimal(10,2) default NULL,
  PRIMARY KEY  (`KUNDENGRUPPE`,`WARENGRUPPE`,`VK`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_registry
CREATE TABLE IF NOT EXISTS `back_registry` (
  `MAINKEY` varchar(255) NOT NULL default '',
  `NAME` varchar(100) NOT NULL default '',
  `VAL_CHAR` varchar(255) default NULL,
  `VAL_DATE` datetime default NULL,
  `VAL_INT` int(11) default NULL,
  `VAL_INT2` bigint(20) default NULL,
  `VAL_INT3` bigint(20) default NULL,
  `VAL_DOUBLE` double default NULL,
  `VAL_BLOB` longtext,
  `VAL_BIN` longblob,
  `VAL_TYP` smallint(6) default NULL,
  `CACHABLE` enum('N','Y') NOT NULL default 'N',
  `READONLY` enum('N','Y') NOT NULL default 'N',
  `LAST_CHANGE` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`MAINKEY`,`NAME`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_schriftverkehr
CREATE TABLE IF NOT EXISTS `back_schriftverkehr` (
  `ID` int(11) NOT NULL auto_increment,
  `BESCHREIBUNG` varchar(250) default NULL,
  `LANG_TEXT` longtext,
  `CHANGE_LAST` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  `CHANGE_USER` varchar(100) default NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_schriftverkehr_adr
CREATE TABLE IF NOT EXISTS `back_schriftverkehr_adr` (
  `SCHRIFTVERKEHR_ID` int(11) NOT NULL default '0',
  `ADDR_ID` int(11) NOT NULL default '-1',
  `ASP_ID` int(11) NOT NULL default '-1',
  PRIMARY KEY  (`SCHRIFTVERKEHR_ID`,`ADDR_ID`,`ASP_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_sprachen
CREATE TABLE IF NOT EXISTS `back_sprachen` (
  `SPRACH_ID` int(11) NOT NULL auto_increment,
  `NAME` varchar(32) NOT NULL default '',
  `CODE` char(2) NOT NULL default '',
  `SORT` int(3) default NULL,
  `DEFAULT_FLAG` enum('N','Y') NOT NULL default 'N',
  PRIMARY KEY  (`SPRACH_ID`),
  KEY `IDX_NAME` (`NAME`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_textbausteine
CREATE TABLE IF NOT EXISTS `back_textbausteine` (
  `ID` int(11) unsigned NOT NULL auto_increment,
  `BESCHREIBUNG` varchar(255) NOT NULL default '',
  `LANGTEXT` text NOT NULL,
  PRIMARY KEY  (`ID`),
  KEY `BESCHREIBUNG` (`BESCHREIBUNG`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_ueberweisungen
CREATE TABLE IF NOT EXISTS `back_ueberweisungen` (
  `ID` int(11) NOT NULL auto_increment,
  `UWNUM` int(11) NOT NULL default '0',
  `ART` enum('U','L') NOT NULL default 'U',
  `FERTIG` tinyint(1) default '0',
  `JOURNAL_ID` int(11) NOT NULL default '0',
  `UW_DATUM` date default NULL,
  `BETRAG` decimal(10,2) NOT NULL default '0.00',
  `KTO` varchar(20) default NULL,
  `BLZ` varchar(8) default NULL,
  `BINHABER` varchar(50) default NULL,
  `UW_TEXT` varchar(250) default NULL,
  PRIMARY KEY  (`ID`,`UWNUM`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_vertrag
CREATE TABLE IF NOT EXISTS `back_vertrag` (
  `MA_ID` int(11) NOT NULL default '-1',
  `REC_ID` int(11) NOT NULL auto_increment,
  `ADDR_ID` int(11) NOT NULL default '-1',
  `ASP_ID` int(11) NOT NULL default '-1',
  `PROJEKT_ID` int(11) NOT NULL default '-1',
  `AUSLAND_TYP` tinyint(1) unsigned NOT NULL default '0',
  `VVTNUM` int(11) NOT NULL default '-1',
  `VERTRETER_ID` int(11) NOT NULL default '-1',
  `KLASSE_ID` tinyint(3) unsigned NOT NULL default '0',
  `GLOBRABATT` float(10,2) NOT NULL default '0.00',
  `DATUM_START` date NOT NULL default '0000-00-00',
  `DATUM_ENDE` date NOT NULL default '0000-00-00',
  `DATUM_NEXT` date NOT NULL default '0000-00-00',
  `INTERVALL` char(1) NOT NULL default 'M',
  `INTERVALL_NUM` tinyint(3) unsigned NOT NULL default '1',
  `AKTIV_FLAG` enum('N','Y') NOT NULL default 'N',
  `PRINT_FLAG` enum('N','Y') NOT NULL default 'N',
  `PR_EBENE` tinyint(4) default NULL,
  `LIEFART` tinyint(2) default NULL,
  `ZAHLART` tinyint(2) default NULL,
  `KOST_NETTO` decimal(10,2) NOT NULL default '0.00',
  `WERT_NETTO` decimal(10,2) NOT NULL default '0.00',
  `LOHN` decimal(10,2) NOT NULL default '0.00',
  `WARE` decimal(10,2) NOT NULL default '0.00',
  `TKOST` decimal(10,2) NOT NULL default '0.00',
  `MWST_0` decimal(5,2) NOT NULL default '0.00',
  `MWST_1` decimal(5,2) NOT NULL default '0.00',
  `MWST_2` decimal(5,2) NOT NULL default '0.00',
  `MWST_3` decimal(5,2) NOT NULL default '0.00',
  `NSUMME_0` decimal(10,2) NOT NULL default '0.00',
  `NSUMME_1` decimal(10,2) NOT NULL default '0.00',
  `NSUMME_2` decimal(10,2) NOT NULL default '0.00',
  `NSUMME_3` decimal(10,2) NOT NULL default '0.00',
  `NSUMME` decimal(10,2) NOT NULL default '0.00',
  `MSUMME_0` decimal(10,2) NOT NULL default '0.00',
  `MSUMME_1` decimal(10,2) NOT NULL default '0.00',
  `MSUMME_2` decimal(10,2) NOT NULL default '0.00',
  `MSUMME_3` decimal(10,2) NOT NULL default '0.00',
  `MSUMME` decimal(10,2) NOT NULL default '0.00',
  `BSUMME_0` decimal(10,2) NOT NULL default '0.00',
  `BSUMME_1` decimal(10,2) NOT NULL default '0.00',
  `BSUMME_2` decimal(10,2) NOT NULL default '0.00',
  `BSUMME_3` decimal(10,2) NOT NULL default '0.00',
  `BSUMME` decimal(10,2) NOT NULL default '0.00',
  `ATSUMME` decimal(10,2) NOT NULL default '0.00',
  `ATMSUMME` decimal(10,2) NOT NULL default '0.00',
  `WAEHRUNG` varchar(5) NOT NULL default '',
  `KURS` decimal(16,4) NOT NULL default '1.0000',
  `GEGENKONTO` int(11) NOT NULL default '-1',
  `SOLL_STAGE` tinyint(4) NOT NULL default '0',
  `SOLL_SKONTO` float(5,2) NOT NULL default '0.00',
  `SOLL_NTAGE` tinyint(4) NOT NULL default '0',
  `SOLL_RATEN` tinyint(4) NOT NULL default '1',
  `SOLL_RATBETR` decimal(10,2) NOT NULL default '0.00',
  `SOLL_RATINTERVALL` int(11) NOT NULL default '0',
  `STADIUM` tinyint(4) NOT NULL default '0',
  `ERSTELLT` date default NULL,
  `ERST_NAME` varchar(20) default NULL,
  `KUN_NUM` varchar(20) default NULL,
  `KUN_ANREDE` varchar(40) default NULL,
  `KUN_NAME1` varchar(40) default NULL,
  `KUN_NAME2` varchar(40) default NULL,
  `KUN_NAME3` varchar(40) default NULL,
  `KUN_ABTEILUNG` varchar(40) default NULL,
  `KUN_STRASSE` varchar(40) default NULL,
  `KUN_LAND` varchar(5) default NULL,
  `KUN_PLZ` varchar(10) default NULL,
  `KUN_ORT` varchar(40) default NULL,
  `USR1` varchar(80) default NULL,
  `USR2` varchar(80) default NULL,
  `KOPFTEXT` text,
  `FUSSTEXT` text,
  `PROJEKT` varchar(80) default NULL,
  `ORGNUM` varchar(20) default NULL,
  `BEST_NAME` varchar(40) default NULL,
  `BEST_CODE` tinyint(4) default NULL,
  `BEST_DATUM` date default NULL,
  `INFO` text,
  `BRUTTO_FLAG` enum('N','Y') NOT NULL default 'N',
  `MWST_FREI_FLAG` enum('N','Y') NOT NULL default 'N',
  PRIMARY KEY  (`REC_ID`),
  KEY `ADDR_ID` (`ADDR_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_vertragpos
CREATE TABLE IF NOT EXISTS `back_vertragpos` (
  `REC_ID` int(11) NOT NULL auto_increment,
  `JOURNAL_ID` int(11) NOT NULL default '0',
  `PROJEKT_ID` int(11) NOT NULL default '-1',
  `WARENGRUPPE` int(11) NOT NULL default '-1',
  `ARTIKELTYP` char(1) NOT NULL default '',
  `ARTIKEL_ID` int(11) NOT NULL default '-1',
  `ADDR_ID` int(11) NOT NULL default '-1',
  `VVTNUM` int(11) NOT NULL default '-1',
  `POSITION` int(11) NOT NULL default '0',
  `VIEW_POS` char(3) default NULL,
  `MATCHCODE` varchar(20) default NULL,
  `ARTNUM` varchar(20) default NULL,
  `BARCODE` varchar(20) default NULL,
  `MENGE` decimal(10,3) NOT NULL default '0.000',
  `LAENGE` varchar(20) default NULL,
  `BREITE` varchar(20) default NULL,
  `HOEHE` varchar(20) default NULL,
  `GROESSE` varchar(20) default NULL,
  `DIMENSION` varchar(20) default NULL,
  `GEWICHT` decimal(10,3) NOT NULL default '0.000',
  `ME_EINHEIT` varchar(10) default NULL,
  `PR_EINHEIT` decimal(10,3) NOT NULL default '1.000',
  `VPE` decimal(10,3) NOT NULL default '1.000',
  `EK_PREIS` decimal(10,4) NOT NULL default '0.0000',
  `CALC_FAKTOR` decimal(6,5) NOT NULL default '0.00000',
  `EPREIS` decimal(10,4) NOT NULL default '0.0000',
  `GPREIS` decimal(10,2) NOT NULL default '0.00',
  `E_RGEWINN` decimal(10,4) NOT NULL default '0.0000',
  `G_RGEWINN` decimal(10,2) NOT NULL default '0.00',
  `RABATT` decimal(10,2) NOT NULL default '0.00',
  `RABATT2` decimal(10,2) NOT NULL default '0.00',
  `RABATT3` decimal(10,2) NOT NULL default '0.00',
  `E_RABATT_BETRAG` decimal(10,4) NOT NULL default '0.0000',
  `G_RABATT_BETRAG` decimal(10,2) NOT NULL default '0.00',
  `STEUER_CODE` tinyint(4) NOT NULL default '0',
  `ALTTEIL_PROZ` decimal(10,2) NOT NULL default '0.10',
  `ALTTEIL_STCODE` tinyint(4) NOT NULL default '0',
  `GEGENKTO` int(11) NOT NULL default '-1',
  `BEZEICHNUNG` text,
  `ALTTEIL_FLAG` enum('N','Y') NOT NULL default 'N',
  `BEZ_FEST_FLAG` enum('N','Y') NOT NULL default 'N',
  `BRUTTO_FLAG` enum('N','Y') NOT NULL default 'N',
  `NO_RABATT_FLAG` enum('N','Y') NOT NULL default 'N',
  PRIMARY KEY  (`REC_ID`),
  KEY `ARTIKEL_ID` (`ARTIKEL_ID`),
  KEY `ADDR_ID` (`ADDR_ID`),
  KEY `JOURNAL_ID` (`JOURNAL_ID`,`POSITION`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_vertreter
CREATE TABLE IF NOT EXISTS `back_vertreter` (
  `VERTRETER_ID` int(11) NOT NULL auto_increment,
  `VERTR_NUMMER` varchar(10) default NULL,
  `VNAME` varchar(30) default NULL,
  `NAME` varchar(30) default NULL,
  `DatumNeu` datetime default NULL,
  `DatumBearbeiten` datetime default NULL,
  `BenutzerNeu` varchar(50) default NULL,
  `BenutzerBearbeiten` varchar(50) default NULL,
  `ANREDE` varchar(15) default NULL,
  `TITEL` varchar(15) default NULL,
  `ZUSATZ` varchar(40) default NULL,
  `ZUSATZ2` varchar(40) default NULL,
  `ZUHAENDEN` varchar(40) default NULL,
  `STRASSE` varchar(40) default NULL,
  `LAND` varchar(5) default NULL,
  `PLZ` varchar(10) default NULL,
  `ORT` varchar(40) default NULL,
  `TELEFON` varchar(100) default NULL,
  `FAX` varchar(100) default NULL,
  `FUNK` varchar(100) default NULL,
  `EMAIL` varchar(100) default NULL,
  `INTERNET` varchar(100) default NULL,
  `SPRACH_ID` smallint(6) default '2',
  `PROVISIONSART` char(1) default NULL,
  `ABRECHNUNGSZEITPUNKT` enum('R','Z') default 'Z',
  `PROVISIONMITTRANSPORT` enum('Y','N') default 'N',
  `PROVISIONSATZ` float(5,2) default NULL,
  `LETZTEABRECHNUNG` date default NULL,
  `UMSATZ` decimal(12,2) default NULL,
  `PROVISION` decimal(10,2) default NULL,
  `BESCHAEFTIGUNGSART` smallint(6) default NULL,
  `BESCHAEFTIGUNGSGRAD` smallint(6) default NULL,
  `GUELTIG_VON` datetime default NULL,
  `GUELTIG_BIS` datetime default NULL,
  `GEBDATUM` datetime default NULL,
  `GESCHLECHT` enum('M','W') NOT NULL default 'M',
  `FAMSTAND` smallint(6) default NULL,
  `BANK` varchar(40) default NULL,
  `KTO_INHABER` varchar(40) default NULL,
  `BLZ` varchar(10) default NULL,
  `KTO` varchar(20) default NULL,
  `BEMERKUNG` text,
  `ERSTELLT` datetime default NULL,
  `ERSTELLT_NAME` varchar(20) default NULL,
  `GEAEND` datetime default NULL,
  `GEAEND_NAME` varchar(20) default NULL,
  `USERFELD_01` varchar(255) default NULL,
  `USERFELD_02` varchar(255) default NULL,
  `USERFELD_03` varchar(255) default NULL,
  `USERFELD_04` varchar(255) default NULL,
  `USERFELD_05` varchar(255) default NULL,
  `USERFELD_06` varchar(255) default NULL,
  `USERFELD_07` varchar(255) default NULL,
  `USERFELD_08` varchar(255) default NULL,
  `USERFELD_09` varchar(255) default NULL,
  `USERFELD_10` varchar(255) default NULL,
  PRIMARY KEY  (`VERTRETER_ID`),
  UNIQUE KEY `IDX_VE_NUM` (`VERTR_NUMMER`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_vertreter_abr
CREATE TABLE IF NOT EXISTS `back_vertreter_abr` (
  `VERTRETER_ID` int(11) NOT NULL default '-1',
  `ABRECHNUNG_ID` int(11) unsigned NOT NULL auto_increment,
  `ZEITRAUM_JAHR` int(4) unsigned NOT NULL default '0',
  `ZEITRAUM_MONAT` int(2) unsigned NOT NULL default '0',
  `ABRECHNUNG_NUM` int(11) unsigned NOT NULL default '0',
  `UMSATZ_NETTO` double(10,2) NOT NULL default '0.00',
  `PROVISION_NETTO` double(10,2) NOT NULL default '0.00',
  `BELEG_ERSTELLT` enum('N','Y') NOT NULL default 'N',
  `JOURNAL_ID` int(11) NOT NULL default '0',
  `BEMERKUNG` text,
  `ERSTELLT` datetime NOT NULL default '0000-00-00 00:00:00',
  `ERSTELLT_NAME` varchar(20) default NULL,
  PRIMARY KEY  (`VERTRETER_ID`,`ZEITRAUM_JAHR`,`ZEITRAUM_MONAT`),
  UNIQUE KEY `IDX_VETR_ABR` (`VERTRETER_ID`,`ABRECHNUNG_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_warengruppen
CREATE TABLE IF NOT EXISTS `back_warengruppen` (
  `ID` int(11) NOT NULL auto_increment,
  `TOP_ID` int(11) NOT NULL default '-1',
  `NAME` varchar(250) NOT NULL default '',
  `BESCHREIBUNG` text,
  `DEF_EKTO` int(11) default '-1',
  `DEF_AKTO` int(11) default '-1',
  `STEUER_CODE` tinyint(4) unsigned NOT NULL default '2',
  `VK1_FAKTOR` float(6,5) NOT NULL default '0.00000',
  `VK2_FAKTOR` float(6,5) NOT NULL default '0.00000',
  `VK3_FAKTOR` float(6,5) NOT NULL default '0.00000',
  `VK4_FAKTOR` float(6,5) NOT NULL default '0.00000',
  `VK5_FAKTOR` float(6,5) NOT NULL default '0.00000',
  `VORGABEN` text,
  PRIMARY KEY  (`ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_wartung
CREATE TABLE IF NOT EXISTS `back_wartung` (
  `REC_ID` int(11) NOT NULL auto_increment,
  `ADDR_ID` int(11) NOT NULL default '-1',
  `ASP_ID` int(11) NOT NULL default '-1',
  `BESCHREIBUNG` varchar(255) default NULL,
  `WARTUNG` date default NULL,
  `INTERVALL` int(11) default '0',
  `WVERTRAG` varchar(20) default NULL,
  `BEMERKUNG` text,
  `LEBENSLAUF` text,
  `LISTE` text,
  `WARTUNG_TYP` varchar(20) default NULL,
  `WVERTRAG_NR` smallint(6) default '0',
  `SOLLZEIT_KW` float(3,1) default NULL,
  `SOLLZEIT_GW` float(3,1) default NULL,
  `ENTFERNUNG` int(11) unsigned default NULL,
  `BEM_OPT1` tinyint(1) unsigned default '0',
  `BEM_OPT2` tinyint(1) unsigned default '0',
  `BEM_OPT3` tinyint(1) unsigned default '0',
  `BEM_OPT4` tinyint(1) unsigned default '0',
  `BEM_OPT5` tinyint(1) unsigned default '0',
  `BEM_OPT6` tinyint(1) unsigned default '0',
  `BEM_OPT7` tinyint(1) unsigned default '0',
  `BEM_OPT8` tinyint(1) unsigned default '0',
  `BEM_OPT9` tinyint(1) unsigned default '0',
  `ERSTELLT` date default NULL,
  `ERST_NAME` varchar(20) default NULL,
  `GEAENDERT` date default NULL,
  `GEAEND_NAME` varchar(20) default NULL,
  PRIMARY KEY  (`REC_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_zahlungen
CREATE TABLE IF NOT EXISTS `back_zahlungen` (
  `REC_ID` int(11) unsigned NOT NULL auto_increment,
  `FIBU_KTO` int(6) unsigned NOT NULL default '0',
  `FIBU_GEGENKTO` int(6) NOT NULL default '-1',
  `MA_ID` int(11) NOT NULL default '0',
  `ADDR_ID` int(11) NOT NULL default '-1',
  `QUELLE` tinyint(2) unsigned default '0',
  `JOURNAL_ID` int(11) NOT NULL default '-1',
  `ART` enum('GS','LS','UB','?') NOT NULL default '?',
  `AUSZUG` int(6) unsigned NOT NULL default '0',
  `UW_NUM` int(11) NOT NULL default '-1',
  `DATUM` date NOT NULL default '0000-00-00',
  `VALUTA` date NOT NULL default '0000-00-00',
  `BELEGNUM` varchar(20) NOT NULL default '',
  `BETRAG` decimal(10,2) NOT NULL default '0.00',
  `SKONTO_PROZ` decimal(5,3) NOT NULL default '0.000',
  `SKONTO_BETRAG` decimal(10,2) NOT NULL default '0.00',
  `WAEHRUNG` char(3) NOT NULL default 'EUR',
  `PRIMANOTA` varchar(10) default NULL,
  `TEXTSCHLUESSEL` int(3) unsigned NOT NULL default '0',
  `VERW_ZWECK` text NOT NULL,
  `BEMERKUNG` text,
  `GEBUCHT` enum('N','Y','S','E') NOT NULL default 'N',
  `PARTNER_NAME1` varchar(40) default NULL,
  `PARTNER_NAME2` varchar(40) default NULL,
  `PARTNER_KTO` varchar(12) default NULL,
  `PARTNER_BLZ` varchar(12) default NULL,
  `PARTNER_IBAN` varchar(100) default NULL,
  `PARTNER_SWIFT` varchar(100) default NULL,
  `ERSTELLT_AM` datetime NOT NULL default '0000-00-00 00:00:00',
  `ERSTELLT_NAME` varchar(50) default NULL,
  PRIMARY KEY  (`REC_ID`),
  KEY `IDX_ADDR_ID` (`ADDR_ID`),
  KEY `IDX_JOURNAL_ID` (`JOURNAL_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.back_zahlungsarten
CREATE TABLE IF NOT EXISTS `back_zahlungsarten` (
  `REC_ID` int(11) NOT NULL auto_increment,
  `NAME` varchar(100) NOT NULL default '',
  `TEXT_KURZ` varchar(255) NOT NULL default '',
  `TEXT_LANG` longtext,
  `NETTO_TAGE` int(3) default NULL,
  `SKONTO_TAGE` int(3) default NULL,
  `SKONTO_PROZ` decimal(5,3) NOT NULL default '0.000',
  `FIBU_KONTEN` varchar(255) NOT NULL default '',
  `AKTIV_FLAG` enum('N','Y') NOT NULL default 'Y',
  PRIMARY KEY  (`REC_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.benutzerrechte
CREATE TABLE IF NOT EXISTS `benutzerrechte` (
  `GRUPPEN_ID` int(11) NOT NULL default '0',
  `USER_ID` int(11) NOT NULL default '0',
  `MODUL_ID` int(11) unsigned NOT NULL default '0',
  `MODUL_NAME` varchar(100) default NULL,
  `SUBMODUL_ID` int(11) NOT NULL default '0',
  `SUBMODUL_NAME` varchar(100) default NULL,
  `RECHTE` bigint(16) unsigned NOT NULL default '0',
  `BEMERKUNG` varchar(250) default NULL,
  PRIMARY KEY  (`GRUPPEN_ID`,`USER_ID`,`MODUL_ID`,`SUBMODUL_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.blz
CREATE TABLE IF NOT EXISTS `blz` (
  `LAND` varchar(5) NOT NULL default 'DE',
  `BLZ` int(10) NOT NULL default '0',
  `BANK_NAME` varchar(255) NOT NULL default '',
  `PRZ` char(2) NOT NULL default '',
  PRIMARY KEY  (`LAND`,`BLZ`),
  KEY `IDX_NAME` (`LAND`,`BANK_NAME`,`BLZ`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.ekbestell
CREATE TABLE IF NOT EXISTS `ekbestell` (
  `REC_ID` int(11) NOT NULL auto_increment,
  `TERM_ID` int(11) unsigned NOT NULL default '1',
  `MA_ID` int(11) NOT NULL default '-1',
  `PREISANFRAGE` enum('N','Y') NOT NULL default 'N',
  `ADDR_ID` int(11) NOT NULL default '-1',
  `ASP_ID` int(11) NOT NULL default '-1',
  `LIEF_ADDR_ID` int(11) NOT NULL default '-1',
  `PROJEKT_ID` int(11) NOT NULL default '-1',
  `BELEGNUM` varchar(20) NOT NULL default '',
  `BELEGDATUM` date NOT NULL default '0000-00-00',
  `TERMIN` date default NULL,
  `LIEFART` tinyint(2) NOT NULL default '-1',
  `ZAHLART` tinyint(2) NOT NULL default '-1',
  `GLOBRABATT` float(10,2) NOT NULL default '0.00',
  `GEWICHT` float(10,3) NOT NULL default '0.000',
  `MWST_0` decimal(5,2) NOT NULL default '0.00',
  `MWST_1` decimal(5,2) NOT NULL default '0.00',
  `MWST_2` decimal(5,2) NOT NULL default '0.00',
  `MWST_3` decimal(5,2) NOT NULL default '0.00',
  `NSUMME_0` decimal(10,2) NOT NULL default '0.00',
  `NSUMME_1` decimal(10,2) NOT NULL default '0.00',
  `NSUMME_2` decimal(10,2) NOT NULL default '0.00',
  `NSUMME_3` decimal(10,2) NOT NULL default '0.00',
  `NSUMME` decimal(10,2) NOT NULL default '0.00',
  `MSUMME_0` decimal(10,2) NOT NULL default '0.00',
  `MSUMME_1` decimal(10,2) NOT NULL default '0.00',
  `MSUMME_2` decimal(10,2) NOT NULL default '0.00',
  `MSUMME_3` decimal(10,2) NOT NULL default '0.00',
  `MSUMME` decimal(10,2) NOT NULL default '0.00',
  `BSUMME_0` decimal(10,2) NOT NULL default '0.00',
  `BSUMME_1` decimal(10,2) NOT NULL default '0.00',
  `BSUMME_2` decimal(10,2) NOT NULL default '0.00',
  `BSUMME_3` decimal(10,2) NOT NULL default '0.00',
  `BSUMME` decimal(10,2) NOT NULL default '0.00',
  `ATSUMME` decimal(10,2) NOT NULL default '0.00',
  `ATMSUMME` decimal(10,2) NOT NULL default '0.00',
  `WAEHRUNG` varchar(5) NOT NULL default '',
  `KURS` decimal(16,4) NOT NULL default '1.0000',
  `GEGENKONTO` int(11) NOT NULL default '-1',
  `SOLL_STAGE` int(4) unsigned NOT NULL default '0',
  `SOLL_SKONTO` float(5,2) NOT NULL default '0.00',
  `SOLL_NTAGE` int(4) unsigned NOT NULL default '0',
  `STADIUM` tinyint(4) NOT NULL default '0',
  `ERSTELLT` date default NULL,
  `ERST_NAME` varchar(20) default NULL,
  `KUN_NUM` varchar(20) default NULL,
  `KUN_ANREDE` varchar(40) default NULL,
  `KUN_NAME1` varchar(40) default NULL,
  `KUN_NAME2` varchar(40) default NULL,
  `KUN_NAME3` varchar(40) default NULL,
  `KUN_ABTEILUNG` varchar(40) default NULL,
  `KUN_STRASSE` varchar(40) default NULL,
  `KUN_LAND` varchar(5) default NULL,
  `KUN_PLZ` varchar(10) default NULL,
  `KUN_ORT` varchar(40) default NULL,
  `USR1` varchar(80) default NULL,
  `USR2` varchar(80) default NULL,
  `KOPFTEXT` text,
  `FUSSTEXT` text,
  `PROJEKT` varchar(80) default NULL,
  `ORGNUM` varchar(20) default NULL,
  `BEST_NAME` varchar(40) default NULL,
  `BEST_CODE` tinyint(4) default NULL,
  `BEST_DATUM` date default NULL,
  `INFO` text,
  `FREIGABE1_FLAG` enum('N','Y') NOT NULL default 'N',
  `PRINT_FLAG` enum('N','Y') NOT NULL default 'N',
  `BRUTTO_FLAG` enum('N','Y') NOT NULL default 'N',
  `MWST_FREI_FLAG` enum('N','Y') NOT NULL default 'N',
  PRIMARY KEY  (`REC_ID`),
  KEY `IDX_BELEGNUM` (`PREISANFRAGE`,`BELEGNUM`),
  KEY `IDX_QUELLE_RDATUM` (`PREISANFRAGE`,`BELEGDATUM`),
  KEY `IDX_ADDR_ID` (`ADDR_ID`,`PREISANFRAGE`,`BELEGDATUM`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.ekbestell_op
CREATE TABLE IF NOT EXISTS `ekbestell_op` (
  `ARTIKEL_ID` int(11) unsigned NOT NULL default '0',
  `EKBESTPOS_ID` int(11) unsigned NOT NULL default '0',
  `MENGE_BEST` decimal(10,2) NOT NULL default '0.00',
  `MENGE_OFFEN` decimal(10,2) NOT NULL default '0.00',
  PRIMARY KEY  (`EKBESTPOS_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.ekbestell_pos
CREATE TABLE IF NOT EXISTS `ekbestell_pos` (
  `EKBESTELL_ID` int(11) NOT NULL default '0',
  `PREISANFRAGE` enum('N','Y') NOT NULL default 'N',
  `BELEGNUM` varchar(20) NOT NULL default '',
  `ADDR_ID` int(11) NOT NULL default '-1',
  `LIEF_ADDR_ID` int(11) NOT NULL default '-1',
  `PROJEKT_ID` int(11) NOT NULL default '-1',
  `REC_ID` int(11) NOT NULL auto_increment,
  `POSITION` int(11) NOT NULL default '0',
  `VIEW_POS` char(3) default NULL,
  `WARENGRUPPE` int(11) NOT NULL default '-1',
  `ARTIKELTYP` char(1) NOT NULL default '',
  `ARTIKEL_ID` int(11) NOT NULL default '-1',
  `MATCHCODE` varchar(20) default NULL,
  `ARTNUM` varchar(20) default NULL,
  `BARCODE` varchar(20) default NULL,
  `LAENGE` varchar(20) default NULL,
  `BREITE` varchar(20) default NULL,
  `HOEHE` varchar(20) default NULL,
  `GROESSE` varchar(20) default NULL,
  `DIMENSION` varchar(20) default NULL,
  `GEWICHT` decimal(10,3) NOT NULL default '0.000',
  `ME_EINHEIT` varchar(10) default NULL,
  `PR_EINHEIT` decimal(10,3) NOT NULL default '1.000',
  `VPE` decimal(10,3) NOT NULL default '1.000',
  `MENGE` decimal(10,3) NOT NULL default '0.000',
  `EPREIS` decimal(10,4) NOT NULL default '0.0000',
  `GPREIS` decimal(10,2) NOT NULL default '0.00',
  `RABATT1` decimal(10,2) NOT NULL default '0.00',
  `RABATT2` decimal(10,2) NOT NULL default '0.00',
  `RABATT3` decimal(10,2) NOT NULL default '0.00',
  `E_RABATT_BETRAG` decimal(10,4) NOT NULL default '0.0000',
  `G_RABATT_BETRAG` decimal(10,2) NOT NULL default '0.00',
  `STEUER_CODE` tinyint(1) unsigned NOT NULL default '0',
  `ALTTEIL_PROZ` decimal(10,2) NOT NULL default '0.10',
  `ALTTEIL_STCODE` tinyint(4) NOT NULL default '0',
  `GEGENKTO` int(11) NOT NULL default '-1',
  `BEZEICHNUNG` text,
  `ALTTEIL_FLAG` enum('N','Y') NOT NULL default 'N',
  `BRUTTO_FLAG` enum('N','Y') NOT NULL default 'N',
  `STADIUM` tinyint(3) unsigned NOT NULL default '0',
  PRIMARY KEY  (`REC_ID`),
  KEY `IDX_ARTIKEL_ID` (`ARTIKEL_ID`),
  KEY `IDX_ADDR_ID` (`ADDR_ID`),
  KEY `IDX_EKBESTELL_ID` (`EKBESTELL_ID`,`POSITION`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.export
CREATE TABLE IF NOT EXISTS `export` (
  `ID` int(11) NOT NULL auto_increment,
  `KURZBEZ` varchar(255) NOT NULL default '',
  `INFO` text NOT NULL,
  `QUERY` text NOT NULL,
  `FELDER` text,
  `FORMULAR` blob,
  `FORMAT` char(3) default NULL,
  `FILENAME` varchar(255) default NULL,
  `EINSTELLUNGEN` text,
  `LAST_CHANGE` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  `CHANGE_NAME` varchar(100) default NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.fibu_konten
CREATE TABLE IF NOT EXISTS `fibu_konten` (
  `KONTORAHMEN` varchar(10) NOT NULL default '',
  `KONTO` bigint(5) unsigned NOT NULL default '0',
  `KONTONAME` varchar(100) NOT NULL default '',
  `KONTOART` int(3) unsigned NOT NULL default '0',
  `NEBENKONTO` bigint(5) unsigned NOT NULL default '0',
  `STEUERSATZ` decimal(6,0) NOT NULL default '0',
  `BILANZKONTO` enum('N','Y') NOT NULL default 'N',
  `NK_AUSWAHL` enum('N','Y') NOT NULL default 'N',
  `USTVA_ZEILE` bigint(5) unsigned NOT NULL default '0',
  `BWA_GRUPPE` bigint(5) unsigned default '0',
  `BANK_BLZ` varchar(15) default NULL,
  `BANK_KONTO` varchar(15) default NULL,
  `BANK_NAME` varchar(255) default NULL,
  `KONTO_INHABER` varchar(255) default NULL,
  PRIMARY KEY  (`KONTORAHMEN`,`KONTO`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.firma
CREATE TABLE IF NOT EXISTS `firma` (
  `ANREDE` varchar(250) default NULL,
  `NAME1` varchar(250) default NULL,
  `NAME2` varchar(250) default NULL,
  `NAME3` varchar(250) default NULL,
  `STRASSE` varchar(250) default NULL,
  `LAND` varchar(10) default NULL,
  `PLZ` varchar(10) default NULL,
  `ORT` varchar(250) default NULL,
  `VORWAHL` varchar(250) default NULL,
  `TELEFON1` varchar(250) default NULL,
  `TELEFON2` varchar(250) default NULL,
  `MOBILFUNK` varchar(250) default NULL,
  `FAX` varchar(250) default NULL,
  `EMAIL` varchar(250) default NULL,
  `WEBSEITE` varchar(250) default NULL,
  `BANK1_BLZ` varchar(20) default NULL,
  `BANK1_KONTONR` varchar(20) default NULL,
  `BANK1_NAME` varchar(250) default NULL,
  `BANK1_IBAN` varchar(100) default NULL,
  `BANK1_SWIFT` varchar(100) default NULL,
  `BANK2_BLZ` varchar(20) default NULL,
  `BANK2_KONTONR` varchar(20) default NULL,
  `BANK2_NAME` varchar(250) default NULL,
  `BANK2_IBAN` varchar(100) default NULL,
  `BANK2_SWIFT` varchar(100) default NULL,
  `KOPFTEXT` text,
  `FUSSTEXT` text,
  `ABSENDER` varchar(250) default NULL,
  `STEUERNUMMER` varchar(25) default NULL,
  `UST_ID` varchar(25) default NULL,
  `IMAGE1` blob,
  `IMAGE2` blob,
  `IMAGE3` blob
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COMMENT='Allgemeine Firmendaten für Formulare';

# Data exporting was unselected.


# Dumping structure for table caofaktura.hersteller
CREATE TABLE IF NOT EXISTS `hersteller` (
  `SHOP_ID` tinyint(3) NOT NULL default '-1',
  `HERSTELLER_ID` int(11) NOT NULL auto_increment,
  `ADDR_ID` int(11) NOT NULL default '-1',
  `HERSTELLER_NAME` varchar(32) NOT NULL default '',
  `HERSTELLER_IMAGE` varchar(64) default NULL,
  `LAST_CHANGE` datetime default NULL,
  `SHOP_DATE_ADDED` datetime default NULL,
  `SHOP_DATE_CHANGE` datetime default NULL,
  `SYNC_FLAG` enum('N','Y') NOT NULL default 'N',
  `CHANGE_FLAG` enum('N','Y') NOT NULL default 'N',
  `DEL_FLAG` enum('N','Y') NOT NULL default 'N',
  PRIMARY KEY  (`SHOP_ID`,`HERSTELLER_ID`),
  KEY `IDX_HERSTELLER_NAME` (`HERSTELLER_NAME`),
  KEY `IDX_HERSTELLER_ID` (`HERSTELLER_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.hersteller_info
CREATE TABLE IF NOT EXISTS `hersteller_info` (
  `SHOP_ID` tinyint(3) NOT NULL default '-1',
  `HERSTELLER_ID` int(11) NOT NULL default '0',
  `SPRACHE_ID` int(11) NOT NULL default '0',
  `HERSTELLER_URL` varchar(255) NOT NULL default '',
  `URL_CLICKED` int(5) NOT NULL default '0',
  `DATE_LAST_CLICK` datetime default NULL,
  PRIMARY KEY  (`SHOP_ID`,`HERSTELLER_ID`,`SPRACHE_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.info
CREATE TABLE IF NOT EXISTS `info` (
  `LFD_NR` int(11) NOT NULL auto_increment,
  `MA_ID` int(11) NOT NULL default '-1',
  `PRIVAT` enum('N','Y') NOT NULL default 'N',
  `QUELLE` tinyint(4) NOT NULL default '0',
  `QUELL_ID` int(11) NOT NULL default '-1',
  `DATUM` date NOT NULL default '0000-00-00',
  `WV_DATUM` date default NULL,
  `WV_FLAG` enum('N','Y') NOT NULL default 'N',
  `ERLEDIGT_FLAG` enum('N','Y') NOT NULL default 'N',
  `ERST_VON` varchar(20) default NULL,
  `KURZTEXT` varchar(100) default NULL,
  `MEMO` text,
  PRIMARY KEY  (`LFD_NR`,`QUELLE`,`DATUM`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.inventur
CREATE TABLE IF NOT EXISTS `inventur` (
  `ID` int(5) NOT NULL auto_increment,
  `DATUM` date NOT NULL default '0000-00-00',
  `BESCHREIBUNG` varchar(250) default NULL,
  `INFO` text,
  `STATUS` tinyint(3) unsigned NOT NULL default '0',
  PRIMARY KEY  (`ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COMMENT='Kopfdaten für Inventuren';

# Data exporting was unselected.


# Dumping structure for table caofaktura.journal
CREATE TABLE IF NOT EXISTS `journal` (
  `TERM_ID` int(11) unsigned NOT NULL default '1',
  `MA_ID` int(11) NOT NULL default '-1',
  `QUELLE` tinyint(4) NOT NULL default '0',
  `REC_ID` int(11) NOT NULL auto_increment,
  `QUELLE_SUB` tinyint(4) default NULL,
  `ADDR_ID` int(11) NOT NULL default '-1',
  `ASP_ID` int(11) NOT NULL default '-1',
  `LIEF_ADDR_ID` int(11) NOT NULL default '-1',
  `PROJEKT_ID` int(11) NOT NULL default '-1',
  `ATRNUM` varchar(20) default NULL,
  `VRENUM` varchar(20) NOT NULL default '',
  `VLSNUM` varchar(20) default NULL,
  `FOLGENR` int(11) NOT NULL default '-1',
  `KM_STAND` int(11) default NULL,
  `KFZ_ID` int(11) NOT NULL default '-1',
  `VERTRETER_ID` int(11) NOT NULL default '-1',
  `VERTRETER_ABR_ID` int(11) NOT NULL default '-1',
  `GLOBRABATT` float(10,2) NOT NULL default '0.00',
  `ADATUM` date default NULL,
  `RDATUM` datetime NOT NULL default '0000-00-00 00:00:00',
  `LDATUM` date default NULL,
  `KLASSE_ID` tinyint(3) unsigned NOT NULL default '0',
  `TERMIN` date default NULL,
  `PR_EBENE` tinyint(4) default NULL,
  `LIEFART` tinyint(2) NOT NULL default '-1',
  `ZAHLART` tinyint(2) NOT NULL default '-1',
  `GEWICHT` float(10,3) NOT NULL default '0.000',
  `KOST_NETTO` decimal(10,2) NOT NULL default '0.00',
  `WERT_NETTO` decimal(10,2) NOT NULL default '0.00',
  `LOHN` decimal(10,2) NOT NULL default '0.00',
  `WARE` decimal(10,2) NOT NULL default '0.00',
  `TKOST` decimal(10,2) NOT NULL default '0.00',
  `ROHGEWINN` decimal(10,2) NOT NULL default '0.00',
  `MWST_0` decimal(5,2) NOT NULL default '0.00',
  `MWST_1` decimal(5,2) NOT NULL default '0.00',
  `MWST_2` decimal(5,2) NOT NULL default '0.00',
  `MWST_3` decimal(5,2) NOT NULL default '0.00',
  `NSUMME_0` decimal(10,2) NOT NULL default '0.00',
  `NSUMME_1` decimal(10,2) NOT NULL default '0.00',
  `NSUMME_2` decimal(10,2) NOT NULL default '0.00',
  `NSUMME_3` decimal(10,2) NOT NULL default '0.00',
  `NSUMME` decimal(10,2) NOT NULL default '0.00',
  `MSUMME_0` decimal(10,2) NOT NULL default '0.00',
  `MSUMME_1` decimal(10,2) NOT NULL default '0.00',
  `MSUMME_2` decimal(10,2) NOT NULL default '0.00',
  `MSUMME_3` decimal(10,2) NOT NULL default '0.00',
  `MSUMME` decimal(10,2) NOT NULL default '0.00',
  `BSUMME_0` decimal(10,2) NOT NULL default '0.00',
  `BSUMME_1` decimal(10,2) NOT NULL default '0.00',
  `BSUMME_2` decimal(10,2) NOT NULL default '0.00',
  `BSUMME_3` decimal(10,2) NOT NULL default '0.00',
  `BSUMME` decimal(10,2) NOT NULL default '0.00',
  `ATSUMME` decimal(10,2) NOT NULL default '0.00',
  `ATMSUMME` decimal(10,2) NOT NULL default '0.00',
  `PROVIS_WERT` decimal(10,2) NOT NULL default '0.00',
  `WAEHRUNG` varchar(5) NOT NULL default '',
  `KURS` decimal(16,4) NOT NULL default '1.0000',
  `GEGENKONTO` int(11) NOT NULL default '-1',
  `SOLL_NTAGE` int(4) unsigned NOT NULL default '0',
  `SOLL_SKONTO` float(5,2) NOT NULL default '0.00',
  `SOLL_STAGE` int(4) unsigned NOT NULL default '0',
  `SOLL_RATEN` tinyint(4) NOT NULL default '1',
  `SOLL_RATBETR` decimal(10,2) NOT NULL default '0.00',
  `SOLL_RATINTERVALL` int(11) NOT NULL default '0',
  `STADIUM` tinyint(4) NOT NULL default '0',
  `POS_TA_ID` int(11) NOT NULL default '-1',
  `ERSTELLT` date default NULL,
  `ERST_NAME` varchar(20) default NULL,
  `KUN_NUM` varchar(20) default NULL,
  `KUN_ANREDE` varchar(40) default NULL,
  `KUN_NAME1` varchar(40) default NULL,
  `KUN_NAME2` varchar(40) default NULL,
  `KUN_NAME3` varchar(40) default NULL,
  `KUN_ABTEILUNG` varchar(40) default NULL,
  `KUN_STRASSE` varchar(40) default NULL,
  `KUN_LAND` varchar(5) default NULL,
  `KUN_PLZ` varchar(10) default NULL,
  `KUN_ORT` varchar(40) default NULL,
  `USR1` varchar(80) default NULL,
  `USR2` varchar(80) default NULL,
  `KOPFTEXT` text,
  `FUSSTEXT` text,
  `PROJEKT` varchar(80) default NULL,
  `ORGNUM` varchar(20) default NULL,
  `BEST_NAME` varchar(40) default NULL,
  `BEST_CODE` tinyint(4) default NULL,
  `BEST_DATUM` date default NULL,
  `INFO` text,
  `FREIGABE1_FLAG` enum('N','Y') NOT NULL default 'N',
  `PRINT_FLAG` enum('N','Y') NOT NULL default 'N',
  `BRUTTO_FLAG` enum('N','Y') NOT NULL default 'N',
  `MWST_FREI_FLAG` enum('N','Y') NOT NULL default 'N',
  `PROVIS_BERECHNET` enum('N','Y') NOT NULL default 'N',
  `SHOP_ID` tinyint(3) NOT NULL default '-1',
  `SHOP_ORDERID` int(11) NOT NULL default '-1',
  `SHOP_STATUS` tinyint(3) unsigned NOT NULL default '0',
  `SHOP_CHANGE_FLAG` enum('N','Y') NOT NULL default 'N',
  `AUSLAND_TYP` tinyint(1) unsigned NOT NULL default '0',
  PRIMARY KEY  (`REC_ID`),
  KEY `RJ_RENUM` (`QUELLE`,`VRENUM`),
  KEY `ADDR_ID` (`ADDR_ID`,`RDATUM`),
  KEY `IDX_QUELLE_RDATUM` (`QUELLE`,`QUELLE_SUB`,`RDATUM`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.journalpos
CREATE TABLE IF NOT EXISTS `journalpos` (
  `REC_ID` int(11) NOT NULL auto_increment,
  `QUELLE` tinyint(4) NOT NULL default '0',
  `QUELLE_SUB` tinyint(4) NOT NULL default '0',
  `QUELLE_SRC` int(11) NOT NULL default '-1',
  `PROJEKT_ID` int(11) NOT NULL default '-1',
  `JOURNAL_ID` int(11) NOT NULL default '0',
  `WARENGRUPPE` int(11) NOT NULL default '-1',
  `ARTIKELTYP` char(1) NOT NULL default '',
  `ARTIKEL_ID` int(11) NOT NULL default '-1',
  `TOP_POS_ID` int(11) NOT NULL default '-1',
  `ADDR_ID` int(11) NOT NULL default '-1',
  `LTERMIN` date default NULL,
  `ATRNUM` varchar(20) default NULL,
  `VRENUM` varchar(20) NOT NULL default '',
  `POSITION` int(11) NOT NULL default '0',
  `VIEW_POS` char(3) default NULL,
  `MATCHCODE` varchar(20) default NULL,
  `ARTNUM` varchar(20) default NULL,
  `BARCODE` varchar(20) default NULL,
  `MENGE` decimal(10,3) NOT NULL default '0.000',
  `LAENGE` varchar(20) default NULL,
  `BREITE` varchar(20) default NULL,
  `HOEHE` varchar(20) default NULL,
  `GROESSE` varchar(20) default NULL,
  `DIMENSION` varchar(20) default NULL,
  `GEWICHT` decimal(10,3) NOT NULL default '0.000',
  `ME_EINHEIT` varchar(10) default NULL,
  `PR_EINHEIT` decimal(10,3) NOT NULL default '1.000',
  `VPE` decimal(10,3) NOT NULL default '1.000',
  `EK_PREIS` decimal(10,4) NOT NULL default '0.0000',
  `CALC_FAKTOR` decimal(6,5) NOT NULL default '0.00000',
  `EPREIS` decimal(10,4) NOT NULL default '0.0000',
  `GPREIS` decimal(10,2) NOT NULL default '0.00',
  `E_RGEWINN` decimal(10,4) NOT NULL default '0.0000',
  `G_RGEWINN` decimal(10,2) NOT NULL default '0.00',
  `RABATT` decimal(10,2) NOT NULL default '0.00',
  `RABATT2` decimal(10,2) NOT NULL default '0.00',
  `RABATT3` decimal(10,2) NOT NULL default '0.00',
  `E_RABATT_BETRAG` decimal(10,4) NOT NULL default '0.0000',
  `G_RABATT_BETRAG` decimal(10,2) NOT NULL default '0.00',
  `STEUER_CODE` tinyint(4) NOT NULL default '0',
  `ALTTEIL_PROZ` decimal(10,2) NOT NULL default '0.10',
  `ALTTEIL_STCODE` tinyint(4) NOT NULL default '0',
  `PROVIS_PROZ` decimal(5,2) NOT NULL default '0.00',
  `PROVIS_WERT` decimal(10,2) NOT NULL default '0.00',
  `GEBUCHT` enum('N','Y') NOT NULL default 'N',
  `GEGENKTO` int(11) NOT NULL default '-1',
  `BEZEICHNUNG` text,
  `SN_FLAG` enum('N','Y') NOT NULL default 'N',
  `ALTTEIL_FLAG` enum('N','Y') NOT NULL default 'N',
  `BEZ_FEST_FLAG` enum('N','Y') NOT NULL default 'N',
  `BRUTTO_FLAG` enum('N','Y') NOT NULL default 'N',
  `NO_RABATT_FLAG` enum('N','Y') NOT NULL default 'N',
  `APOS_FLAG` enum('N','Y') NOT NULL default 'N',
  PRIMARY KEY  (`REC_ID`),
  KEY `ARTIKEL_ID` (`ARTIKEL_ID`),
  KEY `ADDR_ID` (`ADDR_ID`),
  KEY `JOURNAL_ID` (`JOURNAL_ID`,`POSITION`),
  KEY `QUELLE_SRC` (`QUELLE_SRC`),
  KEY `IDX_QUELLE` (`QUELLE`),
  KEY `IDX_QSRC` (`QUELLE_SRC`,`QUELLE`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.journalpos_sernum
CREATE TABLE IF NOT EXISTS `journalpos_sernum` (
  `QUELLE` tinyint(2) unsigned NOT NULL default '0',
  `JOURNAL_ID` int(11) NOT NULL default '-1',
  `JOURNALPOS_ID` int(11) NOT NULL default '-1',
  `ARTIKEL_ID` int(11) NOT NULL default '-1',
  `SNUM_ID` int(11) NOT NULL default '-1',
  PRIMARY KEY  (`QUELLE`,`JOURNAL_ID`,`JOURNALPOS_ID`,`ARTIKEL_ID`,`SNUM_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.journal_op
CREATE TABLE IF NOT EXISTS `journal_op` (
  `QUELLE` tinyint(3) unsigned NOT NULL default '0',
  `ADDR_ID` int(11) unsigned NOT NULL default '0',
  `JOURNAL_ID` int(11) unsigned NOT NULL default '0',
  `BSUMME` decimal(10,2) NOT NULL default '0.00',
  `ZAHLUNGEN_ANZ` int(3) unsigned NOT NULL default '0',
  `ZAHLUNGEN_SUM` decimal(10,2) NOT NULL default '0.00',
  `WAEHRUNG` varchar(5) NOT NULL default '',
  PRIMARY KEY  (`JOURNAL_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.journal_ssh
CREATE TABLE IF NOT EXISTS `journal_ssh` (
  `ID` int(11) unsigned NOT NULL auto_increment,
  `JOURNAL_ID` int(11) unsigned NOT NULL default '0',
  `DATUM` datetime NOT NULL default '0000-00-00 00:00:00',
  `KOMMENTAR` text,
  `KUNDE_BENACHRICHTIGT` enum('N','Y') NOT NULL default 'N',
  `SHOP_ID` int(3) unsigned default '0',
  `SHOP_STATUS` tinyint(3) unsigned NOT NULL default '0',
  `SHOP_ORDERID` int(3) unsigned NOT NULL default '0',
  `SHOP_CHANGE_FLAG` enum('N','Y') NOT NULL default 'Y',
  PRIMARY KEY  (`ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COMMENT='Journal-Shop-Status-Historie';

# Data exporting was unselected.


# Dumping structure for table caofaktura.kfz
CREATE TABLE IF NOT EXISTS `kfz` (
  `KFZ_ID` int(11) NOT NULL auto_increment,
  `ADDR_ID` int(11) NOT NULL default '0',
  `FGST_NUM` varchar(20) NOT NULL default '',
  `KFZ_GRUPPE` tinyint(4) default NULL,
  `POL_KENNZ` varchar(10) NOT NULL default '',
  `SCHL_ZU_1` int(6) unsigned default NULL,
  `SCHL_ZU_2` varchar(20) default NULL,
  `SCHL_ZU_3` varchar(20) default NULL,
  `TYP_ID` int(11) default NULL,
  `TYP` varchar(25) default NULL,
  `AUSFUER` varchar(25) default NULL,
  `ANTRIEBSART_ID` int(2) NOT NULL default '0',
  `FABRIKAT_ID` int(11) default NULL,
  `FABRIKAT` varchar(25) default NULL,
  `KRAFTSTOFF_ID` int(11) default NULL,
  `GRUPPE` int(11) default NULL,
  `SCHLUES_NR_ME` varchar(20) default NULL,
  `SCHLUES_NR_EL` varchar(20) default NULL,
  `ZSCHL_NR` varchar(10) default NULL,
  `MOTOR_NR` varchar(20) default NULL,
  `KFZBRI_NR` varchar(15) default NULL,
  `MOTOR` varchar(15) default NULL,
  `GETRIEBE` varchar(10) default NULL,
  `KW` int(11) default NULL,
  `PS` int(11) default NULL,
  `KM_STAND` int(11) default NULL,
  `HUBRAUM` int(11) default NULL,
  `ZUL_GESGEWICHT` int(5) unsigned NOT NULL default '0',
  `REIFEN1` varchar(30) default NULL,
  `REIFEN2` varchar(30) default NULL,
  `REIFEN3` varchar(30) default NULL,
  `REIFEN4` varchar(30) default NULL,
  `REIFEN1_GR` varchar(10) default NULL,
  `REIFEN2_GR` varchar(30) default NULL,
  `REIFEN3_GR` varchar(30) default NULL,
  `REIFEN4_GR` varchar(30) default NULL,
  `PROFIL_VL` decimal(5,1) default NULL,
  `PROFIL_VR` decimal(5,1) default NULL,
  `PROFIL_HL` decimal(5,1) default NULL,
  `PROFIL_HR` decimal(5,1) default NULL,
  `FARBE` varchar(10) default NULL,
  `POLSTER` varchar(10) default NULL,
  `RADIO_CODE` varchar(100) default NULL,
  `ZULASSUNG` date default NULL,
  `HERSTELLUNG` date default NULL,
  `KAUFDATUM` date default NULL,
  `LE_BESUCH` date default NULL,
  `NAE_TUEV` date default NULL,
  `NAE_AU` date default NULL,
  `NAE_SP` date default NULL,
  `NAE_TP` date default NULL,
  `NAE_GASPR` date default NULL,
  `NAE_UVVPR` date default NULL,
  `EK_PREIS` double default NULL,
  `RUESTK` double default NULL,
  `VK_NETTO` double default NULL,
  `MWST_PROZ` double default NULL,
  `UMSATZ_GES` double default NULL,
  `UMSATZ_GAR` double default NULL,
  `VERTRETER_ID` int(11) NOT NULL default '-1',
  `INFO` text,
  `WKST_INFO` text,
  `USERFELD_01` varchar(255) default NULL,
  `USERFELD_02` varchar(255) default NULL,
  `USERFELD_03` varchar(255) default NULL,
  `USERFELD_04` varchar(255) default NULL,
  `USERFELD_05` varchar(255) default NULL,
  `USERFELD_06` varchar(255) default NULL,
  `USERFELD_07` varchar(255) default NULL,
  `USERFELD_08` varchar(255) default NULL,
  `USERFELD_09` varchar(255) default NULL,
  `USERFELD_10` varchar(255) default NULL,
  PRIMARY KEY  (`KFZ_ID`),
  KEY `KUNNUM` (`ADDR_ID`),
  KEY `KENNZ` (`POL_KENNZ`),
  KEY `FGST_NR` (`FGST_NUM`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.land
CREATE TABLE IF NOT EXISTS `land` (
  `ID` char(2) NOT NULL default '',
  `NAME` varchar(100) NOT NULL default '',
  `NAME2` varchar(255) NOT NULL default '',
  `ISO_CODE_3` char(3) NOT NULL default '',
  `POST_CODE` char(3) default NULL,
  `FORMAT` tinyint(3) NOT NULL default '1',
  `VORWAHL` varchar(10) default NULL,
  `WAEHRUNG` varchar(5) default NULL,
  `WAEHRUNG_LANG` varchar(100) default NULL,
  `SPRACHE` char(3) default NULL,
  `EU_LAND` enum('N','Y') NOT NULL default 'N',
  PRIMARY KEY  (`ID`),
  UNIQUE KEY `IDX_NAME` (`NAME`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.lieferschein
CREATE TABLE IF NOT EXISTS `lieferschein` (
  `TERM_ID` int(11) unsigned NOT NULL default '1',
  `MA_ID` int(11) NOT NULL default '-1',
  `REC_ID` int(11) NOT NULL auto_increment,
  `EDI_FLAG` enum('N','Y') NOT NULL default 'N',
  `STORNO_FLAG` enum('N','Y') NOT NULL default 'N',
  `ADDR_ID` int(11) NOT NULL default '-1',
  `ASP_ID` int(11) NOT NULL default '-1',
  `LIEF_ADDR_ID` int(11) NOT NULL default '-1',
  `PROJEKT_ID` int(11) NOT NULL default '-1',
  `ATRNUM` varchar(20) default NULL,
  `VLSNUM` varchar(20) NOT NULL default '',
  `KM_STAND` int(11) default NULL,
  `KFZ_ID` int(11) NOT NULL default '-1',
  `VERTRETER_ID` int(11) NOT NULL default '-1',
  `GLOBRABATT` float(10,2) NOT NULL default '0.00',
  `ADATUM` date default NULL,
  `LDATUM` date default NULL,
  `KLASSE_ID` tinyint(3) unsigned NOT NULL default '0',
  `TERMIN` date default NULL,
  `PR_EBENE` tinyint(4) default NULL,
  `LIEFART` tinyint(2) NOT NULL default '-1',
  `ZAHLART` tinyint(2) NOT NULL default '-1',
  `GEWICHT` float(10,3) NOT NULL default '0.000',
  `LOHN` decimal(10,2) NOT NULL default '0.00',
  `WARE` decimal(10,2) NOT NULL default '0.00',
  `ROHGEWINN` decimal(10,2) NOT NULL default '0.00',
  `TKOST` decimal(10,2) NOT NULL default '0.00',
  `WERT_NETTO` decimal(10,2) NOT NULL default '0.00',
  `KOST_NETTO` decimal(10,2) NOT NULL default '0.00',
  `MWST_0` decimal(10,2) NOT NULL default '0.00',
  `MWST_1` decimal(10,2) NOT NULL default '0.00',
  `MWST_2` decimal(10,2) NOT NULL default '0.00',
  `MWST_3` decimal(10,2) NOT NULL default '0.00',
  `NSUMME_0` decimal(10,2) NOT NULL default '0.00',
  `NSUMME_1` decimal(10,2) NOT NULL default '0.00',
  `NSUMME_2` decimal(10,2) NOT NULL default '0.00',
  `NSUMME_3` decimal(10,2) NOT NULL default '0.00',
  `NSUMME` decimal(10,2) NOT NULL default '0.00',
  `MSUMME_0` decimal(10,2) NOT NULL default '0.00',
  `MSUMME_1` decimal(10,2) NOT NULL default '0.00',
  `MSUMME_2` decimal(10,2) NOT NULL default '0.00',
  `MSUMME_3` decimal(10,2) NOT NULL default '0.00',
  `MSUMME` decimal(10,2) NOT NULL default '0.00',
  `BSUMME_0` decimal(10,2) NOT NULL default '0.00',
  `BSUMME_1` decimal(10,2) NOT NULL default '0.00',
  `BSUMME_2` decimal(10,2) NOT NULL default '0.00',
  `BSUMME_3` decimal(10,2) NOT NULL default '0.00',
  `BSUMME` decimal(10,2) NOT NULL default '0.00',
  `ATSUMME` decimal(10,2) NOT NULL default '0.00',
  `ATMSUMME` decimal(10,2) NOT NULL default '0.00',
  `PROVIS_WERT` decimal(10,2) NOT NULL default '0.00',
  `WAEHRUNG` varchar(5) NOT NULL default '',
  `KURS` decimal(16,4) NOT NULL default '1.0000',
  `GEGENKONTO` int(11) NOT NULL default '-1',
  `SOLL_STAGE` int(4) unsigned NOT NULL default '0',
  `SOLL_SKONTO` float(5,2) NOT NULL default '0.00',
  `SOLL_NTAGE` int(4) unsigned NOT NULL default '0',
  `SOLL_RATEN` tinyint(4) NOT NULL default '1',
  `SOLL_RATBETR` decimal(10,2) NOT NULL default '0.00',
  `SOLL_RATINTERVALL` int(11) NOT NULL default '0',
  `ERSTELLT` date default NULL,
  `ERST_NAME` varchar(20) default NULL,
  `KUN_NUM` varchar(20) default NULL,
  `KUN_ANREDE` varchar(40) default NULL,
  `KUN_NAME1` varchar(40) default NULL,
  `KUN_NAME2` varchar(40) default NULL,
  `KUN_NAME3` varchar(40) default NULL,
  `KUN_ABTEILUNG` varchar(40) default NULL,
  `KUN_STRASSE` varchar(40) default NULL,
  `KUN_LAND` varchar(5) default NULL,
  `KUN_PLZ` varchar(10) default NULL,
  `KUN_ORT` varchar(40) default NULL,
  `USR1` varchar(80) default NULL,
  `USR2` varchar(80) default NULL,
  `KOPFTEXT` text,
  `FUSSTEXT` text,
  `PROJEKT` varchar(80) default NULL,
  `ORGNUM` varchar(20) default NULL,
  `BEST_NAME` varchar(40) default NULL,
  `BEST_CODE` tinyint(4) default NULL,
  `BEST_DATUM` date default NULL,
  `INFO` text,
  `FREIGABE1_FLAG` enum('N','Y') NOT NULL default 'N',
  `PRINT_FLAG` enum('N','Y') NOT NULL default 'N',
  `BRUTTO_FLAG` enum('N','Y') NOT NULL default 'N',
  `MWST_FREI_FLAG` enum('N','Y') NOT NULL default 'N',
  PRIMARY KEY  (`REC_ID`),
  UNIQUE KEY `IDX_VLSNUM` (`VLSNUM`),
  KEY `ADDR_ID` (`ADDR_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.lieferschein_pos
CREATE TABLE IF NOT EXISTS `lieferschein_pos` (
  `REC_ID` int(11) NOT NULL auto_increment,
  `PROJEKT_ID` int(11) NOT NULL default '-1',
  `RECHPOS_ID` int(11) NOT NULL default '-1',
  `LIEFERSCHEIN_ID` int(11) NOT NULL default '0',
  `WARENGRUPPE` int(11) NOT NULL default '-1',
  `ARTIKELTYP` char(1) NOT NULL default '',
  `ARTIKEL_ID` int(11) NOT NULL default '-1',
  `TOP_POS_ID` int(11) NOT NULL default '-1',
  `ADDR_ID` int(11) NOT NULL default '-1',
  `ATRNUM` varchar(20) default NULL,
  `VRENUM` varchar(20) default NULL,
  `VLSNUM` varchar(20) NOT NULL default '',
  `POSITION` int(11) NOT NULL default '0',
  `VIEW_POS` char(3) default NULL,
  `MATCHCODE` varchar(20) default NULL,
  `ARTNUM` varchar(20) default NULL,
  `BARCODE` varchar(20) default NULL,
  `MENGE` decimal(10,3) NOT NULL default '0.000',
  `MENGE_BEST` decimal(10,3) NOT NULL default '0.000',
  `MENGE_REST` decimal(10,3) NOT NULL default '0.000',
  `LAENGE` varchar(20) default NULL,
  `BREITE` varchar(20) default NULL,
  `HOEHE` varchar(20) default NULL,
  `GROESSE` varchar(20) default NULL,
  `DIMENSION` varchar(20) default NULL,
  `GEWICHT` decimal(10,3) NOT NULL default '0.000',
  `ME_EINHEIT` varchar(10) default NULL,
  `PR_EINHEIT` decimal(10,3) NOT NULL default '1.000',
  `VPE` decimal(10,3) NOT NULL default '1.000',
  `EK_PREIS` decimal(10,4) NOT NULL default '0.0000',
  `CALC_FAKTOR` decimal(6,5) NOT NULL default '0.00000',
  `EPREIS` decimal(10,4) NOT NULL default '0.0000',
  `GPREIS` decimal(10,2) NOT NULL default '0.00',
  `E_RGEWINN` decimal(10,4) NOT NULL default '0.0000',
  `G_RGEWINN` decimal(10,2) NOT NULL default '0.00',
  `RABATT` decimal(10,2) NOT NULL default '0.00',
  `RABATT2` decimal(10,2) NOT NULL default '0.00',
  `RABATT3` decimal(10,2) NOT NULL default '0.00',
  `E_RABATT_BETRAG` decimal(10,4) NOT NULL default '0.0000',
  `G_RABATT_BETRAG` decimal(10,2) NOT NULL default '0.00',
  `STEUER_CODE` tinyint(4) NOT NULL default '0',
  `ALTTEIL_PROZ` decimal(10,2) NOT NULL default '0.10',
  `ALTTEIL_STCODE` tinyint(4) NOT NULL default '0',
  `PROVIS_PROZ` decimal(5,2) NOT NULL default '0.00',
  `PROVIS_WERT` decimal(10,2) NOT NULL default '0.00',
  `GEGENKTO` int(11) NOT NULL default '-1',
  `BEZEICHNUNG` text,
  `GEBUCHT` enum('N','Y') NOT NULL default 'N',
  `SN_FLAG` enum('N','Y') NOT NULL default 'N',
  `ALTTEIL_FLAG` enum('N','Y') NOT NULL default 'N',
  `BEZ_FEST_FLAG` enum('N','Y') NOT NULL default 'N',
  `BRUTTO_FLAG` enum('N','Y') NOT NULL default 'N',
  `NO_RABATT_FLAG` enum('N','Y') NOT NULL default 'N',
  PRIMARY KEY  (`REC_ID`),
  KEY `ARTIKEL_ID` (`ARTIKEL_ID`),
  KEY `JOURNAL_ID` (`LIEFERSCHEIN_ID`,`POSITION`),
  KEY `QUELLE_SRC` (`RECHPOS_ID`),
  KEY `IDX_QSRC` (`RECHPOS_ID`),
  KEY `ADDR_ID` (`ADDR_ID`),
  KEY `IDX_QUELLE_ARTID` (`ARTIKEL_ID`,`ARTIKELTYP`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.lieferzeiten
CREATE TABLE IF NOT EXISTS `lieferzeiten` (
  `REC_ID` int(11) unsigned NOT NULL auto_increment,
  `BEZEICHNUNG` varchar(50) NOT NULL default '',
  PRIMARY KEY  (`REC_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.link
CREATE TABLE IF NOT EXISTS `link` (
  `MODUL_ID` tinyint(3) NOT NULL default '-1',
  `REC_ID` int(11) NOT NULL default '-1',
  `PFAD` varchar(255) NOT NULL default '',
  `DATEI` varchar(200) NOT NULL default '',
  `BEMERKUNG` text,
  `LAST_CHANGE` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  `LAST_CHANGE_USER` varchar(50) NOT NULL default '',
  `OPEN_FLAG` enum('N','Y') NOT NULL default 'N',
  `OPEN_USER` varchar(50) NOT NULL default '',
  `OPEN_TIME` timestamp NOT NULL default '0000-00-00 00:00:00',
  PRIMARY KEY  (`MODUL_ID`,`REC_ID`,`PFAD`,`DATEI`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.mahnung
CREATE TABLE IF NOT EXISTS `mahnung` (
  `JOURNAL_ID` int(11) unsigned NOT NULL default '0',
  `ADDR_ID` int(11) unsigned NOT NULL default '0',
  `MAHNSTUFE` tinyint(1) unsigned NOT NULL default '1',
  `MAHNDATUM` date NOT NULL default '0000-00-00',
  `MAHNGEBUEHR` double(10,2) NOT NULL default '0.00',
  `ZIELDATUM` date NOT NULL default '0000-00-00',
  `MA_ID` int(11) NOT NULL default '-1',
  `BEMERKUNG` text,
  `ERLEDIGT` enum('N','Y') NOT NULL default 'N',
  `PRINT_FLAG` enum('N','Y') NOT NULL default 'N',
  `MAHN_STATUS` enum('O','F','S','E') NOT NULL default 'O',
  PRIMARY KEY  (`JOURNAL_ID`,`MAHNSTUFE`),
  KEY `IDX_ADDR_ID` (`ADDR_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.mail
CREATE TABLE IF NOT EXISTS `mail` (
  `ID` int(11) unsigned NOT NULL auto_increment,
  `MAIL_ID` varchar(255) NOT NULL default '',
  `MA_ID` int(11) unsigned NOT NULL default '0',
  `MA_KONTO_ID` int(11) unsigned NOT NULL default '0',
  `SRC_ID` int(11) unsigned NOT NULL default '0',
  `UIDL` varchar(200) default NULL,
  `TYP` tinyint(1) unsigned NOT NULL default '1',
  `ADDR_ID` int(11) NOT NULL default '-1',
  `ADDR_ASP_ID` int(11) NOT NULL default '-1',
  `GROESSE` bigint(16) unsigned NOT NULL default '0',
  `SDATUM` datetime NOT NULL default '0000-00-00 00:00:00',
  `EDATUM` datetime NOT NULL default '0000-00-00 00:00:00',
  `ORDNER_ID` int(11) unsigned NOT NULL default '1',
  `SENDER` varchar(255) NOT NULL default '',
  `EMPFAENGER` text NOT NULL,
  `CC` text,
  `BCC` text,
  `BETREFF` varchar(255) default NULL,
  `NACHRICHT_TEXT` mediumtext,
  `HEADER` text,
  `STATUS` int(5) unsigned NOT NULL default '0',
  `ANHANG_ANZ` int(3) unsigned NOT NULL default '0',
  `PRIOR` tinyint(1) unsigned NOT NULL default '2',
  `SPRACHE` varchar(100) default NULL,
  PRIMARY KEY  (`ID`),
  UNIQUE KEY `IDX_MAIL_ID` (`MA_ID`,`MA_KONTO_ID`,`MAIL_ID`),
  KEY `IDX_MA_ORDNER` (`MA_ID`,`ORDNER_ID`,`STATUS`),
  KEY `IDX_MA_KONTO_ID` (`MA_KONTO_ID`,`STATUS`),
  KEY `IDX_SRC` (`MA_ID`,`SRC_ID`),
  KEY `IDX_UIDL` (`MA_ID`,`MA_KONTO_ID`,`UIDL`),
  KEY `IDX_KTO_MAIL` (`MA_ID`,`ORDNER_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.mail_adressen
CREATE TABLE IF NOT EXISTS `mail_adressen` (
  `EMAIL` varchar(150) NOT NULL default '',
  `ADDR_ID` int(11) NOT NULL default '-1',
  `ASP_ID` int(11) NOT NULL default '-1',
  PRIMARY KEY  (`EMAIL`,`ADDR_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.mail_anhang
CREATE TABLE IF NOT EXISTS `mail_anhang` (
  `MAIL_ID` int(11) unsigned NOT NULL default '0',
  `PART_ID` int(11) unsigned NOT NULL default '0',
  `TYP` varchar(250) default NULL,
  `DATEINAME` varchar(255) default NULL,
  `DATA` longblob,
  `GROESSE` bigint(20) unsigned NOT NULL default '0',
  PRIMARY KEY  (`MAIL_ID`,`PART_ID`),
  KEY `MAIL_ID` (`MAIL_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.mail_konten
CREATE TABLE IF NOT EXISTS `mail_konten` (
  `MA_ID` int(11) unsigned NOT NULL default '0',
  `KONTO_ID` int(11) unsigned NOT NULL auto_increment,
  `KONTO_NAME` varchar(255) NOT NULL default '',
  `KONTO_DEFAULT` enum('N','Y') NOT NULL default 'N',
  `KONTO_GLOBAL` enum('N','Y') NOT NULL default 'N',
  `KONTO_ORDNER` enum('N','Y') NOT NULL default 'N',
  `POP3_SERVER` varchar(200) default NULL,
  `POP3_USER` varchar(100) default NULL,
  `POP3_PASSWORD` varchar(100) default NULL,
  `POP3_PORT` int(5) unsigned NOT NULL default '110',
  `POP3_EMPFANG_FLAG` enum('N','Y') NOT NULL default 'Y',
  `POP3_DELETE_FLAG` enum('N','Y') NOT NULL default 'N',
  `POP3_DELETE_TAGE` int(5) unsigned NOT NULL default '0',
  `POP3_LE_EMPFANG` datetime NOT NULL default '0000-00-00 00:00:00',
  `SMTP_SERVER` varchar(200) default NULL,
  `SMTP_USER` varchar(100) default NULL,
  `SMTP_PASSWORD` varchar(100) default NULL,
  `SMTP_USERNAME` varchar(255) default NULL,
  `SMTP_PORT` int(5) unsigned NOT NULL default '25',
  `SMTP_EMAIL` varchar(255) default NULL,
  `SMTP_DEFAULT` enum('N','Y') NOT NULL default 'N',
  `SMTP_BCC` varchar(255) default NULL,
  `SMTP_MODE` tinyint(3) unsigned NOT NULL default '1',
  PRIMARY KEY  (`MA_ID`,`KONTO_NAME`),
  UNIQUE KEY `IDX_KTO_ID` (`KONTO_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.mail_ordner
CREATE TABLE IF NOT EXISTS `mail_ordner` (
  `MA_ID` int(11) unsigned NOT NULL default '0',
  `ORDNER_ID` int(11) unsigned NOT NULL auto_increment,
  `KONTO_ID` int(11) unsigned NOT NULL default '0',
  `ORDNER_NAME` varchar(200) NOT NULL default '',
  `ORDNER_TYP` enum('PE','PA','GO','DE','EW','GLOB','-') NOT NULL default '-',
  `PARRENT_ORDNER` int(11) NOT NULL default '-1',
  PRIMARY KEY  (`ORDNER_ID`),
  KEY `IDX_MA_ORD` (`MA_ID`,`KONTO_ID`,`ORDNER_ID`,`ORDNER_TYP`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.mail_regeln
CREATE TABLE IF NOT EXISTS `mail_regeln` (
  `MA_ID` int(11) unsigned NOT NULL default '0',
  `REGELNAME` varchar(100) NOT NULL default '',
  `MA_KONTO_ID` int(11) unsigned NOT NULL default '0',
  `REGEL_AKTIV` enum('N','Y') NOT NULL default 'Y',
  `POSITION` tinyint(3) unsigned default NULL,
  `BED_KONTO_ID` int(11) unsigned NOT NULL default '0',
  `BED_SENDER` varchar(255) default NULL,
  `BED_EMPF` varchar(255) default NULL,
  `BED_EMPF_OR_CC` varchar(255) default NULL,
  `BED_BETR` varchar(255) default NULL,
  `BED_NTEXT` varchar(255) default NULL,
  `BED_BETR_OR_NTEXT` tinyint(3) unsigned default NULL,
  `BED_PRIOR` tinyint(3) NOT NULL default '-1',
  `AKTIONEN` tinyint(3) unsigned NOT NULL default '0',
  `AKT_ZIELORDNER_ID` int(11) unsigned NOT NULL default '0',
  `AKT_AUTOAW` int(11) unsigned NOT NULL default '0',
  `AKT_WL_EMAIL` varchar(255) default NULL,
  PRIMARY KEY  (`MA_ID`,`REGELNAME`,`MA_KONTO_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.mengeneinheit
CREATE TABLE IF NOT EXISTS `mengeneinheit` (
  `REC_ID` int(11) unsigned NOT NULL auto_increment,
  `SPRACHE_ID` int(11) unsigned NOT NULL default '0',
  `BEZEICHNUNG` varchar(50) NOT NULL default '',
  PRIMARY KEY  (`REC_ID`),
  UNIQUE KEY `BEZEICHNUNG` (`BEZEICHNUNG`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.mitarbeiter
CREATE TABLE IF NOT EXISTS `mitarbeiter` (
  `MA_ID` int(11) unsigned NOT NULL auto_increment,
  `MA_NUMMER` varchar(10) default NULL,
  `NAME` varchar(100) default NULL,
  `VNAME` varchar(100) default NULL,
  `LOGIN_NAME` varchar(50) NOT NULL default '',
  `ANZEIGE_NAME` varchar(50) NOT NULL default '',
  `USER_PASSWORD` varchar(32) NOT NULL default '',
  `ANREDE` varchar(15) default NULL,
  `TITEL` varchar(15) default NULL,
  `ZUSATZ` varchar(40) default NULL,
  `ZUSATZ2` varchar(40) default NULL,
  `ZUHAENDEN` varchar(40) default NULL,
  `STRASSE` varchar(40) default NULL,
  `LAND` varchar(5) default NULL,
  `PLZ` varchar(10) default NULL,
  `ORT` varchar(40) default NULL,
  `TELEFON` varchar(100) default NULL,
  `FAX` varchar(100) default NULL,
  `FUNK` varchar(100) default NULL,
  `EMAIL` varchar(100) default NULL,
  `INTERNET` varchar(100) default NULL,
  `TELEFON_INTERN` varchar(255) default NULL,
  `SPRACH_ID` smallint(6) default '2',
  `BESCHAEFTIGUNGSART` smallint(6) default NULL,
  `BESCHAEFTIGUNGSGRAD` smallint(6) default NULL,
  `JAHRESURLAUB` float default NULL,
  `GUELTIG_VON` datetime default NULL,
  `GUELTIG_BIS` datetime default NULL,
  `GEBDATUM` datetime default NULL,
  `GESCHLECHT` enum('M','W') NOT NULL default 'M',
  `FAMSTAND` smallint(6) default NULL,
  `BANK` varchar(40) default NULL,
  `BLZ` varchar(10) default NULL,
  `KTO` varchar(20) default NULL,
  `BEMERKUNG` text,
  `ERSTELLT` datetime default NULL,
  `ERSTELLT_NAME` varchar(20) default NULL,
  `GEAEND` datetime default NULL,
  `GEAEND_NAME` varchar(20) default NULL,
  `USERFELD_01` varchar(255) default NULL,
  `USERFELD_02` varchar(255) default NULL,
  `USERFELD_03` varchar(255) default NULL,
  `USERFELD_04` varchar(255) default NULL,
  `USERFELD_05` varchar(255) default NULL,
  `USERFELD_06` varchar(255) default NULL,
  `USERFELD_07` varchar(255) default NULL,
  `USERFELD_08` varchar(255) default NULL,
  `USERFELD_09` varchar(255) default NULL,
  `USERFELD_10` varchar(255) default NULL,
  PRIMARY KEY  (`MA_ID`),
  UNIQUE KEY `IDX_LOGINNAME` (`LOGIN_NAME`),
  UNIQUE KEY `IDX_MA_NUM` (`MA_NUMMER`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.pim_aufgaben
CREATE TABLE IF NOT EXISTS `pim_aufgaben` (
  `RECORDID` int(11) NOT NULL auto_increment,
  `RESOURCEID` int(11) NOT NULL default '0',
  `COMPLETE` enum('N','Y') default 'N',
  `DESCRIPTION` char(255) default NULL,
  `DETAILS` char(255) default NULL,
  `CREATEDON` datetime default NULL,
  `PRIORITY` int(11) default NULL,
  `CATEGORY` int(11) default NULL,
  `COMPLETEDON` datetime default NULL,
  `DUEDATE` datetime default NULL,
  `PRIVATE` enum('N','Y') NOT NULL default 'N',
  `USERFIELD0` char(100) default NULL,
  `USERFIELD1` char(100) default NULL,
  `USERFIELD2` char(100) default NULL,
  `USERFIELD3` char(100) default NULL,
  `USERFIELD4` char(100) default NULL,
  `USERFIELD5` char(100) default NULL,
  `USERFIELD6` char(100) default NULL,
  `USERFIELD7` char(100) default NULL,
  `USERFIELD8` char(100) default NULL,
  `USERFIELD9` char(100) default NULL,
  PRIMARY KEY  (`RECORDID`),
  KEY `ResID_ndx` (`RESOURCEID`),
  KEY `DueDate` (`DUEDATE`),
  KEY `CompletedOn` (`COMPLETEDON`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.pim_kontakte
CREATE TABLE IF NOT EXISTS `pim_kontakte` (
  `RECORDID` int(11) NOT NULL auto_increment,
  `RESOURCEID` int(11) NOT NULL default '0',
  `FIRSTNAME` char(50) default NULL,
  `LASTNAME` char(50) NOT NULL default '',
  `BIRTHDATE` date default NULL,
  `ANNIVERSARY` date default NULL,
  `TITLE` char(50) default NULL,
  `COMPANY` char(50) NOT NULL default '',
  `JOB_POSITION` char(30) default NULL,
  `ADDRESS` char(100) default NULL,
  `CITY` char(50) default NULL,
  `STATE` char(25) default NULL,
  `ZIP` char(10) default NULL,
  `COUNTRY` char(25) default NULL,
  `NOTE` char(255) default NULL,
  `PHONE1` char(25) default NULL,
  `PHONE2` char(25) default NULL,
  `PHONE3` char(25) default NULL,
  `PHONE4` char(25) default NULL,
  `PHONE5` char(25) default NULL,
  `PHONETYPE1` int(11) default NULL,
  `PHONETYPE2` int(11) default NULL,
  `PHONETYPE3` int(11) default NULL,
  `PHONETYPE4` int(11) default NULL,
  `PHONETYPE5` int(11) default NULL,
  `CATEGORY` int(11) default NULL,
  `EMAIL` char(100) default NULL,
  `CUSTOM1` char(100) default NULL,
  `CUSTOM2` char(100) default NULL,
  `CUSTOM3` char(100) default NULL,
  `CUSTOM4` char(100) default NULL,
  `USERFIELD0` char(100) default NULL,
  `USERFIELD1` char(100) default NULL,
  `USERFIELD2` char(100) default NULL,
  `USERFIELD3` char(100) default NULL,
  `USERFIELD4` char(100) default NULL,
  `USERFIELD5` char(100) default NULL,
  `USERFIELD6` char(100) default NULL,
  `USERFIELD7` char(100) default NULL,
  `USERFIELD8` char(100) default NULL,
  `USERFIELD9` char(100) default NULL,
  PRIMARY KEY  (`RECORDID`),
  KEY `ResID_ndx` (`RESOURCEID`),
  KEY `LName_ndx` (`LASTNAME`),
  KEY `Company_ndx` (`COMPANY`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.pim_termine
CREATE TABLE IF NOT EXISTS `pim_termine` (
  `RECORDID` int(11) NOT NULL auto_increment,
  `STARTTIME` datetime default NULL,
  `ENDTIME` datetime default NULL,
  `RESOURCEID` int(11) NOT NULL default '0',
  `DESCRIPTION` char(255) default NULL,
  `NOTES` char(255) default NULL,
  `CATEGORY` int(11) default NULL,
  `ALLDAYEVENT` enum('N','Y') NOT NULL default 'N',
  `DINGPATH` char(255) default NULL,
  `ALARMSET` enum('N','Y') NOT NULL default 'N',
  `ALARMADVANCE` int(11) default NULL,
  `ALARMADVANCETYPE` int(11) default NULL,
  `SNOOZETIME` datetime default NULL,
  `REPEATCODE` int(11) default NULL,
  `REPEATRANGEEND` datetime default NULL,
  `CUSTOMINTERVAL` int(11) default NULL,
  `PRIVATE` enum('N','Y') NOT NULL default 'N',
  `USERFIELD0` char(100) default NULL,
  `USERFIELD1` char(100) default NULL,
  `USERFIELD2` char(100) default NULL,
  `USERFIELD3` char(100) default NULL,
  `USERFIELD4` char(100) default NULL,
  `USERFIELD5` char(100) default NULL,
  `USERFIELD6` char(100) default NULL,
  `USERFIELD7` char(100) default NULL,
  `USERFIELD8` char(100) default NULL,
  `USERFIELD9` char(100) default NULL,
  PRIMARY KEY  (`RECORDID`),
  KEY `rid_st_ndx` (`RESOURCEID`,`STARTTIME`),
  KEY `st_ndx` (`STARTTIME`),
  KEY `et_ndx` (`ENDTIME`),
  KEY `ResID_ndx` (`RESOURCEID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.plz
CREATE TABLE IF NOT EXISTS `plz` (
  `LAND` char(3) NOT NULL default 'D',
  `PLZ` varchar(11) NOT NULL default '',
  `NAME` varchar(50) NOT NULL default '',
  `VORWAHL` varchar(12) default NULL,
  `BUNDESLAND` char(3) default NULL,
  PRIMARY KEY  (`LAND`,`PLZ`,`NAME`),
  KEY `IDX_NAME` (`LAND`,`NAME`),
  KEY `IDX_VORWAHL` (`LAND`,`VORWAHL`),
  KEY `IDX_LAND` (`LAND`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.pos_ta
CREATE TABLE IF NOT EXISTS `pos_ta` (
  `LFD_NR` int(11) unsigned NOT NULL default '0',
  `MA_ID` int(11) NOT NULL default '-1',
  `DATUM_START` datetime NOT NULL default '0000-00-00 00:00:00',
  `DATUM_ENDE` datetime default NULL,
  `WECHSELGELD_START` decimal(12,2) NOT NULL default '0.00',
  `WECHSELGELD_ENDE` decimal(12,2) NOT NULL default '0.00',
  `UMSATZ_ENDE` decimal(12,2) NOT NULL default '0.00',
  `BEMERKUNG` text,
  `ABGERECHNET` enum('N','Y') NOT NULL default 'N',
  `ABGERECHNET_MA` int(11) NOT NULL default '-1',
  PRIMARY KEY  (`LFD_NR`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COMMENT='Tagesabschluß, Anfangs- und Endbestand der Kasse';

# Data exporting was unselected.


# Dumping structure for table caofaktura.rabattgruppen
CREATE TABLE IF NOT EXISTS `rabattgruppen` (
  `RABGRP_ID` varchar(10) NOT NULL default '',
  `RABGRP_TYP` tinyint(3) NOT NULL default '0',
  `MIN_MENGE` int(11) NOT NULL default '1',
  `LIEF_RABGRP` int(10) NOT NULL default '0',
  `RABATT1` decimal(5,2) NOT NULL default '0.00',
  `RABATT2` decimal(5,2) NOT NULL default '0.00',
  `RABATT3` decimal(5,2) NOT NULL default '0.00',
  `ADDR_ID` int(11) NOT NULL default '-1',
  `BESCHREIBUNG` varchar(250) default NULL,
  PRIMARY KEY  (`RABGRP_ID`,`RABGRP_TYP`,`LIEF_RABGRP`,`MIN_MENGE`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.rabmatrix
CREATE TABLE IF NOT EXISTS `rabmatrix` (
  `KUNDENGRUPPE` int(11) unsigned NOT NULL default '0',
  `WARENGRUPPE` int(11) unsigned NOT NULL default '0',
  `VK` tinyint(3) unsigned NOT NULL default '1',
  `RABATT1` decimal(5,2) NOT NULL default '0.00',
  `RABATT2` decimal(5,2) NOT NULL default '0.00',
  `RABATT3` decimal(5,2) NOT NULL default '0.00',
  `SCHWELLWERT` decimal(10,2) default NULL,
  PRIMARY KEY  (`KUNDENGRUPPE`,`WARENGRUPPE`,`VK`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.registry
CREATE TABLE IF NOT EXISTS `registry` (
  `MAINKEY` varchar(255) NOT NULL default '',
  `NAME` varchar(100) NOT NULL default '',
  `VAL_CHAR` varchar(255) default NULL,
  `VAL_DATE` datetime default NULL,
  `VAL_INT` int(11) default NULL,
  `VAL_INT2` bigint(20) default NULL,
  `VAL_INT3` bigint(20) default NULL,
  `VAL_DOUBLE` double default NULL,
  `VAL_BLOB` longtext,
  `VAL_BIN` longblob,
  `VAL_TYP` smallint(6) default NULL,
  `CACHABLE` enum('N','Y') NOT NULL default 'N',
  `READONLY` enum('N','Y') NOT NULL default 'N',
  `LAST_CHANGE` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`MAINKEY`,`NAME`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.schriftverkehr
CREATE TABLE IF NOT EXISTS `schriftverkehr` (
  `ID` int(11) NOT NULL auto_increment,
  `BESCHREIBUNG` varchar(250) default NULL,
  `LANG_TEXT` longtext,
  `CHANGE_LAST` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  `CHANGE_USER` varchar(100) default NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.schriftverkehr_adr
CREATE TABLE IF NOT EXISTS `schriftverkehr_adr` (
  `SCHRIFTVERKEHR_ID` int(11) NOT NULL default '0',
  `ADDR_ID` int(11) NOT NULL default '-1',
  `ASP_ID` int(11) NOT NULL default '-1',
  PRIMARY KEY  (`SCHRIFTVERKEHR_ID`,`ADDR_ID`,`ASP_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.sprachen
CREATE TABLE IF NOT EXISTS `sprachen` (
  `SPRACH_ID` int(11) NOT NULL auto_increment,
  `NAME` varchar(32) NOT NULL default '',
  `CODE` char(2) NOT NULL default '',
  `SORT` int(3) default NULL,
  `DEFAULT_FLAG` enum('N','Y') NOT NULL default 'N',
  PRIMARY KEY  (`SPRACH_ID`),
  KEY `IDX_NAME` (`NAME`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.textbausteine
CREATE TABLE IF NOT EXISTS `textbausteine` (
  `ID` int(11) unsigned NOT NULL auto_increment,
  `BESCHREIBUNG` varchar(255) NOT NULL default '',
  `LANGTEXT` text NOT NULL,
  PRIMARY KEY  (`ID`),
  KEY `BESCHREIBUNG` (`BESCHREIBUNG`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.ueberweisungen
CREATE TABLE IF NOT EXISTS `ueberweisungen` (
  `ID` int(11) NOT NULL auto_increment,
  `UWNUM` int(11) NOT NULL default '0',
  `ART` enum('U','L') NOT NULL default 'U',
  `FERTIG` tinyint(1) default '0',
  `JOURNAL_ID` int(11) NOT NULL default '0',
  `UW_DATUM` date default NULL,
  `BETRAG` decimal(10,2) NOT NULL default '0.00',
  `KTO` varchar(20) default NULL,
  `BLZ` varchar(8) default NULL,
  `BINHABER` varchar(50) default NULL,
  `UW_TEXT` varchar(250) default NULL,
  PRIMARY KEY  (`ID`,`UWNUM`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.vertrag
CREATE TABLE IF NOT EXISTS `vertrag` (
  `MA_ID` int(11) NOT NULL default '-1',
  `REC_ID` int(11) NOT NULL auto_increment,
  `ADDR_ID` int(11) NOT NULL default '-1',
  `ASP_ID` int(11) NOT NULL default '-1',
  `PROJEKT_ID` int(11) NOT NULL default '-1',
  `AUSLAND_TYP` tinyint(1) unsigned NOT NULL default '0',
  `VVTNUM` int(11) NOT NULL default '-1',
  `VERTRETER_ID` int(11) NOT NULL default '-1',
  `KLASSE_ID` tinyint(3) unsigned NOT NULL default '0',
  `GLOBRABATT` float(10,2) NOT NULL default '0.00',
  `DATUM_START` date NOT NULL default '0000-00-00',
  `DATUM_ENDE` date NOT NULL default '0000-00-00',
  `DATUM_NEXT` date NOT NULL default '0000-00-00',
  `INTERVALL` char(1) NOT NULL default 'M',
  `INTERVALL_NUM` tinyint(3) unsigned NOT NULL default '1',
  `AKTIV_FLAG` enum('N','Y') NOT NULL default 'N',
  `PRINT_FLAG` enum('N','Y') NOT NULL default 'N',
  `PR_EBENE` tinyint(4) default NULL,
  `LIEFART` tinyint(2) default NULL,
  `ZAHLART` tinyint(2) default NULL,
  `KOST_NETTO` decimal(10,2) NOT NULL default '0.00',
  `WERT_NETTO` decimal(10,2) NOT NULL default '0.00',
  `LOHN` decimal(10,2) NOT NULL default '0.00',
  `WARE` decimal(10,2) NOT NULL default '0.00',
  `TKOST` decimal(10,2) NOT NULL default '0.00',
  `MWST_0` decimal(5,2) NOT NULL default '0.00',
  `MWST_1` decimal(5,2) NOT NULL default '0.00',
  `MWST_2` decimal(5,2) NOT NULL default '0.00',
  `MWST_3` decimal(5,2) NOT NULL default '0.00',
  `NSUMME_0` decimal(10,2) NOT NULL default '0.00',
  `NSUMME_1` decimal(10,2) NOT NULL default '0.00',
  `NSUMME_2` decimal(10,2) NOT NULL default '0.00',
  `NSUMME_3` decimal(10,2) NOT NULL default '0.00',
  `NSUMME` decimal(10,2) NOT NULL default '0.00',
  `MSUMME_0` decimal(10,2) NOT NULL default '0.00',
  `MSUMME_1` decimal(10,2) NOT NULL default '0.00',
  `MSUMME_2` decimal(10,2) NOT NULL default '0.00',
  `MSUMME_3` decimal(10,2) NOT NULL default '0.00',
  `MSUMME` decimal(10,2) NOT NULL default '0.00',
  `BSUMME_0` decimal(10,2) NOT NULL default '0.00',
  `BSUMME_1` decimal(10,2) NOT NULL default '0.00',
  `BSUMME_2` decimal(10,2) NOT NULL default '0.00',
  `BSUMME_3` decimal(10,2) NOT NULL default '0.00',
  `BSUMME` decimal(10,2) NOT NULL default '0.00',
  `ATSUMME` decimal(10,2) NOT NULL default '0.00',
  `ATMSUMME` decimal(10,2) NOT NULL default '0.00',
  `WAEHRUNG` varchar(5) NOT NULL default '',
  `KURS` decimal(16,4) NOT NULL default '1.0000',
  `GEGENKONTO` int(11) NOT NULL default '-1',
  `SOLL_STAGE` tinyint(4) NOT NULL default '0',
  `SOLL_SKONTO` float(5,2) NOT NULL default '0.00',
  `SOLL_NTAGE` tinyint(4) NOT NULL default '0',
  `SOLL_RATEN` tinyint(4) NOT NULL default '1',
  `SOLL_RATBETR` decimal(10,2) NOT NULL default '0.00',
  `SOLL_RATINTERVALL` int(11) NOT NULL default '0',
  `STADIUM` tinyint(4) NOT NULL default '0',
  `ERSTELLT` date default NULL,
  `ERST_NAME` varchar(20) default NULL,
  `KUN_NUM` varchar(20) default NULL,
  `KUN_ANREDE` varchar(40) default NULL,
  `KUN_NAME1` varchar(40) default NULL,
  `KUN_NAME2` varchar(40) default NULL,
  `KUN_NAME3` varchar(40) default NULL,
  `KUN_ABTEILUNG` varchar(40) default NULL,
  `KUN_STRASSE` varchar(40) default NULL,
  `KUN_LAND` varchar(5) default NULL,
  `KUN_PLZ` varchar(10) default NULL,
  `KUN_ORT` varchar(40) default NULL,
  `USR1` varchar(80) default NULL,
  `USR2` varchar(80) default NULL,
  `KOPFTEXT` text,
  `FUSSTEXT` text,
  `PROJEKT` varchar(80) default NULL,
  `ORGNUM` varchar(20) default NULL,
  `BEST_NAME` varchar(40) default NULL,
  `BEST_CODE` tinyint(4) default NULL,
  `BEST_DATUM` date default NULL,
  `INFO` text,
  `BRUTTO_FLAG` enum('N','Y') NOT NULL default 'N',
  `MWST_FREI_FLAG` enum('N','Y') NOT NULL default 'N',
  PRIMARY KEY  (`REC_ID`),
  KEY `ADDR_ID` (`ADDR_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.vertragpos
CREATE TABLE IF NOT EXISTS `vertragpos` (
  `REC_ID` int(11) NOT NULL auto_increment,
  `JOURNAL_ID` int(11) NOT NULL default '0',
  `PROJEKT_ID` int(11) NOT NULL default '-1',
  `WARENGRUPPE` int(11) NOT NULL default '-1',
  `ARTIKELTYP` char(1) NOT NULL default '',
  `ARTIKEL_ID` int(11) NOT NULL default '-1',
  `ADDR_ID` int(11) NOT NULL default '-1',
  `VVTNUM` int(11) NOT NULL default '-1',
  `POSITION` int(11) NOT NULL default '0',
  `VIEW_POS` char(3) default NULL,
  `MATCHCODE` varchar(20) default NULL,
  `ARTNUM` varchar(20) default NULL,
  `BARCODE` varchar(20) default NULL,
  `MENGE` decimal(10,3) NOT NULL default '0.000',
  `LAENGE` varchar(20) default NULL,
  `BREITE` varchar(20) default NULL,
  `HOEHE` varchar(20) default NULL,
  `GROESSE` varchar(20) default NULL,
  `DIMENSION` varchar(20) default NULL,
  `GEWICHT` decimal(10,3) NOT NULL default '0.000',
  `ME_EINHEIT` varchar(10) default NULL,
  `PR_EINHEIT` decimal(10,3) NOT NULL default '1.000',
  `VPE` decimal(10,3) NOT NULL default '1.000',
  `EK_PREIS` decimal(10,4) NOT NULL default '0.0000',
  `CALC_FAKTOR` decimal(6,5) NOT NULL default '0.00000',
  `EPREIS` decimal(10,4) NOT NULL default '0.0000',
  `GPREIS` decimal(10,2) NOT NULL default '0.00',
  `E_RGEWINN` decimal(10,4) NOT NULL default '0.0000',
  `G_RGEWINN` decimal(10,2) NOT NULL default '0.00',
  `RABATT` decimal(10,2) NOT NULL default '0.00',
  `RABATT2` decimal(10,2) NOT NULL default '0.00',
  `RABATT3` decimal(10,2) NOT NULL default '0.00',
  `E_RABATT_BETRAG` decimal(10,4) NOT NULL default '0.0000',
  `G_RABATT_BETRAG` decimal(10,2) NOT NULL default '0.00',
  `STEUER_CODE` tinyint(4) NOT NULL default '0',
  `ALTTEIL_PROZ` decimal(10,2) NOT NULL default '0.10',
  `ALTTEIL_STCODE` tinyint(4) NOT NULL default '0',
  `GEGENKTO` int(11) NOT NULL default '-1',
  `BEZEICHNUNG` text,
  `ALTTEIL_FLAG` enum('N','Y') NOT NULL default 'N',
  `BEZ_FEST_FLAG` enum('N','Y') NOT NULL default 'N',
  `BRUTTO_FLAG` enum('N','Y') NOT NULL default 'N',
  `NO_RABATT_FLAG` enum('N','Y') NOT NULL default 'N',
  PRIMARY KEY  (`REC_ID`),
  KEY `ARTIKEL_ID` (`ARTIKEL_ID`),
  KEY `ADDR_ID` (`ADDR_ID`),
  KEY `JOURNAL_ID` (`JOURNAL_ID`,`POSITION`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.vertreter
CREATE TABLE IF NOT EXISTS `vertreter` (
  `VERTRETER_ID` int(11) NOT NULL auto_increment,
  `VERTR_NUMMER` varchar(10) default NULL,
  `VNAME` varchar(30) default NULL,
  `NAME` varchar(30) default NULL,
  `DatumNeu` datetime default NULL,
  `DatumBearbeiten` datetime default NULL,
  `BenutzerNeu` varchar(50) default NULL,
  `BenutzerBearbeiten` varchar(50) default NULL,
  `ANREDE` varchar(15) default NULL,
  `TITEL` varchar(15) default NULL,
  `ZUSATZ` varchar(40) default NULL,
  `ZUSATZ2` varchar(40) default NULL,
  `ZUHAENDEN` varchar(40) default NULL,
  `STRASSE` varchar(40) default NULL,
  `LAND` varchar(5) default NULL,
  `PLZ` varchar(10) default NULL,
  `ORT` varchar(40) default NULL,
  `TELEFON` varchar(100) default NULL,
  `FAX` varchar(100) default NULL,
  `FUNK` varchar(100) default NULL,
  `EMAIL` varchar(100) default NULL,
  `INTERNET` varchar(100) default NULL,
  `SPRACH_ID` smallint(6) default '2',
  `PROVISIONSART` char(1) default NULL,
  `ABRECHNUNGSZEITPUNKT` enum('R','Z') default 'Z',
  `PROVISIONMITTRANSPORT` enum('Y','N') default 'N',
  `PROVISIONSATZ` float(5,2) default NULL,
  `LETZTEABRECHNUNG` date default NULL,
  `UMSATZ` decimal(12,2) default NULL,
  `PROVISION` decimal(10,2) default NULL,
  `BESCHAEFTIGUNGSART` smallint(6) default NULL,
  `BESCHAEFTIGUNGSGRAD` smallint(6) default NULL,
  `GUELTIG_VON` datetime default NULL,
  `GUELTIG_BIS` datetime default NULL,
  `GEBDATUM` datetime default NULL,
  `GESCHLECHT` enum('M','W') NOT NULL default 'M',
  `FAMSTAND` smallint(6) default NULL,
  `BANK` varchar(40) default NULL,
  `KTO_INHABER` varchar(40) default NULL,
  `BLZ` varchar(10) default NULL,
  `KTO` varchar(20) default NULL,
  `BEMERKUNG` text,
  `ERSTELLT` datetime default NULL,
  `ERSTELLT_NAME` varchar(20) default NULL,
  `GEAEND` datetime default NULL,
  `GEAEND_NAME` varchar(20) default NULL,
  `USERFELD_01` varchar(255) default NULL,
  `USERFELD_02` varchar(255) default NULL,
  `USERFELD_03` varchar(255) default NULL,
  `USERFELD_04` varchar(255) default NULL,
  `USERFELD_05` varchar(255) default NULL,
  `USERFELD_06` varchar(255) default NULL,
  `USERFELD_07` varchar(255) default NULL,
  `USERFELD_08` varchar(255) default NULL,
  `USERFELD_09` varchar(255) default NULL,
  `USERFELD_10` varchar(255) default NULL,
  PRIMARY KEY  (`VERTRETER_ID`),
  UNIQUE KEY `IDX_VE_NUM` (`VERTR_NUMMER`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.vertreter_abr
CREATE TABLE IF NOT EXISTS `vertreter_abr` (
  `VERTRETER_ID` int(11) NOT NULL default '-1',
  `ABRECHNUNG_ID` int(11) unsigned NOT NULL auto_increment,
  `ZEITRAUM_JAHR` int(4) unsigned NOT NULL default '0',
  `ZEITRAUM_MONAT` int(2) unsigned NOT NULL default '0',
  `ABRECHNUNG_NUM` int(11) unsigned NOT NULL default '0',
  `UMSATZ_NETTO` double(10,2) NOT NULL default '0.00',
  `PROVISION_NETTO` double(10,2) NOT NULL default '0.00',
  `BELEG_ERSTELLT` enum('N','Y') NOT NULL default 'N',
  `JOURNAL_ID` int(11) NOT NULL default '0',
  `BEMERKUNG` text,
  `ERSTELLT` datetime NOT NULL default '0000-00-00 00:00:00',
  `ERSTELLT_NAME` varchar(20) default NULL,
  PRIMARY KEY  (`VERTRETER_ID`,`ZEITRAUM_JAHR`,`ZEITRAUM_MONAT`),
  UNIQUE KEY `IDX_VETR_ABR` (`VERTRETER_ID`,`ABRECHNUNG_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.warengruppen
CREATE TABLE IF NOT EXISTS `warengruppen` (
  `ID` int(11) NOT NULL auto_increment,
  `TOP_ID` int(11) NOT NULL default '-1',
  `NAME` varchar(250) NOT NULL default '',
  `BESCHREIBUNG` text,
  `DEF_EKTO` int(11) default '-1',
  `DEF_AKTO` int(11) default '-1',
  `STEUER_CODE` tinyint(4) unsigned NOT NULL default '2',
  `VK1_FAKTOR` float(6,5) NOT NULL default '0.00000',
  `VK2_FAKTOR` float(6,5) NOT NULL default '0.00000',
  `VK3_FAKTOR` float(6,5) NOT NULL default '0.00000',
  `VK4_FAKTOR` float(6,5) NOT NULL default '0.00000',
  `VK5_FAKTOR` float(6,5) NOT NULL default '0.00000',
  `VORGABEN` text,
  PRIMARY KEY  (`ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.wartung
CREATE TABLE IF NOT EXISTS `wartung` (
  `REC_ID` int(11) NOT NULL auto_increment,
  `ADDR_ID` int(11) NOT NULL default '-1',
  `ASP_ID` int(11) NOT NULL default '-1',
  `BESCHREIBUNG` varchar(255) default NULL,
  `WARTUNG` date default NULL,
  `INTERVALL` int(11) default '0',
  `WVERTRAG` varchar(20) default NULL,
  `BEMERKUNG` text,
  `LEBENSLAUF` text,
  `LISTE` text,
  `WARTUNG_TYP` varchar(20) default NULL,
  `WVERTRAG_NR` smallint(6) default '0',
  `SOLLZEIT_KW` float(3,1) default NULL,
  `SOLLZEIT_GW` float(3,1) default NULL,
  `ENTFERNUNG` int(11) unsigned default NULL,
  `BEM_OPT1` tinyint(1) unsigned default '0',
  `BEM_OPT2` tinyint(1) unsigned default '0',
  `BEM_OPT3` tinyint(1) unsigned default '0',
  `BEM_OPT4` tinyint(1) unsigned default '0',
  `BEM_OPT5` tinyint(1) unsigned default '0',
  `BEM_OPT6` tinyint(1) unsigned default '0',
  `BEM_OPT7` tinyint(1) unsigned default '0',
  `BEM_OPT8` tinyint(1) unsigned default '0',
  `BEM_OPT9` tinyint(1) unsigned default '0',
  `ERSTELLT` date default NULL,
  `ERST_NAME` varchar(20) default NULL,
  `GEAENDERT` date default NULL,
  `GEAEND_NAME` varchar(20) default NULL,
  PRIMARY KEY  (`REC_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.zahlungen
CREATE TABLE IF NOT EXISTS `zahlungen` (
  `REC_ID` int(11) unsigned NOT NULL auto_increment,
  `FIBU_KTO` int(6) unsigned NOT NULL default '0',
  `FIBU_GEGENKTO` int(6) NOT NULL default '-1',
  `MA_ID` int(11) NOT NULL default '0',
  `ADDR_ID` int(11) NOT NULL default '-1',
  `QUELLE` tinyint(2) unsigned default '0',
  `JOURNAL_ID` int(11) NOT NULL default '-1',
  `ART` enum('GS','LS','UB','?') NOT NULL default '?',
  `AUSZUG` int(6) unsigned NOT NULL default '0',
  `UW_NUM` int(11) NOT NULL default '-1',
  `DATUM` date NOT NULL default '0000-00-00',
  `VALUTA` date NOT NULL default '0000-00-00',
  `BELEGNUM` varchar(20) NOT NULL default '',
  `BETRAG` decimal(10,2) NOT NULL default '0.00',
  `SKONTO_PROZ` decimal(5,3) NOT NULL default '0.000',
  `SKONTO_BETRAG` decimal(10,2) NOT NULL default '0.00',
  `WAEHRUNG` char(3) NOT NULL default 'EUR',
  `PRIMANOTA` varchar(10) default NULL,
  `TEXTSCHLUESSEL` int(3) unsigned NOT NULL default '0',
  `VERW_ZWECK` text NOT NULL,
  `BEMERKUNG` text,
  `GEBUCHT` enum('N','Y','S','E') NOT NULL default 'N',
  `PARTNER_NAME1` varchar(40) default NULL,
  `PARTNER_NAME2` varchar(40) default NULL,
  `PARTNER_KTO` varchar(12) default NULL,
  `PARTNER_BLZ` varchar(12) default NULL,
  `PARTNER_IBAN` varchar(100) default NULL,
  `PARTNER_SWIFT` varchar(100) default NULL,
  `ERSTELLT_AM` datetime NOT NULL default '0000-00-00 00:00:00',
  `ERSTELLT_NAME` varchar(50) default NULL,
  PRIMARY KEY  (`REC_ID`),
  KEY `IDX_ADDR_ID` (`ADDR_ID`),
  KEY `IDX_JOURNAL_ID` (`JOURNAL_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.


# Dumping structure for table caofaktura.zahlungsarten
CREATE TABLE IF NOT EXISTS `zahlungsarten` (
  `REC_ID` int(11) NOT NULL auto_increment,
  `NAME` varchar(100) NOT NULL default '',
  `TEXT_KURZ` varchar(255) NOT NULL default '',
  `TEXT_LANG` longtext,
  `NETTO_TAGE` int(3) default NULL,
  `SKONTO_TAGE` int(3) default NULL,
  `SKONTO_PROZ` decimal(5,3) NOT NULL default '0.000',
  `FIBU_KONTEN` varchar(255) NOT NULL default '',
  `AKTIV_FLAG` enum('N','Y') NOT NULL default 'Y',
  PRIMARY KEY  (`REC_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

# Data exporting was unselected.
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
