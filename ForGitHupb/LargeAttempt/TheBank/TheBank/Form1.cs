using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheBank
{
    public partial class Form1 : Form
    {
        Bank NationalBank;

        public Form1()
        {
            InitializeComponent();
            //create bank
            NationalBank = new Bank("NationalBank");
            
            //create account
            NationalBank.AddAccount(new Account(001, "Dickson",0));
            NationalBank.AddAccount(new Account(002, "Vichayut",0));
            //Add accounts name to ComboboBox1
            foreach (Account acc in NationalBank.accounts)
            {
                comboBox1.Items.Add(acc.Name);
            }
            
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            try
            {
               listBox1.Items.Add(NationalBank.FindAccountInfo(comboBox1.SelectedItem.ToString()).Deposit(Convert.ToInt32(tbBalance.Text)));
               UpdateDetails();
            }
            catch (FormatException)
            {
                listBox1.Items.Add("Only numbers");
            }
            catch(NullReferenceException)
            {
                listBox1.Items.Add("Choose an Account");
            }
           
        }

        private void UpdateDetails()
        {
            Account current = NationalBank.FindAccountInfo(comboBox1.SelectedItem.ToString());
            // updates details of the the current account
            lbId.Text = Convert.ToString(current.Id);
            lbBalance.Text = current.Balance.ToString("0.00");
            lbName.Text = Convert.ToString(current.Name);
            lbState.Text = Convert.ToString(current.State.GetType().Name);
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDetails();
            listBox1.Items.Clear();
        }

        private void btnWithDraw_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Add( NationalBank.FindAccountInfo(comboBox1.SelectedItem.ToString()).Withdraw(Convert.ToInt32(tbBalance.Text)));
                UpdateDetails();
            }
            catch (FormatException)
            {
                 listBox1.Items.Add("Only numbers");
            }
            catch (NullReferenceException)
            {
                listBox1.Items.Add("Choose an Account");
            }
        }

        private void btnCreditCard_Click(object sender, EventArgs e)
        {
            try
            {
                String name = comboBox1.SelectedItem.ToString();
                listBox1.Items.Add(name + " has applied for a creditcard.");
                if (NationalBank.ApplyForCreditCard(name) == true)
                {
                    listBox1.Items.Add(name + " account status is " + NationalBank.FindAccountInfo(name).State.GetType().Name + ".");
                    listBox1.Items.Add(name + " has been approved for creditcard.");
                }
                else
                {
                    listBox1.Items.Add(name + " account status is " + NationalBank.FindAccountInfo(name).State.GetType().Name + ".");
                    listBox1.Items.Add(name + " has been denied for creditcard.");
                }
            }
            catch (NullReferenceException)
            {
                listBox1.Items.Add("Choose an Account");
            }
            
        }

        private void btnInterest_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(NationalBank.PayInterestAccount(comboBox1.SelectedItem.ToString()));
            UpdateDetails();
        }


    }
}
