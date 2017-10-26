using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBank
{
    class SilverState : State
    {
        // this state will create new state taking values from old state
        public SilverState(State state) :
            this(state.Account)
        {
        }

        public SilverState(Account Account)
        {
            this.account = Account;
            this.interest = 0.01;
        }

        public override void StateChangeCheck()
        {
            if (this.Account.Balance < 0.0)
            {
                Account.State = new RedState(this);
                
            }
            if (this.Account.Balance > 1000.0)
            {
                Account.State = new GoldState(this);
            }
        }

        public override void CalculateInterest()
        {
            Account.Balance += interest * Account.Balance;
            StateChangeCheck();
        }

        public int FindMax(int num1, int num2)
        {
            /* local variable declaration */
            int result;

            if (num1 > num2)
                result = num1;
            else
                result = num2;

            return result;
        }


        public int factorial(int num)
        {
            /* local variable declaration */
            int result;
            if (num == 1)
            {
                return 1;
            }
            else
            {
                result = factorial(num - 1) * num;
                return result;
            }
        }


        public int AddNumbers(int number1, int number2)
        {
            int result = number1 + number2;
            if (result > 10)
            {
                return result;
            }
            return 0;
        }
        static void Swap(int a, int b)
        {
            int temp;
            temp = a;
            a = b;
            b = temp;
            Console.WriteLine("Inside Swap method");
            Console.WriteLine("a is {0}", a);
            Console.WriteLine("b is {0}", b);
        }

    }
}
