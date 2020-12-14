using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvMDemo.Models
{
    class Employee
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private String name;

        public String  Name
        {
            get { return name; }
            set { name = value; }
        }

        private int age;

        public int  Age
        {
            get { return age; }
            set { age = value; }
        }

    }
}
