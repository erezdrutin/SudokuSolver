using System;
using System.IO;
using System.Threading;

namespace Sudoku
{
    public class InputOutput
    {
        // Empty Constructor:
        public InputOutput() { }
        
        // Printing an opening message when the program loads up:
        public char PrintOpeningMessage()
        {
            Console.Write(
                  "\n\t░██████╗██╗░░░██╗██████╗░░█████╗░██╗░░██╗██╗░░░██╗  ░██████╗░█████╗░██╗░░░░░██╗░░░██╗███████╗██████╗░\n"
                + "\t██╔════╝██║░░░██║██╔══██╗██╔══██╗██║░██╔╝██║░░░██║  ██╔════╝██╔══██╗██║░░░░░██║░░░██║██╔════╝██╔══██╗\n"
                + "\t╚█████╗░██║░░░██║██║░░██║██║░░██║█████═╝░██║░░░██║  ╚█████╗░██║░░██║██║░░░░░╚██╗░██╔╝█████╗░░██████╔╝\n"
                + "\t░╚═══██╗██║░░░██║██║░░██║██║░░██║██╔═██╗░██║░░░██║  ░╚═══██╗██║░░██║██║░░░░░░╚████╔╝░██╔══╝░░██╔══██╗\n"
                + "\t██████╔╝╚██████╔╝██████╔╝╚█████╔╝██║░╚██╗╚██████╔╝  ██████╔╝╚█████╔╝███████╗░░╚██╔╝░░███████╗██║░░██║\n"
                + "\t╚═════╝░░╚═════╝░╚═════╝░░╚════╝░╚═╝░░╚═╝░╚═════╝░  ╚═════╝░░╚════╝░╚══════╝░░░╚═╝░░░╚══════╝╚═╝░░╚═╝\n"
                + "\n\tWelcome to Sudoku Solver. Enter any Sudoku board and get it's solution. \n"
                + "\tInput method options: \n"
                + "\t - Press T to input board manually.\n"
                + "\t - Press F to input board by File Path.\n"
                + "\t - Press X to exit the program.\n");

            // Returning the input method:
            return GetInputMethod();
        }

        // Asking the user to choose an input method and saving it:
        public char GetInputMethod()
        {
            Console.WriteLine("\nPlease enter your input method:");
            char inputMethod = Console.ReadKey().KeyChar; // Saving the input method
            return inputMethod;
        }
        
        // Saving a string from the console and allowing the program to read more than
        // the max amount of chars available in Console Readline (254):
        public string GetStringFromConsole()
        {
            // Extending the max size of the user's input and saving it in "str":
            int buffSize = 1024;
            Stream inStream = Console.OpenStandardInput(buffSize);
            Console.SetIn(new StreamReader(inStream, Console.InputEncoding, false, buffSize));
            string str = Console.ReadLine(); // Saving the user's input.
            return str;
        }

        // Getting the user's input which will be used to create a Sudoku:
        public string GetUserInput(char inputMethod)
        {
            // Variables Defenition:
            string str = "";
            
            // Input Method = Typing:
            if (inputMethod == 'T' || inputMethod == 't')
            {
                // Asking the User to manually input data which will be used to create a Sudoku:
                Console.WriteLine("\n\nPlease enter the board values:");
                str = GetStringFromConsole();
            }
            // Input Method = Import from file:
            else if (inputMethod == 'F' || inputMethod == 'f')
            {
                // Asking the User to input the path for the file from which we will create a Sudoku:
                Console.WriteLine("\n\nPlease enter the file's path:");
                str = Console.ReadLine(); // Saving the file's path.

                // Creating an instance of the Files class in order to import text from a txt file:
                Files files = new Files(str); // Setting an instance of the Files class in the global variable.

                // Creating an instance of uri to check if we received a string with a valid format:
                Uri uri;
                var canCreateUri = Uri.TryCreate(str, UriKind.Absolute, out uri);

                // Getting the string from the file:
                if(canCreateUri)
                    str = files.GetStringFromFile();
                // letting the program know that the user's input caused an error:
                else
                    str = "patherror";

            }
            else if (inputMethod == 'X' || inputMethod == 'x')
            {
                // Printing an exit message to the user:
                Console.WriteLine("\nThank you for using Sudoku Solver, the app will close itself" +
                    " within the next few seconds.");

                // Setting a delay of 4 seconds
                int milliseconds = 4000;
                Thread.Sleep(milliseconds);

                // Exiting the program:
                Environment.Exit(1);
            }
            else
            {
                // Setting the str to error in order to later let the user know that there
                // was an error:
                str = "error";
            }
            // If we got here then there was an error with the input recieved from a file / the user
            // and not with the choice of the input method. Therefore, returning the user's input (if true):
            if (str.Length > 0 && CheckStringInput(str) && CheckStringLength(str.Length))
                return str;

            // Else, letting the user know that the input is invalid:
            else
            {
                if (str == "error")
                    Console.WriteLine("\nCouldn't create a board, please check your input method and values, and then try again.");
                else if (str == "patherror")
                    Console.WriteLine("\nThere was an error with the path received.");
                return "error";
            }
        }

        // Checking the user's Input:
        public bool CheckStringInput(string input)
        {
            int blockSize = (int)Math.Sqrt(input.Length);
            for (int i=0; i < input.Length; i++)
            {
                // Checking that the user's input only contains digits:
                if (!((input[i] - '0' >= 0) && (input[i] - '0' <= blockSize)))
                    return false;
            }
            return true;
        }

        // Checking the length of the string:
        public bool CheckStringLength(int length)
        {
            int blockSize = (int)Math.Sqrt(length);
            int squareBlockSize = (int)Math.Sqrt(blockSize);

            // Returning True if the input's length has 2 roots, which
            // means that a Sudoku can be created from it. Otherwise,
            // returning false.
            return (Math.Sqrt(length) == blockSize &&
                Math.Sqrt(blockSize) == squareBlockSize);
        }

        // Printing the board that the user inputted:
        public void PrintBoard(GameBoard gameBoard, bool isSolved)
        {
            // Variables Defenition:
            int SquareBlockSize = (int)Math.Sqrt(gameBoard.BlockSize);
            bool isTwoDigits = (SquareBlockSize > 9);

            // Printing the board:
            // Printing the message "Game Board:" if the board isn't solved
            // and "Solved Board:" if the board is solved:
            if (isSolved == false)
                Console.WriteLine("\n\tGame Board:");
            else
                Console.WriteLine("\n\tSolved Board:");
            for (int i = 0; i < gameBoard.BlockSize; i++)
            {
                for (int j = 0; j < gameBoard.BlockSize; j++)
                {
                    if (isTwoDigits == true)
                    {
                        // Printing column by column with "fixed" locations on print:
                        if (j % SquareBlockSize == 0)
                            Console.Write("\t" + string.Format("{0, -2} ", gameBoard.Board[i, j]));
                        else
                            Console.Write(string.Format("{0, -2} ", gameBoard.Board[i, j]));
                    }
                    else
                    {
                        // Printing column by column with "fixed" locations on print:
                        if (j % SquareBlockSize == 0)
                            Console.Write("\t" + string.Format("{0, -1} ", gameBoard.Board[i, j]));
                        else
                            Console.Write(string.Format("{0, -1} ", gameBoard.Board[i, j]));
                    }
                }
                // Dropping a line after every row:
                Console.WriteLine();

                // Dropping a line every "Square" of numbers - To create spacing:
                if ((i+1)%SquareBlockSize == 0)
                {
                    Console.WriteLine();
                }
            }

            // If the board is solved - asking the user if he'd like to save the board into
            // a path or not, and based on the answer either proceeding with the run of the
            // program or saving the file.
            if (isSolved == true)
            {
                // Asking the user if he would like to save the solved board to a file or not:
                Console.WriteLine("Press S if you would like to save the solved board in a txt file\n" +
                    "or hit any another key to proceed:");
                char UserChoice = Console.ReadKey().KeyChar;
                Console.WriteLine(); // Dropping a line.
                // If the user chooses to save the solved board to a file - calling the SaveToFile function:
                if (UserChoice == 'S' || UserChoice == 's')
                    SaveToFile(gameBoard);
            }
        }
        
        // Saving the GameBoard to a file:
        public void SaveToFile(GameBoard gameBoard)
        {
            // Asking the user to enter a path to the location on which we should write the
            // solved board to and saving the board in the same format as the format we received.
            Console.WriteLine("\nPlease enter the file's path:");
            string pathStr = Console.ReadLine();
            Files files = new Files(pathStr);

            // Creating an instance of uri to check if we received a string with a valid format:
            Uri uri;
            var canCreateUri = Uri.TryCreate(pathStr, UriKind.Absolute, out uri);

            // If the string is formatted well and we can set a string in the file then
            // letting the user know. Otherwise, letting the user know that there was an error
            // with the path received from him:
            if (canCreateUri && files.SetStringInFile(gameBoard))
                Console.WriteLine("\nThe file has been successfully saved!\n" +
                    "You can solve another board if you want.");
            else
                Console.WriteLine("Couldn't write to the path you've entered.\n" +
                    "You can solve another board if you want.");
        }
    }
}