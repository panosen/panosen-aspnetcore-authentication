@echo off

dotnet restore

dotnet build --no-restore -c Release

move /Y Panosen.AspNetCore.Authentication.Basic\bin\Release\Panosen.AspNetCore.Authentication.Basic.*.nupkg D:\LocalSavoryNuget\
move /Y Panosen.AspNetCore.Authentication.Header\bin\Release\Panosen.AspNetCore.Authentication.Header.*.nupkg D:\LocalSavoryNuget\

pause