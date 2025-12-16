-- Modulo Pagos y Facturacion
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'METODOSPAGOS' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE METODOSPAGOS (
        IdMetodo INT IDENTITY(1,1) PRIMARY KEY,
        nombre NVARCHAR(255) NOT NULL
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'ESTADOPAGO' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE ESTADOPAGO (
        IdEstado INT IDENTITY(1,1) PRIMARY KEY,
        nombre NVARCHAR(255) NOT NULL
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'PAGOS' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE PAGOS (
        IdPago INT IDENTITY(1,1) PRIMARY KEY,
        monto DECIMAL(10,2) NOT NULL,
        referenciaExterna NVARCHAR(255) NOT NULL,
        IdEstado INT NOT NULL,
        IdPedido INT NOT NULL,
        IdMetodo INT NOT NULL
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'TIPOIMPUESTO' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE TIPOIMPUESTO (
        IdImpuesto INT IDENTITY(1,1) PRIMARY KEY,
        nombre NVARCHAR(255) NOT NULL,
        porcentaje DECIMAL(5,2) NOT NULL
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'FACTURAS' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE FACTURAS (
        IdFactura INT IDENTITY(1,1) PRIMARY KEY,
        totalbruto DECIMAL(10,2) NOT NULL DEFAULT 0.00,
        totalretenido DECIMAL(10,2) NOT NULL DEFAULT 0.00,
        IdPedido INT NOT NULL,
        IdPago INT NOT NULL,
        IdImpuesto INT NOT NULL
    );
END
GO