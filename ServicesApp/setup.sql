USE [master]
GO
/****** Object:  Database [ServiceApp]    Script Date: 28.06.2022 22:59:04 ******/
CREATE DATABASE [ServiceApp]
 
CREATE TABLE [dbo].[Logs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AuthorId] [nvarchar](50) NULL,
	[RequestedUrl] [nvarchar](50) NOT NULL,
	[Method] [nvarchar](50) NOT NULL,
	[RequestedArgs] [nvarchar](max) NULL,
	[RequestedDate] [datetime2](7) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ResponeMessage] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 28.06.2022 22:59:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [money] NOT NULL,
	[Quantity] [int] NULL,
	[IsAvaliable] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((1)) FOR [IsAvaliable]
GO
/****** Object:  StoredProcedure [dbo].[sp_LogsAdd]    Script Date: 28.06.2022 22:59:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[sp_LogsGet]    Script Date: 28.06.2022 22:59:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_LogsGet]
AS
BEGIN
	set nocount on;
	SELECT 
		l.AuthorId as AuthorId, l.RequestedUrl as RequestedUrl,
		l.Method as Method, l.RequestedArgs as RequestedArgs,
		l.RequestedDate as RequestedDate, l.[Description] as [Description],
		l.ResponeMessage as ResponeMessage
	FROM Logs as l
	ORDER BY l.RequestedDate DESC
END
GO
/****** Object:  StoredProcedure [dbo].[sp_LogsGetFromLastHour]    Script Date: 28.06.2022 22:59:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[sp_ProductsAdd]    Script Date: 28.06.2022 22:59:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[sp_ProductsDel]    Script Date: 28.06.2022 22:59:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ProductsDel]
	@ProductId int
AS
BEGIN
	UPDATE Products set IsAvaliable = 0 WHERE ProductId = @ProductId;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ProductsGet]    Script Date: 28.06.2022 22:59:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ProductsGet]
AS
BEGIN
	SELECT p.ProductId, p.[Name], p.[Description], p.Price, p.Quantity
		FROM Products as p where IsAvaliable = 1
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ProductsUpdatePrice]    Script Date: 28.06.2022 22:59:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ProductsUpdatePrice]
	@ProductId int,
	@NewPrice money
AS
BEGIN
	UPDATE Products set Price = @NewPrice WHERE ProductId = @ProductId;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ProductsUpdateQuantity]    Script Date: 28.06.2022 22:59:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ProductsUpdateQuantity]
	@ProductId int,
	@NewQuantity int
AS
BEGIN
	UPDATE Products set Quantity = @NewQuantity WHERE ProductId = @ProductId;
END
GO
USE [master]
GO
ALTER DATABASE [ServiceApp] SET  READ_WRITE 
GO
