using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zoo
{
    class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();

            zoo.FillingZoo();

            string userInput;
            bool isExit = false;

            while (isExit == false)
            {
                zoo.ShowAviaries();

                ShowMenu();

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "Exit":
                        isExit = true;
                        break;

                    default:
                        zoo.ShowAviarie(userInput);
                        break;
                }
            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine("\nВедите номер вольера к которому хотите подойти \n" +
                              "\nДля выхода ведите команду Exit\n");
        }
    }

    class Animal
    {
        public string Title { get; private set; }
        public int Age { get; private set; }
        public string Gender { get; private set; }
        public string AnimalSound { get; private set; }

        public Animal(string title,int age,string gender, string animalSound)
        {
            Title = title;
            Age = age;
            Gender = gender;
            AnimalSound = animalSound;
        }

    }

    class Aviary
    {
        private List<Animal> _animals = new List<Animal>();

        public string Title { get; private set; }
        public int NumberAnimals => _animals.Count;

        public Aviary(string title)
        {
            Title = title;
        }

        public void AddAnimal(string title, int age, string gender, string animalSound)
        {
            _animals.Add(new Animal(title, age, gender, animalSound));
        }

        public string GetGender(int index)
        {
            string genderAnimal = "";
            for (int i = 0; i < _animals.Count; i++)
            {
                genderAnimal += _animals[i].Gender + " ";
            }
            return genderAnimal;
        }

        public void SoundFromAviary()
        {
            Console.WriteLine($"Звуки из вольера:");

            for (int i = 0; i < _animals.Count; i++)
            {
                Console.WriteLine(_animals[i].AnimalSound);
            }
        }
    }

    class Zoo
    {
        private List<Aviary> _aviaries = new List<Aviary>();

        public void FillingZoo()
        {
           CreateAviary("Льви");
           AddAnimal(0, "Лев", 3, "Женский", "Рычание");
           AddAnimal(0, "Лев", 1, "Женский", "Рычание");
           AddAnimal(0, "Лев", 6, "Женский", "Рычание");
           AddAnimal(0, "Лев", 3, "Мужской", "Рычание");

           CreateAviary("Лошади");
           AddAnimal(1, "Лошадь", 1, "Женский", "Ржание");
           AddAnimal(1, "Лошадь", 6, "Женский", "Ржание");
           AddAnimal(1, "Лошадь", 3, "Женский", "Ржание");
           AddAnimal(1, "Лошадь", 8, "Мужской", "Ржание");

           CreateAviary("Вовки");
           AddAnimal(2, "Волк", 1, "Женский", "Вой");
           AddAnimal(2, "Волк", 1, "Мужской", "Вой");
           AddAnimal(2, "Волк", 2, "Мужской", "Вой");
           AddAnimal(2, "Волк", 5, "Мужской", "Вой");

           CreateAviary("Козы");
           AddAnimal(3, "Коза", 1, "Женский", "блеет");
           AddAnimal(3, "Коза", 1, "Мужской", "блеет");
           AddAnimal(3, "Коза", 2, "Мужской", "блеет");
           AddAnimal(3, "Коза", 5, "Мужской", "блеет");
        }

        public void ShowAviaries()
        {
            for (int i = 0; i < _aviaries.Count; i++)
            {
                ShowMessage($"\n№{i} Название вольера :{_aviaries[i].Title}\n", ConsoleColor.Green);
            }
        }

        public void ShowAviarie(string userInput)
        {

            int index = GetNumber(userInput);

            if (index >= 0 && index <= _aviaries.Count)
            {
                ShowMessage($"\nНазвание вольера :{_aviaries[index].Title} \n\nКоличество Животных:{_aviaries[index].NumberAnimals}\n\nПол животных:{_aviaries[index].GetGender(index)}\n", ConsoleColor.Yellow);

                _aviaries[index].SoundFromAviary();
            }
        }

        public void AddAnimal(int index, string title, int age, string gender,string animalSound)
        {
            _aviaries[index].AddAnimal(title, age, gender, animalSound);
        }

        public void CreateAviary(string title)
        {
            _aviaries.Add(new Aviary(title));
        }

        private void ShowMessage(string message, ConsoleColor color)
        {
            ConsoleColor preliminaryColor = Console.ForegroundColor;

            Console.ForegroundColor = color;
            Console.WriteLine(message);

            Console.ForegroundColor = preliminaryColor;
        }
       
        private int GetNumber(string userInput)
        {
            int meaning = 0;
            bool isCorrect = false;

            while (isCorrect == false)
            {
                if (Int32.TryParse(userInput, out meaning))
                {
                    return meaning;
                }
                else
                {
                    ShowMessage("Вы вели вместо числа строку", ConsoleColor.Red);
                }

                userInput = Console.ReadLine();
            }

            return meaning;
        }
    }
}
