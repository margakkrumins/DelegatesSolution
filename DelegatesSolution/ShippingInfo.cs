namespace DelegatesSolution
{
    // declare the delegate type used to calculate the fees
    public delegate void ShippingFeesDelegate(decimal thePrice, ref decimal fee);


    // Now we define implementation classes for each of the real shipping
    // destinations. We can add as many as we like as the need arises

    class Dest_Zone1 : ShippingDestination
    {
        public Dest_Zone1() 
        {
            this.IsHighRisk = false;
        }
        public override void CalcFees(decimal price, ref decimal fee) 
        {
            fee = price * 0.25m;
        }
    }

    class Dest_Zone2 : ShippingDestination
    {
        public Dest_Zone2() 
        {
            this.IsHighRisk = true;
        }
        public override void CalcFees(decimal price, ref decimal fee) 
        {
            fee = price * 0.12m;
        }
    }

    class Dest_Zone3 : ShippingDestination
    {
        public Dest_Zone3() 
        {
            this.IsHighRisk = false;
        }
        public override void CalcFees(decimal price, ref decimal fee) 
        {
            fee = price * 0.08m;
        }
    }

    class Dest_Zone4 : ShippingDestination
    {
        public Dest_Zone4() 
        {
            this.IsHighRisk = true;
        }
        public override void CalcFees(decimal price, ref decimal fee) 
        {
            fee = price * 0.04m;
        }
    }
}
