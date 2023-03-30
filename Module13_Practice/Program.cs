using System.Collections.Generic;
using System.Diagnostics;

namespace Module13_Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\Никита\\source\\repos\\Module13_Practice\\Module13_Practice\\bin\\Debug\\net7.0\\Text1.txt";
            //filePath = Console.ReadLine();
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Неверный путь к файлу");
                Console.ReadKey();
                return;
            }
            List<string> list = new List<string>();
            LinkedList<string> linkedList;
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while (!sr.EndOfStream)
                {
                    if ((line = sr.ReadLine()) == "")
                        continue;
                    list.Add(line);
                }
            }
            linkedList = new LinkedList<string>(list);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            AddAfterEveryElement(list);
            sw.Stop();
            long[] averageTimeArr = new long[2];
            averageTimeArr[0] = sw.ElapsedTicks;
            sw.Reset();
            sw.Start();
            AddAfterEveryElement(linkedList);
            sw.Stop();
            averageTimeArr[1] = sw.ElapsedTicks;
            Console.WriteLine($"Вставка после каждого элемента string: \t\t{averageTimeArr[0].ToString()} ticks\nВставка после каждого элемента LinkedString: \t{averageTimeArr[1].ToString()} ticks");
            Console.ReadKey();
        }

        private static void AddAfterEveryElement(List<string> list)
        {
            for (int j = 0; j < list.Count - 1; j += 2)
            {
                list.Insert(j, list[j + 1]);
            }
        }
        private static void AddAfterEveryElement(LinkedList<string> list)
        {
            LinkedListNode<string>? node = list.First;
            while (!(node.Next == null))
            {
                list.AddAfter(node, node.Next.Value);
                node = node.Next.Next;
            }

        }
    }
}