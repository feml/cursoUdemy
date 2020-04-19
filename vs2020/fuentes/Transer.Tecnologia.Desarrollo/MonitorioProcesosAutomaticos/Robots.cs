using MonitorioProcesosAutomaticos.Helpers;
using System;
using System.Windows.Forms;

namespace MonitorioProcesosAutomaticos
{
    public partial class Robots : Form
    {
        public Robot robots { get; set; }
        public int _codOficina { get; set; }
        public int _codProceso { get; set; }
        public int _codEstado { get; set; }
        public DateTime _FecIni { get; set; }
        public DateTime _FecFin { get; set; }
        public Robots()
        {
            InitializeComponent();
        }

        private void Robots_Load(object sender, EventArgs e)
        {
            robots = new Robot();
            iniciarlizarComboBox();
        }

        private void iniciarlizarComboBox()
        {
            loadCbxOficinas();
            loadCbxProceso();
            loadCbxEstados();
            _FecIni = DateTime.Now;
            _FecFin = DateTime.Now;
        }

        private void loadCbxProceso()
        {
            cbxProceso.ValueMember = "CODIGO_PROCESO";
            cbxProceso.DisplayMember = "NOMBRE_PROCESO";
            cbxProceso.DataSource = robots.getEstadosProcesos();
        }

        private void loadCbxEstados()
        {

            cbxEstado.ValueMember = "ESTA_VALOR_V2";
            cbxEstado.DisplayMember = "ESTA_NOMBRE_V2";
            cbxEstado.DataSource = robots.getEstadosRobots();
        }

        private void loadCbxOficinas()
        {
            cbxOficina.ValueMember = "OFIC_CODOFIC_NB";
            cbxOficina.DisplayMember = "OFIC_NOMBRE_V2";
            cbxOficina.DataSource = robots.getOficinas();
        }

        private void cbxOficina_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                object[] valueType = { cbxProceso.SelectedValue };
                foreach (var value in valueType)
                {
                    Type t = value.GetType();
                    if (t.Equals(typeof(byte)))
                    {
                        var codOficina = cbxOficina.SelectedValue;
                        _codOficina = int.Parse(codOficina.ToString());
                    }
                    else if (t.Equals(typeof(sbyte)))
                    {
                        var codOficina = cbxOficina.SelectedValue;
                        _codOficina = int.Parse(codOficina.ToString());
                    }
                    else if (t.Equals(typeof(decimal)))
                    {
                        var codOficina = cbxOficina.SelectedValue;
                        _codOficina = int.Parse(codOficina.ToString());
                    }
                    else if (t.Equals(typeof(double)))
                    {
                        var codOficina = cbxOficina.SelectedValue;
                        _codOficina = int.Parse(codOficina.ToString());
                    }
                    else if (t.Equals(typeof(int)))
                    {
                        var codOficina = cbxOficina.SelectedValue;
                        _codOficina = int.Parse(codOficina.ToString());
                    }
                    else if (t.Equals(typeof(long)))
                    {
                        var codOficina = cbxOficina.SelectedValue;
                        _codOficina = int.Parse(codOficina.ToString());
                    }
                    else
                    { 
                        Console.WriteLine("'{0}' is another data type.", value); 
                    }
                }
            }
            catch (Exception ex)
            {
                _codOficina = 0;
            }
        }

        private void cbxProceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                object[] valueType = { cbxProceso.SelectedValue };
                foreach (var value in valueType)
                {
                    Type t = value.GetType();
                    if (t.Equals(typeof(byte)))
                    {
                        var codProceso = cbxProceso.SelectedValue;
                        _codProceso = int.Parse(codProceso.ToString());
                    }
                    else if (t.Equals(typeof(sbyte)))
                    {
                        var codProceso = cbxProceso.SelectedValue;
                        _codProceso = int.Parse(codProceso.ToString());
                    }

                    else if (t.Equals(typeof(int)))
                    {
                        var codProceso = cbxProceso.SelectedValue;
                        _codProceso = int.Parse(codProceso.ToString());
                    }

                    else if (t.Equals(typeof(long)))
                    {
                        var codProceso = cbxProceso.SelectedValue;
                        _codProceso = int.Parse(codProceso.ToString());
                    }

                    else if (t.Equals(typeof(decimal)))
                    {
                        var codProceso = cbxProceso.SelectedValue;
                        _codProceso = int.Parse(codProceso.ToString());
                    }

                    else if (t.Equals(typeof(double)))
                    {
                        var codProceso = cbxProceso.SelectedValue;
                        _codProceso = int.Parse(codProceso.ToString());
                    }

                    else
                    { 
                        Console.WriteLine("'{0}' is another data type.", value); 
                    }
                }
            }
            catch (Exception ex)
            {
                _codProceso = 0;
            }
        }

        private void cbxEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                object[] valueType = { cbxProceso.SelectedValue };
                foreach (var value in valueType)
                {
                    Type t = value.GetType();
                    if (t.Equals(typeof(byte)))
                    {
                        var codEstado = cbxEstado.SelectedValue;
                        _codEstado = int.Parse(codEstado.ToString());
                    }

                    else if (t.Equals(typeof(sbyte)))
                    {
                        var codEstado = cbxEstado.SelectedValue;
                        _codEstado = int.Parse(codEstado.ToString());
                    }
                    else if (t.Equals(typeof(int)))
                    {
                        var codEstado = cbxEstado.SelectedValue;
                        _codEstado = int.Parse(codEstado.ToString());
                    }
                    else if (t.Equals(typeof(long)))
                    {
                        var codEstado = cbxEstado.SelectedValue;
                        _codEstado = int.Parse(codEstado.ToString());
                    }
                    else if (t.Equals(typeof(decimal)))
                    {
                        var codEstado = cbxEstado.SelectedValue;
                        _codEstado = int.Parse(codEstado.ToString());
                    }
                    else if (t.Equals(typeof(double)))
                    {
                        var codEstado = cbxEstado.SelectedValue;
                        _codEstado = int.Parse(codEstado.ToString());
                    }
                    else
                    { 
                        Console.WriteLine("'{0}' is another data type.", value); 
                    }
                }
            }
            catch (Exception ex)
            {
                _codEstado = 0;
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            dgvConsulta.DataSource = robots.ExecuteQuery(_FecIni, _FecFin, _codOficina, _codEstado, _codProceso);
            label8.Text = "Registros Procesados.  " + dgvConsulta.Rows.Count;
        }

        private void dtpFechaInicial_ValueChanged(object sender, EventArgs e)
        {
            _FecIni = dtpFechaInicial.Value;
        }

        private void dtpFechaFinal_ValueChanged(object sender, EventArgs e)
        {
            _FecFin = dtpFechaFinal.Value;
        }
    }
}
