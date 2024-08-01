using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class BankBranch
    {
        private int MyBankNumber;
        private string MyBankName;
        private int MyBranchNumber;
        private string MyBranchAddress;
        private string MyBranchCity;
        public override string ToString()  { return "\nBankNumber:" + BankNumber + "\nBankName:" + BankName + "\nBranchNumber:" + BranchNumber + "\nBranchAddress:" + BranchAddress+ "\nBranchCity:"+ BranchCity; }
        //------PROPERTIES-------

            /// <summary>
            /// bank number
            /// </summary>
        public int BankNumber
        {
            get { return MyBankNumber; }
            set { MyBankNumber = value; }
        }
        /// <summary>
        /// name of bank
        /// </summary>
        public string BankName
        {
            get { return MyBankName; }
            set { MyBankName = value; }
        }
        /// <summary>
        /// the number of branch bank
        /// </summary>
        public int BranchNumber
        {
            get { return MyBranchNumber; }
            set { MyBranchNumber = value; }
        }
        /// <summary>
        /// the adress of branch number
        /// </summary>
        public string BranchAddress
        {
            get { return MyBranchAddress; }
            set { MyBranchAddress = value; }
        }
        /// <summary>
        /// the city of branch bank
        /// </summary>
        public string BranchCity
        {
            get { return MyBranchCity; }
            set { MyBranchCity = value; }
        }
    }
}
