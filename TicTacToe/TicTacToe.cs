using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class TicTacToe
    {
        private char[] board = new char[9] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private int currentPlayer = 1;
        private char currentValue = 'X';
        private void SetValue(int selection, char value)
        {
            var validatedData = IsValidInput(selection);
            if (validatedData.IsPass)
            {
                board[selection - 1] = value;
                CreatePlayboard();
                SwitchPlayer();
            }
            else
            {
                Console.WriteLine(validatedData.Message);
                Console.ReadKey();
            }
        }

        private void SwitchPlayer()
        {
            if (currentPlayer == 2)
            {
                currentPlayer = 1;
                currentValue = 'X';
            }
            else
            {
                currentPlayer = 2;
                currentValue = 'O';
            }
        }

        public void PlayGame()
        {
            CreatePlayboard();
            Console.WriteLine("\n Player {0} chance", currentPlayer);
            Console.WriteLine("\n Select number from grid:");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int isparsed))
                SetValue(int.Parse(input), currentValue);
            else
            {
                Console.WriteLine("Please enter valid input from the table shown");
                Console.ReadKey();
            }
        }

        private void CreatePlayboard()
        {
            Console.Clear();
            Console.WriteLine("Player 1: X and Player 2: 0\n");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[0], board[1], board[2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[3], board[4], board[5]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[6], board[7], board[8]);
            Console.WriteLine("     |     |      ");
        }

        internal WinnerDetails CheckWinner()
        {
            if (board.All(x => x.Equals('O') || x.Equals('X')))
                return new WinnerDetails() { HasWon = false, Winner = 0 };
            #region Horzontal Winning Condtion
            //Winning Condition For First Row   
            if (board[0] == board[1] && board[1] == board[2])
            {
                return new WinnerDetails() { HasWon = true, Winner = board[1] == 'X' ? 1 : 2 };
            }
            //Winning Condition For Second Row   
            else if (board[3] == board[4] && board[4] == board[5])
            {
                return new WinnerDetails() { HasWon = true, Winner = board[1] == 'X' ? 1 : 2 };
            }
            //Winning Condition For Third Row   
            else if (board[6] == board[7] && board[7] == board[8])
            {
                return new WinnerDetails() { HasWon = true, Winner = board[1] == 'X' ? 1 : 2 };
            }
            #endregion
            #region vertical Winning Condtion
            //Winning Condition For First Column       
            else if (board[0] == board[3] && board[3] == board[6])
            {
                return new WinnerDetails() { HasWon = true, Winner = board[1] == 'X' ? 1 : 2 };
            }
            //Winning Condition For Second Column  
            else if (board[1] == board[4] && board[4] == board[7])
            {
                return new WinnerDetails() { HasWon = true, Winner = board[1] == 'X' ? 1 : 2 };
            }
            //Winning Condition For Third Column  
            else if (board[2] == board[5] && board[5] == board[8])
            {
                return new WinnerDetails() { HasWon = true, Winner = board[1] == 'X' ? 1 : 2 };
            }
            #endregion
            #region Diagonal Winning Condition
            else if (board[0] == board[4] && board[4] == board[8])
            {
                return new WinnerDetails() { HasWon = true, Winner = board[1] == 'X' ? 1 : 2 };
            }
            else if (board[2] == board[4] && board[4] == board[6])
            {
                return new WinnerDetails() { HasWon = true, Winner = board[1] == 'X' ? 1 : 2 };
            }
            #endregion
            return new WinnerDetails() { HasWon = false };
        }

        internal ErrorLog IsValidInput(int input)
        {
            if (input > 9 || input < 0)
                return new ErrorLog() { IsPass = false, Message = "Please select a value between 0 and 9" };
            if (board[input - 1] == 'X' || board[input - 1] == 'O')
                return new ErrorLog() { IsPass = false, Message = "Please select another value since this is already selected" };
            else
                return new ErrorLog() { IsPass = true };
        }
    }
    internal class ErrorLog
    {
        public string Message { get; set; }
        public bool IsPass { get; set; }
    }
    public class WinnerDetails
    {
        public int? Winner { get; set; }
        public bool HasWon { get; set; }
    }
}
