using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParkingLotApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            string input;
            ParkingLot Park = new ParkingLot();
            string res = String.Empty;
            Car c;
            const string chars = "ABCDEFGHIJKLMNOPQRS-TUVWXYZ0123456789";
            Random rnd = new Random();
            Thread th1 = new Thread(new ThreadStart(Park.EnGate.RunCycle));
            Thread th2 = new Thread(new ThreadStart(Park.ExGate.RunCycle));

            while (running)
            {
                input = Console.ReadLine();
                switch (input)
                {
                    case "q":
                        if(th1.IsAlive)
                            th1.Abort();
                        if (th2.IsAlive)
                            th2.Abort();
                        running = false;
                        break;
                    case "c1":
                        c = new Car(new string(Enumerable.Repeat(chars, 5).Select(s => s[rnd.Next(s.Length)]).ToArray()), rnd.Next(1, 100));
                        Park.EnGate.Queue.Add(c);
                        if (!th1.IsAlive)
                            th1.Start();
                        Console.WriteLine("Entry gate queue : "+Park.EnGate.Queue.Count);
                        break;
                    case "c2":
                        c = new Car(Park.plates.FirstOrDefault(), rnd.Next(1, 100));
                        Park.ExGate.Queue.Add(c);
                        if (!th2.IsAlive)
                            th2.Start();
                        Console.WriteLine("Exit gate queue : " + Park.ExGate.Queue.Count);
                        break;
                    case "l":
                        Console.WriteLine(Park.ToString());
                        break;
                    case "e1":
                        Park.EnGate.HitEmergencyButton(th1);
                        break;
                    case "e2":
                        Park.EnGate.HitEmergencyButton(th2);
                        break;
                }
            }
        }
    }
}
