using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WuziqiServer.Models;

namespace WuziqiServer.Logics.Interfaces
{
    // 房间信息接口,仅用于获取房间信息
    public interface IRoomInfos
    {
        // 获取房间ID
        int GetRoomId();
        // 获取游戏状态
        GameState GetGameState();
        // 获取准备状态
        bool ReadyToBegin();
        // 获取房主
        Player GetHostPlayer();
        // 获取客人
        Player GetGuestPlayer();

        

    }
}
