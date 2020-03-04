using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesSolution
{
    // This is a base class that is used as a foundation 
    // for each of the destination zones
    abstract class ShippingDestination
    {
        public bool IsHighRisk;
        public virtual void CalcFees(decimal price, ref decimal fee) { }

        // This static method returns an actual ShippingDestination object
        // given the name of the destination, or null if none exists
        public static ShippingDestination GetDestinationInfo(string destination)
        {
            if (destination.Equals("1"))
            {
                return new Dest_Zone1();
            }
            if (destination.Equals("2"))
            {
                return new Dest_Zone2();
            }
            if (destination.Equals("3"))
            {
                return new Dest_Zone3();
            }
            if (destination.Equals("4"))
            {
                return new Dest_Zone4();
            }
            return null;
        }
    }

}
