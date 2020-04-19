using System;

namespace AccesoDatos.Credenciales
{
    public partial class Security
    {
        public string Base64Decode(string base64EncodedData)
        {
            string encoding = string.Empty;
            try
            {
                encoding = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(base64EncodedData));
                var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
                encoding = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            }
            catch (Exception ex)
            {
                _eP._Mensaje = ex.Message;
                _eP._Continua = false;
                _eP._Excepcion = ex.Message;
                _eP._Fecha = DateTime.UtcNow;
                _eP.Registro("El parametro base64EncodedData\r\ndel metodo public string Base64Decode(string base64EncodedData) presenta el siguiente mensaje de error : \r\n" + ex.Message);
            }
            return encoding;

        }

        public string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            string texto = System.Convert.ToBase64String(plainTextBytes);
            return texto;
        }

        public string inicialization()
        {
            string cadena = string.Empty;
            switch (Base64Decode(_ambiente))
            {
                case "desarrollo":
                    {
                        _ip = "192.168.30.148";
                        _sid = "PERSONAL.transer.local";
                        break;
                    }
                case "produccion":
                    {
                        _ip = "192.168.30.119";
                        _sid = "DBMILE";
                        break;
                    }
                case "operativo":
                    {
                        _ip = "192.168.30.122";
                        _sid = "dbclon.transer.local";
                        //sid = "dbclon";
                        break;
                    }
                default:
                    {
                        _ip = "192.168.30.148";
                        _sid = "PERSONAL.transer.local";
                        break;
                    }
            }
            cadena = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=" + _ip + ")(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=" + _sid + ")(FAILOVER_MODE=(TYPE=select)(METHOD=basic)(RETRIES=20)(DELAY=15))));";
            cadena += "Min Pool Size=4;" +//Tamaño de grupo mínimo del pool, definimos el número mínimo de conexiones que deben mantenerse en el grupo. 
                 "Max Pool Size=10;" +//Tamaño máximo del pool, define la cantidad máxima de conexiones que pueden mantenerse en el grupo.
                 "Connection Lifetime=120;" +//Duración de la conexión, define la duración máxima (en segundos) que una conexión puede permanecer en caché en el grupo.
                 "Connection Timeout=60;" +//Tiempo de espera de conexión Esta es la cantidad de tiempo (en segundos) que cada solicitud de conexión se da para conectarse a la base de datos. antes de que se levante una excepción de tiempo de espera
                 "Incr Pool Size=5;" +//Tamaño del pool de Incr, define el número de conexiones nuevas para crear cada vez que se necesitan más conexiones en el grupo de conexiones.
                 "Decr Pool Size=2;" +//Tamaño del grupo de escritorios El servicio de agrupación de conexiones intentará cerrar conexiones en caché que no están en uso por más de 3 minutos. Este atributo define el número máximo de conexiones que se pueden cerrar de una vez.
                 "Pooling=true;" +//El atributo Pooling de la conexión de la base de datos permite que la aplicación no esté creando una conexión física a la base de datos en cada solicitud que se necesite una conexión, por tal motivo la conexión se crea una vez y se mantiene establecida en la base de datos con mínimos recursos utilizados en la base de datos. Por default su valor es true y se recomienda dejarlo en ese valor.
                 "Enlist=false;" +//El atributo Enlist permite que las operaciones DML que se ejecutan mediante la conexión establecida se trabajen como parte de una transacción distribuida. Si no fuera nuestro caso, se debe colocar el valor de false ya que por default tiene el valor de true.
                 "Statement Cache Size=50;" +
                 "User ID=" + Base64Decode(_usuario) + ";" +
                 "Password=" + Base64Decode(_password) + ";";

            return cadena;
        }
    }
}
