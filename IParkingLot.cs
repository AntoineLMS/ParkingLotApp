using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApp
{
    interface IParkingLot
    {
        void InitEntryGate();
        void InitExitGate();

        void AddVehicule(string plate);

        void RemoveVehicule(string plate);

        string ToString();

    }
}
