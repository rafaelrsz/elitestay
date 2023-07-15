CREATE PROCEDURE spListBooksByRoom
@RoomId UNIQUEIDENTIFIER
AS
		SELECT [Id], [UserId], [RoomId], [StartDate], [EndDate], [Status], [TotalPrice]
		FROM [Book]
    WHERE [RoomId] = @RoomId
