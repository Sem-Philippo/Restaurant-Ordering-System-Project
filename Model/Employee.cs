using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public int LastName { get; set; }
        public Role Role { get; set; }
        public int Pin { get; set; }

        public Employee (int id, string firstName, int lastName, Role role, int pin)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Role = role;
            Pin = pin;
        }
    }
}
