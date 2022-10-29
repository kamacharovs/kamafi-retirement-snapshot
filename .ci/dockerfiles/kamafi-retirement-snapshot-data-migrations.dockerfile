FROM mcr.microsoft.com/dotnet/sdk:6.0
RUN dotnet tool install --global dotnet-ef --version 6.0.7
ENV PATH="${PATH}:/root/.dotnet/tools"
COPY ./KamaFi.Retirement.Snapshot.Data.Migrations/ ./
CMD ["dotnet", "ef", "database", "update"]