using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesSolution
{
    class Program
    {
        static void Main(string[] args) 
        {
            ShippingFeesDelegate feesDelegate;
            ShippingDestination destination;

            string zoneInput;
            do {
                // get the destination zone
                Console.WriteLine("What is the destination zone? (1, 2, 3, etc.)");
                zoneInput = Console.ReadLine();

                // if the user wrote "exit" then terminate the program,
                // otherwise continue 
                if (!zoneInput.Equals("exit")) 
                {
                    // given the zone, retrieve the associated shipping info
                    destination = ShippingDestination.GetDestinationInfo(zoneInput);

                    // if there's no associated info, then the user entered
                    // an invalid zone, otherwise continue
                    if (destination != null) 
                    {
                        // ask for the price and convert the string to a decimal number
                        Console.WriteLine("What is the item price?");
                        string priceInput = Console.ReadLine();
                        decimal itemPrice = decimal.Parse(priceInput);

                        // Each ShippingDestination object has a function called calcFees,
                        // use that as the delegate for calculating the fee
                        feesDelegate = destination.CalcFees;

                        // For high-risk zones, we tack on the delegate that adds the high risk fee
                        if (destination.IsHighRisk) 
                        {
                            feesDelegate += delegate(decimal thePrice, ref decimal itemFee) 
                            {
                                itemFee += 25.0m;
                            };
                        }

                        // Now all that is left to do is call the delegate and output
                        // the shipping fee to the Console
                        decimal theFee = 0.0m;
                        feesDelegate(itemPrice, ref theFee);
                        Console.WriteLine ($"The shipping fees are: ${theFee}" + Environment.NewLine);
                    }
                    else 
                    {
                        Console.WriteLine("You have entered an uknown destination. Please try again or 'exit'");
                    }
                }
            } 
            while (zoneInput != "exit");
        }
    }
}
