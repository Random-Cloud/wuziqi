using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WuziqiClient {
    class Player {
        // 玩家唯一标识
        public string Id {
            get; set;
        }
        // 玩家昵称（可选）
        public string Name {
            get; set;
        }
        // 玩家准备状态
        public bool IsReady {
            get; set;
        }    
    }
}
