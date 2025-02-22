@echo off

dotnet restore

dotnet build --no-restore -c Release

dotnet nuget push Panosen.AspNetCore.Authentication.Basic\bin\Release\Panosen.AspNetCore.Authentication.Basic.*.nupkg -s https://nuget.panosen.cn/v3/index.json -k 1cd8e026-9715-3c58-aa2c-42cd087c0b88 --skip-duplicate

dotnet nuget push Panosen.AspNetCore.Authentication.Header\bin\Release\Panosen.AspNetCore.Authentication.Header.*.nupkg -s https://nuget.panosen.cn/v3/index.json -k 1cd8e026-9715-3c58-aa2c-42cd087c0b88 --skip-duplicate

move /Y Panosen.AspNetCore.Authentication.Basic\bin\Release\Panosen.AspNetCore.Authentication.Basic.*.nupkg D:\LocalSavoryNuget\

move /Y Panosen.AspNetCore.Authentication.Header\bin\Release\Panosen.AspNetCore.Authentication.Header.*.nupkg D:\LocalSavoryNuget\

pause