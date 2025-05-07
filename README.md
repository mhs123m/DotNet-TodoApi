# 📝 Todo API

A simple ASP.NET Core Web API for managing todo items, using Entity Framework Core and MySQL. Swagger UI is enabled for interactive API exploration.

---

## 📆 Features

* CRUD operations for todo items
* EF Core with MySQL database
* Dockerized setup
* Swagger for API documentation

---

## ✅ Prerequisites

* [Docker](https://www.docker.com/products/docker-desktop)
* [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0) (only if running locally outside Docker)

---

## 🚀 Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/your-username/your-repo-name.git
cd your-repo-name/API
```

> The `docker-compose.yml` and `Dockerfile` are located inside the `API` folder.

---

### 2. Run the application

```bash
docker compose up todoapi
```

This will:

* Build the ASP.NET Core API
* Spin up a MySQL database
* Set environment variables
* Run the app on port `8080`

---

### 3. Access the Swagger UI

Open your browser and visit:

```
http://localhost:8080/swagger
```

Use this interface to interact with the API endpoints.

---

## ⚙️ EF Core Migrations (Optional for Devs)

If you're working on the code and want to manage migrations:

```bash
dotnet ef migrations add InitialCreate \
  --project Infrastructure \
  --startup-project API \
  --output-dir Persistence/Migrations

dotnet ef database update \
  --project Infrastructure \
  --startup-project API
```

---

## 📃 Project Structure

```
/API               # Entry point (Dockerfile + Program.cs)
/Infrastructure    # EF Core DbContext + Migrations
/Application       # Application logic layer
/Domain            # Domain entities
```

---

## 📝 License

MIT License. See [`LICENSE`](./LICENSE) for details.
