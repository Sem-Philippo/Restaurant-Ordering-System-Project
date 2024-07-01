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
        public string Hash { get; set; }
        public string Salt { get; set; }

        public Employee(int id, string firstName, string lastName, Role role, string hash, string slat)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Role = role;
            Hash = hash;
            Salt = slat;
        }
        public Employee()
        {

        }
        public string DisplayName
        {
            get { return $"{Id} - {FirstName} {LastName}"; }
        }
    }
}