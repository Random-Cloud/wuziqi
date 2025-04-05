using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WuziqiServer.Logics.Interfaces;
using WuziqiServer.Logics;


namespace WuziqiServer.Models
{
    class RoomPackage
    {
        public Room? room;
        public IRoomInfos? roomInfos;
        public IRoomInteraction? roomInteraction;
        public void SetRoom(Room room) {
            this.room = room;
            roomInfos ??= new RoomInfos();
            roomInteraction ??= new RoomInteraction();
            roomInfos.SetRoom(room);
            roomInteraction.SetRoom(room);
        }
        public void ClearRoomPackage() {
            room = null;
            roomInfos = null;
            roomInteraction = null;
        }
    }
}
