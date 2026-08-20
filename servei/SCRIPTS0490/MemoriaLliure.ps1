#Autor: Abel
# Versió i data: v1.0-30/04/2026
# Funcionalitat: Retorna la memòria RAM lliure en MB
Get-CimInstance Win32_OperatingSystem | Select-Object @{Name="FreePhysicalMemory_MB";Expression={$_.FreePhysicalMemory / 1KB}} | Format-Table -AutoSize