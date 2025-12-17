
-- 1) Xem các giá tr? payment_method hi?n có
SELECT DISTINCT payment_method FROM dbo.Payments;

-- 2) L?y tên và ??nh ngh?a CHECK constraint liên quan t?i payment_method
SELECT cc.name AS ConstraintName, cc.definition
FROM sys.check_constraints cc
WHERE cc.parent_object_id = OBJECT_ID('dbo.Payments')
  AND cc.definition LIKE '%payment_method%';

  -- REVIEW: hi?n th? giá tr? hi?n có ?? b?n xác nh?n tr??c
SELECT DISTINCT payment_method
FROM dbo.Payments
ORDER BY payment_method;

-- T? ??ng: l?y danh sách giá tr? hi?n có, thêm 'debt' n?u ch?a có,
-- drop constraint hi?n t?i (n?u tìm th?y) và t?o l?i constraint m?i.
SET NOCOUNT ON;

DECLARE @vals NVARCHAR(MAX) = N'';
DECLARE @constraintName NVARCHAR(256);
DECLARE @sql NVARCHAR(MAX);

-- Build quoted list of existing payment_method values
SELECT @vals = STUFF((
    SELECT ',' + QUOTENAME(payment_method,'''')
    FROM (SELECT DISTINCT payment_method FROM dbo.Payments WHERE payment_method IS NOT NULL) AS x
    FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 1, '');

-- Ensure 'debt' present in the list
IF CHARINDEX('''debt''', @vals) = 0
    SET @vals = CASE WHEN LEN(@vals) = 0 THEN '''debt''' ELSE @vals + ',''debt''' END;

-- Find existing CHECK constraint referencing payment_method
SELECT TOP 1 @constraintName = cc.name
FROM sys.check_constraints cc
WHERE cc.parent_object_id = OBJECT_ID('dbo.Payments')
  AND cc.definition LIKE '%payment_method%';

-- Drop existing constraint if found
IF @constraintName IS NOT NULL
BEGIN
    SET @sql = N'ALTER TABLE dbo.Payments DROP CONSTRAINT [' + @constraintName + N'];';
    PRINT 'Dropping constraint: ' + @constraintName;
    PRINT @sql;
    EXEC sp_executesql @sql;
END
ELSE
BEGIN
    PRINT 'No existing payment_method CHECK constraint found.';
END

-- Create new CHECK constraint that allows all existing values + 'debt'
SET @sql = N'ALTER TABLE dbo.Payments ADD CONSTRAINT CK_Payments_payment_method_allow_debt CHECK (payment_method IN (' + @vals + N'));';
PRINT 'Creating new constraint CK_Payments_payment_method_allow_debt';
PRINT @sql;
EXEC sp_executesql @sql;

SELECT 'DONE' AS Result;