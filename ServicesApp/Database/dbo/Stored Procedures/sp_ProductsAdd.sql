CREATE PROCEDURE [dbo].[sp_ProductsAdd]
	@Name nvarchar(50),
	@Description nvarchar(MAX),
	@Price money,
	@Quantity int
AS
BEGIN
	INSERT INTO Products([Name], [Description], Price, Quantity)
	VALUES( @Name, @Description, @Price, @Quantity)
END
