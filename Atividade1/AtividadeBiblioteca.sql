DROP DATABASE Biblioteca

CREATE DATABASE Biblioteca

USE Biblioteca

CREATE TABLE Usuario(
UsuarioID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
Nome NVARCHAR(50),
Email NVARCHAR(100),
Senha VARBINARY(32) NOT NULL
)

CREATE TABLE Livro(
LivroID INT IDENTITY PRIMARY KEY,
Nome NVARCHAR(50),
Autor NVARCHAR(50),
Descricao NVARCHAR(MAX),
DataPublicacao DATETIME,
Imagem VARBINARY(MAX),
UsuarioID UNIQUEIDENTIFIER,
CONSTRAINT fk_livro_Usuario
FOREIGN KEY (UsuarioID)
REFERENCES Usuario(UsuarioID)
)

INSERT INTO Usuario(Nome, Email, Senha)
VALUES('Admin', 'string', HASHBYTES('SHA2_256', 'string')
)

SELECT * FROM Usuario

INSERT INTO Livro(Nome, Autor, Descricao, DataPublicacao, UsuarioID)
VALUES('O Senhor dos Anéis: As Duas Torres','J. R. R. Tolken', 'Livro de fantasia medieval, O Senhor dos Anéis: As Duas Torres é uma continuação direta de O Senhor dos Anéis: A Sociedade do Anel.', '1954-11-11', 'CB2F3A8A-D870-4B95-B989-2C4EC3629B46')

SELECT * FROM Livro