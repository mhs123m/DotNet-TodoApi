📝 Todo API
A simple ASP.NET Core Web API for managing todo items, using Entity Framework Core and MySQL. Swagger UI is enabled for interactive API exploration.

📦 Features
CRUD operations for todo items

EF Core with MySQL database

Dockerized setup

Swagger for API documentation

✅ Prerequisites
Docker

.NET 9 SDK (only if running locally outside Docker)

🚀 Getting Started
1. Clone the repository
bash
Copy
Edit
git clone https://github.com/your-username/your-repo-name.git
cd your-repo-name/API
The docker-compose.yml and Dockerfile are located inside the API folder.

2. Run the application
bash
Copy
Edit
docker compose up todoapi
This will:

Build the ASP.NET Core API

Spin up a MySQL database

Set environment variables

Run the app on port 8080

3. Access the Swagger UI
Open your browser and visit:

bash
Copy
Edit
http://localhost:8080/swagger
Use this interface to interact with the API endpoints.

⚙️ EF Core Migrations (Optional for Devs)
If you're working on the code and want to manage migrations:

bash
Copy
Edit
dotnet ef migrations add InitialCreate \
  --project Infrastructure \
  --startup-project API \
  --output-dir Persistence/Migrations

dotnet ef database update \
  --project Infrastructure \
  --startup-project API
🗃️ Project Structure
bash
Copy
Edit
/API               # Entry point (Dockerfile + Program.cs)
/Infrastructure    # EF Core DbContext + Migrations
/Application       # Application logic layer
/Domain            # Domain entities
📝 License
MIT License. See LICENSE for details.
