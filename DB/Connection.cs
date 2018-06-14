using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data.SQLite;
namespace DB
{
    public abstract class Connection
    {
        private DbConnection _dbConnection;
        private DbCommand _dbCommand;
        private string _address;
        private string _provide;

        private DataTable _dataTable;
        private DataSet _dataSet;
        private DbDataAdapter _dbDataAdapter;

        private bool _isConnection = true;
        private DbType _dbType;
        #region 属性赋值

        /// <summary>
        /// 数据库连接
        /// </summary>
        public DbConnection DbConnection { get => _dbConnection; set => _dbConnection = value; }

        /// <summary>
        /// 数据库命令
        /// </summary>
        public DbCommand DbCommand { get => _dbCommand; set => _dbCommand = value; }

        /// <summary>
        /// 适配器
        /// </summary>
        public DbDataAdapter DbDataAdapter { get => _dbDataAdapter; set => _dbDataAdapter = value; }

        /// <summary>
        /// 连接地址 IP地址 域名 文件路径
        /// </summary>
        public string Address { get => _address; set => _address = value; }

        /// <summary>
        /// 驱动
        /// </summary>
        public string Provide { get => _provide; set => _provide = value; }

        /// <summary>
        /// DataTable
        /// </summary>
        public DataTable DataTable { get => _dataTable; set => _dataTable = value; }

        /// <summary>
        /// DataSet
        /// </summary>
        public DataSet DataSet { get => _dataSet; set => _dataSet = value; }
        /// <summary>
        /// 枚举
        /// </summary>
        public DbType DbType { get => _dbType; set => _dbType = value; }

        /// <summary>
        /// 是已否连接
        /// </summary>
        public bool IsConnection { get => _isConnection; set => _isConnection = value; }

        #endregion

        #region 构造函数

        public Connection()
        {

        }

        /// <summary>
        /// 构造函数初始化
        /// </summary>
        /// <param name="address">连接地址 IP地址 域名 文件路径</param>
        public Connection(string address)
        {
            Address = address;
        }

        #endregion

        #region 数据库连接方法

        /// <summary>
        /// 连接数据库 无返回
        /// </summary>
        public abstract void Open();

        /// <summary>
        /// 查询一条语句 
        /// </summary>
        /// <param name="command">命令语句</param>
        /// <returns>返回DataTable</returns>
        public abstract DataTable SelectData(string command);

        /// <summary>
        /// 查询多条语句
        /// </summary>
        /// <param name="command">一维数组命令语句</param>
        /// <returns>返回DataTable</returns>
        public abstract DataTable SelectData(string[] command);

        /// <summary>
        /// 插入一条数据 无返回
        /// </summary>
        /// <param name="command">命令语句</param>
        public abstract void InsertData(string command);

        /// <summary>
        /// 插入数据 无返回
        /// </summary>
        /// <param name="command">一维数组 命令语句</param>
        public abstract void InsertData(string[] command);

        /// <summary>
        /// 插入数据 无返回
        /// </summary>
        /// <param name="command">二维数组 命令语句</param>
        public abstract void InsertData(string[,] command);

        /// <summary>
        /// 修改数据 无返回
        /// </summary>
        /// <param name="command">一条命令语句</param>
        public abstract void UpdateData(string command);

        /// <summary>
        /// 修改数据 无返回
        /// </summary>
        /// <param name="command">一维数组 命令语句</param>
        public abstract void UpdateData(string[] command);

        /// <summary>
        /// 修改数据 无返回
        /// </summary>
        /// <param name="command">二维数组 命令语句</param>
        public abstract void UpdateData(string[,] command);

        /// <summary>
        /// 删除数据 无返回
        /// </summary>
        /// <param name="command">一条命令语句</param>
        public abstract void DeleteData(string command);

        /// <summary>
        /// 删除数据 无返回
        /// </summary>
        /// <param name="command">一维数组 命令语句</param>
        public abstract void DeleteData(string[] command);

        /// <summary>
        /// 删除数据 无返回
        /// </summary>
        /// <param name="command">二维数组 命令语句</param>
        public abstract void DeleteData(string[,] command);


        /// <summary>
        /// 插入修改删除
        /// </summary>
        /// <param name="command">一维数组命令语句</param>
        public abstract void ExeCuteCommand(string[] command);

        #endregion


    }
}
