FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY MagazinOnline.csproj .
RUN dotnet restore MagazinOnline.csproj

COPY . .
RUN dotnet publish MagazinOnline.csproj -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/out .

ENTRYPOINT ["./MagazinOnline"]
