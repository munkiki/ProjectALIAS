using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    class Program
    {
        static void Main(string[] args)
        {
            Programmer P1 = new Programmer();
            Programmer P2 = new Programmer();
            Programmer P3 = new Programmer();
            Builder B1 = new Builder();
            Builder B2 = new Builder();
            Builder B3 = new Builder();
            List<IDeveloper> List = new List<IDeveloper>();
            List.Add(P1);
            List.Add(P2);
            List.Add(P3);
            List.Add(B1);
            List.Add(B2);
            List.Add(B3);
            foreach (IDeveloper x in List)
            {
                x.Create();
                Console.WriteLine(x.Tool);
            }
            
        }
    }
    interface IDeveloper
    {
        string Tool { get; set; } 
        string Create();
        string Destroy();
    }
    class Programmer : IDeveloper 
    {
        public string Language;
        public string Tool { get; set; }
        public string Create()
        {
            Console.WriteLine("Please, input the language:");
            Tool = Console.ReadLine();
            return Tool;          
        }
        public string Destroy()
        {
            Tool = "";
            return Tool;
        }
        string CompareTo;
    }
    class Builder : IDeveloper 
    {
        public string tool;
        public string Tool { get; set; }
        public string Create()
        {
            Console.WriteLine("Please, name the tool of the builder:");
            Tool = Console.ReadLine();
            return Tool;
        }
        public string Destroy()
        {
            Tool = "";
            return Tool;
        }
        
    }
    
}

