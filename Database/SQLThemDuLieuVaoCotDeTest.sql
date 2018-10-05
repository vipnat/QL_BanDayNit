/*Thêm Dữ Liệu Vào Một Cột Bất Kỳ*/
DECLARE @id INT 
DECLARE @idd nvarchar(1000)
SET @id = 1

WHILE (@id <=141)
BEGIN

SET @idd = 'DAY' + format(@id, '00#')
UPDATE [dbo].[tblMatHang]
   SET [SoLuong] = 1000
      
 WHERE [tblMatHang].[MaMatH] = @idd;
SET @id = @id + 1
END
GO



