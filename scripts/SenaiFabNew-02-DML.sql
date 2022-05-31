use fabsenaiNew
go

insert into objeto(nome, imagem, verificado)
values ('computador', 'computador.jpeg', 1), ('impressora', 'impressora.png', 1);
go

insert into pessoa(nome, imagem, faceid, verificado)
values ('severino', 'severino.jpeg', '', 1), ('josué', 'josué.jpeg', '', 1);
go

insert into registroObjeto(IdObj, IdPessoa, checkIn, checkOut)
values (1, 1, '20220213 12:30:00', '20220213 12:40:00'), (2, 2, '20220213 12:17:00', '20220213 12:30:00');
go

insert into registroPessoa(IdPessoa, checkIn, checkOut)
values ('1', '20220213 07:30:00', '20220213 18:50:00'), ('2', '20220213 08:45:00', '20220213 18:50:00');
go

insert into TipoUser(nome)
values ('Administrador'), ('Guarda');
go

insert into Usuario(IdTipo, email, senha)
values ('1', 'adm@adm.com', 'adm@132'), ('2', 'user@user.com', 'user@132');
go