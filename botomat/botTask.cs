using System.Collections.Generic;
using System;

namespace BotOMat
{
    public class BotTask
    {
        //initialize bot tasks
        public static readonly BotTask DISHES = new BotTask("Dishes", "Do the dishes", 1000, 1);
        public static readonly BotTask SWEEP = new BotTask("Sweep", "Sweep the house", 3000, 2);
        public static readonly BotTask LAUNDRY = new BotTask("Laundry", "Do the laundry", 10000, 3);
        public static readonly BotTask RECYCLING = new BotTask("Recycling", "Take out the recycling", 4000, 4);
        public static readonly BotTask SAMMICH = new BotTask("Sammich", "Make a sammich", 7000, 5);
        public static readonly BotTask LAWN = new BotTask("Lawn", "Mow the lawn", 20000, 6);
        public static readonly BotTask RAKE = new BotTask("Rake", "Rake the leaves", 18000, 7);
        public static readonly BotTask BATH = new BotTask("Bath", "Give the dog a bath", 14500, 8);
        public static readonly BotTask BAKE = new BotTask("Bake", "Bake some cookies", 8000, 9);
        public static readonly BotTask WASH = new BotTask("Wash", "Wash the car", 20000, 10);

        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Duration { get; private set; }
        public int Index { get; private set; }


        private BotTask(string name, string description, int duration, int index)
        {
            Name = name;
            Description = description;
            Duration = duration;
            Index = index;
        }

        public int getDuration()
        {
            return Duration;
        }

        public string getName()
        {
            return Name;
        }

        public void Perform()
        {
            Console.WriteLine($"  - Peforming Task: {Name} with {Duration} and {Index}");
            //Console.WriteLine($"  - Peforming Task: {Name.GetDescription()} with {Duration} and {TaskType}");
        }
    }


}