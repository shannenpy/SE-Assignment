﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class Daily : SeasonParkingPass
    {
        public override string passType()
        {
            return "d";
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

        public Daily(Vehicle v, int id)//originally parking pass have parkStatus, exited and validityStatus, valid
        {
            Vehicle = v;
            PassID = id;
            ParkStatus = "exited";
            ValidityStatus = "valid";
            LatestPassID = 1;
        }
        
        
        




    }
}
