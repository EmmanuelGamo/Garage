using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{



    class Program
    {


        static void Main(string[] args)

        {
            Program program = new Program();

            program.Main();
        }


        public void Main()
        {
         
            while (true)
            {


                Console.WriteLine("Choose what type of parking system you will use\n");
                Console.WriteLine("1.Parking System using Stacks\n");
                Console.WriteLine("2.Parking System using Queue\n");
                Console.WriteLine("3.Exit Program\n");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Parking parking = new Parking();  //Parking System using Stacks
                        parking.EnhanceOperation();
                        break;
                    case 2:
                        Console.Clear();
                        Queue queue = new Queue();
                        queue.QueueOperations();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;

                }

            }

            }

    }
}
