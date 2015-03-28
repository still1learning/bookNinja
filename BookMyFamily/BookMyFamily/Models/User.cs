using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookMyFamily.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Born { get; set; }
        public string Location { get; set; }
        public List<User> Parents { get; set; }
        public List<User> Children { get; set; }

        public User(string Name, string Surname, DateTime Born, string Location)
        {
            this.Name = Name;
            this.Surname = Surname;
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