using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class Daily : SeasonParkingPass
    {
        private string parkStatus;
        private int latestPassID;
        private Vehicle vehicle;

        public override string PassType { get; set; } = "d";

        public Daily(/*Vehicle v,*/ int id, string validityStatus, string PassType):base(id, validityStatus, PassType)//originally parking pass have parkStatus, exited and validityStatus, valid
        {
            //vehicle = v;
            //parkStatus = "exited";
            this.PassType = PassType;
        }

        public string ParkStatus
        {
            get => parkStatus;
            set => parkStatus = value;

        }

        //public string ValidityStatus
        //{

        //    get => validityStatus;
        //    set => validityStatus = value;
        //}

        //public int PassID
        //{
        //    get => passID;
        //    set => passID = value;

        //}

        public int LatestPassID
        {
            get => latestPassID;
            set => latestPassID = value;
        }

        public Vehicle Vehicle
        {
            get => vehicle;
            set => vehicle = value;

        }

        public int generatePassID()
        {
            latestPassID = latestPassID + 1;
            return latestPassID;
        }

        public void setVehicle(Vehicle v)
        {
            vehicle = v;
        }

        public void setParkingStatus(string s)
        {
            parkStatus = s;

        }

        public string getParkingStatus()
        {
            if (parkStatus != null)
            {
                return parkStatus;
            }
            else
            {
                return string.Empty;
            }

        }

        public void setValidityStatus(string s)
        {
            validityStatus = s;

        }

        public string getValidityStatus()
        {
            if (validityStatus != null)
            {
                return validityStatus;
            }
            else
            {
                return string.Empty;
            }
        }


        //private float dailyRate { get; set; }
        //private float fixedAmount { get; set; }

        //public Daily(int passId, string parkStatus, string validityStatus, int latestPassID, float dailyRate, float fixedAmount) : base(passId, parkStatus, validityStatus, latestPassID)
        //{
        //    this.dailyRate = dailyRate;
        //    this.fixedAmount = fixedAmount;
        //}

        //public bool refund() { return false; }
    }
}
