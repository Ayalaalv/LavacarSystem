# Diccionario de datos – LavacarDB

## Tabla: Clientes
Almacena las personas dueñas de los vehículos.

| Campo | Tipo | Nulo | Llave | Descripción |
|---|---|---|---|---|
| id_cliente | INT IDENTITY | No | PK | Identificador único del cliente |
| nombre | NVARCHAR(100) | No | | Nombre completo del cliente |
| telefono | NVARCHAR(15) | No | | Teléfono de contacto |

## Tabla: Vehiculos
Almacena los vehículos registrados de cada cliente.

| Campo | Tipo | Nulo | Llave | Descripción |
|---|---|---|---|---|
| id_vehiculo | INT IDENTITY | No | PK | Identificador único del vehículo |
| placa | NVARCHAR(10) | No | UNIQUE | Placa del vehículo (no se repite) |
| marca | NVARCHAR(50) | No | | Marca del vehículo |
| id_cliente | INT | No | FK → Clientes | Dueño del vehículo |

## Tabla: Servicios
Catálogo de servicios que ofrece el lavacar.

| Campo | Tipo | Nulo | Llave | Descripción |
|---|---|---|---|---|
| id_servicio | INT IDENTITY | No | PK | Identificador único del servicio |
| nombre | NVARCHAR(100) | No | | Nombre del servicio |
| precio | DECIMAL(10,2) | No | CHECK > 0 | Precio del servicio en colones |

## Tabla: Ordenes
Registro de cada lavado realizado o pendiente.

| Campo | Tipo | Nulo | Llave | Descripción |
|---|---|---|---|---|
| id_orden | INT IDENTITY | No | PK | Identificador único de la orden |
| fecha | DATETIME | No | | Fecha y hora de la orden (por defecto GETDATE()) |
| estado | NVARCHAR(20) | No | CHECK | Pendiente, En proceso o Terminado |
| id_vehiculo | INT | No | FK → Vehiculos | Vehículo atendido |
| id_servicio | INT | No | FK → Servicios | Servicio solicitado |

## Relaciones

| Relación | Cardinalidad | Descripción |
|---|---|---|
| Clientes → Vehiculos | 1 a muchos | Un cliente puede tener varios vehículos |
| Vehiculos → Ordenes | 1 a muchos | Un vehículo puede tener varias órdenes |
| Servicios → Ordenes | 1 a muchos | Un servicio puede estar en varias órdenes |
