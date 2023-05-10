using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using Microsoft.VisualBasic.FileIO;

namespace ProjetoFinalM2
{
    public partial class FormMap : Form
    {
        private static string loadedFileName = "";
        private static string savedCoordsFile = "";
        public int numPoints = 0;
        public int nOverlays = 0;
        public List<PointLatLng> points = new List<PointLatLng>();
        public int quantidadePontosNoPoligono = 0;
        public List<PointLatLng> trafficPoints = new List<PointLatLng>();
        public List<TimestampedCoords> loadedTSCoords = new List<TimestampedCoords>();

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();



        public FormMap()
        {
            //Permite a criacao de uma consola para fins de debugging
            AllocConsole();

            #region Colocar delimitador standard
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            #endregion

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

                    labelCurrentFileName.Text = selectFileDialog.SafeFileName;
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

        public void LoadMapFromFile()
        {
            GMapOverlay routes = new GMapOverlay("routes");
            points = new List<PointLatLng>();

            if (!String.IsNullOrEmpty(loadedFileName))
            {
                //grab coords from file
                LoadFilePoints(points);
                numPoints = points.Count;
                Console.WriteLine("Número de pontos da rota : " + numPoints);
                nOverlays = mapa.Overlays.Count;
                Console.WriteLine("O número de Overlays : " + nOverlays);
                if (mapa.Overlays.Contains(routes))
                {
                    Console.WriteLine("Contem a overlay ROTA!");
                }
                else
                {
                    Console.WriteLine("Não contem a rotita! :( ");
                }

            }
            else
            {
                MessageBox.Show("Nenhum ficheiro selecionado.");
            }

            GMapRoute route = new GMapRoute(points, "A Vehicle Route");
            route.Stroke = new Pen(Color.Green, 3);

            routes.Routes.Add(route);
            mapa.Overlays.Add(routes);

            // Força o mapa a fazer zoom para mostrar logo a rota. mapa.Refresh() não funciona.
            mapa.ZoomAndCenterRoute(route);
        }

        private void btnSaveCoord_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(loadedFileName))
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.DefaultExt = "csv";
                openFileDialog.Filter = "CSV files (*.csv)|*.csv";
                openFileDialog.CheckFileExists = false;
                openFileDialog.Title = "Abrir ou criar ficheiro CSV";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    savedCoordsFile = openFileDialog.FileName;
                    labelSaveFileName.Text = openFileDialog.SafeFileName;
                }
            }

            //  Verificar se não é null pois o utilizador pode ter cancelado o openFileDialog
            if (!String.IsNullOrEmpty(savedCoordsFile))
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

        private void buttonCarregarTransito_Click(object sender, EventArgs e)
        {
            LoadTrafficFromFile();
        }

        public void LoadTrafficFromFile()
        {
            trafficPoints = new List<PointLatLng>();
            GMapOverlay polyOverlay = new GMapOverlay("polygons");

            if (!String.IsNullOrEmpty(loadedFileName))
            {
                LoadFilePoints(trafficPoints);
                GMapPolygon polygon1 = new GMapPolygon(trafficPoints, "Traffic Area");

                polygon1.Fill = new SolidBrush(Color.FromArgb(35, Color.Black));
                polygon1.Stroke = new Pen(Color.Black, 1);

                polyOverlay.Polygons.Add(polygon1);
                mapa.Overlays.Add(polyOverlay);
                mapa.ZoomAndCenterRoute(polygon1);

                //polygon1.IsInside();

                var nVerticesPoligono = trafficPoints.Count();
                Console.WriteLine("O polígono para medir o transito tem " + nVerticesPoligono + " vértices.");

                foreach (var point in points)
                {
                    if (polygon1.IsInside(point))
                    {
                        quantidadePontosNoPoligono += 1;
                    }
                }
                Console.WriteLine("Dentro do Polígono existem " + quantidadePontosNoPoligono + " da Rota anterior.");
            }
            else
            {
                MessageBox.Show("Nenhum ficheiro carregado.");
            }
        }

        private void LoadFilePoints(List<PointLatLng> list)
        {
            if (!String.IsNullOrEmpty(loadedFileName))
            {

                using TextFieldParser parser = new TextFieldParser(loadedFileName);
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

                    try
                    {
                        var lat = Convert.ToDouble(fields[1]);
                        var lon = Convert.ToDouble(fields[2]);
                        list.Add(new PointLatLng(lat, lon));

                        var timestamp = DateTime.Parse(fields[0]);

                        loadedTSCoords.Add(new TimestampedCoords(timestamp, lat, lon));

                    }
                    catch
                    {
                        // Caso a linha esteja vazia e nao consiga produzir um double continua para a proxima
                        continue;
                    }
                }
            }
            else
            {
                MessageBox.Show("Nenhum ficheiro carregado.");
            }
        }

        private void buttonRemoveOverlays_Click(object sender, EventArgs e)
        {

            if (mapa.Overlays.Count > 0)
            {
                mapa.Overlays.Clear();
                mapa.Refresh();
            }
            numPoints = 0;
            quantidadePontosNoPoligono = 0;
            nOverlays = 0;
        }

        private void buttonPesquisarTransito_Click(object sender, EventArgs e)
        {
            DateTime start = dateTimePickerInicio.Value.Date + dateTimePickerStartTime.Value.TimeOfDay;
            DateTime end = dateTimePickerFim.Value.Date + dateTimePickerEndTime.Value.TimeOfDay;

            //Para debugging
            Console.WriteLine($"TS: {start.ToString()} {end.ToString()}");
            Console.WriteLine($"There are {loadedTSCoords.Count} points in loadedTSCoords.");

            try
            {
                //search in current routes
                GMapOverlay routesSearch = new GMapOverlay("routesSearch");
                points = new List<PointLatLng>();
                foreach (var tsCoord in loadedTSCoords)
                {
                    if (tsCoord.Timestamp.Ticks >= start.Ticks && tsCoord.Timestamp.Ticks <= end.Ticks)
                    {
                        points.Add(new PointLatLng(tsCoord.Lat, tsCoord.Lon));
                    }
                }
                GMapRoute route = new GMapRoute(points, "Coords between these dates");

                //Mudar cor consoante o Nº de pontos
                if (points.Count > 1000)
                {
                    route.Stroke = new Pen(Color.Red, 3);
                }
                else if (points.Count < 1000 && points.Count > 500)
                {
                    route.Stroke = new Pen(Color.Yellow, 3);
                }
                else
                {
                    route.Stroke = new Pen(Color.Green, 3);
                }

                routesSearch.Routes.Add(route);

                //clear overlay and draw "selected" routes
                mapa.Overlays.Clear();
                mapa.Overlays.Add(routesSearch);
                mapa.ZoomAndCenterRoute(route);

                //NOTA:loadedTSCoords -> Depois teremos de guardar os dados fora do objecto do GMAP até podermos fazer isto com pesquisas à DB. 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo correu mal!");
                Console.WriteLine(ex.Message);
            }
        }
    }

    #region Classe Vehicle
    //// Ser� a classe que guarda carater�sticas do ve�culo
    //public class Vehicle
    //{
    //    private int id { get; }
    //    private int idPath { get; }
    //    //private List<PointLatLng> coordinates;
    //}
    #endregion

    #region Classe Percurso
    //// Ser� a classe Percurso
    //public class Path
    //{
    //    private int ID { get; }
    //    private string Name { get; set; }
    //    private string Date { get; set; }
    //    private int IDVehicle { get; }
    //    private int NVehicles { get; set; }
    //    private List<PointLatLng> coordinates;
    //}
    #endregion

    
}