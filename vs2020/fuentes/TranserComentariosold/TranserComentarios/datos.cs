using System;
using System.Linq;
using System.Text;
using System.Collections.Generic; // For generic collections like List.
using System.Data.SqlClient;
using System.Data;
using System.IO;      // For the database connections and objects.

namespace TranserComentarios
{
    class datos
    {
        #region Definicion de la variables globales
        private bool conexionOpen;

        public bool ConexionOpen
        {
            get { return conexionOpen; }
            set { conexionOpen = value; }
        }
        private string cadena;
        private SqlConnection _connection;
        public SqlConnection Connection
        {
            get { return _connection; }
            set { _connection = value; }
        }
        private SqlCommand _command;
        public SqlCommand Command
        {
            get { return _command; }
            set { _command = value; }
        }
        private SqlDataAdapter _datadapter;
        public SqlDataAdapter Datadapter
        {
            get { return _datadapter; }
            set { _datadapter = value; }
        }

        private SqlDataReader _datareader;

        public SqlDataReader Datareader
        {
            get { return _datareader; }
            set { _datareader = value; }
        }

        private DataTable _datatable;
        public DataTable tabledata
        {
            get { return _datatable; }
            set { _datatable = value; }
        }
        private SqlException _oracleexception;
        public SqlException Oracleexception
        {
            get { return _oracleexception; }
            set { _oracleexception = value; }
        }

        private SqlDataReader _oracleDataReader;
        public SqlDataReader OracleDataReader
        {
            get { return _oracleDataReader; }
            set { _oracleDataReader = value; }
        }

        private Exception _exception;
        public Exception Exception
        {
            get { return _exception; }
            set { _exception = value; }
        }

        private string excepcionPersonalizada;
        public string ExcepcionPersonalizada
        {
            get { return excepcionPersonalizada; }
            set { excepcionPersonalizada = value; }
        }

        private string quienUsoDbFacOra;

        public string QuienUsoDbFacOra
        {
            get { return quienUsoDbFacOra; }
            set { quienUsoDbFacOra = value; }
        }

        private string version;

        public string Version
        {
            get { return version; }
            set { version = value; }
        }
        private DateTime _start_time;

        public DateTime Start_time
        {
            get { return _start_time; }
            set { _start_time = value; }
        }

        private DateTime _end_time;

        public DateTime End_time
        {
            get { return _end_time; }
            set { _end_time = value; }
        }

        private TimeSpan _ts;

        public TimeSpan Ts
        {
            get { return _ts; }
            set { _ts = value; }
        }

        #endregion fin de la Definicion de la variables globales

        public datos()
        { }

        public string capturarCorreo(string idCorreo)
        {//
            string correo = string.Empty;
            //using (SqlConnection connection = new SqlConnection(@"Data Source=svrsqlsr01\SQLEXPRESS,1433;Network Library=DBMSSOCN;Initial Catalog=TranserComentarios;User ID=sa;Password=Satranser2015"))
            using (SqlConnection connection = new SqlConnection(@"Data Source=JSOPORTE\SQLEXPRESS;Initial Catalog=TranserComentarios;User ID=sa;Password=Satranser2015"))
            using (SqlCommand cmd = new SqlCommand("select email Correo from Categoria_Correo where id_Tipo_Funcionario=" + idCorreo, connection))
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Check is the reader has any rows at all before starting to read.
                    if (reader.HasRows)
                    {
                        // Read advances to the next row.
                        while (reader.Read())
                        {
                            // To avoid unexpected bugs access columns by name.
                            correo = reader.GetString(reader.GetOrdinal("Correo"));
                        }
                    }
                }
            }
            return correo;
        }

        public int capturarMaxMensajes()
        {//
            int max = 0;
            //using (SqlConnection connection = new SqlConnection(@"Data Source=svrsqlsr01\SQLEXPRESS,1433;Network Library=DBMSSOCN;Initial Catalog=TranserComentarios;User ID=sa;Password=Satranser2015"))
            using (SqlConnection connection = new SqlConnection(@"Data Source=JSOPORTE\SQLEXPRESS;Initial Catalog=TranserComentarios;User ID=sa;Password=Satranser2015"))
            using (SqlCommand cmd = new SqlCommand(" select max(id) maxid from mensaje", connection))
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Check is the reader has any rows at all before starting to read.
                    if (reader.HasRows)
                    {
                        // Read advances to the next row.
                        while (reader.Read())
                        {
                            // To avoid unexpected bugs access columns by name.
                            //object smax = reader.GetString(reader.GetOrdinal("maxid"));
                            object smax = reader.GetInt32(reader.GetOrdinal("maxid"));
                            //max = reader.GetString(reader.GetInt32("maxid"));
                            max = int.Parse(smax.ToString());
                        }
                    }
                }
            }
            return max;
        }

        public int ejecutar(string select, string[] nombre_parametro, object[] valor_parametro)
        {
            int salida = 0;
            SqlCommand cmd = comandoExecute(select, nombre_parametro, valor_parametro);
            try
            {
                _start_time = DateTime.Now;
                salida = (int)cmd.ExecuteNonQuery();
                //_start_time = DateTime.Now;
                _end_time = DateTime.Now;
                _ts = _end_time - _start_time;
                //escribirMensajePrograma(select, "salida = (int)cmd.ExecuteNonQuery();");
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            catch (SqlException oraexc)
            {
                _oracleexception = oraexc;
                excepcionPersonalizada = "Error de Oracle. \r\t\nMensaje de Error : " + oraexc.Message.ToString() + "  \r\t\nNumero del Error : " + oraexc.Number.ToString() + " \r\t\nNombre del Procedimiento : " + oraexc.Procedure.ToString() + "\r\t\n fuente del Error : " + oraexc.Source.ToString();
                escribirMensaje(excepcionPersonalizada);
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            catch (Exception exc)
            {
                _exception = exc;
                excepcionPersonalizada = "Error de ejecucion. \r\t\nMensaje de Error : " + exc.Message.ToString() + " \r\t\n data del Error : " + exc.Data.ToString() + " \r\t\nfuente del Error : " + exc.Source.ToString();
                escribirMensaje(excepcionPersonalizada);
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            return salida;
        }
        /// <summary>
        /// private OracleConnection conexion()
        /// </summary>
        /// <returns></returns>
        #region Definicion del metodo private OracleConnection conexion()
        private SqlConnection conexion()
        {
            conexionOpen = false;
            _connection = new SqlConnection();
            try
            {
                //cadena = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=U:\desarrollosweb\TranserComentarios\TranserComentarios\TranserComentarios\App_Data\TranserComentarios.mdf;Integrated Security=True;Connect Timeout=30";

                cadena = @"Data Source=JSOPORTE\SQLEXPRESS;Initial Catalog=TranserComentarios;User ID=sa;Password=Satranser2015";
                //cadena = @"Data Source=svrsqlsr01\SQLEXPRESS,1433;Network Library=DBMSSOCN;Initial Catalog=TranserComentarios;User ID=sa;Password=Satranser2015";

                _connection.ConnectionString = cadena;
                _connection.Open();
                conexionOpen = true;
            }
            catch (SqlException oraexc)
            {
                _oracleexception = oraexc;
                excepcionPersonalizada = "Error de Oracle. \r\t\nMensaje de Error : " + oraexc.Message.ToString() + "  \r\t\nNumero del Error : " + oraexc.Number.ToString() + " \r\t\nNombre del Procedimiento : " + oraexc.Procedure.ToString() + "\r\t\n fuente del Error : " + oraexc.Source.ToString();
                escribirMensaje(excepcionPersonalizada);
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            catch (Exception exc)
            {
                _exception = exc;
                excepcionPersonalizada = "Error de ejecucion. \r\t\nMensaje de Error : " + exc.Message.ToString() + " \r\t\n data del Error : " + exc.Data.ToString() + " \r\t\nfuente del Error : " + exc.Source.ToString();
                escribirMensaje(excepcionPersonalizada);
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            return _connection;
        }
        #endregion fin de la Definicion del metodo private OracleConnection conexion()

        /// <summary>
        /// private OracleCommand comando(string select, string[] nombre_parametro, object[] valor_parametro)
        /// </summary>
        /// <param name="select"></param>
        /// <param name="nombre_parametro"></param>
        /// <param name="valor_parametro"></param>
        /// <returns></returns>
        #region Definicion del metodo private OracleCommand comando(string select, string[] nombre_parametro, object[] valor_parametro)
        private SqlCommand comandoExecute(string select, string[] nombre_parametro, object[] valor_parametro)
        {
            _command = new SqlCommand();
            try
            {
                _command.Connection = conexion();
                _command.CommandType = CommandType.Text;
                _command.CommandText = select;
                for (int i = 0; i < nombre_parametro.Length; i++)
                {
                    _command.Parameters.Add(parametroInt(nombre_parametro[i], valor_parametro[i]));
                }
            }
            catch (SqlException oraexc)
            {
                _oracleexception = oraexc;
                excepcionPersonalizada = "Error de Oracle. \r\t\nMensaje de Error : " + oraexc.Message.ToString() + "  \r\t\nNumero del Error : " + oraexc.Number.ToString() + " \r\t\nNombre del Procedimiento : " + oraexc.Procedure.ToString() + "\r\t\n fuente del Error : " + oraexc.Source.ToString();
                escribirMensaje(excepcionPersonalizada);

            }
            catch (Exception exc)
            {
                _exception = exc;
                excepcionPersonalizada = "Error de ejecucion. \r\t\nMensaje de Error : " + exc.Message.ToString() + " \r\t\n data del Error : " + exc.Data.ToString() + " \r\t\nfuente del Error : " + exc.Source.ToString();
                escribirMensaje(excepcionPersonalizada);

            }
            return _command;
        }
        #endregion fin de la Definicion del metodo private OracleCommand comando(string select, string[] nombre_parametro, object[] valor_parametro)        /// <summary>


        /// <summary>
        /// private OracleParameter parametroInt(string pnombre, object valor)
        /// </summary>
        /// <param name="pnombre"></param>
        /// <param name="valor"></param>
        /// <returns></returns>
        #region Definicion del metodo private OracleParameter parametroInt(string pnombre, object valor)
        private SqlParameter parametroInt(string pnombre, object valor)
        {
            bool getype = false;
            SqlParameter op = new SqlParameter();

            op.ParameterName = pnombre;
            op.Direction = ParameterDirection.Input;

            if (valor.GetType() == Type.GetType("System.Int32"))
            {
                op.Value = (int)valor;
                op.SqlDbType = SqlDbType.Int;
                getype = true;
            }
            if (valor.GetType() == Type.GetType("System.Double"))
            {
                op.Value = (Double)valor;
                op.SqlDbType = SqlDbType.Int;
                getype = true;
            }
            if (valor.GetType() == Type.GetType("System.Int64"))
            {
                op.Value = (long)valor;
                op.SqlDbType = SqlDbType.Int;
                getype = true;
            }
            if (valor.GetType() == Type.GetType("System.String"))
            {
                op.Value = (string)valor;
                op.SqlDbType = SqlDbType.VarChar;
                getype = true;
            }
            if (valor.GetType() == Type.GetType("System.DateTime"))
            {
                DateTime fecha = (DateTime)valor;
                //op.Value = fecha.ToShortDateString() + " " +fecha.ToShortTimeString();
                op.Value = valor;
                op.SqlDbType = SqlDbType.Date;
                getype = true;
            }
            if (valor.GetType() == Type.GetType("System.Object"))
            {
                op.Value = (byte[])valor;
                op.SqlDbType = SqlDbType.BigInt;
                getype = true;
            }
            if (valor.GetType() == Type.GetType("System.Byte[]"))
            {
                op.Value = (byte[])valor;
                op.SqlDbType = SqlDbType.BigInt;
                getype = true;
            }
            if (!getype)
            {
                try
                {
                    op.Value = (byte[])valor;
                    op.SqlDbType = SqlDbType.BigInt;
                    getype = true;
                }
                catch (Exception exc)
                {
                    _exception = exc;
                    excepcionPersonalizada = "Error de ejecucion al momento de cargar parametos. \r\t\nMensaje de Error : " + exc.Message.ToString() + " \r\t\n data del Error : " + exc.Data.ToString() + " \r\t\nfuente del Error : " + exc.Source.ToString();
                    escribirMensaje(excepcionPersonalizada);
                    if (_connection.State == ConnectionState.Open)
                    {
                        _connection.Close();
                    }
                }
            }
            return op;
        }
        #endregion fin de la Definicion del metodo private OracleParameter parametroInt(string pnombre, object valor)
        /// <summary>
        /// private void escribirMensaje(string mensaje)
        /// </summary>
        /// <param name="mensaje"></param>
        /// 
        #region Definicion del metodo private void escribirMensaje(string mensaje)
        private void escribirMensaje(string mensaje)
        {

        }
        #endregion fin de la Definicion del metodo private void escribirMensaje(string mensaje)
    }
}
