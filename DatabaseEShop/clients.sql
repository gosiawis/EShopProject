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
    CONSTRAINT clients_voivodeship_id_fk FOREIGN KEY (voivodeship_id) REFERENCES voivodeships ([id])
)
