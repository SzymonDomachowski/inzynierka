using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotificationBox.Domain.Entities;

namespace NotificationBox.Domain.Abstract
{
    public interface IUserRepository
    {
        IEnumerable<User> Users { get; }

        void AddUser(dynamic data);
        int? FindUser(string accessToken);
    }
}
