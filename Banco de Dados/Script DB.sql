Drop DATABASE IF EXISTS bdOrangePoint;
CREATE DATABASE bdOrangePoint;
CREATE TABLE `bdOrangePoint`.`USUARIO` (
  `COD_USUARIO` INT NOT NULL AUTO_INCREMENT , 
  `LOGIN` VARCHAR(45) NULL,
  `SENHA` VARCHAR(45) NULL,
  `NME_FUNCIONARIO` VARCHAR(45) NULL,
  `HRS_DIARIA` DECIMAL(2,2) NULL,
  `FOTO_USUARIO` VARCHAR(100) NULL,
  PRIMARY KEY (`COD_USUARIO`));
  
  CREATE TABLE `bdOrangePoint`.`TIPO_PERMISSAO` (
  `COD_TIPO_PERMISSAO` INT NOT NULL AUTO_INCREMENT , 
  `DESC_PERMISSAO` VARCHAR(45) NULL,
  PRIMARY KEY (`COD_TIPO_PERMISSAO`));
  
CREATE TABLE `bdOrangePoint`.`FOLHA_PONTO_USUARIO` (
  `COD_PONTO` INT NOT NULL AUTO_INCREMENT , 
  `COD_USUARIO` INT NOT NULL,
  `DATA_PONTO` DATE NOT NULL,
  `ENTRADA_1` VARCHAR(45) NULL,
  `SAIDA_1` VARCHAR(45) NULL,
  `ENTRADA_2` VARCHAR(45) NULL,
  `SAIDA_2` VARCHAR(45) NULL,
  PRIMARY KEY (`COD_PONTO`),
  FOREIGN KEY(COD_USUARIO) REFERENCES bdOrangePoint.USUARIO (COD_USUARIO));
  
  CREATE TABLE `bdOrangePoint`.`PERMISSOES` (
  `COD_PERMISSAO` INT NOT NULL AUTO_INCREMENT , 
  `COD_USUARIO` INT NOT NULL,
  `COD_TIPO_PERMISSAO` INT NOT NULL,
  PRIMARY KEY (`COD_PERMISSAO`),
  FOREIGN KEY(COD_USUARIO) REFERENCES bdOrangePoint.USUARIO (COD_USUARIO),
  FOREIGN KEY(COD_TIPO_PERMISSAO) REFERENCES bdOrangePoint.TIPO_PERMISSAO (COD_TIPO_PERMISSAO));
  
   CREATE TABLE `bdOrangePoint`.`ATIVIDADE_EMPRESA` (
  `COD_ATIVIDADE` INT NOT NULL AUTO_INCREMENT , 
  `DESCRICAO` VARCHAR(45) NULL,
  PRIMARY KEY (`COD_ATIVIDADE`));
  
   CREATE TABLE `bdOrangePoint`.`REGIME_EMPRESA` (
  `COD_REGIME` INT NOT NULL AUTO_INCREMENT , 
  `DESCRICAO` VARCHAR(45) NULL,
  PRIMARY KEY (`COD_REGIME`));
  
  CREATE TABLE `bdOrangePoint`.`TIPO_DATA` (
  `COD_TIPO_DATA` INT NOT NULL AUTO_INCREMENT , 
  `DESC_TIPO` VARCHAR(45) NULL,
  PRIMARY KEY (`COD_TIPO_DATA`));
  
  CREATE TABLE `bdOrangePoint`.`EMPRESA` (
  `COD_EMPRESA` INT NOT NULL AUTO_INCREMENT , 
  `COD_REGIME` INT NOT NULL,
  `COD_ATIVIDADE` INT NOT NULL,
  `GRUPO` VARCHAR(45) NULL,
  `CNPJ` VARCHAR(45) NULL,
  `CLASSIFICACAO` VARCHAR(45),
  `NUM_SOCIOS` INT NULL,
  `NUM_VINCULOS` INT NULL,
  `OBSERVACAO` VARCHAR(45),
  `SENHA_SIAT` VARCHAR(45),
  `ESOCIAL` VARCHAR(45),
  PRIMARY KEY (`COD_EMPRESA`),
  FOREIGN KEY(COD_REGIME) REFERENCES bdOrangePoint.REGIME_EMPRESA (COD_REGIME),
  FOREIGN KEY(COD_ATIVIDADE) REFERENCES bdOrangePoint.ATIVIDADE_EMPRESA (COD_ATIVIDADE));
  
   CREATE TABLE `bdOrangePoint`.`DATAS_EMPRESA` (
  `COD_DATA` INT NOT NULL AUTO_INCREMENT , 
  `COD_TIPO_DATA` INT NOT NULL,
  `COD_EMPRESA` INT NOT NULL,
  `DATA` DATE NULL,
  PRIMARY KEY (`COD_DATA`),
  FOREIGN KEY(COD_TIPO_DATA) REFERENCES bdOrangePoint.TIPO_DATA (COD_TIPO_DATA),
  FOREIGN KEY(COD_EMPRESA) REFERENCES bdOrangePoint.EMPRESA (COD_EMPRESA));
  
  CREATE TABLE `bdOrangePoint`.`ALVARAS_EMPRESA` (
  `COD_ALVARA` INT NOT NULL AUTO_INCREMENT , 
  `COD_EMPRESA` INT NOT NULL,
  `DESC_ALVARA` INT NOT NULL,
  PRIMARY KEY (`COD_ALVARA`),
  FOREIGN KEY(COD_EMPRESA) REFERENCES bdOrangePoint.EMPRESA (COD_EMPRESA));
  
  CREATE TABLE `bdOrangePoint`.`DADOS_WEB_EMPRESA` (
  `COD_DADO_WEB` INT NOT NULL AUTO_INCREMENT , 
  `COD_EMPRESA` INT NOT NULL,
  `USUARIO_WEB` VARCHAR(45) NULL,
  `SENHA_WEB` VARCHAR(45) NULL,
  `DESC_DADO` VARCHAR(45) NULL,
  PRIMARY KEY (`COD_DADO_WEB`),
  FOREIGN KEY(COD_EMPRESA) REFERENCES bdOrangePoint.EMPRESA (COD_EMPRESA));
  
  CREATE TABLE `bdOrangePoint`.`CONTATOS_EMPRESA` (
  `COD_CONTATO` INT NOT NULL AUTO_INCREMENT , 
  `COD_EMPRESA` INT NOT NULL,
  `DESC_CONTATO` VARCHAR(45) NULL,
  PRIMARY KEY (`COD_CONTATO`),
  FOREIGN KEY(COD_EMPRESA) REFERENCES bdOrangePoint.EMPRESA (COD_EMPRESA));
  
  CREATE TABLE `bdOrangePoint`.`FUNCIONARIOS_EMPRESA` (
  `COD_FUNCIONARIO` INT NOT NULL AUTO_INCREMENT , 
  `COD_EMPRESA` INT NOT NULL,
  `NME_FUNCIONARIO` VARCHAR(45) NULL,
  PRIMARY KEY (`COD_FUNCIONARIO`),
  FOREIGN KEY(COD_EMPRESA) REFERENCES bdOrangePoint.EMPRESA (COD_EMPRESA));
  
  CREATE TABLE `bdOrangePoint`.`BENEFICIOS_FUNC` (
  `COD_BENEFICIO` INT NOT NULL AUTO_INCREMENT,
  `COD_FUNCIONARIO` INT NOT NULL, 
  `DESC_BENEFICIO` VARCHAR(45) NULL,
  `DATA_ACORDO` DATE NULL,
  `DATA_VENCIMENTO` DATE NULL,
  `FLG_PARC_FGTS` BOOLEAN NULL,
  PRIMARY KEY (`COD_BENEFICIO`),
  FOREIGN KEY(COD_FUNCIONARIO) REFERENCES bdOrangePoint.FUNCIONARIOS_EMPRESA (COD_FUNCIONARIO));
  
  
  
  
  
  