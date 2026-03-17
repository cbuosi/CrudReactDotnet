# 🚀 CRUD React + .NET + Dapper

Projeto de estudo full-stack utilizando **React no frontend** e
**ASP.NET Core no backend**.

Objetivo do projeto: aprender integração entre **frontend moderno** e
**API REST em C#**, implementando um CRUD completo com SQL Server.

------------------------------------------------------------------------

# 🧰 Tecnologias utilizadas

## Backend

-   C#
-   ASP.NET Core Web API
-   Dapper
-   SQL Server

## Frontend

-   React
-   Vite
-   Axios
-   JavaScript

## Ferramentas

-   Git
-   Node.js
-   Visual Studio / VS Code
-   Postman

------------------------------------------------------------------------

# 📷 Preview

### Lista de clientes

  ID   Nome           UF   Cargo
  ---- -------------- ---- ----------
  1    Carlos Silva   SP   Gerente
  2    Ana Souza      RJ   Analista

Funcionalidades disponíveis:

✔ Listar clientes\
✔ Filtrar por nome\
✔ Criar cliente\
✔ Editar cliente\
✔ Excluir cliente

------------------------------------------------------------------------

# 🗂 Estrutura do projeto

    CrudReactDotnet
    │
    ├── CrudApi
    │   ├── Controllers
    │   │   ├── ClientesController.cs
    │   │   └── CargosController.cs
    │   │
    │   ├── Models
    │   │   ├── Cliente.cs
    │   │   └── Cargo.cs
    │   │
    │   ├── Repository
    │   │   └── Repo.cs
    │   │
    │   └── Program.cs
    │
    └── crud-react
        ├── src
        │   ├── components
        │   │   ├── ClienteForm.jsx
        │   │   └── ClienteGrid.jsx
        │   │
        │   ├── pages
        │   │   └── Clientes.jsx
        │   │
        │   └── services
        │       └── api.js

------------------------------------------------------------------------

# ⚙️ Como executar o projeto

## 1️⃣ Clonar o repositório

``` bash
git clone https://github.com/SEU_USUARIO/crud-react-dotnet.git
```

------------------------------------------------------------------------

# 🖥 Rodar Backend (.NET)

Entrar na pasta da API:

``` bash
cd CrudApi
```

Executar:

``` bash
dotnet run
```

API disponível em:

    http://localhost:5194

Endpoints principais:

    GET     /api/clientes
    GET     /api/clientes/{id}
    POST    /api/clientes
    PUT     /api/clientes/{id}
    DELETE  /api/clientes/{id}

    GET     /api/cargos

------------------------------------------------------------------------

# 🌐 Rodar Frontend (React)

Entrar na pasta do frontend:

``` bash
cd crud-react
```

Instalar dependências:

``` bash
npm install
```

Rodar aplicação:

``` bash
npm run dev
```

Abrir no navegador:

    http://localhost:5173

------------------------------------------------------------------------

# 🗄 Banco de dados

Banco utilizado:

**SQL Server**

Estrutura simplificada:

## Tabela Cliente

  Campo            Tipo
  ---------------- ---------
  Id               int
  Nome             varchar
  DataNascimento   date
  Endereco         varchar
  UF               char(2)
  CargoId          int

## Tabela Cargo

  Campo   Tipo
  ------- ---------
  Id      int
  Nome    varchar

------------------------------------------------------------------------

# 🧠 Conceitos estudados

Este projeto cobre conceitos importantes de desenvolvimento full-stack:

### Backend

-   API REST
-   Repository Pattern
-   Dapper
-   CORS
-   DTO / Model binding

### Frontend

-   React Hooks (`useState`, `useEffect`)
-   Componentização
-   Consumo de API
-   CRUD em interface web
-   Gerenciamento de estado simples

------------------------------------------------------------------------

# 📈 Possíveis melhorias

-   Paginação na grid
-   Ordenação de colunas
-   Modal para edição
-   Validação de formulário
-   Material UI / Tailwind
-   Autenticação JWT
-   Dockerização

------------------------------------------------------------------------

# 📚 Objetivo educacional

Este projeto foi desenvolvido como **laboratório de aprendizado** para
praticar integração entre:

-   Frontend moderno
-   API REST
-   Banco de dados relacional

------------------------------------------------------------------------

# 👨‍💻 Autor

Carlos Buosi

------------------------------------------------------------------------

# ⭐ Contribuição

Pull requests são bem-vindos.

Se este projeto te ajudou, considere dar uma ⭐ no repositório.
