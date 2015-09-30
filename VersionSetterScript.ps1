$contentAssembly = Get-Content MindKeeper\SharedAssemblyInfo.cs
"'"+$contentAssembly+"'" -match '\[assembly: AssemblyVersion\(\"(?<major>\d+).(?<minor>\d+).(?<patch>\d+).(\*)\"\)\]'
$matchVar = $matches
$versionNew = "{0}.{1}.{2}" -f $matchVar["major"],$matchVar["minor"],$matchVar["patch"]


$contentInstaller = Get-Content MindKeeper\Installer\MKInstaller.iss
"'"+$contentInstaller+"'" -match '\#define MyAppVersion \"(?<major>\d+).(?<minor>\d+).(?<patch>\d+)\"'
$matchVar1 = $matches
$versionOld = "{0}.{1}.{2}" -f $matchVar1["major"],$matchVar1["minor"],$matchVar1["patch"]


(Get-Content MindKeeper\Installer\MKInstaller.iss) | 
Foreach-Object {$_ -replace $versionOld,$versionNew}  | 
Out-File MindKeeper\Installer\MKInstaller.iss