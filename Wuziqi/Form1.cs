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

        public Form1() {
            InitializeComponent();
            ChessBoardPanel.MouseClick += ChessBoardPanel_MouseClick;
            ChessBoardPanel.Paint += ChessBoardPanel_Paint;
            FunctionBar.Paint += FunctionBar_Paint;
            BeginButton.Click += BeginButton_Click;
            Restart.Click += Restart_Click;
            ExitButton.Click += ExitButton_Click;
        }


        // 加载窗体时的事件处理程序,初始化窗口大小以及位置
        private void Form1_Load(object sender, EventArgs e) {
            initializeGame();
            this.Width = MainSize.FormWidth;
            this.Height = MainSize.FormHeight;
            this.Location = new Point(400, 75);

        }
        // 棋盘初始化，显示开始按钮，隐藏重新开始按钮
        private void initializeGame() {
            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    checkBoard[i, j] = 0;
                }
            }
            start = false;
            GameState.Text = "游戏未开始";
            BeginButton.Visible = true;
            Restart.Visible = false;
        }

        private void ChessBoardPanel_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            ChessBoard.DrawCB(g);
            Chess chess = new Chess(ChessBoardPanel);
            chess.ReDrawChess(checkBoard);
        }


        private void ChessBoardPanel_MouseClick(object sender, MouseEventArgs e) {
            // 判断游戏是否开始
            if (start) {

                // 鼠标点击位置的x、y坐标
                int PlacementX = e.X / MainSize.CellSize;
                int PlacementY = e.Y / MainSize.CellSize;
                try {
                    if (checkBoard[PlacementX, PlacementY] != 0) {
                        return;
                    }
                    if (isBlackTurn) {
                        checkBoard[PlacementX, PlacementY] = 1;
                        GameState.Text = "白方执棋";
                    }
                    else {
                        checkBoard[PlacementX, PlacementY] = 2;
                        GameState.Text = "黑方执棋";
                    }
                    // 绘制棋子
                    Chess chess = new Chess(ChessBoardPanel);
                    chess.DrawChess(isBlackTurn, PlacementX, PlacementY);

                    // 判断是否胜利
                    if (IsWin.IsWinCheck(checkBoard, PlacementX, PlacementY)) {
                        string winner = isBlackTurn ? "黑方" : "白方";
                        MessageBox.Show(winner + "胜利！", "游戏结束", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        initializeGame();
                    }
                    // 切换回合
                    isBlackTurn = !isBlackTurn;
                }
                catch (Exception) {
                    // TODO: 处理异常
                }

            }
        }
        private void FunctionBar_Paint(object sender, PaintEventArgs e) {
            FunctionBar.Size = new Size(MainSize.FormWidth - MainSize.BoardWidth - MainSize.ChessBoardMargin, MainSize.FormHeight);
        }
        // 开始按钮
        private void BeginButton_Click(object sender, EventArgs e) {
            // 游戏开始，显示重新开始按钮，隐藏开始按钮
            start = true;
            GameState.Text = "黑方执棋";
            isBlackTurn = true;
            BeginButton.Visible = false;
            Restart.Visible = true;
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
            this.Dispose();
        }

        private void ExitButton_Click_1(object sender, EventArgs e) {

        }
    }
}
