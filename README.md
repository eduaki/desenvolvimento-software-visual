# 🧾 Gerenciador de Inventário

API desenvolvida em **ASP.NET Core Web API** com **Entity Framework Core** e
**SQLite** para controle de bens patrimoniais, permitindo o registro, consulta e
gerenciamento de **itens**, **usuários**, **tipos** e **requisições**.

---

## 🚀 Tecnologias Utilizadas

- **ASP.NET Core Web API (.NET 7, 8 e 9 compatível)**
  > O projeto é compatível com as versões do .NET **7 a 9** — basta ajustar o
  > `<TargetFramework>` no arquivo `.csproj` conforme o SDK instalado no
  > ambiente de execução.
  ```xml
  <PropertyGroup>
      <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>
  ```
- **Entity Framework Core** — ORM para persistência dos dados.
- **SQLite** — banco de dados leve e portátil.
- **Swagger / OpenAPI** — documentação e testes de endpoints.
- **C#** — linguagem principal de desenvolvimento.

---

## 🗂️ Estrutura das Entidades

| Entidade       | Descrição                                                          |
| -------------- | ------------------------------------------------------------------ |
| **Item**       | Representa um bem físico cadastrado (ex: notebook, mesa, veículo). |
| **Tipo**       | Classificação do item (ex: informática, mobiliário).               |
| **Usuário**    | Pessoa responsável ou solicitante da requisição.                   |
| **Requisição** | Registro de movimentação ou solicitação de uso de um item.         |

---

## 📡 Endpoints da API

### 🧩 Itens (`/api/Itens`)

| Método     | Rota              | Descrição                               |
| ---------- | ----------------- | --------------------------------------- |
| **GET**    | `/api/Itens`      | Lista todos os itens cadastrados.       |
| **GET**    | `/api/Itens/{id}` | Busca um item específico pelo ID.       |
| **POST**   | `/api/Itens`      | Cadastra um novo item no inventário.    |
| **PUT**    | `/api/Itens/{id}` | Atualiza os dados de um item existente. |
| **DELETE** | `/api/Itens/{id}` | Remove um item do sistema.              |

#### Exemplo de `POST`

```json
{
	"nome": "Notebook Dell Inspiron",
	"descricao": "Intel i7, 16GB RAM, SSD 512GB",
	"valor": 4500.0,
	"iD_tipo": 1
}
```

---

### 👥 Usuários (`/api/Usuarios`)

| Método     | Rota                 | Descrição                              |
| ---------- | -------------------- | -------------------------------------- |
| **GET**    | `/api/Usuarios`      | Retorna todos os usuários cadastrados. |
| **GET**    | `/api/Usuarios/{id}` | Retorna um usuário pelo ID.            |
| **POST**   | `/api/Usuarios`      | Cadastra um novo usuário.              |
| **PUT**    | `/api/Usuarios/{id}` | Atualiza os dados de um usuário.       |
| **DELETE** | `/api/Usuarios/{id}` | Exclui um usuário.                     |

#### Exemplo de `POST`

```json
{
	"nome": "Eduardo Candido",
	"cpf": "123.456.789-00",
	"area": "Tecnologia",
	"endereco": "Rua Exemplo, 123 - Curitiba/PR",
	"telefone": "(41) 99999-0000",
	"email": "eduardo.candido@empresa.com",
	"data_Nascimento": "2004-03-12"
}
```

---

### 🏷️ Tipos (`/api/Tipos`)

| Método     | Rota              | Descrição                      |
| ---------- | ----------------- | ------------------------------ |
| **GET**    | `/api/Tipos`      | Lista todos os tipos de itens. |
| **GET**    | `/api/Tipos/{id}` | Retorna um tipo específico.    |
| **POST**   | `/api/Tipos`      | Cadastra um novo tipo.         |
| **PUT**    | `/api/Tipos/{id}` | Atualiza um tipo existente.    |
| **DELETE** | `/api/Tipos/{id}` | Exclui um tipo.                |

#### Exemplo de `POST`

```json
{
	"nome": "Informática"
}
```

---

### 📦 Requisições (`/api/Requisicoes`)

| Método     | Rota                    | Descrição                               |
| ---------- | ----------------------- | --------------------------------------- |
| **GET**    | `/api/Requisicoes`      | Lista todas as requisições registradas. |
| **GET**    | `/api/Requisicoes/{id}` | Busca uma requisição específica.        |
| **POST**   | `/api/Requisicoes`      | Cria uma nova requisição de item.       |
| **DELETE** | `/api/Requisicoes/{id}` | Exclui uma requisição.                  |

#### Exemplo de `POST`

```json
{
	"iD_item": 3,
	"iD_usuario": 1,
	"status": "Em andamento",
	"dataRequisicao": "2025-11-07T10:00:00Z"
}
```

---

## 🧠 Observações Técnicas

- A API segue o padrão **RESTful** com rotas auditáveis.
- As requisições e respostas utilizam o formato **JSON**.
- O projeto está configurado com **Swagger** para testes e visualização
  interativa das rotas.
- Banco de dados gerenciado via **Entity Framework Core** com suporte a
  migrações (`dotnet ef migrations add Initial`).

---

## 🧰 Como Executar o Projeto

```bash
# Clonar o repositório
git clone https://github.com/seuusuario/gerenciador_inventario.git

# Entrar na pasta
cd gerenciador_inventario

# Restaurar dependências
dotnet restore

# Executar o projeto
dotnet run
```

Após executar, acesse no navegador:  
👉 **http://localhost:5116/swagger**

---

## 👨‍💻 Desenvolvido por

**[Eduardo Alves](https://github.com/eduaki)**,
**[Yasmin Faraj](https://github.com/YasminFaraj)**,
**[Israel Ribeiro](https://github.com/israelnobre15)** e
**[Tainara Lachowski](https://github.com/tailachowski)**  
📚 Universidade Positivo — Projeto A2: Desenvolvimento de Software Visual  
🗓️ **Ano:** 2025
