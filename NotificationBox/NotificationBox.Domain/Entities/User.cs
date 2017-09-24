using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationBox.Domain.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string FacebookToken { get; set; }
        public string InstagramToken { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        
        //musisz pododawac swoje 
    }
}
