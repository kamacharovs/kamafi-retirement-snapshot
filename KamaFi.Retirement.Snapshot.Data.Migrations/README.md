# Overview

This is an overview of how to work with `KamaFi.Retirement.Snapshot.Data.Migrations`

## How to add a migration

1. Make your way to the `KamaFi.Retirement.Snapshot.Data.Migrations` directory

    ```ps
    cd .\KamaFi.Retirement.Snapshot.Data.Migrations\
    ```

2. (Optional) Update `dotnet tool`

    ```ps
    dotnet tool update --global dotnet-ef --version {{version}
    ```

    For example

    ```ps
    dotnet tool update --global dotnet-ef --version 6.0.7
    ```

3. Run the `dotnet ef migrations add` command

    ```ps
    dotnet ef migrations add {{migration_name}
    ```

## How to test locally

1. Start the PostgreSQL docker image. This uses the `docker-compose.yml` file in the root directory of this project

    ```ps
    docker compose up
    ```

2. Run the `KamaFi.Retirement.Snapshot.Data.Migrations` project
3. Connect to the database using the settings in `appsettings.json`
4. Check if there is data by connecting to the database
5. Clean up

    ```ps
    docker compose down
    ```
