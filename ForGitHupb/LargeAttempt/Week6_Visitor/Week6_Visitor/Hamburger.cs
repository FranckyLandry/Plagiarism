using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Visitor
{
    public class Hamburger : Product, IVisitable
    {
        public Hamburger()
        {
            base._price = 3;
            base._description = "Tasty Cheese Burger";
        }

        public decimal Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}