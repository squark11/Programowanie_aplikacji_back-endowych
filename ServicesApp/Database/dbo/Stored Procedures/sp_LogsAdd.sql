CREATE PROCEDURE [dbo].[sp_LogsAdd]
	@AuthorId nvarchar(50),
	@RequestedUri nvarchar(50),
	@RequestedArgs nvarchar(MAX),
	@Date datetime2(7),
	@Description nvarchar(MAX),
	@ResponeMessage nvarchar(MAX)
AS
BEGIN
	INSERT INTO Logs(AuthorId, RequestedDate, RequestedArgs,
						[Description], RequestedUrl, ResponeMessage)
	VALUES(@AuthorId,@Date, @RequestedArgs, @Description,
				@RequestedUri, @ResponeMessage);
END
