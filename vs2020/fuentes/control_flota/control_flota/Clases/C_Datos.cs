using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
//using Oracle.DataAccess.Client;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace control_flota.Clases
{
    class C_Datos : Interfaces.I_Datos
    {
        private OracleConnection _Connection;
        private OracleCommand _Command;
        private OracleDataAdapter _DataAdapter;
        private DataSet _dataset;
        private string _cadena;
        private string _usuario;
        private string _password;
        private string _excepciones_oracle;
        public C_Datos(string usuario, string password, string cadena)
        {
            _usuario = usuario;
            _password = password;
            _cadena = cadena;
            _Connection = new OracleConnection(_cadena);            
        }

        #region Definicion de la region para el bloque de transacciones

        public DataSet generico(string select, DateTimePicker fecini, DateTimePicker fecfin)
        {
            _dataset = new DataSet();
            _Command = new OracleCommand(select, _Connection);
            _Command.CommandType = CommandType.StoredProcedure;
            OracleParameter p_refcursor = new OracleParameter();
            p_refcursor.OracleDbType = OracleDbType.RefCursor;
            p_refcursor.Direction = ParameterDirection.ReturnValue;
            _Command.Parameters.Add(p_refcursor);

            OracleParameter p_fecini = new OracleParameter(":fecini", OracleDbType.Date, ParameterDirection.Input);
            p_fecini.Value = fecini.Value;
            _Command.Parameters.Add(p_fecini);

            OracleParameter p_fecfin = new OracleParameter(":fecfin", OracleDbType.Date, ParameterDirection.Input);
            p_fecfin.Value = fecfin.Value;
            _Command.Parameters.Add(p_fecfin);

            _DataAdapter = new OracleDataAdapter(_Command);

            try
            {
                _DataAdapter.Fill(_dataset, "CONSULTA");
            }
            catch (OracleException ora_exception)
            {
                _excepciones_oracle = ora_exception.Message;
                System.Windows.Forms.MessageBox.Show(_excepciones_oracle, "PROCEDIMIENTOS DE LA BASE DE DATOS", MessageBoxButtons.OK);
            }
            return _dataset;
        }


        public DataSet generico(string select)
        {
            _dataset = new DataSet();
            _Command = new OracleCommand(select, _Connection);
            _Command.CommandType = CommandType.StoredProcedure;
            OracleParameter p_refcursor = new OracleParameter();
            p_refcursor.OracleDbType = OracleDbType.RefCursor;
            p_refcursor.Direction = ParameterDirection.ReturnValue;
            _Command.Parameters.Add(p_refcursor);
            _DataAdapter = new OracleDataAdapter(_Command);
            try
            {
                _DataAdapter.Fill(_dataset, "CONSULTA");//Revisado 10/02/2014
            }
            catch (OracleException ora_exception)
            {
                _excepciones_oracle = ora_exception.Message;
                System.Windows.Forms.MessageBox.Show(_excepciones_oracle, "PROCEDIMIENTOS DE LA BASE DE DATOS", MessageBoxButtons.OK);
            }
            return _dataset;
        }

        public DataSet generico(string select, string valor, string tipo)
        {
            _dataset = new DataSet();
            _Command = new OracleCommand(select, _Connection);
            _Command.CommandType = CommandType.StoredProcedure;
            OracleParameter p_refcursor = new OracleParameter();
            p_refcursor.OracleDbType = OracleDbType.RefCursor;
            p_refcursor.Direction = ParameterDirection.ReturnValue;
            _Command.Parameters.Add(p_refcursor);
            OracleParameter p_valor = new OracleParameter(":pconductor", OracleDbType.Varchar2);
            p_valor.Value = valor;
            _Command.Parameters.Add(p_valor);
            _DataAdapter = new OracleDataAdapter(_Command);
            try
            {
                _DataAdapter.Fill(_dataset, "CONSULTA");
            }
            catch (OracleException ora_exception)
            {
                _excepciones_oracle = ora_exception.Message;
                System.Windows.Forms.MessageBox.Show(_excepciones_oracle, "PROCEDIMIENTOS DE LA BASE DE DATOS", MessageBoxButtons.OK);
            }
            return _dataset;
        }


        public DataSet generico(string select, string conductor)
        {
            _dataset = new DataSet();
            _Command = new OracleCommand(select, _Connection);
            _Command.CommandType = CommandType.StoredProcedure;
            OracleParameter p_refcursor = new OracleParameter();
            p_refcursor.OracleDbType = OracleDbType.RefCursor;
            p_refcursor.Direction = ParameterDirection.ReturnValue;
            _Command.Parameters.Add(p_refcursor);
            OracleParameter p_conductor = new OracleParameter(":pconductor", OracleDbType.Int32, 13);
            p_conductor.Value = double.Parse(conductor.ToString());
            _Command.Parameters.Add(p_conductor);
            _DataAdapter = new OracleDataAdapter(_Command);
            try
            {
                _DataAdapter.Fill(_dataset, "CONSULTA");//Revisado 10/02/2014
            }
            catch (OracleException ora_exception)
            {
                _excepciones_oracle = ora_exception.Message;
                System.Windows.Forms.MessageBox.Show(_excepciones_oracle, "PROCEDIMIENTOS DE LA BASE DE DATOS", MessageBoxButtons.OK);
            }
            return _dataset;
        }

        public void registroIngreso(string select, string conductor, string vehiculo, string trailers)
        {
            _Command = new OracleCommand(select, _Connection);
            _Command.CommandType = CommandType.StoredProcedure;

            #region Definicion de los parametros del comando

            OracleParameter PCONDUCTOR = new OracleParameter(":PCONDUCTOR", OracleDbType.Long, 13);
            PCONDUCTOR.Value = double.Parse(conductor.ToString());
            _Command.Parameters.Add(PCONDUCTOR);

            OracleParameter PVEHICULO = new OracleParameter(":PVEHICULO", OracleDbType.Varchar2, 6);
            PVEHICULO.Value = vehiculo;
            _Command.Parameters.Add(PVEHICULO);

            OracleParameter PTRAILER = new OracleParameter(":PTRAILER", OracleDbType.Varchar2, 6);
            PTRAILER.Value = trailers;
            _Command.Parameters.Add(PTRAILER);

            OracleParameter PESTADO = new OracleParameter(":PESTADO", OracleDbType.Varchar2, 1);
            PESTADO.Value = "I";//variable que determina si el registro pertenece a un vehiculo que ingresa o sale del area operativa
            _Command.Parameters.Add(PESTADO);

            #endregion fin de la Definicion de los parametros del comando


            try
            {
                _Connection.Open();
                _Command.ExecuteNonQuery();
                //MessageBox.Show(pvalidar.Value.ToString(),"VARIABLE",MessageBoxButtons.OK);
            }
            catch (OracleException ora_exception)
            {
                _excepciones_oracle = ora_exception.Message;
                System.Windows.Forms.MessageBox.Show(_excepciones_oracle, "PROCEDIMIENTOS DE LA BASE DE DATOS", MessageBoxButtons.OK);
            }
            finally
            {
                _Connection.Close();
            }
        }


        public void registroSalida(string select, string conductor, string vehiculo, string trailers)
        {
            _Command = new OracleCommand(select, _Connection);
            _Command.CommandType = CommandType.StoredProcedure;

            #region Definicion de los parametros del comando

            OracleParameter PCONDUCTOR = new OracleParameter(":PCONDUCTOR", OracleDbType.Long, 13);
            PCONDUCTOR.Value = double.Parse(conductor.ToString());
            _Command.Parameters.Add(PCONDUCTOR);

            OracleParameter PVEHICULO = new OracleParameter(":PVEHICULO", OracleDbType.Varchar2, 6);
            PVEHICULO.Value = vehiculo;
            _Command.Parameters.Add(PVEHICULO);

            OracleParameter PTRAILER = new OracleParameter(":PTRAILER", OracleDbType.Varchar2, 6);
            PTRAILER.Value = trailers;
            _Command.Parameters.Add(PTRAILER);

            OracleParameter PESTADO = new OracleParameter(":PESTADO", OracleDbType.Varchar2, 1);
            PESTADO.Value = "I";//variable que determina si el registro pertenece a un vehiculo que ingresa o sale del area operativa
            _Command.Parameters.Add(PESTADO);

            #endregion fin de la Definicion de los parametros del comando


            try
            {
                _Connection.Open();
                _Command.ExecuteNonQuery();
                //MessageBox.Show(pvalidar.Value.ToString(),"VARIABLE",MessageBoxButtons.OK);
            }
            catch (OracleException ora_exception)
            {
                _excepciones_oracle = ora_exception.Message;
                System.Windows.Forms.MessageBox.Show(_excepciones_oracle, "PROCEDIMIENTOS DE LA BASE DE DATOS", MessageBoxButtons.OK);
            }
            finally
            {
                _Connection.Close();
            }
        }


        public void registro(string select, string conductor, string vehiculo, string trailers)
        {
            _Command = new OracleCommand(select, _Connection);
            _Command.CommandType = CommandType.StoredProcedure;

            OracleParameter p_conductor = new OracleParameter(":pconductor", OracleDbType.Int32, 13);
            p_conductor.Value = double.Parse(conductor.ToString());
            _Command.Parameters.Add(p_conductor);

            OracleParameter p_vehiculo = new OracleParameter(":pvehiculo", OracleDbType.Char,6);
            p_vehiculo.Value = vehiculo;
            _Command.Parameters.Add(p_vehiculo);

            OracleParameter p_trailer = new OracleParameter(":ptrailer", OracleDbType.Char, 6);
            p_trailer.Value = trailers;
            _Command.Parameters.Add(p_trailer);

            OracleParameter pvalidar = new OracleParameter("pvalidar", OracleDbType.NVarchar2, 500);
            pvalidar.Direction = ParameterDirection.Output;
            _Command.Parameters.Add(pvalidar);

            try
            {
                _Connection.Open();
                _Command.ExecuteNonQuery();
                //MessageBox.Show(pvalidar.Value.ToString(),"VARIABLE",MessageBoxButtons.OK);
            }
            catch (OracleException ora_exception)
            {
                _excepciones_oracle = ora_exception.Message;
                System.Windows.Forms.MessageBox.Show(_excepciones_oracle, "PROCEDIMIENTOS DE LA BASE DE DATOS", MessageBoxButtons.OK);
            }
            finally
            {
                _Connection.Close();
            }
        }

        public void registro_parqueadero(string select, string conductor, string vehiculo, string trailers, string parqueadero)
        {
            _Command = new OracleCommand(select, _Connection);
            _Command.CommandType = CommandType.StoredProcedure;

            OracleParameter p_conductor = new OracleParameter(":pconductor", OracleDbType.Int32, 13);
            p_conductor.Value = double.Parse(conductor.ToString());
            _Command.Parameters.Add(p_conductor);

            OracleParameter p_vehiculo = new OracleParameter(":pvehiculo", OracleDbType.Char, 6);
            p_vehiculo.Value = vehiculo;
            _Command.Parameters.Add(p_vehiculo);

            OracleParameter p_trailer = new OracleParameter(":ptrailer", OracleDbType.Char, 6);
            p_trailer.Value = trailers;
            _Command.Parameters.Add(p_trailer);

            OracleParameter p_parqueadero = new OracleParameter(":pparqueadero", OracleDbType.Char, 60);
            p_parqueadero.Value = parqueadero;
            _Command.Parameters.Add(p_parqueadero);

            OracleParameter pvalidar = new OracleParameter("pvalidar", OracleDbType.NVarchar2, 500);
            pvalidar.Direction = ParameterDirection.Output;
            _Command.Parameters.Add(pvalidar);

            try
            {
                _Connection.Open();
                _Command.ExecuteNonQuery();
                //MessageBox.Show(pvalidar.Value.ToString(),"VARIABLE",MessageBoxButtons.OK);
            }
            catch (OracleException ora_exception)
            {
                _excepciones_oracle = ora_exception.Message;
                System.Windows.Forms.MessageBox.Show(_excepciones_oracle, "PROCEDIMIENTOS DE LA BASE DE DATOS", MessageBoxButtons.OK);
            }
            finally
            {
                _Connection.Close();
            }
        }


        public void registro(string select, int secuencia, string estado, DateTimePicker fecenturne, DateTimePicker fecsolicita, DateTimePicker fecingresa, DateTimePicker fecsalida)
        {
            _Command = new OracleCommand(select, _Connection);
            _Command.CommandType = CommandType.StoredProcedure;

            OracleParameter p_secuencia = new OracleParameter(":psecuencia", OracleDbType.Int32, 13,ParameterDirection.Input);
            p_secuencia.Value = secuencia;
            _Command.Parameters.Add(p_secuencia);

            OracleParameter p_estado = new OracleParameter(":pestado", OracleDbType.Varchar2, 1,ParameterDirection.Input);
            p_estado.Value = estado;
            _Command.Parameters.Add(p_estado);

            OracleParameter p_fecenturne = new OracleParameter(":pfecenturne", OracleDbType.Date, ParameterDirection.Input);
            p_fecenturne.Value = fecenturne.Value;
            _Command.Parameters.Add(p_fecenturne);

            OracleParameter p_fecsolicita = new OracleParameter(":pfecsolicita", OracleDbType.Date, ParameterDirection.Input);
            p_fecsolicita.Value = fecsolicita.Value;
            _Command.Parameters.Add(p_fecsolicita);

            OracleParameter p_fecingresa = new OracleParameter(":pfecingresa", OracleDbType.Date, ParameterDirection.Input);
            p_fecingresa.Value = fecingresa.Value;
            _Command.Parameters.Add(p_fecingresa);

            OracleParameter p_fecsalida = new OracleParameter(":pfecsalida", OracleDbType.Date, ParameterDirection.Input);
            p_fecsalida.Value = fecsalida.Value;
            _Command.Parameters.Add(p_fecsalida);

            OracleParameter pvalidar = new OracleParameter("pvalidar", OracleDbType.NVarchar2, 500);
            pvalidar.Direction = ParameterDirection.Output;
            _Command.Parameters.Add(pvalidar);

            try
            {                
                _Connection.Open();
                _Command.ExecuteNonQuery();
                //MessageBox.Show("O.k", "VARIABLE", MessageBoxButtons.OK);
            }
            catch (OracleException ora_exception)
            {
                MessageBox.Show(pvalidar.Value.ToString() + "    " + ora_exception.Message, "VARIABLE", MessageBoxButtons.OK);
                System.Windows.Forms.MessageBox.Show(_excepciones_oracle, "PROCEDIMIENTOS DE LA BASE DE DATOS", MessageBoxButtons.OK);
            }
            finally
            {
                _Connection.Close();
            }
        }

        public int[] registro(string select)
        {
            int[] c_f = new int[6];
            _Command = new OracleCommand(select, _Connection);
            _Command.CommandType = CommandType.StoredProcedure;

            OracleParameter penturnados = new OracleParameter("penturnados", OracleDbType.Int32,6);
            penturnados.Direction = ParameterDirection.Output;
            _Command.Parameters.Add(penturnados);

            OracleParameter ptaller = new OracleParameter("ptaller", OracleDbType.Int32, 6);
            ptaller.Direction = ParameterDirection.Output;
            _Command.Parameters.Add(ptaller);

            OracleParameter pdespachados = new OracleParameter("pdespachados", OracleDbType.Int32, 6);
            pdespachados.Direction = ParameterDirection.Output;
            _Command.Parameters.Add(pdespachados);

            OracleParameter preparacion = new OracleParameter("preparacion", OracleDbType.Int32, 6);
            preparacion.Direction = ParameterDirection.Output;
            _Command.Parameters.Add(preparacion);

            OracleParameter psiniestrados = new OracleParameter("psiniestrados", OracleDbType.Int32, 6);
            psiniestrados.Direction = ParameterDirection.Output;
            _Command.Parameters.Add(psiniestrados);

            OracleParameter pparqueadero = new OracleParameter("pparqueadero", OracleDbType.Int32, 6);
            pparqueadero.Direction = ParameterDirection.Output;
            _Command.Parameters.Add(pparqueadero);

            try
            {
                _Connection.Open();
                _Command.ExecuteNonQuery();
                c_f[0] = int.Parse(penturnados.Value.ToString());
                c_f[1] = int.Parse(ptaller.Value.ToString());
                c_f[2] = int.Parse(pdespachados.Value.ToString());
                c_f[3] = int.Parse(preparacion.Value.ToString());
                c_f[4] = int.Parse(psiniestrados.Value.ToString());
                c_f[5] = int.Parse(pparqueadero.Value.ToString());
            }
            catch (OracleException ora_exception)
            {
                _excepciones_oracle = ora_exception.Message;
                System.Windows.Forms.MessageBox.Show(_excepciones_oracle, "PROCEDIMIENTOS DE LA BASE DE DATOS", MessageBoxButtons.OK);
            }
            finally
            {
                _Connection.Close();
            }
            return c_f;
        }

        public void registro(string select, int secuencia, string estado)
        {
            _Command = new OracleCommand(select, _Connection);
            _Command.CommandType = CommandType.StoredProcedure;

            OracleParameter p_secuencia = new OracleParameter(":psecuencia", OracleDbType.Int32, 13, ParameterDirection.Input);
            p_secuencia.Value = secuencia;
            _Command.Parameters.Add(p_secuencia);

            OracleParameter p_estado = new OracleParameter(":pestado", OracleDbType.Varchar2, 1, ParameterDirection.Input);
            p_estado.Value = estado;
            _Command.Parameters.Add(p_estado);

            OracleParameter pvalidar = new OracleParameter("pvalidar", OracleDbType.NVarchar2, 500);
            pvalidar.Direction = ParameterDirection.Output;
            _Command.Parameters.Add(pvalidar);

            try
            {
                _Connection.Open();
                _Command.ExecuteNonQuery();
                //MessageBox.Show("O.k", "VARIABLE", MessageBoxButtons.OK);
            }
            catch (OracleException ora_exception)
            {
                MessageBox.Show(pvalidar.Value.ToString() + "    " + ora_exception.Message, "VARIABLE", MessageBoxButtons.OK);
                System.Windows.Forms.MessageBox.Show(_excepciones_oracle, "PROCEDIMIENTOS DE LA BASE DE DATOS", MessageBoxButtons.OK);
            }
            finally
            {
                _Connection.Close();
            }
        }
        #endregion fin de la Definicion de la region para el bloque de transacciones

        public bool validarUsuario(string Cadena)
        {
            bool conexion = false;
            try
            {
                _Connection.Open();
                conexion = true;
                _Connection.Close();
            }
            catch (OracleException excep)
            {
                _excepciones_oracle = excep.Message;
                System.Windows.Forms.MessageBox.Show(_excepciones_oracle, "PROCEDIMIENTOS DE LA BASE DE DATOS", MessageBoxButtons.OK);
                conexion = false;
            }
            return conexion;
        }

        public void registro(string select, string conductor, string vehiculo, string trailers, string plogin)
        {
            _Command = new OracleCommand(select, _Connection);
            _Command.CommandType = CommandType.StoredProcedure;

            OracleParameter p_conductor = new OracleParameter(":pconductor", OracleDbType.Int32, 13);
            p_conductor.Value = double.Parse(conductor.ToString());
            _Command.Parameters.Add(p_conductor);

            OracleParameter p_vehiculo = new OracleParameter(":pvehiculo", OracleDbType.Char, 6);
            p_vehiculo.Value = vehiculo;
            _Command.Parameters.Add(p_vehiculo);

            OracleParameter p_trailer = new OracleParameter(":ptrailer", OracleDbType.Char, 6);
            if (trailers=="0     ")
            {
                trailers = "ZZZZZZ";
            }
            if (trailers == "0")
            {
                trailers = "ZZZZZZ";
            }
            p_trailer.Value = trailers;
            _Command.Parameters.Add(p_trailer);

            OracleParameter pvalidar = new OracleParameter("pvalidar", OracleDbType.NVarchar2, 500);
            pvalidar.Direction = ParameterDirection.Output;
            _Command.Parameters.Add(pvalidar);

            OracleParameter p_login = new OracleParameter(":plogin", OracleDbType.Varchar2, 15);
            //p_login.Value = plogin;
            p_login.Value = "FMONTOYA";//plogin;
            _Command.Parameters.Add(p_login);

            try
            {
                _Connection.Open();
                if (plogin.Length < 2)
                {
                    MessageBox.Show("Usuario : " + plogin, "USUARIO AUTENTICADO", MessageBoxButtons.OK);
                }
                _Command.ExecuteNonQuery();
                //MessageBox.Show(pvalidar.Value.ToString(),"VARIABLE",MessageBoxButtons.OK);
            }
            catch (OracleException ora_exception)
            {
                _excepciones_oracle = ora_exception.Message;
                System.Windows.Forms.MessageBox.Show(_excepciones_oracle, "PROCEDIMIENTOS DE LA BASE DE DATOS", MessageBoxButtons.OK);
                MessageBox.Show("Usuario : " + plogin, "USUARIO AUTENTICADO", MessageBoxButtons.OK);
            }
            finally
            {
                _Connection.Close();
            }
        }

        public void registroIngreso(string select, string conductor, string vehiculo, string trailers, string plogin)
        {
            _Command = new OracleCommand(select, _Connection);
            _Command.CommandType = CommandType.StoredProcedure;

            #region Definicion de los parametros del comando

            OracleParameter PCONDUCTOR = new OracleParameter(":PCONDUCTOR", OracleDbType.Long, 13);
            PCONDUCTOR.Value = double.Parse(conductor.ToString());
            _Command.Parameters.Add(PCONDUCTOR);

            OracleParameter PVEHICULO = new OracleParameter(":PVEHICULO", OracleDbType.Varchar2, 6);
            PVEHICULO.Value = vehiculo;
            _Command.Parameters.Add(PVEHICULO);

            OracleParameter PTRAILER = new OracleParameter(":PTRAILER", OracleDbType.Varchar2, 6);
            PTRAILER.Value = trailers;
            _Command.Parameters.Add(PTRAILER);

            OracleParameter PESTADO = new OracleParameter(":PESTADO", OracleDbType.Varchar2, 1);
            PESTADO.Value = "I";//variable que determina si el registro pertenece a un vehiculo que ingresa o sale del area operativa
            _Command.Parameters.Add(PESTADO);


            OracleParameter p_login = new OracleParameter(":plogin", OracleDbType.Varchar2, 15);
            //p_login.Value = plogin;
            p_login.Value = "FMONTOYA";//plogin;
            _Command.Parameters.Add(p_login);

            #endregion fin de la Definicion de los parametros del comando


            try
            {
                _Connection.Open();
                if (plogin.Length < 2)
                {
                    MessageBox.Show("Usuario : " + plogin, "USUARIO AUTENTICADO", MessageBoxButtons.OK);
                }
                _Command.ExecuteNonQuery();
                //MessageBox.Show(pvalidar.Value.ToString(),"VARIABLE",MessageBoxButtons.OK);
            }
            catch (OracleException ora_exception)
            {
                _excepciones_oracle = ora_exception.Message;
                System.Windows.Forms.MessageBox.Show(_excepciones_oracle, "PROCEDIMIENTOS DE LA BASE DE DATOS", MessageBoxButtons.OK);
                MessageBox.Show("Usuario : " + plogin, "USUARIO AUTENTICADO", MessageBoxButtons.OK);
            }
            finally
            {
                _Connection.Close();
            }
        }

        public void registroSalida(string select, string conductor, string vehiculo, string trailers, string plogin)
        {
            _Command = new OracleCommand(select, _Connection);
            _Command.CommandType = CommandType.StoredProcedure;

            #region Definicion de los parametros del comando

            OracleParameter PCONDUCTOR = new OracleParameter(":PCONDUCTOR", OracleDbType.Long, 13);
            PCONDUCTOR.Value = double.Parse(conductor.ToString());
            _Command.Parameters.Add(PCONDUCTOR);

            OracleParameter PVEHICULO = new OracleParameter(":PVEHICULO", OracleDbType.Varchar2, 6);
            PVEHICULO.Value = vehiculo;
            _Command.Parameters.Add(PVEHICULO);

            OracleParameter PTRAILER = new OracleParameter(":PTRAILER", OracleDbType.Varchar2, 6);
            PTRAILER.Value = trailers;
            _Command.Parameters.Add(PTRAILER);

            OracleParameter PESTADO = new OracleParameter(":PESTADO", OracleDbType.Varchar2, 1);
            PESTADO.Value = "I";//variable que determina si el registro pertenece a un vehiculo que ingresa o sale del area operativa
            _Command.Parameters.Add(PESTADO);


            OracleParameter p_login = new OracleParameter(":plogin", OracleDbType.Varchar2, 15);
            //p_login.Value = plogin;
            p_login.Value = "FMONTOYA";//plogin;

            _Command.Parameters.Add(p_login);

            #endregion fin de la Definicion de los parametros del comando


            try
            {
                _Connection.Open();
                if (plogin.Length < 2)
                {
                    MessageBox.Show("Usuario : " + plogin, "USUARIO AUTENTICADO", MessageBoxButtons.OK);
                }
                _Command.ExecuteNonQuery();
                //MessageBox.Show(pvalidar.Value.ToString(),"VARIABLE",MessageBoxButtons.OK);
            }
            catch (OracleException ora_exception)
            {
                _excepciones_oracle = ora_exception.Message;
                System.Windows.Forms.MessageBox.Show(_excepciones_oracle, "PROCEDIMIENTOS DE LA BASE DE DATOS", MessageBoxButtons.OK);
                MessageBox.Show("Usuario : " + plogin, "USUARIO AUTENTICADO", MessageBoxButtons.OK);
            }
            finally
            {
                _Connection.Close();
            }
        }

        public void registro(string select, int secuencia, string estado, string plogin)
        {
            _Command = new OracleCommand(select, _Connection);
            _Command.CommandType = CommandType.StoredProcedure;

            OracleParameter p_secuencia = new OracleParameter(":psecuencia", OracleDbType.Int32, 13, ParameterDirection.Input);
            p_secuencia.Value = secuencia;
            _Command.Parameters.Add(p_secuencia);

            OracleParameter p_estado = new OracleParameter(":pestado", OracleDbType.Varchar2, 1, ParameterDirection.Input);
            p_estado.Value = estado;
            _Command.Parameters.Add(p_estado);

            OracleParameter pvalidar = new OracleParameter("pvalidar", OracleDbType.NVarchar2, 500);
            pvalidar.Direction = ParameterDirection.Output;
            _Command.Parameters.Add(pvalidar);

            OracleParameter p_login = new OracleParameter(":plogin", OracleDbType.Varchar2, 15);
            //p_login.Value = plogin;
            p_login.Value = "FMONTOYA";//plogin;

            _Command.Parameters.Add(p_login);

            try
            {
                _Connection.Open();
                if (plogin.Length < 2)
                {
                    MessageBox.Show("Usuario : " + plogin, "USUARIO AUTENTICADO", MessageBoxButtons.OK);
                }
                _Command.ExecuteNonQuery();
                //MessageBox.Show("O.k", "VARIABLE", MessageBoxButtons.OK);
            }
            catch (OracleException ora_exception)
            {
                MessageBox.Show(pvalidar.Value.ToString() + "    " + ora_exception.Message, "VARIABLE", MessageBoxButtons.OK);
                System.Windows.Forms.MessageBox.Show(_excepciones_oracle, "PROCEDIMIENTOS DE LA BASE DE DATOS", MessageBoxButtons.OK);
                MessageBox.Show("Usuario : " + plogin, "USUARIO AUTENTICADO", MessageBoxButtons.OK);
            }
            finally
            {
                _Connection.Close();
            }
        }
        public void registro_parqueadero(string select, string conductor, string vehiculo, string trailers, string parqueadero, string plogin)
        {
            _Command = new OracleCommand(select, _Connection);
            _Command.CommandType = CommandType.StoredProcedure;

            OracleParameter p_conductor = new OracleParameter(":pconductor", OracleDbType.Int32, 13);
            p_conductor.Value = double.Parse(conductor.ToString());
            _Command.Parameters.Add(p_conductor);

            OracleParameter p_vehiculo = new OracleParameter(":pvehiculo", OracleDbType.Char, 6);
            p_vehiculo.Value = vehiculo;
            _Command.Parameters.Add(p_vehiculo);

            OracleParameter p_trailer = new OracleParameter(":ptrailer", OracleDbType.Char, 6);
            p_trailer.Value = trailers;
            _Command.Parameters.Add(p_trailer);

            OracleParameter p_parqueadero = new OracleParameter(":pparqueadero", OracleDbType.Char, 60);
            p_parqueadero.Value = parqueadero;
            _Command.Parameters.Add(p_parqueadero);

            OracleParameter pvalidar = new OracleParameter("pvalidar", OracleDbType.NVarchar2, 500);
            pvalidar.Direction = ParameterDirection.Output;
            _Command.Parameters.Add(pvalidar);

            OracleParameter p_login = new OracleParameter(":plogin", OracleDbType.Varchar2, 15);
            p_login.Value = "FMONTOYA";//plogin;
            _Command.Parameters.Add(p_login);

            try
            {
                _Connection.Open();
                if (plogin.Length < 2)
                {
                    MessageBox.Show("Usuario : " + plogin, "USUARIO AUTENTICADO", MessageBoxButtons.OK);
                }
                _Command.ExecuteNonQuery();
                //MessageBox.Show(pvalidar.Value.ToString(),"VARIABLE",MessageBoxButtons.OK);
            }
            catch (OracleException ora_exception)
            {
                _excepciones_oracle = ora_exception.Message;
                System.Windows.Forms.MessageBox.Show(_excepciones_oracle, "PROCEDIMIENTOS DE LA BASE DE DATOS", MessageBoxButtons.OK);
            }
            finally
            {
                _Connection.Close();
            }
        }

        public void registro(string select, int secuencia, string estado, DateTimePicker fecenturne, DateTimePicker fecsolicita, DateTimePicker fecingresa, DateTimePicker fecsalida, string plogin)
        {
            _Command = new OracleCommand(select, _Connection);
            _Command.CommandType = CommandType.StoredProcedure;

            OracleParameter p_secuencia = new OracleParameter(":psecuencia", OracleDbType.Int32, 13, ParameterDirection.Input);
            p_secuencia.Value = secuencia;
            _Command.Parameters.Add(p_secuencia);

            OracleParameter p_estado = new OracleParameter(":pestado", OracleDbType.Varchar2, 1, ParameterDirection.Input);
            p_estado.Value = estado;
            _Command.Parameters.Add(p_estado);

            OracleParameter p_fecenturne = new OracleParameter(":pfecenturne", OracleDbType.Date, ParameterDirection.Input);
            p_fecenturne.Value = fecenturne.Value;
            _Command.Parameters.Add(p_fecenturne);

            OracleParameter p_fecsolicita = new OracleParameter(":pfecsolicita", OracleDbType.Date, ParameterDirection.Input);
            p_fecsolicita.Value = fecsolicita.Value;
            _Command.Parameters.Add(p_fecsolicita);

            OracleParameter p_fecingresa = new OracleParameter(":pfecingresa", OracleDbType.Date, ParameterDirection.Input);
            p_fecingresa.Value = fecingresa.Value;
            _Command.Parameters.Add(p_fecingresa);

            OracleParameter p_fecsalida = new OracleParameter(":pfecsalida", OracleDbType.Date, ParameterDirection.Input);
            p_fecsalida.Value = fecsalida.Value;
            _Command.Parameters.Add(p_fecsalida);

            OracleParameter pvalidar = new OracleParameter("pvalidar", OracleDbType.NVarchar2, 500);
            pvalidar.Direction = ParameterDirection.Output;
            _Command.Parameters.Add(pvalidar);

            OracleParameter p_login = new OracleParameter(":plogin", OracleDbType.Varchar2, 15);
            //p_login.Value = plogin;
            p_login.Value = "FMONTOYA";//plogin;

            _Command.Parameters.Add(p_login);

            try
            {
                _Connection.Open();
                if (plogin.Length<2)
                {
                    MessageBox.Show("Usuario : " + plogin, "USUARIO AUTENTICADO", MessageBoxButtons.OK);
                }
                _Command.ExecuteNonQuery();
                //MessageBox.Show("O.k", "VARIABLE", MessageBoxButtons.OK);
            }
            catch (OracleException ora_exception)
            {
                MessageBox.Show(pvalidar.Value.ToString() + "    " + ora_exception.Message, "VARIABLE", MessageBoxButtons.OK);
                System.Windows.Forms.MessageBox.Show(_excepciones_oracle, "PROCEDIMIENTOS DE LA BASE DE DATOS", MessageBoxButtons.OK);
                MessageBox.Show("Usuario : " + plogin, "USUARIO AUTENTICADO", MessageBoxButtons.OK);
            }
            finally
            {
                _Connection.Close();
            }
        }

        public DataSet generico(string select, DateTimePicker fecini, DateTimePicker fecfin, string estado)
        {
            _dataset = new DataSet();
            _Command = new OracleCommand(select, _Connection);
            _Command.CommandType = CommandType.StoredProcedure;

            OracleParameter p_refcursor = new OracleParameter();
            p_refcursor.OracleDbType = OracleDbType.RefCursor;
            p_refcursor.Direction = ParameterDirection.ReturnValue;
            _Command.Parameters.Add(p_refcursor);

            OracleParameter p_fecini = new OracleParameter(":fecini", OracleDbType.Date, ParameterDirection.Input);
            p_fecini.Value = fecini.Value;
            _Command.Parameters.Add(p_fecini);

            OracleParameter p_fecfin = new OracleParameter(":fecfin", OracleDbType.Date, ParameterDirection.Input);
            p_fecfin.Value = fecfin.Value;
            _Command.Parameters.Add(p_fecfin);

            OracleParameter p_estado = new OracleParameter(":estado", OracleDbType.Varchar2, ParameterDirection.Input);
            p_estado.Value = estado;
            _Command.Parameters.Add(p_estado);

            _DataAdapter = new OracleDataAdapter(_Command);

            try
            {
                _DataAdapter.Fill(_dataset, "CONSULTA");
            }
            catch (OracleException ora_exception)
            {
                _excepciones_oracle = ora_exception.Message;
                System.Windows.Forms.MessageBox.Show(_excepciones_oracle, "PROCEDIMIENTOS DE LA BASE DE DATOS", MessageBoxButtons.OK);
            }
            return _dataset;
        }
        public DataSet generico(string select, Int32 inta_conjunto, string nombreparametro)
        {
            _dataset = new DataSet();
            _Command = new OracleCommand(select, _Connection);
            _Command.CommandType = CommandType.StoredProcedure;

            OracleParameter p_refcursor = new OracleParameter();
            p_refcursor.OracleDbType = OracleDbType.RefCursor;
            p_refcursor.Direction = ParameterDirection.ReturnValue;
            _Command.Parameters.Add(p_refcursor);

            OracleParameter p_conjunto = new OracleParameter(nombreparametro, OracleDbType.Int32, ParameterDirection.Input);
            p_conjunto.Value = inta_conjunto;
            _Command.Parameters.Add(p_conjunto);

            _DataAdapter = new OracleDataAdapter(_Command);

            try
            {
                _DataAdapter.Fill(_dataset, "CONSULTA");
            }
            catch (OracleException ora_exception)
            {
                _excepciones_oracle = ora_exception.Message;
                System.Windows.Forms.MessageBox.Show(_excepciones_oracle, "PROCEDIMIENTOS DE LA BASE DE DATOS", MessageBoxButtons.OK);
            }
            return _dataset;
        }

    }
}
