
-- Creacion De Base De Datos
-- Sistema de punto de venta (SPV)
-- -----------------------------------------------------------
CREATE DATABASE `SPV`;
USE `SPV`;


-- Tabla Genero
-- -----------------------------------------------------------
CREATE TABLE `Genero` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `sexo` ENUM('Masculino', 'Femenimo'),
  PRIMARY KEY (`id`)
)ENGINE=InnoDB DEFAULT CHARSET=utf8;


-- Tabla Empledos
-- -----------------------------------------------------------
CREATE TABLE `Empleado` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(50) NOT NULL,
  `apellido` VARCHAR(50) NOT NULL,
  `idGenero` INT NOT NULL,
  `correoElectronico` VARCHAR(50) NOT NULL UNIQUE,
  `noTelefono` VARCHAR(10) DEFAULT  0,
  `noCelular` VARCHAR(10) NOT NULL,
  `direccion` VARCHAR(150) NOT NULL,
  `noDPI` VARCHAR(13) NOT NULL,
  `noNit` VARCHAR(10) NOT NULL UNIQUE,
  `fechaDeNacimiento` DATE NOT NULL,
  `fechaIngreso` DATE NOT NULL,
  `estado` INT DEFAULT  1,
  PRIMARY KEY (`id`),
  FOREIGN KEY (`idGenero`) REFERENCES `Genero`(`id`)
)ENGINE=InnoDB DEFAULT CHARSET=utf8;


-- Tabla Usuario
-- -----------------------------------------------------------
CREATE TABLE `Usuario` (
  `idEmpleado` INT NOT NULL,
  `nombre` VARCHAR(30) NOT NULL UNIQUE,
  `clave` VARCHAR(50) NOT NULL,
  `sal` VARCHAR(30) NOT NULL,
  `estado` INT DEFAULT 1,
  PRIMARY KEY (`idEmpleado`),
  FOREIGN KEY (`idEmpleado`) REFERENCES `Empleado`(`id`)
)ENGINE=InnoDB DEFAULT CHARSET=utf8;


-- Tabla Rol
-- -----------------------------------------------------------
CREATE TABLE `Rol` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(30) NOT NULL ,
  PRIMARY KEY (`id`)
)ENGINE=InnoDB DEFAULT CHARSET=utf8;


-- Tabla RolEmpleado
-- -----------------------------------------------------------
CREATE TABLE `RolEmpleado` (
  `idRol` INT NOT NULL,
  `idEmpleado` INT NOT NULL,
  PRIMARY KEY (`idRol`,`idEmpleado`),
  FOREIGN KEY (`idEmpleado`) REFERENCES `Empleado`(`id`),
  FOREIGN KEY (`idRol`) REFERENCES `Rol`(`id`)
)ENGINE=InnoDB DEFAULT CHARSET=utf8;


-- Tabla Cliente 
-- -----------------------------------------------------------
CREATE TABLE `Cliente` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(50) NOT NULL,
  `noNit` VARCHAR(10) NOT NULL UNIQUE,
  `noTelefono` VARCHAR(10) NOT NULL,
  `correoElectronico` VARCHAR(50) NOT NULL UNIQUE,
  `direccion` VARCHAR(150) NOT NULL,
  `estado` INT DEFAULT  1,
  PRIMARY KEY (`id`)
)ENGINE=InnoDB DEFAULT CHARSET=utf8;


-- Tabla Proveedor
-- -----------------------------------------------------------
CREATE TABLE `Proveedor` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(50) NOT NULL,
  `noTelefono` VARCHAR(10) NOT NULL,
  `noNit` VARCHAR(10) NOT NULL UNIQUE,
  `correoElectronico` VARCHAR(50) NOT NULL UNIQUE,
  `direccion` VARCHAR(150) NOT NULL,
  `estado` INT DEFAULT  1,
  PRIMARY KEY (`id`)
)ENGINE=InnoDB DEFAULT CHARSET=utf8;


-- Tabla Categoria
-- -----------------------------------------------------------
CREATE TABLE `Categoria` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`id`)
)ENGINE=InnoDB DEFAULT CHARSET=utf8;


-- Tabla Producto
-- -----------------------------------------------------------
CREATE TABLE `Producto` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(150) NOT NULL,
  `descripcion` VARCHAR(500) NOT NULL,
  `marca` VARCHAR(50) NOT NULL,
  `idCategoria` INT NOT NULL,
  `idProveedor` INT NOT NULL,
  `fechaDeVencimiento` DATE NOT NULL,
  `estado` INT DEFAULT  1,
  PRIMARY KEY (`id`),
  FOREIGN KEY (`idCategoria`) REFERENCES `Categoria`(`id`),
  FOREIGN KEY (`idProveedor`) REFERENCES `Proveedor`(`id`)
)ENGINE=InnoDB DEFAULT CHARSET=utf8;


-- Tabla Factura
-- -----------------------------------------------------------
CREATE TABLE `Factura` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `serie` VARCHAR(5) NOT NULL,
  `numero` VARCHAR(10) NOT NULL,
  `fecha` DATE NOT NULL,
  `estado` INT DEFAULT 1,
  PRIMARY KEY (`id`)
)ENGINE=InnoDB DEFAULT CHARSET=utf8;


-- Tabla Venta
-- -----------------------------------------------------------
CREATE TABLE `Venta` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `idFactura` INT NOT NULL UNIQUE,
  `idCliente` INT NOT NULL,
  `idEmpleado` INT NOT NULL,
  `precioTota` DECIMAL(10,2) NOT NULL,
  PRIMARY KEY (`id`),
  FOREIGN KEY (`idFactura`) REFERENCES `Factura`(`id`),
  FOREIGN KEY (`idCliente`) REFERENCES `Cliente`(`id`),
  FOREIGN KEY (`idEmpleado`) REFERENCES `Empleado`(`id`)
)ENGINE=InnoDB DEFAULT CHARSET=utf8;


-- Tabla Detalle Venta
-- -----------------------------------------------------------
CREATE TABLE `DetalleVenta` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `idVenta` INT NOT NULL,
  `idProducto` INT NOT NULL,
  `cantidad` INT NOT NULL,
  `precioCantidad` DECIMAL(10,2)  NOT NULL,
  PRIMARY KEY (`id`),
  FOREIGN KEY (`idVenta`) REFERENCES `Venta`(`id`),
  FOREIGN KEY (`idProducto`) REFERENCES `Producto`(`id`)
)ENGINE=InnoDB DEFAULT CHARSET=utf8;


-- Tabla Detalle Venta
-- -----------------------------------------------------------
CREATE TABLE `Inventario` (
  `idProducto` INT NOT NULL,
  `cantidad` INT NOT NULL,
  `precio` DECIMAL(10,2) NOT NULL,
  `iva` INT DEFAULT 12,
  PRIMARY KEY (`idProducto`),
  FOREIGN KEY (`idProducto`) REFERENCES `Producto`(`id`)
)ENGINE=InnoDB DEFAULT CHARSET=utf8;


-- Tabla Compra
-- -----------------------------------------------------------
CREATE TABLE `Compra` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `idProveedor` INT NOT NULL,
  `idEmpleado` INT NOT NULL,
  `numeroFactura` VARCHAR(15) NOT NULL,
  `fecha` DATE NOT NULL,
  `precioTotal` DECIMAL(10,2) NOT NULL,
  PRIMARY KEY (`id`),
  FOREIGN KEY (`idProveedor`) REFERENCES `Proveedor`(`id`),
  FOREIGN KEY (`idEmpleado`) REFERENCES `Empleado`(`id`)
)ENGINE=InnoDB DEFAULT CHARSET=utf8;


-- Tabla Detalle Compras
-- -----------------------------------------------------------
CREATE TABLE `DetalleCompras` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `idCompra` INT NOT NULL,
  `idProducto` INT NOT NULL,
  `cantidad` INT NOT NULL,
  `precioCantidad` DECIMAL(10,2) NOT NULL,
  `iva` INT DEFAULT 12,
  PRIMARY KEY (`id`),
  FOREIGN KEY (`idCompra`) REFERENCES `Compra`(`id`),
  FOREIGN KEY (`idProducto`) REFERENCES `Producto`(`id`)
)ENGINE=InnoDB DEFAULT CHARSET=utf8;















