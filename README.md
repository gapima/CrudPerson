# CRUD Person e Adição de Endereço

Este repositório contém uma aplicação que implementa um CRUD simples para gerenciamento de pessoas e seus endereços.

## Descrição do Projeto

O projeto consiste em uma aplicação **ASP.NET MVC** que permite realizar operações de **CRUD** (Criar, Ler, Atualizar e Deletar) para pessoas, além de adicionar endereços a cada pessoa cadastrada. As funcionalidades principais incluem:

- **Listagem de Pessoas**: Tela com a lista de pessoas cadastradas, com a opção de **+ Cadastro** para adicionar novos registros.
- **Cadastro de Pessoa**: Formulário para cadastrar uma nova pessoa com os campos **Nome**, **Telefone** e **CPF**.
- **Edição de Pessoa**: Após o cadastro, é possível editar as informações de cada pessoa.
- **Listagem de Endereços**: Na tela de edição, é possível visualizar os endereços cadastrados para a pessoa e adicionar novos endereços.
- **Cadastro de Endereço**: Um modal de cadastro permite adicionar um novo endereço, com os campos **Endereço**, **CEP**, **Cidade** e **Estado**.

## Funcionalidades Implementadas

- **Cadastro e Edição de Pessoas**: Permite adicionar, editar e excluir pessoas.
- **Cadastro de Endereços**: A funcionalidade de adicionar endereços a uma pessoa está implementada.
- **Integração com API de CEP (opcional)**: Implementação parcial de consulta ao CEP utilizando a API [ViaCEP](https://viacep.com.br).

## Tecnologias Utilizadas

- **ASP.NET MVC**: Framework utilizado para o desenvolvimento da aplicação.
- **C#**: Linguagem de programação utilizada para o back-end.
- **Dapper**: Biblioteca utilizada para realizar consultas ao banco de dados e mapear os resultados para objetos C#.
- **SQL Server**: Banco de dados utilizado para armazenar os registros de pessoas e endereços.
- **T-SQL**: Linguagem de consulta utilizada para interagir com o banco de dados.
- **HTML, CSS, JavaScript**: Tecnologias utilizadas para a criação das interfaces de usuário.

## Como Rodar o Projeto

1. Clone este repositório:
   ```bash
   git clone git@github.com:gapima/CrudPerson.git
