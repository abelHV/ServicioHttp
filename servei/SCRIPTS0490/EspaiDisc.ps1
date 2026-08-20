#Autor: Abel
# Versió i data: v1.0-30/04/2026
# Funcionalitat: Llista l'espai lliure de tots els discs locals (C:, etc.)
Get-Volume | Where-Object {$_.DriveLetter -ne $null} | Select-Object DriveLetter, FriendlyName, @{Name="SizeGB";Expression={[math]::round($_.Size/1GB,2)}}, @{Name="FreeGB";Expression={[math]::round($_.SizeRemaining/1GB,2)}} | Format-Table -AutoSize