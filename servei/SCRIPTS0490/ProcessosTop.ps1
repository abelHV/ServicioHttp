#Autor: Abel
# Versió i data: v1.0-30/04/2026
# Funcionalitat: Mostra els 10 processos que consumeixen més memòria RAM
Get-Process | Sort-Object WorkingSet64 -Descending | Select-Object -First 10 Name, @{Name="RAM_MB";Expression={[math]::round($_.WorkingSet64/1MB,2)}} | Format-Table -AutoSize