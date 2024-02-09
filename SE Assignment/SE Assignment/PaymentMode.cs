using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class PaymentMode
    {
        public string mode { get; private set; }
        public int cardNo { get; private set; }
        private List<Application> applicationList;


        public PaymentMode(string mode, int cardNo)
        {
            this.mode = mode;
            this.cardNo = cardNo;
        }
    }
}
