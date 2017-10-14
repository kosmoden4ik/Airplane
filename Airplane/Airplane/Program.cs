using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airplane
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
        airplane.AutoPilotOn = true;
        Console.WriteLine(airplane.Altitude);
        airplane.SetAltitude(11000);
        Console.WriteLine(airplane.Altitude);
        airplane.SetAltitude(1000);
        Console.WriteLine(airplane.Altitude);
        airplane.AutoPilotOn = false;
        airplane.SetAltitude(12000);
        Console.WriteLine(airplane.Altitude);
        airplane.SetAltitude(500);
        Console.WriteLine(airplane.Altitude);
        airplane.airplaneTeroristWin();
        Console.WriteLine(airplane.Altitude);
        Console.ReadLine();

    }
}
}
