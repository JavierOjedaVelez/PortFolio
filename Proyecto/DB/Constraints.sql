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


IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Usuarios_PasswordHash')
BEGIN
    ALTER TABLE USUARIOS
    ADD CONSTRAINT CK_Usuarios_PasswordHash
    CHECK (LEN(PasswordHash) > 0);
END


--CHECKS MODULO RESTAURANTES

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Restaurantes_Nombre')
BEGIN
    ALTER TABLE RESTAURANTES
    ADD CONSTRAINT CK_Restaurantes_Nombre
    CHECK (LEN(Nombre) > 0 AND LEN(Nombre) <= 255);
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Restaurantes_Direccion')
BEGIN
    ALTER TABLE RESTAURANTES
    ADD CONSTRAINT CK_Restaurantes_Direccion
    CHECK (LEN(Direccion) > 0 AND LEN(Direccion) <= 510);
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Restaurantes_TelefonoFormato')
BEGIN
    ALTER TABLE RESTAURANTES
    ADD CONSTRAINT CK_Restaurantes_TelefonoFormato
    CHECK (Telefono LIKE '+%' AND Telefono NOT LIKE '%[^0-9+ ()-]%');
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Restaurantes_CapacidadTotal')
BEGIN
    ALTER TABLE RESTAURANTES
    ADD CONSTRAINT CK_Restaurantes_CapacidadTotal
    CHECK (CapacidadTotal > 0);
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Mesas_Numero')
BEGIN
    ALTER TABLE MESAS
    ADD CONSTRAINT CK_Mesas_Numero
    CHECK (Numero > 0);
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Mesas_Capacidad')
BEGIN
    ALTER TABLE MESAS
    ADD CONSTRAINT CK_Mesas_Capacidad
    CHECK (Capacidad > 0);
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Mesas_QRLength')
BEGIN
    ALTER TABLE MESAS
    ADD CONSTRAINT CK_Mesas_QRLength
    CHECK (LEN(codQR) > 0);
END


IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Horarios_HorasValidas')
BEGIN
    ALTER TABLE HORARIOSTRABAJADOR
    ADD CONSTRAINT CK_Horarios_HorasValidas
    CHECK (horaentrada >= '00:00' AND horaentrada <= '23:59:59'
           AND HoraSalida >= '00:00' AND HoraSalida <= '23:59:59');
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Horarios_EntradaMenorSalida')
BEGIN
    ALTER TABLE HORARIOSTRABAJADOR
    ADD CONSTRAINT CK_Horarios_EntradaMenorSalida
    CHECK (HoraSalida > horaentrada);
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Horarios_DiaSemana')
BEGIN
    ALTER TABLE HORARIOSTRABAJADOR
    ADD CONSTRAINT CK_Horarios_DiaSemana
    CHECK (diaSemana >= 1 AND diaSemana <= 7);
END

--CHECKS  PEDIDOS Y RESERVAS

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_CategoriasPedidos_Nombre')
BEGIN
    ALTER TABLE CATEGORIAPEDIDOS
    ADD CONSTRAINT CK_CategoriasPedidos_Nombre
    CHECK (LEN(nombre) > 0 AND LEN(nombre) <= 255);
END


IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_EstadoPedidos_Nombre')
BEGIN
    ALTER TABLE ESTADOPEDIDO
    ADD CONSTRAINT CK_EstadoPedidos_Nombre
    CHECK (LEN(nombre) > 0 AND LEN(nombre) <= 255);
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Pedidos_Total')
BEGIN
    ALTER TABLE PEDIDOS
    ADD CONSTRAINT CK_Pedidos_Total
    CHECK (total > 0);
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_DetallePedidos_Cantidad')
BEGIN
    ALTER TABLE DETALLEPEDIDOS
    ADD CONSTRAINT CK_DetallePedidos_Cantidad
    CHECK (cantidad > 0);
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_DetallePedidos_PrecioUnitario')
BEGIN
    ALTER TABLE DETALLEPEDIDOS
    ADD CONSTRAINT CK_DetallePedidos_PrecioUnitario
    CHECK (precioUnitario > 0);
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_EstadoReservas_Nombre')
BEGIN
    ALTER TABLE ESTADOSRESERVAS
    ADD CONSTRAINT CK_EstadoReservas_Nombre
    CHECK (LEN(nombre) > 0 AND LEN(nombre) <= 255);
END