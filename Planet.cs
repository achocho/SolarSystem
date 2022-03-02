using System;
using System.Collections.Generic;
using System.Text;

namespace SolarSystem
{
    internal class Planet
    {
        string name;
        string type;
        string live;
        string StarName;
      public  Planet(string name,string type,string live,string StarName) 
        {
            this.name = name;
            this.type = type;
            this.live = live;
            this.StarName = StarName;
        }
        public string getStarName() 
        {
            return StarName;
        }
        public void setStarName(string StarName)
        {
            this.StarName = StarName;
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
        public string getLive() 
        {
            return live;
        }
        public void setLive(string live) 
        {
            this.live = live;
        }
    }
    
}
