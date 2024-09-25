using System.Data;
using System.Data.SqlClient;

namespace WinFormsPrinterClass
{/// <summary>
 /// 打开数据库连接，返回DataSet及执行Sql语句
 /// </summary>
    internal class DataClass
    {
        //private static SqlConnection _conn; //静态变量全局引用
        public static string connStr = "server = 10.8.100.241; database= FAMS; uid=sa; pwd=sa@1234;";
        #region 创建连接数据库对象
        public static SqlConnection createCon()
        {
            string connStr = "server = 10.8.100.241; database= FAMS; uid=sa; pwd=sa@1234;";
            SqlConnection conn = new SqlConnection(connStr); //实例化连接对象
            return conn;
        }
        #endregion

        #region 打开数据库连接方法
        /// <summary>
        /// 打开数据库连接
        /// </summary>
        public static Boolean Open()
        {
            string connStr;
            connStr = "server = 10.8.100.241; database= FAMS; uid=sa; pwd=sa@1234;";
            using (SqlConnection _conn = new SqlConnection(connStr))
            {
                try
                {
                    _conn.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("点检数据库连接不上！"+ex);
                    _conn.Close();
                    return false; //没有打开
                }
            }

            return true; //打开成功
        }
        #endregion

        #region 执行SQL查找语句并返回数据集
        /// <summary>
        /// 查找并返回数据集
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="table">表名</param>
        /// <returns></returns>
        public static DataSet getDataSet(string sql, string table) //返回Dataset,参数按值传递
        {

            using (SqlConnection _conn = new SqlConnection(connStr)) //使用完后释放连接对象
            {
                Boolean status = Open();
                DataSet ds = new DataSet();
                if (!status) //如果打开状态
                {
#pragma warning disable CS8603 // 可能返回 null 引用。
                    return null; //返回空
#pragma warning restore CS8603 // 可能返回 null 引用。
                }
                SqlDataAdapter da = new SqlDataAdapter(sql, _conn); //数据适配器，配合ds使用
                da.Fill(ds, table);
                return ds;
            }
        }
        #endregion //c#分块预处理器指令

        #region 执行SQL语句，返回真假
        /// <summary>
        /// 增、删、改
        /// </summary>
        /// <param name="sqlcmd">SQL语句</param>
        /// <returns></returns>
        public static bool execSQL(string sqlcmd)
        {
            using (SqlConnection _conn = new SqlConnection(connStr)) //使用完后释放连接对象
            {
                _conn.Open();//打开连接
                SqlCommand cmd = new SqlCommand(sqlcmd, _conn);
                try
                {
                    cmd.ExecuteNonQuery();  //执行SQL语句
                    _conn.Close();
                    _conn.Dispose();
                }
                catch (Exception ex)
                {
                    _conn.Close();
                    _conn.Dispose();
                    MessageBox.Show("执行操作失败" + ex.Message);
                    return false; //执行失败
                }
            }
            return true; //执行成功
        }
    }
}
#endregion