using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week6_Visitor
{
    public partial class VisitorForm : Form
    {
        private IVisitor _visitor;
        private Liquor _liqour;
        private Tobacco _tobacco;
        private Hamburger _hamburger;

        public VisitorForm()
        {
            InitializeComponent();
            _liqour = new Liquor();
            lbLiquor.Text += _liqour.GetPrice().ToString();
            _tobacco = new Tobacco();
            lbTobacco.Text += _tobacco.GetPrice().ToString();
            _hamburger = new Hamburger();
            lbBurger.Text += _hamburger.GetPrice().ToString();

            _visitor = new DutchVisitor();
            SwitchDutch();
        }

        private void AddMessage(string message)
        {
            this.rbMessages.Text = string.Format("[{0}]\r\n{1}\r\n{2}",
                DateTime.Now.ToLongTimeString(),
                message,
                this.rbMessages.Text);
        }

        private void SwitchDutch()
        {
            _visitor = new DutchVisitor();
            AddMessage("You are now in a Dutch shop!\r\n" + _visitor.GetTaxes());
            rbBulgarian.Checked = false;
            rbDutch.Checked = true;
        }

        private void SwitchBulgarian()
        {
            _visitor = new BulgarianVisitor();
            AddMessage("You are now in a Bulgarian shop!\r\n" + _visitor.GetTaxes());
            rbBulgarian.Checked = true;
            rbDutch.Checked = false;
        }

        private void picHamburger_Click(object sender, EventArgs e)
        {
            AddMessage(string.Format("You bought a \"{0}\" for {1}", _hamburger.GetDescription(), _visitor.Visit(_hamburger)));
        }

        private void picLiqour_Click(object sender, EventArgs e)
        {
            AddMessage(string.Format("You bought a \"{0}\" for {1}", _liqour.GetDescription(), _visitor.Visit(_liqour)));
        }

        private void picTobacco_Click(object sender, EventArgs e)
        {
            AddMessage(string.Format("You bought a \"{0}\" for {1}", _tobacco.GetDescription(), _visitor.Visit(_tobacco)));
        }

        private void rbDutch_MouseClick(object sender, MouseEventArgs e)
        {
            SwitchDutch();
        }

        private void rbBulgarian_MouseClick(object sender, MouseEventArgs e)
        {
            SwitchBulgarian();
        }
    }
}