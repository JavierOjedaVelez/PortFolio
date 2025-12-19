-- Crear base de datos si no existe
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'restaurante')
BEGIN
    CREATE DATABASE restaurante;
END
GO

USE restaurante;
GO

:r .\Usuarios.sql;
:r .\Restaurantes.sql;
:r .\PedidosReservas.sql;
:r .\ProductosMenu.sql;
:r .\Inventario.sql;
:r .\Auditoria.sql;
:r .\RRHH.sql;
:r .\Facturacion.sql;
:r .\Relaciones.sql;
:r .\Constraints.sql;
