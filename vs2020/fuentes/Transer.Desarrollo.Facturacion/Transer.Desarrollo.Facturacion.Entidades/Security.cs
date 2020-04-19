namespace Transer.Desarrollo.Facturacion.Entidades
{
    public class Security
    {
        public string _Usuario { get; set; }
        public string _Password { get; set; }
        public string _Cadena { get; set; }
        public string _Ip { get; set; }
        public string _Sid { get; set; }
        public Security(string usuario, string password)
        {
            _Usuario = usuario;
            _Password = password;
            inicialization();
        }

        private void inicialization()
        {
            _Ip = "192.168.30.148";
            _Sid = "PERSONAL.transer.local";
            _Cadena = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=" + _Ip + ")(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=" + _Sid + ")(FAILOVER_MODE=(TYPE=select)(METHOD=basic)(RETRIES=20)(DELAY=15))));";
            _Cadena += "Min Pool Size=2;" +//Tamaño de grupo mínimo del pool, definimos el número mínimo de conexiones que deben mantenerse en el grupo. 
                 "Max Pool Size=8;" +//Tamaño máximo del pool, define la cantidad máxima de conexiones que pueden mantenerse en el grupo.
                 "Connection Lifetime=60;" +//Duración de la conexión, define la duración máxima (en segundos) que una conexión puede permanecer en caché en el grupo.
                 "Connection Timeout=60;" +//Tiempo de espera de conexión Esta es la cantidad de tiempo (en segundos) que cada solicitud de conexión se da para conectarse a la base de datos. antes de que se levante una excepción de tiempo de espera
                 "Incr Pool Size=1;" +//Tamaño del pool de Incr, define el número de conexiones nuevas para crear cada vez que se necesitan más conexiones en el grupo de conexiones.
                 "Decr Pool Size=1;" +//Tamaño del grupo de escritorios El servicio de agrupación de conexiones intentará cerrar conexiones en caché que no están en uso por más de 3 minutos. Este atributo define el número máximo de conexiones que se pueden cerrar de una vez.
                 "User ID=" + _Usuario + ";" +
                 "Password=" + _Password + ";";

        }
    }
}