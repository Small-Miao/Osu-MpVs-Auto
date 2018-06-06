using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Osu_MpVs_Auto
{
    class Program
    {
        static void Main(string[] args)
        {
            int choose = 3;
            Console.WriteLine("\t\tOsu！自动比赛客户端");
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
            switch(choose)
            {
                case 1:break;
                case 2:break;
                case 3:break;
                default: break;
            }
            Console.ReadLine();
        }
    }
}
