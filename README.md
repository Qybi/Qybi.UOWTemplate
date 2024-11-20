# .NET 8 Minimal API - EF + Unit of Work Pattern
Personal template to have as reference for a unit of work pattern with entity framework.

(Link for EF + UoW + Mediatr and CQRS)[]

Both the commands below should be run from the web project folder (the startup project).
### To add a migration
```
dotnet ef migrations add InitialMigration -s Qybi.UOWTemplate -p Qybi.UOWTemplate.DataAccess -o Migrations -c ApplicationDbContext
```

### To apply all migrations
```
dotnet ef database update
```
