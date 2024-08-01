using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public static class Cloning
    {
        public static BE.BankBranch clone(this BE.BankBranch original)
        {
            BE.BankBranch target = new BE.BankBranch();
            target.BankName = original.BankName;
            target.BankNumber = original.BankNumber;
            target.BranchAddress = original.BranchAddress;
            target.BranchCity = original.BranchCity;
            target.BranchNumber = original.BranchNumber;
            return target;
        }
        public static BE.GuestRequest clone(this BE.GuestRequest original)
        {
            BE.GuestRequest target = new BE.GuestRequest();
            target.ID = original.ID;
            target.Adults = original.Adults;
            target.Area = original.Area;
            target.Children = original.Children;
            target.EntryDate = original.EntryDate;
            target.FamilyName = original.FamilyName;
            target.GuestRequestKey = original.GuestRequestKey;
            target.MailAddress = original.MailAddress;
            target.PrivateName = original.PrivateName;
            target.RegistrationDate = original.RegistrationDate;
            target.ReleaseDate = original.ReleaseDate;
            target.Status = original.Status;
            if (target.Area == BE.Area.center)
                target.SubAreaCenter = original.SubAreaCenter;
            if (target.Area == BE.Area.east)
                target.SubAreaEast = original.SubAreaEast;
            if (target.Area == BE.Area.north)
                target.SubAreaNorth = original.SubAreaNorth;
            if (target.Area == BE.Area.south)
                target.SubAreaSouth = original.SubAreaSouth;
            if (target.Area == BE.Area.west)
                target.SubAreaWest = original.SubAreaWest;
            target.SubArea = original.SubArea;
            target.Pool = original.Pool;
            target.Jacuzzi = original.Jacuzzi;
            target.Garden = original.Garden;
            target.ChildrensAttractions = original.ChildrensAttractions;
            target.Type = target.Type;
            return target;
        }
        public static BE.Host clone(this BE.Host original)
        {
            BE.Host target = new BE.Host();
            target.BankAccountNumber = original.BankAccountNumber;
            target.BankBranchDetails = original.BankBranchDetails;
            target.FamilyName = original.FamilyName;
            target.FhoneNumber = original.FhoneNumber;
            target.HostKey = original.HostKey;
            target.MailAddress = original.MailAddress;
            target.PrivateName = original.PrivateName;
            return target;
        }
        public static BE.HostingUnit clone(this BE.HostingUnit original)
        {
            BE.HostingUnit target = new BE.HostingUnit();
            target.HostingUnitKey = original.HostingUnitKey;
            target.HostingUnitName = original.HostingUnitName;
            target.Owner = original.Owner;
            target.Diary = original.Diary;//לבדוק
            target.Area = original.Area;
            return target;
        }
        public static BE.Order clone(this BE.Order original)
        {
            BE.Order target = new BE.Order();
            target.CreateDate = original.CreateDate;
            target.GuestRequestKey = original.GuestRequestKey;
            target.HostingUnitKey = original.HostingUnitKey;
            target.OrderDate = original.OrderDate;
            target.OrderKey = original.OrderKey;
            target.SumOfFee = original.SumOfFee;
            return target;
        }
    }
        
}
