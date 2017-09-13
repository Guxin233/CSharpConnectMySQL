using System.Collections.Generic;
using NHibernateConnectMySQL.Model;
using NHibernate;
using NHibernate.Criterion;

namespace NHibernateConnectMySQL.Manager
{
    class UserManager : IUserManager
    {
        // 插入一条纪录
        public void Add(User user)
        {
            using (ISession session = NHibernateHelper.SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(user);
                    transaction.Commit();
                }
            }
        }

        // 删除一条纪录
        public void Delete(User user)
        {
            using (ISession session = NHibernateHelper.SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(user);
                    transaction.Commit();
                }
            }
        }

        // 更新一条纪录
        public void Update(User user)
        {
            using (ISession session = NHibernateHelper.SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(user);
                    transaction.Commit();
                }
            }
        }

        // 查询一条纪录
        public User GetUserByID(int id)
        {
            using (ISession session = NHibernateHelper.SessionFactory.OpenSession())
            {
                // 查询不会对数据进行操作，可以不用事务
                User user = session.Get<User>(id);
                return user;
            }
        }
        
        // 查询一条纪录
        public User GetUserByUserName(string userName)
        {
            using (ISession session = NHibernateHelper.SessionFactory.OpenSession())
            {
                //ICriteria criteria = session.CreateCriteria(typeof(User));
                // 添加查询条件为传入的参数等于实体类中的属性
                //criteria.Add(Restrictions.Eq("UserName", userName));
                //User user = criteria.UniqueResult<User>();

                User user = session
                    .CreateCriteria(typeof(User))
                    .Add(Restrictions.Eq("UserName", userName))
                    .UniqueResult<User>();
                return user;
            }
        }

        // 查询多条纪录
        public ICollection<User> GetAllUsers()
        {
            using (ISession session = NHibernateHelper.SessionFactory.OpenSession())
            {
                IList<User> list = session.CreateCriteria(typeof(User)).List<User>();
                return list;
            }
        }

        // 校验登录
        public bool VerifyUser(string userName, string password)
        {
            using (ISession session = NHibernateHelper.SessionFactory.OpenSession())
            {
                User user = session
                    .CreateCriteria(typeof(User))
                    .Add(Restrictions.Eq("UserName", userName))
                    .Add(Restrictions.Eq("UserPwd", password))
                    .UniqueResult<User>();

                if (user == null)
                    return false;
                else
                    return true; 
            }
        }

    }
}
