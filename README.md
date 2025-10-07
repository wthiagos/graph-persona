---

```markdown
# GraphPersona API

A modern GraphQL API built with .NET 9, PostgreSQL 17, and EF Core 9 — designed with clean architecture, minimal GraphQL setup via MapGraphQL, and full Docker support.

---

## 🚀 Tech Stack

- **.NET 9** — latest runtime with minimal API and MapGraphQL
- **GraphQL** — powered by [HotChocolate](https://chillicream.com/docs/hotchocolate) with `MapGraphQL` for minimal API-style schema
- **PostgreSQL 17** — relational database with native enum support
- **EF Core 9** — ORM with code-first migrations and enum mapping
- **FluentValidation** — model validation integrated via `ModelBuilder`
- **Docker & Docker Compose** — containerized setup with migration step
- **Clean Architecture** — layered structure with separation of concerns

---

## 🧱 Architecture Overview

```
GraphPersona.Api/
├── GraphQL/
│   ├── Mutations/
│   ├── Queries/
│   ├── Inputs/
│   ├── Types/
├── Data/
│   ├── Migrations/
│   ├── GraphPersonaDbContext.cs
├── Domain/
│   ├── Entities/
│   ├── Enums/
├── Services/
├── Repositories/
├── Validators/
└── Program.cs
```

---

## 📦 Features

- ✅ Minimal GraphQL setup with `MapGraphQL`
- ✅ PostgreSQL enum type mapped to C# enum
- ✅ FluentValidation rules applied via `ModelBuilder`
- ✅ Docker Compose step for running migrations
- ✅ Clean `Program.cs` with DI, logging, and configuration
- ✅ Entity relationships:
    - `Person` has one optional `Address`
    - `Person` has many `Contacts` with `Type` and `Value`

---

## 📌 TODO

- [ ] Implement full CRUD operations for:
    - `Person`
    - `Address`
    - `Contact`
- [ ] Add FluentValidation rules for all input models
- [ ] Add pagination and filtering to GraphQL queries
- [ ] Add unit and integration tests
- [ ] Add CI/CD pipeline for Docker builds and migrations

---

## 🐳 Docker Setup

```bash
# Build and run the app
docker compose up --build

# Run migrations only
docker compose run api dotnet ef database update
```

---

## 🧪 Sample GraphQL Mutation

```graphql
mutation {
  addPerson(input: {
    fullName: "John Doe",
    birthDate: "1980-01-15",
    address: {
      city: "Sampleville",
      country: "Exampleland",
      state: "EX",
      street: "123 Placeholder Street",
      zipCode: "00000-000"
    },
    contacts: [
      { type: Email, value: "john.doe@example.com" },
      { type: Phone, value: "+1234567890" }
    ]
  }) {
    id
    fullName
  }
}
```

---

## 🧠 Notes

- Enum values must match PostgreSQL enum type: `'Email'`, `'Phone'`, `'WhatsApp'`, `'Telegram'`
- `DateOnly` is used for `BirthDate` and validated to prevent future dates

---

## 📄 License

MIT — feel free to use and adapt.