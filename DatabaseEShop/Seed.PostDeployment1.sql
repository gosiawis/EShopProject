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
INSERT INTO products VALUES ('Dior Addict Lip Glow', 2, 1, 35.00, 45, NULL, GetDate()), ('BACKSTAGE Eyeshadow Palette', 2, 2, 49.00, 23, NULL, GetDate()), ('Killawatt Freestyle Highlighter', 4, 3, 38.00, 11, NULL, GetDate()), ('Stunna Lip Paint Longwear Fluid Lip Color', 4, 1, 26.00, 0, NULL, GetDate()), ('Fly Baby Mini Eye Primer and Liner Set', 4, 2, 24.00, 0, NULL, GetDate());
INSERT INTO voivodeships VALUES ('Lower Silesia'), ('Kuyavia-Pomerania'), ('Lodzkie'), ('Lublin');
INSERT INTO order_statuses VALUES ('New'), ('In progress'), ('Completed'), ('Closed'), ('Canceled');
INSERT INTO payment_statuses VALUES ('In progress'), ('Received'), ('Failed');
INSERT INTO payment_methods VALUES ('BLIK'), ('Card'), ('Bank transfer');
INSERT INTO clients VALUES ('Anna', 'Kowalska', 'annak@gmail.com', 1, 'Towny', 'Sokowa', 72, 27, '04-124');
INSERT INTO orders VALUES (1, 3, 2, 1, GetDate(), GetDate(), 0.00);
INSERT INTO order_items VALUES (1, 2, 1), (1, 4, 1);

