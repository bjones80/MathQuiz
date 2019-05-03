using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        //Create Random object called randomizer
        //generate random numbers. 
        Random randomizer = new Random();

        //integer variables store numbers for addition problem
        int addend1;
        int addend2;

        // integer variables store number for subtraction
        int minuend;
        int subtrahend;

        //integer variables store number for multiplication
        int multiplicand;
        int multiplier;

        // integer variables store numbers for division problems
        int dividend;
        int divisor;

        // interger keeps track of remaining time
        int timeLeft;


        

        public void StartTheQuiz()
        {
            // Generate two random numbers to add
            // store values variables 'addend1'
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            // convert two random numbers into strings
            // allows to be displayed in label controls.
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            // set sum to value 0 before anyone adds another number.
            sum.Value = 0;

            // Fill in the subtraction problem.
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            // Fill in the multiplication problem.
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            // Fill in the division problem.
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            // Start the timer
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();

            // to display date
            date.Text = DateTime.Now.ToString("dd MMMM yyyy");
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer()){ 
                // if returns turn, then got the right answer
                // stop timer and show a messagebox.
                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                    "Congratulations!");
                startButton.Enabled = true;
                timeLabel.BackColor = Control.DefaultBackColor;
            }
            else if (timeLeft > 0)
            {
                // Display the new time left
                // by updating the Time Left label.
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
                if (timeLeft <= 5)
                {
                    timeLabel.BackColor = Color.Red;
                }
            }
            else
            {
                // If the user ran out of time, stop the timer, show 
                // a MessageBox, and fill in the answers.
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
                timeLabel.BackColor = Control.DefaultBackColor;
            }
        }
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
                && (minuend - subtrahend == difference.Value) 
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            // Select the whole answer in the NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void Sum_ValueChanged(object sender, EventArgs e)
        {
            var answer = ((NumericUpDown)sender).Value;

            if ((addend1 + addend2) == answer)
            {
                //play sound
                SoundPlayer simpleSound = new SoundPlayer(@"C:\Windows\media\Alarm03.wav");
                simpleSound.Play();
            }
        }

        private void Difference_ValueChanged(object sender, EventArgs e)
        {
            var answer = ((NumericUpDown)sender).Value;

            if ((minuend - subtrahend) == answer)
            {
                //play sound
                SoundPlayer simpleSound = new SoundPlayer(@"C:\Windows\media\Alarm03.wav");
                simpleSound.Play();
            }

        }

        private void Product_ValueChanged(object sender, EventArgs e)
        {
            var answer = ((NumericUpDown)sender).Value;

            if ((multiplicand * multiplier) == answer)
            {
                //play sound
                SoundPlayer simpleSound = new SoundPlayer(@"C:\Windows\media\Alarm03.wav");
                simpleSound.Play();
            }

        }

        private void Quotient_ValueChanged(object sender, EventArgs e)
        {
            var answer = ((NumericUpDown)sender).Value;

            if ((dividend / divisor) == answer)
            {
                //play sound
                SoundPlayer simpleSound = new SoundPlayer(@"C:\Windows\media\Alarm03.wav");
                simpleSound.Play();
            }

        }
    }
}
