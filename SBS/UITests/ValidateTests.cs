using Microsoft.VisualStudio.TestTools.UnitTesting;
using UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Tests
{
    [TestClass()]
    public class ValidateTests
    {
        [TestMethod()]
        public void generalValidateTest()
        {
            // Check Alphabetic
            Assert.IsTrue(Validate.generalValidate("AaBbCcDdEeFfGg",true,false));

            Assert.IsFalse(Validate.generalValidate("AaBbCc7DdEeFfGg", true, false));
            Assert.IsFalse(Validate.generalValidate("AaBbCc DdEeFfGg", true, false));
            Assert.IsFalse(Validate.generalValidate("AaBbCc_DdEeFfGg", true, false));
            Assert.IsFalse(Validate.generalValidate("AaBbCc%DdEeFfGg", true, false));
            Assert.IsFalse(Validate.generalValidate("AaBbCc$DdEeFfGg", true, false));
            Assert.IsFalse(Validate.generalValidate("AaBbCc&DdEeFfGg", true, false));
            Assert.IsFalse(Validate.generalValidate("AaBbCc<DdEeFfGg", true, false));
            Assert.IsFalse(Validate.generalValidate("AaBbCc>DdEeFfGg", true, false));

            // Check Numeric
            Assert.IsTrue(Validate.generalValidate("1234567890", false, true));

            Assert.IsFalse(Validate.generalValidate("12345a67890", false, true));
            Assert.IsFalse(Validate.generalValidate("12345 67890", false, true));
            Assert.IsFalse(Validate.generalValidate("12345-67890", false, true));
            Assert.IsFalse(Validate.generalValidate("12345_67890", false, true));

            // Check Special
            Assert.IsTrue(Validate.generalValidate("!@#$%^&*()<>", false, false, "!@#$%^&*()<>"));
            Assert.IsTrue(Validate.generalValidate("!@#$%^&*()<>", false, false, "!@#$%^&*)<>"));

            Assert.IsFalse(Validate.generalValidate("!@#$2^&*()<>", false, false, "!@#$%^&*()<>"));
            Assert.IsFalse(Validate.generalValidate("A", false, false, "!@#$%^&*()<>"));
            Assert.IsFalse(Validate.generalValidate(" ", false, false, "!@#$%^&*()<>"));
            Assert.IsFalse(Validate.generalValidate("-", false, false, "!@#$%^&*()<>"));
            Assert.IsFalse(Validate.generalValidate("!@#$ ^&*()<>", false, false, "!@#$%^&*()<>"));
        }
    }
}