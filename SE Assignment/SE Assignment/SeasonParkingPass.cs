using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    abstract class SeasonParkingPass
    {
        Vehicle Vehicle { get; set; }
        private int passId { get; set; }
        public int PassId { get; set; }
        void setVehicle(Vehicle v);
        void setParkingStatus(string s);
        string getParkingStatus();
        void setValidityStatus(string s);
        string getValidityStatus();
        string ParkStatus { get; set; }
        int generatePassID();
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        private string validityStatus { get; set; }
        public string ValidityStatus { get; set; }
        public abstract string PassType { get; set; }
        private string terminationReason { get; set; }
        public string TerminationReason { get; set; }

        public SeasonParkingPass(int PassId, string ValidityStatus, string PassType )
        {
            this.passId = PassId;
            this.validityStatus = ValidityStatus;
            this.PassType = PassType;
        }

        //private int PassId { get; set; }
        //private string parkStatus { get; set; }
        //private string validityStatus { get; set; }
        //private int latestPassID { get; set; }
        //private DateTime StartDate { get; set; }
        //private DateTime EndDate { get; set; }

        //public SeasonParkingPass(int passId,  string parkStatus, string validityStatus, int latestPassID, DateTime StartDate, DateTime EndDate)
        //{
        //    this.PassId = passId; 
        //    this.parkStatus = parkStatus; 
        //    this.validityStatus = validityStatus;
        //    this.latestPassID = latestPassID;
        //    this.StartDate = StartDate;
        //    this.EndDate = EndDate;
        //}

        //public void generatePassId()
        //{

        //}

    }
}
