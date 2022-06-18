CREATE PROCEDURE [dbo].[sp_LogsGetFromLastHour]
	@Date datetime2
AS
BEGIN
	set nocount on;
	SELECT 
		l.AuthorId as AuthorId, l.RequestedUrl as RequestedUrl,
		l.Method as Method, l.RequestedArgs as RequestedArgs,
		l.RequestedDate as RequestedDate, l.[Description] as [Description],
		l.ResponeMessage as ResponeMessage
	FROM Logs as l
	WHERE l.RequestedDate >= @Date
	ORDER BY l.RequestedDate DESC
END
