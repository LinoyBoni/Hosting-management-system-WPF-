using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class GuestRequest
    {
      private string MyID;
      private int MyGuestRequestKey;
      private string MyPrivateName;
      private string MyFamilyName;
      private string MyMailAddress;
      private bool MyStatus;
      private DateTime MyRegistrationDate;
      private DateTime MyEntryDate;
      private DateTime MyReleaseDate;
      private BE.Area MyArea;
      private string MySubArea;
        //subArea
      private BE.centerArea MySubAreaCenter;
      private BE.southArea MySubAreaSouth;
      private BE.westArea MySubAreaWest;
      private BE.northArea MySubAreaNorth;
      private BE.eastArea MySubAreaEast;

      private BE.Type MyType;
      private int MyAdults;
      private int MyChildren;
      private BE.Interest MyPool;
      private BE.Interest MyJacuzzi;
      private BE.Interest MyGarden;
      private BE.Interest MyChildrensAttractions;
      public override string  ToString()
       {
            return "\nGuestRequestKey:" + GuestRequestKey
                + "\nprivate name: " + PrivateName + "\nfamily name: " + FamilyName + "\nmail adress: " + MailAddress + "\nstatus: " + Status + "\nregition date: " + RegistrationDate + "\nentry date: " + EntryDate
                + "\n release date: " + ReleaseDate + "\nArea: " + Area + "   Sub Area: " + SubArea + "\nType: " + Type + "\nnumber of Adults: " + Adults + "   number of children: " + Children + "\npool: " + Pool + "   jacuzzi: " + Jacuzzi + "   Garden: " + Garden + "\nChildren Attractions: " + ChildrensAttractions;



        }

        //-----------PROPERTIES----------------------------------------------------------------------
        public int GuestRequestKey
      {
          get { return MyGuestRequestKey; }
          set { MyGuestRequestKey = value; }
      }
        public string ID
        {
            get { return MyID; }
            set { MyID = value; }
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
      public string MailAddress
      {
          get { return MyMailAddress; }
          set { MyMailAddress = value; }
      }
      public bool Status
      {
          get { return MyStatus; }
          set { MyStatus = value; }
      }
      public DateTime RegistrationDate
      {
          get { return MyRegistrationDate; }
          set { MyRegistrationDate = value; }
      }
      public DateTime EntryDate
      {
          get { return MyEntryDate; }
          set { MyEntryDate = value; }
      }
      public DateTime ReleaseDate
      {
          get { return MyReleaseDate; }
          set { MyReleaseDate = value; }
      }
      public BE.Area Area
      {
          get { return MyArea; }
          set { MyArea = value; }
      }
      public string SubArea
      {
          get { return MySubArea; }
          set { MySubArea = value; }
      }
      public BE.Type Type
      {
          get { return MyType; }
          set { MyType = value; }
      }
      public int Adults
      {
          get { return MyAdults; }
          set { MyAdults = value; }
      }
      public int Children
      {
          get { return MyChildren; }
          set { MyChildren = value;}
      }

        public Interest Pool { get => MyPool; set => MyPool = value; }
        public Interest Jacuzzi { get => MyJacuzzi; set => MyJacuzzi = value; }
        public Interest Garden { get => MyGarden; set => MyGarden = value; }
        public Interest ChildrensAttractions { get => MyChildrensAttractions; set => MyChildrensAttractions = value; }
        public centerArea SubAreaCenter { get => MySubAreaCenter; set => MySubAreaCenter = value; }
        public southArea SubAreaSouth { get => MySubAreaSouth; set => MySubAreaSouth = value; }
        public westArea SubAreaWest { get => MySubAreaWest; set => MySubAreaWest = value; }
        public northArea SubAreaNorth { get => MySubAreaNorth; set => MySubAreaNorth = value; }
        public eastArea SubAreaEast { get => MySubAreaEast; set => MySubAreaEast = value; }
    }
}

