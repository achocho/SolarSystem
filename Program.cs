using System;
using System.Collections;
namespace SolarSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Command();

        }
        static void Command()
        {
            string command;
            ArrayList galaxies = new ArrayList();
            ArrayList stars = new ArrayList();
            ArrayList planets = new ArrayList();
            ArrayList moons = new ArrayList();
            ArrayList comms = new ArrayList();
            while (true)
            {
                command = Console.ReadLine();
                if (command.Equals("exit"))
                {
                    Print(galaxies,stars,planets,moons,comms);
                    break;
                }
                comms.Add(command);
            }
        }
        static void Print(ArrayList galaxies,ArrayList stars,ArrayList planets,ArrayList moons,ArrayList comms) 
        {
            foreach (string command in comms) {
                string commandType = "";
                if (command.IndexOf('[') > 0)
                {
                    commandType = command.Substring(0, command.IndexOf('['));
                }
                if (commandType.Equals("add galaxy"))
                {
                    string galaxyName = getGalaxyName(command);
                    string type = getGalaxyType(command);
                    string age = getGalaxyAge(command);

                    galaxies.Add(new Galaxy(galaxyName, type, age));


                }
                if (commandType.Equals("add star"))
                {
                    string name = getStarName(command);
                    string GalaxyName = getStarGalaxyName(command);
                    double mass = getStarMass(command);
                    double area = getStarArea(command);
                    int temp = getStarTemp(command);
                    double light = getStarLight(command);
                    string clas = getStarClas(mass, area, temp, light);
                    stars.Add(new Star(name, clas, mass, area, temp, light, GalaxyName));

                }
                if (commandType.Equals("add planet"))
                {
                    string name = getPlanetName(command);
                    string starName = getPlanetStarName(command);
                    string type = getPlanetType(command);
                    string live = getPlanetLive(command);
                    planets.Add(new Planet(name, type, live, starName));
                }
                if (commandType.Equals("add moon"))
                {
                    string name = getMoonName(command);
                    string planetName = getMoonPlanetName(command);

                    moons.Add(new Moon(name, planetName));

                }
                if (command.Equals("list galaxies"))
                {
                    Console.WriteLine("----------List galaxies-----------");
                    foreach (Galaxy g in galaxies)
                    {
                        Console.WriteLine(g.getName());
                    }
                    Console.WriteLine("----------End of list--------------");
                }
                if (command.Equals("list stars"))
                {
                    Console.WriteLine("----------List stars-----------");
                    foreach (Star s in stars)
                    {
                        Console.WriteLine(s.getName());
                    }
                    Console.WriteLine("----------End of list----------");
                }
                if (command.Equals("list planets"))
                {
                    Console.WriteLine("----------List planets-----------");
                    foreach (Planet p in planets)
                    {
                        Console.WriteLine(p.getName());
                    }
                    Console.WriteLine("----------End of list------------");
                }
                if (command.Equals("list moons"))
                {
                    Console.WriteLine("----------List moons-----------");
                    foreach (Moon m in moons)
                    {
                        Console.WriteLine(m.getName());
                    }
                    Console.WriteLine("----------End of list-----------");
                }
                if (command.Equals("stats"))
                {
                    Console.WriteLine("-------------Printing stats------------");
                    Console.WriteLine("Galaxies: " + galaxies.Count);
                    Console.WriteLine("Stars: " + stars.Count);
                    Console.WriteLine("Planets: " + planets.Count);
                    Console.WriteLine("Moons: " + moons.Count);
                    Console.WriteLine("-------------End Printing stats------");
                }
                if (commandType.Equals("print"))
                {
                    string galaxyName = getPrintGalaxyName(command);
                    foreach (Galaxy g in galaxies)
                    {
                        if (g.getName().Equals(galaxyName))
                        {
                            Console.WriteLine("Galaxy name: " + g.getName());
                            Console.WriteLine("Galaxy type: " + g.getType());
                            Console.WriteLine("Galaxy age: " + g.getAge());
                            Console.WriteLine("Stars:");
                            foreach (Star s in stars)
                            {
                                if (s.getGalaxyName().Equals(galaxyName))
                                {
                                    Console.WriteLine("      Name: " + s.getName());
                                    Console.WriteLine("      Class:  " + s.getClas() + "[" + s.getMass() + "," + s.getArea() + "," + s.getTemp() + "," + s.getLight() + "]");
                                    Console.WriteLine("      Planets:");
                                    foreach (Planet p in planets)
                                    {
                                        if (p.getStarName().Equals(s.getName()))
                                        {
                                            Console.WriteLine("              Name: " + p.getName());
                                            Console.WriteLine("              Type: " + p.getType());
                                            Console.WriteLine("              SupportLife: " + p.getLive());
                                            Console.WriteLine("              Moons:");
                                            foreach (Moon m in moons)
                                            {
                                                if (m.getPlanetName().Equals(p.getName()))
                                                {
                                                    Console.WriteLine("                  Name: " + m.getName());
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }
        }
        static string getGalaxyName(string command)
        {
            string galaxyName = "";
            bool startAdd = false;
            for (int i = 0; i < command.Length; i++)
            {
                if (command[i] == ']')
                {
                    break;
                }
                if (startAdd)
                {
                    galaxyName += command[i];
                }
                if (command[i] == '[')
                {
                    startAdd = true;
                }

            }
            return galaxyName;
        }
        static string getGalaxyType(string command)
        {
            int spaceCount = 0;
            string type = "";
            bool startAdd = false;
            int countB = 0;
            for (int i = 0; i < command.Length; i++)
            {
                if (startAdd)
                {
                    type += command[i];
                }
                if (command[i]==']') 
                {
                    countB++;
                }
                if (command[i] == ' '&&countB==1)
                {
                    spaceCount++;

                }
                if (spaceCount == 1)
                {
                    startAdd = true;
                }
                else
                {
                    startAdd = false;
                }


            }
            return type;
        }
        static string getGalaxyAge(string command)
        {
            int spaceCount = 0;
            string age = "";
            bool startAdd = false;
            int CountB = 0;
            for (int i = 0; i < command.Length; i++)
            {
                if (startAdd)
                {
                    age += command[i];
                }
                if (command[i] == ']')
                {
                    CountB++;
                }
                if (command[i] == ' '&&CountB==1)
                {
                    spaceCount++;

                }
                if (spaceCount == 2 )
                {
                    startAdd = true;
                }
                else
                {
                    startAdd = false;
                }


            }
            return age;
        }

        static string getStarGalaxyName(string command)
        {
            string name = "";
            Boolean startAdd = false;
            for (int i = 0; i < command.Length; i++)
            {
                if (command[i] == ']')
                {
                    startAdd = false;
                    break;
                }
                if (startAdd)
                {
                    name += command[i];
                }
                if (command[i] == '[')
                {
                    startAdd = true;
                }

            }
            return name;
        }

       static string getStarClas(double mass,double area,int temp,double light) 
        {
            string clas = "";
            if (mass>=16&&area>=6.6&&temp>=30000&&light>=30000) 
            {
                clas = "O";
            }
            if (mass>=2.1&&mass<16&&area>=1.8&&area<6.6&&temp>=10000&&temp<30000&&light>=25&&light<30000) 
            {
                clas = "B";
            }
            if (mass >= 1.4 && mass < 2.1 && area >= 1.4 && area < 1.8 && temp >= 7500 && temp < 10000 && light >= 5 && light <25)
            {
                clas = "A";
            }
            if (mass >= 1.04 && mass < 1.4 && area >= 1.15 && area < 1.4 && temp >= 6000 && temp < 7500 && light >= 1.5 && light < 5)
            {
                clas = "F";
            }
            if (mass >= 0.8 && mass < 1.04 && area >= 0.96 && area < 1.15 && temp >= 5200 && temp < 6000 && light >= 0.6 && light < 1.5)
            {
                clas = "G";
            }
            if (mass >= 0.45 && mass < 0.8 && area >= 0.7 && area < 0.96 && temp >= 3700 && temp < 5200 && light >= 0.08 && light < 0.6)
            {
                clas = "K";
            }
            if (mass >= 0.08 && mass < 0.45 && area <= 0.7 && temp >= 2400 && temp < 3700 && light <=0.08)
            {
                clas = "M";
            }
            return clas;
        }
        static string getStarName(string command)
        {
            string name = "";
            bool startAdd = false;
            int count = 0;
            for (int i = 0; i < command.Length; i++)
            {
                if (command[i] == '[')
                {
                    count++;
                }
                if (command[i] == ']'&&count==2)
                {
                    startAdd = false;
                    break;
                }
                if (startAdd)
                {
                    name += command[i];
                }
                if (count == 2)
                {
                    startAdd = true;
                }
                else 
                {
                    startAdd = false;
                }

            }
            return name;
        }

        static double getStarMass(string command)
        {
            double mass = 0;
            string massS = "";
            Boolean startAdd = false;
            Boolean startCount = false;
            int countB = 0;
            int count = 0;
            for (int i = 0; i < command.Length; i++)
            {
                if (command[i] == ']')
                {
                    countB++;
                }
                if (command[i] == ' ' && startCount)
                {
                    count++;
                }
                if (startAdd)
                {
                    massS += command[i];
                }
                if (countB == 2)
                {
                    startCount = true;
                }
                if (count == 1)
                {
                    startAdd = true;
                }
                else
                {
                    startAdd = false;
                }

            }

            mass = Convert.ToDouble(massS);
            return mass;
        }

        static double getStarArea(string command)
        {
            double mass = 0;
            string massS = "";
            Boolean startAdd = false;
            Boolean startCount = false;
            int countB = 0;
            int count = 0;
            for (int i = 0; i < command.Length; i++)
            {
                if (command[i] == ']')
                {
                    countB++;
                }
                if (command[i] == ' ' && startCount)
                {
                    count++;
                }
                if (startAdd)
                {
                    massS += command[i];
                }
                if (countB == 2)
                {
                    startCount = true;
                }
                if (count == 2)
                {
                    startAdd = true;
                }
                else
                {
                    startAdd = false;
                }

            }

            mass = Convert.ToDouble(massS);
            return mass;
        }

        static int getStarTemp(string command)
        {
            int mass = 0;
            string massS = "";
            Boolean startAdd = false;
            Boolean startCount = false;
            int countB = 0;
            int count = 0;
            for (int i = 0; i < command.Length; i++)
            {
                if (command[i] == ']')
                {
                    countB++;
                }
                if (command[i] == ' ' && startCount)
                {
                    count++;
                }
                if (startAdd)
                {
                    massS += command[i];
                }
                if (countB == 2)
                {
                    startCount = true;
                }
                if (count == 3)
                {
                    startAdd = true;
                }
                else
                {
                    startAdd = false;
                }

            }

            mass = Convert.ToInt32(massS);
            return mass;
        }

        static double getStarLight(string command)
        {
            double mass = 0;
            string massS = "";
            Boolean startAdd = false;
            Boolean startCount = false;
            int countB = 0;
            int count = 0;
            for (int i = 0; i < command.Length; i++)
            {
                if (command[i] == ']')
                {
                    countB++;
                }
                if (command[i] == ' ' && startCount)
                {
                    count++;
                }
                if (startAdd)
                {
                    massS += command[i];
                }
                if (countB == 2)
                {
                    startCount = true;
                }
                if (count == 4)
                {
                    startAdd = true;
                }
                else
                {
                    startAdd = false;
                }

            }

            mass = Convert.ToDouble(massS);
            return mass;
        }

        static string getPlanetStarName(string command) 
        {
            string name = "";
            Boolean startAdd = false;
            for (int i = 0; i < command.Length; i++)
            {
                if (command[i] == ']')
                {
                    startAdd = false;
                    break;
                }
                if (startAdd)
                {
                    name += command[i];
                }
                if (command[i] == '[')
                {
                    startAdd = true;
                }

            }
            return name;

        }

        static string getPlanetName(string command) 
        {
            string name = "";
            bool startAdd = false;
            int count = 0;
            for (int i = 0; i < command.Length; i++)
            {
                if (command[i] == '[')
                {
                    count++;
                }
                if (command[i] == ']'&&count==2)
                {
                    startAdd = false;
                    break;
                }
                if (startAdd)
                {
                    name += command[i];
                }
                if (count == 2)
                {
                    startAdd = true;
                }

            }
            return name;
        }

        static string getPlanetType(string command) 
        {
            
            string massS = "";
            Boolean startAdd = false;
            Boolean startCount = false;
            int countB = 0;
            int count = 0;
            for (int i = 0; i < command.Length; i++)
            {
                if (command[i] == ']')
                {
                    countB++;
                }
                if (command[i] == ' ' && startCount)
                {
                    count++;
                }
                if (startAdd)
                {
                    massS += command[i];
                }
                if (countB == 2)
                {
                    startCount = true;
                }
                if (count == 1)
                {
                    startAdd = true;
                }
                else
                {
                    startAdd = false;
                }

            }

            
            return massS;
        }

        static string getPlanetLive(string command)
        {
            string massS = "";
            Boolean startAdd = false;
            Boolean startCount = false;
            int countB = 0;
            int count = 0;
            for (int i = 0; i < command.Length; i++)
            {
                if (command[i] == ']')
                {
                    countB++;
                }
                if (command[i] == ' ' && startCount)
                {
                    count++;
                }
                if (startAdd)
                {
                    massS += command[i];
                }
                if (countB == 2)
                {
                    startCount = true;
                }
                if (count == 2)
                {
                    startAdd = true;
                }
                else
                {
                    startAdd = false;
                }

            }


            return massS;
        }

        static string getMoonPlanetName(string command)
        {
            string name = "";
            Boolean startAdd = false;
           
            for (int i = 0; i < command.Length; i++)
            {
                if (command[i] == ']')
                {
                    startAdd = false;
                    break;
                }
                if (startAdd)
                {
                    name += command[i];
                }
                if (command[i] == '[')
                {
                    startAdd = true;
                }

            }
            return name;
        }

        static string getMoonName(string command) 
        {
            string name = "";
            bool startAdd = false;
            int count = 0;
            for (int i = 0; i < command.Length; i++)
            {
                if (command[i] == '[')
                {
                    count++;
                }
                if (command[i] == ']'&&count==2)
                {
                    startAdd = false;
                    break;
                }
                if (startAdd)
                {
                    name += command[i];
                }
                if (count == 2)
                {
                    startAdd = true;
                }

            }
            return name;
        }

        static string getPrintGalaxyName(string command) 
        {
            string name = "";
            Boolean startAdd = false;
            for (int i = 0; i < command.Length; i++)
            {
                if (command[i] == ']')
                {
                    startAdd = false;
                    break;
                }
                if (startAdd)
                {
                    name += command[i];
                }
                if (command[i] == '[')
                {
                    startAdd = true;
                }

            }
            return name;
        }
    }
}
