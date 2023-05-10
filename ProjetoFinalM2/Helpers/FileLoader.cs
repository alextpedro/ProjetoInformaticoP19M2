using Avalonia;
using GMap.NET.WindowsForms;
using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalM2.Helpers
{
    static class FileLoader
    {
        private static string? loadedFileName;
        private static string? savedCoordsFile;
        private static string? saveFileName;
        public static List<PointLatLng> points = new List<PointLatLng>();

        public static int numPoints = 0;
        public static int nOverlays = 0;

        public static void LoadMapFromFile(GMapControl mapa)
        {
            GMapOverlay routes = new GMapOverlay("routes");
            points = new List<PointLatLng>();

            if (!String.IsNullOrEmpty(loadedFileName))
            {
                //grab coords from file
                //LoadFilePoints(points);
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

        [STAThread]
        public static string SaveCoordToFile(string lat, string lon)
        {

            //Se não houver ficheiro de guardar coordenadas:
            if (String.IsNullOrEmpty(savedCoordsFile))
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.DefaultExt = "csv";
                openFileDialog.Filter = "CSV files (*.csv)|*.csv";
                openFileDialog.CheckFileExists = false;
                openFileDialog.Title = "Abrir ou criar ficheiro CSV";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    savedCoordsFile = openFileDialog.FileName;
                    saveFileName = openFileDialog.SafeFileName;
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

                    fileStream.WriteLine($"{lat}, {lon}");
                }
            }

            return saveFileName;
        }

        public static void TestMethod()
        {
            Console.WriteLine("Test method.");
        }
    }
}
