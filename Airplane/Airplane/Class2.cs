using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirCompany
{
    class Boing: Airplane
    {

        public Boing(int capacity, float consuption, int altitudeIncrement):base(capacity, consuption, altitudeIncrement)
        {
            Altitude = 0;
            AutoPilotOn = false;
            Capacity = capacity;
            Consuption = consuption;
            _altitudeIncrement = altitudeIncrement;
            Console.WriteLine("Welcome");
        }
        protected override int Climb(int increment)
        {
            if (Forsage == true) increment *= 3;
            if (Forsage == false) increment = 1;
            if (!AutoPilotOn) return Altitude += increment;

            if (Altitude + increment < MaxAltitudeAuto)
            {
                return Altitude += increment;
            }
            //  .Console.Console.WriteLine("Невозможно на"
            return Altitude = MaxAltitudeAuto;
        }
    }
}
