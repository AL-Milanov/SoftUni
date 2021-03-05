using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    interface ICheck
    {
        public bool CanDrive(double distance);

        public string CanRefillFuel(double liters);

    }
}
