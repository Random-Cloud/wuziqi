using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Metadata.Providers;

namespace WuziqiServer.Constants
{
    public enum ERoomState
    {
        EmptyRoom = 0, // 空房间 
        MatchRoom = 1, // 匹配中
        FullRoom = 2 // 满员
    }
}
