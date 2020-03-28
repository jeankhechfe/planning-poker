rm db.db
rm ./Migrations/*
dotnet ef migrations add InitialMigration
