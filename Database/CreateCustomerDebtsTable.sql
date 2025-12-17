-- Thay <ConstraintName> bằng tên thực tế lấy từ truy vấn trước
ALTER TABLE dbo.Orders DROP CONSTRAINT [<ConstraintName>];

ALTER TABLE dbo.Orders
ADD CONSTRAINT CK_Orders_status CHECK (status IN ('completed','pending','cancelled','debt'));

select * from dbo.Orders



-- 1) Xem các giá trị status hiện có
SELECT DISTINCT payment_method FROM dbo.Payments;

-- 2) Lấy tên và định nghĩa CHECK constraint liên quan tới status
SELECT cc.name AS ConstraintName, cc.definition
FROM sys.check_constraints cc
WHERE cc.parent_object_id = OBJECT_ID('dbo.Payments')
  AND cc.definition LIKE '%payment_method%';

  ALTER TABLE dbo.Orders DROP CONSTRAINT [CK__Orders__status__4F7CD00D];