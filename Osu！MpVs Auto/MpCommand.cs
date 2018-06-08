﻿using System;
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
            Console.WriteLine("\t\t\t提示：以下指令无需加前缀符号 直接输入文字即可 命令后面带* 只有裁判才能使用  星号在房间内使用时不需要打 ");
            Console.WriteLine("\t\t\t房间大小 <数量>*");
            Console.WriteLine("\t\t\tban图 <地图ID>？只有队长才可使用");
            Console.WriteLine("\t\t\t列出图池");
            Console.WriteLine("\t\t\t抽取地图");
            Console.WriteLine("\t\t\t选择地图 <地图id>");
            Console.WriteLine("\t\t\t移动 <玩家ID> <楼层>*");
            Console.WriteLine("\t\t\t切换模式 <0 Freemod 1 none >*");
            Console.WriteLine("\t\t\t踢出玩家 <玩家ID>*");

        }
    }
}
