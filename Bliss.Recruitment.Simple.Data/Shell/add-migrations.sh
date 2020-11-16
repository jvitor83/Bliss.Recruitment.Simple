# Command to Create a new Migration
cd ..
dotnet ef migrations add "$1" --startup-project "../Bliss.Recruitment.Simple.Api/Bliss.Recruitment.Simple.Api.csproj" --project "./Bliss.Recruitment.Simple.Data.csproj" --verbose