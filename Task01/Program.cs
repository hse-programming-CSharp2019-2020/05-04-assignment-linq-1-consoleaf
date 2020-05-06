using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/* В задаче не использовать циклы for, while. Все действия по обработке данных выполнять с использованием LINQ
 * 
 * На вход подается строка, состоящая из целых чисел типа int, разделенных одним или несколькими пробелами.
 * Необходимо отфильтровать полученные коллекцию, оставив только отрицательные или четные числа.
 * Дважды вывести коллекцию, разделив элементы специальным символом.
 * Остальные указания см. непосредственно в коде!
 * 
 * Пример входных данных:
 * 1 2 3 4 5
 * 
 * Пример выходных:
 * 2:4
 * 2*4
 * 
 * Обрабатывайте возможные исключения путем вывода на экран типа этого исключения 
 * (не использовать GetType(), пишите тип руками).
 * Например, 
 *          catch (SomeException)
            {
                Console.WriteLine("SomeException");
            }
 * В случае возникновения иных нештатных ситуаций (например, в случае попытки итерирования по пустой коллекции) 
 * выбрасывайте InvalidOperationException!
 * 
 */

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTesk01();
        }

        public static void RunTesk01()
        {
            int[] arr;
            try
            {
                // Попробуйте осуществить считывание целочисленного массива, записав это ОДНИМ ВЫРАЖЕНИЕМ.
                arr = Regex.Replace(Console.ReadLine(), @"\s+", " ").Split(' ').Select(i => int.Parse(i)).ToArray();
            }
            catch (FormatException)
            {
                Console.WriteLine("FormatException");
                return;
            }

            if (arr == null || arr.Length == 0)
                throw new InvalidOperationException();

            // использовать синтаксис запросов!
            IEnumerable<int> arrQuery = from item in arr where item % 2 == 0 || item < 0 select item;

            // использовать синтаксис методов!
            IEnumerable<int> arrMethod = arr.Where(i => i < 0 || i % 2 == 0);

            try
            {
                PrintEnumerableCollection<int>(arrQuery, ":");
                PrintEnumerableCollection<int>(arrMethod, "*");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("InvalidOperationException");
            }
        }

        // Попробуйте осуществить вывод элементов коллекции с учетом разделителя, записав это ОДНИМ ВЫРАЖЕНИЕМ.
        // P.S. Есть два способа, оставьте тот, в котором применяется LINQ...
        public static void PrintEnumerableCollection<T>(IEnumerable<T> collection, string separator)
        {
            if (!collection.Any())
                throw new InvalidOperationException();
            var aggregated = collection.Select<T, string>(i => i.ToString())
                .Aggregate((s, arg2) => $"{s}{separator}{arg2}");
            Console.WriteLine(aggregated);
        }
    }
}