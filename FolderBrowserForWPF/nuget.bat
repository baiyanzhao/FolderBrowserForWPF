::https://dist.nuget.org/win-x86-commandline/latest/nuget.exe
::nuget spec
nuget pack
nuget push FolderBrowserForWPF.1.0.0.nupkg oy2h5snb66vvqwtrkgiq4dtdxzrazgwuteb2idjvxlx46y -Source https://api.nuget.org/v3/index.json
pause
