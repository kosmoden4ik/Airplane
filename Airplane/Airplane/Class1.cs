using System;

namespace AirCompany
{
     abstract class  Airplane
    {
        public int Capacity { get; protected set; }
        public bool AutoPilotOn { get; set; }
        public void airplaneTeroristWin()
        {
            while (Altitude != -1)
            {
                --Altitude;
            }
            Console.WriteLine("Alah-akbar");
        }
        /// <summary>
        /// Fuel consuption. kg/km
        /// </summary>
        public float Consuption { get; protected set; }

        public int Altitude { get; protected set; }


        public static decimal TicketPrice { get; set; }
        public static int MinAltitudeAuto { get; set; }
        public static int MaxAltitudeAuto { get; set; }

        protected int _altitudeIncrement;
        public bool Forsage = false;//форсаж выключен
        public Airplane(int capacity, float consuption, int altitudeIncrement)
        {
            Altitude = 0;
            AutoPilotOn = false;
            Capacity = capacity;
            Consuption = consuption;
            _altitudeIncrement = altitudeIncrement;
        }
         public void logick()
        {
            string menu;
            bool Q = false;
            while (Q != true)
            {
                Console.WriteLine("Введите команду:\n A= - Ввод высоты\n Auto=1 - автопилот активирован");
                Console.WriteLine("F=1 форсаж активирован\n");
                Console.WriteLine("Q - для выхода\n");
                menu = Console.ReadLine();
                if (string.Compare(menu, "Q") == 0) return;
                if (string.Compare(menu, "q") == 0) return;
                string[] menu_x = menu.Split('=');
                switch (menu_x[0])
                {
                    case "A":
                        int Alt = Convert.ToInt32(menu_x[1]);
                        SetAltitude(Alt);
                        Console.WriteLine("Набрана высота - {0}", Altitude);
                        break;
                    case "Print":
                        Console.WriteLine("Текущая высота - {0}", Altitude);
                        break;
                    case "F":
                        Alt = Convert.ToInt32(menu_x[1]);
                        if (Alt == 1)
                        {
                            Forsage = true;
                            Console.WriteLine("Форсаж включен");
                        }
                        else if (Alt == 0)
                        {
                            Forsage = false;
                            Console.WriteLine("Форсаж выключен");
                        }
                        else Console.WriteLine("Error");

                        break;
                    case "Auto":
                        Alt = Convert.ToInt32(menu_x[1]);
                        if (Alt == 1)
                        {
                            AutoPilotOn = true;
                            Console.WriteLine("Автопилот включен");
                        }
                        else if (Alt == 0)
                        {
                            AutoPilotOn = false;
                            Console.WriteLine("Автопилот выключен");
                        }
                        else Console.WriteLine("Error");

                        break;
                }
            }
        }
        protected virtual int Climb(int increment)
        {
            if (Forsage == true) increment *= 2;
            if (Forsage == false) increment = 1;
            if (!AutoPilotOn) return Altitude += increment;

            if (Altitude + increment < MaxAltitudeAuto)
            {
                return Altitude += increment;
            }
            //  .Console.Console.WriteLine("Невозможно на"
            return Altitude = MaxAltitudeAuto;
        }

        protected virtual int Down(int increment)
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

        protected void SetAltitude(int targetAlitude)
        {
            if (targetAlitude > Altitude && AutoPilotOn == false)
            {
                while (Altitude <= targetAlitude)
                {
                    Climb(1);
                    if (Altitude == (targetAlitude - 1) && Forsage == true)
                    {
                        Forsage = false;//Выключаем форсаж
                        break;

                    }

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
                if (targetAlitude < MinAltitudeAuto) Console.WriteLine("Невозможно снизить высоту до - {0} " +
                     "в режиме автопилота", targetAlitude);
            }
            if (targetAlitude > Altitude && AutoPilotOn == true)
            {
                while (Altitude != targetAlitude && MaxAltitudeAuto > Altitude)
                {
                    Climb(1);
                }
                if (targetAlitude > MaxAltitudeAuto) Console.WriteLine("Невозможно набрать высоту до - {0} в" +
                "режиме автопилота", targetAlitude);
            }
        }
    }
}