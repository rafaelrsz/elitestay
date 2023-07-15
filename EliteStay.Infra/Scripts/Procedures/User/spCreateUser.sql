CREATE PROCEDURE spCreateUser
    @Id UNIQUEIDENTIFIER,
    @FirstName VARCHAR(40),
    @LastName VARCHAR(40),
    @Password VARCHAR(89),
    @Document CHAR(11),
    @Email VARCHAR(160),
    @Phone VARCHAR(13),
    @Age INT,
    @Permission INT
AS
    INSERT INTO [User] (
        [Id], 
        [FirstName], 
        [LastName], 
        [Password],
        [Document], 
        [Email], 
        [Phone],
        [Age],
        [Permission]
    ) VALUES (
        @Id,
        @FirstName,
        @LastName,
        @Password,
        @Document,
        @Email,
        @Phone,
        @Age,
        @Permission
    )