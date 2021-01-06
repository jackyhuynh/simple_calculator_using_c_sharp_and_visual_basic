//Truc Huynh, CIS 316, Course Project
using System;
using System.Windows.Forms;

namespace Calculator_Huynh
{
    public partial class Calculator : Form
    {
        //------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Variable declaration
        /// </summary>
        double ResultValue = 0; //Store the result of the calculation
        string Operator_ = "";  //Store the operator input
        bool isOperation_Performed = false; //Check if operation is performed
        bool Operation_is_Pepeated = false; //Value to clear the text box in case user forgot to clear the textbox after calculation is performed

        //------------------------------------------------------------------------------------------------------
        public Calculator()
        {
            InitializeComponent();
        }


        /// <summary>
        /// This method is used to input the number to the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //------------------------------------------------------------------------------------------------------
        private void button_click_Input (object sender, EventArgs e)
        {
             Button button = (Button)sender;        

            if (double.Parse(ResultTextBox.Text) > 0 && Operation_is_Pepeated && isOperation_Performed)
            {
                ResultTextBox.Clear();              //Clear the text box
                //Value to clear the text box in case user forgot to clear the textbox after calculation is performed
                Operation_is_Pepeated = false;      //Set the repeted action to false
                isOperation_Performed = false;      //Set the operation performed to false
                ResultValue = 0;                    //
                Check_Button_Dot(button);           //Call Check button to check if the 
            }
            else {
                // Clear the textbox if the operation haven't performed
                if (ResultTextBox.Text=="0"||(isOperation_Performed))
                {
                    ResultTextBox.Clear();  //Clear the text box
                }
                isOperation_Performed = false;
                Check_Button_Dot(button);
            }
            
        }

        /// <summary>
        /// Check if the decimal point is in the text box
        /// </summary>
        /// <param name="button"></param>
        //------------------------------------------------------------------------------------------------------
        private void Check_Button_Dot(Button button)
        {       
            if (button.Text == ".")
            {
                //Limit the decimal point to only 1
                if (!ResultTextBox.Text.Contains("."))
                    ResultTextBox.Text = ResultTextBox.Text + button.Text;
            }
            else // Do as normal.
            {
                ResultTextBox.Text = ResultTextBox.Text + button.Text;
            }
        }

        /// <summary>
        /// operator_clickEvent add the operator to the calculation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //------------------------------------------------------------------------------------------------------
        private void operator_clickEvent(object sender, EventArgs e)
        {
            Button button = (Button)sender;                         
            //Local data to store the button value
            if (ResultValue != 0)
            {
                // Call button Equal if one of the operator(+,-,*,/) button is clicked two or more times 
                buttonEqual.PerformClick();
                Operator_ = button.Text;                                //Get what operator button is clicked
                currentOperation.Text = ResultValue + " " + Operator_;  //Show the current data and the operator
                isOperation_Performed = true;                           //Set the Operation to true
            }
            else
            {
                Operator_ = button.Text;                                //Get what operator's button is clicked
                ResultValue = double.Parse(ResultTextBox.Text);         //Set the result of the text
                currentOperation.Text = ResultValue + " " + Operator_;  //Show the current data and the operator
                isOperation_Performed = true;                           //Set the Operation to true
            }                       
        }

        /// <summary>
        /// button CE set the result text box to 0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCE_Click(object sender, EventArgs e)
        {
            ResultTextBox.Text = "0";
        }

        /// <summary>
        /// button C set the result text box to 0
        /// and clear all the ResultValue.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonC_Click(object sender, EventArgs e)
        {
            ResultTextBox.Text = "0";
            ResultValue = 0;
        }

        /// <summary>
        /// buttonEqual_Click get the user input and choose what case
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void buttonEqual_Click(object sender, EventArgs e)
        {
            switch (Operator_)
            {
                case "+":
                    ResultTextBox.Text = (ResultValue + 
                        double.Parse(ResultTextBox.Text)).ToString();
                    break;
                case "-":
                    ResultTextBox.Text = (ResultValue - 
                        double.Parse(ResultTextBox.Text)).ToString();
                    break;
                case "*":
                    ResultTextBox.Text = (ResultValue * 
                        double.Parse(ResultTextBox.Text)).ToString();
                    break;
                case "/":
                    ResultTextBox.Text = (ResultValue / 
                        double.Parse(ResultTextBox.Text)).ToString();
                    break;
                default:
                    break;
            }
            ResultValue = double.Parse(ResultTextBox.Text);
            Operation_is_Pepeated = true;
            currentOperation.Text = "";
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResultTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Square root button to reset the text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSQRT_Click(object sender, EventArgs e)
        {
            ResultTextBox.Text = (Math.Sqrt(double.Parse(ResultTextBox.Text))).ToString();
        }
    }
}
