using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonyboxDesktop.Forum
{
    class AccountDatabase
    {
        DataTable dtAccounts;
        DbDataAdapter adapterAccouts;

        public AccountDatabase(DbDataAdapter adapterAccouts)
        {
            dtAccounts = new DataTable();
            adapterAccouts.Fill(dtAccounts);
            this.adapterAccouts = adapterAccouts;
        }

        public DataRow UserToDataRow(ForumUser u)
        {
            DataRow dr = dtAccounts.NewRow();
            dr["ID"] = u.Id;
            dr["Rank"] = u.Rank;
            dr["Color"] = u.Color;
            dr["Username"] = u.Name;
            dr["Website"] = u.Website;
            dr["Location"] = u.Location;
            dr["Register"] = u.RegisterDate;
            dr["LastLogin"] = u.LoginDate;
            dr["Messages"] = u.Messages;

            return dr;
        }

        public bool ContainsUser(ForumUser u)
        {
            DataRow[] res = dtAccounts.Select("id = " + u.Id);

            return (res.Count() > 0);
        }

        public void LogUser(ForumUser u)
        {
            if (!ContainsUser(u))
            {
                dtAccounts.Rows.Add(UserToDataRow(u));
            }
            this.adapterAccouts.Update(dtAccounts);
        }

        public void LogUsers(List<ForumUser> u)
        {
            for (int i = 0; i < u.Count; i++)
            {
                if (!ContainsUser(u[i]))
                {
                    dtAccounts.Rows.Add(UserToDataRow(u[i]));
                }
            }
            this.adapterAccouts.Update(dtAccounts);
        }
    }
}
