namespace Wuziqi
{
    public partial class Form1 : Form {
        // ��Ϸ�Ƿ�ʼ�ı�־
        private bool start;
        // �Ƿ�Ϊ�ڷ��غ�
        private bool isBlackTurn;
        // ���̴�С
        private const int size = 15;
        // ��������
        private int[,] checkBoard = new int[size, size];
        private RemoveCoordinates removeCoordinates;
        private int chessCount;

        public Form1() {
            InitializeComponent();
        }


        // ���ش���ʱ���¼��������,��ʼ�����ڴ�С�Լ�λ��
        private void Form1_Load(object sender, EventArgs e) {
            initializeGame();
            Width = ClientConstants.FormWidth;
            Height = ClientConstants.FormHeight;
            Location = new Point(400, 75);

        }
        // ���̳�ʼ������ʾ��ʼ��ť���������¿�ʼ��ť
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
            GameState.Text = "��Ϸδ��ʼ";
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
                GameState.Text = "�ڷ�ִ��";
            }
            else {
                GameState.Text = "�׷�ִ��";
            }
        }
        private void ChessBoardPanel_MouseClick(object sender, MouseEventArgs e) {
            // �ж���Ϸ�Ƿ�ʼ
            if (start) {

                // �����λ�õ�x��y����
                int PlacementX = e.X / ClientConstants.CellSize;
                int PlacementY = e.Y / ClientConstants.CellSize;
                try {
                    // �жϵ��λ���Ƿ������̷�Χ��
                    if (checkBoard[PlacementX, PlacementY] != 0) {
                        return;
                    }
                    checkBoard[PlacementX, PlacementY] = isBlackTurn ? 1 : 2;

                    // ��¼��������
                    removeCoordinates.SetCoordinates(PlacementX, PlacementY);
                    // ��������
                    Chess chess = Chess.GetInstance(ChessBoardPanel);
                    chess.DrawChess(isBlackTurn, PlacementX, PlacementY);
                    chessCount++;

                    // �ж��Ƿ�ʤ��
                    if (IsWin.IsWinCheck(checkBoard, PlacementX, PlacementY)) {
                        string winner = isBlackTurn ? "�ڷ�" : "�׷�";
                        MessageBox.Show(winner + "ʤ����", "��Ϸ����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        initializeGame();
                    }
                    // �л��غ�
                    isBlackTurn = !isBlackTurn;
                    changeGameState();
                    // �ж�ƽ��
                    if (chessCount == size * size) {
                        MessageBox.Show("����������ƽ�֣�", "��Ϸ����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        initializeGame();
                        return;
                    }
                }
                catch (Exception) {
                    // TODO: �����쳣
                }

            }
        }
        private void FunctionBar_Paint(object sender, PaintEventArgs e) {
            FunctionBar.Size = new Size(ClientConstants.FormWidth - ClientConstants.BoardWidth - ClientConstants.ChessBoardMargin, ClientConstants.FormHeight);
        }
        // ��ʼ��ť
        private void BeginButton_Click(object sender, EventArgs e) {
            // ��Ϸ��ʼ����ʾ���¿�ʼ��ť�����ؿ�ʼ��ť
            start = true;
            GameState.Text = "�ڷ�ִ��";
            isBlackTurn = true;
            BeginButton.Visible = false;
            Restart.Visible = true;
            BackChess.Visible = true;
            // �ػ�����
            ChessBoardPanel.Invalidate();
        }
        // ���¿�ʼ��ť
        private void Restart_Click(object sender, EventArgs e) {
            // ���¿�ʼ��Ϸ����ʼ������
            if (MessageBox.Show("�Ƿ������ǰ�Ծ����¿�ʼ��", "��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                initializeGame();
                BeginButton_Click(sender, e);
            }

        }

        private void ExitButton_Click(object sender, EventArgs e) {
            // �˳���Ϸ
            Dispose();
        }

        private void BackChess_Click(object sender, EventArgs e) {
            if (checkBoard[removeCoordinates.X, removeCoordinates.Y] == 0) {
                MessageBox.Show("û�����ӿ��Գ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("ȷ�ϳ���" + removeCoordinates.ToString() + "��������(ֻ�ܳ���һ����", "��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
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
        //30-0Ϊ���棬10-0��˸
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
            TimeLable.Text = "ʣ��ʱ�䣺" + countTime;
        }

        private void BlinkTimer_Tick(object sender, EventArgs e) {
            if (isBlinking) {
                TimeLable.Visible = !TimeLable.Visible; // �л�Label�Ŀɼ���
            }
            else {
                TimeLable.Visible = true; // ȷ��Label��ֹͣ��˸ʱ�ɼ�
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
                TimeLable.Visible = true; // ȷ��Label��ֹͣ��˸ʱ�ɼ�
                string winner = isBlackTurn ? "�׷�" : "�ڷ�";
                MessageBox.Show($"��ʱ����δ���ӣ�{winner}��ʤ", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                initializeGame();
            }
        }
    }
}
