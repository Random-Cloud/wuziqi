using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WuziqiServer.Models;

namespace WuziqiServer.Logics.Interfaces
{
    // 更新房间状态的接口
    public interface IRoomInteraction
    {
        
        void UpdateReadyState(int index);
        void UpdateHostPlayer(Player host);
        void UpdateGuestPlayer(Player guest);
        void UpdateGameState(GameState gameState);
        void ExchangeHostAndGuest();
    }
}
