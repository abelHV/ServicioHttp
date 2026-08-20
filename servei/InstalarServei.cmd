@echo off
:: Ruta del ejecutable de tu servicio
set EXE_PATH="C:\ServeiHttp\servei\servei\bin\Debug\servei.exe"
:: Ruta del InstallUtil (asegúrate de que esta versión coincide con tu proyecto .NET)
set INSTALLER="C:\Windows\Microsoft.NET\Framework64\v4.0.30319\InstallUtil.exe"

echo Instal·lant el servei MonitorSistemaHTTP490...

%INSTALLER% %EXE_PATH%

echo.
echo Iniciant el servei...
net start MonitorSistemaHTTP490

echo.
echo Fase d'instal·lació completada.
pause