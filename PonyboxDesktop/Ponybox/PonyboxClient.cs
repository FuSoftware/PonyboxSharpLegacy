using Newtonsoft.Json;
using Quobject.EngineIoClientDotNet.ComponentEmitter;
using Quobject.SocketIoClientDotNet.Client;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PonyboxDesktop.Ponybox
{
    public class PonyboxClient
    {

        public class MessageListRecievedEvent
        {
            public List<Message> messages;
            public string channel;

            public MessageListRecievedEvent(string channel, List<Message> messages)
            {
                this.channel = channel;
                this.messages = messages;
            }
        }
        public class ChannelJoinedEvent
        {
            public Channel channel;

            public ChannelJoinedEvent(Channel channel)
            {
                this.channel = channel;
            }
        }
        public class ChannelListRefreshedEvent
        {
            public List<Channel> channels;
            public ChannelListRefreshedEvent(List<Channel> channels)
            {
                this.channels = channels;
            }
        }
        public class SocketConnectionEvent
        {
            public bool isConnected;

            public SocketConnectionEvent(bool isConnected)
            {
                this.isConnected = isConnected;
            }
        }

        //Events
        public event EventHandler<Message> MessageRecieved;
        public event EventHandler<MessageListRecievedEvent> MessagesRecieved;
        public event EventHandler<ChannelJoinedEvent> ChannelJoined;
        public event EventHandler<ChannelListRefreshedEvent> ChannelListRefreshed;
        public event EventHandler<SocketConnectionEvent> SocketConnectionStateChanged;

        public class ChannelMessageAckListener : IListener
        {
            private readonly Action<object, object> fn;
            private static int id_counter = 0;
            private int ID;

            public ChannelMessageAckListener(Action<object, object> fn)
            {
                this.fn = fn;
                this.ID = id_counter++;
            }

            public void Call(params object[] args)
            {
                var arg1 = args.Length > 0 ? args[0] : null;
                var arg2 = args.Length > 1 ? args[1] : null;

                fn(arg1, arg2);
            }


            public int CompareTo(IListener other)
            {
                return this.GetId().CompareTo(other.GetId());
            }

            public int GetId()
            {
                return ID;
            }
        }

        private static readonly HttpClient client = new HttpClient();

        static string cb_url = "http://www.frenchy-ponies.fr/cb_new_window.php";
        //static string cb_address = "http://94.23.60.187:8080";
        static string cb_address = "https://www.frenchy-ponies.fr:2096";
        static string cb_login = "https://www.frenchy-ponies.fr/ucp.php?mode=login";

        string token = "";
        string sid = "";
        string id = "";

        Socket socket;

        Form parentForm;
        MethodInfo callbackMessageList;
        MethodInfo callbackChannels;
        MethodInfo callbackMessageInsert;

        List<Channel> channels = new List<Channel>();
        Dictionary<string,List<Message>> messages = new Dictionary<string, List<Message>>();

        public void BindForm(Form parent)
        {
            parentForm = parent;
        }

        public void BindMessageListCallback(string method)
        {
            Type thisType = parentForm.GetType();
            callbackMessageList = thisType.GetMethod(method);
        }

        public void BindMessageInsertCallback(string method)
        {
            Type thisType = parentForm.GetType();
            callbackMessageInsert = thisType.GetMethod(method);
        }

        public void BindChannelListCallback(string method)
        {
            Type thisType = parentForm.GetType();
            callbackChannels = thisType.GetMethod(method);
        }

        public void LoadUser(string json)
        {
            dynamic oJson = JsonConvert.DeserializeObject(json);

            token = oJson.token;
            sid = oJson.sid;
            Match m = Regex.Match(sid, @"^user([0-9]+)\.pony");
            id = m.Groups[1].Value;

           Console.WriteLine("Loaded sid (" + sid + "), token (" + token + "), id (" + id + ")");
        }

        public void SetUserData(int id, string token)
        {
            this.token = token;
            this.id = id.ToString();
        }

        public static dynamic LoadUser(string username, string password)
        {
            CookieAwareWebClient c = new CookieAwareWebClient();
            string res = "";
            //c.CookieContainer.SetCookies(new Uri("http://frenchy-ponies.fr"), "phpbb_ma_sid=c7aca50b997055971562307c4be3d745;domain=.frenchy-ponies.fr;path =/");

            try
            {
                byte[] log_res = c.UploadValues(cb_login, "POST", new NameValueCollection()
                {
                    { "username", username },
                    { "password", password },
                    { "redirect", "index.php" },
                    { "login", "Connexion" },
                    //{ "sid", "a6cce2c9a9448a93eab7002f5f459829" }
                });

                string s = Encoding.Default.GetString(log_res);
                //File.WriteAllText(@"D:\Test.html",s);

                res = c.DownloadString("http://frenchy-ponies.fr/ponybox/pb-include.php");
                Console.WriteLine(res);
            }
            catch(Exception e){
                Console.WriteLine("Exception for " + username + "/" + password);
                Console.WriteLine(e.Message);
            }

            return res;
        }

        public void Connect()
        {
            this.socket.Connect();
        }

        public void LoadChatbox(bool initListeners = true)
        {
            socket = IO.Socket(cb_address);

            socket.On(Socket.EVENT_CONNECT_ERROR, (oError) =>
            {
                Console.WriteLine("On : {0} {1}", "EVENT_CONNECT_ERROR", oError.ToString());
            });

            socket.On(Socket.EVENT_CONNECT_TIMEOUT, (oError) =>
            {
                Console.WriteLine("On : {0} {1}", "EVENT_CONNECT_TIMEOUT", oError.ToString());
            });

            socket.On(Socket.EVENT_ERROR, (oError) =>
            {
                Console.WriteLine("On : {0} : {1}", "EVENT_ERROR", oError.ToString());
            });

            socket.On(Socket.EVENT_CONNECT, () =>
            {
                Console.WriteLine("On : {0}", "CONNECT");
                Console.WriteLine("Connected");

                if(SocketConnectionStateChanged != null)
                {
                    EventHandler<SocketConnectionEvent> handler = SocketConnectionStateChanged;
                    handler(this, new SocketConnectionEvent(true));
                }

                Console.WriteLine("Emit : {0} {1} {2}", "create", int.Parse(id), token);
                socket.Emit("create", new AckImpl((oReturn) =>
                {
                    Console.WriteLine("Recieved ack from creation");
                    socket.Emit("login");
                    JoinChannel("general");

                    Console.WriteLine(oReturn);
                }), int.Parse(id), token);
            });

            socket.On(Socket.EVENT_DISCONNECT, () =>
            {
                Console.WriteLine("On : {0}", "DISCONNECT");
                if (SocketConnectionStateChanged != null)
                {
                    EventHandler<SocketConnectionEvent> handler = SocketConnectionStateChanged;
                    handler(this, new SocketConnectionEvent(false));
                }
                Console.WriteLine("Disconnected");
            });

            if (initListeners)
            {

                socket.On("login", () =>
                {
                    Console.WriteLine("On : {0}", "login");
                    Console.WriteLine("Logged in");
                });

                socket.On("already-logged", () =>
                {
                    Console.WriteLine("On : {0}", "already-logged");
                    Console.WriteLine("Already logged in");
                });

                socket.On("login-success", () =>
                {
                    Console.WriteLine("On : {0}", "login-success");
                    Console.WriteLine("Logged in successfully");
                });

                socket.On("join-channel", (oChannel) =>
                {
                    Console.WriteLine("On : {0}", "join-channel");

                    Channel c = new Channel(oChannel);
                    //this.channels.Add(c);

                    Console.WriteLine("Channel " + c.GetLabel() + " joined");

                    if (ChannelJoined != null)
                        {
                            EventHandler<ChannelJoinedEvent> handler = ChannelJoined;
                            handler(this, new ChannelJoinedEvent(c));
                        }


                    if (!messages.Keys.Contains(c.GetName())) { messages.Add(c.GetName(), new List<Message>()); }
                });

                socket.On("new-message", (oMessage) =>
                {
                    Console.WriteLine("On : {0}", "new-message");
                    Console.WriteLine("Message recieved");
                    Message m = new Message(oMessage);
                    AddMessage(m);

                    if (MessageRecieved != null)
                    {
                        EventHandler<Message> handler = MessageRecieved;
                        handler(this, m);
                    }


                    if (parentForm != null)
                    {
                        object[] p = new object[] { m.GetChannel() };
                        callbackMessageInsert.Invoke(parentForm, p);
                    }
                });

                socket.On("channel-messages", (data) =>
                {
                    Console.WriteLine("On : {0}", "channel-messages");
                    //Console.WriteLine("Messages :");
                    //Console.WriteLine(data);
                });

                socket.On("refresh-new-channels", (aChannels) =>
                {
                    Console.WriteLine("On : {0}", "refresh-new-channels");
                    LoadChannelList(aChannels);
                });

                var myIListenerImplUsers = new ChannelMessageAckListener((iChannel, aUsers) =>
                {
                    Console.WriteLine("Recieved " + ((dynamic)aUsers).Count + " users from " + (string)iChannel);
                    //System.IO.File.WriteAllText(@"D:\report.txt", aUsers.ToString());

                });

                socket.On("refresh-channel-users", myIListenerImplUsers);

                var myIListenerImpl = new ChannelMessageAckListener((iChannel, aMessages) =>
                {
                    Console.WriteLine("Recieved " + ((dynamic)aMessages).Count + " older messages from " + (string)iChannel );
                    LoadMessages(aMessages, (string)iChannel);
                });

                socket.On("get-older-message", myIListenerImpl);
            }
        }

        public void RefreshChannelList()
        {
            Console.WriteLine("Emit : {0}", "refresh-new-channels");
            socket.Emit("refresh-new-channels");
        }

        public void LoadChannelList(dynamic oJson)
        {
            Console.WriteLine("Refreshing Channels");
            if (oJson == null)
            {
                Console.WriteLine("No result when querying channels");
            }

            string[] categories = new string[3] { "Général", "+ 18", "Fan art" };

            for (int j=0;j<categories.Count();j++)
            {
                for (int i = 0; i < oJson[categories[j]].Count; i++)
                {
                    Channel c = new Channel(oJson[categories[j]][i]);
                    if (!channels.Contains(c))
                    {
                        channels.Add(c);
                    }
                }
            }

            if(ChannelListRefreshed != null)
            {
                EventHandler<ChannelListRefreshedEvent> handler = ChannelListRefreshed;
                handler(this, new ChannelListRefreshedEvent(channels));
            }

            if (parentForm != null)
            {
                callbackChannels.Invoke(parentForm, null);
            }
        }

        public void ListBans()
        {
            socket.Emit("get-bans", (aBans) =>
            {
                //Console.WriteLine(aBans);
            });
        }

        public void LoadMessages(dynamic oJson, string channel)
        {
            List<Message> aMessages = new List<Message>();

            for(int i=0;i<oJson.Count;i++)
            {
                Message m = new Message(oJson[i]);
                messages[channel].Add(m);
                aMessages.Add(m);
            }

            if(MessagesRecieved != null)
            {
                EventHandler<MessageListRecievedEvent> handler = MessagesRecieved;
                handler(this, new MessageListRecievedEvent(channel, aMessages));
            }

            if (parentForm != null)
            {
                object[] p = new object[] { channel };
                callbackMessageList.Invoke(parentForm, p);
            }
        }

        public void LockChannel(string name)
        {
            socket.Emit("lock-channel", name);
        }

        public void UnlockChannel(string name)
        {
            socket.Emit("unlock-channel", name);
        }

        public void JoinChannel(string name)
        {
            socket.Emit("join-new-channel", name);
        }

        public void LeaveChannel(string name)
        {
            socket.Emit("close-channel", name);
        }

        public void DebanUser(int id)
        {
            socket.Emit("deban-user", id);
        }

        public void SendMessage(string channel, string message, string to)
        {
            if(to == "")
            {
                to = null;
            }

            socket.Emit("send-message", new AckImpl((bValid, sError) =>
            {
                //Console.WriteLine(sError);
                //Console.WriteLine(bValid);
            }), channel, message, to, false);
        }

        public void AddMessage(Message m)
        {
            if (messages.ContainsKey(m.GetChannel()))
                messages[m.GetChannel()].Add(m);
        }

        public List<Message> GetMessages(string channel)
        {
            return this.messages[channel];
        }

        public List<Channel> GetChannelList()
        {
            return this.channels;
        }

        public Channel GetChannel(string name)
        {
            for(int i=0;i<channels.Count;i++)
                if(channels[i].GetName() == name) { return channels[i]; }
            return null;
        }

        public void Kick(int userID)
        {
            socket.Emit("kick-user", userID);
        }

        public void GetOlderMessages(string channelName, Message lastMessage)
        {
            GetOlderMessages(channelName, lastMessage.GetID());
        }

        public void GetOlderMessages(string channelName, long id)
        {
            socket.Emit("get-older-messages", channelName, id);
        }
    }
}
