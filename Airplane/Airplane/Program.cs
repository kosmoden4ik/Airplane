using System;

namespace AirCompany
{
    class Program
    {
        static void Main(string[] args)
        {
           Console.WriteLine("App started");
 Boing airplane = new Boing(140, 2.26F, 100);
           Boing.MaxAltitudeAuto = 10000;
           Boing.MinAltitudeAuto = 2000;
           airplane.logick();
           Console.ReadLine();
    AN biplan = new AN(140, 2.26F, 100);
    AN.MaxAltitudeAuto = 16000;
    AN.MinAltitudeAuto = 10;
            biplan.logick();
        }
    }

}