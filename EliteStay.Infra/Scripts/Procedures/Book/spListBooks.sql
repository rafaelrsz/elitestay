CREATE PROCEDURE spListBooks
AS
		SELECT [Id], [UserId], [RoomId], [StartDate], [EndDate], [Status], [TotalPrice]
		FROM [Book]
