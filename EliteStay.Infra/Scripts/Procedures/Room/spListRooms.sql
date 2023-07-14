CREATE PROCEDURE spListRooms
AS
		SELECT [Id], [Description], [Location], [Capacity], [DailyPrice]
		FROM [Room]
