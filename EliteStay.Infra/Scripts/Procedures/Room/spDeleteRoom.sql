CREATE PROCEDURE spDeleteRoom
  @Id UNIQUEIDENTIFIER
AS
		DELETE [Room]
    WHERE [Room].[Id] = @Id
