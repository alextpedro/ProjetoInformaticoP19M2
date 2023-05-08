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
using System.Collections;
using System.Windows.Documents;
using static GMap.NET.Entity.OpenStreetMapRouteEntity;
using System.Globalization;
using Avalonia;

namespace ProjetoFinalM2 {
    public partial class FormMap : Form {
        private static string? loadedFileName;
        private static string? savedCoordsFile;
        public int numPoints = 0;
        public int nOverlays = 0;
        public List<PointLatLng> points;
        public int quantidadePontosNoPoligono = 0;
        public List<PointLatLng> trafficPoints;
        public int numRotas = 0;

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        public FormMap() {
            //Permite a criacao de uma consola para fins de debugging
            AllocConsole();

            #region Colocar delimitador standard
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            #endregion

            InitializeComponent();
        }

        private void BtnCarregarMapa_Click(object sender, EventArgs e) {
            LoadMapFromFile();
        }

        private void Mapa_MouseClick(object sender, MouseEventArgs e) {
            labelLatitude.Text = mapa.FromLocalToLatLng(e.X, e.Y).Lat.ToString();
            labelLongitude.Text = mapa.FromLocalToLatLng(e.X, e.Y).Lng.ToString();
        }

        private void BtnCarregarFicheiro_Click(object sender, EventArgs e) {
            using (var selectFileDialog = new OpenFileDialog()) {
                if (selectFileDialog.ShowDialog() == DialogResult.OK) {
                    loadedFileName = selectFileDialog.FileName;
                    Console.WriteLine("******************************************");
                    Console.WriteLine("Filename: " + loadedFileName);
                    Console.WriteLine("******************************************");

                    labelCurrentFileName.Text = selectFileDialog.SafeFileName;
                }
            }
        }

        private void LabelLatitude_Click(object sender, EventArgs e) {
            labelLatitude.Focus();
        }

        private void LabelLongitude_Click(object sender, EventArgs e) {
            labelLongitude.Focus();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) {
            if (labelLatitude.ContainsFocus && e.Control && e.KeyCode == Keys.C)
                Clipboard.SetText(labelLatitude.Text);

            if (labelLongitude.ContainsFocus && e.Control && e.KeyCode == Keys.C)
                Clipboard.SetText(labelLongitude.Text);
        }

        private void Mapa_MouseHover(object sender, EventArgs e) {

        }

        private void FormMap_Shown(object sender, EventArgs e) {
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

        public void LoadMapFromFile() {
            GMapOverlay routes = new GMapOverlay("routes");
            points = new List<PointLatLng>();

            if (loadedFileName != null) {
                //grab coords from file
                LoadFilePoints(points);
                numPoints = points.Count;
                Console.WriteLine("******************************************");
                Console.WriteLine("N�mero de pontos da rota � " + numPoints);
                numRotas++;
            } else {
                //points.Add(new PointLatLng(39.734105, -8.821917));
                //points.Add(new PointLatLng(39.734336, -8.821535));
                //points.Add(new PointLatLng(39.734728, -8.820946));
                Console.WriteLine("##########################################");
                Console.WriteLine("###          N�o tem Overlays!         ###");
                Console.WriteLine("###        Insira rotas primeiro!      ###");
                Console.WriteLine("##########################################");
            }

            GMapRoute route = new GMapRoute(points, "A Vehicle Route");
            route.Stroke = new Pen(Color.Green, 3);

            routes.Routes.Add(route);
            mapa.Overlays.Add(routes);

            // For�a o mapa a fazer zoom para mostrar logo a rota. mapa.Refresh() n�o funciona.
            mapa.ZoomAndCenterRoute(route);
        }

        private void btnSaveCoord_Click(object sender, EventArgs e) {
            if (savedCoordsFile == null) {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.DefaultExt = "csv";
                openFileDialog.Filter = "CSV files (*.csv)|*.csv";
                openFileDialog.CheckFileExists = false;
                openFileDialog.Title = "Abrir ou criar ficheiro CSV";

                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    savedCoordsFile = openFileDialog.FileName;
                    labelSaveFileName.Text = openFileDialog.SafeFileName;
                }
            }

            //  Verificar se n�o � null pois o utilizador pode ter cancelado o openFileDialog
            if (savedCoordsFile != null) {
                using (StreamWriter fileStream = File.AppendText(savedCoordsFile)) {
                    if (new FileInfo(savedCoordsFile).Length == 0) {
                        fileStream.WriteLine("Latitude,Longitude");
                    }

                    fileStream.WriteLine(labelLatitude.Text + "," + labelLongitude.Text);
                }
            }

        }

        private void buttonCarregarTransito_Click(object sender, EventArgs e) {
            LoadTrafficFromFile();
        }

        public void LoadTrafficFromFile() {

            trafficPoints = new List<PointLatLng>();
            GMapOverlay polyOverlay = new GMapOverlay("polygons");
            // Obtem a primeira Overlay
            GMapOverlay overlay = mapa.Overlays.FirstOrDefault();

            if (loadedFileName != null) {

                LoadFilePointsAntigo(trafficPoints);
                GMapPolygon polygon1 = new GMapPolygon(trafficPoints, "Traffic Area");

                polygon1.Fill = new SolidBrush(Color.FromArgb(35, Color.Black));
                polygon1.Stroke = new Pen(Color.Black, 1);

                polyOverlay.Polygons.Add(polygon1);
                mapa.Overlays.Add(polyOverlay);
                mapa.ZoomAndCenterRoute(polygon1);

                var nVerticesPoligono = trafficPoints.Count();
                Console.WriteLine("O pol�gono para medir o transito tem " + nVerticesPoligono + " v�rtices.");

                //foreach (var point in points) {
                //    if (polygon1.IsInside(point)) {
                //        quantidadePontosNoPoligono += 1;

                //    }
                //}
                //Console.WriteLine("Dentro do Pol�gono existem " + quantidadePontosNoPoligono + " pontos da Rota anterior.");

                foreach (GMapRoute route in overlay.Routes) {
                    // Fazer algo com cada rota -> como acessar as coordenadas de seus pontos
                    List<PointLatLng> routePoints = route.Points;
                    foreach (var point in routePoints) {
                        if (polygon1.IsInside(point)) {
                            quantidadePontosNoPoligono += 1;
                        }
                    }
                    numRotas++;

                    #region Onde definimos cores consoante tr�nsito
                    if (numRotas < 3) {
                        // Pouco Transito -> Verde a Rua 
                        route.Stroke = new Pen(Color.Green, 3);
                    } else if (numRotas < 6) {
                        // Transito Moderado -> Laranja a Rua
                        route.Stroke = new Pen(Color.Orange, 3);
                    } else {
                        // Muito Tr�nsito -> Vermelho a Rua
                        route.Stroke = new Pen(Color.Red, 3);
                    }
                    #endregion

                    mapa.ZoomAndCenterRoutes(overlay.Id);

                    #region Dados a imprimir na consola
                    Console.WriteLine("******************************************");
                    Console.WriteLine("Estou na Rota: " + route.Name);
                    Console.WriteLine("******************************************");
                    Console.WriteLine("Quantidade de Rotas =    " + numRotas);
                    Console.WriteLine("******************************************");
                    Console.WriteLine("Quantidade de Pontos =   " + points.Count);
                    Console.WriteLine("******************************************");
                    Console.WriteLine("Quantidade de Overlays = " + mapa.Overlays.Count);
                    Console.WriteLine("******************************************");
                    Console.WriteLine("Dentro do Pol�gono existem " + quantidadePontosNoPoligono + " pontos da Rota anterior.");
                    Console.WriteLine("******************************************");
                    #endregion
                }

            } else {
                // Caso n�o tenho um ficheiro v�lido:
                trafficPoints.Add(new PointLatLng(39.73572687127097, -8.821855187416077));
                trafficPoints.Add(new PointLatLng(39.73630027771427, -8.820868134498596));
                trafficPoints.Add(new PointLatLng(39.736287902086005, -8.82051408290863));
                trafficPoints.Add(new PointLatLng(39.735854753696806, -8.819999098777771));
                trafficPoints.Add(new PointLatLng(39.73574749748473, -8.819961547851562));
                trafficPoints.Add(new PointLatLng(39.73527721827691, -8.820052742958069));
                trafficPoints.Add(new PointLatLng(39.73476155756275, -8.820868134498596));
                //Console.WriteLine("Entrei no else");
            }

        }

        private void LoadFilePoints(List<PointLatLng> list) {
            using (TextFieldParser parser = new TextFieldParser(loadedFileName)) {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                bool isHeader = true;
                while (!parser.EndOfData) {
                    string[] fields = parser.ReadFields();

                    if (isHeader) {
                        isHeader = false;
                        continue;
                    }

                    try {
                        var lat = Convert.ToDouble(fields[1]);
                        var lon = Convert.ToDouble(fields[2]);
                        list.Add(new PointLatLng(lat, lon));
                    } catch {
                        // Caso a linha esteja vazia e n�o consiga produzir um double continua para a pr�xima
                        continue;
                    }
                }
            }
        }

        #region Apagar quando o LoadFilePoints estiver bom
        private void LoadFilePointsAntigo(List<PointLatLng> list) {
            using (TextFieldParser parser = new TextFieldParser(loadedFileName)) {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                bool isHeader = true;
                while (!parser.EndOfData) {
                    string[] fields = parser.ReadFields();

                    if (isHeader) {
                        isHeader = false;
                        continue;
                    }

                    try {
                        var lat = Convert.ToDouble(fields[0]);
                        var lon = Convert.ToDouble(fields[1]);
                        list.Add(new PointLatLng(lat, lon));
                    } catch {
                        // Caso a linha esteja vazia e n�o consiga produzir um double continua para a pr�xima
                        continue;
                    }
                }
            }
        }
        #endregion

        private void buttonRemoveOverlays_Click(object sender, EventArgs e) {

            if (mapa.Overlays.Count > 0) {
                mapa.Overlays.Clear();
                mapa.Refresh();
                Console.WriteLine("##########################################");
                Console.WriteLine("###    As Overlays foram removidas.    ###");
                Console.WriteLine("##########################################");
            }
            numPoints = 0;
            numRotas = 0;
            quantidadePontosNoPoligono = 0;
            nOverlays = 0;
            numRotas = 0;
        }

        private void buttonTransito_Click(object sender, EventArgs e) {

            #region Variaveis com dados dos filtros
            string dataInicio = dateTimePickerInicio.ToString();
            string dataFim = dateTimePickerFim.ToString();
            string rua = textBoxRua.ToString();
            #endregion

            // Obtem a primeira Overlay
            GMapOverlay overlay = mapa.Overlays.FirstOrDefault();


            string startCoorStreet = "Rua dos M�rtires, Leiria, Portugal";//textBoxRua.ToString();
            string endCoorStreet = "Avenida Marqu�s de Pombal, Leiria, Portugal";//textBoxRua.ToString();
            MapRoute mapRoute = GMap.NET.MapProviders.GoogleMapProvider.Instance.GetRoute(startCoorStreet, endCoorStreet, false, false, 15);
            GMapRoute r = new GMapRoute(mapRoute.Points, "My route");

            GMapOverlay routesOverlay = new GMapOverlay("trafficRoutes");
            routesOverlay.Routes.Add(r);
            mapa.Overlays.Add(routesOverlay);

            if (numRotas < 3) {
                // Pouco Transito -> Verde a Rua 
                r.Stroke = new Pen(Color.Green, 3);
            } else if (numRotas < 6) {
                // Transito Moderado -> Laranja a Rua
                r.Stroke = new Pen(Color.Orange, 3);
            } else {
                // Muito Tr�nsito -> Vermelho a Rua
                r.Stroke = new Pen(Color.Red, 3);
            }


            //if (overlay != null) {

            //    // Itera sobre cada rota na Overlay
            //    foreach (GMapRoute route in overlay.Routes) {
            //        // Fazer algo com cada rota -> como acessar as coordenadas de seus pontos
            //        List<PointLatLng> routePoints = route.Points;



            //        #region Onde definimos cores consoante tr�nsito
            //        if (numRotas < 3) {
            //            // Pouco Transito -> Verde a Rua 
            //            //route.Stroke = new Pen(Color.Green, 3);
            //        } else if (numRotas < 6) {
            //            // Transito Moderado -> Laranja a Rua
            //            route.Stroke = new Pen(Color.Orange, 3);
            //        } else {
            //            // Muito Tr�nsito -> Vermelho a Rua
            //            route.Stroke = new Pen(Color.Red, 3);
            //        }
            //        #endregion

            //        // No final faz zoom na rua
            //        //mapa.ZoomAndCenterRoute(route);
            //        mapa.ZoomAndCenterRoutes(overlay.Id);

            //        #region Dados a imprimir na consola
            //        Console.WriteLine("******************************************");
            //        Console.WriteLine("Estou na Rota: " + route.Name);
            //        Console.WriteLine("******************************************");
            //        Console.WriteLine("Quantidade de Rotas =    " + numRotas);
            //        Console.WriteLine("******************************************");
            //        Console.WriteLine("Quantidade de Pontos =   " + points.Count);
            //        Console.WriteLine("******************************************");
            //        Console.WriteLine("Quantidade de Overlays = " + mapa.Overlays.Count);
            //        Console.WriteLine("******************************************");
            //        #endregion
            //    }
            //} else {
            //    Console.WriteLine("##########################################");
            //    Console.WriteLine("###          N�o tem Overlays!         ###");
            //    Console.WriteLine("###        Insira rotas primeiro!      ###");
            //    Console.WriteLine("##########################################");
            //}
        }
    }

    // Ser� a classe que guarda carater�sticas do ve�culo
    public class Vehicle {
        private int id { get; }
        private int idPath { get; }
        //private List<PointLatLng> coordinates;
    }

    // Ser� a classe Percurso
    public class Path {
        private int ID { get; }
        private string Name { get; set; }
        private string Date { get; set; }
        private int IDVehicle { get; }
        private int NVehicles { get; set; }
        private List<PointLatLng> coordinates;
    }
}