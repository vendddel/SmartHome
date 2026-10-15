namespace SmartHome
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.Red;

            Device nappalilampa = new DimmableLight("Nappali lámpa", 75);

            Console.WriteLine(nappalilampa.GetDescription());
            nappalilampa.TurnOn();
            Console.WriteLine(nappalilampa.GetDescription());
            nappalilampa.TurnOff();
            nappalilampa.TurnOn();
            Console.WriteLine(nappalilampa.GetDescription());
            Console.WriteLine(nappalilampa.Consumption(5));

            Device furdoszobaiFutes = new Heater("Fürdőszobai fűtés", 22);
            Console.WriteLine(furdoszobaiFutes.GetDescription());
            Console.WriteLine(furdoszobaiFutes.Consumption(3));
            Console.WriteLine(Device.Count);

            furdoszobaiFutes.TurnOn();
            Console.WriteLine(furdoszobaiFutes.GetDescription());
            Console.WriteLine("----ablak nyitas----");
            ((Heater)furdoszobaiFutes).OpenWindow();
            Console.WriteLine(furdoszobaiFutes.GetDescription());
            Console.WriteLine("----nyitott ablakos turn on----");

            furdoszobaiFutes.TurnOn();
            Console.WriteLine(furdoszobaiFutes.GetDescription());
            Console.WriteLine("-----------------------HŰTŐ--------------------------------");


            //huto
            Device huto = new Fridge("Konyhai hűtő", false);
            Console.WriteLine(huto.GetDescription());
            Console.WriteLine(huto.Consumption(24));

            ((Fridge)huto).IsEcoMode = true;
            Console.WriteLine(huto.Consumption(24));

            Console.WriteLine("-----megprobalom kikapcs-----");
            huto.TurnOff();
            Console.WriteLine(huto.GetDescription());


            //8

            Console.WriteLine("-----legnagyobb fogyaszto-----");

            if (Device.MoreConsuming(furdoszobaiFutes, nappalilampa, 2) == furdoszobaiFutes)
            {
                Console.WriteLine("A furdoszobai futes fogyaszt tobbet 2 ora alatt.");
            }
            else if (Device.MoreConsuming(furdoszobaiFutes, nappalilampa, 2) == null)
            {
                Console.WriteLine("A furdoszobai futes es a nappali lampa fogyasztasa ugyanannyu 2 ora alatt.");
            }
            else
            {
                Console.WriteLine("A nappali lampa fogyaszt tobbet 2 ora alatt.");
            }


            if (Device.MoreConsuming(nappalilampa, huto, 2) == nappalilampa)
            {
                Console.WriteLine("A nappali lam fogyaszt tobbet 2 ora alatt.");
            }
            else if (Device.MoreConsuming(nappalilampa, huto, 2) == null)
            {
                Console.WriteLine("A nappali lampa es a konyhai huto fogyasztasa ugyananny2 ora alatt.");
            }
            else
            {
                Console.WriteLine("A konyhai huto fogyaszt tobbet 2 ora alatt.");
            }



            if (Device.MoreConsuming(furdoszobaiFutes, nappalilampa, 0) == furdoszobaiFutes)
            {
                Console.WriteLine("A furdoszobai futes fogyaszt tobbet 0 ora alatt.");
            }
            else if (Device.MoreConsuming(furdoszobaiFutes, nappalilampa, 0) == null)
            {
                Console.WriteLine("A furdoszobai futes meg a nappali lampa fogyasztasa ugyanannyi 0 ora alatt.");
            }
            else
            {
                Console.WriteLine("A nappali lampa fogyaszt tobbet 0 ora alatt.");
            }

            //9es felllllaaaddaaatttt

            Console.WriteLine("------------------------------------keret letrehozasa-------------------------------------------");
            EnergyMeter keret = new EnergyMeter(10000);
            keret.Run(furdoszobaiFutes, 3);
            Console.WriteLine(furdoszobaiFutes.GetDescription());
            Console.WriteLine($"maradt energia: {keret.Remaining()}");
            Console.WriteLine("-----------");


            keret.Run(huto, 24);
            Console.WriteLine(huto.GetDescription());
            Console.WriteLine($"maradt energia: {keret.Remaining()}");
            Console.WriteLine("-----------");

            keret.Run(nappalilampa, 5);
            Console.WriteLine(nappalilampa.GetDescription());
            Console.WriteLine($"maradt energia: {keret.Remaining()}");
            Console.WriteLine("-----------");


            keret.Run(furdoszobaiFutes, 3);
            Console.WriteLine(furdoszobaiFutes.GetDescription());
            Console.WriteLine($"maradt energia: {keret.Remaining()}");
            Console.WriteLine("-----------");

            keret.Run(huto, 24);
            Console.WriteLine(huto.GetDescription());
            Console.WriteLine($"maradt energia: {keret.Remaining()}");
            Console.WriteLine("-----------");

            









        }
    }
}


