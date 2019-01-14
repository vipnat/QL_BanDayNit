/*Thêm Dữ Liệu Vào Một Cột Bất Kỳ*/
DECLARE @id INT 
DECLARE @idd nvarchar(1000)
SET @id = 1

WHILE (@id <=362)  -- Số Lượng Mặt Hàng
BEGIN
--SET @idd = 'DAY' + format(@id, '00#')
UPDATE [dbo].[tblMatHang]
   SET [SoLuong] = 9999    
-- WHERE [tblMatHang].[MaMatH] = @idd;
SET @id = @id + 1
END
GO



