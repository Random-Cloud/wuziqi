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

        public Form1() {
            InitializeComponent();
            ChessBoardPanel.MouseClick += ChessBoardPanel_MouseClick;
            ChessBoardPanel.Paint += ChessBoardPanel_Paint;
            FunctionBar.Paint += FunctionBar_Paint;
            BeginButton.Click += BeginButton_Click;
            Restart.Click += Restart_Click;
            ExitButton.Click += ExitButton_Click;
        }


        // ���ش���ʱ���¼��������,��ʼ�����ڴ�С�Լ�λ��
        private void Form1_Load(object sender, EventArgs e) {
            initializeGame();
            this.Width = MainSize.FormWidth;
            this.Height = MainSize.FormHeight;
            this.Location = new Point(400, 75);

        }
        // ���̳�ʼ������ʾ��ʼ��ť���������¿�ʼ��ť
        private void initializeGame() {
            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    checkBoard[i, j] = 0;
                }
            }
            start = false;
            GameState.Text = "��Ϸδ��ʼ";
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
            // �ж���Ϸ�Ƿ�ʼ
            if (start) {

                // �����λ�õ�x��y����
                int PlacementX = e.X / MainSize.CellSize;
                int PlacementY = e.Y / MainSize.CellSize;
                try {
                    if (checkBoard[PlacementX, PlacementY] != 0) {
                        return;
                    }
                    if (isBlackTurn) {
                        checkBoard[PlacementX, PlacementY] = 1;
                        GameState.Text = "�׷�ִ��";
                    }
                    else {
                        checkBoard[PlacementX, PlacementY] = 2;
                        GameState.Text = "�ڷ�ִ��";
                    }
                    // ��������
                    Chess chess = new Chess(ChessBoardPanel);
                    chess.DrawChess(isBlackTurn, PlacementX, PlacementY);

                    // �ж��Ƿ�ʤ��
                    if (IsWin.IsWinCheck(checkBoard, PlacementX, PlacementY)) {
                        string winner = isBlackTurn ? "�ڷ�" : "�׷�";
                        MessageBox.Show(winner + "ʤ����", "��Ϸ����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        initializeGame();
                    }
                    // �л��غ�
                    isBlackTurn = !isBlackTurn;
                }
                catch (Exception) {
                    // TODO: �����쳣
                }

            }
        }
        private void FunctionBar_Paint(object sender, PaintEventArgs e) {
            FunctionBar.Size = new Size(MainSize.FormWidth - MainSize.BoardWidth - MainSize.ChessBoardMargin, MainSize.FormHeight);
        }
        // ��ʼ��ť
        private void BeginButton_Click(object sender, EventArgs e) {
            // ��Ϸ��ʼ����ʾ���¿�ʼ��ť�����ؿ�ʼ��ť
            start = true;
            GameState.Text = "�ڷ�ִ��";
            isBlackTurn = true;
            BeginButton.Visible = false;
            Restart.Visible = true;
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
            this.Dispose();
        }

        private void ExitButton_Click_1(object sender, EventArgs e) {

        }
    }
}
