namespace VirtualPet
{
    internal class Pet()
    {
        public string Name { get; private set; }
        public bool IsHungry { get; private set; }
        public bool IsPoopy { get; private set; }
        public bool IsCuddly { get; private set; }

        public bool running = true;

        public bool isDead = false;

        public Pet(string name) : this()
        {
            Name = name;
            IsHungry = true;
            IsPoopy = false;
            IsCuddly = true;
        }

        public Pet(string name, bool isHungry, bool isPoopy, bool isCuddly) : this()
        {
            Name = name;
            IsHungry = isHungry;
            IsPoopy = isPoopy;
            IsCuddly = isCuddly;
        }

        Random random = new Random();


        public void RunShowPetCareOptions()
        {
            Console.WriteLine();
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
                case 5:
                    Environment.Exit(1);
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
                DoesItDie();
                if (isDead) DeathMessage(1);

                IsHungry = false;
            }
            else
            {
                Console.WriteLine($"{Name} was not hungry");

            }
            RunShowPetCareOptions();
        }
        public void RunOption2()
        {
            IsHungry = RandomBool();
            IsCuddly = RandomBool();

            if (IsPoopy)
            {
                Console.WriteLine($"You took {Name} to use the bathroom");
                DoesItDie();
                if (isDead) DeathMessage(2);
                IsPoopy = false;
            }
            else
            {
                Console.WriteLine($"{Name} did not need to use the bathroom");

            }
            RunShowPetCareOptions();
        }
        public void RunOption3()
        {
            IsHungry = RandomBool();
            IsPoopy = RandomBool();

            if (IsCuddly)
            {
                Console.WriteLine($"You cuddled {Name}");
                DoesItDie();
                if (isDead) DeathMessage(3);
                IsCuddly = false;
            }
            else
            {
                Console.WriteLine($"{Name} did not want to be cuddled");

            }
            RunShowPetCareOptions();
        }

        public bool RandomBool()
        {
            int randomInt = random.Next(0, 2);
            bool randomBool = randomInt == 0 ? true : false;

            return randomBool;
        }

        public void DoesItDie()
        {
            int deathChance = random.Next(0, 60);
            if (deathChance == 0)
            {
                isDead = true;
            }
        }

        public void DeathMessage(int input)
        {
            switch (input)
            {
                case 1:
                    Console.WriteLine("Your pet died of food poisoning");
                    Environment.Exit(2);
                    break;
                case 2:
                    Console.WriteLine("Your died of violent diarrhea");
                    Environment.Exit(3);
                    break;
                case 3:
                    Console.WriteLine("You squished your pet to death");
                    Environment.Exit(4);
                    break;
                default:
                    break;

            }
        }
    }
}