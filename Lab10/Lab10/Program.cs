using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            //-----------------------------------task1---------------------------------------------
            Cars<Car> myCarCollection = new Cars<Car>(
                new Car("Opel", "Astra", "Metalic"), new Car("Audi", "100", "White"), new Car("BMW", "X5", "Black"),
                new Car("Passat", "B5", "Red"), new Car("Mercedes", "W213", "Gray"));

            myCarCollection.Add(new Car("Audi", "80", "Brown"));
            foreach (var i in myCarCollection) Console.WriteLine($"{i.Brand} {i.Modedl} {i.Color}");
            Console.WriteLine();

            myCarCollection.Remove(new Car("Audi", "80", "Brown"));
            foreach (var i in myCarCollection) Console.WriteLine($"{i.Brand} {i.Modedl} {i.Color}");
            Console.WriteLine();

            int index = myCarCollection.IndexOf(new Car("Audi", "100", "White"));
            Console.WriteLine($"Index Audi 100 in collection: {index}");
            Console.WriteLine();

            //---------------------------------------task2-----------------------------------------

            Dictionary<string, int> greatPeople = new Dictionary<string, int> { { "Уинстон Черчиль", 1874 },
                { "Мохаммед Aли",1942}, {"Ганди",1869 },{"Галилео Галилей",1564 },{ "Альберт Эйнштэйн", 1879} };

            //a
            foreach (var i in greatPeople) Console.WriteLine($"Name: {i.Key}  Year:{i.Value}");
            Console.WriteLine();
            //b
            RemoveNCountInDictionary(ref greatPeople);
            foreach (var i in greatPeople) Console.WriteLine($"Name: {i.Key}  Year:{i.Value}");
            Console.WriteLine();
            //c
            greatPeople.Add("Валько Сергей", 2002);
            greatPeople.Add("Дед Мороз", 0);
            //d
            List<int> yearForGreat = new List<int>();
            foreach (var i in greatPeople) yearForGreat.Add(i.Value);
            //e
            foreach (var i in yearForGreat) Console.Write(i + " ");
            Console.WriteLine();
            //f
            if (yearForGreat.Find(i => i == 2002) != default(int)) Console.WriteLine("Dictionary has men with 2002 year!");
            Console.WriteLine();

            //----------------------------------task3----------------------------------------------------------------
            ObservableCollection<Car> autoShow = new ObservableCollection<Car> { myCarCollection[0], myCarCollection[1], myCarCollection[2] };

            autoShow.CollectionChanged += CollectionChange;
            autoShow.CollectionChanged += CollectionChange;

            autoShow.Add(myCarCollection[3]);
            autoShow.Remove(new Car("Opel", "Astra", "Metalic"));

            Console.Read();
        }

        public static void RemoveNCountInDictionary(ref Dictionary<string, int> dc)
        {
            List<string> str = new List<string>();
            foreach (var it in dc)
            {
                str.Add(it.Key);
            }
            Console.WriteLine("Enter count elements for remove:");
            int count = Convert.ToInt32(Console.ReadLine());
            int n = 0;
            foreach (var i in str)
            {
                if (n < count) dc.Remove(i);
                n++;
            }
        }

        public static void CollectionChange(object obj, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // Выяснить действие, которое привело к генерации события. 
            Console.WriteLine("Action for this event: {0}", e.Action);
            // Было что-то удалено, 
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                Console.WriteLine("Here are the OLD items:"); // старые элементы 
                foreach (var p in e.OldItems)
                {
                    Console.WriteLine(p.ToString());
                }
            }
            Console.WriteLine();
            // Было что-то добавлено. 
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                // Теперь вывести новые элементы, которые были вставлены. 
                Console.WriteLine("Here are the NEW items:"); // новые элементы 
                foreach (var p in e.NewItems)
                {
                    Console.WriteLine(p.ToString());
                }
            }
        }
    }

}
