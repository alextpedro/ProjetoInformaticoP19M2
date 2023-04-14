using GMap.NET.MapProviders;
using GMap.NET;
using System.Linq.Expressions;
using OfficeOpenXml;
using System.Windows.Forms;
using System.Drawing.Text;
using GMap.NET.WindowsForms;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;

namespace ProjetoFinalM2
{
    public partial class FormMap : Form
    {
        private static string? loadedFileName;
        private static string? savedCoordsFile;

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        public FormMap()
        {
            //Permite a criacao de uma consola para fins de debugging
            AllocConsole();
            InitializeComponent();
        }

        private void BtnCarregarMapa_Click(object sender, EventArgs e)
        {
            LoadMapFromFile();
        }

        private void Mapa_MouseClick(object sender, MouseEventArgs e)
        {
            labelLatitude.Text = mapa.FromLocalToLatLng(e.X, e.Y).Lat.ToString();
            labelLongitude.Text = mapa.FromLocalToLatLng(e.X, e.Y).Lng.ToString();
        }


        private void BtnCarregarFicheiro_Click(object sender, EventArgs e)
        {
            using (var selectFileDialog = new OpenFileDialog())
            {
                if (selectFileDialog.ShowDialog() == DialogResult.OK)
                {
                    loadedFileName = selectFileDialog.FileName;
                    Console.WriteLine("Filename: " + loadedFileName);
                }
            }
        }

        private void LabelLatitude_Click(object sender, EventArgs e)
        {
            labelLatitude.Focus();
        }

        private void LabelLongitude_Click(object sender, EventArgs e)
        {
            labelLongitude.Focus();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (labelLatitude.ContainsFocus && e.Control && e.KeyCode == Keys.C)
                Clipboard.SetText(labelLatitude.Text);

            if (labelLongitude.ContainsFocus && e.Control && e.KeyCode == Keys.C)
                Clipboard.SetText(labelLongitude.Text);
        }



        private void Mapa_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void FormMap_Shown(object sender, EventArgs e)
        {
            //Codigo corre assim que o formulario acabar de carregar tudo

            #region Configurar o mapa:
            mapa.DragButton = MouseButtons.Left;
            mapa.CanDragMap = true;
            mapa.MapProvider = GMapProviders.OpenStreetMap;
            mapa.Position = new PointLatLng(39.734273, -8.821656);
            mapa.MinZoom = 0;
            mapa.MaxZoom = 24;
            mapa.Zoom = 18;
            mapa.AutoScroll = true;
            mapa.ShowCenter = false;
            #endregion

            labelLatitude.Text = mapa.Position.Lat.ToString();
            labelLongitude.Text = mapa.Position.Lng.ToString();
        }

        private void LoadMapFromFile()
        {
            GMapOverlay routes = new GMapOverlay("routes");
            List<PointLatLng> points = new List<PointLatLng>();

            if (loadedFileName != null)
            {
                //grab coords from file
                using (TextFieldParser parser = new TextFieldParser(loadedFileName))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");

                    bool isHeader = true;
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();

                        if (isHeader)
                        {
                            isHeader = false;
                            continue;
                        }

                        for (int i = 0; i < fields.Length; i += 2) //fields tem sempre só 2 indices
                        {
                            Console.WriteLine(fields[i] + "," + fields[i + 1]);
                            double lat = Convert.ToDouble(fields[i]);
                            double lon = Convert.ToDouble(fields[i + 1]);
                            points.Add(new PointLatLng(lat, lon));
                        }
                    }
                }
            }
            else
            {
                points.Add(new PointLatLng(39.734105, -8.821917));
                points.Add(new PointLatLng(39.734336, -8.821535));
                points.Add(new PointLatLng(39.734728, -8.820946));
            }

            GMapRoute route = new GMapRoute(points, "A Vehicle Route");
            route.Stroke = new Pen(Color.Red, 3);

            routes.Routes.Add(route);
            mapa.Overlays.Add(routes);

            // Força o mapa a fazer zoom para mostrar logo a rota. mapa.Refresh() não funciona.
            mapa.ZoomAndCenterRoute(route);
        }

        private void btnSaveCoord_Click(object sender, EventArgs e)
        {
            if (savedCoordsFile == null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.DefaultExt = "csv";
                openFileDialog.Filter = "CSV files (*.csv)|*.csv";
                openFileDialog.CheckFileExists = false;
                openFileDialog.Title = "Abrir ou criar ficheiro CSV";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    savedCoordsFile = openFileDialog.FileName;
                }
            }
            
            //  Verificar se não é null pois o utilizador pode ter cancelado o openFileDialog
            if (savedCoordsFile != null)
            {
                using (StreamWriter fileStream = File.AppendText(savedCoordsFile))
                {
                    if (new FileInfo(savedCoordsFile).Length == 0)
                    {
                        fileStream.WriteLine("Latitude,Longitude");
                    }

                    fileStream.WriteLine(labelLatitude.Text + "," + labelLongitude.Text);
                }
            }

        }
    }
}