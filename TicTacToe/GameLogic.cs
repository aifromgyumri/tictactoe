using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class GameLogic
    {
        private int[][] _board;
        private Players _movingPlayer;
        
        public Players Player {
            get
            {
                return _movingPlayer;
            }
        }

        
        public GameLogic()
        {
            _board = new int[3][];
            for (int i = 0; i < 3; i++)
            {
                _board[i] = new int[3];
            }
            InitBoard();
            InitGameState();
        }

        private void InitGameState()
        {
            _movingPlayer = Players.FirstPlayer;
        }

        private void InitBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _board[i][j] = 0;
                }
            }
        }

        public GameState Move(int x,int y)
        {
            if (_board[x][y] == 0)
            {
                switch (_movingPlayer)
                {
                    case Players.FirstPlayer:
                        _board[x][y] = 1;
                        break;
                    case Players.SecondPlayer:
                        _board[x][y] = -1;
                        break;
                    default:
                        break;
                        
                }
                return CheckGameState();
            }
            else {
                return GameState.NotValid;
            }
            }

        private GameState CheckGameState()
        {
            var gameState = CheckRowWin();
            if (gameState!=GameState.NotFinished)
            {
                return gameState;
            }
            gameState = CheckColumnWin();
            if (gameState!=GameState.NotFinished)
            {
                return gameState;
            }
            gameState = CheckDiagonal();
            if (gameState==GameState.NotFinished)
            {
                if (_movingPlayer==Players.FirstPlayer)
                {
                    _movingPlayer = Players.SecondPlayer;
                }
                else
                {
                    _movingPlayer = Players.FirstPlayer;
                }
            }
            gameState = CheckTie();
            return gameState;
        }

        private GameState CheckTie()
        {
            
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (_board[i][j]==0)
                    {
                        return GameState.NotFinished;    
                    }
                }
            }
            return GameState.Tie;
        }

        private GameState CheckDiagonal()
        {
            var gameState = CheckMainDiagonal();
            if (gameState!=GameState.NotFinished)
            {
                return gameState;
            }

            return CheckSecondaryDiagonal();
        }

        private GameState CheckSecondaryDiagonal()
        {
            var sum = 0;
            for (int i = 0; i < 3; i++)
            {
                sum += _board[i][2 - i];
            }

            switch (sum)
            {
                case 3:
                    return GameState.PlayerWin;
                case -3:
                    return GameState.PlayerWin;
                default:
                    return GameState.NotFinished;
            }
        }

        private GameState CheckMainDiagonal()
        {
            var sum = 0;
            for (int i = 0; i < 3; i++)
            {
                sum += _board[i][i];
            }
            switch (sum)
            {
                case 3:
                    return GameState.PlayerWin;
                case -3:
                    return GameState.PlayerWin;
                default:
                    return GameState.NotFinished;
            }
            
        }

        private GameState CheckColumnWin()
        {
            for (int i = 0; i < 3; i++)
            {
                var sum = 0;

                for (int j = 0; j < 3; j++)
                {
                    sum += _board[j][i];
                }
                switch (sum)
                {
                    case 3:
                        return GameState.PlayerWin;
                    case -3:
                        return GameState.PlayerWin;
                    default:
                        break;
                }
            }
            return GameState.NotFinished;
        }

        private GameState CheckRowWin()
        {
            for (int i = 0; i < 3; i++)
            {
                switch (_board[i].Sum())
                {
                    case 3:
                        return GameState.PlayerWin;
                    case -3:
                        return GameState.PlayerWin;
                    default:
                        break;
                }
            }
            return GameState.NotFinished;
        }
    }


 }
