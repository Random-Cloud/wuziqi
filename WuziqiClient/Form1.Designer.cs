namespace Wuziqi
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            BeginButton = new Button();
            Restart = new Button();
            ExitButton = new Button();
            ChessBoardPanel = new Panel();
            FunctionBar = new Panel();
            TimeLable = new Label();
            BackChess = new Button();
            GameState = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            BlinkTime = new System.Windows.Forms.Timer(components);
            ChessBoardPanel.SuspendLayout();
            FunctionBar.SuspendLayout();
            SuspendLayout();
            // 
            // BeginButton
            // 
            BeginButton.Location = new Point(88, 114);
            BeginButton.Name = "BeginButton";
            BeginButton.Size = new Size(154, 62);
            BeginButton.TabIndex = 0;
            BeginButton.Text = "开始";
            BeginButton.UseVisualStyleBackColor = true;
            BeginButton.Click += BeginButton_Click;
            // 
            // Restart
            // 
            Restart.Location = new Point(88, 202);
            Restart.Name = "Restart";
            Restart.Size = new Size(154, 62);
            Restart.TabIndex = 1;
            Restart.Text = "重新开始";
            Restart.UseVisualStyleBackColor = true;
            Restart.Click += Restart_Click;
            // 
            // ExitButton
            // 
            ExitButton.Location = new Point(88, 356);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(154, 62);
            ExitButton.TabIndex = 2;
            ExitButton.Text = "结束";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // ChessBoardPanel
            // 
            ChessBoardPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ChessBoardPanel.BackColor = Color.Wheat;
            ChessBoardPanel.Controls.Add(FunctionBar);
            ChessBoardPanel.Dock = DockStyle.Fill;
            ChessBoardPanel.Location = new Point(0, 0);
            ChessBoardPanel.Name = "ChessBoardPanel";
            ChessBoardPanel.Size = new Size(1378, 944);
            ChessBoardPanel.TabIndex = 3;
            ChessBoardPanel.Paint += ChessBoardPanel_Paint;
            ChessBoardPanel.MouseClick += ChessBoardPanel_MouseClick;
            // 
            // FunctionBar
            // 
            FunctionBar.BackColor = Color.AntiqueWhite;
            FunctionBar.Controls.Add(TimeLable);
            FunctionBar.Controls.Add(BackChess);
            FunctionBar.Controls.Add(GameState);
            FunctionBar.Controls.Add(ExitButton);
            FunctionBar.Controls.Add(BeginButton);
            FunctionBar.Controls.Add(Restart);
            FunctionBar.Dock = DockStyle.Right;
            FunctionBar.Location = new Point(1078, 0);
            FunctionBar.Name = "FunctionBar";
            FunctionBar.Size = new Size(300, 944);
            FunctionBar.TabIndex = 0;
            FunctionBar.Paint += FunctionBar_Paint;
            // 
            // TimeLable
            // 
            TimeLable.AutoSize = true;
            TimeLable.Location = new Point(88, 468);
            TimeLable.Name = "TimeLable";
            TimeLable.Size = new Size(115, 24);
            TimeLable.TabIndex = 5;
            TimeLable.Text = "倒计时：120";
            // 
            // BackChess
            // 
            BackChess.Location = new Point(88, 279);
            BackChess.Name = "BackChess";
            BackChess.Size = new Size(154, 56);
            BackChess.TabIndex = 4;
            BackChess.Text = "悔棋";
            BackChess.UseVisualStyleBackColor = true;
            BackChess.Click += BackChess_Click;
            // 
            // GameState
            // 
            GameState.AutoSize = true;
            GameState.Location = new Point(88, 584);
            GameState.Name = "GameState";
            GameState.Size = new Size(100, 24);
            GameState.TabIndex = 3;
            GameState.Text = "游戏未开始";
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // BlinkTime
            // 
            BlinkTime.Interval = 500;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1378, 944);
            Controls.Add(ChessBoardPanel);
            Name = "Form1";
            Text = "五子棋";
            Load += Form1_Load;
            ChessBoardPanel.ResumeLayout(false);
            FunctionBar.ResumeLayout(false);
            FunctionBar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button BeginButton;
        private Button Restart;
        private Button ExitButton;
        private Panel ChessBoardPanel;
        private Panel FunctionBar;
        private Label GameState;
        private Button BackChess;
        private System.Windows.Forms.Timer timer1;
        private Label TimeLable;
        private System.Windows.Forms.Timer BlinkTime;
    }
}
