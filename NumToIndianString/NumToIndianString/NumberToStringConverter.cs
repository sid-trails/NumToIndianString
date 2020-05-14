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
    
    
    public class NumberToStringConverter
    {
        public PlaceValue GetHighestPlaceValue(string number)
        {
            double convertedLongInt = Convert.ToDouble(number);
            int placeValueInt =Convert.ToInt32(Math.Floor(Math.Log10(convertedLongInt)));
            return (PlaceValue) placeValueInt;
        }
        
        
    }
}