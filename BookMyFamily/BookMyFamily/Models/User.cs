using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookMyFamily.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
            set
            {
                var tmp = value.Split(' ');
                FirstName = tmp[0];
                LastName = tmp[1];
            }
        }
        public DateTime Born { get; set; }
        public string Location { get; set; }
        public List<User> Parents { get; set; }
        public List<User> Children { get; set; }

        public User()
        {
            this.FirstName = "";
            this.LastName = "";
            this.Born = DateTime.Now;
            this.Location = "";
        }

        public User(string Name, string Surname, DateTime Born, string Location)
        {
            this.FirstName = Name;
            this.LastName = Surname;
            this.Born = Born;
            this.Location = Location;
        }

        public void AddParent(User parrent)
        {
            try
            {
                if (Parents.Count <= 2)
                {
                    Parents.Add(parrent);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Cant have more then 2 parents");
            }
            
        }

        public void AddChild(User child)
        {
            Children.Add(child);
        }
    }
}