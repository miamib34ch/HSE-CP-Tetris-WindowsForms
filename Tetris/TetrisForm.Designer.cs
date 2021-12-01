
namespace Tetris
{
    partial class Tetris
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tetris));
            this.PanelField = new System.Windows.Forms.TableLayoutPanel();
            this.TimerGameFunc = new System.Windows.Forms.Timer(this.components);
            this.DrawTimer = new System.Windows.Forms.Timer(this.components);
            this.HighScoresTableButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.InstructionButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.StartPauseButton = new System.Windows.Forms.Button();
            this.CurrentScoreLabel = new System.Windows.Forms.Label();
            this.PanelNextFigure = new System.Windows.Forms.TableLayoutPanel();
            this.tetColorGameButton = new System.Windows.Forms.Button();
            this.BastardGameButton = new System.Windows.Forms.Button();
            this.ClassicGameButton = new System.Windows.Forms.Button();
            this.GameOverTimer = new System.Windows.Forms.Timer(this.components);
            this.StaticScoreLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // PanelField
            // 
            this.PanelField.BackColor = System.Drawing.Color.White;
            this.PanelField.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PanelField.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.PanelField.ColumnCount = 10;
            this.PanelField.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PanelField.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PanelField.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PanelField.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PanelField.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PanelField.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PanelField.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PanelField.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PanelField.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PanelField.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.PanelField.ForeColor = System.Drawing.Color.Black;
            this.PanelField.Location = new System.Drawing.Point(199, 18);
            this.PanelField.Name = "PanelField";
            this.PanelField.RowCount = 20;
            this.PanelField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.PanelField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.PanelField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.PanelField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.PanelField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.PanelField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.PanelField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.PanelField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.PanelField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.PanelField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.PanelField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.PanelField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.PanelField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.PanelField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.PanelField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.PanelField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.PanelField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.PanelField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.PanelField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.PanelField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.PanelField.Size = new System.Drawing.Size(361, 701);
            this.PanelField.TabIndex = 18;
            this.PanelField.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelField_Paint);
            // 
            // TimerGameFunc
            // 
            this.TimerGameFunc.Interval = 700;
            this.TimerGameFunc.Tick += new System.EventHandler(this.TimerGameFunc_Tick);
            // 
            // DrawTimer
            // 
            this.DrawTimer.Interval = 1;
            this.DrawTimer.Tick += new System.EventHandler(this.DrawTimer_Tick);
            // 
            // HighScoresTableButton
            // 
            this.HighScoresTableButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HighScoresTableButton.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HighScoresTableButton.ForeColor = System.Drawing.Color.White;
            this.HighScoresTableButton.Location = new System.Drawing.Point(13, 181);
            this.HighScoresTableButton.Name = "HighScoresTableButton";
            this.HighScoresTableButton.Size = new System.Drawing.Size(165, 41);
            this.HighScoresTableButton.TabIndex = 29;
            this.HighScoresTableButton.Text = "High scores";
            this.HighScoresTableButton.UseVisualStyleBackColor = true;
            this.HighScoresTableButton.Click += new System.EventHandler(this.HighScoresTableButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExitButton.ForeColor = System.Drawing.Color.White;
            this.ExitButton.Location = new System.Drawing.Point(13, 678);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(165, 41);
            this.ExitButton.TabIndex = 28;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsButton.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SettingsButton.ForeColor = System.Drawing.Color.White;
            this.SettingsButton.Location = new System.Drawing.Point(13, 601);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(164, 41);
            this.SettingsButton.TabIndex = 27;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // InstructionButton
            // 
            this.InstructionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InstructionButton.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InstructionButton.ForeColor = System.Drawing.Color.White;
            this.InstructionButton.Location = new System.Drawing.Point(13, 554);
            this.InstructionButton.Name = "InstructionButton";
            this.InstructionButton.Size = new System.Drawing.Size(164, 41);
            this.InstructionButton.TabIndex = 26;
            this.InstructionButton.Text = "Instruction";
            this.InstructionButton.UseVisualStyleBackColor = true;
            this.InstructionButton.Click += new System.EventHandler(this.InstructionButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResetButton.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResetButton.ForeColor = System.Drawing.Color.White;
            this.ResetButton.Location = new System.Drawing.Point(13, 477);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(165, 41);
            this.ResetButton.TabIndex = 25;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // StartPauseButton
            // 
            this.StartPauseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartPauseButton.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartPauseButton.ForeColor = System.Drawing.Color.White;
            this.StartPauseButton.Location = new System.Drawing.Point(13, 430);
            this.StartPauseButton.Name = "StartPauseButton";
            this.StartPauseButton.Size = new System.Drawing.Size(165, 41);
            this.StartPauseButton.TabIndex = 24;
            this.StartPauseButton.Text = "Start / Pause";
            this.StartPauseButton.UseVisualStyleBackColor = true;
            this.StartPauseButton.Click += new System.EventHandler(this.StartPauseButton_Click);
            // 
            // CurrentScoreLabel
            // 
            this.CurrentScoreLabel.BackColor = System.Drawing.Color.Black;
            this.CurrentScoreLabel.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CurrentScoreLabel.ForeColor = System.Drawing.Color.White;
            this.CurrentScoreLabel.Location = new System.Drawing.Point(76, 142);
            this.CurrentScoreLabel.Name = "CurrentScoreLabel";
            this.CurrentScoreLabel.Size = new System.Drawing.Size(90, 28);
            this.CurrentScoreLabel.TabIndex = 23;
            this.CurrentScoreLabel.Text = "0";
            // 
            // PanelNextFigure
            // 
            this.PanelNextFigure.BackColor = System.Drawing.Color.White;
            this.PanelNextFigure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PanelNextFigure.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.PanelNextFigure.ColumnCount = 4;
            this.PanelNextFigure.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.PanelNextFigure.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.PanelNextFigure.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.PanelNextFigure.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.PanelNextFigure.Location = new System.Drawing.Point(24, 18);
            this.PanelNextFigure.Name = "PanelNextFigure";
            this.PanelNextFigure.RowCount = 3;
            this.PanelNextFigure.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.PanelNextFigure.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.PanelNextFigure.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.PanelNextFigure.Size = new System.Drawing.Size(145, 106);
            this.PanelNextFigure.TabIndex = 22;
            // 
            // tetColorGameButton
            // 
            this.tetColorGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tetColorGameButton.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tetColorGameButton.ForeColor = System.Drawing.Color.White;
            this.tetColorGameButton.Location = new System.Drawing.Point(13, 353);
            this.tetColorGameButton.Name = "tetColorGameButton";
            this.tetColorGameButton.Size = new System.Drawing.Size(165, 41);
            this.tetColorGameButton.TabIndex = 21;
            this.tetColorGameButton.Text = "tetColor";
            this.tetColorGameButton.UseVisualStyleBackColor = true;
            this.tetColorGameButton.Click += new System.EventHandler(this.tetColorGameButton_Click);
            // 
            // BastardGameButton
            // 
            this.BastardGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BastardGameButton.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BastardGameButton.ForeColor = System.Drawing.Color.White;
            this.BastardGameButton.Location = new System.Drawing.Point(13, 306);
            this.BastardGameButton.Name = "BastardGameButton";
            this.BastardGameButton.Size = new System.Drawing.Size(165, 41);
            this.BastardGameButton.TabIndex = 20;
            this.BastardGameButton.Text = "Bastard";
            this.BastardGameButton.UseVisualStyleBackColor = true;
            this.BastardGameButton.Click += new System.EventHandler(this.BastardGameButton_Click);
            // 
            // ClassicGameButton
            // 
            this.ClassicGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClassicGameButton.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClassicGameButton.ForeColor = System.Drawing.Color.White;
            this.ClassicGameButton.Location = new System.Drawing.Point(13, 259);
            this.ClassicGameButton.Name = "ClassicGameButton";
            this.ClassicGameButton.Size = new System.Drawing.Size(165, 41);
            this.ClassicGameButton.TabIndex = 19;
            this.ClassicGameButton.Text = "Classic";
            this.ClassicGameButton.UseVisualStyleBackColor = true;
            this.ClassicGameButton.Click += new System.EventHandler(this.ClassicGameButton_Click);
            // 
            // GameOverTimer
            // 
            this.GameOverTimer.Interval = 2000;
            this.GameOverTimer.Tick += new System.EventHandler(this.GameOverTimer_Tick);
            // 
            // StaticScoreLabel
            // 
            this.StaticScoreLabel.BackColor = System.Drawing.Color.Black;
            this.StaticScoreLabel.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StaticScoreLabel.ForeColor = System.Drawing.Color.White;
            this.StaticScoreLabel.Location = new System.Drawing.Point(13, 142);
            this.StaticScoreLabel.Name = "StaticScoreLabel";
            this.StaticScoreLabel.Size = new System.Drawing.Size(69, 28);
            this.StaticScoreLabel.TabIndex = 30;
            this.StaticScoreLabel.Text = "Score: ";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ForeColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(580, 18);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 20;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(361, 701);
            this.tableLayoutPanel1.TabIndex = 31;
            // 
            // Tetris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(960, 736);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.CurrentScoreLabel);
            this.Controls.Add(this.StaticScoreLabel);
            this.Controls.Add(this.PanelField);
            this.Controls.Add(this.HighScoresTableButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.InstructionButton);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.StartPauseButton);
            this.Controls.Add(this.PanelNextFigure);
            this.Controls.Add(this.tetColorGameButton);
            this.Controls.Add(this.BastardGameButton);
            this.Controls.Add(this.ClassicGameButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Tetris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tetris";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Tetris_FormClosed);
            this.Load += new System.EventHandler(this.Tetris_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel PanelField;
        private System.Windows.Forms.TableLayoutPanel PanelNextFigure;
        private System.Windows.Forms.Label CurrentScoreLabel;
        private System.Windows.Forms.Timer TimerGameFunc;
        private System.Windows.Forms.Timer DrawTimer;
        private System.Windows.Forms.Timer GameOverTimer;
        private System.Windows.Forms.Button HighScoresTableButton;
        private System.Windows.Forms.Button ClassicGameButton;
        private System.Windows.Forms.Button BastardGameButton;
        private System.Windows.Forms.Button tetColorGameButton;
        private System.Windows.Forms.Button StartPauseButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Button InstructionButton;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label StaticScoreLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

