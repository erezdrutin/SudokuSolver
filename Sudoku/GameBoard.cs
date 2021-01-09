using System;
using System.Collections.Generic;

namespace Sudoku
{
    public class GameBoard
    {
        // Variables Defenition:
        private int[,] _board;
        private int _nextEmptyCellRowIndex;
        private int _nextEmptyCellColIndex;
        private int _blockSize;

        // Getters and Setters:
        public int[,] Board { get => _board; set => _board = value; }
        public int BlockSize { get => _blockSize; set => _blockSize = value; }
        public int NextEmptyCellRowIndex { get => _nextEmptyCellRowIndex; set => _nextEmptyCellRowIndex = value; }
        public int NextEmptyCellColIndex { get => _nextEmptyCellColIndex; set => _nextEmptyCellColIndex = value; }

        // Constructor:
        public GameBoard(int[,] board, int rowIndex, int colIndex, int blockSize)
        {
            this._board = board;
            this.NextEmptyCellRowIndex = rowIndex;
            this.NextEmptyCellColIndex = colIndex;
            this._blockSize = blockSize;
        }

        // Inserting values from a string to the board:
        public void InsertValuesToBoard(string str)
        {
            // Inserting the values (From the string) to the board:
            for (int i = 0; i < _blockSize; i++)
            {
                for (int j = 0; j < _blockSize; j++)
                {
                    _board[i, j] = str[i * _blockSize + j] - '0'; // Setting the cell's value
                }
            }
        }
        
        // Using a backtracking algorithm for solving the Sudoku:
        public bool Solve(GameBoard gameBoard)
        {
            // Creating a new instance of the GameBoard class every run of the recursion,
            // so that we won't lose the board state between turn to turn:
            gameBoard = new GameBoard(gameBoard.Board, 0, 0, gameBoard.BlockSize);

            // If gameBoard.IsFull return true then the function Finished solving,
            // and the game board is full of numbers. Otherwise, the function will
            // update gameBoard's Col, Row indexes to be those of the first instance
            // of the value 0 that it found:
            if (!gameBoard.GetNextEmptyCell())
            {
                return true;
            }

            // Using a foreach loop, running through all of the options for the current
            // cell in game board:
            foreach (int value in gameBoard.GetOptionsList())
            {
                // Setting temp value to the first value
                // that came from the GetOptions function:
                gameBoard.SetValue(value);
                if (Solve(this))
                    return true;
                else
                    gameBoard.SetValue(0);
            }

            // Returning false - could either be because the current "guess"
            // failed and we want to go back or because the program didn't
            // manage to find a solution to the board:
            return false;
        }

        // Returns a list of options for the current cell that is being checked on the board.
        // If a cell already contains a value, the returned list will be an empty list:
        public List<int> GetOptionsList()
        {
            // Variables Defenition:
            List<int> optionsList = new List<int>();
            // Defining a variable to store the size of a row/cell of numbers in a square:
            int sizeOfSquareBlock = (int)Math.Sqrt(_blockSize);

            // Using a for loop, going through the values 1->_blockSize (including the edges)
            // and checking if they are a viable possibility for the current position on the board:
            if (_board[_nextEmptyCellRowIndex,_nextEmptyCellColIndex] == 0)
            {
                for (int value = 1; value <= _blockSize; value++)
                {
                    // Checking that the value doesn't show up in the same row, column or square as the
                    // value that is currently being checked, and then adding it to the list of options:
                    if (IsNotInRow(value) && IsNotInColumn(value)
                        && IsNotInSquare(_nextEmptyCellRowIndex - _nextEmptyCellRowIndex % sizeOfSquareBlock,
                        _nextEmptyCellColIndex - _nextEmptyCellColIndex % sizeOfSquareBlock, value, sizeOfSquareBlock))
                        optionsList.Add(value);
                }
            }
            // Returning a list with the options for the current cell:
            return optionsList;
        }

        // Helping Function - Filling all the certain cells options in the sudoku:
        public void FillCertainOptions()
        {
            for (int i = 0; i < _blockSize; i++)
            {
                for (int j = 0; j < _blockSize; j++)
                {
                    // For each empty cell setting the indexes of the row & col in order to use
                    // the GetOptionsList function to fill it's options list and accordingly
                    // update the board in case the options list contains only 1 value, which
                    // means that we can know for sure what the value of the cell is:
                    _nextEmptyCellRowIndex = i;
                    _nextEmptyCellColIndex = j;
                    List<int> lst = GetOptionsList();
                    if (lst.Count == 1)
                    {
                        _board[i, j] = lst[0];
                    }
                }
            }
        }

        // Checking whether a value in the board exists already in the same row or not:
        public bool IsNotInRow(int value)
        {
            for (int i = 0; i < _blockSize; i++)
            {
                // Checking if another slot in the same row in the matrix
                // contains the same value as the one in mat[row,col] contains.
                if (_board[NextEmptyCellRowIndex, i] == value && i != NextEmptyCellColIndex)
                {
                    return false; // Stopping the loop and returning false.
                }
            }
            // Returning true - The value doesn't exist in the same row:
            return true;
        }

        // Checking whether a value in the board exists already in the same column or not:
        public bool IsNotInColumn(int value)
        {
            for (int i = 0; i < _blockSize; i++)
            {
                // Checking if another slot in the same column in the matrix
                // contains the same value as the one in mat[row,col] contains.
                if (_board[i, NextEmptyCellColIndex] == value && i != NextEmptyCellRowIndex)
                {
                    return false; // Stopping the loop and returning false.
                }
            }
            // Returning true - The value doesn't exist in the same column:
            return true;
        }

        // Checking whether a value in the board exists already in the same square or not:
        public bool IsNotInSquare(int startRow, int startCol, int value, int SquareBlock)
        {
            // If we got here, the sizeOfSquare must have a root,
            // which means that we can get the lengths of the rows
            // and the columns in the "Square" we're currently checking.
            for (int i = startRow; i < startRow + SquareBlock; i++)
            {
                for (int j = startCol; j < startCol + SquareBlock; j++)
                {
                    // board[i,j] == value -> Checking if the value exists in the Square already.
                    if ((i != _nextEmptyCellRowIndex || j != _nextEmptyCellColIndex) && _board[i, j] == value)
                        return false;
                }
            }
            return true;
        }

        // Updates GameBoard's _nextEmptyCellRowIndex, _nextEmptyCellColIndex to be set
        // to those of the next empty cell on the board. If the board is full, the function
        // will return false, because it wouldn't be able to find an empty cell:
        public bool GetNextEmptyCell()
        {
            // If there's an element with the value 0 then the board isn't full.
            // Therefore, setting m_RowIndex and m_ColIndex to those of that instance of the
            // value 0 and returning false. Otherwise, returning true:
            for (int i = _nextEmptyCellRowIndex; i < _blockSize; i++)
            {
                for (int j = _nextEmptyCellColIndex; j < _blockSize; j++)
                {
                    if (_board[i, j] == 0)
                    {
                        _nextEmptyCellRowIndex = i;
                        _nextEmptyCellColIndex = j;
                        return true;
                    }
                }
            }
            // Returning false - the board is full of numbers:
            return false;
        }

        // Updates a cell's value in the board:
        private void SetValue(int value)
        {
            _board[_nextEmptyCellRowIndex, _nextEmptyCellColIndex] = value;
        }
    }
}