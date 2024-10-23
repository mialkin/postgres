# Postgres

Showcase of using PostgreSQL with EC Core migrations.

## Prerequisites

- .NET 8 SDK
- Docker
- [↑ GNU Make](https://www.gnu.org/software/make/)
- [↑ Entity Framework Core tools](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)

## Running application

```bash
make run-infrastructure
```

```bash
make apply-database-migrations
```

```bash
make run-application
```

Additional commands:

```bash
make shutdown-infrastructure
```

```bash
make list-database-migrations
```

```bash
make add-database-migration name="Add_Initial_Migration"
```
