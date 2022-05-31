CREATE TABLE [dbo].[addresses]
(
	[id] INT IDENTITY NOT NULL PRIMARY KEY,
	[district_id] INT NOT NULL,
    [city] NVARCHAR(MAX) NOT NULL, 
    [street] NVARCHAR(MAX) NOT NULL, 
    [house_number] INT NOT NULL, 
    [apartment_number] INT NULL, 
    [zip_code] NVARCHAR(MAX) NOT NULL, 
    CONSTRAINT addresses_district_id_fk FOREIGN KEY (district_id) REFERENCES districts ([id])
)
