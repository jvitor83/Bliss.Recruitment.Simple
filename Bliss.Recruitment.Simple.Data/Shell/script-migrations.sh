# Command to generate the scripts of database
cd ..
dotnet ef migrations script --startup-project "../Bliss.Recruitment.Simple.Api/Bliss.Recruitment.Simple.Api.csproj" --project "./Bliss.Recruitment.Simple.Data.csproj" --idempotent --verbose --output ./Scripts/$1.sql