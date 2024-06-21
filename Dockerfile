#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Estágio de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia e restaura o projeto
COPY Treinaí.csproj .
RUN dotnet restore

# Copia os arquivos restantes e publica a aplicação
COPY . .
RUN dotnet publish -c Release -o out

# Estágio de publicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Define as variáveis de ambiente para acesso aos segredos
ENV ConnectionStrings__DefaultConnection="Server=localhost,1433;Database=Treinai;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False;TrustServerCertificate=True"
ENV SMTP__UserName="fabricio_dev@outlook.com"
ENV SMTP__Nome="TreinaÍ"
ENV SMTP__Host="smtp-mail.outlook.com"
ENV SMTP__Senha="Evelin2305@"
ENV SMTP__Porta="587"

ENTRYPOINT ["dotnet", "Treinaí.dll"]


