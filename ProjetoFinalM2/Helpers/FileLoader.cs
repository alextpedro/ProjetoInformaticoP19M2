using Avalonia;
using GMap.NET.WindowsForms;
using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using ProjetoFinalM2.Data;
using System.Globalization;

namespace ProjetoFinalM2.Helpers
{
    static class FileLoader
    {
        private static string? loadedFileName;
        private static string? savedCoordsFile;
        private static string? saveFileName;

        public static int numPoints = 0;
        public static int nOverlays = 0;

        public static string SaveCoordToFile(DateTime time, string lat, string lon, double bearing, int id)
        {
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

            if (!String.IsNullOrEmpty(savedCoordsFile))
            {
                using (StreamWriter fileStream = File.AppendText(savedCoordsFile))
                {
                    if (new FileInfo(savedCoordsFile).Length == 0)
                    {
                        fileStream.WriteLine("Timestamp,Latitude,Longitude,Bearing,Vehicle ID");
                    }

                    fileStream.WriteLine($"{time}, {lat}, {lon}, {bearing}, {id}");
                }
            }

            return saveFileName;
        }

        public static List<Vehicle>? LoadPointsFromFile()
        {
            if (!String.IsNullOrEmpty(loadedFileName))
            {
                using TextFieldParser parser = new TextFieldParser(loadedFileName);
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                List<Vehicle> tmpVehiclesList = new List<Vehicle>();

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
                        var timestamp = DateTime.Parse(fields[0]);
                        var lat = Convert.ToDouble(fields[1]);
                        var lon = Convert.ToDouble(fields[2]);
                        var bearing = Convert.ToDouble(fields[3]);
                        var id = Convert.ToInt32(fields[4]);

                        Vehicle tmpVehicle = new Vehicle(id);

                        bool vehicleExists = tmpVehiclesList.Any(vehicle => vehicle.Id == tmpVehicle.Id);
                        if (vehicleExists)
                        {
                            tmpVehiclesList.Find(vehicle => vehicle.Id == tmpVehicle.Id).TimestampedCoords.Add(new TimestampedCoords(timestamp, lat, lon, bearing));
                        }
                        else
                        {
                            tmpVehicle.TimestampedCoords.Add(new TimestampedCoords(timestamp, lat, lon, bearing));
                            tmpVehiclesList.Add(tmpVehicle);
                        }
                    }
                    catch { continue; } // Caso a linha esteja vazia e nao consiga produzir um double continua para a proxima
                }
                
                tmpVehiclesList.ForEach(v => Console.WriteLine(v.ToString()));
                return tmpVehiclesList;
            }
            else
            {
                return null;
            }
        }

        public static List<PointLatLng>? LoadPointsForPolygon()
        {
            string tmpLoadedFileName = LoadFile(true);
            if (!String.IsNullOrEmpty(tmpLoadedFileName))
            {
                using TextFieldParser parser = new TextFieldParser(tmpLoadedFileName);
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                List<PointLatLng> coordsRouteList = new List<PointLatLng>();

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

                        coordsRouteList.Add(new PointLatLng(lat, lon));

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine();
                        continue;
                    }
                }
                return coordsRouteList;
            }
            else
            {
                return null;
            }
        }

        internal static string? LoadFile(bool fullPath)
        {
            using (var selectFileDialog = new OpenFileDialog())
            {
                if (selectFileDialog.ShowDialog() == DialogResult.OK)
                {
                    loadedFileName = selectFileDialog.FileName;
                    Console.WriteLine($"Filename: {loadedFileName}");

                    if(fullPath)
                    {
                        return loadedFileName;
                    }
                    return selectFileDialog.SafeFileName;
                }
            }
            return null;
        }
    }
}
