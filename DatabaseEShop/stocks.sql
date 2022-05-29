CREATE TABLE [dbo].[stocks]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [product_id] INT NOT NULL, 
    [warehouse_id] INT NOT NULL, 
    [quantity] INT NOT NULL,
    CONSTRAINT stocks_product_id_fk FOREIGN KEY (product_id) REFERENCES products ([id]),
    CONSTRAINT stocks_warehouse_id_fk FOREIGN KEY (warehouse_id) REFERENCES warehouses ([id])
)
