using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using ProjetoFinalM2.Data;
using ProjetoFinalM2.Helpers;

namespace ProjetoFinalM2
{
    public partial class FormMap : Form
    {

        public int quantidadePontosNoPoligono = 0;
        public int totalVeiculos = 0;
        public List<Vehicle> vehiclesList = new List<Vehicle>();
        public List<PointLatLng> pointLatLngsList = new List<PointLatLng>();
        public List<PointLatLng> clickedPoints = new List<PointLatLng>();

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
                        OverlayHelper.DrawPin(mapa, new PointLatLng(item.Lat, item.Lng), "Veiculo " + vehicle.Id.ToString());
                    }
                    #endregion
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

                OverlayHelper.RefreshMap(mapa);
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
            if (clickedPoints.Count > 4)
            {
                clickedPoints.Clear();
            }
            clickedPoints.Add(new PointLatLng(mapa.FromLocalToLatLng(e.X, e.Y).Lat, mapa.FromLocalToLatLng(e.X, e.Y).Lng));
        }

        private void BtnCarregarFicheiro_Click(object sender, EventArgs e)
        {
            labelCurrentFileName.Text = FileLoader.LoadFile(false) ?? labelCurrentFileName.Text;
        }

        private void FormMap_Shown(object sender, EventArgs e)
        {
            //Codigo corre assim que o formulario acabar de carregar tudo

            #region Configurar o mapa:
            mapa.DragButton = MouseButtons.Right;
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
            labelSaveFileName.Text = FileLoader.SaveCoordToFile(DateTime.Now, labelLatitude.Text, labelLongitude.Text, 0, 1) ?? labelSaveFileName.Text;
        }

        private void ButtonRemoveOverlays_Click(object sender, EventArgs e)
        {
            OverlayHelper.ClearOverlays(mapa);
            clickedPoints.Clear();
        }

        private void ButtonPesquisarTransito_Click(object sender, EventArgs e)
        {
            String timeWorkaround = $"{dateTimePickerDate.Value.ToShortDateString()} {dateTimePickerTime.Value.ToShortTimeString()}:{trackBarTime.Value}";
            DateTime selectedTime = DateTime.Parse(timeWorkaround);

            //Para debugging
            Console.WriteLine($"TS: {selectedTime}");
            Console.WriteLine($"There are {vehiclesList.Count} vehicles in vehiclesList.");

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
                            tmpCoords.Add(new TimestampedCoords(c.Timestamp, c.Lat, c.Lon, c.Bearing));
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
                GMapOverlay overlay = mapa.Overlays.First(overlay => overlay.Id == "polygons");
                GMapPolygon polygon = overlay.Polygons.First(p => p.Name == "polygon");
                GMapOverlay markersOverlay = mapa.Overlays.First(overlay => overlay.Id == "MarkersOverlay");
                OverlayHelper.ClearPins(mapa);

                List<Vehicle> polygonVehicles = new();
                if (timedVehicles != null)
                {
                    foreach (var v in timedVehicles)
                    {
                        foreach (var c in v.TimestampedCoords)
                        {
                            bool isInside = polygon.IsInside(new PointLatLng(c.Lat, c.Lon));
                            if (isInside)
                            {
                                bool vehicleExists = polygonVehicles.Any(vehicle => vehicle.Id == v.Id);
                                if (!vehicleExists)
                                {
                                    polygonVehicles.Add(v);
                                }
                                OverlayHelper.DrawPin(mapa, new PointLatLng(c.Lat, c.Lon), $"Veículo {v.Id}");
                            }
                        }
                    }
                }
                #endregion

                #region Colorir o polígono / "Está trânsito"
                var nVeiculosMax = uiNVeiculosTransito.Value;
                int nVeiculos = polygonVehicles.Count;
                if (nVeiculos > 0)
                {
                    if (nVeiculos > nVeiculosMax)
                    {
                        labelTrafficState.Text = "Com trânsito";
                        polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
                        polygon.Stroke = new Pen(Color.Red, 1);
                    } else if (nVeiculos < nVeiculosMax && nVeiculos > nVeiculosMax / 2)
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
            ButtonPesquisarTransito_Click(sender, e);
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
            OverlayHelper.ClearRoutes(mapa);
            #region Obter informação da Rua
            // OS PONTOS SÃO ARMAZENADOS NUMA LISTA DE PONTOS (Tipo de cada elemento PointLatLng)
            PointLatLng clickedPoint1 = clickedPoints[0];
            PointLatLng clickedPoint2 = clickedPoints[1];
            PointLatLng clickedPoint3 = clickedPoints[2];
            PointLatLng clickedPoint4 = clickedPoints[3];
            clickedPoints.Clear();
            #endregion

            #region Obtém Direções Cartesianas
            double lat1 = clickedPoint1.Lat * Math.PI / 180;
            double lon1 = clickedPoint1.Lng * Math.PI / 180;
            double lat2 = clickedPoint2.Lat * Math.PI / 180;
            double lon2 = clickedPoint2.Lng * Math.PI / 180;

            double dLon = lon2 - lon1;

            double y = Math.Sin(dLon) * Math.Cos(lat2);
            double x = Math.Cos(lat1) * Math.Sin(lat2) - Math.Sin(lat1) * Math.Cos(lat2) * Math.Cos(dLon);

            double bearing = Math.Atan2(y, x) * 180 / Math.PI;

            if (bearing < 0)
            {
                bearing += 360;
            }

            // verificar em que sentido a rota vai
            switch (GetSimplifiedBearing(bearing))
            {
                case 0:
                    labelSentidoCart.Text = "Rota para Norte";
                    Console.WriteLine("A rota está a ir para norte.");
                    break;
                case 1:
                    labelSentidoCart.Text = "rota para este";
                    Console.WriteLine("a rota está a ir para este.");
                    break;
                case 2:
                    labelSentidoCart.Text = "Rota para Sul";
                    Console.WriteLine("A rota está a ir para sul.");
                    break;
                case 3:
                    labelSentidoCart.Text = "Rota para Oeste";
                    Console.WriteLine("A rota está a ir para oeste.");
                    break;
                default:
                    labelSentidoCart.Text = "Rota para Norte";
                    Console.WriteLine("A rota está a ir para norte.");
                    break;
            }
            #endregion

            // Obter informação a Rua do sobre o primeiro ponto
            List<Placemark> placemarks = null;
            var statusCode = GMapProviders.OpenStreetMap.GetPlacemarks(clickedPoint1, out placemarks);

            // Verificar se TUDO OK
            if (statusCode == GeoCoderStatusCode.OK && placemarks != null)
            {
                List<String> addresses = new List<string>();
                foreach (var placemark in placemarks)
                {
                    // Obter o nome da rua
                    addresses.Add(placemark.ThoroughfareName);
                    labelStreet.Text = placemark.ThoroughfareName;

                    MapRoute route = GMap.NET.MapProviders.OpenStreetMapProvider.Instance.GetRoute(clickedPoint1, clickedPoint2, false, false, 15);
                    MapRoute routeOpposite = GMap.NET.MapProviders.OpenStreetMapProvider.Instance.GetRoute(clickedPoint3, clickedPoint4, false, false, 15);
                    GMapRoute r = new GMapRoute(route.Points, "My route");
                    GMapRoute ro = new GMapRoute(routeOpposite.Points, "My opposing route");

                    GMapOverlay routesOverlay = new GMapOverlay("routes");
                    labelRouteLength.Text = route.Distance.ToString() + " km";
                    routesOverlay.Routes.Add(r);
                    routesOverlay.Routes.Add(ro);
                    mapa.Overlays.Add(routesOverlay);
                    mapa.ZoomAndCenterRoute(r);
                }
            }
        }

        private void BtnFilterPointsOnRoute_Click(object sender, EventArgs e)
        {
            try
            {
                //Inicialize lists
                List<PointLatLng> points = new();
                List<Vehicle> timedVehicles = new();
                List<Vehicle> vehiclesOnRoute = new();
                List<Vehicle> vehiclesOnOppositeRoute = new();

                //Find routes
                GMapOverlay overlay = mapa.Overlays.First(overlay => overlay.Id == "routes");
                GMapRoute route = overlay.Routes.First(route => route.Name == "My route");
                GMapRoute oppositeRoute = overlay.Routes.First(route => route.Name == "My opposing route");

                //int routeBearing = GetSimplifiedBearing(mapa.GetBearing(route.Points.First(), route.Points.Last()));
                //int oppositeRouteBearing = GetSimplifiedBearing(mapa.GetBearing(oppositeRoute.Points.First(), oppositeRoute.Points.Last()));

                OverlayHelper.ClearPins(mapa);

                //Sort points into routes
                if (vehiclesList != null)
                {
                    foreach (var v in vehiclesList)
                    {
                        Console.WriteLine($"Veículo {v.Id}:");
                        int pointCount = 0;
                        foreach (var c in v.TimestampedCoords)
                        {
                            pointCount++;
                            PointLatLng point = new PointLatLng(c.Lat, c.Lon);
                            double distance = (double)route.DistanceTo(point);
                            double roadWidth = Convert.ToDouble(3);
                            //int cBearing = GetSimplifiedBearing(c.Bearing);
                            //Console.WriteLine($"Street Bearing {routeBearing} Coordinate Bearing {c.Bearing} {cBearing}");

                            //Points for route
                            //if (routeBearing == cBearing)
                            if (distance <= roadWidth)
                            {
                                bool vehicleExists = vehiclesOnRoute.Any(vehicle => vehicle.Id == v.Id);
                                if (!vehicleExists)
                                {
                                    vehiclesOnRoute.Add(v);
                                }
                                OverlayHelper.DrawPin(mapa, point, $"Rota Veículo {v.Id} Ponto {pointCount}");
                            }
                            //Points for opposite route
                            //if (oppositeRouteBearing == cBearing)
                            //{
                            distance = (double)oppositeRoute.DistanceTo(point);

                            if (distance <= roadWidth)
                            {
                                bool vehicleExists = vehiclesOnOppositeRoute.Any(vehicle => vehicle.Id == v.Id);
                                if (!vehicleExists)
                                {
                                    vehiclesOnOppositeRoute.Add(v);
                                }
                                OverlayHelper.DrawPin(mapa, point, $"Rota Oposta Veículo {v.Id} Ponto {pointCount}");
                            }
                        }
                    }
                }


                //Color routes
                var nVeiculosMax = uiNVeiculosTransito.Value;
                var nVeiculosNaRota = vehiclesOnRoute.Count;
                var nVeiculosNaRotaOposta = vehiclesOnOppositeRoute.Count;

                if (nVeiculosNaRota > nVeiculosMax)
                {
                    labelTrafficState.Text = "Com trânsito";
                    route.Stroke = new Pen(Color.Red, 3);
                } else if (nVeiculosNaRota <= nVeiculosMax && nVeiculosNaRota > nVeiculosMax / 2)
                {
                    labelTrafficState.Text = "Trânsito normal";
                    route.Stroke = new Pen(Color.Yellow, 3);
                } else
                {
                    labelTrafficState.Text = "Sem trânsito";
                    route.Stroke = new Pen(Color.Green, 3);
                }

                if (nVeiculosNaRotaOposta > nVeiculosMax)
                {
                    labelTrafficState.Text = "Com trânsito";
                    oppositeRoute.Stroke = new Pen(Color.Red, 3);
                } else if (nVeiculosNaRotaOposta <= nVeiculosMax && nVeiculosNaRotaOposta > nVeiculosMax / 2)
                {
                    labelTrafficState.Text = "Trânsito normal";
                    oppositeRoute.Stroke = new Pen(Color.Yellow, 3);
                } else
                {
                    labelTrafficState.Text = "Sem trânsito";
                    oppositeRoute.Stroke = new Pen(Color.Green, 3);
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Algo correu mal!");
                Console.WriteLine(ex.Message);
            }
        }

        private void BtnGoToStreet_Click(object sender, EventArgs e)
        {
            string streetToGoTo = textBoxStreetToGoTo.Text;

            if (!String.IsNullOrEmpty(streetToGoTo))
            {
                try
                {
                    mapa.SetPositionByKeywords(streetToGoTo);
                } catch
                {
                    MessageBox.Show("Rua não encontrada.");
                }
            }
        }

        private int GetSimplifiedBearing(double dBearing)
        {
            int bearing = Convert.ToInt32(dBearing);
            Console.WriteLine($"Bearing {dBearing} converted to {bearing}");
            // verificar em que sentido a rota vai
            bool isGoingNorth = (bearing >= 0 && bearing < 45) || (bearing >= 315 && bearing <= 360);
            bool isGoingEast = bearing >= 45 && bearing < 135;
            bool isGoingSouth = bearing >= 135 && bearing < 225;
            bool isGoingWest = bearing >= 225 && bearing < 315;


            Console.WriteLine($"North {isGoingNorth} East {isGoingEast} South {isGoingSouth} West {isGoingWest}");

            // Atribuir à label a direção
            if (isGoingNorth)
            {
                return 0;
            } else if (isGoingEast)
            {
                return 1;
            } else if (isGoingSouth)
            {
                return 2;
            } else if (isGoingWest)
            {
                return 3;
            } else
            {
                return -1;
            }
        }

        private void labelStartDate_Click(object sender, EventArgs e)
        {

        }
    }
}
