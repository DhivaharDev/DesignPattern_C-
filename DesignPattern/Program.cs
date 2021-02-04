using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace DesignPattern
{

    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private static int count = 0;
        public int AddEntry(string text)
        {
            entries.Add(++count + " : " + text);
            return count;
        }
        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }

    }


    public class Persistence
    {
        public void SaveToFile(Journal j, string fileName, bool overwrite = false)
        {
            if (overwrite || !File.Exists(fileName))
                File.WriteAllText(fileName, j.ToString());

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("Hi this is string");
            j.AddEntry("C# testing");

            Console.WriteLine(j);
            var p = new Persistence();
            string fileName = @"E:\MyLearning\DesignPattern\Code\journal.txt";
            p.SaveToFile(j, fileName, true);
           
            Console.ReadKey();
        }
    }
}
