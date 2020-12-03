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
        public double SpaceTakenInHarbor { get; set; }
        public string SuperFeature { get; set; }
    }

    public class SpeedBoat : BoatBase
    {
      
    }

    public  class SailBoat : BoatBase
    {
       
    }

    public class CargoShip : BoatBase
    {
      
    }

    public class RowingBoat : BoatBase
    {

    }


}
