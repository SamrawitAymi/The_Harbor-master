using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace The_Harbor
{
   public class Harbor
    {
        List<BoatBase> _docksInHarbor = new List<BoatBase>();
        public Harbor()
        {
            CreateHarborDocks();
        }

        public int FreeDocksInHarbor()
        {
            return _docksInHarbor.Count(x => x.NoOfDaysTheBoatHasLeftInHarbor <= 0);
        }

        public List<BoatBase> BoatsInHarbor
        {
            get { return _docksInHarbor; }
            set { _docksInHarbor = value; }
        }

        private void CreateHarborDocks()
        {
            for (int i = 0; i < 25; i++)
                _docksInHarbor.Add(new BoatBase());
        }

        public void SetBoatInDock(Queue<BoatBase> boatsInLine)
        {
            for (int i = 0; i < _docksInHarbor.Count; i++)
            {
                if (boatsInLine.Count == 0)
                    break;

                var boat = boatsInLine.Peek();

                var startindex = i;      
                var freeDock = 0;

                while(i < _docksInHarbor.Count && _docksInHarbor[i].NoOfDaysTheBoatHasLeftInHarbor <= 0 && freeDock < boat.SpaceTakenInHarbor)
                {
                    i++;
                    freeDock++;
                }

                var stopIndex = i - 1;

                if(boat.SpaceTakenInHarbor == freeDock)
                {
                    i--;
                    AddBoatToDockInHarbor(boat, startindex, stopIndex);
                    boatsInLine.Dequeue();
                }
  
            }
        }

        public void AddBoatToDockInHarbor(BoatBase boat, int firstIndexToOccupied, int lastIndexToOccupied)
        {
            for (int i = firstIndexToOccupied; i <= lastIndexToOccupied; i++)
            {
                _docksInHarbor[i] = boat;
            }
        }

        public void NoOfDaysTheBoatHasLeftInHarborUpdate()
        {
            var boatsInHarbor = _docksInHarbor.Where(x => x.NoOfDaysTheBoatHasLeftInHarbor > 0).GroupBy(x => x.ID).ToList();
       
            foreach (var boat in boatsInHarbor)
            {
                var index = _docksInHarbor.FindIndex(x => x.ID == boat.Key);
               
                _docksInHarbor[index].NoOfDaysTheBoatHasLeftInHarbor--;
            }
        }

        



    }

}
