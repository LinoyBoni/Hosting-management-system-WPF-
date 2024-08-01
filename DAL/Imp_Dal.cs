using System;
using System.Collections.Generic;
using System.Linq;
using BE;
using System.Text;

namespace DAL
{
    public class Imp_Dal : Idal
    {
        private static Idal instance = null;
        /// <summary>
        /// the function returns an instance of dal
        /// </summary>
        /// <returns></returns>
        public static Idal GetMyDal()
        {
            if (instance == null)
                instance = new Imp_Dal();
            return instance;
        }
        private Imp_Dal()
        {
        }

        public List<BE.Host> GetHost()
        {
            return DS.DataSource.host.Select(item => item).ToList();
        }
        /// <summary>
        /// the function adds a guestrequest
        /// </summary>
        /// <param name="gr">guestrequest</param>
        public void AddClientRequest(BE.GuestRequest gr)
        {
            BE.Configuration.stGuestRequestKey++;
            gr.GuestRequestKey = BE.Configuration.stGuestRequestKey;
            DS.DataSource.guestRequest.Add(gr.clone());
        }
        /// <summary>
        /// the function updates guestrequest
        /// </summary>
        /// <param name="gr">guestrequest</param>
        public void UpdateRequest(BE.GuestRequest gr)
        {
            bool flag = false;
            foreach (BE.GuestRequest st in DS.DataSource.guestRequest)
            {
                if (st.GuestRequestKey == gr.GuestRequestKey)
                {
                    st.Status = gr.Status;
                    flag = true;
                }    
            }
            //if (flag)
            //    AddClientRequest(gr);
            //else
            //    throw new DAL.DoesntExist(gr,"guest request doesnt exist");
            if (!flag)
                throw new DAL.DoesntExist(gr, " guest request doesnt exist");
        }
        /// <summary>
        /// the function adds a hostunit
        /// </summary>
        /// <param name="hu">hostunit</param>
        public void AddHostUnit(BE.HostingUnit hu)
        {
            BE.Configuration.stHostingUnitKey++;
            hu.HostingUnitKey = BE.Configuration.stHostingUnitKey;
            DS.DataSource.hostingUnit.Add(hu.clone()); 
        }
        /// <summary>
        /// the function deletes hostunit 
        /// </summary>
        /// <param name="hu">hostunit</param>
        public void DeleteHostUnit(BE.HostingUnit hu)
        {
            bool flag = false;
            foreach (BE.HostingUnit st in DS.DataSource.hostingUnit)
            {
                if (st.HostingUnitKey == hu.HostingUnitKey)
                {
                    DS.DataSource.hostingUnit.Remove(st);
                    flag = true;
                    break;
                }
            }
            if (!flag)
                throw new DAL.DoesntExist(hu,"the hosting unit doesnt exist");
        }
        /// <summary>
        /// the function updates hostunit 
        /// </summary>
        /// <param name="hu">hostunit</param>
        public void UpdateHostUnit(BE.HostingUnit hu)
        {
            DeleteHostUnit(hu);
            AddHostUnit(hu);
        }
        /// <summary>
        /// the function add order
        /// </summary>
        /// <param name="or"a>order</param>
        public void AddOrder(BE.Order or)
        {
            BE.Configuration.stOrderKey++;
            or.OrderKey = BE.Configuration.stOrderKey;
            DS.DataSource.order.Add(or.clone());
        }
        /// <summary>
        /// the function updates a order
        /// </summary>
        /// <param name="or">order</param>
        public void UpdateOrder(BE.Order or)
        {
            bool flag = false;
            foreach (BE.Order st in DS.DataSource.order)
            {
                if (st.OrderKey == or.OrderKey)
                {
                    st.Status = or.Status;
                    flag = true;
                }     
            }
            if (!flag)
                throw new DAL.DoesntExist(or,"order doesnt exist");
            
        }
        /// <summary>
        /// the function returns a list of hosting unit
        /// </summary>
        /// <returns>list of hosting unit</returns>
        public List<BE.HostingUnit> GetHostUnit()
        {
            return DS.DataSource.hostingUnit.Select(item => item).ToList();
        }
        /// <summary>
        /// the function returns a list of guestrequest
        /// </summary>
        /// <returns>guestrequest</returns>
        public List<BE.GuestRequest> GetRequest(Func<GuestRequest, bool> predicat = null)
        {

            if (predicat == null)
                return DS.DataSource.guestRequest.Select(item => item).ToList();
            return DS.DataSource.guestRequest.Select(item => item).ToList().Where(predicat).ToList();
          
            
        }
        /// <summary>
        /// the function returns a list of order
        /// </summary>
        /// <returns>a list of order</returns>
        public List<BE.Order> GetOrder()
        {
            return DS.DataSource.order.Select(item => item).ToList();
        }
        /// <summary>
        /// the function returns a list of bank branch
        /// </summary>
        /// <returns>list of bank branch</returns>
        public List<BE.BankBranch> GetBank()
        {
            return DS.DataSource.Bank.Select(item => item).ToList();
        }
        public int FindGR(string name)
        {
            foreach (BE.GuestRequest st in DS.DataSource.guestRequest)
                if (name == st.PrivateName)
                    return st.GuestRequestKey;
            return -1;
        }
        public int FindUnit(string name)
        {
            foreach (BE.HostingUnit st in DS.DataSource.hostingUnit)
                if (name == st.HostingUnitName)
                    return st.HostingUnitKey;
            return -1;
        }

    }
}
