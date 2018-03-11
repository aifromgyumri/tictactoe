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
            GameLogic logic = new GameLogic();
            while (true)
            {
                string readLocations = Console.ReadLine();
                var locationArray = readLocations.Split(' ');
                var x = int.Parse(locationArray[0]);
                var y = int.Parse(locationArray[1]);
                var gameState=logic.Move(x, y);
                if (gameState!=GameState.NotFinished&&gameState!=GameState.NotValid)
                {
                    
                    Console.WriteLine(gameState);
                    if (gameState==GameState.PlayerWin)
                    {
                        Console.WriteLine(logic.Player);
                    }
                    break;
                }
                else if (gameState==GameState.NotValid)
                {
                    Console.WriteLine("Not valid move");
                }

            }
            Console.Read();
        }
    }
}
