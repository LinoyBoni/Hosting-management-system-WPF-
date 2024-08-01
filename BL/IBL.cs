using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;

namespace BL
{
    public interface IBL
    {
        List<BE.Host> GetHost();
        void AddClientRequest(BE.GuestRequest gr);
        void UpdateRequest(BE.GuestRequest gr);
        void AddHostUnit(BE.HostingUnit hu);
        void DeleteHostUnit(BE.HostingUnit hu);
        void UpdateHostUnit(BE.HostingUnit hu);
        void AddOrder(BE.Order or);
        void UpdateOrder(BE.Order or);
        IEnumerable<BE.GuestRequest> RequestByArea(BE.Area a);
        List<BE.HostingUnit> GetHostUnit();
        List<BE.GuestRequest> GetRequest(Func<GuestRequest, bool> predicat = null);
        List<BE.Order> GetOrder();
        List<BE.BankBranch> GetBank();

        int FindUnit(string name);
        int FindGR(string name);

    }
}
