@ECHO OFF
SETLOCAL ENABLEEXTENSIONS
CD /D %~dp0

:: MakeRunner.cmd [icon file]

:: 컴파일러 경로 설정
SET CSCPATH="C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe"

:: 출력 파일 이름
SET OUTNAME=Runner.exe

:: 아이콘 설정
SET ICONFILE=app.ico
IF NOT "%1"=="" SET ICONFILE=%1
SET ICONOPT=
IF EXIST %ICONFILE% SET ICONOPT=/win32icon:%ICONFILE%

%CSCPATH% /nologo /target:winexe %ICONOPT% /out:%OUTNAME% MakeRunnerSource.cs && ^
EXIT /B 0

PAUSE
EXIT /B 1
