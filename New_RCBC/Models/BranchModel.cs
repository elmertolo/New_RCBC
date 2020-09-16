﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_RCBC.Models
{
    class BranchModel
    {
        private string returnBlankIfNull(string _input)
        {
            if (_input == null)
                return " ";
            else
                return _input;
        }

        public string BRSTN { get; set; }
        //public string BranchName { get; set; }
        private string _address1;
        public string Address1
        {
            get
            {
                return (returnBlankIfNull(_address1));
            }
            set { _address1 = value; }
        }
        private string _address2;
        public string Address2
        {
            get
            {
                return (returnBlankIfNull(_address2));
            }
            set { _address2 = value; }
        }
        private string _address3;
        public string Address3
        {
            get
            {
                return (returnBlankIfNull(_address3));
            }
            set { _address3 = value; }
        }
        private string _address4;
        public string Address4
        {
            get
            {
                return (returnBlankIfNull(_address4));
            }
            set { _address4 = value; }
        }
        private string _address5;
        public string Address5
        {
            get
            {
                return (returnBlankIfNull(_address5));
            }
            set { _address5 = value; }
        }
        private string _address6;
        public string Address6
        {
            get
            {
                return (returnBlankIfNull(_address6));
            }
            set { _address6 = value; }
        }
        public string Company { get; set; }
        public string BaeStock { get; set; }
        public string BranchCode { get; set; }
        public Int64 Reg_LastNo { get; set; }
        public Int64 Adv_LastNo { get; set; }
        //public Int64 Binan_LastNo { get; set; }
        public DateTime Date { get; set; }
        public Int64 MC_LastNo { get; set; }
        public Int64 MCS_LastNo { get; set; }
        public Int64 Con_LastNo { get; set; }
        public Int64 CV_LastNo { get; set; }
        public string AccountNo { get; set; }
    }
}
