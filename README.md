## Treinaí - Plataforma de Gestão de Atividades Físicas 🌐

## ⚙️ Status: Trabalhando.

## Descrição do Projeto

### O Treinaí é uma plataforma dedicada à gestão de atividades físicas, voltada tanto para professores quanto para alunos. Permite que professores criem planos de treino personalizados, com base em diferentes modalidades de exercícios como musculação, crossfit, corrida, natação, bicicleta e triathlon. Cada plano de treino pode especificar a quantidade de dias de atividade, dias de descanso, exercícios a serem realizados em cada modalidade, assim como o número de repetições e séries para cada exercício.

### Regras do Negócio  📏

### Cadastro de Professores e Alunos: Cadastre e gerencie professores e alunos na plataforma.

### Criação de Planos de Treino: Professores podem criar planos de treino detalhados para cada aluno, incluindo dias de atividade, exercícios, repetições e séries.

### Gestão de Modalidades: Suporte para diferentes modalidades de exercício como musculação, crossfit, corrida, natação, bicicleta e triathlon.


### Funcionalidades 🖥️ 


 - ☑ CRUD Professores
 - ☑ CRUD Alunos
 - ☑ CRUD Modalidades de Exercício
 - ☑ CRUD Planos de Treino
 - ☑ CRUD Séries de Exercício
 - ☑ CRUD Dias de Treino
 - ☑ Envio de E-mails usando SMTP
 - ☑ Integração com RabbitMQ: Utilização de RabbitMQ para comunicação assíncrona entre componentes do sistema.
 - ☑ Autenticação e Autorização: Utilização do ASP.NET Identity para autenticação e autorização de usuários.
 - ☑ Containerização com Docker: Utilização de Docker para empacotamento e distribuição do aplicativo, garantindo 
      portabilidade e facilidade de implantação.
 - ☑ Testes Unitários com XUnit:  Com XUnit, você pode escrever testes de maneira simples e clara, melhorando a    
      confiabilidade e a robustez do seu código.
  

### Tecnologias utilizadas 💡


 - ASP.NET Core 8: Framework web para desenvolvimento de aplicações .NET.
 - Entity Framework Core: Persistência e consulta de dados.
 - SQL Server: Banco de dados relacional.
 - Mensageria com RabbitMQ: Comunicação assíncrona entre serviços.
 - Containerização com Docker: Empacotamento e distribuição de aplicações.
 - Autenticação com Identity: Gerenciamento de autenticação e autorização de usuários.
   

### Padrões, conceitos e arquitetura utilizada 📂


- ☑ Padrão Repository
- ☑ IEntityTipeConfiguration 
- ☑ Sql Server 
- ☑ RabbitMQ
- ☑ Docker
- ☑ Testes Unitários

 
## Instalação

### Requisitos

Antes de começar, verifique se você tem os seguintes requisitos instalados:

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0): A versão do .NET Framework necessária para executar a API.
- [SQL Server](https://www.microsoft.com/en-us/sql-server): O banco de dados utilizado para armazenar os dados.

### Clone

Clone o repositório do GitHub:

```bash
git clone https://github.com/[seu-usuário]/Treinai.git
```

### Navegue até a pasta do projeto:

```bash
cd Treinai
```

### Abra o projeto na sua IDE de preferência (a IDE utilizada para desenvolvimento foi o Visual Studio)

### Restaure os pacotes:

```bash
dotnet restore
```

### Configure o banco de dados:

1. Abra o arquivo `appsettings.json`.
2. Altere as configurações do banco de dados para corresponder ao seu ambiente.

### Execute o Projeto:

Para executar o projeto, use o seguinte comando:

```bash
dotnet run
```

### Executando o Projeto com Docker

1 - Certifique-se de que o Docker está instalado e em execução.

2 - Navegue até o diretório raiz do projeto e crie um arquivo Dockerfile com o seguinte conteúdo:

```bash
# Use a imagem base do .NET 6 SDK
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Treinai/Treinai.csproj", "Treinai/"]
RUN dotnet restore "Treinai/Treinai.csproj"
COPY . .
WORKDIR "/src/Treinai"
RUN dotnet build "Treinai.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Treinai.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Treinai.dll"]
```

3 - Crie um arquivo docker-compose.yml com o seguinte conteúdo:

```bash
version: '3.13'

services:
  treinai:
    image: treinai
    build:
      context: .
      dockerfile: Dockerfile
    ports:
      - "8080:8080"
      - "8081:8081"
    depends_on:
      - db
      - rabbitmq
    environment:
      ASPNETCORE_ENVIRONMENT: Development
      ConnectionStrings__DefaultConnection: "Server=db;Database=Treinai;User=sa;Password=YourStrong!Passw0rd;"
      SMTP__UserName: ${SMTP__UserName}
      SMTP__Nome: ${SMTP__Nome}
      SMTP__Host: ${SMTP__Host}
      SMTP__Senha: ${SMTP__Senha}
      SMTP__Porta: ${SMTP__Porta}
      RabbitMQ__Host: ${RabbitMQ__Host}
      RabbitMQ__UserName: ${RabbitMQ__UserName}
      RabbitMQ__Password: ${RabbitMQ__Password}

  db:
    image: mcr.microsoft.com/mssql/server
    environment:
      SA_PASSWORD: "YourStrong!Passw0rd"
      ACCEPT_EULA: "Y"
    ports:
      - "1433:1433"
    volumes:
      - treinai-db-data:/var/opt/mssql

  rabbitmq:
    image: "rabbitmq:3-management"
    ports:
      - "15672:15672"
      - "5672:5672"

volumes:
  treinai-db-data:
```

4 - No terminal, navegue até o diretório raiz do projeto (onde estão os arquivos Dockerfile e docker-compose.yml) e execute:

```bash
docker-compose up --build
```

Isso construirá e iniciará os contêineres Docker para a aplicação, banco de dados e RabbitMQ.

5 - Acesse a aplicação pelo navegador usando o seguinte endereço

```bash
http://localhost:8080
```

### Contribuição

- Contribuições são bem-vindas! Sinta-se à vontade para abrir problemas (issues) ou enviar pull requests com melhorias.
- Para grandes mudanças, abra um problema primeiro para discutir o que você gostaria de mudar.

### Lembre-se de substituir [seu-usuário] pelo seu nome de usuário do GitHub.

Este projeto foi criado para fins didáticos e não abrange todas as regras e conceitos necessários de uma aplicação real em produção.*
