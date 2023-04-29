create database Veterinaria

use Veterinaria

CREATE TABLE MAE_USUARIOS
(
  Login_Usuario INT IDENTITY PRIMARY KEY,
  Clave_Usuario varchar (100) NOT NULL,
  Nombre_Usuario varchar (100) NOT NULL,
)

CREATE TABLE MAE_MASCOTAS
(
  ID_Mascota INT IDENTITY (1,1) PRIMARY KEY,
  Nombre_Mascota varchar (100) UNIQUE,
  Tipo_Mascota varchar (100),
  Comida_Favorita varchar (100),
)

CREATE TABLE CONTROL_CITAS
(
  ID_Mascota INT NOT NULL,
  FOREIGN KEY (ID_Mascota) REFERENCES MAE_MASCOTAS (ID_Mascota),
  Proxima_Fecha varchar (100),
  Medico_Asignado varchar (100),
)

CREATE TABLE USERS
(
  ID INT IDENTITY (1,1),
  Usuario varchar (100) NOT NULL,
  Contraseña varchar (100) NOT NULL,
  CONSTRAINT PK_ID PRIMARY KEY (ID),
  CONSTRAINT UQ_USER UNIQUE (Usuario)
)

GO
INSERT INTO USERS VALUES ('Lmiguel', '120193')
INSERT INTO USERS VALUES ('Ccastro', '101214')
INSERT INTO USERS VALUES ('Jlopez', '151212')
GO

-- PROCEDIMIENTOS --

-- MAE_USUARIOS --
CREATE PROCEDURE SP_AgregarUsuarios
(
    @Clave_Usuario varchar(100),
    @Nombre_Usuario varchar(100)
)
AS
BEGIN
    INSERT INTO MAE_USUARIOS(Clave_Usuario, Nombre_Usuario)
    VALUES (@Clave_Usuario, @Nombre_Usuario)
END
GO

CREATE PROCEDURE SP_BorrarUsuarios
(
    @Login_Usuario int
)
AS
BEGIN
    DELETE FROM MAE_USUARIOS WHERE Login_Usuario = @Login_Usuario
END
GO

CREATE PROCEDURE SP_ModificarUsuarios
(
    @Login_Usuario int,
    @Clave_Usuario varchar(100),
    @Nombre_Usuario varchar(100)
)
AS
BEGIN
	UPDATE MAE_USUARIOS SET
		Clave_Usuario = @Clave_Usuario,
		Nombre_Usuario = @Nombre_Usuario
	WHERE Login_Usuario = @Login_Usuario
END
GO

-- MAE_MASCOTAS --
CREATE PROCEDURE SP_AgregarMascotas
(
    @Nombre_Mascota varchar(100),
    @Tipo_Mascota varchar(100),
	@Comida_Favorita varchar(100)
)
AS
BEGIN
    INSERT INTO MAE_MASCOTAS(Nombre_Mascota, Tipo_Mascota, Comida_Favorita)
    VALUES (@Nombre_Mascota, @Tipo_Mascota, @Comida_Favorita)
END
GO

CREATE PROCEDURE SP_BorrarMascotas
(
    @ID_Mascota int
)
AS
BEGIN
    DELETE FROM MAE_MASCOTAS WHERE ID_Mascota = @ID_Mascota
END
GO

CREATE PROCEDURE SP_ModificarMascotas
(
    @ID_Mascota int,
    @Nombre_Mascota varchar(100),
    @Tipo_Mascota varchar(100),
	@Comida_Favorita varchar(100)
)
AS
BEGIN
	UPDATE MAE_MASCOTAS SET
		Nombre_Mascota = @Nombre_Mascota,
		Tipo_Mascota = @Tipo_Mascota,
		Comida_Favorita = @Comida_Favorita
	WHERE ID_Mascota = @ID_Mascota
END
GO

-- CONTROL_CITAS --
CREATE PROCEDURE SP_AgregarCitas
(
	@ID_Mascota int,
    @Proxima_Fecha varchar(100),
    @Medico_Asignado varchar(100)
)
AS
BEGIN
    INSERT INTO CONTROL_CITAS(ID_Mascota, Proxima_Fecha, Medico_Asignado)
    VALUES (@ID_Mascota, @Proxima_Fecha, @Medico_Asignado)
END
GO

CREATE PROCEDURE SP_BorrarCitas
(
    @ID_Mascota int
)
AS
BEGIN
    DELETE FROM CONTROL_CITAS WHERE ID_Mascota = @ID_Mascota
END
GO

CREATE PROCEDURE SP_ModificarCitas
(
    @ID_Mascota int,
    @Proxima_Fecha varchar(100),
    @Medico_Asignado varchar(100)
)
AS
BEGIN
	UPDATE CONTROL_CITAS SET
		Proxima_Fecha = @Proxima_Fecha,
		Medico_Asignado = @Medico_Asignado
	WHERE ID_Mascota = @ID_Mascota
END
GO

SELECT m.Nombre_Mascota, cc.Proxima_Fecha, cc.Medico_Asignado 
FROM CONTROL_CITAS cc
INNER JOIN MAE_MASCOTAS m ON cc.ID_Mascota = m.ID_Mascota
WHERE cc.Proxima_Fecha >= CONVERT(date, GETDATE())
ORDER BY cc.Proxima_Fecha ASC;

-- USERS --
CREATE PROCEDURE ValidarLogin
  @Usuario varchar(100) = '',
  @Contraseña varchar(100) = ''
AS
BEGIN
  SELECT Usuario, Contraseña
  FROM USERS
  WHERE Usuario = @Usuario AND Contraseña = @Contraseña
END