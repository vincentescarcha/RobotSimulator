using System;
using System.IO;

namespace RobotSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            RobotController controller = new RobotController(5, 5);
            if (args.Length == 0)
            {
                while(true)
                {
                    var command = Console.ReadLine();
                    ProcessInput(controller, command);
                }
            }
            else
            {
                try
                {
                    string[] lines = File.ReadAllLines(args[0]);
                    foreach (string command in lines)
                    {
                        ProcessInput(controller, command);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("invalid file");
                }
            }
        }
        static void ProcessInput(RobotController controller, string _command)
        {
            var command = _command.Trim().ToUpper();
            if (command.Split(' ')[0] == "PLACE")
            {
                var param = command.Split(' ')[1].Split(',');
                int posX = 0;
                int posY = 0;
                Directions direction;
                if (!Enum.TryParse<Directions>(param[2], out direction)
                    || !Int32.TryParse(param[0], out posX) || !Int32.TryParse(param[1], out posY))
                {
                    Console.WriteLine("invalid");
                    return;
                }
                Console.WriteLine(controller.Place(posX, posY, direction));
            }
            else if (command == "MOVE")
            {
                Console.WriteLine(controller.Move());
            }
            else if (command == "RIGHT")
            {
                Console.WriteLine(controller.Right());
            }
            else if (command == "LEFT")
            {
                Console.WriteLine(controller.Left());
            }
            else if (command == "REPORT")
            {
                Console.WriteLine(controller.Report());
            }
            else if (command == "")
            {
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("invalid");
            }
        }
        
    }
}
