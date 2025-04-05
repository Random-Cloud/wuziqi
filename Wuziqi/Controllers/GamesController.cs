using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WuziqiServer.Services.Interfaces;

namespace WuziqiServer.Controllers
{
    [ApiController]
    [Route("api/games")]
    public class GamesController : ControllerBase {
        private readonly IRoomService _roomService;

        public GamesController(IRoomService roomService) {
            _roomService = roomService;
        }

        // 获取游戏状态
        [HttpGet("{roomId}/state")]
        public IActionResult GetGameState(int roomId) {
            var state = _roomService.GetGameState(roomId);
            return state != null ? Ok(state) : NotFound();
        }

        // 落子操作
        [HttpPost("{roomId}/place")]
        public IActionResult PlaceChess(int roomId, [FromBody] PlaceChessRequest request) {
            bool success = _roomService.PlaceChess(roomId, request.X, request.Y, request.PlayerId);
            return success ? Ok() : BadRequest("非法操作");
        }
    }

    public class PlaceChessRequest {
        public int X {
            get; set;
        }
        public int Y {
            get; set;
        }
        // 0表示没有，1表示黑棋，2表示白棋
        public int ChessColor {
            get; set;
        }
        public string PlayerId {
            get; set;
        }
    }
}
