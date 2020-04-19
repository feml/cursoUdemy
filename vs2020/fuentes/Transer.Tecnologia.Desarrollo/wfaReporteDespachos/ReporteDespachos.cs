using executionreports;
using infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfaReporteDespachos
{
    public partial class ReporteDespachos : Form
    {

        #region Definicion de las variables globales al proyecto
        public DataTable _dtGlobal { get; set; }

        #region Definicion de las columnas de la tabla de salida
        private int _OFIC_CODOFIC { get; set; }
        private string _OFIC_NOMBRE { get; set; }
        private string _ORCA_NUMERO { get; set; }
        private DateTime _ORCA_FECCREA { get; set; }
        private string _ORCA_ESTADO { get; set; }
        private string _VEHI_PLACA { get; set; }
        private string _TRAI_PLACA { get; set; }
        private string _VIAJ_NOPLANILLA { get; set; }
        private DateTime _VIAJ_FECVIAJE { get; set; }
        private string _VIAJ_ESTADO { get; set; }
        private string _VIAJ_CELULAR { get; set; }
        private string _EMPL_NOMBRE { get; set; }
        private string _VIAJ_CUMLIQ { get; set; }
        private DateTime _VIAJ_FECANULA { get; set; }
        private double _COND_CEDULA { get; set; }
        private string _COND_NOMBRE { get; set; }
        private double _PROP_CEDULA { get; set; }
        private string _PROP_NOMBRE { get; set; }
        private double _POSE_CEDULA { get; set; }
        private string _POSE_NOMBRE { get; set; }
        private string _PROD_NOMBRE { get; set; }
        private int _NEGO_NRONEGOCIO { get; set; }
        private int _CLIE_CODIGO_NEGOCIO { get; set; }
        private int _CLIE_NIT_NEGOCIO { get; set; }
        private string _CLIE_NOMBRE_NEGOCIO { get; set; }
        private int _CLIE_CODIGO_PAGA { get; set; }
        private int _CLIE_NIT_PAGA { get; set; }
        private string _CLIE_NOMBRE_PAGA { get; set; }
        private int _PLAN_CODPLANTA_ORIGEN { get; set; }
        private string _PLAN_NOMPLANTA_ORIGEN { get; set; }
        private string _PLAN_ORIGEN { get; set; }
        private string _CIUD_ORIGEN { get; set; }
        private int _PLAN_CODPLANTA_DESTINO { get; set; }
        private string _PLAN_NOMPLANTA_DESTINO { get; set; }
        private string _PLAN_DESTINO { get; set; }
        private string _CIUD_DESTINO { get; set; }


        private string _tipoFlete { get; set; }
        private double _fleteEmp { get; set; }
        private double _fleteCon { get; set; }
        public string _intermediacion { get; set; }
        public double _margen { get; set; }
        private double _KilDespachados { get; set; }
        private double _KilRecibidos { get; set; }



        private string _tipoAnticipo { get; set; }
        private string _chequenro { get; set; }
        private string _comprobante { get; set; }
        private double _valorCheque { get; set; }
        private string _volaEfecnro { get; set; }
        private double _volaEfecvalor { get; set; }
        private string _volaCombunro { get; set; }
        private double _volaCombuvalor { get; set; }
        public int[] _cfgTbl { get; set; }


        public string _factura { get; set; }
        public DateTime _fecFactura { get; set; }
        public string _estadoFactura { get; set; }


        #endregion fin de la Definicion de las columnas de la tabla de salida

        public DataTable _dtOsp { get; set; }
        public DataTable _dtBavaria { get; set; }
        public DataTable _dtDeseguro { get; set; }
        public DataTable _dtMinisterio { get; set; }
        public DataTable _dtFacturas { get; set; }
        private int _codOfic { get; set; }
        private DateTime _dtFecIni { get; set; }
        private DateTime _dtFecFin { get; set; }
        #endregion fin de la Definicion de las variables globales al proyecto



        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Ambiente { get; set; }
        public Consola consola { get; set; }




        public ReporteDespachos()
        {
            InitializeComponent();

            DateTime fecIni = DateTime.Now;
            #region Definicion del bloque de seguridad
            string usuario = string.Empty;
            string password = string.Empty;
            string usuEmail = string.Empty;
            string passEmail = string.Empty;
            string ambiente = string.Empty;
            SecurityPrvt security = new SecurityPrvt();
            try
            {
                usuario = security.Decode("fmontoya");
            }
            catch (System.Exception)
            {
                usuario = security.Decode("usuario");
            }
            try
            {
                password = security.Decode("f935cjm9262");
            }
            catch (System.Exception)
            {
                password = security.Decode("password");
            }
            try
            {
                usuEmail = security.Decode("robotcorreo");
            }
            catch (System.Exception)
            {
                usuEmail = security.Decode("usuEmail");
            }
            try
            {
                passEmail = security.Decode("Tys860504882");
            }
            catch (System.Exception)
            {
                passEmail = security.Decode("passEmail");
            }
            try
            {
                ambiente = security.Decode("produccion");
            }
            catch (System.Exception)
            {
                ambiente = security.Decode("desarrollo");
            }
            #endregion fin de la Definicion del bloque de seguridad
            Usuario = usuario;
            Password = password;
            Ambiente = ambiente;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            dgvConsulta.DataSource = Consulta();
        }
        private DataTable Consulta()
        {
            createTables();
            string[] _nParametros;
            object[] _vParametros;
            DataTable dt = new DataTable();
            if (_codOfic == 0)
            {
                _nParametros = new string[2] { ":fecini", ":fecfin" };
                _vParametros = new object[2] { _dtFecIni, _dtFecFin };

                //dt = _datos.getTableDataAdaptar(getSelect("resumenMilenioTodas"), _nParametros, _vParametros);

                Factory data = new Factory(Usuario, Password, Ambiente);
                try
                {
                    dt = data.getTable("resumenMilenioTodas", _nParametros, _vParametros);
                }
                catch (Exception ex)
                {
                    ManejoError(ex, "var dtLogReporteDian = data.getTable(\"getLogReporteDian\", _nParametros, _vParametros);");
                }
            }
            else
            {
                _nParametros = new string[3] { ":fecini", ":fecfin", ":oficina" };
                _vParametros = new object[3] { _dtFecIni, _dtFecFin, _codOfic };

                //dt = _datos.getTableDataAdaptar(getSelect("resumenMilenioOficina"), _nParametros, _vParametros);
                Factory data = new Factory(Usuario, Password, Ambiente);
                try
                {
                    dt = data.getTable("resumenMilenioOficina", _nParametros, _vParametros);
                }
                catch (Exception ex)
                {
                    ManejoError(ex, "var dtLogReporteDian = data.getTable(\"getLogReporteDian\", _nParametros, _vParametros);");
                }
            }
            //dgvConsulta.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    cargarVariables(dr);
                }
            }
            return _dtGlobal;
        }
        private void ManejoError(Exception ex, string texto)
        {
            using (StreamWriter writer = new StreamWriter("Robots.txt", true))
            {
                writer.WriteLine("Fecha : " + DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToLongTimeString());
                writer.WriteLine("Se Produjo un error de tipo Exception:");
                writer.WriteLine(ex.Message);
            }
            consola.ReadKey("Se presento un error ...!!!!\r\n\r\n\r\n" + texto + ex.Message, true);
        }

        private void cargarVariables(DataRow dr)
        {
            #region Definicion del bloque carga variables

            _OFIC_NOMBRE = dr["oficina"].ToString();
            _ORCA_NUMERO = dr["orden"].ToString();
            _ORCA_FECCREA = DateTime.Parse(dr["fecOrden"].ToString());
            _ORCA_ESTADO = dr["estOrden"].ToString();
            _COND_CEDULA = double.Parse(dr["idConductor"].ToString());
            _COND_NOMBRE = dr["conductor"].ToString();
            _VEHI_PLACA = dr["vehiculo"].ToString();
            _TRAI_PLACA = dr["trailer"].ToString();
            _PROD_NOMBRE = dr["producto"].ToString();

            if (cbxInfoPlanilla.Checked)
            {
                _VIAJ_NOPLANILLA = dr["planilla"].ToString();
                _VIAJ_FECVIAJE = DateTime.Parse(dr["fecPlanilla"].ToString());
                _VIAJ_ESTADO = dr["estPlanilla"].ToString();
                try
                {
                    _VIAJ_FECANULA = DateTime.Parse(dr["fecAnula"].ToString());
                }
                catch (Exception ex)
                {
                    _VIAJ_FECANULA = DateTime.Now;
                }
                _VIAJ_CUMLIQ = dr["cumliq"].ToString();
                _VIAJ_CELULAR = dr["celular"].ToString();
                _EMPL_NOMBRE = dr["funcionario"].ToString();
            }
            if (cbxInfoPropietario.Checked)
            {
                _PROP_CEDULA = double.Parse(dr["idPropietario"].ToString());
                _PROP_NOMBRE = dr["propietario"].ToString();
                _POSE_CEDULA = double.Parse(dr["idPoseedor"].ToString());
                _POSE_NOMBRE = dr["poseedor"].ToString();

            }
            if (cbxInfoRuta.Checked)
            {
                _CIUD_ORIGEN = dr["Origen"].ToString();
                _CIUD_DESTINO = dr["destino"].ToString();
            }
            if (cbxInfoClienteNegocio.Checked)
            {
                _NEGO_NRONEGOCIO = int.Parse(dr["idNegocio"].ToString());
                _CLIE_CODIGO_NEGOCIO = int.Parse(dr["codClienteNegocio"].ToString());
                _CLIE_NIT_NEGOCIO = int.Parse(dr["idClienteNegocio"].ToString());
                _CLIE_NOMBRE_NEGOCIO = dr["clienteNegocio"].ToString();
                _CLIE_CODIGO_PAGA = int.Parse(dr["codClientePaga"].ToString());
                _CLIE_NIT_PAGA = int.Parse(dr["idClientePaga"].ToString());
                _CLIE_NOMBRE_PAGA = dr["clientePaga"].ToString();
            }
            if (cbxInfoPlantas.Checked)
            {
                _PLAN_CODPLANTA_ORIGEN = int.Parse(dr["idPlaOrigen"].ToString());
                _PLAN_NOMPLANTA_ORIGEN = dr["PlantaOrigen"].ToString();
                _PLAN_ORIGEN = dr["PLAN_ORIGEN"].ToString();

                _PLAN_CODPLANTA_DESTINO = int.Parse(dr["idPlaDestino"].ToString());
                _PLAN_NOMPLANTA_DESTINO = dr["PlantaDestino"].ToString();
                _PLAN_DESTINO = dr["PLAN_DESTINO"].ToString();
            }
            if (cbxInfoFletes.Checked)
            {
                _fleteEmp = 0;
                _fleteCon = 0;
                double fleteEmpresa = 0;
                double fleteConductor = 0;
                DataTable dtFletes = new DataTable("Fletes");
                string[] _nParametros;
                object[] _vParametros;
                _nParametros = new string[1] { ":planilla" };
                _vParametros = new object[1] { dr["planilla"].ToString() 
            };

                //dtFletes = _datos.getTableDataAdaptar(getSelect("fletes"), _nParametros, _vParametros);

                Factory data = new Factory(Usuario, Password, Ambiente);
                try
                {
                    dtFletes = data.getTable("fletes", _nParametros, _vParametros);
                }
                catch (Exception ex)
                {
                    ManejoError(ex, "var dtLogReporteDian = data.getTable(\"getLogReporteDian\", _nParametros, _vParametros);");
                }

                if (dtFletes.Rows.Count > 0)
                {
                    foreach (DataRow drFle in dtFletes.Rows)
                    {
                        _tipoFlete = drFle["VIDE_VOLUMEN"].ToString();
                        if (drFle["CUMP_ESTADO"].ToString() == "I")
                        {
                            _KilDespachados = double.Parse(drFle["CUMP_KILOSDESPACHA"].ToString());
                            _KilRecibidos = 0;

                            if (_tipoFlete == "V")
                            {
                                fleteEmpresa = double.Parse(drFle["VIDE_FLETEEMPR"].ToString());
                                fleteConductor = double.Parse(drFle["VIDE_FLETECOND"].ToString());
                                _tipoFlete = "Volumen";
                            }
                            else
                            {
                                fleteEmpresa = double.Parse(drFle["VIDE_FLETEEMPR"].ToString()) * _KilDespachados;
                                fleteConductor = double.Parse(drFle["VIDE_FLETECOND"].ToString()) * _KilDespachados;
                                _tipoFlete = "Peso";
                            }
                        }
                        else
                        {
                            _KilDespachados = double.Parse(drFle["CUMP_KILOSDESPACHA"].ToString());
                            _KilRecibidos = double.Parse(drFle["CUMP_KILOSRECIBE"].ToString());

                            if (_tipoFlete == "V")
                            {
                                fleteEmpresa = double.Parse(drFle["VIDE_FLETEEMPR"].ToString());
                                fleteConductor = double.Parse(drFle["VIDE_FLETECOND"].ToString());
                                _tipoFlete = "Volumen";
                            }
                            else
                            {
                                fleteEmpresa = double.Parse(drFle["VIDE_FLETEEMPR"].ToString()) * _KilRecibidos;
                                fleteConductor = double.Parse(drFle["VIDE_FLETECOND"].ToString()) * _KilRecibidos;
                                _tipoFlete = "Peso";
                            }

                        }
                        /*_fleteEmp += fleteEmpresa;
                        _fleteCon += fleteConductor;*/
                        _fleteEmp += Math.Truncate(fleteEmpresa);
                        _fleteCon += Math.Truncate(fleteConductor);

                        if (_fleteEmp == _fleteCon)
                        {
                            _intermediacion = "100%";
                            _margen = 100;
                        }
                        else
                        {
                            //_intermediacion = (100-(_fleteCon / _fleteEmp) * 100).ToString()+("%");
                            double aTruncated = Math.Truncate((100 - (_fleteCon / _fleteEmp) * 100));

                            _intermediacion = aTruncated.ToString() + "%";
                            _margen = _fleteEmp - _fleteCon;
                        }
                    }
                }
                else
                {
                    _tipoFlete = "Sin anticipo";
                    _KilDespachados = 0;
                    _KilRecibidos = 0;
                    _fleteEmp = 0;
                    _fleteCon = 0;

                }
            }
            if (cbxInfoAnticipos.Checked)
            {
                _tipoAnticipo = string.Empty;
                _chequenro = "N/A";
                _comprobante = "N/A";
                _valorCheque = 0;
                _volaEfecnro = "N/A";
                _volaEfecvalor = 0;
                _volaCombunro = "N/A";
                _volaCombuvalor = 0;
                //_fleteEmp = 0;
                //_fleteCon = 0;
                DataTable dtAnticpos = new DataTable("Anticipo");
                string[] _nParametros;
                object[] _vParametros;
                _nParametros = new string[1] { ":planilla" };
                _vParametros = new object[1] { dr["planilla"].ToString() };
                //dtAnticpos = _datos.getTableDataAdaptar(getSelect("anticipos"), _nParametros, _vParametros);

                Factory data = new Factory(Usuario, Password, Ambiente);
                try
                {
                    dtAnticpos = data.getTable("anticipos", _nParametros, _vParametros);
                }
                catch (Exception ex)
                {
                    ManejoError(ex, "var dtLogReporteDian = data.getTable(\"getLogReporteDian\", _nParametros, _vParametros);");
                }

                if (dtAnticpos.Rows.Count > 0)
                {
                    foreach (DataRow drFle in dtAnticpos.Rows)
                    {
                        _tipoAnticipo = drFle["tipoAnticipo"].ToString();
                        if (_tipoAnticipo == "CH")
                        {
                            _chequenro = drFle["chequenro"].ToString();
                            _comprobante = drFle["comprobante"].ToString();
                            _valorCheque = double.Parse(drFle["valorCheque"].ToString());
                        }
                        if (_tipoAnticipo == "VE")
                        {
                            _volaEfecnro = drFle["VOLA_NOVOLANTE"].ToString();
                            _volaEfecvalor = double.Parse(drFle["VOLA_VALOR"].ToString());
                        }
                        if (_tipoAnticipo == "VC")
                        {
                            _volaCombunro = drFle["VOLA_NOVOLANTE"].ToString();
                            _volaCombuvalor = double.Parse(drFle["VOLA_VALOR"].ToString());
                        }
                    }
                }
                else
                {
                    _tipoAnticipo = "Sin Anticipo";
                    _chequenro = "Sin Anticipo";
                    _comprobante = "Sin Anticipo";
                    _volaEfecnro = "Sin Anticipo";
                    _volaCombunro = "Sin Anticipo";
                }
            }
            if (cbxInfoFactura.Checked)
            {
                _factura = string.Empty;
                _fecFactura = DateTime.Now;
                DataTable dtFactura = new DataTable("Factura");
                string[] _nParametros;
                object[] _vParametros;
                _nParametros = new string[1] { ":planilla" };
                _vParametros = new object[1] { dr["planilla"].ToString() };


                //dtFactura = _datos.getTableDataAdaptar(getSelect("facturas"), _nParametros, _vParametros);

                Factory data = new Factory(Usuario, Password, Ambiente);
                try
                {
                    dtFactura = data.getTable("facturas", _nParametros, _vParametros);
                }
                catch (Exception ex)
                {
                    ManejoError(ex, "var dtLogReporteDian = data.getTable(\"getLogReporteDian\", _nParametros, _vParametros);");
                }



                if (dtFactura.Rows.Count > 0)
                {
                    foreach (DataRow drFac in dtFactura.Rows)
                    {
                        _factura = drFac["FACT_NOFACTURA"].ToString();
                        _fecFactura = DateTime.Parse(drFac["FACT_FECFACT"].ToString());
                    }
                }
                else
                {
                    _factura = "No Facturado";
                }
            }
            #endregion fin de la Definicion del bloque carga variables

            #region Definicion del bloque carga filas


            #region bloque pruebas

            //todas las combinaciones
            if (_cfgTbl[0] == 1 && //planilla
                _cfgTbl[1] == 1 && //propietario
                _cfgTbl[2] == 1 && //ruta
                _cfgTbl[3] == 1 && //cliente
                _cfgTbl[4] == 1 && //planta
                _cfgTbl[5] == 1 && //flete
                _cfgTbl[6] == 1 &&//anticipo
                _cfgTbl[7] == 1 //facturas
                )//todas las combinaciones
            {
                try
                {
                    _dtGlobal.Rows.Add(_OFIC_NOMBRE, _ORCA_NUMERO, _ORCA_FECCREA, _ORCA_ESTADO, _COND_CEDULA, _COND_NOMBRE, _VEHI_PLACA, _TRAI_PLACA, _PROD_NOMBRE,
                                        _VIAJ_NOPLANILLA, _VIAJ_FECVIAJE, _VIAJ_ESTADO, _VIAJ_FECANULA, _VIAJ_CUMLIQ, _VIAJ_CELULAR, _EMPL_NOMBRE,
                                        _PROP_CEDULA, _PROP_NOMBRE, _POSE_CEDULA, _POSE_NOMBRE,
                                        _CIUD_ORIGEN, _CIUD_DESTINO,
                                        _NEGO_NRONEGOCIO, _CLIE_CODIGO_NEGOCIO, _CLIE_NIT_NEGOCIO, _CLIE_NOMBRE_NEGOCIO, _CLIE_CODIGO_PAGA, _CLIE_NIT_PAGA, _CLIE_NOMBRE_PAGA,
                                        _PLAN_CODPLANTA_ORIGEN, _PLAN_NOMPLANTA_ORIGEN, _PLAN_ORIGEN, _PLAN_CODPLANTA_DESTINO, _PLAN_NOMPLANTA_DESTINO, _PLAN_DESTINO,
                                        _tipoFlete, _KilDespachados, _KilRecibidos, _fleteEmp, _fleteCon, _intermediacion, _margen,
                                        _chequenro, _comprobante, _valorCheque, _volaEfecnro, _volaEfecvalor, _volaCombunro, _volaCombuvalor,
                                        _factura, _fecFactura);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            //sin anticipo
            if (_cfgTbl[0] == 1 && //planilla
                _cfgTbl[1] == 1 && //propietario
                _cfgTbl[2] == 1 && //ruta
                _cfgTbl[3] == 1 && //cliente
                _cfgTbl[4] == 1 && //planta
                _cfgTbl[5] == 1 && //flete
                _cfgTbl[6] == 0 && //anticipo
                _cfgTbl[7] == 1 //facturas
                )//todas las combinaciones
            {
                try
                {
                    _dtGlobal.Rows.Add(_OFIC_NOMBRE, _ORCA_NUMERO, _ORCA_FECCREA, _ORCA_ESTADO, _COND_CEDULA, _COND_NOMBRE, _VEHI_PLACA, _TRAI_PLACA, _PROD_NOMBRE,
                                        _VIAJ_NOPLANILLA, _VIAJ_FECVIAJE, _VIAJ_ESTADO, _VIAJ_FECANULA, _VIAJ_CUMLIQ, _VIAJ_CELULAR, _EMPL_NOMBRE,
                                        _PROP_CEDULA, _PROP_NOMBRE, _POSE_CEDULA, _POSE_NOMBRE,
                                        _CIUD_ORIGEN, _CIUD_DESTINO,
                                        _NEGO_NRONEGOCIO, _CLIE_CODIGO_NEGOCIO, _CLIE_NIT_NEGOCIO, _CLIE_NOMBRE_NEGOCIO, _CLIE_CODIGO_PAGA, _CLIE_NIT_PAGA, _CLIE_NOMBRE_PAGA,
                                        _PLAN_CODPLANTA_ORIGEN, _PLAN_NOMPLANTA_ORIGEN, _PLAN_ORIGEN, _PLAN_CODPLANTA_DESTINO, _PLAN_NOMPLANTA_DESTINO, _PLAN_DESTINO,
                                        _tipoFlete, _KilDespachados, _KilRecibidos, _fleteEmp, _fleteCon, _intermediacion, _margen,
                                        _factura, _fecFactura);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            //sin anticipo, sin flete
            if (_cfgTbl[0] == 1 && //planilla
                _cfgTbl[1] == 1 && //propietario
                _cfgTbl[2] == 1 && //ruta
                _cfgTbl[3] == 1 && //cliente
                _cfgTbl[4] == 1 && //planta
                _cfgTbl[5] == 0 && //flete
                _cfgTbl[6] == 0 && //anticipo
                _cfgTbl[7] == 1 //facturas
                )//todas las combinaciones
            {
                try
                {
                    _dtGlobal.Rows.Add(_OFIC_NOMBRE, _ORCA_NUMERO, _ORCA_FECCREA, _ORCA_ESTADO, _COND_CEDULA, _COND_NOMBRE, _VEHI_PLACA, _TRAI_PLACA, _PROD_NOMBRE,
                                        _VIAJ_NOPLANILLA, _VIAJ_FECVIAJE, _VIAJ_ESTADO, _VIAJ_FECANULA, _VIAJ_CUMLIQ, _VIAJ_CELULAR, _EMPL_NOMBRE,
                                        _PROP_CEDULA, _PROP_NOMBRE, _POSE_CEDULA, _POSE_NOMBRE,
                                        _CIUD_ORIGEN, _CIUD_DESTINO,
                                        _NEGO_NRONEGOCIO, _CLIE_CODIGO_NEGOCIO, _CLIE_NIT_NEGOCIO, _CLIE_NOMBRE_NEGOCIO, _CLIE_CODIGO_PAGA, _CLIE_NIT_PAGA, _CLIE_NOMBRE_PAGA,
                                        _PLAN_CODPLANTA_ORIGEN, _PLAN_NOMPLANTA_ORIGEN, _PLAN_ORIGEN, _PLAN_CODPLANTA_DESTINO, _PLAN_NOMPLANTA_DESTINO, _PLAN_DESTINO,
                                        _factura, _fecFactura);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            //sin anticipo, sin flete, sin planta
            if (_cfgTbl[0] == 1 && //planilla
                _cfgTbl[1] == 1 && //propietario
                _cfgTbl[2] == 1 && //ruta
                _cfgTbl[3] == 1 && //cliente
                _cfgTbl[4] == 0 && //planta
                _cfgTbl[5] == 0 && //flete
                _cfgTbl[6] == 0 && //anticipo
                _cfgTbl[7] == 1 //facturas
                )//todas las combinaciones
            {
                try
                {
                    _dtGlobal.Rows.Add(_OFIC_NOMBRE, _ORCA_NUMERO, _ORCA_FECCREA, _ORCA_ESTADO, _COND_CEDULA, _COND_NOMBRE, _VEHI_PLACA, _TRAI_PLACA, _PROD_NOMBRE,
                                        _VIAJ_NOPLANILLA, _VIAJ_FECVIAJE, _VIAJ_ESTADO, _VIAJ_FECANULA, _VIAJ_CUMLIQ, _VIAJ_CELULAR, _EMPL_NOMBRE,
                                        _PROP_CEDULA, _PROP_NOMBRE, _POSE_CEDULA, _POSE_NOMBRE,
                                        _CIUD_ORIGEN, _CIUD_DESTINO,
                                        _NEGO_NRONEGOCIO, _CLIE_CODIGO_NEGOCIO, _CLIE_NIT_NEGOCIO, _CLIE_NOMBRE_NEGOCIO, _CLIE_CODIGO_PAGA, _CLIE_NIT_PAGA, _CLIE_NOMBRE_PAGA,
                                        _factura, _fecFactura);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            //sin anticipo, sin flete, sin planta, sin cliente
            if (_cfgTbl[0] == 1 && //planilla
                _cfgTbl[1] == 1 && //propietario
                _cfgTbl[2] == 1 && //ruta
                _cfgTbl[3] == 0 && //cliente
                _cfgTbl[4] == 0 && //planta
                _cfgTbl[5] == 0 && //flete
                _cfgTbl[6] == 0 && //anticipo
                _cfgTbl[7] == 1 //facturas
                )//todas las combinaciones
            {
                try
                {
                    _dtGlobal.Rows.Add(_OFIC_NOMBRE, _ORCA_NUMERO, _ORCA_FECCREA, _ORCA_ESTADO, _COND_CEDULA, _COND_NOMBRE, _VEHI_PLACA, _TRAI_PLACA, _PROD_NOMBRE,
                                        _VIAJ_NOPLANILLA, _VIAJ_FECVIAJE, _VIAJ_ESTADO, _VIAJ_FECANULA, _VIAJ_CUMLIQ, _VIAJ_CELULAR, _EMPL_NOMBRE,
                                        _PROP_CEDULA, _PROP_NOMBRE, _POSE_CEDULA, _POSE_NOMBRE,
                                        _CIUD_ORIGEN, _CIUD_DESTINO,
                                        _factura, _fecFactura);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            //sin anticipo, sin flete, sin planta, sin cliente, sin ruta
            if (_cfgTbl[0] == 1 && //planilla
                _cfgTbl[1] == 1 && //propietario
                _cfgTbl[2] == 0 && //ruta
                _cfgTbl[3] == 0 && //cliente
                _cfgTbl[4] == 0 && //planta
                _cfgTbl[5] == 0 && //flete
                _cfgTbl[6] == 0 && //anticipo
                _cfgTbl[7] == 1 //facturas
                )//todas las combinaciones
            {
                try
                {
                    _dtGlobal.Rows.Add(_OFIC_NOMBRE, _ORCA_NUMERO, _ORCA_FECCREA, _ORCA_ESTADO, _COND_CEDULA, _COND_NOMBRE, _VEHI_PLACA, _TRAI_PLACA, _PROD_NOMBRE,
                                        _VIAJ_NOPLANILLA, _VIAJ_FECVIAJE, _VIAJ_ESTADO, _VIAJ_FECANULA, _VIAJ_CUMLIQ, _VIAJ_CELULAR, _EMPL_NOMBRE,
                                        _PROP_CEDULA, _PROP_NOMBRE, _POSE_CEDULA, _POSE_NOMBRE,
                                        _factura, _fecFactura);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            //sin anticipo, sin flete, sin planta, sin cliente, sin ruta, sin propietario
            if (_cfgTbl[0] == 1 && //planilla
                _cfgTbl[1] == 0 && //propietario
                _cfgTbl[2] == 0 && //ruta
                _cfgTbl[3] == 0 && //cliente
                _cfgTbl[4] == 0 && //planta
                _cfgTbl[5] == 0 && //flete
                _cfgTbl[6] == 0 && //anticipo
                _cfgTbl[7] == 1 //facturas
                )//todas las combinaciones
            {
                try
                {
                    _dtGlobal.Rows.Add(_OFIC_NOMBRE, _ORCA_NUMERO, _ORCA_FECCREA, _ORCA_ESTADO, _COND_CEDULA, _COND_NOMBRE, _VEHI_PLACA, _TRAI_PLACA, _PROD_NOMBRE,
                                        _VIAJ_NOPLANILLA, _VIAJ_FECVIAJE, _VIAJ_ESTADO, _VIAJ_FECANULA, _VIAJ_CUMLIQ, _VIAJ_CELULAR, _EMPL_NOMBRE,
                                        _factura, _fecFactura);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            //sin anticipo, sin flete, sin planta, sin cliente, sin ruta, sin propietario, sin planilla
            if (_cfgTbl[0] == 0 && //planilla
                _cfgTbl[1] == 0 && //propietario
                _cfgTbl[2] == 0 && //ruta
                _cfgTbl[3] == 0 && //cliente
                _cfgTbl[4] == 0 && //planta
                _cfgTbl[5] == 0 && //flete
                _cfgTbl[6] == 0 && //anticipo
                _cfgTbl[7] == 1 //facturas
                )//todas las combinaciones
            {
                try
                {
                    _dtGlobal.Rows.Add(_OFIC_NOMBRE, _ORCA_NUMERO, _ORCA_FECCREA, _ORCA_ESTADO, _COND_CEDULA, _COND_NOMBRE, _VEHI_PLACA, _TRAI_PLACA, _PROD_NOMBRE,
                        _factura, _fecFactura);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

            //anticipo
            if (_cfgTbl[0] == 0 && //planilla
                _cfgTbl[1] == 0 && //propietario
                _cfgTbl[2] == 0 && //ruta
                _cfgTbl[3] == 0 && //cliente
                _cfgTbl[4] == 0 && //planta
                _cfgTbl[5] == 0 && //flete
                _cfgTbl[6] == 1 && //anticipo
                _cfgTbl[7] == 1 //facturas
                )//todas las combinaciones
            {
                try
                {
                    _dtGlobal.Rows.Add(_OFIC_NOMBRE, _ORCA_NUMERO, _ORCA_FECCREA, _ORCA_ESTADO, _COND_CEDULA, _COND_NOMBRE, _VEHI_PLACA, _TRAI_PLACA, _PROD_NOMBRE,
                                        _chequenro, _comprobante, _valorCheque, _volaEfecnro, _volaEfecvalor, _volaCombunro, _volaCombuvalor,
                                        _factura, _fecFactura);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

            //anticipo, flete
            if (_cfgTbl[0] == 0 && //planilla
                _cfgTbl[1] == 0 && //propietario
                _cfgTbl[2] == 0 && //ruta
                _cfgTbl[3] == 0 && //cliente
                _cfgTbl[4] == 0 && //planta
                _cfgTbl[5] == 1 && //flete
                _cfgTbl[6] == 1 && //anticipo
                _cfgTbl[7] == 1 //facturas
                )//todas las combinaciones
            {
                try
                {
                    _dtGlobal.Rows.Add(_OFIC_NOMBRE, _ORCA_NUMERO, _ORCA_FECCREA, _ORCA_ESTADO, _COND_CEDULA, _COND_NOMBRE, _VEHI_PLACA, _TRAI_PLACA, _PROD_NOMBRE,
                    _tipoFlete, _KilDespachados, _KilRecibidos, _fleteEmp, _fleteCon, _intermediacion, _margen,
                                        _chequenro, _comprobante, _valorCheque, _volaEfecnro, _volaEfecvalor, _volaCombunro, _volaCombuvalor,
                                        _factura, _fecFactura);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            //anticipo,flete,planta
            if (_cfgTbl[0] == 0 && //planilla
                _cfgTbl[1] == 0 && //propietario
                _cfgTbl[2] == 0 && //ruta
                _cfgTbl[3] == 0 && //cliente
                _cfgTbl[4] == 1 && //planta
                _cfgTbl[5] == 1 && //flete
                _cfgTbl[6] == 1 && //anticipo
                _cfgTbl[7] == 1 //facturas
                )//todas las combinaciones
            {
                try
                {
                    _dtGlobal.Rows.Add(_OFIC_NOMBRE, _ORCA_NUMERO, _ORCA_FECCREA, _ORCA_ESTADO, _COND_CEDULA, _COND_NOMBRE, _VEHI_PLACA, _TRAI_PLACA, _PROD_NOMBRE,
                    _PLAN_CODPLANTA_ORIGEN, _PLAN_NOMPLANTA_ORIGEN, _PLAN_ORIGEN, _PLAN_CODPLANTA_DESTINO, _PLAN_NOMPLANTA_DESTINO, _PLAN_DESTINO,
                                        _tipoFlete, _KilDespachados, _KilRecibidos, _fleteEmp, _fleteCon, _intermediacion, _margen,
                                        _chequenro, _comprobante, _valorCheque, _volaEfecnro, _volaEfecvalor, _volaCombunro, _volaCombuvalor,
                                        _factura, _fecFactura);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            //anticipo,flete,planta,cliente
            if (_cfgTbl[0] == 0 && //planilla
                _cfgTbl[1] == 0 && //propietario
                _cfgTbl[2] == 0 && //ruta
                _cfgTbl[3] == 1 && //cliente
                _cfgTbl[4] == 1 && //planta
                _cfgTbl[5] == 1 && //flete
                _cfgTbl[6] == 1 && //anticipo
                _cfgTbl[7] == 1 //facturas
                )//todas las combinaciones
            {
                try
                {
                    _dtGlobal.Rows.Add(_OFIC_NOMBRE, _ORCA_NUMERO, _ORCA_FECCREA, _ORCA_ESTADO, _COND_CEDULA, _COND_NOMBRE, _VEHI_PLACA, _TRAI_PLACA, _PROD_NOMBRE,
                    _NEGO_NRONEGOCIO, _CLIE_CODIGO_NEGOCIO, _CLIE_NIT_NEGOCIO, _CLIE_NOMBRE_NEGOCIO, _CLIE_CODIGO_PAGA, _CLIE_NIT_PAGA, _CLIE_NOMBRE_PAGA,
                                        _PLAN_CODPLANTA_ORIGEN, _PLAN_NOMPLANTA_ORIGEN, _PLAN_ORIGEN, _PLAN_CODPLANTA_DESTINO, _PLAN_NOMPLANTA_DESTINO, _PLAN_DESTINO,
                                        _tipoFlete, _KilDespachados, _KilRecibidos, _fleteEmp, _fleteCon, _intermediacion, _margen,
                                        _chequenro, _comprobante, _valorCheque, _volaEfecnro, _volaEfecvalor, _volaCombunro, _volaCombuvalor,
                                        _factura, _fecFactura);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            //anticipo,flete,planta,cliente,ruta
            if (_cfgTbl[0] == 0 && //planilla
                _cfgTbl[1] == 0 && //propietario
                _cfgTbl[2] == 1 && //ruta
                _cfgTbl[3] == 1 && //cliente
                _cfgTbl[4] == 1 && //planta
                _cfgTbl[5] == 1 && //flete
                _cfgTbl[6] == 1 && //anticipo
                _cfgTbl[7] == 1 //facturas
                )//todas las combinaciones
            {
                try
                {
                    _dtGlobal.Rows.Add(_OFIC_NOMBRE, _ORCA_NUMERO, _ORCA_FECCREA, _ORCA_ESTADO, _COND_CEDULA, _COND_NOMBRE, _VEHI_PLACA, _TRAI_PLACA, _PROD_NOMBRE,
                    _CIUD_ORIGEN, _CIUD_DESTINO,
                                        _NEGO_NRONEGOCIO, _CLIE_CODIGO_NEGOCIO, _CLIE_NIT_NEGOCIO, _CLIE_NOMBRE_NEGOCIO, _CLIE_CODIGO_PAGA, _CLIE_NIT_PAGA, _CLIE_NOMBRE_PAGA,
                                        _PLAN_CODPLANTA_ORIGEN, _PLAN_NOMPLANTA_ORIGEN, _PLAN_ORIGEN, _PLAN_CODPLANTA_DESTINO, _PLAN_NOMPLANTA_DESTINO, _PLAN_DESTINO,
                                        _tipoFlete, _KilDespachados, _KilRecibidos, _fleteEmp, _fleteCon, _intermediacion, _margen,
                                        _chequenro, _comprobante, _valorCheque, _volaEfecnro, _volaEfecvalor, _volaCombunro, _volaCombuvalor,
                                        _factura, _fecFactura);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            //anticipo,flete,planta,cliente,ruta,propietario
            if (_cfgTbl[0] == 0 && //planilla
                _cfgTbl[1] == 1 && //propietario
                _cfgTbl[2] == 1 && //ruta
                _cfgTbl[3] == 1 && //cliente
                _cfgTbl[4] == 1 && //planta
                _cfgTbl[5] == 1 && //flete
                _cfgTbl[6] == 1 && //anticipo
                _cfgTbl[7] == 1 //facturas
                )//todas las combinaciones
            {
                try
                {
                    _dtGlobal.Rows.Add(_OFIC_NOMBRE, _ORCA_NUMERO, _ORCA_FECCREA, _ORCA_ESTADO, _COND_CEDULA, _COND_NOMBRE, _VEHI_PLACA, _TRAI_PLACA, _PROD_NOMBRE,
                    _PROP_CEDULA, _PROP_NOMBRE, _POSE_CEDULA, _POSE_NOMBRE,
                                        _CIUD_ORIGEN, _CIUD_DESTINO,
                                        _NEGO_NRONEGOCIO, _CLIE_CODIGO_NEGOCIO, _CLIE_NIT_NEGOCIO, _CLIE_NOMBRE_NEGOCIO, _CLIE_CODIGO_PAGA, _CLIE_NIT_PAGA, _CLIE_NOMBRE_PAGA,
                                        _PLAN_CODPLANTA_ORIGEN, _PLAN_NOMPLANTA_ORIGEN, _PLAN_ORIGEN, _PLAN_CODPLANTA_DESTINO, _PLAN_NOMPLANTA_DESTINO, _PLAN_DESTINO,
                                        _tipoFlete, _KilDespachados, _KilRecibidos, _fleteEmp, _fleteCon, _intermediacion, _margen,
                                        _chequenro, _comprobante, _valorCheque, _volaEfecnro, _volaEfecvalor, _volaCombunro, _volaCombuvalor,
                                        _factura, _fecFactura);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            //flete
            if (_cfgTbl[0] == 0 && //planilla
                _cfgTbl[1] == 0 && //propietario
                _cfgTbl[2] == 0 && //ruta
                _cfgTbl[3] == 0 && //cliente
                _cfgTbl[4] == 0 && //planta
                _cfgTbl[5] == 1 && //flete
                _cfgTbl[6] == 0 && //anticipo
                _cfgTbl[7] == 1 //facturas
                )//todas las combinaciones
            {
                try
                {
                    _dtGlobal.Rows.Add(_OFIC_NOMBRE, _ORCA_NUMERO, _ORCA_FECCREA, _ORCA_ESTADO, _COND_CEDULA, _COND_NOMBRE, _VEHI_PLACA, _TRAI_PLACA, _PROD_NOMBRE,
                    _tipoFlete, _KilDespachados, _KilRecibidos, _fleteEmp, _fleteCon, _intermediacion, _margen,
                    _factura, _fecFactura);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            //flete,planta
            if (_cfgTbl[0] == 0 && //planilla
                _cfgTbl[1] == 0 && //propietario
                _cfgTbl[2] == 0 && //ruta
                _cfgTbl[3] == 0 && //cliente
                _cfgTbl[4] == 1 && //planta
                _cfgTbl[5] == 1 && //flete
                _cfgTbl[6] == 0 && //anticipo
                _cfgTbl[7] == 1 //facturas
                )//todas las combinaciones
            {
                try
                {
                    _dtGlobal.Rows.Add(_OFIC_NOMBRE, _ORCA_NUMERO, _ORCA_FECCREA, _ORCA_ESTADO, _COND_CEDULA, _COND_NOMBRE, _VEHI_PLACA, _TRAI_PLACA, _PROD_NOMBRE,
                    _PLAN_CODPLANTA_ORIGEN, _PLAN_NOMPLANTA_ORIGEN, _PLAN_ORIGEN, _PLAN_CODPLANTA_DESTINO, _PLAN_NOMPLANTA_DESTINO, _PLAN_DESTINO,
                                        _tipoFlete, _KilDespachados, _KilRecibidos, _fleteEmp, _fleteCon, _intermediacion, _margen,
                                        _factura, _fecFactura);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            //flete,planta,cliente
            if (_cfgTbl[0] == 0 && //planilla
                _cfgTbl[1] == 0 && //propietario
                _cfgTbl[2] == 0 && //ruta
                _cfgTbl[3] == 1 && //cliente
                _cfgTbl[4] == 1 && //planta
                _cfgTbl[5] == 1 && //flete
                _cfgTbl[6] == 0 && //anticipo
                _cfgTbl[7] == 1 //facturas
                )//todas las combinaciones
            {
                try
                {
                    _dtGlobal.Rows.Add(_OFIC_NOMBRE, _ORCA_NUMERO, _ORCA_FECCREA, _ORCA_ESTADO, _COND_CEDULA, _COND_NOMBRE, _VEHI_PLACA, _TRAI_PLACA, _PROD_NOMBRE,
                    _NEGO_NRONEGOCIO, _CLIE_CODIGO_NEGOCIO, _CLIE_NIT_NEGOCIO, _CLIE_NOMBRE_NEGOCIO, _CLIE_CODIGO_PAGA, _CLIE_NIT_PAGA, _CLIE_NOMBRE_PAGA,
                                        _PLAN_CODPLANTA_ORIGEN, _PLAN_NOMPLANTA_ORIGEN, _PLAN_ORIGEN, _PLAN_CODPLANTA_DESTINO, _PLAN_NOMPLANTA_DESTINO, _PLAN_DESTINO,
                                        _tipoFlete, _KilDespachados, _KilRecibidos, _fleteEmp, _fleteCon, _intermediacion, _margen,
                                        _factura, _fecFactura);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            //flete,planta,cliente,ruta
            if (_cfgTbl[0] == 0 && //planilla
                _cfgTbl[1] == 0 && //propietario
                _cfgTbl[2] == 1 && //ruta
                _cfgTbl[3] == 1 && //cliente
                _cfgTbl[4] == 1 && //planta
                _cfgTbl[5] == 1 && //flete
                _cfgTbl[6] == 0 && //anticipo
                _cfgTbl[7] == 1 //facturas
                )//todas las combinaciones
            {
                try
                {
                    _dtGlobal.Rows.Add(_OFIC_NOMBRE, _ORCA_NUMERO, _ORCA_FECCREA, _ORCA_ESTADO, _COND_CEDULA, _COND_NOMBRE, _VEHI_PLACA, _TRAI_PLACA, _PROD_NOMBRE,
                    _CIUD_ORIGEN, _CIUD_DESTINO,
                                        _NEGO_NRONEGOCIO, _CLIE_CODIGO_NEGOCIO, _CLIE_NIT_NEGOCIO, _CLIE_NOMBRE_NEGOCIO, _CLIE_CODIGO_PAGA, _CLIE_NIT_PAGA, _CLIE_NOMBRE_PAGA,
                                        _PLAN_CODPLANTA_ORIGEN, _PLAN_NOMPLANTA_ORIGEN, _PLAN_ORIGEN, _PLAN_CODPLANTA_DESTINO, _PLAN_NOMPLANTA_DESTINO, _PLAN_DESTINO,
                                        _tipoFlete, _KilDespachados, _KilRecibidos, _fleteEmp, _fleteCon, _intermediacion, _margen,
                                        _factura, _fecFactura);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            //flete,planta,cliente,ruta,propietario
            if (_cfgTbl[0] == 0 && //planilla
                _cfgTbl[1] == 1 && //propietario
                _cfgTbl[2] == 1 && //ruta
                _cfgTbl[3] == 1 && //cliente
                _cfgTbl[4] == 1 && //planta
                _cfgTbl[5] == 1 && //flete
                _cfgTbl[6] == 0 && //anticipo
                _cfgTbl[7] == 1 //facturas
                )//todas las combinaciones
            {
                try
                {
                    _dtGlobal.Rows.Add(_OFIC_NOMBRE, _ORCA_NUMERO, _ORCA_FECCREA, _ORCA_ESTADO, _COND_CEDULA, _COND_NOMBRE, _VEHI_PLACA, _TRAI_PLACA, _PROD_NOMBRE,
                    _PROP_CEDULA, _PROP_NOMBRE, _POSE_CEDULA, _POSE_NOMBRE,
                                        _CIUD_ORIGEN, _CIUD_DESTINO,
                                        _NEGO_NRONEGOCIO, _CLIE_CODIGO_NEGOCIO, _CLIE_NIT_NEGOCIO, _CLIE_NOMBRE_NEGOCIO, _CLIE_CODIGO_PAGA, _CLIE_NIT_PAGA, _CLIE_NOMBRE_PAGA,
                                        _PLAN_CODPLANTA_ORIGEN, _PLAN_NOMPLANTA_ORIGEN, _PLAN_ORIGEN, _PLAN_CODPLANTA_DESTINO, _PLAN_NOMPLANTA_DESTINO, _PLAN_DESTINO,
                                        _tipoFlete, _KilDespachados, _KilRecibidos, _fleteEmp, _fleteCon, _intermediacion, _margen,
                                        _factura, _fecFactura);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            //planta
            if (_cfgTbl[0] == 0 && //planilla
                _cfgTbl[1] == 0 && //propietario
                _cfgTbl[2] == 0 && //ruta
                _cfgTbl[3] == 0 && //cliente
                _cfgTbl[4] == 1 && //planta
                _cfgTbl[5] == 0 && //flete
                _cfgTbl[6] == 0 && //anticipo
                _cfgTbl[7] == 1 //facturas
                )//todas las combinaciones
            {
                try
                {
                    _dtGlobal.Rows.Add(_OFIC_NOMBRE, _ORCA_NUMERO, _ORCA_FECCREA, _ORCA_ESTADO, _COND_CEDULA, _COND_NOMBRE, _VEHI_PLACA, _TRAI_PLACA, _PROD_NOMBRE,
                    _PLAN_CODPLANTA_ORIGEN, _PLAN_NOMPLANTA_ORIGEN, _PLAN_ORIGEN, _PLAN_CODPLANTA_DESTINO, _PLAN_NOMPLANTA_DESTINO, _PLAN_DESTINO,
                    _factura, _fecFactura);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            //planta,cliente
            if (_cfgTbl[0] == 0 && //planilla
                _cfgTbl[1] == 0 && //propietario
                _cfgTbl[2] == 0 && //ruta
                _cfgTbl[3] == 1 && //cliente
                _cfgTbl[4] == 1 && //planta
                _cfgTbl[5] == 0 && //flete
                _cfgTbl[6] == 0 && //anticipo
                _cfgTbl[7] == 1 //facturas
                )//todas las combinaciones
            {
                try
                {
                    _dtGlobal.Rows.Add(_OFIC_NOMBRE, _ORCA_NUMERO, _ORCA_FECCREA, _ORCA_ESTADO, _COND_CEDULA, _COND_NOMBRE, _VEHI_PLACA, _TRAI_PLACA, _PROD_NOMBRE,
                    _NEGO_NRONEGOCIO, _CLIE_CODIGO_NEGOCIO, _CLIE_NIT_NEGOCIO, _CLIE_NOMBRE_NEGOCIO, _CLIE_CODIGO_PAGA, _CLIE_NIT_PAGA, _CLIE_NOMBRE_PAGA,
                                        _PLAN_CODPLANTA_ORIGEN, _PLAN_NOMPLANTA_ORIGEN, _PLAN_ORIGEN, _PLAN_CODPLANTA_DESTINO, _PLAN_NOMPLANTA_DESTINO, _PLAN_DESTINO,
                                        _factura, _fecFactura);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            //planta,cliente,ruta
            if (_cfgTbl[0] == 0 && //planilla
                _cfgTbl[1] == 0 && //propietario
                _cfgTbl[2] == 1 && //ruta
                _cfgTbl[3] == 1 && //cliente
                _cfgTbl[4] == 1 && //planta
                _cfgTbl[5] == 0 && //flete
                _cfgTbl[6] == 0 && //anticipo
                _cfgTbl[7] == 1 //facturas
                )//todas las combinaciones
            {
                try
                {
                    _dtGlobal.Rows.Add(_OFIC_NOMBRE, _ORCA_NUMERO, _ORCA_FECCREA, _ORCA_ESTADO, _COND_CEDULA, _COND_NOMBRE, _VEHI_PLACA, _TRAI_PLACA, _PROD_NOMBRE,
                    _CIUD_ORIGEN, _CIUD_DESTINO,
                                        _NEGO_NRONEGOCIO, _CLIE_CODIGO_NEGOCIO, _CLIE_NIT_NEGOCIO, _CLIE_NOMBRE_NEGOCIO, _CLIE_CODIGO_PAGA, _CLIE_NIT_PAGA, _CLIE_NOMBRE_PAGA,
                                        _PLAN_CODPLANTA_ORIGEN, _PLAN_NOMPLANTA_ORIGEN, _PLAN_ORIGEN, _PLAN_CODPLANTA_DESTINO, _PLAN_NOMPLANTA_DESTINO, _PLAN_DESTINO,
                                        _factura, _fecFactura);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            //planta,cliente,ruta,propietario
            if (_cfgTbl[0] == 0 && //planilla
                _cfgTbl[1] == 1 && //propietario
                _cfgTbl[2] == 1 && //ruta
                _cfgTbl[3] == 1 && //cliente
                _cfgTbl[4] == 1 && //planta
                _cfgTbl[5] == 0 && //flete
                _cfgTbl[6] == 0 && //anticipo
                _cfgTbl[7] == 1 //facturas
                )//todas las combinaciones
            {
                try
                {
                    _dtGlobal.Rows.Add(_OFIC_NOMBRE, _ORCA_NUMERO, _ORCA_FECCREA, _ORCA_ESTADO, _COND_CEDULA, _COND_NOMBRE, _VEHI_PLACA, _TRAI_PLACA, _PROD_NOMBRE,
                                        _VIAJ_NOPLANILLA, _VIAJ_FECVIAJE, _VIAJ_ESTADO, _VIAJ_FECANULA, _VIAJ_CUMLIQ, _VIAJ_CELULAR, _EMPL_NOMBRE,
                                        _PROP_CEDULA, _PROP_NOMBRE, _POSE_CEDULA, _POSE_NOMBRE,
                                        _CIUD_ORIGEN, _CIUD_DESTINO,
                                        _NEGO_NRONEGOCIO, _CLIE_CODIGO_NEGOCIO, _CLIE_NIT_NEGOCIO, _CLIE_NOMBRE_NEGOCIO, _CLIE_CODIGO_PAGA, _CLIE_NIT_PAGA, _CLIE_NOMBRE_PAGA,
                                        _PLAN_CODPLANTA_ORIGEN, _PLAN_NOMPLANTA_ORIGEN, _PLAN_ORIGEN, _PLAN_CODPLANTA_DESTINO, _PLAN_NOMPLANTA_DESTINO, _PLAN_DESTINO,
                                        _tipoFlete, _KilDespachados, _KilRecibidos, _fleteEmp, _fleteCon, _intermediacion, _margen,
                                        _chequenro, _comprobante, _valorCheque, _volaEfecnro, _volaEfecvalor, _volaCombunro, _volaCombuvalor,
                                        _factura, _fecFactura);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            //cliente
            if (_cfgTbl[0] == 0 && //planilla
                _cfgTbl[1] == 0 && //propietario
                _cfgTbl[2] == 0 && //ruta
                _cfgTbl[3] == 1 && //cliente
                _cfgTbl[4] == 0 && //planta
                _cfgTbl[5] == 0 && //flete
                _cfgTbl[6] == 0 && //anticipo
                _cfgTbl[7] == 1 //facturas
                )//todas las combinaciones
            {
                try
                {
                    _dtGlobal.Rows.Add(_OFIC_NOMBRE, _ORCA_NUMERO, _ORCA_FECCREA, _ORCA_ESTADO, _COND_CEDULA, _COND_NOMBRE, _VEHI_PLACA, _TRAI_PLACA, _PROD_NOMBRE,
                    _NEGO_NRONEGOCIO, _CLIE_CODIGO_NEGOCIO, _CLIE_NIT_NEGOCIO, _CLIE_NOMBRE_NEGOCIO, _CLIE_CODIGO_PAGA, _CLIE_NIT_PAGA, _CLIE_NOMBRE_PAGA,
                    _factura, _fecFactura);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            //cliente,ruta
            if (_cfgTbl[0] == 0 && //planilla
                _cfgTbl[1] == 0 && //propietario
                _cfgTbl[2] == 1 && //ruta
                _cfgTbl[3] == 1 && //cliente
                _cfgTbl[4] == 0 && //planta
                _cfgTbl[5] == 0 && //flete
                _cfgTbl[6] == 0 && //anticipo
                _cfgTbl[7] == 1 //facturas
                )//todas las combinaciones
            {
                try
                {
                    _dtGlobal.Rows.Add(_OFIC_NOMBRE, _ORCA_NUMERO, _ORCA_FECCREA, _ORCA_ESTADO, _COND_CEDULA, _COND_NOMBRE, _VEHI_PLACA, _TRAI_PLACA, _PROD_NOMBRE,
                    _CIUD_ORIGEN, _CIUD_DESTINO,
                                        _NEGO_NRONEGOCIO, _CLIE_CODIGO_NEGOCIO, _CLIE_NIT_NEGOCIO, _CLIE_NOMBRE_NEGOCIO, _CLIE_CODIGO_PAGA, _CLIE_NIT_PAGA, _CLIE_NOMBRE_PAGA,
                                        _factura, _fecFactura);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            //cliente,ruta,propietario
            if (_cfgTbl[0] == 0 && //planilla
                _cfgTbl[1] == 1 && //propietario
                _cfgTbl[2] == 1 && //ruta
                _cfgTbl[3] == 1 && //cliente
                _cfgTbl[4] == 0 && //planta
                _cfgTbl[5] == 0 && //flete
                _cfgTbl[6] == 0 && //anticipo
                _cfgTbl[7] == 1 //facturas
                )//todas las combinaciones
            {
                try
                {
                    _dtGlobal.Rows.Add(_OFIC_NOMBRE, _ORCA_NUMERO, _ORCA_FECCREA, _ORCA_ESTADO, _COND_CEDULA, _COND_NOMBRE, _VEHI_PLACA, _TRAI_PLACA, _PROD_NOMBRE,
                    _PROP_CEDULA, _PROP_NOMBRE, _POSE_CEDULA, _POSE_NOMBRE,
                                        _CIUD_ORIGEN, _CIUD_DESTINO,
                                        _NEGO_NRONEGOCIO, _CLIE_CODIGO_NEGOCIO, _CLIE_NIT_NEGOCIO, _CLIE_NOMBRE_NEGOCIO, _CLIE_CODIGO_PAGA, _CLIE_NIT_PAGA, _CLIE_NOMBRE_PAGA,
                                        _factura, _fecFactura);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            //ruta
            if (_cfgTbl[0] == 0 && //planilla
                _cfgTbl[1] == 0 && //propietario
                _cfgTbl[2] == 1 && //ruta
                _cfgTbl[3] == 0 && //cliente
                _cfgTbl[4] == 0 && //planta
                _cfgTbl[5] == 0 && //flete
                _cfgTbl[6] == 0 && //anticipo
                _cfgTbl[7] == 1 //facturas
                )//todas las combinaciones
            {
                try
                {
                    _dtGlobal.Rows.Add(_OFIC_NOMBRE, _ORCA_NUMERO, _ORCA_FECCREA, _ORCA_ESTADO, _COND_CEDULA, _COND_NOMBRE, _VEHI_PLACA, _TRAI_PLACA, _PROD_NOMBRE,
                            _CIUD_ORIGEN, _CIUD_DESTINO,
                            _factura, _fecFactura);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            //ruta,propietario
            if (_cfgTbl[0] == 0 && //planilla
                _cfgTbl[1] == 1 && //propietario
                _cfgTbl[2] == 1 && //ruta
                _cfgTbl[3] == 0 && //cliente
                _cfgTbl[4] == 0 && //planta
                _cfgTbl[5] == 0 && //flete
                _cfgTbl[6] == 0 && //anticipo
                _cfgTbl[7] == 1 //facturas
                )//todas las combinaciones
            {
                try
                {
                    _dtGlobal.Rows.Add(_OFIC_NOMBRE, _ORCA_NUMERO, _ORCA_FECCREA, _ORCA_ESTADO, _COND_CEDULA, _COND_NOMBRE, _VEHI_PLACA, _TRAI_PLACA, _PROD_NOMBRE,
                    _PROP_CEDULA, _PROP_NOMBRE, _POSE_CEDULA, _POSE_NOMBRE,
                                        _CIUD_ORIGEN, _CIUD_DESTINO,
                                        _factura, _fecFactura);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            //propietario
            if (_cfgTbl[0] == 0 && //planilla
                _cfgTbl[1] == 1 && //propietario
                _cfgTbl[2] == 0 && //ruta
                _cfgTbl[3] == 0 && //cliente
                _cfgTbl[4] == 0 && //planta
                _cfgTbl[5] == 0 && //flete
                _cfgTbl[6] == 0 && //anticipo
                _cfgTbl[7] == 1 //facturas
                )//todas las combinaciones
            {
                try
                {
                    _dtGlobal.Rows.Add(_OFIC_NOMBRE, _ORCA_NUMERO, _ORCA_FECCREA, _ORCA_ESTADO, _COND_CEDULA, _COND_NOMBRE, _VEHI_PLACA, _TRAI_PLACA, _PROD_NOMBRE,
                    _PROP_CEDULA, _PROP_NOMBRE, _POSE_CEDULA, _POSE_NOMBRE,
                    _factura, _fecFactura);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

            //planilla,propietario
            if (_cfgTbl[0] == 1 && //planilla
                _cfgTbl[1] == 1 && //propietario
                _cfgTbl[2] == 0 && //ruta
                _cfgTbl[3] == 0 && //cliente
                _cfgTbl[4] == 0 && //planta
                _cfgTbl[5] == 0 && //flete
                _cfgTbl[6] == 0 && //anticipo
                _cfgTbl[7] == 1 //facturas
                )//todas las combinaciones
            {
                try
                {
                    _dtGlobal.Rows.Add(_OFIC_NOMBRE, _ORCA_NUMERO, _ORCA_FECCREA, _ORCA_ESTADO, _COND_CEDULA, _COND_NOMBRE, _VEHI_PLACA, _TRAI_PLACA, _PROD_NOMBRE,
                                        _VIAJ_NOPLANILLA, _VIAJ_FECVIAJE, _VIAJ_ESTADO, _VIAJ_FECANULA, _VIAJ_CUMLIQ, _VIAJ_CELULAR, _EMPL_NOMBRE,
                                        _PROP_CEDULA, _PROP_NOMBRE, _POSE_CEDULA, _POSE_NOMBRE,
                                        _factura, _fecFactura);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            //planilla,ruta
            if (_cfgTbl[0] == 1 && //planilla
                _cfgTbl[1] == 0 && //propietario
                _cfgTbl[2] == 1 && //ruta
                _cfgTbl[3] == 0 && //cliente
                _cfgTbl[4] == 0 && //planta
                _cfgTbl[5] == 0 && //flete
                _cfgTbl[6] == 0 && //anticipo
                _cfgTbl[7] == 1 //facturas
                )//todas las combinaciones
            {
                try
                {
                    _dtGlobal.Rows.Add(_OFIC_NOMBRE, _ORCA_NUMERO, _ORCA_FECCREA, _ORCA_ESTADO, _COND_CEDULA, _COND_NOMBRE, _VEHI_PLACA, _TRAI_PLACA, _PROD_NOMBRE,
                                        _VIAJ_NOPLANILLA, _VIAJ_FECVIAJE, _VIAJ_ESTADO, _VIAJ_FECANULA, _VIAJ_CUMLIQ, _VIAJ_CELULAR, _EMPL_NOMBRE,
                                        _CIUD_ORIGEN, _CIUD_DESTINO,
                                        _factura, _fecFactura);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

            //planilla,cliente
            if (_cfgTbl[0] == 1 && //planilla
                _cfgTbl[1] == 0 && //propietario
                _cfgTbl[2] == 0 && //ruta
                _cfgTbl[3] == 1 && //cliente
                _cfgTbl[4] == 0 && //planta
                _cfgTbl[5] == 0 && //flete
                _cfgTbl[6] == 0 && //anticipo
                _cfgTbl[7] == 1 //facturas
                )//todas las combinaciones
            {
                try
                {
                    _dtGlobal.Rows.Add(_OFIC_NOMBRE, _ORCA_NUMERO, _ORCA_FECCREA, _ORCA_ESTADO, _COND_CEDULA, _COND_NOMBRE, _VEHI_PLACA, _TRAI_PLACA, _PROD_NOMBRE,
                                        _VIAJ_NOPLANILLA, _VIAJ_FECVIAJE, _VIAJ_ESTADO, _VIAJ_FECANULA, _VIAJ_CUMLIQ, _VIAJ_CELULAR, _EMPL_NOMBRE,
                                        _NEGO_NRONEGOCIO, _CLIE_CODIGO_NEGOCIO, _CLIE_NIT_NEGOCIO, _CLIE_NOMBRE_NEGOCIO, _CLIE_CODIGO_PAGA, _CLIE_NIT_PAGA, _CLIE_NOMBRE_PAGA,
                                        _factura, _fecFactura);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            //planilla,planta
            if (_cfgTbl[0] == 1 && //planilla
                _cfgTbl[1] == 0 && //propietario
                _cfgTbl[2] == 0 && //ruta
                _cfgTbl[3] == 0 && //cliente
                _cfgTbl[4] == 1 && //planta
                _cfgTbl[5] == 0 && //flete
                _cfgTbl[6] == 0 && //anticipo
                _cfgTbl[7] == 1 //facturas
                )//todas las combinaciones
            {
                try
                {
                    _dtGlobal.Rows.Add(_OFIC_NOMBRE, _ORCA_NUMERO, _ORCA_FECCREA, _ORCA_ESTADO, _COND_CEDULA, _COND_NOMBRE, _VEHI_PLACA, _TRAI_PLACA, _PROD_NOMBRE,
                                        _VIAJ_NOPLANILLA, _VIAJ_FECVIAJE, _VIAJ_ESTADO, _VIAJ_FECANULA, _VIAJ_CUMLIQ, _VIAJ_CELULAR, _EMPL_NOMBRE,
                                        _PLAN_CODPLANTA_ORIGEN, _PLAN_NOMPLANTA_ORIGEN, _PLAN_ORIGEN, _PLAN_CODPLANTA_DESTINO, _PLAN_NOMPLANTA_DESTINO, _PLAN_DESTINO,
                                        _factura, _fecFactura);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            //planilla,flete
            if (_cfgTbl[0] == 1 && //planilla
                _cfgTbl[1] == 0 && //propietario
                _cfgTbl[2] == 0 && //ruta
                _cfgTbl[3] == 0 && //cliente
                _cfgTbl[4] == 0 && //planta
                _cfgTbl[5] == 1 && //flete
                _cfgTbl[6] == 0 && //anticipo
                _cfgTbl[7] == 1 //facturas
                )//todas las combinaciones
            {
                try
                {
                    _dtGlobal.Rows.Add(_OFIC_NOMBRE, _ORCA_NUMERO, _ORCA_FECCREA, _ORCA_ESTADO, _COND_CEDULA, _COND_NOMBRE, _VEHI_PLACA, _TRAI_PLACA, _PROD_NOMBRE,
                                        _VIAJ_NOPLANILLA, _VIAJ_FECVIAJE, _VIAJ_ESTADO, _VIAJ_FECANULA, _VIAJ_CUMLIQ, _VIAJ_CELULAR, _EMPL_NOMBRE,
                                        _tipoFlete, _KilDespachados, _KilRecibidos, _fleteEmp, _fleteCon, _intermediacion, _margen,
                                        _factura, _fecFactura);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            //planilla,anticipo
            if (_cfgTbl[0] == 1 && //planilla
                _cfgTbl[1] == 0 && //propietario
                _cfgTbl[2] == 0 && //ruta
                _cfgTbl[3] == 0 && //cliente
                _cfgTbl[4] == 0 && //planta
                _cfgTbl[5] == 0 && //flete
                _cfgTbl[6] == 1 && //anticipo
                _cfgTbl[7] == 1 //facturas
                )//todas las combinaciones
            {
                try
                {
                    _dtGlobal.Rows.Add(_OFIC_NOMBRE, _ORCA_NUMERO, _ORCA_FECCREA, _ORCA_ESTADO, _COND_CEDULA, _COND_NOMBRE, _VEHI_PLACA, _TRAI_PLACA, _PROD_NOMBRE,
                                        _VIAJ_NOPLANILLA, _VIAJ_FECVIAJE, _VIAJ_ESTADO, _VIAJ_FECANULA, _VIAJ_CUMLIQ, _VIAJ_CELULAR, _EMPL_NOMBRE,
                                        _chequenro, _comprobante, _valorCheque, _volaEfecnro, _volaEfecvalor, _volaCombunro, _volaCombuvalor,
                                        _factura, _fecFactura);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

            //planilla,flete,anticipo
            if (_cfgTbl[0] == 1 && //planilla
                _cfgTbl[1] == 0 && //propietario
                _cfgTbl[2] == 0 && //ruta
                _cfgTbl[3] == 0 && //cliente
                _cfgTbl[4] == 0 && //planta
                _cfgTbl[5] == 1 && //flete
                _cfgTbl[6] == 1 && //anticipo
                _cfgTbl[7] == 1 //facturas
                )//todas las combinaciones
            {
                try
                {
                    _dtGlobal.Rows.Add(_OFIC_NOMBRE, _ORCA_NUMERO, _ORCA_FECCREA, _ORCA_ESTADO, _COND_CEDULA, _COND_NOMBRE, _VEHI_PLACA, _TRAI_PLACA, _PROD_NOMBRE,
                                        _VIAJ_NOPLANILLA, _VIAJ_FECVIAJE, _VIAJ_ESTADO, _VIAJ_FECANULA, _VIAJ_CUMLIQ, _VIAJ_CELULAR, _EMPL_NOMBRE,
                                        _tipoFlete, _KilDespachados, _KilRecibidos, _fleteEmp, _fleteCon, _intermediacion, _margen,
                                        _chequenro, _comprobante, _valorCheque, _volaEfecnro, _volaEfecvalor, _volaCombunro, _volaCombuvalor,
                                        _factura, _fecFactura);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            //planilla,ruta,flete,anticipo
            if (_cfgTbl[0] == 1 && //planilla
                _cfgTbl[1] == 0 && //propietario
                _cfgTbl[2] == 1 && //ruta
                _cfgTbl[3] == 0 && //cliente
                _cfgTbl[4] == 0 && //planta
                _cfgTbl[5] == 1 && //flete
                _cfgTbl[6] == 1 && //anticipo
                _cfgTbl[7] == 1 //facturas
                )//todas las combinaciones
            {
                try
                {
                    _dtGlobal.Rows.Add(_OFIC_NOMBRE, _ORCA_NUMERO, _ORCA_FECCREA, _ORCA_ESTADO, _COND_CEDULA, _COND_NOMBRE, _VEHI_PLACA, _TRAI_PLACA, _PROD_NOMBRE,
                                        _VIAJ_NOPLANILLA, _VIAJ_FECVIAJE, _VIAJ_ESTADO, _VIAJ_FECANULA, _VIAJ_CUMLIQ, _VIAJ_CELULAR, _EMPL_NOMBRE,
                                        _CIUD_ORIGEN, _CIUD_DESTINO,
                                        _tipoFlete, _KilDespachados, _KilRecibidos, _fleteEmp, _fleteCon, _intermediacion, _margen,
                                        _chequenro, _comprobante, _valorCheque, _volaEfecnro, _volaEfecvalor, _volaCombunro, _volaCombuvalor,
                                        _factura, _fecFactura);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            //planilla,ruta,anticipo
            if (_cfgTbl[0] == 1 && //planilla
                _cfgTbl[1] == 0 && //propietario
                _cfgTbl[2] == 1 && //ruta
                _cfgTbl[3] == 0 && //cliente
                _cfgTbl[4] == 0 && //planta
                _cfgTbl[5] == 0 && //flete
                _cfgTbl[6] == 1 && //anticipo
                _cfgTbl[7] == 1 //facturas
                )//todas las combinaciones
            {
                try
                {
                    _dtGlobal.Rows.Add(_OFIC_NOMBRE, _ORCA_NUMERO, _ORCA_FECCREA, _ORCA_ESTADO, _COND_CEDULA, _COND_NOMBRE, _VEHI_PLACA, _TRAI_PLACA, _PROD_NOMBRE,
                                        _VIAJ_NOPLANILLA, _VIAJ_FECVIAJE, _VIAJ_ESTADO, _VIAJ_FECANULA, _VIAJ_CUMLIQ, _VIAJ_CELULAR, _EMPL_NOMBRE,
                                        _CIUD_ORIGEN, _CIUD_DESTINO,
                                        _chequenro, _comprobante, _valorCheque, _volaEfecnro, _volaEfecvalor, _volaCombunro, _volaCombuvalor,
                                        _factura, _fecFactura);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

            //planilla,ruta,flete
            if (_cfgTbl[0] == 1 && //planilla
                _cfgTbl[1] == 0 && //propietario
                _cfgTbl[2] == 1 && //ruta
                _cfgTbl[3] == 0 && //cliente
                _cfgTbl[4] == 0 && //planta
                _cfgTbl[5] == 1 && //flete
                _cfgTbl[6] == 0 && //anticipo
                _cfgTbl[7] == 1 //facturas
                )//todas las combinaciones
            {
                try
                {
                    _dtGlobal.Rows.Add(_OFIC_NOMBRE, _ORCA_NUMERO, _ORCA_FECCREA, _ORCA_ESTADO, _COND_CEDULA, _COND_NOMBRE, _VEHI_PLACA, _TRAI_PLACA, _PROD_NOMBRE,
                                        _VIAJ_NOPLANILLA, _VIAJ_FECVIAJE, _VIAJ_ESTADO, _VIAJ_FECANULA, _VIAJ_CUMLIQ, _VIAJ_CELULAR, _EMPL_NOMBRE,
                                        _CIUD_ORIGEN, _CIUD_DESTINO, _tipoFlete, _KilDespachados, _KilRecibidos, _fleteEmp, _fleteCon, _intermediacion, _margen,
                                        _factura, _fecFactura);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

            #endregion fin bloque pruebas

            #endregion fin de la definicion del bloque carga filas
        }

        private void createTables()
        {
            _dtGlobal = new DataTable("milenio");

            _dtOsp = new DataTable("log_plan_adminsat");
            _dtBavaria = new DataTable("Log_reporte_bavaria");
            _dtDeseguro = new DataTable("log_reporte_deseguro");
            _dtMinisterio = new DataTable("log_reporte_ministerio");
            _dtFacturas = new DataTable("log_reporte_dian");
            createFormatdtGlobal();
            createFormatdtOsp();
            createFormatdtBavaria();
            createFormatdtDeseguro();
            createFormatdtMinisterio();
            createFormatdtFacturas();
        }
        private void createFormatdtFacturas()
        {
            _dtFacturas.Columns.Add("LODI_SECUENCIA_NB", typeof(double));
            _dtFacturas.Columns.Add("LODI_OFICINA_NB", typeof(int));
            _dtFacturas.Columns.Add("LODI_TRANSACCION_NB", typeof(int));
            _dtFacturas.Columns.Add("LODI_LLAVE_V2", typeof(string));
            _dtFacturas.Columns.Add("LODI_FECREGISTRO_DT", typeof(DateTime));
            _dtFacturas.Columns.Add("LODI_ESTADO_V2", typeof(string));
            _dtFacturas.Columns.Add("LODI_CAMPO1_NB", typeof(double));
            _dtFacturas.Columns.Add("LODI_CAMPO2_DT", typeof(string));
            _dtFacturas.Columns.Add("LODI_CAMPO3_V2", typeof(DateTime));
            _dtFacturas.Columns.Add("LODI_ESTADODIAN_V2", typeof(string));
        }

        private void createFormatdtMinisterio()
        {
            _dtMinisterio.Columns.Add("LRMI_SECUENCIA_NB", typeof(double));
            _dtMinisterio.Columns.Add("LRMI_OFICINA_NB", typeof(int));
            _dtMinisterio.Columns.Add("LRMI_TRANSACCION_NB", typeof(int));
            _dtMinisterio.Columns.Add("LRMI_LLAVE_V2", typeof(string));
            _dtMinisterio.Columns.Add("LRMI_FECREGISTRO_DT", typeof(DateTime));
            _dtMinisterio.Columns.Add("LRMI_ESTADO_V2", typeof(string));
            _dtMinisterio.Columns.Add("LRMI_CAMPO1_NB", typeof(double));
            _dtMinisterio.Columns.Add("LRMI_CAMPO2_DT", typeof(string));
            _dtMinisterio.Columns.Add("LRMI_CAMPO3_V2", typeof(DateTime));
        }

        private void createFormatdtDeseguro()
        {
            _dtDeseguro.Columns.Add("REDE_SECUENCIA_NB", typeof(double));
            _dtDeseguro.Columns.Add("REDE_OFICINA_NB", typeof(int));
            _dtDeseguro.Columns.Add("REDE_TRANSACCION_NB", typeof(int));
            _dtDeseguro.Columns.Add("REDE_LLAVE_V2", typeof(string));
            _dtDeseguro.Columns.Add("REDE_FECHA_DT", typeof(DateTime));
            _dtDeseguro.Columns.Add("REDE_ESTADO_V2", typeof(string));
            _dtDeseguro.Columns.Add("REDE_CAMPO1_NB", typeof(double));
            _dtDeseguro.Columns.Add("REDE_CAMPO2_DT", typeof(string));
            _dtDeseguro.Columns.Add("REDE_CAMPO3_V2", typeof(DateTime));
        }

        private void createFormatdtBavaria()
        {
            _dtBavaria.Columns.Add("REBA_SECUENCIA_NB", typeof(double));
            _dtBavaria.Columns.Add("REBA_OFICINA_NB", typeof(int));
            _dtBavaria.Columns.Add("REBA_TRANSACCION_NB", typeof(int));
            _dtBavaria.Columns.Add("REBA_LLAVE_V2", typeof(string));
            _dtBavaria.Columns.Add("REBA_FECHA_DT", typeof(DateTime));
            _dtBavaria.Columns.Add("REBA_ESTADO_V2", typeof(string));
            _dtBavaria.Columns.Add("REDE_CAMPO1_NB", typeof(double));
            _dtBavaria.Columns.Add("REBA_CAMPO2_DT", typeof(string));
            _dtBavaria.Columns.Add("REBA_CAMPO3_V2", typeof(DateTime));
        }

        private void createFormatdtOsp()
        {
            _dtOsp.Columns.Add("LPAD_SECUENCIA_NB", typeof(double));
            _dtOsp.Columns.Add("LPAD_OFICINA_NB", typeof(int));
            _dtOsp.Columns.Add("LPAD_TRANSACCION_NB", typeof(int));
            _dtOsp.Columns.Add("LPAD_LLAVE_V2", typeof(string));
            _dtOsp.Columns.Add("LPAD_FECHA_DT", typeof(DateTime));
            _dtOsp.Columns.Add("LPAD_ESTADO_V2", typeof(string));
            _dtOsp.Columns.Add("LPAD_IDADMINSAT_V2", typeof(string));
            _dtOsp.Columns.Add("LPAD_FECENVIO_DT", typeof(DateTime));
            _dtOsp.Columns.Add("LPAD_RESPUESTA_V2", typeof(string));

        }

        private void createFormatdtGlobal()
        {
            int x = -1;
            int y = -1;
            //_configuraTabla = new int[36,2];
            _cfgTbl = new int[8];

            _dtGlobal.Columns.Add("oficina", typeof(string));
            _dtGlobal.Columns.Add("orden", typeof(string));
            _dtGlobal.Columns.Add("fecOrden", typeof(DateTime));
            _dtGlobal.Columns.Add("estOrden", typeof(string));
            _dtGlobal.Columns.Add("idConductor", typeof(double));
            _dtGlobal.Columns.Add("conductor", typeof(string));
            _dtGlobal.Columns.Add("vehiculo", typeof(string));
            _dtGlobal.Columns.Add("trailer", typeof(string));
            _dtGlobal.Columns.Add("producto", typeof(string));

            if (cbxInfoPlanilla.Checked)
            {
                _dtGlobal.Columns.Add("planilla", typeof(string));
                _dtGlobal.Columns.Add("fecPlanilla", typeof(DateTime));
                _dtGlobal.Columns.Add("estPlanilla", typeof(string));
                _dtGlobal.Columns.Add("fecAnula", typeof(DateTime));
                _dtGlobal.Columns.Add("cumliq", typeof(string));
                _dtGlobal.Columns.Add("celular", typeof(string));
                _dtGlobal.Columns.Add("funcionario", typeof(string));
                x++;
                _cfgTbl[x] = 1;
            }
            else
            {
                x++;
                _cfgTbl[x] = 0;
            }

            if (cbxInfoPropietario.Checked)
            {
                _dtGlobal.Columns.Add("idPropietario", typeof(double));
                _dtGlobal.Columns.Add("propietario", typeof(string));
                _dtGlobal.Columns.Add("idPoseedor", typeof(double));
                _dtGlobal.Columns.Add("poseedor", typeof(string));
                x++;
                _cfgTbl[x] = 1;
            }
            else
            {
                x++;
                _cfgTbl[x] = 0;
            }

            if (cbxInfoRuta.Checked)
            {
                _dtGlobal.Columns.Add("Origen", typeof(string));
                _dtGlobal.Columns.Add("destino", typeof(string));
                x++;
                _cfgTbl[x] = 1;
            }
            else
            {
                x++;
                _cfgTbl[x] = 0;
            }

            if (cbxInfoClienteNegocio.Checked)
            {
                _dtGlobal.Columns.Add("idNegocio", typeof(int));
                _dtGlobal.Columns.Add("codClienteNegocio", typeof(int));
                _dtGlobal.Columns.Add("idClienteNegocio", typeof(int));
                _dtGlobal.Columns.Add("clienteNegocio", typeof(string));
                _dtGlobal.Columns.Add("codClientePaga", typeof(int));
                _dtGlobal.Columns.Add("idClientePaga", typeof(int));
                _dtGlobal.Columns.Add("clientePaga", typeof(string));
                x++;
                _cfgTbl[x] = 1;
            }
            else
            {
                x++;
                _cfgTbl[x] = 0;
            }

            if (cbxInfoPlantas.Checked)
            {
                _dtGlobal.Columns.Add("idPlaOrigen", typeof(int));
                _dtGlobal.Columns.Add("PlantaOrigen", typeof(string));
                _dtGlobal.Columns.Add("PLAN_ORIGEN", typeof(string));
                _dtGlobal.Columns.Add("idPlaDestino", typeof(int));
                _dtGlobal.Columns.Add("PlantaDestino", typeof(string));
                _dtGlobal.Columns.Add("PLAN_DESTINO", typeof(string));
                x++;
                _cfgTbl[x] = 1;
            }
            else
            {
                x++;
                _cfgTbl[x] = 0;
            }

            if (cbxInfoFletes.Checked)
            {
                _dtGlobal.Columns.Add("tipoFlete", typeof(string));
                _dtGlobal.Columns.Add("KilDespachados", typeof(int));
                _dtGlobal.Columns.Add("KilRecibidos", typeof(int));
                _dtGlobal.Columns.Add("fleteEmp", typeof(double));
                _dtGlobal.Columns.Add("fleteCon", typeof(double));
                _dtGlobal.Columns.Add("intermediacion", typeof(string));
                _dtGlobal.Columns.Add("margen", typeof(double));
                x++;
                _cfgTbl[x] = 1;
            }
            else
            {
                x++;
                _cfgTbl[x] = 0;
            }

            if (cbxInfoAnticipos.Checked)
            {
                _dtGlobal.Columns.Add("cheque", typeof(string));
                _dtGlobal.Columns.Add("comprobante", typeof(string));
                _dtGlobal.Columns.Add("valorCheque", typeof(double));

                _dtGlobal.Columns.Add("vEfectivo", typeof(string));
                _dtGlobal.Columns.Add("vEvalor", typeof(double));

                _dtGlobal.Columns.Add("vCombustible", typeof(string));
                _dtGlobal.Columns.Add("vCvalor", typeof(double));
                x++;
                _cfgTbl[x] = 1;
            }
            else
            {
                x++;
                _cfgTbl[x] = 0;
            }

            if (cbxInfoFactura.Checked)
            {
                _dtGlobal.Columns.Add("factura", typeof(string));
                _dtGlobal.Columns.Add("fecFactura", typeof(DateTime));
                x++;
                _cfgTbl[x] = 1;
            }
            else
            {
                x++;
                _cfgTbl[x] = 0;
            }


        }

        private void ReporteDespachos_Load(object sender, EventArgs e)
        {
            cargarComboBoxOficinas();
            inicializarvariables();
        }
        private void cargarComboBoxOficinas()
        {
            cbxOficina.DisplayMember = "OFIC_NOMBRE";
            cbxOficina.ValueMember = "OFIC_CODOFIC";
            cbxOficina.DataSource = ObtenerOficinas();
        }

        private DataTable ObtenerOficinas()
        {
            DataTable dtOficinas = new DataTable("Oficinas");
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[0] { };
            _vParametros = new object[0] { };
            Factory data = new Factory(Usuario, Password, Ambiente);
            try
            {
                dtOficinas = data.getTable("oficinas", _nParametros, _vParametros);
            }
            catch (Exception ex)
            {
                ManejoError(ex, "var dtLogReporteDian = data.getTable(\"getLogReporteDian\", _nParametros, _vParametros);");
            }
            return dtOficinas;
        }

        private void inicializarvariables()
        {
            _dtFecIni = DateTime.Now;
            _dtFecFin = DateTime.Now;

            #region Definicion de las columnas de la tabla de salida

            _OFIC_CODOFIC = 0;
            _OFIC_NOMBRE = string.Empty;
            _ORCA_NUMERO = string.Empty;
            _ORCA_FECCREA = DateTime.Now;
            _ORCA_ESTADO = string.Empty;
            _VIAJ_NOPLANILLA = string.Empty;
            _VIAJ_FECVIAJE = DateTime.Now;
            _VIAJ_ESTADO = string.Empty;
            _VEHI_PLACA = string.Empty;
            _TRAI_PLACA = string.Empty;
            _COND_CEDULA = 0;
            _COND_NOMBRE = string.Empty;
            //_COND_APELLIDO = string.Empty;
            _VIAJ_CELULAR = string.Empty;
            _PROP_CEDULA = 0;
            _PROP_NOMBRE = string.Empty;
            //_PROP_APELLIDO = string.Empty;
            _POSE_CEDULA = 0;
            _POSE_NOMBRE = string.Empty;
            //_POSE_APELLIDO = string.Empty;
            _PLAN_CODPLANTA_ORIGEN = 0;
            _PLAN_NOMPLANTA_ORIGEN = string.Empty;
            _PLAN_ORIGEN = string.Empty;
            _CIUD_ORIGEN = string.Empty;
            _PLAN_CODPLANTA_DESTINO = 0;
            _PLAN_NOMPLANTA_DESTINO = string.Empty;
            _PLAN_DESTINO = string.Empty;
            _CIUD_DESTINO = string.Empty;
            _NEGO_NRONEGOCIO = 0;
            _CLIE_CODIGO_NEGOCIO = 0;
            _CLIE_NIT_NEGOCIO = 0;
            _CLIE_NOMBRE_NEGOCIO = string.Empty;
            _PROD_NOMBRE = string.Empty;

            _tipoFlete = string.Empty;
            _fleteEmp = 0;
            _fleteCon = 0;
            _KilDespachados = 0;
            _KilRecibidos = 0;



            _tipoAnticipo = string.Empty;
            _chequenro = string.Empty;
            _comprobante = string.Empty;
            _valorCheque = 0;
            _volaEfecnro = string.Empty;
            _volaEfecvalor = 0;
            _volaCombunro = string.Empty;
            _volaCombuvalor = 0;

            _factura = string.Empty;
            _fecFactura = DateTime.Now;

            #endregion fin de la Definicion de las columnas de la tabla de salida

        }

        private class SecurityPrvt
        {
            public SecurityPrvt()
            {

            }
            public string Decode(string texto)
            {
                string codigo = string.Empty;
                switch (texto)
                {
                    case "usuario":
                        {
                            codigo = Base64Decode("SOPORTE");
                            break;
                        }
                    case "password":
                        {
                            codigo = Base64Decode("SOPORTE");
                            break;
                        }
                    case "usuEmail":
                        {
                            codigo = Base64Decode("robotcorreo");
                            break;
                        }
                    case "passEmail":
                        {
                            codigo = Base64Decode("Tys860504882");
                            break;
                        }
                    default:
                        {
                            codigo = Base64Decode(texto);
                            break;
                        }
                }
                return codigo;
            }

            private string Base64Decode(string base64EncodedData)
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(base64EncodedData);
                //string encodedText = Convert.ToBase64String(plainTextBytes);
                return Convert.ToBase64String(plainTextBytes);
                //return System.Text.Encoding.UTF8.GetString(plainTextBytes);
            }

        }

        private void dtpFecIni_ValueChanged(object sender, EventArgs e)
        {
            _dtFecIni = dtpFecIni.Value;
        }

        private void dtpFecFin_ValueChanged(object sender, EventArgs e)
        {
            _dtFecFin = dtpFecFin.Value;
        }

        private void cbxOficina_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxOficina.Text.Length > 6)
                {
                    _codOfic = int.Parse(cbxOficina.SelectedValue.ToString());
                }
            }
            catch (Exception ex)
            {
            }

        }
    }
}
