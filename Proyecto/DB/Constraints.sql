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

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_CategoriaProductos_Nombre')
BEGIN
    ALTER TABLE CATEGORIAPRODUCTOS
    ADD CONSTRAINT CK_CategoriaProductos_Nombre
    CHECK (LEN(nombre) > 0 AND LEN(nombre) <= 255);
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Producto_Nombre')
BEGIN
    ALTER TABLE PRODUCTOS
    ADD CONSTRAINT CK_Producto_Nombre
    CHECK (LEN(nombre) > 0 AND LEN(nombre) <= 255);
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Producto_Descripcion')
BEGIN
    ALTER TABLE PRODUCTOS
    ADD CONSTRAINT CK_Producto_Descripcion
    CHECK (LEN(nombre) <= 765);
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Producto_Precio')
BEGIN
    ALTER TABLE PRODUCTOS
    ADD CONSTRAINT CK_Producto_Precio
    CHECK (precio > 0);
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Producto_imagenURL')
BEGIN
    ALTER TABLE PRODUCTOS
    ADD CONSTRAINT CK_Producto_imagenURL
    CHECK (
    imagenURL IS NULL
    OR LTRIM(RTRIM(imagenURL)) <> ''
);
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Ingrediente_Nombre')
BEGIN
    ALTER TABLE INGREDIENTES
    ADD CONSTRAINT CK_Ingrediente_Nombre
    CHECK (LEN(nombre) > 0 AND LEN(nombre) <= 255);
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Ingrediente_Descripcion')
BEGIN
    ALTER TABLE INGREDIENTES
    ADD CONSTRAINT CK_Ingrediente_Descripcion
    CHECK (LEN(nombre) <= 765);
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_ProductosIngredientes_Cantidad')
BEGIN
    ALTER TABLE PRODUCTOSINGREDIENTES
    ADD CONSTRAINT CK_ProductosIngredientes_Cantidad
    CHECK (Cantidad > 0);
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_TipoPromocion_Nombre')
BEGIN
    ALTER TABLE TIPOPROMOCION
    ADD CONSTRAINT CK_TipoPromocion_Nombre
    CHECK (
        LEN(nombre) <= 255
        AND LTRIM(RTRIM(nombre)) <> ''
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Promociones_Nombre')
BEGIN
    ALTER TABLE PROMOCIONES
    ADD CONSTRAINT CK_Promociones_Nombre
    CHECK (
        LEN(nombre) <= 255
        AND LTRIM(RTRIM(nombre)) <> ''
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Promociones_Descripcion')
BEGIN
    ALTER TABLE PROMOCIONES
    ADD CONSTRAINT CK_Promociones_Descripcion
    CHECK (
        descripcion IS NULL
        OR LEN(descripcion) <= 765
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Promociones_Valor')
BEGIN
    ALTER TABLE PROMOCIONES
    ADD CONSTRAINT CK_Promociones_Valor
    CHECK (valor > 0);
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Promociones_Fechas')
BEGIN
    ALTER TABLE PROMOCIONES
    ADD CONSTRAINT CK_Promociones_Fechas
    CHECK (Fechafin >= Fechainicio);
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Promociones_Activo')
BEGIN
    ALTER TABLE PROMOCIONES
    ADD CONSTRAINT CK_Promociones_Activo
    CHECK (activo IN (0,1));
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Proveedores_Nombre')
BEGIN
    ALTER TABLE PROVEEDORES
    ADD CONSTRAINT CK_Proveedores_Nombre
    CHECK (
        LEN(nombre) <= 255
        AND LTRIM(RTRIM(nombre)) <> ''
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Proveedores_Contacto')
BEGIN
    ALTER TABLE PROVEEDORES
    ADD CONSTRAINT CK_Proveedores_Contacto
    CHECK (
        LEN(contacto) <= 255
        AND LTRIM(RTRIM(contacto)) <> ''
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Proveedores_Telefono')
BEGIN
    ALTER TABLE PROVEEDORES
    ADD CONSTRAINT CK_Proveedores_Telefono
    CHECK (
        telefono IS NULL
        OR (
            LEN(telefono) <= 20
            AND LTRIM(RTRIM(telefono)) <> ''
        )
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Proveedores_Email')
BEGIN
    ALTER TABLE PROVEEDORES
    ADD CONSTRAINT CK_Proveedores_Email
    CHECK (
        LEN(email) <= 255
        AND LTRIM(RTRIM(email)) <> ''
        AND email LIKE '%@%.%'
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Inventario_CantidadDisponible')
BEGIN
    ALTER TABLE INVENTARIO
    ADD CONSTRAINT CK_Inventario_CantidadDisponible
    CHECK (cantidaddisponible >= 0);
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_ObjetoTipo_Nombre')
BEGIN
    ALTER TABLE OBJETOTIPO
    ADD CONSTRAINT CK_ObjetoTipo_Nombre
    CHECK (
        LEN(nombre) <= 255
        AND LTRIM(RTRIM(nombre)) <> ''
    );
END


IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Historico_Accion')
BEGIN
    ALTER TABLE HISTORICO
    ADD CONSTRAINT CK_Historico_Accion
    CHECK (
        LEN(accion) <= 255
        AND LTRIM(RTRIM(accion)) <> ''
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Historico_Descripcion')
BEGIN
    ALTER TABLE HISTORICO
    ADD CONSTRAINT CK_Historico_Descripcion
    CHECK (
        LEN(descripcion) <= 765
        AND LTRIM(RTRIM(descripcion)) <> ''
    );
END



IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Logs_Accion')
BEGIN
    ALTER TABLE LOGS
    ADD CONSTRAINT CK_Logs_Accion
    CHECK (
        LEN(accion) <= 255
        AND LTRIM(RTRIM(accion)) <> ''
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Logs_TablaAfectada')
BEGIN
    ALTER TABLE LOGS
    ADD CONSTRAINT CK_Logs_TablaAfectada
    CHECK (
        LEN(tablaafectada) <= 255
        AND LTRIM(RTRIM(tablaafectada)) <> ''
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Logs_Descripcion')
BEGIN
    ALTER TABLE LOGS
    ADD CONSTRAINT CK_Logs_Descripcion
    CHECK (
        LEN(descripcion) <= 765
        AND LTRIM(RTRIM(descripcion)) <> ''
    );
END





IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Calificaciones_Puntuacion')
BEGIN
    ALTER TABLE CALIFICACIONES
    ADD CONSTRAINT CK_Calificaciones_Puntuacion
    CHECK (puntuacion >= 0 AND puntuacion <= 10);
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Calificaciones_Comentario')
BEGIN
    ALTER TABLE CALIFICACIONES
    ADD CONSTRAINT CK_Calificaciones_Comentario
    CHECK (
        LEN(comentario) <= 255
        AND LTRIM(RTRIM(comentario)) <> ''
    );
END

IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_Calificaciones_Fecha')
BEGIN
    ALTER TABLE CALIFICACIONES
    ADD CONSTRAINT CK_Calificaciones_Fecha
    CHECK (fecha <= GETDATE());
END
