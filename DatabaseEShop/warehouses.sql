CREATE TABLE [dbo].[warehouses]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [address] NVARCHAR(MAX) NOT NULL, 
    [district_id] INT NOT NULL, 
    CONSTRAINT warehouses_district_id_fk FOREIGN KEY (district_id) REFERENCES districts ([id])
)
