using System;
using System.Collections.Generic;
using System.Text;

namespace The_Harbor
{
    public  class BoatBase
    {
        public string ID { get; set; }
        public string BoatType { get; set; }
        public int Weight { get; set; }
        public int TopSpeed { get; set; }
        public int NoOfDaysTheBoatHasLeftInHarbor { get; set; }
        public int SpaceTakenInHarbor { get; set; }
        public string SuperFeature { get; set; }
    }

    internal class SpeedBoat : BoatBase
    {
      
    }

    internal  class SailBoat : BoatBase
    {
       
    }

    internal class CargoShip : BoatBase
    {
      
    }


  
}
