using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Visitor
{
    public class Liquor : Product, IVisitable
    {
        public Liquor()
        {
            base._price = 10;
            base._description = "Traditional Bulgarian Rakiya";
        }

        public decimal Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}