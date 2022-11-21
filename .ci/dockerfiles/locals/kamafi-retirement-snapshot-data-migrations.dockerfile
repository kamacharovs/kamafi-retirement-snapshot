FROM mcr.microsoft.com/dotnet/sdk:6.0

COPY /KamaFi.Retirement.Snapshot.Data/ ./KamaFi.Retirement.Snapshot.Data
COPY /KamaFi.Retirement.Snapshot.Data.Migrations/ ./KamaFi.Retirement.Snapshot.Data.Migrations

RUN dotnet build /KamaFi.Retirement.Snapshot.Data/KamaFi.Retirement.Snapshot.Data.csproj
RUN dotnet build /KamaFi.Retirement.Snapshot.Data.Migrations/KamaFi.Retirement.Snapshot.Data.Migrations.csproj

WORKDIR /KamaFi.Retirement.Snapshot.Data.Migrations

CMD ["dotnet", "run"]