using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WuziqiServer.Models;

namespace WuziqiServer.Services.Interfaces
{
    public interface IRoomService
    {
        int GetRoom(Player host);             // 创建房间
        bool JoinRoom(int roomId, Player guest); // 加入房间
        bool ToggleReady(int roomId); // 切换准备状态
        GameState GetGameState(int roomId);      // 获取游戏状态
        bool PlaceChess(int roomId, int x, int y, string playerId); // 落子

        
    }
}
