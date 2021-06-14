using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApp
{
    public class Car
    {
        public string RegistrationPlate;
        public int DriverID;

        public Car(string plate, int id)
        {
            this.RegistrationPlate = plate;
            this.DriverID = id;
        }
    }
}
