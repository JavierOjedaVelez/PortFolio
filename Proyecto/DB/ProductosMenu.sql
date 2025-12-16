-- Modulo Productos y Menu
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'CATEGORIAPRODUCTOS' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE CATEGORIAPRODUCTOS (
        IdCategoriaProducto INT IDENTITY(1,1) PRIMARY KEY,
        nombre NVARCHAR(255) NOT NULL
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'PRODUCTOS' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE PRODUCTOS (
        IdProducto INT IDENTITY(1,1) PRIMARY KEY,
        nombre NVARCHAR(255) NOT NULL,
        descripcion NVARCHAR(MAX) DEFAULT NULL,
        precio DECIMAL(18,2) NOT NULL DEFAULT 0.00,
        imagenURL NVARCHAR(255) DEFAULT NULL,
        IdCategoriaProducto INT NOT NULL
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'INGREDIENTES' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE INGREDIENTES (
        IdIngrediente INT IDENTITY(1,1) PRIMARY KEY,
        nombre NVARCHAR(255) NOT NULL,
        descripcion NVARCHAR(MAX) NOT NULL,
        IdProveedor INT NOT NULL
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'PRODUCTOSINGREDIENTES' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE PRODUCTOSINGREDIENTES (
        IdProducto INT NOT NULL,
        IdIngrediente INT NOT NULL,
        Cantidad DECIMAL(18,2) NOT NULL,
        PRIMARY KEY (IdProducto, IdIngrediente)
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'TIPOPROMOCION' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE TIPOPROMOCION (
        IdTipo INT IDENTITY(1,1) PRIMARY KEY,
        nombre NVARCHAR(255) NOT NULL
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'PROMOCIONES' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE PROMOCIONES (
        IdPromocion INT IDENTITY(1,1) PRIMARY KEY,
        nombre NVARCHAR(255) NOT NULL,
        descripcion NVARCHAR(MAX) DEFAULT NULL,
        IdTipo INT NOT NULL,
        valor DECIMAL(18,2) NOT NULL,
        fechainicio DATETIME NOT NULL,
        Fechafin DATETIME NOT NULL,
        activo BIT NOT NULL
    );
END
GO