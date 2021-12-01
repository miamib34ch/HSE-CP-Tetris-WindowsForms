using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Tetris
{
    public partial class Tetris : Form
    {

        #region Поля класса

        int ChangeGame = 0;         //отвечает за смену режима: значение 0 - классический, 1 - ублюдочный, 2 - цветовой

        const int height = 20;      //высота поля
        const int width = 10;       //ширина поля

        public static int w;
        public static int h;

        TetColorField colorField;

        static PictureBox[,] pic_field = new PictureBox[height, width];  //для вывода картинки поля
        static PictureBox[,] pic_area = new PictureBox[height, width];
        static PictureBox[,] pic_next_figure = new PictureBox[3, 4];     //для вывода картинки следующей фигуры

        int[,] field = new int[height, width];  //поле
        int[,] figure = new int[2, 4];          //фигура
        int[,] next_figure = new int[2, 4];     //следующая фигура, создаём отдельно, так как нужна для вывода

        Random rnd = new Random();    //рандом нужен при выборе фигуры в классическом и цветном режимах

        int how_much_x = 0;           //переменная, по которой определяется движение по горизонтали (сколько было от начальной позиции) 
        int how_much_y = 0;           //переменная, по которой определяется движение вниз (сколько было от начальной позиции)
        int how_much_reverse = 0;     //переменная, по которой определяется, сколько раз был совершен поворот

        static int score = 0;         //переменная, в которую зависывается текущий рекорд

        string current_figure = "";         //строка, в которую записывается обозначение текущей фигуры
        string current_next_figure = "";    //строка, в которую записывается обозначение текущей следующей фигуры

        bool move_down_stop = true;   //логическая переменная, благодаря которой определяется нужно ли прекратить скип
        bool start_go = false;        //логическая переменная, чтобы определить идёт игра или на паузе
        bool GameOverWas = false;     //логическая переменная, чтобы определить, был ли GameOver

        static Color falling_figure_color = new Color();    //переменная для цвета падающей фигуры
        static Color fallen_figure_color = new Color();     //переменная для цвета упавшей фигуры

        static WMPLib.WindowsMediaPlayer wmp = new WMPLib.WindowsMediaPlayer(); //музыкальный плеер

        #endregion

        #region Свойства

        public static int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
            }
        }   //рекорд

        public static WMPLib.WindowsMediaPlayer WMP
        {
            get
            {
                return wmp;
            }
            set
            {
                wmp = value;
            }
        }   //музыкальный проигрыватель

        public static Color Falling_Figure_Color
        {
            get 
            {
                return falling_figure_color;
            }
            set
            {
                falling_figure_color = value;
            }
        }   //цвет падающей фигурки
        public static Color Fallen_Figure_Color
        {
            get
            {
                return fallen_figure_color;
            }
            set
            {
                fallen_figure_color = value;
            }
        }   //цвет упавшей фигурки

        public static string Lang { get; set; } //текущий язык

        #endregion

        public Tetris()
        {
            InitializeComponent();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    pic_field[i, j] = new PictureBox();
                    pic_field[i, j].BackColor = Color.White;
                    PanelField.Controls.Add(pic_field[i, j], j, i);
                }
            }   //первоначальная отрисовка поля
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    pic_next_figure[i, j] = new PictureBox();
                    pic_next_figure[i, j].BackColor = Color.White;
                    PanelNextFigure.Controls.Add(pic_next_figure[i, j], j, i);
                }
            }   //первоначальная отрисовка поля со следующей фигурой 
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    pic_area[i, j] = new PictureBox();
                    pic_area[i, j].BackColor = Color.White;
                    tableLayoutPanel1.Controls.Add(pic_area[i, j], j, i);
                }
            }   //первоначальная отрисовка поля со следующей фигурой 
            Falling_Figure_Color = Color.Red;
            Fallen_Figure_Color = Color.Green;
            figure = Create_Classic_Figure();
            next_figure = Create_Next_Classic_Figure();
            Lang = "E";
            WMP.URL = @"BackgroundMusic.mp3";
            WMP.settings.volume = 13;
            WMP.settings.setMode("loop", true);
            this.KeyDown += new KeyEventHandler(KeyFuncDown);
            this.KeyUp += new KeyEventHandler(KeyFuncR);
            tableLayoutPanel1.Visible = false;
            tableLayoutPanel1.Enabled = false;
            this.Size = new System.Drawing.Size(589, 775);
        }   //конструктор по-умолчанию, который вызывается при создании формы TetrisForm

        #region Функции нажатия кнопок

        private void HighScoresTableButton_Click(object sender, EventArgs e)
        {
            HighScoresTable highscorestable = new HighScoresTable();
            if(Lang == "R")
            {
                highscorestable.Name1.Text = "Имя";
                highscorestable.label1.Text = "Лучший рекорд";
                highscorestable.Type.Text = "Режим игры";

            }
            else
            {
                highscorestable.Name1.Text = "Name";
                highscorestable.label1.Text = "Best score";
                highscorestable.Type.Text = "Gamemode";

            }
            highscorestable.Show();

        }   //нажатие кнопки рекордов

        private void ClassicGameButton_Click(object sender, EventArgs e)
        {
            ResetButton_Click(sender, e);
        }   //нажатие кнопки режима Classic

        private void BastardGameButton_Click(object sender, EventArgs e)
        {
            ResetButton_Click(sender, e);
            ChangeGame = 1;
            count_figure = 0;

            figure = Create_First_Bastard_Figure();
            next_figure = Create_Next_Bastard_Figure();
        }   //нажатие кнопки режима Bastard

        private void tetColorGameButton_Click(object sender, EventArgs e)
        {
            ResetButton_Click(sender, e);
            ChangeGame = 2;
        }   //нажатие кнопки режима tetColor

        private void StartPauseButton_Click(object sender, EventArgs e)
        {
            if (GameOverWas)
            {
                int tmpChangeGame = ChangeGame; //сохранение выбранного режима игры
                ResetButton_Click(sender, e);
                ChangeGame = tmpChangeGame;
                if(ChangeGame == 1)
                {
                    figure = Create_First_Bastard_Figure();
                    next_figure = Create_Next_Bastard_Figure();
                }
            }
            if (start_go == false)
            {
                TimerGameFunc.Enabled = true;
                DrawTimer.Enabled = true;
                start_go = true;
            }
            else
            {
                TimerGameFunc.Enabled = false;
                start_go = false;
            }
        }   //нажатие кнопки старта и паузы

        private void ResetButton_Click(object sender, EventArgs e)
        {
            GameOverTimer.Enabled = false;
            TimerGameFunc.Enabled = false;
            TimerGameFunc.Interval = 700;
            DrawTimer.Enabled = false;
            ChangeGame = 0;
            how_much_x = 0;
            how_much_y = 0;
            h = 0;
            w = 0;
            how_much_reverse = 0;
            score = 0;
            CurrentScoreLabel.Text = $"{score}";
            current_figure = "";
            current_next_figure = "";
            move_down_stop = true;
            start_go = false;
            GameOverWas = false;
            ZeroingField();
            DrawEmptyField();
            figure = Create_Classic_Figure();
            next_figure = Create_Next_Classic_Figure();
            colorField = new TetColorField(width, height);
            count_figure = 0;
            try
            {
                for (int i = 0; i < h; i++)
                {
                    for (int j = 0; j < w; j++)
                    {
                        if (pole[i, j] == 1)
                        {
                            pole[i, j] = 0;
                        }
                    }
                }
            }
            catch
            {

            }
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    pic_area[i, j].BackColor = Color.White;
                }
            }
        }   //нажатие кнопки сброса

        private void InstructionButton_Click(object sender, EventArgs e)
        {
            Instruction instruction = new Instruction();    //создание формы инструкции
            instruction.Show();
        }   //нажатие кнопки инструкции

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();     //создание формы настроек
            settings.FallingFigBCEmpty();   //изменение цвета границ кнопок на пустой
            settings.FallenFigBCEmpty();    //изменение цвета границ кнопок на пустой
            settings.FallingFigBCWhite();   //изменение цвета границ кнопок текущего цвета фигурки на белый
            settings.FallenFigBCWhite();    //изменение цвета границ кнопок текущего цвета фигурки на белый
            settings.Set_StaticScoreLabel = StaticScoreLabel;   //присвоение ссылки на лейбл 
            settings.bHS = HighScoresTableButton;   //присвоение ссылки на кнопку
            settings.bCL = ClassicGameButton;
            settings.bBS = BastardGameButton;
            settings.bTC = tetColorGameButton;
            settings.bSP = StartPauseButton;
            settings.bRE = ResetButton;
            settings.bIN = InstructionButton;
            settings.bST = SettingsButton;
            settings.bEXT = ExitButton;
            settings.title = this;  //присвоение ссылки на форму, для того в дальнейшем изменить ей заголоволок окна
            if (start_go)   //если игра идёт, стваится пауза
                StartPauseButton_Click(sender, e);
            if (Lang == "R")    //если язык уже меняли на русский, перевод новой формы
                settings.RuLangButton_Click(sender, e);
            else    
                settings.EngLangButton_Click(sender, e);
            settings.BackMusicSet.Value = WMP.settings.volume;
            settings.Show();
        }   //нажатие кнопки настроек

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }   //нажатие кнопки выхода

        #endregion

        #region Функции игры

        #region Classic
        private int[,] Create_Classic_Figure()
        {
            switch (rnd.Next(7))
            {
                case 0:
                    current_figure = "I";
                    return new int[,] { { 0, 0, 0, 0 }, { 3, 4, 5, 6 } };   //I
                case 1:
                    current_figure = "O";
                    return new int[,] { { 0, 1, 0, 1 }, { 4, 4, 5, 5 } };   //O
                case 2:
                    current_figure = "L";
                    return new int[,] { { 0, 1, 2, 2 }, { 4, 4, 4, 5 } };   //L
                case 3:
                    current_figure = "J";
                    return new int[,] { { 0, 1, 2, 2 }, { 4, 4, 4, 3 } };   //J
                case 4:
                    current_figure = "Z";
                    return new int[,] { { 0, 0, 1, 1 }, { 3, 4, 4, 5 } };   //Z
                case 5:
                    current_figure = "S";
                    return new int[,] { { 0, 0, 1, 1 }, { 5, 4, 4, 3 } };   //S
                case 6:
                    current_figure = "T";
                    return new int[,] { { 0, 1, 1, 1 }, { 4, 3, 4, 5 } };   //T
                default:
                    return new int[,] { { }, { } };   //никода не вызовется, нужен, так как по-умолчанию должно что-то возвращаться
            }
        }   //создание фигуры в классическом режиме

        private int[,] Create_Next_Classic_Figure()
        {
            switch (rnd.Next(7))
            {
                case 0:
                    current_next_figure = "I";
                    return new int[,] { { 0, 0, 0, 0 }, { 3, 4, 5, 6 } };   //I
                case 1:
                    current_next_figure = "O";
                    return new int[,] { { 0, 1, 0, 1 }, { 4, 4, 5, 5 } };   //O
                case 2:
                    current_next_figure = "L";
                    return new int[,] { { 0, 1, 2, 2 }, { 4, 4, 4, 5 } };   //L
                case 3:
                    current_next_figure = "J";
                    return new int[,] { { 0, 1, 2, 2 }, { 4, 4, 4, 3 } };   //J
                case 4:
                    current_next_figure = "Z";
                    return new int[,] { { 0, 0, 1, 1 }, { 3, 4, 4, 5 } };   //Z
                case 5:
                    current_next_figure = "S";
                    return new int[,] { { 0, 0, 1, 1 }, { 5, 4, 4, 3 } };   //S
                case 6:
                    current_next_figure = "T";
                    return new int[,] { { 0, 1, 1, 1 }, { 4, 3, 4, 5 } };   //T
                default:
                    return new int[,] { { }, { } };   //никода не вызовется
            }
        }   //создание следующей фигуры в классическом режиме

        #endregion

        #region Bastard

        int[,] pole = new int[1,10];

        private int[,] AnalizePole()
        {
            int max = SearchMax();
            int min = SearchMin();
            w = max;
            h = min;
            int n = min - max;
            pole = new int[n, 10];
            int count = -1;

            for(int i = max; i < min; i++)
            {
                count++;
                try
                {
                    for (int j = 0; j < 10; j++)
                    {
                        pole[count, j] = field[i, j];
                    }
                }
                catch
                {

                }
  
            }

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    if (pole[i, j] == 0)
                    {
                        try
                        {
                            if (pole[i - 1, j] == 1)
                            {
                                pole[i, j] = 1;
                            }
                        }
                        catch { }
                    }

                }
            }
            return pole;
        }

        private void MoveRight(int [,] figure)
        {
            for (int i = 0; i < 4; i++)
                figure[1, i]++;
        }   //движение вправо

        private void MoveLeft(int[,] figure)
        {
            for (int i = 0; i < 4; i++)
                figure[1, i]--;
        }   //движение влево

        private void MoveDown(int[,] figure)
        {
            for (int i = 0; i < 4; i++)
                figure[0, i]++;
        }   //движение вниз

        private int[,] NextBastardFigure()
        {

            int[,] bastard_T_up = new int[,] { { 0, 1, 1, 1 },
                                           { 1, 0, 1, 2 } };   //T (двойной цикл)

            int[,] bastard_T_left = new int[,] { { 1, 0, 1, 2 },
                                             { 0, 1, 1, 1 } }; //T

            int[,] bastard_T_right = new int[,] { { 0, 1, 2, 1 },
                                              { 0, 0, 0, 1 } };//T

            int[,] bastard_T_down = new int[,] { { 0, 0, 0, 1 },
                                             { 0, 1, 2, 1 } }; //T (двойной цикл)

            int[,] bastard_O_up = new int[,] { { 0, 0, 1, 1 },
                                        { 0, 1, 0, 1 } };      //O (двойной цикл)

            int[,] bastard_L_up = new int[,] { { 0, 1, 2, 2  },
                                           { 0, 0, 0, 1 } };   //L

            int[,] bastard_L_right = new int[,] { { 1, 1, 1, 0  },
                                              { 0, 1, 2, 2 } };//L (двойной цикл)

            int[,] bastard_L_down = new int[,] { { 0, 0, 1, 2  },
                                             { 0, 1, 1, 1 } }; //L 

            int[,] bastard_L_left = new int[,] { { 0, 0, 0, 1  },
                                             { 0, 1, 2, 0 } }; //L (двойной цикл)

            int[,] bastard_J_up = new int[,] { { 2, 0, 1, 2 },
                                               { 0, 1, 1, 1 } };  //J

            int[,] bastard_J_right = new int[,] { { 0, 0, 0, 1 },
                                            { 0, 1, 2, 2 } };  //J (двойной цикл)

            int[,] bastard_J_down = new int[,] { { 0, 1, 2, 0 },
                                            { 0, 0, 0, 1 } };  //J 

            int[,] bastard_J_left = new int[,] { { 0, 1, 1, 1 },
                                            { 0, 0, 1, 2 } };  //J 

            int[,] bastard_Z_up = new int[,] { { 0, 0, 1, 1 },
                                               { 0, 1, 1, 2 } };   //Z (двойной цикл)

            int[,] bastard_Z_down = new int[,] { { 0, 1, 1, 2 },
                                           { 1, 1, 0, 0 } };   //Z 

            int[,] bastard_S_up = new int[,] { { 1, 1, 0, 0 },
                                           { 0, 1, 1, 2 } };   //S (двойной цикл)

            int[,] bastard_S_down = new int[,] { { 0, 1, 1, 2 },
                                             { 0, 0, 1, 1 } }; //S


            int bastard_O = 0; // счетчик фигуры O
            int bastard_L = 0; // счетчик фигуры L
            int bastard_J = 0; // счетчик фигуры J
            int bastard_Z = 0; // счетчик фигуры Z
            int bastard_S = 0; // счетчик фигуры S
            int bastard_T = 0; // счетчик фигуры T   

            int[,] pole = AnalizePole();

            int max = SearchMax();
            int min = SearchMin();
            int n = min - max;

            //анализ фигур T_up и T_down
            for(int l = 0; l < n-1; l++)
            {
                for (int i = 0; i < 7; i++)
                {
                    //анализ T_up
                    if (FindMistake(bastard_T_up))
                        bastard_T++;
                    MoveRight(bastard_T_up);

                    if (FindMistake(bastard_T_down))
                        bastard_T++;
                    MoveRight(bastard_T_down);
                }
                for(int i = 0; i < 7; i++)
                {
                    MoveLeft(bastard_T_up);
                    MoveLeft(bastard_T_down);
                }
                MoveDown(bastard_T_up);
                MoveDown(bastard_T_down);
            }

            //анализ фигур T_left и T_right
            for (int l = 0; l < n-2; l++)
            {
                for (int i = 0; i < 8; i++)
                {
                    //анализ T_up
                    if (FindMistake(bastard_T_right))
                        bastard_T++;
                    MoveRight(bastard_T_right);

                    if (FindMistake(bastard_T_left))
                        bastard_T++;
                    MoveRight(bastard_T_left);
                }
                for (int i = 0; i < 8; i++)
                {
                    MoveLeft(bastard_T_right);
                    MoveLeft(bastard_T_left);
                }
                MoveDown(bastard_T_right);
                MoveDown(bastard_T_left);
            }
            //анализ фигуры O
            for (int l = 0; l < n-1; l++)
            {
                for (int i = 0; i < 8; i++)
                {
                    //анализ O_up
                    if (FindMistake(bastard_O_up))
                        bastard_O++;
                    MoveRight(bastard_O_up);
                }
                for (int i = 0; i < 8; i++)
                {
                    MoveLeft(bastard_O_up);
                }
                MoveDown(bastard_O_up);
            }

            //анализ фигуры L_up и L_down
            for(int l = 0; l < n-2; l++)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (FindMistake(bastard_L_up))
                        bastard_L++;
                    MoveRight(bastard_L_up);

                    if (FindMistake(bastard_L_down))
                        bastard_L++;
                    MoveRight(bastard_L_down);
                }
                for (int i = 0; i < 8; i++)
                {
                    MoveLeft(bastard_L_up);
                    MoveLeft(bastard_L_down);
                }
                MoveDown(bastard_L_up);
                MoveDown(bastard_L_down);
            }
            //анализ фигур L_right и L_left
            for (int l = 0; l < n-1; l++)
            {
                for (int i = 0; i < 7; i++)
                {
                    if (FindMistake(bastard_L_right))
                        bastard_L++;
                    MoveRight(bastard_L_right);

                    if (FindMistake(bastard_L_left))
                        bastard_L++;
                    MoveRight(bastard_L_left);
                }
                for (int i = 0; i < 7; i++)
                {
                    MoveLeft(bastard_L_right);
                    MoveLeft(bastard_L_left);
                }
                MoveDown(bastard_L_right);
                MoveDown(bastard_L_left);
            }

            //анализ фигур J_up и J_down
            for (int l = 0; l < n-2; l++)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (FindMistake(bastard_J_up))
                        bastard_J++;
                    MoveRight(bastard_J_up);

                    if (FindMistake(bastard_J_down))
                        bastard_J++;
                    MoveRight(bastard_J_down);
                }
                for (int i = 0; i < 8; i++)
                {
                    MoveLeft(bastard_J_up);
                    MoveLeft(bastard_J_down);
                }
                MoveDown(bastard_J_up);
                MoveDown(bastard_J_down);
            }

            //анализ фигур J_right и J_left
            for (int l = 0; l < n - 1; l++)
            {
                for (int i = 0; i < 7; i++)
                {
                    if (FindMistake(bastard_J_right))
                        bastard_J++;
                    MoveRight(bastard_J_right);

                    if (FindMistake(bastard_J_left))
                        bastard_J++;
                    MoveRight(bastard_J_left);
                }
                for (int i = 0; i < 7; i++)
                {
                    MoveLeft(bastard_J_right);
                    MoveLeft(bastard_J_left);
                }
                MoveDown(bastard_J_right);
                MoveDown(bastard_J_left);
            }

            //анализ фигуры Z_up
            for (int l = 0; l < n-1; l++)
            {
                for (int i = 0; i < 7; i++)
                {
                    if (FindMistake(bastard_Z_up))
                        bastard_Z++;
                    MoveRight(bastard_Z_up);
                }
                for (int i = 0; i < 7; i++)
                {
                    MoveLeft(bastard_Z_up);
                }
                MoveDown(bastard_Z_up);
            }

            //анализ фигуры Z_down
            for(int l = 0; l < n - 2; l++)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (FindMistake(bastard_Z_down))
                        bastard_Z++;
                    MoveRight(bastard_Z_down);
                }
                for (int i = 0; i < 8; i++)
                {
                    MoveLeft(bastard_Z_down);
                }
                MoveDown(bastard_Z_down);
            }

            //анализ фигуры S_up
            for (int l = 0; l < n-1; l++)
            {
                for (int i = 0; i < 7; i++)
                {
                    if (FindMistake(bastard_S_up))
                        bastard_S++;
                    MoveRight(bastard_S_up);
                }
                for (int i = 0; i < 7; i++)
                {
                    MoveLeft(bastard_S_up);
                }
                MoveDown(bastard_S_up);
            }

            //анализ фигуры S_dowm
            for(int l = 0; l < n - 2; l++)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (FindMistake(bastard_S_down))
                        bastard_S++;
                    MoveRight(bastard_S_down);
                }
                for (int i = 0; i < 8; i++)
                {
                    MoveLeft(bastard_S_down);
                }
                MoveDown(bastard_S_down);
            }
            bastard_L -= 1;
            bastard_J -= 1;
            bastard_T += 1;
            bastard_O = bastard_O * 3+10;
            bastard_Z = bastard_Z * 2;
            bastard_S = bastard_S * 2;

            if (bastard_T > bastard_O && bastard_T > bastard_O && bastard_T > bastard_L && bastard_T > bastard_J && bastard_T > bastard_Z && bastard_T > bastard_S)
            {
                return new int[,] { { 0, 1, 1, 1 }, { 4, 3, 4, 5 } };   //T
            }
            else
            {
                if (bastard_O > bastard_T && bastard_O > bastard_L && bastard_O > bastard_J && bastard_O > bastard_Z && bastard_O > bastard_S)
                {
                    return new int[,] { { 0, 1, 0, 1 }, { 4, 4, 5, 5 } };   //O
                }
                else
                {
                    if (bastard_L > bastard_O && bastard_L > bastard_J && bastard_L > bastard_Z && bastard_L > bastard_S)
                    {
                        return new int[,] { { 0, 1, 2, 2 }, { 4, 4, 4, 5 } };   //L
                    }
                    else
                    {
                        if (bastard_J > bastard_L && bastard_J > bastard_Z && bastard_J > bastard_S)
                        {
                            return new int[,] { { 0, 1, 2, 2 }, { 4, 4, 4, 3 } };   //J
                        }
                        else
                        {
                            if (bastard_Z > bastard_J && bastard_Z > bastard_S)
                            {
                                return new int[,] { { 0, 0, 1, 1 }, { 3, 4, 4, 5 } };   //Z
                            }
                            else
                            {
                                return new int[,] { { 0, 0, 1, 1 }, { 5, 4, 4, 3 } };   //S
                            }
                        }
                    }
                }
            }
        }

        private bool FindMistake(int[,] figure)
        {
            for (int i = 0; i < 4; i++)
                if (figure[1, i] >= width || figure[0, i] >= height ||
                    figure[1, i] < 0 || figure[0, i] < 0 ||
                    pole[figure[0, i], figure[1, i]] == 1)
                    return true;
            return false;
        }   //нахождение ошибки 

        private int[,] Create_First_Bastard_Figure()
        {
            count_figure++;
            switch (rnd.Next(7))
            {
                case 0:
                    current_figure = "I";
                    return new int[,] { { 0, 0, 0, 0 }, { 3, 4, 5, 6 } };   //I
                case 1:
                    current_figure = "O";
                    return new int[,] { { 0, 1, 0, 1 }, { 4, 4, 5, 5 } };   //O
                case 2:
                    current_figure = "L";
                    return new int[,] { { 0, 1, 2, 2 }, { 4, 4, 4, 5 } };   //L
                case 3:
                    current_figure = "J";
                    return new int[,] { { 0, 1, 2, 2 }, { 4, 4, 4, 3 } };   //J
                case 4:
                    current_figure = "Z";
                    return new int[,] { { 0, 0, 1, 1 }, { 3, 4, 4, 5 } };   //Z
                case 5:
                    current_figure = "S";
                    return new int[,] { { 0, 0, 1, 1 }, { 5, 4, 4, 3 } };   //S
                case 6:
                    current_figure = "T";
                    return new int[,] { { 0, 1, 1, 1 }, { 4, 3, 4, 5 } };   //T
                default:
                    return new int[,] { { }, { } };   //никода не вызовется, нужен, так как по-умолчанию должно что-то возвращаться
            }

        } //создание 1 фигурки
        
        private bool Analize_I()
        {
            int[,] bastard_I_down = new int[,] { { 2, 3, 4, 5 },
                                                { 0, 0, 0, 0 } };

            int[,] pole = AnalizePole();

            int max = SearchMax();
            int min = SearchMin();
            int n = min - max;

            //анализ фигуры l_up
            for (int l = 0; l < n - 5; l++)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (!FindMistake(bastard_I_down))
                        return false;
                    MoveRight(bastard_I_down);
                }
                for (int i = 0; i < 9; i++)
                {
                    MoveLeft(bastard_I_down);
                }
                MoveDown(bastard_I_down);
            }
            return true;
        }

        int count_I = 0;

        private int[,] Create_Bastard_Figure()
        {
           
            if (count_figure < 5)
            {
                
                int[,] figure_first = Create_First_Bastard_Figure();
                return figure_first;
            }
            else
            {
                count_I++;
                if(Analize_I() == true && count_I > 12)
                {
                    count_I = 0;
                    current_figure = "I";
                    return new int[,] { { 0, 0, 0, 0 }, { 3, 4, 5, 6 } };
                }
                int[,] figure = NextBastardFigure();

                int[,] figure_I = new int[,] { { 0, 0, 0, 0 }, { 3, 4, 5, 6 } };   //I
                int[,] figure_O = new int[,] { { 0, 1, 0, 1 }, { 4, 4, 5, 5 } };   //O
                int[,] figure_L = new int[,] { { 0, 1, 2, 2 }, { 4, 4, 4, 5 } };   //L
                int[,] figure_J = new int[,] { { 0, 1, 2, 2 }, { 4, 4, 4, 3 } };   //J
                int[,] figure_Z = new int[,] { { 0, 0, 1, 1 }, { 3, 4, 4, 5 } };   //Z
                int[,] figure_S = new int[,] { { 0, 0, 1, 1 }, { 5, 4, 4, 3 } };   //S
                int[,] figure_T = new int[,] { { 0, 1, 1, 1 }, { 4, 3, 4, 5 } };   //T


                if (figure[1, 3] == figure_I[1, 3])
                {
                    current_figure = "I";
                }
                else
                {
                    if (figure[1, 2] == figure_O[1, 2] && figure[0, 1] == figure_O[0, 1])
                    {
                        current_figure = "O";
                    }
                    else
                    {
                        if (figure[0, 3] == figure_L[0, 3] && figure[1, 3] == figure_L[1, 3])
                        {
                            current_figure = "L";
                        }
                        else
                        {
                            if (figure[0, 3] == figure_J[0, 3] && figure[1, 3] == figure_J[1, 3])
                            {
                                current_figure = "J";
                            }
                            else
                            {
                                if (figure[0, 3] == figure_Z[0, 3] && figure[1, 0] == figure_Z[1, 0])
                                {
                                    current_figure = "Z";
                                }
                                else
                                {
                                    if (figure[0, 3] == figure_S[0, 3] && figure[1, 0] == figure_S[1, 0])
                                    {
                                        current_figure = "S";
                                    }
                                    else
                                    {
                                        if (figure[0, 2] == figure_T[0, 2] && figure[1, 1] == figure_T[1, 1])
                                        {
                                            current_figure = "T";
                                        }
                                        else
                                        {

                                        }
                                    }
                                }
                            }
                        }
                    }
                }  //отрисовка фигур с сравнением

                return figure;
            }
        }

        private int Lenght()
        {
            int count_connect = 0;
            int connect_lengt = 0;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (field[i, j] == 1)
                    {
                        count_connect = i;
                        goto LoopEnd;
                    }
                }
            }
        LoopEnd:
            for (int i = 0; i < width; i++)
            {
                if (field[count_connect, i] == 1)
                {
                    connect_lengt++;
                }
            }
            while (connect_lengt < 3)
            {
                count_connect += 1;
                connect_lengt = 0;
                for (int i = 0; i < width; i++)
                {
                    if (field[count_connect, i] == 1)
                    {
                        connect_lengt++;
                    }
                }
            }
            return count_connect;
        }

        private int SearchMax()
        {
            int max = 21;
            for(int i = 0; i < width; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    if (field[j, i] == 1)
                    {
                        if(j < max)
                            max = j;
                        break;
                    }              
                }
            }
            if(max == 1)
            {
                return max;
            }
            else if(max != 2)
            {
                max -= 2;
                return max;
            }
            else
            {
                return max;
            }  
        }

        private int SearchMin()
        {
            int min = 0;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (field[j, i] == 1)
                    {
                        if(j > min)
                        {
                            min = j;
                        }
                        break;
                    }
                }
            }
            if(min != 19)
            {
                min++;
            }

            return min;
        }
 
        int count_figure = 0; //счетчик фигур

        private int[,] Create_Next_Bastard_Figure()
        {
            switch (rnd.Next(7))
            {
                case 0:
                    
                    return new int[,] { { 0, 0, 0, 0 }, { 3, 4, 5, 6 } };   //I
                case 1:
                    
                    return new int[,] { { 0, 1, 0, 1 }, { 4, 4, 5, 5 } };   //O
                case 2:
                   
                    return new int[,] { { 0, 1, 2, 2 }, { 4, 4, 4, 5 } };   //L
                case 3:
                   
                    return new int[,] { { 0, 1, 2, 2 }, { 4, 4, 4, 3 } };   //J
                case 4:
                  
                    return new int[,] { { 0, 0, 1, 1 }, { 3, 4, 4, 5 } };   //Z
                case 5:
                  
                    return new int[,] { { 0, 0, 1, 1 }, { 5, 4, 4, 3 } };   //S
                case 6:
                  
                    return new int[,] { { 0, 1, 1, 1 }, { 4, 3, 4, 5 } };   //T
                default:
                    return new int[,] { { }, { } };   //никода не вызовется, нужен, так как по-умолчанию должно что-то возвращаться
            }
        }

        #endregion

        #region Функции TetrisColor
        void DrawTetColorField()
        {
            CurrentScoreLabel.Text = $"{colorField.Score}";
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    pic_field[j, i].BackColor = colorField.Field[j, i];
            if (colorField.ActiveFigure != null)
                for (int i = 0; i < colorField.ActiveFigure.Points.Count; i++)
                    pic_field[colorField.ActiveFigure.Points[i].Y, colorField.ActiveFigure.Points[i].X].BackColor = colorField.ActiveFigure.Colors[i];
        }
        #endregion

        private bool FindMistake()
        {
            for (int i = 0; i < 4; i++)
                if (figure[1, i] >= width || figure[0, i] >= height ||
                    figure[1, i] < 0 || figure[0, i] < 0 ||
                    field[figure[0, i], figure[1, i]] == 1)
                    return true;
            return false;
        }   //нахождение ошибки 

        private void MoveLeft()
        {
            if (ChangeGame == 1 || ChangeGame == 0)
            {
                for (int i = 0; i < 4; i++)
                    figure[1, i]--;
                if (FindMistake())
                {
                    for (int i = 0; i < 4; i++)
                        figure[1, i]++;
                    how_much_x++;
                }
                how_much_x--;
            }
            else
            {
                if (colorField.ActiveFigure != null)
                    colorField.MoveActiveFigureSide(false);
            }
        }   //движение влево

        private void MoveRight()
        {
            if (ChangeGame == 1 || ChangeGame == 0)
            {
                for (int i = 0; i < 4; i++)
                    figure[1, i]++;
                if (FindMistake())
                {
                    for (int i = 0; i < 4; i++)
                        figure[1, i]--;
                    how_much_x--;
                }
                how_much_x++;
            }
            else
            {
                if (colorField.ActiveFigure != null)
                    colorField.MoveActiveFigureSide(true);
            }
        }   //движение вправо

        private void MoveDown()
        {
            if (ChangeGame == 1 || ChangeGame == 0)
            {
                for (int i = 0; i < 4; i++)
                    figure[0, i]++;
                if (FindMistake())
                {
                    for (int i = 0; i < 4; i++)
                        figure[0, i]--;
                    how_much_y--;
                }
                how_much_y++;
            }
            else
            {
                if (colorField.ActiveFigure != null)
                    colorField.MoveActiveFigureDown();
            }
        }   //движение вниз

        private void Skip()
        {
            do
            {
                for (int i = 0; i < 4; i++)
                    figure[0, i]++;
                if (FindMistake())
                {
                    for (int i = 0; i < 4; i++)
                        figure[0, i]--;
                    move_down_stop = false;
                    how_much_y--;
                }
                how_much_y++;
            } while (move_down_stop);
            move_down_stop = true;
        }   //движение вниз

        private void Reverse()
        {
            if (ChangeGame == 1 || ChangeGame == 0)
            {
                var figure_copy = new int[2, 4];
                Array.Copy(figure, figure_copy, figure.Length);
                int how_much_reverse_temp = how_much_reverse;
                if (how_much_reverse == 0)
                {
                    if (current_figure == "I")
                    {
                        figure = new int[2, 4] { { 1 + how_much_y, 0 + how_much_y, -1 + how_much_y, -2 + how_much_y }, { 4 + how_much_x, 4 + how_much_x, 4 + how_much_x, 4 + how_much_x } };
                        how_much_reverse = 1;
                    }
                    else
                    {
                        if (current_figure == "L")
                        {
                            figure = new int[2, 4] { { 1 + how_much_y, 1 + how_much_y, 1 + how_much_y, 0 + how_much_y }, { 3 + how_much_x, 4 + how_much_x, 5 + how_much_x, 5 + how_much_x } };
                            how_much_reverse = 1;
                        }
                        else
                        {
                            if (current_figure == "J")
                            {
                                figure = new int[2, 4] { { 1 + how_much_y, 1 + how_much_y, 1 + how_much_y, 2 + how_much_y }, { 3 + how_much_x, 4 + how_much_x, 5 + how_much_x, 5 + how_much_x } };
                                how_much_reverse = 1;
                            }
                            else
                            {
                                if (current_figure == "Z")
                                {
                                    figure = new int[2, 4] { { 1 + how_much_y, 0 + how_much_y, 0 + how_much_y, -1 + how_much_y }, { 4 + how_much_x, 4 + how_much_x, 5 + how_much_x, 5 + how_much_x } };
                                    how_much_reverse = 1;
                                }
                                else
                                {
                                    if (current_figure == "S")
                                    {
                                        figure = new int[2, 4] { { -1 + how_much_y, 0 + how_much_y, 0 + how_much_y, 1 + how_much_y }, { 4 + how_much_x, 4 + how_much_x, 5 + how_much_x, 5 + how_much_x } };
                                        how_much_reverse = 1;
                                    }
                                    else
                                    {
                                        if (current_figure == "T")
                                        {
                                            figure = new int[2, 4] { { 1 + how_much_y, 2 + how_much_y, 1 + how_much_y, 0 + how_much_y }, { 3 + how_much_x, 4 + how_much_x, 4 + how_much_x, 4 + how_much_x } };
                                            how_much_reverse = 1;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (how_much_reverse == 1)
                    {
                        if (current_figure == "I")
                        {
                            figure = new int[2, 4] { { 0 + how_much_y, 0 + how_much_y, 0 + how_much_y, 0 + how_much_y }, { 2 + how_much_x, 3 + how_much_x, 4 + how_much_x, 5 + how_much_x } };
                            how_much_reverse = 2;
                        }
                        else
                        {
                            if (current_figure == "L")
                            {
                                figure = new int[2, 4] { { 0 + how_much_y, 0 + how_much_y, 1 + how_much_y, 2 + how_much_y }, { 3 + how_much_x, 4 + how_much_x, 4 + how_much_x, 4 + how_much_x } };
                                how_much_reverse = 2;
                            }
                            else
                            {
                                if (current_figure == "J")
                                {
                                    figure = new int[2, 4] { { 2 + how_much_y, 1 + how_much_y, 0 + how_much_y, 0 + how_much_y }, { 4 + how_much_x, 4 + how_much_x, 4 + how_much_x, 5 + how_much_x } };
                                    how_much_reverse = 2;
                                }
                                else
                                {
                                    if (current_figure == "Z")
                                    {
                                        figure = new int[2, 4] { { 1 + how_much_y, 1 + how_much_y, 0 + how_much_y, 0 + how_much_y }, { 5 + how_much_x, 4 + how_much_x, 4 + how_much_x, 3 + how_much_x } };
                                        how_much_reverse = 2;
                                    }
                                    else
                                    {
                                        if (current_figure == "S")
                                        {
                                            figure = new int[2, 4] { { 1 + how_much_y, 1 + how_much_y, 0 + how_much_y, 0 + how_much_y }, { 3 + how_much_x, 4 + how_much_x, 4 + how_much_x, 5 + how_much_x } };
                                            how_much_reverse = 2;
                                        }
                                        else
                                        {
                                            if (current_figure == "T")
                                            {
                                                figure = new int[2, 4] { { 2 + how_much_y, 1 + how_much_y, 1 + how_much_y, 1 + how_much_y }, { 4 + how_much_x, 5 + how_much_x, 4 + how_much_x, 3 + how_much_x } };
                                                how_much_reverse = 2;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (how_much_reverse == 2)
                        {
                            if (current_figure == "I")
                            {
                                figure = new int[2, 4] { { -1 + how_much_y, 0 + how_much_y, 1 + how_much_y, 2 + how_much_y }, { 4 + how_much_x, 4 + how_much_x, 4 + how_much_x, 4 + how_much_x } };
                                how_much_reverse = 3;
                            }
                            else
                            {
                                if (current_figure == "L")
                                {
                                    figure = new int[2, 4] { { 1 + how_much_y, 1 + how_much_y, 1 + how_much_y, 2 + how_much_y }, { 3 + how_much_x, 4 + how_much_x, 5 + how_much_x, 3 + how_much_x } };
                                    how_much_reverse = 3;
                                }
                                else
                                {
                                    if (current_figure == "J")
                                    {
                                        figure = new int[2, 4] { { 1 + how_much_y, 1 + how_much_y, 1 + how_much_y, 0 + how_much_y }, { 3 + how_much_x, 4 + how_much_x, 5 + how_much_x, 3 + how_much_x } };
                                        how_much_reverse = 3;
                                    }
                                    else
                                    {
                                        if (current_figure == "Z")
                                        {
                                            figure = new int[2, 4] { { -1 + how_much_y, 0 + how_much_y, 0 + how_much_y, 1 + how_much_y }, { 5 + how_much_x, 5 + how_much_x, 4 + how_much_x, 4 + how_much_x } };
                                            how_much_reverse = 3;
                                        }
                                        else
                                        {
                                            if (current_figure == "S")
                                            {
                                                figure = new int[2, 4] { { 1 + how_much_y, 0 + how_much_y, 0 + how_much_y, -1 + how_much_y }, { 5 + how_much_x, 5 + how_much_x, 4 + how_much_x, 4 + how_much_x } };
                                                how_much_reverse = 3;
                                            }
                                            else
                                            {
                                                if (current_figure == "T")
                                                {
                                                    figure = new int[2, 4] { { 1 + how_much_y, 0 + how_much_y, 1 + how_much_y, 2 + how_much_y }, { 5 + how_much_x, 4 + how_much_x, 4 + how_much_x, 4 + how_much_x } };
                                                    how_much_reverse = 3;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (how_much_reverse == 3)
                            {
                                if (current_figure == "I")
                                {
                                    figure = new int[2, 4] { { 0 + how_much_y, 0 + how_much_y, 0 + how_much_y, 0 + how_much_y }, { 3 + how_much_x, 4 + how_much_x, 5 + how_much_x, 6 + how_much_x } };
                                    how_much_reverse = 0;
                                }
                                else
                                {
                                    if (current_figure == "L")
                                    {
                                        figure = new int[2, 4] { { 0 + how_much_y, 1 + how_much_y, 2 + how_much_y, 2 + how_much_y }, { 4 + how_much_x, 4 + how_much_x, 4 + how_much_x, 5 + how_much_x } };
                                        how_much_reverse = 0;
                                    }
                                    else
                                    {
                                        if (current_figure == "J")
                                        {
                                            figure = new int[2, 4] { { 0 + how_much_y, 1 + how_much_y, 2 + how_much_y, 2 + how_much_y }, { 4 + how_much_x, 4 + how_much_x, 4 + how_much_x, 3 + how_much_x } };
                                            how_much_reverse = 0;
                                        }
                                        else
                                        {
                                            if (current_figure == "Z")
                                            {
                                                figure = new int[2, 4] { { 0 + how_much_y, 0 + how_much_y, 1 + how_much_y, 1 + how_much_y }, { 3 + how_much_x, 4 + how_much_x, 4 + how_much_x, 5 + how_much_x } };
                                                how_much_reverse = 0;
                                            }
                                            else
                                            {
                                                if (current_figure == "S")
                                                {
                                                    figure = new int[2, 4] { { 0 + how_much_y, 0 + how_much_y, 1 + how_much_y, 1 + how_much_y }, { 5 + how_much_x, 4 + how_much_x, 4 + how_much_x, 3 + how_much_x } };
                                                    how_much_reverse = 0;
                                                }
                                                else
                                                {
                                                    if (current_figure == "T")
                                                    {
                                                        figure = new int[2, 4] { { 0 + how_much_y, 1 + how_much_y, 1 + how_much_y, 1 + how_much_y }, { 4 + how_much_x, 3 + how_much_x, 4 + how_much_x, 5 + how_much_x } };
                                                        how_much_reverse = 0;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (FindMistake())
                {
                    how_much_reverse = how_much_reverse_temp;
                    Array.Copy(figure_copy, figure, figure.Length);
                }
            }
            else
            {
                if (colorField.ActiveFigure != null)
                    colorField.TryRotateActiveFigure();
            }
        }   //поворот

        private void KeyFuncDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    if (start_go)
                        MoveLeft();
                    break;
                case Keys.D:
                    if (start_go)
                        MoveRight();
                    break;
                case Keys.W:
                    if (start_go)
                        Reverse();
                    break;
                case Keys.S:
                    if (start_go)
                        MoveDown();
                    break;
                case Keys.Q:
                    if (start_go)
                        Skip();
                    break;
                case Keys.H:
                    HighScoresTableButton_Click(sender, e);
                    break;
                case Keys.D1:
                    ClassicGameButton_Click(sender, e);
                    break;
                case Keys.D2:
                    BastardGameButton_Click(sender, e);
                    break;
                case Keys.D3:
                    tetColorGameButton_Click(sender, e);
                    break;
                case Keys.E:
                    StartPauseButton_Click(sender, e);
                    break;
                case Keys.R:
                    ResetButton_Click(sender, e);
                    break;
                case Keys.I:
                    InstructionButton_Click(sender, e);
                    break;
                case Keys.Escape:
                    SettingsButton_Click(sender, e);
                    break;
                case Keys.Back:
                    ExitButton_Click(sender, e);
                    break;
            }
        }   //использование клавиатуры

        private void KeyFuncR(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D0 && e.Control)
            {
                tableLayoutPanel1.Visible = false;
                tableLayoutPanel1.Enabled = false;
                this.Size = new System.Drawing.Size(589, 775);
            }
            else
            {
                if (e.KeyCode == Keys.D9 && e.Control)
                {
                    this.Size = new System.Drawing.Size(976, 775);
                    tableLayoutPanel1.Enabled = true;
                    tableLayoutPanel1.Visible = true;
                }
                else
                {

                }
            }
        } //использование клавиатуры

        private void ZeroingField()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (field[i, j] == 1)
                    {
                        field[i, j] = 0;
                    }
                }
            }
        }   //обнуление поля

        private void DrawEmptyField()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    pic_field[i, j].BackColor = Color.White;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    pic_next_figure[i, j].BackColor = Color.White;
                }
            }
        }   //рисует пустое поле

        private void Draw_Classic_Figure()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (field[i, j] == 1)
                    {
                        pic_field[i, j].BackColor = Fallen_Figure_Color;
                    }
                }
            }
            for (int i = 0; i < 4; i++)
            {
                pic_field[figure[0, i], figure[1, i]].BackColor = Falling_Figure_Color;
            }
            for (int i = 0; i < 4; i++)
            {
                pic_next_figure[next_figure[0, i], next_figure[1, i] - 3].BackColor = Falling_Figure_Color;
            }
            try
            {
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        pic_area[i, j].BackColor = Color.White;
                    }
                }
                int count = -1;
                for (int i = w; i < h; i++)
                {
                    count++;
                    for (int j = 0; j < 10; j++)
                    {
                        if (pole[count, j] == 1)
                        {
                            pic_area[i, j].BackColor = Fallen_Figure_Color;
                        }
                        if (pole[count, j] == 0)
                            pic_area[i, j].BackColor = Color.LightGray;
                    }

                }
            }
            catch
            {

            }

            

        }   //отрисовка фигур

        private void DrawGame()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if ((i == 11 && (j == 1 || j == 3)) || (i == 12 && j == 2) || ((i == 4 || i == 6) && (j == 7 || j == 8)) || (i == 7 && j == 4))
                        pic_field[i, j].BackColor = Color.Black;
                    else
                        pic_field[i, j].BackColor = Color.White;
                }
            }
            for (int i = 5; i < 8; i++)
            {
                pic_field[i, 0].BackColor = Color.Black;
            }
            for (int i = 10; i < 15; i++)
            {
                pic_field[i, 0].BackColor = Color.Black;
            }
            for (int i = 10; i < 15; i++)
            {
                pic_field[i, 4].BackColor = Color.Black;
            }
            for (int i = 10; i < 15; i++)
            {
                pic_field[i, 4].BackColor = Color.Black;
            }
            for (int i = 10; i < 15; i++)
            {
                pic_field[i, 6].BackColor = Color.Black;
            }
            for (int i = 5; i < 9; i++)
            {
                pic_field[i, 6].BackColor = Color.Black;
            }
            for (int i = 5; i < 9; i++)
            {
                pic_field[i, 9].BackColor = Color.Black;
            }
            for (int i = 1; i < 4; i++)
            {
                pic_field[4, i].BackColor = Color.Black;
            }
            for (int i = 2; i < 5; i++)
            {
                pic_field[6, i].BackColor = Color.Black;
            }
            for (int i = 7; i < 10; i++)
            {
                pic_field[10, i].BackColor = Color.Black;
            }
            for (int i = 7; i < 10; i++)
            {
                pic_field[12, i].BackColor = Color.Black;
            }
            for (int i = 7; i < 10; i++)
            {
                pic_field[14, i].BackColor = Color.Black;
            }
            for (int i = 1; i < 4; i++)
            {
                pic_field[8, i].BackColor = Color.Black;
            }
        }   //рисует game

        private void DrawOver()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if ((i == 12 && j == 7) || (i == 11 && j == 9) || (i == 14 && j == 9))
                        pic_field[i, j].BackColor = Color.Black;
                    else
                        pic_field[i, j].BackColor = Color.White;
                }
            }
            for (int i = 4; i < 9; i++)
            {
                pic_field[i, 0].BackColor = Color.Black;
            }
            for (int i = 10; i < 15; i++)
            {
                pic_field[i, 1].BackColor = Color.Black;
            }
            for (int i = 10; i < 15; i++)
            {
                pic_field[i, 6].BackColor = Color.Black;
            }
            for (int i = 4; i < 9; i++)
            {
                pic_field[i, 3].BackColor = Color.Black;
            }
            for (int i = 4; i < 8; i++)
            {
                pic_field[i, 5].BackColor = Color.Black;
            }
            for (int i = 4; i < 8; i++)
            {
                pic_field[i, 8].BackColor = Color.Black;
            }
            for (int i = 12; i < 14; i++)
            {
                pic_field[i, 8].BackColor = Color.Black;
            }
            for (int i = 1; i < 3; i++)
            {
                pic_field[4, i].BackColor = Color.Black;
            }
            for (int i = 1; i < 3; i++)
            {
                pic_field[8, i].BackColor = Color.Black;
            }
            for (int i = 6; i < 8; i++)
            {
                pic_field[8, i].BackColor = Color.Black;
            }
            for (int i = 2; i < 5; i++)
            {
                pic_field[10, i].BackColor = Color.Black;
            }
            for (int i = 2; i < 5; i++)
            {
                pic_field[14, i].BackColor = Color.Black;
            }
            for (int i = 2; i < 5; i++)
            {
                pic_field[12, i].BackColor = Color.Black;
            }
            for (int i = 7; i < 9; i++)
            {
                pic_field[10, i].BackColor = Color.Black;
            }
        }   //рисует over

        private void DeleteStringAndUpScore()
        {
            int count = 0;
            int indexUp = 0;
            int indexDown = 0;
            bool first = true;
            int strings = 0;
            for (int i = height - 1; i > -1; i--)
            {
                for (int j = 0; j < width; j++)
                {
                    if (field[i, j] == 1)
                        count++;
                }
                if (count == width)
                {
                    strings++;
                    indexUp = i;
                    for (int j = 0; j < width; j++)
                        field[i, j] = 0;
                    if (first == true)
                    {
                        indexDown = i;
                        first = false;
                    }
                }
                count = 0;
            }
            if (strings - 1 == indexDown - indexUp)
            {
                for (int i = indexUp - 1; i > -1; i--)
                {
                    for (int j = 0; j < width; j++)
                    {
                        if (field[i, j] == 1)
                        {
                            field[i, j] = 0;
                            field[i + strings, j] = 1;
                        }
                    }
                }
            }
            else
            {
                if (first == false)
                {
                    int count2 = 0;
                    for (int i = 0; i < width; i++)
                    {
                        if (field[indexUp + 1, i] == 1)
                            count2++;
                    }
                    if ((count2 == 0) || (strings == 2))
                    {
                        for (int i = indexDown - 1; i > indexUp; i--)
                        {
                            for (int j = 0; j < width; j++)
                            {
                                if (field[i, j] == 1)
                                {
                                    field[i, j] = 0;
                                    field[i + 1, j] = 1;
                                }
                            }
                        }
                        for (int i = indexUp - 1; i > -1; i--)
                        {
                            for (int j = 0; j < width; j++)
                            {
                                if (field[i, j] == 1)
                                {
                                    field[i, j] = 0;
                                    field[i + strings, j] = 1;
                                }
                            }
                        }
                        count2 = 0;
                    }
                    else
                    {
                        for (int i = indexDown - 1; i > indexUp; i--)
                        {
                            for (int j = 0; j < width; j++)
                            {
                                if (field[i, j] == 1)
                                {
                                    field[i, j] = 0;
                                    field[i + 2, j] = 1;
                                }
                            }
                        }
                        for (int i = indexUp - 1; i > -1; i--)
                        {
                            for (int j = 0; j < width; j++)
                            {
                                if (field[i, j] == 1)
                                {
                                    field[i, j] = 0;
                                    field[i + strings, j] = 1;
                                }
                            }
                        }
                    }
                }
            }

            if (strings == 1)
                score = score + 100;
            if (strings == 2)
                score = score + 300;
            if (strings == 3)
                score = score + 700;
            if (strings == 4)
                score = score + 1500;
        }   //удаление строк и обновление рекорда

        private void GameOver()
        {
            if (field[0, 3] == 1 || field[0, 4] == 1 || field[0, 5] == 1 || field[1, 3] == 1 || field[1, 4] == 1 || field[1, 5] == 1 || field[2, 3] == 1 || field[2, 4] == 1 || field[2, 5] == 1 || field[0, 6] == 1)   //если клетка с местом, где спавнится фигура занята, то игра кончается
            {
                DrawTimer.Enabled = false;
                DrawGame();
                GameOverTimer.Enabled = true;
                start_go = false;
                ZeroingField();
                TimerGameFunc.Enabled = false;
                GameOverWas = true;
                if (score > Data.ScoreTable && ChangeGame == 0)
                {
                    Data.Gamemode = "Classic";
                    Data.ScoreTable = score;
                    Name form = new Name();
                    form.ShowDialog();
                    Player p = new Player(Data.Name, Data.ScoreTable, Data.Gamemode);
                    for (int i = 0; i < Data.list.Count; i++)
                    {
                        if (Data.Gamemode == Data.list[i].Mode)
                        {
                            Data.list.RemoveAt(i);
                        }
                    }
                    Data.list.Add(p);
                }
                if (score > Data.ScoreTable_Bastard && ChangeGame == 1)
                {
                    Data.Gamemode = "Bastard";
                    Data.ScoreTable_Bastard = score;
                    Name form = new Name();
                    form.ShowDialog();
                    Player p = new Player(Data.Name, Data.ScoreTable_Bastard, Data.Gamemode);
                    for (int i = 0; i < Data.list.Count; i++)
                    {
                        if (Data.Gamemode == Data.list[i].Mode)
                        {
                            Data.list.RemoveAt(i);
                        }
                    }
                    Data.list.Add(p);
                }
                count_figure = 0;

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        pic_area[i, j].BackColor = Color.White;
                    }
                }
            }
        }   //конец игры, если место, где спавнится фигура занято

        private void Boost()
        {
            if ((score >= 500) && (score < 1500))
            {
                TimerGameFunc.Interval = 650;
            }
            else
            {
                if ((score >= 1500) && (score < 2000))
                {
                    TimerGameFunc.Interval = 600;
                }
                else
                {
                    if ((score >= 2000) && (score < 5000))
                    {
                        TimerGameFunc.Interval = 550;
                    }
                    else
                    {
                        if ((score >= 5000) && (score < 8000))
                        {
                            TimerGameFunc.Interval = 500;
                        }
                        else
                        {
                            if ((score >= 8000) && (score < 14000))
                            {
                                TimerGameFunc.Interval = 400;
                            }
                            else
                            {
                                if ((score >= 14000) && (score < 18000))
                                {
                                    TimerGameFunc.Interval = 300;
                                }
                                else
                                {
                                    if ((score >= 18000) && (score < 22000))
                                    {
                                        TimerGameFunc.Interval = 200;
                                    }
                                    else
                                    {
                                        if ((score >= 22000) && (score < 28000))
                                        {
                                            TimerGameFunc.Interval = 100;
                                        }
                                        else
                                        {
                                            if (score >= 28000)
                                            {
                                                TimerGameFunc.Interval = 50;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }   //ускорение

        private void ClassicGame()
        {
            GameOver();
            for (int i = 0; i < 4; i++)
                figure[0, i]++;
            how_much_y++;
            if (FindMistake())
            {
                for (int i = 0; i < 4; i++)
                    field[--figure[0, i], figure[1, i]]++;
                Array.Copy(next_figure, figure, next_figure.Length);
                current_figure = current_next_figure;
                how_much_x = 0;
                how_much_y = 0;
                how_much_reverse = 0;
                next_figure = Create_Next_Classic_Figure();
            }   //если нашлась ошибка, перенести фигурку на 1 клетку вверх, сохранить её в массив field и создать новую фигурку
            DeleteStringAndUpScore();
            Boost();
            CurrentScoreLabel.Text = $"{score}";
        }   //то, что происходит раз в 700 милисекунд (или быстрее) при классическом режиме игры

        private void BastardGame()
        {
            
            GameOver();
            for (int i = 0; i < 4; i++)
                figure[0, i]++;
            how_much_y++;
            if (FindMistake())
            {
                for (int i = 0; i < 4; i++)
                    field[--figure[0, i], figure[1, i]]++;
                figure = Create_Bastard_Figure();
                how_much_x = 0;
                how_much_y = 0;
                how_much_reverse = 0;
                next_figure = Create_Next_Bastard_Figure();
            }   //если нашлась ошибка, перенести фигурку на 1 клетку вверх, сохранить её в массив field и создать новую фигурку
            DeleteStringAndUpScore();
            Boost();
            CurrentScoreLabel.Text = $"{score}";
        }

        #endregion

        #region Таймеры

        private void TimerGameFunc_Tick(object sender, EventArgs e)
        {
            switch (ChangeGame) 
            {
                case 0:
                    ClassicGame();
                    break;
                case 1:
                    BastardGame();
                    break;
                case 2:
                    try
                    {
                        colorField.Step();
                    }
                    catch (IndexOutOfRangeException)
                    {
                        DrawTimer.Enabled = false;
                        start_go = false;
                        GameOverTimer.Enabled = true;
                        TimerGameFunc.Enabled = false;
                        GameOverWas = true;
                        score = colorField.Score;
                        if (score > Data.ScoreTable_TetColor && ChangeGame == 2)
                        {
                            Data.Gamemode = "tetColor";
                            Data.ScoreTable_TetColor = score;
                            Name form = new Name();
                            form.ShowDialog();
                            Player p = new Player(Data.Name, Data.ScoreTable_TetColor, Data.Gamemode);
                            for (int i = 0; i < Data.list.Count; i++)
                            {
                                if (Data.Gamemode == Data.list[i].Mode)
                                {
                                    Data.list.RemoveAt(i);
                                }
                            }
                            Data.list.Add(p);
                        }
                    }
                    break;
            }
        }   //таймер самой игры

        private void DrawTimer_Tick(object sender, EventArgs e)
        {
            switch (ChangeGame)
            {
                case 0:
                    DrawEmptyField();
                    Draw_Classic_Figure();
                    break;
                case 1:
                    DrawEmptyField();
                    Draw_Classic_Figure();
                    break;
                case 2:
                    if (colorField == null)
                        colorField = new TetColorField(width, height);
                    DrawTetColorField();
                    break;
            }
        }   //таймер отрисовки

        private void GameOverTimer_Tick(object sender, EventArgs e)
        {
            DrawOver();
            GameOverTimer.Enabled = false;
        }   //таймер для вывод надписи GameOver

        #endregion

        #region Сохранение рекордов

        private void Tetris_Load(object sender, EventArgs e)
        {
            if(System.IO.File.Exists("score.dat"))
            {
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    using (FileStream fs = new FileStream("score.dat", FileMode.OpenOrCreate))
                    {
                        Data.list = (List<Player>)formatter.Deserialize(fs);
                    }
                }
                catch
                {

                }
            }
            else
            {
                Data.file = new FileStream("score.dat", FileMode.OpenOrCreate);
                Data.file.Close();
            }
            for(int i = 0; i < Data.list.Count; i++)
            {
                if (Data.list[i].Mode == "Classic")
                {
                    Data.ScoreTable = Data.list[i].Score;
                }
                else
                {
                    if (Data.list[i].Mode == "Bastard")
                    {
                        Data.ScoreTable_Bastard = Data.list[i].Score;
                    }
                    else
                    {
                        Data.ScoreTable_TetColor = Data.list[i].Score;
                    }
                }
            }
        }

        private void Tetris_FormClosed(object sender, FormClosedEventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("score.dat", FileMode.OpenOrCreate))
            {
                // сериализуем весь list
                formatter.Serialize(fs, Data.list);
                fs.Close();
            }
        }

        #endregion

        private void PanelField_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
