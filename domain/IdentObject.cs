using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp.domain
{
    public class IdentObject
    {
        private long id=0;

        public long Id { get; set; }

        public IdentObject(long id)
        {
            this.id = id;
        }

        public IdentObject()
        {
        }
    }
}
