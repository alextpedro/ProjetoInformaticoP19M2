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

                vehiclesList.ForEach(vehicle =>
                {
                    List<PointLatLng> tmpListCoords = new();

                    vehicle.TimestampedCoords.ForEach(coord =>
                    {
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
                }
                else
                {
                    labelTrafficState.Text = "Com Transito";
                }
                #endregion

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
                }
                else if (timedVehicles.Count < nVeiculosMax && timedVehicles.Count > nVeiculosMax / 2)
                {
                    labelTrafficState.Text = "Trânsito normal";
                    polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Yellow));
                    polygon.Stroke = new Pen(Color.Yellow, 1);
                }
                else
                {
                    labelTrafficState.Text = "Sem trânsito";
                    polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Green));
                    polygon.Stroke = new Pen(Color.Green, 1);
                }
                #endregion

            }
            catch (Exception ex)
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

            }
            catch (Exception ex)
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
            PointLatLng myPoint3 = myList[2];
            PointLatLng myPoint4 = myList[3];
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
            }
            else if (isGoingEast)
            {
                labelSentidoCart.Text = "Rota para Este";
                Console.WriteLine("A rota está a ir para este.");
            }
            else if (isGoingSouth)
            {
                labelSentidoCart.Text = "Rota para Sul";
                Console.WriteLine("A rota está a ir para sul.");
            }
            else if (isGoingWest)
            {
                labelSentidoCart.Text = "Rota para Oeste";
                Console.WriteLine("A rota está a ir para oeste.");
            }
            else
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

                    //PointLatLng start = new PointLatLng(39.7398231162096, -8.80534887313843);
                    //PointLatLng end = new PointLatLng(39.7395632408332, -8.808873295784);
                    MapRoute routeOpposite = GMap.NET.MapProviders.OpenStreetMapProvider.Instance.GetRoute(myPoint3, myPoint4, false, false, 15);
                    GMapRoute r = new GMapRoute(route.Points, "My route");
                    GMapRoute ro = new GMapRoute(routeOpposite.Points, "My opposing route");
                    GMapOverlay routesOverlay = new GMapOverlay("routes");
                    labelRouteLenght.Text = route.Distance.ToString() + " km";
                    routesOverlay.Routes.Add(r);
                    routesOverlay.Routes.Add(ro);
                    mapa.Overlays.Add(routesOverlay);

                }
            }
        }

        private void FormMap_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnPointsOnRoute_Click(object sender, EventArgs e)
        {
            String timeWorkaround = $"{dateTimePickerDate.Value.ToShortDateString()} {dateTimePickerTime.Value.ToShortTimeString()}:{trackBarTime.Value}";
            DateTime selectedTime = DateTime.Parse(timeWorkaround);

            try
            {
                List<PointLatLng> points = new List<PointLatLng>();
                List<Vehicle> timedVehicles = new();

                #region Obter informação da Rua
                PointLatLng myPoint1 = myList[0];
                PointLatLng myPoint2 = myList[1];
                #endregion

                #region Desenhar pins na rota e próximos da rota
                GMapOverlay overlay = mapa.Overlays.First(ov => ov.Id == "routes");
                OverlayHelper.ClearPins(mapa);
                GMapRoute route = overlay.Routes.First(rota => rota.Name == "My route");
                List<Vehicle> vehiclesOnRoute = new();
                if (vehiclesList != null)
                {
                    foreach (var v in vehiclesList)
                    {
                        foreach (var c in v.TimestampedCoords)
                        {
                            PointLatLng point = new PointLatLng(c.Lat, c.Lon);
                            double distance = (double)route.DistanceTo(point);

                            Console.WriteLine($"Distancia entre pontos: {distance} Diferênça: {distance - Convert.ToDouble(3)}");

                            if (distance < Convert.ToDouble(3)) //Se a distância fôr menor que x metros
                            {
                                Console.WriteLine(distance);
                                bool vehicleExists = vehiclesOnRoute.Any(vehicle => vehicle.Id == v.Id);
                                if (!vehicleExists)
                                {
                                    vehiclesOnRoute.Add(v);
                                }
                                OverlayHelper.DrawPin(mapa, point, $"Veículo {v.Id}");
                            }
                        }
                    }
                }
                #endregion

                #region Colorir a rota / "Está trânsito"
                var nVeiculosMax = uiNVeiculosTransito.Value;
                var nVeiculosNaRota = vehiclesOnRoute.Count;
                if (nVeiculosNaRota > nVeiculosMax)
                {
                    labelTrafficState.Text = "Com trânsito";
                    route.Stroke = new Pen(Color.Red, 3);
                }
                else if (nVeiculosNaRota < nVeiculosMax && nVeiculosNaRota > nVeiculosMax / 2)
                {
                    labelTrafficState.Text = "Trânsito normal";
                    route.Stroke = new Pen(Color.Yellow, 3);
                }
                else
                {
                    labelTrafficState.Text = "Sem trânsito";
                    route.Stroke = new Pen(Color.Green, 3);
                }
                #endregion

                #region Desenhar pins na rota oposta
                GMapRoute oppositeRoute = overlay.Routes.First(rota => rota.Name == "My opposing route");
                List<Vehicle> vehiclesOnOppositeRoute = new();
                if (vehiclesList != null)
                {
                    foreach (var v in vehiclesList)
                    {
                        foreach (var c in v.TimestampedCoords)
                        {
                            PointLatLng point = new PointLatLng(c.Lat, c.Lon);
                            double distance = (double)oppositeRoute.DistanceTo(point);

                            Console.WriteLine($"Distancia entre pontos: {distance} Diferênça: {distance - Convert.ToDouble(3)}");

                            if (distance < Convert.ToDouble(3)) //Se a distância fôr menor que x metros
                            {
                                Console.WriteLine(distance);
                                bool vehicleExists = vehiclesOnOppositeRoute.Any(vehicle => vehicle.Id == v.Id);
                                if (!vehicleExists)
                                {
                                    vehiclesOnOppositeRoute.Add(v);
                                }
                                OverlayHelper.DrawPin(mapa, point, $"Veículo {v.Id}");
                            }
                        }
                    }
                }
                #endregion

                #region Colorir a rota / "Está trânsito"
                var nVeiculosNaRotaOposta = vehiclesOnOppositeRoute.Count;
                if (nVeiculosNaRotaOposta > nVeiculosMax)
                {
                    labelTrafficState.Text = "Com trânsito";
                    oppositeRoute.Stroke = new Pen(Color.Red, 3);
                }
                else if (nVeiculosNaRotaOposta < nVeiculosMax && nVeiculosNaRotaOposta > nVeiculosMax / 2)
                {
                    labelTrafficState.Text = "Trânsito normal";
                    oppositeRoute.Stroke = new Pen(Color.Yellow, 3);
                }
                else
                {
                    labelTrafficState.Text = "Sem trânsito";
                    oppositeRoute.Stroke = new Pen(Color.Green, 3);
                }
                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo correu mal!");
                Console.WriteLine(ex.Message);

            }
        }

        public static bool IsPointInsideRoute(PointLatLng point, List<PointLatLng> routePoints)
        {
            for (int i = 1; i < routePoints.Count; i++)
            {
                PointLatLng p1 = routePoints[i - 1];
                PointLatLng p2 = routePoints[i];

                //double distanceToSegment = CalculateDistanceToSegment(point, p1, p2);
                //if (distanceToSegment <= 0)
                return true;
            }

            return false;
        }

        static bool IsPointNearRoute(PointLatLng point, List<PointLatLng> routePoints, double proximityRadius)
        {
            for (int i = 1; i < routePoints.Count; i++)
            {
                PointLatLng p1 = routePoints[i - 1];
                PointLatLng p2 = routePoints[i];

                //double distanceToSegment = CalculateDistanceToSegment(point, p1, p2);
                //if (distanceToSegment <= proximityRadius)
                return true;
            }

            return false;
        }

        private void buttonGoToStreet_Click(object sender, EventArgs e)
        {
            string streetToGoTo = textBoxStreetToGoTo.Text;

            if (!String.IsNullOrEmpty(streetToGoTo))
            {
                try
                {
                    mapa.SetPositionByKeywords(streetToGoTo);
                }
                catch
                {
                    MessageBox.Show("Rua não encontrada.");
                }
            }
        }


        //static double CalculateDistanceToSegment(PointLatLng point, PointLatLng segmentStart, PointLatLng segmentEnd)
        //{
        //    double segmentLength = segmentStart.GetDistance(segmentEnd);
        //    if (segmentLength == 0)
        //    {
        //        return point.GetDistance(segmentStart);
        //    }

        //    double t = ((point.Lng - segmentStart.Lng) * (segmentEnd.Lng - segmentStart.Lng) +
        //                (point.Lat - segmentStart.Lat) * (segmentEnd.Lat - segmentStart.Lat)) / (segmentLength * segmentLength);

        //    if (t < 0)
        //        return point.GetDistance(segmentStart);
        //    if (t > 1)
        //        return point.GetDistance(segmentEnd);

        //    double closestPointLng = segmentStart.Lng + t * (segmentEnd.Lng - segmentStart.Lng);
        //    double closestPointLat = segmentStart.Lat + t * (segmentEnd.Lat - segmentStart.Lat);

        //    PointLatLng closestPoint = new PointLatLng(closestPointLat, closestPointLng);

        //    return point.GetDistance(closestPoint);
        //}
    }
}
