using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheBank
{
    class RedState:State
    {

        public RedState(State state) :
            this(state.Account)
        {
        }

        public RedState(Account Account)
        {
            this.account = Account;
        }

        public override void StateChangeCheck()
        {
            if (this.Account.Balance >= 0.0)
            {
                Account.State = new SilverState(this);
            }
            if (this.Account.Balance >= 1000.0)
            {
                Account.State = new GoldState(this);
            }
        }

        public override void CalculateInterest()
        {
            // no interest
        }
    }
}
