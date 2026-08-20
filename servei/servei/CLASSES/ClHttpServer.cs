using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace servei.CLASSES
{
    public class ClHttpServer
    {
        private HttpListener _listener;
        private bool _seguir;
        public delegate string PeticioRebudaHandler(string comanda);
        public event PeticioRebudaHandler OnPeticioRebuda;

        public ClHttpServer(string port)
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add($"http://*:{port}/");
        }

        public void Start()
        {
            _listener.Start();
            _seguir = true;
            Task.Run(() => Escoltar());
        }

        public void Stop()
        {
            _seguir = false;
            _listener?.Stop();
            _listener?.Close();
        }

        private async Task Escoltar()
        {
            while (_seguir && _listener.IsListening)
            {
                try
                {
                    HttpListenerContext context = await _listener.GetContextAsync();
                    Processar(context);
                }
                catch { }
            }
        }

        private void Processar(HttpListenerContext ctx)
        {
            string comanda = ctx.Request.Url.AbsolutePath.Trim('/');

            string respostaBody = OnPeticioRebuda?.Invoke(comanda) ?? "Error de servidor";

            byte[] buffer = Encoding.UTF8.GetBytes(respostaBody);
            ctx.Response.ContentType = "text/html; charset=utf-8";
            ctx.Response.ContentLength64 = buffer.Length;
            ctx.Response.OutputStream.Write(buffer, 0, buffer.Length);
            ctx.Response.OutputStream.Close();
        }
    }
}
