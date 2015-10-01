/*** Thêm nhiều dữ liệu rand vào table ***/


USE [BanHang]
GO

declare @dem int=0 --Khai bao biến và gán giá trị cho nó = 0
declare @strdem char(10)
declare @rand int = 1;

while @dem<100 --Sử dụng vòng lặp while
begin
 set @dem=@dem+1
 set @strdem = @dem+'';
 set @rand = convert(int, (200 - 1 + 1) * rand()) + 1;
if len(@strdem) = 1    /*Kiểm Tra Số Trả Về 1 Chữ Số + Thêm Tiền Tố 00 */
begin
set @strdem ='00' + @strdem
end
else if len(@strdem) = 2  /*Kiểm Tra Số Trả Về 2 Chữ Số + Thêm Tiền Tố 0 */
begin
set @strdem='0' + @strdem
end
if len(@rand) = 1   /*Kiểm Tra Rand Trả Về 1 Chữ Số + Thêm 9*/
begin
set @rand = 9 + @rand
end

INSERT INTO [dbo].[tblMatHang]
           ([MaMatH]
           ,[TenMatH]
           ,[SoLuong]
           ,[DonGia])
     VALUES
           ('DAI'+ @strdem
           ,N'Đai '+ @strdem
           ,200
           ,@rand)
end


