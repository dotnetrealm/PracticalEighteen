# Practical-18

ASP.NET Core Web API with Automapper &amp; Bind with EF Core MVC

## Setup

- Add connection string in the user secrets file

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=[DBSOURCENAME];Initial Catalog=[DBName];Persist Security Info=True;User ID=[YOURUSERID];Password=[******];TrustServerCertificate=True"
  }
}
```

- Add API_URL in the user secrets file of PracticalEighteen project

```json
{
  "API_URL": "https://localhost:[PORT]/api/"
}
```

> **_NOTE:_** This configuration only works under "Development" enviorment.

## Migration

- Make sure you add connection string in secrets and then follow the following steps
- In the package manager console select "PracticalEighteen.Data" project and then run the given command

```bash
Update-Database
```
