﻿CREATE TABLE [dbo].[clients]
(
	[id] INT IDENTITY NOT NULL PRIMARY KEY, 
    [name] NVARCHAR(MAX) NOT NULL, 
    [surname] NVARCHAR(MAX) NOT NULL, 
    [email] NVARCHAR(MAX) NOT NULL
)
