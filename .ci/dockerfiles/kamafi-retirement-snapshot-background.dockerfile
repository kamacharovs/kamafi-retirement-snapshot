FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine
WORKDIR /app
COPY /app/publish/KamaFi.Retirement.Snapshot.Background /app/
EXPOSE 80
ENTRYPOINT ["dotnet", "KamaFi.Retirement.Snapshot.Background.dll"]