-- Modulo Usuarios

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'ROLES' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE ROLES (
        IdRol INT IDENTITY(1,1) PRIMARY KEY,
        Nombre NVARCHAR(255) NOT NULL
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'USUARIOS' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE USUARIOS (
        IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
        Nombre NVARCHAR(255) NOT NULL,
        Apellidos NVARCHAR(255) NOT NULL,
        Email NVARCHAR(255) NOT NULL UNIQUE,
        Telefono NVARCHAR(50) NOT NULL,
        FechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
        PasswordHash NVARCHAR(510) NOT NULL,
        IdRol INT NOT NULL
    );
END


GO