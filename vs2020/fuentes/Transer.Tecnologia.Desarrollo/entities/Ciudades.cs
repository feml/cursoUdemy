namespace entities
{
    public class Ciudades
    {
        public int CIUD_PAIS_NB { get; set; }  //   NOT NULL NUMBER(2)
        public int CIUD_DEPTO_NB { get; set; }  //   NOT NULL NUMBER(3)
        public int CIUD_CODIGO_NB { get; set; }  //   NOT NULL NUMBER(5)
        public string CIUD_DESCRIPCION_V2 { get; set; }  //   NOT NULL VARCHAR2(60)
        public string CIUD_DIVIPOLA_CH { get; set; }  //   NOT NULL CHAR(8)
    }
}
