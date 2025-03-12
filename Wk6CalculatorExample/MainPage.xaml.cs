namespace Wk6CalculatorExample
{
    public partial class MainPage : ContentPage
    {
        string _currentOperator;
        double _firstNumberValue;
        bool _secondNumberValue;
        string _displayCalculation; 

        public MainPage()
        {
            InitializeComponent();
            _displayCalculation = string.Empty;
        }

        private void OnNumberClicked(object sender, EventArgs e) 
        {
            var button = (Button)sender;
            var number = button.Text;

            if (_secondNumberValue)
            {
                displayRes.Text = number;
                _secondNumberValue = false;
            }
            else
            {
                displayRes.Text = displayRes.Text == "0" ? number : displayRes.Text + number;
            }

            _displayCalculation += number;
            UpdateDisplayValue();
        }

        //Use this function on all my operators
        private void OnOperatorClicked(string operatorSymbol)
        {
            _currentOperator = operatorSymbol;
            _firstNumberValue = double.Parse(displayRes.Text); // SUNNY DAY FOR PARSE rn
            _secondNumberValue = true;

            _displayCalculation += " " + operatorSymbol + " ";
            UpdateDisplayValue();
        }

        //If event fired DO this
        private void OnMultiplyClicked(object sender, EventArgs e) => OnOperatorClicked("*");

        private void OnDivideClicked(object sender, EventArgs e) => OnOperatorClicked("/");

        private void OnMinusClicked(object sender, EventArgs e) => OnOperatorClicked("-");

        private void OnPlusClicked(object sender, EventArgs e) => OnOperatorClicked("+");

        //reset all values
        private void OnClearClicked(object sender, EventArgs e)
        {
            _firstNumberValue = 0;
            _secondNumberValue = false;
            _displayCalculation = string.Empty;
            displayRes.Text = "0";
        }

        private void OnEqualsClicked(object sender, EventArgs e)
        {
            double secondValOtherSide = GetSecondNumberValue();

            //Math temp var for display
            double calcTotal = 0;


            switch(_currentOperator)
            {
                case "+":
                    calcTotal = _firstNumberValue + secondValOtherSide;
                    break;
                case "-":
                    calcTotal = _firstNumberValue - secondValOtherSide;
                    break;
                case "*":
                    calcTotal = _firstNumberValue * secondValOtherSide;
                    break;
                case "/":
                    calcTotal = _firstNumberValue / secondValOtherSide;
                    break;
            }

            displayRes.Text = calcTotal.ToString();
            //Clear the next calculation
            _displayCalculation = string.Empty;
        }

        private double GetSecondNumberValue() 
        {
            var operatorSelect = _displayCalculation.IndexOf(_currentOperator); //555 + 675 - Index of plus
            var secondNumberInCurrCalc = _displayCalculation.Substring(operatorSelect + 2); // 555 + 675 - Use the index to get sub number OR other side
            return double.Parse(secondNumberInCurrCalc); //Convert to Double
        }


        //Update the display label for calulation
        private void UpdateDisplayValue()
        {
            displayRes.Text = _displayCalculation;
        }
    }

}
