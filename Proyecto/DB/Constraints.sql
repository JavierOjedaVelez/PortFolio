-- Agregar constraints
GO 
IF NOT EXISTS (
    SELECT 1
    FROM sys.objects AS o
    JOIN sys.schemas AS s ON o.schema_id = s.schema_id
    WHERE o.type = 'UQ' 
      AND o.name = 'UQ_MesaNumero_Restaurante'
      AND s.name = 'dbo'
)
BEGIN
    ALTER TABLE MESAS
    ADD CONSTRAINT UQ_MesaNumero_Restaurante UNIQUE (IdRestaurante, Numero);
END



IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Roles_NombreLength')
BEGIN
    ALTER TABLE ROLES
    ADD CONSTRAINT CK_Roles_NombreLength
    CHECK (LEN(nombre) > 0 AND LEN(nombre) <= 255);
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Usuarios_NombreLength')
BEGIN
    ALTER TABLE USUARIOS
    ADD CONSTRAINT CK_Usuarios_NombreLength
    CHECK (LEN(Nombre) > 0 AND LEN(Nombre) <= 255);
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Usuarios_ApellidosLength')
BEGIN
    ALTER TABLE USUARIOS
    ADD CONSTRAINT CK_Usuarios_ApellidosLength
    CHECK (LEN(Apellidos) > 0 AND LEN(Apellidos) <= 255);
END


IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Usuarios_EmailFormato')
BEGIN
    ALTER TABLE USUARIOS
    ADD CONSTRAINT CK_Usuarios_EmailFormato
    CHECK (Email LIKE '%_@_%._%');
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Usuarios_TelefonoFormato')
BEGIN
    ALTER TABLE USUARIOS
    ADD CONSTRAINT CK_Usuarios_TelefonoFormato
    CHECK (Telefono LIKE '+%' AND Telefono NOT LIKE '%[^0-9+ ()-]%');
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Usuarios_FechaRegistro')
BEGIN
    ALTER TABLE USUARIOS
    ADD CONSTRAINT CK_Usuarios_FechaRegistro
    CHECK (FechaRegistro <= GETDATE());
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Usuarios_PasswordHash')
BEGIN
    ALTER TABLE USUARIOS
    ADD CONSTRAINT CK_Usuarios_PasswordHash
    CHECK (LEN(PasswordHash) > 0);
END
