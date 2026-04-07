# Etapa 1: Build — compilăm aplicația folosind SDK-ul complet .NET 8
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiem fișierul de proiect și restaurăm pachetele NuGet
COPY MagazinOnline.csproj .
RUN dotnet restore MagazinOnline.csproj

# Copiem toate fișierele sursă și publicăm aplicația în modul Release
COPY . .
RUN dotnet publish MagazinOnline.csproj -c Release -o /app/out

# Etapa 2: Runtime — imagine finală ușoară, fără SDK (mai mică și mai sigură)
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copiem fișierele publicate din etapa de build
COPY --from=build /app/out .

# Railway injectează automat variabila PORT; Program.cs o citește deja
ENTRYPOINT ["./MagazinOnline"]
