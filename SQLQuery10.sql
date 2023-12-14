-- Створення таблиці Customers
CREATE TABLE Customers (
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    AddressCity NVARCHAR(50),
    Phone NVARCHAR(20)
);

-- Створення таблиці Shop
CREATE TABLE Shop (
    ShopID INT IDENTITY(1,1) PRIMARY KEY,
    ShopName NVARCHAR(50),
    StorageID INT,
);

-- Створення таблиці Storage
CREATE TABLE Storage (
    StorageID INT IDENTITY(1,1) PRIMARY KEY,
    ToyID INT,
    QuantityOfGoods INT
);

-- Створення таблиці Toy
CREATE TABLE Toy (
    ToyID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(50),
    Price FLOAT,
    CategoryID INT,
    SupplierID INT,
    ShopID INT
);

-- Створення таблиці Orders
CREATE TABLE Orders (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    OrderDate DATE,
    CustomerID INT
);

-- Створення таблиці OrderToys
CREATE TABLE OrderToys (
    OrderToyID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT,
    ToyID INT,
    Quantity INT
);

-- Створення таблиці ToyCategories
CREATE TABLE ToyCategories (
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(50)
);

-- Створення таблиці Suppliers
CREATE TABLE Suppliers (
    SupplierID INT IDENTITY(1,1) PRIMARY KEY,
    CompanyName NVARCHAR(50),
    SupplierCity NVARCHAR(50),
    ContactName NVARCHAR(50),
    SupplierPhone NVARCHAR(20)
);

