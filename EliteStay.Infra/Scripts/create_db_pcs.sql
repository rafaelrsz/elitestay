USE [elitestay]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 15/07/2023 00:20:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[RoomId] [uniqueidentifier] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
	[TotalPrice] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 15/07/2023 00:20:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[Id] [uniqueidentifier] NOT NULL,
	[Description] [varchar](300) NOT NULL,
	[Location] [varchar](300) NOT NULL,
	[Capacity] [int] NOT NULL,
	[DailyPrice] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 15/07/2023 00:20:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [uniqueidentifier] NOT NULL,
	[Password] [varchar](89) NOT NULL,
	[FirstName] [varchar](40) NOT NULL,
	[LastName] [varchar](40) NOT NULL,
	[Document] [char](11) NOT NULL,
	[Email] [varchar](160) NOT NULL,
	[Phone] [varchar](13) NOT NULL,
	[Age] [int] NOT NULL,
	[Permission] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD FOREIGN KEY([RoomId])
REFERENCES [dbo].[Room] ([Id])
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
/****** Object:  StoredProcedure [dbo].[spCheckDate]    Script Date: 15/07/2023 00:20:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCheckDate]
	@StartDate DATETIME,
  @EndDate DATETIME,
  @RoomId UNIQUEIDENTIFIER
AS
	SELECT CASE WHEN EXISTS (
		SELECT [Id]
		FROM [Book]
		WHERE [RoomId] = @RoomId
    AND @StartDate >= [StartDate] AND @EndDate <= [EndDate] AND [STATUS] = 1
	)
	THEN CAST(1 AS BIT)
	ELSE CAST(0 AS BIT) END
GO
/****** Object:  StoredProcedure [dbo].[spCheckDocument]    Script Date: 15/07/2023 00:20:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCheckDocument]
	@Document CHAR(11)
AS
	SELECT CASE WHEN EXISTS (
		SELECT [Id]
		FROM [User]
		WHERE [Document] = @Document
	)
	THEN CAST(1 AS BIT)
	ELSE CAST(0 AS BIT) END
GO
/****** Object:  StoredProcedure [dbo].[spCheckEmail]    Script Date: 15/07/2023 00:20:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCheckEmail]
	@Email VARCHAR(160)
AS
	SELECT CASE WHEN EXISTS (
		SELECT [Id]
		FROM [User]
		WHERE [Email] = @Email
	)
	THEN CAST(1 AS BIT)
	ELSE CAST(0 AS BIT) END
GO
/****** Object:  StoredProcedure [dbo].[spCheckLocation]    Script Date: 15/07/2023 00:20:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCheckLocation]
	@Location VARCHAR(300)
AS
	SELECT CASE WHEN EXISTS (
		SELECT [Id]
		FROM [Room]
		WHERE [Location] = @Location
	)
	THEN CAST(1 AS BIT)
	ELSE CAST(0 AS BIT) END
GO
/****** Object:  StoredProcedure [dbo].[spCreateBook]    Script Date: 15/07/2023 00:20:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spCreateBook]
    @Id UNIQUEIDENTIFIER,
    @UserId UNIQUEIDENTIFIER,
    @RoomId UNIQUEIDENTIFIER,
    @StartDate DATETIME,
    @EndDate DATETIME,
    @Status INT,
    @TotalPrice MONEY
AS
    INSERT INTO [Book] (
        [Id], 
        [UserId], 
        [RoomId], 
        [StartDate],
        [EndDate],
        [Status],
        [TotalPrice]
    ) VALUES (
        @Id,
        @UserId,
        @RoomId,
        @StartDate,
        @EndDate,
        @Status,
        @TotalPrice
      )
GO
/****** Object:  StoredProcedure [dbo].[spCreateRoom]    Script Date: 15/07/2023 00:20:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCreateRoom]
    @Id UNIQUEIDENTIFIER,
    @Description VARCHAR(300),
    @Location VARCHAR(300),
    @Capacity INT,
    @DailyPrice MONEY
AS
    INSERT INTO [Room] (
        [Id], 
        [Description], 
        [Location], 
        [Capacity],
        [DailyPrice]
    ) VALUES (
      @Id,
      @Description,
      @Location,
      @Capacity,
      @DailyPrice
    )
GO
/****** Object:  StoredProcedure [dbo].[spCreateUser]    Script Date: 15/07/2023 00:20:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCreateUser]
    @Id UNIQUEIDENTIFIER,
    @FirstName VARCHAR(40),
    @LastName VARCHAR(40),
    @Password VARCHAR(89),
    @Document CHAR(11),
    @Email VARCHAR(160),
    @Phone VARCHAR(13),
    @Age INT,
    @Permission INT
AS
    INSERT INTO [User] (
        [Id], 
        [FirstName], 
        [LastName], 
        [Password],
        [Document], 
        [Email], 
        [Phone],
        [Age],
        [Permission]
    ) VALUES (
        @Id,
        @FirstName,
        @LastName,
        @Password,
        @Document,
        @Email,
        @Phone,
        @Age,
        @Permission
    )
GO
/****** Object:  StoredProcedure [dbo].[spDeleteRoom]    Script Date: 15/07/2023 00:20:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDeleteRoom]
  @Id UNIQUEIDENTIFIER
AS
		DELETE [Room]
    WHERE [Room].[Id] = @Id
GO
/****** Object:  StoredProcedure [dbo].[spDeleteUser]    Script Date: 15/07/2023 00:20:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDeleteUser]
  @Id UNIQUEIDENTIFIER
AS
		DELETE [User]
    WHERE [User].[Id] = @Id
GO
/****** Object:  StoredProcedure [dbo].[spGetBook]    Script Date: 15/07/2023 00:20:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetBook]
  @Id UNIQUEIDENTIFIER
AS
		SELECT [Id], [UserId], [RoomId], [StartDate], [EndDate], [Status], [TotalPrice]
		FROM [Book]
    WHERE [Book].[Id] = @Id
GO
/****** Object:  StoredProcedure [dbo].[spGetRoom]    Script Date: 15/07/2023 00:20:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetRoom]
  @Id UNIQUEIDENTIFIER
AS
		SELECT [Id], [Description], [Location], [Capacity], [DailyPrice]
		FROM [Room]
    WHERE [Room].[Id] = @Id
GO
/****** Object:  StoredProcedure [dbo].[spGetUser]    Script Date: 15/07/2023 00:20:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetUser]
  @Id UNIQUEIDENTIFIER
AS
		SELECT [Id], Concat([FirstName], ' ',[LastName]) as Name, [Document], [Email], [Permission]
		FROM [User]
    WHERE [User].[Id] = @Id
GO
/****** Object:  StoredProcedure [dbo].[spGetUserByEmail]    Script Date: 15/07/2023 00:20:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetUserByEmail]
  @Email VARCHAR(160)
AS
		SELECT [Id], Concat([FirstName], ' ',[LastName]) as Name, [Document], [Email], [Permission], [Password]
		FROM [User]
    WHERE [User].[Email] = @Email
GO
/****** Object:  StoredProcedure [dbo].[spListBooks]    Script Date: 15/07/2023 00:20:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spListBooks]
AS
		SELECT [Id], [UserId], [RoomId], [StartDate], [EndDate], [Status], [TotalPrice]
		FROM [Book]
GO
/****** Object:  StoredProcedure [dbo].[spListBooksByRoom]    Script Date: 15/07/2023 00:20:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spListBooksByRoom]
@RoomId UNIQUEIDENTIFIER
AS
		SELECT [Id], [UserId], [RoomId], [StartDate], [EndDate], [Status], [TotalPrice]
		FROM [Book]
    WHERE [RoomId] = @RoomId
GO
/****** Object:  StoredProcedure [dbo].[spListBooksByUser]    Script Date: 15/07/2023 00:20:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spListBooksByUser]
@UserId UNIQUEIDENTIFIER
AS
		SELECT [Id], [UserId], [RoomId], [StartDate], [EndDate], [Status], [TotalPrice]
		FROM [Book]
    WHERE [UserId] = @UserId
GO
/****** Object:  StoredProcedure [dbo].[spListRooms]    Script Date: 15/07/2023 00:20:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spListRooms]
AS
		SELECT [Id], [Description], [Location], [Capacity], [DailyPrice]
		FROM [Room]
GO
/****** Object:  StoredProcedure [dbo].[spListUsers]    Script Date: 15/07/2023 00:20:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spListUsers]
AS
		SELECT [Id], Concat([FirstName], ' ' ,[LastName]) as Name, [Document], [Email]
		FROM [User]
GO
/****** Object:  StoredProcedure [dbo].[spUpdateBookStatus]    Script Date: 15/07/2023 00:20:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateBookStatus]
    @Id UNIQUEIDENTIFIER,
    @Status INT
AS
    UPDATE [Book] 
    SET [Status] = @Status
    Where [Id] = @Id 
GO
/****** Object:  StoredProcedure [dbo].[spValidateRoomExclusion]    Script Date: 15/07/2023 00:20:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spValidateRoomExclusion]
	@Id UNIQUEIDENTIFIER
AS
	SELECT CASE WHEN EXISTS (
		SELECT TOP 1 [Id]
		FROM [Book]
		WHERE [RoomId] = @Id
	)
	THEN CAST(1 AS BIT)
	ELSE CAST(0 AS BIT) END
GO
/****** Object:  StoredProcedure [dbo].[spValidateUserExclusion]    Script Date: 15/07/2023 00:20:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spValidateUserExclusion]
	@Id UNIQUEIDENTIFIER
AS
	SELECT CASE WHEN EXISTS (
		SELECT TOP 1 [Id]
		FROM [Book]
		WHERE [UserId] = @Id
	)
	THEN CAST(1 AS BIT)
	ELSE CAST(0 AS BIT) END
GO
