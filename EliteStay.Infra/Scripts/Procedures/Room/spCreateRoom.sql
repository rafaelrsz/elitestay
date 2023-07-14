CREATE PROCEDURE spCreateRoom
    @Id UNIQUEIDENTIFIER,
    @Description VARCHAR(300),
    @Location VARCHAR(300),
    @Capacity INT,
    @DailyPrice MONEY
AS
    INSERT INTO [Room] (
        [Id], 
        [Description], 
        [Location], 
        [Capacity],
        [DailyPrice]
    ) VALUES (
      @Id,
      @Description,
      @Location,
      @Capacity,
      @DailyPrice
    )