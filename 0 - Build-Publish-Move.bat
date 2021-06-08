@echo off

dotnet restore

dotnet build --no-restore -c Release

dotnet nuget Panosen.AspNetCore.Authentication.Basic\bin\Release\Panosen.AspNetCore.Authentication.Basic.*.nupkg -s https://package.savory.cn/v3/index.json --skip-duplicate
dotnet nuget Panosen.AspNetCore.Authentication.Header\bin\Release\Panosen.AspNetCore.Authentication.Header.*.nupkg -s https://package.savory.cn/v3/index.json --skip-duplicate

move /Y Panosen.AspNetCore.Authentication.Basic\bin\Release\Panosen.AspNetCore.Authentication.Basic.*.nupkg D:\LocalSavoryNuget\
move /Y Panosen.AspNetCore.Authentication.Header\bin\Release\Panosen.AspNetCore.Authentication.Header.*.nupkg D:\LocalSavoryNuget\

pause