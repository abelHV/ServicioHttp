#Autor: Abel
# Versió i data: 1.0 - 2026
# Funcionalitat: Calcula la mida total dels fitxers temporals de Windows (Temp).

$rutaTemp = "C:\Windows\Temp"
Write-Host "--- ANALISI DE CARPETES ---"
if (Test-Path $rutaTemp) {
    $mida = (Get-ChildItem $rutaTemp -Recurse -ErrorAction SilentlyContinue | Measure-Object -Property Length -Sum).Sum / 1MB
    Write-Host "Carpeta: $rutaTemp"
    Write-Host "Mida total: $([math]::round($mida, 2)) MB"
} else {
    Write-Host "No es pot accedir a la ruta temporal."
}