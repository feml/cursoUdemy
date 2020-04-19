using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public partial class Security
    {
        public string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            string texto = System.Convert.ToBase64String(plainTextBytes);
            return texto;
        }

        public void inicialization()
        {
            switch (Base64Decode(ambiente))
            {
                case "desarrollo":
                    {
                        ip = "192.168.30.148";
                        sid = "PERSONAL.transer.local";
                        break;
                    }
                case "produccion":
                    {
                        ip = "192.168.30.119";
                        sid = "DBMILE";
                        break;
                    }
                case "operativo":
                    {
                        ip = "192.168.30.122";
                        sid = "dbclon.transer.local";
                        //sid = "dbclon";
                        break;
                    }
                default:
                    {
                        ip = "192.168.30.148";
                        sid = "PERSONAL.transer.local";
                        break;
                    }
            }
            cadena = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=" + ip + ")(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=" + sid + ")(FAILOVER_MODE=(TYPE=select)(METHOD=basic)(RETRIES=20)(DELAY=15))));";
            cadena += "Min Pool Size=4;" +//Tamaño de grupo mínimo del pool, definimos el número mínimo de conexiones que deben mantenerse en el grupo. 
                 "Max Pool Size=10;" +//Tamaño máximo del pool, define la cantidad máxima de conexiones que pueden mantenerse en el grupo.
                 "Connection Lifetime=120;" +//Duración de la conexión, define la duración máxima (en segundos) que una conexión puede permanecer en caché en el grupo.
                 "Connection Timeout=60;" +//Tiempo de espera de conexión Esta es la cantidad de tiempo (en segundos) que cada solicitud de conexión se da para conectarse a la base de datos. antes de que se levante una excepción de tiempo de espera
                 "Incr Pool Size=5;" +//Tamaño del pool de Incr, define el número de conexiones nuevas para crear cada vez que se necesitan más conexiones en el grupo de conexiones.
                 "Decr Pool Size=2;" +//Tamaño del grupo de escritorios El servicio de agrupación de conexiones intentará cerrar conexiones en caché que no están en uso por más de 3 minutos. Este atributo define el número máximo de conexiones que se pueden cerrar de una vez.
                 "Pooling=true;" +//El atributo Pooling de la conexión de la base de datos permite que la aplicación no esté creando una conexión física a la base de datos en cada solicitud que se necesite una conexión, por tal motivo la conexión se crea una vez y se mantiene establecida en la base de datos con mínimos recursos utilizados en la base de datos. Por default su valor es true y se recomienda dejarlo en ese valor.
                 "Enlist=false;" +//El atributo Enlist permite que las operaciones DML que se ejecutan mediante la conexión establecida se trabajen como parte de una transacción distribuida. Si no fuera nuestro caso, se debe colocar el valor de false ya que por default tiene el valor de true.
                 "Statement Cache Size=50;" +
                 "User ID=" + Base64Decode(usuario) + ";" +
                 "Password=" + Base64Decode(password) + ";";
            /*"User ID=" + usuario + ";" +
                 "Password=" + password + ";";*/
        }

    }
}
