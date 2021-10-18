using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace BotOMat
{
    public class Robot
    {

        public string BotName { get; set; }

        public RobotType BotType { get; set; }
        public string BotTypeDescription => BotType.GetDescription();

        public int TimeElapsed { get; set; }

        private readonly List<BotTask> _tasks = new List<BotTask>();
        public static List<Robot> robotsList = new List<Robot>();


        public Robot(string botName, RobotType botType, int timeElapsed = default)
        {
            this.BotName = botName;
            this.BotType = botType;
            TimeElapsed = timeElapsed;
        }

        public void AddTask(BotTask task)
        {
            _tasks.Add(task);
        }

        public void Show()
        {
            Console.WriteLine($"Robot: {BotName}, Type: {BotTypeDescription}, TimeElapsed: {TimeElapsed}ms");
        }


        private void CompleteTasks(BotTask botTask)
        {
            Thread.Sleep(botTask.Duration);
            TimeElapsed += botTask.getDuration();
            Console.WriteLine($"Task Completed: {botTask.Name}");
        }

        public List<BotTask> randomizeBotTasks()
        {
            var loadBotTasks = new List<BotTask> { BotTask.DISHES, BotTask.SWEEP, BotTask.LAUNDRY, BotTask.RECYCLING, BotTask.SAMMICH, BotTask.LAWN, BotTask.RAKE, BotTask.BATH, BotTask.BAKE, BotTask.WASH };

            int i = 1;
            List<BotTask> randomizedBotTasks = new List<BotTask>();

            Console.WriteLine("Randomizing tasks...");

            //randomize botTasks: loops 5 times for 5 bottasks per robot
            while (i <= 5)
            {
                var random = new Random();
                int index = random.Next(loadBotTasks.Count);
                randomizedBotTasks.Add(loadBotTasks[index]);
                CompleteTasks(loadBotTasks[index]);
                loadBotTasks.Remove(loadBotTasks[index]);
                i++;
            }
            return randomizedBotTasks;
        }

        public static void CreateRobot()
        {
            {

                Console.Write("Enter robot name: ");
                var robotName = Console.ReadLine();

                RobotType? robotType = null;
                while (!robotType.HasValue)
                {
                    robotType = GetResponseUsingEnum<RobotType>("Robots");
                }

                var robot = new Robot(robotName, robotType.Value);
                robotsList.Add(robot);
                robot.randomizeBotTasks();
                
            }
            //At this point, we have a fully populated list of robots, each with some tasks
            
        }

        public static void DisplayRobots()
        {

            //Sort robots list by time elapsed.
            Robot.robotsList = Robot.robotsList.OrderByDescending(x => x.TimeElapsed).ToList();
            
            foreach (var robot in robotsList)
            {
                robot.Show();
            }
        }

        public static T? GetResponseUsingEnum<T>(string prompt) where T : struct, Enum
        {
            //Loop until a good answer (or no answer)
            while (true)
            {
                Console.WriteLine($"{prompt}: Please enter one of:");
                var values = (T[])Enum.GetValues(typeof(T));
                foreach (var enumValue in values)
                {
                    var description = enumValue.GetDescription<T>();
                    var intValue = Convert.ToInt32(enumValue);
                    Console.WriteLine($"{intValue}: {description}");
                }
                Console.Write(">> ");
                var response = Console.ReadLine();
                if (string.IsNullOrEmpty(response))
                {
                    return (T?)null;
                }
                if (Enum.TryParse<T>(response, out var val))
                {
                    if (values.Contains(val))
                    {
                        Console.WriteLine($"You answered: {val}");
                        return val;
                    }
                }
            }
        }
    }
}