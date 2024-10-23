INFRASTRUCTURE_FILE := infrastructure.yaml
STARTUP_PROJECT := src/Postgres.Api
DATABASE_PROJECT := src/Postgres.Infrastructure.Implementation.Database

.PHONY: copy-env
copy-env:
	cp -n .env.example .env | true

.PHONY: run-infrastructure
run-infrastructure: copy-env
	docker-compose --file $(INFRASTRUCTURE_FILE) up --detach

.PHONY: shutdown-infrastructure
shutdown-infrastructure:
	docker-compose --file $(INFRASTRUCTURE_FILE) down

.PHONY: add-database-migration
add-database-migration:
	dotnet ef migrations add $(name) \
        --project $(DATABASE_PROJECT) \
        --startup-project $(STARTUP_PROJECT)

.PHONY: apply-database-migrations
apply-database-migrations:
	dotnet ef database update \
        --project $(DATABASE_PROJECT) \
        --startup-project $(STARTUP_PROJECT)

.PHONY: list-database-migrations
list-database-migrations:
	dotnet ef migrations list \
        --project $(DATABASE_PROJECT) \
        --startup-project $(STARTUP_PROJECT)

.PHONY: run-application
run-application:
	dotnet run --project $(STARTUP_PROJECT)
