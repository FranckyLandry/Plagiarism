using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBank
{
    class GoldState:State
    {
      public GoldState(State state):
          this(state.Account)
        {
        }
 
    public GoldState(Account Account)
    {
      this.Account = Account;
      interest = 0.05;
    }

    public override void StateChangeCheck()
    {
        if (this.Account.Balance < 0.0)
        {
            Account.State = new RedState(this);
        }
        if (this.Account.Balance < 1000.0)
        {
            Account.State = new SilverState(this);
        }
    }


    public override void CalculateInterest()
    {
        Account.Balance += interest * Account.Balance;
        StateChangeCheck();
    }
    }
}
