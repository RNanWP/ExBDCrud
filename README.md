# 🖥️ Projeto CRUD - Cadastro de Produtos 📚

Este é um projeto simples de **CRUD (Create, Read, Update, Delete)** para gerenciar produtos em um banco de dados MySQL, desenvolvido em **C#** utilizando o **Windows Forms**. O projeto permite a inserção, edição e visualização de produtos em uma tabela de banco de dados.

## Funcionalidades

- **Cadastro de Produtos**: Permite cadastrar novos produtos com nome e preço.
- **Edição de Produtos**: Permite editar produtos cadastrados, alterando nome e preço.
- **Exibição de Produtos**: Exibe os produtos cadastrados em um grid na interface.
- **Banco de Dados**: Utiliza o MySQL para armazenar os dados dos produtos.

## Tecnologias Utilizadas

- **C#** (Windows Forms)
- **MySQL** (Banco de dados)
- **MySql.Data** (Biblioteca para conexão com o MySQL)

## Como Rodar o Projeto

### Pré-requisitos

- **.NET Framework 4.7.2 ou superior** instalado.
- **MySQL** instalado localmente ou em um servidor.
- **Biblioteca MySql.Data** instalada via NuGet.

### Passos

1. Clone o repositório para sua máquina:

    ```bash
    git clone https://github.com/RNanWP/ExBDCrud.git
    ```

2. Abra o projeto no Visual Studio.

3. No banco de dados MySQL, crie o banco de dados com o nome **CrudRN** e a tabela **Produto**. A estrutura da tabela pode ser criada com o seguinte comando SQL:

    ```sql
    CREATE DATABASE CrudRN;
    USE CrudRN;

    CREATE TABLE Produto (
        Id INT AUTO_INCREMENT PRIMARY KEY,
        Nome VARCHAR(255) NOT NULL,
        Preco DECIMAL(10, 2) NOT NULL
    );
    ```

4. Certifique-se de que a conexão com o banco de dados está configurada corretamente no arquivo `Database.cs`, onde a string de conexão é configurada como:

    ```csharp
    string connectionString = "server=localhost;database=CrudRN;user=root;password=root;";
    ```

    Ajuste conforme necessário, dependendo da configuração do seu MySQL.

5. Compile e execute o projeto no Visual Studio.

6. Agora, você pode usar a interface do Windows Forms para adicionar, editar e visualizar produtos.

## Estrutura do Projeto

- **Database.cs**: Responsável pela conexão com o banco de dados MySQL.
- **Cadastro.cs**: Formulário para cadastro e edição de produtos.
- **Form1.cs**: Formulário principal que exibe a lista de produtos.

## Contribuições

1. Fork o repositório.
2. Crie uma nova branch (`git checkout -b feature/nova-funcionalidade`).
3. Faça suas alterações.
4. Commit suas mudanças (`git commit -am 'Adicionando nova funcionalidade'`).
5. Push para a branch (`git push origin feature/nova-funcionalidade`).
6. Abra um Pull Request.

## Licença

Este projeto é licenciado sob a [MIT License](LICENSE).
