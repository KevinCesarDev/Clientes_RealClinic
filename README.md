# CRUD de Lista de Clientes - Aplicação Web Forms

## Descrição do Projeto
Este projeto é uma aplicação web desenvolvida em ASP.NET Web Forms que realiza o gerenciamento de uma lista de clientes. A aplicação permite criar, visualizar, editar e excluir registros de clientes. Além disso, possui funcionalidades avançadas, como paginação, filtragem e ordenação dos dados.

## Funcionalidades
- **Cadastrar Cliente**: Adicionar novos clientes à lista com informações como nome, e-mail, telefone, etc.
- **Listar Clientes**: Exibir uma tabela com todos os clientes cadastrados no sistema.
- **Editar Cliente**: Modificar as informações de um cliente específico.
- **Excluir Cliente**: Remover um cliente da lista.
- **Validação de Dados**: As entradas de formulário são validadas para garantir a integridade dos dados.
- **Paginação**: Exibe 5 clientes por página, com controle para navegar 3 páginas por vez, ou ir diretamente à primeira ou última página.
- **Filtragem**: Filtrar a lista de clientes por nome, ID ou data de nascimento.
- **Ordenação**: Ordenar a lista de clientes em ordem crescente ou decrescente.
- **Status de Clientes**: Visualizar clientes ativos, inativos ou todos.

## Tecnologias Utilizadas
- **ASP.NET Web Forms**: Estrutura principal do projeto.
- **SQL Server**: Banco de dados utilizado para armazenamento dos dados dos clientes.
- **Bootstrap**: Framework CSS para a criação de layouts responsivos.
- **JavaScript (JS)**: Usado para interações dinâmicas na interface.
- **CSS**: Para estilização customizada da aplicação.

## Instalação e Configuração

### Pré-requisitos
- Visual Studio (ou outra IDE compatível com ASP.NET)
- SQL Server
- .NET Framework instalado

### Passos para rodar o projeto

1. **Clone o repositório:**

    ```bash
    git clone https://github.com/seu-usuario/seu-repositorio.git
    ```

2. **Configuração do Banco de Dados:**

    Crie o banco de dados no SQL Server e rode os scripts SQL fornecidos na pasta Database do projeto para criar as tabelas necessárias.

3. **Configuração do Web.config:**

    Edite a string de conexão com o banco de dados no arquivo Web.config:

    ```xml
    <connectionStrings>
      <add name="DbConnection" connectionString="Data Source=SEU_SERVIDOR;Initial Catalog=SEU_BANCO_DE_DADOS;User ID=USUARIO;Password=SENHA" providerName="System.Data.SqlClient"/>
    </connectionStrings>
    ```

4. **Rodar a aplicação:**

    Abra o projeto no Visual Studio e execute pressionando F5 ou clique em "Iniciar".

## Estrutura do Projeto

```bash
├── App_Code/
├── App_Data/
├── Content/        # Arquivos CSS e Bootstrap
├── Scripts/        # Arquivos JavaScript
├── Pages/          # Páginas Web Forms (aspx)
├── Database/       # Scripts SQL para criação do banco de dados
├── BLL/            # Classes de lógica de negócios (Business Logic Layer)
├── DAL/            # Classes de acesso a dados (Data Access Layer)
├── Web.config      # Configurações da aplicação
└── README.md
```
## Nota
- BLL (Business Logic Layer): Contém a lógica de negócios da aplicação, como validações e regras do CRUD.
- DAL (Data Access Layer): Responsável por interagir com o banco de dados, executando operações como consultas, inserções e atualizações.
- Models: Não foi utilizada neste projeto, pois as entidades de dados foram gerenciados diretamente na camada de lógica de negócios.

