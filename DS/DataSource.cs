using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DS
{
    public class DataSource
    {
        public static List<BE.Host> host = new List<BE.Host>()
        {
            new BE.Host(){HostKey = "211820824", PrivateName = "linoy",FamilyName ="bony",
            FhoneNumber = "0507744481", MailAddress = "linoyboni@gmail.com", BankAccountNumber = 76688
            ,CollectionClearance = true, Pass=1234},

            new BE.Host(){HostKey = "211820832", PrivateName = "dvir",FamilyName ="bony",
            FhoneNumber = "0507744481", MailAddress = "linoyboni@gmail.com", BankAccountNumber = 76688
            ,CollectionClearance = true, Pass=4321}
        };

        public static List<BE.BankBranch> Bank = new List<BE.BankBranch>();
        public static List<BE.Order> order = new List<BE.Order>();
        public static List<BE.GuestRequest> guestRequest = new List<BE.GuestRequest>();
        public static List<BE.HostingUnit> hostingUnit = new List<BE.HostingUnit>();
    }
}
