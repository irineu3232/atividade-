create database ecomerse;
use  ecomerse;

Create table Usuarios(
Id int primary key auto_increment,
Nome varchar(50) not null,
Email varchar(50) not null,
Senha varchar(50) not null
);

create table Produtos(
Id int primary key auto_increment,
Descriçao varchar(240) not null,
Preco float not null
);
