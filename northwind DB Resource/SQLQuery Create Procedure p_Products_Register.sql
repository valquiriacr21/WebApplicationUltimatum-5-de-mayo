go 
use Northwind
go
-------------------------------Validation Procedure Exist-------------------------------
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name ='p_Products_Register')
DROP PROCEDURE p_Products_Register

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name ='p_Products_Update')
DROP PROCEDURE p_Products_Update

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name ='p_Products_Get')
DROP PROCEDURE p_Products_Get

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name ='p_Products_List')
DROP PROCEDURE p_Products_List

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name ='p_Products_Delete')
DROP PROCEDURE p_Products_Delete

go
----------------------------------------Create Products--------------------------------------------------------------------
create procedure p_Products_Register(
@ProductName nvarchar(40),
@QuantityPerUnit nvarchar(20),
@UnitPrice money,
@UnitsInStock smallint,
@UnitsOnOrder smallint, 
@ReorderLevel smallint, 
@Discontinued bit)
AS
BEGIN
INSERT INTO Products(ProductName,QuantityPerUnit,UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) 
VALUES (
@ProductName,
@QuantityPerUnit,
@UnitPrice,
@UnitsInStock,
@UnitsOnOrder, 
@ReorderLevel, 
@Discontinued)
end

go

----------------------------------------Update Products--------------------------------------------------------------------
create procedure p_Products_Update(
@ProductID int,
@ProductName nvarchar(40),
@QuantityPerUnit nvarchar(20),
@UnitPrice money,
@UnitsInStock smallint,
@UnitsOnOrder smallint, 
@ReorderLevel smallint, 
@Discontinued bit)
AS
BEGIN
UPDATE  Products
SET 
ProductName=@ProductName,
QuantityPerUnit=@QuantityPerUnit,
UnitPrice=@UnitPrice,
UnitsInStock=@UnitsInStock,
UnitsOnOrder=@UnitsOnOrder, 
ReorderLevel=@ReorderLevel, 
Discontinued=@Discontinued
WHERE ProductID=@ProductID
end

go

----------------------------------------Get Products--------------------------------------------------------------------
create procedure p_Products_Get(@ProductID int)
AS
BEGIN
SELECt * FROM  Products
WHERE 
ProductID=@ProductID
end

go
----------------------------------------List Products--------------------------------------------------------------------
create procedure p_Products_List
AS
BEGIN
SELECt * FROM  Products
end

go
----------------------------------------Delete Products--------------------------------------------------------------------
create procedure p_Products_Delete(@ProductID int)
AS
BEGIN
Delete FROM  Products
WHERE 
ProductID=@ProductID
end

go
