CREATE DATABASE GroceryList
GO

USE GroceryList
GO

CREATE TABLE [dbo].[Groceries](
    [GroceryID] [int] IDENTITY(1,1) NOT NULL,
    [GroceryName] [varchar](120) NULL,
    [GroceryDescription] [varchar](120) NULL,
    [GroceryType] [varchar](120) NULL,
);
GO

ALTER TABLE dbo.Groceries
ADD CONSTRAINT [PK_Groceries] PRIMARY KEY CLUSTERED ([GroceryID] ASC);
GO

CREATE TABLE [dbo].[Stores](
    [StoreID] [int] IDENTITY(1,1) NOT NULL,
    [StoreName] [varchar](120) NULL,
);
GO

ALTER TABLE dbo.Stores
ADD CONSTRAINT [PK_Stores] PRIMARY KEY CLUSTERED ([StoreID] ASC);
GO

CREATE TABLE [dbo].[Pricing](
	[PricingID] [int] IDENTITY(1,1) NOT NULL,
    [GroceryID] [int] NOT NULL,
    [StoreID] [int] NULL,
    [GroceryPrice] [decimal] NULL,
);
GO

ALTER TABLE dbo.Pricing
ADD CONSTRAINT [PK_PricingID] PRIMARY KEY CLUSTERED ([PricingID] ASC);
GO

ALTER TABLE Pricing
ADD CONSTRAINT FK_GroceryID
FOREIGN KEY (GroceryID) REFERENCES Groceries(GroceryID);

ALTER TABLE Pricing
ADD CONSTRAINT FK_StoreID
FOREIGN KEY (StoreID) REFERENCES Stores(StoreID);



INSERT INTO [dbo].[Groceries]
           ([GroceryName],
           [GroceryDescription],
           [GroceryType]
           )
		   VALUES    ('Butter','Unsalted Butter 250g','Eggs and Dairy'),
		   ('Cocoa Powder','Unsweetened cocoa powder 150g', 'Baking'),
		   ('Sugar','White Sugar 2.5kgs','General'),
		   ('Vanilla essence','Vanilla Extract 50ml','Baking'),
		    ('Eggs','Free Range Extra Large Eggs 6 Pk','Eggs and Dairy'),
			('Flour','Cake Wheat Flour 1Kg','Baking'),
			('Baking Soda','Bicarbonate Of Soda 200 g','Baking'),
			('Salt','Cerebos Iodated Table Salt 1 Kg','Spices'),
			('Milk','Fresh Full Cream Milk 2 L','Eggs and Dairy'),
			('Chocolate Icing','Chocolate Icing Mix 280 g','Baking'),
			('Chocolate','Cadbury Dairy Milk 150 g','Sweets'),
			('Cherries','Cherries 180g','Fruits and Vegtables'),
			('Whipped Cream','UHT Whipping Cream 250 g','Eggs and Dairy')
GO

INSERT INTO [dbo].[Stores]
			([StoreName])
			VALUES ('Woolworths'),
			('Checkers'),
			('Shoprite')
GO

INSERT INTO [dbo].[Pricing]
			([GroceryID],
			[StoreID],
			[GroceryPrice])
			VALUES (1, 1, 55.22),
			(1, 2, 53.22),
			(1, 3, 53.65),
			(2, 1, 46),
			(2, 2, 41.99),
			(2, 3, 43.68),
			(3, 1, 48.99),
			(3, 2, 39.99),
			(3, 3, 42.68),
			(4, 1, 48.99),
			(4, 2, 39.99),
			(4, 3, 42.68),
			(5, 1, 23),
			(5, 2, 19.99),
			(5, 3, 21.20),
			(6, 1, 14.99),
			(6, 2, 12.99),
			(6, 3, 12.48),
			(7, 1, 24.99),
			(7, 2, 19.99),
			(7, 3, 21.89),
			(8, 1, 19.99),
			(8, 2, 18.99),
			(8, 3, 17.49),
			(9, 1, 34.99),
			(9, 2, 32.99),
			(9, 3, 30.99),
			(10, 1, 41.99),
			(10, 2, 42.99),
			(10, 3, 49.99),
			(11, 1, 29.99),
			(11, 2, 30.99),
			(11, 3, 31.99),
			(12, 1, 41.99),
			(12, 2, 41.99),
			(12, 3, 41.99),
			(13, 1, 62.99),
			(13, 2, 63.99),
			(13, 3, 76.99)

GO