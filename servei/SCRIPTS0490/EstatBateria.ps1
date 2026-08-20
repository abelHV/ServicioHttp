#Autor: Abel
# Versió i data: 1.0 - 04/05/2026
# Funcionalitat: Mostra el percentatge de bateria i si el carregador està connectat.

$bateria = Get-WmiObject -Class Win32_Battery
if ($bateria) {
    Write-Host "--- ESTAT DE LA BATERIA ---"
    Write-Host "Percentatge: $($bateria.EstimatedChargeRemaining)%"
    $estat = if ($bateria.BatteryStatus -eq 2) { "Carregant / Connectat" } else { "Descarregant" }
    Write-Host "Estat: $estat"
} else {
    Write-Host "No s'ha detectat cap bateria (possiblement un sobretaula)."
}