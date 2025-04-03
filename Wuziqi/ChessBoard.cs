using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wuziqi
{
    class ChessBoard
    {
        // 绘制棋盘
        public static void DrawCB(Graphics g) {
            // 棋盘格子大小
            int GapWidth = MainSize.CellSize;
            // 棋盘格子数
            int GapNum = MainSize.BoardWidth / GapWidth - 1;
            
            g.Clear(Color.Bisque);
            Pen pen = new Pen(Color.FromArgb(160, 120, 80), 2f);
            // Pen pen = new Pen(Color.FromArgb(192, 166, 107));
            for (int i = 0; i < GapNum + 1; i++) {
                g.DrawLine(pen, new Point(20, i * GapWidth + 20), new Point(GapWidth * GapNum + 20, i * GapWidth + 20));
                g.DrawLine(pen, new Point(i * GapWidth + 20, 20), new Point(i * GapWidth + 20, GapWidth * GapNum + 20));
            }

        }
    }
}
