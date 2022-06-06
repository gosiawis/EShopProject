CREATE TABLE [dbo].[clients]
(
	[id] INT IDENTITY NOT NULL PRIMARY KEY, 
    [name] NVARCHAR(MAX) NOT NULL, 
    [surname] NVARCHAR(MAX) NOT NULL, 
    [email] NVARCHAR(MAX) NOT NULL,
    [voivodeship_id] INT NOT NULL,
    [city] NVARCHAR(MAX) NOT NULL, 
    [street] NVARCHAR(MAX) NOT NULL, 
    [house_number] INT NOT NULL, 
    [apartment_number] INT NULL, 
    [zip_code] NVARCHAR(MAX) NOT NULL, 
    [created_date] DATETIME NOT NULL DEFAULT getdate(), 
    [createtd_by] NVARCHAR(MAX) NOT NULL DEFAULT SUSER_NAME(), 
    [last_modified_date] DATETIME NOT NULL DEFAULT getdate(), 
    [last_modified_by] NVARCHAR(MAX) NOT NULL DEFAULT SUSER_NAME()
    CONSTRAINT clients_voivodeship_id_fk FOREIGN KEY (voivodeship_id) REFERENCES voivodeships ([id])
)
