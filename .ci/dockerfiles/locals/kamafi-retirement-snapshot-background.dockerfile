FROM mcr.microsoft.com/dotnet/sdk:6.0

COPY /KamaFi.Retirement.Snapshot.Data/ ./KamaFi.Retirement.Snapshot.Data
COPY /KamaFi.Retirement.Snapshot.Background/ ./KamaFi.Retirement.Snapshot.Background

RUN dotnet restore /KamaFi.Retirement.Snapshot.Background/KamaFi.Retirement.Snapshot.Background.csproj
RUN dotnet build -c release /KamaFi.Retirement.Snapshot.Background/KamaFi.Retirement.Snapshot.Background.csproj --no-restore
RUN dotnet test -c release /KamaFi.Retirement.Snapshot.Background/KamaFi.Retirement.Snapshot.Background.csproj -l trx -v normal --no-build
RUN dotnet publish -c release /KamaFi.Retirement.Snapshot.Background/KamaFi.Retirement.Snapshot.Background.csproj -o app/publish

WORKDIR /app/publish

EXPOSE 80
ENTRYPOINT ["dotnet", "KamaFi.Retirement.Snapshot.Background.dll"]