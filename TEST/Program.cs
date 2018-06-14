using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DB;
using DbType = DB.DbType;

namespace TEST
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dataTable;
            string[] sqlStrings = new string[2];
            //sqlStrings[0] = "SELECT * FROM customer";
            sqlStrings[0] = "INSERT INTO customer VALUES(NULL, 'lyg',30)";
            sqlStrings[1] = "INSERT INTO customer VALUES(NULL, 'cb1',31)";
            //sqlStrings[2] = "INSERT INTO customer VALUES(NULL, 'cb1',32)";
            //sqlStrings[0] = "UPDATE customer SET name = 'cbk', age = '33' WHERE id = 4";
            //sqlStrings[1] = "UPDATE customer SET name = 'cbkk', age = '333' WHERE id = 5";

            //sqlStrings[0] = "DELETE FROM customer  WHERE id = 4";
            //sqlStrings[1] = "DELETE FROM customer  WHERE id = 5";
            //Query query = new Query(@" Data Source = D:\test1.db", DbType.Sqlite);
            Query query = new Query(@" Data Source = D:\test.db", DbType.Sqlite);
            query.Execute(sqlStrings);
            dataTable = query.DataTable;

            //string str1 = "SELECT * FROM customer".Substring(0,6);

        }
    }
}
