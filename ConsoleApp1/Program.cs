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
                item.GetLC();
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
