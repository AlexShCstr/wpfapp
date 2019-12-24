using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WpfApp.domain
{
    public class Department:IdentObject, INotifyPropertyChanged
    {
        private string name;

        public String Name
        {
            get { return this.name; }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.NotifyPropertyChanged("Name");
                }
            }
        }

        public Department(long id, string name):base(id)
        {            
            Name = name;
        }

        public Department(string name)
        {
            Name = name;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
