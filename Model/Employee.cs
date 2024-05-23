using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Enums;

namespace Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Role Role { get; set; }
        public string Pin { get; set; }

        public Employee (int id, string firstName, string lastName, Role role, string pin)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Role = role;
            Pin = pin;
        }
    }
}
