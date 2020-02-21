--DQL 

USE M_Peoples;
GO

--Exibi todas as informa��es da tabela Funcionario
SELECT * FROM Funcionario;

--Exibi as informa��es de um objeto pelo seu ID
SELECT * FROM Funcionario WHERE IdFun = 1;

--Buscando objeto pelo seu nome
CREATE PROCEDURE BuscarNome @NomeFun VARCHAR(255)
AS
SELECT * FROM Funcionario WHERE NomeFun = @NomeFun;

EXEC BuscarNome 'Luciano'

--Listando funcion�rios em ordem alfab�tica 
CREATE PROCEDURE ordemnsASC
AS
SELECT * FROM Funcionario ORDER BY NomeFun ASC

EXEC ordemnsASC


