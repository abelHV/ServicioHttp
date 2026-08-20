#Autor: Abel
# Versió i data: v1.0-30/04/2026
# Funcionalitat: Indica quant de temps fa que el sistema està encès
$os = Get-CimInstance Win32_OperatingSystem
$uptime = (Get-Date) - $os.LastBootUpTime
Write-Output "El sistema porta encès: $($uptime.Days) dies, $($uptime.Hours) hores i $($uptime.Minutes) minuts."