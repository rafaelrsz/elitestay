CREATE PROCEDURE spUpdateBookStatus
    @Id UNIQUEIDENTIFIER,
    @Status INT
AS
    UPDATE [Book] 
    SET [Status] = @Status
    Where [Id] = @Id 