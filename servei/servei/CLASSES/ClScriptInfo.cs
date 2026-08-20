using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servei.CLASSES
{
    public class ClScriptInfo
    {
        public string Nombre;
        public string RutaCompleta;
        public string Autor;
        public string VersionData;
        public string Funcionalitat;

        public ClScriptInfo(string ruta)
        {
            this.RutaCompleta = ruta;
            this.Nombre = Path.GetFileNameWithoutExtension(ruta);

            string[] linies = File.ReadLines(ruta).Take(3).ToArray();

            this.Autor = linies.Length > 0 ? linies[0].Replace("#Autor:", "").Trim() : "Desconegut";
            this.VersionData = linies.Length > 1 ? linies[1].Replace("# Versió i data:", "").Trim() : "n/a";
            this.Funcionalitat = linies.Length > 2 ? linies[2].Replace("# Funcionalitat:", "").Trim() : "n/a";
        }
    }
}
