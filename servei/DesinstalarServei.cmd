@echo off
:: Ruta del ejecutable de tu servicio
set EXE_PATH="C:\ServeiHttp\servei\servei\bin\Debug\servei.exe"
:: Ruta del InstallUtil
set INSTALLER="C:\Windows\Microsoft.NET\Framework64\v4.0.30319\InstallUtil.exe"

echo Aturant el servei...
net stop MonitorSistemaHTTP490

echo.
echo Desinstal·lant el servei...
%INSTALLER% /u %EXE_PATH%

echo.
echo El servei s'ha eliminat correctament.
pause