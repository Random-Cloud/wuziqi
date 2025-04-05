using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WuziqiServer.Logics.Interfaces;
using WuziqiServer.Logics;

namespace WuziqiServer.Models
{
    // 房间,默认房主执黑
    public class Room {
        // 房间信息接口
        // public readonly IRoomInfos? roomInfos;
        // public readonly IRoomInteraction? roomInteraction;
        public readonly GameState gameState = new();
        public Room() {
            // roomInfos = new RoomInfos(this);
            // roomInteraction = new RoomInteraction(this);
        }
        // 房间号 (1-20)
        public int RoomId {
            get; set;
        }
        // 房主
        public Player? HostPlayer {
            get; set;
        }
        // 玩家
        public Player? GuestPlayer {
            get; set;
        }
        // 双方准备状态，0表示房主，1表示客人
        private bool [] isReady = {false, false};
        public bool ReadyToBegin() {
            return isReady[0] && isReady[1];
        }
        public void ChangeReady(int index) {
            isReady[index] = !isReady[index];
        }
    }
}
