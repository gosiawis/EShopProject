CREATE TABLE [dbo].[clients_addresses]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY, 
    [client_id] INT NOT NULL, 
    [address_id] INT NOT NULL,
    CONSTRAINT clients_addresses_client_id_fk FOREIGN KEY (client_id) REFERENCES clients ([id]),
    CONSTRAINT clients_addresses_address_id_fk FOREIGN KEY (address_id) REFERENCES addresses ([id])
)
