using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Instruction : Form
    {
        public Instruction()
        {
            InitializeComponent();
            if (Tetris.Lang == "R")
            {
                instructionLabel.Text = "«Tetris» представляет собой головоломку, построенную на использовании геометрических фигур «тетрамино» — разновидности полимино, состоящих из четырёх квадратов." +
                                        "\n«Bastard» — это свободный клон игры Тетрис, который пытается вычислить, насколько полезен тот или иной блок, и выдаёт вам наихудшие из возможных блоков." +
                                        "\n«TetColor» — это обычный тетрис, но фигуры состоят из случайных цветных блоков." +

                                        "\n\nПравила:" +
                                        "\nСлучайные фигурки тетрамино падают сверху в прямоугольный стакан шириной 10 и высотой 20 клеток.В полёте игрок может поворачивать фигурку и двигать её по горизонтали." +
                                        "\nТакже можно «сбрасывать» фигурку, то есть ускорять её падение, когда уже решено, куда фигурка должна упасть. Фигурка летит до тех пор, пока не наткнётся на другую фигурку либо" +
                                        "\nна дно стакана. Если при этом заполнился горизонтальный ряд из 10 клеток, он пропадает и всё, что выше него, опускается на одну клетку.Дополнительно показывается фигурка," +
                                        "\nкоторая будет следовать после текущей — это подсказка, которая позволяет игроку планировать действия. Игра заканчивается, когда новая фигурка не может поместиться в стакан." +
                                        "\nИгрок получает очки за каждый заполненный ряд, поэтому его задача — заполнять ряды, не заполняя сам стакан(по вертикали) как можно дольше, чтобы таким образом получить" +
                                        "\nкак можно больше очков." +
                                        "\n\nОчки:" +
                                        "\nОчки выдаются следующим образом:" +
                                        "\n1 ряд — 100 очков" +
                                        "\n2 ряда — 300 очков" +
                                        "\n3 ряда — 700 очков" +
                                        "\n4 ряда — 1500 очков" +
                                        "\n\nВ цветовом режим 1 убранный кубик — 1 очко" +
                                        "\n\nУправление:" +
                                        "\nW — поворот фигуры" +
                                        "\nA — влево" +
                                        "\nS — ускорение вниз" +
                                        "\nD — вправо" +
                                        "\nQ — пропуск падения" +
                                        "\nE — пауза / старт" +
                                        "\nR — сброс" +
                                        "\nH — открытие рекордов" +
                                        "\nI — инструкция" +
                                        "\nEsc — настройки" +
                                        "\nBackspace — выход" +
                                        "\nD1 — классический режим" +
                                        "\nD2 — ублюдочный режим" +
                                        "\nD3 — цветовой режим";
                button1.Text = "Ок";
                label1.Text = "Инструкция";
            }
            else
            {
                instructionLabel.Text = "«Tetris» is a puzzle based on the use of geometric shapes «tetrimino» - a type of polyomino, consisting of four squares." +
                                    "\n«Bastard» is a free Tetris clone that tries to figure out how useful a particular block is and gives you the worst possible blocks." +
                                    "\n«TetColor» is a regular Tetris, but the shapes are made up of random colored blocks." +

                                    "\n\nRules:" +
                                    "\nRandom tetrimino figures fall from above into a rectangular glass 10 cells wide and 20 cells high. In flight, the player can rotate the figure and move it horizontally." +
                                    "\nYou can also «drop» a figure, that is, accelerate its fall when it has already been decided where the figure should fall. The figurine flies until it bumps into another figurine, or" +
                                    "\nto the bottom of the glass. If at the same time a horizontal row of 10 cells is filled, it disappears and everything above it is lowered by one cell," +
                                    "\nwhich will follow after the current one is a hint that allows the player to plan actions. The game ends when the new figure cannot fit into the glass." +
                                    "\nThe player receives points for each filled row, so his task is to fill the rows without filling the glass itself (vertically) as long as possible in order to get" +
                                    "\nas many points as possible." +
                                    "\n\nPoints:" +
                                    "\nPoints are awarded as follows:" +
                                    "\n1 row — 100 points" +
                                    "\n2 rows — 300 points" +
                                    "\n3 rows — 700 points" +
                                    "\n4 rows — 1500 points" +
                                    "\n\nIn color mode, 1 removed cube — 1 point" +
                                    "\n\nControl:" +
                                    "\nW — figure rotation" +
                                    "\nA — to the left" +
                                    "\nS — downward acceleration" +
                                    "\nD — to the right" +
                                    "\nQ — fall skip" +
                                    "\nE — pause / start" +
                                    "\nR — reset" +
                                    "\nH — opening highscores" +
                                    "\nI — instruction" +
                                    "\nEsc — settings" +
                                    "\nBackspace — exit" +
                                    "\nD1 — classic game" +
                                    "\nD2 — bastard game" +
                                    "\nD3 — tetcolor game";
                button1.Text = "Ok";
                label1.Text = "Instruction";
            }
        }

        private void Instruction_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
