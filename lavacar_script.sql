-- =============================================
-- Proyecto: Sistema de gestión para Lavacar
-- Curso: ISB-13 Programación II - UISIL
-- Base de datos: SQL Server
-- =============================================

CREATE DATABASE LavacarDB;
GO

USE LavacarDB;
GO

-- =============================================
-- TABLAS
-- =============================================

CREATE TABLE Clientes (
    id_cliente INT IDENTITY(1,1) NOT NULL,
    nombre     NVARCHAR(100) NOT NULL,
    telefono   NVARCHAR(15)  NOT NULL,
    CONSTRAINT PK_Clientes PRIMARY KEY (id_cliente)
);
GO

CREATE TABLE Vehiculos (
    id_vehiculo INT IDENTITY(1,1) NOT NULL,
    placa       NVARCHAR(10) NOT NULL,
    marca       NVARCHAR(50) NOT NULL,
    id_cliente  INT NOT NULL,
    CONSTRAINT PK_Vehiculos PRIMARY KEY (id_vehiculo),
    CONSTRAINT UQ_Vehiculos_Placa UNIQUE (placa),
    CONSTRAINT FK_Vehiculos_Clientes FOREIGN KEY (id_cliente)
        REFERENCES Clientes(id_cliente)
);
GO

CREATE TABLE Servicios (
    id_servicio INT IDENTITY(1,1) NOT NULL,
    nombre      NVARCHAR(100) NOT NULL,
    precio      DECIMAL(10,2) NOT NULL,
    CONSTRAINT PK_Servicios PRIMARY KEY (id_servicio),
    CONSTRAINT CK_Servicios_Precio CHECK (precio > 0)
);
GO

CREATE TABLE Ordenes (
    id_orden    INT IDENTITY(1,1) NOT NULL,
    fecha       DATETIME NOT NULL DEFAULT GETDATE(),
    estado      NVARCHAR(20) NOT NULL DEFAULT 'Pendiente',
    id_vehiculo INT NOT NULL,
    id_servicio INT NOT NULL,
    CONSTRAINT PK_Ordenes PRIMARY KEY (id_orden),
    CONSTRAINT CK_Ordenes_Estado CHECK (estado IN ('Pendiente', 'En proceso', 'Terminado')),
    CONSTRAINT FK_Ordenes_Vehiculos FOREIGN KEY (id_vehiculo)
        REFERENCES Vehiculos(id_vehiculo),
    CONSTRAINT FK_Ordenes_Servicios FOREIGN KEY (id_servicio)
        REFERENCES Servicios(id_servicio)
);
GO

-- =============================================
-- DATOS DE PRUEBA
-- =============================================

INSERT INTO Clientes (nombre, telefono) VALUES
('Juan Pérez Mora',     '8888-1111'),
('María Rodríguez Soto','8777-2222'),
('Carlos Vargas Ruiz',  '8666-3333'),
('Ana Jiménez Castro',  '8555-4444'),
('Luis Fernández Díaz', '8444-5555');
GO

INSERT INTO Vehiculos (placa, marca, id_cliente) VALUES
('ABC123', 'Toyota', 1),
('BCD456', 'Honda',  1),
('CDE789', 'Nissan', 2),
('DEF012', 'Hyundai',3),
('EFG345', 'Kia',    4),
('FGH678', 'Suzuki', 5);
GO

INSERT INTO Servicios (nombre, precio) VALUES
('Lavado básico',     5000.00),
('Lavado completo',   8000.00),
('Encerado',         12000.00),
('Lavado de motor',   7000.00),
('Aspirado interior', 4000.00);
GO

INSERT INTO Ordenes (fecha, estado, id_vehiculo, id_servicio) VALUES
('2026-10-05 09:00', 'Terminado',  1, 2),
('2026-10-05 10:30', 'Terminado',  3, 1),
('2026-10-06 08:15', 'Terminado',  4, 3),
('2026-10-07 14:00', 'Terminado',  5, 2),
('2026-10-08 11:00', 'Terminado',  2, 5),
('2026-10-09 09:45', 'En proceso', 6, 4),
('2026-10-10 10:00', 'Pendiente',  1, 1),
('2026-10-10 10:30', 'Pendiente',  3, 2);
GO

-- =============================================
-- CONSULTAS DE VERIFICACIÓN
-- =============================================

-- Ver todas las órdenes con cliente, vehículo y total a cobrar
SELECT o.id_orden, o.fecha, c.nombre AS cliente, v.placa,
       s.nombre AS servicio, s.precio AS total, o.estado
FROM Ordenes o
INNER JOIN Vehiculos v ON o.id_vehiculo = v.id_vehiculo
INNER JOIN Clientes  c ON v.id_cliente  = c.id_cliente
INNER JOIN Servicios s ON o.id_servicio = s.id_servicio
ORDER BY o.fecha DESC;
GO
