using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Sudoku.Tests
{
    [TestClass()]
    public class GameBoardTests
    {
        #region GetOptionsList Tests
        [TestMethod()]
        public void GetOptionsList_CellHasOneOption_ReturnsListOfOneNumber()
        {
            // Testing how the function acts in a case on which the cell has
            // only 1 option. We expect it to return a list that only contains that value.
            // In this test, we expect to recieve a list with the number 3 for the first
            // cell in the board.

            // Arrange:
            int[,] board = new int[4, 4] {
                        { 0, 0, 1, 0 },
                        { 2, 0, 0, 0 },
                        { 0, 0, 3, 0 },
                        { 4, 0, 0, 0 } };
            GameBoard gameBoard = new GameBoard(board, 0, 0, 4);
            List<int> expectedOptionsList = new List<int> { 3 };
        
            // Act:
            List<int> ResultOptionsList = gameBoard.GetOptionsList();

            // Assert:
            CollectionAssert.AreEqual(ResultOptionsList, expectedOptionsList);
        }

        [TestMethod()]
        public void GetOptionsList_CellHasFewOptions_ReturnsListOfFewNumbers()
        {
            // Testing how the function acts in a case on which the cell has few options.
            // In this test, we expect the function to return a list containing the numbers 3,8
            // for the first cell in the board.

            // Arrange:
            int[,] board = new int[9, 9]
            {
                { 0,5,0,0,0,0,0,9,0 },
                { 2,0,0,5,0,0,0,0,1 },
                { 9,7,0,3,8,0,0,0,2 },
                { 0,0,2,0,6,0,9,1,0 },
                { 0,8,0,9,0,4,0,0,0 },
                { 6,1,9,0,2,0,3,0,0 },
                { 5,0,0,0,9,8,0,0,4 },
                { 4,0,0,0,3,1,0,0,6 },
                { 1,3,0,0,0,0,0,2,0 }
            };
            GameBoard gameBoard = new GameBoard(board, 0, 0, 9);
            List<int> ExpectedOptionsList = new List<int> { 3, 8 };

            // Act:
            List<int> ResultOptionsList = gameBoard.GetOptionsList();

            // Assert:
            CollectionAssert.AreEqual(ResultOptionsList, ExpectedOptionsList);
        }

        [TestMethod()]
        public void GetOptionsList_CellAlreadyContainsValue_ReturnsAnEmptyList()
        {
            // Testing how the function acts in a case on which the cell already contains value.
            // In this test, we expect the function to return an empty list for the second cell
            // in the board (board[0,1]).

            // Arrange:
            int[,] board = new int[9, 9]
            {
                { 0,5,0,0,0,0,0,9,0 },
                { 2,0,0,5,0,0,0,0,1 },
                { 9,7,0,3,8,0,0,0,2 },
                { 0,0,2,0,6,0,9,1,0 },
                { 0,8,0,9,0,4,0,0,0 },
                { 6,1,9,0,2,0,3,0,0 },
                { 5,0,0,0,9,8,0,0,4 },
                { 4,0,0,0,3,1,0,0,6 },
                { 1,3,0,0,0,0,0,2,0 }
            };
            GameBoard gameBoard = new GameBoard(board, 0, 1, 9);
            List<int> ExpectedOptionsList = new List<int> ();

            // Act:
            List<int> ResultOptionsList = gameBoard.GetOptionsList();

            // Assert:
            CollectionAssert.AreEqual(ResultOptionsList, ExpectedOptionsList);
        }

        [TestMethod()]
        public void GetOptionsList_CellHasMaxOptions_ReturnsAListWithAllValue()
        {
            // Testing how the function acts in a case on which it receives an empty board.
            // We expect the function to return a list containing all the values between
            // 0->blockSize (in thie example: 0->16) for the first cell in the board.

            // Arrange:
            int[,] board = new int[16, 16]
            {
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 }
            };
            GameBoard gameBoard = new GameBoard(board, 0, 0, 16);
            List<int> ExpectedOptionsList = new List<int>{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

            // Act:
            List<int> ResultOptionsList = gameBoard.GetOptionsList();

            // Assert:
            CollectionAssert.AreEqual(ResultOptionsList, ExpectedOptionsList);
        }
        #endregion

        #region IsNotInRow Tests
        [TestMethod()]
        public void IsNotInRow_ValueIsNotInRow_ReturnsTrue()
        {
            // Testing how the function acts in case the value isn't in the row. In this
            // test, the number 3 isn't in the first row, therefore we expect to receive true.

            // Arrange:
            int[,] board = new int[9, 9]
            {
                { 0,5,0,0,0,0,0,9,0 },
                { 2,0,0,5,0,0,0,0,1 },
                { 9,7,0,3,8,0,0,0,2 },
                { 0,0,2,0,6,0,9,1,0 },
                { 0,8,0,9,0,4,0,0,0 },
                { 6,1,9,0,2,0,3,0,0 },
                { 5,0,0,0,9,8,0,0,4 },
                { 4,0,0,0,3,1,0,0,6 },
                { 1,3,0,0,0,0,0,2,0 }
            };
            GameBoard gameBoard = new GameBoard(board, 0, 0, 9);

            // Act:
            bool result = gameBoard.IsNotInRow(3);

            // Assert:
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void IsNotInRow_ValueIsInRow_ReturnsFalse()
        {
            // Testing how the function acts in case the value is in the row. In this
            // test, the number 9 is in the first row, therefore we expect to receive false.

            // Arrange:
            int[,] board = new int[9, 9]
            {
                { 0,5,0,0,0,0,0,9,0 },
                { 2,0,0,5,0,0,0,0,1 },
                { 9,7,0,3,8,0,0,0,2 },
                { 0,0,2,0,6,0,9,1,0 },
                { 0,8,0,9,0,4,0,0,0 },
                { 6,1,9,0,2,0,3,0,0 },
                { 5,0,0,0,9,8,0,0,4 },
                { 4,0,0,0,3,1,0,0,6 },
                { 1,3,0,0,0,0,0,2,0 }
            };
            GameBoard gameBoard = new GameBoard(board, 0, 0, 9);

            // Act:
            bool result = gameBoard.IsNotInRow(5);

            // Assert:
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void IsNotInRow_RowIsEmpty_ReturnsTrue()
        {
            // Testing how the function acts in case the row that is being checked is empty.
            // In this test, the first row contains only zeroes and we're checking if the value
            // 1 appears in it. Therefore, we expect to receive true.

            // Arrange:
            int[,] board = new int[9, 9]
            {
                { 0,0,0,0,0,0,0,0,0 },
                { 2,0,0,5,0,0,0,0,1 },
                { 9,7,0,3,8,0,0,0,2 },
                { 0,0,2,0,6,0,9,1,0 },
                { 0,8,0,9,0,4,0,0,0 },
                { 6,1,9,0,2,0,3,0,0 },
                { 5,0,0,0,9,8,0,0,4 },
                { 4,0,0,0,3,1,0,0,6 },
                { 1,3,0,0,0,0,0,2,0 }
            };
            GameBoard gameBoard = new GameBoard(board, 0, 0, 9);

            // Act:
            bool result = gameBoard.IsNotInRow(1);

            // Assert:
            Assert.IsTrue(result);
        }
        
        [TestMethod()]
        public void IsNotInRow_RowIsFull_ReturnsFalse()
        {
            // Testing how the function acts in case the row that is being checked is full.
            // In this test, the first row contains all the available values, therefore when we
            // check if 1 appears in the row, we expect to receive false.

            // Arrange:
            int[,] board = new int[9, 9]
            {
                { 8,5,4,1,7,2,6,9,3 },
                { 2,0,0,5,0,0,0,0,1 },
                { 9,7,0,3,8,0,0,0,2 },
                { 0,0,2,0,6,0,9,1,0 },
                { 0,8,0,9,0,4,0,0,0 },
                { 6,1,9,0,2,0,3,0,0 },
                { 5,0,0,0,9,8,0,0,4 },
                { 4,0,0,0,3,1,0,0,6 },
                { 1,3,0,0,0,0,0,2,0 }
            };
            GameBoard gameBoard = new GameBoard(board, 0, 0, 9);

            // Act:
            bool result = gameBoard.IsNotInRow(1);

            // Assert:
            Assert.IsFalse(result);
        }
        #endregion

        #region IsNotInCol Tests
        [TestMethod()]
        public void IsNotInCol_ValueIsNotInColumn_ReturnsTrue()
        {
            // Testing how the function acts in case the value isn't in the column. In this
            // test, the number 3 isn't in the first column, therefore we expect to receive true.

            // Arrange:
            int[,] board = new int[9, 9]
            {
                { 0,5,0,0,0,0,0,9,0 },
                { 2,0,0,5,0,0,0,0,1 },
                { 9,7,0,3,8,0,0,0,2 },
                { 0,0,2,0,6,0,9,1,0 },
                { 0,8,0,9,0,4,0,0,0 },
                { 6,1,9,0,2,0,3,0,0 },
                { 5,0,0,0,9,8,0,0,4 },
                { 4,0,0,0,3,1,0,0,6 },
                { 1,3,0,0,0,0,0,2,0 }
            };
            GameBoard gameBoard = new GameBoard(board, 0, 0, 9);

            // Act:
            bool result = gameBoard.IsNotInColumn(3);

            // Assert:
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void IsNotInCol_ValueIsInColumn_ReturnsFalse()
        {
            // Testing how the function acts in case the value is in the column. In this
            // test, the number 9 is in the first column, therefore we expect to receive false.

            // Arrange:
            int[,] board = new int[9, 9]
            {
                { 0,5,0,0,0,0,0,9,0 },
                { 2,0,0,5,0,0,0,0,1 },
                { 9,7,0,3,8,0,0,0,2 },
                { 0,0,2,0,6,0,9,1,0 },
                { 0,8,0,9,0,4,0,0,0 },
                { 6,1,9,0,2,0,3,0,0 },
                { 5,0,0,0,9,8,0,0,4 },
                { 4,0,0,0,3,1,0,0,6 },
                { 1,3,0,0,0,0,0,2,0 }
            };
            GameBoard gameBoard = new GameBoard(board, 0, 0, 9);

            // Act:
            bool result = gameBoard.IsNotInColumn(2);

            // Assert:
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void IsNotInCol_ColumnIsEmpty_ReturnsTrue()
        {
            // Testing how the function acts in case the column that is being checked is empty.
            // In this test, the first column contains only zeroes and we're checking if the
            // value 1 appears in it. Therefore, we expect to receive true.

            // Arrange:
            int[,] board = new int[9, 9]
            {
                { 0,5,0,0,0,0,0,9,0 },
                { 0,0,0,5,0,0,0,0,1 },
                { 0,7,0,3,8,0,0,0,2 },
                { 0,0,2,0,6,0,9,1,0 },
                { 0,8,0,9,0,4,0,0,0 },
                { 0,1,9,0,2,0,3,0,0 },
                { 0,0,0,0,9,8,0,0,4 },
                { 0,0,0,0,3,1,0,0,6 },
                { 0,3,0,0,0,0,0,2,0 }
            };
            GameBoard gameBoard = new GameBoard(board, 0, 0, 9);

            // Act:
            bool result = gameBoard.IsNotInColumn(1);

            // Assert:
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void IsNotInCol_ColumnIsFull_ReturnsFalse()
        {
            // Testing how the function acts in case the column that is being checked is full.
            // In this test, the first column contains all the available values, therefore
            // when we check if 1 appears in the column, we expect to receive false.

            // Arrange:
            int[,] board = new int[9, 9]
            {
                { 8,5,4,1,7,2,6,9,3 },
                { 2,0,0,5,0,0,0,0,1 },
                { 9,7,0,3,8,0,0,0,2 },
                { 7,0,2,0,6,0,9,1,0 },
                { 3,8,0,9,0,4,0,0,0 },
                { 6,1,9,0,2,0,3,0,0 },
                { 5,0,0,0,9,8,0,0,4 },
                { 4,0,0,0,3,1,0,0,6 },
                { 1,3,0,0,0,0,0,2,0 }
            };
            GameBoard gameBoard = new GameBoard(board, 0, 0, 9);

            // Act:
            bool result = gameBoard.IsNotInColumn(1);

            // Assert:
            Assert.IsFalse(result);
        }
        #endregion

        #region IsNotInSquare Tests
        [TestMethod()]
        public void IsNotInSquare_ValueIsNotInSquare_ReturnsTrue()
        {
            // Testing how the function acts in case the value isn't in the square. In this
            // test, the number 3 isn't in the square being checked, therefore we expect to
            // receive true.

            // Arrange:
            int[,] board = new int[9, 9]
            {
                { 0,5,0,0,0,0,0,9,0 },
                { 2,0,0,5,0,0,0,0,1 },
                { 9,7,0,3,8,0,0,0,2 },
                { 0,0,2,0,6,0,9,1,0 },
                { 0,8,0,9,0,4,0,0,0 },
                { 6,1,9,0,2,0,3,0,0 },
                { 5,0,0,0,9,8,0,0,4 },
                { 4,0,0,0,3,1,0,0,6 },
                { 1,3,0,0,0,0,0,2,0 }
            };
            GameBoard gameBoard = new GameBoard(board, 0, 0, 9);

            // Act:
            bool result = gameBoard.IsNotInSquare(0, 0, 3, 3);

            // Assert:
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void IsNotInSquare_ValueIsInSquare_ReturnsFalse()
        {
            // Testing how the function acts in case the value is in the square. In this
            // test, the number 9 is in the square being checked, therefore we expect
            // to receive false.

            // Arrange:
            int[,] board = new int[9, 9]
            {
                { 0,5,0,0,0,0,0,9,0 },
                { 2,0,0,5,0,0,0,0,1 },
                { 9,7,0,3,8,0,0,0,2 },
                { 0,0,2,0,6,0,9,1,0 },
                { 0,8,0,9,0,4,0,0,0 },
                { 6,1,9,0,2,0,3,0,0 },
                { 5,0,0,0,9,8,0,0,4 },
                { 4,0,0,0,3,1,0,0,6 },
                { 1,3,0,0,0,0,0,2,0 }
            };
            GameBoard gameBoard = new GameBoard(board, 0, 0, 9);

            // Act:
            bool result = gameBoard.IsNotInSquare(0, 0, 2, 3);

            // Assert:
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void IsNotInSquare_SquareIsEmpty_ReturnsTrue()
        {
            // Testing how the function acts in case the square that is being checked is empty.
            // In this test, the square that is being checked contains only zeroes and we're
            // checking if the value 1 appears in it. Therefore, we expect to receive true.

            // Arrange:
            int[,] board = new int[9, 9]
            {

                { 0,0,0,0,0,0,0,9,0 },
                { 0,0,0,5,0,0,0,0,1 },
                { 0,0,0,3,8,0,0,0,2 },
                { 0,0,2,0,6,0,9,1,0 },
                { 0,8,0,9,0,4,0,0,0 },
                { 6,1,9,0,2,0,3,0,0 },
                { 5,0,0,0,9,8,0,0,4 },
                { 4,0,0,0,3,1,0,0,6 },
                { 1,3,0,0,0,0,0,2,0 }
            };
            GameBoard gameBoard = new GameBoard(board, 0, 0, 9);

            // Act:
            bool result = gameBoard.IsNotInSquare(0, 0, 1, 3);

            // Assert:
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void IsNotInSquare_SquareIsFull_ReturnsFalse()
        {

            // Testing how the function acts in case the square that is being checked is full.
            // In this test, the square that is being checked contains all the available values
            // therefore when we check if 1 appears in the row, we expect to receive false.

            // Arrange:
            int[,] board = new int[9, 9]
            {
                { 8,5,4,1,7,2,6,9,3 },
                { 2,6,3,5,0,0,0,0,1 },
                { 9,7,1,3,8,0,0,0,2 },
                { 7,0,2,0,6,0,9,1,0 },
                { 3,8,0,9,0,4,0,0,0 },
                { 6,1,9,0,2,0,3,0,0 },
                { 5,0,0,0,9,8,0,0,4 },
                { 4,0,0,0,3,1,0,0,6 },
                { 1,3,0,0,0,0,0,2,0 }
            };
            GameBoard gameBoard = new GameBoard(board, 0, 0, 9);

            // Act:
            bool result = gameBoard.IsNotInSquare(0, 0, 1, 3);

            // Assert:
            Assert.IsFalse(result);
        }
        #endregion

        #region GetNextEmptyCell Tests
        [TestMethod()]
        public void GetNextEmptyCell_ThereIsAnEmptyCellInBoard_ReturnsTrueAndUpdatesIndexes()
        {
            // Arrange:
            int[,] board = new int[9, 9]
            {
                { 1,5,0,0,0,0,0,9,0 },
                { 2,0,0,5,0,0,0,0,1 },
                { 9,7,0,3,8,0,0,0,2 },
                { 0,0,2,0,6,0,9,1,0 },
                { 0,8,0,9,0,4,0,0,0 },
                { 6,1,9,0,2,0,3,0,0 },
                { 5,0,0,0,9,8,0,0,4 },
                { 4,0,0,0,3,1,0,0,6 },
                { 1,3,0,0,0,0,0,2,0 }
            };
            GameBoard gameBoard = new GameBoard(board, 0, 0, 9);

            // Act:
            bool result = gameBoard.GetNextEmptyCell();

            // Assert:
            Assert.IsTrue(result && gameBoard.NextEmptyCellRowIndex == 0
                && gameBoard.NextEmptyCellColIndex == 2);
        }

        [TestMethod()]
        public void GetNextEmptyCell_BoardIsEmpty_ReturnsTrueAndUpdatesIndexes()
        {
            int[,] board = new int[16, 16]
            {
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 }
            };
            GameBoard gameBoard = new GameBoard(board, 0, 0, 16);

            // Act:
            bool result = gameBoard.GetNextEmptyCell();

            // Assert:
            Assert.IsTrue(result && gameBoard.NextEmptyCellRowIndex == 0
                && gameBoard.NextEmptyCellColIndex == 0);
        }

        [TestMethod()]
        public void GetNextEmptyCell_BoardIsFull_ReturnsFalse()
        {
            // Arrange:
            int[,] board = new int[4, 4]
            {
                { 3, 4, 1, 2 },
                { 2, 1, 4, 3 },
                { 1, 2, 3, 4 },
                { 4, 3, 2, 1 }
            };
            GameBoard gameBoard = new GameBoard(board, 0, 0, 4);

            // Act:
            bool result = gameBoard.GetNextEmptyCell();

            // Assert:
            Assert.IsTrue(!result && gameBoard.NextEmptyCellRowIndex == 0
                && gameBoard.NextEmptyCellColIndex == 0);
        }
        #endregion

        #region Solve Tests
        [TestMethod()]
        public void Solve_SimpleBoardWithoutGuesses_SolvesBoardAndReturnsTrue()
        {
            // Testing how the function acts in a case on which it receives a board
            // that doesn't require it to make any guesses in order to solve it.
            // We expect the function to successfuly solve the board. 

            // Arrange:
            int[,] board = new int[4, 4]
            {
                { 0, 0, 1, 0 },
                { 2, 0, 0, 0 },
                { 0, 0, 3, 0 },
                { 4, 0, 0, 0 }
            };
            GameBoard gameBoard = new GameBoard(board, 0, 0, 4);
            int[,] solvedBoard = new int[4, 4]
            {
                { 3, 4, 1, 2 },
                { 2, 1, 4, 3 },
                { 1, 2, 3, 4 },
                { 4, 3, 2, 1 }
            };

            // Act:
            bool result = gameBoard.Solve(gameBoard);

            // Assert:
            if (result == true)
                CollectionAssert.AreEqual(gameBoard.Board, solvedBoard);
            else
                Assert.IsTrue(result); // Function couldn't solve board.
        }

        [TestMethod()]
        public void Solve_ComplicatedBoardWithGuesses_SolvesBoard()
        {
            // Testing how the function acts in a case on which it receives a board
            // that requires it to make guesses in order to solve it.
            // We expect the function to successfuly solve the board.

            // Arrange:
            int[,] board = new int[9, 9]
            {
                { 0,5,0,0,0,0,0,9,0 },
                { 2,0,0,5,0,0,0,0,1 },
                { 9,7,0,3,8,0,0,0,2 },
                { 0,0,2,0,6,0,9,1,0 },
                { 0,8,0,9,0,4,0,0,0 },
                { 6,1,9,0,2,0,3,0,0 },
                { 5,0,0,0,9,8,0,0,4 },
                { 4,0,0,0,3,1,0,0,6 },
                { 1,3,0,0,0,0,0,2,0 }
            };
            GameBoard gameBoard = new GameBoard(board, 0, 0, 9);
            int[,] solvedBoard = new int[9, 9]
            {
                { 8,5,4,1,7,2,6,9,3 },
                { 2,6,3,5,4,9,7,8,1 },
                { 9,7,1,3,8,6,4,5,2 },
                { 7,4,2,8,6,3,9,1,5 },
                { 3,8,5,9,1,4,2,6,7 },
                { 6,1,9,7,2,5,3,4,8 },
                { 5,2,7,6,9,8,1,3,4 },
                { 4,9,8,2,3,1,5,7,6 },
                { 1,3,6,4,5,7,8,2,9 }
            };

            // Act:
            bool result = gameBoard.Solve(gameBoard);

            // Assert:
            if (result == true)
                CollectionAssert.AreEqual(gameBoard.Board, solvedBoard);
            else
                Assert.IsTrue(result); // Function couldn't solve board.
        }
        
        [TestMethod()]
        public void Solve_SmallestBoardPossible_SolvesBoard()
        {
            // Since the 1x1 board is a special case which creates the smallest Sudoku board
            // according to the Sudoku defenition (since 1's 3rd root is 1),
            // We test how the function will act with such board, expecting
            // that the "special" size won't affect it's performance.

            // Arrange:
            int[,] board = new int[1, 1] { { 0 } };
            GameBoard gameBoard = new GameBoard(board, 0, 0, 1);
            int[,] solvedBoard = new int[1, 1] { { 1 } };

            // Act:
            bool result = gameBoard.Solve(gameBoard);

            // Assert:
            if (result == true)
                CollectionAssert.AreEqual(gameBoard.Board, solvedBoard);
            else
                Assert.IsTrue(result); // Function couldn't solve board.
        }

        [TestMethod()]
        public void Solve_BoardIsEmpty_SolvesBoard()
        {
            // Testing how the function acts in a case on which it receives an empty board.
            // We expect the function to solve the board.

            // Arrange:
            int[,] board = new int[16, 16]
            {
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 }
            };
            GameBoard gameBoard = new GameBoard(board, 0, 0, 16);

            // Act:
            bool result = gameBoard.Solve(gameBoard);

            // Assert:
            Assert.IsTrue(result);
        }
        
        [TestMethod()]
        public void Solve_BoardIsSolved_ReturnsTrue()
        {
            // Testing how the function acts in a case on which it receives a board which has
            // already been solved.
            // We expect the function to return true.

            // Arrange:
            int[,] board = new int[9, 9]
            {
                { 1,2,3,4,5,6,7,8,9 },
                { 4,5,6,7,8,9,1,2,3 },
                { 7,8,9,1,2,3,4,5,6 },
                { 2,1,4,3,6,5,8,9,7 },
                { 3,6,5,8,9,7,2,1,4 },
                { 8,9,7,2,1,4,3,6,5 },
                { 5,3,1,6,4,2,9,7,8 },
                { 6,4,2,9,7,8,5,3,1 },
                { 9,7,8,5,3,1,6,4,2 }
            };
            GameBoard gameBoard = new GameBoard(board, 0, 0, 9);

            // Act:
            bool result = gameBoard.Solve(gameBoard);

            // Assert:
            if (result == true)
                CollectionAssert.AreEqual(gameBoard.Board, board); // Test passed & the function didn't change the board.
            else
                Assert.IsTrue(result); // Function couldn't solve board.
        }
        
        [TestMethod()]
        public void Solve_InvalidBoardValues_ReturnsFalse()
        {
            // Testing how the function acts in a case on which it receives an invalid board.
            // We expect the function to return false, since the board can't be solved.

            // Arrange:
            int[,] board = new int[4, 4]
            {
                { 1, 1, 1, 1 },
                { 2, 0, 0, 0 },
                { 0, 0, 3, 0 },
                { 4, 0, 0, 0 }
            };
            GameBoard gameBoard = new GameBoard(board, 0, 0, 4);

            // Act:
            bool result = gameBoard.Solve(gameBoard);

            // Assert:
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void Solve_InvalidBoardSize_ReturnsFalse()
        {
            // Testing how the function acts in case it received a board with an invalid size.
            // We expect the function to return false, since a board with an invalid size
            // isn't a sudoku, which means that it can't be solved.

            // Arrange:
            int[,] board = new int[3, 3]
            {
                { 3, 2, 1 },
                { 2, 0, 0 },
                { 0, 0, 3 }
            };
            GameBoard gameBoard = new GameBoard(board, 0, 0, 3);

            // Act:
            bool result = gameBoard.Solve(gameBoard);

            // Assert:
            Assert.IsFalse(result);
        }
        #endregion
    }
}