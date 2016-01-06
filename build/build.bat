@ECHO OFF
SET config=%1
IF "%config%" == "" (
   SET config=Release
)
IF NOT EXIST version.txt (
	ECHO version.txt missing!
	GOTO :showerror
)

REM Get the version and comment from version.txt lines 2 and 3
SET "release="
SET "comment="
FOR /F "skip=1 delims=" %%i IN (version.txt) DO IF NOT DEFINED release SET "release=%%i"
FOR /F "skip=2 delims=" %%i IN (version.txt) DO IF NOT DEFINED comment SET "comment=%%i"

REM If there's arguments on the command line overrule version.txt and use that as the version
IF [%1] NEQ [] (SET release=%1)
IF [%2] NEQ [] (SET comment=%2) ELSE (IF [%1] NEQ [] (SET "comment="))

SET version=%release%

REM Build
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild Build.proj /p:Configuration="%config%" /p:BUILD_RELEASE=%release% /p:BUILD_COMMENT=%comment%

REM Package
nuget.exe Pack UrlRewritingNet.UrlRewriter.nuspec -Version %version% -Symbols
GOTO :EOF

:showerror
PAUSE