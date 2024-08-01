using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;

namespace DAL
{
    public interface Idal
    {
        List<Host> GetHost();
        void AddClientRequest(GuestRequest gr);
        void UpdateRequest(GuestRequest gr);
        void AddHostUnit(HostingUnit hu);
        void DeleteHostUnit(HostingUnit hu);
        void UpdateHostUnit(HostingUnit hu);
        void AddOrder(Order or);
        void UpdateOrder(Order or);
        List<HostingUnit> GetHostUnit();
        List<GuestRequest> GetRequest(Func<GuestRequest , bool> predicat = null);
        List<Order> GetOrder();
        List<BankBranch> GetBank();

        int FindGR(string name);
        int FindUnit(string name);
    }
}
