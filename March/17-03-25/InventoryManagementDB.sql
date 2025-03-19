CREATE TABLE Inventory (
    InventoryID INT PRIMARY KEY IDENTITY,
    Location NVARCHAR(100)
);

INSERT INTO Inventory (Location) VALUES
('Warehouse A'),
('Warehouse B'),
('Store 1'),
('Store 2'),
('Store 3');

CREATE TABLE Product (
    ProductID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) ,
    Description NVARCHAR(255),
    Quantity INT,
    Price DECIMAL,
    InventoryId INT FOREIGN KEY REFERENCES Inventory(InventoryID)
);

CREATE TABLE Supplier (
    SupplierID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100),
    ContactInformation NVARCHAR(255),
    InventoryId INT FOREIGN KEY REFERENCES Inventory(InventoryID)
);

CREATE TABLE Transactions (
    TransactionID INT PRIMARY KEY IDENTITY,
    ProductID INT FOREIGN KEY REFERENCES Product(ProductID),
    Type NVARCHAR(50),
    Quantity INT ,
    Date DATETIME DEFAULT GETDATE(),
    InventoryId INT FOREIGN KEY REFERENCES Inventory(InventoryID)
);

ALTER TABLE Transactions
DROP CONSTRAINT FK__Transacti__Produ__3F466844;

ALTER TABLE Transactions
DROP CONSTRAINT FK__Transacti__Inven__412EB0B6;

ALTER TABLE Product
DROP CONSTRAINT FK__Product__Invento__398D8EEE;