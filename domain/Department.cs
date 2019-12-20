using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp.domain
{
    public class Department:IdentObject
    {
        public String Name { get; set; }

        public Department(long id, string name):base(id)
        {            
            Name = name;
        }

        public Department(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
