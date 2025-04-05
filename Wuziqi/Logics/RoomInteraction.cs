using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WuziqiServer.Logics.Interfaces;
using WuziqiServer.Models;

namespace WuziqiServer.Logics {
    public class RoomInteraction : IRoomInteraction {
        private readonly Room room;
        public RoomInteraction(Room room) {
            this.room = room;
        }

        public void UpdateReadyState(int index) {
            room.isReady[index] = !room.isReady[index];
        }
        public void UpdateHostPlayer(Player host) {
            room.HostPlayer = host;
        }
        public void UpdateGuestPlayer(Player guest) {
            room.GuestPlayer = guest;
        }
        public void UpdateGameState(GameState gameState) {
            room.gameState = gameState;
        }
        public void ExchangeHostAndGuest() {
            (room.HostPlayer, room.GuestPlayer) = (room.GuestPlayer, room.HostPlayer);
        }
    }
}
    
