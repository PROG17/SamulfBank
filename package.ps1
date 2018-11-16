param([string]$packageName, [string]$projectPath, [string]$absoluteRepoDirectory)

$publishPath = "$absoluteRepoDirectory\$packageName";

dotnet publish $projectPath --configuration Release --output $publishPath
7z a "$packageName.zip" $publishPath\*