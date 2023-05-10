using GMap.NET;
using GMap.NET.MapProviders;
using ProjetoFinalM2.Data;
using ProjetoFinalM2.Helpers;

namespace ProjetoFinalM2
{
    public partial class FormMap : Form
    {

        public int quantidadePontosNoPoligono = 0;
        public List<TimestampedCoords> loadedTSCoords = new List<TimestampedCoords>();

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        public FormMap()
        {
            AllocConsole(); //Permite a criacao de uma consola para fins de debugging

            #region Colocar delimitador standard
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            #endregion

            InitializeComponent();
        }

        private void BtnCarregarMapa_Click(object sender, EventArgs e)
        {
            try
            {
                loadedTSCoords.AddRange(FileLoader.LoadPointsFromFile());

                List<PointLatLng> pointsLoadedFromFile = new();
                pointsLoadedFromFile.AddRange(from coord in loadedTSCoords
                                              select new PointLatLng(coord.Lat, coord.Lon));

                OverlayHelper.DrawRoute(mapa, pointsLoadedFromFile, Color.Green, 3);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nenhum ficheiro carregado.");
                Console.WriteLine(ex.Message);
            }
        }

        private void Mapa_MouseClick(object sender, MouseEventArgs e)
        {
            labelLatitude.Text = mapa.FromLocalToLatLng(e.X, e.Y).Lat.ToString();
            labelLongitude.Text = mapa.FromLocalToLatLng(e.X, e.Y).Lng.ToString();
        }

        private void BtnCarregarFicheiro_Click(object sender, EventArgs e)
        {
            labelCurrentFileName.Text = FileLoader.LoadFile() ?? labelCurrentFileName.Text;
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

        private void btnSaveCoord_Click(object sender, EventArgs e)
        {
            labelSaveFileName.Text = FileLoader.SaveCoordToFile(labelLatitude.Text, labelLongitude.Text) ?? labelSaveFileName.Text;
        }

        private void buttonCarregarTransito_Click(object sender, EventArgs e)
        {
            List<PointLatLng> trafficPoints = new();
            trafficPoints.AddRange(from coord in loadedTSCoords
                                   select new PointLatLng(coord.Lat, coord.Lon));

            OverlayHelper.DrawPolygon(mapa, trafficPoints, Color.Black);

            var nVerticesPoligono = trafficPoints.Count();
            Console.WriteLine("O polígono para medir o transito tem " + nVerticesPoligono + " vértices.");

            //foreach (var point in points)
            //{
            //    if (polygon1.IsInside(point))
            //    {
            //        quantidadePontosNoPoligono += 1;
            //    }
            //}
            Console.WriteLine("Dentro do Polígono existem " + quantidadePontosNoPoligono + " da Rota anterior.");
        }

        private void buttonRemoveOverlays_Click(object sender, EventArgs e)
        {
            OverlayHelper.ClearOverlays(mapa);
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
                List<PointLatLng> points = new List<PointLatLng>();
                foreach (var tsCoord in loadedTSCoords)
                {
                    if (tsCoord.Timestamp.Ticks >= start.Ticks && tsCoord.Timestamp.Ticks <= end.Ticks) //TODO: Bug de tempo
                    {
                        points.Add(new PointLatLng(tsCoord.Lat, tsCoord.Lon));
                    }
                }

                if (points.Count > 1000)
                {
                    OverlayHelper.DrawRoute(mapa, points, Color.Red, 3);
                }
                else if (points.Count < 1000 && points.Count > 500)
                {
                    OverlayHelper.DrawRoute(mapa, points, Color.Yellow, 3);
                }
                else
                {
                    OverlayHelper.DrawRoute(mapa, points, Color.Green, 3);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo correu mal!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}