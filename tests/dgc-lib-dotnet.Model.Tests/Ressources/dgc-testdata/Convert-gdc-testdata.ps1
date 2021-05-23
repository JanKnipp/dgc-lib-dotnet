Set-StrictMode -Version Latest
Import-Module Microsoft.PowerShell.Utility

# add folder containing dgc-testdata files
$testDataFolder = Get-Item -Path ""

# add repo folder that should contain the converted files.
$targetBaseFolder = Get-Item -Path ""
$files = Get-ChildItem $testDataFolder.FullName -Filter "*.json" -Recurse -File
$allNewFileNames = @()

foreach($file in $files)
{
    try
    {
        $json = Get-Content -Raw -Path $file.FullName | ConvertFrom-Json -ErrorAction SilentlyContinue
        $validJson = $true
    }
    catch
    {
        $validJson = $false
    }

    if (-not ($validJson))
    {
        Write-Host Skipping $file.FullName as json is not valid
    }

    $newFolder = ($file.Directory.FullName).Replace($testDataFolder.FullName, $targetBaseFolder.FullName)
    $newFile = $file.BaseName + "_dgc"+ $file.Extension
    
    if (-not (Test-Path $newFolder))
    {
        New-Item -ItemType Directory -Force -Path $newFolder |Out-Null
    }

    $targetFolder = Get-Item -Path $newFolder
    $targetFile = Join-Path $targetFolder.FullName $newFile

    if (Get-Member -inputobject $json -name "JSON" -Membertype Properties)
    {
        
        #$json.JSON | ConvertTo-Json -Depth 100 |Out-File $targetFile -Force
        $allNewFileNames += $targetFile
    }
}



foreach($fileName in $allNewFileNames)
{
    $testFileName = ($fileName).Replace($targetBaseFolder.Parent.Parent.FullName, ".")
    
    Write-Host "[InlineData(@`"$testFileName`")]"

}



# csproj build actions
foreach($fileName in $allNewFileNames)
{
    $testFileName = ($fileName).Replace($targetBaseFolder.Parent.Parent.FullName+"\", "")
    
    Write-Host "<None Remove=`"$testFileName`" />"
}


# csproj build actions
foreach($fileName in $allNewFileNames)
{
    $testFileName = ($fileName).Replace($targetBaseFolder.Parent.Parent.FullName+"\", "")
    
    Write-Host "<Content Include=`"$testFileName`">"
    Write-Host "  <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>"
    Write-Host "</Content>"
}

