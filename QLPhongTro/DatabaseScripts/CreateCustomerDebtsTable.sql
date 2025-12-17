-- Run this script on the MilkStoreManagement database (development copy)
-- Adds a simple table to keep current debt balance per customer.
CREATE TABLE IF NOT EXISTS CustomerDebts
(
    customer_id INT PRIMARY KEY,
    balance DECIMAL(18,2) NOT NULL DEFAULT (0),
    last_updated DATETIME NOT NULL DEFAULT GETDATE()
);

-- Optional: history table for audit
CREATE TABLE IF NOT EXISTS CustomerDebtHistory
(
    id INT IDENTITY(1,1) PRIMARY KEY,
    customer_id INT NOT NULL,
    change_amount DECIMAL(18,2) NOT NULL,
    note NVARCHAR(500) NULL,
    created_at DATETIME NOT NULL DEFAULT GETDATE()
);

select * from CustomerDebts;
 SELECT DISTINCT status FROM dbo.Orders;




 -- 1) Ki?m tra các giá tr? status hi?n có (ch?y tr??c ?? review)
SELECT DISTINCT status
FROM dbo.Orders
WHERE status IS NOT NULL;

-- 2) Tìm tên CHECK constraint liên quan t?i c?t status
SELECT cc.name AS ConstraintName, cc.definition
FROM sys.check_constraints cc
WHERE cc.parent_object_id = OBJECT_ID('dbo.Orders')
  AND cc.definition LIKE '%status%';

-- 3) DROP + RECREATE constraint ?? bao g?m các giá tr? hi?n có và 'debt'
--    Script sau s?:
--      - L?y danh sách giá tr? status hi?n có
--      - Thêm 'debt' n?u ch?a có
--      - Xóa constraint hi?n t?i (n?u tìm th?y)
--      - T?o constraint m?i CK_Orders_status_allow_debt
SET NOCOUNT ON;

DECLARE @vals NVARCHAR(MAX) = N'';
DECLARE @constraintName NVARCHAR(256);
DECLARE @sql NVARCHAR(MAX);

-- Build quoted list of existing statuses
SELECT @vals = STUFF((
    SELECT ',' + QUOTENAME(status,'''')
    FROM (SELECT DISTINCT status FROM dbo.Orders WHERE status IS NOT NULL) AS x
    FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 1, '');

-- Ensure 'debt' present
IF CHARINDEX('''debt''', @vals) = 0
    SET @vals = CASE WHEN LEN(@vals) = 0 THEN '''debt''' ELSE @vals + ',''debt''' END;

-- Get existing constraint name (first match)
SELECT TOP 1 @constraintName = cc.name
FROM sys.check_constraints cc
WHERE cc.parent_object_id = OBJECT_ID('dbo.Orders')
  AND cc.definition LIKE '%status%';

-- Drop existing constraint if found
IF @constraintName IS NOT NULL
BEGIN
    SET @sql = N'ALTER TABLE dbo.Orders DROP CONSTRAINT [' + @constraintName + N'];';
    PRINT @sql;
    EXEC sp_executesql @sql;
END

-- Create new CHECK constraint (name chosen to indicate change)
SET @sql = N'ALTER TABLE dbo.Orders ADD CONSTRAINT CK_Orders_status_allow_debt CHECK (status IN (' + @vals + N'));';
PRINT @sql;
EXEC sp_executesql @sql;

SELECT 'DONE' AS Result;

