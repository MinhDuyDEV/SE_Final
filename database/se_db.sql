create database MobilePhone
go
use MobilePhone
go
CREATE TABLE Product
(
  ProductID VARCHAR(10) NOT NULL PRIMARY KEY,
  ProductName VARCHAR(50) NOT NULL,
  ProductPrice INT NOT NULL,
  ProductQuantity INT NOT NULL,
);
go
CREATE TABLE WarehouseReceipt
(
  ReceiptID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  TotalWarehouseQuantity INT NOT NULL,
  TotalWarehousePrice INT NOT NULL,
  CreatedDate DATE NOT NULL,
);
go
CREATE TABLE Agent
(
  AgentID VARCHAR(10) NOT NULL PRIMARY KEY,
  AgentName NVARCHAR(50) NOT NULL,
  AgentAccount NVARCHAR(50) NOT NULL,
  AgentPassword NVARCHAR(50) NOT NULL,
  AgentAddress NVARCHAR(100),
  AgentPhoneNumber NVARCHAR(20)
);
go
CREATE TABLE OrderReceipt
(
  OrderID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  TotalOrderPrice INT NOT NULL,
  TotalOrderQuantity INT NOT NULL,
  OrderedDate DATE NOT NULL,
  Status NVARCHAR(50) NOT NULL,
  AgentID VARCHAR(10) NOT NULL,
  PaymentStatus NVARCHAR(50),
  OrderStatus NVARCHAR(50),
  CONSTRAINT FkOrderReceipt_AgentID FOREIGN KEY (AgentID) REFERENCES Agent(AgentID) 
);
go
CREATE TABLE IncludeOrderProducts
(
  TotalProductQuantity INT NOT NULL,
  TotalProductPrice INT NOT NULL,
  OrderID INT NOT NULL,
  ProductID VARCHAR(10) NOT NULL,
  CONSTRAINT PkIncludeOrderProducts_OrderID_ProductID PRIMARY KEY (OrderID, ProductID),
  CONSTRAINT FkIncludeOrderProducts_OrderID FOREIGN KEY (OrderID) REFERENCES OrderReceipt(OrderID),
  CONSTRAINT FkIncludeOrderProducts_ProductID FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);
go
CREATE TABLE IncludeImportedProducts
(
  TotalProductQuantity INT NOT NULL,
  TotalProductPrice INT NOT NULL,
  ReceiptID INT NOT NULL,
  ProductID VARCHAR(10) NOT NULL,
  CONSTRAINT PkIncludeImportedProducts PRIMARY KEY (ReceiptID, ProductID),
  CONSTRAINT FkIncludeImportedProducts_ReceiptID FOREIGN KEY (ReceiptID) REFERENCES WarehouseReceipt(ReceiptID),
  CONSTRAINT FkIncludeImportedProducts_ProductID FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);
go
CREATE TABLE Distributor
(
  DistributorID VARCHAR(10) NOT NULL PRIMARY KEY,
  DistributorAccount NVARCHAR(50) NOT NULL,
  DistributorPassword NVARCHAR(50) NOT NULL
);
go
INSERT INTO Distributor (DistributorID, DistributorAccount, DistributorPassword)
VALUES ('D001', 'distributor1', 'password1');
go
INSERT INTO Agent (AgentID, AgentName, AgentAccount, AgentPassword, AgentAddress, AgentPhoneNumber)
VALUES ('A001', 'Agent1', 'agent1', 'password1', '123 Main Street', '555-1234'),
('A002', 'Agent2', 'admin', '123456', 'Tan Phong', '999-8888'),
('A003', 'Agent3', 'admin1', '123456', 'Tan Phong', '999-8888'),
('A004', 'Agent4', 'admin2', '123456', 'Tan Phong', '999-8888'),
('A005', 'Agent5', 'admin3', '123456', 'Tan Phong', '999-8888');
go
INSERT INTO Product (ProductID, ProductName, ProductPrice, ProductQuantity)
VALUES ('P001', 'iPhone XS', 1000, 100)
go
INSERT INTO WarehouseReceipt (TotalWarehouseQuantity, TotalWarehousePrice, CreatedDate)
VALUES 
    (1000, 5500, '2023-01-01')
go
INSERT INTO IncludeImportedProducts (TotalProductQuantity, TotalProductPrice, ReceiptID, ProductID)
VALUES (100, 1000, 1, 'P001')
go

DECLARE @month AS INT = 1;
WHILE @month <= 12
BEGIN
    INSERT INTO OrderReceipt 
    VALUES 
        (10000 * @month, 1000 * @month, DATEFROMPARTS(2023, @month, 1), '', 'A001', 'unpaid', 'processing'),
        (20000 * @month, 2000 * @month, DATEFROMPARTS(2023, @month, 15), '', 'A002', 'unpaid' , 'processing'),
        (20000 * @month, 2000 * @month, DATEFROMPARTS(2023, @month, 15), '', 'A003', 'unpaid' , 'processing'),
        (20000 * @month, 2000 * @month, DATEFROMPARTS(2023, @month, 15), '', 'A004', 'unpaid' , 'processing'),
        (20000 * @month, 2000 * @month, DATEFROMPARTS(2023, @month, 15), '', 'A005', 'unpaid' , 'processing');
    SET @month = @month + 1;
END
go
INSERT INTO IncludeOrderProducts (TotalProductQuantity, TotalProductPrice, OrderID, ProductID)
SELECT 
    TotalOrderQuantity / 15 AS TotalProductQuantity,
    TotalOrderPrice / 15 AS TotalProductPrice,
    OrderID,
    'P' + RIGHT('00' + CAST(ROW_NUMBER() OVER(PARTITION BY OrderID ORDER BY ProductID) AS NVARCHAR(3)), 3) AS ProductID
FROM 
    OrderReceipt
CROSS JOIN 
    Product;

go


CREATE TRIGGER trIncludeOrderProductsUpdateForProduct
ON IncludeOrderProducts
AFTER INSERT
AS
	BEGIN
		DECLARE @productID VARCHAR(20)
		DECLARE @totalProductQuantity INT
		
		DECLARE cursor_product CURSOR
		FOR
			SELECT ProductID, TotalProductQuantity FROM INSERTED

		OPEN cursor_product;

		FETCH NEXT FROM cursor_product INTO @productID, @totalProductQuantity

		WHILE @@fetch_status = 0
			BEGIN
				UPDATE Product
				SET ProductQuantity = ProductQuantity - @totalProductQuantity
				WHERE ProductID = @productID

				FETCH NEXT FROM cursor_product INTO @productID, @totalProductQuantity
			END

		CLOSE cursor_product;
		DEALLOCATE cursor_product;
    END
GO

GO
CREATE FUNCTION fnProductsIn()
RETURNS TABLE 
AS
	RETURN (
		SELECT ProductID, SUM(TotalProductPrice) AS TotalProductPrice, SUM(TotalProductQuantity) AS TotalProductQuantity 
		FROM IncludeImportedProducts
		GROUP BY ProductID
	)
GO

GO
CREATE FUNCTION fnProductsOut()
RETURNS TABLE 
AS
	RETURN (
		SELECT ProductID, SUM(TotalProductPrice) AS TotalProductPrice, SUM(TotalProductQuantity) AS TotalProductQuantity 
		FROM IncludeOrderProducts
		GROUP BY ProductID
	)
GO

GO
CREATE FUNCTION fnBestSellingProduct()
RETURNS TABLE 
AS
	RETURN (
		SELECT TOP 1 TotalProductQuantity, ProductID, TotalProductPrice FROM 
		(
			SELECT ProductID, SUM(TotalProductPrice) AS TotalProductPrice, SUM(TotalProductQuantity) AS TotalProductQuantity 
			FROM IncludeOrderProducts
			GROUP BY ProductID
		) Best_Selling_Product
		ORDER BY TotalProductQuantity DESC
	)
GO

GO
CREATE FUNCTION fnRevenueEachMonth()
RETURNS TABLE
AS
	RETURN (
		SELECT MONTH(OrderedDate) AS OrderedMonth, SUM(TotalOrderPrice) AS Revenue 
		FROM OrderReceipt
		GROUP BY MONTH(OrderedDate)
	)
GO

CREATE TABLE ProductAgent 
(
	ProductID VARCHAR(10) NOT NULL PRIMARY KEY,
	ProductName VARCHAR(50) NOT NULL,
	ProductPrice INT NOT NULL,
	ProductQuantity INT NOT NULL,
)
