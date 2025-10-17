-- MySQL dump 10.13  Distrib 8.0.43, for Win64 (x86_64)
--
-- Host: localhost    Database: quiz
-- ------------------------------------------------------
-- Server version	9.4.0

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
-- Table structure for table `perguntas`
--

DROP TABLE IF EXISTS `perguntas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `perguntas` (
  `PerguntasID` int NOT NULL AUTO_INCREMENT,
  `Pergunta` varchar(300) DEFAULT NULL,
  `opA` varchar(300) DEFAULT NULL,
  `opB` varchar(300) DEFAULT NULL,
  `opC` varchar(300) DEFAULT NULL,
  `opD` varchar(300) DEFAULT NULL,
  `respostaCorreta` varchar(300) DEFAULT NULL,
  PRIMARY KEY (`PerguntasID`)
) ENGINE=InnoDB AUTO_INCREMENT=40 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `perguntas`
--

LOCK TABLES `perguntas` WRITE;
/*!40000 ALTER TABLE `perguntas` DISABLE KEYS */;
INSERT INTO `perguntas` VALUES (1,'Qual o maior oceano do mundo? ',' Atlântico ',' Ártico ','Pacífico','Índico','C'),(2,'Quem foi o primero presidente do Brasil? ',' Dom Pedro II ',' Getúlio Vargas','Juscelino Kubitschek','Marechal Deodoro da Fonseca ','D'),(3,'Em que ano terminou a Segunda Guerra Mundial? ',' 1945 ',' 1943 ',' 1944 ',' 1946 ','A'),(4,'Em que continente fica o Egito? ',' Ásia ',' Europa ',' Africa ',' América ','C'),(5,'Qual o menor país do mundo? ',' Mônaco ',' Vaticano ',' Luxemburgo ',' San Marino ','B'),(6,'Quem foi o primeiro homem a pisar na Lua? ',' Yuri Gagarin ',' Buzz Aldrin ',' Alan Shepard',' Neil Armstrong ','D'),(7,'Qual o animal é símbolo da sabedoria ? ',' Raposa ',' Cão',' Coruja',' Leão','C'),(8,'Em que ano ocorreu a Revolução Francesa ? ',' 1789 ',' 1804',' 1776',' 1815','A'),(9,'O que significa a sigla ? \'ONU\' ',' Ordem das Nações Unidas ',' Organização das Nações Unidas',' Organização Nacional Unida',' Operação das Nações Unidas','B'),(10,'Em qual país se localiza o vulcão Krakatoa ?  ',' Chile ',' Japão',' Filipinas',' Indonésia','D'),(11,'Qual é o símbolo químico do ouro ?  ',' Au ',' Ag',' Go',' Or','A'),(12,'Quantas cordas tem um violão comum ?  ','7 ',' 5',' 6 ','12 ','C'),(13,'Qual a moeda oficial do Japão ?  ',' Dólar',' Yen',' Real ',' Won','B'),(14,'Quantas casa tem um tabuleiro de Xadrez ',' 49',' 100',' 64 ',' 81','C'),(15,'Qual o país tem a maior reserva de petróleo do mundo  ',' Venezuela',' Rússia',' Arábia Saudita',' Irã','A'),(16,' Qual é o idioma ofial da Argentina',' Italiano',' Francês',' Português',' Espanhol','D'),(17,' Quantos continentes existem ',' 3',' 9',' 6',' 7','D'),(18,' Qual desses é um super-herói da Marvel?',' Superman',' Batman',' Homem de Ferro',' Flash','C'),(19,' Qual a capital da França?',' Paris',' Roma',' Berlim',' Londres','A'),(20,' Quem canta a música Shape of You? ',' Harry Styles',' Justin Bieber',' Ed Sheeran',' Shawn Mendes','C'),(21,' Quem foi a primeira pessoa a viaja no Espaço?',' Yuri Garin','A cadela Laika ',' Neil Armstrong',' Marcus Portes',' A'),(22,' De onde é a invenção do chuveiro elétrico',' França','Inglaterra ',' Brasil',' Marcus PortesItália',' C'),(23,' Um anél tem 3 pedras preciosas.Quantos preciosas tem 11 anéis?','33','110 ',' 333',' 30',' A'),(24,' Qual é o maior Planeta do Sistema Solar?','Marte','Saturno ',' Terra',' Júpter',' D'),(25,' Qual o metal cujo símbolo químico é o Au?','Cobre','Prata ',' Mercúrio',' Ouro',' D'),(26,' As pessoas de qual tipo sanguíneo são consideradas doadores universais?','Tipo A','Tipo B',' Tipo O',' Tipo AB',' C'),(27,' Qual o maior animal terrestre?','Baleia Azul','Dinossauro','Elefante africano',' Tubarão Branco',' C'),(28,' Qual grande evento histórico aconteceu em 1822 no Brasil?','Descobrimento do Brasil','Ditadura Militar','Revolução de 1930',' Independência do Brasil',' D'),(29,' Em que ano foi usado um celular pela primeira vez no Brasil?','1900','1990','1890',' 2000',' D'),(30,' Qual o plural de chapéu?','Chapéis','Chapéus','Chapéuzes',' Chapuzes',' B'),(31,' Barack Obama foi o presidente de que país?','Estados Unidos da América','Inglaterra','Alemanha',' Rússia',' A'),(32,' O que é um tsunami?','Um ciclone','Um tornado','Um maremoto',' Um terremoto',' C'),(33,' Quantas casas decimais tem o número pi?','Duas','Centenas','Infinitas',' vinte',' C'),(34,' Quais as duas datas que são comemoradas em novembro no Brasil?','Independência do Brasil e Dia da Bandeira','Proclamação da República e Dia Nacional da Consciência Negra','Dia do Médico e Dia de São Lucas',' Dia de Finados e Dia Nacional do Livro',' B'),(35,' Quanto tempo a luz do Sol demora para chegar à Terra?','300 000 000 metros por segundo','150 000 000 metros por segundo','199 792 458 metros por segundo',' 299 792 458 metros por segundo',' D'),(36,' Quais destas doênças são sexualmente transmissíveis?','Aids, Tricomoníase e ebola','Chikunguya , Aids ,e Herpes genital',' Gonorréia, Clamídia e Sífilis',' Botulismo , Cistite e Gonorréia',' C'),(37,' Qual desses países é transcontinental?','Rússia','Filipinas',' Marrocus',' Groenlândia',' A'),(38,' Quais os nomes dos três Reis Magos?','Gaspar, Nicolau e Natanael','Belchior, Gaspar e Baltazar',' Belchior, Gaspar e Nataniel',' Gabriel Benjamim e Melchior',' B'),(39,' Quais são os cromossomos que determinam o sexo masculino?','Os V','Os X',' Os Y',' Os W',' C');
/*!40000 ALTER TABLE `perguntas` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-10-16 21:50:13
