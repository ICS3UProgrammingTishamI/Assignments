/*
 * Created by: Tisham Islam
 * Created on: 15/02/2019
 * Created for: ICS3U Programming
 * Assignment #2 - Falling Objects
 * This program calculates the distance a rock is from the ground, based on the force exerted by gravity. The user can input the value of time elapsed since the rock was dropped, 
 *and the program will calculate the height based off of that
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FallingObjectTishamI
{
    public partial class frmFallingObjects : Form
    {
        public frmFallingObjects()
        {
            InitializeComponent();
        }

        //Here are our variables
        double Gravity = 9.807;
        double InitialHeight = 100;
        double Height = 100;

        //This is all used so that the text box can have only numbers in it
        private void txtTimeInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            
            //Translation: if the entered characters are *not* digits (1,2,3,4,5 . . .), backspaces, or the delete key, then it will prevent it from being entered.
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //This gets whatever was entered in the textbox
            double UserTimeInput = double.Parse(txtTimeInput.Text);

            //This calculates the height of the object once it's fallen
            double Height = InitialHeight - (0.5 * Gravity * Math.Pow(UserTimeInput, 2));

            //This makes sure you can't enter 0 and negatives, just in case
            if (Height >= InitialHeight)
            {
                lblCalculations.Text = "Dude, the rock hasn't been dropped yet. Maybe you're already on the ground?";
            }

            //This sends a message that the object has hit the ground, so that negative values aren't shown in the calculations
            else if (Height <= 0)
            {
                lblCalculations.Text = "Wow, the rock has fallen to the ground!";
            }

            //This just writes the message for the calculation
            else if (true)
            {
                lblCalculations.Text = "The rock is currently " + Convert.ToString(Math.Round(Height, 2)) + "m above the ground.";
            }
        }

        //This lets you close the form when you click on the "Exit" menu item
        private void mniExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //This lets you change the value of gravity to that of another interstellar body
        private void mniEarthGravity_Click(object sender, EventArgs e)
        {
            Gravity = 9.807;
        }

        private void mniMoonGravity_Click(object sender, EventArgs e)
        {
            Gravity = 1.62;
        }

        private void mniSunGravity_Click(object sender, EventArgs e)
        {
            Gravity = 274;
        }
        //This lets you change the inital height when you click on the menu items
        private void mni100Height_Click(object sender, EventArgs e)
        {
            InitialHeight = 100;
        }

        private void mni1000Height_Click(object sender, EventArgs e)
        {
            InitialHeight = 1000;
        }

        private void mni10000Height_Click(object sender, EventArgs e)
        {
            InitialHeight = 10000;
        }
    }
}
