using System;

namespace Sudoku
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Setting the title of the console to "Sudoku Solver"
            Console.Title = "Sudoku Solver";

            // Defining an instance of the InputOutput class:
            InputOutput inputOutput = new InputOutput();

            // Printing an opening message to the user:
            char InputMethod = inputOutput.PrintOpeningMessage();
            
            // Getting the user's input. If the user's input is valid, str will contain
            // the user's input. Otherwise, str will be an empty string - "":
            string str = inputOutput.GetUserInput(InputMethod);
            
            // Running in a continious while loop until the user hits 'x' which closes the program:
            while (str != null)
            {
                // Unless we received error as the output from the functions, we will solve the
                // board. However, if we received an error, then letting the user to retry input data:
                if (str != "error" && str != "patherror")
                {
                    // Saving the size of the the board (Example: 81 chars -> 9x9 -> size of board = 9):
                    int sizeOfBoard = (int)Math.Sqrt(str.Length);

                    // Creating a new instance of the GameBoard class, and inserting the string that
                    // the user inputted to the GameBoard's matrix of values. Afterwards, printing
                    // the board to the user by sending the gameBoard and false, which tells the function
                    // that the board isn't solved yet and that it should print the board with the
                    // line "Game Board" before:
                    GameBoard gameBoard = new GameBoard(new int[sizeOfBoard, sizeOfBoard], 0, 0, sizeOfBoard);
                    gameBoard.InsertValuesToBoard(str);
                    inputOutput.PrintBoard(gameBoard, false);

                    // Calling a function in gameBoard which fills in all the certain options
                    // which we can find based on checking every row, column and square:
                    gameBoard.FillCertainOptions();

                    // Calling the SolveBoard function and if it returns as true, then printing
                    // the solved board. Otherwise, letting the user know that the board that he
                    // entered couldn't be solved:
                    if (gameBoard.Solve(gameBoard))
                    {
                        // Printing the board by sending GameBoard and true which tells the function
                        // that the board is solved therefore it should print the board with the line
                        // "Solved Board" before:
                        inputOutput.PrintBoard(gameBoard, true);
                    }
                    else
                        Console.WriteLine("\n\tThe board you've entered couldn't be solved.");
                }

                // Asking the user to choose again what he would like to do, and then
                // calling the functions accordingly in order to either continue or end the program:
                InputMethod = inputOutput.GetInputMethod();
                str = inputOutput.GetUserInput(InputMethod);
            }
        }
    }
}