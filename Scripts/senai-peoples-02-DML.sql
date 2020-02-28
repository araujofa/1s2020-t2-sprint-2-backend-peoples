USE T_Peoples;

INSERT INTO Funcionarios(Nome, Sobrenome, DataNascimento)
VALUES ('Catarina', 'Strada', '01/09/2000'), ('Tadeu', 'Vitelli', '10/03/2000');

INSERT INTO TipoUsuario (Titulo)
VALUES ('Administrador'), ('Comum');

INSERT INTO Usuarios (Nome, Email, Senha, IdTipoUsuario)
VALUES ('Fabio Araujo', 'araujosilvafabio@hotmail.com', '123', 2), ('Felipe Sabino', 'felipe@hotmail.com', '123', 1);

DROP TABLE Usuarios

DROP TABLE TipoUsuario