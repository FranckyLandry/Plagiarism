using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Visitor
{
    public class Product
    {
        protected decimal _price;

        protected string _description;

        public decimal GetPrice()
        {
            return this._price;
        }

        public string GetDescription()
        {
            return this._description;
        }
    }
}