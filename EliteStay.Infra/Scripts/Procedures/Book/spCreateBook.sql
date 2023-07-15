CREATE PROCEDURE spCreateBook
    @Id UNIQUEIDENTIFIER,
    @UserId UNIQUEIDENTIFIER,
    @RoomId UNIQUEIDENTIFIER,
    @StartDate DATETIME,
    @EndDate DATETIME,
    @Status INT,
    @TotalPrice MONEY
AS
    INSERT INTO [Book] (
        [Id], 
        [UserId], 
        [RoomId], 
        [StartDate],
        [EndDate],
        [Status],
        [TotalPrice]
    ) VALUES (
        @Id,
        @UserId,
        @RoomId,
        @StartDate,
        @EndDate,
        @Status,
        @TotalPrice
      )