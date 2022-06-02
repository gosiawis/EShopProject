CREATE TABLE [dbo].[categories]
(
	[id] INT IDENTITY NOT NULL PRIMARY KEY, 
    [name] NVARCHAR(MAX) NOT NULL, 
    [data_added] DATETIME NOT NULL DEFAULT getdate()
)
