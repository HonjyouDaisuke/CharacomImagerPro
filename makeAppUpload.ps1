Param($Arg1, $Arg2)

echo $Arg1
echo $Arg2
echo "------------"

$exePath = $Arg2 + "CharacomImagerPro.exe"
echo $exePath
$vi = (Get-ItemProperty $exePath).VersionInfo
$fileVersion = "v" + ($vi.FileMajorPart) + "." + ($vi.FileMinorPart) + "." + ($vi.FileBuildPart) + "." + ($vi.FilePrivatePart)
$output = $Arg1 + "AppPackage\version.ini"
echo $fileVersion > $output

Compress-Archive -Path packageTmp -DestinationPath AppPackage\CharacomImagerPro.zip -Force
