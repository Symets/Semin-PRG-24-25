using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; //pokradeny z 2Dplayground cuz idk jak zacit novy projekt, kms fr

namespace BattleShips
{
    internal class Program
    {

        //todo: prekopej placeholder text
        static void Main(string[] args)
        {
            char[,] boardPlayer = new char[10, 10];
            char[,] boardVisibleComputer = new char[10, 10];
            char[,] boardComputer = new char[10, 10];

            CreateBoard(boardPlayer);
            CreateBoard(boardVisibleComputer);
            CreateBoard(boardComputer);
            PlaceShipsRandom(boardComputer);
            //PlaceShipsManual(boardPlayer);
            PlaceShipsRandom(boardPlayer); //<- for cheats (pokud se pan borec nechce srat s pokladani lodicek all day)
            DisplayBoard(boardPlayer); //, "     Player" todo: dopln jmena tabulek aby pan borec videl ci je ci tabulka v celym programu
            //DisplayBoard(boardComputer); //, "      Computer" <- for cheats

            bool gameOver = false;

            while (gameOver==false)
            {
                Console.Clear();
                DisplayBoard(boardPlayer); //, "     Player"
                //isplayBoard(boardVisibleComputer);
                DisplayBoard(boardComputer); //, "      Computer" <- for cheats
                //todo: dodej povolani funkce na pokladani lodi + mozna preorganizovat main cuz dvakrat volat tu fukci asi nepotrebuju?
                Console.WriteLine("you shoot");
                PlayerShoot(boardComputer, boardVisibleComputer);

                Console.WriteLine("computer shoot");
                ComputerShoot(boardPlayer);

                gameOver = CheckGameOver(boardPlayer, "...") || CheckGameOver(boardComputer, "..."); //nejako mi to nefunguje tak jak ma todo: bud fixni gameover funkci nebo asi swapni playera a pc

                if (!gameOver)
                {
                    Console.WriteLine(" enter next round");
                    Console.ReadLine();
                }
            }

            //wip jak restartovat program, cestne ukradeny z napovedy todo: flakni tam od koho presne to je + rework it a lil
            char k;//proc jsem tam dala k bro, tf was i cooking
            do
            {
                Console.WriteLine("Press x to exit");
                k = Console.ReadKey().KeyChar;
            }
            while (k != 'x' && k != 'X');


        }

        static void CreateBoard(char[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = '~';
                }
            }
        }
        static void DisplayBoard( char[,] board) //, string boardName
        {
            Console.WriteLine();
            //Console.WriteLine(boardName);
            Console.Write("   ");
            for (char col = 'A'; col < 'A' + board.GetLength(1); col++)
            {
                Console.Write(col + " ");
            }
            Console.WriteLine();
            for (int row = 0; row < board.GetLength(0); row++)
            {
                Console.Write(row + 1 + " ");
                if (row + 1 < 10) Console.Write(" ");
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    Console.Write(board[row, col] + " " );
                }
                Console.WriteLine();
            }


        }
        static void PlaceShipsRandom(char[,] board)
        {

            (string name, int length)[] ships = {
            ("Torpedoborec", 2),
            ("Kriznik", 3), // idk jak jsou anglicky, todo: preloz a flakni tam tu ang verzi
            ("Submarie", 3),
            ("Battleship", 4),
            ("Aircarrier", 5)
        };

            Random rand = new Random();

            foreach (var ship in ships)
            {
                bool placed = false;

                while (!placed)
                {
                    int orientation = rand.Next(2);
                    int startRow = rand.Next(board.GetLength(0));
                    int startCol = rand.Next(board.GetLength(1));


                    if (CanPlaceShip(board, startRow, startCol, ship.length, orientation))
                    {
                        PlaceShip(board, startRow, startCol, ship.length, orientation, ship.name[0]);
                        placed = true;
                    }
                }
            }
        }
        static bool CanPlaceShip(char[,] board, int row, int col, int length, int orientation)
        {
            if (orientation == 0) 
            {
                if (col + length > board.GetLength(1)) return false; 

                for (int i = 0; i < length; i++)
                {
                    if (board[row, col + i] != '~') return false; 
                }
            }
            else 
            {
                if (row + length > board.GetLength(0)) return false;

                for (int i = 0; i < length; i++)
                {
                    if (board[row + i, col] != '~') return false;
                }
            }

            return true;
        }
        static void PlaceShipsManual(char[,] board)
        {
            (string name, int length)[] ships =
            {
            ("Torpedoborec", 2),
            ("Kriznik", 3), // idk jak jsou anglicky, todo: preloz a flakni tam tu ang verzi
            ("Submarie", 3),
            ("Battleship", 4),
            ("Aircarrier", 5)
            };
            foreach (var ship in ships)
            {
                bool placed = false;

                while (!placed)
                {
                    Console.WriteLine("ship: " + ship.name + ship.length);
                    DisplayBoard(board);
                    Console.Write("enter coordinates: ");
                    string input = Console.ReadLine()?.ToUpper();
                    if (string.IsNullOrEmpty(input) || input.Length < 2)
                    {
                        Console.WriteLine("invalid input");
                        continue;
                    }

                    char colLetter = input[0];
                    int col = colLetter - 'A';
                    if (!int.TryParse(input.Substring(1), out int row) || col < 0 || col >= board.GetLength(1) || row < 1 || row > board.GetLength(0))
                    {
                        Console.WriteLine("invalid coordinates");
                        continue;
                    }
                    row -= 1;

                    Console.Write("orientation (H = horizontal, V = vertical): ");
                    string orientationInput = Console.ReadLine()?.ToUpper();
                    if (orientationInput != "H" && orientationInput != "V")
                    {
                        Console.WriteLine("invalid orientation");
                        continue;
                    }

                    int orientation = orientationInput == "H" ? 0 : 1;

                    // Check if the ship can be placed
                    if (CanPlaceShip(board, row, col, ship.length, orientation))
                    {
                        PlaceShip(board, row, col, ship.length, orientation, ship.name[0]);
                        placed = true;
                    }
                    else
                    {
                        Console.WriteLine("unable to place ship");
                    }
                    Console.Clear();
                }
            }
        }
        static void PlaceShip(char[,] board, int row, int col, int length, int orientation, char shipSymbol)
        {
            if (orientation == 0)
            {
                for (int i = 0; i < length; i++)
                {
                    board[row, col + i] = shipSymbol;
                }
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    board[row + i, col] = shipSymbol;
                }
            }
        }
        static void PlayerShoot(char[,] targetBoard, char[,] visibleBoard)
        {
            while (true)
            {
                Console.Write("target coordinates: ");
                string input = Console.ReadLine()?.ToUpper();

                if (string.IsNullOrEmpty(input) || input.Length < 2)
                {
                    Console.WriteLine("invalid input");
                    continue;
                }

                char colLetter = input[0];
                int col = colLetter - 'A';
                if (!int.TryParse(input.Substring(1), out int row) || col < 0 || col >= targetBoard.GetLength(1) || row < 1 || row > targetBoard.GetLength(0))
                {
                    Console.WriteLine("invalid coordinates");
                    continue;
                }

                row -= 1;

                if (visibleBoard[row, col] == 'X' || visibleBoard[row, col] == 'O')
                {
                    Console.WriteLine("already shot here");
                    continue;
                }

                if (targetBoard[row, col] != '~')
                {
                    Console.WriteLine("hit");
                    targetBoard[row, col] = 'X';
                    visibleBoard[row, col] = 'X';
                }
                else 
                {
                    Console.WriteLine("midd");
                    targetBoard[row, col] = 'O';
                    visibleBoard[row, col] = 'O';
                }
                break;
            }
        }
        static void ComputerShoot(char[,] playerBoard)
        {
            Random random = new Random();
            while (true)
            {
                int row = random.Next(playerBoard.GetLength(0));
                int col = random.Next(playerBoard.GetLength(1));

                if (playerBoard[row, col] == 'X' || playerBoard[row, col] == 'O')
                {
                    continue;
                }
                if (playerBoard[row, col] != '~')
                {
                    Console.WriteLine(" hit " + Convert.ToChar('A' + col) + (row + 1));
                    playerBoard[row, col] = 'X';
                }
                else
                {
                    Console.WriteLine(" miss " + Convert.ToChar('A' + col) + (row + 1));
                    playerBoard[row, col] = 'O';
                }
                break;
            }
        }
        static bool CheckGameOver(char[,] board, string playerName) 
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] != '~' && board[i, j] != 'X' && board[i, j] != 'O')
                    {
                        return false;
                    }
                }
            }

            Console.WriteLine("gameover, " + playerName + " won"); 
            return true;
        }
    }
}
