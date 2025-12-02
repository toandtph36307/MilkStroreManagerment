CREATE TABLE CustomerGroups (
    group_id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    name NVARCHAR(50) NOT NULL,
    description NVARCHAR(MAX) NULL,
    created_at DATETIME NOT NULL DEFAULT GETDATE()
);

ALTER TABLE CustomerGroups ADD CONSTRAINT UQ_CustomerGroups_Name UNIQUE ([name]);

-- N?u mu?n gán nhóm cho khách hàng (nullable)
ALTER TABLE Customers ADD group_id INT NULL;
ALTER TABLE Customers ADD CONSTRAINT FK_Customers_CustomerGroups FOREIGN KEY (group_id) REFERENCES CustomerGroups(group_id);