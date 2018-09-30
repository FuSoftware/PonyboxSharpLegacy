using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace PonyboxDesktop.Ponybox
{
    public class Message
    {
        long id;
        string format;
        int type;
        bool isPrivate;
        User from;
        User to;
        string channel;
        long sendDate;
        Dictionary<string, bool> rights = new Dictionary<string, bool>();

        dynamic oJson;

        public Message(string input)
        {
            loadMessage(JsonConvert.DeserializeObject(input));
        }

        public Message(dynamic oJson)
        {
            loadMessage(oJson);
        }

        public void loadMessage(dynamic oJson)
        {
            this.oJson = oJson;
            id = oJson.id;
            format = oJson.format;
            type = oJson.type;
            sendDate = oJson.sendDate;
            //isPrivate = oJson.private;

            //from
            from = new User(oJson.from);

            //to
            if (oJson.to != null)
            {
                to = new User(oJson.to);
            }

            channel = oJson.channel;
            isPrivate = oJson["private"];
        }

        public string GetChannel()
        {
            return this.channel;
        }

        public long GetTimestamp()
        {
            return this.sendDate;
        }

        public string GetMessage()
        {
            return this.format;
        }

        public User GetSender()
        {
            return this.from;
        }

        public User GetRecipient()
        {
            return this.to;
        }

        public object GetJson()
        {
            return this.oJson;
        }

        public long GetID()
        {
            return this.id;
        }

        public Boolean IsPrivate()
        {
            return this.isPrivate;
        }
    }
}
