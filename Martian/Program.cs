using System;

namespace Martian
{
    internal class Program
    {
        public const int tamanio = 50;
        public static string command = "";
        public static bool robotCaido = false;
        public static string posicionRobot = "";
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese x para finalizar.");
            Console.WriteLine();
            InitializeRobot();
            while (!command.Contains("x"))
            {
                command = Console.ReadLine();
                while (!robotCaido && !command.Contains("x"))
                {
                    Console.WriteLine();
                    ExecuteCommand(command.ToUpper());
                    if (robotCaido)
                        break;
                    command = Console.ReadLine();
                    //DrawMars();
                }
                Console.WriteLine("El robot se salio del terreno.");
                Console.WriteLine();
                Console.WriteLine("Ingrese instrucciones para nuevo robot.");
                Console.WriteLine();
                InitializeRobot();
                robotCaido = false;
            }
        }

        public static void InitializeRobot()
        {
            posicionRobot = "0 0 N";
            Console.WriteLine(posicionRobot);
            Console.WriteLine();
        }

        public static void ExecuteCommand(string command)
        {
            foreach (string s in command.Split(" "))
            {
                string posicion = "";
                switch (s)
                {
                    case "N":
                    case "S":
                    case "E":
                    case "W":
                        posicionRobot = posicionRobot.Split(" ")[0] + " " + posicionRobot.Split(" ")[1] + " " + s;
                        break;
                    case "L":
                        posicion = posicionRobot.Split(" ")[2];
                        switch(posicion)
                        {
                            case "N":
                                posicionRobot = posicionRobot.Split(" ")[0] + " " + posicionRobot.Split(" ")[1] + " W";
                                break;
                            case "S":
                                posicionRobot = posicionRobot.Split(" ")[0] + " " + posicionRobot.Split(" ")[1] + " E";
                                break;
                            case "E":
                                posicionRobot = posicionRobot.Split(" ")[0] + " " + posicionRobot.Split(" ")[1] + " N";
                                break;
                            case "W":
                                posicionRobot = posicionRobot.Split(" ")[0] + " " + posicionRobot.Split(" ")[1] + " S";
                                break;
                            default:
                                break;
                        }
                        break;
                    case "R":
                        posicion = posicionRobot.Split(" ")[2];
                        switch (posicion)
                        {
                            case "N":
                                posicionRobot = posicionRobot.Split(" ")[0] + " " + posicionRobot.Split(" ")[1] + " E";
                                break;
                            case "S":
                                posicionRobot = posicionRobot.Split(" ")[0] + " " + posicionRobot.Split(" ")[1] + " W";
                                break;
                            case "E":
                                posicionRobot = posicionRobot.Split(" ")[0] + " " + posicionRobot.Split(" ")[1] + " S";
                                break;
                            case "W":
                                posicionRobot = posicionRobot.Split(" ")[0] + " " + posicionRobot.Split(" ")[1] + " N";
                                break;
                            default:
                                break;
                        }
                        break;
                    case "F":
                        posicion = posicionRobot.Split(" ")[2];
                        var y = Convert.ToInt32(posicionRobot.Split(" ")[1]);
                        var x = Convert.ToInt32(posicionRobot.Split(" ")[0]);
                        switch (posicion)
                        {
                            case "N":
                                y++;
                                if (y > tamanio)
                                    robotCaido = true;
                                break;
                            case "S":
                                y--;
                                if (y < 0)
                                    robotCaido = true;
                                break;
                            case "E":
                                x--;
                                if (x < 0)
                                    robotCaido = true;
                                break;
                            case "W":
                                x++;
                                if (x > tamanio)
                                    robotCaido = true;
                                break;
                            default:
                                break;
                        }
                        posicionRobot = x + " " + y + " " + posicion;
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(posicionRobot);
            Console.WriteLine();
        }


    }
}
