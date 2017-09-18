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

        public int? FindUser(string accessToken)
        {
            User dbEntry = context.Users.Find(accessToken);
            if(dbEntry == null)
            {
                return null;
            }
            else
            {
                return dbEntry.UserID;
            }
        }

        public void AddUser(dynamic data)
        {
            string accessToken = data.access_token;
            string username = data.user.username;
            //szukamy w bazie po nazwie uzytkownika danego portalu w innych portalach wystarczy dodac LUB do LINQ ponizej
            User dbEntry = context.Users.FirstOrDefault(u => u.InstagramName == username);

            if (dbEntry != null)
            {
                dbEntry.InstagramToken = data.access_token;
            }
            else
            {
                User user = new User();
                user.InstagramName = data.user.username;
                user.InstagramToken = data.access_token;

                context.Users.Add(user);
            }

            context.SaveChanges();

        }

    }
}
