using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    abstract class SeasonParkingPass
    {
        public abstract Vehicle Vehicle { get; set; }
        public abstract int PassID { get; set; }
        public abstract void setVehicle(Vehicle v);
        public abstract void setParkingStatus(string s);
        public abstract string getParkingStatus();
        public abstract void setValidityStatus(string s);
        public abstract string getValidityStatus();
        public abstract string ParkStatus { get; set; }
        public abstract string ValidityStatus { get; set; }
        public abstract int LatestPassID { get; set; }
        public abstract int generatePassID();
        public abstract string passType();

    }
}
