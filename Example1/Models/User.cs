using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Example1.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

    }

    public class ListUser
    {
        public List<User> ListOfUser { get; set; }

    }
}