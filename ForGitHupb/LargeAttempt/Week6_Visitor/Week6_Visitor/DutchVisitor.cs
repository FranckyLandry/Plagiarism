using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Visitor
{
    public class DutchVisitor : IVisitor
    {
        public decimal Visit(Liquor liqourItem)
        {
            return liqourItem.GetPrice() * 1.4m;
        }

        public decimal Visit(Tobacco tobaccoItem)
        {
            return tobaccoItem.GetPrice() * 1.5m;
        }

        public decimal Visit(Hamburger hamburgerItem)
        {
            return hamburgerItem.GetPrice() * 1.1m;
        }

        public string GetTaxes()
        {
            return "Taxes => Liquor: 40%; Tobacco: 50%; Hamburger: 10%";
        }
    }
}