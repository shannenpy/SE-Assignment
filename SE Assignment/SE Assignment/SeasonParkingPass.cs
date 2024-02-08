using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    interface SeasonParkingPass
    {
        Vehicle Vehicle { get; set; }
        int PassID { get; set; }
        void setVehicle(Vehicle v);
        void setParkingStatus(string s);
        string getParkingStatus();
        void setValidityStatus(string s);
        string getValidityStatus();
        string ParkStatus { get; set; }
        string ValidityStatus { get; set; }
        int generatePassID();
    }
}
