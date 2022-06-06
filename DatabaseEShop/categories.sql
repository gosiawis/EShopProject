CREATE TABLE [dbo].[categories]
(
	[id] INT IDENTITY NOT NULL PRIMARY KEY, 
    [name] NVARCHAR(MAX) NOT NULL, 
    [created_date] DATETIME NOT NULL DEFAULT getdate(), 
    [createtd_by] NVARCHAR(MAX) NOT NULL DEFAULT SUSER_NAME(), 
    [last_modified_date] DATETIME NOT NULL DEFAULT getdate(), 
    [last_modified_by] NVARCHAR(MAX) NOT NULL DEFAULT SUSER_NAME()
)
