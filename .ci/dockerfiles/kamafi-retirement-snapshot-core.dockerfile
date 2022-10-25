FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine
WORKDIR /app
COPY /app/publish/KamaFi.Retirement.Snapshot.Core /app/
EXPOSE 80
ENTRYPOINT ["dotnet", "KamaFi.Retirement.Snapshot.Core.dll"]