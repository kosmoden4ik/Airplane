using System;

namespace AirCompany
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("App started");

            Airplane.MaxAltitudeAuto = 10000;
            Airplane.MinAltitudeAuto = 2000;

            Airplane airplane = new Airplane(140, 2.26F, 100);
            //
            airplane.logick();
            //     Console.ReadLine();

        }
    }
}