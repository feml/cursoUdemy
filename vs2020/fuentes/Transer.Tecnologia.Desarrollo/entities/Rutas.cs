namespace entities
{
    public class Rutas
    {
        public int RUTA_CODIGO_NB { get; set; }  //   NOT NULL NUMBER(10)
        public int RUTA_ORIGEN_NB { get; set; }  //   NOT NULL NUMBER(5)
        public int RUTA_DESTINO_NB { get; set; }  //   NOT NULL NUMBER(5)
        public int RUTA_ESTADO_V2 { get; set; }  //   NOT NULL VARCHAR2(1)
        public int RUTA_CODMINIS_NB { get; set; }  //   NUMBER(10)
        public int RUTA_CENTROCOSTO_NB { get; set; }  //   NUMBER(3)

    }
}
