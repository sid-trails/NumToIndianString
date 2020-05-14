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
    }
}