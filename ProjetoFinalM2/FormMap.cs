using Avalonia;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using ProjetoFinalM2.Data;
using ProjetoFinalM2.Helpers;
using System.Reflection;
using System.Linq;

namespace ProjetoFinalM2
{
    public partial class FormMap : Form
    {

        public int quantidadePontosNoPoligono = 0;
        public int totalVeiculos = 0;
        public List<Vehicle> vehiclesList = new List<Vehicle>();
        public List<PointLatLng> pointLatLngsList = new List<PointLatLng>();

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
                vehiclesList.AddRange(FileLoader.LoadPointsFromFile(vehiclesList));

                vehiclesList.ForEach(vehicle => {
                    List<PointLatLng> tmpListCoords = new();

                    vehicle.TimestampedCoords.ForEach(coord => {
                        tmpListCoords.Add(new PointLatLng(coord.Lat, coord.Lon));
                    });

                    #region Colocar Marcador no mapa de cada veículo
                    foreach (var item in tmpListCoords)
                    {
                        GMapOverlay markersOverlay = new GMapOverlay("MarkersOverlay");
                        PointLatLng markerPosition = new PointLatLng(item.Lat, item.Lng);
                        GMarkerGoogle marker = new GMarkerGoogle(markerPosition, GMarkerGoogleType.red_pushpin);
                        marker.ToolTipText = "Veiculo " + vehicle.Id.ToString();
                        markersOverlay.Markers.Add(marker);
                        mapa.Overlays.Add(markersOverlay);
                    }
                    #endregion

                    //OverlayHelper.DrawRoute(mapa, tmpListCoords, randomColor, 3);
                });

                #region Colocar Estado do Trânsito
                if (vehiclesList.Count < (int)uiNVeiculosTransito.Value)
                {
                    labelTrafficState.Text = "Normal";
                } else
                {
                    labelTrafficState.Text = "Com Transito";
                }
                #endregion

            } catch (Exception ex)
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
            mapa.Position = new PointLatLng(39.739790, -8.805316);
            mapa.MinZoom = 0;
            mapa.MaxZoom = 24;
            mapa.Zoom = 17;
            mapa.AutoScroll = true;
            mapa.ShowCenter = false;
            #endregion

            labelLatitude.Text = mapa.Position.Lat.ToString();
            labelLongitude.Text = mapa.Position.Lng.ToString();
        }

        private void btnSaveCoord_Click(object sender, EventArgs e)
        {
            labelSaveFileName.Text = FileLoader.SaveCoordToFile(DateTime.Now, labelLatitude.Text, labelLongitude.Text, 1) ?? labelSaveFileName.Text;
        }

        //private void buttonCarregarTransito_Click(object sender, EventArgs e)
        //{
        //    List<PointLatLng> trafficPoints = new();
        //    trafficPoints.AddRange(from coord in loadedTSCoords
        //                           select new PointLatLng(coord.Lat, coord.Lon));

        //    OverlayHelper.DrawPolygon(mapa, trafficPoints, Color.Black);

        //    var nVerticesPoligono = trafficPoints.Count();
        //    Console.WriteLine("O polígono para medir o transito tem " + nVerticesPoligono + " vértices.");

        //    //foreach (var point in points)
        //    //{
        //    //    if (polygon1.IsInside(point))
        //    //    {
        //    //        quantidadePontosNoPoligono += 1;
        //    //    }
        //    //}
        //    Console.WriteLine("Dentro do Polígono existem " + quantidadePontosNoPoligono + " da Rota anterior.");
        //}

        private void buttonRemoveOverlays_Click(object sender, EventArgs e)
        {
            OverlayHelper.ClearOverlays(mapa);
        }

        private void buttonPesquisarTransito_Click(object sender, EventArgs e)
        {
            //TODO: Refactor for Vehicles
            String timeWorkaround = $"{dateTimePickerDate.Value.ToShortDateString()} {dateTimePickerTime.Value.ToShortTimeString()}:{trackBarTime.Value}";
            DateTime selectedTime = DateTime.Parse(timeWorkaround);
            string streetName = textBoxSreetName.Text;

            //Para debugging
            Console.WriteLine($"TS: {selectedTime}");
            Console.WriteLine($"There are {vehiclesList.Count} vehicles in vehiclesList.");
            Console.WriteLine("O nome da rua é " + streetName);

            //try
            //{
                List<PointLatLng> points = new List<PointLatLng>();
                List<Vehicle> timedVehicles = new();

                #region Adicionar Pontos na Lista e Filtrar
                foreach (var v in vehiclesList)
                {
                    var coords = v.TimestampedCoords;
                    var tmpCoords = new List<TimestampedCoords>();
                    foreach (var c in coords)
                    {
                        string coordWorkaround = c.Timestamp.ToString();
                        string selectedTimeWorkaround = selectedTime.ToString();

                        if (coordWorkaround == selectedTimeWorkaround)
                        {
                            points.Add(new PointLatLng(c.Lat, c.Lon));
                            tmpCoords.Add(new TimestampedCoords(c.Timestamp, c.Lat, c.Lon));
                        }
                    }

                    if (!timedVehicles.Contains(v))
                    {
                        Vehicle tmpVehicle = new Vehicle(v.Id);
                        tmpVehicle.TimestampedCoords.AddRange(tmpCoords);
                        timedVehicles.Add(tmpVehicle);
                    }
                }
                #endregion

                #region Desenhar pins
                //GMapOverlay overlay = mapa.Overlays["polygon"];
                GMapOverlay overlay = mapa.Overlays.FirstOrDefault();
                GMapPolygon polygon = overlay.Polygons.FirstOrDefault(p => p.Name == "polygon");
                if (timedVehicles != null)
                {
                    //OverlayHelper.ClearOverlays(mapa);

                    foreach (var v in timedVehicles)
                    {
                        foreach (var c in v.TimestampedCoords)
                        {
                            //OverlayHelper.DrawPin(mapa, new PointLatLng(c.Lat, c.Lon), $"Veículo {v.Id}");
                            //OverlayHelper.DrawPolygon(mapa, points, Color.Red, 3);
                            bool isInside = polygon.IsInside(new PointLatLng(c.Lat, c.Lon));
                            if (isInside)
                            {
                                Console.WriteLine("Estou no isInside");
                                OverlayHelper.DrawPin(mapa, new PointLatLng(c.Lat, c.Lon), $"Veículo {v.Id}");
                            }
                        }

                        #region Sentido Cartesiano
                        //for (int i = 1; i < 2; i++)
                        //{
                        //    TimestampedCoords pontoAtual = v.TimestampedCoords[i];
                        //    TimestampedCoords pontoAnterior = v.TimestampedCoords[i - 1];
                        //    if (pontoAtual.Lon > pontoAnterior.Lon)
                        //    {
                        //        // Rota da esquerda para a direita
                        //        Console.WriteLine("Veículo " + v.Id + " circula de Este para Oeste");
                        //    } else if (pontoAtual.Lon < pontoAnterior.Lon)
                        //    {
                        //        // Rota da direita para a esquerda
                        //        Console.WriteLine("Veículo " + v.Id + " circula de Oeste para Este");
                        //    }
                        //    if (pontoAtual.Lat > pontoAnterior.Lat)
                        //    {
                        //        // Rota de cima para baixo
                        //        Console.WriteLine("Veículo " + v.Id + " circula de Norte para Sul");
                        //    } else if (pontoAtual.Lat < pontoAnterior.Lat)
                        //    {
                        //        // Rota de baixo para cima
                        //        Console.WriteLine("Veículo " + v.Id + " circula deSul para Norte");
                        //    } else
                        //    {
                        //        Console.WriteLine("Estou no else do FOR i do timedVehicles");
                        //    }
                        //}
                        #endregion
                    }
                }
                #endregion

                #region Colorir a Rota / "Está trânsito"
                var nVeiculosMax = uiNVeiculosTransito.Value;
                if (timedVehicles.Count > nVeiculosMax)
                {
                    //OverlayHelper.DrawRoute(mapa, points, Color.Red, 3);
                    labelTrafficState.Text = "Com trânsito";
                    //OverlayHelper.DrawPolygon(mapa, points, Color.Red, 3);
                    polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
                    polygon.Stroke = new Pen(Color.Red, 1);
                } else if (timedVehicles.Count < nVeiculosMax && timedVehicles.Count > nVeiculosMax / 2)
                {
                    labelTrafficState.Text = "Trânsito normal";
                    //OverlayHelper.DrawRoute(mapa, points, Color.Yellow, 3);
                    polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Yellow));
                    polygon.Stroke = new Pen(Color.Yellow, 1);
                } else
                {
                    labelTrafficState.Text = "Sem trânsito";
                    //OverlayHelper.DrawRoute(mapa, points, Color.Green, 3);
                    polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Green));
                    polygon.Stroke = new Pen(Color.Green, 1);
                }
                #endregion

            //} 
            //catch (Exception ex)
            //{
            //    //MessageBox.Show("Algo correu mal!");
            //    //Console.WriteLine(ex.Message);

            //}
        }

        private void trackBarTime_ValueChanged(object sender, EventArgs e)
        {
            labelSelectedSeconds.Text = trackBarTime.Value.ToString();
            //TODO: Filtrar veiculos quando isto muda
        }

        private void btnRotaTransito_Click(object sender, EventArgs e)
        {
            try
            {
                List<PointLatLng> coordsList = new();

                vehiclesList.ForEach(vehicle => {

                    vehicle.TimestampedCoords.ForEach(coord => {
                        coordsList.Add(new PointLatLng(coord.Lat, coord.Lon));
                    });

                });

                OverlayHelper.DrawPolygon(mapa, coordsList, Color.Black);

            } catch (Exception ex)
            {
                MessageBox.Show("Nenhum ficheiro carregado.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}