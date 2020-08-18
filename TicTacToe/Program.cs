using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
        resetpoint:
            var tictactoe = new TicTacToe();
            WinnerDetails winner = new WinnerDetails() { HasWon = false, Winner = null };
            do
            {
                tictactoe.PlayGame();
                winner = tictactoe.CheckWinner();
            } while (!winner.HasWon && winner.Winner != 0);
            if (winner.HasWon)
                Console.WriteLine("The winner of this round is Player" + winner.Winner);
            else
                Console.WriteLine("No winner this round");
            Console.WriteLine("Would you like to play again? Select Y for YES and N for NO");
            var reset = Console.ReadLine();
            if (reset.ToUpper() == "Y")
                goto resetpoint;

            Console.Read();
        }
    }
}
