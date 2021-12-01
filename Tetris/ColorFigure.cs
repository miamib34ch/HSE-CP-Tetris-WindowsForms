using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    enum Directions
    {
        Top, Right, Left, Down
    }
    public class ColorFigure
    {
        static Color[] possibleColors = { Color.Blue, Color.Red, Color.Green };

        Random rnd = new Random();

        public Point Position;
        public int[] Size = new int[2]; // [width, height]
        public List<Point> Points { get; set; }
        public List<Color> Colors { get; set; }

        public ColorFigure()
        {

        }

        public ColorFigure(bool random)
        {
            if (random)
            {
                List<Point> points = new List<Point>();
                List<Color> colors = new List<Color>();

                var length = rnd.Next(2, 5);
                var point = new Point(0, 0);
                var topLeftPoint = new Point(0, 0);
                var bottomRightPoint = new Point(0, 0);

                points.Add(point);
                colors.Add(possibleColors[rnd.Next(0, possibleColors.Length)]);
                for (int i = 1; i < length; i++)
                {
                    var direction = (Directions)rnd.Next(0, 4);
                    switch (direction)
                    {
                        case Directions.Top:
                            point = new Point(point.X, point.Y - 1);
                            if (point.Y < topLeftPoint.Y)
                                topLeftPoint = new Point(topLeftPoint.X, point.Y);
                            break;
                        case Directions.Right:
                            point = new Point(point.X + 1, point.Y);
                            if (point.X > bottomRightPoint.X)
                                bottomRightPoint = new Point(point.X, bottomRightPoint.Y);
                            break;
                        case Directions.Down:
                            point = new Point(point.X, point.Y + 1);
                            if (point.Y > bottomRightPoint.Y)
                                bottomRightPoint = new Point(bottomRightPoint.X, point.Y);
                            break;
                        case Directions.Left:
                            point = new Point(point.X - 1, point.Y);
                            if (point.X < topLeftPoint.X)
                                topLeftPoint = new Point(point.X, topLeftPoint.Y);
                            break;
                    }
                    points.Add(point);
                    colors.Add(possibleColors[rnd.Next(0, possibleColors.Length)]);
                }
                Points = points;
                Colors = colors;

                Size[0] = bottomRightPoint.X - topLeftPoint.X + 1;
                Size[1] = bottomRightPoint.Y - topLeftPoint.Y + 1;
                Position = topLeftPoint;

                MoveX(0 - topLeftPoint.X);
                MoveY(0 - topLeftPoint.Y);
            }
        }

        public ColorFigure Clone()
        {
            var cloned = new ColorFigure();
            cloned.Points = new List<Point>(this.Points.Count);
            foreach (var p in Points)
                cloned.Points.Add(new Point(p.X, p.Y));

            cloned.Colors = new List<Color>(this.Colors.Count);
            foreach (var c in Colors)
                cloned.Colors.Add(c);
            cloned.Position = new Point(Position.X, Position.Y);
            cloned.Size = (int[])Size.Clone();
            return cloned;
        }

        public void Rotate()
        {
            var oldPosition = new Point(Position.X, Position.Y);
            MoveX(-Position.X);
            MoveY(-Position.Y);

            for (int i = 0; i < Points.Count; i++)
            {
                Points[i] = new Point(-Points[i].Y, Points[i].X);
            }

            int temp = Size[0];
            Size[0] = Size[1];
            Size[1] = temp;

            MoveX(oldPosition.X);
            MoveY(oldPosition.Y);
        }

        // метод для движения в сторону
        public void MoveX(int n = 1)
        {
            for (int i = 0; i < Points.Count; i++)
            {
                Points[i] = new Point(Points[i].X + n, Points[i].Y);
            }

            Position = new Point(Position.X + n, Position.Y);
        }

        // MoveDown(5), MoveDown()
        // Метод для движения вниз
        public void MoveY(int n = 1)
        {
            for (int i = 0; i < Points.Count; i++)
            {
                Points[i] = new Point(Points[i].X, Points[i].Y + n);
            }
            Position = new Point(Position.X, Position.Y + n);
        }
    }
}
