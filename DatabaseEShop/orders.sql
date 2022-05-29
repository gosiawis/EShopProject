CREATE TABLE [dbo].[orders]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [client_id] INT NOT NULL,
	[status_id] INT NOT NULL, 
    [payment_status_id] INT NOT NULL, 
    [payment_method_id] INT NOT NULL, 
    CONSTRAINT orders_client_id_fk FOREIGN KEY (client_id) REFERENCES clients ([id]),
	CONSTRAINT orders_status_id_fk FOREIGN KEY ([status_id]) REFERENCES statuses ([id]),
	CONSTRAINT orders_payment_status_id_fk FOREIGN KEY ([payment_status_id]) REFERENCES payment_statuses ([id]),
	CONSTRAINT orders_payment_method_id_fk FOREIGN KEY ([payment_method_id]) REFERENCES payment_methods ([id])
)
