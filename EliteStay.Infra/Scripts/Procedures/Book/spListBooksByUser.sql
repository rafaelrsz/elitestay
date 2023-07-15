CREATE PROCEDURE spListBooksByUser
@UserId UNIQUEIDENTIFIER
AS
		SELECT [Id], [UserId], [RoomId], [StartDate], [EndDate], [Status], [TotalPrice]
		FROM [Book]
    WHERE [UserId] = @UserId
