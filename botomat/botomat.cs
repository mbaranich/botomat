using System;
using System.Linq;
using System.ComponentModel;

namespace BotOMat
{
    [AttributeUsageAttribute(AttributeTargets.All)]
    public class DescriptionWithValueAttribute : DescriptionAttribute
    {
        public DescriptionWithValueAttribute(string description, int value) : base(description)
        {
            this.Value = value;
        }

        public int Value { get; private set; }
    }


    public enum RobotType
    {
        Unipedal = 1,
        Bipedal,
        Quadrupedal,
        Arachnid,
        Radial,
        Aeronautical
    }


    public class BotOMat
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to BotOMat!");
            bool showMenu = true;
            while (showMenu == true)
            {
                showMenu = MainMenu();
            }

        }

        private static bool MainMenu()
        {
            Console.WriteLine("Enter a number below, then select enter to continue:");
            Console.WriteLine("1) Create a Robot");
            Console.WriteLine("2) Display Leaderboard");
            Console.WriteLine("3) Exit");
            Console.Write(">> ");
            //Read user input:
            int option = Convert.ToInt32(Console.ReadLine());

            //Initilize menu options. Make sure option is valid.
            if (option >= 1 && option <= 6)
            {
                switch (option)
                {
                    case 1:
                        Robot.CreateRobot();
                        return true;
                    case 2:
                        Robot.robotsList = Robot.robotsList.OrderBy(x => x.TimeElapsed).ToList();
                        Robot.DisplayRobots();
                        return true;
                    case 3:
                        return false;
                    default:
                        return true;

                }
            }
            else
            {
                Console.WriteLine("Please select a value from the list.");
                return true;
            }

        }

    }
}
