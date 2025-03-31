Helpdesk API - Back-End (C# & SQL Server)
Este repositório contém apenas o back-end do sistema de Helpdesk, desenvolvido em C# com SQL Server e Swagger para documentação da API. Feito por Matheus Fernandes!

🚨 Aviso
O projeto foi originalmente hospedado no Azure, mas meu plano de estudante expirou. Portanto, para rodar localmente, siga as instruções abaixo.


📥 Como baixar e executar


1️⃣ Clonar o repositório

Abra o terminal e execute:

sh
git clone https://github.com/matheusferx/HelpDesk.git  
cd HelpDesk


2️⃣ Configurar o banco de dados
O banco de dados é integrado ao código usando as classes dentro da pasta Models.

Certifique-se de ter o SQL Server rodando localmente.

Atualize a string de conexão no appsettings.json:
  json
  "ConnectionStrings": {
    "DefaultConnection": "Server=SEU_SERVIDOR;Database=HELPDESK;User Id=SEU_USUARIO;Password=SUA_SENHA;"
  }

Execute as migrações para criar o banco de dados automaticamente:

sh
  dotnet ef database update

3️⃣ Restaurar dependências e executar o projeto

sh
  dotnet restore  
  dotnet build  
  dotnet run 
  
A API estará disponível em http://localhost:5000 e a documentação Swagger em http://localhost:5000/swagger.

📌 Tecnologias utilizadas

  C# (.NET)

  SQL Server

  Entity Framework Core

  Swagger

⚠️ Este repositório contém apenas o back-end. O front-end será desenvolvido separadamente e fará chamadas para esta API.
