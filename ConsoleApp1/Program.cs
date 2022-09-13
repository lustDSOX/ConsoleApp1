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
        static void Main(string[] args)
        {
            List<Transport> transports= new List<Transport>();
            transports.Add(new Automobile() {mark = "Nisan",model = "V8",horsepower = 4});
            transports.Add(new MotoBike() { mark = "Yamaha", model = "14.1", horsepower = 1,wheelchair = false });
            transports.Add(new Truck() {mark = "Honda",model = "SEX PISTOLS",horsepower = 10, trailer = true});

            foreach (var item in transports)
            {
                item.PrintDetal();
                WriteLine("\n");
            }


            ReadKey();
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

            public double GetLC()
            {
               return horsepower * 2.5 / Math.PI;
            }
        }

        class Automobile : Transport
        {
        }
        class MotoBike : Transport
        {
            public bool wheelchair;
            double LC = 0;
            public override double load_capacity
            {
                get => LC;
                set
                {
                    if (!wheelchair)
                    {
                        LC = value;
                    }
                    else
                    {
                        LC = GetLC();
                    }
                }
            }
        }
        class Truck : Transport
        {
            public bool trailer;
            double LC = 0;
            public override double load_capacity
            {
                get => 0;
                set
                {
                    if (trailer)
                    {
  
                        LC = GetLC() * 2;
                    }
                    else
                    {
                        LC = GetLC();
                    }
                }
            }
        }
    }
}
