using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wuziqi
{
    public sealed class RemoveCoordinates {
        public int X { get; private set; }
        public int Y { get; private set; }
        private RemoveCoordinates() {
        }
        private static RemoveCoordinates instance;
        // 当前场景不涉及多线程，所以不需要加锁
        public static RemoveCoordinates GetInstance() {
            if (instance == null) {
                instance = new RemoveCoordinates();
            }
            return instance;
        }
        public void SetCoordinates(int x, int y) {
            X = x;
            Y = y;
        }
        public override string ToString() {
            return $"[{X},{Y}]";
        }
    }
}
