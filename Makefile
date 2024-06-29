.PHONY: copy-env
copy-env:
	cp -n .env.example .env | true

.PHONY: run-infrastructure
run-infrastructure: copy-env
	docker-compose -f docker-compose.infrastructure.yml up

.PHONY: shutdown-infrastructure
shutdown-infrastructure:
	docker-compose -f docker-compose.infrastructure.yml down

.PHONY: add-database-migration
add-database-migration:
	dotnet ef migrations add $(MIGRATION_NAME) \
        --project src/Postgres.Infrastructure.Implementation.Database \
        --startup-project src/Postgres.Api

.PHONY: apply-database-migrations
apply-database-migrations:
	dotnet ef database update \
        --project src/Postgres.Infrastructure.Implementation.Database \
        --startup-project src/Postgres.Api

.PHONY: list-database-migrations
list-database-migrations:
	dotnet ef migrations list \
        --project src/Postgres.Infrastructure.Implementation.Database \
        --startup-project src/Postgres.Api

.PHONY: run-application
run-application:
	dotnet run --project src/Postgres.Api
