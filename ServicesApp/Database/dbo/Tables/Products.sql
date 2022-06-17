CREATE TABLE [dbo].[Products]
(
	[ProductId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL,
    [Price] MONEY NOT NULL, 
    [Quantity] INT NULL, 
    [IsAvaliable] BIT NOT NULL DEFAULT 1
)
