-- Modulo Pedidos y Reservas
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'CATEGORIAPEDIDOS' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE CATEGORIAPEDIDOS (
        IdCategoria INT IDENTITY(1,1) PRIMARY KEY,
        nombre NVARCHAR(255) NOT NULL
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'ESTADOPEDIDO' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE ESTADOPEDIDO (
        IdEstado INT IDENTITY(1,1) PRIMARY KEY,
        nombre NVARCHAR(255) NOT NULL
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'PEDIDOS' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE PEDIDOS (
        IdPedido INT IDENTITY(1,1) PRIMARY KEY,
        fechacreacion DATETIME NOT NULL DEFAULT GETDATE(),
        total DECIMAL(18,2) NOT NULL DEFAULT 0.00,
        IdUsuario INT NOT NULL,
        IdMesa INT DEFAULT NULL,
        IdEstado INT NOT NULL
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'DETALLEPEDIDOS' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE DETALLEPEDIDOS (
        IdPedido INT NOT NULL,
        IdProducto INT NOT NULL,
        cantidad INT NOT NULL,
        precioUnitario DECIMAL(18,2) NOT NULL DEFAULT 0.00,
        PRIMARY KEY (IdProducto, IdPedido)
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'ESTADOSRESERVAS' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE ESTADOSRESERVAS(
        IdEstado INT IDENTITY(1,1) PRIMARY KEY,
        nombre NVARCHAR(255) NOT NULL
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'RESERVAS' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE RESERVAS (
        IdReserva INT IDENTITY(1,1) PRIMARY KEY,
        fechareserva DATETIME NOT NULL,
        IdUsuario INT NOT NULL,
        IdMesa INT NOT NULL,
        IdEstado INT NOT NULL
    );
END
GO