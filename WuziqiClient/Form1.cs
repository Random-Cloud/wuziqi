namespace Wuziqi
{
    public partial class Form1 : Form {
        // 游戏是否开始的标志
        private bool start;
        // 是否为黑方回合
        private bool isBlackTurn;
        // 棋盘大小
        private const int size = 15;
        // 棋盘数组
        private int[,] checkBoard = new int[size, size];
        private RemoveCoordinates removeCoordinates;
        private int chessCount;

        public Form1() {
            InitializeComponent();
        }


        // 加载窗体时的事件处理程序,初始化窗口大小以及位置
        private void Form1_Load(object sender, EventArgs e) {
            initializeGame();
            Width = ClientConstants.FormWidth;
            Height = ClientConstants.FormHeight;
            Location = new Point(400, 75);

        }
        // 棋盘初始化，显示开始按钮，隐藏重新开始按钮
        private void initializeGame() {
            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    checkBoard[i, j] = 0;
                }
            }
            // checkBoard = SomeTest.GetInstance().checkBoard;
            chessCount = 0;
            // chessCount = SomeTest.GetInstance().count;
            start = false;
            GameState.Text = "游戏未开始";
            BeginButton.Visible = true;
            Restart.Visible = false;
            BackChess.Visible = false;
            removeCoordinates = RemoveCoordinates.GetInstance();
        }

        private void ChessBoardPanel_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            ChessBoard.DrawCB(g);
            Chess chess = Chess.GetInstance(ChessBoardPanel);
            chess.ReDrawChess(checkBoard);
        }

        private void changeGameState() {
            if (isBlackTurn) {
                GameState.Text = "黑方执棋";
            }
            else {
                GameState.Text = "白方执棋";
            }
        }
        private void ChessBoardPanel_MouseClick(object sender, MouseEventArgs e) {
            // 判断游戏是否开始
            if (start) {

                // 鼠标点击位置的x、y坐标
                int PlacementX = e.X / ClientConstants.CellSize;
                int PlacementY = e.Y / ClientConstants.CellSize;
                try {
                    // 判断点击位置是否在棋盘范围内
                    if (checkBoard[PlacementX, PlacementY] != 0) {
                        return;
                    }
                    checkBoard[PlacementX, PlacementY] = isBlackTurn ? 1 : 2;

                    // 记录落子坐标
                    removeCoordinates.SetCoordinates(PlacementX, PlacementY);
                    // 绘制棋子
                    Chess chess = Chess.GetInstance(ChessBoardPanel);
                    chess.DrawChess(isBlackTurn, PlacementX, PlacementY);
                    chessCount++;

                    // 判断是否胜利
                    if (IsWin.IsWinCheck(checkBoard, PlacementX, PlacementY)) {
                        string winner = isBlackTurn ? "黑方" : "白方";
                        MessageBox.Show(winner + "胜利！", "游戏结束", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        initializeGame();
                    }
                    // 切换回合
                    isBlackTurn = !isBlackTurn;
                    changeGameState();
                    // 判断平局
                    if (chessCount == size * size) {
                        MessageBox.Show("棋盘已满，平局！", "游戏结束", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        initializeGame();
                        return;
                    }
                }
                catch (Exception) {
                    // TODO: 处理异常
                }

            }
        }
        private void FunctionBar_Paint(object sender, PaintEventArgs e) {
            FunctionBar.Size = new Size(ClientConstants.FormWidth - ClientConstants.BoardWidth - ClientConstants.ChessBoardMargin, ClientConstants.FormHeight);
        }
        // 开始按钮
        private void BeginButton_Click(object sender, EventArgs e) {
            // 游戏开始，显示重新开始按钮，隐藏开始按钮
            start = true;
            GameState.Text = "黑方执棋";
            isBlackTurn = true;
            BeginButton.Visible = false;
            Restart.Visible = true;
            BackChess.Visible = true;
            // 重绘棋盘
            ChessBoardPanel.Invalidate();
        }
        // 重新开始按钮
        private void Restart_Click(object sender, EventArgs e) {
            // 重新开始游戏，初始化棋盘
            if (MessageBox.Show("是否放弃当前对局重新开始？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                initializeGame();
                BeginButton_Click(sender, e);
            }

        }

        private void ExitButton_Click(object sender, EventArgs e) {
            // 退出游戏
            Dispose();
        }

        private void BackChess_Click(object sender, EventArgs e) {
            if (checkBoard[removeCoordinates.X, removeCoordinates.Y] == 0) {
                MessageBox.Show("没有棋子可以撤回", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("确认撤回" + removeCoordinates.ToString() + "的棋子吗(只能撤回一步）", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                checkBoard[removeCoordinates.X, removeCoordinates.Y] = 0;
                // Chess chess = Chess.GetInstance(ChessBoardPanel);
                isBlackTurn = !isBlackTurn;
                changeGameState();
                Refresh();
                FunctionBar.Refresh();
                // chess.ReDrawChess(checkBoard);
            }
        }
        public int timerText = 120;
        private bool isBlinking = false;
        //30-0为警告，10-0闪烁
        public void UpdateTimerLableText(int countTime) {
            if (countTime > 30) {
                TimeLable.ForeColor = Color.Black;
            }
            else if (countTime > 10) {
                TimeLable.ForeColor = Color.Orange;
            }
            else if (countTime > 0) {
                TimeLable.ForeColor = Color.Red;
                if (!BlinkTime.Enabled) {
                    isBlinking = true;
                    BlinkTime.Start();
                }
            }
            else {
                isBlinking = false;
            }
            TimeLable.Text = "剩余时间：" + countTime;
        }

        private void BlinkTimer_Tick(object sender, EventArgs e) {
            if (isBlinking) {
                TimeLable.Visible = !TimeLable.Visible; // 切换Label的可见性
            }
            else {
                TimeLable.Visible = true; // 确保Label在停止闪烁时可见
                BlinkTime.Stop();
            }
        }
        private void timer1_Tick(object sender, EventArgs e) {
            if(timerText > 0) {
                UpdateTimerLableText(timerText);
                timerText--;
            }
            else {
                timer1.Stop();
                BlinkTime.Stop();
                TimeLable.Visible = true; // 确保Label在停止闪烁时可见
                string winner = isBlackTurn ? "白方" : "黑方";
                MessageBox.Show($"计时结束未落子，{winner}获胜", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                initializeGame();
            }
        }
    }
}
