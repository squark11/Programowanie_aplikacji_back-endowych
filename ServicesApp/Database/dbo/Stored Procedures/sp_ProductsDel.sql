CREATE PROCEDURE [dbo].[sp_ProductsDel]
	@ProductId int
AS
BEGIN
	UPDATE Products set IsAvaliable = 0 WHERE ProductId = @ProductId;
END
