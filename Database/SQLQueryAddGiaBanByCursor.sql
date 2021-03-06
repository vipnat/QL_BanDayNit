--declare @dem int 
--SELECT @dem = COUNT(*) FROM tblMatHang

--WHILE @dem > 0
--BEGIN


--INSERT INTO [dbo].[tblGiaBan]([MaMatH],[MaKH],[GiaBan])
--VALUES('MaMatH, nvarchar(20)','KH000','GiaBan, float')

--END;

DECLARE @_maHang Char(20)
DECLARE @_donGia float

DECLARE cur_MaHang CURSOR
FORWARD_ONLY 
STATIC
FOR SELECT MaMatH,DonGia From tblMatHang

OPEN cur_MaHang

FETCH NEXT FROM cur_MaHang
WHILE @@FETCH_STATUS = 0
	BEGIN

		FETCH NEXT FROM cur_MaHang INTO @_maHang,@_donGia
		INSERT INTO [dbo].[tblGiaBan]([MaMatH],[MaKH],[GiaBan])
		VALUES(@_maHang,'KH005',@_donGia)
		
	END
CLOSE cur_MaHang
DEALLOCATE cur_MaHang