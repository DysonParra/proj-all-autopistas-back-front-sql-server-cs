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
    [IntCedulaUsuario]                  BIGINT              NOT NULL IDENTITY,
    [StrNombreUsuario]                  VARCHAR(50)             NULL DEFAULT NULL,
    [StrApellidoUsuario]                VARCHAR(50)             NULL DEFAULT NULL,
    [StrSeudonimo]                      VARCHAR(30)             NULL DEFAULT NULL,
    [EnmTipoUsuario]                    VARCHAR                 CHECK (enmTipoUsuario in ('1','2','3','4')),
    [StrContrasena]                     VARCHAR(30)             NULL DEFAULT NULL,
    [StrCargoUsuario]                   VARCHAR(30)             NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([IntCedulaUsuario])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'TransitoDinamica')
CREATE TABLE [dbo].[TransitoDinamica] (
    [IntIdDinamica]                     BIGINT              NOT NULL IDENTITY,
    [IntIdCategoria]                    INT                     NULL DEFAULT NULL,
    [StrPlacaVehiculo]                  VARCHAR(10)             NULL DEFAULT NULL,
    [DtFechaHoraTransito]               DATETIME                NULL DEFAULT NULL,
    [IntPesoGeneral]                    INT                     NULL DEFAULT NULL,
    [StrPesoEjes]                       VARCHAR(50)             NULL DEFAULT NULL,
    [FltVelocidad]                      FLOAT                   NULL DEFAULT NULL,
    [TxtBase64Placa]                    VARCHAR(MAX)            NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([IntIdDinamica])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'VehiculoSobrepeso')
CREATE TABLE [dbo].[VehiculoSobrepeso] (
    [IntIdRepeso]                       BIGINT              NOT NULL IDENTITY,
    [IntIdDinamica]                     BIGINT                  NULL DEFAULT NULL,
    [IntPesoMaximo]                     INT                     NULL DEFAULT NULL,
    [IntDiferenciaPeso]                 INT                     NULL DEFAULT NULL,
    [StrPlacaVehiculo]                  VARCHAR(10)             NULL DEFAULT NULL,
    [BitBorrado]                        BIT                     NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([IntIdRepeso])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'RegistroVehiculo')
CREATE TABLE [dbo].[RegistroVehiculo] (
    [IntTiqueteNro]                     BIGINT              NOT NULL IDENTITY,
    [IntIdRepeso]                       BIGINT                  NULL DEFAULT NULL,
    [IntIdCategoria]                    BIGINT                  NULL DEFAULT NULL,
    [IntCedulaUsuario]                  BIGINT                  NULL DEFAULT NULL,
    [StrPlacaVehiculo]                  VARCHAR(10)             NULL DEFAULT NULL,
    [IntIdMercancia]                    BIGINT                  NULL DEFAULT NULL,
    [IntCedulaConductor]                BIGINT                  NULL DEFAULT NULL,
    [DtFechaHoraEstatica]               DATETIME                NULL DEFAULT NULL,
    [IntPesoEstatica]                   BIGINT                  NULL DEFAULT NULL,
    [IntSobrepeso]                      BIGINT                  NULL DEFAULT NULL,
    [BitPesajeAutorizado]               BIT                     NULL DEFAULT NULL,
    [BitComparendo]                     BIT                     NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([IntTiqueteNro])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Mercancia')
CREATE TABLE [dbo].[Mercancia] (
    [IntIdMercancia]                    BIGINT              NOT NULL IDENTITY,
    [StrNombreMercancia]                VARCHAR(50)             NULL DEFAULT NULL,
    [StrDescripcionMercancia]           VARCHAR(200)            NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([IntIdMercancia])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Conductor')
CREATE TABLE [dbo].[Conductor] (
    [IntCedulaConductor]                BIGINT              NOT NULL IDENTITY,
    [StrNombreConductor]                VARCHAR(50)             NULL DEFAULT NULL,
    [StrApellidoConductor]              VARCHAR(50)             NULL DEFAULT NULL,
    [StrTelefono]                       VARCHAR(20)             NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([IntCedulaConductor])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Categoria')
CREATE TABLE [dbo].[Categoria] (
    [IntIdCategoria]                    BIGINT              NOT NULL IDENTITY,
    [StrCategoria]                      VARCHAR(6)              NULL DEFAULT NULL,
    [IntPesoMaximo]                     INT                     NULL DEFAULT NULL,
    [IntTolerancia]                     INT                     NULL DEFAULT NULL,
    [StrDescripcion]                    VARCHAR(200)            NULL DEFAULT NULL,
    [IntEjeSencillo]                    INT                     NULL DEFAULT NULL,
    [IntEjeTandem]                      INT                     NULL DEFAULT NULL,
    [IntTotalEjes]                      INT                     NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([IntIdCategoria])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Vehiculo')
CREATE TABLE [dbo].[Vehiculo] (
    [StrPlacaVehiculo]                  VARCHAR(10)         NOT NULL,
    [IntIdCategoria]                    BIGINT                  NULL DEFAULT NULL,
    [StrObservaciones]                  VARCHAR(200)            NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([StrPlacaVehiculo])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Comparendo')
CREATE TABLE [dbo].[Comparendo] (
    [IntIdComparendo]                   BIGINT              NOT NULL IDENTITY,
    [StrPlacaVehiculo]                  VARCHAR(10)             NULL DEFAULT NULL,
    [IntIdPolicia]                      BIGINT                  NULL DEFAULT NULL,
    [IntCedulaConductor]                BIGINT                  NULL DEFAULT NULL,
    [IntTiqueteNro]                     BIGINT                  NULL DEFAULT NULL,
    [IntCodigoComparendo]               INT                     NULL DEFAULT NULL,
    [StrObservaciones]                  VARCHAR(200)            NULL DEFAULT NULL,
    [EnmTipoInfractor]                  VARCHAR                 NULL DEFAULT NULL CHECK (enmTipoInfractor in ('1','2','3')),
    PRIMARY KEY CLUSTERED ([IntIdComparendo])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'TramaComunicacion')
CREATE TABLE [dbo].[TramaComunicacion] (
    [IntIdTrama]                        BIGINT              NOT NULL IDENTITY,
    [StrNombreTrama]                    VARCHAR(50)             NULL DEFAULT NULL,
    [IntPosicionInicial]                INT                     NULL DEFAULT NULL,
    [IntTotalDatosPeso]                 INT                     NULL DEFAULT NULL,
    [CrCaracterFin]                     CHAR(5)                 NULL DEFAULT NULL,
    [CrCaracterInicio]                  CHAR(5)                 NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([IntIdTrama])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Configuracion')
CREATE TABLE [dbo].[Configuracion] (
    [IntIdConfiguracion]                BIGINT              NOT NULL IDENTITY,
    [StrParametro]                      VARCHAR(50)             NULL DEFAULT NULL,
    [TxtValor]                          VARCHAR(MAX)            NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([IntIdConfiguracion])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Policia')
CREATE TABLE [dbo].[Policia] (
    [IntIdPolicia]                      BIGINT              NOT NULL IDENTITY,
    [StrNombrePolicia]                  VARCHAR(50)             NULL DEFAULT NULL,
    [StrApellidoPolicia]                VARCHAR(50)             NULL DEFAULT NULL,
    [StrTelefono]                       VARCHAR(20)             NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([IntIdPolicia])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Menu')
CREATE TABLE [dbo].[Menu] (
    [StrId]                             VARCHAR(200)        NOT NULL,
    [StrTitle]                          VARCHAR(100)            NULL DEFAULT NULL,
    [StrSubtitle]                       VARCHAR(200)            NULL DEFAULT NULL,
    [StrType]                           VARCHAR(100)            NULL DEFAULT NULL,
    [StrIcon]                           VARCHAR(100)            NULL DEFAULT NULL,
    [StrLink]                           VARCHAR(100)            NULL DEFAULT NULL,
    [BitExactMatch]                     BIT                     NULL DEFAULT NULL,
    [BitActive]                         BIT                     NULL DEFAULT NULL,
    [BitDisabled]                       BIT                     NULL DEFAULT NULL,
    [StrBadge]                          VARCHAR(50)             NULL DEFAULT NULL,
    [StrFather]                         VARCHAR(200)            NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([StrId])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Badge')
CREATE TABLE [dbo].[Badge] (
    [StrTitle]                          VARCHAR(50)         NOT NULL,
    [StrClasses]                        VARCHAR(250)            NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([StrTitle])
);


IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Pesaje')
CREATE TABLE [dbo].[Pesaje] (
    [IntId]                             BIGINT              NOT NULL IDENTITY,
    [IntTiqueteNumero]                  BIGINT                  NULL DEFAULT NULL,
    [StrPlaca]                          VARCHAR(10)             NULL DEFAULT NULL,
    [StrCodigo]                         VARCHAR(50)             NULL DEFAULT NULL,
    [IntNumeroInterno]                  BIGINT                  NULL DEFAULT NULL,
    [StrTipoVehiculo]                   VARCHAR(20)             NULL DEFAULT NULL,
    [StrConductor]                      VARCHAR(100)            NULL DEFAULT NULL,
    [StrCedula]                         VARCHAR(20)             NULL DEFAULT NULL,
    [StrProducto]                       VARCHAR(100)            NULL DEFAULT NULL,
    [StrPlanta]                         VARCHAR(100)            NULL DEFAULT NULL,
    [StrCliente]                        VARCHAR(100)            NULL DEFAULT NULL,
    [StrTransportadora]                 VARCHAR(100)            NULL DEFAULT NULL,
    [DtFechaHoraPesoVacio]              DATETIME                NULL DEFAULT NULL,
    [DtFechaHoraPesoLleno]              DATETIME                NULL DEFAULT NULL,
    [StrCiv]                            VARCHAR(50)             NULL DEFAULT NULL,
    [StrDireccion]                      VARCHAR(80)             NULL DEFAULT NULL,
    [StrEntregadoPor]                   VARCHAR(100)            NULL DEFAULT NULL,
    [StrRecibidoPor]                    VARCHAR(100)            NULL DEFAULT NULL,
    [StrShipment]                       VARCHAR(50)             NULL DEFAULT NULL,
    [StrSello]                          VARCHAR(50)             NULL DEFAULT NULL,
    [StrR]                              VARCHAR(50)             NULL DEFAULT NULL,
    [StrContenedor]                     VARCHAR(50)             NULL DEFAULT NULL,
    [StrObservacion]                    VARCHAR(250)            NULL DEFAULT NULL,
    [EnmTipoIngreso]                    VARCHAR                 CHECK (enmTipoIngreso in ('Despacho producto','Entrada materia prima', '')),
    PRIMARY KEY CLUSTERED ([IntId])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Periferico')
CREATE TABLE [dbo].[Periferico] (
    [IntId]                             BIGINT              NOT NULL IDENTITY,
    [EnmTipoPeriferico]                 VARCHAR                 CHECK (enmTipoPeriferico in ('Bascula_Estatica','Bascula_Dinamica', '')),
    [StrIp]                             VARCHAR(50)             NULL DEFAULT NULL,
    [IntPuerto]                         BIGINT                  NULL DEFAULT NULL,
    [StrCodigo]                         VARCHAR(50)             NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([IntId])
);

-- ---------------------------- --
-- --------FOREIGN KEYS-------- --
-- ---------------------------- --

ALTER TABLE [VehiculoSobrepeso]
    ADD CONSTRAINT [FkVehiculosSobrepesoIdDinamica]
        FOREIGN KEY ([IntIdDinamica])
        REFERENCES [TransitoDinamica] ([IntIdDinamica])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Vehiculo]
    ADD CONSTRAINT [FkVehiculoIdCategoria]
        FOREIGN KEY ([IntIdCategoria])
        REFERENCES [Categoria] ([IntIdCategoria])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [RegistroVehiculo]
    ADD CONSTRAINT [FkRegistroVehiculosIdRepeso]
        FOREIGN KEY ([IntIdRepeso])
        REFERENCES [VehiculoSobrepeso] ([IntIdRepeso])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [FkRegistroVehiculosCedulaUsuario]
        FOREIGN KEY ([IntCedulaUsuario])
        REFERENCES [Usuario] ([IntCedulaUsuario])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [FkRegistroVehiculosIdMercancia]
        FOREIGN KEY ([IntIdMercancia])
        REFERENCES [Mercancia] ([IntIdMercancia])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [FkRegistroVehiculosCedulaConductor]
        FOREIGN KEY ([IntCedulaConductor])
        REFERENCES [Conductor] ([IntCedulaConductor])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [FkRegistroVehiculosIdCategoria]
        FOREIGN KEY ([IntIdCategoria])
        REFERENCES [Categoria] ([IntIdCategoria])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [FkRegistroVehiculosPlacaVehiculo]
        FOREIGN KEY ([StrPlacaVehiculo])
        REFERENCES [Vehiculo] ([StrPlacaVehiculo])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Comparendo]
    ADD CONSTRAINT [FkComparendosCedulaConductor]
        FOREIGN KEY ([IntCedulaConductor])
        REFERENCES [Conductor] ([IntCedulaConductor])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [FkComparendosTiqueteNro]
        FOREIGN KEY ([IntTiqueteNro])
        REFERENCES [RegistroVehiculo] ([IntTiqueteNro])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [FkComparendosPlacaVehiculo]
        FOREIGN KEY ([StrPlacaVehiculo])
        REFERENCES [Vehiculo] ([StrPlacaVehiculo])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [FkComparendosIdPolicia]
        FOREIGN KEY ([IntIdPolicia])
        REFERENCES [Policia] ([IntIdPolicia])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Menu]
    ADD CONSTRAINT [FkMenuBadge]
        FOREIGN KEY ([StrBadge])
        REFERENCES [Badge] ([StrTitle])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [FkMenuFather]
        FOREIGN KEY ([StrFather])
        REFERENCES [Menu] ([StrId])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;
