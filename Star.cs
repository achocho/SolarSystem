using System;
using System.Collections.Generic;
using System.Text;

namespace SolarSystem
{
    internal class Star
    {
        string name;
        double mass;
        double area;
        int temp;
        string clas;
        double light;
        string GalaxyName;
       public Star(string name,string clas,double mass,double area,int temp,double light,string GalaxyName) 
        {
            this.name = name;
            this.mass = mass;
            this.area = area;
            this.temp = temp;
            this.light = light;
            this.clas = clas;
            this.GalaxyName = GalaxyName;
        }
        public string getClas() 
        {
            return clas;
        }
        public void setClas(string clas)
        {
            this.clas = clas;
        }
        public string getGalaxyName() 
        {
            return GalaxyName;
        }
        public void setGalaxyName(string GalaxyName)
        {
            this.GalaxyName = GalaxyName;
        }
        public String getName() 
        {
            return name;
        }
        public void setName(string name) 
        {
            this.name = name;
        }
        public double getMass() 
        {
            return mass;
        }
        public void setMass(double mass)
        {
            this.mass = mass;
        }
        public double getArea() 
        {
            return area;
        }
        public void setArea(double area) 
        {
            this.area = area;
        }
        public int getTemp() 
        {
            return temp;
        }
        public void setTemp(int temp) 
        {
            this.temp = temp;
        }
        public double getLight() 
        {
            return light;
        }
        public void setLight(double light)
        {
            this.light = light;
        }
    }
}
