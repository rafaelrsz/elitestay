CREATE PROCEDURE spGetUser
  @Id UNIQUEIDENTIFIER
AS
		SELECT [Id], Concat([FirstName], ' ',[LastName]) as Name, [Document], [Email], [Permission]
		FROM [User]
    WHERE [User].[Id] = @Id
