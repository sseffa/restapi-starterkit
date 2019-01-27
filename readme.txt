dotnet ef migrations add Initial -c CatalogContext -p ../Infrastructure/Infrastructure.csproj -s starterkit.csproj -o Data/Migrations/
dotnet ef migrations add InitialIdentityModel -c AppIdentityDbContext -p ../Infrastructure/Infrastructure.csproj -s starterkit.csproj -o Identity/Migrations/

dotnet ef database update -c CatalogContext -p ../Infrastructure/Infrastructure.csproj -s starterkit.csproj
dotnet ef database update -c AppIdentityDbContext -p ../Infrastructure/Infrastructure.csproj -s starterkit.csproj
