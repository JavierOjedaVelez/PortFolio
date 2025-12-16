-- Modulo Restaurantes
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'RESTAURANTES' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE RESTAURANTES (
        IdRestaurante INT IDENTITY(1,1) PRIMARY KEY,
        Nombre NVARCHAR(255) NOT NULL,
        Direccion NVARCHAR(510) NOT NULL,
        Telefono NVARCHAR(50) NOT NULL,
        CapacidadTotal INT NOT NULL
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'MESAS' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE MESAS (
        IdMesa INT IDENTITY(1,1) PRIMARY KEY,
        Numero INT NOT NULL,
        Capacidad INT NOT NULL,
        codQR NVARCHAR(255) DEFAULT NULL,
        IdRestaurante INT NOT NULL
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'HORARIOSTRABAJADOR' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE HORARIOSTRABAJADOR (
        IdHorario INT IDENTITY(1,1) PRIMARY KEY,
        diaSemana INT NOT NULL,
        horaentrada TIME NOT NULL,
        HoraSalida TIME NOT NULL,
        IdUsuario INT NOT NULL
    );
END
GO