using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using Wuziqi;

namespace Wuziqi
{

    public class  Chess {
        
        private Graphics g;
        private int accurateX;
        private int accurateY;
        private Rectangle rect;
        private static Chess instance;

        private Chess(Panel p) {
            g = p.CreateGraphics();
        }

        public static Chess GetInstance(Panel p) {
            if (instance == null) {
                instance = new Chess(p);
            }
            return instance;
        }

        private void DrawChess(bool isBlackTurn) {
            if (isBlackTurn) {
                g.FillEllipse(ChessBrush.blackBrush, rect);
            }
            else {
                g.FillEllipse(ChessBrush.whiteBrush, rect);
            }
        }
        private void InitCoordinate(int placementX, int placementY) {
            accurateX = placementX * ClientConstants.CellSize + ClientConstants.ChessBoardMargin - ClientConstants.ChessOffset;
            accurateY = placementY * ClientConstants.CellSize + ClientConstants.ChessBoardMargin - ClientConstants.ChessOffset;
            
            // 绘制区域（中心点坐标需根据棋盘计算）
            rect = new Rectangle(
                x: accurateX - ClientConstants.ChessDiameter / 2,  // 圆心X - 半径
                y: accurateY - ClientConstants.ChessDiameter / 2,  // 圆心Y - 半径
                width: ClientConstants.ChessDiameter,
                height: ClientConstants.ChessDiameter
            );
            
        }
        public void DrawChess(bool isBlackTurn, int placementX, int placementY) {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // 确认棋子的x、y中心位置
            InitCoordinate(placementX, placementY);

            // 判断是谁的回合并绘制棋子
            DrawChess(isBlackTurn);
        }
        public void ReDrawChess(int[,] CheckBoard) {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // 外层遍历每行，内层遍历每列
            for (int i = 0; i < CheckBoard.GetLength(1); i++) {
                for (int j = 0; j < CheckBoard.GetLength(0); j++) {
                    // 判断当前格子是否有棋子 0表示没有棋子 1表示黑子 2表示白子
                    int checkChess = CheckBoard[j, i];
                    switch (checkChess) {
                        case 0:
                            break;
                        case 1:
                            InitCoordinate(j, i);
                            DrawChess(true);
                            break;
                        case 2:
                            InitCoordinate(j, i);
                            DrawChess(false);
                            break;
                    }
                }
            }
        }
    }
}
