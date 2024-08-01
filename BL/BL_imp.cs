
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Configuration;
using BE;

namespace BL
{
    public class BL_imp : IBL
    {
        
        DAL.Idal d = DAL.FactoryDal.GetDal();
        private static IBL instance = null;
        /// <summary>
        /// the function returns instance of BL
        /// </summary>
        /// <returns> AN INSTANCE OF BL</returns>
        public static IBL GetMyBL()
        {
            if (instance == null)
                instance = new BL_imp();
            return instance;
        }
        private BL_imp()
        { }
        /// <summary>
        /// the function returns list of orders
        /// </summary>
        /// <returns>a list of orders</returns>
        public List<BE.Order> GetOrder()
        {
            return d.GetOrder();
        }
        /// <summary>
        /// the function returns a list of bank
        /// </summary>
        /// <returns>a list of bank</returns>
        public List<BE.BankBranch> GetBank()
        {
          return d.GetBank();
        }
        /// <summary>
        /// the function returns a list of request
        /// </summary>
        /// <returns>return list of request</returns>
        public List<BE.GuestRequest> GetRequest(Func<GuestRequest, bool> predicat = null)
        {
            return d.GetRequest(predicat);
        }
        /// <summary>
        /// the function returns a list of host units
        /// </summary>
        /// <returns>a list of host units</returns>
        public List<BE.HostingUnit> GetHostUnit()
        {
            return d.GetHostUnit();
        }
        public List<BE.Host> GetHost()
        {
            return d.GetHost();
        }
        /// <summary>
        /// helping function which checks if the first date is before the second date
        /// </summary>
        /// <param name="start">the first date</param>
        /// <param name="end">the second date</param>
        /// <returns>return true if the first date is before the second else return false</returns>
        public bool CheckFirstEnd(DateTime start, DateTime end)
        {
            if (start < end)
                return true;
            return false;
        }
        /// <summary>
        ///the function adds a client request and checking if the entry date is before the release date at least one
        /// </summary>
        /// <param name="gr">an instance of guest request</param>
        public void AddClientRequest(BE.GuestRequest gr)
        {
            if (CheckFirstEnd(gr.EntryDate, gr.ReleaseDate))
               d.AddClientRequest(gr);
            else
                throw new Exception("wrong dates");
        }

        /// <summary>
        /// the function deletes host uint
        /// </summary>
        /// <param name="hu">an object of hosting unit</param>
        public void DeleteHostUnit(BE.HostingUnit hu)
        {
            bool flag = false;
            foreach (BE.HostingUnit st in DS.DataSource.hostingUnit)
            {
                if (st.HostingUnitKey == hu.HostingUnitKey)
                {
                    foreach (BE.Order s in DS.DataSource.order)
                    {
                        if (hu.HostingUnitKey == s.HostingUnitKey)
                        {
                            if (s.Status == BE.OrderStatus.not_yet_handel)
                            {
                                flag = true;
                                throw new Exception("אין אפשרות למחוק כיוון שקיים דרישות במאגר");
                            }
                        }
                    }
                }
            }
            if (!flag)
            {
                d.DeleteHostUnit(hu);

            }
            else
                throw new DAL.DoesntExist(hu, "hosting unit doesnt exist");
        }
        /// <summary>
        /// the function adds host unit to the database
        /// </summary>
        /// <param name="hu">an object of host unit</param>
        public void AddHostUnit(BE.HostingUnit hu)
        {
           d.AddHostUnit(hu);
        }
        /// <summary>
        /// the function updates host unit 
        /// </summary>
        /// <param name="hu">an instance of host unit</param>
        public void UpdateHostUnit(BE.HostingUnit hu)
        {
            //bool flag = false;
            int count = 0;
            foreach (BE.HostingUnit st in DS.DataSource.hostingUnit)
            {
                if (st.HostingUnitKey == hu.HostingUnitKey)
                {
                    DS.DataSource.hostingUnit[count].HostingUnitName = hu.HostingUnitName;
                    DS.DataSource.hostingUnit[count].Owner = hu.Owner;
                    DS.DataSource.hostingUnit[count].Area = hu.Area;
                    DS.DataSource.hostingUnit[count].Diary = hu.Diary;
                }
                count++;
            }
            //DeleteHostUnit(hu);
            //AddHostUnit(hu);
        }
        /// <summary>
        /// the function adds an order to the database
        /// </summary>
        /// <param name="or">an instance of order</param>
        public void AddOrder(BE.Order or)
        {
                            
            int dateStart1, mon,l;
            bool b = true;
            foreach (BE.HostingUnit hu in DS.DataSource.hostingUnit)
                if (hu.HostingUnitKey == or.HostingUnitKey)
                {
                    foreach (BE.GuestRequest gr in DS.DataSource.guestRequest)
                    {
                        if (gr.GuestRequestKey == or.GuestRequestKey)
                        {
                            dateStart1 = gr.EntryDate.Day;
                            dateStart1 -= 1;
                            mon = gr.EntryDate.Month;
                            mon = mon - 1;
                            l = (gr.ReleaseDate - gr.EntryDate).Days;
                            for (int j = 0; j < l; j++)
                            {
                                if(mon == 2)
                                    if(dateStart1==29)
                                if (hu.Diary[dateStart1, mon] == true)
                                    b=false;
                                dateStart1++;
                                if (dateStart1 == 31)
                                {
                                    mon++;
                                    dateStart1 = 0;
                                }

                            }
          
                        }
                    }
                }
            if (b)
            {
                d.AddOrder(or);
            }
            else
                throw new Exception("cant be added");
            
        }
        /// <summary>
        /// the function updates the guest requests
        /// </summary>
        /// <param name="gr">an instance of guestsrequest</param>
        public void UpdateRequest(BE.GuestRequest gr)
        {
            try
            {
                d.UpdateRequest(gr);
            }
            catch(Exception ex)
            {
                throw new Exception(ex+"");
            }
            
        }
        /// <summary>
        /// the function updates the order
        /// </summary>
        /// <param name="or">an order to update</param>
        public void UpdateOrder(BE.Order or)
        {
            foreach (BE.Order st in DS.DataSource.order)
            {
                if (st.OrderKey == or.OrderKey)
                {
                    if (or.Status == BE.OrderStatus.send_mail)
                        setStatus(st);
                    d.UpdateOrder(or);
                }
                    
            }
        }
        //public void FinalDeal(BE.Order order, BE.OrderStatus status)
        //{
        //    if (status == BE.OrderStatus.send_mail)
        //    {
        //        setStatus(order);
        //    }
        //}
        public void setStatus(BE.Order order)
        {
            foreach (BE.HostingUnit st in DS.DataSource.hostingUnit)
            {
                if (order.HostingUnitKey == st.HostingUnitKey)
                {
                    foreach (BE.Host h in DS.DataSource.host)
                    {
                         if(st.Owner.HostKey == h.HostKey&&h.CollectionClearance)
                         {
                                if (order.Status == BE.OrderStatus.send_mail)
                                    throw new Exception("invalid order");
                                else
                                {
                                    order.Status = BE.OrderStatus.send_mail;
                                    
                                    order.OrderDate = DateTime.Today;
                                    foreach (BE.GuestRequest gr in DS.DataSource.guestRequest)
                                    {
                                        if (gr.GuestRequestKey == order.GuestRequestKey)
                                        {
                                            order.SumOfFee += ((BE.Configuration.stCommission) * ((gr.ReleaseDate - gr.EntryDate).Days));
                                            FillDiary(st.Diary, gr.EntryDate, gr.ReleaseDate);
                                            gr.Status = false;
                                            sendMail(h, st, gr);
                                            Console.WriteLine(order);
                                            foreach (BE.Order or in DS.DataSource.order)
                                            {
                                                if (or.GuestRequestKey == gr.GuestRequestKey)
                                                    or.Status = BE.OrderStatus.close_from_responde;
                                            }
                                        }
                                    }
                                }

                        }
                    }

                }
            }
        }
        public void sendMail(BE.Host h, BE.HostingUnit hu,GuestRequest gr)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(gr.MailAddress);
            mail.From = new MailAddress("tzimerLinoyShira@gmail.com");
            mail.Subject = "closing a deal";//נושא ההודעה
            string body = "hello,\n\n"+gr.PrivateName+" "+gr.FamilyName +"\n" + hu.ToString() + "\nto close the deal please send yes\n";
            mail.Body = "Host";
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential("tzimerLinoyShira@gmail.com", "@tzimer1234");
            smtp.EnableSsl = true;
            try
            {
                //שליחת ההודעה
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                //תפיסה וטיפול בשגיאות
                throw new Exception(ex.ToString());
            }
        }
        /// <summary>
        /// the function calculates the number orders of guest request
        /// </summary>
        /// <param name="gr">an object of guestRequest</param>
        /// <returns>returns the number orders of guest request</returns>
        public int NumOrderByRequest(BE.GuestRequest gr)
        {
            int count = 0;
            foreach (BE.Order or in DS.DataSource.order)
            {
                if (or.GuestRequestKey == gr.GuestRequestKey)
                    count++;
            }
            return count;
        }
        /// <summary>
        /// the function calaulates the number of orders by hosting unit 
        /// </summary>
        /// <param name="hu">an object of hostingUnit</param>
        /// <returns>returns the number of orders by hosting unit </returns>
        public int NumOfOrderByHostingUnit(BE.HostingUnit hu)
        {
            int count = 0;
            foreach (BE.Order or in DS.DataSource.order)
            {
                if (or.HostingUnitKey == hu.HostingUnitKey)
                {
                    if (or.Status == BE.OrderStatus.send_mail || or.Status == BE.OrderStatus.close_from_responde)
                        count++;
                }
            }
            return count;
        }
        /// <summary>
        /// the function grouping a list of guest request by area
        /// </summary>
        /// <param name="a">an object of area</param>
        /// <returns>a list of guestRequest by area</returns>
        public IEnumerable<BE.GuestRequest> RequestByArea(BE.Area a)
        {
            IEnumerable<BE.GuestRequest> guestRe = from BE.GuestRequest gr in DS.DataSource.guestRequest
                                                   where gr.Area == a
                                                   select gr;
            return guestRe;
        }
        /// <summary>
        /// the function is grouping a list of guestRequest by num of guest
        /// </summary>
        /// <param name="num">an integer num of guest</param>
        /// <returns>a list of guestRequest by num of guests</returns>
        public IEnumerable<BE.GuestRequest> RequestByNumGuest(int num)
        {
            IEnumerable<BE.GuestRequest> guestRe = from BE.GuestRequest gr in DS.DataSource.guestRequest
                                                   where gr.Adults + gr.Children == num
                                                   select gr;
            return guestRe;
        }
        /// <summary>
        /// the function groups a list of host by sum of hostunit
        /// </summary>
        /// <param name="num">sum of host</param>
        /// <returns>a list of host</returns>
        public IEnumerable<BE.Host> HostByHostingUnit(int num)
        {
            IEnumerable<BE.Host> groupH = from BE.Host h in DS.DataSource.host
                                          where SumOfHost(h)==num
                                          select h;

            return groupH;
        }
        /// <summary>
        /// the function calculates the sum of hosting unit for every host
        /// </summary>
        /// <param name="h">an instance of host</param>
        /// <returns>sum of hostingunit</returns>
        public int SumOfHost(Host h)
        {
            int sum = 0;
            foreach (BE.HostingUnit hu in DS.DataSource.hostingUnit)
                    if (hu.Owner.HostKey == h.HostKey)
                        sum++;
            return sum;
        }
        /// <summary>
        /// the function fills dates orders to the diary
        /// </summary>
        /// <param name="arr">diary</param>
        /// <param name="date1">an entry date</param>
        /// <param name="date2">a release date</param>
       public void FillDiary(bool[,] arr, DateTime date1, DateTime date2)
        {
            int dateStart = date1.Day;
            dateStart -= 1;
            int mon = date1.Month;
            mon = mon - 1;
            int l = (date2 - date1).Days;
            for (int j = 0; j < l; j++)
            {
                if(mon==1)
                {
                    if (dateStart == 29)
                    {
                        mon++;
                        dateStart = 0;
                    }
                }
                if (dateStart == 30)
                {
                    mon++;
                    dateStart = 0;
                }
                arr[dateStart,mon] = true;
                dateStart++;
            }
        }
        /// <summary>
        /// the function groups hostingunit by area
        /// </summary>
        /// <param name="a">area</param>
        /// <returns>a grouping of hosting units</returns>
        public IEnumerable<BE.HostingUnit> GroupingHostingUnitByArea(BE.Area a)
        {
            IEnumerable<BE.HostingUnit> gH= from BE.HostingUnit h in DS.DataSource.hostingUnit
                                            where h.Area == a
                                            select h;
            return gH;
        }
        /// <summary>
        /// the function groups hosting units by aviable dates
        /// </summary>
        /// <param name="d1">entry date</param>
        /// <param name="l">the length of vacation</param>
        /// <returns></returns>
        public List<HostingUnit> AvailableHostUnit(DateTime d1, int l)
        {
            List<HostingUnit> listHostUnit = new List<HostingUnit>();
            foreach (BE.HostingUnit st in DS.DataSource.hostingUnit)
            {
                if (IsAvailable(st.Diary, d1, l))
                    listHostUnit.Add(st);
            }
            return listHostUnit;
        }
        /// <summary>
        /// the function checks if the date is aviable in the diary
        /// </summary>
        /// <param name="arr">diary</param>
        /// <param name="d1">entry date</param>
        /// <param name="l">the length of vacation</param>
        /// <returns></returns>
        public bool IsAvailable(bool[,] arr, DateTime d1, int l)
        {
            int dateStart1 = d1.Day;
            dateStart1 -= 1;
            int dateStart2 = dateStart1;
            int mon = d1.Month;
            mon = mon - 1;
            int mon2 = mon;

            for (int j = 0; j < l; j++)
            {
                if (arr[mon, dateStart1] == true)
                    return false;
                dateStart1++;
                if (dateStart1 == 31)
                {
                    mon2++;
                    dateStart1 = 0;
                }

            }

            return true;
        }
        /// <summary>
        /// the function calculates the sum of dates between the date of today and the current date
        /// </summary>
        /// <param name="d1">date</param>
        /// <returns>sum of dates</returns>
        public int SumDays(DateTime d1)
        {
            DateTime d = DateTime.Today;
            return SumDays(d1, d);
        }
        /// <summary>
        /// the function calculates the sum of dates between the two dates
        /// </summary>
        /// <param name="d1">date</param>
        /// /// <param name="d2">date</param>
        /// <returns>sum of dates</returns>
        public int SumDays(DateTime d1, DateTime d2)
        {
            return Math.Abs((d2 - d1).Days);
        }
        /// <summary>
        /// the function return a list of orders by sum days
        /// </summary>
        /// <param name="sumD">sun days</param>
        /// <returns></returns>
        public List <Order> FindOrderBy(int sumD)
        {
            List<Order> or = new List<Order>();
            foreach (BE.Order st in DS.DataSource.order)
            {
                if (SumDays(st.OrderDate) >= sumD || SumDays(st.CreateDate) >= sumD)
                    or.Add(st);
            }
            return or;
        }
        public int FindGR(string name)
        {
          return  d.FindGR(name);
        }
        public int FindUnit(string name)
        {
           return d.FindUnit(name);
        }

    }
}
