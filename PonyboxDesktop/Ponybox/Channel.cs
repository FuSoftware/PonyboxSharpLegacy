using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonyboxDesktop.Ponybox
{
    public class Channel
    {
        dynamic oJson;

        string name;
        string label;
        bool locked;
        string description;

        public Channel(string input)
        {
            loadMessage(JsonConvert.DeserializeObject(input));
        }

        public Channel(dynamic oJson)
        {
            loadMessage(oJson);
        }

        public void loadMessage(dynamic oJson)
        {
            this.oJson = oJson;

            name = oJson.name;
            label = oJson.label;
            locked = oJson.locked;
            description = oJson.description;
        }

        public string GetName()
        {
            return this.name;
        }

        public string GetLabel()
        {
            return this.label;
        }
    }
}
