using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    abstract class SeasonParkingPass
    {
        public Vehicle? Vehicle { get; set; }
        public abstract int PassID { get; set; }
        public void setVehicle(Vehicle v)
        {
            Vehicle = v;
        }
        public void setParkingStatus(string s)
        {
            ParkStatus = s;
        }
        public string getParkingStatus()
        {
            if (ParkStatus != null)
            {
                return ParkStatus;
            }
            else
            {
                return string.Empty;
            }
        }
        public void setValidityStatus(string s)
        {
            ValidityStatus = s;
        }
        public string getValidityStatus()
        {
            if (ValidityStatus != null)
            {
                return ValidityStatus;
            }
            else
            {
                return string.Empty;
            }
        }
        public string ParkStatus { get; set; }
        public string ValidityStatus { get; set; }
        public abstract int LatestPassID { get; set; }
        public DateTime startMonth { get; set; }
        public DateTime endMonth { get; set; }
        public int generatePassID()
        {
            LatestPassID = LatestPassID + 1;
            return LatestPassID;
        }
        public abstract string passType();

    }
}
