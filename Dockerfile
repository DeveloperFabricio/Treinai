#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app


COPY Treinaí.csproj .
RUN dotnet restore


COPY . .
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./


ENV ConnectionStrings__DefaultConnection="Server=localhost,1433;Database=Treinai;User ID=sa;Password=1q2w3e4r@$;Trusted_Connection=False;TrustServerCertificate=True"
ENV SMTP__UserName="seu_email_aqui@outlook.com"
ENV SMTP__Nome="TreinaÍ"
ENV SMTP__Host="smtp-mail.outlook.com"
ENV SMTP__Senha="sua_senha_aqui"
ENV SMTP__Porta="587"
ENV RabbitMQ__Host="localhost"
ENV RabbitMQ__UserName="guest"
ENV RabbitMQ__Password="guest"

ENTRYPOINT ["dotnet", "Treinaí.dll"]


