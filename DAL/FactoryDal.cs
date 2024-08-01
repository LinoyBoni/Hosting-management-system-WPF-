using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class FactoryDal
    {
        public static Idal GetDal()
        {
            return Imp_Dal.GetMyDal();
        }
    }
}
