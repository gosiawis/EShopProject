CREATE TABLE [dbo].[orders]
(
	[id] INT IDENTITY NOT NULL PRIMARY KEY, 
    [client_id] INT NOT NULL,
	[order_status_id] INT NOT NULL, 
    [payment_status_id] INT NOT NULL, 
    [payment_method_id] INT NOT NULL, 
    [start_date] DATETIME NOT NULL DEFAULT GetDate(), 
    [end_date] DATETIME NULL, 
    [price] FLOAT NOT NULL DEFAULT 0.00, 
    CONSTRAINT orders_client_id_fk FOREIGN KEY (client_id) REFERENCES clients ([id]),
	CONSTRAINT orders_status_id_fk FOREIGN KEY ([order_status_id]) REFERENCES order_statuses ([id]),
	CONSTRAINT orders_payment_status_id_fk FOREIGN KEY ([payment_status_id]) REFERENCES payment_statuses ([id]),
	CONSTRAINT orders_payment_method_id_fk FOREIGN KEY ([payment_method_id]) REFERENCES payment_methods ([id])
)
