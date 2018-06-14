using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DB
{
    public class Query
    {
        private Connection Connection { get; set; }
        
        private DataTable _dataTable;

        #region 属性

        /// <summary>
        /// DataTable 返回从数据库获取到的数据
        /// </summary>
        public DataTable DataTable { get => _dataTable; set => _dataTable = value; }

        #endregion

        #region 构造函数

        public Query(string address, DbType dbType)
        {
            JudgeDbType(dbType);
            this.Connection.Address = address;
            this.Connection.Open();
        }

        #endregion


        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="command">命令语句</param>
        public void Execute(string[] command)
        {
            //取前6位字符 用于判断对数据库增删改查
            string str1 = command[0].Substring(0,6).ToUpper();

            if (str1 == "SELECT")
            {
                DataTable = this.Connection.SelectData(command);
            }
            else if (str1 == "INSERT" || str1 == "UPDATE" || str1 == "DELETE")
            {
                this.Connection.ExeCuteCommand(command);
            }
            else
            {
                MessageBox.Show("命令语句错误！\n语句前6个字符 必须是 SELECT或者UPDATE或者INSERT或者DELETE");
            }   
        }  

        /// <summary>
        /// 判断数据库的类型 来进行多态
        /// </summary>
        /// <param name="dbType">枚举数据库</param>
        private void JudgeDbType(DbType dbType)
        {
            switch (dbType)
            {
                case DbType.Sqlite:
                    Sqlite sqlite = new Sqlite();
                    this.Connection = sqlite;
                    break;
                default:
                    MessageBox.Show("数据库类型不存在！");
                    break;
            }
        }

        
    }
}
