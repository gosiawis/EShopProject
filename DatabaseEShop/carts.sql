CREATE TABLE [dbo].[carts]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [product_id] INT NOT NULL, 
    [product_quantity] INT NOT NULL,
    CONSTRAINT cart_items_product_id_fk FOREIGN KEY (product_id) REFERENCES products ([id])
)
