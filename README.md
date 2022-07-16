
# Olá! 👋


## Badges

[![Commit](https://img.shields.io/github/commit-activity/y/limup/capta-gestao-cliente)](https://img.shields.io/github/commit-activity/y/limup/capta-gestao-cliente)
[![Size](https://img.shields.io/github/repo-size/limup/capta-gestao-cliente)](https://img.shields.io/github/repo-size/limup/capta-gestao-cliente)
[![limup](https://img.shields.io/github/followers/limup?style=plastic)](https://img.shields.io/github/followers/limup?style=social)


## Tech Stack

**Client:** Windows Form, C#

**Server:** dotnet core 7, WebAPI

**Database:** SQL Server

# capta-gestao-cliente

Sistema de Gestão de Clientes Simples



## Executando API CaptaAPI

Clone o projeto inteiro

```bash
  git clone https://github.com/limup/capta-gestao-cliente.git
```

Acesse a pasta

```bash
  cd captaApi
```

Restaure e Compile as dependencias

```bash
  dotnet restore
  dotnet build
```

Execute as migrations do Entity Frameworks

```bash
  dotnet ef migrations add InitialCreate
```

Atualize as tabelas ef

```bash
  dotnet ef update
```

Serve a API

```bash
  dotnet run
```


## Executando APP CaptaAPP no Windows

Acesse a pasta

```bash
  cd /"Capta Tecnologia"/"Capta Tecnologia"/bin/Debug
```

Execute o arquivo 

```bash
  Capta Tecnologia.exe
```

## API Reference

#### SWAGGER

```http
  http://localhost:5054/swagger/index.html
```

#### Listar todos os clientes

```http
  GET /Cliente/Listar
```

#### Cadastrar cliente

```http
  POST /Cliente/Cadastrar/${id}
```

```Json
{
  "id": 0,
  "nome": "string",
  "cpf": 0,
  "sexo": "string",
  "tbDominios": [
    {
      "id": 0,
      "tipo": "string",
      "situacao": true
    }
  ]
}

```
#### Atualizar cliente

```http
  PUT /Cliente/Cadastrar/${id}
```

```Json
{
  "id": 0,
  "nome": "string",
  "cpf": 0,
  "sexo": "string",
  "tbDominios": [
    {
      "id": 0,
      "tipo": "string",
      "situacao": true
    }
  ]
}
```

#### Deletar cliente

```http
  DELETE /Cliente/Cadastrar/${id}
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `id` | `int` | **Required**. Id do cliente |

## Pacotes

- SQL Scritps: https://github.com/limup/capta-gestao-cliente/blob/main/captaApi/Script/script.sql


## 🛠 Skills
C#


## Authors

- [@limup](https://www.github.com/limup)


## Support

para suporte, email limup@outlook.com.

