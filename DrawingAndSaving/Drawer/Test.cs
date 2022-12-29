using DrawingAndSaving.Drawer.Exporter;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace DrawingAndSaving.Drawer
{
    public class Test
    {
        Point[] Points = new Point[] { new Point(960, 239), new Point(480, 240), new Point(479, 481), new Point(721, 239), new Point(480, 480), new Point(719, 240), new Point(2161, 0), new Point(480, 240), new Point(720, 240), new Point(480, 480) };

        byte[] Types = new byte[0];
        public void Draw()
        {
            Bitmap output = new Bitmap(3000, 3000, PixelFormat.Format32bppRgb);
            Pen blackPen = new Pen(Color.White, 3);
            Pen blackPen2 = new Pen(Color.Red, 4);
            var pathes = File.ReadAllTextAsync("test.txt").GetAwaiter().GetResult();
            Points = new GetPointsFromPathMapper().GetPoints(pathes);


            using (var graphics = Graphics.FromImage(output))
            {
                var cherkassy = new GraphicsPath();
                for (var i = 0; i < Points.Length - 2; i++)
                {
                    cherkassy.AddLine(Points[i], Points[i + 1]);
                }
                graphics.DrawPath(blackPen2, cherkassy);
            }
            output.Save("test.png");
        }
    }
}
