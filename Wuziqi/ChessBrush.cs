using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wuziqi
{
    public static class ChessBrush
    {
        public static readonly SolidBrush blackBrush = new SolidBrush(Color.FromArgb(0, 0, 0));  // 纯黑
        public static readonly SolidBrush whiteBrush = new SolidBrush(Color.FromArgb(255, 255, 255)); // 纯白
        
    }
}
