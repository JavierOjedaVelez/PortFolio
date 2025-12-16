-- Modulo RRHH
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'TIPOFICHAJE' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE TIPOFICHAJE (
        IdTipo INT IDENTITY(1,1) PRIMARY KEY,
        nombre NVARCHAR(255) NOT NULL
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'FICHAJE' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE FICHAJE (
        IdFichaje INT IDENTITY(1,1) PRIMARY KEY,
        fechahoraentrada DATETIME NOT NULL,
        fechahorasalida DATETIME DEFAULT NULL,
        IdUsuario INT NOT NULL,
        IdTipo INT NOT NULL
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'NOMINAS' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE NOMINAS (
        IdNomina INT IDENTITY(1,1) PRIMARY KEY,
        mes NVARCHAR(20) NOT NULL,
        año INT NOT NULL,
        salariobase DECIMAL(10,2) NOT NULL DEFAULT 0.00,
        bonos NVARCHAR(255) DEFAULT NULL,
        deducciones DECIMAL(10,2) NOT NULL DEFAULT 0.00,
        total DECIMAL(10,2) NOT NULL DEFAULT 0.00,
        IdUsuario INT NOT NULL
    );
END
GO
