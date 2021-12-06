using Microsoft.VisualStudio.TestTools.UnitTesting;
using PartTrader.API.Helpers.Validations;
using System.ComponentModel.DataAnnotations;

namespace PartTrader.Test.UnitTest
{
    [TestClass]
    public class PartsCodeCustomValidationTest
    {
        [TestMethod]
        public void PartCodeValidationOnlyNumbers()
        {
            //prep
            var partsCodeCustomValidation = new PartsCodeCustomValidation();
            var value = "11223";
            var context = new ValidationContext(new { name= value });

            //eject
            var result = partsCodeCustomValidation.GetValidationResult(value, context);
            //verific
            Assert.AreEqual("Part Code can't be only numbers", result.ErrorMessage);

        }
        [TestMethod]
        public void PartCodeValidationLenght()
        {
            //prep
            var partsCodeCustomValidation = new PartsCodeCustomValidation();
            var value = "s43";
            var context = new ValidationContext(new { name = value });

            //eject
            var result = partsCodeCustomValidation.GetValidationResult(value, context);
            //verific
            Assert.AreEqual("Part Code lenght is not valid, should be at least 4 alphanumeric characters", result.ErrorMessage);

        }
    }
}
