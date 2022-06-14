CREATE TABLE [dbo].[Logs]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AuthorId] NVARCHAR(50) NULL, 
    [RequestedUrl] NVARCHAR(50) NOT NULL,
    [Method] NVARCHAR(50) NOT NULL,
    [RequestedArgs] NVARCHAR(MAX) NULL,
    [RequestedDate] DATETIME2 NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [ResponeMessage] NVARCHAR(MAX) NULL, 
)
