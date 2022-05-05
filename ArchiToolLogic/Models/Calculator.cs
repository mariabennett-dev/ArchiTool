/**********************************************************
 * CALCULATOR.CS
 * 
 * Purpose: A basic foot/inches calculator using Number.cs 
 * to perform unit conversions
 * 
 * Author: Maria Bennett
 * *******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArchiTool.ArchiToolLogic.Models
{
    public class Calculator
    {
        //Constructor
        public Calculator()
        {
            RD = new RoofDimensions();
            NumberString = "";
            Answer = new Number(0);
            AnswerFormatSelected = "";
            Infix = new List<string>();
            Postfix = new List<string>();
            ContinueOperations = false;
            NewNumber = true;
            DecimalEntered = false;
            Operator = "";
            FtEntered = false;
            InEntered = false;
            DisplayEquation = "";
            MixedNumberEntered = false;
            FractionEntered = false;
            ConversionCalcHistory = new List<Equation>();
            DefaultAnswers();
            styles = System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowLeadingSign;
            RoofCalcCount = 0;
            ConversionCalcCount = 0;
        }

        //Properties
        public int RoofCalcCount { get; set; }
        public int ConversionCalcCount { get; set; }
        public RoofDimensions RD { get; set; }
        public Number Answer { get; set; }
        public string AnswerFormatSelected { get; set; }
        public List<string> Infix { get; set; }
        public List<string> Postfix { get; set; }
        public string NumberString { get; set; }
        public string DisplayEquation { get; set; }
        public bool NewNumber { get; set; }
        public bool DecimalEntered { get; set; }
        public bool ContinueOperations { get; set; }
        public bool MixedNumberEntered { get; set; }
        public bool FractionEntered { get; set; }
        public string Operator { get; set; }
        public bool FtEntered { get; set; }
        public bool InEntered { get; set; }
        public List<string> Answers { get; set; } // For answer box Select options
        public List<Equation> ConversionCalcHistory { get; set; }
        public List<RoofDimensions> RoofDimensionsHistory { get; set; }
        private System.Globalization.NumberStyles styles { get; set; }


        //Methods

        /**********************************************************
        * CLEARSLOPE:
        * Update dimensions based on selected units
        * ********************************************************/
        public void ClearSlope()
        {
            RD.SlopeString = null;
            RD.SlopeValue = null;
            RD.SlopeName = "Slope";
            RD.SlopeDimensionFormatSelected = "Select Units";
        }

        /**********************************************************
        * CLEARDISTANCE:
        * Update dimensions based on selected units
        * ********************************************************/
        public void ClearDistance()
        {
            RD.DistanceString = "";
            RD.DistanceValue.Value = 0;
            RD.DistanceName = "Distance Between Columns";
            RD.DistanceDimensionFormatSelected = "Select Units";
        }

        /**********************************************************
        * CLEARICH:
        * Update dimensions based on selected units
        * ********************************************************/
        public void ClearICH()
        {
            RD.ICHString = null;
            RD.ICHValue = null;
            RD.ICHName = "Interior Column Height";
            RD.ICHDimensionFormatSelected = "Select Units";
        }

        /**********************************************************
        * CLEARECH:
        * Update dimensions based on selected units
        * ********************************************************/
        public void ClearECH()
        {
            RD.ECHString = null;
            RD.ECHValue = null;
            RD.ECHName = "Exterior Column Height";
            RD.ECHDimensionFormatSelected = "Select Units";
        }

        /**********************************************************
        * CLEARROOFCALCULATOR:
        * Clear roof dimension values
        * ********************************************************/
        public void ClearRoofCalculator()
        {
            RD = new RoofDimensions();

        }

        /**********************************************************
        * CALCULATEDIMENSIONS:
        * Calculates values of roof dimensions based on units
        * selected and string entered
        * ********************************************************/
        public int CalculateDimensions()
        {
            if(RD.DistanceDimensionFormatSelected == "Select Units" || RD.ICHDimensionFormatSelected == "Select Units" || 
                  RD.SlopeDimensionFormatSelected == "Select Units" || RD.ECHDimensionFormatSelected == "Select Units")
            {
                RD.ErrorMessage = "Select units for all four dimensions";
                return -1;
            }
            if (RD.SlopeString != null && RD.SlopeString != "")
            {
                if (RD.SlopeDimensionFormatSelected == "Degrees")
                {
                    double degrees = double.Parse(RD.SlopeString) * Math.PI / 180;
                    RD.SlopeValue.Value = (decimal)(Math.Tan(degrees));
                }
                else if (RD.SlopeDimensionFormatSelected == "Inches per Linear Foot (Eighths)"
                        || RD.SlopeDimensionFormatSelected == "Decimal Inches per Linear Foot"
                        || RD.SlopeDimensionFormatSelected == "Inches per Linear Foot (Sixteenths)")
                {
                    if (RD.SlopeString.EndsWith("\""))
                    {
                        RD.SlopeValue.Value = StringToValue(RD.SlopeString);
                    }
                    else
                    {
                        RD.SlopeValue.Value = StringToValue(RD.SlopeString) / 12;
                    }
                }
                else
                {
                    RD.ErrorMessage = $"Select {RD.SlopeName} units";
                    return -1;
                }
            }
            if (RD.ECHString != null && RD.ECHString != "")
            {
                if (RD.ECHDimensionFormatSelected != "Select Units")
                {
                    RD.ECHValue.Value = StringToValue(RD.ECHString);
                }
                else
                {
                    RD.ErrorMessage = $"Select {RD.ECHName} units";
                    return -1;
                }
            }
            if (RD.ICHString != null && RD.ICHString != "")
            {
                if (RD.ICHDimensionFormatSelected != "Select Units")
                {
                    RD.ICHValue.Value = StringToValue(RD.ICHString);
                }
                else
                {
                    RD.ErrorMessage = $"Select {RD.ICHName} units";
                    return -1;
                }
            }
            if (RD.DistanceString != null && RD.DistanceString != "")
            {
                if (RD.DistanceDimensionFormatSelected != "Select Units")
                {
                    RD.DistanceValue.Value = StringToValue(RD.DistanceString);
                }
                else
                {
                    RD.ErrorMessage = $"Select {RD.DistanceName} units";
                    return -1;
                }
                if (RD.DistanceValue.Value == 0)
                {
                    RD.ErrorMessage = "Error: Cannot divide by 0";
                    return -1;
                }
                

            }
            return 0;
        }

        /**********************************************************
        * CALCULATEROOF:
        * Calculates values of roof dimensions based on units
        * selected and routes them to correct method
        * ********************************************************/
        public int CalculateRoof()
        {
            if (RD.ECHString != null && RD.SlopeString != null && RD.ICHString != null && RD.DistanceString != null
             && RD.ECHString != ""   && RD.SlopeString != ""   && RD.ICHString != ""   && RD.DistanceString != "")
            {
                RD.ErrorMessage = "Enter only 3 dimensions";
                return -1; ;
            }
            else if (RD.ICHString != null && RD.ECHString != null && RD.DistanceString != null &&
                     RD.ICHString != ""   && RD.ECHString != ""   && RD.DistanceString != "" )
            {
                CalculateSlope();
                return 0;
            }
            else if (RD.ICHString != null && RD.SlopeString != null && RD.DistanceString != null &&
                     RD.ICHString != ""   && RD.SlopeString != ""   && RD.DistanceString != "")
            {
                CalculateECH();
                return 0;
            }
            else if (RD.ECHString != null && RD.SlopeString != null && RD.DistanceString != null &&
                     RD.ECHString != ""   && RD.SlopeString != ""   && RD.DistanceString != "")
            {
                CalculateICH();
                return 0;
            }
            else if (RD.ECHString != null && RD.SlopeString != null && RD.ICHString != null &&
                     RD.ECHString != ""   && RD.SlopeString != ""   && RD.ICHString != "")
            {
                CalculateDistance();
                return 0;
            }
            else 
            {
                RD.ErrorMessage = "Enter exactly 3 dimensions and select all units";
                return -1;
            }
        }

        /**********************************************************
        * CALCULATESLOPE:
        * Calculates Roof slope based on 2 column dimensions and 
        * distance
        * ********************************************************/
        public void CalculateSlope() 
        {
           
            if (RD.SlopeDimensionFormatSelected == "Select Units")
            {
                RD.ErrorMessage = $"Select {RD.SlopeName} units";
                return;
            }
            RD.SlopeValue.Value = ((RD.ECHValue.Value - RD.ICHValue.Value)/RD.DistanceValue.Value);
            if (RD.SlopeDimensionFormatSelected == "Inches per Linear Foot (Eighths)")
            { 
                RD.SlopeString = RD.SlopeValue.ToInchesStringEighth();
            }
            if (RD.SlopeDimensionFormatSelected == "Inches per Linear Foot (Sixteenths)")
            {
                RD.SlopeString = RD.SlopeValue.ToInchesStringSixteenths();
            }
            else if (RD.SlopeDimensionFormatSelected == "Decimal Inches per Linear Foot")
            {
                RD.SlopeString = RD.SlopeValue.ToDecimalInchesRound3();
            }
            else if (RD.SlopeDimensionFormatSelected == "Degrees")
            {
                Number degrees = new Number((decimal)(Math.Atan((double)RD.SlopeValue.Value) * 180 / Math.PI));
                RD.SlopeString = decimal.Round(degrees.Value, 5, MidpointRounding.AwayFromZero).ToString();
            }
        }

        /**********************************************************
        * CALCULATEICH:
        * Calculates column height based on roof slope, 1 column 
        * dimension and distance
        * ********************************************************/
        public void CalculateICH()
        {
            if (RD.ICHDimensionFormatSelected == "Select Units")
            {
                RD.ErrorMessage = $"Select {RD.ICHName} units";
                return;
            }
            RD.ICHValue.Value = RD.ECHValue.Value - (RD.SlopeValue.Value * RD.DistanceValue.Value);
            if (RD.ICHDimensionFormatSelected == "Feet and Inches (Eighths)")
            {
                RD.ICHString = RD.ICHValue.ToFeetInchesStringEighth();
            }
            if (RD.ICHDimensionFormatSelected == "Feet and Inches (Sixteenths)")
            {
                RD.ICHString = RD.ICHValue.ToFeetInchesStringSixteenths();
            }
            else if (RD.ICHDimensionFormatSelected == "Decimal Feet")
            {
                RD.ICHString = RD.ICHValue.ToDecimalFeetRound3();
            }
        }

        /**********************************************************
        * CALCULATEECH:
        * Calculates column height based on roof slope, 1 column 
        * dimension and distance
        * ********************************************************/
        public void CalculateECH() 
        {
            if (RD.ECHDimensionFormatSelected == "Select Units")
            {
                RD.ErrorMessage = $"Select {RD.ECHName} units";
                return;
            }
            RD.ECHValue.Value = RD.ICHValue.Value + (RD.SlopeValue.Value * RD.DistanceValue.Value);
            if (RD.ECHDimensionFormatSelected == "Feet and Inches (Eighths)")
            {
                RD.ECHString = RD.ECHValue.ToFeetInchesStringEighth();
            }
            if (RD.ECHDimensionFormatSelected == "Feet and Inches (Sixteenths)")
            {
                RD.ECHString = RD.ECHValue.ToFeetInchesStringSixteenths();
            }
            else if (RD.ECHDimensionFormatSelected == "Decimal Feet")
            {
                RD.ECHString = RD.ECHValue.ToDecimalFeetRound3();
            }
        }

        /**********************************************************
        * CALCULATEDISTANCE:
        * Calculates distance between 2 columns based on roof slope 
        * and 2 column heights
        * ********************************************************/
        public void CalculateDistance()
        {
            if (RD.DistanceDimensionFormatSelected == "Select Units")
            {
                RD.ErrorMessage = $"Select {RD.DistanceName} units";
                return;
            }
            RD.DistanceValue.Value = (RD.ECHValue.Value - RD.ICHValue.Value)/RD.SlopeValue.Value;
            if (RD.DistanceDimensionFormatSelected == "Feet and Inches (Eighths)")
            {
                RD.DistanceString = RD.DistanceValue.ToFeetInchesStringEighth();
            }
            if (RD.DistanceDimensionFormatSelected == "Feet and Inches (Sixteenths)")
            {
                RD.DistanceString = RD.DistanceValue.ToFeetInchesStringSixteenths();
            }
            else if (RD.DistanceDimensionFormatSelected == "Decimal Feet")
            {
                RD.DistanceString = RD.DistanceValue.ToDecimalFeetRound3();
            }
        }

        /**********************************************************
        * ERRORMESSAGE:
        * Displays error message on display screen
        * *******************************************************/
        public void ErrorMessage(string message)
        {
            Clear();
            DisplayEquation = message;
        }

        /**********************************************************
        * INFIXTOPOSTFIX:
        * Converts infix equation to postfix
        * *******************************************************/
        public void InfixToPostfix()
        {
            Stack<string> s = new Stack<string>();
            for (int i = 0; i < Infix.Count; i++)
            {
                if(isOperator(Infix[i]))
                {
                    if (Infix[i] == "(")
                    {
                        s.Push("(");
                    }
                    else if (Infix[i] == ")")
                    {
                        while (s.Any() || s.Peek() != "(")
                        {
                            Postfix.Add(s.Pop());
                        }
                        s.Pop();
                    }
                    else
                    {
                        while (s.Any() && OperatorPriority(Infix[i]) <= OperatorPriority(s.Peek()))
                        {
                            Postfix.Add(s.Pop());
                        }
                        s.Push(Infix[i]);
                    }
                }
                else
                {
                    Postfix.Add(Infix[i]);
                }
            }
            while (s.Any())
            {
                Postfix.Add(s.Pop());
            }
        }

        /**********************************************************
        * EVALUATEPOSTFIX:
        * Converts infix equation to postfix
        * *******************************************************/
        public decimal EvaluatePostfix() 
        {
            decimal answer = 0;
            Stack<String> operands = new Stack<String>();
            decimal num1;
            decimal num2;
            
            foreach (string s in Postfix)
            {
                if (!isOperator(s))
                {
                    operands.Push(s);
                }
                else
                {
                    num1 = decimal.Parse(operands.Pop());
                    num2 = decimal.Parse(operands.Pop());
                    switch (s)
                    {
                        case "+":
                            answer = num2 + num1;
                            break;
                        case "-":
                            answer = num2 - num1;
                            break;
                        case "*":
                            answer = num2 * num1;
                            break;
                        case "/":
                            answer = num2 / num1;
                            break;
                        default: 
                            break;
                    }
                    operands.Push(answer.ToString());
                }
            }
            if (!Postfix.Contains("+") && !Postfix.Contains("-") && !Postfix.Contains("*") && !Postfix.Contains("/"))
            {
                answer = decimal.Parse(Postfix[0]);
            }
            return answer;
        }

        /**********************************************************
        * ISOPERATOR:
        * Returns true if char is an operator
        * *******************************************************/
        public bool isOperator(string c)
        {
            if (c == "+" || c == "-" || c == "*" || c == "/" || 
                c == "^" || c == "%" || c == "(" || c == ")" )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /**********************************************************
        * OPERATORPRIORITY:
        * Returns priority for operand based on order of operations
        * *******************************************************/
        public int OperatorPriority(string c)
        {
            int priority = 0;
            if (c == "+" || c == "-")
            {
                priority = 1;
            }
            if (c == "*" || c == "/")
            {
                priority = 2;
            }
            if (c == "^")
            {
                priority = 3;
            }
            return priority;
        }


        /**********************************************************
        * DEFAULTANSWERS:
        * Creates a default "blank" answer for Select box options
        * *******************************************************/
        public List<string> DefaultAnswers()
        {
            Answers = new List<string>();
            Answers.Add("---");
            return Answers;
        }

        /**********************************************************
        * FORMATTEDANSWERS:
        * Returns a list of unit-converted answers options
        * *******************************************************/
        public List<string> FormattedAnswers()
        {
            Answers = new List<string>();
            if (FtEntered || InEntered)
            {
                Answers.Add(Answer.ToFeetInchesStringSixteenths());
                Answers.Add(Answer.ToFeetInchesStringEighth());
                Answers.Add(Answer.ToInchesStringSixteenths());
                Answers.Add(Answer.ToInchesStringEighth());
                Answers.Add(Answer.ToDecimalFeetRound3()); 
                Answers.Add(Answer.ToDecimalFeet());
                Answers.Add(Answer.ToDecimalInchesRound3());
                Answers.Add(Answer.ToDecimalInches());
               
            }
            else
            {
                Answers.Add(Answer.ToDecimal());
                Answers.Add(Answer.ToDecimalRound3());
                Answers.Add(Answer.ToDecimalRound2());
                Answers.Add(Answer.ToDecimalRound1());

            }
            Answers = Answers.Distinct().ToList();
            return Answers;
        }


        /**********************************************************
        * STRINGTOVALUE:
        * Returns decimal number from NumberString entered by user
        * *******************************************************/
        public decimal StringToValue(string numberString)
        {
            decimal tempFeet = 0;
            decimal tempInches = 0;
            string tempDigitsWhole = "";
            string tempDigits = "";
            string tempDigitsNum = "";
            if (numberString =="")
            {
                return 0m;
            }
            if (!numberString.Contains("\"") && !numberString.Contains("\'") &&
                !numberString.Contains(" ") && !numberString.Contains("/"))
            {
                return decimal.Parse(numberString, styles);
            }
            else
            {
                for (int i = 0; i < numberString.Length; i++)
                {
                    if (char.IsDigit(numberString[i]) || numberString[i] == '.' || numberString[i] == '-')
                    {
                        tempDigits += numberString[i];
                    }
                    if (char.IsWhiteSpace(numberString[i]))
                    {
                        tempDigitsWhole = tempDigits;
                        tempDigits = "";
                    }
                    if (numberString[i] == '/')
                    {
                        tempDigitsNum = tempDigits;
                        tempDigits = "";
                    }
                    if (numberString[i] == '\'')
                    {
                        if (tempDigitsWhole == "" && tempDigitsNum == "")
                        {
                            tempFeet = decimal.Parse(tempDigits, styles);
                        }
                        else if (tempDigits == "")
                        {
                            tempFeet = decimal.Parse(tempDigitsNum, styles) /decimal.Parse(tempDigits, styles);
                        }
                        else
                        {
                            tempFeet = decimal.Parse(tempDigitsWhole, styles) + (decimal.Parse(tempDigitsNum, styles) / decimal.Parse(tempDigits, styles));
                        }
                        tempDigits = "";
                        tempDigitsWhole = "";
                        tempDigitsNum = "";
                    }
                    if (numberString[i] == '\"')
                    {
                        if (tempDigitsWhole == "" && tempDigitsNum == "")
                        {
                            tempInches = decimal.Parse(tempDigits, styles);
                        }
                        else if (tempDigitsWhole == "")
                        {
                            tempInches = decimal.Parse(tempDigitsNum) / decimal.Parse(tempDigits);
                        }
                        else
                        {
                            tempInches = decimal.Parse(tempDigitsWhole, styles) + (decimal.Parse(tempDigitsNum, styles) / decimal.Parse(tempDigits, styles));
                        }
                        tempDigits = "";
                        tempDigitsWhole = "";
                        tempDigitsNum = "";
                    }
                }
            }
            if (!numberString.Contains("\"") && !numberString.Contains("\'"))
            {
                if (tempDigitsWhole != "" && tempDigitsNum != "")
                {

                    return decimal.Parse(tempDigitsWhole, styles) + decimal.Parse(tempDigitsNum, styles) / decimal.Parse(tempDigits, styles); 
                }
                if(tempDigitsWhole == "" && tempDigitsNum != "")
                {
                    return decimal.Parse(tempDigitsNum, styles) / decimal.Parse(tempDigits, styles);
                }
                else
                {
                    return decimal.Parse(tempDigits, styles);
                }
            }

            return tempFeet + tempInches/12;
        }

        /**********************************************************
        * SAVE:
        * Adds current equation to CalcHistory list
        * *******************************************************/
        public Equation Save(string answer) 
        {
            if (DisplayEquation != "")
            {
                Equation equation = new Equation();
                equation.EquationString = $"{DisplayEquation} {answer}";
                equation.Id = ConversionCalcCount + 1;
                ConversionCalcHistory.Add(equation);
                return equation;
            }
            Equation empty = new Equation();
            return empty;
        }

        /**********************************************************
        * EQUALS:
        * Evaluates equation and returns formatted answers
        * *******************************************************/
        public void Equals()
        {
            Infix.Add(StringToValue(NumberString).ToString());

            //Convert to Postfix and Evaluate
            InfixToPostfix();
            Answer.Value = EvaluatePostfix();

            //Format displays
            DisplayEquation += " = ";
            Operator = "";
            FormattedAnswers();

            //Prepare for next operations
            NumberString = Answer.Value.ToString();
            NewNumber = true;
            DecimalEntered = false;
            Operator = "";
            MixedNumberEntered = false;
            FractionEntered = false;
            FtEntered = false;
            InEntered = false;
            Postfix.Clear();
            Infix.Clear();
        }

        /**********************************************************
        * FT:
        * Designates input as measurement in feet
        * *******************************************************/
        public void Ft()
        {
            if (!FtEntered)
            {
               NumberString += "\'";
            }
            FtEntered = true;
            DisplayEquation += "\'";
        }

        /**********************************************************
        * IN:
        * Designates input as measurement in inches
        * *******************************************************/
        public void In()
        {
            if (!InEntered)
            {
                NumberString += "\"";
            }
            InEntered = true;
            DisplayEquation += "\"";
        }

        /**********************************************************
        * FRACTION:
        * Designates input as a fraction
        * *******************************************************/
        public void Fraction()
        {
            if (!FractionEntered)
            {
                NumberString += "/";
            }
            FractionEntered = true;
            DisplayEquation += "/";
        }

        /**********************************************************
        * MIXEDNUMBER:
        * Designates input as a mixed number
        * *******************************************************/
        public void MixedNumber()
        {
            if (!MixedNumberEntered)
            {
                NumberString += " ";
            }
            MixedNumberEntered = true;
            DisplayEquation += " ";
        }

        /**********************************************************
        * NUMBERBUTTON:
        * Inputs numbers into calculator
        * *******************************************************/
        public void NumberButton(string number)
        {
            if (NewNumber && NumberString != "-")
            {
                NumberString = "";
            }
            NewNumber = false;
            NumberString += number;
            DisplayEquation += number;
        }

        /**********************************************************
        * OPERATIONBUTTON:
        * Inputs operations into calculator
        * *******************************************************/
        public void OperationButton(string operand)
        {
            Infix.Add(StringToValue(NumberString).ToString());
            Infix.Add(operand);
            DisplayEquation += $" {operand} ";
            Operator = operand;
            //reset NumberString markers
            NumberString = "";    
            NewNumber = true;
            MixedNumberEntered = false;
            FractionEntered = false;
            DecimalEntered = false;
            FtEntered = false;
            InEntered = false;
        }

        /**********************************************************
        * DECIMAL:
        * Inputs decimal into calculator
        * *******************************************************/
        public void Decimal()
        {
            if (NewNumber)
            {
                NumberString = "0";
                NewNumber = false;
                DisplayEquation += "0";
            }
            if (!DecimalEntered)
            {
                NumberString += ".";
                DecimalEntered = true;
                DisplayEquation += ".";
            }
        }

        /**********************************************************
        * SIGN:
        * Changes sign of calculator input
        * *******************************************************/
        public void Sign()
        {
            if (NumberString.StartsWith("-"))
            {
                NumberString = NumberString.Substring(1, NumberString.Length - 1);
            }
            else if (NumberString == "")
            {
                NumberString = "-";
            }
            else
            {
                NumberString = "-" + NumberString;
            }
            
            if (Operator == "")
            {
                if (!DisplayEquation.StartsWith("-"))
                {
                    DisplayEquation = "-" + DisplayEquation;
                }
                else
                {
                    DisplayEquation = DisplayEquation.Substring(1, DisplayEquation.Length - 1);
                }
            }
            else
            {
                for (int i = DisplayEquation.Length - 1; i >= 0; i--)
                {
                    if (DisplayEquation[i] == '-')
                    {
                        DisplayEquation = DisplayEquation.Remove(i,1);
                        return;
                    }
                    if (DisplayEquation[i] == ' ')
                    {
                        DisplayEquation = DisplayEquation.Insert(i+1, "-");
                        return;
                    }
                }
            }
        }

        /**********************************************************
        * BACKSPACE:
        * Backspaces input from calculator - up to last operand -
        * then clears calculator
        * *******************************************************/
        public void BackSpace()
        {
            if (DisplayEquation.Length > 0 && NumberString.Length > 0)
            {
                if (NumberString.Length > 1)
                {
                    NumberString = NumberString.Substring(0, NumberString.Length - 1);
                    DisplayEquation = DisplayEquation.Substring(0, DisplayEquation.Length - 1);
                }
                else
                {
                    if (!DisplayEquation.EndsWith('+') && !DisplayEquation.EndsWith('-') && 
                        !DisplayEquation.EndsWith('*') && !DisplayEquation.EndsWith('/'))
                    {
                        DisplayEquation = DisplayEquation.Substring(0, DisplayEquation.Length - 1);
                    }
                    NumberString = "";
                }
                if (!DisplayEquation.Contains("\'"))
                {
                    FtEntered = false;
                }
                if (!DisplayEquation.Contains("\""))
                {
                    InEntered = false;
                }
            }
        }

        /**********************************************************
        * CLEAR:
        * Clears all input from calculator in preparation for new
        * expression
        * *******************************************************/
        public void Clear()
        {
            NumberString = "";
            Answer.Value = 0;
            NewNumber = true;
            DecimalEntered = false;
            Operator = "";
            DisplayEquation = "";
            MixedNumberEntered = false;
            FractionEntered = false;
            FtEntered = false;
            InEntered = false;
            DefaultAnswers();
            Postfix.Clear();
            Infix.Clear();
        }
    }
}
