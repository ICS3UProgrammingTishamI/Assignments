/*
 * Created by: Tisham Islam
 * Created on: 07/04/2019
 * Created for: ICS3U Programming
 * Assignment #6b - Simplified 21
 * This program simulate a game of 21, or blackjack, in a simplified form
 * It does not have many features a regular game of 21 might have
 * such as images of cards being flipped or poker chips
 * It shall be improved as part of assignment 7
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

namespace Simplified21TishamI
{
    public partial class frmSimplified21 : Form
    {
        #region Initializer
        public frmSimplified21()
        {
            InitializeComponent();
            //This will hide all the objects on the form
            foreach (Control controlObject in this.Controls)
            {
                controlObject.Hide();
            }

            //These will let the player enter how many other players they want
            //and continue on from there
            lblPlayerAmount.Show();
            btnPlayerAmount.Show();
            nudPlayerAmount.Show();

            //menu strips are important to have at all times
            mnuMenuStrip.Show();
        }
        #endregion

        #region Constants and Variables
        //constants
        int MIN_CARD = 2, MAX_CARD = 11;
        int MIN_BET = 0, MAX_BET = 3;

        //variables
        int playerAmount;
        int playerTotal = 250;
        int playerBet;
        int playerBet2;
        int com1Total = 250;
        int com1Bet;
        int com2Total = 250;
        int com2Bet;
        int com3Total = 250;
        int com3Bet;
        int dealerTotal = 5000;
        int playerCardSum;
        int playerCardSum2;
        int dealerCardSum;
        int com1CardSum;
        int com2CardSum;
        int com3CardSum;
        bool replay;

        #region Cards
        //User's cards
        int playerCard1 = 0, playerCard2 = 0, playerCard3 = 0,
            playerCard4 = 0, playerCard5 = 0, playerCard6 = 0,
            playerCard7 = 0, playerCard8 = 0,
            playerCard9 = 0, playerCard10 = 0;

        //User's second hand's cards (for splitting the deck)
        int playerD2C1 = 0, playerD2C2 = 0, playerD2C3 = 0,
            playerD2C4 = 0, playerD2C5 = 0, playerD2C6 = 0,
            playerD2C7 = 0, playerD2C8 = 0,
            playerD2C9 = 0, playerD2C10 = 0;

        //com1's cards
        int com1Card1 = 0, com1Card2 = 0, com1Card3 = 0,
             com1Card4 = 0, com1Card5 = 0, com1Card6 = 0,
             com1Card7 = 0, com1Card8 = 0,
             com1Card9 = 0, com1Card10 = 0;

        //com2's cards
        int com2Card1 = 0, com2Card2 = 0, com2Card3 = 0,
             com2Card4 = 0, com2Card5 = 0, com2Card6 = 0,
             com2Card7 = 0, com2Card8 = 0,
             com2Card9 = 0, com2Card10 = 0;

        //com3's cards
        int com3Card1 = 0, com3Card2 = 0, com3Card3 = 0,
             com3Card4 = 0, com3Card5 = 0, com3Card6 = 0,
             com3Card7 = 0, com3Card8 = 0,
             com3Card9 = 0, com3Card10 = 0;

        //dealer's cards
        int dealerCard1 = 0, dealerCard2 = 0, dealerCard3 = 0,
             dealerCard4 = 0, dealerCard5 = 0, dealerCard6 = 0,
             dealerCard7 = 0, dealerCard8 = 0,
             dealerCard9 = 0, dealerCard10 = 0;
        #endregion

        //every game needs a random number generator
        Random numberGenerator = new Random();
        #endregion

        #region Player Amount
        private void BtnPlayerAmount_Click(object sender, EventArgs e)
        {
            //initializing the player amount as the user deems fit
            playerAmount = (int)nudPlayerAmount.Value;

            //hiding these objects as they're no longer needed
            btnPlayerAmount.Hide();
            lblPlayerAmount.Hide();
            nudPlayerAmount.Hide();

            //show the objects for the next step
            btnBetAmount.Show();
            lblBetAmount.Show();
            nudBetAmount.Show();
        }
        #endregion

        #region Player Bet
        private void BtnBetAmount_Click(object sender, EventArgs e)
        {
            //Get the player's bet from the nud
            playerBet = (int)nudBetAmount.Value;
            lblPlayerBet.Text = "Your bet: $" + Convert.ToString(playerBet);
            lblPlayerBet.Show();

            //hide the objects for betting until needed again
            nudBetAmount.Hide();
            lblBetAmount.Hide();
            btnBetAmount.Hide();

            #region Initial Card Generation
            //generate cards for everyone
            playerCard1 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
            playerCard2 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);

            dealerCard1 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
            dealerCard2 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);

            //Disable the button to display COM's cards
            btnComCards.Enabled = false;
            btnComCards.Show();

            //Generate cards for COM players based on how many players there are
            if (playerAmount >= 1)
            {
                //Generate first 2 cards
                com1Card1 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                com1Card2 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);

                //Generate and display a bet for COM1
                com1Bet = 20 + 10 * numberGenerator.Next(MIN_BET, MAX_BET + 1);
                lblCom1Bet.Text = "COM1's Bet: $" + Convert.ToString(com1Bet);

                //Add them to the label
                lblCom1Cards.Text += Convert.ToString(com1Card1) + " " + Convert.ToString(com1Card2);

                //if there are any COM players, this will let you see their cards
                btnComCards.Enabled = true;

                //display totals and bets
                lblCom1Total.Show();
                lblCom1Bet.Show();
            }

            if (playerAmount >= 2)
            {
                //Generate first 2 cards for COM2
                com2Card1 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                com2Card2 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);

                //Generate and display bet for COM2
                com2Bet = 20 + 10 * numberGenerator.Next(MIN_BET, MAX_BET + 1);
                lblCom2Bet.Text = "COM2's Bet: $" + Convert.ToString(com2Bet);

                //Add them to COM2's label
                lblCom2Cards.Text += Convert.ToString(com2Card1) + " " + Convert.ToString(com2Card2);

                //display totals and bets
                lblCom2Total.Show();
                lblCom2Bet.Show();
            }

            if (playerAmount >= 3)
            {
                //Generate first 2 cards for COM3
                com3Card1 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                com3Card2 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);

                //Generate and display a bet for COM3
                com3Bet = 20 + 10 * numberGenerator.Next(MIN_BET, MAX_BET + 1);
                lblCom3Bet.Text = "COM3's Bet: $" + Convert.ToString(com3Bet);

                //Add them to COM3's label
                lblCom3Cards.Text += Convert.ToString(com3Card1) + " " + Convert.ToString(com3Card2);

                //display totals and bets
                lblCom3Total.Show();
                lblCom3Bet.Show();
            }
            #endregion

            #region Displays
            //display your cards and the dealer's cards
            lblPlayerCards.Text = "Your cards: "
                        + Convert.ToString(playerCard1) + " "
                        + Convert.ToString(playerCard2) + " "
                        + Convert.ToString(playerCard3) + " "
                        + Convert.ToString(playerCard4) + " "
                        + Convert.ToString(playerCard5) + " "
                        + Convert.ToString(playerCard6) + " "
                        + Convert.ToString(playerCard7) + " "
                        + Convert.ToString(playerCard8) + " "
                        + Convert.ToString(playerCard9) + " "
                        + Convert.ToString(playerCard10);
            lblPlayerCards.Show();

            //The dealer's second card is only shown when it is their turn
            lblDealerCards.Text += Convert.ToString(dealerCard1);
            lblDealerCards.Show();

            //display totals
            lblPlayerTotal.Show();
            lblDealerTotal.Show();

            //show the actions you can take with your cards
            btnHit.Show();
            btnStand.Show();
            btnSplit.Show();
            btnSurrender.Show();
            btnDoubleDown.Show();
            btnInsurance.Show();

            //This is for later
            btnContinue.Show();
            btnContinue.Enabled = false;

            //These buttons are all enabled, and the rest may or may not be enabled
            btnHit.Enabled = true;
            btnStand.Enabled = true;
            btnDoubleDown.Enabled = true;
            btnSurrender.Enabled = true;

            //This explains each button
            lblInsurance.Show();
            lblHit.Show();
            lblStand.Show();
            lblSurrender.Show();
            lblSplit.Show();
            lblDoubleDown.Show();
            #endregion

            #region Initial Conditions

            //If you have doubles, you can split your hand
            if (playerCard1 == playerCard2)
            {
                btnSplit.Enabled = true;
            }
            else
            {
                btnSplit.Enabled = false;
            }

            //If the dealer has an ace, you can make an insurance bet
            if (dealerCard1 == 11)
            {
                btnInsurance.Enabled = true;

                //the insurance bet will be immediately checked for,
                //so all other buttons must be disabled
                btnHit.Enabled = false;
                btnStand.Enabled = false;
                btnSplit.Enabled = false;
                btnDoubleDown.Enabled = false;

                //surrender can always be done, however, so it is not disabled here

                //The continue button in case you don't want to make the bet
                btnContinue.Enabled = true;
                btnContinue.Show();
            }
            else
            {
                btnInsurance.Enabled = false;
            }

            //If you have a blackjack, you automatically win unless the dealer has blackjack too
            //Therefore, you just need to hit the continue button, and maybe insurance
            if (playerCard1 + playerCard2 == 21)
            {
                //Disable all these buttons, except for insurance if the dealer has an ace
                btnSplit.Enabled = false;
                btnSurrender.Enabled = false;
                btnStand.Enabled = false;
                btnHit.Enabled = false;
                btnDoubleDown.Enabled = false;

                //Continue with COM and dealer turns
                btnContinue.Enabled = true;
                btnContinue.Show();
            }
            #endregion
        }
        #endregion

        #region Display COM Cards
        private void BtnComCards_Click(object sender, EventArgs e)
        {//If the cards are already visible, make them hidden again
            if (lblCom1Cards.Visible == true)
            {
                lblCom1Cards.Hide();
                lblCom2Cards.Hide();
                lblCom3Cards.Hide();
                //change the text of the button to show you can still display the cards
                btnComCards.Text = "Display COM Cards";
            }
            else
            //Otherwise, make the cards visible
            {
                //Show the cards of each COM player in game
                if (playerAmount >= 1)
                {
                    lblCom1Cards.Show();
                }
                if (playerAmount >= 2)
                {
                    lblCom2Cards.Show();
                }
                if (playerAmount >= 3)
                {
                    lblCom3Cards.Show();
                }

                //change the text of the button to indicate that you can hide the cards
                btnComCards.Text = "Hide COM Cards";
            }

        }
        #endregion

        #region Surrender
        private void BtnSurrender_Click(object sender, EventArgs e)
        {
            //Disable the buttons as you've surrendered
            btnSurrender.Enabled = false;
            btnStand.Enabled = false;
            btnHit.Enabled = false;
            btnDoubleDown.Enabled = false;
            btnSplit.Enabled = false;
            btnInsurance.Enabled = false;

            //continue with the COM and dealer turns
            btnContinue.Enabled = true;
            btnContinue.Show();

            //Give half your bet to the dealer, and reset the bet
            //If you have only one hand of cards, the second bet will be 0 anyways
            //Otherwise, you'll pay more 
            playerTotal -= playerBet / 2 + playerBet2 / 2;
            dealerTotal += playerBet / 2 + playerBet2 / 2;
            playerBet = 0;
            lblPlayerTotal.Text = "Your total: $" + Convert.ToString(playerTotal);
            lblPlayerBet.Text = "Your bet: SURRENDERED";

            lblMessages.Text = "You surrendered half your bet, press continue to see COM's actions";
            lblMessages.Show();
        }
        #endregion

        #region Split
        private void BtnSplit_Click(object sender, EventArgs e)
        {
            //Adds and displays a second hand of cards
            //Removes your second card to become your second hand
            playerD2C1 = playerCard2;
            playerCard2 = 0;

            //re-display your cards
            lblPlayerCards.Text = "Your cards: "
                        + Convert.ToString(playerCard1) + " "
                        + Convert.ToString(playerCard2) + " "
                        + Convert.ToString(playerCard3) + " "
                        + Convert.ToString(playerCard4) + " "
                        + Convert.ToString(playerCard5) + " "
                        + Convert.ToString(playerCard6) + " "
                        + Convert.ToString(playerCard7) + " "
                        + Convert.ToString(playerCard8) + " "
                        + Convert.ToString(playerCard9) + " "
                        + Convert.ToString(playerCard10);

            //display your second hand
            lblPlayerCards2.Text = "Your cards: "
                             + Convert.ToString(playerD2C1) + " "
                             + Convert.ToString(playerD2C2) + " "
                             + Convert.ToString(playerD2C3) + " "
                             + Convert.ToString(playerD2C4) + " "
                             + Convert.ToString(playerD2C5) + " "
                             + Convert.ToString(playerD2C6) + " "
                             + Convert.ToString(playerD2C7) + " "
                             + Convert.ToString(playerD2C8) + " "
                             + Convert.ToString(playerD2C9) + " "
                             + Convert.ToString(playerD2C10);

            lblPlayerCards2.Show();
            lblMessages.Text = "You've split your deck in half! And you've also doubled your bet!";
            lblMessages.Show();

            //As this is still simplified, doubling down and further splitting is disabled
            btnDoubleDown.Enabled = false;
            btnSplit.Enabled = false;
        }
        #endregion

        #region Double Down
        private void BtnDoubleDown_Click(object sender, EventArgs e)
        {
            //hide the message label for convenience
            lblMessages.Hide();

            //Doubles your bet
            playerBet += playerBet;

            #region Card Generation
            //Generates cards
            if (playerCard3 == 0)
            {
                playerCard3 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                lblPlayerCards.Text = "Your cards: "
                        + Convert.ToString(playerCard1) + " "
                        + Convert.ToString(playerCard2) + " "
                        + Convert.ToString(playerCard3) + " "
                        + Convert.ToString(playerCard4) + " "
                        + Convert.ToString(playerCard5) + " "
                        + Convert.ToString(playerCard6) + " "
                        + Convert.ToString(playerCard7) + " "
                        + Convert.ToString(playerCard8) + " "
                        + Convert.ToString(playerCard9) + " "
                        + Convert.ToString(playerCard10);
            }
            else if (playerCard4 == 0)
            {
                playerCard4 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                lblPlayerCards.Text = "Your cards: "
                        + Convert.ToString(playerCard1) + " "
                        + Convert.ToString(playerCard2) + " "
                        + Convert.ToString(playerCard3) + " "
                        + Convert.ToString(playerCard4) + " "
                        + Convert.ToString(playerCard5) + " "
                        + Convert.ToString(playerCard6) + " "
                        + Convert.ToString(playerCard7) + " "
                        + Convert.ToString(playerCard8) + " "
                        + Convert.ToString(playerCard9) + " "
                        + Convert.ToString(playerCard10);
            }
            else if (playerCard5 == 0)
            {
                playerCard5 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                lblPlayerCards.Text = "Your cards: "
                        + Convert.ToString(playerCard1) + " "
                        + Convert.ToString(playerCard2) + " "
                        + Convert.ToString(playerCard3) + " "
                        + Convert.ToString(playerCard4) + " "
                        + Convert.ToString(playerCard5) + " "
                        + Convert.ToString(playerCard6) + " "
                        + Convert.ToString(playerCard7) + " "
                        + Convert.ToString(playerCard8) + " "
                        + Convert.ToString(playerCard9) + " "
                        + Convert.ToString(playerCard10);
            }
            else if (playerCard6 == 0)
            {
                playerCard6 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                lblPlayerCards.Text = "Your cards: "
                        + Convert.ToString(playerCard1) + " "
                        + Convert.ToString(playerCard2) + " "
                        + Convert.ToString(playerCard3) + " "
                        + Convert.ToString(playerCard4) + " "
                        + Convert.ToString(playerCard5) + " "
                        + Convert.ToString(playerCard6) + " "
                        + Convert.ToString(playerCard7) + " "
                        + Convert.ToString(playerCard8) + " "
                        + Convert.ToString(playerCard9) + " "
                        + Convert.ToString(playerCard10);
            }
            else if (playerCard7 == 0)
            {
                playerCard7 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                lblPlayerCards.Text = "Your cards: "
                        + Convert.ToString(playerCard1) + " "
                        + Convert.ToString(playerCard2) + " "
                        + Convert.ToString(playerCard3) + " "
                        + Convert.ToString(playerCard4) + " "
                        + Convert.ToString(playerCard5) + " "
                        + Convert.ToString(playerCard6) + " "
                        + Convert.ToString(playerCard7) + " "
                        + Convert.ToString(playerCard8) + " "
                        + Convert.ToString(playerCard9) + " "
                        + Convert.ToString(playerCard10);
            }
            else if (playerCard8 == 0)
            {
                playerCard8 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                lblPlayerCards.Text = "Your cards: "
                        + Convert.ToString(playerCard1) + " "
                        + Convert.ToString(playerCard2) + " "
                        + Convert.ToString(playerCard3) + " "
                        + Convert.ToString(playerCard4) + " "
                        + Convert.ToString(playerCard5) + " "
                        + Convert.ToString(playerCard6) + " "
                        + Convert.ToString(playerCard7) + " "
                        + Convert.ToString(playerCard8) + " "
                        + Convert.ToString(playerCard9) + " "
                        + Convert.ToString(playerCard10);
            }
            else if (playerCard9 == 0)
            {
                playerCard9 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                lblPlayerCards.Text = "Your cards: "
                        + Convert.ToString(playerCard1) + " "
                        + Convert.ToString(playerCard2) + " "
                        + Convert.ToString(playerCard3) + " "
                        + Convert.ToString(playerCard4) + " "
                        + Convert.ToString(playerCard5) + " "
                        + Convert.ToString(playerCard6) + " "
                        + Convert.ToString(playerCard7) + " "
                        + Convert.ToString(playerCard8) + " "
                        + Convert.ToString(playerCard9) + " "
                        + Convert.ToString(playerCard10);
            }
            else
            {
                playerCard10 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                lblPlayerCards.Text = "Your cards: "
                    + Convert.ToString(playerCard1) + " "
                    + Convert.ToString(playerCard2) + " "
                    + Convert.ToString(playerCard3) + " "
                    + Convert.ToString(playerCard4) + " "
                    + Convert.ToString(playerCard5) + " "
                    + Convert.ToString(playerCard6) + " "
                    + Convert.ToString(playerCard7) + " "
                    + Convert.ToString(playerCard8) + " "
                    + Convert.ToString(playerCard9) + " "
                    + Convert.ToString(playerCard10);
            }
            #endregion

            //adds up all your cards
            playerCardSum = playerCard1 + playerCard2 +
                playerCard3 + playerCard4 +
                playerCard5 + playerCard6 +
                playerCard7 + playerCard8 +
                playerCard9 + playerCard10;

            //display your card total
            lblPlayerCards.Text = "Your Card Total: $" + Convert.ToString(playerCardSum);

            //checks if you've busted
            if (playerCardSum > 21)
            {
                #region Ace Conversion
                //this converts any cards that happen to be an ace into a one
                //This one is for your second hand
                //I don't know how to optimize this
                if (playerCard1 == 11)
                {
                    playerCard1 = 1;
                    lblPlayerCards.Text = "Your cards: "
                        + Convert.ToString(playerCard1) + " "
                        + Convert.ToString(playerCard2) + " "
                        + Convert.ToString(playerCard3) + " "
                        + Convert.ToString(playerCard4) + " "
                        + Convert.ToString(playerCard5) + " "
                        + Convert.ToString(playerCard6) + " "
                        + Convert.ToString(playerCard7) + " "
                        + Convert.ToString(playerCard8) + " "
                        + Convert.ToString(playerCard9) + " "
                        + Convert.ToString(playerCard10);
                }
                else if (playerCard2 == 11)
                {
                    playerCard2 = 1;
                    lblPlayerCards.Text = "Your cards: "
                        + Convert.ToString(playerCard1) + " "
                        + Convert.ToString(playerCard2) + " "
                        + Convert.ToString(playerCard3) + " "
                        + Convert.ToString(playerCard4) + " "
                        + Convert.ToString(playerCard5) + " "
                        + Convert.ToString(playerCard6) + " "
                        + Convert.ToString(playerCard7) + " "
                        + Convert.ToString(playerCard8) + " "
                        + Convert.ToString(playerCard9) + " "
                        + Convert.ToString(playerCard10);
                }
                else if (playerCard3 == 11)
                {
                    playerCard3 = 1;
                    lblPlayerCards.Text = "Your cards: "
                        + Convert.ToString(playerCard1) + " "
                        + Convert.ToString(playerCard2) + " "
                        + Convert.ToString(playerCard3) + " "
                        + Convert.ToString(playerCard4) + " "
                        + Convert.ToString(playerCard5) + " "
                        + Convert.ToString(playerCard6) + " "
                        + Convert.ToString(playerCard7) + " "
                        + Convert.ToString(playerCard8) + " "
                        + Convert.ToString(playerCard9) + " "
                        + Convert.ToString(playerCard10);
                }
                else if (playerCard4 == 11)
                {
                    playerCard4 = 1;
                    lblPlayerCards.Text = "Your cards: "
                    + Convert.ToString(playerCard1) + " "
                    + Convert.ToString(playerCard2) + " "
                    + Convert.ToString(playerCard3) + " "
                    + Convert.ToString(playerCard4) + " "
                    + Convert.ToString(playerCard5) + " "
                    + Convert.ToString(playerCard6) + " "
                    + Convert.ToString(playerCard7) + " "
                    + Convert.ToString(playerCard8) + " "
                    + Convert.ToString(playerCard9) + " "
                    + Convert.ToString(playerCard10);
                }
                else if (playerCard5 == 11)
                {
                    playerCard5 = 1;
                    lblPlayerCards.Text = "Your cards: "
                    + Convert.ToString(playerCard1) + " "
                    + Convert.ToString(playerCard2) + " "
                    + Convert.ToString(playerCard3) + " "
                    + Convert.ToString(playerCard4) + " "
                    + Convert.ToString(playerCard5) + " "
                    + Convert.ToString(playerCard6) + " "
                    + Convert.ToString(playerCard7) + " "
                    + Convert.ToString(playerCard8) + " "
                    + Convert.ToString(playerCard9) + " "
                    + Convert.ToString(playerCard10);
                }
                else if (playerCard6 == 11)
                {
                    playerCard6 = 1;
                    lblPlayerCards.Text = "Your cards: "
                        + Convert.ToString(playerCard1) + " "
                        + Convert.ToString(playerCard2) + " "
                        + Convert.ToString(playerCard3) + " "
                        + Convert.ToString(playerCard4) + " "
                        + Convert.ToString(playerCard5) + " "
                        + Convert.ToString(playerCard6) + " "
                        + Convert.ToString(playerCard7) + " "
                        + Convert.ToString(playerCard8) + " "
                        + Convert.ToString(playerCard9) + " "
                        + Convert.ToString(playerCard10);
                }
                else if (playerCard7 == 11)
                {
                    playerCard7 = 1;
                    lblPlayerCards.Text = "Your cards: "
                        + Convert.ToString(playerCard1) + " "
                        + Convert.ToString(playerCard2) + " "
                        + Convert.ToString(playerCard3) + " "
                        + Convert.ToString(playerCard4) + " "
                        + Convert.ToString(playerCard5) + " "
                        + Convert.ToString(playerCard6) + " "
                        + Convert.ToString(playerCard7) + " "
                        + Convert.ToString(playerCard8) + " "
                        + Convert.ToString(playerCard9) + " "
                        + Convert.ToString(playerCard10);
                }
                else if (playerCard8 == 11)
                {
                    playerCard8 = 1;
                    lblPlayerCards.Text = "Your cards: "
                        + Convert.ToString(playerCard1) + " "
                        + Convert.ToString(playerCard2) + " "
                        + Convert.ToString(playerCard3) + " "
                        + Convert.ToString(playerCard4) + " "
                        + Convert.ToString(playerCard5) + " "
                        + Convert.ToString(playerCard6) + " "
                        + Convert.ToString(playerCard7) + " "
                        + Convert.ToString(playerCard8) + " "
                        + Convert.ToString(playerCard9) + " "
                        + Convert.ToString(playerCard10);
                }
                else if (playerCard9 == 11)
                {
                    playerCard9 = 1;
                    lblPlayerCards.Text = "Your cards: "
                        + Convert.ToString(playerCard1) + " "
                        + Convert.ToString(playerCard2) + " "
                        + Convert.ToString(playerCard3) + " "
                        + Convert.ToString(playerCard4) + " "
                        + Convert.ToString(playerCard5) + " "
                        + Convert.ToString(playerCard6) + " "
                        + Convert.ToString(playerCard7) + " "
                        + Convert.ToString(playerCard8) + " "
                        + Convert.ToString(playerCard9) + " "
                        + Convert.ToString(playerCard10);
                }
                else if (playerCard10 == 11)
                {
                    playerCard10 = 1;
                    lblPlayerCards.Text = "Your cards: "
                        + Convert.ToString(playerCard1) + " "
                        + Convert.ToString(playerCard2) + " "
                        + Convert.ToString(playerCard3) + " "
                        + Convert.ToString(playerCard4) + " "
                        + Convert.ToString(playerCard5) + " "
                        + Convert.ToString(playerCard6) + " "
                        + Convert.ToString(playerCard7) + " "
                        + Convert.ToString(playerCard8) + " "
                        + Convert.ToString(playerCard9) + " "
                        + Convert.ToString(playerCard10);
                }
                #endregion
                else
                {
                    lblMessages.Text = "You've busted and lost double your bet!";
                    lblMessages.Show();
                    lblPlayerCards.Text = "Player: BUST";
                    playerTotal -= playerBet;
                    dealerTotal += playerBet;
                    playerBet = 0;
                    lblPlayerBet.Text = "Player bet: BUST";
                    lblPlayerTotal.Text = "Your total: $" + Convert.ToString(playerTotal);
                    lblDealerTotal.Text = "Your total: $" + Convert.ToString(dealerTotal);
                }
            }
            //Disable the buttons as you've doubled down
            btnSurrender.Enabled = false;
            btnStand.Enabled = false;
            btnHit.Enabled = false;
            btnDoubleDown.Enabled = false;
            btnSplit.Enabled = false;
            btnInsurance.Enabled = false;

            //continue with the COM and dealer turns
            btnContinue.Enabled = true;
            btnContinue.Show();
        }
        #endregion

        #region Insurance
        private void BtnInsurance_Click(object sender, EventArgs e)
        {
            //hide the message label for convenience
            lblMessages.Hide();

            if (dealerCard2 == 10)
            {
                //Cases for if you won the bet

                //Shows up in the middle of the screen to inform you of your success
                lblMessages.Text = "All the COM players took the bet, " +
                    "like they always do, and so lost nothing. " +
                    //line break
                    Environment.NewLine +
                    "You also lost nothing.";

                //if you had a blackjack
                if (playerCard1 + playerCard2 == 21)
                {
                    playerTotal += (int)(playerBet * 1.5);
                    dealerTotal -= (int)(playerBet * 1.5);
                    playerBet = 0;
                    lblPlayerBet.Text = "Player bet: BLACKJACK";
                    lblMessages.Text += Environment.NewLine +
                        "As you got a blackjack, you also got your full payout";
                    lblPlayerTotal.Text = "Player's Total: $" + Convert.ToString(playerTotal);
                    lblDealerTotal.Text = "Dealer's Total: $" + Convert.ToString(dealerTotal);
                }
                lblMessages.Show();

                //Disable the buttons, as your turn has effectively ended
                btnSurrender.Enabled = false;
                btnStand.Enabled = false;
                btnHit.Enabled = false;
                btnDoubleDown.Enabled = false;
                btnSplit.Enabled = false;
                btnInsurance.Enabled = false;

                //Enable the replay button
                btnReplay.Enabled = true;
                btnReplay.Show();
            }
            else
            {
                //cases for if you lost the bet
                lblMessages.Text += "You lost this bet.";
                lblMessages.Show();

                //If there are any number of COM players
                if (playerAmount >= 1)
                {
                    lblMessages.Text = "All the COM players took the bet, " +
                        "like they always do, and so lost this bet. " +
                        //line break
                        Environment.NewLine;

                    //Remove half of COM1's bet from their total
                    com1Total -= com1Bet / 2;
                    lblCom1Total.Text = "COM1's Total: $" + Convert.ToString(com1Total);

                    //Remove half of COM2's bet from their total
                    if (playerAmount >= 2)
                    {
                        com2Total -= com2Bet / 2;
                        lblCom2Total.Text = "COM2's Total: $" + Convert.ToString(com2Total);
                    }

                    //Remove half of COM3's bet from their total
                    if (playerAmount >= 3)
                    {
                        com3Total -= com3Bet / 2;
                        lblCom3Total.Text = "COM3's Total: $" + Convert.ToString(com3Total);
                    }
                }


                //Remove half of the user's bet from the user's total
                playerTotal -= playerBet / 2;
                dealerTotal += playerBet / 2;
                lblPlayerTotal.Text = "Player's Total: $" + Convert.ToString(playerTotal);

                //disable the insurance button, and enable the regular buttons
                btnInsurance.Enabled = false;

                //If you have a blackjack, you automatically win
                //All you need to do is go through COM's and the dealer's turns
                if (playerCard1 + playerCard2 == 21)
                {
                    playerTotal += (int)(playerBet * 1.5);
                    dealerTotal -= (int)(playerBet * 1.5);
                    playerBet = 0;
                    //Continue with COM and dealer turns
                    btnContinue.Enabled = true;
                    btnContinue.Show();
                }
            }
        }
        #endregion

        #region Stand
        private void BtnStand_Click(object sender, EventArgs e)
        {
            //if there is no second hand
            if (playerD2C1 == 0)
            {
                //disable the buttons as you ended your turn
                btnSurrender.Enabled = false;
                btnStand.Enabled = false;
                btnHit.Enabled = false;
                btnDoubleDown.Enabled = false;
                btnSplit.Enabled = false;
                btnInsurance.Enabled = false;

                //continue with COM and dealer turns
                btnContinue.Enabled = true;
                btnContinue.Show();

                //add up all the cards
                playerCardSum = playerCard1 + playerCard2 +
                   playerCard3 + playerCard4 +
                   playerCard5 + playerCard6 +
                   playerCard7 + playerCard8 +
                   playerCard9 + playerCard10;

                playerCard1 = 0;
                playerCard2 = 0;
                playerCard3 = 0;
                playerCard4 = 0;
                playerCard5 = 0;
                playerCard6 = 0;
                playerCard7 = 0;
                playerCard8 = 0;
                playerCard9 = 0;
                playerCard10 = 0;

                lblMessages.Text = "Your hand has been tallied up,"
                    + Environment.NewLine +
                    "and you can now observe the COM's and dealer's turns.";
                lblMessages.Show();

                lblPlayerCards.Text = "Your Card Total: " + Convert.ToString(playerCardSum);
            }
            //if the second hand is present, but hasn't been interacted with yet
            //there's no possibility of having more than one card in your second hand here
            else if (playerCardSum2 > playerD2C1)
            {
                playerCardSum = playerCard1 + playerCard2 +
                   playerCard3 + playerCard4 +
                   playerCard5 + playerCard6 +
                   playerCard7 + playerCard8 +
                   playerCard9 + playerCard10;

                playerCard1 = 0;
                playerCard2 = 0;
                playerCard3 = 0;
                playerCard4 = 0;
                playerCard5 = 0;
                playerCard6 = 0;
                playerCard7 = 0;
                playerCard8 = 0;
                playerCard9 = 0;
                playerCard10 = 0;

                lblMessages.Text = "Your first hand has been tallied up,"
                    + Environment.NewLine +
                    "and you can now use your second hand";
                lblMessages.Show();

                lblPlayerCards.Text = "Your Card Total: " + Convert.ToString(playerCardSum);
            }
            //once you are finished with the second hand
            else
            {
                //add up all the cards
                playerCardSum2 = playerD2C1 + playerD2C2 +
                   playerD2C3 + playerD2C4 +
                   playerD2C5 + playerD2C6 +
                   playerD2C7 + playerD2C8 +
                   playerD2C9 + playerD2C10;

                playerD2C1 = 0;
                playerD2C2 = 0;
                playerD2C3 = 0;
                playerD2C4 = 0;
                playerD2C5 = 0;
                playerD2C6 = 0;
                playerD2C7 = 0;
                playerD2C8 = 0;
                playerD2C9 = 0;
                playerD2C10 = 0;

                lblMessages.Text = "Your second hand has been tallied up,"
                    + Environment.NewLine +
                    "and you can now observe the COM's and dealer's turns.";
                lblMessages.Show();

                lblPlayerCards2.Text = "Your Card Total: " + Convert.ToString(playerCardSum2);
            }
        }
        #endregion

        #region Hit
        private void BtnHit_Click(object sender, EventArgs e)
        {
            //hide the message label for convenience
            lblMessages.Hide();

            //This checks if your first card has been reset
            //If it has been reset, that means that you have a second hand of cards
            //And that your first hand has been finalized
            //Then, it will generate cards for the second hand
            if (playerCard1 != 0)
            {
                #region Card Generation
                //Generates cards
                if (playerCard2 == 0)
                {
                    playerCard2 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                    lblPlayerCards.Text = "Your cards: "
                            + Convert.ToString(playerCard1) + " "
                            + Convert.ToString(playerCard2) + " "
                            + Convert.ToString(playerCard3) + " "
                            + Convert.ToString(playerCard4) + " "
                            + Convert.ToString(playerCard5) + " "
                            + Convert.ToString(playerCard6) + " "
                            + Convert.ToString(playerCard7) + " "
                            + Convert.ToString(playerCard8) + " "
                            + Convert.ToString(playerCard9) + " "
                            + Convert.ToString(playerCard10);
                }
                else if (playerCard3 == 0)
                {
                    playerCard3 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                    lblPlayerCards.Text = "Your cards: "
                            + Convert.ToString(playerCard1) + " "
                            + Convert.ToString(playerCard2) + " "
                            + Convert.ToString(playerCard3) + " "
                            + Convert.ToString(playerCard4) + " "
                            + Convert.ToString(playerCard5) + " "
                            + Convert.ToString(playerCard6) + " "
                            + Convert.ToString(playerCard7) + " "
                            + Convert.ToString(playerCard8) + " "
                            + Convert.ToString(playerCard9) + " "
                            + Convert.ToString(playerCard10);
                }
                else if (playerCard4 == 0)
                {
                    playerCard4 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                    lblPlayerCards.Text = "Your cards: "
                            + Convert.ToString(playerCard1) + " "
                            + Convert.ToString(playerCard2) + " "
                            + Convert.ToString(playerCard3) + " "
                            + Convert.ToString(playerCard4) + " "
                            + Convert.ToString(playerCard5) + " "
                            + Convert.ToString(playerCard6) + " "
                            + Convert.ToString(playerCard7) + " "
                            + Convert.ToString(playerCard8) + " "
                            + Convert.ToString(playerCard9) + " "
                            + Convert.ToString(playerCard10);
                }
                else if (playerCard5 == 0)
                {
                    playerCard5 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                    lblPlayerCards.Text = "Your cards: "
                            + Convert.ToString(playerCard1) + " "
                            + Convert.ToString(playerCard2) + " "
                            + Convert.ToString(playerCard3) + " "
                            + Convert.ToString(playerCard4) + " "
                            + Convert.ToString(playerCard5) + " "
                            + Convert.ToString(playerCard6) + " "
                            + Convert.ToString(playerCard7) + " "
                            + Convert.ToString(playerCard8) + " "
                            + Convert.ToString(playerCard9) + " "
                            + Convert.ToString(playerCard10);
                }
                else if (playerCard6 == 0)
                {
                    playerCard6 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                    lblPlayerCards.Text = "Your cards: "
                            + Convert.ToString(playerCard1) + " "
                            + Convert.ToString(playerCard2) + " "
                            + Convert.ToString(playerCard3) + " "
                            + Convert.ToString(playerCard4) + " "
                            + Convert.ToString(playerCard5) + " "
                            + Convert.ToString(playerCard6) + " "
                            + Convert.ToString(playerCard7) + " "
                            + Convert.ToString(playerCard8) + " "
                            + Convert.ToString(playerCard9) + " "
                            + Convert.ToString(playerCard10);
                }
                else if (playerCard7 == 0)
                {
                    playerCard7 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                    lblPlayerCards.Text = "Your cards: "
                            + Convert.ToString(playerCard1) + " "
                            + Convert.ToString(playerCard2) + " "
                            + Convert.ToString(playerCard3) + " "
                            + Convert.ToString(playerCard4) + " "
                            + Convert.ToString(playerCard5) + " "
                            + Convert.ToString(playerCard6) + " "
                            + Convert.ToString(playerCard7) + " "
                            + Convert.ToString(playerCard8) + " "
                            + Convert.ToString(playerCard9) + " "
                            + Convert.ToString(playerCard10);
                }
                else if (playerCard8 == 0)
                {
                    playerCard8 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                    lblPlayerCards.Text = "Your cards: "
                            + Convert.ToString(playerCard1) + " "
                            + Convert.ToString(playerCard2) + " "
                            + Convert.ToString(playerCard3) + " "
                            + Convert.ToString(playerCard4) + " "
                            + Convert.ToString(playerCard5) + " "
                            + Convert.ToString(playerCard6) + " "
                            + Convert.ToString(playerCard7) + " "
                            + Convert.ToString(playerCard8) + " "
                            + Convert.ToString(playerCard9) + " "
                            + Convert.ToString(playerCard10);
                }
                else if (playerCard9 == 0)
                {
                    playerCard9 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                    lblPlayerCards.Text = "Your cards: "
                            + Convert.ToString(playerCard1) + " "
                            + Convert.ToString(playerCard2) + " "
                            + Convert.ToString(playerCard3) + " "
                            + Convert.ToString(playerCard4) + " "
                            + Convert.ToString(playerCard5) + " "
                            + Convert.ToString(playerCard6) + " "
                            + Convert.ToString(playerCard7) + " "
                            + Convert.ToString(playerCard8) + " "
                            + Convert.ToString(playerCard9) + " "
                            + Convert.ToString(playerCard10);
                }
                else
                {
                    playerCard10 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                    lblPlayerCards.Text = "Your cards: "
                        + Convert.ToString(playerCard1) + " "
                        + Convert.ToString(playerCard2) + " "
                        + Convert.ToString(playerCard3) + " "
                        + Convert.ToString(playerCard4) + " "
                        + Convert.ToString(playerCard5) + " "
                        + Convert.ToString(playerCard6) + " "
                        + Convert.ToString(playerCard7) + " "
                        + Convert.ToString(playerCard8) + " "
                        + Convert.ToString(playerCard9) + " "
                        + Convert.ToString(playerCard10);
                    //Disable hitting as you've reached the max amount of cards
                    btnHit.Enabled = false;
                    btnDoubleDown.Enabled = false;

                }
                #endregion
            }
            else
            {
                #region Card Generation
                //Generates cards for the second deck
                if (playerD2C2 == 0)
                {
                    playerD2C2 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                    lblPlayerCards2.Text = "Your cards: "
                                                    + Convert.ToString(playerD2C1) + " "
                                                    + Convert.ToString(playerD2C2) + " "
                                                    + Convert.ToString(playerD2C3) + " "
                                                    + Convert.ToString(playerD2C4) + " "
                                                    + Convert.ToString(playerD2C5) + " "
                                                    + Convert.ToString(playerD2C6) + " "
                                                    + Convert.ToString(playerD2C7) + " "
                                                    + Convert.ToString(playerD2C8) + " "
                                                    + Convert.ToString(playerD2C9) + " "
                                                    + Convert.ToString(playerD2C10);
                }
                else if (playerD2C3 == 0)
                {
                    playerD2C3 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                    lblPlayerCards2.Text = "Your cards: "
                                                    + Convert.ToString(playerD2C1) + " "
                                                    + Convert.ToString(playerD2C2) + " "
                                                    + Convert.ToString(playerD2C3) + " "
                                                    + Convert.ToString(playerD2C4) + " "
                                                    + Convert.ToString(playerD2C5) + " "
                                                    + Convert.ToString(playerD2C6) + " "
                                                    + Convert.ToString(playerD2C7) + " "
                                                    + Convert.ToString(playerD2C8) + " "
                                                    + Convert.ToString(playerD2C9) + " "
                                                    + Convert.ToString(playerD2C10);
                }
                else if (playerD2C4 == 0)
                {
                    playerD2C4 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                    lblPlayerCards2.Text = "Your cards: "
                                                    + Convert.ToString(playerD2C1) + " "
                                                    + Convert.ToString(playerD2C2) + " "
                                                    + Convert.ToString(playerD2C3) + " "
                                                    + Convert.ToString(playerD2C4) + " "
                                                    + Convert.ToString(playerD2C5) + " "
                                                    + Convert.ToString(playerD2C6) + " "
                                                    + Convert.ToString(playerD2C7) + " "
                                                    + Convert.ToString(playerD2C8) + " "
                                                    + Convert.ToString(playerD2C9) + " "
                                                    + Convert.ToString(playerD2C10);
                }
                else if (playerD2C5 == 0)
                {
                    playerD2C5 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                    lblPlayerCards2.Text = "Your cards: "
                                                    + Convert.ToString(playerD2C1) + " "
                                                    + Convert.ToString(playerD2C2) + " "
                                                    + Convert.ToString(playerD2C3) + " "
                                                    + Convert.ToString(playerD2C4) + " "
                                                    + Convert.ToString(playerD2C5) + " "
                                                    + Convert.ToString(playerD2C6) + " "
                                                    + Convert.ToString(playerD2C7) + " "
                                                    + Convert.ToString(playerD2C8) + " "
                                                    + Convert.ToString(playerD2C9) + " "
                                                    + Convert.ToString(playerD2C10);
                }
                else if (playerD2C6 == 0)
                {
                    playerD2C6 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                    lblPlayerCards2.Text = "Your cards: "
                                                    + Convert.ToString(playerD2C1) + " "
                                                    + Convert.ToString(playerD2C2) + " "
                                                    + Convert.ToString(playerD2C3) + " "
                                                    + Convert.ToString(playerD2C4) + " "
                                                    + Convert.ToString(playerD2C5) + " "
                                                    + Convert.ToString(playerD2C6) + " "
                                                    + Convert.ToString(playerD2C7) + " "
                                                    + Convert.ToString(playerD2C8) + " "
                                                    + Convert.ToString(playerD2C9) + " "
                                                    + Convert.ToString(playerD2C10);
                }
                else if (playerD2C7 == 0)
                {
                    playerD2C7 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                    lblPlayerCards2.Text = "Your cards: "
                                                    + Convert.ToString(playerD2C1) + " "
                                                    + Convert.ToString(playerD2C2) + " "
                                                    + Convert.ToString(playerD2C3) + " "
                                                    + Convert.ToString(playerD2C4) + " "
                                                    + Convert.ToString(playerD2C5) + " "
                                                    + Convert.ToString(playerD2C6) + " "
                                                    + Convert.ToString(playerD2C7) + " "
                                                    + Convert.ToString(playerD2C8) + " "
                                                    + Convert.ToString(playerD2C9) + " "
                                                    + Convert.ToString(playerD2C10);
                }
                else if (playerD2C8 == 0)
                {
                    playerD2C8 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                    lblPlayerCards2.Text = "Your cards: "
                                                    + Convert.ToString(playerD2C1) + " "
                                                    + Convert.ToString(playerD2C2) + " "
                                                    + Convert.ToString(playerD2C3) + " "
                                                    + Convert.ToString(playerD2C4) + " "
                                                    + Convert.ToString(playerD2C5) + " "
                                                    + Convert.ToString(playerD2C6) + " "
                                                    + Convert.ToString(playerD2C7) + " "
                                                    + Convert.ToString(playerD2C8) + " "
                                                    + Convert.ToString(playerD2C9) + " "
                                                    + Convert.ToString(playerD2C10);
                }
                else if (playerD2C9 == 0)
                {
                    playerD2C9 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                    lblPlayerCards2.Text = "Your cards: "
                                                + Convert.ToString(playerD2C1) + " "
                                                + Convert.ToString(playerD2C2) + " "
                                                + Convert.ToString(playerD2C3) + " "
                                                + Convert.ToString(playerD2C4) + " "
                                                + Convert.ToString(playerD2C5) + " "
                                                + Convert.ToString(playerD2C6) + " "
                                                + Convert.ToString(playerD2C7) + " "
                                                + Convert.ToString(playerD2C8) + " "
                                                + Convert.ToString(playerD2C9) + " "
                                                + Convert.ToString(playerD2C10);
                }
                else
                {
                    playerD2C10 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                    lblPlayerCards2.Text = "Your cards: "
                                                + Convert.ToString(playerD2C1) + " "
                                                + Convert.ToString(playerD2C2) + " "
                                                + Convert.ToString(playerD2C3) + " "
                                                + Convert.ToString(playerD2C4) + " "
                                                + Convert.ToString(playerD2C5) + " "
                                                + Convert.ToString(playerD2C6) + " "
                                                + Convert.ToString(playerD2C7) + " "
                                                + Convert.ToString(playerD2C8) + " "
                                                + Convert.ToString(playerD2C9) + " "
                                                + Convert.ToString(playerD2C10);
                    //disable hitting as you've reached the limit for drawing cards
                    btnDoubleDown.Enabled = false;
                    btnHit.Enabled = false;
                }
                #endregion
            }
            //adds up all your cards 
            playerCardSum = playerCard1 + playerCard2 +
                playerCard3 + playerCard4 +
                playerCard5 + playerCard6 +
                playerCard7 + playerCard8 +
                playerCard9 + playerCard10;

            //checks if you've busted
            if (playerCardSum > 21)
            {
                #region Ace Conversion
                //this converts any cards that happen to be an ace into a one
                //It then updates the numbers displayed
                //I don't know how to optimize this
                if (playerCard1 == 11)
                {
                    playerCard1 = 1;
                    lblPlayerCards.Text = "Your cards: "
                        + Convert.ToString(playerCard1) + " "
                        + Convert.ToString(playerCard2) + " "
                        + Convert.ToString(playerCard3) + " "
                        + Convert.ToString(playerCard4) + " "
                        + Convert.ToString(playerCard5) + " "
                        + Convert.ToString(playerCard6) + " "
                        + Convert.ToString(playerCard7) + " "
                        + Convert.ToString(playerCard8) + " "
                        + Convert.ToString(playerCard9) + " "
                        + Convert.ToString(playerCard10);
                }
                else if (playerCard2 == 11)
                {
                    playerCard2 = 1;
                    lblPlayerCards.Text = "Your cards: "
                        + Convert.ToString(playerCard1) + " "
                        + Convert.ToString(playerCard2) + " "
                        + Convert.ToString(playerCard3) + " "
                        + Convert.ToString(playerCard4) + " "
                        + Convert.ToString(playerCard5) + " "
                        + Convert.ToString(playerCard6) + " "
                        + Convert.ToString(playerCard7) + " "
                        + Convert.ToString(playerCard8) + " "
                        + Convert.ToString(playerCard9) + " "
                        + Convert.ToString(playerCard10);
                }
                else if (playerCard3 == 11)
                {
                    playerCard3 = 1;
                    lblPlayerCards.Text = "Your cards: "
                        + Convert.ToString(playerCard1) + " "
                        + Convert.ToString(playerCard2) + " "
                        + Convert.ToString(playerCard3) + " "
                        + Convert.ToString(playerCard4) + " "
                        + Convert.ToString(playerCard5) + " "
                        + Convert.ToString(playerCard6) + " "
                        + Convert.ToString(playerCard7) + " "
                        + Convert.ToString(playerCard8) + " "
                        + Convert.ToString(playerCard9) + " "
                        + Convert.ToString(playerCard10);
                }
                else if (playerCard4 == 11)
                {
                    playerCard4 = 1;
                    lblPlayerCards.Text = "Your cards: "
                        + Convert.ToString(playerCard1) + " "
                        + Convert.ToString(playerCard2) + " "
                        + Convert.ToString(playerCard3) + " "
                        + Convert.ToString(playerCard4) + " "
                        + Convert.ToString(playerCard5) + " "
                        + Convert.ToString(playerCard6) + " "
                        + Convert.ToString(playerCard7) + " "
                        + Convert.ToString(playerCard8) + " "
                        + Convert.ToString(playerCard9) + " "
                        + Convert.ToString(playerCard10);
                }
                else if (playerCard5 == 11)
                {
                    playerCard5 = 1;
                    lblPlayerCards.Text = "Your cards: "
                        + Convert.ToString(playerCard1) + " "
                        + Convert.ToString(playerCard2) + " "
                        + Convert.ToString(playerCard3) + " "
                        + Convert.ToString(playerCard4) + " "
                        + Convert.ToString(playerCard5) + " "
                        + Convert.ToString(playerCard6) + " "
                        + Convert.ToString(playerCard7) + " "
                        + Convert.ToString(playerCard8) + " "
                        + Convert.ToString(playerCard9) + " "
                        + Convert.ToString(playerCard10);
                }
                else if (playerCard6 == 11)
                {
                    playerCard6 = 1;
                    lblPlayerCards.Text = "Your cards: "
                        + Convert.ToString(playerCard1) + " "
                        + Convert.ToString(playerCard2) + " "
                        + Convert.ToString(playerCard3) + " "
                        + Convert.ToString(playerCard4) + " "
                        + Convert.ToString(playerCard5) + " "
                        + Convert.ToString(playerCard6) + " "
                        + Convert.ToString(playerCard7) + " "
                        + Convert.ToString(playerCard8) + " "
                        + Convert.ToString(playerCard9) + " "
                        + Convert.ToString(playerCard10);
                }
                else if (playerCard7 == 11)
                {
                    playerCard7 = 1;
                    lblPlayerCards.Text = "Your cards: "
                        + Convert.ToString(playerCard1) + " "
                        + Convert.ToString(playerCard2) + " "
                        + Convert.ToString(playerCard3) + " "
                        + Convert.ToString(playerCard4) + " "
                        + Convert.ToString(playerCard5) + " "
                        + Convert.ToString(playerCard6) + " "
                        + Convert.ToString(playerCard7) + " "
                        + Convert.ToString(playerCard8) + " "
                        + Convert.ToString(playerCard9) + " "
                        + Convert.ToString(playerCard10);
                }
                else if (playerCard8 == 11)
                {
                    playerCard8 = 1;
                    lblPlayerCards.Text = "Your cards: "
                        + Convert.ToString(playerCard1) + " "
                        + Convert.ToString(playerCard2) + " "
                        + Convert.ToString(playerCard3) + " "
                        + Convert.ToString(playerCard4) + " "
                        + Convert.ToString(playerCard5) + " "
                        + Convert.ToString(playerCard6) + " "
                        + Convert.ToString(playerCard7) + " "
                        + Convert.ToString(playerCard8) + " "
                        + Convert.ToString(playerCard9) + " "
                        + Convert.ToString(playerCard10);
                }
                else if (playerCard9 == 11)
                {
                    playerCard9 = 1;
                    lblPlayerCards.Text = "Your cards: "
                        + Convert.ToString(playerCard1) + " "
                        + Convert.ToString(playerCard2) + " "
                        + Convert.ToString(playerCard3) + " "
                        + Convert.ToString(playerCard4) + " "
                        + Convert.ToString(playerCard5) + " "
                        + Convert.ToString(playerCard6) + " "
                        + Convert.ToString(playerCard7) + " "
                        + Convert.ToString(playerCard8) + " "
                        + Convert.ToString(playerCard9) + " "
                        + Convert.ToString(playerCard10);
                }
                else if (playerCard10 == 11)
                {
                    playerCard10 = 1;
                    lblPlayerCards.Text = "Your cards: "
                        + Convert.ToString(playerCard1) + " "
                        + Convert.ToString(playerCard2) + " "
                        + Convert.ToString(playerCard3) + " "
                        + Convert.ToString(playerCard4) + " "
                        + Convert.ToString(playerCard5) + " "
                        + Convert.ToString(playerCard6) + " "
                        + Convert.ToString(playerCard7) + " "
                        + Convert.ToString(playerCard8) + " "
                        + Convert.ToString(playerCard9) + " "
                        + Convert.ToString(playerCard10);
                }
                #endregion
                else
                {
                    lblMessages.Text = "You've busted and lost your bet!";
                    lblMessages.Show();

                    playerTotal -= playerBet;
                    dealerTotal += playerBet;
                    playerBet = 0;
                    lblPlayerBet.Text = "Player bet: BUST";
                    lblPlayerTotal.Text = "Your total: $" + Convert.ToString(playerTotal);

                    //checks if you've split your cards 
                    if (playerD2C1 == 0)
                    {
                        //Disable everything but continuing, as you've lost
                        btnHit.Enabled = false;
                        btnDoubleDown.Enabled = false;
                        btnStand.Enabled = false;
                        btnSurrender.Enabled = false;
                        btnInsurance.Enabled = false;
                        btnSplit.Enabled = false;

                        lblPlayerCards.Text = "Player: BUST";

                        //Show the continue button
                        btnContinue.Enabled = true;
                        btnContinue.Show();
                    }
                    else
                    {
                        lblMessages.Text += Environment.NewLine + "Good thing you have a second hand";
                        lblPlayerCards.Text = "Player: BUST";

                        //reset card values
                        playerCard1 = 0;
                        playerCard2 = 0;
                        playerCard3 = 0;
                        playerCard4 = 0;
                        playerCard5 = 0;
                        playerCard6 = 0;
                        playerCard7 = 0;
                        playerCard8 = 0;
                        playerCard9 = 0;
                        playerCard10 = 0;
                    }
                }
            }

            //adds up the cards of your second deck if you have one 
            if (playerD2C1 != 0)
            {
                playerCardSum2 = playerD2C1 + playerD2C2 +
                                playerD2C3 + playerD2C4 +
                                playerD2C5 + playerD2C6 +
                                playerD2C7 + playerD2C8 +
                                playerD2C9 + playerD2C10;

                //checks to see if you've busted
                if (playerCardSum2 > 21)
                {
                    #region Ace Conversion
                    //this converts any cards that happen to be an ace into a one
                    //I don't know how to optimize this
                    if (playerD2C1 == 11)
                    {
                        playerD2C1 = 1;
                        lblPlayerCards.Text = "Your cards: "
                            + Convert.ToString(playerD2C1) + " "
                            + Convert.ToString(playerD2C2) + " "
                            + Convert.ToString(playerD2C3) + " "
                            + Convert.ToString(playerD2C4) + " "
                            + Convert.ToString(playerD2C5) + " "
                            + Convert.ToString(playerD2C6) + " "
                            + Convert.ToString(playerD2C7) + " "
                            + Convert.ToString(playerD2C8) + " "
                            + Convert.ToString(playerD2C9) + " "
                            + Convert.ToString(playerD2C10);
                    }
                    else if (playerD2C2 == 11)
                    {
                        playerD2C2 = 1;
                        lblPlayerCards2.Text = "Your cards: "
                            + Convert.ToString(playerD2C1) + " "
                            + Convert.ToString(playerD2C2) + " "
                            + Convert.ToString(playerD2C3) + " "
                            + Convert.ToString(playerD2C4) + " "
                            + Convert.ToString(playerD2C5) + " "
                            + Convert.ToString(playerD2C6) + " "
                            + Convert.ToString(playerD2C7) + " "
                            + Convert.ToString(playerD2C8) + " "
                            + Convert.ToString(playerD2C9) + " "
                            + Convert.ToString(playerD2C10);
                    }
                    if (playerD2C3 == 11)
                    {
                        playerD2C3 = 1;
                        lblPlayerCards2.Text = "Your cards: "
                            + Convert.ToString(playerD2C1) + " "
                            + Convert.ToString(playerD2C2) + " "
                            + Convert.ToString(playerD2C3) + " "
                            + Convert.ToString(playerD2C4) + " "
                            + Convert.ToString(playerD2C5) + " "
                            + Convert.ToString(playerD2C6) + " "
                            + Convert.ToString(playerD2C7) + " "
                            + Convert.ToString(playerD2C8) + " "
                            + Convert.ToString(playerD2C9) + " "
                            + Convert.ToString(playerD2C10);
                    }
                    else if (playerD2C4 == 11)
                    {
                        playerD2C4 = 1;
                        lblPlayerCards2.Text = "Your cards: "
                            + Convert.ToString(playerD2C1) + " "
                            + Convert.ToString(playerD2C2) + " "
                            + Convert.ToString(playerD2C3) + " "
                            + Convert.ToString(playerD2C4) + " "
                            + Convert.ToString(playerD2C5) + " "
                            + Convert.ToString(playerD2C6) + " "
                            + Convert.ToString(playerD2C7) + " "
                            + Convert.ToString(playerD2C8) + " "
                            + Convert.ToString(playerD2C9) + " "
                            + Convert.ToString(playerD2C10);
                    }
                    else if (playerD2C5 == 11)
                    {
                        playerD2C5 = 1;
                        lblPlayerCards2.Text = "Your cards: "
                            + Convert.ToString(playerD2C1) + " "
                            + Convert.ToString(playerD2C2) + " "
                            + Convert.ToString(playerD2C3) + " "
                            + Convert.ToString(playerD2C4) + " "
                            + Convert.ToString(playerD2C5) + " "
                            + Convert.ToString(playerD2C6) + " "
                            + Convert.ToString(playerD2C7) + " "
                            + Convert.ToString(playerD2C8) + " "
                            + Convert.ToString(playerD2C9) + " "
                            + Convert.ToString(playerD2C10);
                    }
                    else if (playerD2C6 == 11)
                    {
                        playerD2C6 = 1;
                        lblPlayerCards2.Text = "Your cards: "
                            + Convert.ToString(playerD2C1) + " "
                            + Convert.ToString(playerD2C2) + " "
                            + Convert.ToString(playerD2C3) + " "
                            + Convert.ToString(playerD2C4) + " "
                            + Convert.ToString(playerD2C5) + " "
                            + Convert.ToString(playerD2C6) + " "
                            + Convert.ToString(playerD2C7) + " "
                            + Convert.ToString(playerD2C8) + " "
                            + Convert.ToString(playerD2C9) + " "
                            + Convert.ToString(playerD2C10);
                    }
                    else if (playerD2C7 == 11)
                    {
                        playerD2C7 = 1;
                        lblPlayerCards2.Text = "Your cards: "
                            + Convert.ToString(playerD2C1) + " "
                            + Convert.ToString(playerD2C2) + " "
                            + Convert.ToString(playerD2C3) + " "
                            + Convert.ToString(playerD2C4) + " "
                            + Convert.ToString(playerD2C5) + " "
                            + Convert.ToString(playerD2C6) + " "
                            + Convert.ToString(playerD2C7) + " "
                            + Convert.ToString(playerD2C8) + " "
                            + Convert.ToString(playerD2C9) + " "
                            + Convert.ToString(playerD2C10);
                    }
                    else if (playerD2C8 == 11)
                    {
                        playerD2C8 = 1;
                        lblPlayerCards2.Text = "Your cards: "
                            + Convert.ToString(playerD2C1) + " "
                            + Convert.ToString(playerD2C2) + " "
                            + Convert.ToString(playerD2C3) + " "
                            + Convert.ToString(playerD2C4) + " "
                            + Convert.ToString(playerD2C5) + " "
                            + Convert.ToString(playerD2C6) + " "
                            + Convert.ToString(playerD2C7) + " "
                            + Convert.ToString(playerD2C8) + " "
                            + Convert.ToString(playerD2C9) + " "
                            + Convert.ToString(playerD2C10);
                    }
                    else if (playerD2C9 == 11)
                    {
                        playerD2C9 = 1;
                        lblPlayerCards2.Text = "Your cards: "
                            + Convert.ToString(playerD2C1) + " "
                            + Convert.ToString(playerD2C2) + " "
                            + Convert.ToString(playerD2C3) + " "
                            + Convert.ToString(playerD2C4) + " "
                            + Convert.ToString(playerD2C5) + " "
                            + Convert.ToString(playerD2C6) + " "
                            + Convert.ToString(playerD2C7) + " "
                            + Convert.ToString(playerD2C8) + " "
                            + Convert.ToString(playerD2C9) + " "
                            + Convert.ToString(playerD2C10);
                    }
                    else if (playerD2C10 == 11)
                    {
                        playerD2C10 = 1;
                        lblPlayerCards2.Text = "Your cards: "
                            + Convert.ToString(playerD2C1) + " "
                            + Convert.ToString(playerD2C2) + " "
                            + Convert.ToString(playerD2C3) + " "
                            + Convert.ToString(playerD2C4) + " "
                            + Convert.ToString(playerD2C5) + " "
                            + Convert.ToString(playerD2C6) + " "
                            + Convert.ToString(playerD2C7) + " "
                            + Convert.ToString(playerD2C8) + " "
                            + Convert.ToString(playerD2C9) + " "
                            + Convert.ToString(playerD2C10);
                    }
                    #endregion
                    else
                    {
                        lblMessages.Text = "You've busted and lost your second hand's bet!";
                        lblMessages.Show();
                        lblPlayerCards2.Text = "Player: BUST";
                        playerTotal -= playerBet2;
                        dealerTotal += playerBet2;
                        playerBet2 = 0;
                        lblPlayerTotal.Text = "Your total: $" + Convert.ToString(playerTotal);

                        //Disable everything but continuing, as you've lost
                        btnHit.Enabled = false;
                        btnDoubleDown.Enabled = false;
                        btnStand.Enabled = false;
                        btnSurrender.Enabled = false;
                        btnInsurance.Enabled = false;
                        btnSplit.Enabled = false;

                        //Show the continue button
                        btnContinue.Enabled = true;
                        btnContinue.Show();
                    }
                }
            }
        }
        #endregion

        #region Continue
        private void btnContinue_Click(object sender, EventArgs e)
        {
            #region Insurance
            //Test case for if you don't take the insurance bet
            if (btnInsurance.Enabled == true)
            {
                //insurance and the continue will no longer be needed for a bit
                btnInsurance.Enabled = false;
                btnContinue.Hide();

                //if the dealer has a blackjack then
                if (dealerCard2 == 10)
                {
                    //Display to the player that they lost
                    lblMessages.Text = "Wow, the dealer had blackjack! You lost your bet this time!";
                    lblMessages.Show();

                    //Unless they had a blackjack themselves
                    if (playerCard1 + playerCard2 == 21)
                    {
                        lblMessages.Text = "As you had blackjack, you lost nothing";
                        playerBet = 0;
                        lblPlayerBet.Text = "Player bet: DRAW";
                    }

                    playerTotal -= playerBet;
                    dealerTotal += playerBet;
                    playerBet = 0;
                    lblPlayerBet.Text = "Player bet: Dealer - BLACKJACK";

                    lblPlayerTotal.Text = "Your Total: $" + Convert.ToString(playerTotal);
                }
                else
                {
                    if (playerAmount >= 1)
                    {
                        com1Total -= com1Bet;
                        dealerTotal += com1Bet;
                        lblCom1Total.Text = "COM1's Total: $" + Convert.ToString(com1Total);
                    }
                    if (playerAmount >= 2)
                    {
                        com2Total -= com2Bet;
                        dealerTotal += com2Bet;
                        lblCom2Total.Text = "COM2's Total: $" + Convert.ToString(com2Total);
                    }
                    if (playerAmount >= 3)
                    {
                        com3Total -= com3Bet;
                        dealerTotal += com1Bet + com2Bet + com3Bet;
                        lblCom3Total.Text = "COM3's Total: $" + Convert.ToString(com3Total);
                    }

                    lblDealerTotal.Text = "Dealer's Total $" + Convert.ToString(dealerTotal);
                    lblMessages.Text = "No blackjack! Any COM players lost their insurance bet, but you didn't!";
                    lblMessages.Show();

                    //enable buttons again

                    btnStand.Enabled = true;
                    btnHit.Enabled = true;
                    btnDoubleDown.Enabled = true;
                    btnSurrender.Enabled = true;

                    //If you have doubles, you can split your hand
                    if (playerCard1 == playerCard2)
                    {
                        btnSplit.Enabled = true;
                    }
                    else
                    {
                        btnSplit.Enabled = false;
                    }

                    //If you had a blackjack
                    if (playerCard1 + playerCard2 == 21)
                    {
                        lblMessages.Text = "As you had blackjack, you automatically win";
                        playerTotal += (int)(playerBet * 1.5);
                        dealerTotal -= (int)(playerBet * 1.5);
                        playerBet = 0;
                        lblPlayerBet.Text = "Player bet: BLACKJACK";
                        lblPlayerTotal.Text = "Player's Total: $" + Convert.ToString(playerTotal);
                        lblDealerTotal.Text = "Dealer's Total: $" + Convert.ToString(dealerTotal);

                        btnSplit.Enabled = false;
                        btnStand.Enabled = false;
                        btnHit.Enabled = false;
                        btnDoubleDown.Enabled = false;
                        btnSurrender.Enabled = false;

                        btnContinue.Enabled = true;
                        btnContinue.Show();
                    }
                }
            }
            #endregion

            #region Player Turn End
            //When your turn has ended
            if (btnStand.Enabled == false)
            {
                if (playerAmount >= 1)
                {
                    #region COM1 Hit/Stand
                    //if com1 has a card
                    //the card value gets reset in the method, so that btnContinue can be clicked on again
                    if (com1Card1 != 0)
                    {
                        //check if COM1's first 2 cards are greater than 16
                        //if not, get another card until the total reaches 16 or above
                        com1CardSum = com1Card1 + com1Card2;
                        while (com1CardSum <= 16)
                        {
                            if (com1Card3 == 0)
                            {
                                com1Card3 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                            }
                            else if (com1Card4 == 0)
                            {
                                com1Card4 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                            }
                            else if (com1Card5 == 0)
                            {
                                com1Card5 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                            }
                            else if (com1Card6 == 0)
                            {
                                com1Card6 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                            }
                            else if (com1Card7 == 0)
                            {
                                com1Card7 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                            }
                            else if (com1Card8 == 0)
                            {
                                com1Card8 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                            }
                            else if (com1Card9 == 0)
                            {
                                com1Card9 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                            }
                            else if (com1Card10 == 0)
                            {
                                com1Card10 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                            }

                            com1CardSum = com1Card1 + com1Card2 +
                                com1Card3 + com1Card4 +
                                com1Card5 + com1Card6 +
                                com1Card7 + com1Card8 +
                                com1Card9 + com1Card10;

                            //Ace conversion
                            if (com1CardSum > 21)
                            {
                                //if card[number] is an ace, change it back to a value of 1
                                if (com1Card1 == 11)
                                {
                                    com1Card1 = 1;
                                }
                                else if (com1Card2 == 11)
                                {
                                    com1Card2 = 1;
                                }
                                else if (com1Card3 == 11)
                                {
                                    com1Card3 = 1;
                                }
                                else if (com1Card4 == 11)
                                {
                                    com1Card4 = 1;
                                }
                                else if (com1Card5 == 11)
                                {
                                    com1Card5 = 1;
                                }
                                else if (com1Card6 == 11)
                                {
                                    com1Card6 = 1;
                                }
                                else if (com1Card7 == 11)
                                {
                                    com1Card7 = 1;
                                }
                                else if (com1Card8 == 11)
                                {
                                    com1Card8 = 1;
                                }
                                else if (com1Card9 == 11)
                                {
                                    com1Card9 = 1;
                                }
                                else if (com1Card10 == 11)
                                {
                                    com1Card10 = 1;
                                }
                                else
                                {
                                    lblMessages.Text = "COM1 has busted, and lost their bet!";
                                    lblMessages.Show();

                                    com1Total -= com1Bet;
                                    dealerTotal += com1Bet;
                                    com1Bet = 0;
                                    lblCom1Bet.Text = "COM1 bet: BUST";
                                    lblCom1Total.Text = "COM1's Total: $" + Convert.ToString(com1Total);
                                    lblDealerTotal.Text = "Dealer's Total: $" + Convert.ToString(dealerTotal);
                                }

                                //tally up the card sum again, if there was a converted ace
                                com1CardSum = com1Card1 + com1Card2 +
                                    com1Card3 + com1Card4 +
                                    com1Card5 + com1Card6 +
                                    com1Card7 + com1Card8 +
                                    com1Card9 + com1Card10;
                            }

                            //if COM1 has equal to or lower than 21, display the card value
                            //else, display BUST
                            if (com1CardSum <= 21)
                            {
                                lblCom1Cards.Text = "COM1's Card Total: " + Convert.ToString(com1CardSum);
                            }
                            else
                            {
                                lblCom1Cards.Text = "COM1: BUST";
                            }

                            //reset the card values
                            com1Card1 = 0;
                            com1Card2 = 0;
                            com1Card3 = 0;
                            com1Card4 = 0;
                            com1Card5 = 0;
                            com1Card6 = 0;
                            com1Card7 = 0;
                            com1Card8 = 0;
                            com1Card9 = 0;
                            com1Card10 = 0;

                            break;
                        }
                    }
                    else
                    {
                        return;
                    }
                    #endregion
                }

                if (playerAmount >= 2)
                {
                    #region COM2 Hit/Stand

                    //if com2 has a card
                    //the card value gets reset in the loop, so that btnContinue can be clicked on again
                    if (com2Card1 != 0)
                    {
                        //check if COM2's first 2 cards are greater than 16
                        //if not, get another card until the total reaches 16 or above
                        com2CardSum = com2Card1 + com2Card2;
                        while (com2CardSum <= 16)
                        {
                            if (com2Card3 == 0)
                            {
                                com2Card3 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                            }
                            else if (com2Card4 == 0)
                            {
                                com2Card4 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                            }
                            else if (com2Card5 == 0)
                            {
                                com2Card5 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                            }
                            else if (com2Card6 == 0)
                            {
                                com2Card6 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                            }
                            else if (com2Card7 == 0)
                            {
                                com2Card7 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                            }
                            else if (com2Card8 == 0)
                            {
                                com2Card8 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                            }
                            else if (com2Card9 == 0)
                            {
                                com2Card9 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                            }
                            else if (com2Card10 == 0)
                            {
                                com2Card10 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                            }

                            com2CardSum = com2Card1 + com2Card2 +
                                com2Card3 + com2Card4 +
                                com2Card5 + com2Card6 +
                                com2Card7 + com2Card8 +
                                com2Card9 + com2Card10;

                            //Ace conversion
                            if (com2CardSum > 21)
                            {
                                //if card[number] is an ace, change it back to a value of 1
                                if (com2Card1 == 11)
                                {
                                    com2Card1 = 1;
                                }
                                else if (com2Card2 == 11)
                                {
                                    com2Card2 = 1;
                                }
                                else if (com2Card3 == 11)
                                {
                                    com2Card3 = 1;
                                }
                                else if (com2Card4 == 11)
                                {
                                    com2Card4 = 1;
                                }
                                else if (com2Card5 == 11)
                                {
                                    com2Card5 = 1;
                                }
                                else if (com2Card6 == 11)
                                {
                                    com2Card6 = 1;
                                }
                                else if (com2Card7 == 11)
                                {
                                    com2Card7 = 1;
                                }
                                else if (com2Card8 == 11)
                                {
                                    com2Card8 = 1;
                                }
                                else if (com2Card9 == 11)
                                {
                                    com2Card9 = 1;
                                }
                                else if (com2Card10 == 11)
                                {
                                    com2Card10 = 1;
                                }
                                else
                                {
                                    lblMessages.Text = Environment.NewLine +
                                        "COM2 has busted, and lost their bet!";
                                    lblMessages.Show();

                                    com2Total -= com2Bet;
                                    dealerTotal += com2Bet;
                                    com2Bet = 0;
                                    lblCom2Bet.Text = "COM2 bet: BUST";
                                    lblCom2Total.Text = "COM2's Total: $" + Convert.ToString(com2Total);
                                    lblDealerTotal.Text = "Dealer's Total: $" + Convert.ToString(dealerTotal);
                                }

                                com2CardSum = com2Card1 + com2Card2 +
                                    com2Card3 + com2Card4 +
                                    com2Card5 + com2Card6 +
                                    com2Card7 + com2Card8 +
                                    com2Card9 + com2Card10;
                            }

                            //if COM2 has equal to or lower than 21, display the card value
                            //else, display BUST
                            if (com2CardSum <= 21)
                            {
                                lblCom2Cards.Text = "COM2's Card Total: " + Convert.ToString(com2CardSum);
                            }
                            else
                            {
                                lblCom2Cards.Text = "COM2: BUST";
                            }

                            //reset the card values
                            com2Card1 = 0;
                            com2Card2 = 0;
                            com2Card3 = 0;
                            com2Card4 = 0;
                            com2Card5 = 0;
                            com2Card6 = 0;
                            com2Card7 = 0;
                            com2Card8 = 0;
                            com2Card9 = 0;
                            com2Card10 = 0;

                            break;
                        }
                    }
                    else
                    {
                        return;
                    }
                    #endregion
                }

                if (playerAmount >= 3)
                {
                    #region COM3 Hit/Stand

                    //if com3 has a card
                    //the card value gets reset in the loop, so that btnContinue can be clicked on again
                    if (com3Card1 != 0)
                    {
                        //check if com3's first 2 cards are greater than 16
                        //if not, get another card until the total reaches 16 or above
                        com3CardSum = com3Card1 + com3Card2;
                        while (com3CardSum <= 16)
                        {
                            if (com3Card3 == 0)
                            {
                                com3Card3 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                            }
                            else if (com3Card4 == 0)
                            {
                                com3Card4 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                            }
                            else if (com3Card5 == 0)
                            {
                                com3Card5 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                            }
                            else if (com3Card6 == 0)
                            {
                                com3Card6 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                            }
                            else if (com3Card7 == 0)
                            {
                                com3Card7 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                            }
                            else if (com3Card8 == 0)
                            {
                                com3Card8 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                            }
                            else if (com3Card9 == 0)
                            {
                                com3Card9 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                            }
                            else if (com3Card10 == 0)
                            {
                                com3Card10 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                            }

                            com3CardSum = com3Card1 + com3Card2 +
                                com3Card3 + com3Card4 +
                                com3Card5 + com3Card6 +
                                com3Card7 + com3Card8 +
                                com3Card9 + com3Card10;

                            //Ace conversion
                            if (com3CardSum > 21)
                            {
                                //if card[number] is an ace, change it back to a value of 1
                                if (com3Card1 == 11)
                                {
                                    com3Card1 = 1;
                                }
                                else if (com3Card2 == 11)
                                {
                                    com3Card2 = 1;
                                }
                                else if (com3Card3 == 11)
                                {
                                    com3Card3 = 1;
                                }
                                else if (com3Card4 == 11)
                                {
                                    com3Card4 = 1;
                                }
                                else if (com3Card5 == 11)
                                {
                                    com3Card5 = 1;
                                }
                                else if (com3Card6 == 11)
                                {
                                    com3Card6 = 1;
                                }
                                else if (com3Card7 == 11)
                                {
                                    com3Card7 = 1;
                                }
                                else if (com3Card8 == 11)
                                {
                                    com3Card8 = 1;
                                }
                                else if (com3Card9 == 11)
                                {
                                    com3Card9 = 1;
                                }
                                else if (com3Card10 == 11)
                                {
                                    com3Card10 = 1;
                                }
                                else
                                {
                                    lblMessages.Text += Environment.NewLine
                                        + "COM3 has busted, and lost their bet!";
                                    lblMessages.Show();

                                    com3Total -= com3Bet;
                                    dealerTotal += com3Bet;
                                    com3Bet = 0;
                                    lblCom3Bet.Text = "COM3 bet: BUST";
                                    lblCom3Total.Text = "COM3's Total: $" + Convert.ToString(com3Total);
                                    lblDealerTotal.Text = "Dealer's Total: $" + Convert.ToString(dealerTotal);
                                }

                                com3CardSum = com3Card1 + com3Card2 +
                                    com3Card3 + com3Card4 +
                                    com3Card5 + com3Card6 +
                                    com3Card7 + com3Card8 +
                                    com3Card9 + com3Card10;
                            }

                            //if COM3 has equal to or lower than 21, display the card value
                            //else, display BUST
                            if (com3CardSum <= 21)
                            {
                                lblCom3Cards.Text = "COM3's Card Total: " + Convert.ToString(com3CardSum);
                            }
                            else
                            {
                                lblCom3Cards.Text = "COM3: BUST";
                            }

                            //reset the card values
                            com3Card1 = 0;
                            com3Card2 = 0;
                            com3Card3 = 0;
                            com3Card4 = 0;
                            com3Card5 = 0;
                            com3Card6 = 0;
                            com3Card7 = 0;
                            com3Card8 = 0;
                            com3Card9 = 0;
                            com3Card10 = 0;

                            break;
                        }
                    }
                    else
                    {
                        return;
                    }
                    #endregion
                }
                btnDealerTurn.Enabled = true;
                btnDealerTurn.Show();
            }
            #endregion
        }
        #endregion

        #region Dealer Turn
        private void btnDealerTurn_Click(object sender, EventArgs e)
        {
            #region Dealer Hit/Stand
            //check if dealer's first 2 cards are greater than 16
            //if not, get another card until the total reaches 16 or above
            dealerCardSum = dealerCard1 + dealerCard2;

            while (dealerCardSum <= 17)
            {
                if (dealerCard3 == 0)
                {
                    dealerCard3 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                }
                else if (dealerCard4 == 0)
                {
                    dealerCard4 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                }
                else if (dealerCard5 == 0)
                {
                    dealerCard5 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                }
                else if (dealerCard6 == 0)
                {
                    dealerCard6 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                }
                else if (dealerCard7 == 0)
                {
                    dealerCard7 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                }
                else if (dealerCard8 == 0)
                {
                    dealerCard8 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                }
                else if (dealerCard9 == 0)
                {
                    dealerCard9 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                }
                else if (dealerCard10 == 0)
                {
                    dealerCard10 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                }

                dealerCardSum = dealerCard1 + dealerCard2 +
                    dealerCard3 + dealerCard4 +
                    dealerCard5 + dealerCard6 +
                    dealerCard7 + dealerCard8 +
                    dealerCard9 + dealerCard10;

                //Ace conversion
                if (dealerCardSum > 21)
                {
                    //if card[number] is an ace, change it back to a value of 1
                    if (dealerCard1 == 11)
                    {
                        dealerCard1 = 1;
                    }
                    else if (dealerCard2 == 11)
                    {
                        dealerCard2 = 1;
                    }
                    else if (dealerCard3 == 11)
                    {
                        dealerCard3 = 1;
                    }
                    else if (dealerCard4 == 11)
                    {
                        dealerCard4 = 1;
                    }
                    else if (dealerCard5 == 11)
                    {
                        dealerCard5 = 1;
                    }
                    else if (dealerCard6 == 11)
                    {
                        dealerCard6 = 1;
                    }
                    else if (dealerCard7 == 11)
                    {
                        dealerCard7 = 1;
                    }
                    else if (dealerCard8 == 11)
                    {
                        dealerCard8 = 1;
                    }
                    else if (dealerCard9 == 11)
                    {
                        dealerCard9 = 1;
                    }
                    else if (dealerCard10 == 11)
                    {
                        dealerCard10 = 1;
                    }
                    else
                    {
                        lblMessages.Text = "Dealer has busted, and remaining players won!";
                        lblMessages.Show();
                        btnDealerTurn.Enabled = false;
                        btnReplay.Enabled = true;
                        btnReplay.Show();

                        //Note that if any of these bets were to have been gained or lost before, 
                        //they would've been reset to 0 beforehand anyways
                        dealerTotal -= playerBet + com1Bet + com2Bet + com3Bet;
                        playerTotal += playerBet + playerBet2;
                        com1Total += com1Bet;
                        com2Total += com2Bet;
                        com3Total += com3Bet;

                        //reset bets to zero
                        com1Bet = 0;
                        com1Bet = 0;
                        com3Bet = 0;
                        playerBet = 0;
                        playerBet2 = 0;

                        lblCom1Total.Text = "COM1's Total: $" + Convert.ToString(com1Total);
                        lblCom2Total.Text = "COM2's Total: $" + Convert.ToString(com2Total);
                        lblCom3Total.Text = "COM3's Total: $" + Convert.ToString(com3Total);
                        lblPlayerTotal.Text = "Player's Total: $" + Convert.ToString(playerTotal);
                        lblDealerTotal.Text = "Dealer's Total: $" + Convert.ToString(dealerTotal);
                    }

                    dealerCardSum = dealerCard1 + dealerCard2 +
                        dealerCard3 + dealerCard4 +
                        dealerCard5 + dealerCard6 +
                        dealerCard7 + dealerCard8 +
                        dealerCard9 + dealerCard10;
                }

                //if dealer has equal to or lower than 21, display the card value
                //else, display BUST
                if (dealerCardSum <= 21)
                {
                    lblDealerCards.Text = "Dealer's Card Total: " + Convert.ToString(dealerCardSum);
                }
                else
                {
                    lblDealerCards.Text = "Dealer: BUST";
                }

                //reset the card values
                dealerCard1 = 0;
                dealerCard2 = 0;
                dealerCard3 = 0;
                dealerCard4 = 0;
                dealerCard5 = 0;
                dealerCard6 = 0;
                dealerCard7 = 0;
                dealerCard8 = 0;
                dealerCard9 = 0;
                dealerCard10 = 0;
            }
        #endregion

            #region End Card Sum Comparisons
            //if the dealer has not busted
            if (dealerCardSum <= 21)
            {
                if (playerCardSum <= 21)
                {
                    //if your first hand did not bust
                    //player win
                    if (playerCardSum > dealerCardSum)
                    {
                        playerTotal += playerBet;
                        dealerTotal -= playerBet;
                        playerBet = 0;
                        lblPlayerBet.Text = "Player bet: WIN";
                        lblDealerTotal.Text = "Dealer's Total: " + Convert.ToString(dealerTotal);
                        lblPlayerTotal.Text = "Player's Total " + Convert.ToString(playerTotal);

                    }
                    //player loss
                    else if (playerCardSum < dealerCardSum)
                    {
                        playerTotal -= playerBet;
                        dealerTotal += playerBet;
                        playerBet = 0;
                        lblPlayerBet.Text = "Player bet: LOSS";
                        lblDealerTotal.Text = "Dealer's Total: " + Convert.ToString(dealerTotal);
                        lblPlayerTotal.Text = "Player's Total " + Convert.ToString(playerTotal);

                    }
                    //player tie
                    else
                    {
                        playerBet = 0;
                        lblPlayerBet.Text = "Player bet: DRAW";
                    }
                }

                //if your second hand did not bust
                if (playerCardSum2 <= 21)
                {
                    if (playerCardSum2 > dealerCardSum)
                    {
                        playerTotal += playerBet2;
                        dealerTotal -= playerBet2;
                        playerBet2 = 0;
                        lblPlayerBet2.Text = "Player bet2: WIN";
                        lblDealerTotal.Text = "Dealer's Total: " + Convert.ToString(dealerTotal);
                        lblPlayerTotal.Text = "Player's Total " + Convert.ToString(playerTotal);

                    }
                    //player loss
                    else if (playerCardSum2 < dealerCardSum)
                    {
                        playerTotal -= playerBet2;
                        dealerTotal += playerBet2;
                        playerBet2 = 0;
                        lblPlayerBet2.Text = "Player bet2: LOSS";
                        lblDealerTotal.Text = "Dealer's Total: " + Convert.ToString(dealerTotal);
                        lblPlayerTotal.Text = "Player's Total " + Convert.ToString(playerTotal);

                    }
                    //player tie
                    else
                    {
                        playerBet2 = 0;
                        lblPlayerBet2.Text = "Player bet2: DRAW";
                    }
                }

                //if COM1 did not bust
                if (com1CardSum <= 21)
                {
                    //com1 win
                    if (com1CardSum > dealerCardSum)
                    {
                        com1Total += com1Bet;
                        dealerTotal -= com1Bet;
                        com1Bet = 0;
                        lblCom1Bet.Text = "COM1 bet: WIN";
                        lblDealerTotal.Text = "Dealer's Total: " + Convert.ToString(dealerTotal);
                        lblCom1Total.Text = "COM1's Total " + Convert.ToString(com1Total);
                    }
                    //com1 loss
                    else if (com1CardSum < dealerCardSum)
                    {
                        com1Total -= com1Bet;
                        dealerTotal += com1Bet;
                        com1Bet = 0;
                        lblCom1Bet.Text = "COM1 bet: LOSS";
                        lblDealerTotal.Text = "Dealer's Total: " + Convert.ToString(dealerTotal);
                        lblCom1Total.Text = "COM1's Total " + Convert.ToString(com1Total);

                    }
                    //com1 tie
                    else
                    {
                        com1Bet = 0;
                        lblCom1Bet.Text = "COM1 bet: DRAW";
                    }
                }

                //if COM2 did not bust
                if (com2CardSum <= 21)
                {
                    //com2 win
                    if (com2CardSum > dealerCardSum)
                    {
                        com2Total += com2Bet;
                        dealerTotal -= com2Bet;
                        com2Bet = 0;
                        lblCom2Bet.Text = "COM2 bet: WIN";
                        lblDealerTotal.Text = "Dealer's Total: " + Convert.ToString(dealerTotal);
                        lblCom2Total.Text = "COM2's Total " + Convert.ToString(com2Total);

                    }
                    //com2 loss
                    else if (com2CardSum < dealerCardSum)
                    {
                        com2Total -= com2Bet;
                        dealerTotal += com2Bet;
                        com2Bet = 0;
                        lblCom2Bet.Text = "COM2 bet: LOSS";
                        lblDealerTotal.Text = "Dealer's Total: " + Convert.ToString(dealerTotal);
                        lblCom2Total.Text = "COM2's Total " + Convert.ToString(com2Total);

                    }
                    //tie
                    else
                    {
                        com2Bet = 0;
                        lblCom2Bet.Text = "COM2 bet: DRAW";
                    }
                }

                //if COM3 did not bust
                if (com3CardSum <= 21)
                {
                    //com3 win
                    if (com3CardSum > dealerCardSum)
                    {
                        com3Total += com3Bet;
                        dealerTotal -= com3Bet;
                        com3Bet = 0;
                        lblCom3Bet.Text = "COM3 bet: WIN";
                        lblDealerTotal.Text = "Dealer's Total: " + Convert.ToString(dealerTotal);
                        lblCom3Total.Text = "COM3's Total " + Convert.ToString(com3Total);

                    }
                    //com3 loss
                    else if (com3CardSum < dealerCardSum)
                    {
                        com3Total -= com3Bet;
                        dealerTotal += com3Bet;
                        com3Bet = 0;
                        lblCom3Bet.Text = "COM3 bet: LOSS";
                        lblDealerTotal.Text = "Dealer's Total: " + Convert.ToString(dealerTotal);
                        lblCom3Total.Text = "COM3's Total " + Convert.ToString(com3Total);

                    }
                    //tie
                    else
                    {
                        com3Bet = 0;
                        lblCom3Bet.Text = "COM3 bet: DRAW";
                    }
                    lblMessages.Text = "Totals have been modified based on wins and losses";
                }

                //losing all your money is bad
                if (playerTotal <= 0)
                {
                    lblMessages.Text = Environment.NewLine +
                    "You lost all your money to a gambling habit. Disappointing.";
                }
                
                if (com1Total <= 0)
                {
                    lblMessages.Text = Environment.NewLine +
                    "COM1 lost all their money and left";
                    playerAmount--;
                }
                if (com2Total <= 0)
                {
                    lblMessages.Text = Environment.NewLine +
                    "COM2 lost all their money and left";
                    playerAmount--;
                }
                if (com3Total <= 0)
                {
                    lblMessages.Text = Environment.NewLine +
                       "COM3 lost all their money and left";
                    playerAmount--;
                }

                //if you want to play another round
                btnReplay.Enabled = true;
                btnReplay.Show();
            }
            #endregion
        }
        #endregion

        #region Replay
        private void btnReplay_Click(object sender, EventArgs e)
        { 
            //This will hide all the objects on the form once again
            foreach (Control controlObject in this.Controls)
            {
                controlObject.Hide();
            }

            //Show the first couple of objects to enter your bet amount in
            lblBetAmount.Show();
            btnBetAmount.Show();
            nudBetAmount.Show();

            //shows the menu strip
            mnuMenuStrip.Show();

            //change the maximum bet to how much you have to prevent over-betting
            nudBetAmount.Maximum = playerTotal;

            //reset the card values
            #region Cards
            //User's cards
            playerCard1 = 0;
            playerCard2 = 0;
            playerCard3 = 0;
            playerCard4 = 0;
            playerCard5 = 0;
            playerCard6 = 0;
            playerCard7 = 0;
            playerCard8 = 0;
            playerCard9 = 0;
            playerCard10 = 0;

            //User's second hand's cards (for splitting the deck)
            playerD2C1 = 0;
            playerD2C2 = 0;
            playerD2C3 = 0;
            playerD2C4 = 0;
            playerD2C5 = 0;
            playerD2C6 = 0;
            playerD2C7 = 0;
            playerD2C8 = 0;
            playerD2C9 = 0;
            playerD2C10 = 0;

            //com1's cards
            com1Card1 = 0;
            com1Card2 = 0;
            com1Card3 = 0;
            com1Card4 = 0;
            com1Card5 = 0;
            com1Card6 = 0;
            com1Card7 = 0;
            com1Card8 = 0;
            com1Card9 = 0;
            com1Card10 = 0;

            //com2's cards
            com2Card1 = 0;
            com2Card2 = 0;
            com2Card3 = 0;
            com2Card4 = 0;
            com2Card5 = 0;
            com2Card6 = 0;
            com2Card7 = 0;
            com2Card8 = 0;
            com2Card9 = 0;
            com2Card10 = 0;

            //com3's cards
            com3Card1 = 0;
            com3Card2 = 0;
            com3Card3 = 0;
            com3Card4 = 0;
            com3Card5 = 0;
            com3Card6 = 0;
            com3Card7 = 0;
            com3Card8 = 0;
            com3Card9 = 0;
            com3Card10 = 0;

            //dealer's cards
            dealerCard1 = 0;
            dealerCard2 = 0;
            dealerCard3 = 0;
            dealerCard4 = 0;
            dealerCard5 = 0;
            dealerCard6 = 0;
            dealerCard7 = 0;
            dealerCard8 = 0;
            dealerCard9 = 0;
            dealerCard10 = 0;
            #endregion

            //reset the labels
            lblPlayerTotal.Text = "Your Total: $" + Convert.ToString(playerTotal);
            lblCom1Total.Text = "COM1's Total: $" + Convert.ToString(com1Total);
            lblCom2Total.Text = "COM2's Total: $" + Convert.ToString(com2Total);
            lblCom3Total.Text = "COM3's Total: $" + Convert.ToString(com3Total);
            lblDealerTotal.Text = "Dealer's Total: $" + Convert.ToString(dealerTotal);

            lblPlayerCards.Text = "Your Cards: ";
            lblPlayerCards2.Text = "Your 2nd Hand's Cards:" + Environment.NewLine;
            lblDealerCards.Text = "Dealer's Cards: ";
            lblCom1Cards.Text = "COM1's Cards: ";
            lblCom2Cards.Text = "COM2's Cards: ";
            lblCom3Cards.Text = "COM3's Cards: ";

            lblPlayerBet.Text = "Your Bet: ";
            lblCom1Bet.Text = "COM1's Bet: ";
            lblCom2Bet.Text = "COM2's Bet: ";
            lblCom3Bet.Text = "COM3's Bet: ";
        }
        #endregion

        #region Exit
        private void MniExit_Click(object sender, EventArgs e)
        {
            //close this dang program and get rid of your gambling addiction
            this.Close();
        }
        #endregion

        #region New Game
        private void mniNewGame_Click(object sender, EventArgs e)
        {
            //This will hide all the objects on the form once again
            foreach (Control controlObject in this.Controls)
            {
                controlObject.Hide();
            }

            //Show the first couple of objects to enter your player amount in
            lblPlayerAmount.Show();
            btnPlayerAmount.Show();
            nudPlayerAmount.Show();

            //menu strips are important to have at all times
            mnuMenuStrip.Show();

            //reset all the variables
            playerAmount = 0;
            playerTotal = 250;
            playerBet = 0;
            playerBet2 = 0;
            com1Total = 250;
            com1Bet = 0;
            com2Total = 250;
            com2Bet = 0;
            com3Total = 250;
            com3Bet = 0;
            dealerTotal = 5000;
            playerCardSum = 0;
            playerCardSum2 = 0;
            dealerCardSum = 0;
            com1CardSum = 0;
            com2CardSum = 0;
            com3CardSum = 0;

            //reset the card values
            #region Cards
            //User's cards
            playerCard1 = 0;
            playerCard2 = 0;
            playerCard3 = 0;
            playerCard4 = 0;
            playerCard5 = 0;
            playerCard6 = 0;
            playerCard7 = 0;
            playerCard8 = 0;
            playerCard9 = 0;
            playerCard10 = 0;

            //User's second hand's cards (for splitting the deck)
            playerD2C1 = 0;
            playerD2C2 = 0;
            playerD2C3 = 0;
            playerD2C4 = 0;
            playerD2C5 = 0;
            playerD2C6 = 0;
            playerD2C7 = 0;
            playerD2C8 = 0;
            playerD2C9 = 0;
            playerD2C10 = 0;
            
            //com1's cards
            com1Card1 = 0;
            com1Card2 = 0;
            com1Card3 = 0;
            com1Card4 = 0;
            com1Card5 = 0;
            com1Card6 = 0;
            com1Card7 = 0;
            com1Card8 = 0;
            com1Card9 = 0;
            com1Card10 = 0;
            
            //com2's cards
            com2Card1 = 0;
            com2Card2 = 0;
            com2Card3 = 0;
            com2Card4 = 0;
            com2Card5 = 0;
            com2Card6 = 0;
            com2Card7 = 0;
            com2Card8 = 0;
            com2Card9 = 0;
            com2Card10 = 0;
            
            //com3's cards
            com3Card1 = 0;
            com3Card2 = 0;
            com3Card3 = 0;
            com3Card4 = 0;
            com3Card5 = 0;
            com3Card6 = 0;
            com3Card7 = 0;
            com3Card8 = 0;
            com3Card9 = 0;
            com3Card10 = 0;
            
            //dealer's cards
            dealerCard1 = 0;
            dealerCard2 = 0;
            dealerCard3 = 0;
            dealerCard4 = 0;
            dealerCard5 = 0;
            dealerCard6 = 0;
            dealerCard7 = 0;
            dealerCard8 = 0;
            dealerCard9 = 0;
            dealerCard10 = 0;
            #endregion
        
            //reset the labels
            lblPlayerTotal.Text = "Your Total: $250";
            lblCom1Total.Text = "Com1's Total: $250";
            lblCom2Total.Text = "Com2's Total: $250";
            lblCom3Total.Text = "Com3's Total: $250";
            lblDealerTotal.Text = "Dealer's Total: $5000";
        
            lblPlayerCards.Text = "Your Cards: ";
            lblPlayerCards2.Text = "Your 2nd Hand's Cards:" + Environment.NewLine;
            lblDealerCards.Text = "Dealer's Cards: ";
            lblCom1Cards.Text = "Com1's Cards: ";
            lblCom2Cards.Text = "Com2's Cards: ";
            lblCom3Cards.Text = "Com3's Cards: ";

            lblPlayerBet.Text = "Your Bet: ";
            lblCom1Bet.Text = "Com1's Bet: ";
            lblCom2Bet.Text = "Com2's Bet: ";
            lblCom3Bet.Text = "Com3's Bet: ";

        }
        #endregion
    }
}

