using System;
using System.Collections.Generic;
using System.Text;

namespace SolarSystem
{
    internal class Galaxy
    {
        string name;
        string type;
        string age;

       public Galaxy(string name, string type, string age)
        {
            this.name = name;
            this.type = type;
            this.age = age;
        }
        public string getName()
        {
            return name;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public string getType()
        {
            return type;
        }
        public void setType(string type) 
        {
            this.type = type;
        }
        public string getAge() 
        {
            return age;
        }
        public void setAge(string age) 
        {
            this.age = age;
        }

    }
}
