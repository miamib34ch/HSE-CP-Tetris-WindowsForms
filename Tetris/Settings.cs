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
    public partial class Settings : Form
    {
        #region Свойства
        public Button bHS { get; set; } //кнопка рекордов
        public Button bCL{ get; set; }  //кнопка классического режима
        public Button bBS { get; set; } //кнопка ублюдочного режима
        public Button bTC { get; set; } //кнопка цветового режима
        public Button bSP { get; set; } //кнопка старта и паузы
        public Button bRE{ get; set; }  //кнопка рестарта
        public Button bIN{ get; set; }  //кнопка инструкции
        public Button bST{ get; set; }  //кнопка настроек
        public Button bEXT{ get; set; } //кнопка выхода
        public Tetris title { get; set; }   //форма класса Tetris, нужна для изменения заголовка
        public Label Set_StaticScoreLabel { get; set; } //лейбл рекорда
        public TrackBar BackMusicSet
        {
            get
            {
                return BackMusicVolume;
            }
            set
            {
                BackMusicVolume = value;
            }
        }   //ползунок громкости
        #endregion

        #region Изменение цвета падающей фигурки 

        public void FallingFigBCEmpty()
        {
            Color1.FlatAppearance.BorderColor = Color.Empty;
            Color2.FlatAppearance.BorderColor = Color.Empty;
            Color3.FlatAppearance.BorderColor = Color.Empty;
            Color4.FlatAppearance.BorderColor = Color.Empty;
            Color5.FlatAppearance.BorderColor = Color.Empty;
            Color6.FlatAppearance.BorderColor = Color.Empty;
        }   //меняет цвет границы кнопок для изменения цвета на пустой 

        public void FallingFigBCWhite()
        {
            if (Tetris.Falling_Figure_Color == Color.Red)
                Color1.FlatAppearance.BorderColor = Color.White;
            else
                if (Tetris.Falling_Figure_Color == Color.Gold)
                Color2.FlatAppearance.BorderColor = Color.White;
            else
                if (Tetris.Falling_Figure_Color == Color.Lime)
                Color3.FlatAppearance.BorderColor = Color.White;
            else
                if (Tetris.Falling_Figure_Color == Color.DodgerBlue)
                Color4.FlatAppearance.BorderColor = Color.White;
            else
                if (Tetris.Falling_Figure_Color == Color.MediumOrchid)
                Color5.FlatAppearance.BorderColor = Color.White;
            else
                if (Tetris.Falling_Figure_Color == Color.DarkGray)
                Color6.FlatAppearance.BorderColor = Color.White;
        }   //меняет цвет границы кнопки для изменения цвета на белый в зависимости от условия 

        private void Color1_Click(object sender, EventArgs e)
        {
            FallingFigBCEmpty();
            Color1.FlatAppearance.BorderColor = Color.White;    //меняет цвет границы кнопки на белый
            Tetris.Falling_Figure_Color = Color.Red;
        }   //Красный

        private void Color2_Click(object sender, EventArgs e)
        {
            FallingFigBCEmpty();
            Color2.FlatAppearance.BorderColor = Color.White;
            Tetris.Falling_Figure_Color = Color.Gold;
        }   //Жёлтый

        private void Color3_Click(object sender, EventArgs e)
        {
            FallingFigBCEmpty();
            Color3.FlatAppearance.BorderColor = Color.White;
            Tetris.Falling_Figure_Color = Color.Lime;
        }   //Зелёный

        private void Color4_Click(object sender, EventArgs e)
        {
            FallingFigBCEmpty();
            Color4.FlatAppearance.BorderColor = Color.White;
            Tetris.Falling_Figure_Color = Color.DodgerBlue;
        }   //Синий

        private void Color5_Click(object sender, EventArgs e)
        {
            FallingFigBCEmpty();
            Color5.FlatAppearance.BorderColor = Color.White;
            Tetris.Falling_Figure_Color = Color.MediumOrchid;
        }   //Фиолетовый

        private void Color6_Click(object sender, EventArgs e)
        {
            FallingFigBCEmpty();
            Color6.FlatAppearance.BorderColor = Color.White;
            Tetris.Falling_Figure_Color = Color.DarkGray;
        }   //Серый

        #endregion

        #region Изменение цвета упавшей фигурки

        public void FallenFigBCEmpty()
        {
            Color7.FlatAppearance.BorderColor = Color.Empty;
            Color8.FlatAppearance.BorderColor = Color.Empty;
            Color9.FlatAppearance.BorderColor = Color.Empty;
            Color10.FlatAppearance.BorderColor = Color.Empty;
            Color11.FlatAppearance.BorderColor = Color.Empty;
            Color12.FlatAppearance.BorderColor = Color.Empty;
        }   //меняет цвет границы кнопок для изменения цвета на пустой 

        public void FallenFigBCWhite()
        {
            if (Tetris.Fallen_Figure_Color == Color.Maroon)
                Color7.FlatAppearance.BorderColor = Color.White;
            else
                if (Tetris.Fallen_Figure_Color == Color.DarkGoldenrod)
                Color8.FlatAppearance.BorderColor = Color.White;
            else
                if (Tetris.Fallen_Figure_Color == Color.Green)
                Color9.FlatAppearance.BorderColor = Color.White;
            else
                if (Tetris.Fallen_Figure_Color == Color.DarkBlue)
                Color10.FlatAppearance.BorderColor = Color.White;
            else
                if (Tetris.Fallen_Figure_Color == Color.Indigo)
                Color11.FlatAppearance.BorderColor = Color.White;
            else
                if (Tetris.Fallen_Figure_Color == Color.DimGray)
                Color12.FlatAppearance.BorderColor = Color.White;
        }   //меняет цвет границы кнопки для изменения цвета на белый в зависимости от условия 

        private void Color7_Click(object sender, EventArgs e)
        {
            FallenFigBCEmpty();
            Color7.FlatAppearance.BorderColor = Color.White;
            Tetris.Fallen_Figure_Color = Color.Maroon;
        }   //Красный

        private void Color8_Click(object sender, EventArgs e)
        {
            FallenFigBCEmpty();
            Color8.FlatAppearance.BorderColor = Color.White;
            Tetris.Fallen_Figure_Color = Color.DarkGoldenrod;
        }   //Жёлтый

        private void Color9_Click(object sender, EventArgs e)
        {
            FallenFigBCEmpty();
            Color9.FlatAppearance.BorderColor = Color.White;
            Tetris.Fallen_Figure_Color = Color.Green;
        }   //Зелёный

        private void Color10_Click(object sender, EventArgs e)
        {
            FallenFigBCEmpty();
            Color10.FlatAppearance.BorderColor = Color.White;
            Tetris.Fallen_Figure_Color = Color.DarkBlue;
        }   //Синий

        private void Color11_Click(object sender, EventArgs e)
        {
            FallenFigBCEmpty();
            Color11.FlatAppearance.BorderColor = Color.White;
            Tetris.Fallen_Figure_Color = Color.Indigo;
        }   //Фиолетовый

        private void Color12_Click(object sender, EventArgs e)
        {
            FallenFigBCEmpty();
            Color12.FlatAppearance.BorderColor = Color.White;
            Tetris.Fallen_Figure_Color = Color.DimGray;
        }   //Синий

        #endregion

        #region Кнопки

        private void AboutLabel_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("tetris.help.pi203@gmail.com");   //копирование в буфер обмена
            if (Tetris.Lang == "R")
                MessageBox.Show("Почта скопирована в буфер обмена!");
            else
                MessageBox.Show("Mail copied to clipboard!");
        }   //происходит при нажатии на лейбл с информацией о разработчиках

        private void BackMusicVolume_Scroll(object sender, EventArgs e)
        {
            Tetris.WMP.settings.volume = BackMusicVolume.Value;
        }   //метод, обрабатывающий изменение ползунка громкости

        public void RuLangButton_Click(object sender, EventArgs e)
        {
            Set_StaticScoreLabel.Text = "Счёт:";
            bHS.Text = "Рекорды";
            bCL.Text = "Классический";
            bBS.Text = "Ублюдочный";
            bTC.Text = "Цветовой";
            bSP.Text = "Старт / Пауза";
            bRE.Text = "Сброс";
            bIN.Text = "Инструкция";
            bST.Text = "Настройки";
            bEXT.Text = "Выход";
            LabelChangeFallen.Text = "Цвет упавшей фигурки:";
            LabelChangeFalling.Text = "Цвет падающей фигурки:";
            Exit.Text = "Закрыть настройки";
            this.Text = "Настройки";
            title.Text = "Тетрис";
            AboutLabel.Text = "Тетрис разработчики:" +
                "\nБогдан Полыгалов" +
                "\nАртём Будин" +
                "\nЕлисей Лазарев" +
                "\n" +
                "\nДля контакта с нами:" +
                "\ntetris.help.pi203@gmail.com";
            Tetris.Lang = "R";
        }   //кнопка для переключения на русский язык

        public void EngLangButton_Click(object sender, EventArgs e)
        {
            Set_StaticScoreLabel.Text = "Score:";
            bHS.Text = "High scores";
            bCL.Text = "Classic";
            bBS.Text = "Bastard";
            bTC.Text = "tetColor";
            bSP.Text = "Start / Pause";
            bRE.Text = "Reset";
            bIN.Text = "Instruction";
            bST.Text = "Settings";
            bEXT.Text = "Exit";
            LabelChangeFallen.Text = "Fallen figure color:";
            LabelChangeFalling.Text = "Falling figure color:";
            Exit.Text = "Close settings";
            this.Text = "Settings";
            title.Text = "Tetris";
            AboutLabel.Text = "Tetris developers:" +
                "\nBogdan Polygalov" +
                "\nArtyom Budin" +
                "\nElisey Lazarev" +
                "\n" +
                "\nFor contact with us:" +
                "\ntetris.help.pi203@gmail.com";
            Tetris.Lang = "E";
        }   //кнопка для переключения на английский язык

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }   //кнопка закрытия настроек

        #endregion

        #region Не используется

        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void LabelChangeFallen_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
