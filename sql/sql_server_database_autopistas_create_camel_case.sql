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
    [CedulaUsuario]                     BIGINT              NOT NULL IDENTITY,
    [NombreUsuario]                     VARCHAR(50)             NULL DEFAULT NULL,
    [ApellidoUsuario]                   VARCHAR(50)             NULL DEFAULT NULL,
    [Seudonimo]                         VARCHAR(30)             NULL DEFAULT NULL,
    [TipoUsuario]                       VARCHAR                 CHECK (tipoUsuario in ('1','2','3','4')),
    [Contrasena]                        VARCHAR(30)             NULL DEFAULT NULL,
    [CargoUsuario]                      VARCHAR(30)             NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([CedulaUsuario])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'TransitoDinamica')
CREATE TABLE [dbo].[TransitoDinamica] (
    [IdDinamica]                        BIGINT              NOT NULL IDENTITY,
    [IdCategoria]                       INT                     NULL DEFAULT NULL,
    [PlacaVehiculo]                     VARCHAR(10)             NULL DEFAULT NULL,
    [FechaHoraTransito]                 DATETIME                NULL DEFAULT NULL,
    [PesoGeneral]                       INT                     NULL DEFAULT NULL,
    [PesoEjes]                          VARCHAR(50)             NULL DEFAULT NULL,
    [Velocidad]                         FLOAT                   NULL DEFAULT NULL,
    [Base64Placa]                       VARCHAR(MAX)            NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([IdDinamica])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'VehiculoSobrepeso')
CREATE TABLE [dbo].[VehiculoSobrepeso] (
    [IdRepeso]                          BIGINT              NOT NULL IDENTITY,
    [IdDinamica]                        BIGINT                  NULL DEFAULT NULL,
    [PesoMaximo]                        INT                     NULL DEFAULT NULL,
    [DiferenciaPeso]                    INT                     NULL DEFAULT NULL,
    [PlacaVehiculo]                     VARCHAR(10)             NULL DEFAULT NULL,
    [Borrado]                           BIT                     NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([IdRepeso])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'RegistroVehiculo')
CREATE TABLE [dbo].[RegistroVehiculo] (
    [TiqueteNro]                        BIGINT              NOT NULL IDENTITY,
    [IdRepeso]                          BIGINT                  NULL DEFAULT NULL,
    [IdCategoria]                       BIGINT                  NULL DEFAULT NULL,
    [CedulaUsuario]                     BIGINT                  NULL DEFAULT NULL,
    [PlacaVehiculo]                     VARCHAR(10)             NULL DEFAULT NULL,
    [IdMercancia]                       BIGINT                  NULL DEFAULT NULL,
    [CedulaConductor]                   BIGINT                  NULL DEFAULT NULL,
    [FechaHoraEstatica]                 DATETIME                NULL DEFAULT NULL,
    [PesoEstatica]                      BIGINT                  NULL DEFAULT NULL,
    [Sobrepeso]                         BIGINT                  NULL DEFAULT NULL,
    [PesajeAutorizado]                  BIT                     NULL DEFAULT NULL,
    [Comparendo]                        BIT                     NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([TiqueteNro])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Mercancia')
CREATE TABLE [dbo].[Mercancia] (
    [IdMercancia]                       BIGINT              NOT NULL IDENTITY,
    [NombreMercancia]                   VARCHAR(50)             NULL DEFAULT NULL,
    [DescripcionMercancia]              VARCHAR(200)            NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([IdMercancia])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Conductor')
CREATE TABLE [dbo].[Conductor] (
    [CedulaConductor]                   BIGINT              NOT NULL IDENTITY,
    [NombreConductor]                   VARCHAR(50)             NULL DEFAULT NULL,
    [ApellidoConductor]                 VARCHAR(50)             NULL DEFAULT NULL,
    [Telefono]                          VARCHAR(20)             NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([CedulaConductor])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Categoria')
CREATE TABLE [dbo].[Categoria] (
    [IdCategoria]                       BIGINT              NOT NULL IDENTITY,
    [Categoria]                         VARCHAR(6)              NULL DEFAULT NULL,
    [PesoMaximo]                        INT                     NULL DEFAULT NULL,
    [Tolerancia]                        INT                     NULL DEFAULT NULL,
    [Descripcion]                       VARCHAR(200)            NULL DEFAULT NULL,
    [EjeSencillo]                       INT                     NULL DEFAULT NULL,
    [EjeTandem]                         INT                     NULL DEFAULT NULL,
    [TotalEjes]                         INT                     NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([IdCategoria])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Vehiculo')
CREATE TABLE [dbo].[Vehiculo] (
    [PlacaVehiculo]                     VARCHAR(10)         NOT NULL,
    [IdCategoria]                       BIGINT                  NULL DEFAULT NULL,
    [Observaciones]                     VARCHAR(200)            NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([PlacaVehiculo])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Comparendo')
CREATE TABLE [dbo].[Comparendo] (
    [IdComparendo]                      BIGINT              NOT NULL IDENTITY,
    [PlacaVehiculo]                     VARCHAR(10)             NULL DEFAULT NULL,
    [IdPolicia]                         BIGINT                  NULL DEFAULT NULL,
    [CedulaConductor]                   BIGINT                  NULL DEFAULT NULL,
    [TiqueteNro]                        BIGINT                  NULL DEFAULT NULL,
    [CodigoComparendo]                  INT                     NULL DEFAULT NULL,
    [Observaciones]                     VARCHAR(200)            NULL DEFAULT NULL,
    [TipoInfractor]                     VARCHAR                 NULL DEFAULT NULL CHECK (tipoInfractor in ('1','2','3')),
    PRIMARY KEY CLUSTERED ([IdComparendo])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'TramaComunicacion')
CREATE TABLE [dbo].[TramaComunicacion] (
    [IdTrama]                           BIGINT              NOT NULL IDENTITY,
    [NombreTrama]                       VARCHAR(50)             NULL DEFAULT NULL,
    [PosicionInicial]                   INT                     NULL DEFAULT NULL,
    [TotalDatosPeso]                    INT                     NULL DEFAULT NULL,
    [CaracterFin]                       CHAR(5)                 NULL DEFAULT NULL,
    [CaracterInicio]                    CHAR(5)                 NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([IdTrama])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Configuracion')
CREATE TABLE [dbo].[Configuracion] (
    [IdConfiguracion]                   BIGINT              NOT NULL IDENTITY,
    [Parametro]                         VARCHAR(50)             NULL DEFAULT NULL,
    [Valor]                             VARCHAR(MAX)            NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([IdConfiguracion])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Policia')
CREATE TABLE [dbo].[Policia] (
    [IdPolicia]                         BIGINT              NOT NULL IDENTITY,
    [NombrePolicia]                     VARCHAR(50)             NULL DEFAULT NULL,
    [ApellidoPolicia]                   VARCHAR(50)             NULL DEFAULT NULL,
    [Telefono]                          VARCHAR(20)             NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([IdPolicia])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Menu')
CREATE TABLE [dbo].[Menu] (
    [Id]                                VARCHAR(200)        NOT NULL,
    [Title]                             VARCHAR(100)            NULL DEFAULT NULL,
    [Subtitle]                          VARCHAR(200)            NULL DEFAULT NULL,
    [Type]                              VARCHAR(100)            NULL DEFAULT NULL,
    [Icon]                              VARCHAR(100)            NULL DEFAULT NULL,
    [Link]                              VARCHAR(100)            NULL DEFAULT NULL,
    [ExactMatch]                        BIT                     NULL DEFAULT NULL,
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
    [TiqueteNumero]                     BIGINT                  NULL DEFAULT NULL,
    [Placa]                             VARCHAR(10)             NULL DEFAULT NULL,
    [Codigo]                            VARCHAR(50)             NULL DEFAULT NULL,
    [NumeroInterno]                     BIGINT                  NULL DEFAULT NULL,
    [TipoVehiculo]                      VARCHAR(20)             NULL DEFAULT NULL,
    [Conductor]                         VARCHAR(100)            NULL DEFAULT NULL,
    [Cedula]                            VARCHAR(20)             NULL DEFAULT NULL,
    [Producto]                          VARCHAR(100)            NULL DEFAULT NULL,
    [Planta]                            VARCHAR(100)            NULL DEFAULT NULL,
    [Cliente]                           VARCHAR(100)            NULL DEFAULT NULL,
    [Transportadora]                    VARCHAR(100)            NULL DEFAULT NULL,
    [FechaHoraPesoVacio]                DATETIME                NULL DEFAULT NULL,
    [FechaHoraPesoLleno]                DATETIME                NULL DEFAULT NULL,
    [Civ]                               VARCHAR(50)             NULL DEFAULT NULL,
    [Direccion]                         VARCHAR(80)             NULL DEFAULT NULL,
    [EntregadoPor]                      VARCHAR(100)            NULL DEFAULT NULL,
    [RecibidoPor]                       VARCHAR(100)            NULL DEFAULT NULL,
    [Shipment]                          VARCHAR(50)             NULL DEFAULT NULL,
    [Sello]                             VARCHAR(50)             NULL DEFAULT NULL,
    [R]                                 VARCHAR(50)             NULL DEFAULT NULL,
    [Contenedor]                        VARCHAR(50)             NULL DEFAULT NULL,
    [Observacion]                       VARCHAR(250)            NULL DEFAULT NULL,
    [TipoIngreso]                       VARCHAR                 CHECK (tipoIngreso in ('Despacho producto','Entrada materia prima', '')),
    PRIMARY KEY CLUSTERED ([Id])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Periferico')
CREATE TABLE [dbo].[Periferico] (
    [Id]                                BIGINT              NOT NULL IDENTITY,
    [TipoPeriferico]                    VARCHAR                 CHECK (tipoPeriferico in ('Bascula_Estatica','Bascula_Dinamica', '')),
    [Ip]                                VARCHAR(50)             NULL DEFAULT NULL,
    [Puerto]                            BIGINT                  NULL DEFAULT NULL,
    [Codigo]                            VARCHAR(50)             NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([Id])
);

-- ---------------------------- --
-- --------FOREIGN KEYS-------- --
-- ---------------------------- --

ALTER TABLE [VehiculoSobrepeso]
    ADD CONSTRAINT [FkVehiculosSobrepesoIdDinamica]
        FOREIGN KEY ([IdDinamica])
        REFERENCES [TransitoDinamica] ([IdDinamica])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Vehiculo]
    ADD CONSTRAINT [FkVehiculoIdCategoria]
        FOREIGN KEY ([IdCategoria])
        REFERENCES [Categoria] ([IdCategoria])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [RegistroVehiculo]
    ADD CONSTRAINT [FkRegistroVehiculosIdRepeso]
        FOREIGN KEY ([IdRepeso])
        REFERENCES [VehiculoSobrepeso] ([IdRepeso])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [FkRegistroVehiculosCedulaUsuario]
        FOREIGN KEY ([CedulaUsuario])
        REFERENCES [Usuario] ([CedulaUsuario])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [FkRegistroVehiculosIdMercancia]
        FOREIGN KEY ([IdMercancia])
        REFERENCES [Mercancia] ([IdMercancia])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [FkRegistroVehiculosCedulaConductor]
        FOREIGN KEY ([CedulaConductor])
        REFERENCES [Conductor] ([CedulaConductor])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [FkRegistroVehiculosIdCategoria]
        FOREIGN KEY ([IdCategoria])
        REFERENCES [Categoria] ([IdCategoria])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [FkRegistroVehiculosPlacaVehiculo]
        FOREIGN KEY ([PlacaVehiculo])
        REFERENCES [Vehiculo] ([PlacaVehiculo])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Comparendo]
    ADD CONSTRAINT [FkComparendosCedulaConductor]
        FOREIGN KEY ([CedulaConductor])
        REFERENCES [Conductor] ([CedulaConductor])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [FkComparendosTiqueteNro]
        FOREIGN KEY ([TiqueteNro])
        REFERENCES [RegistroVehiculo] ([TiqueteNro])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [FkComparendosPlacaVehiculo]
        FOREIGN KEY ([PlacaVehiculo])
        REFERENCES [Vehiculo] ([PlacaVehiculo])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [FkComparendosIdPolicia]
        FOREIGN KEY ([IdPolicia])
        REFERENCES [Policia] ([IdPolicia])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Menu]
    ADD CONSTRAINT [FkMenuBadge]
        FOREIGN KEY ([Badge])
        REFERENCES [Badge] ([Title])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [FkMenuFather]
        FOREIGN KEY ([Father])
        REFERENCES [Menu] ([Id])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;
