CREATE DATABASE StoreDB;
GO

USE StoreDB;
GO

-- Clientes
CREATE TABLE Clientes (
    ClienteId int PRIMARY KEY IDENTITY(1,1),
    Nombre varchar(100) NOT NULL,
    Apellidos varchar(100) NOT NULL,
    Direccion varchar(200),
    Email varchar(100) NOT NULL,        -- nuevo campo para login
    PasswordHash varchar(200) NOT NULL  -- nuevo campo para login
);
GO

-- Tiendas
CREATE TABLE Tiendas (
    TiendaId int PRIMARY KEY IDENTITY(1,1),
    Sucursal varchar(100) NOT NULL,
    Direccion varchar(200)
);
GO

-- Artículos
CREATE TABLE Articulos (
    ArticuloId int PRIMARY KEY IDENTITY(1,1),
    Codigo varchar(50) NOT NULL,
    Descripcion varchar(200),
    Precio decimal(10,2) NOT NULL,
    Imagen varchar(200),
    Stock int NOT NULL
);
GO

-- Relación Artículo - Tienda
CREATE TABLE ArticulosTiendas (
    Id int PRIMARY KEY IDENTITY(1,1),
    ArticuloId int NOT NULL FOREIGN KEY REFERENCES Articulos(ArticuloId),
    TiendaId int NOT NULL FOREIGN KEY REFERENCES Tiendas(TiendaId),
    Fecha datetime NOT NULL DEFAULT GETDATE()
);
GO

-- Relación Cliente - Artículo (compra)
CREATE TABLE ClientesArticulos (
    Id int PRIMARY KEY IDENTITY(1,1),
    ClienteId int NOT NULL FOREIGN KEY REFERENCES Clientes(ClienteId),
    ArticuloId int NOT NULL FOREIGN KEY REFERENCES Articulos(ArticuloId),
    Fecha datetime NOT NULL DEFAULT GETDATE()
);
GO

-- Insertar un cliente para poder loguearse al proyecto
-- Email: el correo con el que iniciarás sesión.
-- PasswordHash: contiene el hash generado de la contraseña (no la contraseña directa).
-- Para probar, cuando hagas login desde Angular pon:
-- Email: carlos.perez@example.com
-- Password: 123456
INSERT INTO Clientes (Nombre, Apellidos, Direccion, Email, PasswordHash)
VALUES 
(
    'Carlos',
    'Pérez López',
    'Av. Siempre Viva 742',
    'carlos.perez@example.com',
    '$2a$12$gETcrurRgueSDj.lXfhBCebKpqhootxT3uQMYd5aW.B/hoxfOECVC' -- contraseña = 123456
);
GO
