using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _1DV406L1._4.Model;

namespace _1DV406L1._4
{
    public partial class Default : System.Web.UI.Page
    {
        private SecretNumber SecretNumber
        {
            get { return Session["SecretNumber"] as SecretNumber ?? (SecretNumber)(Session["SecretNumber"] = new SecretNumber()); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.SetFocus(userInputTextBox);
        }

        protected void guessButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                int userInput = int.Parse(userInputTextBox.Text);
                guessButton.Enabled = true;

                SecretNumber.MakeGuess(userInput);

                if (SecretNumber.Outcome == Outcome.Low)
                {
                    messages.Text = "Din gissning var för låg.";
                }
                else if (SecretNumber.Outcome == Outcome.High)
                {
                    messages.Text = "Din gissning var för hög.";
                }
                else if (SecretNumber.Outcome == Outcome.PreviousGuess)
                {
                    messages.Text = String.Format("Du har redan gissat på {0}, gör ett nytt försök", userInput);
                }
                else if (SecretNumber.Outcome == Outcome.NoMoreGuesses)
                {
                    messages.Text = String.Format("Du har slut på gissningar, det hemliga talet var {0]", SecretNumber.Number);
                }
                else
                {
                    messages.Text = String.Format("Grattis! Du klarade det på {0} gissningar!", SecretNumber.Count);
                }

                if (!SecretNumber.CanMakeGuess)
                {
                    guessButton.Enabled = false;
                    userInputTextBox.Enabled = false;
                    Page.SetFocus(resetButton);

                    resetButtonPlaceholder.Visible = true;
                }
            }

            labelPlaceHolder.Visible = true;
            foreach (var item in SecretNumber.PreviousGuesses)
            {
                result.Text = String.Join(", ", SecretNumber.PreviousGuesses);
            }
          
        }

        protected void resetButton_Click(object sender, EventArgs e)
        {
            //Starts a new game
            SecretNumber.Initialize();

            //Enables the guess button and input field again
            guessButton.Enabled = true;
            userInputTextBox.Enabled = true;

            //Clears the messages and removes the resetbutton again
            resetButtonPlaceholder.Visible = false;
            result.Text = "";
            messages.Text = "";
        }
    }
}