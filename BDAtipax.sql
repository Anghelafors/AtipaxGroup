drop database  BDAtipax
create database BDAtipax
use BDAtipax

--use master

-- tables

create table tb_roles
(
 idRol int primary key not null,
 nombre varchar(50) not null

  
)

create table tb_usuario
(
 idUsuario int primary key not null,
 usuario varchar(20),
 pass varchar(15),
 idRol int not null,
 foreign key (idRol) references tb_roles(idRol)
)

insert into tb_roles values(1,'Administrador')
insert into tb_roles values(2,'Cliente')

--select*from tb_usuario
insert into tb_usuario values(1,'admi@gmail.com','admi',1)
insert into tb_usuario values(2,'cliente@gmail.com','cliente',2)
go

create table tb_tour(
idTour int primary key not null,
precio decimal not null,
descripcion nvarchar(100) not null
)
go
-- Insertando datos
insert into tb_tour values(1,'full day',500)
insert into tb_tour values(2,'medio dia',300)
insert into tb_tour values(3,'city tour',100)

--select*from tb_tour

go
--drop table tb_hotel
go
create table tb_hotel(
idHotel int primary key not null,
nomHotel nvarchar(20) not null,
categoria nvarchar(15) not null,
precioHotel decimal not null,
descripcion nvarchar(50) not null,
idTour int not null,
foreign key(idTour) references tb_tour(idTour)
)
go
-- Insertando datos a tb_hotel
insert into tb_hotel values(1,'Sheraton','5 estrellas',150,'completo',2)
insert into tb_hotel values(2,'Marriot','4 estrellas',140,'Semi completo',1)

--select*from tb_hotel
create table tb_categorias(
IdCategoria int primary key not null,
NombreCategoria varchar(15) not null
)
insert into tb_categorias values(1,'Nacionales')
insert into tb_categorias values(2,'Internacionales')

--select * from tb_categorias 

go
drop table tb_destino
create table tb_destino(
idDestino int primary key not null,
pais nvarchar(40) not null,
ciudad nvarchar(40) not null,
idHotel int not null,
IdCategoria int not null,
foreign key(idHotel) references tb_hotel(idHotel),
foreign key(IdCategoria) references tb_categorias(IdCategoria)
)
go
--Agregar una nueva columna a la tabla destino
alter table tb_destino add precio decimal not null

--delete from tb_destino
go
insert into tb_destino values(1,'Peru','Lima',1,2,1500)
insert into tb_destino values(2,'Chile','Santiago',2,1,3000)
						 


--select * from tb_destino

-- modificar
create table tb_cliente(
idCliente int primary key not null,
nombre nvarchar(40)not null,
apePaterno nvarchar(20) not null,
apeMaterno nvarchar(20) not null,
dni char(8) not null,
telefono char(9) not null,
correo nvarchar(40) not null 
)
go
/*insert into tb_cliente values('C00001','Dario','Yaranga','Verano','12345678','987654327','Veranod@atipax.com')
insert into tb_cliente values('C00002','Anghela','Sanchez','Castillo','47345678','927684321','Sanchez@atipax.com')
insert into tb_cliente values('C00003','Marco','Castañeda','Solis','42345678','917684326','Castañeda@atipax.com')
*/


create table tb_compra(

idCompra int primary key not null,
cantidadPerson int not null,
total decimal(10,2) not null,
fechaInicio date not null,
fechaFin date not null,
idHotel int not null,
idTour int not null,
idDestino int not null,
idCliente int not null,
foreign key(idTour) references tb_tour(idTour),
foreign key(idHotel) references tb_hotel(idHotel),
foreign key(idDestino) references tb_destino(idDestino),
foreign key(idCliente) references tb_cliente(idCliente)
)
go

/*create procedure usp_usuarios_listar
	as
	select * from tb_usuarios
	go
*/
create procedure usp_tour_listar
	as
	select * from tb_tour
	go

/*create or alter proc usp_hotel_listar
As
select h.idHotel, h.nomHotel, h.categoria, h.precioHotel, h.descripcion , t.descripcion
from tb_hotel h join tb_tour t on h.idTour = t.idTour
go

create or alter procedure usp_destino_listar
	as
	select d.idDestino, d.pais, d.ciudad, h.nomHotel
	from tb_destino d join tb_hotel h on d.idHotel = h.idHotel
	go
	*/
	create procedure usp_hotel_lis
	As
	select * from tb_hotel
	go
create procedure usp_destino_list
as
select * from tb_destino
go
/*create procedure usp_cliente_listar
	as
	select * from tb_cliente
	go
*/
create procedure usp_compra_listar
	as
	select * from tb_compra
	go

create procedure usp_validar_usuario
@usu  varchar(20),
@pass varchar(15)
as
Select*from tb_usuario u Where @usu=u.usuario And @pass= u.pass
go

--ejecutar
--exec usp_validar_usuario 'cliente@gmail.com','cliente'

create procedure usp_agregar_tour
@idTo int,
@pre decimal,
@des varchar(100)
As
Insert tb_tour values (@idTo,@pre,@des)
go

create or alter procedure usp_agregar_hotel
@idHo int,
@nom varchar(20),
@cate varchar(15),
@pre decimal,
@des varchar(50),
@idTo int

As
Insert tb_hotel values (@idHo,@nom,@cate,@pre,@des,@idTo)
go


create or alter procedure usp_agregar_destino

@idDes int,
@pais varchar(40),
@ciu varchar(40),
@idHo int
As
Insert tb_destino values (@idDes,@pais,@ciu,@idHo)
go

create procedure usp_actualizar_tour
@idTo int,
@pre decimal,
@des varchar(100)
As
Update tb_tour 
Set @pre=precio,@des=descripcion
Where @idTo = idTour
go

create or alter procedure usp_actualizar_hotel
@idHo int,
@nom varchar(20),
@cate varchar(15),
@pre decimal,
@des varchar(50),
@idTo int

As
Update tb_hotel
Set @nom = nomHotel,@cate=categoria,@pre=precioHotel,@des=descripcion,@idTo=idTour
Where @idHo = idHotel
go

create or alter procedure usp_actualizar_destino

@idDes int,
@pais varchar(40),
@ciu varchar(40),
@idHo int
As
Update tb_destino 
Set @pais=pais,@ciu=ciudad,@idHo=idHotel
Where @idDes = idDestino
go
