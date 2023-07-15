CREATE PROCEDURE spValidateRoomExclusion
	@Id UNIQUEIDENTIFIER
AS
	SELECT CASE WHEN EXISTS (
		SELECT TOP 1 [Id]
		FROM [Book]
		WHERE [RoomId] = @Id
	)
	THEN CAST(1 AS BIT)
	ELSE CAST(0 AS BIT) END