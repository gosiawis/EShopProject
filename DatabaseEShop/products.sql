CREATE TABLE [dbo].[products]
(
	[id] INT IDENTITY NOT NULL PRIMARY KEY, 
    [name] NVARCHAR(MAX) NOT NULL, 
    [brand_id] INT NOT NULL, 
    CONSTRAINT products_brand_id_fk FOREIGN KEY (brand_id) REFERENCES brands ([id]),
    [category_id] INT NOT NULL, 
    CONSTRAINT products_category_id_fk FOREIGN KEY (category_id) REFERENCES categories ([id]),
    [price] FLOAT NOT NULL, 
    [quantity] INT NOT NULL DEFAULT 0, 
    [created_date] DATETIME NOT NULL DEFAULT getdate(), 
    [createtd_by] NVARCHAR(MAX) NOT NULL DEFAULT SUSER_NAME(), 
    [last_modified_date] DATETIME NOT NULL DEFAULT getdate(), 
    [last_modified_by] NVARCHAR(MAX) NOT NULL DEFAULT SUSER_NAME())
