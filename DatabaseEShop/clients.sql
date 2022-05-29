CREATE TABLE [dbo].[clients]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [name] NVARCHAR(MAX) NOT NULL, 
    [surname] NVARCHAR(MAX) NOT NULL, 
    [district_id] INT NOT NULL,
    [address] NVARCHAR(MAX) NOT NULL, 
    CONSTRAINT clients_district_id_fk FOREIGN KEY (district_id) REFERENCES districts ([id])
)
