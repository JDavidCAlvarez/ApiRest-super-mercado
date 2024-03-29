USE [SUPERMERCADO]
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		ERICK MARTINEZ
-- Create date: 29/06/2015
-- Description: ACTUALIZA LA CANTIDAD DE PRODUCTOS DISPONIBLE
-- =============================================
CREATE PROCEDURE SP_ACTUALIZACION_CANTIDAD_PRODUCTOS_FACTURA
	@ID_FACTURA INT
AS
BEGIN
	
	DECLARE @ID_PRODUCTO_1 INT, @CANTIDAD_1 INT 
	
	DECLARE FACTURA_PRODUCTO SCROLL CURSOR FOR
		SELECT 
			[SUPERMERCADO].[dbo].[FACTURA_PRODUCTO].[ID_PRODUCTO],
			[SUPERMERCADO].[dbo].[FACTURA_PRODUCTO].[CANTIDAD_PRODUCTO]
		
		FROM 
			[SUPERMERCADO].[dbo].[FACTURA_PRODUCTO]
		WHERE
			[SUPERMERCADO].[dbo].[FACTURA_PRODUCTO].[ID_FACTURA] =
						@ID_FACTURA

	OPEN FACTURA_PRODUCTO
		FETCH FIRST FROM FACTURA_PRODUCTO INTO @ID_PRODUCTO_1,@CANTIDAD_1


		WHILE @@FETCH_STATUS = 0
		BEGIN

		DECLARE	@return_value int

		EXEC	@return_value = [dbo].[SP_ACTUALIZACION_CANTIDAD_PRODUCTOS]
		@ID_PRODUCTO = @ID_PRODUCTO_1, 
		@CANTIDAD = @CANTIDAD_1


			FETCH NEXT FROM FACTURA_PRODUCTO INTO @ID_PRODUCTO_1,@CANTIDAD_1
		END


	CLOSE FACTURA_PRODUCTO
	DEALLOCATE FACTURA_PRODUCTO

	
END
GO