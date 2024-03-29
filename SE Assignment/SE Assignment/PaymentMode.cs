﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    class PaymentMode
    {
        private string mode { get; set; }
        private int cardNo { get; set; }
        private List<Application> applicationList;

        public string Mode
        {
            get => Mode;
            set => Mode = value;
        }

        public int CardNo
        {
            get => CardNo;
            set => CardNo = value;
        }
        public PaymentMode(string mode, int cardNo)
        {
            this.mode = mode;
            this.cardNo = cardNo;
        }
    }
}
