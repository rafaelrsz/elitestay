CREATE PROCEDURE spListUsers
AS
		SELECT [Id], Concat([FirstName], ' ' ,[LastName]) as Name, [Document], [Email]
		FROM [User]
