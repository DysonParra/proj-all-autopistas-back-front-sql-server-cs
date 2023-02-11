USE master
GO
IF EXISTS(SELECT * FROM sys.databases WHERE name = 'Autopistas') DROP DATABASE [Autopistas]
GO
CREATE DATABASE [Autopistas];
GO
USE [Autopistas];
GO

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Usuario')
CREATE TABLE [dbo].[Usuario] (
    [Cedula_Usuario]                    BIGINT              NOT NULL IDENTITY,
    [Nombre_Usuario]                    VARCHAR(50)             NULL DEFAULT NULL,
    [Apellido_Usuario]                  VARCHAR(50)             NULL DEFAULT NULL,
    [Seudonimo]                         VARCHAR(30)             NULL DEFAULT NULL,
    [Tipo_Usuario]                      VARCHAR                 CHECK (tipo_Usuario in ('1','2','3','4')),
    [Contrasena]                        VARCHAR(30)             NULL DEFAULT NULL,
    [Cargo_Usuario]                     VARCHAR(30)             NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([Cedula_Usuario])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Transito_Dinamica')
CREATE TABLE [dbo].[Transito_Dinamica] (
    [Id_Dinamica]                       BIGINT              NOT NULL IDENTITY,
    [Id_Categoria]                      INT                     NULL DEFAULT NULL,
    [Placa_Vehiculo]                    VARCHAR(10)             NULL DEFAULT NULL,
    [Fecha_Hora_Transito]               DATETIME                NULL DEFAULT NULL,
    [Peso_General]                      INT                     NULL DEFAULT NULL,
    [Peso_Ejes]                         VARCHAR(50)             NULL DEFAULT NULL,
    [Velocidad]                         FLOAT                   NULL DEFAULT NULL,
    [Base_64_Placa]                     VARCHAR(MAX)            NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([Id_Dinamica])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Vehiculo_Sobrepeso')
CREATE TABLE [dbo].[Vehiculo_Sobrepeso] (
    [Id_Repeso]                         BIGINT              NOT NULL IDENTITY,
    [Id_Dinamica]                       BIGINT                  NULL DEFAULT NULL,
    [Peso_Maximo]                       INT                     NULL DEFAULT NULL,
    [Diferencia_Peso]                   INT                     NULL DEFAULT NULL,
    [Placa_Vehiculo]                    VARCHAR(10)             NULL DEFAULT NULL,
    [Borrado]                           BIT                     NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([Id_Repeso])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Registro_Vehiculo')
CREATE TABLE [dbo].[Registro_Vehiculo] (
    [Tiquete_Nro]                       BIGINT              NOT NULL IDENTITY,
    [Id_Repeso]                         BIGINT                  NULL DEFAULT NULL,
    [Id_Categoria]                      BIGINT                  NULL DEFAULT NULL,
    [Cedula_Usuario]                    BIGINT                  NULL DEFAULT NULL,
    [Placa_Vehiculo]                    VARCHAR(10)             NULL DEFAULT NULL,
    [Id_Mercancia]                      BIGINT                  NULL DEFAULT NULL,
    [Cedula_Conductor]                  BIGINT                  NULL DEFAULT NULL,
    [Fecha_Hora_Estatica]               DATETIME                NULL DEFAULT NULL,
    [Peso_Estatica]                     BIGINT                  NULL DEFAULT NULL,
    [Sobrepeso]                         BIGINT                  NULL DEFAULT NULL,
    [Pesaje_Autorizado]                 BIT                     NULL DEFAULT NULL,
    [Comparendo]                        BIT                     NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([Tiquete_Nro])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Mercancia')
CREATE TABLE [dbo].[Mercancia] (
    [Id_Mercancia]                      BIGINT              NOT NULL IDENTITY,
    [Nombre_Mercancia]                  VARCHAR(50)             NULL DEFAULT NULL,
    [Descripcion_Mercancia]             VARCHAR(200)            NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([Id_Mercancia])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Conductor')
CREATE TABLE [dbo].[Conductor] (
    [Cedula_Conductor]                  BIGINT              NOT NULL IDENTITY,
    [Nombre_Conductor]                  VARCHAR(50)             NULL DEFAULT NULL,
    [Apellido_Conductor]                VARCHAR(50)             NULL DEFAULT NULL,
    [Telefono]                          VARCHAR(20)             NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([Cedula_Conductor])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Categoria')
CREATE TABLE [dbo].[Categoria] (
    [Id_Categoria]                      BIGINT              NOT NULL IDENTITY,
    [Categoria]                         VARCHAR(6)              NULL DEFAULT NULL,
    [Peso_Maximo]                       INT                     NULL DEFAULT NULL,
    [Tolerancia]                        INT                     NULL DEFAULT NULL,
    [Descripcion]                       VARCHAR(200)            NULL DEFAULT NULL,
    [Eje_Sencillo]                      INT                     NULL DEFAULT NULL,
    [Eje_Tandem]                        INT                     NULL DEFAULT NULL,
    [Total_Ejes]                        INT                     NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([Id_Categoria])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Vehiculo')
CREATE TABLE [dbo].[Vehiculo] (
    [Placa_Vehiculo]                    VARCHAR(10)         NOT NULL,
    [Id_Categoria]                      BIGINT                  NULL DEFAULT NULL,
    [Observaciones]                     VARCHAR(200)            NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([Placa_Vehiculo])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Comparendo')
CREATE TABLE [dbo].[Comparendo] (
    [Id_Comparendo]                     BIGINT              NOT NULL IDENTITY,
    [Placa_Vehiculo]                    VARCHAR(10)             NULL DEFAULT NULL,
    [Id_Policia]                        BIGINT                  NULL DEFAULT NULL,
    [Cedula_Conductor]                  BIGINT                  NULL DEFAULT NULL,
    [Tiquete_Nro]                       BIGINT                  NULL DEFAULT NULL,
    [Codigo_Comparendo]                 INT                     NULL DEFAULT NULL,
    [Observaciones]                     VARCHAR(200)            NULL DEFAULT NULL,
    [Tipo_Infractor]                    VARCHAR                NULL DEFAULT NULL CHECK (tipo_Infractor in ('1','2','3')),
    PRIMARY KEY CLUSTERED ([Id_Comparendo])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Trama_Comunicacion')
CREATE TABLE [dbo].[Trama_Comunicacion] (
    [Id_Trama]                          BIGINT              NOT NULL IDENTITY,
    [Nombre_Trama]                      VARCHAR(50)             NULL DEFAULT NULL,
    [Posicion_Inicial]                  INT                     NULL DEFAULT NULL,
    [Total_Datos_Peso]                  INT                     NULL DEFAULT NULL,
    [Caracter_Fin]                      CHAR(5)                 NULL DEFAULT NULL,
    [Caracter_Inicio]                   CHAR(5)                 NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([Id_Trama])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Configuracion')
CREATE TABLE [dbo].[Configuracion] (
    [Id_Configuracion]                  BIGINT              NOT NULL IDENTITY,
    [Parametro]                         VARCHAR(50)             NULL DEFAULT NULL,
    [Valor]                             VARCHAR(MAX)            NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([Id_Configuracion])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Policia')
CREATE TABLE [dbo].[Policia] (
    [Id_Policia]                        BIGINT              NOT NULL IDENTITY,
    [Nombre_Policia]                    VARCHAR(50)             NULL DEFAULT NULL,
    [Apellido_Policia]                  VARCHAR(50)             NULL DEFAULT NULL,
    [Telefono]                          VARCHAR(20)             NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([Id_Policia])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Menu')
CREATE TABLE [dbo].[Menu] (
    [Id]                                VARCHAR(200)        NOT NULL,
    [Title]                             VARCHAR(100)            NULL DEFAULT NULL,
    [Subtitle]                          VARCHAR(200)            NULL DEFAULT NULL,
    [Type]                              VARCHAR(100)            NULL DEFAULT NULL,
    [Icon]                              VARCHAR(100)            NULL DEFAULT NULL,
    [Link]                              VARCHAR(100)            NULL DEFAULT NULL,
    [Exact_Match]                       BIT                     NULL DEFAULT NULL,
    [Active]                            BIT                     NULL DEFAULT NULL,
    [Disabled]                          BIT                     NULL DEFAULT NULL,
    [Badge]                             VARCHAR(50)             NULL DEFAULT NULL,
    [Father]                            VARCHAR(200)            NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([Id])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Badge')
CREATE TABLE [dbo].[Badge] (
    [Title]                             VARCHAR(50)         NOT NULL,
    [Classes]                           VARCHAR(250)            NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([Title])
);


IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Pesaje')
CREATE TABLE [dbo].[Pesaje] (
    [Id]                                BIGINT              NOT NULL IDENTITY,
    [Tiquete_Numero]                    BIGINT                  NULL DEFAULT NULL,
    [Placa]                             VARCHAR(10)             NULL DEFAULT NULL,
    [Codigo]                            VARCHAR(50)             NULL DEFAULT NULL,
    [Numero_Interno]                    BIGINT                  NULL DEFAULT NULL,
    [Tipo_Vehiculo]                     VARCHAR(20)             NULL DEFAULT NULL,
    [Conductor]                         VARCHAR(100)            NULL DEFAULT NULL,
    [Cedula]                            VARCHAR(20)             NULL DEFAULT NULL,
    [Producto]                          VARCHAR(100)            NULL DEFAULT NULL,
    [Planta]                            VARCHAR(100)            NULL DEFAULT NULL,
    [Cliente]                           VARCHAR(100)            NULL DEFAULT NULL,
    [Transportadora]                    VARCHAR(100)            NULL DEFAULT NULL,
    [Fecha_Hora_Peso_Vacio]             DATETIME                NULL DEFAULT NULL,
    [Fecha_Hora_Peso_Lleno]             DATETIME                NULL DEFAULT NULL,
    [Civ]                               VARCHAR(50)             NULL DEFAULT NULL,
    [Direccion]                         VARCHAR(80)             NULL DEFAULT NULL,
    [Entregado_Por]                     VARCHAR(100)            NULL DEFAULT NULL,
    [Recibido_Por]                      VARCHAR(100)            NULL DEFAULT NULL,
    [Shipment]                          VARCHAR(50)             NULL DEFAULT NULL,
    [Sello]                             VARCHAR(50)             NULL DEFAULT NULL,
    [R]                                 VARCHAR(50)             NULL DEFAULT NULL,
    [Contenedor]                        VARCHAR(50)             NULL DEFAULT NULL,
    [Observacion]                       VARCHAR(250)            NULL DEFAULT NULL,
    [Tipo_Ingreso]                      VARCHAR                 CHECK (tipo_Ingreso in ('Despacho producto','Entrada materia prima', '')),
    PRIMARY KEY CLUSTERED ([Id])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Periferico')
CREATE TABLE [dbo].[Periferico] (
    [Id]                                BIGINT              NOT NULL IDENTITY,
    [Tipo_Periferico]                   VARCHAR                 CHECK (tipo_Periferico in ('Bascula_Estatica','Bascula_Dinamica', '')),
    [Ip]                                VARCHAR(50)             NULL DEFAULT NULL,
    [Puerto]                            BIGINT                  NULL DEFAULT NULL,
    [Codigo]                            VARCHAR(50)             NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([Id])
);

-- ---------------------------- --
-- --------FOREIGN KEYS-------- --
-- ---------------------------- --

ALTER TABLE [Vehiculo_Sobrepeso]
    ADD CONSTRAINT [Fk_Vehiculos_Sobrepeso_Id_Dinamica]
        FOREIGN KEY ([Id_Dinamica])
        REFERENCES [Transito_Dinamica] ([Id_Dinamica])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Vehiculo]
    ADD CONSTRAINT [Fk_Vehiculo_Id_Categoria]
        FOREIGN KEY ([Id_Categoria])
        REFERENCES [Categoria] ([Id_Categoria])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Registro_Vehiculo]
    ADD CONSTRAINT [Fk_Registro_Vehiculos_Id_Repeso]
        FOREIGN KEY ([Id_Repeso])
        REFERENCES [Vehiculo_Sobrepeso] ([Id_Repeso])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [Fk_Registro_Vehiculos_Cedula_Usuario]
        FOREIGN KEY ([Cedula_Usuario])
        REFERENCES [Usuario] ([Cedula_Usuario])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [Fk_Registro_Vehiculos_Id_Mercancia]
        FOREIGN KEY ([Id_Mercancia])
        REFERENCES [Mercancia] ([Id_Mercancia])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [Fk_Registro_Vehiculos_Cedula_Conductor]
        FOREIGN KEY ([Cedula_Conductor])
        REFERENCES [Conductor] ([Cedula_Conductor])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [Fk_Registro_Vehiculos_Id_Categoria]
        FOREIGN KEY ([Id_Categoria])
        REFERENCES [Categoria] ([Id_Categoria])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [Fk_Registro_Vehiculos_Placa_Vehiculo]
        FOREIGN KEY ([Placa_Vehiculo])
        REFERENCES [Vehiculo] ([Placa_Vehiculo])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Comparendo]
    ADD CONSTRAINT [Fk_Comparendos_Cedula_Conductor]
        FOREIGN KEY ([Cedula_Conductor])
        REFERENCES [Conductor] ([Cedula_Conductor])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [Fk_Comparendos_Tiquete_Nro]
        FOREIGN KEY ([Tiquete_Nro])
        REFERENCES [Registro_Vehiculo] ([Tiquete_Nro])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [Fk_Comparendos_Placa_Vehiculo]
        FOREIGN KEY ([Placa_Vehiculo])
        REFERENCES [Vehiculo] ([Placa_Vehiculo])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [Fk_Comparendos_Id_Policia]
        FOREIGN KEY ([Id_Policia])
        REFERENCES [Policia] ([Id_Policia])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Menu]
    ADD CONSTRAINT [Fk_Menu_Badge]
        FOREIGN KEY ([Badge])
        REFERENCES [Badge] ([Title])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [Fk_Menu_Father]
        FOREIGN KEY ([Father])
        REFERENCES [Menu] ([Id])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;
