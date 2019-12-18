USE [SUPERMERCADO]
GO
-- =============================================
-- Author:		JHON CAICEDO	
-- Create date: 16-12-2019
-- Description:	Crear datos para cifrar contraseña
-- =============================================
CREATE MASTER KEY ENCRYPTION BY PASSWORD = 'SUPERMERCADO_1';  
GO  
CREATE CERTIFICATE [cert_LLAVE_USUARIOS] WITH SUBJECT = 'Key Protection';  
GO  
CREATE SYMMETRIC KEY [LLAVE_USUARIOS] WITH  
    KEY_SOURCE = 'My key generation bits. This is a shared secret!',  
    ALGORITHM = AES_256,   
    IDENTITY_VALUE = 'Key Identity generation bits. Also a shared secret'  
    ENCRYPTION BY CERTIFICATE [cert_LLAVE_USUARIOS];  
GO  

