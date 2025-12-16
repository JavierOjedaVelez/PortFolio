-- Modulo Inventario y Proveedores
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'PROVEEDORES' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE PROVEEDORES (
        IdProveedor INT IDENTITY(1,1) PRIMARY KEY,
        nombre NVARCHAR(255) NOT NULL,
        contacto NVARCHAR(255) NOT NULL,
        telefono NVARCHAR(20),
        email NVARCHAR(255) NOT NULL
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'INVENTARIO' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE INVENTARIO (
        IdInventario INT IDENTITY(1,1) PRIMARY KEY,
        cantidaddisponible INT NOT NULL,
        fechaactualicacion DATETIME NOT NULL,
        IdIngrediente INT NOT NULL,
        IdRestaurante INT NOT NULL
    );
END
GO
