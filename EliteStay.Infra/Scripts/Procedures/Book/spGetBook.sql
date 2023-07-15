CREATE PROCEDURE spGetBook
  @Id UNIQUEIDENTIFIER
AS
		SELECT [Id], [UserId], [RoomId], [StartDate], [EndDate], [Status], [TotalPrice]
		FROM [Book]
    WHERE [Book].[Id] = @Id
