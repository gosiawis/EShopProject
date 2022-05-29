CREATE TABLE [dbo].[order_items]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [order_id] INT NOT NULL, 
    [product_id] INT NOT NULL, 
    [product_quantity] INT NOT NULL,
    CONSTRAINT order_itmes_order_id_fk FOREIGN KEY (order_id) REFERENCES orders ([id]),
	CONSTRAINT orders_items_product_id_fk FOREIGN KEY (product_id) REFERENCES products ([id])
)
