using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetuxeToZwaki
{
    public class DataManager
    {
        public DataManager() { }


        public User getUser(string name)
        {
            foreach (User USERS in Program.getUsers())
            {
                if (USERS.getName().Equals(name))
                {
                    return USERS;
                }
            }
            return null;
        }

        public List<User> getTop10Users()
        {
            List<User> userList = new List<User>();
            userList.Clear();

            // GOOGLE -> https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.orderby?view=net-7.0
            User[] users = Program.getUsers().ToArray();

            IEnumerable<User> query = users.OrderByDescending(User => User.getScore());

            return query.ToList().Take(10).ToList();
        }

    }
}
