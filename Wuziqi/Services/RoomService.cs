using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wuziqi;
using WuziqiServer.Constants;
using WuziqiServer.Models;
using WuziqiServer.Logics;
using WuziqiServer.Services.Interfaces;
using Microsoft.Extensions.Hosting;
using WuziqiServer.Logics.Interfaces;

namespace WuziqiServer.Services
{
    public class RoomService : IRoomService {
        private readonly ConcurrentDictionary<int, Room> _rooms = new();
        // 线程锁，确保线程安全
        private readonly Lock _lock = new();
        private readonly ConcurrentDictionary<int, ERoomState> _roomStates = new();
        // emptyRoomStack 用于存储空闲房间号
        private readonly Stack<int> emptyRoomStack = new();
        // matchRoomStack 用于存储匹配中的房间号
        private readonly Stack<int> matchRoomStack = new();


        // 初始化所有房间
        public void InitRoomService() {
            for (int id = AllConstants.MinRoomCount; id <= AllConstants.MaxRoomCount; id++) {
                var room = new Room();
                if (_rooms.TryAdd(id, room)) {
                    room.RoomId = id;
                    _roomStates.TryAdd(id, ERoomState.EmptyRoom);
                    emptyRoomStack.Push(id);
                }
            }
        }

        // 房主创建房间，将房间状态设置为匹配中
        public int GetRoom(Player host) {
            lock (_lock) {
                if (emptyRoomStack.Count > 0) {
                    int roomId = emptyRoomStack.Pop();
                    _rooms.TryGetValue(roomId, out var room);
                    room.HostPlayer = host;
                    _roomStates[roomId] = ERoomState.MatchRoom;
                    matchRoomStack.Push(roomId);
                    return roomId;
                }
            }
            return -1;
        }
        // 可以考虑返回ERoomState类型，给出更详细的加入失败原因
        public bool JoinRoom(int roomId, Player guest) {
            if (roomId > AllConstants.MaxRoomCount || roomId < AllConstants.MinRoomCount)
                return false;
            if (_roomStates[roomId] != ERoomState.MatchRoom)
                return false;
            _rooms.TryGetValue(roomId, out var room);
            room.GuestPlayer = guest;
            return true;
        }
        // 先留着，后面考虑删除
        public GameState GetGameState(int roomId) {
            return _rooms.TryGetValue(roomId, out var room) ? room.gameState : null;
        }
        public bool ToggleReady(int roomId) {
            _rooms.TryGetValue(roomId, out var room);
            if (room.ReadyToBegin()) {
                lock (_lock) {
                    // 双方准备后启动游戏
                    room.gameState.UpdateStart();
                    Task.Run(() => StartTurnTimer(room));
                    return true;
                }
            }
            return false;       
        }


        /// <summary>
        /// 处理落子，返回游戏状态
        /// 棋子越界直接抛出异常，不做额外处理
        /// 黑方回合且玩家非主机，直接返回; 白方回合且玩家非客机，直接返回
        /// 默认房主执黑
        /// </summary>
        public bool PlaceChess(int roomId, int x, int y, string playerId) {
            if (!_rooms.TryGetValue(roomId, out var room))
                return false;
            
            lock (_lock) {
                GameState gameState = room.gameState;
                if (gameState.IsBlackTurn && room.HostPlayer.Id != playerId)
                    return false;

                if (!gameState.IsBlackTurn && room.GuestPlayer.Id != playerId)
                    return false;

                // 落子
                gameState.Board[x, y] = gameState.IsBlackTurn ? (int)EChess.BlackChess : (int)EChess.WhiteChess;
                // 切换回合并重置计时
                gameState.UpdateIsBlackTurn();
                gameState.RestWaitTime();
                return true;
            }
        }

        // 处理倒计时
        private async void StartTurnTimer(Room room) {
            GameState gameState = room.gameState;
            while (gameState.Start) {
                var remaining = gameState.RemainingSeconds;
                if (remaining <= 0) {
                    // 处理超时判负
                    gameState.UpdateStart();
                    break;
                }
                await Task.Delay(1000);
            }
        }
    }
}
