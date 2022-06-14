CREATE PROCEDURE [dbo].[sp_LogsGet]
AS
BEGIN
	set nocount on;
	SELECT 
		l.AuthorId, l.RequestedDate, l.[Description], 
		l.RequestedArgs, l.RequestedUrl, l.Method, l.ResponeMessage 
	FROM Logs as l;
END
