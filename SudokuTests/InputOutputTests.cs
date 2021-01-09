using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku;

namespace Sudoku.Tests
{
    [TestClass()]
    public class InputOutputTests
    {
        #region CheckStringInput Tests
        [TestMethod()]
        public void CheckStringInputTest_StringIsValid_ReturnsTrue()
        {
            // Testing a valid input string case - only contains values in the ascii
            // range of values '0' -> '0' + BlockSize (including the edges).

            // Arrange:
            InputOutput inputOutput = new InputOutput();
            string input = "0010200000304000";

            // Act:
            bool result = inputOutput.CheckStringInput(input);

            // Assert:
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void CheckStringInput_ContainsValueAboveAsciiValueOfZeroPlusBlockSize_ReturnsFalse()
        {
            // Testing a 4x4 board, which means that we expect that the value 5 will be out of range.

            // Arrange:
            InputOutput inputOutput = new InputOutput();
            string input = "5510200000304000";

            // Act:
            bool result = inputOutput.CheckStringInput(input);

            // Assert:
            Assert.IsFalse(result);
        }
        
        [TestMethod()]
        public void CheckStringInput_ContainsValueBelowAsciiValueOfZero_ReturnsFalse()
        {
            // The ascii value of . and / is below the ascii value of 0, which means
            // that we expect to get false out of this test.

            // Arrange:
            InputOutput inputOutput = new InputOutput();
            string input = "./10200000304000";

            // Act:
            bool result = inputOutput.CheckStringInput(input);

            // Assert:
            Assert.IsFalse(result);
        }
        #endregion

        #region CheckStringLength Tests
        [TestMethod()]
        public void CheckStringLength_StringLengthIsValid_ReturnsTrue()
        {
            // Testing a valid input length case - 81 characters (81 -> 9 -> 3).

            // Arrange:
            InputOutput inputOutput = new InputOutput();
            int InputLength = 81;

            // Act:
            bool result = inputOutput.CheckStringLength(InputLength);

            // Assert:
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void CheckStringLength_StringLengthHasLessThan2Roots_ReturnsFalse()
        {
            // Testing an invalid input length case - 4 characters (Don't have 2 roots:
            // (4 -> 2 -> X).

            // Arrange:
            InputOutput inputOutput = new InputOutput();
            int InputLength = 4;

            // Act:
            bool result = inputOutput.CheckStringLength(InputLength);

            // Assert:
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void CheckStringLength_StringLengthHasMoreThan2Roots_ReturnsTrue()
        {
            // Testing a valid input length case on which the input length has more than
            // 2 roots - 256 characters (256 -> 16 -> 4 -> 2).

            // Arrange:
            InputOutput inputOutput = new InputOutput();
            int InputLength = 256;

            // Act:
            bool result = inputOutput.CheckStringLength(InputLength);

            // Assert:
            Assert.IsTrue(result);
        }
        #endregion
    }
}