# CrudAPI
Passar os headers com os parametros username e password para autenticação da API
script para o banco de dados

create table Usuario (
    ID int primary key not null,
    Nome varchar(100) not null,
    Idade int not null,
    Sexo varchar(20) not null,
    Rua varchar(100) not null,
    Numero int not null,
    Complemento varchar(100) not null,
    Bairro varchar(100) not null,
    Cidade varchar(100) not null,
    Estado varchar(100) not null,
    Pais varchar(100) not null,
    DocumentoTipo varchar(20) not null,
	Documento varchar(20) not null
);

create table Login(
	ID int primary key not null,
	Username varchar(100) not null,
	Password varchar(100) not null
)

//CRIAÇÃO DO USUARIO PARA LOGIN
insert into login(ID, Username, Password) values (0, 'admin','admin')

-- os Id's estão sendo passados manualmente durante as criações de usuários;

API endpoints :

GET
/api/Controller/Get
 - Busca todos os usuários cadastrados no banco;

POST
/api/Controller/Create
 - Cria um usuário;
   Passar um JSON no corpo da requisição, exemplo --- 
    {
        "id":5,
        "nome": "Usuario 2",
        "idade": 5,
        "sexo": "Mulher",
        "documentoTipo": "RG",
        "documento": "wqeweeweqw",
        "rua": "Rua",
        "numero": 3,
        "complemento": "Complemento",
        "bairro": "Bairro",
        "cidade": "Cidade",
        "estado": "312",
        "pais": "154"
    }

/api/Controller/Update

-- Atualiza os dados de um usuário;
mesmo padrão de JSON do create;


/api/Controller/CreateLogin
-- Cria um usuário de login;
exemplo de json -- 
{
    "id"        : "2",
    "username" : "admin2",
    "password" : "admin2"

}

DELETE
/api/Controller/Delete?ID=1
--Deleta o registro com o id passado por query;
