# Nombre del Proyecto
Api rest con C# para la tabla de usuarios 
desarrollada con la base de datos MySql y Dapper.

## Características
- La api contiene los metodos crud
  consultar, guardar, modificar y eliminar
- La api ha sido desarrollada con Dapper de C#.

## Tecnologías usadas
- C#
- .NET 8
- Dapper
- MySQL 


Endpoints (si es un API)

POST
/api/Auth/login

GET
/api/Usuarios

POST
/api/Usuarios

GET
/api/Usuarios/{id}

PUT
/api/Usuarios/{id}

DELETE
/api/Usuarios/{id}



Base de datos utilizada ABank en MySql

Tabla Usuarios
CREATE TABLE `usuarios` (
  `id` int(11) NOT NULL AUTOINCREMENT,
  `nombres` varchar(100) DEFAULT NULL,
  `apellidos` varchar(100) DEFAULT NULL,
  `fechanacimiento` date DEFAULT NULL,
  `direccion` varchar(200) DEFAULT NULL,
  `password` varchar(50) DEFAULT NULL,
  `Telefono` varchar(10) DEFAULT NULL,
  `Email` varchar(50) DEFAULT NULL,
  `Estado` varchar(1) DEFAULT NULL,
  `FechaCreacion` date DEFAULT curdate(),
  `FechaModificacion` date DEFAULT NULL
);

INSERT INTO `usuarios` (`id`, `nombres`, `apellidos`, `fechanacimiento`, `direccion`, `password`, `Telefono`, `Email`, `Estado`, `FechaCreacion`, `FechaModificacion`) VALUES
(1, 'SALVADOR ', 'OLIVARES', '1970-10-30', 'SAN SALVADOR', '123456', '78528701', 'salvador@gmail.com', 'A', '2025-11-26', NULL),
(2, 'VERONICA', 'MONGE', '1975-02-23', 'SAN SALVADOR', '123456', '78412272', 'veronica@gmail.com', 'A', '2025-11-26', NULL);