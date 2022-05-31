CREATE TABLE [dbo].[stocks]
(
	[id] INT IDENTITY NOT NULL PRIMARY KEY, 
    [product_id] INT NOT NULL, 
    [warehouse_id] INT NOT NULL, 
    [quantity] INT NOT NULL DEFAULT 0,
    CONSTRAINT stocks_product_id_fk FOREIGN KEY (product_id) REFERENCES products ([id]),
    CONSTRAINT stocks_warehouse_id_fk FOREIGN KEY (warehouse_id) REFERENCES warehouses ([id])
)
