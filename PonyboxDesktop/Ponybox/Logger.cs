using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.Common;

namespace PonyboxDesktop.Ponybox
{
    class Logger
    {
        DataTable dtMessages;
        DataTable dtUsers;

        DbDataAdapter adapterMessages;
        DbDataAdapter adapterUsers;

        public Logger(DbDataAdapter adapterMessages, DbDataAdapter adapterUsers)
        {
            dtMessages = new DataTable();
            dtUsers = new DataTable();

            adapterMessages.Fill(dtMessages);
            adapterUsers.Fill(dtUsers);

            this.adapterMessages = adapterMessages;
            this.adapterUsers = adapterUsers;
        }

        public void LogUser(User u)
        {
            if (!ContainsUser(u))
            {
                dtUsers.Rows.Add(UserToDataRow(u));
                this.adapterUsers.Update(dtUsers);
            }
        }

        public void LogMessages(List<Message> m)
        {
            for(int i=0;i<m.Count;i++)
            {
                if (!ContainsMessage(m[i]))
                {
                    dtMessages.Rows.Add(MessageToDataRow(m[i]));
                    LogUser(m[i].GetSender());

                    if (m[i].GetRecipient() != null)
                        LogUser(m[i].GetRecipient());
                }
            }
            this.adapterMessages.Update(dtMessages);
        }

        public void LogMessage(Message m)
        {
            if (!ContainsMessage(m))
            {
                dtMessages.Rows.Add(MessageToDataRow(m));
                LogUser(m.GetSender());

                if (m.GetRecipient() != null)
                    LogUser(m.GetRecipient());

                this.adapterMessages.Update(dtMessages);
            }
        }

        public bool ContainsUser(User u)
        {
            DataRow[] res = dtUsers.Select("id = " + u.GetUid());

            return (res.Count() > 0);
        }

        public bool ContainsMessage(Message m)
        {
            DataRow[] res = dtMessages.Select("sender = " + m.GetSender().GetUid() + " AND heure = " + (m.GetTimestamp() / 1000));

            return (res.Count() > 0);
        }

        public DataRow UserToDataRow(User u)
        {
            DataRow dr = dtUsers.NewRow();
            dr["id"] = u.GetUid();
            dr["username"] = u.GetUsername();

            return dr;
        }

        public DataRow MessageToDataRow(Message m)
        {
            DataRow dr = dtMessages.NewRow();
            dr["cbid"] = m.GetID();
            dr["sender"] = m.GetSender().GetUid();
            dr["message"] = m.GetMessage();
            dr["private"] = m.IsPrivate();
            dr["heure"] = (m.GetTimestamp() / 1000);
            dr["channel"] = m.GetChannel();

            if (m.GetRecipient() != null)
                dr["recipient"] = m.GetRecipient().GetUid();

            return dr;
        }
    }
}
