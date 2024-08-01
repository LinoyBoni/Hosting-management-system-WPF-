using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
namespace PL
{
    //Linoy Boni 211820824
    //Shira Doron 208053173
    class Program
    { 
        static void Main(string[] args)
        {
            IBL b= FactoryBL.GetBL();
            BE.GuestRequest gr = new BE.GuestRequest();

            gr.PrivateName = "shira";
            gr.FamilyName = "doron";
            gr.MailAddress = "hhhh";
            gr.Status = true;
            gr.RegistrationDate = new DateTime(2019,03,30);
            gr.EntryDate = new DateTime(2019, 03, 29);
            gr.ReleaseDate = new DateTime(2019, 03, 28);
            gr.Area = BE.Area.north;
            gr.SubArea = "tel aviv";
            gr.Type = BE.Type.apartment;
            gr.Adults = 6;
            gr.Children = 4;
            gr.Pool = BE.Interest.possible;
            gr.Garden = BE.Interest.not_interested;
            gr.ChildrensAttractions = BE.Interest.necessary;
            try
            {
                b.AddClientRequest(gr);
                Console.WriteLine("\nGuest request add succesfully:");
                Console.WriteLine(gr);
            }
              catch(Exception ex)
            {
                Console.WriteLine("\n" + ex.Message);
            }
            gr.ReleaseDate = new DateTime(2019, 04, 02);
            try
            {
                b.AddClientRequest(gr);
                Console.WriteLine("\nGuest request add succesfully:");
                Console.WriteLine(gr);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n"+ex.Message);
            }

            BE.Host h = new BE.Host();
            h.HostKey = "211820824";
            h.PrivateName = "linoy";
            h.FamilyName = "boni";
            h.FhoneNumber = "0507744481";
            h.MailAddress = "linotboni@gamil";
            h.BankBranchDetails = new BE.BankBranch();

            h.BankBranchDetails.BankName = "y";
            h.BankBranchDetails.BankNumber = 4;
            h.BankBranchDetails.BranchAddress = "ashdod";
            h.BankBranchDetails.BranchCity = "jerusalem";
            h.BankBranchDetails.BranchNumber = 45; 
            
            h.BankAccountNumber = 54;
            h.CollectionClearance = true;
            BE.HostingUnit hu = new BE.HostingUnit();
            hu.Owner = h;
            hu.HostingUnitName = "hotel";
            hu.Diary = new bool[30, 12];
            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 30; j++)
                    hu.Diary[j, i] = false;
            try
            {
                b.DeleteHostUnit(hu);
                Console.WriteLine("\nDelete hosting unit succesfully:");
                Console.WriteLine(hu);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex.Message);
            }

            try
            {
                b.AddHostUnit(hu);
                Console.WriteLine("\nHosting unit add succesfully:");
                Console.WriteLine(hu);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            hu.HostingUnitName = "home";
            try
            {
                b.UpdateHostUnit(hu);
                Console.WriteLine("\nHosting unit update succesfully:");
                Console.WriteLine(hu);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("\nAfter edit\n"+hu);
            BE.Order or = new BE.Order();
            or.HostingUnitKey = hu.HostingUnitKey;
            or.GuestRequestKey = gr.GuestRequestKey;
            or.OrderDate= new DateTime(2019, 04, 29);
            or.CreateDate= new DateTime(2019, 01, 29);
            or.Status = BE.OrderStatus.not_yet_handel;
            try
            {
                b.AddOrder(or);
                Console.WriteLine("\nOrder added succcessfuly");
                Console.WriteLine(or);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex.Message);
            }
            or.Status = BE.OrderStatus.send_mail;
            try
            {
                b.UpdateOrder(or);
                Console.WriteLine("\nOrder update succcessfuly");
                List<BE.Order> lOrder = b.GetOrder();
                foreach (var st in lOrder)
                    Console.WriteLine("\n" + st);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex.Message);
            }
            
            Console.ReadLine();
        }
    }
}
/*an example:
 wrong dates

Guest request add succesfully:

GuestRequestKey:10000001
private name:shira
family name:doron
mail adress:hhhh
status:True
regition date:30/03/2019 00:00:00
entry date:29/03/2019 00:00:00

the hosting unit doesnt exist

Hosting unit add succesfully:

HostingUnitKey:10000001
HostingUnitName:hotel
Area:jerusalem

After edit

HostingUnitKey:10000002
HostingUnitName:home
Area:jerusalem

Order added succcessfuly

HostingUnitKey:10000002
GuestRequestKey:10000001
OrderKey:10000001
CreateDate:29/01/2019 00:00:00
OrderDate: 29/04/2019 00:00:00
Status:not_yet_handel
SumOfFee: 0

HostingUnitKey:10000002
GuestRequestKey:10000001
OrderKey:10000001
CreateDate:29/01/2019 00:00:00
OrderDate: 02/01/2020 00:00:00
Status:send_mail
SumOfFee: 40

Order update succcessfuly


HostingUnitKey:10000002
GuestRequestKey:10000001
OrderKey:10000001
CreateDate:29/01/2019 00:00:00
OrderDate: 02/01/2020 00:00:00
Status:send_mail
SumOfFee: 40
 */

