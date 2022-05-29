CREATE TABLE [dbo].[products]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [name] NVARCHAR(MAX) NOT NULL, 
    [brand_id] INT NOT NULL, 
    CONSTRAINT products_brand_id_fk FOREIGN KEY (brand_id) REFERENCES brands ([id]),
    [category_id] INT NOT NULL, 
    CONSTRAINT products_category_id_fk FOREIGN KEY (category_id) REFERENCES categories ([id]),
    [price] FLOAT NOT NULL, 
    [quantity] INT NOT NULL)
