using Avalonia;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using ProjetoFinalM2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalM2.Helpers
{
    static class OverlayHelper
    {
        public static void DrawRoute(GMapControl mapa, List<PointLatLng> pointsToDraw, Color color, float width)
        {
            ClearOverlays(mapa);

            GMapOverlay routes = new GMapOverlay("routes");
            GMapRoute route = new GMapRoute(pointsToDraw, "route");

            route.Stroke = new Pen(color, width);

            routes.Routes.Add(route);
            mapa.Overlays.Add(routes);
            mapa.ZoomAndCenterRoute(route);
        }

        public static void DrawPolygon(GMapControl mapa, List<PointLatLng> pointsToDraw, Color? color)
        {
            ClearOverlays(mapa);

            GMapOverlay polygons = new GMapOverlay("polygons");
            GMapPolygon polygon = new GMapPolygon(pointsToDraw, "polygon");

            if(color != null)
            {
                polygon.Fill = new SolidBrush(Color.FromArgb(50, (Color)color));
                polygon.Stroke = new Pen((Color)color, 1);
            }

            polygons.Polygons.Add(polygon);
            mapa.Overlays.Add(polygons);
            mapa.ZoomAndCenterRoutes("polygon");
        }

        public static void ClearOverlays(GMapControl mapa)
        {
            if (mapa.Overlays.Count > 0)
            {
                mapa.Overlays.Clear();
                mapa.Refresh();
            }
        }

        public static void DrawPin (GMapControl mapa, PointLatLng pinPoint, string tooltip)
        {
            GMapOverlay markersOverlay = new GMapOverlay("MarkersOverlay");
            PointLatLng markerPosition = pinPoint;
            GMarkerGoogle marker = new GMarkerGoogle(markerPosition, GMarkerGoogleType.red_pushpin);
            marker.ToolTipText = tooltip;
            markersOverlay.Markers.Add(marker);
            mapa.Overlays.Add(markersOverlay);
            mapa.ZoomAndCenterMarkers("MarkersOverlay");
        }

        public static void ClearPins (GMapControl mapa)
        {
            foreach (var o in mapa.Overlays)
            {
                o.Markers.Clear();
            }
        }
    }
}
