-- MySQL dump 10.13  Distrib 5.7.12, for Win64 (x86_64)
--
-- Host: localhost    Database: spreadrecon
-- ------------------------------------------------------
-- Server version	5.7.14

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
-- Table structure for table `PESSOA`
--

DROP TABLE IF EXISTS `PESSOA`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `PESSOA` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `PESSOA`
--

LOCK TABLES `PESSOA` WRITE;
/*!40000 ALTER TABLE `PESSOA` DISABLE KEYS */;
INSERT INTO `PESSOA` VALUES (1,'teste'),(2,'Truta'),(5,'teste 14/12/2016.');
/*!40000 ALTER TABLE `PESSOA` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `REL_EXIBIRTERMINAISACHADOS`
--

DROP TABLE IF EXISTS `REL_EXIBIRTERMINAISACHADOS`;
/*!50001 DROP VIEW IF EXISTS `REL_EXIBIRTERMINAISACHADOS`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `REL_EXIBIRTERMINAISACHADOS` AS SELECT 
 1 AS `id`,
 1 AS `ciclo`,
 1 AS `descricao`,
 1 AS `dataEvento`,
 1 AS `telefone`,
 1 AS `valorPago`,
 1 AS `idStatus`,
 1 AS `nomeStatus`,
 1 AS `idImportacaoPlanilha`,
 1 AS `idLoja`,
 1 AS `nomeLoja`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `REL_EXIBIRTERMINAISACHADOS_TOTAL`
--

DROP TABLE IF EXISTS `REL_EXIBIRTERMINAISACHADOS_TOTAL`;
/*!50001 DROP VIEW IF EXISTS `REL_EXIBIRTERMINAISACHADOS_TOTAL`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `REL_EXIBIRTERMINAISACHADOS_TOTAL` AS SELECT 
 1 AS `ciclo`,
 1 AS `telefone`,
 1 AS `total`,
 1 AS `idStatus`,
 1 AS `nomeStatus`,
 1 AS `idImportacaoPlanilha`,
 1 AS `idLoja`,
 1 AS `nomeLoja`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `REL_EXIBIRTERMINAISPAGOSSEMVENDA`
--

DROP TABLE IF EXISTS `REL_EXIBIRTERMINAISPAGOSSEMVENDA`;
/*!50001 DROP VIEW IF EXISTS `REL_EXIBIRTERMINAISPAGOSSEMVENDA`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `REL_EXIBIRTERMINAISPAGOSSEMVENDA` AS SELECT 
 1 AS `id`,
 1 AS `ciclo`,
 1 AS `descricao`,
 1 AS `dataEvento`,
 1 AS `telefone`,
 1 AS `valorPago`,
 1 AS `idStatus`,
 1 AS `nomeStatus`,
 1 AS `idImportacaoPlanilha`,
 1 AS `idLoja`,
 1 AS `nomeLoja`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `REL_EXIBIRTERMINAISPAGOSSEMVENDA_TOTAL`
--

DROP TABLE IF EXISTS `REL_EXIBIRTERMINAISPAGOSSEMVENDA_TOTAL`;
/*!50001 DROP VIEW IF EXISTS `REL_EXIBIRTERMINAISPAGOSSEMVENDA_TOTAL`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `REL_EXIBIRTERMINAISPAGOSSEMVENDA_TOTAL` AS SELECT 
 1 AS `ciclo`,
 1 AS `telefone`,
 1 AS `total`,
 1 AS `idStatus`,
 1 AS `nomeStatus`,
 1 AS `idImportacaoPlanilha`,
 1 AS `idLoja`,
 1 AS `nomeLoja`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `REL_GERARCONCILIADOS_PAGAMENTOOPERADORA`
--

DROP TABLE IF EXISTS `REL_GERARCONCILIADOS_PAGAMENTOOPERADORA`;
/*!50001 DROP VIEW IF EXISTS `REL_GERARCONCILIADOS_PAGAMENTOOPERADORA`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `REL_GERARCONCILIADOS_PAGAMENTOOPERADORA` AS SELECT 
 1 AS `id`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `REL_GERARCONCILIADOS_VENDASVIVA`
--

DROP TABLE IF EXISTS `REL_GERARCONCILIADOS_VENDASVIVA`;
/*!50001 DROP VIEW IF EXISTS `REL_GERARCONCILIADOS_VENDASVIVA`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `REL_GERARCONCILIADOS_VENDASVIVA` AS SELECT 
 1 AS `id`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `REL_GERARESULTADOPROCESSAMENTO`
--

DROP TABLE IF EXISTS `REL_GERARESULTADOPROCESSAMENTO`;
/*!50001 DROP VIEW IF EXISTS `REL_GERARESULTADOPROCESSAMENTO`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `REL_GERARESULTADOPROCESSAMENTO` AS SELECT 
 1 AS `idImportacaoPlanilhaVendasViva`,
 1 AS `idVendasViva`,
 1 AS `idImportacaoPlanilhaPagamentoOperadora`,
 1 AS `idPagamentoOperadora`,
 1 AS `dataResultadoProcessamento`,
 1 AS `idStatus`,
 1 AS `nomeCicloPagamento`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `REL_GERARNAOCONCILIADOS_PAGAMENTOOPERADORA`
--

DROP TABLE IF EXISTS `REL_GERARNAOCONCILIADOS_PAGAMENTOOPERADORA`;
/*!50001 DROP VIEW IF EXISTS `REL_GERARNAOCONCILIADOS_PAGAMENTOOPERADORA`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `REL_GERARNAOCONCILIADOS_PAGAMENTOOPERADORA` AS SELECT 
 1 AS `id`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `REL_GERARNAOCONCILIADOS_VENDASVIVA`
--

DROP TABLE IF EXISTS `REL_GERARNAOCONCILIADOS_VENDASVIVA`;
/*!50001 DROP VIEW IF EXISTS `REL_GERARNAOCONCILIADOS_VENDASVIVA`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `REL_GERARNAOCONCILIADOS_VENDASVIVA` AS SELECT 
 1 AS `id`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `REL_GERARPAGAMENTOSCONCILIADOS`
--

DROP TABLE IF EXISTS `REL_GERARPAGAMENTOSCONCILIADOS`;
/*!50001 DROP VIEW IF EXISTS `REL_GERARPAGAMENTOSCONCILIADOS`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `REL_GERARPAGAMENTOSCONCILIADOS` AS SELECT 
 1 AS `id`,
 1 AS `nomeCicloPagamento`,
 1 AS `idImportacaoPlanilhaVendasViva`,
 1 AS `nomeArquivoOriginalVendasViva`,
 1 AS `totalVendasViva`,
 1 AS `idImportacaoPlanilhaPagamentoOperadora`,
 1 AS `nomeArquivoOriginalPagamentoOperadora`,
 1 AS `totalPagamentoOperadora`,
 1 AS `dataResultadoProcessamento`,
 1 AS `idStatus`,
 1 AS `nomeStatus`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `TBD_PERFILUSUARIO`
--

DROP TABLE IF EXISTS `TBD_PERFILUSUARIO`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `TBD_PERFILUSUARIO` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nomePerfil` varchar(50) NOT NULL,
  `descricao` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `TBD_PERFILUSUARIO`
--

LOCK TABLES `TBD_PERFILUSUARIO` WRITE;
/*!40000 ALTER TABLE `TBD_PERFILUSUARIO` DISABLE KEYS */;
INSERT INTO `TBD_PERFILUSUARIO` VALUES (1,'STARK','Perfil que deve ter acesso a todas as funcionalidades da aplicacao e mais um pouco. STARK !!!'),(2,'ADMIN','Perfil que deve ter acesso a todas as funcionalidades da aplicacao.'),(3,'FRANQUEADO','Perfil que deve ter acesso as informacoes, importacoes e relatorios especificos da sua franquia.');
/*!40000 ALTER TABLE `TBD_PERFILUSUARIO` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `TBD_STATUS`
--

DROP TABLE IF EXISTS `TBD_STATUS`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `TBD_STATUS` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nomeStatus` varchar(50) NOT NULL,
  `descricao` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `UK_TBD_STATUS_Nome` (`nomeStatus`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `TBD_STATUS`
--

LOCK TABLES `TBD_STATUS` WRITE;
/*!40000 ALTER TABLE `TBD_STATUS` DISABLE KEYS */;
INSERT INTO `TBD_STATUS` VALUES (1,'IMPORTAÇÃO CONCLUÍDA','Status que determina se a importacao foi concluida'),(2,'IMPORTANDO','Status que determina se a importacao esta em andamento'),(3,'IMPORTAÇÃO CANCELADA','Status que determina se a importacao foi cancelada'),(4,'PENDENTE IMPORTAÇÃO','Status que determina que foi feito upload arquivo, e esta pendente de importação'),(5,'EM CONCILIAÇÃO','Status que determina se a conciliacao esta em processamento'),(6,'NÃO CONCILIADO','Status que determina se o registro nao foi conciliado, ou seja, nao encontrou correspondencia de pagamento pela operadora'),(7,'CONCILIADO','Status que determina se o registro foi conciliado, ou seja, encontrou correspondencia de pagamento pela operadora'),(8,'PENDENTE CONCILIAÇÃO','Status que determina que o registro foi importado mas ainda não passou pelo processo de conciliação');
/*!40000 ALTER TABLE `TBD_STATUS` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `TBD_TIPOPLANILHA`
--

DROP TABLE IF EXISTS `TBD_TIPOPLANILHA`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `TBD_TIPOPLANILHA` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nomeTipoPlanilha` varchar(50) NOT NULL,
  `descricao` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `UK_TBD_TIPOPLANILHA_Nome` (`nomeTipoPlanilha`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `TBD_TIPOPLANILHA`
--

LOCK TABLES `TBD_TIPOPLANILHA` WRITE;
/*!40000 ALTER TABLE `TBD_TIPOPLANILHA` DISABLE KEYS */;
INSERT INTO `TBD_TIPOPLANILHA` VALUES (1,'VENDAS VIVA','Planilha que representa a movimentacao de vendas por franquia.'),(2,'CICLO PAGAMENTO','Planilha que representa os pagamentos realizados pela operadora. Nessa planilha pode conter pagamentos de mais do que uma franquia.');
/*!40000 ALTER TABLE `TBD_TIPOPLANILHA` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `TBD_TIPORELATORIO`
--

DROP TABLE IF EXISTS `TBD_TIPORELATORIO`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `TBD_TIPORELATORIO` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nomeTipoRelatorio` varchar(50) NOT NULL,
  `versaoTipoRelatorio` int(11) NOT NULL,
  `descricao` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `UK_TBD_TIPORELATORIO_Nome` (`nomeTipoRelatorio`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `TBD_TIPORELATORIO`
--

LOCK TABLES `TBD_TIPORELATORIO` WRITE;
/*!40000 ALTER TABLE `TBD_TIPORELATORIO` DISABLE KEYS */;
INSERT INTO `TBD_TIPORELATORIO` VALUES (1,'Conciliação Geral',1,'Relatorio utilizado para listar de forma macro todos os registros que foram conciliados atraves da funcionalidade Conciliação de Pagamento'),(2,'Conciliação Analítico',1,'Relatorio utilizado para listar de forma analitica todos os registros que foram conciliados atraves da funcionalidade Conciliação de Pagamento, e os registros que nao tiveram pagamentos correspondentes'),(3,'Uso da Ferramenta',1,'Relatorio utilizado para visualizar o uso da ferramenta pelos usuarios cadastrados.');
/*!40000 ALTER TABLE `TBD_TIPORELATORIO` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `TBN_LOJA`
--

DROP TABLE IF EXISTS `TBN_LOJA`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `TBN_LOJA` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nomeLoja` varchar(50) NOT NULL,
  `numeroPDV` varchar(10) NOT NULL,
  `isAtivo` bit(1) NOT NULL,
  `numeroCNPJLoja` varchar(15) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `UK_TBN_LOJA_PDV` (`numeroPDV`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `TBN_LOJA`
--

LOCK TABLES `TBN_LOJA` WRITE;
/*!40000 ALTER TABLE `TBN_LOJA` DISABLE KEYS */;
INSERT INTO `TBN_LOJA` VALUES (1,'Loja Stark','0','\0','0'),(2,'Viva Marketing Direto','1037620','','23299339000136'),(3,'JGMIX GUARUJA','1038485','\0','24396290000100'),(5,'Loja Administradores','1','','0');
/*!40000 ALTER TABLE `TBN_LOJA` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `TBN_PAGAMENTOOPERADORA`
--

DROP TABLE IF EXISTS `TBN_PAGAMENTOOPERADORA`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `TBN_PAGAMENTOOPERADORA` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nomeCicloPagamento` varchar(100) NOT NULL,
  `tipoIncentivo` varchar(50) DEFAULT NULL,
  `tipoEvento` varchar(50) DEFAULT NULL,
  `descricao` varchar(150) DEFAULT NULL,
  `categoria` varchar(50) DEFAULT NULL,
  `numeroPDV` varchar(10) DEFAULT NULL,
  `nomePDV` varchar(150) DEFAULT NULL,
  `numeroSFIDPDVPagador` varchar(50) DEFAULT NULL,
  `nomePDVPagador` varchar(150) DEFAULT NULL,
  `dataEvento` date DEFAULT NULL,
  `dataAtivacao` date DEFAULT NULL,
  `dataDesativacao` date DEFAULT NULL,
  `dataDocumento` date DEFAULT NULL,
  `motivo` varchar(150) DEFAULT NULL,
  `numeroContrato` varchar(50) DEFAULT NULL,
  `numeroMSISDN` varchar(11) NOT NULL,
  `numeroIMEI` varchar(150) DEFAULT NULL,
  `numeroICCID` varchar(150) DEFAULT NULL,
  `nomeAparelho` varchar(100) DEFAULT NULL,
  `nomeCampanha` varchar(150) DEFAULT NULL,
  `nomeCampanhaAnterior` varchar(150) DEFAULT NULL,
  `nomeOferta` varchar(150) DEFAULT NULL,
  `numeroIDBundle` varchar(50) DEFAULT NULL,
  `nomeBundle` varchar(50) DEFAULT NULL,
  `dataBundle` date DEFAULT NULL,
  `nomeRelacionamento` varchar(150) DEFAULT NULL,
  `nomeRelacionamentoAnterior` varchar(150) DEFAULT NULL,
  `tipoOiTV` varchar(50) DEFAULT NULL,
  `isCliente` bit(1) DEFAULT NULL,
  `tipoMigracao` varchar(1) DEFAULT NULL,
  `nomePlanoEvento` varchar(50) DEFAULT NULL,
  `nomePlanoAnterior` varchar(50) DEFAULT NULL,
  `nomePlanoGrupo` varchar(50) DEFAULT NULL,
  `nomeGrupoPlanoContabil` varchar(50) DEFAULT NULL,
  `nomeServicoEvento` varchar(50) DEFAULT NULL,
  `nomeServicoAnterior` varchar(50) DEFAULT NULL,
  `nomeServicoGrupo` varchar(50) DEFAULT NULL,
  `nomeGrupoServicoContabil` varchar(50) DEFAULT NULL,
  `totalVoiceTerminal` varchar(25) DEFAULT NULL,
  `totalVoiceDias` varchar(5) DEFAULT NULL,
  `nomeCartaoCredito` varchar(50) DEFAULT NULL,
  `isPortabilidade` bit(1) DEFAULT NULL,
  `isOCT` bit(1) DEFAULT NULL,
  `quantidade` varchar(25) DEFAULT NULL,
  `tipoPex` varchar(25) DEFAULT NULL,
  `valor` decimal(10,2) DEFAULT NULL,
  `valorAnterior` decimal(10,2) DEFAULT NULL,
  `valorEvento` decimal(10,2) DEFAULT NULL,
  `valorCalculado` decimal(10,2) NOT NULL,
  `valorPago` decimal(10,2) DEFAULT NULL,
  `idImportacaoPlanilha` int(11) NOT NULL,
  `idStatus` int(11) DEFAULT '8',
  PRIMARY KEY (`id`),
  KEY `FK_TBN_PAGAMENTOOPERADORA_TBR_IMPORTACAOPLANILHA` (`idImportacaoPlanilha`),
  CONSTRAINT `FK_TBN_PAGAMENTOOPERADORA_TBR_IMPORTACAOPLANILHA` FOREIGN KEY (`idImportacaoPlanilha`) REFERENCES `TBR_IMPORTACAOPLANILHA` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5217 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `TBN_PAGAMENTOOPERADORA`
--

LOCK TABLES `TBN_PAGAMENTOOPERADORA` WRITE;
/*!40000 ALTER TABLE `TBN_PAGAMENTOOPERADORA` DISABLE KEYS */;
/*!40000 ALTER TABLE `TBN_PAGAMENTOOPERADORA` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `TBN_RESULTADOPROCESSAMENTO`
--

DROP TABLE IF EXISTS `TBN_RESULTADOPROCESSAMENTO`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `TBN_RESULTADOPROCESSAMENTO` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idImportacaoPlanilhaVendasViva` int(11) NOT NULL,
  `idVendasViva` int(11) NOT NULL,
  `idImportacaoPlanilhaPagamentoOperadora` int(11) NOT NULL,
  `idPagamentoOperadora` int(11) NOT NULL,
  `dataResultadoProcessamento` datetime DEFAULT NULL,
  `idStatus` int(11) NOT NULL,
  `nomeCicloPagamento` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `UK_TBN_RESULTADOPROCESSAMENTO` (`idImportacaoPlanilhaVendasViva`,`idVendasViva`,`idImportacaoPlanilhaPagamentoOperadora`,`idPagamentoOperadora`) USING BTREE,
  KEY `FK_TBN_RESULTADOPROCESSAMENTO_TBD_STATUS` (`idStatus`),
  KEY `FK_TBN_RESULTADOPROCESSAMENTO_TBR_IMPORTACAOPLANILHA_PAGOPE` (`idImportacaoPlanilhaPagamentoOperadora`),
  KEY `FK_TBN_RESULTADOPROCESSAMENTO_TBN_PAGAMENTOOPERADORA` (`idPagamentoOperadora`),
  KEY `IN_VENDASVIVA_PAGAMENTOOPERADORA` (`idVendasViva`,`idPagamentoOperadora`) USING BTREE,
  CONSTRAINT `FK_TBN_RESULTADOPROCESSAMENTO_TBD_STATUS` FOREIGN KEY (`idStatus`) REFERENCES `TBD_STATUS` (`id`),
  CONSTRAINT `FK_TBN_RESULTADOPROCESSAMENTO_TBN_PAGAMENTOOPERADORA` FOREIGN KEY (`idPagamentoOperadora`) REFERENCES `TBN_PAGAMENTOOPERADORA` (`id`) ON DELETE CASCADE,
  CONSTRAINT `FK_TBN_RESULTADOPROCESSAMENTO_TBN_VENDASVIVA` FOREIGN KEY (`idVendasViva`) REFERENCES `TBN_VENDASVIVA` (`id`) ON DELETE CASCADE,
  CONSTRAINT `FK_TBN_RESULTADOPROCESSAMENTO_TBR_IMPORTACAOPLANILHA_PAGOPE` FOREIGN KEY (`idImportacaoPlanilhaPagamentoOperadora`) REFERENCES `TBR_IMPORTACAOPLANILHA` (`id`) ON DELETE CASCADE,
  CONSTRAINT `FK_TBN_RESULTADOPROCESSAMENTO_TBR_IMPORTACAOPLANILHA_VENDASVIVA` FOREIGN KEY (`idImportacaoPlanilhaVendasViva`) REFERENCES `TBR_IMPORTACAOPLANILHA` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=1046 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `TBN_RESULTADOPROCESSAMENTO`
--

LOCK TABLES `TBN_RESULTADOPROCESSAMENTO` WRITE;
/*!40000 ALTER TABLE `TBN_RESULTADOPROCESSAMENTO` DISABLE KEYS */;
/*!40000 ALTER TABLE `TBN_RESULTADOPROCESSAMENTO` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `TBN_USUARIO`
--

DROP TABLE IF EXISTS `TBN_USUARIO`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `TBN_USUARIO` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(50) NOT NULL,
  `login` varchar(20) NOT NULL,
  `senha` varchar(10) NOT NULL,
  `dataUltimoLogin` datetime DEFAULT NULL,
  `idPerfilUsuario` int(11) NOT NULL,
  `isAtivo` bit(1) NOT NULL,
  `idLoja` int(11) NOT NULL,
  `email` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `UK_TBN_USUARIO_Login` (`login`),
  KEY `FK_TBN_USUARIO_TBD_PERFILUSUARIO` (`idPerfilUsuario`),
  KEY `FK_TBN_USUARIO_TBN_LOJA` (`idLoja`),
  CONSTRAINT `FK_TBN_USUARIO_TBD_PERFILUSUARIO` FOREIGN KEY (`idPerfilUsuario`) REFERENCES `TBD_PERFILUSUARIO` (`id`),
  CONSTRAINT `FK_TBN_USUARIO_TBN_LOJA` FOREIGN KEY (`idLoja`) REFERENCES `TBN_LOJA` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `TBN_USUARIO`
--

LOCK TABLES `TBN_USUARIO` WRITE;
/*!40000 ALTER TABLE `TBN_USUARIO` DISABLE KEYS */;
INSERT INTO `TBN_USUARIO` VALUES (1,'Charles Mendes','cmendes','senha','2017-01-31 04:03:56',1,'',1,'charles@starkdev.com.br'),(2,'Eduardo Mazzini','emazzini','senha',NULL,1,'',1,'eduardo@starkdev.com.br'),(3,'Viva marketing direto','viva','viva','2017-01-17 18:06:31',2,'',2,'alex@megafastshop.com.br'),(4,'JGMIX GUARUJA','JGMix','Lojaoi10','2017-01-17 00:30:24',3,'',3,'lojaoiguaruja@outlook.com'),(7,'Administrador','admin','admin','2017-01-17 00:29:58',2,'',5,'admin@spreadrecon.com.br'),(8,'stark_viva','stark_viva','123','2017-01-31 04:03:18',3,'',2,NULL),(9,'stark_guaruja','stark_guaruja','123','2017-01-31 03:48:46',3,'',3,NULL);
/*!40000 ALTER TABLE `TBN_USUARIO` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `TBN_VENDASVIVA`
--

DROP TABLE IF EXISTS `TBN_VENDASVIVA`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `TBN_VENDASVIVA` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `dataVenda` date NOT NULL,
  `numeroPDV` varchar(10) NOT NULL,
  `numeroLinha` varchar(11) NOT NULL,
  `nomeVendedor` varchar(50) DEFAULT NULL,
  `nomePlano` varchar(150) DEFAULT NULL,
  `nomePacoteDados` varchar(150) DEFAULT NULL,
  `nomeTipo` varchar(50) DEFAULT NULL,
  `nomeTitular` varchar(150) DEFAULT NULL,
  `nomeDependente` varchar(150) DEFAULT NULL,
  `dadosDependente` varchar(150) DEFAULT NULL,
  `numeroOs` varchar(50) DEFAULT NULL,
  `numeroICCD` varchar(50) DEFAULT NULL,
  `numeroContrato` varchar(50) DEFAULT NULL,
  `valorVenda` decimal(10,2) NOT NULL,
  `idImportacaoPlanilha` int(11) NOT NULL,
  `idStatus` int(11) NOT NULL DEFAULT '8',
  PRIMARY KEY (`id`),
  KEY `FK_TBN_VENDASVIVA_TBR_IMPORTACAOPLANILHA` (`idImportacaoPlanilha`),
  CONSTRAINT `FK_TBN_VENDASVIVA_TBR_IMPORTACAOPLANILHA` FOREIGN KEY (`idImportacaoPlanilha`) REFERENCES `TBR_IMPORTACAOPLANILHA` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3266 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `TBN_VENDASVIVA`
--

LOCK TABLES `TBN_VENDASVIVA` WRITE;
/*!40000 ALTER TABLE `TBN_VENDASVIVA` DISABLE KEYS */;
/*!40000 ALTER TABLE `TBN_VENDASVIVA` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `TBR_IMPORTACAOPLANILHA`
--

DROP TABLE IF EXISTS `TBR_IMPORTACAOPLANILHA`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `TBR_IMPORTACAOPLANILHA` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idTipoPlanilha` int(11) NOT NULL,
  `idUsuarioImportacao` int(11) NOT NULL,
  `dataInicioProcessamento` datetime NOT NULL,
  `dataFimProcessamento` datetime DEFAULT NULL,
  `idStatus` int(11) NOT NULL,
  `qtdImportacaoSucesso` int(11) DEFAULT NULL,
  `qtdImportacaoIgnorada` int(11) DEFAULT NULL,
  `nomeArquivoOriginal` varchar(100) DEFAULT NULL,
  `nomeArquivoProcessado` varchar(100) DEFAULT NULL,
  `nomeArquivoErro` varchar(100) DEFAULT NULL,
  `idLoja` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_TBR_IMPORTACAOPLANILHA_TBD_TIPOPLANILHA` (`idTipoPlanilha`),
  KEY `FK_TBR_IMPORTACAOPLANILHA_TBN_USUARIO` (`idUsuarioImportacao`),
  KEY `FK_TBR_IMPORTACAOPLANILHA_TBD_STATUS` (`idStatus`),
  KEY `FK_TBR_IMPORTACAOPLANILHA_TBN_LOJA_idx` (`idLoja`),
  KEY `FK_TBR_IMPORTACAOPLANILHA_TBN_LOJA` (`idLoja`),
  CONSTRAINT `FK_TBR_IMPORTACAOPLANILHA_TBD_STATUS` FOREIGN KEY (`idStatus`) REFERENCES `TBD_STATUS` (`id`),
  CONSTRAINT `FK_TBR_IMPORTACAOPLANILHA_TBD_TIPOPLANILHA` FOREIGN KEY (`idTipoPlanilha`) REFERENCES `TBD_TIPOPLANILHA` (`id`),
  CONSTRAINT `FK_TBR_IMPORTACAOPLANILHA_TBN_LOJA` FOREIGN KEY (`idLoja`) REFERENCES `TBN_LOJA` (`id`),
  CONSTRAINT `FK_TBR_IMPORTACAOPLANILHA_TBN_USUARIO` FOREIGN KEY (`idUsuarioImportacao`) REFERENCES `TBN_USUARIO` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=38 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `TBR_IMPORTACAOPLANILHA`
--

LOCK TABLES `TBR_IMPORTACAOPLANILHA` WRITE;
/*!40000 ALTER TABLE `TBR_IMPORTACAOPLANILHA` DISABLE KEYS */;
/*!40000 ALTER TABLE `TBR_IMPORTACAOPLANILHA` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `TBR_PERFILUSUARIOTIPORELATORIO`
--

DROP TABLE IF EXISTS `TBR_PERFILUSUARIOTIPORELATORIO`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `TBR_PERFILUSUARIOTIPORELATORIO` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idPerfilUsuario` int(11) NOT NULL,
  `idTipoRelatorio` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_TBR_PERFILUSUARIOTIPORELATORIO_TBD_PERFILUSUARIO` (`idPerfilUsuario`),
  KEY `FK_TBR_PERFILUSUARIOTIPORELATORIO_TBD_TIPORELATORIO` (`idTipoRelatorio`),
  CONSTRAINT `FK_TBR_PERFILUSUARIOTIPORELATORIO_TBD_PERFILUSUARIO` FOREIGN KEY (`idPerfilUsuario`) REFERENCES `TBD_PERFILUSUARIO` (`id`),
  CONSTRAINT `FK_TBR_PERFILUSUARIOTIPORELATORIO_TBD_TIPORELATORIO` FOREIGN KEY (`idTipoRelatorio`) REFERENCES `TBD_TIPORELATORIO` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `TBR_PERFILUSUARIOTIPORELATORIO`
--

LOCK TABLES `TBR_PERFILUSUARIOTIPORELATORIO` WRITE;
/*!40000 ALTER TABLE `TBR_PERFILUSUARIOTIPORELATORIO` DISABLE KEYS */;
INSERT INTO `TBR_PERFILUSUARIOTIPORELATORIO` VALUES (1,1,1),(2,1,2),(3,1,3),(4,2,1),(5,2,2),(6,2,3),(7,3,1);
/*!40000 ALTER TABLE `TBR_PERFILUSUARIOTIPORELATORIO` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'spreadrecon'
--
/*!50003 DROP PROCEDURE IF EXISTS `ZerarBase` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`sd_spreadrecon`@`%` PROCEDURE `ZerarBase`()
BEGIN
	DELETE FROM TBN_RESULTADOPROCESSAMENTO;
	DELETE FROM TBN_VENDASVIVA;
	DELETE FROM TBN_PAGAMENTOOPERADORA;
	DELETE FROM TBR_IMPORTACAOPLANILHA;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Final view structure for view `REL_EXIBIRTERMINAISACHADOS`
--

/*!50001 DROP VIEW IF EXISTS `REL_EXIBIRTERMINAISACHADOS`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`sd_spreadrecon`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `REL_EXIBIRTERMINAISACHADOS` AS select `p`.`id` AS `id`,`p`.`nomeCicloPagamento` AS `ciclo`,`p`.`descricao` AS `descricao`,`p`.`dataEvento` AS `dataEvento`,`p`.`numeroMSISDN` AS `telefone`,`p`.`valorPago` AS `valorPago`,`p`.`idStatus` AS `idStatus`,`s`.`nomeStatus` AS `nomeStatus`,`p`.`idImportacaoPlanilha` AS `idImportacaoPlanilha`,`i`.`idLoja` AS `idLoja`,`l`.`nomeLoja` AS `nomeLoja` from (((`TBN_PAGAMENTOOPERADORA` `p` join `TBD_STATUS` `s` on((`p`.`idStatus` = `s`.`id`))) join `TBR_IMPORTACAOPLANILHA` `i` on((`p`.`idImportacaoPlanilha` = `i`.`id`))) join `TBN_LOJA` `l` on((`i`.`idLoja` = `l`.`id`))) where `p`.`id` in (select distinct `TBN_RESULTADOPROCESSAMENTO`.`idPagamentoOperadora` from `TBN_RESULTADOPROCESSAMENTO`) order by `p`.`nomeCicloPagamento`,`p`.`numeroMSISDN`,`p`.`dataEvento`,`p`.`id` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `REL_EXIBIRTERMINAISACHADOS_TOTAL`
--

/*!50001 DROP VIEW IF EXISTS `REL_EXIBIRTERMINAISACHADOS_TOTAL`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`sd_spreadrecon`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `REL_EXIBIRTERMINAISACHADOS_TOTAL` AS select `r`.`ciclo` AS `ciclo`,`r`.`telefone` AS `telefone`,sum(`r`.`valorPago`) AS `total`,`r`.`idStatus` AS `idStatus`,`s`.`nomeStatus` AS `nomeStatus`,`r`.`idImportacaoPlanilha` AS `idImportacaoPlanilha`,`r`.`idLoja` AS `idLoja`,`r`.`nomeLoja` AS `nomeLoja` from (`REL_EXIBIRTERMINAISACHADOS` `r` join `TBD_STATUS` `s` on((`r`.`idStatus` = `s`.`id`))) group by `r`.`idLoja`,`r`.`telefone` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `REL_EXIBIRTERMINAISPAGOSSEMVENDA`
--

/*!50001 DROP VIEW IF EXISTS `REL_EXIBIRTERMINAISPAGOSSEMVENDA`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`sd_spreadrecon`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `REL_EXIBIRTERMINAISPAGOSSEMVENDA` AS select `p`.`id` AS `id`,`p`.`nomeCicloPagamento` AS `ciclo`,`p`.`descricao` AS `descricao`,`p`.`dataEvento` AS `dataEvento`,`p`.`numeroMSISDN` AS `telefone`,`p`.`valorPago` AS `valorPago`,`p`.`idStatus` AS `idStatus`,`s`.`nomeStatus` AS `nomeStatus`,`p`.`idImportacaoPlanilha` AS `idImportacaoPlanilha`,`i`.`idLoja` AS `idLoja`,`l`.`nomeLoja` AS `nomeLoja` from (((`TBN_PAGAMENTOOPERADORA` `p` join `TBD_STATUS` `s` on((`p`.`idStatus` = `s`.`id`))) join `TBR_IMPORTACAOPLANILHA` `i` on((`p`.`idImportacaoPlanilha` = `i`.`id`))) join `TBN_LOJA` `l` on((`i`.`idLoja` = `l`.`id`))) where (`p`.`idStatus` = 6) order by `p`.`nomeCicloPagamento`,`p`.`numeroMSISDN`,`p`.`dataEvento`,`p`.`id` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `REL_EXIBIRTERMINAISPAGOSSEMVENDA_TOTAL`
--

/*!50001 DROP VIEW IF EXISTS `REL_EXIBIRTERMINAISPAGOSSEMVENDA_TOTAL`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`sd_spreadrecon`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `REL_EXIBIRTERMINAISPAGOSSEMVENDA_TOTAL` AS select `r`.`ciclo` AS `ciclo`,`r`.`telefone` AS `telefone`,sum(`r`.`valorPago`) AS `total`,`r`.`idStatus` AS `idStatus`,`s`.`nomeStatus` AS `nomeStatus`,`r`.`idImportacaoPlanilha` AS `idImportacaoPlanilha`,`r`.`idLoja` AS `idLoja`,`r`.`nomeLoja` AS `nomeLoja` from (`REL_EXIBIRTERMINAISPAGOSSEMVENDA` `r` join `TBD_STATUS` `s` on((`r`.`idStatus` = `s`.`id`))) group by `r`.`idLoja`,`r`.`telefone` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `REL_GERARCONCILIADOS_PAGAMENTOOPERADORA`
--

/*!50001 DROP VIEW IF EXISTS `REL_GERARCONCILIADOS_PAGAMENTOOPERADORA`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_unicode_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`sd_spreadrecon`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `REL_GERARCONCILIADOS_PAGAMENTOOPERADORA` AS select distinct `p`.`id` AS `id` from (`TBN_PAGAMENTOOPERADORA` `p` join `TBR_IMPORTACAOPLANILHA` `ip` on(((`ip`.`id` = `p`.`idImportacaoPlanilha`) and (`ip`.`idStatus` = 5) and (`p`.`idStatus` = 8)))) where `p`.`id` in (select distinct `r`.`idPagamentoOperadora` from `TBN_RESULTADOPROCESSAMENTO` `r`) order by `p`.`id` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `REL_GERARCONCILIADOS_VENDASVIVA`
--

/*!50001 DROP VIEW IF EXISTS `REL_GERARCONCILIADOS_VENDASVIVA`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_unicode_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`sd_spreadrecon`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `REL_GERARCONCILIADOS_VENDASVIVA` AS select distinct `v`.`id` AS `id` from (`TBN_VENDASVIVA` `v` join `TBR_IMPORTACAOPLANILHA` `iv` on(((`iv`.`id` = `v`.`idImportacaoPlanilha`) and (`iv`.`idStatus` = 5) and (`v`.`idStatus` = 8)))) where `v`.`id` in (select distinct `r`.`idVendasViva` from `TBN_RESULTADOPROCESSAMENTO` `r`) order by `v`.`id` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `REL_GERARESULTADOPROCESSAMENTO`
--

/*!50001 DROP VIEW IF EXISTS `REL_GERARESULTADOPROCESSAMENTO`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`sd_spreadrecon`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `REL_GERARESULTADOPROCESSAMENTO` AS select distinct `v`.`idImportacaoPlanilha` AS `idImportacaoPlanilhaVendasViva`,`v`.`id` AS `idVendasViva`,`p`.`idImportacaoPlanilha` AS `idImportacaoPlanilhaPagamentoOperadora`,`p`.`id` AS `idPagamentoOperadora`,sysdate() AS `dataResultadoProcessamento`,7 AS `idStatus`,`p`.`nomeCicloPagamento` AS `nomeCicloPagamento` from (((`TBN_VENDASVIVA` `v` join `TBN_PAGAMENTOOPERADORA` `p` on((`v`.`numeroLinha` = `p`.`numeroMSISDN`))) join `TBR_IMPORTACAOPLANILHA` `iv` on(((`iv`.`id` = `v`.`idImportacaoPlanilha`) and (`iv`.`idStatus` = 5) and (`v`.`idStatus` = 8)))) join `TBR_IMPORTACAOPLANILHA` `ip` on(((`ip`.`id` = `p`.`idImportacaoPlanilha`) and (`ip`.`idStatus` = 5) and (`p`.`idStatus` = 8)))) where (((not(`p`.`idImportacaoPlanilha` in (select `r`.`idImportacaoPlanilhaPagamentoOperadora` from `TBN_RESULTADOPROCESSAMENTO` `r`))) or (not(`v`.`idImportacaoPlanilha` in (select `r`.`idImportacaoPlanilhaVendasViva` from `TBN_RESULTADOPROCESSAMENTO` `r`)))) and (`iv`.`idLoja` = `ip`.`idLoja`)) order by `v`.`idImportacaoPlanilha`,`v`.`id` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `REL_GERARNAOCONCILIADOS_PAGAMENTOOPERADORA`
--

/*!50001 DROP VIEW IF EXISTS `REL_GERARNAOCONCILIADOS_PAGAMENTOOPERADORA`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`sd_spreadrecon`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `REL_GERARNAOCONCILIADOS_PAGAMENTOOPERADORA` AS select distinct `p`.`id` AS `id` from (`TBN_PAGAMENTOOPERADORA` `p` join `TBR_IMPORTACAOPLANILHA` `ip` on(((`ip`.`id` = `p`.`idImportacaoPlanilha`) and (`ip`.`idStatus` = 5)))) where (not(`p`.`id` in (select distinct `r`.`idPagamentoOperadora` from `TBN_RESULTADOPROCESSAMENTO` `r`))) order by `p`.`id` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `REL_GERARNAOCONCILIADOS_VENDASVIVA`
--

/*!50001 DROP VIEW IF EXISTS `REL_GERARNAOCONCILIADOS_VENDASVIVA`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`sd_spreadrecon`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `REL_GERARNAOCONCILIADOS_VENDASVIVA` AS select distinct `v`.`id` AS `id` from (`TBN_VENDASVIVA` `v` join `TBR_IMPORTACAOPLANILHA` `iv` on(((`iv`.`id` = `v`.`idImportacaoPlanilha`) and (`iv`.`idStatus` = 5)))) where (not(`v`.`id` in (select distinct `r`.`idVendasViva` from `TBN_RESULTADOPROCESSAMENTO` `r`))) order by `v`.`id` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `REL_GERARPAGAMENTOSCONCILIADOS`
--

/*!50001 DROP VIEW IF EXISTS `REL_GERARPAGAMENTOSCONCILIADOS`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`sd_spreadrecon`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `REL_GERARPAGAMENTOSCONCILIADOS` AS select `r`.`id` AS `id`,`r`.`nomeCicloPagamento` AS `nomeCicloPagamento`,`r`.`idImportacaoPlanilhaVendasViva` AS `idImportacaoPlanilhaVendasViva`,`iv`.`nomeArquivoOriginal` AS `nomeArquivoOriginalVendasViva`,count(`r`.`idImportacaoPlanilhaVendasViva`) AS `totalVendasViva`,`r`.`idImportacaoPlanilhaPagamentoOperadora` AS `idImportacaoPlanilhaPagamentoOperadora`,`ip`.`nomeArquivoOriginal` AS `nomeArquivoOriginalPagamentoOperadora`,count(`r`.`idImportacaoPlanilhaPagamentoOperadora`) AS `totalPagamentoOperadora`,`r`.`dataResultadoProcessamento` AS `dataResultadoProcessamento`,`r`.`idStatus` AS `idStatus`,`s`.`nomeStatus` AS `nomeStatus` from (((`TBN_RESULTADOPROCESSAMENTO` `r` join `TBR_IMPORTACAOPLANILHA` `iv` on((`iv`.`id` = `r`.`idImportacaoPlanilhaVendasViva`))) join `TBR_IMPORTACAOPLANILHA` `ip` on((`ip`.`id` = `r`.`idImportacaoPlanilhaPagamentoOperadora`))) join `TBD_STATUS` `s` on((`s`.`id` = `r`.`idStatus`))) group by `r`.`dataResultadoProcessamento`,`r`.`idImportacaoPlanilhaVendasViva`,`r`.`idImportacaoPlanilhaPagamentoOperadora` order by `r`.`dataResultadoProcessamento` desc,`r`.`idImportacaoPlanilhaVendasViva`,`r`.`idImportacaoPlanilhaPagamentoOperadora` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-01-31  4:43:24
