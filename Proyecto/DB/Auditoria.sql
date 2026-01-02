
-- Modulo Auditoria y Valoraciones
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'OBJETOTIPO' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE OBJETOTIPO (
        IdTipo INT IDENTITY(1,1) PRIMARY KEY,
        nombre NVARCHAR(255) NOT NULL
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'HISTORICO' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE HISTORICO (
        IdHistorico INT IDENTITY(1,1) PRIMARY KEY,
        IdTipoObjeto INT NOT NULL,
        accion NVARCHAR(255) NOT NULL,
        fecha DATETIME NOT NULL,
        descripcion NVARCHAR(765) NOT NULL
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'LOGS' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE LOGS (
        IdLog INT IDENTITY(1,1) PRIMARY KEY,
        accion NVARCHAR(255) NOT NULL,
        tablaafectada NVARCHAR(255) NOT NULL,
        fecha DATETIME NOT NULL,
        descripcion NVARCHAR(765) NOT NULL,
        IdUsuario INT NOT NULL
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'CALIFICACIONES' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE CALIFICACIONES (
        IdCalificacion INT IDENTITY(1,1) PRIMARY KEY,
        IdUsuario INT NOT NULL,
        IdProducto INT NOT NULL,
        puntuacion DECIMAL(10,2) NOT NULL DEFAULT 0.00,
        comentario NVARCHAR(255) NOT NULL,
        fecha DATETIME NOT NULL
    );
END
GO