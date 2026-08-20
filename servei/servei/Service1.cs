using servei.CLASSES;
using System;
using System.Diagnostics;
using System.ServiceProcess;

namespace servei
{
    public partial class MonitorService : ServiceBase
    {
        ClGestorScripts gestor;
        ClHttpServer servidor;
        string rutaCarpeta = @"C:\SCRIPTS0490";

        public MonitorService()
        {
            this.ServiceName = "MonitorSistemaHTTP490";

            if (!EventLog.SourceExists("MonitorSistema"))
            {
                EventLog.CreateEventSource("MonitorSistema", "Application");
            }
        }

        protected override void OnStart(string[] args)
        {
            // 1. Inicializar lógica
            gestor = new ClGestorScripts(rutaCarpeta);

            // 2. Inicializar servidor HTTP en el puerto 8080
            servidor = new ClHttpServer("8080");
            
            // 3. Suscribirse al evento de peticiones
            servidor.OnPeticioRebuda += Servidor_OnPeticioRebuda;
            
            servidor.Start();

            EventLog.WriteEntry("MonitorSistema", "Servei i Servidor HTTP Iniciats", EventLogEntryType.Information);
        }

        // Aquí es donde unimos el servidor con los scripts y el HTML
        private string Servidor_OnPeticioRebuda(string comanda)
        {
            string respostaBody = "";
            string titolPagina = "Monitor Sistema";

            if (comanda.ToLower() == "whatcanyoudo")
            {
                titolPagina = "Scripts Disponibles";
                foreach (var s in gestor.Llista)
                {
                    respostaBody += $"NOM: {s.Nombre}\nAutor: {s.Autor}\nVersió: {s.VersionData}\nFuncionalitat: {s.Funcionalitat}\n\n";
                }
            }
            else
            {
                ClScriptInfo trobat = gestor.Buscar(comanda);
                if (trobat != null)
                {
                    titolPagina = "Resultat: " + trobat.Nombre;
                    ClPowerShellRunner ps = new ClPowerShellRunner();
                    respostaBody = ps.Executar(trobat.RutaCompleta);
                    EventLog.WriteEntry("MonitorSistema", "Executat script: " + trobat.Nombre);
                }
                else
                {
                    respostaBody = "L'script no existeix.";
                }
            }

            // Devolvemos el HTML ya generado con el estilo profesional
            return ClGeneradorHTML.Envoltar(respostaBody, titolPagina);
        }

        protected override void OnStop()
        {
            servidor?.Stop();
        }
    }
}