CREATE DATABASE  IF NOT EXISTS `usermgt` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `usermgt`;
-- MySQL dump 10.13  Distrib 8.0.27, for Win64 (x86_64)
--
-- Host: localhost    Database: usermgt
-- ------------------------------------------------------
-- Server version	8.0.27

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
-- Table structure for table `nationalities`
--

DROP TABLE IF EXISTS `nationalities`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `nationalities` (
  `nationality_id` int NOT NULL AUTO_INCREMENT,
  `country_code` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `country` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `nationality` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  PRIMARY KEY (`nationality_id`)
) ENGINE=InnoDB AUTO_INCREMENT=578 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `nationalities`
--

LOCK TABLES `nationalities` WRITE;
/*!40000 ALTER TABLE `nationalities` DISABLE KEYS */;
INSERT INTO `nationalities` VALUES (387,'AD','Andorra','Andorran'),(388,'AE','United Arab Emirates','Emirian'),(389,'AF','Afghanistan','Afghan'),(390,'AG','Antigua and Barbuda','Antiguans, Barbudans'),(391,'AL','Albania','Albanian'),(392,'AM','Armenia','Armenian'),(393,'AO','Angola','Angolan'),(394,'AR','Argentina','Argentinean'),(395,'AT','Austria','Austrian'),(396,'AU','Australia','Australian'),(397,'AZ','Azerbaijan','Azerbaijani'),(398,'BA','Bosnia and Herzegovina','Bosnian, Herzegovinian'),(399,'BB','Barbados','Barbadian'),(400,'BD','Bangladesh','Bangladeshi'),(401,'BE','Belgium','Belgian'),(402,'BF','Burkina Faso','Burkinabe'),(403,'BG','Bulgaria','Bulgarian'),(404,'BH','Bahrain','Bahraini'),(405,'BI','Burundi','Burundian'),(406,'BJ','Benin','Beninese'),(407,'B','Brunei','Bruneian'),(408,'BO','Bolivia','Bolivian'),(409,'BR','Brazil','Brazilian'),(410,'BS','The Bahamas','Bahamian'),(411,'BT','Bhutan','Bhutanese'),(412,'BW','Botswana','Motswana (\',singular), Batswana (\',plural)'),(413,'BY','Belarus','Belarusian'),(414,'BZ','Belize','Belizean'),(415,'CA','Canada','Canadian'),(416,'CD','Congo, Republic of the','Congolese'),(417,'CG','Congo, Democratic Republic of the','Congolese'),(418,'CH','Switzerland','Swiss'),(419,'CI','Cote d\'Ivoire','Ivorian'),(420,'CM','Cameroon','Cameroonian'),(421,'C','China','Chinese'),(422,'CO','Colombia','Colombian'),(423,'CR','Costa Rica','Costa Rican'),(424,'CU','Cuba','Cuban'),(425,'CV','Cape Verde','Cape Verdian'),(426,'CY','Cyprus','Cypriot'),(427,'CZ','Czech Republic','Czech'),(428,'DE','Germany','German'),(429,'DJ','Djibouti','Djibouti'),(430,'DK','Denmark','Danish'),(431,'DM','Dominica','Dominican'),(432,'DO','Dominican Republic','Dominican'),(433,'DZ','Algeria','Algerian'),(434,'EC','Ecuador','Ecuadorean'),(435,'EE','Estonia','Estonian'),(436,'EG','Egypt','Egyptian'),(437,'ER','Eritrea','Eritrean'),(438,'ES','Spain','Spanish'),(439,'ET','Ethiopia','Ethiopian'),(440,'FI','Finland','Finnish'),(441,'FJ','Fiji','Fijian'),(442,'FR','France','French'),(443,'GA','Gabon','Gabonese'),(444,'GD','Grenada','Grenadian'),(445,'GE','Georgia','Georgian'),(446,'GH','Ghana','Ghanaian'),(447,'GM','The Gambia','Gambian'),(448,'G','Guinea','Guinean'),(449,'GQ','Equatorial Guinea','Equatorial Guinean'),(450,'GT','Guatemala','Guatemalan'),(451,'GW','Guinea-Bissau','Guinea-Bissauan'),(452,'GY','Guyana','Guyanese'),(453,'HK','Hong Kong','Hong Kong'),(454,'H','Honduras','Honduran'),(455,'HR','Croatia','Croatian'),(456,'HT','Haiti','Haitian'),(457,'HU','Hungary','Hungarian'),(458,'ID','Indonesia','Indonesian'),(459,'IE','Ireland','Irish'),(460,'IL','Israel','Israeli'),(461,'I','India','Indian'),(462,'IQ','Iraq','Iraqi'),(463,'IR','Iran','Iranian'),(464,'IS','Iceland','Icelander'),(465,'IT','Italy','Italian'),(466,'JM','Jamaica','Jamaican'),(467,'JO','Jordan','Jordanian'),(468,'JP','Japan','Japanese'),(469,'KE','Kenya','Kenyan'),(470,'KG','Kyrgyz Republic','Kirghiz'),(471,'KH','Cambodia','Cambodian'),(472,'KI','Kiribati','I-Kiribati'),(473,'KM','Comoros','Comoran'),(474,'K','Saint Kitts and Nevis','Kittian and Nevisian'),(475,'KP','Korea, North','North Korean'),(476,'KR','Korea, South','South Korean'),(477,'KW','Kuwait','Kuwaiti'),(478,'KY','Central African Republic','Central African'),(479,'KZ','Kazakhstan','Kazakhstani'),(480,'LA','Laos','Laotian'),(481,'LB','Lebanon','Lebanese'),(482,'LC','Saint Lucia','Saint Lucian'),(483,'LI','Liechtenstein','Liechtensteiner'),(484,'LK','Sri Lanka','Sri Lankan'),(485,'LR','Liberia','Liberian'),(486,'LS','Lesotho','Mosotho'),(487,'LT','Lithuania','Lithuanian'),(488,'LU','Luxembourg','Luxembourger'),(489,'LV','Latvia','Latvian'),(490,'LY','Libya','Libyan'),(491,'MA','Morocco','Moroccan'),(492,'MC','Monaco','Monegasque'),(493,'MD','Moldova','Moldovan'),(494,'MG','Madagascar','Malagasy'),(495,'MH','Marshall Islands','Marshallese'),(496,'MI','Federated States of Micronesia','Micronesian'),(497,'MK','Macedonia','Macedonian'),(498,'ML','Mali','Malian'),(499,'MM','Myanmar (\',Burma)','Burmese'),(500,'MR','Mauritania','Mauritanian'),(501,'MT','Malta','Maltese'),(502,'MU','Mauritius','Mauritian'),(503,'MV','Maldives','Maldivan'),(504,'MW','Malawi','Malawian'),(505,'MX','Mexico','Mexican'),(506,'MY','Malaysia','Malaysian'),(507,'MZ','Mozambique','Mozambican'),(508,'NA','Namibia','Namibian'),(509,'NE','Niger','Nigerien'),(510,'NG','Nigeria','Nigerian'),(511,'NI','Nicaragua','Nicaraguan'),(512,'NL','Netherlands','Dutch'),(513,'NO','Norway','Norwegian'),(514,'NP','Nepal','Nepalese'),(515,'NR','Nauru','Nauruan'),(516,'NZ','New Zealand','New Zealander'),(517,'OM','Oman','Omani'),(518,'PA','Panama','Panamanian'),(519,'PE','Peru','Peruvian'),(520,'PG','Papua New Guinea','Papua New Guinean'),(521,'PH','Philippines','Filipino'),(522,'PK','Pakistan','Pakistani'),(523,'PL','Poland','Polish'),(524,'PT','Portugal','Portuguese'),(525,'PW','Palau','Palauan'),(526,'PY','Paraguay','Paraguayan'),(527,'QA','Qatar','Qatari'),(528,'RO','Romania','Romanian'),(529,'RS','Serbia and Montenegro','Serbian'),(530,'RU','Russia','Russian'),(531,'RW','Rwanda','Rwandan'),(532,'SA','Saudi Arabia','Saudi Arabian'),(533,'SB','Solomon Islands','Solomon Islander'),(534,'SC','Seychelles','Seychellois'),(535,'SD','Sudan','Sudanese'),(536,'SE','Sweden','Swedish'),(537,'SG','Singapore','Singaporean'),(538,'SI','Slovenia','Slovene'),(539,'SK','Slovakia','Slovak'),(540,'SL','Sierra Leone','Sierra Leonean'),(541,'SM','San Marino','Sammarinese'),(542,'S','Senegal','Senegalese'),(543,'SO','Somalia','Somali'),(544,'SR','Suriname','Surinamer'),(545,'ST','Sao Tome and Principe','Sao Tomean'),(546,'SV','El Salvador','Salvadoran'),(547,'SY','Syria','Syrian'),(548,'SZ','Swaziland','Swazi'),(549,'TD','Chad','Chadian'),(550,'TG','Togo','Togolese'),(551,'TH','Thailand','Thai'),(552,'TJ','Tajikistan','Tadzhik'),(553,'TL','East Timor','East Timorese'),(554,'TM','Turkmenistan','Turkmen'),(555,'T','Tunisia','Tunisian'),(556,'TO','Tonga','Tongan'),(557,'TR','Turkey','Turkish'),(558,'TT','Trinidad and Tobago','Trinidadian'),(559,'TV','Tuvalu','Tuvaluan'),(560,'TW','Taiwan','Taiwanese'),(561,'TZ','Tanzania','Tanzanian'),(562,'UA','Ukraine','Ukrainian'),(563,'UG','Uganda','Ugandan'),(564,'UK','United Kingdom','British'),(565,'US','United States','American'),(566,'UY','Uruguay','Uruguayan'),(567,'UZ','Uzbekistan','Uzbekistani'),(568,'VA','Vatican City (\',Holy See)','none'),(569,'VE','Venezuela','Venezuelan'),(570,'VH','Chile','Chilean'),(571,'V','Vietnam','Vietnamese'),(572,'VU','Vanuatu','Ni-Vanuatu'),(573,'WS','Samoa','Samoan'),(574,'YE','Yemen','Yemeni'),(575,'ZA','South Africa','South African'),(576,'ZM','Zambia','Zambian'),(577,'ZW','Zimbabwe','Zimbabwean');
/*!40000 ALTER TABLE `nationalities` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_type`
--

DROP TABLE IF EXISTS `user_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_type` (
  `user_type_id` int NOT NULL AUTO_INCREMENT,
  `user_type_name` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`user_type_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_type`
--

LOCK TABLES `user_type` WRITE;
/*!40000 ALTER TABLE `user_type` DISABLE KEYS */;
INSERT INTO `user_type` VALUES (1,'Admin'),(2,'Customer');
/*!40000 ALTER TABLE `user_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `user_id` int NOT NULL AUTO_INCREMENT,
  `first_name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `last_name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `email` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `phone_no` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `gender` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `dob` date NOT NULL,
  `nationality_id` int NOT NULL,
  `user_type_id` int NOT NULL,
  PRIMARY KEY (`user_id`),
  KEY `fk_nationality_id_idx` (`nationality_id`),
  KEY `fk_user_type_id_idx` (`user_type_id`),
  CONSTRAINT `fk_nationality_id` FOREIGN KEY (`nationality_id`) REFERENCES `nationalities` (`nationality_id`),
  CONSTRAINT `fk_user_type_id` FOREIGN KEY (`user_type_id`) REFERENCES `user_type` (`user_type_id`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (27,'Aduramomi','Oke','aduraoke@gmailcom',' 2348087992989','Male','2022-03-25',401,1);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-03-05 10:01:33
