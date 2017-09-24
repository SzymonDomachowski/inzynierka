using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotificationBox.Domain.Abstract;
using NotificationBox.Domain.Entities;

namespace NotificationBox.Domain.Concrete
{
    public class EFUserRepository : IUserRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<User> Users
        {
            get { return context.Users; }
        }

        //public int? FindUser(string accessToken)
        //{
        //    User dbEntry = context.Users.Find(accessToken);
        //    if(dbEntry == null)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        return dbEntry.UserID;
        //    }
        //}

        public void AddUser(dynamic data, int Id)
        {
            User dbEntry = context.Users.Find(Id);

            if (dbEntry != null)
            {
                dbEntry.InstagramToken = data.access_token;
            }

            context.SaveChanges();
        }

        public void AddAccount(User user)
        {
            if (user.UserID == 0)
            {
                context.Users.Add(user);
            }

            context.SaveChanges();
        }

    }
}
