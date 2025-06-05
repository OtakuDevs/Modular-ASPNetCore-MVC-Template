# Get the solution name based on the current directory name
$solutionName = Split-Path -Leaf $PWD

# Remove old solution file (optional)
Remove-Item "$solutionName.sln" -Force -ErrorAction SilentlyContinue

# Create new solution
dotnet new sln -n $solutionName

# Add projects to solution folders
dotnet sln $solutionName.sln add .\Common.UtilityConstants\Common.UtilityConstants.csproj --solution-folder "$solutionName.Common"
dotnet sln $solutionName.sln add .\Common.ValidationConstants\Common.ValidationConstants.csproj --solution-folder "$solutionName.Common"

dotnet sln $solutionName.sln add .\Data.Database\Data.Database.csproj --solution-folder "$solutionName.Data"
dotnet sln $solutionName.sln add .\Data.DataModels\Data.DataModels.csproj --solution-folder "$solutionName.Data"

dotnet sln $solutionName.sln add .\Services.Abstractions\Services.Abstractions.csproj --solution-folder "$solutionName.Services"
dotnet sln $solutionName.sln add .\Services.CoreServices\Services.CoreServices.csproj --solution-folder "$solutionName.Services"
dotnet sln $solutionName.sln add .\Services.DataServices\Services.DataServices.csproj --solution-folder "$solutionName.Services"
dotnet sln $solutionName.sln add .\Services.PresentationServices\Services.PresentationServices.csproj --solution-folder "$solutionName.Services"
dotnet sln $solutionName.sln add .\Services.UtilityServices\Services.UtilityServices.csproj --solution-folder "$solutionName.Services"

dotnet sln $solutionName.sln add .\Tests\Tests.csproj --solution-folder "$solutionName.Tests"

dotnet sln $solutionName.sln add .\Web.Application\Web.Application.csproj --solution-folder "$solutionName.Web"
dotnet sln $solutionName.sln add .\Web.ViewModels\Web.ViewModels.csproj --solution-folder "$solutionName.Web"

Write-Host "✅ Solution folder structure restored for $solutionName!"
