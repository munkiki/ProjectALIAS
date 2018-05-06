using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HW8
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task1
            string LineFromFile;
            string Number = "";
            string Person = "";
            string AllNumbers = "";
            string[] SplitLine = new string[2];
            Dictionary<String, String> PhoneBook = new Dictionary<String, String>();
            StreamReader FileReader = new StreamReader("D:\\phones.txt");
            while ((LineFromFile = FileReader.ReadLine()) != null)
            {
                SplitLine = LineFromFile.Split('-');
                Person = SplitLine[0];
                Number = SplitLine[1];
                Person = Person.Trim();
                Number = Number.Trim();
                PhoneBook.Add(Person, Number);
            }
            foreach (KeyValuePair<string, string> pair in PhoneBook)
            {
                AllNumbers = AllNumbers + pair.Value + Environment.NewLine;
            }
            File.WriteAllText("D:\\phones2.txt", AllNumbers);

            //Task2
            bool Result = false;
            string ResultStr = "";
            Console.Write("Please enter the name for search in the database: ");
            string Input = Console.ReadLine();
            foreach (KeyValuePair<string, string> pair in PhoneBook)
            {
                if (Input == pair.Key)
                {
                    Result = true;
                    ResultStr = pair.Value;
                }
            }
            if (Result == true) Console.WriteLine("The phone number of the person is {0}.", ResultStr);
            else Console.WriteLine("You typed the wrong ID.");

            //Task3
            string Median = "";
            string NewOutput = "";
            foreach (KeyValuePair<string, string> pair in PhoneBook)
            {
                if (pair.Value.StartsWith("8"))
                {
                    Median = "+3" + pair.Value;
                }
                else Median = pair.Value;
                NewOutput += pair.Key + " - " + Median + Environment.NewLine;
                File.WriteAllText("D:\\new.txt", NewOutput);
            }
            Console.ReadLine();
        }
    }
}
