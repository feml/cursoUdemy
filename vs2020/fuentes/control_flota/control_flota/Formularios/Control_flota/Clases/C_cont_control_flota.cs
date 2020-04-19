using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Windows.Forms;
namespace control_flota.Formularios.Control_flota.Clases
{
    class C_cont_control_flota : Interfaces.I_cont_control_flota
    {
        private control_flota.Interfaces.I_Datos _datos;
        private DataSet _ds;
        private DataTable reportePlano;
        private DateTime tiempo1;

        public C_cont_control_flota(string usuario, string password, string cadena)
        {
            _datos = new control_flota.Clases.C_Datos(usuario, password, cadena);
            _ds = new DataSet();
            reportePlano = new DataTable();
            reportePlano.Columns.Add("CONDUCTOR", typeof(string));
            reportePlano.Columns.Add("TICKET", typeof(string));
            reportePlano.Columns.Add("PLACA", typeof(string));
            reportePlano.Columns.Add("ESTADO", typeof(string));
            reportePlano.Columns.Add("AUTORIZO", typeof(string));
            reportePlano.Columns.Add("FECREPORTE", typeof(string));
            reportePlano.Columns.Add("FECLLAMADA", typeof(string));
            reportePlano.Columns.Add("FECINGRESO", typeof(string));
            reportePlano.Columns.Add("FECSALIDA", typeof(string));
            reportePlano.Columns.Add("ORDEN CAB", typeof(string));
            reportePlano.Columns.Add("TICKET R", typeof(string));
            reportePlano.Columns.Add("PLACA TRAILER", typeof(string));
            reportePlano.Columns.Add("ORDEN TRAILER", typeof(string));
            reportePlano.Columns.Add("SECUENCIA", typeof(string));
        }
        public DataSet consulta_vehiculos_oficinas()
        {
            _ds = _datos.generico("PK_CONTROL_FLOTA.F_GET_ENTURNADOS_OFICINAS");
            return _ds;
        }
        public DataSet consulta_vehiculos_enturnados_taller()
        {
            _ds = _datos.generico(@"PK_CONTROL_FLOTA.F_GET_ENTURNADOS_TALLER");
            return _ds;
        }
        public DataSet consulta_vehiculos_solicitados_taller()
        {
            _ds = _datos.generico(@"PK_CONTROL_FLOTA.F_GET_SOLICITADO_TALLER");            
            return _ds;
        }
        public DataSet consulta_vehiculos_taller()
        {
            _ds = _datos.generico(@"PK_CONTROL_FLOTA.F_GET_VEHICULOS_TALLER");
            return _ds;
        }

        public DataSet consulta_vehiculos_atendidos_taller(DateTimePicker fecini,DateTimePicker fecfin)
        {
            _ds = _datos.generico(@"PK_CONTROL_FLOTA.F_GET_ATENDIDO_TALLER_FECHAS", fecini, fecfin);
            return _ds;
        }

        public DataSet consulta_vehiculos_siniestrados()
        {
            _ds = _datos.generico(@"PK_CONTROL_FLOTA.F_GET_SINIESTRADOS");
            return _ds;
        }
        public DataSet consulta_reparaciones_externas()
        {
            _ds = _datos.generico(@"PK_CONTROL_FLOTA.F_GET_REPARACIONESEXTERNAS");
            return _ds;
        }

        public DataSet consulta_vehiculos_despachados()
        {
            _ds = _datos.generico("PK_CONTROL_FLOTA.F_GET_DESPACHADOS");
            return _ds;
        }

        public DataSet consulta_vehiculos_parqueadero()
        {
            _ds = _datos.generico(@"PK_CONTROL_FLOTA.F_GET_VEHICULOS_PARQUEADERO");
            return _ds;
        }

        public int[] consulta_flota()
        {
             int[] c_f = new int[5];
             //c_f = _datos.registro("PK_CONTROL_INGRESO.F_GET_FLOTA");
             c_f = _datos.registro("PK_CONTROL_FLOTA.F_GET_FLOTA");
            return c_f;
        }

        public void generarArchivoPlanoNew(string select, DateTimePicker fecini, DateTimePicker fecfin)
        {
            int mes = fecini.Value.Month;
            int ano = fecini.Value.Year;
            int dia = fecini.Value.Day;
            switch (mes)
            {
                case 3:
                    {
                        mes = 12;
                        ano -= 1;
                        break;
                    }
                case 2:
                    {
                        mes = 11;
                        ano -= 1;
                        break;
                    }
                case 1:
                    {
                        mes = 10;
                        ano -= 1;
                        break;
                    }
                default:
                    {
                        mes -= 3;
                        break;
                    }
            }
            fecini.Value = new DateTime(ano, mes, dia);
            switch (select)
            {
                case "ATENDIDOS_TALLER":
                    {
                        primeraParte(fecini, fecfin);
                        segundaParte(fecini, fecfin);
                        procesarArchivoPlano(reportePlano, "atendidosTaller.txt");
                        //abrilHojaExcel(@"GrafMod2.xlsm");
                        abrilHojaExcel(@"msisIngresog.xlsm");
                        break;
                    }
                default:
                    break;
            }
        }

        public void generarArchivoPlanoonemes(string select, DateTimePicker fecini, DateTimePicker fecfin)
        {
            int mes = fecini.Value.Month;
            int ano = fecini.Value.Year;
            int dia = fecini.Value.Day;
            dia = 1;
            /*switch (mes)
            {
                case 3:
                    {
                        mes = 12;
                        ano -= 1;
                        break;
                    }
                case 2:
                    {
                        mes = 11;
                        ano -= 1;
                        break;
                    }
                case 1:
                    {
                        mes = 10;
                        ano -= 1;
                        break;
                    }
                default:
                    {
                        mes -= 3;
                        break;
                    }
            }
             */
            fecini.Value = new DateTime(ano, mes, dia);
            switch (select)
            {
                case "ATENDIDOS_TALLER":
                    {
                        primeraParte(fecini, fecfin);
                        segundaParte(fecini, fecfin);
                        procesarArchivoPlano(reportePlano, "atendidosTaller.txt");
                        //abrilHojaExcel(@"GrafMod2.xlsm");
                        abrilHojaExcel(@"msismes.xlsm");
                        break;
                    }
                default:
                    break;
            }
        }

        private void abrilHojaExcel(string direccion)
        {
            string miHoja = @"C:\orant\REPORTE_EXCEL\" + direccion;
            var aplicacionExcel = new Microsoft.Office.Interop.Excel.Application();

            aplicacionExcel.Visible = true;

            Microsoft.Office.Interop.Excel.Workbooks libros = aplicacionExcel.Workbooks;
            try
            {
                Microsoft.Office.Interop.Excel.Workbook hoja = libros.Open(miHoja);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se presento un error al momento de ejecutar la macro. descripcion del error: " + ex.Message.ToString(),"No se encontro el archivo " + miHoja, MessageBoxButtons.OK);
            }
            
        }

        public void generarArchivoPlano(string select, DateTimePicker fecini, DateTimePicker fecfin)
        {
            switch (select)
            {
                case "ATENDIDOS_TALLER":
                    {
                        primeraParte(fecini, fecfin);
                        segundaParte(fecini, fecfin);
                        procesarArchivoPlano(reportePlano, "atendidosTaller.txt");
                        break;
                    }
                default:
                    break;
            }
        }

        private void primeraParte(DateTimePicker fecini, DateTimePicker fecfin)
        {
            string tiempototal = "";
            DateTime tiempo2;
            TimeSpan total;
            int orden = 0;
            string conductor, ticket, placa, estado, autorizo, fecreporte, fecllamada, fecingreso, fecsalida, ordencab, ticketr, placatrailer, orderntrailer;
            conductor = ticket = placa = estado = autorizo = fecreporte = fecllamada = fecingreso = fecsalida = ordencab = ticketr = placatrailer = orderntrailer = "";
            tiempo1 = DateTime.Now;
            _ds = _datos.generico(@"PK_CONTROL_FLOTA.F_TALLER_REPORTE", fecini, fecfin, "A");
            //tiempo1 = DateTime.Now;
            tiempo2 = DateTime.Now;
            total = new TimeSpan(tiempo2.Ticks - tiempo1.Ticks);
            tiempototal = total.ToString();
            //MessageBox.Show("tiempo utilizada para cargar el dataset con la informacion de los registros a procesar  =>  :" + tiempototal);
            tiempo1 = DateTime.Now;
            if (_ds.Tables[0].Rows.Count > 0)
            {
                DataSet dsplano = new DataSet();
                string intaconjunto = "";
                string intasecuencianb = "";
                foreach (DataRow dr in _ds.Tables[0].Rows)
                {
                    intaconjunto = dr["INTA_CONJUNTO"].ToString();
                    dsplano = _datos.generico(@"PK_CONTROL_FLOTA.F_ATENDIDO_TALLER_REPORTE", Int32.Parse(intaconjunto), ":INTA_CONJUNTO");
                    if (dsplano.Tables[0].Rows.Count > 0)
                    {
                        DataSet dsordentrabajo = new DataSet();
                        foreach (DataRow drtaller in dsplano.Tables[0].Rows)
                        {
                            intasecuencianb = drtaller["INTA_SECUENCIA"].ToString();
                            dsordentrabajo = _datos.generico(@"PK_CONTROL_FLOTA.F_ORDENES_TALLER", Int32.Parse(intasecuencianb), ":INTA_SECUENCIA");
                            orden = 0;
                            if (dsordentrabajo.Tables[0].Rows.Count > 0)
                            {
                                orden = procesarOrdenesTrabajo(dsordentrabajo);
                            }
                            if (drtaller["ESTADO"].ToString().Length > 1)
                            {
                                if (drtaller["INTA_TIPOPLACA"].ToString() == "T")
                                {
                                    ticketr = drtaller["TICKET"].ToString(); ;
                                    placatrailer = drtaller["INTA_PLACA"].ToString();
                                    orderntrailer = orden.ToString();
                                }
                                else
                                {
                                    conductor = drtaller["CONDUCTOR"].ToString();
                                    ticket = drtaller["TICKET"].ToString();
                                    placa = drtaller["INTA_PLACA"].ToString();
                                    estado = drtaller["ESTADO"].ToString();
                                    autorizo = drtaller["AUTORIZA"].ToString();
                                    fecreporte = drtaller["INTA_FECREPORTE"].ToString();
                                    fecllamada = drtaller["INTA_FECLLAMADA"].ToString();
                                    fecingreso = drtaller["INTA_FECINGRESO"].ToString();
                                    fecsalida = drtaller["INTA_FECSALIDA"].ToString();
                                    ordencab = orden.ToString();
                                }
                            }
                        }
                        if (estado == "ATENDIDO")
                        {
                            reportePlano.Rows.Add(conductor, ticket, placa, estado, autorizo, fecreporte, fecllamada, fecingreso, fecsalida, ordencab, ticketr, placatrailer, orderntrailer, intasecuencianb);
                        }
                        conductor = ticket = placa = estado = autorizo = fecreporte = fecllamada = fecingreso = fecsalida = ordencab = ticketr = placatrailer = orderntrailer = "";
                    }
                }

            }
        }

        private void segundaParte(DateTimePicker fecini, DateTimePicker fecfin)
        {
            string tiempototal = "";
            DateTime tiempo2;
            TimeSpan total;
            int orden = 0;
            string conductor, ticket, placa, estado, autorizo, fecreporte, fecllamada, fecingreso, fecsalida, ordencab, ticketr, placatrailer, orderntrailer;
            conductor = ticket = placa = estado = autorizo = fecreporte = fecllamada = fecingreso = fecsalida = ordencab = ticketr = placatrailer = orderntrailer = "";
            tiempo1 = DateTime.Now;
            _ds = _datos.generico(@"PK_CONTROL_FLOTA.F_TALLER_REPORTE", fecini, fecfin, "I");
            //tiempo1 = DateTime.Now;
            tiempo2 = DateTime.Now;
            total = new TimeSpan(tiempo2.Ticks - tiempo1.Ticks);
            tiempototal = total.ToString();
            //MessageBox.Show("tiempo utilizada para cargar el dataset con la informacion de los registros a procesar  =>  :" + tiempototal);
            tiempo1 = DateTime.Now;
            if (_ds.Tables[0].Rows.Count > 0)
            {
                DataSet dsplano = new DataSet();
                string intaconjunto = "";
                string intasecuencianb = "";
                foreach (DataRow dr in _ds.Tables[0].Rows)
                {
                    intaconjunto = dr["INTA_CONJUNTO"].ToString();
                    dsplano = _datos.generico(@"PK_CONTROL_FLOTA.F_ATENDIDO_TALLER_REPORTE", Int32.Parse(intaconjunto), ":INTA_CONJUNTO");
                    if (dsplano.Tables[0].Rows.Count > 0)
                    {
                        DataSet dsordentrabajo = new DataSet();
                        foreach (DataRow drtaller in dsplano.Tables[0].Rows)
                        {
                            intasecuencianb = drtaller["INTA_SECUENCIA"].ToString();
                            dsordentrabajo = _datos.generico(@"PK_CONTROL_FLOTA.F_ORDENES_TALLER", Int32.Parse(intasecuencianb), ":INTA_SECUENCIA");
                            orden = 0;
                            if (dsordentrabajo.Tables[0].Rows.Count > 0)
                            {
                                orden = procesarOrdenesTrabajo(dsordentrabajo);
                            }
                            if (drtaller["ESTADO"].ToString().Length > 1)
                            {
                                if (drtaller["INTA_TIPOPLACA"].ToString() == "T")
                                {
                                    ticketr = drtaller["TICKET"].ToString(); ;
                                    placatrailer = drtaller["INTA_PLACA"].ToString();
                                    orderntrailer = orden.ToString();
                                }
                                else
                                {
                                    conductor = drtaller["CONDUCTOR"].ToString();
                                    ticket = drtaller["TICKET"].ToString();
                                    placa = drtaller["INTA_PLACA"].ToString();
                                    estado = drtaller["ESTADO"].ToString();
                                    autorizo = drtaller["AUTORIZA"].ToString();
                                    fecreporte = drtaller["INTA_FECREPORTE"].ToString();
                                    fecllamada = drtaller["INTA_FECLLAMADA"].ToString();
                                    fecingreso = drtaller["INTA_FECINGRESO"].ToString();
                                    fecsalida = drtaller["INTA_FECSALIDA"].ToString();
                                    //INTA_SECUENCIA
                                    ordencab = orden.ToString();
                                }
                            }
                        }
                        if (estado == "EN TALLER")
                        {
                            reportePlano.Rows.Add(conductor, ticket, placa, estado, autorizo, fecreporte, fecllamada, fecingreso, fecsalida, ordencab, ticketr, placatrailer, orderntrailer, intasecuencianb);
                        }
                        conductor = ticket = placa = estado = autorizo = fecreporte = fecllamada = fecingreso = fecsalida = ordencab = ticketr = placatrailer = orderntrailer = "";
                    }
                }

            }
        }
        private void procesarArchivoPlano(DataTable reportePlano, string nombre)
        {
            tiempo1 = DateTime.Now;
            //string fic = @"C:\orant\excel\" + nombre;
            string fic = @"C:\orant\REPORTE_EXCEL\" + nombre;
            string texto = "";
            System.IO.StreamWriter sw = new System.IO.StreamWriter(fic, false, System.Text.Encoding.Default);
            foreach (DataRow dr in reportePlano.Rows)
            {
                texto = dr[0].ToString() + ";" + dr[1].ToString() + ";" + dr[2].ToString() + ";" + dr[3].ToString() + ";" + dr[4].ToString() + ";" + dr[5].ToString() + ";" + dr[6].ToString() + ";" + dr[7].ToString() + ";"
                      + dr[8].ToString() + ";" + dr[9].ToString() + ";" + dr[10].ToString() + ";" + dr[11].ToString() + ";" + dr[12].ToString() + ";" + dr[13].ToString() + ";";
                sw.WriteLine(texto);
                texto = "";
            }
            sw.Close();
            DateTime tiempo2 = DateTime.Now;
            TimeSpan total = new TimeSpan(tiempo2.Ticks - tiempo1.Ticks);
            string tiempototal = total.ToString();
        }
        public int procesarOrdenesTrabajo(DataSet dsordentrabajo)
        {
            int orden = 0;
            if (dsordentrabajo.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsordentrabajo.Tables[0].Rows)
                {
                    if (dr["DETA_ESTADO"].ToString() == "A")
                    {
                        orden++;
                    }
                }
            }
            return orden;
        }
    }
}
