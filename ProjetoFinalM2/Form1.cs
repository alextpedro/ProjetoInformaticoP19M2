using GMap.NET.MapProviders;
using GMap.NET;
using System.Linq.Expressions;
using OfficeOpenXml;
using System.Windows.Forms;
//using GMap.NET.Avalonia;
using System.Drawing.Text;
using GMap.NET.WindowsForms;
using System.Collections.Generic;
//using GMap.NET.WindowsPresentation;

namespace ProjetoFinalM2
{
    public partial class Form1 : Form
    {
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();
        public Form1()
        {
            //Permite a criacao de uma consola para fins de debugging
            AllocConsole();
            InitializeComponent();
        }

        private void btnCarregarMapa_Click(object sender, EventArgs e)
        {

            #region Tentativa 1
            GMapOverlay routes = new GMapOverlay("routes");
            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(new PointLatLng(39.734105, -8.821917));
            points.Add(new PointLatLng(39.734336, -8.821535));
            points.Add(new PointLatLng(39.734728, -8.820946));
            GMapRoute route = new GMapRoute(points, "A Vehicle Route");
            route.Stroke = new Pen(Color.Red, 3);
            routes.Routes.Add(route);
            mapa.Overlays.Add(routes);
            #endregion

            #region Tentativa 2
            /*mapa.Position = new PointLatLng(39.734273, -8.821656);
            PointLatLng start = new PointLatLng(39.736998, -8.821571);
            PointLatLng end = new PointLatLng(39.738739, -8.818470);
            MapRoute route = GoogleMapProvider.Instance.GetRoute(start, end, false, false, 18);
            GMapRoute r = new GMapRoute(route.Points, "My route");
            GMapOverlay routesOverlay = new GMapOverlay("routes");
            routesOverlay.Routes.Add(r);
            mapa.Overlays.Add(routesOverlay);
            r.Stroke.Width = 2;
            r.Stroke.Color = Color.SeaGreen;*/
            #endregion

        }

        private static void btnCarregarFicheiro_Click(object sender, EventArgs e)
        {

        }

        //private static List<Coordenada> ReadXls() {

        //    var response = new List<Coordenada>();

        //    FileInfo ficheiroExcel = new FileInfo("E:\\projFinal\\ProjetoInformaticoP19M2\\ProjetoFinalM2\\Coordenadas.xlsx");
        //    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        //    using (ExcelPackage package = new ExcelPackage(ficheiroExcel)) {

        //        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
        //        int colCount = worksheet.Dimension.End.Column;
        //        int rowCount = worksheet.Dimension.End.Row;

        //        for (int row = 2; row<= rowCount; rowCount++) {
        //            var coordenada = new Coordenada();
        //            coordenada.Latitude = (float)worksheet.Cells[row, 1].Value;
        //            coordenada.Longitude = (float)worksheet.Cells[row, 2].Value;
        //            response.Add(coordenada);
        //        }
        //    }

        //    return response;
        //}

        private void Mapa_MouseClick(object sender, MouseEventArgs e)
        {
            labelLatitude.Text = mapa.FromLocalToLatLng(e.X, e.Y).Lat.ToString();
            labelLongitude.Text = mapa.FromLocalToLatLng(e.X, e.Y).Lng.ToString();
        }

        public class Coordenada
        {
            public float Latitude { get; set; }
            public float Longitude { get; set; }
        }

        private void Mapa_MouseHover(object sender, EventArgs e)
        {
            //labelLatitude.Text = mapa.FromLocalToLatLng(e.X, e.Y).Lat.ToString();
            //labelLongitude.Text = mapa.FromLocalToLatLng(e.X, e.Y).Lng.ToString();
        }

        private void Form1_Shown(object sender, EventArgs e)
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
            #endregion
        }

        private void labelLatitude_Click(object sender, EventArgs e)
        {
            labelLatitude.Focus();
        }

        private void labelLongitude_Click(object sender, EventArgs e)
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
    }
}