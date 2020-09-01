::https://dist.nuget.org/win-x86-commandline/latest/nuget.exe
::nuget spec
::nuget pack
nuget push *.nupkg oy2f33tvfvjkfl7eo5mam74vklttjpvuvla5v4ewcyyjqq -Source https://api.nuget.org/v3/index.json
pause
