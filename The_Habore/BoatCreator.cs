using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace The_Harbor
{
   public class BoatCreator
    {

        private static readonly Random _random = new Random();
        internal Queue<BoatBase> CreateBoats(int noOfBoatsToCreate)
        {
           
            Queue<BoatBase> Boats = new Queue<BoatBase>();
            for (int i = 0; i < noOfBoatsToCreate; i++)
            {
              
                int randomNumber = _random.Next(1, 5);


                if (randomNumber == 1)
                {
                     var speedBoat = CreateSpeedBoat();
                    Boats.Enqueue(speedBoat);
                }
                else if (randomNumber == 2)
                {
                    var sailBoat = CreateSailBoat();
                    Boats.Enqueue(sailBoat);
                }
                else if (randomNumber == 3)
                {
                    var cargoShip = CreateShip();
                    Boats.Enqueue(cargoShip);
                }
                else if (randomNumber == 4)
                {
                    var rowingBoat = CreateRowingBoat();
                    Boats.Enqueue(rowingBoat);
                    if (rowingBoat.SpaceTakenInHarbor == 0.5)
                    {
                        Boats.Enqueue(rowingBoat);
                    }
                }

            }

            return Boats;
        }

        private static SpeedBoat CreateSpeedBoat()
        {
          
            var speedBoat = new SpeedBoat
            {
                ID = "M-" + GenerateThreeRandomLetters(),
                BoatType = "Motorbåt",
                Weight = _random.Next(200, 3001),
                TopSpeed = _random.Next(0, 61),
                NoOfDaysTheBoatHasLeftInHarbor = 3,
                SpaceTakenInHarbor = 1,
                SuperFeature = $"Häst krafter: {_random.Next(10, 1001)}"
            };
            return speedBoat;
        }

       
        private static SailBoat CreateSailBoat()
        {
          //  Random random = new Random();
            SailBoat sailBoat = new SailBoat
            {
                ID = "S-" + GenerateThreeRandomLetters(),
                BoatType = "Segelbåt",
                Weight = _random.Next(800, 6001),
                TopSpeed = _random.Next(0, 13),
                NoOfDaysTheBoatHasLeftInHarbor = 4,
                SpaceTakenInHarbor = 2,
                SuperFeature = $"Båtens längd i fot: {_random.Next(10, 61)}"

            };

            return sailBoat;
        }

        private static CargoShip CreateShip()
        {
          
            CargoShip cargoShip = new CargoShip
            {
                ID = "F-" + GenerateThreeRandomLetters(),
                BoatType = "Fraktfartyg",
                Weight = _random.Next(3000, 20001),
                TopSpeed = _random.Next(0, 21),
                NoOfDaysTheBoatHasLeftInHarbor = 6,
                SpaceTakenInHarbor = 4,
                SuperFeature = $"Antal containers på fartyget: {_random.Next(0, 501)}"
            };

            return cargoShip;
        }

        public static RowingBoat CreateRowingBoat()
        {

            RowingBoat rowingBoat = new RowingBoat
            {
                ID = "R-" + GenerateThreeRandomLetters(),
                BoatType = "Roddbåt",
                Weight = _random.Next(100, 300),
                TopSpeed = _random.Next(0, 3),
                NoOfDaysTheBoatHasLeftInHarbor = 1,
                SpaceTakenInHarbor = 0.5,
                SuperFeature = $"Max antal passagerare: {_random.Next(0, 6)}"
            };

            return rowingBoat;
        }

        public static string GenerateThreeRandomLetters()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
           return new string (Enumerable.Repeat(chars, 3)
              .Select(s => s[_random.Next(s.Length)]).ToArray());
        }
   }
}
