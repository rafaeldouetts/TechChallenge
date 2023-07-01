# TechChallenge

Introdução
- Projeto criado para o Tech Challenge dotnet da Fase 1 da PósTech em Arquitetura de Sistemas .Net com Azure da FIAP
- Objetivo: Criar aplicação Web com upload e exibição de imagens, utilizando Serviços de Storage e database Azure

Funcionalidades

- Recurso 1: Aplicação Front-end em Angular 8 e typescrypt 3.5, apresentando ao usuário as funcionalidades a seguir:
  - Login e Cadastro de usuário
  - Upload de imagens
  - Visualização e Busca de imagens
  Detalhes de setup do Angular 8: https://v8.angular.io/guide/setup-local
  Detalhes da implementação e execução: https://github.com/JairJr/TechChallenge/tree/master/TechChallenge.WebApp#readme

- Recurso 2: API AspNetCore em .Net 7 com Identity 7.05 responsável pelos seguintes itens:
  - Autenticação e autorização do sistema
  - Validação de token
  Detalhes da implementação e execução: https://github.com/JairJr/TechChallenge/tree/master/TechChallenge.Identity#readme

- Recurso 3: API AspNetCore em .Net 7 com as implementações das regras de negocio e validações (Business Core). Implementa a conexão com banco de dados SqlServer no Azure e as seguintes funcionalidades:
  - Cria e gerencia os objetos Usuário, Foto e suas propriedades como título e extensão.
  - Relacionamento entre os objetos(imagens) e o usuário
  - Realiza a persistencia de dados através do Entity Framework Core 7.05
  Detalhes da implementação e execução: https://github.com/JairJr/TechChallenge/blob/master/TechChallangeApi/README.md

- Recurso 4: API Minima em .Net 7 responsável em salvar arquivos no Azure Storage e recuperar SASToken com validade de 1 hora para acesso ao arquivo.
  Detalhes da implementação e execução: https://github.com/JairJr/TechChallenge/blob/master/TechChallengeMinimalApi/README.md  

A Imagem abaixo segue foi a referência de arquitetura definida no inicio do projeto como referência a ser adotada pelo time:

![image](https://github.com/JairJr/TechChallenge/assets/29376086/c1825dc0-cf40-4290-84ac-b134eff7bcbd)
