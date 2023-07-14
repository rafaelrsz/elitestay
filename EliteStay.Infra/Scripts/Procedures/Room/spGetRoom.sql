CREATE PROCEDURE spGetRoom
  @Id UNIQUEIDENTIFIER
AS
		SELECT [Id], [Description], [Location], [Capacity], [DailyPrice]
		FROM [Room]
    WHERE [Room].[Id] = @Id
