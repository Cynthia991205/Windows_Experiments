-- MySQL dump 10.13  Distrib 5.7.12, for Win64 (x86_64)
--
-- Host: localhost    Database: commerce
-- ------------------------------------------------------
-- Server version	5.7.16-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Customer`
--

DROP TABLE IF EXISTS `Customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Customer` (
  `CustomerName` char(10) NOT NULL,
  `CustomerID` char(4) NOT NULL,
  `Address` char(20) NOT NULL,
  `PhoneNumber` char(12) NOT NULL,
  `EmailAddress` char(30) NOT NULL,
  PRIMARY KEY (`CustomerName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Customer`
--

LOCK TABLES `Customer` WRITE;
/*!40000 ALTER TABLE `Customer` DISABLE KEYS */;
INSERT INTO `Customer` VALUES ('吴九','0009','琴台大道十二号','7345628','wujiu@gmail.com'),('周八','0008','中南路一二七号','5489732','zhouba@yahoo.com'),('孙七','0007','硚口路八十二号','6589742','sunqi@sina.com'),('张三','0003','八一路二十五号','5672374','zhangsan@qq.com'),('李四','0004','江汉路五十八号','7897562','lisi@sina.com'),('王五','0005','武昌路十号','7354698','wangwu@163.com'),('赵六','0006','雄楚大道七号','1345697','zhaoliu@126.com'),('郑十','0010','龟山南路二十一号','5146987','zhengshi@qq.com'),('陈二','0002','武珞路十七号','3310842','chener@126.com');
/*!40000 ALTER TABLE `Customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ordering`
--

DROP TABLE IF EXISTS `Ordering`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Ordering` (
  `OrderID` char(3) NOT NULL,
  `CustomerName` char(10) NOT NULL,
  `ProductName` char(10) NOT NULL,
  `OrderTime` date NOT NULL,
  `OrderAmount` int(11) NOT NULL,
  PRIMARY KEY (`OrderID`),
  KEY `CustomerName` (`CustomerName`),
  KEY `ProductName` (`ProductName`),
  CONSTRAINT `ordering_ibfk_1` FOREIGN KEY (`CustomerName`) REFERENCES `Customer` (`CustomerName`) ON DELETE CASCADE,
  CONSTRAINT `ordering_ibfk_2` FOREIGN KEY (`ProductName`) REFERENCES `Product` (`ProductName`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ordering`
--

LOCK TABLES `Ordering` WRITE;
/*!40000 ALTER TABLE `Ordering` DISABLE KEYS */;
INSERT INTO `Ordering` VALUES ('003','张三','苹果手机','2017-11-11',5000),('004','李四','小米手机','2017-11-01',1500),('006','赵六','华为手机','2017-10-30',7200),('007','孙七','VIVO手机','2017-11-11',1800),('008','周八','小米手机','2017-11-06',5300),('009','吴九','华为手机','2017-11-11',2800),('010','郑十','VIVO手机','2017-11-24',9100);
/*!40000 ALTER TABLE `Ordering` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Product`
--

DROP TABLE IF EXISTS `Product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Product` (
  `ProductName` char(10) NOT NULL,
  `ProductID` char(3) NOT NULL,
  `Factory` char(20) NOT NULL,
  `ModelNumber` char(30) NOT NULL,
  `Price` double NOT NULL,
  PRIMARY KEY (`ProductName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Product`
--

LOCK TABLES `Product` WRITE;
/*!40000 ALTER TABLE `Product` DISABLE KEYS */;
INSERT INTO `Product` VALUES ('VIVO手机','006','苏州工厂','X20',2998),('中兴手机','007','深圳工厂','Blade V8',1199),('华为手机','001','东莞工厂','Mate10',3899),('小米手机','003','青岛工厂','小米6',2499),('苹果手机','002','高雄工厂','IPhone8',4898);
/*!40000 ALTER TABLE `Product` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-11-18  9:40:45
