using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using ProjetoFinalM2.Data;
using ProjetoFinalM2.Helpers;
using System.Net;

namespace ProjetoFinalM2
{
    public partial class FormMap : Form
    {

        public int quantidadePontosNoPoligono = 0;
        public int totalVeiculos = 0;
        public List<Vehicle> vehiclesList = new List<Vehicle>();
        public List<PointLatLng> pointLatLngsList = new List<PointLatLng>();
        public List<PointLatLng> myList = new List<PointLatLng>();

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
                vehiclesList.AddRange(FileLoader.LoadPointsFromFile());

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
            myList.Add(new PointLatLng(mapa.FromLocalToLatLng(e.X, e.Y).Lat, mapa.FromLocalToLatLng(e.X, e.Y).Lng));
        }

        private void BtnCarregarFicheiro_Click(object sender, EventArgs e)
        {
            labelCurrentFileName.Text = FileLoader.LoadFile(false) ?? labelCurrentFileName.Text;
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

        private void BtnSaveCoord_Click(object sender, EventArgs e)
        {
            labelSaveFileName.Text = FileLoader.SaveCoordToFile(DateTime.Now, labelLatitude.Text, labelLongitude.Text, 1) ?? labelSaveFileName.Text;
        }

        private void ButtonRemoveOverlays_Click(object sender, EventArgs e)
        {
            OverlayHelper.ClearOverlays(mapa);
            myList.Clear();
        }

        private void ButtonPesquisarTransito_Click(object sender, EventArgs e)
        {
            //TODO: Refactor for Vehicles
            String timeWorkaround = $"{dateTimePickerDate.Value.ToShortDateString()} {dateTimePickerTime.Value.ToShortTimeString()}:{trackBarTime.Value}";
            DateTime selectedTime = DateTime.Parse(timeWorkaround);
            //string streetName = textBoxSreetName.Text;

            //Para debugging
            Console.WriteLine($"TS: {selectedTime}");
            Console.WriteLine($"There are {vehiclesList.Count} vehicles in vehiclesList.");
            //Console.WriteLine("O nome da rua é " + streetName);

            try
            {
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
                    foreach (var v in timedVehicles)
                    {
                        foreach (var c in v.TimestampedCoords)
                        {
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

                #region Colorir o polígono / "Está trânsito"
                var nVeiculosMax = uiNVeiculosTransito.Value;
                if (timedVehicles.Count > nVeiculosMax)
                {
                    labelTrafficState.Text = "Com trânsito";
                    polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
                    polygon.Stroke = new Pen(Color.Red, 1);
                } else if (timedVehicles.Count < nVeiculosMax && timedVehicles.Count > nVeiculosMax / 2)
                {
                    labelTrafficState.Text = "Trânsito normal";
                    polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Yellow));
                    polygon.Stroke = new Pen(Color.Yellow, 1);
                } else
                {
                    labelTrafficState.Text = "Sem trânsito";
                    polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Green));
                    polygon.Stroke = new Pen(Color.Green, 1);
                }
                #endregion

            } catch (Exception ex)
            {
                MessageBox.Show("Algo correu mal!");
                Console.WriteLine(ex.Message);

            }
        }

        private void TrackBarTime_ValueChanged(object sender, EventArgs e)
        {
            labelSelectedSeconds.Text = trackBarTime.Value.ToString();
            //TODO: Filtrar veiculos quando isto muda
        }

        private void BtnDrawPolygon_Click(object sender, EventArgs e)
        {
            List<PointLatLng> coordsList = new List<PointLatLng>();
            try
            {
                coordsList.AddRange(FileLoader.LoadPointsForPolygon());

                OverlayHelper.DrawPolygon(mapa, coordsList, Color.Black);

            } catch (Exception ex)
            {
                MessageBox.Show("Nenhum ficheiro carregado.");
                Console.WriteLine(ex.Message);
            }
        }

        private void BtnGetStreet_Click(object sender, EventArgs e)
        {
            #region Obter informação da Rua
            // OS PONTOS SÃO ARMAZENADOS NUMA LISTA DE PONTOS (Tipo de cada elemento PointLatLng)
            PointLatLng myPoint1 = myList[0];
            PointLatLng myPoint2 = myList[1];
            #endregion

            #region Obtém Direções Cartesianas 2
            double lat1 = myPoint1.Lat * Math.PI / 180;
            double lon1 = myPoint1.Lng * Math.PI / 180;
            double lat2 = myPoint2.Lat * Math.PI / 180;
            double lon2 = myPoint2.Lng * Math.PI / 180;

            double dLon = lon2 - lon1;

            double y = Math.Sin(dLon) * Math.Cos(lat2);
            double x = Math.Cos(lat1) * Math.Sin(lat2) - Math.Sin(lat1) * Math.Cos(lat2) * Math.Cos(dLon);

            double bearing = Math.Atan2(y, x) * 180 / Math.PI;

            if (bearing < 0)
            {
                bearing += 360;
            }

            // verificar em que sentido a rota vai
            bool isGoingNorth = bearing > 315 && bearing < 45;
            bool isGoingEast = bearing > 45 && bearing < 135;
            bool isGoingSouth = bearing > 135 && bearing < 225;
            bool isGoingWest = bearing > 225 && bearing < 315;

            // Atribuir à label a direção
            if (isGoingNorth)
            {
                labelSentidoCart.Text = "Rota para Norte";
                Console.WriteLine("A rota está a ir para norte.");
            } else if (isGoingEast)
            {
                labelSentidoCart.Text = "Rota para Este";
                Console.WriteLine("A rota está a ir para este.");
            } else if (isGoingSouth)
            {
                labelSentidoCart.Text = "Rota para Sul";
                Console.WriteLine("A rota está a ir para sul.");
            } else if (isGoingWest)
            {
                labelSentidoCart.Text = "Rota para Oeste";
                Console.WriteLine("A rota está a ir para oeste.");
            } else
            {
                labelSentidoCart.Text = "Rota para Norte";
                Console.WriteLine("A rota está a ir para norte.");
            }

            #endregion

            // Obter informação a Rua do sobre o primeiro ponto
            List<Placemark> placemarks = null;
            var statusCode = GMapProviders.OpenStreetMap.GetPlacemarks(myPoint1, out placemarks);

            // Verificar se TUDO OK
            if (statusCode == GeoCoderStatusCode.OK && placemarks != null)
            {
                List<String> addresses = new List<string>();
                foreach (var placemark in placemarks)
                {
                    // Obter o nome da rua
                    addresses.Add(placemark.ThoroughfareName);
                    labelStreet.Text = placemark.ThoroughfareName;

                    MapRoute route = GMap.NET.MapProviders.OpenStreetMapProvider.Instance.GetRoute(myPoint1, myPoint2, false, false, 15);
                    GMapRoute r = new GMapRoute(route.Points, "My route");
                    GMapOverlay routesOverlay = new GMapOverlay("routes");
                    routesOverlay.Routes.Add(r);
                    mapa.Overlays.Add(routesOverlay);

                }
            }
        }

        private void FormMap_Load(object sender, EventArgs e)
        {

        }
    }
}
