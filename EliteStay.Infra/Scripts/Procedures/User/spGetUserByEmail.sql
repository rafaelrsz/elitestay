CREATE PROCEDURE spGetUserByEmail
  @Email VARCHAR(160)
AS
		SELECT [Id], Concat([FirstName], ' ',[LastName]) as Name, [Document], [Email], [Permission], [Password]
		FROM [User]
    WHERE [User].[Email] = @Email
