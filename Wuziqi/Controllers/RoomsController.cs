using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WuziqiServer.Models;
using WuziqiServer.Services.Interfaces;

namespace WuziqiServer.Controllers
{
    [ApiController]
    [Route("api/rooms")]
    public class RoomsController : ControllerBase {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService) {
            _roomService = roomService;
        }

        // 创建房间
        [HttpPost("create")]
        public IActionResult CreateRoom([FromBody] Player host) {
            int roomId = _roomService.GetRoom(host);
            return roomId == -1 ? BadRequest("房间已满") : Ok(new {
                RoomId = roomId
            });
        }

        // 加入房间
        [HttpPost("{roomId}/join")]
        public IActionResult JoinRoom(int roomId, [FromBody] Player guest) {
            return _roomService.JoinRoom(roomId, guest)
                ? Ok("加入成功")
                : BadRequest("房间不存在或已满");
        }

        // 准备/取消准备
        [HttpPost("{roomId}/ready")]
        public IActionResult ToggleReady(int roomId, [FromQuery] string playerId) {
            return _roomService.ToggleReady(roomId, playerId)
                ? Ok()
                : NotFound("房间不存在");
        }
    }
}
