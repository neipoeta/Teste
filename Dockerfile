# Imagem base
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copia e restaura dependências
COPY *.csproj ./
RUN dotnet restore

# Copia todo o restante do código e constrói a aplicação
COPY . ./
RUN dotnet publish -c Release -o out

# Build final da imagem
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

CMD ASPNETCORE_URLS="http://*:$PORT" dotnet TesteSKA.dll
#ENTRYPOINT ["dotnet", "TesteSKA.dll"]
