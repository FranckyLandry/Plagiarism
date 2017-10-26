using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Visitor
{
    public class BulgarianVisitor : IVisitor
    {
        public decimal Visit(Liquor liqourItem)
        {
            return liqourItem.GetPrice() * 1.05m;
        }

        public decimal Visit(Tobacco tobaccoItem)
        {
            return tobaccoItem.GetPrice() * 1.2m;
        }

        public decimal Visit(Hamburger hamburgerItem)
        {
            return hamburgerItem.GetPrice() * 1.3m;
        }

        public string GetTaxes()
        {
            return "Taxes => Liquor: 5%; Tobacco: 20%; Hamburger: 30%";
        }
    }
}