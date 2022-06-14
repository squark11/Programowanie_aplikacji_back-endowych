CREATE PROCEDURE [dbo].[sp_LogsAdd]
	@AuthorId nvarchar(50),
	@RequestedUrl nvarchar(50),
	@Method NVARCHAR(50),
	@RequestedArgs nvarchar(MAX),
	@Date datetime2(7),
	@Description nvarchar(MAX),
	@ResponeMessage nvarchar(MAX)
AS
BEGIN
	INSERT INTO Logs(AuthorId, RequestedDate, Method, RequestedArgs,
						[Description], RequestedUrl, ResponeMessage)
	VALUES(@AuthorId,@Date, @Method, @RequestedArgs, @Description,
				@RequestedUrl, @ResponeMessage);
END
