using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class TetColorField //логика поля
    {
        Color BackgroundColor { get; set; } = Color.White;
        public Color[,] Field { get; set; }

        public ColorFigure ActiveFigure { get; set; }

        private int width;
        private int height;

        public int Score { get; set; }

        public TetColorField(int width, int height)
        {
            Score = 0;
            Field = new Color[height, width];

            for (int i = 0; i < Field.GetLength(0); i++)
                for (int j = 0; j < Field.GetLength(1); j++)
                {
                    Field[i, j] = BackgroundColor;
                }
            ActiveFigure = new ColorFigure(random: true);
            ActiveFigure.MoveX(width / 2 - 1);
        }

        public int Step()
        {
            // возвращает очки после ка;дого шага
            if (ActiveFigure == null)
            {
                // 1) Проверить, что ход не новый, проверить, что фигуру мо;н создать
                ActiveFigure = new ColorFigure(random: true);
                if (isAbleToMoveSide(true, n: Field.GetLength(1) / 2 - 1))
                    ActiveFigure.MoveX(Field.GetLength(1) / 2 - 1);
                else
                    throw new IndexOutOfRangeException();

                return 0;
            }
            else
            {
                // 2) Проверить, что мы можем подвинуть фигуру вниз.
                if (isAbleToMoveDown())
                {
                    ActiveFigure.MoveY();
                    return 0;
                }
                else
                {
                    var score = CalculateScore();
                    Score += score;
                    return score;
                }
            }
        }

        public int CalculateScore()
        {
            // логика заполнения поля
            for (int i = 0; i < ActiveFigure.Points.Count; i++)
            {
                Field[ActiveFigure.Points[i].Y, ActiveFigure.Points[i].X] = ActiveFigure.Colors[i];
            }

            // логика подсчета очков
            var current_score = 0;
            int score = 0;
            do
            {
                current_score = CalculateScoreAcrossLines();
                current_score += CalculateScoreAcrossColumns();
                score += current_score;
            }
            while (current_score != 0);

            ActiveFigure = null;
            return score;
        }

        public int CalculateScoreAcrossColumns()
        {
            int score = 0;

            for (int j = 0; j < Field.GetLength(1); j++)  // по строкам
            {
                List<Point> cells = new List<Point>();        // координаты клеток на удаление
                for (int i = Field.GetLength(0) - 1; i >= 0; i--)  // по координатам в строке
                {
                    if (Field[i, j] == BackgroundColor)
                    {
                        if (cells.Count > 2)
                        {
                            score += cells.Count;
                            for (int l = 0; l < cells.Count; l++)
                                ShiftColumnDown(cells[l], cells.Count);

                        }
                        cells = new List<Point>();
                        continue;
                    }

                    if (cells.Count == 0)
                        cells.Add(new Point(j, i));
                    else
                    {
                        if (Field[cells.Last<Point>().Y, cells.Last<Point>().X] == Field[i, j])
                            cells.Add(new Point(j, i));
                        else
                        {
                            if (cells.Count > 2)
                            {
                                score += cells.Count;
                                for (int l = 0; l < cells.Count; l++)
                                    ShiftColumnDown(cells[l], cells.Count);
                            }
                            cells = new List<Point>();
                            cells.Add(new Point(j, i));
                        }
                    }
                }

                if (cells.Count > 2)
                {
                    score += cells.Count;
                    for (int l = 0; l < cells.Count; l++)
                        ShiftColumnDown(cells[l], cells.Count);
                }

                if (score > 0)
                    return score;
            }
            return score;
        }

        public int CalculateScoreAcrossLines()
        {
            int score = 0;

            for (int i = Field.GetLength(0) - 1; i >= 0; i--) // по строкам
            {
                List<Point> cells = new List<Point>();        // координаты клеток на удаление
                for (int j = 0; j < Field.GetLength(1); j++)  // по координатам в строке
                {
                    if (Field[i, j] == BackgroundColor)
                    {
                        if (cells.Count > 2)
                        {
                            score += cells.Count;
                            for (int l = 0; l < cells.Count; l++)
                                ShiftColumnDown(cells[l], 1);

                        }
                        cells = new List<Point>();
                        continue;
                    }

                    if (cells.Count == 0)
                        cells.Add(new Point(j, i));
                    else
                    {
                        if (Field[cells.Last<Point>().Y, cells.Last<Point>().X] == Field[i, j])
                            cells.Add(new Point(j, i));
                        else
                        {
                            if (cells.Count > 2)
                            {
                                score += cells.Count;
                                for (int l = 0; l < cells.Count; l++)
                                    ShiftColumnDown(cells[l], 1);
                            }
                            cells = new List<Point>();
                            cells.Add(new Point(j, i));
                        }
                    }
                }

                if (cells.Count > 2)
                {
                    score += cells.Count;
                    for (int l = 0; l < cells.Count; l++)
                        ShiftColumnDown(cells[l], 1);
                }

                if (score > 0)
                    return score;
            }
            return score;
        }

        private void ShiftColumnDown(Point point, int v)
        {
            for (int y = point.Y; y >= 0; y--)
            {
                if (y - v < 0)
                    Field[y, point.X] = BackgroundColor;
                else
                    Field[y, point.X] = Field[y - v, point.X];
            }
        }

        public void TryRotateActiveFigure()
        {
            var cloned = ActiveFigure.Clone();
            var isAbleToRotate = true;

            cloned.Rotate();

            for (int i = 0; i < cloned.Points.Count; i++)
                isAbleToRotate &= cloned.Points[i].X >= 0 && cloned.Points[i].X <= Field.GetLength(1) - 1
                    && cloned.Points[i].Y >= 0 && cloned.Points[i].Y <= Field.GetLength(0) - 1;

            if (isAbleToRotate)
                for (int i = 0; i < cloned.Points.Count; i++)
                    isAbleToRotate &= Field[cloned.Points[i].Y, cloned.Points[i].X].Equals(BackgroundColor);

            if (isAbleToRotate)
                ActiveFigure = cloned;
        }

        // True - go right, false - go left
        public void MoveActiveFigureSide(bool direction)
        {
            if (isAbleToMoveSide(direction))
            {
                if (direction)
                    ActiveFigure.MoveX(1);
                else
                    ActiveFigure.MoveX(-1);
            }
        }

        // True - go right, false - go left
        public bool isAbleToMoveSide(bool direction, int n = 1)
        {
            var displacement = direction ? n : -n;

            var isEdge = (ActiveFigure.Position.X + displacement < 0) || (ActiveFigure.Position.X + ActiveFigure.Size[0] - 1 + displacement >= Field.GetLength(1));
            var isFree = true;

            try
            {
                if (!isEdge)
                    for (int i = 0; i < ActiveFigure.Points.Count; i++)
                    {
                        isFree &= Field[ActiveFigure.Points[i].Y, ActiveFigure.Points[i].X + displacement].Equals(BackgroundColor);
                    }
            }
            catch (IndexOutOfRangeException)
            {
                isFree = false;
            }

            return isFree && !isEdge;
        }

        private bool isAbleToMoveDown()
        {
            var isBottom = ActiveFigure.Position.Y + ActiveFigure.Size[1] >= Field.GetLength(0);
            var isFree = true;

            if (!isBottom)
                for (int i = 0; i < ActiveFigure.Points.Count; i++)
                {
                    isFree &= Field[ActiveFigure.Points[i].Y + 1, ActiveFigure.Points[i].X].Equals(BackgroundColor);
                }
            return isFree && !isBottom;
        }

        internal void MoveActiveFigureDown()
        {
            if (isAbleToMoveDown())
                ActiveFigure.MoveY();
        }
    }
}
