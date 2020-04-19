using System;
namespace EntityMilenio
{
    public class Viajes
    {
        public string VIAJ_NOPLANILLA_V2 { get; set; } //   NOT NULL VARCHAR2(9)
        public double VIAJ_NEGOCIO_NB { get; set; } //   NOT NULL NUMBER(10)
        public double VIAJ_ORDCARGUE_NB { get; set; } //   NUMBER(12)
        public DateTime VIAJ_FECVIAJE_DT { get; set; } //   NOT NULL DATE
        public string VIAJ_PLACA_CH { get; set; } //   NOT NULL CHAR(6)
        public int VIAJ_OFDESPACHA_NB { get; set; } //   NOT NULL NUMBER(3)
        public int VIAJ_CLASEVEHI_NB { get; set; } //   NOT NULL NUMBER(3)
        public string VIAJ_ESTADO_V2 { get; set; } //   NOT NULL VARCHAR2(1)
        public int VIAJ_MONEDA_NB { get; set; } //   NOT NULL NUMBER(5)
        public string VIAJ_NODTAI_NB { get; set; } //   VARCHAR2(12)
        public int VIAJ_MOTONAVE_NB { get; set; } //   NUMBER(5)
        public double VIAJ_CONDUCTOR_NB { get; set; } //   NOT NULL NUMBER(13)
        public double VIAJ_PROPIETARIO_NB { get; set; } //   NOT NULL NUMBER(13)
        public double VIAJ_POSEEDOR_NB { get; set; } //   NOT NULL NUMBER(13)
        public DateTime VIAJ_FECANULA_DT { get; set; } //   DATE
        public string VIAJ_TIPO_V2 { get; set; } //   NOT NULL VARCHAR2(1)
        public int VIAJ_CANTVIAJES_NB { get; set; } //   NOT NULL NUMBER(3)
        public decimal VIAJ_VALORCARGA_NB { get; set; } //   NOT NULL NUMBER(14,4)
        public string VIAJ_OBSERVACIONES_V2 { get; set; } //   VARCHAR2(250)
        public string VIAJ_TRAILER_CH { get; set; } //   CHAR(6)
        public string VIAJ_CUMLIQ_V2 { get; set; } //   NOT NULL VARCHAR2(1)
        public string VIAJ_FACTURADA_V2 { get; set; } //   NOT NULL VARCHAR2(1)
        public string VIAJ_SINIESTROS_V2 { get; set; } //   NOT NULL VARCHAR2(1)
        public string VIAJ_DOCTRANSPORTE_V2 { get; set; } //   VARCHAR2(20)
        public double VIAJ_CEDRELEVO_NB { get; set; } //   NUMBER(13)
        public string VIAJ_TIPOVIAJE_V2 { get; set; } //   VARCHAR2(1)
        public string VIAJ_DOCEXTERNO_V2 { get; set; } //   VARCHAR2(20)
        public double VIAJ_USUCREA_NB { get; set; } //   NUMBER(13)
        public double VIAJ_USUANULA_NB { get; set; } //   NUMBER(13)
        public decimal VIAJ_PORDCTOCOMER_NB { get; set; } //   NUMBER(14,4)
        public decimal VIAJ_PORMARGENINT_NB { get; set; } //   NUMBER(14,4)
        public double VIAJ_CELULAR_NB { get; set; } //   NUMBER(15)
        public double VIAJ_FIN_NB { get; set; } //   NUMBER(15)
        public double VIAJ_USUFIN_NB { get; set; } //   NUMBER(15)
        public string VIAJ_CAUSANULA_NB { get; set; } //   NUMBER(3)
        public double VIAJ_CAMPO1_NB { get; set; } //   NUMBER(20)
        public double VIAJ_CAMPO2_NB { get; set; } //   NUMBER(20)
        public string VIAJ_CAMPO3_V2 { get; set; } //   VARCHAR2(50)
        public string VIAJ_CAMPO4_V2 { get; set; } //   VARCHAR2(50)
        public int VIAJ_TIPMANIFIESTO_NB { get; set; } //   NUMBER(3)
        public DateTime VIAJ_FECENTREGA_DT { get; set; } //   DATE
        public string VIAJ_CONSMANIFIESTO_NB { get; set; } //   VARCHAR2(12)
        public string VIAJ_IDMINISTERIO_V2 { get; set; } //   VARCHAR2(25)

    }
}
