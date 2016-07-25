using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseClient
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public User(int id, string name, string password)
        {
            this.Id = id;
            this.Name = name;
            this.Password = password;
        }
    }
}
