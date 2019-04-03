using System;
using System.Collections.Generic;
using System.IO;

namespace FileHomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            string text;
            using (FileStream reader = new FileStream("data.txt", FileMode.Open))
            {
                byte[] array = new byte[reader.Length];
                reader.Read(array, 0, array.Length);
                text = System.Text.Encoding.Default.GetString(array);
            }

            Dictionary<char, int> symbols = new Dictionary<char, int>();

            for (int i = 0; i < text.ToCharArray().Length; i++)
            {
                char symbol = text.ToCharArray()[i];
                if (symbol == ' ')
                    continue;

                bool haveSymbol = false;

                foreach (var element in symbols)
                    if (element.Key == symbol)
                        haveSymbol = true;

                if (haveSymbol)
                    symbols[symbol]++;
                else
                    // Если нет символа, тогда создаем новую запись с количеством повторений 1.
                    symbols.Add(symbol, 1);

            }

            foreach (var element in symbols)
            {
                Console.WriteLine($"{element.Key} -> {element.Value} шт.");
            }
            Console.ReadLine();
            
            using (StreamWriter writer = new StreamWriter("MyInfo.txt"))
            {
                writer.WriteLine("Vladislav");
                writer.WriteLine("Gorokhov");
                writer.WriteLine("15");
            }
            Console.ReadLine();
        }
    }
}
