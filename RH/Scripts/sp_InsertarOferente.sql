USE [practicantes]
GO
CREATE PROCEDURE [dbo].[sp_InsertarOferente_JoseGuzman]
    @identificacion CHAR(15),
	@nombre varchar(50),
	@apellido1 varchar(50),
	@apellido2 varchar(50),
	@correo VARCHAR(100),
    @telefono VARCHAR(20),
    @clave VARCHAR(100),
    @activo bit,
    @verificado bit	
AS
BEGIN
    INSERT INTO OFERENTES (identificacion, nombre, apellido1, apellido2, correo, telefono, clave, activo, verificado)
    VALUES (@identificacion, @nombre, @apellido1, @apellido2, @correo, @telefono, @clave, @activo, @verificado);
END;
GO