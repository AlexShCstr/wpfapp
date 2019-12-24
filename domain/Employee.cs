using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WpfApp.domain
{
    public class Employee : IdentObject,INotifyPropertyChanged
    {
        private string firstname;
        private string lastname;
        private string middlename;
        private Department depart;

        public String Firstname
        {
            get { return this.firstname; }
            set
            {
                if (this.firstname != value)
                {
                    this.firstname = value;
                    this.NotifyPropertyChanged("Firstname");
                }
            }
        }
        public String Lastname
        {
            get { return this.lastname; }
            set
            {
                if (this.lastname != value)
                {
                    this.lastname = value;
                    this.NotifyPropertyChanged("Lastname");
                }
            }
        }
        public String Middlename
        {
            get { return this.middlename; }
            set
            {
                if (this.middlename != value)
                {
                    this.middlename = value;
                    this.NotifyPropertyChanged("Middlename");
                }
            }
        }
        public Department department
        {
            get { return this.depart; }
            set
            {
                if (this.depart != value)
                {
                    this.depart = value;
                    this.NotifyPropertyChanged("department");
                }
            }
        }
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

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }


        public override string ToString()
        {
            return Name + " - " + department;
        }
    }
}
