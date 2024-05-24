namespace VirtualPet
{
    internal class Admin
    {
        private List<Pet> _pets = new List<Pet>()
        {
            new("Nico", false, true, true),
            new("Bianca", true, false, false),
            new("Loki", false,false,false),
        };

        public void RunVirtualPetProgram()
        {
            bool runningMain = true;
            while (runningMain)
            {
                Console.Clear();
                PrintTitle();
                Console.WriteLine("Welcome to Virtual Pet!");
                Console.WriteLine("Which pet would you like to take care of?");
                RunShowPets();
                Pet pickedPet = RunPickPet();
                Console.WriteLine($"You picked: {pickedPet.Name}");
                Console.WriteLine();
                pickedPet.RunShowPetCareOptions();
            }
        }

        public void PrintTitle()
        {
            Console.WriteLine(@" _    ___      __              __   ____       __ 
| |  / (_)____/ /___  ______ _/ /  / __ \___  / /_
| | / / / ___/ __/ / / / __ `/ /  / /_/ / _ \/ __/
| |/ / / /  / /_/ /_/ / /_/ / /  / ____/  __/ /_  
|___/_/_/   \__/\__,_/\__,_/_/  /_/    \___/\__/");
        }

        private void RunShowPets()
        {
            for (int i = 0; i < _pets.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_pets[i].Name}");
            }
            Console.WriteLine("If you would like to make your own pet, tap 0.");

        }

        private void RunMakePet()
        {
            Console.WriteLine("Name your pet");
            string? petName = Console.ReadLine();
            Pet newPet = new Pet(petName);
            _pets.Add(newPet);
            Console.WriteLine("\n");
            RunShowPets();
        }

        private Pet RunPickPet()
        {
            bool runningPickPet = true;
            int input = 0;
            while (runningPickPet)
            {
                Console.WriteLine("Please type the number of the pet:");
                input = Convert.ToInt32(Console.ReadLine());
                if (input > _pets.Count || input < 0)
                {
                    Console.WriteLine("Yooo");

                }
                else if (input == 0)
                {
                    RunMakePet();
                }
                else { runningPickPet = false; }


            };

            return _pets.Where(p => p.Name == _pets[input - 1].Name).FirstOrDefault();
        }


    }
}