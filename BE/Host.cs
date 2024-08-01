using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class Host
    {
        private string MyHostKey;
        private string MyPrivateName;
        private string MyFamilyName;
        private string MyFhoneNumber;
        private string MyMailAddress;
        private BankBranch MyBankBranchDetails;
        private int MyBankAccountNumber;
        private bool MyCollectionClearance;
        private int Mypass;
        public override string ToString()   { return "\nHostKey" + HostKey + "\nPrivateName" + PrivateName + "\nFamilyName" + FamilyName + "\nFhoneNumber" + FhoneNumber + "\nMailAddress" + MailAddress + "\nBankBranchDetails" + BankBranchDetails + "\nCollectionClearance" + CollectionClearance; }
        //----------------PROPERTIES----------------------------------------------------------
        public string HostKey
        {
            get { return MyHostKey; }
            set { MyHostKey = value; }
        }
        public int Pass
        {
            get { return Mypass; }
            set { Mypass = value; }
        }
        public string PrivateName
        {
            get { return MyPrivateName; }
            set { MyPrivateName = value; }
        }
        public string FamilyName
        {
            get { return MyFamilyName; }
            set { MyFamilyName = value; }
        }
        public string FhoneNumber
        {
            get { return MyFhoneNumber; }
            set { MyFhoneNumber = value; }
        }
        public string MailAddress
        {
            get { return MyMailAddress; }
            set { MyMailAddress = value; }
        }
        public BankBranch BankBranchDetails
        {
            get { return MyBankBranchDetails; }
            set { MyBankBranchDetails = value; }
        }
        public int BankAccountNumber
        {
            get { return MyBankAccountNumber; }
            set { MyBankAccountNumber = value; }
        }
        public bool CollectionClearance
        {
            get { return MyCollectionClearance; }
            set { MyCollectionClearance = value; }
        }

    }
}
