# TechChallenge

Introdução
- Projeto criado para concluir a etapa de tech challenge dotnet da Fiap

Funcionalidades
- Recurso 1: Aplicação Front-end em Angular versão 8 e typescrypt 3.5, apresentando ao usuário as funcionalidades a seguir:
  - Cadastro
  - Login
  - Upload de imagens
  - Busca de imagens
    - Detalhes de setup do Angular 8 https://v8.angular.io/guide/setup-local
    - detalhes da implementação e como executar podem ser consultados em: https://github.com/JairJr/TechChallenge/tree/master/TechChallenge.WebApp#readme
- Recurso 2: API AspNetCore com Identity responsável pelos seguintes itens
  - Autenticação e autorização do sistema
  - Validação de token
  - Este recurso pode ser consultado em detalhes em: https://github.com/JairJr/TechChallenge/tree/master/TechChallenge.Identity#readme
- Recurso 3: API AspNetCore com as implementações das regras de negocio e validações (Business Core) que implementa a conexão com banco de dados SqlServer no Azure, implementa as seguintes funcionalidades especificas:
  - Relacionamento entre os objetos(imagens) e o usuário
  - Cria e gerencia os intens da publicação, nome, proprietário da imagem e extensão
  - Realiza a persistencia de dados
  - Detalhes da implementação podem ser consultados em: https://github.com/JairJr/TechChallenge/blob/master/TechChallangeApi/README.md
- Recurso 4: API Minima em NET7 responsável em salvar arquivos no Azure Storage e recuperar SASToken com validade de 1 hora para acesso ao arquivo.
  - Detalhes para execução e implentações podem ser consultados em: https://github.com/JairJr/TechChallenge/blob/master/TechChallengeMinimalApi/README.md  

A Imagem abaixo segue como referencia dedefinição inicial da arquitetura a ser adotada pelo time:

![image](https://github.com/JairJr/TechChallenge/assets/29376086/c1825dc0-cf40-4290-84ac-b134eff7bcbd)
