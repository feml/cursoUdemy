using SecurityScheme.Entities_Security;
using System;
using System.Text;

namespace SecurityScheme
{
    public class AccessInformationDataBase
    {
        public string Cadena { get; set; }
        public string Ip { get; set; }
        public string Sid { get; set; }
        public string Port { get; set; }
        public string Protocol { get; set; }
        public SecurityBd securityBd { get; set; }
        public AccessInformationDataBase()
        {
            securityBd = new SecurityBd(Base64Encode("SOPORTE"), Base64Encode("SOPORTE"));
            Ip = "192.168.30.119";
            Sid = "BDMILE";
            Port = "1521";
            Protocol = "TCP";
            Cadena = getCadena();
        }
        public AccessInformationDataBase(string ambiente)
        {
            securityBd = new SecurityBd(Base64Encode("SOPORTE"), Base64Encode("SOPORTE"));
            switch (Base64Decode(Base64Encode(ambiente)))
            {
                case "desarrollo":
                    {
                        Ip = "192.168.30.148";
                        Sid = "PERSONAL.transer.local";
                        break;
                    }
                case "produccion":
                    {
                        Ip = "192.168.30.119";
                        Sid = "DBMILE";
                        break;
                    }
                case "operativo":
                    {
                        Ip = "192.168.30.122";
                        Sid = "dbclon.transer.local";
                        //sid = "dbclon";
                        break;
                    }
                default:
                    {
                        Ip = "192.168.30.148";
                        Sid = "PERSONAL.transer.local";
                        break;
                    }
            }
            Port = "1521";
            Protocol = "TCP";
            Cadena = getCadena();
        }
        public AccessInformationDataBase(string ambiente, string usuario, string password)
        {
            securityBd = new SecurityBd(Base64Encode(usuario), Base64Encode(password));
            switch (Base64Decode(Base64Encode(ambiente)))
            {
                case "desarrollo":
                    {
                        Ip = "192.168.30.148";
                        Sid = "PERSONAL.transer.local";
                        break;
                    }
                case "produccion":
                    {
                        Ip = "192.168.30.119";
                        Sid = "DBMILE";
                        break;
                    }
                case "operativo":
                    {
                        Ip = "192.168.30.122";
                        Sid = "dbclon.transer.local";
                        //sid = "dbclon";
                        break;
                    }
                default:
                    {
                        Ip = "192.168.30.148";
                        Sid = "PERSONAL.transer.local";
                        break;
                    }
            }
            Port = "1521";
            Protocol = "TCP";
            Cadena = getCadena();
        }
        private string getCadena()
        {
            string cadena = string.Empty;
            StringBuilder chain = new StringBuilder();
            chain.Append("Data Source=(");
            chain.Append("DESCRIPTION=(");
            chain.Append("ADDRESS=");
            chain.Append("(PROTOCOL = " + Protocol + ")");
            chain.Append("(HOST = " + Ip + ")");
            chain.Append("(PORT = " + Port + "))");
            chain.Append("(CONNECT_DATA =");
            chain.Append("(SERVICE_NAME = " + Sid + ")");
            chain.Append("(FAILOVER_MODE = ");
            chain.Append("(TYPE = select)");
            chain.Append("(METHOD = basic)");
            chain.Append("(RETRIES = 20)");
            chain.Append("(DELAY = 15)");
            chain.Append(")));");
            chain.Append("Min Pool Size=5;");//Tamaño de grupo mínimo del pool, definimos el número mínimo de conexiones que deben mantenerse en el grupo. 
            chain.Append("Max Pool Size=100;");//Tamaño máximo del pool, define la cantidad máxima de conexiones que pueden mantenerse en el grupo.
            chain.Append("Connection Lifetime=120;");//Duración de la conexión, define la duración máxima (en segundos) que una conexión puede permanecer en caché en el grupo.
            chain.Append("Connection Timeout=60;");//Tiempo de espera de conexión Esta es la cantidad de tiempo (en segundos) que cada solicitud de conexión se da para conectarse a la base de datos. antes de que se levante una excepción de tiempo de espera
            chain.Append("Incr Pool Size=5;");//Tamaño del pool de Incr, define el número de conexiones nuevas para crear cada vez que se necesitan más conexiones en el grupo de conexiones.
            chain.Append("Decr Pool Size=1;");//Tamaño del grupo de escritorios El servicio de agrupación de conexiones intentará cerrar conexiones en caché que no están en uso por más de 3 minutos. Este atributo define el número máximo de conexiones que se pueden cerrar de una vez.
            chain.Append("Pooling=true;");//El atributo Pooling de la conexión de la base de datos permite que la aplicación no esté creando una conexión física a la base de datos en cada solicitud que se necesite una conexión, por tal motivo la conexión se crea una vez y se mantiene establecida en la base de datos con mínimos recursos utilizados en la base de datos. Por default su valor es true y se recomienda dejarlo en ese valor.
            chain.Append("Enlist=false;"); //El atributo Enlist permite que las operaciones DML que se ejecutan mediante la conexión establecida se trabajen como parte de una transacción distribuida. Si no fuera nuestro caso, se debe colocar el valor de false ya que por default tiene el valor de true.
            chain.Append("Statement Cache Size=50;");
            chain.Append("User ID=" + Base64Decode(securityBd.Usuario) + ";");
            chain.Append("Password=" + Base64Decode(securityBd.Password) + ";");
            cadena = chain.ToString();
            return cadena;
        }
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

    }
}
