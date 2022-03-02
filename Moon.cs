using System;
using System.Collections.Generic;
using System.Text;

namespace SolarSystem
{
    internal class Moon 
    {
        string name;
        string PlanetName;
      public  Moon(string name,string PlanetName) 
        {
            this.name = name;
            this.PlanetName = PlanetName;
        }
        public string getPlanetName() 
        {
            return PlanetName;
        }
        public void setPlanetName(string PlanetName)
        {
            this.PlanetName = PlanetName;
        }
        public string getName() 
        {
            return name;
        }
        public void setName(string name)
        {
            this.name = name;
        }
    }
}
