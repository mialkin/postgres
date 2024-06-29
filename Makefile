.PHONY: copy-env
copy-env:
	cp -n .env.example .env | true

.PHONY: run-infrastructure
run-infrastructure: copy-env
	docker-compose -f docker-compose.infrastructure.yml up

.PHONY: shutdown-infrastructure
shutdown-infrastructure:
	docker-compose -f docker-compose.infrastructure.yml down

.PHONY: run-application
run-application:
	dotnet run --project src/Postgres.Api

.PHONY: update-database
update-database:
	dotnet ef database update \
        --project src/Postgres.Infrastructure.Implementation.Database \
        --startup-project src/Postgres.Api
