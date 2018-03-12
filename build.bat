cd /d %~dp0
@echo off

set DEVENV="C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE\devenv.com"
set NUGET="C:\Program Files (x86)\NuGet\nuget.exe"

if not exist %NUGET% (
	set NUGET=nuget.exe
)

for /r %%i in (*.sln) do (
	echo %%i

	echo %NUGET% restore %%i
	     %NUGET% restore %%i || exit /b 1
	echo %DEVENV% %%i /rebuild "Release|Any CPU"
	     %DEVENV% %%i /rebuild "Release|Any CPU" || exit /b 1
)
