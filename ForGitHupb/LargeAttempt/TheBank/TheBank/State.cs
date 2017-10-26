using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBank
{
    abstract class State
    {
        protected Account account;
        protected Double interest;
                 // Properties

        public Account Account
        {
            get { return account; }
            set { account = value; }
        }
        public abstract void StateChangeCheck();
        public abstract void CalculateInterest();

        }
      }
