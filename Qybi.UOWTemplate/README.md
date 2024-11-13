# .NET 8 Minimal API - EF + Unit of Work Pattern
Personal template to have as reference for a unit of work pattern with entity framework.

Will make a second one for EF + UoW + Mediatr and CQRS

### To add a migration
```
dotnet ef migrations add InitialMigration -s Qybi.UOWTemplate -p Qybi.UOWTemplate.DataAccess -o Migrations -c ApplicationDbContext
```