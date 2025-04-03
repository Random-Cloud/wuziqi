using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wuziqi
{
    class IsWin
    {
        public static bool IsWinCheck(int[,] checkBoard, int x, int y) {
            // 检查横向
            if (CheckDirection(checkBoard, x, y, 1, 0) >= 5)
                return true;
            // 检查纵向
            if (CheckDirection(checkBoard, x, y, 0, 1) >= 5)
                return true;
            // 检查斜向（左上到右下）
            if (CheckDirection(checkBoard, x, y, 1, 1) >= 5)
                return true;
            // 检查斜向（右上到左下）
            if (CheckDirection(checkBoard, x, y, -1, 1) >= 5)
                return true;
            return false;
        }
        private static int CheckDirection(int[,] checkBoard, int x, int y, int dx, int dy) {
            int count = 1;
            // 检查正向
            for (int i = 1; i < 5; i++) {
                int newX = x + i * dx;
                int newY = y + i * dy;
                if (newX < 0 || newX >= checkBoard.GetLength(0) || newY < 0 || newY >= checkBoard.GetLength(1))
                    break;
                if (checkBoard[newX, newY] == checkBoard[x, y])
                    count++;
                else
                    break;
            }
            // 检查反向
            for (int i = 1; i < 5; i++) {
                int newX = x - i * dx;
                int newY = y - i * dy;
                if (newX < 0 || newX >= checkBoard.GetLength(0) || newY < 0 || newY >= checkBoard.GetLength(1))
                    break;
                if (checkBoard[newX, newY] == checkBoard[x, y])
                    count++;
                else
                    break;
            }
            return count;
        }
    }
}
