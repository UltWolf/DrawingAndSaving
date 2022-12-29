using System.Drawing;

namespace DrawingAndSaving.Drawer.Exporter
{
    public class GetPointsFromPathMapper
    {
        public Point[] GetPoints(string path)
        {
            var points = path.Split('l');
            var pointsResult = new Point[points.Length];
            for (var i = 0; i < points.Length - 1; i++)
            {
                var point = points[i];
                var numbers = point.Split(' ');

                pointsResult[i] = new Point(int.Parse(numbers[1].Replace(".", String.Empty)), int.Parse(numbers[2].Replace(".", String.Empty)));
            }
            return pointsResult;
        }
    }
}
