using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wuziqi
{
    // 一些静态常量
    class MainSize
    {
        public static int FormWidth { get; } = 1400;
        public static int FormHeight { get; } = 1000;
        public static int BoardWidth { get; } = 930; // 15列 = 15*62 - 2*50（边距）
        public static int BoardHeight { get; } = 930;
        // 棋盘格子大小
        public static int CellSize { get; } = 62;
        // 棋子直径
        public static int ChessDiameter { get; } = 50;
        // 棋盘边距
        public static int ChessBoardMargin { get; } = 50;
        // 棋子绘制偏移量
        public static int ChessOffset {get;} = 31;

    }
}
