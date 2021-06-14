using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApp
{
    class ParkingLot : IParkingLot
    {
        public HashSet<string> plates = new HashSet<string>();

        public Gate EnGate;
        public Gate ExGate;

        public void InitEntryGate()
        {
            EnGate = new Gate();
            EnGate.CarPassed += AddVehicule;
        }

        public void InitExitGate()
        {
            ExGate = new Gate();
            ExGate.CarPassed += RemoveVehicule;
        }

        public void AddVehicule(string plate)
        {
            if (!plates.Add(plate))
                Console.WriteLine("Vehicule is already present in the Parking Lot");
            else
                Console.WriteLine("New car : " + plate + " entered the parking. Gate is closing");
        }

        public void RemoveVehicule(string plate)
        {
            if (this.plates.Contains(plate))
            {
                this.plates.Remove(plate);
                Console.WriteLine(plate + " exited the parking.");
            }
        }

        public ParkingLot()
        {
            InitEntryGate();
            InitExitGate();
        }

        override public String ToString()
        {
            string res = "";
            foreach(string s in this.plates)
            {
                res += "\n"+s;
            }
            return res;
        }
    }
}
