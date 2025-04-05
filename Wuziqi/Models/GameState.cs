using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WuziqiServer.Constants;

namespace WuziqiServer.Models
{
    // 游戏开始后的状态
    public class GameState
    {
        // 当前棋盘
        public bool Start {
            get;private set;
        }
        public readonly int[,] Board;
        // 当前回合玩家（黑/白）
        public bool IsBlackTurn {
            get; private set;
        }
        // 剩余时间（秒）
        public int RemainingSeconds {
            get; set;
        }
        // 获胜者
        public EWhoWin WhoWin {
            get; private set;
        }
        public GameState() {
            Board = new int[AllConstants.BoardSize, AllConstants.BoardSize];
            IsBlackTurn = true;
            RemainingSeconds = AllConstants.MaxWaitTime;
            WhoWin = EWhoWin.None;
            Start = false;
        }
        public void UpdateIsHostWin(EWhoWin winer) {
            WhoWin = winer;
        }
        public void UpdateIsBlackTurn() {
            IsBlackTurn = !IsBlackTurn;
        }
        public void RestWaitTime() {
            RemainingSeconds = AllConstants.MaxWaitTime;
        }
        public void UpdateStart() {
            Start = !Start;
        }

    }
}
