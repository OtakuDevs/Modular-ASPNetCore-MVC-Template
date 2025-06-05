#!/bin/bash

# Get the solution name by extracting the current directory name
solution_name=$(basename "$PWD")

# Remove existing solution file if it exists
rm -f "$solution_name.sln"

# Create a new solution
dotnet new sln -n "$solution_name"

# Add projects with solution folder structure
dotnet sln "$solution_name.sln" add "$solution_name.Common.UtilityConstants/$solution_name.Common.UtilityConstants.csproj" --solution-folder "$solution_name.Common"
dotnet sln "$solution_name.sln" add "$solution_name.Common.ValidationConstants/$solution_name.Common.ValidationConstants.csproj" --solution-folder "$solution_name.Common"

dotnet sln "$solution_name.sln" add "$solution_name.Data.Database/$solution_name.Data.Database.csproj" --solution-folder "$solution_name.Data"
dotnet sln "$solution_name.sln" add "$solution_name.Data.DataModels/$solution_name.Data.DataModels.csproj" --solution-folder "$solution_name.Data"

dotnet sln "$solution_name.sln" add "$solution_name.Services.Abstractions/$solution_name.Services.Abstractions.csproj" --solution-folder "$solution_name.Services"
dotnet sln "$solution_name.sln" add "$solution_name.Services.CoreServices/$solution_name.Services.CoreServices.csproj" --solution-folder "$solution_name.Services"
dotnet sln "$solution_name.sln" add "$solution_name.Services.DataServices/$solution_name.Services.DataServices.csproj" --solution-folder "$solution_name.Services"
dotnet sln "$solution_name.sln" add "$solution_name.Services.PresentationServices/$solution_name.Services.PresentationServices.csproj" --solution-folder "$solution_name.Services"
dotnet sln "$solution_name.sln" add "$solution_name.Services.UtilityServices/$solution_name.Services.UtilityServices.csproj" --solution-folder "$solution_name.Services"

dotnet sln "$solution_name.sln" add "$solution_name.Tests/$solution_name.Tests.csproj" --solution-folder "$solution_name.Tests"

dotnet sln "$solution_name.sln" add "$solution_name.Web.Application/$solution_name.Web.Application.csproj" --solution-folder "$solution_name.Web"
dotnet sln "$solution_name.sln" add "$solution_name.Web.ViewModels/$solution_name.Web.ViewModels.csproj" --solution-folder "$solution_name.Web"

echo "✅ Solution folder structure restored for $solution_name!"
