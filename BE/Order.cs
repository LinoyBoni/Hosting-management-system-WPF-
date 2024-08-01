using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class Order
    {
        private int MyHostingUnitKey;
        private int MyGuestRequestKey;
        private int MyOrderKey;
        private BE.OrderStatus MyStatus;
        private DateTime MyCreateDate;
        private DateTime MyOrderDate;
        private int MySumOfFee;
        /// <summary>
        /// the Func return string of order
        /// </summary>
        /// <returns>string of order</returns>
        public override string ToString()
        {
            return "\nHostingUnit Key: "+ HostingUnitKey+ "\nGuestRequest Key: "+ GuestRequestKey+ "\nOrder Key: "+OrderKey+ "\nCreateDate: "+ CreateDate+ "\nOrderDate: "+ OrderDate+ "\nStatus: "+ Status+ "\nSumOfFee: "+ SumOfFee;
        }
        //------------PROPERTIES----------------------------------------------
        public int HostingUnitKey
        {
            get { return MyHostingUnitKey; }
            set { MyHostingUnitKey = value; }
        }
        public int GuestRequestKey
        {
            get { return MyGuestRequestKey; }
            set { MyGuestRequestKey = value; }
        }
        public int OrderKey
        {
            get { return MyOrderKey; }
            set { MyOrderKey = value; }
        }
        public DateTime CreateDate
        {
            get { return MyCreateDate; }
            set { MyCreateDate = value; }
        }
        public DateTime OrderDate
        {
            get { return MyOrderDate; }
            set { MyOrderDate = value; }
        }

        public OrderStatus Status { get => MyStatus; set => MyStatus = value; }
        public int SumOfFee { get => MySumOfFee; set => MySumOfFee = value; }

    }
}
