using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku;

namespace Sudoku.Tests
{
    [TestClass()]
    public class FilesTests
    {
        [TestMethod()]
        public void CheckPath_PathIsValid_ReturnsTrue()
        {
            // Testing how the function acts in a regular case on which it works
            // with a valid path. We expect it to return true.

            // Arrange:
            string path = "C:\\Users\\erez\\source\\repos\\Sudoku\\str.txt";
            Files files = new Files(path);

            // Act:
            bool result = files.CheckPath();

            // Assert:
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void CheckPath_PathIsNotValid_ReturnsFalse()
        {
            // Testing how the function acts in a case on which it works
            // with an invalid path. We expect it to return false.

            // Arrange:
            string path = "C:\\";
            Files files = new Files(path);

            // Act:
            bool result = files.CheckPath();

            // Assert:
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void Checkpath_PathIsEmpty_ReturnsFalse()
        {
            // Testing how the function acts in a case on which it works
            // with an empty path. We expect it to return false, since a path
            // can't be empty.

            // Arrange:
            string path = "";
            Files files = new Files(path);

            // Act:
            bool result = files.CheckPath();

            // Assert:
            Assert.IsFalse(result);
        }
    }
}