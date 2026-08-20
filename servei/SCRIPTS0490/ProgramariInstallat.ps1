#Autor: Abel
# Versió i data: 1.1 - 2026
# Funcionalitat: Llista els darrers 10 programes instal·lats al sistema.

Write-Host "--- DARRERS PROGRAMES INSTAL·LATS ---"
Write-Host "DATA        | NOM DEL PROGRAMA"
Write-Host "--------------------------------------"

Get-ItemProperty HKLM:\Software\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\* | 
    Sort-Object InstallDate -Descending | 
    Select-Object -First 10 | 
    ForEach-Object {
        $data = if ($_.InstallDate) { $_.InstallDate } else { "Sense data" }
        Write-Host "$data | $($_.DisplayName)"
    }