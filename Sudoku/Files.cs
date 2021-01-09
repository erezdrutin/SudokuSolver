using System;
using System.IO;

namespace Sudoku
{
    public class Files
    {
        // Variables Defenition:
        private string _textPath;

        // Getters and Setters:
        public string TextPath { get => _textPath; set => _textPath = value; }

        // Constructor:
        public Files(string textPath)
        {
            this.TextPath = textPath; // Storing the path in m_Text.
        }

        // Getting a string from a file:
        public string GetStringFromFile()
        {
            string str = "";
            try
            {
                // Updating Text to contain the string that was found
                // in the file that the program reads:
                if (CheckPath())
                    str = File.ReadAllText(_textPath);
                // There was an error - letting the function that calls this function know
                // that in order to print a matching output to the user:
                else
                    str = "patherror";
            }
            catch (IOException e)
            {
                // Letting the user know in case of an error:
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return str;
        }

        // Checking if the path input is valid:
        public bool CheckPath()
        {
            for (int i=0; i<_textPath.Length; i++)
            {
                // Text path can't contain only "c:" or "c:/", it must actually contain a path
                // such as C:\\Users\\erez\\source\\repos\\Sudoku\\str.txt:
                if (_textPath[i] != 'c' && _textPath[i] != ':' && _textPath[i] != '/'
                    && _textPath[i] != 'C' && _textPath[i] != '\\')
                    return true;
            }
            return false;
        }

        // Setting a string in a txt file:
        public bool SetStringInFile(GameBoard gameBoard)
        {
            try
            {
                // Updating the file that can be found on the location that TextPath
                // points towards to contain the solved Sudoku board values:
                if (CheckPath())
                {
                    File.WriteAllText(_textPath, BoardToString(gameBoard));
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (IOException e)
            {
                // Letting the user know in case of an error:
                Console.WriteLine("The file could not be written:");
                Console.WriteLine(e.Message);
                return false;
            }
        }

        // Transferring the board values into a string:
        public string BoardToString(GameBoard gameBoard)
        {
            string output = "";
            // Using 2 for loops, running through the board
            // and adding it to the output:
            for (int i=0; i<gameBoard.BlockSize; i++)
            {
                for (int j = 0; j < gameBoard.BlockSize; j++)
                {
                    output += (char)(gameBoard.Board[i, j] + '0');
                }
            }
            return output;
        }
    }
}
