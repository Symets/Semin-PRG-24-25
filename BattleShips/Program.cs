using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks; //možnáá ukradený z 2DArrayPlayground

namespace BattleShips
{
    //Jelikož umělá inteligence a táta <3 mi pomohli hodně se samotným syntaxem kód,tak jsem přiložila do repozitáře solution
    //(BattleShipSolution.pdf)
    //Programovaní assist: AI, Táta; Visio rychlokurz: Máma; Tester(unpaid): Bratr. 
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] boardPlayer = new char[10, 10];
            char[,] boardVisibleComputer = new char[10, 10];
            char[,] boardComputer = new char[10, 10];

            //Vygenerování 3 tabulek
            CreateBoard(boardPlayer); //= Player, kam si hráč pokládá lodě + záznam kde střílel počítač
            CreateBoard(boardVisibleComputer); //= VisibleComputer, pro hráče aby viděl kde už střílel
            CreateBoard(boardComputer); //= Computer, pro program, kam si počítač rozloží lodě, tato tabulka není defaultně vidět pro hráče
            
            PlaceShipsRandom(boardComputer);
            PlaceShipsManual(boardPlayer);
            //PlaceShipsRandom(boardPlayer); //Pro rychlejší testování, abys nemusel konstatně pokládat 5 lodí dokola. 

            bool gameOver = false;

            while (gameOver==false)
            {

                Console.Clear();
                DisplayBoard(boardPlayer, "     Player");
                //DisplayBoard(boardComputer, "     Computer(hidden)"); //Pro rychlejší testování.
                DisplayBoard(boardVisibleComputer, "      Computer");
                Console.WriteLine("you shoot");
                PlayerShoot(boardComputer, boardVisibleComputer);
                Console.WriteLine("computer shoots");
                ComputerShoot(boardPlayer);
                gameOver = CheckGameOver(boardPlayer, "Computer") || CheckGameOver(boardComputer, "Player");
                if (gameOver==false)
                {
                    Console.WriteLine("Press enter to continue to the next round.");
                    Console.ReadLine();
                }

            }

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
        static void DisplayBoard( char[,] board, string boardName)
        //pro orientaci každá tabulka se zobrazí s názvem, to platí i pro skrytou tabulku
        {
            Console.WriteLine();
            Console.WriteLine(boardName);
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
                    Console.Write(board[row, col] + " ");
                }
                Console.WriteLine();
            }


        }
        static void PlaceShipsRandom(char[,] board)
        {
            (string name, int length)[] ships =
            {
            ("Destroyer", 2),
            ("Cruiser", 3),
            ("Submarie", 3),
            ("Battleship", 4),
            ("Aircarrier", 5)
            };

            Random rand = new Random();

            foreach (var ship in ships)
            {
                bool placed = false;

                while (placed == false)
                {
                    int directionRand = rand.Next(2);
                    int startRow = rand.Next(board.GetLength(0));
                    int startCol = rand.Next(board.GetLength(1));


                    if (CanPlaceShip(board, startRow, startCol, ship.length, directionRand) == true )
                    {
                        PlaceShip(board, startRow, startCol, ship.length, directionRand, ship.name[0]);
                        placed = true;
                    }
                }
            }
        }
        static void PlaceShipsManual(char[,] board)
        {
            (string name, int length)[] ships =
            {
            ("Destroyer", 2),
            ("Cruiser", 3),
            ("Submarine", 3),
            ("Battleship", 4),
            ("Aircarrier", 5)
            };
            foreach (var ship in ships)
            {
                bool placed = false;

                while (placed == false)
                {
                    Console.WriteLine("Ship name: " + ship.name + "  ship length: " + ship.length);
                    DisplayBoard(board, "     Player");
                    Console.Write("Enter coordinates (such as A9): ");
                    //program automaticku převede input na velká písmena pro méně omezený input: a1 -> A1
                    string input = Console.ReadLine().ToUpper(); 
                    if (string.IsNullOrEmpty(input) || input.Length < 2)
                    {
                        Console.WriteLine("Invalid input, please try again.");
                        continue;
                    }

                    char collumLetter = input[0];
                    int col = collumLetter - 'A';
                    if (!int.TryParse(input.Substring(1), out int row) || col < 0 || col >= board.GetLength(1) || row < 1 || row > board.GetLength(0))
                    {
                        Console.WriteLine("Invalid coordinates, please try again.");
                        continue;
                    }
                    //jelikož souřadnice tabulky jsou od 0-9 tak, potřebuju aby můj input byl o 1 menší: A10 -> A9
                    row -= 1;

                    Console.Write("Direction of the ship (H = horizontal, V = vertical): ");
                    string directionS = Console.ReadLine().ToUpper();
                    if (directionS != "H" && directionS != "V")
                    {
                        Console.WriteLine("Invalid direction, please try again.");
                        continue;
                    }

                    int direction = directionS == "H" ? 0 : 1;


                    if (CanPlaceShip(board, row, col, ship.length, direction))
                    {
                        PlaceShip(board, row, col, ship.length, direction, ship.name[0]);
                        placed = true;
                    }
                    else
                    {
                        Console.WriteLine("Unable to place ship, please try again.");
                    }
                    Console.Clear();
                }
            }
        }
        static bool CanPlaceShip(char[,] board, int row, int col, int length, int direction)
        {
            if (direction == 0) 
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
        static void PlaceShip(char[,] board, int row, int col, int length, int direction, char shipSymbol)
        {
            if (direction == 0)
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
        static void PlayerShoot(char[,] boardComputer, char[,] boardVisibleComputer)
        {
            while (true)
            {
                Console.Write("Target coordinates: ");
                string input = Console.ReadLine().ToUpper();

                if (string.IsNullOrEmpty(input) || input.Length < 2)
                {
                    Console.WriteLine("Invalid input, please try again.");
                    continue;
                }

                char colLetter = input[0];
                int col = colLetter - 'A';
                if (!int.TryParse(input.Substring(1), out int row) || col < 0 || col >= boardComputer.GetLength(1) || row < 1 || row > boardComputer.GetLength(0))
                {
                    Console.WriteLine("Invalid coordinates, please try again.");
                    continue;
                }
                //Jelikož souřadnice samotné tabulku jsou od 0-9 tak je potřeba převest input hráče na odpovídajicí hodnotu. (A10 -> A9)
                row -= 1;

                if (boardVisibleComputer[row, col] == 'X' || boardVisibleComputer[row, col] == 'O')
                {
                    Console.WriteLine("You lready shot here, please try somewhere else.");
                    continue;
                }

                if (boardComputer[row, col] != '~')
                {
                    Console.WriteLine("Hit");
                    boardComputer[row, col] = 'X';
                    boardVisibleComputer[row, col] = 'X';
                }
                else 
                {
                    Console.WriteLine("Miss");
                    boardComputer[row, col] = 'O';
                    boardVisibleComputer[row, col] = 'O';
                }
                break;
            }
        }
        static void ComputerShoot(char[,] boardPlayer)
        {
            Random random = new Random();
            while (true)
            {
                int row = random.Next(boardPlayer.GetLength(0));
                int col = random.Next(boardPlayer.GetLength(1));

                if (boardPlayer[row, col] == 'X' || boardPlayer[row, col] == 'O')
                {
                    continue;
                }
                if (boardPlayer[row, col] != '~')
                {
                    Console.WriteLine(" hit " + Convert.ToChar('A' + col) + (row + 1));
                    boardPlayer[row, col] = 'X';
                }
                else
                {
                    Console.WriteLine(" miss " + Convert.ToChar('A' + col) + (row + 1));
                    boardPlayer[row, col] = 'O';
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

            Console.WriteLine("Gameover, " + playerName + " won!"); 
            return true;
        }
    }
}
