/**********************************************************
 * NUMBER.CS
 * 
 * Purpose: A foot/inches specific number class that enables
 * coversions of units
 * 
 * Author: Maria Bennett
 * ********************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArchiTool.ArchiToolLogic.Models
{
    public class Number
    {
        /*********************************Value is always in Decimal Feet!***********************************/

        //Constructors convert all dimensions to decimal feet
        public Number(decimal feet)
        {
            Value = feet;
            WholeFeet = 0;
            WholeInches = 0;
            EighthInches = 0;
            InchesOnly = 0;
        }

    //Units and partial units for conversions
        public Decimal Value { get; set; }
        public Decimal Inches { get; set; }
        public int WholeFeet { get; set; }
        public int WholeInches { get; set; }
        public int EighthInches { get; set; }
        public int SixteenthInches { get; set; }
        public Decimal InchesOnly { get; set; }
        public Decimal PartialDecimalInches { get; set; }


    //Conversion Methods
        //decimal feet
        public string ToDecimalFeet() { return $"{Math.Round(Value, 10, MidpointRounding.AwayFromZero)}\'"; }
        public string ToDecimalFeetRound1() { return $"{Math.Round(Value, 1, MidpointRounding.AwayFromZero)}\'"; }
        public string ToDecimalFeetRound2() { return $"{Math.Round(Value, 2, MidpointRounding.AwayFromZero)}\'"; }
        public string ToDecimalFeetRound3() { return $"{Math.Round(Value, 3, MidpointRounding.AwayFromZero)}\'"; }

        //decimal inches
        public string ToDecimalInches() { return $"{Math.Round(Value * 12, 10, MidpointRounding.AwayFromZero)}\""; }
        public string ToDecimalInchesRound1() { return $"{Math.Round(Value * 12, 1, MidpointRounding.AwayFromZero)}\""; }
        public string ToDecimalInchesRound2() { return $"{Math.Round(Value * 12, 2, MidpointRounding.AwayFromZero)}\""; }
        public string ToDecimalInchesRound3() { return $"{Math.Round(Value * 12, 3, MidpointRounding.AwayFromZero)}\""; }

        //decimal (not feet/inches)
        public string ToDecimal() { return Math.Round(Value, 8, MidpointRounding.AwayFromZero).ToString(); }
        public string ToDecimalRound1() { return Math.Round(Value, 1, MidpointRounding.AwayFromZero).ToString(); }
        public string ToDecimalRound2() { return Math.Round(Value, 2, MidpointRounding.AwayFromZero).ToString(); }
        public string ToDecimalRound3() { return Math.Round(Value, 3, MidpointRounding.AwayFromZero).ToString(); }
        
        //feet and inches rounded to eighths
        public string ToFeetInchesStringEighth() 
        {
            ToFeetInchesEighths();
            if (EighthInches == 0)
            {
                return $"{WholeFeet}\' {WholeInches}\"";
            }
            if (EighthInches == 4)
            {
                return $"{WholeFeet}\' {WholeInches} 1/2\"";
            }
            if (EighthInches % 2 == 0)
            {
                return $"{WholeFeet}\' {WholeInches} {EighthInches / 2}/4\"";
            }
            else
                return $"{WholeFeet}\' {WholeInches} {EighthInches}/8\"";
        }

        //feet and inches rounded to eighths
        public string ToFeetInchesStringSixteenths()
        {
            ToFeetInchesSixteenths();
            if (SixteenthInches == 0)
            {
                return $"{WholeFeet}\' {WholeInches}\"";
            }
            if (SixteenthInches == 8)
            {
                return $"{WholeFeet}\' {WholeInches} 1/2\"";
            }
            if (SixteenthInches % 4 ==0)
            {
                return $"{WholeFeet}\' {WholeInches} {SixteenthInches / 4}/4\"";
            }
            if (SixteenthInches % 2 == 0)
            {
                return $"{WholeFeet}\' {WholeInches} {SixteenthInches / 2}/8\"";
            }
            else
                return $"{WholeFeet}\' {WholeInches} {SixteenthInches}/16\"";
        }

        //inches only rounded to eighths
        public string ToInchesStringEighth()
        {
            ToFeetInchesEighths();
            InchesOnly = (WholeFeet * 12) + WholeInches;
            if (EighthInches == 0)
            {
                return $"{InchesOnly}\"";
            }
            if(EighthInches == 4)
            {
                return $"{InchesOnly} 1/2\"";
            }
            if (EighthInches % 2 == 0)
            {
                return $"{InchesOnly} {EighthInches / 2}/4\"";
            }
            else
                return $"{InchesOnly} {EighthInches}/8\"";
        }

        //inches only rounded to sixteenths
        public string ToInchesStringSixteenths()
        {
            ToFeetInchesSixteenths();
            InchesOnly = (WholeFeet * 12) + WholeInches;
            if (SixteenthInches == 0)
            {
                return $"{InchesOnly}\"";
            }
            if (SixteenthInches == 8)
            {
                return $"{InchesOnly} 1/2\"";
            }
            if (SixteenthInches % 4 == 0)
            {
                return $"{InchesOnly} {SixteenthInches / 4}/4\"";
            }
            if (SixteenthInches % 2 == 0)
            {
                return $"{InchesOnly} {SixteenthInches / 2}/8\"";
            }
            else
                return $"{InchesOnly} {SixteenthInches}/16\"";
        }

        //converts decimal inches to feet, inches, and eighth inches
        public void ToFeetInchesEighths() 
        {
            Inches = (Value - Math.Truncate(Value))*12;
            WholeFeet = (int)Math.Truncate(Value);
            WholeInches = (int)Math.Truncate(Inches);
            PartialDecimalInches = Inches - Math.Truncate(Inches);

            //round to nearest .125 or eighth inch
            if (PartialDecimalInches >= 0 && PartialDecimalInches < 0.0625m)
            {
                EighthInches = 0;
            }
            else if (PartialDecimalInches >= 0.0625m && PartialDecimalInches < .1875m)
            {
                EighthInches = 1;
            }
            else if(PartialDecimalInches >= .1875m && PartialDecimalInches < .3125m)
            {
                EighthInches = 2;
            }
            else if(PartialDecimalInches >= .3125m && PartialDecimalInches < .4375m)
            {
                EighthInches = 3;
            }
            else if(PartialDecimalInches >= .4375m && PartialDecimalInches < .5625m)
            {
                EighthInches = 4;
            }
            else if(PartialDecimalInches >= .5625m && PartialDecimalInches < .6875m)
            {
                EighthInches = 5;
            }
            else if(PartialDecimalInches >= .6875m && PartialDecimalInches < .8125m)
            {
                EighthInches = 6;
            }
            else if(PartialDecimalInches >= .8125m && PartialDecimalInches < .9375m)
            {
                EighthInches = 7;
            }
            else if(PartialDecimalInches >= .9375m && PartialDecimalInches < 1)
            {
                WholeInches += 1;
                EighthInches = 0;
            }
            if (WholeInches == 12)
            {
                WholeFeet += 1;
                WholeInches = 0;
            } 
        }

        //converts decimal inches to feet, inches, and sixteenth inches
        public void ToFeetInchesSixteenths()
        {
            Inches = (Value - Math.Truncate(Value)) * 12;
            WholeFeet = (int)Math.Truncate(Value);
            WholeInches = (int)Math.Truncate(Inches);
            PartialDecimalInches = Inches - Math.Truncate(Inches);

            //round to nearest sixteenth inch
            if (PartialDecimalInches >= 0 && PartialDecimalInches < 0.0625m)
            {
                if (PartialDecimalInches < 0.03125m)
                {
                    SixteenthInches = 0;
                }
                else
                {
                    SixteenthInches = 1;
                }
            }
            else if (PartialDecimalInches >= 0.0625m && PartialDecimalInches < .1875m)
            {
                if (PartialDecimalInches < 0.09375m)
                {
                    SixteenthInches = 1;
                }
                else if (PartialDecimalInches < 0.15625m)
                {
                    SixteenthInches = 2;
                }
                else
                {
                    SixteenthInches = 3;
                }
            }
            else if (PartialDecimalInches >= .1875m && PartialDecimalInches < .3125m)
            {
                if (PartialDecimalInches < 0.21875m)
                {
                    SixteenthInches = 3;
                }
                else if (PartialDecimalInches < 0.28125m)
                {
                    SixteenthInches = 4;
                }
                else
                {
                    SixteenthInches = 5;
                }
            }
            else if (PartialDecimalInches >= .3125m && PartialDecimalInches < .4375m)
            {
                if (PartialDecimalInches < 0.34375m)
                {
                    SixteenthInches = 5;
                }
                else if (PartialDecimalInches < 0.40625m)
                {
                    SixteenthInches = 6;
                }
                else
                {
                    SixteenthInches = 7;
                }
            }
            else if (PartialDecimalInches >= .4375m && PartialDecimalInches < .5625m)
            {
                if (PartialDecimalInches < 0.46875m)
                {
                    SixteenthInches = 7;
                }
                else if (PartialDecimalInches < 0.53125m)
                {
                    SixteenthInches = 8;
                }
                else
                {
                    SixteenthInches = 9;
                }
            }
            else if (PartialDecimalInches >= .5625m && PartialDecimalInches < .6875m)
            { 
                if (PartialDecimalInches < 0.59375m)
                {
                    SixteenthInches = 9;
                }
                else if (PartialDecimalInches < 0.65625m)
                {
                    SixteenthInches = 10;
                }
                else
                {
                    SixteenthInches = 11;
                }
            }
            else if (PartialDecimalInches >= .6875m && PartialDecimalInches < .8125m)
            {
                if (PartialDecimalInches < 0.71875m)
                {
                    SixteenthInches = 11;
                }
                else if (PartialDecimalInches < 0.78125m)
                {
                    SixteenthInches = 12;
                }
                else
                {
                    SixteenthInches = 13;
                }
            }
            else if (PartialDecimalInches >= .8125m && PartialDecimalInches < .9375m)
            {
               
                if (PartialDecimalInches < 0.84375m)
                {
                    SixteenthInches = 13;
                }
                else if (PartialDecimalInches < 0.90625m)
                {
                    SixteenthInches = 14;
                }
                else
                {
                    SixteenthInches = 15;
                }
            }
            else if (PartialDecimalInches >= .9375m && PartialDecimalInches < 1)
            {
                if (PartialDecimalInches < 0.96875m)
                {
                    SixteenthInches = 15;
                }
                else
                {
                    SixteenthInches = 0;
                    WholeInches += 1;
                }
            }
            if (WholeInches == 12)
            {
                WholeFeet += 1;
                WholeInches = 0;
            }
        }

    }
}
