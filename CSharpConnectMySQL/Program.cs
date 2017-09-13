using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpConnectMySQL
{
    class Program
    {
        static void Main(string[] args)
        {
            // 服务器地址；端口号；数据库；用户名；密码
            string connectStr = "server=127.0.0.1;port=3306;database=mygamedb;user=root;password=2860527Z";
            // 创建连接
            MySqlConnection conn = new MySqlConnection(connectStr);

            try
            {
                // 打开连接
                conn.Open();
                Console.WriteLine("已经建立连接");

                //Query(conn);  // 测试查询
                //Insert(conn); // 测试插入
                //Update(conn); // 测试更新
                //Delete(conn); // 测试删除
                //Query(conn);
                Console.WriteLine(Verify(conn, "newName", "66777"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                // 关闭连接
                conn.Close();
                Console.WriteLine("数据库已关闭");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="conn"></param>
        private static void Query(MySqlConnection conn)
        {
            // 创建命令
            string sql = "select * from user";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            // 读取数据
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) // true表示能读取该行数据
            {
                // 方式一：访问数组
                Console.WriteLine(reader[0].ToString() + reader[1].ToString());
                // 方式二：根据列数
                Console.WriteLine(reader.GetInt32(0));
                // 方式三：根据列名
                Console.WriteLine(reader.GetInt32("user_id"));
            }
        }


        /// <summary>
        /// 插入，增加数据
        /// </summary>
        /// <param name="conn"></param>
        private static void Insert(MySqlConnection conn)
        {
            // 创建命令
            string sql = "insert into user(user_name, user_pwd) values('asdAa','2345')";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            // 添加一条记录
            int result = cmd.ExecuteNonQuery();
            Console.WriteLine("数据库中受影响的行数 = " + result);
        }


        /// <summary>
        /// 更新，改数据
        /// </summary>
        /// <param name="conn"></param>
        private static void Update(MySqlConnection conn)
        {
            // 创建命令
            string sql = "update user set user_name = 'newName', user_pwd = '66777' where user_id = '3'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            // 更新记录
            int result = cmd.ExecuteNonQuery();
            Console.WriteLine("数据库中受影响的行数 = " + result);
        }


        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="conn"></param>
        private static void Delete(MySqlConnection conn)
        {
            // 创建命令
            string sql = "delete from user where user_id = '4'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            // 删除记录
            int result = cmd.ExecuteNonQuery();
            Console.WriteLine("数据库中受影响的行数 = " + result);
        }


        /// <summary>
        /// 验证用户名和密码
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private static bool Verify(MySqlConnection conn, string userName, string password)
        {
            // 方式一：组拼sql
            //string sql = "select * from user where user_name = '" + userName + "' and user_pwd = '" + password + "'";
            //MySqlCommand cmd = new MySqlCommand(sql, conn);

            // 方式二：参数标记
            string sql = "select * from user where user_name = @p1 and user_pwd = @p2";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("p1", userName);
            cmd.Parameters.AddWithValue("p2", password);

            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read()) // 要么查出一条数据，要么0条。
            {
                return true;
            }

            return false;
        }
    }
}
