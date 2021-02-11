using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Queue
    {

        int Acounter = 0;
        int Dcounter = 0;
       
        Queue<int> insideQ = new Queue<int>(); //Queue for vehicles inside the parking slot
        Queue<int> outsideQ = new Queue<int>(); //Queue for vehicles outside the parking slot
        public void QueueOperations()
        {
            int result = 5;
            Queue.UI();
            this.Choice(out result);
            this.Todo(result);
        }

        public static void UI()
        {
            Console.WriteLine("**Welcome to the Garage Simulation using Queue**");
            Console.WriteLine("1. Vehicle entry registration");
            Console.WriteLine("2. Vehicle departure registration");
            Console.WriteLine("3. Number of Arrivals and Departures");
            Console.WriteLine("4. Check parking space");
            Console.WriteLine("5. Exit");
            Console.WriteLine("************************************************");
        }

        public void Choice(out int result)
        {
            Console.WriteLine("Enter your choice:");
            try
            {
                result = Convert.ToInt32(Console.ReadLine());

                if (result >= 6 || result < 0)
                {
                    throw new FormatException();
                }
                else
                {

                    Todo(result);
                }
            }
            catch (FormatException)
            {
                result = 0;
                Console.Clear();
                Console.WriteLine("Incorrect input, choose only from 1 to 5.");
                Queue.UI();
                this.Choice(out result);

            }
        }

        public void Todo(int choice)
        {

            Console.Clear();
            switch (choice)
            {
                case 1:
                    this.ChoiceOne();
                    break;
                case 2:
                    this.ChoiceTwo();
                    break;
                case 3:
                    this.ChoiceThree();
                    break;
                case 4:
                    this.ChoiceFour();
                    break;
                case 5:
                    Console.Clear();
                   outsideQ.Clear();
                    insideQ.Clear();
                    Program program = new Program();
                    program.Main();
                    break;

            }
        }

        public void GetPlate(out int result)
        {
            try
            {
                Console.WriteLine("Please enter the license plate number: ");
                result = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("Choose only numbers.");
                this.GetPlate(out result);
            }
;
        }

        public void ChoiceOne()
        {
            int plateNumber;
            this.GetPlate(out plateNumber);
            if (insideQ.Contains(plateNumber) == true)
            {
                Console.WriteLine("That car is already in the parking space");
                Console.WriteLine("Press enter to try again");
                Console.ReadLine();
                Console.Clear();


            }
            else if (insideQ.Count() == 10)
            {
                Console.WriteLine("The Parking Area is full");
                Console.WriteLine("Press enter to go back");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                insideQ.Enqueue(plateNumber);
                Acounter = Acounter + 1;
                Console.WriteLine("Successfully Parked!");
                Console.WriteLine("Press enter to go back");
                Console.ReadLine();
                Console.Clear();
            }
            this.QueueOperations();
        }

        public void ChoiceTwo()
        {
            int plateNumber = 0;
           
            if (insideQ.Count == 0)
            {
                Console.WriteLine("The parking space is empty!");
                this.QueueOperations();
            }
            else
            {
                Console.WriteLine("List of Parked Plate Numbers:");
                foreach (var item in insideQ)
                    Console.WriteLine(item);
                this.GetPlate(out plateNumber);
                if (insideQ.Contains(plateNumber) == true)
                {
                    int checker = insideQ.Peek();
                    while (checker != plateNumber)
                    {

                        outsideQ.Enqueue(insideQ.Dequeue());
                        Dcounter = Dcounter + 1;
                        checker = insideQ.Peek();
                    }
                    if (checker == plateNumber)
                    {
                        Dcounter = Dcounter + 1;
                        insideQ.Dequeue();
                    }
                    foreach (var item in outsideQ)
                        Acounter = Acounter + 1;
                    foreach (var item in outsideQ)
                        insideQ.Enqueue(item);

                    outsideQ.Clear();

                    Console.WriteLine("Successfully Departed!");
                    Console.WriteLine("Press enter to go back");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Car license number not found");
                    Console.WriteLine("Press enter to go back");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            this.QueueOperations();
        }

        public void ChoiceThree()
        {
            Console.WriteLine("Number of Arrivals:" + Acounter);
            Console.WriteLine("Number of Departures:" + Dcounter);
            Console.WriteLine("Press enter to go back");
            Console.ReadLine();
            Console.Clear();
            this.QueueOperations();
        }

        public void ChoiceFour()
        {
            Console.WriteLine("Number of cars in the parking lot: {0}", insideQ.Count);
            int Space = 10 - insideQ.Count;
            Console.WriteLine("Number of free spaces: {0}", Space);
            Console.WriteLine("License plate list:");
            foreach (var item in insideQ)
                Console.WriteLine(item);

            Console.WriteLine("Press enter to go back");
            Console.ReadLine();
            Console.Clear();
            this.QueueOperations();
        }


    }

}
