FROM mcr.microsoft.com/dotnet/sdk:6.0

COPY /KamaFi.Retirement.Snapshot.Calculators/ ./KamaFi.Retirement.Snapshot.Calculators
COPY /KamaFi.Retirement.Snapshot.Data/ ./KamaFi.Retirement.Snapshot.Data
COPY /KamaFi.Retirement.Snapshot.Services/ ./KamaFi.Retirement.Snapshot.Services
COPY /KamaFi.Retirement.Snapshot.Core/ ./KamaFi.Retirement.Snapshot.Core

RUN dotnet restore /KamaFi.Retirement.Snapshot.Core/KamaFi.Retirement.Snapshot.Core.csproj
RUN dotnet build -c release /KamaFi.Retirement.Snapshot.Core/KamaFi.Retirement.Snapshot.Core.csproj --no-restore
RUN dotnet test -c release /KamaFi.Retirement.Snapshot.Core/KamaFi.Retirement.Snapshot.Core.csproj -l trx -v normal --no-build
RUN dotnet publish -c release /KamaFi.Retirement.Snapshot.Core/KamaFi.Retirement.Snapshot.Core.csproj -o app/publish

WORKDIR /app/publish

EXPOSE 5124
ENTRYPOINT ["dotnet", "KamaFi.Retirement.Snapshot.Core.dll"]