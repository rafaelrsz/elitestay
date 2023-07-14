CREATE DATABASE [elitestay]
USE [elitestay]

CREATE TABLE [User]
(
	[Id] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
  [Password] VARCHAR(64) NOT NULL,
	[FirstName] VARCHAR(40) NOT NULL,
	[LastName] VARCHAR(40) NOT NULL,
	[Document] CHAR(11) NOT NULL,
	[Email] VARCHAR(160) NOT NULL,
	[Phone] VARCHAR(13) NOT NULL,
  [Age] INT NOT NULL,
  [Permission] INT NOT NULL
)

CREATE TABLE [Room]
(
	[Id] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	[Description] VARCHAR(300) NOT NULL,
	[Location] VARCHAR(300) NOT NULL,
  [Capacity] INT NOT NULL,
	[DailyPrice] MONEY NOT NULL,
)

CREATE TABLE [Book]
(
	[Id] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	[UserId] UNIQUEIDENTIFIER NOT NULL,
  [RoomId] UNIQUEIDENTIFIER NOT NULL,
	[StartDate] DATETIME NOT NULL,
	[EndDate] DATETIME NOT NULL,
	[Status] INT NOT NULL,
  FOREIGN KEY([UserId]) REFERENCES [User]([Id]),
  FOREIGN KEY([RoomId]) REFERENCES [Room]([Id])
)
