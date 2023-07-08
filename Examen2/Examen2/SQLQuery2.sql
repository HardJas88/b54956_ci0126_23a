CREATE TABLE Telefonos(
ID INTEGER PRIMARY KEY IDENTITY,
Marca VARCHAR(200) NOT NULL,
Modelo VARCHAR(200) NOT NULL,
Color VARCHAR(200) NOT NULL,
Cores INT NOT NULL,
Android BIT NOT NULL
)
GO

INSERT INTO [dbo].Telefonos ([Marca],[Modelo],[Color],[Cores],[Android])
VALUES('Samsung', 'Galaxy Z', 'Rojo', 5, 1),
('Huawei', 'P30', 'Dorado', 6, 1),
('Iphone', '7', 'Verde', 2, 0)
GO

Select *
from Telefonos