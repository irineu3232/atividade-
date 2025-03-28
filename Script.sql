create database ecomerse;
use  ecomerse;

Create table Usuario(
Id int primary key auto_increment,
Nome varchar(50) not null,
Email varchar(50) not null,
Senha varchar(50) not null
);

create table Produto(
Id int primary key auto_increment,
Descriçao varchar(240) not null,
Preco decimal(10,2) not null
);

select * from Usuario;
select * from Produto;