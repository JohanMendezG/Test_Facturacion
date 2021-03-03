USE Facturacion
GO

IF OBJECT_ID('ProductosXFactura') IS NOT NULL
	DROP TABLE ProductosXFactura
IF OBJECT_ID('Facturas') IS NOT NULL
	DROP TABLE Facturas
IF OBJECT_ID('Productos') IS NOT NULL
	DROP TABLE Productos
IF OBJECT_ID('Clientes') IS NOT NULL
	DROP TABLE Clientes

CREATE TABLE Clientes(
Documento BIGINT PRIMARY KEY,
Nombres VARCHAR(50) NOT NULL,
PrimerApellido VARCHAR(20) NOT NULL,
SegundoApellido VARCHAR(20) NOT NULL,
Edad INT NOT NULL
)
CREATE TABLE Productos(
Id INT PRIMARY KEY IDENTITY,
Nombre VARCHAR(50) NOT NULL,
PrecioUnidad DECIMAL(10,2) NOT NULL,
CantInventario INT NOT NULL
)
CREATE TABLE Facturas(
Id VARCHAR(5) PRIMARY KEY,
Fecha DATETIME NOT NULL,
ClienteId BIGINT NOT NULL,
FOREIGN KEY(ClienteId) REFERENCES Clientes(Documento)
)
CREATE TABLE ProductosXFactura(
FacturaId VARCHAR(5) NOT NULL,
ProductoId INT NOT NULL,
CantVendido INT NOT NULL,
PRIMARY KEY(FacturaId,ProductoId),
FOREIGN KEY(FacturaId) REFERENCES Facturas(Id),
FOREIGN KEY(ProductoId) REFERENCES Productos(Id),
)
GO

INSERT INTO Clientes(Documento,Nombres,PrimerApellido,SegundoApellido,Edad) VALUES (111111,'JUAN','PEREZ','',30),(222222,'DAVID ANDRES','PEREZ','SUAREZ',40),(333333,'PEPITO','FLORES','LOPEZ',34)
INSERT INTO Productos(Nombre,PrecioUnidad,CantInventario) VALUES ('COBIJA','10000',10),('CAJA ZAPATOS','50000',20),('TELEVISOR','2500000',5),('CELULARES','900000',2)
INSERT INTO Facturas(Id,Fecha,ClienteId) VALUES ('A1','20000225',111111),('A2','20000530',111111),('A3','20000110',222222),('A4','20000605',333333),('A5','20000415',333333)
INSERT INTO ProductosXFactura(FacturaId,ProductoId,CantVendido) VALUES ('A1',1,2),('A1',2,1),('A2',3,1),('A3',4,1),('A3',1,2),('A3',2,3),('A4',3,2),('A5',1,2),('A5',3,1)
GO