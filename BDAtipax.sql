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
