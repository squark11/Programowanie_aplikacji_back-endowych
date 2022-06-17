CREATE PROCEDURE [dbo].[sp_ProductsGet]
AS
BEGIN
	SELECT p.ProductId, p.[Name], p.[Description], p.Price, p.Quantity
		FROM Products as p where IsAvaliable = 1
END
