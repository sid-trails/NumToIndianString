using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumToIndianString;

namespace NumToIndianStringTest
{
    [TestClass]
    public class NumberToStringCoverterTest
    {
        [TestMethod]
        public void ShouldGetHigestPlaceValueForPassedInString()
        {
            var converter = new NumberToStringConverter();
            var placeValue = converter.GetHighestPlaceValue("200");
            Assert.AreEqual(PlaceValue.Hundreds,placeValue);
        }
        
        [TestMethod]
        public void ShouldGetHigestPlaceValueForPassedInStringForDigits()
        {
            var converter = new NumberToStringConverter();
            var placeValue = converter.GetHighestPlaceValue("9");
            Assert.AreEqual(PlaceValue.Digits,placeValue);
        }
        
        [TestMethod]
        public void ShouldGetGreaterThanCroresOnPassing10Crores()
        {
            var converter = new NumberToStringConverter();
            var placeValue = converter.GetHighestPlaceValue("100000000");
            Assert.AreEqual(PlaceValue.MoreThanCrores,placeValue);
        }

        [TestMethod, TestCategory("EdgeCases")]
        public void ShoudGetLakhsOnGivingNineLakhs()
        {
            var converter = new NumberToStringConverter();
            var placeValue = converter.GetHighestPlaceValue("9999999");
            Assert.AreEqual(PlaceValue.TenLakhs,placeValue);
        }

        [TestMethod]
        public void shouldSpellOutRawNumberBasedForHighestValuesTill20()
        {
            var converter = new NumberToStringConverter();
            Assert.AreEqual(converter.Convert("1"), "One");
            Assert.AreEqual(converter.Convert("2"), "Two");
            Assert.AreEqual(converter.Convert("3"), "Three");
            Assert.AreEqual(converter.Convert("4"), "Four");
            Assert.AreEqual(converter.Convert("5"), "Five");
            Assert.AreEqual(converter.Convert("6"), "Six");
            Assert.AreEqual(converter.Convert("7"), "Seven");
            Assert.AreEqual(converter.Convert("8"), "Eight");
            Assert.AreEqual(converter.Convert("9"), "Nine");
            Assert.AreEqual(converter.Convert("10"), "Ten");
            Assert.AreEqual(converter.Convert("11"), "Eleven");
            Assert.AreEqual(converter.Convert("12"), "Twelve");
            Assert.AreEqual(converter.Convert("13"), "Thirteen");
            Assert.AreEqual(converter.Convert("14"), "Fourteen");
            Assert.AreEqual(converter.Convert("15"), "Fifteen");
            Assert.AreEqual(converter.Convert("16"), "Sixteen");
            Assert.AreEqual(converter.Convert("17"), "Seventeen");
            Assert.AreEqual(converter.Convert("18"), "Eighteen");
            Assert.AreEqual(converter.Convert("19"), "Nineteen");
        }
    }
}