namespace servei.CLASSES
{
    public static class ClGeneradorHTML
    {
        public static string Envoltar(string contingut, string titol = "Monitor Sistema")
        {
            return $@"<!DOCTYPE html>
            <html lang='ca'>
            <head>
                <meta charset='UTF-8'>
                <title>{titol}</title>
                <style>
                    :root {{
                        --bg-body: #0f172a;       /* Fondo exterior azul noche */
                        --bg-console: #1e293b;    /* Fondo consola slate */
                        --text-main: #f8fafc;     /* Texto principal */
                        --accent: #38bdf8;        /* Azul brillante para el título */
                        --border: #334155;        /* Bordes suaves */
                    }}

                    body {{ 
                        font-family: 'Segoe UI', system-ui, sans-serif; 
                        background-color: var(--bg-body); 
                        margin: 0; 
                        display: flex; 
                        justify-content: center; 
                        align-items: center; 
                        min-height: 100vh;
                        color: var(--text-main);
                    }}

                    .main-container {{ 
                        width: 90%; 
                        max-width: 850px; 
                    }}

                    .header {{
                        margin-bottom: 15px;
                        display: flex;
                        align-items: center;
                        gap: 12px;
                    }}

                    .header h2 {{ 
                        margin: 0; 
                        font-size: 1.2rem; 
                        color: var(--accent); 
                        text-transform: uppercase;
                        letter-spacing: 1px;
                    }}

                    /* Bloque estilo CMD profesional */
                    pre {{ 
                        background: var(--bg-console); 
                        color: var(--text-main); 
                        padding: 25px; 
                        border-radius: 12px; 
                        box-shadow: 0 20px 25px -5px rgba(0, 0, 0, 0.3);
                        border: 1px solid var(--border);
                        overflow-x: auto; 
                        font-family: 'Consolas', 'Cascadia Code', 'Monaco', monospace;
                        font-size: 14px;
                        line-height: 1.6;
                        margin: 0;
                        white-space: pre-wrap; /* Mantiene saltos de línea del script */
                    }}

                    .footer {{ 
                        margin-top: 15px; 
                        font-size: 11px; 
                        color: #64748b; 
                        text-align: right;
                        font-weight: 500;
                    }}
                </style>
            </head>
            <body>
                <div class='main-container'>
                    <div class='header'>
                        <div style='width: 12px; height: 12px; background: #ef4444; border-radius: 50%;'></div>
                        <div style='width: 12px; height: 12px; background: #f59e0b; border-radius: 50%;'></div>
                        <div style='width: 12px; height: 12px; background: #10b981; border-radius: 50%;'></div>
                        <h2>{titol}</h2>
                    </div>
                    <pre>{contingut}</pre>
                    <div class='footer'>SYSTEM MONITOR • ABEL • 2026</div>
                </div>
            </body>
            </html>";
        }
    }
}