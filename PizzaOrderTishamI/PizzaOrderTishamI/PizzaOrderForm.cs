using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaOrderTishamI
{
    public partial class frmPizzaOrder : Form
    {
        public frmPizzaOrder()
        {
            InitializeComponent();
        }

        private void nudToppings_ValueChanged(object sender, EventArgs e)
        {
            lblToppings.Text = "The cost of your toppings is " + String.Format("{0:$0.00}" , Convert.ToString(nudToppings.Value));
        }
    }
}
