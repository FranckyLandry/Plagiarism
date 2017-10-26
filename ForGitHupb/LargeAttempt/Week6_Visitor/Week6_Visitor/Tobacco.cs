using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Visitor
{
    public class Tobacco : Product, IVisitable
    {
        public Tobacco()
        {
            base._price = 6;
            base._description = "Dutch Tobacco";
        }

        public decimal Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}