create database SellPoint;
go
use SellPoint;
go

create table Entidades(
	IdEntidad int primary key identity(1,1),
	Descripcion varchar(120) not null,
	Direccion text not null,
	Localidad varchar(40) not null,
	TipoEntidad varchar(8) not null default 'Jurídica',
	TipoDocumento varchar(9) not null default 'RNC',
	NumeroDocumento bigint not null,
	Telefonos varchar(60) not null,
	URLPaginaWeb varchar(120),
	URLFacebook varchar(120),
	URLInstagram varchar(120),
	URLTwitter varchar(120),
	URLTikTok varchar(120),
	IdGrupoEntidad int not null,
	IdTipoEntidad int not null,
	LimiteCredito decimal(15,2) default 0,
	UserNameEntidad varchar(60) not null,
	PassworEntidad varchar(30) not null,
	RolUserEntidad varchar(10) default 'User',
	Comentario text,
	Status varchar(10) default 'Activa',
	NoEliminable bit default 0,
	FechaRegistro date default getdate()
);
go


create table GruposEntidades(
	IdGrupoEntidad int primary key identity(1,1),
	Descripcion varchar(120) not null,
	Comentario text,
	Status varchar(10) default 'Activa',
	NoEliminable bit default 0,
	FechaRegistro date default getdate()
);
go

create table TiposEntidades(
	IdTipoEntidad int primary key identity(1,1),
	Descripcion varchar(120) not null,
	IdGrupoEntidad int not null,
	Comentario text,
	Status varchar(10) default 'Activa',
	NoEliminable bit default 0,
	FechaRegistro date default getdate()
);
go
use SellPoint;
go

alter table Entidades 
	add constraint fk_Entidades_idGrEntidad
	foreign key (IdGrupoEntidad) 
	references GruposEntidades (IdGrupoEntidad);
go
alter table Entidades 
	add constraint fk_Entidades_idTpEntidad
	foreign key (IdTipoEntidad) 
	references TiposEntidades (IdTipoEntidad);
go

alter table TiposEntidades 
	add constraint fk_TpEntidades_idGrEntidad
	foreign key (IdGrupoEntidad) 
	references GruposEntidades (IdGrupoEntidad);
go

--PROCEDIMIENTO ALMACENADO DEL LOGIN
CREATE PROCEDURE EntidadesLogin
	@user as varchar(60),
	@pass as varchar(30)
AS
BEGIN
	select * 
	from Entidades
	where UserNameEntidad=@user
	and PassworEntidad=@pass
END
GO




---------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------
--PROCEDIMIENTOS DE LA TABLA ENTIDADES

--Listar todos los registros de la tabla Entidades
CREATE PROCEDURE EntidadesListar
AS
BEGIN
	select * 
	from Entidades
END
GO


--Insertar un registro a la tabla Entidades
CREATE PROCEDURE EntidadesInsertar
@Descripcion AS VARCHAR(120),
@Direccion AS TEXT,
@Localidad AS VARCHAR(40),
@TipoEntidad AS VARCHAR(8),
@TipoDocumento AS VARCHAR(9),
@NumeroDocumento AS bigint,
@Telefonos AS VARCHAR(60),
@URLPaginaWeb AS VARCHAR(120),
@URLFacebook AS VARCHAR(120),
@URLInstagram AS VARCHAR(120),
@URLTwitter AS VARCHAR(120),
@URLTikTok AS VARCHAR(120),
@IdGrupoEntidad AS INT,
@IdTipoEntidad AS INT,
@LimiteCredito AS DECIMAL(15,2),
@UserNameEntidad AS VARCHAR(60),
@PassworEntidad AS VARCHAR(30),
@RolUserEntidad AS VARCHAR(10),
@Comentario AS TEXT,
@Status AS VARCHAR(10),
@NoEliminable AS BIT
AS
BEGIN
INSERT INTO Entidades (Descripcion,Direccion,Localidad,TipoEntidad,TipoDocumento,
	NumeroDocumento,Telefonos,URLPaginaWeb,URLFacebook,URLInstagram,URLTwitter,
	URLTikTok,IdGrupoEntidad,IdTipoEntidad,LimiteCredito,UserNameEntidad,PassworEntidad,
	RolUserEntidad,Comentario,Status,NoEliminable)

VALUES (@Descripcion,@Direccion,@Localidad,@TipoEntidad,@TipoDocumento,
	@NumeroDocumento,@Telefonos,@URLPaginaWeb,@URLFacebook,@URLInstagram,@URLTwitter,
	@URLTikTok,@IdGrupoEntidad,@IdTipoEntidad,@LimiteCredito,@UserNameEntidad,@PassworEntidad,
	@RolUserEntidad,@Comentario,@Status,@NoEliminable)
END
GO


--Editar un registro de la tabla Entidades
CREATE PROCEDURE EntidadesActualizar
@IdEntidad AS INT,
@Descripcion AS VARCHAR(120),
@Direccion AS TEXT,
@Localidad AS VARCHAR(40),
@TipoEntidad AS VARCHAR(8),
@TipoDocumento AS VARCHAR(9),
@NumeroDocumento AS bigint,
@Telefonos AS VARCHAR(60),
@URLPaginaWeb AS VARCHAR(120),
@URLFacebook AS VARCHAR(120),
@URLInstagram AS VARCHAR(120),
@URLTwitter AS VARCHAR(120),
@URLTikTok AS VARCHAR(120),
@IdGrupoEntidad AS INT,
@IdTipoEntidad AS INT,
@LimiteCredito AS DECIMAL(15,2),
@UserNameEntidad AS VARCHAR(60),
@PassworEntidad AS VARCHAR(30),
@RolUserEntidad AS VARCHAR(10),
@Comentario AS TEXT,
@Status AS VARCHAR(10),
@NoEliminable AS BIT
AS
BEGIN
UPDATE Entidades
	SET Descripcion = @Descripcion,
	Direccion = @Direccion,
	Localidad = @Localidad,
	TipoEntidad = @TipoEntidad,
	TipoDocumento = @TipoDocumento,
	NumeroDocumento = @NumeroDocumento,
	Telefonos = @Telefonos,
	URLPaginaWeb = @URLPaginaWeb,
	URLFacebook = @URLFacebook,
	URLInstagram = @URLInstagram,
	URLTwitter = @URLTwitter,
	URLTikTok = @URLTikTok,
	IdGrupoEntidad = @IdGrupoEntidad,
	IdTipoEntidad = @IdTipoEntidad,
	LimiteCredito = @LimiteCredito,
	UserNameEntidad = @UserNameEntidad,
	PassworEntidad = @PassworEntidad,
	RolUserEntidad = @RolUserEntidad,
	Comentario = @Comentario,
	Status = @Status,
	NoEliminable = @NoEliminable
WHERE IdEntidad = @IdEntidad
END
GO


--Eliminar un registro de la tabla Entidades
CREATE PROCEDURE EntidadesEliminar
@IdEntidad AS INT
AS
BEGIN
DELETE FROM Entidades
WHERE IdEntidad = @IdEntidad
END
GO


--Buscar registros en la tabla Entidades segun un parametro
CREATE PROCEDURE EntidadesBuscar
@parametro AS varchar(40)
AS
BEGIN
	select *
	from Entidades
	where 
		Descripcion LIKE '%'+@parametro+'%' OR
		Direccion LIKE '%'+@parametro+'%' OR
		Localidad LIKE '%'+@parametro+'%' OR
		TipoEntidad LIKE '%'+@parametro+'%' OR
		TipoDocumento LIKE '%'+@parametro+'%' OR
		NumeroDocumento LIKE '%'+@parametro+'%' OR
		Telefonos LIKE '%'+@parametro+'%' OR
		URLPaginaWeb LIKE '%'+@parametro+'%' OR
		URLFacebook LIKE '%'+@parametro+'%' OR
		URLInstagram LIKE '%'+@parametro+'%' OR
		URLTwitter LIKE '%'+@parametro+'%' OR
		URLTikTok LIKE '%'+@parametro+'%' OR
		IdGrupoEntidad LIKE '%'+@parametro+'%' OR
		IdTipoEntidad LIKE '%'+@parametro+'%' OR
		LimiteCredito LIKE '%'+@parametro+'%' OR
		UserNameEntidad LIKE '%'+@parametro+'%' OR
		PassworEntidad LIKE '%'+@parametro+'%' OR
		RolUserEntidad LIKE '%'+@parametro+'%' OR
		Comentario LIKE '%'+@parametro+'%' OR
		Status LIKE '%'+@parametro+'%' OR
		NoEliminable LIKE '%'+@parametro+'%' OR
		FechaRegistro LIKE '%'+@parametro+'%' OR
		IdEntidad LIKE '%'+@parametro+'%'
END
GO



 --Cargar los datos del usuario para mostrarlos en el Status Bar
create proc MostrarDatos
@UserNameEntidad AS varchar(60)
as
select UserNameEntidad, Direccion, Localidad, Telefonos, RolUserEntidad
from Entidades 
where UserNameEntidad = @UserNameEntidad
go











---------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------
--PROCEDIMIENTOS DE LA TABLA GRUPOSENTIDADES

--Listar todos los registros de la tabla GruposEntidades
CREATE PROCEDURE GrEntidadesListar
AS
BEGIN
	select * 
	from GruposEntidades
END
GO


--Insertar un registro a la tabla GruposEntidades
CREATE PROCEDURE GrEntidadesInsertar
@Descripcion AS VARCHAR(120),
@Comentario AS TEXT,
@Status AS VARCHAR(10),
@NoEliminable AS BIT
AS
BEGIN
INSERT INTO GruposEntidades (Descripcion,Comentario,Status,NoEliminable)
VALUES (@Descripcion,@Comentario,@Status,@NoEliminable)
END
GO



--Editar un registro de la tabla GruposEntidades
CREATE PROCEDURE GrEntidadesActualizar
@IdGrupoEntidad AS INT,
@Descripcion AS VARCHAR(120),
@Comentario AS TEXT,
@Status AS VARCHAR(10),
@NoEliminable AS BIT
AS
BEGIN
UPDATE GruposEntidades
SET Descripcion = @Descripcion,
Comentario = @Comentario,
Status = @Status,
NoEliminable = @NoEliminable
WHERE IdGrupoEntidad = @IdGrupoEntidad
END
GO



--Eliminar un registro de la tabla GruposEntidades
CREATE PROCEDURE GrEntidadesEliminar
@IdGrupoEntidad AS INT
AS
BEGIN
DELETE FROM GruposEntidades
WHERE IdGrupoEntidad = @IdGrupoEntidad
END
GO



--Buscar registros en la tabla GruposEntidades segun un parametro
CREATE PROCEDURE GrEntidadesBuscar
@parametro AS varchar(40)
AS
BEGIN
	select *
	from GruposEntidades
	where 
		Descripcion LIKE '%'+@parametro+'%' OR
		Comentario LIKE '%'+@parametro+'%' OR
		Status LIKE '%'+@parametro+'%' OR
		NoEliminable LIKE '%'+@parametro+'%' OR
		FechaRegistro LIKE '%'+@parametro+'%' OR
		IdGrupoEntidad LIKE '%'+@parametro+'%'
END
GO







---------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------
--PROCEDIMIENTOS DE LA TABLA TIPOSENTIDADES

--Listar todos los registros de la tabla TiposEntidades
CREATE PROCEDURE TpEntidadesListar
AS
BEGIN
	select * 
	from TiposEntidades
END
GO


--Insertar un registro a la tabla TiposEntidades
CREATE PROCEDURE TpEntidadesInsertar
@Descripcion AS VARCHAR(120),
@IdGrupoEntidad AS INT,
@Comentario AS TEXT,
@Status AS VARCHAR(10),
@NoEliminable AS BIT
AS
BEGIN
INSERT INTO TiposEntidades (Descripcion,IdGrupoEntidad,Comentario,Status,NoEliminable)
VALUES (@Descripcion,@IdGrupoEntidad,@Comentario,@Status,@NoEliminable)
END
GO



--Editar un registro de la tabla TiposEntidades
CREATE PROCEDURE TpEntidadesActualizar
@IdTipoEntidad AS INT,
@Descripcion AS VARCHAR(120),
@IdGrupoEntidad AS INT,
@Comentario AS TEXT,
@Status AS VARCHAR(10),
@NoEliminable AS BIT
AS
BEGIN
UPDATE TiposEntidades
	SET Descripcion = @Descripcion,
	IdGrupoEntidad = @IdGrupoEntidad,
	Comentario = @Comentario,
	Status = @Status,
	NoEliminable = @NoEliminable
WHERE IdTipoEntidad = @IdTipoEntidad
END
GO



--Eliminar un registro de la tabla TiposEntidades
CREATE PROCEDURE TpEntidadesEliminar
@IdTipoEntidad AS INT
AS
BEGIN
DELETE FROM TiposEntidades
WHERE IdTipoEntidad = @IdTipoEntidad
END
GO



--Buscar registros en la tabla TiposEntidades segun un parametro
CREATE PROCEDURE TpEntidadesBuscar
@parametro AS varchar(40)
AS
BEGIN
	select *
	from TiposEntidades
	where 
		Descripcion LIKE '%'+@parametro+'%' OR
		IdGrupoEntidad LIKE '%'+@parametro+'%' OR
		Comentario LIKE '%'+@parametro+'%' OR
		Status LIKE '%'+@parametro+'%' OR
		NoEliminable LIKE '%'+@parametro+'%' OR
		FechaRegistro LIKE '%'+@parametro+'%' OR
		IdTipoEntidad LIKE '%'+@parametro+'%'
END
GO


INSERT INTO GruposEntidades(Descripcion,Comentario) VALUES('Grupo Lamborghini', 'Duenos del sistema xd');
go

INSERT INTO TiposEntidades(Descripcion,IdGrupoEntidad,Comentario) VALUES('Creadores', 1, 'Creadores del sistema xd');
go

INSERT INTO Entidades(Descripcion,Direccion,Localidad,NumeroDocumento,Telefonos,IdGrupoEntidad,
IdTipoEntidad,LimiteCredito,UserNameEntidad,PassworEntidad,RolUserEntidad,Comentario) 
VALUES('Administrador provisional', 'Calle 5ta #45', 'Barahona', 83278, '8297647368', 1,
1, 500000, 'Admin', 'Admin123', 'Admin', 'Usuario de emergencia para acceder al sistema');
go
