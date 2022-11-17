using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp1
{
    internal class Program
    {
        static List<Transport> transports = new List<Transport>();
        static void Main(string[] args)
        {
          
            transports.Add(new Automobile() {mark = "Nisan",model = "V8",horsepower = 4});
            transports.Add(new MotoBike() { mark = "Yamaha", model = "14.1", horsepower = 1,wheelchair = false });
            transports.Add(new Truck() {mark = "Honda",model = "SEX PISTOLS",horsepower = 10, trailer = true});

            while (true)
            {
                Main_print();
            }
        }
        static void Nissan_repair()
        {
         Console.WriteLine("Саня починился!!!");
        }
        static void Main_print()
        {
            foreach (var item in transports)
            {
                item.GetLC();
                item.PrintDetal();
                WriteLine("\n");
            }


            WriteLine("чтобы перейтив режим поиска нажмите s");

            if (ReadLine() == "s")
                Search_mode();
            else
                Clear();
        }

        static void Search_mode()
        {
            string[] text;
            while (true)
            {
                while (true)
                {
                    Clear();
                    WriteLine("Введите нужные рамки по грузоподъемности (например 10-13)");
                    text = ReadLine().Split('-');
                    if (int.TryParse(text[0], out int i) && int.TryParse(text[1], out int o))
                    {
                        break;
                    }

                }

                WriteLine("___________________________________________");
                int min = Convert.ToInt32(text[0]);
                int max = Convert.ToInt32(text[1]);

                foreach (Transport item in transports)
                {
                    if (item.load_capacity >= min && item.load_capacity <= max)
                    {
                        item.PrintDetal();
                        WriteLine("\n");
                    }
                }

                WriteLine("Чтобы вернуться назад нажмите enter, чтобы воспользоваться поиском еще раз - r");
                string end_text = ReadLine();
                if (end_text == "")
                {
                    Clear();
                    break;
                }
                else if(end_text== "r")
                {
                    Search_mode();
                }

            }
        }

        abstract class Transport
        {
            public string mark { get; set; }
            public string model { get; set; }
            public double horsepower { get; set; }
            public double load_capacity { get; set; }
            public void PrintDetal()
            {
                WriteLine("Марка - {0,5} \nмодель - {1,5} \nлошадиные силы - {2,4} \nгрузоподъесность - {3,4}", mark,model,horsepower,load_capacity);
            }

            public virtual void GetLC()
            {
               load_capacity = horsepower * 2.5 / Math.PI;
            }
        }

        class Automobile : Transport
        {
        }
        class MotoBike : Transport
        {
            public bool wheelchair;
            public override void GetLC()
            {
                if (wheelchair)
                    load_capacity = horsepower * 2.5 / Math.PI;
                else
                    load_capacity = 0;
            }
        }
        class Truck : Transport
        {
            public bool trailer;
            public override void GetLC()
            {
                if (trailer)
                    load_capacity = horsepower * 2.5 / Math.PI * 2;
                else
                    load_capacity = horsepower * 2.5 / Math.PI;
            }
        }
    }
}
