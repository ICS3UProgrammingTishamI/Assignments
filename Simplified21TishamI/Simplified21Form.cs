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
        string playerName = "";
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

                //Generate a bet for COM1
                com1Bet = 20 + 10 * numberGenerator.Next(MIN_BET, MAX_BET + 1);

                //Add them to the label
                lblCom1Cards.Text += Convert.ToString(com1Card1) + ", " + Convert.ToString(com1Card2);

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

                //Generate a bet for COM2
                com2Bet = 20 + 10 * numberGenerator.Next(MIN_BET, MAX_BET + 1);

                //Add them to COM2's label
                lblCom2Cards.Text += Convert.ToString(com2Card1) + ", " + Convert.ToString(com2Card2);

                //display totals and bets
                lblCom2Total.Show();
                lblCom2Bet.Show();
            }

            if (playerAmount >= 3)
            {
                //Generate first 2 cards for COM3
                com3Card1 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                com3Card2 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);

                //Generate a bet for COM3
                com3Bet = 20 + 10 * numberGenerator.Next(MIN_BET, MAX_BET + 1);

                //Add them to COM3's label
                lblCom3Cards.Text += Convert.ToString(com3Card1) + ", " + Convert.ToString(com3Card2);

                //display totals and bets
                lblCom3Total.Show();
                lblCom3Bet.Show();
            }
            #endregion

            #region Displays
            //display your cards and the dealer's cards
            lblPlayerCards.Text += Convert.ToString(playerCard1) + ", " + Convert.ToString(playerCard2);
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

            //This explains each button
            lblInsurance.Show();
            lblHit.Show();
            lblStand.Show();
            lblSurrender.Show();
            lblSplit.Show();
            lblDoubleDown.Show();
            #endregion

            #region Initial Conditions
            //If the dealer has an ace, you can make an insurance bet
            if (dealerCard1 == 11)
            {
                btnInsurance.Enabled = true;

                //the insurance bet will be immediately checked for,
                //so all other buttons must be disabled
                btnHit.Enabled = false;
                btnStand.Enabled = false;
                btnSplit.Enabled = false;
                btnSurrender.Enabled = false;
                btnDoubleDown.Enabled = false;

                //The continue button in case you don't want to make the bet
                btnContinue.Enabled = true;
                btnContinue.Show();
            }
            else
            {
                btnInsurance.Enabled = false;
            }

            //If you have doubles, you can split your hand
            if (playerCard1 == playerCard2)
            {
                btnSplit.Enabled = true;
            }
            else
            {
                btnSplit.Enabled = false;
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
            lblPlayerTotal.Text = "Your total: " + Convert.ToString(playerTotal);
        }
        #endregion

        #region Split
        private void BtnSplit_Click(object sender, EventArgs e)
        {
            //Adds and displays a second hand of cards
            //Removes your second card to become your second hand
            playerD2C1 = playerCard2;
            playerCard2 = 0;
            lblPlayerCards2.Text += Convert.ToString(playerD2C1);
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
            //Doubles your bet
            playerBet += playerBet;

            #region Card Generation
            //gives you a new card and shows you said card
            if (playerCard3 == 0)
            {
                playerCard3 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                lblPlayerCards.Text += " " + Convert.ToString(playerCard3);
            }
            else if (playerCard4 == 0)
            {
                playerCard4 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                lblPlayerCards.Text += " " + Convert.ToString(playerCard4);
            }
            else if (playerCard5 == 0)
            {
                playerCard5 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                lblPlayerCards.Text += " " + Convert.ToString(playerCard5);
            }
            else if (playerCard6 == 0)
            {
                playerCard6 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                lblPlayerCards.Text += " " + Convert.ToString(playerCard6);
            }
            else if (playerCard7 == 0)
            {
                playerCard7 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                lblPlayerCards.Text += " " + Convert.ToString(playerCard7);
            }
            else if (playerCard8 == 0)
            {
                playerCard8 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                lblPlayerCards.Text += " " + Convert.ToString(playerCard8);
            }
            else if (playerCard9 == 0)
            {
                playerCard9 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                lblPlayerCards.Text += " " + Convert.ToString(playerCard9);
            }
            else
            {
                playerCard10 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                lblPlayerCards.Text += " " + Convert.ToString(playerCard10);
            }
            #endregion

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

            //adds up all your cards and checks if you've busted
            playerCardSum = playerCard1 + playerCard2 + 
                playerCard3 + playerCard4 + 
                playerCard5 + playerCard6 + 
                playerCard7 + playerCard8 + 
                playerCard9 + playerCard10;

            if (playerCardSum > 21)
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
            if (playerCard3 == 11)
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
                playerTotal -= playerBet;
                dealerTotal += playerBet;
                playerBet = 0;
                lblPlayerTotal.Text = "Your total: " + Convert.ToString(playerTotal);
            }
        }
        #endregion

        #region Insurance
        private void BtnInsurance_Click(object sender, EventArgs e)
        {
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
                    playerTotal += playerBet;
                    dealerTotal -= playerBet;
                    playerBet = 0;
                    lblMessages.Text += Environment.NewLine + 
                        "As you got a blackjack, you also got your full payout";
                }
                lblMessages.Show();

                //Disable the buttons, as your turn has effecctively ended
                btnSurrender.Enabled = false;
                btnStand.Enabled = false;
                btnHit.Enabled = false;
                btnDoubleDown.Enabled = false;
                btnSplit.Enabled = false;
                btnInsurance.Enabled = false;

                //Enable the continue button
                btnContinue.Enabled = true;
                btnContinue.Show();
            }
            else
            {
                //cases for if you lost the bet

                //If there are any number of COM players
                if (playerAmount >= 1)
                {
                    lblMessages.Text = "All the COM players took the bet, " +
                        "like they always do, and so lost this bet. " +
                        //line break
                        Environment.NewLine;

                    //Remove half of COM1's bet from their total
                    com1Total -= com1Bet / 2;

                    //Remove half of COM2's bet from their total
                    if (playerAmount >= 2)
                    {
                        com2Total -= com2Bet / 2;
                    }

                    //Remove half of COM3's bet from their total
                    if (playerAmount >= 3)
                    {
                        com3Total -= com3Bet / 2;
                    }
                }

                lblMessages.Text += "You also lost this bet.";

                //Remove half of the user's bet from the user's total
                playerTotal -= playerBet / 2;
            }
        }
        #endregion

        #region Stand
        private void BtnStand_Click(object sender, EventArgs e)
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
        }
        #endregion

        #region Hit
        private void BtnHit_Click(object sender, EventArgs e)
        {
            //This checks if your first card has been reset
            //If it has been reset, that means that you have a second hand of cards
            //And that your first hand has been finalized
            //Then, it will generate cards for the second hand
            if (playerCard1 == 0)
            {
                #region Card Generation
                //Generates cards
                if (playerCard2 == 0)
                {
                    playerCard2 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                    lblPlayerCards.Text += " " + Convert.ToString(playerCard2);
                }
                else if (playerCard3 == 0)
                {
                    playerCard3 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                    lblPlayerCards.Text += " " + Convert.ToString(playerCard3);
                }
                else if (playerCard4 == 0)
                {
                    playerCard4 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                    lblPlayerCards.Text += " " + Convert.ToString(playerCard4);
                }
                else if (playerCard5 == 0)
                {
                    playerCard5 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                    lblPlayerCards.Text += " " + Convert.ToString(playerCard5);
                }
                else if (playerCard6 == 0)
                {
                    playerCard6 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                    lblPlayerCards.Text += " " + Convert.ToString(playerCard6);
                }
                else if (playerCard7 == 0)
                {
                    playerCard7 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                    lblPlayerCards.Text += " " + Convert.ToString(playerCard7);
                }
                else if (playerCard8 == 0)
                {
                    playerCard8 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                    lblPlayerCards.Text += " " + Convert.ToString(playerCard8);
                }
                else if (playerCard9 == 0)
                {
                    playerCard9 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                    lblPlayerCards.Text += " " + Convert.ToString(playerCard9);
                }
                else
                {
                    playerCard10 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                    lblPlayerCards.Text += " " + Convert.ToString(playerCard10);
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
                    lblPlayerCards2.Text += " " + Convert.ToString(playerD2C2);
                }
                else if (playerD2C3 == 0)
                {
                    playerD2C3 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                    lblPlayerCards2.Text += " " + Convert.ToString(playerD2C3);
                }
                else if (playerD2C4 == 0)
                {
                    playerD2C4 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                    lblPlayerCards2.Text += " " + Convert.ToString(playerD2C4);
                }
                else if (playerD2C5 == 0)
                {
                    playerD2C5 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                    lblPlayerCards2.Text += " " + Convert.ToString(playerD2C5);
                }
                else if (playerD2C6 == 0)
                {
                    playerD2C6 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                    lblPlayerCards2.Text += " " + Convert.ToString(playerD2C6);
                }
                else if (playerD2C7 == 0)
                {
                    playerD2C7 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                    lblPlayerCards2.Text += " " + Convert.ToString(playerD2C7);
                }
                else if (playerD2C8 == 0)
                {
                    playerD2C8 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                    lblPlayerCards2.Text += " " + Convert.ToString(playerD2C8);
                }
                else if (playerD2C9 == 0)
                {
                    playerD2C9 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                    lblPlayerCards2.Text += " " + Convert.ToString(playerD2C9);
                }
                else
                {
                    playerD2C10 = numberGenerator.Next(MIN_CARD, MAX_CARD + 1);
                    lblPlayerCards2.Text += " " + Convert.ToString(playerD2C10);
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
                if (playerCard3 == 11)
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
                    playerTotal -= playerBet;
                    dealerTotal += playerBet;
                    playerBet = 0;
                    lblPlayerTotal.Text = "Your total: " + Convert.ToString(playerTotal);
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
                    if (playerD2C3 == 11)
                    {
                        playerD2C3 = 1;
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
                    else if (playerD2C4 == 11)
                    {
                        playerD2C4 = 1;
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
                    else if (playerD2C5 == 11)
                    {
                        playerD2C5 = 1;
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
                    else if (playerD2C6 == 11)
                    {
                        playerD2C6 = 1;
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
                    else if (playerD2C7 == 11)
                    {
                        playerD2C7 = 1;
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
                    else if (playerD2C8 == 11)
                    {
                        playerD2C8 = 1;
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
                    else if (playerD2C9 == 11)
                    {
                        playerD2C9 = 1;
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
                    else if (playerD2C10 == 11)
                    {
                        playerD2C10 = 1;
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
                    #endregion
                    else
                    {
                        lblMessages.Text = "You've busted and lost your second hand's bet!";
                        playerTotal -= playerBet2;
                        dealerTotal += playerBet2;
                        playerBet2 = 0;
                        lblPlayerTotal.Text = "Your total: " + Convert.ToString(playerTotal);
                    }
                }
            }
        }
        #endregion

        #region Exit
        private void MniExit_Click(object sender, EventArgs e)
        {
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
        }
        #endregion
    }
}