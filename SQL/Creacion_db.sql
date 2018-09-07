CREATE DATABASE VirtualidadReal

USE VirtualidadReal
CREATE TABLE Usuarios(
Id INT PRIMARY KEY IDENTITY(1,1),
Nombre NVARCHAR(20) NOT NULL,
Apellido NVARCHAR(20)NOT NULL,
Direccion NVARCHAR(50)NOT NULL,
Telefono NVARCHAR(15) NOT NULL,
Correo NVARCHAR(50))

CREATE TABLE Nivel(
Id INT PRIMARY KEY IDENTITY(1,1),
UsuarioId INT FOREIGN KEY REFERENCES Usuarios(Id),
Nivel INT NOT NULL,
Descripcion NVARCHAR(50) NOT NULL)

CREATE TABLE Acciones(
Id INT PRIMARY KEY IDENTITY(1,1),
Nombre NVARCHAR(20) NOT NULL,
Descripcion NVARCHAR(50) NOT NULL)

CREATE TABLE UsuarioAccion(
Id INT PRIMARY KEY IDENTITY(1,1),
UsuarioId INT FOREIGN KEY REFERENCES Usuarios(Id),
AccionId INT FOREIGN KEY REFERENCES Acciones(Id),
Tiempo DATETIME NOT NULL,
NivelId INT FOREIGN KEY REFERENCES Nivel (ID))

