using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParkingLotApp
{
    public class Gate
    {
        #region Events
        public delegate void Notify(string plate);
        public event Notify CarPassed;
        #endregion

        #region Members
        public List<Car> Queue = new List<Car>();

        public Boolean FullyOpen { get; set; }

        public Boolean FullyClose { get; set; }

        public Boolean SafetySensor { get; set; }

        public Boolean EmergencyButton { get; set; }

        #endregion

        #region Method

        
        public void RunCycle()
        {
            while (true)
            {
                Car c;
                if (this.CanMove())
                {
                    c = this.Queue.FirstOrDefault();
                    if (AuthorisedDriver(CardReader(c)))
                    {
                        Console.WriteLine("Driver check OK, gate opening");
                        OpenCycle();
                        this.SafetySensor = true;
                        Thread.Sleep(3000);
                        this.SafetySensor = false;
                        CarPassed?.Invoke(c.RegistrationPlate);
                        CloseCycle();
                    }
                    else
                        Console.WriteLine("Driver non authorised");
                    Queue.Remove(c);
                }
                Thread.Sleep(2000);
            }
            
            //return message;
        }

        private void OpenCycle()
        {
            this.FullyClose = false;
            System.Threading.Thread.Sleep(5000);
            this.FullyOpen = true;
            Console.WriteLine("Gate opened");
        }

        private void CloseCycle()
        {
            if (!SafetySensor)
            {
                this.FullyOpen = false;
                System.Threading.Thread.Sleep(5000);
                this.FullyClose = true;
                Console.WriteLine("Gate closed");
            }
        }
        #endregion
        #region GetSensors
        public bool CanMove()
        {
            return GetInductiveSensor() && !(EmergencyButton || SafetySensor);
        }
        public int CardReader(Car c)
        {
            return c.DriverID;
        }

        public bool AuthorisedDriver(int ID)
        {
            return ID < 75;
        }

        public bool GetInductiveSensor()
        {
            return this.Queue.Count > 0;
        }

        public void HitEmergencyButton(Thread th)
        {
            EmergencyButton = !EmergencyButton;
            if (EmergencyButton)
            {
                Console.WriteLine("Emergency button pressed !");
                th.Suspend();
            }
            else
            {
                th.Resume();
                Console.WriteLine("Emergency resolved, door's task is resuming");
            }      
        }
        #endregion
        
        public Gate()
        {
            this.FullyClose = true;
            this.FullyOpen = false;
            this.EmergencyButton = false;
            this.SafetySensor = false;
        }
    }
}