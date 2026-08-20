using System;
using System.Collections.Generic;
using System.IO;

namespace servei.CLASSES
{
    public class ClGestorScripts
    {
        private string _ruta;
        public List<ClScriptInfo> Llista { get; private set; }

        public ClGestorScripts(string ruta)
        {
            _ruta = ruta;
            Llista = new List<ClScriptInfo>();
            Carregar();
        }

        private void Carregar()
        {
            if (Directory.Exists(_ruta))
            {
                foreach (string fitxer in Directory.GetFiles(_ruta, "*.ps1"))
                {
                    Llista.Add(new ClScriptInfo(fitxer));
                }
            }
        }

        public ClScriptInfo Buscar(string nom)
        {
            return Llista.Find(s => s.Nombre.Equals(nom, StringComparison.OrdinalIgnoreCase));
        }
    }
}