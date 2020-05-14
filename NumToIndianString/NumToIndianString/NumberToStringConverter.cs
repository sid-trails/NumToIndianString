using System;
using Microsoft.VisualBasic;

namespace NumToIndianString
{
    public enum PlaceValue
    {
        Digits = 0,
        Tens = 1,
        Hundreds = 2,
        Thousands = 3,
        TenThousands = 4,
        Lakhs = 5,
        TenLakhs =6,
        Crores = 7,
        MoreThanCrores
    }

    public enum RawValues
    {
        _ =0,
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Eleven = 11,
        Twelve = 12,
        Thirteen= 13,
        Fourteen = 14,
        Fifteen = 15,
        Sixteen = 16,
        Seventeen = 17,
        Eighteen = 18,
        Nineteen = 19
    }

    public enum Tens
    {
        _ = 0,
        Twenty = 2,
        Thirty = 3,
        Forty = 4,
        Fifty = 5,
        Sixty = 6,
        Seventy = 7,
        Eighty = 8,
        Ninety = 9,
    }
    public class NumberToStringConverter
    {
        public static PlaceValue GetHighestPlaceValue(string number)
        {
            double convertedLongInt = System.Convert.ToDouble(number);
            int placeValueInt = System.Convert.ToInt32(Math.Floor(Math.Log10(convertedLongInt)));
            return (PlaceValue) placeValueInt;
        }

        public static string Convert(string number)
        {
            string numberString = String.Empty;
            
            var placeVlaue = GetHighestPlaceValue(number);
            Func<string, string> getDigits = (x) => (GetRawValue(System.Convert.ToInt16(x))).ToString();

            numberString = placeVlaue switch
            {
                PlaceValue.Digits => getDigits(number),
                PlaceValue.Tens => GetTensValue(number),
                PlaceValue.Hundreds => GetFormatedValue(number, "{0} Hundred",
                    getDigits, "{0} Hundred and {1}", 1, GetTensValue),
                PlaceValue.Thousands => GetFormatedValue(number, "{0} Thousand",
                    getDigits, "{0} Thousand {1}", 1, Convert),
                PlaceValue.TenThousands => GetFormatedValue(number, "{0} Thousand",
                    GetTensValue, "{0} Thousand {1}", 2, Convert),
                PlaceValue.Lakhs => GetFormatedValue(number, "{0} Lakh",
                    (x) => (GetRawValue(System.Convert.ToInt16(x))).ToString(),
                    "{0} Lakhs {1}", 1, Convert),
                PlaceValue.TenLakhs => GetFormatedValue(number, "{0} Lakhs",
                    GetTensValue,
                    "{0} Lakhs {1}", 2, Convert),
                PlaceValue.Crores => GetFormatedValue(number, "{0} crore",
                    GetTensValue,
                    "{0} crores {1}", 1, Convert),
                _ => throw new NotSupportedException("Number you have passed is not supported for conversion")
            };
            return numberString.Replace("_", String.Empty).Trim();
        }

        private static string GetTensValue(string number)
        {
            int numberInt16 = System.Convert.ToInt16(number);
            string format = "{0} {1}";
            if (numberInt16 < 20)
            {
                return GetRawValue(numberInt16).ToString();
            }
 
            int firstDigit = System.Convert.ToInt16(number.Substring(0,1));
            int unitsPlace = System.Convert.ToInt16(number.Substring(1, 1));
            return  string.Format(format,((Tens)firstDigit).ToString(), ((RawValues)unitsPlace).ToString());

        }

        public static string GetFormatedValue(string number,
            string format,
            Func<string, string> primaryFunc,
            string secondaryFormat,
            int indexForSecondaryString,
            Func<string, string> secondaryFunc)
        {
            string rawValue = number.Substring(0, indexForSecondaryString);
            bool isAbsolute = System.Convert.ToInt32(number.Substring(indexForSecondaryString)) == 0;
            return isAbsolute
                ? string.Format(format, primaryFunc(rawValue))
                : string.Format(secondaryFormat, primaryFunc(rawValue),
                    secondaryFunc(number.Substring(indexForSecondaryString)));
        }

        private static RawValues GetRawValue(int number)
        {
            return (RawValues) number;
        }
    }
}