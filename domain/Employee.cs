using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp.domain
{
    public class Employee : IdentObject
    {

        public String Firstname { get; set; }
        public String Lastname { get; set; }
        public String Middlename { get; set; }
        public Department department { get; set; }
        public String Name => String.Concat(Lastname, " ", Firstname, " ", Middlename);

        public Employee(long id, string firstname, string lastname, string middlename) : base(id)
        {
            Firstname = firstname;
            Lastname = lastname;
            Middlename = middlename;
        }

        public Employee(string firstname, string lastname, string middlename)
        {
            Firstname = firstname;
            Lastname = lastname;
            Middlename = middlename;
            this.department = department;
        }

        public Employee()
        {
        }

        public override string ToString()
        {
            return Name + " - " + department;
        }
    }
}
