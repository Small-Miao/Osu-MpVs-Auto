using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Osu_MpVs_Auto
{
    class MpCommand
    {
        public void help()
        {
            Console.WriteLine("\t\t\t本地指令:\n\t\t\tmp mapadd <beatmapid>往图池添加地图");
            Console.WriteLine("\t\t\tmp invite <username>邀请玩家");
            Console.WriteLine("\t\t\tmp redteamcap set <username>设置红队队长>");
            Console.WriteLine("\t\t\tmp redteammem set <username>添加红队队员");
            Console.WriteLine("\t\t\tmp blueteamcap set <username>设置蓝队队长>");
            Console.WriteLine("\t\t\tmp buleteammem set <username>添加蓝队队员");
            Console.WriteLine("\t\t\tmp setref <username>设置裁判");
            Console.WriteLine("\t\t\tMp房间指令");
        }
    }
}
