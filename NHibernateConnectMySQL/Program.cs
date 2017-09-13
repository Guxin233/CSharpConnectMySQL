using NHibernateConnectMySQL.Manager;
using System;

namespace NHibernateConnectMySQL
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            // ---- NHibernate初始化 ----
            var conf = new Configuration();
            // 解析hibernate.cfg.xml
            conf.Configure(); // 参数为文件，缺省值就是hibernate.cfg.xml
            // 解析表映射文件（User.hbm.xml等），表映射文件已被集成到程序集中（嵌入的资源）
            conf.AddAssembly("NHibernateConnectMySQL"); // 参数为文件所在的程序集，已在hibernate.cfg.xml中声明
            // ---- 完成初始化 ----

            // ---- 连接数据库 ----
            ISessionFactory sessionFactory = null;
            ISession session = null;
            ITransaction transaction = null;
            try
            {
                // 连接数据库的会话工厂
                sessionFactory = conf.BuildSessionFactory();
                // 打开一个跟数据库的会话
                session = sessionFactory.OpenSession();
                // 开启事务
                transaction = session.BeginTransaction();

                User user1 = new User() { UserName = "jjss2", UserPwd = "4606519" };
                User user2 = new User() { UserName = "jjag3", UserPwd = "46064519" };
                session.Save(user1);
                session.Save(user2);

                // 提交事务
                transaction.Commit();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                if (transaction != null)
                {
                    transaction.Dispose();
                }
                if (session != null)
                {
                    session.Close();
                }
                if (sessionFactory != null)
                {
                    sessionFactory.Close();
                }
            }
            */

            UserManager userManager = new UserManager();

            // 插入数据
            //User user = new User() { UserName = "3643uhyrjut", UserPwd = "123453143" };
            //UserManager userManager = new UserManager();
            //userManager.Add(user);

            // 查询单条纪录
            //User user = userManager.GetUserByUserName("agr43");
            //Console.WriteLine(user.UserPwd);

            // 查询多条纪录
            //ICollection<User> list = userManager.GetAllUsers();
            //foreach (User item in list)
            //{
            //    Console.WriteLine(item.UserPwd);
            //}

            // 验证登录
            //Console.WriteLine(userManager.VerifyUser("jjssag1", "4606519"));

            Console.ReadKey();
        }
    }
}
