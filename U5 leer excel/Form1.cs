using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.IO;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace U5_leer_excel
{
    public partial class Form1 : Form
    {

        private readonly string RUTA_CARPETA = @"C:\Users\abner\source\repos\U5 leer excel\U5 leer excel\Excel";

        public Form1()
        {
            InitializeComponent();
            ConfigurarListViews();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarArchivosExcel();
        }

        private void ConfigurarListViews()
        {
            listViewArchivos.View = View.Details;
            listViewArchivos.Columns.Add("Archivos Excel", 250);
            listViewArchivos.FullRowSelect = true;

            listViewLineas.View = View.Details;
            listViewLineas.FullRowSelect = true;
            listViewLineas.GridLines = true;
        }

        private void CargarArchivosExcel()
        {
            if (!Directory.Exists(RUTA_CARPETA))
            {
                MessageBox.Show("No se encontró la carpeta:\n" + RUTA_CARPETA);
                return;
            }

            var archivos = Directory.GetFiles(RUTA_CARPETA, "*.xlsx");
            listViewArchivos.Items.Clear();

            foreach (var archivo in archivos)
            {
                listViewArchivos.Items.Add(Path.GetFileName(archivo));
            }
        }

        private void btnLeerArchivo_Click_1(object sender, EventArgs e)
        {
            if (listViewArchivos.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecciona un archivo de la lista");
                return;
            }

            string nombreArchivo = listViewArchivos.SelectedItems[0].Text;
            string rutaCompleta = Path.Combine(RUTA_CARPETA, nombreArchivo);

            MostrarDatosExcelEnListView(rutaCompleta);
        }

        private void MostrarDatosExcelEnListView(string rutaArchivo)
        {
            try
            {
                listViewLineas.Items.Clear();
                listViewLineas.Columns.Clear();

                using (var workbook = new XLWorkbook(rutaArchivo))
                {
                    var worksheet = workbook.Worksheet(1);
                    var range = worksheet.RangeUsed();

                    if (range == null)
                    {
                        MessageBox.Show("El archivo está vacío.");
                        return;
                    }

                    // Agregar columnas (encabezados)
                    foreach (var celda in range.FirstRow().Cells())
                    {
                        string encabezado = string.IsNullOrWhiteSpace(celda.GetString())
                            ? $"Columna {celda.Address.ColumnNumber}"
                            : celda.GetString();

                        listViewLineas.Columns.Add(encabezado, 100);
                    }

                    // Agregar filas (datos)
                    foreach (var fila in range.RowsUsed().Skip(1))
                    {
                        var item = new ListViewItem(fila.Cell(1).GetString());
                        for (int i = 2; i <= range.ColumnCount(); i++)
                        {
                            item.SubItems.Add(fila.Cell(i).GetString());
                        }
                        listViewLineas.Items.Add(item);
                    }

                    // Autoajustar columnas
                    foreach (ColumnHeader col in listViewLineas.Columns)
                        col.Width = -2;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer el archivo:\n" + ex.Message);
            }
        }

        private void listViewArchivos_DoubleClick(object sender, EventArgs e)
        {
            btnLeerArchivo_Click_1(sender, e);
        }
    }
}