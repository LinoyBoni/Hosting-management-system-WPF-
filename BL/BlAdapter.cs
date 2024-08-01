using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public class BlAdapter
    {
       DAL.Idal dal = DAL.FactoryDal.GetDal();
    }
}
