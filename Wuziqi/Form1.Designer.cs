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
            BeginButton = new Button();
            Restart = new Button();
            ExitButton = new Button();
            ChessBoardPanel = new Panel();
            FunctionBar = new Panel();
            GameState = new Label();
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
            // 
            // Restart
            // 
            Restart.Location = new Point(88, 247);
            Restart.Name = "Restart";
            Restart.Size = new Size(154, 62);
            Restart.TabIndex = 1;
            Restart.Text = "重新开始";
            Restart.UseVisualStyleBackColor = true;
            // 
            // ExitButton
            // 
            ExitButton.Location = new Point(88, 473);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(154, 62);
            ExitButton.TabIndex = 2;
            ExitButton.Text = "结束";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click_1;
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
            // 
            // FunctionBar
            // 
            FunctionBar.BackColor = Color.AntiqueWhite;
            FunctionBar.Controls.Add(GameState);
            FunctionBar.Controls.Add(ExitButton);
            FunctionBar.Controls.Add(BeginButton);
            FunctionBar.Controls.Add(Restart);
            FunctionBar.Dock = DockStyle.Right;
            FunctionBar.Location = new Point(1078, 0);
            FunctionBar.Name = "FunctionBar";
            FunctionBar.Size = new Size(300, 944);
            FunctionBar.TabIndex = 0;
            // 
            // GameState
            // 
            GameState.AutoSize = true;
            GameState.Location = new Point(88, 331);
            GameState.Name = "GameState";
            GameState.Size = new Size(63, 24);
            GameState.TabIndex = 3;
            GameState.Text = "label1";
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
    }
}
