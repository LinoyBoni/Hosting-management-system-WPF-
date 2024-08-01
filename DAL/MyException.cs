using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
     public class DoesntExist : Exception
    {
       public object myOb { get; private set; }
        //public MyException(object ob) : base() { }
         public DoesntExist( object ob, string st) : base(st)
        {
            myOb = ob;
        }

        override public string ToString()
        {
            return "the " + myOb.GetType().ToString() + " doesnt exist";
        }
    }
}
