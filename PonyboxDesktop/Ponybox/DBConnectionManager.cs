using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonyboxDesktop.Ponybox
{
    class DBConnectionManager
    {
        string type;
        string connection;

        public DBConnectionManager(string file, string type)
        {
            this.type = type;

            switch (this.type)
            {
                case "SQLite":
                    this.connection = "Data Source=" + file + ";Version=3";
                    break;
                case "OleDb":
                    this.connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + file + ";Persist Security Info = False;";
                    break;
            }
        }

        public SQLiteDataAdapter GetSQLiteAdapter(string SelectCommand)
        {
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(SelectCommand, this.connection);

            SQLiteCommandBuilder cb = new SQLiteCommandBuilder(adapter);
            adapter.InsertCommand = cb.GetInsertCommand();
            adapter.UpdateCommand = cb.GetUpdateCommand();
            adapter.DeleteCommand = cb.GetDeleteCommand();

            return adapter;
        }

        public OleDbDataAdapter GetOleAdapter(string SelectCommand)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter(SelectCommand, this.connection);

            OleDbCommandBuilder cb = new OleDbCommandBuilder(adapter);
            adapter.InsertCommand = cb.GetInsertCommand();
            adapter.UpdateCommand = cb.GetUpdateCommand();
            adapter.DeleteCommand = cb.GetDeleteCommand();

            return adapter;
        }

        public DbDataAdapter GetAdapter(string SelectCommand)
        {
            switch(this.type)
            {
                case "SQLite":
                    return GetSQLiteAdapter(SelectCommand);
                case "OleDb":
                    return GetOleAdapter(SelectCommand);
            }

            return null;
        }
    }
}
