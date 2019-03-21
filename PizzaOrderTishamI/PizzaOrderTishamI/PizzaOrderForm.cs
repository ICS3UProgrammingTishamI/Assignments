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

        //variables
        double sizeCost;
        double toppingsCost;
        double friesCost;
        double drinksCost;
        double drinksAmount;
        double friesAmount;
        double subtotal;
        double total;



        private void nudToppings_ValueChanged(object sender, EventArgs e)
        {
            if (nudToppings.Value == 0)
            {
                toppingsCost = 0;
            }
            else if (nudToppings.Value == 1)
            {
                toppingsCost = 0.75;
            }
            else if (nudToppings.Value == 2)
            {
                toppingsCost = 1.35;
            }
            else if (nudToppings.Value == 3)
            {
                toppingsCost = 2.15;
            }
            else if (nudToppings.Value == 4)
            {
                toppingsCost = 2.75;
            }
            lblToppings.Text = "The cost of your toppings is " + String.Format("{0:$0.00}", toppingsCost);
        }

        private void nudFries_ValueChanged(object sender, EventArgs e)
        {
            friesAmount = Convert.ToDouble(nudFries.Value);
            friesCost = friesAmount * 299;
            lblFries.Text = "The cost of your fries is " + String.Format("{0:$0:00}", friesCost);
        }

        private void nudDrinks_ValueChanged(object sender, EventArgs e)
        {
            drinksAmount = Convert.ToDouble(nudDrinks.Value);
            drinksCost = drinksAmount * 199;
            lblDrinks.Text = "The cost of your drinks is " + String.Format("{0:$0:00}", drinksCost);
        }

        private void radMedium_CheckedChanged(object sender, EventArgs e)
        {
            sizeCost = 699;
            lblPizzaSize.Text = "The cost of your medium pizza is " + String.Format("{0:$0:00}", sizeCost); 
        }

        private void radLarge_CheckedChanged(object sender, EventArgs e)
        {
            sizeCost = 999;
            lblPizzaSize.Text = "The cost of your large pizza is " + String.Format("{0:$0:00}", sizeCost);
        }
        private void radExtraLarge_CheckedChanged(object sender, EventArgs e)
        {
            sizeCost = 1299;
            lblPizzaSize.Text = "The cost of your extra large pizza is " + String.Format("{0:$0:00}", sizeCost);
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {

        }
    }
}
