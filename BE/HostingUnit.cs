using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class HostingUnit
    {
        private int MyHostingUnitKey;
        private Host MyOwner;
        private string MyHostingUnitName;
        private bool[,] MyDiary;
        private BE.Area Myarea;
        public override string ToString() { return "\nHostingUnit Key: " + HostingUnitKey + "\nHostingUnit Name: " + HostingUnitName + " \nArea: " + Area; }
        //--------------PROPERTIES-----------------------------------------------
        public int HostingUnitKey
        {
            get { return MyHostingUnitKey; }
            set { MyHostingUnitKey = value; }
        }
        public Host Owner
        {
            get { return MyOwner; }
            set { MyOwner = value; }
        }
        public string HostingUnitName
        {
            get { return MyHostingUnitName; }
            set { MyHostingUnitName = value; }
        }
        public bool[,] Diary{ get => MyDiary; set => MyDiary = value; }
        public Area Area { get => Myarea; set => Myarea = value; }

    }
}
