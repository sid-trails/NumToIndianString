using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumToIndianString;

namespace NumToIndianStringTest
{
    [TestClass]
    public class NumberToStringCoverterTest
    {
        [TestMethod]
        public void ShouldGetHighestPlaceValueForPassedInString()
        {
            var placeValue = NumberToStringConverter.GetHighestPlaceValue("200");
            Assert.AreEqual(PlaceValue.Hundreds,placeValue);
        }
        
        [TestMethod]
        public void ShouldGetHigestPlaceValueForPassedInStringForDigits()
        {
            var placeValue = NumberToStringConverter.GetHighestPlaceValue("9");
            Assert.AreEqual(PlaceValue.Digits,placeValue);
        }
        
        [TestMethod]
        public void ShouldGetGreaterThanCroresOnPassing10Crores()
        {
            var placeValue = NumberToStringConverter.GetHighestPlaceValue("100000000");
            Assert.AreEqual(PlaceValue.MoreThanCrores,placeValue);
        }

        [TestMethod, TestCategory("EdgeCases")]
        public void ShouldGetLakhsOnGivingNineLakhs()
        {
            var placeValue = NumberToStringConverter.GetHighestPlaceValue("9999999");
            Assert.AreEqual(PlaceValue.TenLakhs,placeValue);
        }

        [TestMethod]
        public void ShouldSpellOutRawNumberBasedForHighestValuesTill20()
        {
            Assert.AreEqual(NumberToStringConverter.Convert("1"), "One");
            Assert.AreEqual(NumberToStringConverter.Convert("2"), "Two");
            Assert.AreEqual(NumberToStringConverter.Convert("3"), "Three");
            Assert.AreEqual(NumberToStringConverter.Convert("4"), "Four");
            Assert.AreEqual(NumberToStringConverter.Convert("5"), "Five");
            Assert.AreEqual(NumberToStringConverter.Convert("6"), "Six");
            Assert.AreEqual(NumberToStringConverter.Convert("7"), "Seven");
            Assert.AreEqual(NumberToStringConverter.Convert("8"), "Eight");
            Assert.AreEqual(NumberToStringConverter.Convert("9"), "Nine");
            Assert.AreEqual(NumberToStringConverter.Convert("10"), "Ten");
            Assert.AreEqual(NumberToStringConverter.Convert("11"), "Eleven");
            Assert.AreEqual(NumberToStringConverter.Convert("12"), "Twelve");
            Assert.AreEqual(NumberToStringConverter.Convert("13"), "Thirteen");
            Assert.AreEqual(NumberToStringConverter.Convert("14"), "Fourteen");
            Assert.AreEqual(NumberToStringConverter.Convert("15"), "Fifteen");
            Assert.AreEqual(NumberToStringConverter.Convert("16"), "Sixteen");
            Assert.AreEqual(NumberToStringConverter.Convert("17"), "Seventeen");
            Assert.AreEqual(NumberToStringConverter.Convert("18"), "Eighteen");
            Assert.AreEqual(NumberToStringConverter.Convert("19"), "Nineteen");
        }


        [TestMethod]
        public void ShouldSpellOutTensPost20()
        {
            Assert.AreEqual(NumberToStringConverter.Convert("22"), "Twenty Two");
            Assert.AreEqual(NumberToStringConverter.Convert("31"), "Thirty One");
            Assert.AreEqual(NumberToStringConverter.Convert("45"), "Forty Five");
            Assert.AreEqual(NumberToStringConverter.Convert("56"), "Fifty Six");
            Assert.AreEqual(NumberToStringConverter.Convert("64"), "Sixty Four");
            Assert.AreEqual(NumberToStringConverter.Convert("73"), "Seventy Three");
            Assert.AreEqual(NumberToStringConverter.Convert("89"), "Eighty Nine");
            Assert.AreEqual(NumberToStringConverter.Convert("90"), "Ninety");
        }

        [TestMethod]
        public void ShouldSpellOutHundreds()
        {
            Assert.AreEqual(NumberToStringConverter.Convert("100"), "One Hundred");
            Assert.AreEqual(NumberToStringConverter.Convert("225"), "Two Hundred and Twenty Five");

        }
        [TestMethod]
        public void ShouldSpellOutThousands()
        {
            Assert.AreEqual(NumberToStringConverter.Convert("1000"), "One Thousand");
            Assert.AreEqual(NumberToStringConverter.Convert("9999"), "Nine Thousand Nine Hundred and Ninety Nine");
        }

        [TestMethod]
        public void ShouldSpellOutTenThousands()
        {
            Assert.AreEqual(NumberToStringConverter.Convert("99999"), "Ninety Nine Thousand Nine Hundred and Ninety Nine");
        }
        
        [TestMethod]
        public void ShouldSpellOutLakhs()
        {
            Assert.AreEqual(NumberToStringConverter.Convert("100000"), "One Lakh");
            Assert.AreEqual(NumberToStringConverter.Convert("999999"), "Nine Lakhs Ninety Nine Thousand Nine Hundred and Ninety Nine");
        }

        [TestMethod]
        public void ShouldSpellOutTenLakhs()
        {
            Assert.AreEqual(NumberToStringConverter.Convert("9999999"), "Ninety Nine Lakhs Ninety Nine Thousand Nine Hundred and Ninety Nine");
        }
  
    }
}