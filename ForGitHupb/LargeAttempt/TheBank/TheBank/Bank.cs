using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBank
{
    class Bank
    {
        public List<Account> accounts;
        private String name;
  

        public Bank(String Name)
        {
            this.name = Name;
            accounts = new List<Account>();
        }

        public void AddAccount(Account account)
        {
            accounts.Add(account);
        }

        public Account FindAccountInfo(String Name)
        {
            foreach (Account acc in accounts)
            {
                if (acc.Name == Name)
                {
                    return acc;
                }
            }
            return null;
        }

        public bool ApplyForCreditCard(String Name)
        {
            foreach (Account acc in accounts)
            {
                if (acc.Name == Name)
                {
                    if (acc.State.GetType().Name == "GoldState")
                    {
                        return true;
                    }
                }
            }

            return false;
            
        }


        public String PayInterestAccount(String Name)
        {
            foreach (Account acc in accounts)
            {
                if (acc.Name == Name)
                {
                    acc.State.CalculateInterest();
                    return "Interest has been paid" + ", new balance is : " + acc.Balance.ToString("0.00");
                }
            }

            return "";
        }


    }
}
