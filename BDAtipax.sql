drop database if exists BDAtipax
create database BDAtipax
use BDAtipax

--use master

-- tables
create table tb_tour(
idTour char(5) primary key not null,
precio decimal(7,2) not null,
descripcion nvarchar(100) not null
)
go
create table tb_hotel(
idHotel char(5) primary key not null,
nomHotel nvarchar(20) not null,
categoria nvarchar(15) not null,
precioHotel decimal(6,2) not null,
descripcion nvarchar(50) not null,
idTour char(5) not null,
foreign key(idTour) references tb_tour(idTour)
)
go
create table tb_destino(
idDestino char(5) primary key not null,
pais nvarchar(40) not null,
ciudad nvarchar(40) not null,
idHotel char(5) not null,
foreign key(idHotel) references tb_hotel(idHotel)
)
go
insert into tb_destino values('D0001','Peru','Lima','H0001')

							 

go
select * from tb_destino


create table tb_cliente(
idCliente char(6) primary key not null,
nombre nvarchar(40)not null,
apePaterno nvarchar(20) not null,
apeMaterno nvarchar(20) not null,
dni char(8) not null,
telefono char(9) not null,
correo nvarchar(40) not null 
)
go
insert into tb_cliente values('C00001','Dario','Yaranga','Verano','12345678','987654327','Veranod@atipax.com')
insert into tb_cliente values('C00002','Anghela','Sanchez','Castillo','47345678','927684321','Sanchez@atipax.com')
insert into tb_cliente values('C00003','Marco','Castañeda','Solis','42345678','917684326','Castañeda@atipax.com')


create table tb_usuarios(
idUsu int primary key  identity(1,1) not null,
usuario nvarchar(13) not null,
pass nvarchar(15) not null
)
go

create table tb_compra(

idCompra char(6) primary key not null,
cantidadPerson int not null,
total decimal(10,2) not null,
fechaInicio date not null,
fechaFin date not null,
idHotel char(5) not null,
idTour char(5) not null,
idDestino char(5) not null,
idCliente char(6) not null,
foreign key(idTour) references tb_tour(idTour),
foreign key(idHotel) references tb_hotel(idHotel),
foreign key(idDestino) references tb_destino(idDestino),
foreign key(idCliente) references tb_cliente(idCliente)
)
go

create procedure usp_usuarios_listar
	as
	select * from tb_usuarios
	go

create procedure usp_tour_listar
	as
	select * from tb_tour
	go

create procedure usp_hotel_listar
	as
	select * from tb_hotel
	go

create procedure usp_destino_listar
	as
	select * from tb_destino
	go

create procedure usp_cliente_listar
	as
	select * from tb_cliente
	go

create procedure usp_compra_listar
	as
	select * from tb_compra
	go
