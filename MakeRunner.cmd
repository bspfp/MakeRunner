@ECHO OFF
SETLOCAL ENABLEEXTENSIONS
CD /D %~dp0

:: MakeRunner.cmd [icon file]

:: �����Ϸ� ��� ����
SET CSCPATH="C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe"

:: ��� ���� �̸�
SET OUTNAME=Runner.exe

:: ������ ����
SET ICONFILE=app.ico
IF NOT "%1"=="" SET ICONFILE=%1
SET ICONOPT=
IF EXIST %ICONFILE% SET ICONOPT=/win32icon:%ICONFILE%

%CSCPATH% /nologo /target:winexe %ICONOPT% /out:%OUTNAME% MakeRunnerSource.cs && ^
EXIT /B 0

PAUSE
EXIT /B 1
