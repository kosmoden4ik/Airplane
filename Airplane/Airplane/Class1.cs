using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airplane
{
    class Airplane
    {
        public int Capacity { get; private set; }
        public bool AutoPilotOn { get; set; }
        public void airplaneTeroristWin()
        {
            while (Altitude != -1)
            {
                --Altitude;
            }
            Console.WriteLine("++++++Alah-akbar++++++");
        }
        /// <summary>
        /// Fuel consuption. kg/km
        /// </summary>
        public float Consuption { get; private set; }

        public int Altitude { get; private set; }


        public static decimal TicketPrice { get; set; }
        public static int MinAltitudeAuto { get; set; }
        public static int MaxAltitudeAuto { get; set; }

        private int _altitudeIncrement;

        public Airplane(int capacity, float consuption, int altitudeIncrement)
        {
            Altitude = 0;
            AutoPilotOn = false;
            Capacity = capacity;
            Consuption = consuption;
            _altitudeIncrement = altitudeIncrement;
        }

        public int Climb(int increment)
        {
            if (!AutoPilotOn) return Altitude += increment;

            if (Altitude + increment < MaxAltitudeAuto)
            {
                return Altitude += increment;
            }

            return Altitude = MaxAltitudeAuto;
        }

        public int Down(int increment)
        {
            if (AutoPilotOn)
            {
                if (Altitude - increment > MinAltitudeAuto)
                {
                    return Altitude -= increment;
                }
                if (Altitude < MinAltitudeAuto) return Altitude;
                return Altitude = MinAltitudeAuto;
            }

            if (Altitude - increment < 0) return Altitude = 0;
            return Altitude -= increment;
        }

        public void SetAltitude(int targetAlitude)
        {
            if (targetAlitude > Altitude && AutoPilotOn == false)
            {
                while (Altitude != targetAlitude)
                {
                    Climb(1);
                }
            }
            if (targetAlitude < Altitude && AutoPilotOn == false)
            {

                while (Altitude != targetAlitude)
                {
                    Down(1);
                }
            }
            if (targetAlitude < Altitude && AutoPilotOn == true)
            {

                while (Altitude != targetAlitude && MinAltitudeAuto < Altitude)
                {
                    Down(1);
                }
            }
            if (targetAlitude > Altitude && AutoPilotOn == true)
            {
                while (Altitude != targetAlitude && MaxAltitudeAuto > Altitude)
                {
                    Climb(1);
                }
            }
        }
    }

}
