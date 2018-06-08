﻿using System;
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

            }else
            {
                msg = a[4];
                a = msg.Split(' ');
                msg = a[0];
                this.Send("!mp unlock", "#mp_" + msg);
                Console.WriteLine("Room is UnLock");
                this.Send("!mp password 1234", "#mp_" + msg);
                Console.WriteLine("Password is set :1234");
                
            }
          
        }

        private void IRC_OnQueryAction(object sender, ActionEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void IRC_OnChannelMessage(object sender, IrcEventArgs e)
        {
            Console.WriteLine("[" + System.DateTime.Now + e.Data.Channel + "]" + e.Data.Nick + ":" + e.Data.Message);
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
        public void inviteRome()
        {
        
           
        }
    }
}
