using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB
{
     public class Sqlite : Connection
    {

        //1.基础连接，FailIfMissing 参数 true=没有数据文件将异常;false=没有数据库文件则创建一个  
        //Data Source=test.db;Pooling=true;FailIfMissing=false  
        //2。使用utf-8 格式  
        //Data Source={0};Version=3;UTF8Encoding=True;  
        //3.禁用日志  
        //Data Source={0};Version=3;UTF8Encoding=True;Journal Mode=Off;  
        //4.连接池  
        //Data Source=c:\mydb.db;Version=3;Pooling=True;Max Pool Size=100;  
        public Sqlite()
        {
            Provide = ";FailIfMissing=true";
        }

        public Sqlite(string address) : base(address)
        {
            Provide = ";FailIfMissing=true";
        }

        public override void Open()
        {
            DbConnection = new SQLiteConnection(Address + Provide);
            try
            {
                DbConnection.Open();
            }
            catch (Exception e)
            {
                IsConnection = false;
            }
            
        }


        private void Init()
        {

        }

        public override DataTable SelectData(string command)
        {
            DataTable = new DataTable();
            DataSet = new DataSet();
            DbDataAdapter = new SQLiteDataAdapter();

            DbCommand = new SQLiteCommand
            {
                CommandText = command,
                CommandType = CommandType.Text

            };
            DbCommand.Connection = DbConnection;

            DbDataAdapter.SelectCommand = DbCommand;
            DbDataAdapter.SelectCommand.Connection = DbConnection;
            DbDataAdapter.Fill(DataSet);
            DataTable = DataSet.Tables[0];
            return DataTable;
        }

        public override DataTable SelectData(string[] command)
        {
            DataTable = new DataTable();
            DataSet = new DataSet();
            DbDataAdapter = new SQLiteDataAdapter();

            DbCommand = new SQLiteCommand
            {
                CommandText = command[0],
                CommandType = CommandType.Text

            };
            DbCommand.Connection = DbConnection;

            DbDataAdapter.SelectCommand = DbCommand;
            DbDataAdapter.SelectCommand.Connection = DbConnection;
            DbDataAdapter.Fill(DataSet);
            DataTable = DataSet.Tables[0];
            return DataTable;
        }

        public override void InsertData(string command)
        {
            DbTransaction trans = DbConnection.BeginTransaction();
            DbCommand = new SQLiteCommand(){CommandText = command, CommandType = CommandType.Text};
            DbCommand.Connection = DbConnection;
            DbCommand.ExecuteNonQuery();
            trans.Commit();//提交事务  

        }

        public override void InsertData(string[] command)
        {
            DbTransaction trans = DbConnection.BeginTransaction();
            DbCommand = new SQLiteCommand();
            DbCommand.Connection = DbConnection;
            for (int i = 0; i < command.Length; i++)
            {
                DbCommand.CommandText = command[i];
                DbCommand.ExecuteNonQuery();
            }
            trans.Commit();//提交事务  
        }

        public override void ExeCuteCommand(string[] command)
        {
            StringBuilder stringBuilder = new StringBuilder("以下数据已存在\n");
            DbTransaction trans = DbConnection.BeginTransaction();
            DbCommand = new SQLiteCommand();
            DbCommand.Connection = DbConnection;
            for (int i = 0; i < command.Length; i++)
            {
                DbCommand.CommandText = command[i];
                try
                {
                    DbCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    stringBuilder.Append("第" + (i + 1) + "行" + "\n"); 
                }
                
            }
            trans.Commit();//提交事务  
            if (stringBuilder.Length > 8)
            {
                MessageBox.Show(stringBuilder.ToString());
            }

            
        }

        public override void InsertData(string[,] command)
        {
            throw new NotImplementedException();
        }

        public override void UpdateData(string command)
        {
            throw new NotImplementedException();
        }

        public override void UpdateData(string[] command)
        {
            throw new NotImplementedException();
        }

        public override void UpdateData(string[,] command)
        {
            throw new NotImplementedException();
        }

        public override void DeleteData(string command)
        {
            throw new NotImplementedException();
        }

        public override void DeleteData(string[] command)
        {
            throw new NotImplementedException();
        }

        public override void DeleteData(string[,] command)
        {
            throw new NotImplementedException();
        }
    }
}
