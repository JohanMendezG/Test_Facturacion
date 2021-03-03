USE Facturacion
GO

SELECT	Id,Nombre,PrecioUnidad 
FROM	Productos

SELECT	Id,Nombre,CantInventario 
FROM	Productos 
WHERE	CantInventario <= 5

SELECT		C.*
FROM		Clientes C 
INNER JOIN	Facturas F ON C.Documento = F.ClienteId 
WHERE		C.Edad <= 35 AND F.Fecha BETWEEN '20000201' AND '20000525'

SELECT		P.Id, P.Nombre, TotalVendido = SUM(P.PrecioUnidad * PF.CantVendido)
FROM		Productos P 
INNER JOIN	ProductosXFactura PF ON P.Id = PF.ProductoId
INNER JOIN	Facturas F ON PF.FacturaId = F.Id
WHERE		YEAR(F.Fecha) = 2000
GROUP BY	P.Id,P.Nombre

DECLARE @FECHA1 DATETIME, @FECHA2 DATETIME, @CLIENTEID BIGINT
SET @CLIENTEID = 111111
SET @FECHA1 =	(SELECT C.FECHA 
				FROM 
				(SELECT ID = ROW_NUMBER() OVER(ORDER BY F.FECHA DESC),F.Fecha FROM Clientes C INNER JOIN Facturas F ON C.Documento = F.ClienteId WHERE C.Documento = @CLIENTEID)C
				WHERE C.ID = 2)
SET @FECHA2 =	(SELECT C.FECHA 
				FROM 
				(SELECT ID = ROW_NUMBER() OVER(ORDER BY F.FECHA DESC),F.Fecha FROM Clientes C INNER JOIN Facturas F ON C.Documento = F.ClienteId WHERE C.Documento = @CLIENTEID)C
				WHERE C.ID = 1)
SELECT EstimacioNuevaCompra = DATEADD(DAY,DATEDIFF(DAY,@FECHA1,@FECHA2),@FECHA2)

