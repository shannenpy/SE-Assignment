using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class Monthly : SeasonParkingPass
    {
        public override string passType()
        {
            return "m";
        }
        private int latestPassID;
        public override int LatestPassID
        {
            get => latestPassID;
            set => latestPassID = value;
        }
        private int passID;
        public override int PassID
        {
            get => passID;
            set => passID = value;
        }
        public Monthly(Vehicle v, int id)//originally parking pass have parkStatus, exited and validityStatus, valid
        {
            Vehicle = v;
            PassID = id;
            ParkStatus = "exited";
            ValidityStatus = "valid";
            LatestPassID = 1;
        }
        


    }
}
