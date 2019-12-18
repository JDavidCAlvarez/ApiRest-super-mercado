USE [SUPERMERCADO]
GO

/****** Object:  StoredProcedure [dbo].[SP_USUARIOS_VALIDAR_CONTRASEÑA]    Script Date: 17/12/2019 11:18:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		JHON CAICEDO	
-- Create date: 16-12-2019
-- Description:	MOSTRAR PRODUCTOS
-- =============================================
CREATE PROCEDURE [dbo].[SP_MOSTRAR_PRODUCTOS]
	
AS
BEGIN
	SELECT [ID_PRODUCTO]
      ,[NOMBRE_PRODUCTO]
      ,[VALOR_VENTA_PRODUCTO]
      ,[CANTIDAD_PRODUCTO]
	FROM [SUPERMERCADO].[dbo].[PRODUCTO]
END
GO


