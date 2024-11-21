# API em C# - .NET 8 para Controle de Retirada e Devolução de Livros

Esta é uma API desenvolvida em C# utilizando o .NET 8, projetada para o controle de retirada e devolução de livros. O projeto foi estruturado seguindo boas práticas de desenvolvimento, com foco em escalabilidade, manutenção e integração com outros sistemas. A seguir, estão os principais aspectos da implementação:

## Tecnologias Utilizadas

- **C#** - Linguagem de programação principal.
- **.NET 8** - Framework para o desenvolvimento da API.
- **Entity Framework** - Utilizado para o mapeamento de banco de dados, facilitando a interação com o banco de dados de forma eficiente e segura.
- **FluentValidation** - Usado para validação de dados de entrada, garantindo que as regras de negócios sejam seguidas de maneira clara e concisa.
- **DDD (Domain-Driven Design)** - Arquitetura utilizada para organizar o projeto em torno dos domínios e regras de negócio, promovendo um código mais coeso e fácil de manter.
- **TDD (Test-Driven Development)** - Abordagem de desenvolvimento orientada a testes, que ajudou a garantir que a API estivesse funcionando corretamente desde as primeiras etapas do desenvolvimento.
- **CORS (Cross-Origin Resource Sharing)** - Implementado para permitir a integração com o projeto **LivrosWeb**, garantindo que a API possa ser consumida de maneira segura e controlada por aplicações externas.
- **Interfaces** - Utilizadas para promover menor acoplamento entre os componentes da aplicação, facilitando a manutenção e o teste do código.

## Funcionalidades

- **Controle de Retirada de Livros**: A API oferece endpoints para registrar a retirada de livros, alterando seu status de disponibilidade para "indisponível".
- **Controle de Devolução de Livros**: Implementação de lógica para registrar a devolução de livros, alterando seu status de "indisponível" para "disponível" novamente.
- **CRUD Completo**: Endpoints para criação, leitura, atualização e exclusão de livros.
- **Validação**: Utiliza o FluentValidation para garantir que os dados enviados pelos usuários estejam de acordo com as regras definidas.
- **Testes**: A API foi desenvolvida seguindo os princípios de TDD, com testes unitários e de integração para garantir a qualidade do código.
- **Integração com LivrosWeb**: A API se integra ao projeto **LivrosWeb** através do CORS, permitindo que o front-end acesse os dados de forma segura.

## Como Rodar o Projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/api-csharp-net8.git
