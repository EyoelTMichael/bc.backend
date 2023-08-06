# last step

## Migrations
dotnet ef migrations add InitialCreate --startup-project ../Site.Api
dotnet ef database update --startup-project ../Site.Api
