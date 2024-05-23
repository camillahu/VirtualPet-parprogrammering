namespace VirtualPet
{
    internal class Admin
    {
        private List<Pet> _pets = new List<Pet>()
        {
            new("Nico", 7, false, true, true),
            new("Bianca", 3, true, false, false),
            new("Loki",  6, false,false,false),
        };

        public void RunVirtualPetProgram()
        {
            bool runningMain = true;
            while (runningMain)
            {
                Console.WriteLine("Welcome to Virtual Pet!");
                Console.WriteLine("Which pet would you like to take care of?");
                RunShowPets();
                Pet pickedPet = RunPickPet();
                Console.WriteLine($"You picked: {pickedPet.Name}");
                pickedPet.RunShowPetCareOptions();
            }
        }

        private void RunShowPets()
        {
            for (int i = 0; i < _pets.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_pets[i].Name}");
            }
            Console.WriteLine("If you would like to make your own pet, tap 0.");
            int input= Convert.ToInt32(Console.ReadLine());
            if (input == 0)
            {
                RunMakePet();
            }
        }

        private void RunMakePet()
        {

        }

        private Pet RunPickPet()
        {
            bool runningPickPet= false;
            int input = 0;
            do
            {
                Console.WriteLine("Please type the number of the pet:");
                 input = Convert.ToInt32(Console.ReadLine());
                if (input > _pets.Count || input <= 0)
                {
                    runningPickPet = true;
                }
            } while (runningPickPet);
           

            return _pets.Where(p => p.Name == _pets[input - 1].Name).FirstOrDefault();
        }


    }
}
