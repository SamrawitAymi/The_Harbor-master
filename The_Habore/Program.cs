using System;
using System.Collections.Generic;
using System.Linq;
using The_Harbor;


namespace The_Harbor
{
    class Program
    {
        private static int _dayCounter = 0;
        private static readonly Harbor _harbor = new Harbor();
        private static Queue<BoatBase> _boatsInLine = new Queue<BoatBase>();
        private static readonly BoatCreator _boatCreator = new BoatCreator();
        
        static void Main()
        {
            do
            {
                _dayCounter++;


                if (_dayCounter > 1)
                    _harbor.NoOfDaysTheBoatHasLeftInHarborUpdate(); //Deletes the boats that have 0 days left in Harbor

                _boatsInLine = _boatCreator.CreateBoats(5);

                _harbor.SetBoatInDock(_boatsInLine);

             
                Console.Clear();
                Console.WriteLine($"\tDag: {_dayCounter}\n");
                Console.WriteLine("\tHamnplats\t\tBåttyp\t\tBåt-ID\t\tDagar kvar till avfärd\n");
        
                for (int i = 0; i < _harbor.BoatsInHarbor.Count; i++)
                {
                    var boat = _harbor.BoatsInHarbor[i];
                    if (_harbor.BoatsInHarbor[i].NoOfDaysTheBoatHasLeftInHarbor > 0)
                        Console.WriteLine($"\t{i + 1}\t\t\t{boat.BoatType}\t{boat.ID}\t\t\t{boat.NoOfDaysTheBoatHasLeftInHarbor}");
                    else
                        Console.WriteLine($"\t{i + 1}");
                }

                var boatsDismissed = _boatsInLine.Count();
                var FreeDocksInHarbor = _harbor.FreeDocksInHarbor();

                Console.WriteLine($"\n\tAntalet båtar som ej fick plats idag: {boatsDismissed}\n\n\tLediga båtplatser: {FreeDocksInHarbor}\r\n");
                Console.ReadKey();
            } while (true);

        }
    }
}
