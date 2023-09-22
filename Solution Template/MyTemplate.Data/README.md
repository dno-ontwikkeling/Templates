1. cd ....\MyTemplate.Data\MyTemplate.Data.csproj

2. dotnet ef migrations add MigrationName -s "..\MyTemplate.Web\MyTemplate.Web.csproj"

3. dotnet ef database update -s "..\MyTemplate.Web\MyTemplate.Web.csproj"
