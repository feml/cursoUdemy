using System;
namespace EntityMilenio
{
    public class Ordenes_Cargue
    {
        public double ORCA_NUMERO_NB { get; set; } //  NOT NULL NUMBER(12)
        public double ORCA_NEGOCIO_NB { get; set; } //  NUMBER(10)
        public DateTime ORCA_FECCREA_DT { get; set; } //  NOT NULL DATE
        public string ORCA_PLACA_CH { get; set; } //  NOT NULL CHAR(6)
        public double ORCA_CONDUCTOR_NB { get; set; } //  NOT NULL NUMBER(13)
        public double ORCA_NITREM_NB { get; set; } //  NOT NULL NUMBER(9)
        public double ORCA_RUTA_NB { get; set; } //  NOT NULL NUMBER(10)
        public int ORCA_OFICDESP_NB { get; set; } //  NOT NULL NUMBER(3)
        public int ORCA_PRODUCTO_NB { get; set; } //  NOT NULL NUMBER(5)
        public string ORCA_OBSERVACIONES_V2 { get; set; } //  VARCHAR2(250)
        public int ORCA_TIPOEMPAQUE_NB { get; set; } //  NOT NULL NUMBER(5)
        public int ORCA_CANTIDAD_NB { get; set; } //  NOT NULL NUMBER(7)
        public string ORCA_VOLUMEN_NB { get; set; } //  VARCHAR2(1)
        public decimal ORCA_PESOKGS_NB { get; set; } //  NOT NULL NUMBER(7,2)
        public string ORCA_ESTADO_V2 { get; set; } //  NOT NULL VARCHAR2(1)
        public string ORCA_TRAILER_CH { get; set; } //  CHAR(6)
        public int ORCA_CAMINO_NB { get; set; } //  NOT NULL NUMBER(5)
        public int ORCA_SECUENCIA_NB { get; set; } //  NUMBER(5)
        public int ORCA_PLANTAREMITE_NB { get; set; } //  NUMBER(5)
        public int ORCA_PLANTARECIBE_NB { get; set; } //  NUMBER(5)
        public double ORCA_CEDRELEVO_NB { get; set; } //  NUMBER(13)
        public string ORCA_TIPOVIAJE_V2 { get; set; } //  VARCHAR2(1)
        public double ORCA_USUCREA_NB { get; set; } //  NUMBER(13)
        public DateTime ORCA_FECANULA_DT { get; set; } //  DATE
        public double ORCA_USUANULA_NB { get; set; } //  NUMBER(13)
        public int ORCA_CAUSANULA_NB { get; set; } //  NUMBER(3)
        public int ORCA_CLIENTEPAGA_NB { get; set; } //  NUMBER(5)
        public double ORCA_CELULAR_NB { get; set; } //  NUMBER(15)
        public double ORCA_CAMPO1_NB { get; set; } //  NUMBER(20)
        public string ORCA_CAMPO2_NB { get; set; } //  VARCHAR2(50)
        public string ORCA_OPCIONCREA_V2 { get; set; } //  VARCHAR2(10)
        public double ORCA_GRUPORUTA_NB { get; set; } //  NUMBER(10)
        public int ORCA_CLIENTEREC_NB { get; set; } //  NUMBER(5)
        public double ORCA_CAMPO3_NB { get; set; } //  NUMBER(15)
        public string ORCA_CAMPO4_V2 { get; set; } //  VARCHAR2(70)
        public string ORCA_IDMINISTERIO_V2 { get; set; } //  VARCHAR2(25)

    }
}
