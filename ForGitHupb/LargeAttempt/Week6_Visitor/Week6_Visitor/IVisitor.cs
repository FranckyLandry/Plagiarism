using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Visitor
{
    public interface IVisitor
    {
        decimal Visit(Liquor liqourItem);

        decimal Visit(Tobacco tobaccoItem);

        decimal Visit(Hamburger hamburgerItem);

        string GetTaxes();
    }
}