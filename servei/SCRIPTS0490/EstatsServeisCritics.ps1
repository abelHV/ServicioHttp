#Autor: Abel
# Versió i data: v1.0-30/04/2026
# Funcionalitat: Verifica si els serveis crítics de Windows estan en execució o aturats.


$serveis = @("Spooler", "AudioEndpointBuilder", "wuauserv", "LanmanServer")

Write-Host "--- ESTAT DELS SERVEIS CRÍTICS ---"
Write-Host "SERVEI              | ESTAT"
Write-Host "-----------------------------"

foreach ($s in $serveis) {
    $obj = Get-Service -Name $s -ErrorAction SilentlyContinue
    if ($obj) {
        $nom = $obj.DisplayName.PadRight(20)
        $estat = $obj.Status
        Write-Host "$nom | $estat"
    }
}