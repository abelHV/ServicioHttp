#Autor: Abel
# Versió i data: v1.0-30/04/2026
# Funcionalitat: Mostra un resum de les connexions de xarxa actives
Get-NetTCPConnection | Group-Object State | Select-Object Name, Count | Format-Table -AutoSize