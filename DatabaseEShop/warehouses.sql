CREATE TABLE [dbo].[warehouses]
(
	[id] INT IDENTITY NOT NULL PRIMARY KEY, 
    [name] VARCHAR(MAX) NOT NULL,
    [district_id] INT NOT NULL,
    [city] NVARCHAR(MAX) NULL DEFAULT NULL, 
    [street] NVARCHAR(MAX) NULL DEFAULT NULL, 
    [house_number] INT NULL DEFAULT NULL, 
    [apartment_number] INT NULL DEFAULT NULL, 
    [zip_code] NVARCHAR(MAX) NULL DEFAULT NULL, 
    CONSTRAINT warehouses_district_id_fk FOREIGN KEY (district_id) REFERENCES districts ([id])
)
