@ECHO OFF

SETLOCAL ENABLEEXTENSIONS
CD /D %~dp0

:: �����Ϸ� ��� ����
SET CSCPATH="C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe"

:: ��� ���� �̸�
SET OUTNAME=Runner.exe

:: ������ ����
SET ICONOPT=
IF EXIST app.ico SET ICONOPT=/win32icon:app.ico

%CSCPATH% /nologo /target:winexe %ICONOPT% /out:%OUTNAME% MakeRunnerSource.cs && ^
PAUSE && ^
EXIT /B 0

PAUSE
EXIT /B 1
