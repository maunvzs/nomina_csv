using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace EnviaNomina
{
    public partial class frmCargaDatos : Form
    {
        public frmCargaDatos()
        {
            InitializeComponent();
        }

        private void btncargar_Click(object sender, EventArgs e)
        {

            if (!File.Exists(txtruta.Text)) { MessageBox.Show("El archivo no existe en la ruta especificada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            pbarcarga.Value = 0;
            backgroundWorker1.RunWorkerAsync();
            //Aqui se puede validar que las llaves estén correctas y que además exista conexión a internet
            pbarcarga.PerformStep();
            if (backgroundWorker1.IsBusy)
                enableOrDisable(false);
            //var json = JsonConvert.SerializeObject(LeerCsv(txtruta.Text));
        }

        /*
        //var respuesta = Peticion(JsonConvert.SerializeObject(LeerCsv(txtruta.Text)));
        //if (respuesta.Respuesta != null)
        //{
        //    var validacionRespuesta = JsonConvert.DeserializeAnonymousType(respuesta.Respuesta, new { success = false, message = string.Empty });
        //    MessageBox.Show(validacionRespuesta.message);
        //}

        //backgroundWorker1.RunWorkerAsync();



        //Para escribir el archivo csv a un txt plano.
        
            System.IO.File.WriteAllText(@"C:\Users\ventas2\Desktop\JSON.txt", o);
        

        //Para leer la información directamente del grid y serializarla
        
        string[] rowdata;
        var rowdatalist = new List<string[]>();
        var sb = new StringBuilder();
        foreach (DataGridViewRow row in griddatos.Rows)
        {
            var cells = row.Cells.Cast<DataGridViewCell>();
            string line;
            line = string.Join(",", cells.Select(cell => cell.Value).ToArray());
            rowdata = line.Split(',');
            rowdatalist.Add(rowdata);
        }
        var o = JsonConvert.SerializeObject(Data(rowdatalist));
        
        //System.IO.File.WriteAllText(@"C:\Users\ventas2\Desktop\JSON.txt", o); //Para testear
        //}
        */

        private void enableOrDisable(bool param)
        {
            btncargar.Enabled = param;
            btnexaminar.Enabled = param;
            configuracionToolStripMenuItem.Enabled = param;
            acercaDeToolStripMenuItem.Enabled = param;
        }

        private void btnexaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog File = new OpenFileDialog();
            File.Filter = "Archivos separados por coma (*.csv)|*.csv";
            File.Title = "Abrir";

            if (File.ShowDialog() == DialogResult.OK)
            {
                while (griddatos.Rows.Count != 0) { griddatos.Rows.RemoveAt(0); }
                try {
                    var msg = validarFormato(new StreamReader(@"" + File.FileName));
                    if (msg == string.Empty)
                    {
                        var timer = new System.Diagnostics.Stopwatch();
                        timer.Start();

                        txtruta.Text = File.FileName;
                        int empcount = 0;
                        string[] row;
                        griddatos.ColumnCount = 36;
                        using (StreamReader sr = new StreamReader(@"" + File.FileName, Encoding.GetEncoding("iso-8859-1")))
                        {
                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                row = line.Split(',');
                                if (row[0] == "empleado") empcount++;
                                griddatos.Rows.Add(row);
                            }
                        }
                        lblnumempleados.Text = "Número de empleados: " + empcount.ToString();
                        timer.Stop();
                    }
                    else
                    {
                        txtruta.Text = string.Empty;
                        griddatos.ColumnCount = 0;
                        lblnumempleados.Text = string.Empty;
                        MessageBox.Show(msg);
                    }
                        
                        
                }
                catch (System.IO.IOException ex) 
                {
                    MessageBox.Show("Error: " + ex.Message + " Cierre el archivo y vuelva a intentarlo");
                }

            }
            
            File.Dispose();
        }

        private string validarFormato(StreamReader sr)
        {
            string line;
            string[] row;
            string invalidmsg = string.Empty;
            var list = new List<string>();
            int empleados = 0, nomina = 0, per = 0, ded = 0;
            while ((line = sr.ReadLine()) != null)
            {
                row = line.Split(',');
                list.Add(row[0]);
            }
            if (list.Count > 0)
            {
                int indice = 0;
                bool[] arreglo = { false, false, false, false };
                foreach (var i in list)
                {
                    indice++;
                    bool bnomina = false, bemp = false, bper = false, bded = false;
                    switch (i)
                    {
                        case "nomina":
                            nomina++;
                            bnomina = true;
                            break;
                        case"empleado":
                            empleados++;
                            bemp = true;
                            break;
                        case "percepcion_empleado":
                            per++;
                            bper = true;
                            break;
                        case "deduccion_empleado":
                            ded++;
                            bded = true;
                            break;
                        default:
                            if (indice == list.Count)
                            {
                                invalidmsg = "El archivo no tiene el formato correcto, se encontró: " + (string.IsNullOrWhiteSpace(i) ? "una línea vacía" : i) + " inesperado/a";
                                //goto terminar;
                            }
                            continue;
                            //invalidmsg = "El archivo no tiene el formato correcto, se encontró: "+ (string.IsNullOrWhiteSpace(i) ? "una línea vacía" : i) +" inesperado/a";
                    }

                    if (nomina > 1)
                        { invalidmsg = "Sólo se permite enviar una nómina por archivo"; break; }
                    if (empleados > 50)
                        { invalidmsg = "El archivo excede el máximo número de empleados permitido (50)"; break; }

                    //Si es nómina.. (Primer flujo posible) Si no se cumple, avanza a "Segunda sección"
                    if (bnomina)
                    {
                        arreglo[0] = true;
                        continue;
                    }
                    //Si es empleado.. (Segundo flujo posible)
                    else if (arreglo[0] && bemp && (!arreglo[2] || !arreglo[3]) && !arreglo[1])
                    {
                        arreglo[1] = true;
                        continue;
                    }
                    //Si es percepcion o deducción.. (Tercer flujo posible)
                    else if (arreglo[1] && (bper || bded))
                    {
                        arreglo[2] = bper;
                        arreglo[3] = bded;
                    }
                    //Se debe evaluar si es el último empleado antes de continuar el flujo.
                    else if (indice == list.Count && bemp)
                    {
                        invalidmsg = "Al menos un empleado no contiene percepcion o deduccion";
                        break;
                    }
                    //Si no lo es, (el último empleado) continúa.. (Cuarto flujo posible)
                    else if (bemp && (arreglo[2] || arreglo[3]))
                    {
                        arreglo[2] = false;
                        arreglo[3] = false;
                    }
                    //Segunda sección: A partir de este punto no hay flujo posible.
                    //Si no se encontró una nómina, entonces..
                    else if (!arreglo[0] && !bnomina)
                    {
                        invalidmsg = "El archivo no contiene ninguna nomina";
                        break;
                    }
                    //Si existe una nómina pero no un empleado..
                    else if (arreglo[0] && !bemp)
                    {
                        invalidmsg = "No se encontró un empleado después de la línea de nómina";
                        break;
                    }
                    //Si existe un empleado pero no una percepción o deducción..
                    else if (!bemp || (!arreglo[2] || !arreglo[3]))
                    {
                        invalidmsg = "Al menos un empleado no contiene percepcion o deduccion";
                        break;
                    }
                    //Si hay una nómina y no es un empleado..
                    else if (arreglo[0] && !bemp && !arreglo[1])
                    {
                        invalidmsg = "No se encontró un empleado después de la línea de nómina";
                        break;
                    }
                }
            }
            else
                return "El archivo se encuentra vacío";

            sr.Dispose();
            return invalidmsg;
        }

        private List<Nomina> LeerCsv(string ruta)
        {
            StringBuilder sb = new StringBuilder();

            var data = new List<Nomina>();
            var nomina = new List<Nomina>();
            var empleado = new List<Empleados>();
            var percepcion = new List<Percepcion>();
            var deduccion = new List<Deduccion>();

            int nomaux = 0, empaux = 0, peraux = 0, dedaux = 0;

            string[] row;

            try
            {
                using (StreamReader sr = new StreamReader(@"" + ruta, Encoding.GetEncoding("iso-8859-1")))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        row = line.Split(',');
                        bool nom = false, emp = false, per = false, ded = false, nuevanomina = false, nuevoempleado = false;
                        row.RemoveAccents();
                        if (row[0] == "nomina")
                        {
                            nomina.Add(new Nomina
                            {
                                Nombre = row[1],
                                FechaPago = row[2].FormatDate("yyyy-MM-dd"),
                                FechaInicialPago = row[3].FormatDate("yyyy-MM-dd"),
                                FechaFinalPago = row[4].FormatDate("yyyy-MM-dd"),
                                NumDiasPagados = row[5],
                                Moneda = row[6],
                                Rate = row[7],
                                SucursalId = row[8],
                                Serie = row[9],
                                CondicionDePago = row[10],
                                MetodoDePago = row[11],
                                FormaDePago = row[12],
                                Decimales = row[13],
                                Empleados = new List<Empleados>()
                            });
                            nom = true;
                        }
                        else if (row[0] == "empleado")
                        {
                            empleado.Add(new Empleados
                            {
                                Cantidad = row[1],
                                Unidad = row[2],
                                Descripcion = row[3],
                                ValorUnitario = row[4],
                                Subtotal = row[5],
                                Descuento = row[6],
                                MotivoDescuento = row[7],
                                ISR = row[8],
                                Total = row[9],
                                NombreEmpleado = row[10],
                                ApellidoPaterno = row[11],
                                ApellidoMaterno = row[12],
                                RFC = row[13],
                                CURP = row[14],
                                Calle = row[15],
                                NumeroExt = row[16],
                                Colonia = row[17],
                                CP = row[18],
                                Municipio = row[19],
                                Estado = row[20],
                                Pais = row[21],
                                Puesto = row[22],
                                TipoContrato = row[23],
                                TipoJornada = row[24],
                                NumEmpleado = row[25],
                                NumSeguro = row[26],
                                PeriodicidadPago = row[27],
                                SalarioBase = row[28],
                                SalarioDiario = row[29],
                                InicioRelacionLaboral = row[30] == string.Empty? string.Empty : row[30].FormatDate("yyyy-MM-dd"),
                                Regimen = row[31],
                                RiesgoPuesto = row[32],
                                Departamento = row[33],
                                NumCuenta = row[34],
                                Email = row[35],
                                Percepcion = new List<Percepcion>(),
                                Deduccion = new List<Deduccion>()
                            });
                            emp = true;
                        }
                        else if (row[0] == "percepcion_empleado")
                        {
                            percepcion.Add(new Percepcion
                            {
                                ImporteGravado = row[1],
                                ImporteExterno = row[2],
                                ImporteTotal = row[3],
                                Clave = row[4],
                                ClaveInterna = row[5],
                                DescripcionInterna = row[6],
                                HorasExtra = row[7],
                                Dias = row[8],
                                TipoHoras = row[9],
                                ImportePagado = row[10],
                            });
                            per = true;
                        }
                        else if (row[0] == "deduccion_empleado")
                        {
                            deduccion.Add(new Deduccion
                            {
                                ImporteGravado = row[1],
                                ImporteExterno = row[2],
                                ImporteTotal = row[3],
                                Clave = row[4],
                                ClaveInterna = row[5],
                                DescripcionInterna = row[6],
                                Dias = row[7],
                                ClaveIncapacidad = row[8],
                                Descuento = row[9]
                            });
                            ded = true;
                        }

                        if (nom)
                        {
                            data.Add(nomina[nomaux]);
                            nomaux++;
                            if (nomaux > 1) nuevanomina = true;
                        }
                        else if (emp)
                        {
                            data[nomaux - 1].Empleados.Add(empleado[empaux]);
                            empaux++;
                            nuevoempleado = empaux > 1 ? true : false;
                        }
                        else if (per)
                        {
                            data[nomaux - 1].Empleados[empaux - 1].Percepcion.Add(percepcion[peraux]);
                            peraux++;
                        }
                        else if (ded)
                        {
                            data[nomaux - 1].Empleados[empaux - 1].Deduccion.Add(deduccion[dedaux]);
                            dedaux++;
                        }

                        if (nuevanomina)
                        {
                            empleado = new List<Empleados>();
                            empaux = 0;
                        }
                        if (nuevoempleado)
                        {
                            percepcion = new List<Percepcion>();
                            peraux = 0;
                            deduccion = new List<Deduccion>();
                            dedaux = 0;
                        }
                    }
                }
            }
            catch (System.FormatException fe)
            {
                MessageBox.Show(fe.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return data;
        }

        private Peticion Peticion(object nomina)
        {
            StringBuilder datos = new StringBuilder();
            datos.Append("data[metodo]=emitir_nomina&");
            datos.Append("data[userg]=" + Settings.App.Default.usuario + "&");
            datos.Append("data[sucursalg]=" + Settings.App.Default.sucursal + "&");
            datos.Append("data[Nomina]=" + nomina);
            Peticion operacion = new Peticion(datos.ToString(), Settings.App.Default.url);
            return operacion;
        }

        private object Data(List<string[]> list)
        {
            var data = new List<Nomina>();
            //var nomina = new List<Nomina>();
            //var empleado = new List<Empleados>();
            //var percepcion = new List<Percepcion>();
            //var deduccion = new List<Deduccion>();

            //int nomaux = 0, empaux = 0, peraux = 0, dedaux = 0;
            //foreach (string[] row in list)
            //{
            //    bool nom = false, emp = false, per = false, ded = false;
            //    if (row[0] == "nomina")
            //    {
            //        nomina.Add(new Nomina
            //        {
            //            Nombre = row[1],
            //            FechaPago = row[2],
            //            FechaInicialPago = row[3],
            //            FechaFinalPago = row[4],
            //            NumDiasPagados = row[5],
            //            Moneda = row[6],
            //            Rate = row[7],
            //            SucursalId = row[8],
            //            Serie = row[9],
            //            CondicionDePago = row[10],
            //            MetodoDePago = row[11],
            //            FormaDePago = row[12],
            //            Decimales = row[13],
            //            Empleados = new List<Empleados>()
            //        });
            //        nom = true;
            //    }
            //    else if (row[0] == "empleado")
            //    {
            //        empleado.Add(new Empleados
            //        {
            //            Cantidad = row[1],
            //            Unidad = row[2],
            //            Descripcion = row[3],
            //            ValorUnitario = row[4],
            //            Subtotal = row[5],
            //            Descuento = row[6],
            //            MotivoDescuento = row[7],
            //            ISR = row[8],
            //            Total = row[9],
            //            NombreEmpleado = row[10],
            //            ApellidoPaterno = row[11],
            //            ApellidoMaterno = row[12],
            //            RFC = row[13],
            //            CURP = row[14],
            //            Calle = row[15],
            //            NumeroExt = row[16],
            //            Colonia = row[17],
            //            CP = row[18],
            //            Municipio = row[19],
            //            Estado = row[20],
            //            Pais = row[21],
            //            Puesto = row[22],
            //            TipoContrato = row[23],
            //            TipoJornada = row[24],
            //            NumEmpleado = row[25],
            //            NumSeguro = row[26],
            //            PeriodicidadPago = row[27],
            //            SalarioBase = row[28],
            //            SalarioDiario = row[29],
            //            InicioRelacionLaboral = row[30],
            //            Regimen = row[31],
            //            RiesgoPuesto = row[32],
            //            Departamento = row[33],
            //            Percepcion = new List<Percepcion>(),
            //            Deduccion = new List<Deduccion>()
            //        });
            //        emp = true;
            //    }
            //    else if (row[0] == "percepcion_empleado")
            //    {
            //        percepcion.Add(new Percepcion
            //        {
            //            ImporteGravado = row[1],
            //            ImporteExterno = row[2],
            //            ImporteTotal = row[3],
            //            Clave = row[4],
            //            ClaveInterna = row[5],
            //            DescripcionInterna = row[6],
            //            HorasExtra = row[7],
            //            Dias = row[8],
            //            TipoHoras = row[9],
            //            ImportePagado = row[10],
            //        });
            //        per = true;
            //    }
            //    else if (row[0] == "deduccion_empleado")
            //    {
            //        deduccion.Add(new Deduccion
            //        {
            //            ImporteGravado = row[1],
            //            ImporteExterno = row[2],
            //            ImporteTotal = row[3],
            //            Clave = row[4],
            //            ClaveInterna = row[5],
            //            DescripcionInterna = row[6],
            //            Dias = row[7],
            //            TipoIncapacidad = row[8],
            //            Descuento = row[9]
            //        });
            //        ded = true;
            //    }

            //    if (nom)
            //    {
            //        data.Add(nomina[nomaux]);
            //        nomaux++;
            //    }
            //    else if (emp)
            //    {
            //        data[nomaux - 1].Empleados.Add(empleado[empaux]);
            //        empaux++;
            //    }
            //    else if (per)
            //    {
            //        data[nomaux - 1].Empleados[empaux - 1].Percepcion.Add(percepcion[peraux]);
            //        peraux++;
            //    }
            //    else if (ded)
            //    {
            //        data[nomaux - 1].Empleados[empaux - 1].Deduccion.Add(deduccion[dedaux]);
            //    }
            //}
            return data;
        }


        private void configuracionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var c = new frmConfiguracion().Get;
            c.StartPosition = FormStartPosition.Manual;
            c.Location = new Point(this.Location.X + (this.Width - c.Width) / 2, this.Location.Y + (this.Height - c.Height) / 2);
            c.Show();
        }

        private void griddatos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            var IdEstado = griddatos.Rows[e.RowIndex].Cells[20].Value.ToString();

            if (IdEstado != string.Empty)
            {
                var cbo = new DataGridViewComboBoxCell();
                var estados = new List<Estado>();
                estados.Add(new Estado { Id = 1, Nombre = "Aguascalientes" });
                estados.Add(new Estado { Id = 2, Nombre = "Baja California" });
                estados.Add(new Estado { Id = 3, Nombre = "Baja California Sur" });
                estados.Add(new Estado { Id = 4, Nombre = "Campeche" });

                cbo.DisplayMember = "Nombre";
                cbo.ValueMember = "Id";
                cbo.DataSource = estados;

                cboEstado.DisplayMember = "Nombre";
                cboEstado.ValueMember = "Id";
                cboEstado.DataSource = estados;

                griddatos.Rows[e.RowIndex].Cells[20] = cbo;
            }
        }

        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in griddatos.Rows)
            {
                if (row.Cells[0].Value as string == "empleado")
                    row.Cells[20].Value = cboEstado.SelectedValue;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var timer = new System.Diagnostics.Stopwatch();
                var list = LeerCsv(txtruta.Text);
                if (list.Count == 0) return;
                var json = JsonConvert.SerializeObject(list);
                timer.Start();
                var arr = Peticion(json);
                timer.Stop();

                //Logger.Initialize(@"C:\Users\ventas2\Desktop\log.txt");
                //Logger.set.Debug("thishe first log message");

                if (arr.Respuesta != null)
                {
                    var validacionRespuesta = JsonConvert.DeserializeAnonymousType(arr.Respuesta, new { success = false, message = string.Empty });
                    backgroundWorker1.ReportProgress(0);
                    MessageBox.Show(validacionRespuesta.message);
                    //MessageBox.Show("Segundos: " + (timer.ElapsedMilliseconds /1000).ToString());
                }
                else
                {
                    if (!arr.Validacion.Valido)
                    {
                        MessageBox.Show(arr.Validacion.Mensaje +" "+ arr.Validacion.Detalle);
                        //MessageBox.Show("Milisegundos: " + timer.ElapsedMilliseconds.ToString());
                    }
                }
                //Thread.Sleep(3000);
                //backgroundWorker1.ReportProgress(0);
                //MessageBox.Show("success");
            }
            catch (Newtonsoft.Json.JsonReaderException ex)
            {
                MessageBox.Show("Error: " + ex.Message + " Error al deserializar respuesta del servidor");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            //var respuesta = Peticion(JsonConvert.SerializeObject(LeerCsv(txtruta.Text)));
            //if (respuesta.Respuesta != null)
            //{
            //    //var validacionRespuesta = JsonConvert.DeserializeAnonymousType(respuesta.Respuesta, new { success = false, message = string.Empty });
            //    //mensaje = validacionRespuesta.message;

            //    //var o = JsonConvert.DeserializeObject<Mensaje>(respuesta.Respuesta);
            //}
            //else
            //{

            //}


            //var objs = JsonConvert.SerializeObject(LeerCsv(txtruta.Text));
            //ThreadStart deleg = delegate { Peticion(objs); };
            //Thread t = new Thread(deleg);
            //t.Start();

            //for (int i = 1; i <= 100; i++)
            //{
            //    System.Threading.Thread.Sleep(30);
            //    //Report progress.
            //    backgroundWorker1.ReportProgress(i);
            //}
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbarcarga.PerformStep();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbarcarga.PerformStep();
            Thread.Sleep(100);
            pbarcarga.Value = 0;
            enableOrDisable(true);
        }

        private void griddatos_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            griddatos.Columns[e.Column.Index].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var o = new frmAcercaDe().Get;
            o.StartPosition = FormStartPosition.Manual;
            o.Location = new Point(this.Location.X + (this.Width - o.Width) / 2, this.Location.Y + (this.Height - o.Height) / 2);
            o.Show();
        }
    }
}
