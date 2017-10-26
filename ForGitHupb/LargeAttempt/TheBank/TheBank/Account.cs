using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBank
{
    class Account
    {
        private int id;
        private String name;
        private State state;
        private Double balance;

        public Account(int Id, String Name,Double Balance)
        {
            this.id = Id;
            this.name = Name;
            this.balance = Balance;
            this.state = new SilverState(this);    
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public Double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public State State
        {
            get { return state; }
            set { state = value; }
        }

        public String Withdraw(Double amount)
        {
            if (state.GetType().Name != "RedState")
            {
                this.balance -= amount;
                state.StateChangeCheck();
                return "$ " + amount + " has been withdrawn on " + this.Name + "s account" + ", new balance is : " + Balance.ToString("0.00"); ;
            }
            else
            {
                return "You cannot withdraw anymore";
            }
       

        }
        public String Deposit(Double amount)
        {

            this.balance += amount;
            state.StateChangeCheck();
            return "$ " + amount + " has been deposited on " + this.Name + "s account" + ", new balance is : " + Balance.ToString("0.00");
        }


    }
}
