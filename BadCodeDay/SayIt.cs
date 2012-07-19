using System;
using System.IO;
using System.Net;

namespace BadCodeDay
{
    public class SayIt
    {
        public string[] small = new[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        public string[] teens = new[] { "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen","nineteen" };
        public string[] tens = new[] { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"};
        public string hundred = "hundred";
        public string thousand = "thousand";

        public string Convert(int valueToSay)
        {
            if(valueToSay<0)
            {
                return "Dont do negatives";
            }

            if (valueToSay>999999)
            {
                return "Dont do big numbers";
            }
            var translatedString = "";

            if ((valueToSay/1000)!=0 )
            {
                var thousands = valueToSay / 1000;
                valueToSay = valueToSay - (1000 * thousands);
                if(thousands>99)
                {
                    translatedString = translatedString + small[thousands / 100] + " " + hundred + " ";
                    thousands = thousands - (100 * (thousands / 100));
                }
                if(thousands>20)
                {
                    if (translatedString.Length != 0)
                    {
                        translatedString = translatedString + " and ";
                    }
                    translatedString = translatedString + tens[thousands / 10] + " ";
                    thousands = thousands - (10 * (thousands / 10));
                } else if (thousands > 9)
                {
                    translatedString = translatedString + teens[thousands - 10] + " ";
                    thousands = 0;
                }
                if (thousands > 0)
                {
                    translatedString = translatedString + small[thousands] + " ";
                }
                translatedString = translatedString + " " + thousand + " ";
            }

            if (valueToSay > 99)
            {
                translatedString = translatedString + small[valueToSay / 100] + " " + hundred + " ";
                valueToSay = valueToSay - (100 * (valueToSay / 100));
            }
            
            var doneAnd = false;

            if (valueToSay > 20)
            {
                if (translatedString.Length != 0)
                {
                    translatedString = translatedString + " and ";
                    doneAnd = true;
                }
                translatedString = translatedString + tens[valueToSay / 10] + " ";
                valueToSay = valueToSay - (10 * (valueToSay / 10));
            }
            else if (valueToSay > 9)
            {
                if (translatedString.Length!=0)
                {
                    translatedString = translatedString + " and ";
                    doneAnd = true;
                }
                translatedString = translatedString + teens[valueToSay - 10] + " ";
                valueToSay = 0;
            }
            if (valueToSay > 0)
            {
                if (translatedString.Length != 0 && !doneAnd)
                {
                    translatedString = translatedString + " and ";
                }

                translatedString = translatedString + small[valueToSay] + " ";
            }

            return translatedString;
        }
    }
}