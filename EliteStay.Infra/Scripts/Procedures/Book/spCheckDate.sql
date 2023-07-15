CREATE PROCEDURE spCheckDate
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