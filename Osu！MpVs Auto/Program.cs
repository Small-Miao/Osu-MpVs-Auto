﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Osu_MpVs_Auto
{

    class Program
    {
        IrcSettingOrConnect Irc = new IrcSettingOrConnect();
        static void Main(string[] args)
        {
            int choose = 3;
            Console.WriteLine("\t\tOsu！自动比赛客户端");
            while (true)
            {
                Console.WriteLine("\t\t\t-Menu-");
                Console.WriteLine("\t\t1.设置irc账号信息\n\t\t2.开始比赛\n\t\t3.退出软件");
                try
                {
                    choose = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("请输入正确的数字");

                }
                switch (choose)
                {
                    case 1:
                        IrcSettingOrConnect irc = new IrcSettingOrConnect();
                        irc.ircsetting();
                        break;
                    case 2:
                        IrcSettingOrConnect ircSetting = new IrcSettingOrConnect();
                        Console.WriteLine("输入你要创建的房间名称:");
                        Console.ReadLine();
                        break;
                    case 3: break;
                    default: break;
                }
                Console.ReadLine();
            }

        }

    }
}
