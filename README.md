# GraphPersona API

A modern GraphQL API built with **.NET 9**, **PostgreSQL 17**, and **EF Core 9** — designed with **Clean Architecture**, single‑responsibility patterns, and full Docker support.  
Now featuring complete CRUD flows (List, Detail, Create, Update, Delete) with validation, services, repositories, and GraphQL integration.

---

## 🚀 Tech Stack

- **.NET 9** — minimal APIs with `MapGraphQL`
- **GraphQL** — powered by [HotChocolate](https://chillicream.com/docs/hotchocolate) with inputs, queries, and mutations
- **PostgreSQL 17** — relational database with enum support
- **EF Core 9** — ORM with code‑first migrations
- **FluentValidation** — DTO validation with custom error codes
- **Docker & Docker Compose** — containerized setup with a dedicated migration container
- **Clean Architecture** — layered solution with strict separation of concerns
- **Directory.Packages.props** — centralized NuGet package management

---

## 🧱 Solution Structure

```
GraphPersona.sln
├── GraphPersona.Api/           # API layer (GraphQL endpoints, Program.cs)
├── GraphPersona.Application/   # Services, validators, DTOs, business logic
├── GraphPersona.Domain/        # Entities, enums, domain rules
├── GraphPersona.Infrastructure/# EF Core, repositories, persistence
├── GraphPersona.Migrations/    # Dedicated migration container
```

---

## 📦 Features

- ✅ Full CRUD flows for `Person`, `Address`, and `Contact`
- ✅ GraphQL queries and mutations for list, detail, create, update, and delete
- ✅ Partial update support — only fields provided in the request are updated
- ✅ FluentValidation rules for all DTOs with custom error codes
- ✅ Services, repositories, and validators following single‑responsibility principle
- ✅ Extension methods for a clean `Program.cs`
- ✅ Docker Compose setup with migration container
- ✅ Entity relationships:
    - `Person` has one optional `Address`
    - `Person` has many `Contacts` with `Channel` and `Info`

---

## 📌 TODO

- [ ] Add pagination and filtering to `Person` list queries
- [ ] Add unit and integration tests
- [ ] Add CI/CD pipeline for Docker builds and migrations

---

## 🏁 Getting Started

### Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/get-started) & Docker Compose
- [PostgreSQL client tools](https://www.postgresql.org/download/) (optional, for manual DB inspection)

### Clone the Repository
```bash
git clone https://github.com/wthiagos/graph-persona.git
cd graphpersona
```

### Run with Docker
```bash
# Build and run the app
docker compose up --build
```

The API will be available at:  
👉 http://localhost:5544/graphql

### Apply Database Migrations
```bash
# Run migrations only
docker compose run migrations
```

### Run Locally (without Docker)
```bash
dotnet build
dotnet run --project GraphPersona.Api
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
      { channel: Email, info: "john.doe@example.com" },
      { channel: Phone, info: "+1234567890" }
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
- Update mutations only apply changes to fields explicitly provided

---

## 📄 License

MIT — feel free to use and adapt.