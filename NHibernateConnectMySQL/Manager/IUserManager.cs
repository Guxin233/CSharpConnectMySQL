using NHibernateConnectMySQL.Model;
using System.Collections.Generic;

namespace NHibernateConnectMySQL.Manager
{
    interface IUserManager
    {
        void Add(User user);
        void Delete(User user);
        void Update(User user);
        User GetUserByID(int id);
        User GetUserByUserName(string userName);
        ICollection<User> GetAllUsers();
        bool VerifyUser(string userName, string password); // 校验登录
    }
}
