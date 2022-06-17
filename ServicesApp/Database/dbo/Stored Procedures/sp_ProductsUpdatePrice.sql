CREATE PROCEDURE [dbo].[sp_ProductsUpdatePrice]
	@ProductId int,
	@NewPrice money
AS
BEGIN
	UPDATE Products set Price = @NewPrice WHERE ProductId = @ProductId;
END
