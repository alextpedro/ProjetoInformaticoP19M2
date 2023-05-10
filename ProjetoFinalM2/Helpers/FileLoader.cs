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

namespace ProjetoFinalM2.Helpers
{
    static class FileLoader
    {
        private static string? loadedFileName;
        private static string? savedCoordsFile;
        private static string? saveFileName;

        public static int numPoints = 0;
        public static int nOverlays = 0;

        public static string SaveCoordToFile(string lat, string lon)
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
                        fileStream.WriteLine("Latitude,Longitude");
                    }

                    fileStream.WriteLine($"{lat}, {lon}");
                }
            }

            return saveFileName;
        }

        public static List<TimestampedCoords>? LoadPointsFromFile()
        {
            if (!String.IsNullOrEmpty(loadedFileName))
            {
                using TextFieldParser parser = new TextFieldParser(loadedFileName);
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                List<TimestampedCoords> tmpTSCoords = new List<TimestampedCoords>();

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

                        var timestamp = DateTime.Parse(fields[0]);

                        tmpTSCoords.Add(new TimestampedCoords(timestamp, lat, lon));

                    }
                    catch { continue; } // Caso a linha esteja vazia e nao consiga produzir um double continua para a proxima
                }

                return tmpTSCoords;
            }
            else
            {
                return null;
            }
        }

        internal static string? LoadFile()
        {
            using (var selectFileDialog = new OpenFileDialog())
            {
                if (selectFileDialog.ShowDialog() == DialogResult.OK)
                {
                    loadedFileName = selectFileDialog.FileName;
                    Console.WriteLine($"Filename: {loadedFileName}");

                    return selectFileDialog.SafeFileName;
                }
            }
            return null;
        }
    }
}
