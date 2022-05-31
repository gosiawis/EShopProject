/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO brands VALUES ('Chanel', GetDate()), ('Dior', GetDate()), ('Lancome', GetDate()), ('Fenty Beauty', GetDate()), ('Rare Beauty', GetDate()), ('Huda Beauty', GetDate());
INSERT INTO categories VALUES ('Lips', GetDate()), ('Eyes', GetDate()), ('Face', GetDate()), ('Brows', GetDate()), ('Body', GetDate()), ('Hair', GetDate());
INSERT INTO products VALUES ('Dior Addict Lip Glow', 2, 1, 35.00, 0, NULL, GetDate()), ('BACKSTAGE Eyeshadow Palette', 2, 2, 49.00, 0, NULL, GetDate()), ('Killawatt Freestyle Highlighter', 4, 3, 38.00, 0, NULL, GetDate()), ('Stunna Lip Paint Longwear Fluid Lip Color', 4, 1, 26.00, 0, NULL, GetDate()), ('Fly Baby Mini Eye Primer and Liner Set', 4, 2, 24.00, 0, NULL, GetDate());
INSERT INTO districts VALUES ('Lower Silesia'), ('Kuyavia-Pomerania'), ('Lodzkie'), ('Lublin'), ('Lubusz'), ('Lesser Poland'), ('Masovia'), ('Subcarpathia'), ('Pomerania'), ('Silesia'), ('Warmia-Masuria'), ('Greater Poland'), ('West Pomerania');
INSERT INTO addresses VALUES (7, 'Warsaw', 'Sokowa', 72, 27, '04-124');
INSERT INTO clients VALUES ('Anna', 'Kowalska', 'annak@gmail.com');
INSERT INTO clients_addresses VALUES (1,1);
INSERT INTO order_statuses VALUES ('New'), ('In progress'), ('Completed'), ('Closed'), ('Canceled');
INSERT INTO payment_statuses VALUES ('In progress'), ('Received'), ('Failed');
INSERT INTO payment_methods VALUES ('BLIK'), ('Card'), ('Bank transfer');
INSERT INTO warehouses VALUES ('Main Warehouse', 2, NULL, NULL, NULL, NULL, NULL), ('Backup Warehouse', 8, NULL, NULL, NULL, NULL, NULL);
INSERT INTO stocks VALUES (1, 1, 20), (1, 2, 2), (3, 1, 5), (2, 1, 3), (4, 1, 3), (5, 2, 8);
INSERT INTO orders VALUES (1, 3, 2, 1, GetDate(), GetDate(), 0.00);
INSERT INTO order_items VALUES (1, 2, 1), (1, 4, 1);
