drop database  BDAtipax
create database BDAtipax
use BDAtipax

use master

-- tables

/*create table tb_roles
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

insert into tb_usuario values(1,'admi@gmail.com','admi',1)
insert into tb_usuario values(2,'cliente@gmail.com','cliente',2)
go
*/
create table tb_tour(
idTour int primary key ,
precio decimal not null,
descripcion nvarchar(100) not null
)
go

-- Insertando datos
insert into tb_tour values(1,0,'No existe tour')
insert into tb_tour values(2,300,'medio dia')
insert into tb_tour values(3,100,'city tour')
insert into tb_tour values(4,100,'full day')
--select*from tb_tour

--select*from tb_hotel
go

create  table tb_hotel(
idHotel int primary key ,
nomHotel nvarchar(20) not null,
categoria nvarchar(15) not null,
precioHotel decimal not null,
descripcion nvarchar(50) not null,
idTour int DEFAULT 1,
foreign key(idTour) references tb_tour(idTour)
on update cascade
on delete  set DEFAULT
)
go

-- Insertando datos a tb_hotel
insert into tb_hotel values(1,'Sin asignar','Sin asignar',0,'Sin asignar',1)
insert into tb_hotel values(2,'Sheraton','5 estrellas',150,'Completo',2)
insert into tb_hotel values(3,'Marriot','4 estrellas',140,'Semi completo',3)

--select*from tb_hotel
create table tb_categorias(
IdCategoria int primary key not null,
NombreCategoria varchar(15) not null
)
insert into tb_categorias values(1,'Sin asignar')
insert into tb_categorias values(2,'Internacionales')
insert into tb_categorias values(3,'Nacionales')
insert into tb_categorias values(4,'Europa')
--select * from tb_categorias 

--select * from tb_categorias 



create table tb_destino(
idDestino int primary key not null,
pais nvarchar(40) not null,
ciudad nvarchar(40) not null,
idHotel int DEFAULT 1,
IdCategoria int not null DEFAULT 1,
precio decimal not null,
UnidadesEnExistencia smallint not null,
foreign key(idHotel) references tb_hotel(idHotel),
foreign key(IdCategoria) references tb_categorias(IdCategoria)
on update cascade
on delete set DEFAULT
)
go

--delete from tb_destino
--

insert into tb_destino values(1,'España','Madrid',2,3,15000,5)
insert into tb_destino values(2,'Peru','Lima',2,2,3000,10)
insert into tb_destino values(3,'Chile','Santiago',3,4,2000,4)
						 


create table tb_pedidos(
	idpedido int primary key,
	fpedido datetime default(getdate()),
	dni varchar(8),
	nombre varchar(255),
	email varchar(255)
)
go

create table tb_pedidos_deta(
	idpedido int references tb_pedidos,
	idDestino int references tb_destino,
	cantidad int,
	precio decimal
)

go

-- ************ PROCEDURES **********
create or alter function dbo.autogenera() returns int
As
Begin 
	Declare @n int=(Select top 1 idpedido from tb_pedidos order by 1 desc)
	if(@n is null)
		Set @n=1
	else
		Set @n+=1
	return @n
End
go

create or alter proc usp_agrega_pedido
@idpedido int output,
@dni varchar(8),
@nombre varchar(255),
@email varchar(255)
As
Begin
	Set @idpedido=dbo.autogenera()
	insert tb_pedidos(idpedido,dni,nombre,email) Values(@idpedido,@dni,@nombre,@email)
End
go

create or alter procedure usp_agrega_detalle
@idpedido int,
@idDestino int,
@cantidad int,
@precio decimal
As
Insert tb_pedidos_deta Values(@idpedido,@idDestino,@cantidad,@precio)
go

create or alter proc usp_actualiza_stock
@idDestino int,
@cant smallint
As
Update tb_destino Set UnidadesEnExistencia-=@cant Where idDestino=@idDestino

go
						 
--*************************************************************************************



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

create procedure usp_categorias_list
as
select*from tb_categorias
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

--drop procedure usp_validar_usuario
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
@idHo int,
@idCate int,
@pre decimal,
@uni smallint
As
Insert tb_destino values (@idDes,@pais,@ciu,@idHo,@idCate,@pre,@uni)
go

create procedure usp_agregar_categoria
@idCa int,
@nom varchar(15)
As
Insert tb_categorias values (@idCa,@nom)
go

create or alter procedure usp_actualizar_tour
@idTo int,
@pre decimal,
@des varchar(100)
As
Update tb_tour
Set  precio= @pre ,descripcion=@des
Where idTour=@idTo
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
Set nomHotel= @nom ,categoria=@cate,precioHotel =@pre,descripcion=@des,idTour=@idTo
Where idHotel=@idHo  
go

create or alter procedure usp_actualizar_categoria
@idCa int,
@nom varchar(15)
As
Update tb_categorias
Set NombreCategoria= @nom
Where IdCategoria=@idCa
go

create or alter procedure usp_actualizar_destino

@idDes int,
@pais varchar(40),
@ciu varchar(40),
@idHo int,
@idCate int,
@pre decimal,
@uni smallint
As
Update tb_destino 
Set pais= @pais,ciudad=@ciu,idHotel= @idHo, IdCategoria=@idCate, precio=@pre, UnidadesEnExistencia=@uni
Where idDestino=@idDes
go



create procedure usp_eliminar_tour
@idTo int
as
	delete from tb_tour
	where idTour = @idTo
go

create procedure usp_eliminar_hotel
@idHo int
as
	delete from tb_hotel
	where idHotel= @idHo
go
create procedure usp_eliminar_destino
@idDe int
as
	delete from tb_destino
	where idDestino = @idDe
go
create procedure usp_eliminar_categoria

@idCa int
as
	delete from tb_categorias
	where IdCategoria = @idCa
go

--consultar por destino
/*create procedure usp_consultar_destino
@pa varchar(40),
@ciu varchar(40)
as
	select d.idDestino, d.pais, d.ciudad, h.nomHotel
	from tb_destino d join tb_hotel h on d.idHotel = h.idHotel
	where d.pais = @pa OR d.ciudad =@ciu
	
go*/

create procedure usp_consultar_destino
@pa varchar(40)
as
	select d.idDestino, d.pais, d.ciudad, h.nomHotel
	from tb_destino d join tb_hotel h on d.idHotel = h.idHotel
	where d.pais= @pa 
go

exec usp_consultar_destino Chile,Lima
--exec usp_eliminar_tour 3
--select* from tb_hotel
--select*from tb_tour
--exec usp_tour_listar
--update tb_hotel set idTour=2 where idHotel=2
--insert into tb_tour values(3,0,'Sin tour')
--insert into tb_tour values(1,45,'TOUR A')
--insert into tb_tour values(2,67,'TOUR B')
drop table tb_compra
drop table tb_cliente
drop table tb_destino
drop table tb_hotel
drop table tb_tour
drop procedure usp_tour_listar
--usp_hotel_lis
--usp_destino_list