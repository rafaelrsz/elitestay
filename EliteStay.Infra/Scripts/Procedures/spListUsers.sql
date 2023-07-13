CREATE PROCEDURE spListUsers
AS
		SELECT [Id], [Document], [Email]
		FROM [User]
