using System;

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
    
    public class NumberToStringConverter
    {
        public PlaceValue GetHighestPlaceValue(string number)
        {
            double convertedLongInt = System.Convert.ToDouble(number);
            int placeValueInt = System.Convert.ToInt32(Math.Floor(Math.Log10(convertedLongInt)));
            return (PlaceValue) placeValueInt;
        }

        public string Convert(string number)
        {
            if (number.Length <= 2 && System.Convert.ToInt16(number) < 20)
            {
               return getRawValue(System.Convert.ToInt16(number)).ToString();
            }
            return number;
        }

        private RawValues getRawValue(int number)
        {
            return (RawValues) number;
        }
    }
}