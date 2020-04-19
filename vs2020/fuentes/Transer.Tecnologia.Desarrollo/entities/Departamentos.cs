namespace entities
{
    public class Departamentos
    {
        public int DPTO_PAIS_NB { get; set; }  //  NOT NULL NUMBER(2)
        public int DPTO_CODIGO_NB { get; set; }  //  NOT NULL NUMBER(3)
        public string DPTO_DESCRIPCION_V2 { get; set; }  //  NOT NULL VARCHAR2(20)
        public string DPTO_DANE_CODIGO_V2 { get; set; }  //  VARCHAR2(2)
        public string DPTO_DANE_ISO_V2 { get; set; }  //  VARCHAR2(3)
    }
}
