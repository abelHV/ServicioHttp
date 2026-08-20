#Autor: Abel
# Versió i data: v1.0-30/04/2026
# Funcionalitat: Busca els 5 errors més recents al registre d'esdeveniments del sistema.


Write-Host "--- ÚLTIMS 5 ERRORS DEL SISTEMA ---"
Write-Host "DATA                | FONT               | MISSATGE"
Write-Host "------------------------------------------------------"

Get-EventLog -LogName System -EntryType Error -Newest 5 | ForEach-Object {
    $data = $_.TimeGenerated.ToString("dd/MM HH:mm")
    $font = $_.Source.PadRight(18)
    $msg = $_.Message.Replace("`r`n", " ").Substring(0, [math]::Min($_.Message.Length, 40))
    Write-Host "$data | $font | $msg..."
}