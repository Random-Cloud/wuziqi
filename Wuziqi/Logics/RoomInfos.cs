using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WuziqiServer.Logics.Interfaces;
using WuziqiServer.Models;

namespace WuziqiServer.Logics
{
    public class RoomInfos : IRoomInfos {
        private readonly Room room;
        public RoomInfos(Room room) {
            this.room = room;
        }
        public int GetRoomId() {
            return room.RoomId;
        }
        public GameState GetGameState() {
            return room.gameState;
        }
        public bool ReadyToBegin() {
            return room.isReady [0] && room.isReady[1];
        }
        public Player GetHostPlayer() {
            return room.HostPlayer;
        }
        public Player GetGuestPlayer() {
            return room.GuestPlayer;
        }
        
    }
    
}
