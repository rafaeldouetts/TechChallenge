# Detalhes da implentação da API Core

- API criada em .NET 7 para funcionar como modulo core da aplicação
- Realiza integração entre os serviços Identity (controle de usuários) e Minimal Api (gerenciamento do storage).
- Utiliza o EF Core para persistir as classes em um banco de dados Azure SQL Server
- Implementa as regras de negócio para as classes Foto e Publicação onde cada publicação tem uma foto e armazena informações como data, texto e usuário com base nas informações do identity
- Pode ser executada localmente via o comando <i><b>dotnet run</i></b>

 ![image](https://github.com/JairJr/TechChallenge/assets/29376086/784a5c05-87e6-422a-819e-c7f93af12173)
