CREATE PROCEDURE [dbo].[sp_LogsGet]
AS
BEGIN
	set nocount on;
	SELECT 
		l.AuthorId as AuthorId, l.RequestedUrl as RequestedUrl,
		l.Method as Method, l.RequestedArgs as RequestedArgs,
		l.RequestedDate as RequestedDate, l.[Description] as [Description],
		l.ResponeMessage as ResponeMessage
	FROM Logs as l;
END
