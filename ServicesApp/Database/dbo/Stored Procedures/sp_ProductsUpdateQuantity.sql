CREATE PROCEDURE [dbo].[sp_ProductsUpdateQuantity]
	@ProductId int,
	@NewQuantity int
AS
BEGIN
	UPDATE Products set Quantity = @NewQuantity WHERE ProductId = @ProductId;
END
