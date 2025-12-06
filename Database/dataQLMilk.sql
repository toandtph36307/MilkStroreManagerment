    use MilkStoreManagement;
    select * from Customers;





USE MilkStoreManagement;
SELECT DB_NAME() AS CurrentDatabase;
SELECT OBJECT_ID('dbo.Customers') AS CustomersObjectId;



USE MilkStoreManagement;
SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Customers'
  AND COLUMN_NAME = 'status';



USE MilkStoreManagement;
BEGIN TRANSACTION;

IF COL_LENGTH('dbo.Customers', 'statusCus') IS NULL
BEGIN
    ALTER TABLE dbo.Customers
    ADD statusCus NVARCHAR(10) NOT NULL
        CONSTRAINT DF_Customers_Status DEFAULT (N'Active');

    ALTER TABLE dbo.Customers
    ADD CONSTRAINT CK_Customers_Status CHECK (statusCus IN (N'Active', N'Inactive'));
END

COMMIT TRANSACTION;