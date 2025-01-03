--Proyecto Ecommerce .NET
--CREATE DATABASE DBEcommerce;

USE DBEcommerce;

CREATE TABLE Categoria(
IdCategoria int primary key identity,
Nombre varchar(50),
FechaCreacion datetime default GetDate()
);

CREATE TABLE Producto(
IdProducto int primary key identity,
Nombre varchar(50),
Descripcion varchar(1000),
IdCategoria int references Categoria(IdCategoria), -- llave foranea
Precio decimal(10,2),
PrecioOferta decimal (10,2),
Cantidad int,
Imagen varchar(max),
FechaCreacion datetime default GetDate()
);

CREATE TABLE Usuario(
IdUsuario int primary key identity,
Nombre varchar (50),
ApellidoMaterno varchar (50),
ApellidoPaterno varchar (50),
Correo varchar(50),
Clave varchar(50),
Rol varchar(50),
FechaCreacion datetime default GetDate()
);

CREATE TABLE Venta(
IdVenta int primary key identity,
IdUsuario int references Usuario(IdUsuario),
Total decimal(10,2),
FechaCreacion datetime default GetDate()
);

CREATE TABLE DetalleVenta(
IdDetalleVenta int primary key identity,
IdVenta int references Venta(IdVenta),
IdProducto int references Producto(IdProducto),
Cantidad int,
Total decimal(10,2)
);

Insert into Usuario(Nombre,ApellidoMaterno,ApellidoPaterno,Correo,Clave,Rol)Values
('Admin','Sistema','Ecommerce','admin@example.com','123','Administrador');

SELECT * FROM Usuario;