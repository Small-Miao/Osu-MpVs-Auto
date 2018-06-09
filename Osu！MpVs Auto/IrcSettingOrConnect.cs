using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Meebey.SmartIrc4net;

namespace Osu_MpVs_Auto
{
    class IrcSettingOrConnect
    {
        public static IrcClient IRC = new IrcClient();
        private static Thread _ListenThread;
        private string Addres = "irc.ppy.sh";
        string msg;
        int matchroom;
        
        private int Port = 6667;
        public void irc()
        {
            IRC.Encoding = Encoding.UTF8;
            IRC.OnChannelMessage += IRC_OnChannelMessage;
            IRC.OnQueryAction += IRC_OnQueryAction;
            IRC.OnQueryMessage += IRC_OnQueryMessage;
        }

        private void IRC_OnQueryMessage(object sender, IrcEventArgs e)
        {
           Console.WriteLine("[" + System.DateTime.Now + "私聊" + "]" + e.Data.Nick + ":" + e.Data.Message);
           msg= e.Data.Message;
          var a = msg.Split('/');
            if (a[0]==null)
            {
               a = msg.Split(' ');
                switch (a[0])
                {
                    case "房间大小": this.Send("!mp size"+a[1],"#mp_"+matchroom);
                        break;
                    default:
                        break;
                }
            }else
            {
                msg = a[4];
                a = msg.Split(' ');
                matchroom = Convert.ToInt32( a[0]);
                Console.WriteLine("房间号为："+matchroom);
                this.Send("!mp unlock", "#mp_" + matchroom);
                Console.WriteLine("Room is UnLock");
                this.Send("!mp password 1234", "#mp_" + matchroom);
                Console.WriteLine("Password is set :1234");
                this.Send("!mp set 2 0 16","#mp_"+matchroom);
                Console.WriteLine("已经设置房间为团队对抗模式 积分模式ScoreV1 房间大小：16人");
               
                
            }
          
        }

        private void IRC_OnQueryAction(object sender, ActionEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void IRC_OnChannelMessage(object sender, IrcEventArgs e)
        {
            Console.WriteLine("[" + System.DateTime.Now + e.Data.Channel + "]" + e.Data.Nick + ":" + e.Data.Message);
            msg = e.Data.Message;
            var a = msg.Split(' ');
            switch (a[0])
            {
                case "房间大小":
                    this.Send("!mp size " + a[1], "#mp_" + matchroom);
                    break;
                default:
                    break;
            }
        }
        public bool Connect()
        {   //服务器连接
            try
            {
                IRC.Connect(this.Addres, this.Port);
                Console.WriteLine("服务器连接成功");
                return true;
            }
            catch (CouldNotConnectException)
            {
                Console.WriteLine("无法连接到服务器 请检查网络");
                return false;
            }
            catch (AlreadyConnectedException)
            {
                Console.WriteLine("服务器已连接");
                return false;

            }
        }
        public bool Login(string User, string Password)
        {   //登录=
            try
            {
                Console.WriteLine("登录成功");
                IRC.Login(User, User, 0, User, Password);
                return true;
            }
            catch
            {
                Console.WriteLine("登录失败");
                return false;

            }

        }
        public void Send(string message, string Chanl)
        {
            //发送频道消息
            IRC.SendMessage(SendType.Message, Chanl, message);
        }
        public void IRCsend(string Msg, string id)
        {
            //发送私聊消息
            IRC.SendMessage(SendType.Message, id, Msg);
        }
        public void JoinChanl(string Chanl)
        {
            //加入频道
            IRC.RfcJoin(Chanl);
        }

        public void ExitChanl(string Chanl)
        {
            //退出频道
            IRC.RfcQuit(Chanl);
        }
        public bool ThredStart()
        {   //监听线程
            _ListenThread = new Thread(new ThreadStart(IRCThread));
            try
            {
                Console.WriteLine("线程启动成功");
                _ListenThread.Start();
                return true;
            }
            catch
            {
                Console.WriteLine("线程启动失败");
                return false;

            }
        }
        public void ThredStop()
        {//停止线程
            _ListenThread.Abort();
        }

        public void IRCThread()
        {
            try

            {
                IRC.Listen();
            }
            catch
            {
            }
        }
        public void ircsetting()
        {
            IrcSettingOrConnect Irc = new IrcSettingOrConnect();
            string user, password;
            Console.Write("输入IRC用户名:");
            user = Console.ReadLine();
            Console.Write("输入IRC密码:");
            password = Console.ReadLine();
            Irc.irc();
            Irc.Connect();
            Irc.Login(user, password);
            Irc.JoinChanl("#lobby");
            Irc.ThredStart();
        }
        public void inviteRome(string name)
        {
            this.Send("!mp invite"+name,"#mp_"+msg);
           
        }
        public void exit()
        {
            this.Send("!mp close","#mp_"+msg);
        }
    }
}
