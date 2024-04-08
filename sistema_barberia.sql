-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 08, 2024 at 03:34 AM
-- Server version: 10.4.27-MariaDB
-- PHP Version: 8.1.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `sistema_barberia`
--

-- --------------------------------------------------------

--
-- Table structure for table `cliente`
--

CREATE TABLE `cliente` (
  `Id_Cliente` int(11) NOT NULL,
  `Cliente` varchar(50) NOT NULL,
  `Telefono` varchar(9) NOT NULL,
  `Correo` varchar(20) NOT NULL,
  `Deleted_at` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `empleado`
--

CREATE TABLE `empleado` (
  `Id_Empleado` int(11) NOT NULL,
  `Nombre` varchar(50) NOT NULL,
  `Apellido` varchar(50) NOT NULL,
  `Telefono` varchar(9) NOT NULL,
  `Correo` varchar(20) NOT NULL,
  `Direccion` varchar(100) NOT NULL,
  `Dui` varchar(10) NOT NULL,
  `Contraseña` varchar(20) NOT NULL,
  `Estado` varchar(20) NOT NULL,
  `Id_Rol` int(11) NOT NULL,
  `Id_Sucursal` int(11) NOT NULL,
  `Deleted_at` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `movimiento`
--

CREATE TABLE `movimiento` (
  `Id_Movimiento` int(11) NOT NULL,
  `Precio_Total` decimal(18,2) NOT NULL,
  `Cantidad_Total` int(11) NOT NULL,
  `Observacion` varchar(100) NOT NULL,
  `Tipo_Movimiento` varchar(10) NOT NULL,
  `Usuario` varchar(50) NOT NULL,
  `Id_Cliente` int(11) DEFAULT NULL,
  `Deleted_at` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `movimiento_producto`
--

CREATE TABLE `movimiento_producto` (
  `Id_Movimiento_Producto` int(11) NOT NULL,
  `Precio` decimal(18,2) NOT NULL,
  `Cantidad` int(11) NOT NULL,
  `SubTotal` decimal(18,2) NOT NULL,
  `Id_Sucursal_Producto` int(11) NOT NULL,
  `Id_Movimiento` int(11) NOT NULL,
  `Deleted_at` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `producto`
--

CREATE TABLE `producto` (
  `Id_Producto` int(11) NOT NULL,
  `Producto` varchar(50) NOT NULL,
  `Descripcion` varchar(100) NOT NULL,
  `Precio` decimal(18,2) NOT NULL,
  `Tipo` int(11) NOT NULL,
  `Deleted_at` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `rol`
--

CREATE TABLE `rol` (
  `Id_Rol` int(11) NOT NULL,
  `Nombre` varchar(20) NOT NULL,
  `Descripcion` varchar(100) NOT NULL,
  `Deleted_at` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `sucursal`
--

CREATE TABLE `sucursal` (
  `Id_Sucursal` int(11) NOT NULL,
  `Sucursal` varchar(50) NOT NULL,
  `Direccion` varchar(50) NOT NULL,
  `Deleted_at` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `sucursal_producto`
--

CREATE TABLE `sucursal_producto` (
  `Id_Sucursal_Producto` int(11) NOT NULL,
  `Stock` int(11) NOT NULL,
  `Stock_Min` int(11) NOT NULL,
  `Id_Sucursal` int(11) NOT NULL,
  `Id_Producto` int(11) NOT NULL,
  `Deleted_at` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `cliente`
--
ALTER TABLE `cliente`
  ADD PRIMARY KEY (`Id_Cliente`);

--
-- Indexes for table `empleado`
--
ALTER TABLE `empleado`
  ADD PRIMARY KEY (`Id_Empleado`),
  ADD KEY `Id_Rol` (`Id_Rol`),
  ADD KEY `Id_Sucursal` (`Id_Sucursal`);

--
-- Indexes for table `movimiento`
--
ALTER TABLE `movimiento`
  ADD PRIMARY KEY (`Id_Movimiento`),
  ADD KEY `Id_Cliente` (`Id_Cliente`);

--
-- Indexes for table `movimiento_producto`
--
ALTER TABLE `movimiento_producto`
  ADD PRIMARY KEY (`Id_Movimiento_Producto`),
  ADD KEY `Id_Sucursal_Producto` (`Id_Sucursal_Producto`),
  ADD KEY `Id_Movimiento` (`Id_Movimiento`);

--
-- Indexes for table `producto`
--
ALTER TABLE `producto`
  ADD PRIMARY KEY (`Id_Producto`);

--
-- Indexes for table `rol`
--
ALTER TABLE `rol`
  ADD PRIMARY KEY (`Id_Rol`);

--
-- Indexes for table `sucursal`
--
ALTER TABLE `sucursal`
  ADD PRIMARY KEY (`Id_Sucursal`);

--
-- Indexes for table `sucursal_producto`
--
ALTER TABLE `sucursal_producto`
  ADD PRIMARY KEY (`Id_Sucursal_Producto`),
  ADD KEY `Id_Sucursal` (`Id_Sucursal`),
  ADD KEY `Id_Producto` (`Id_Producto`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `cliente`
--
ALTER TABLE `cliente`
  MODIFY `Id_Cliente` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `empleado`
--
ALTER TABLE `empleado`
  MODIFY `Id_Empleado` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `movimiento`
--
ALTER TABLE `movimiento`
  MODIFY `Id_Movimiento` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `movimiento_producto`
--
ALTER TABLE `movimiento_producto`
  MODIFY `Id_Movimiento_Producto` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `producto`
--
ALTER TABLE `producto`
  MODIFY `Id_Producto` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `rol`
--
ALTER TABLE `rol`
  MODIFY `Id_Rol` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `sucursal`
--
ALTER TABLE `sucursal`
  MODIFY `Id_Sucursal` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `sucursal_producto`
--
ALTER TABLE `sucursal_producto`
  MODIFY `Id_Sucursal_Producto` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `empleado`
--
ALTER TABLE `empleado`
  ADD CONSTRAINT `empleado_ibfk_1` FOREIGN KEY (`Id_Rol`) REFERENCES `rol` (`Id_Rol`),
  ADD CONSTRAINT `empleado_ibfk_2` FOREIGN KEY (`Id_Sucursal`) REFERENCES `sucursal` (`Id_Sucursal`);

--
-- Constraints for table `movimiento`
--
ALTER TABLE `movimiento`
  ADD CONSTRAINT `movimiento_ibfk_1` FOREIGN KEY (`Id_Cliente`) REFERENCES `cliente` (`Id_Cliente`);

--
-- Constraints for table `movimiento_producto`
--
ALTER TABLE `movimiento_producto`
  ADD CONSTRAINT `movimiento_producto_ibfk_1` FOREIGN KEY (`Id_Sucursal_Producto`) REFERENCES `sucursal_producto` (`Id_Sucursal_Producto`),
  ADD CONSTRAINT `movimiento_producto_ibfk_2` FOREIGN KEY (`Id_Movimiento`) REFERENCES `movimiento` (`Id_Movimiento`);

--
-- Constraints for table `sucursal_producto`
--
ALTER TABLE `sucursal_producto`
  ADD CONSTRAINT `sucursal_producto_ibfk_1` FOREIGN KEY (`Id_Sucursal`) REFERENCES `sucursal` (`Id_Sucursal`),
  ADD CONSTRAINT `sucursal_producto_ibfk_2` FOREIGN KEY (`Id_Producto`) REFERENCES `producto` (`Id_Producto`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
