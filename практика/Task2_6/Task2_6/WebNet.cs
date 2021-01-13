using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_6
{
    class WebNet
    {
        private LinkedList<User> users;

        public WebNet()
        {
            users = new LinkedList<User>();
        }
        public LinkedList<User> Users
        {
            get => users;
           
        }

        public void Add(User newUser)
        {
            users.AddLast(newUser);
        }

        public void Delete(User user)
        {
            users.Remove(user);
        }

    }
}
