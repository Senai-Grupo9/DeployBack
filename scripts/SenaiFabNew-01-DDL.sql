create table tipoObjeto(
	IdTipoObj tinyint primary key identity(1,1),
	nome varchar(20),
)
go

create table pessoa(
	IdPessoa tinyint primary key identity(1,1),
	nome varchar(50),
	imagem varchar(100),
	faceid varchar(100),
	verificado bit,
)
go

create table registroObjeto(
	IdRegistroObj tinyint primary key identity(1,1),
	IdTipoObj tinyint foreign key references tipoObjeto(IdTipoObj),
	IdPessoa tinyint foreign key references pessoa(IdPessoa),
	checkIn datetime,
	checkOut datetime,
)
go

create table registroPessoa(
	IdRegistroPessoa tinyint primary key identity(1,1),
	IdPessoa tinyint foreign key references pessoa(IdPessoa),
	checkIn datetime,
	checkOut datetime,
)
go

create table TipoUser(
	IdTipo tinyint primary key identity(1,1),
	nome varchar(30),
)
go

create table Usuario(
	IdUser tinyint primary key identity(1,1),
	IdTipo tinyint foreign key references TipoUser(IdTipo),
	email varchar(50),
	senha varchar(200),
)
go