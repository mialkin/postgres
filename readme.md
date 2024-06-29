# Postgres

Terminal 1:

```bash
make run-infrastructure
```

Terminal 2:

```bash
make apply-database-migrations
make run-application
```

Additional commands:

```csharp
make list-database-migrations
make add-database-migration name="Add_Initial_Migration"
```
