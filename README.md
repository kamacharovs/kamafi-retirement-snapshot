# KamaFi Retirement Snapshot

KamaFi Retirement Snapshot

## How to run it

How to run it

### Local

From the root directory

```ps
docker build -f .ci/dockerfiles/kamafi-retirement-snapshot-data-migrations-local.dockerfile -t kamafi-retirement-snapshot_data_migration .
```

```ps
docker run migration
```

Re-create the docker images

```ps
docker-compose up --force-recreate
```

#### Docker

From root directory `/kamafi-retirement-snapshot`

```ps
docker-compose up
```

This will then run the `docker-compose.yml` configuration, which will do the following:

- Create a PostgreSQL database
- Run the `KamaFi.Retirement.Snapshot.Data.Migrations` to create the `retirement_snapshot` database, run the EF migrations and insert the fake data. Essentially what is defined in the project

#### Docker clean up

1. Stop the container(s) using the following command:

    ```ps
    docker-compose down
    ```

2. Delete all containers using the following command:

    ```ps
    docker rm -f $(docker ps -a -q)
    ```

3. Delete all volumes using the following command:

    ```ps
    docker volume rm $(docker volume ls -q)
    ```

4. Restart the containers using the following command:

    ```ps
    docker-compose up -d
    ```
