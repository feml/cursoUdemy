using System;
using System.Data;
using System.Text;

namespace fml.Varios
{
    public partial class LogicaHistoryPlanilla : IDisposable
    {
        private bool disposed = false;
        private readonly string usuario;
        private readonly string password;
        private readonly string usuEmail;
        private readonly string passEmail;
        private readonly string ambiente;
        public StringBuilder cicloVida { get; set; }
        public DataTable _dtResultado { get; set; }
        private string Oficina { get; set; }
        private DateTime Fecha { get; set; }
        private string Llave { get; set; }
        private string Estado { get; set; }
        private bool Ministerio { get; set; }

        private string Id { get; set; }

        private string EstadoLogMin { get; set; }
        
        private DateTime FecLogMin { get; set; }

        public int Intentos { get; set; }
        private string EstadoDetLog { get; set; }

        private DateTime FecDetLog { get; set; }



        public LogicaHistoryPlanilla(string usuario, string password, string usuEmail, string passEmail, string ambiente)
        {
            this.usuario = usuario;
            this.password = password;
            this.usuEmail = usuEmail;
            this.passEmail = passEmail;
            this.ambiente = ambiente;
            estructuraDtResultado();
            inicializarRow();
        }


    private void estructuraDtResultado()
        {
            _dtResultado = new DataTable("Consulta");
            _dtResultado.Columns.Add("Oficina", typeof(string));
            _dtResultado.Columns.Add("Fecha", typeof(DateTime));
            _dtResultado.Columns.Add("Llave", typeof(string));
            _dtResultado.Columns.Add("Estado", typeof(string));
            _dtResultado.Columns.Add("Ministerio", typeof(bool));
            _dtResultado.Columns.Add("Id", typeof(string));
            _dtResultado.Columns.Add("EstadoLogMin", typeof(string));
            _dtResultado.Columns.Add("FecLogMin", typeof(DateTime));
            _dtResultado.Columns.Add("Intentos", typeof(int));
            _dtResultado.Columns.Add("EstadoDetLog", typeof(string));
            _dtResultado.Columns.Add("FecDetLog", typeof(DateTime));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {

                // Free any other managed objects here.
                //
            }

            disposed = true;
        }

        public string Inicio(DateTime fecIni)
        {
            Inicio();
            return "O.K";
        }

    }
}
