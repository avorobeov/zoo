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
                        isExit = false;
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

        public Animal(string title,int age,string gender)
        {
            Title = title;
            Age = age;
            Gender = gender;
        }

    }

    class Aviary
    {
        private List<Animal> _animals = new List<Animal>();

        public string Title { get; private set; }
        public string AnimalSound { get; private set; }
        public int NumberAnimals => _animals.Count;

        public Aviary(string title, string animalSound)
        {
            Title = title;
            AnimalSound = animalSound;
        }

        public void AddAnimal(string title, int age, string gender)
        {
            _animals.Add(new Animal(title, age, gender));
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
    }

    class Zoo
    {
        private List<Aviary> _aviaries = new List<Aviary>();

        public void FillingZoo()
        {
           CreateAviary("Льви", "Рычание");
           AddAnimal(0, "Лев", 3, "Женский");
           AddAnimal(0, "Лев", 1, "Женский");
           AddAnimal(0, "Лев", 6, "Женский");
           AddAnimal(0, "Лев", 3, "Мужской");

           CreateAviary("Лошади", "Ржание");
           AddAnimal(1, "Лошадь", 1, "Женский");
           AddAnimal(1, "Лошадь", 6, "Женский");
           AddAnimal(1, "Лошадь", 3, "Женский");
           AddAnimal(1, "Лошадь", 8, "Мужской");

           CreateAviary("Вовки", "Вой");
           AddAnimal(2, "Волк", 1, "Женский");
           AddAnimal(2, "Волк", 1, "Мужской");
           AddAnimal(2, "Волк", 2, "Мужской");
           AddAnimal(2, "Волк", 5, "Мужской");

           CreateAviary("Козы", "блеет");
           AddAnimal(3, "Коза", 1, "Женский");
           AddAnimal(3, "Коза", 1, "Мужской");
           AddAnimal(3, "Коза", 2, "Мужской");
           AddAnimal(3, "Коза", 5, "Мужской");
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
                ShowMessage($"\nНазвание вольера :{_aviaries[index].Title} \n\nКоличество Животных:{_aviaries[index].NumberAnimals}\n\nПол животных:{_aviaries[index].GetGender(index)}\n\nЭтот зверь издаёт такой звук: {_aviaries[index].AnimalSound}", ConsoleColor.Yellow);
            }
        }

        public void AddAnimal(int index, string title, int age, string gender)
        {
            _aviaries[index].AddAnimal(title, age, gender);
        }

        public void CreateAviary(string title, string animalSound)
        {
            _aviaries.Add(new Aviary(title, animalSound));
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
