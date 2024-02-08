using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class Carpark
    {
        private int carparkNo { get; set; }
        private string description { get; set; }
        private string location { get; set; }
        private double perMinuteRate { get; set; }

        public Carpark(int carparkNo, string description, string location, double perMinuteRate)
        {
            this.carparkNo = carparkNo;
            this.description = description;
            this.location = location;
            this.perMinuteRate = perMinuteRate;
        }
    }
}
