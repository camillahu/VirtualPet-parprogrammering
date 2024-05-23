using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;

namespace VirtualPet
{
    internal class Pet(string name, bool isHungry, bool isPoopy, bool isCuddly)
    {
        public string Name { get; private set; } = name;
        public bool IsHungry { get; private set; } = isHungry;
        public bool IsPoopy { get; private set; } = isPoopy;
        public bool IsCuddly { get; private set; } = isCuddly;

        public bool running = true;

        public Pet()
        {
            
        }

        public Pet(string name)
        {
            Name = name;
            IsHungry = true;
            IsPoopy = true;
            IsCuddly = true;
        }
        
        Random random = new Random();

        public void RunShowPetCareOptions()
        {
            Console.WriteLine("Pick an option:");
            running = true;
            while (running)
            {
                Console.WriteLine($"1. Feed {Name}");
                Console.WriteLine($"2. Potty {Name}");
                Console.WriteLine($"3. Cuddle {Name}");
                Console.WriteLine("4. Pick another pet");
                Console.WriteLine("5. Exit game");
                int input = Convert.ToInt32(Console.ReadLine());
                RunPickedOption(input);
            }
        }

        public void RunPickedOption(int input)
        {
            switch (input)
            {
                case 1:
                    RunOption1();
                    break;
                case 2:
                    RunOption2();
                    break;
                case 3:
                    RunOption3();
                    break;
                case 4:
                    running = false;
                    break;
                case 5: Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("Please pick a valid option"); RunShowPetCareOptions();
                    break;
            }
        }

        public void RunOption1()
        {
            IsPoopy = RandomBool();
            IsCuddly = RandomBool();

            if (IsHungry)
            {
                Console.WriteLine($"You fed {Name}");
                IsHungry = false;
            }
            else
            {
                Console.WriteLine($"{Name} was not hungry");
                RunShowPetCareOptions();
            }
        }
        public void RunOption2()
        {
            IsHungry = RandomBool();
            IsCuddly = RandomBool();

            if (IsPoopy)
            {
                Console.WriteLine($"You took {Name} to use the bathroom");
                IsPoopy = false;
            }
            else
            {
                Console.WriteLine($"{Name} did not need to use the bathroom");
                RunShowPetCareOptions();
            }
        }
        public void RunOption3()
        {
            IsHungry = RandomBool();
            IsPoopy = RandomBool();

            if (IsCuddly)
            {
                Console.WriteLine($"You cuddled {Name}");
                IsCuddly = false;
            }
            else
            {
                Console.WriteLine($"{Name} did not want to be cuddled");
                RunShowPetCareOptions();
            }
        }

        public bool RandomBool()
        {
            int randomInt = random.Next(0, 2);
            bool randomBool = randomInt == 0 ? true : false;

            return randomBool;
        }
    }
}