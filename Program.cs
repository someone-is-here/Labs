using System;
using System.Collections.Generic;
using System.Threading;

namespace Snake {
    class Snake {
        List<int> snakeCoordinates;
        char[][] field;
        int sizeX;
        int sizeY;
        int foodAmount;
        char symb = 'O';
        Random rand = new Random();
        
        public Snake(int sizeX, int sizeY) {
            if (sizeX > 0 && sizeY > 0) {
                this.sizeX = sizeX;
                this.sizeY = sizeY;
                GenField(sizeX, sizeY);
                SetSnake();
                SetFood();
                SetTraps();
                SetExit();
            } else {
                Console.WriteLine("Field will be too small");
            }
        }
        
        public void GenField(int sizeX, int sizeY) {
            field = new char[sizeY][];
            for (int i = 0; i < sizeY; i++) {
                field[i] = new char[sizeX];
                for (int j = 0; j < sizeX; j++) {
                    field[i][j] = '*';
                }
            }
            return;
        }
        
        public void SetSnake() {
            int posX, posY;
            snakeCoordinates = new List<int>(foodAmount * 2 + 2);
            posX = rand.Next(sizeX);
            posY = rand.Next(sizeY);
            snakeCoordinates.Add(posY);
            snakeCoordinates.Add(posX);
            field[posY][posX] = symb;
            return;
        }
        
        public void SetFood() {
            int posX, posY, foodAmountCopy;
            foodAmount = rand.Next(Math.Min(sizeX, sizeY), Math.Max(sizeX, sizeY) + 1);
            foodAmountCopy = foodAmount;
            while (foodAmountCopy > 0) {
                posX = rand.Next(sizeX);
                posY = rand.Next(sizeY);
                if (field[posY][posX] != symb && field[posY][posX] != '@') { 
                    field[posY][posX] = '@';
                    foodAmountCopy--;
                }
            }
            return;
        }
        
        public void SetTraps() {
            int posX, posY, trapsNum;
            trapsNum = rand.Next(Math.Min(sizeX, sizeY), Math.Max(sizeX, sizeY) + 1);
            
            while (trapsNum >= 0) {
                posX = rand.Next(sizeX);
                posY = rand.Next(sizeY);
                if (field[posY][posX] != symb && field[posY][posX] != '@' && field[posY][posX] != ' ') {
                    if (posX > 0 &&  posY < sizeY - 1 && posY > 0 && posX < sizeX - 1) { 
                        if (field[posY][posX - 1] != ' ' && field[posY + 1][posX - 1] != ' ' && field[posY + 1][posX] != ' ' && field[posY - 1][posX + 1] != ' ' && field[posY - 1][posX] != ' ' && field[posY][posX + 1] != ' ') {
                            field[posY][posX] = ' ';
                            trapsNum--;
                        }
                    }
  
                }
            }
            return;
        }
        
        public void SetExit() {
            int posX, posY;
            while (true) {
                posX = rand.Next(sizeX);
                posY = rand.Next(sizeY);
                if (field[posY][posX] != symb && field[posY][posX] != '@' && field[posY][posX] != ' ') {
                    field[posY][posX] = 'E';
                    break;
                }
            }
            return;
        }
        
        public void ShowField() {
            foreach (char[] str in field) {
                foreach (char symb in str) {
                    switch (symb){
                        case 'O':
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case '@':
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case '*':
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            break;
                        case 'E':
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                    }
                    Console.Write(symb + " ");
                }
                Console.WriteLine();
            }
            return;
        }
        
        public bool MoveSnake() {
            bool ex = true, win = false;
            Console.ForegroundColor = ConsoleColor.White;
            switch (Console.ReadKey().KeyChar) {
                case 'w':
                case 'W':
                    if (snakeCoordinates[0] - 1 >= 0) {
                        if (field[snakeCoordinates[0] - 1][snakeCoordinates[1]] == ' ') {
                            ex = false;
                        } else if (field[snakeCoordinates[0] - 1][snakeCoordinates[1]] == 'E') {
                            win = true;
                        } else if (field[snakeCoordinates[0] - 1][snakeCoordinates[1]] == symb) {
                            DeleteSnakeSegments(snakeCoordinates[0] - 1, snakeCoordinates[1]);
                            MoveAllSegments(snakeCoordinates[0] - 1, snakeCoordinates[1]);
                        } else if (field[snakeCoordinates[0] - 1][snakeCoordinates[1]] == '@') {
                            AddSegment(snakeCoordinates[0] - 1, snakeCoordinates[1]);
                        } else {
                            MoveAllSegments(snakeCoordinates[0] - 1, snakeCoordinates[1]);
                        }
                    }
                    break;
                case 'a':
                case 'A':
                    if (snakeCoordinates[1] - 1 >= 0) {
                        if (field[snakeCoordinates[0]][snakeCoordinates[1] - 1] == ' ') {
                            ex = false;
                        } else if (field[snakeCoordinates[0]][snakeCoordinates[1] - 1] == 'E') { 
                            win = true;
                        } else if (field[snakeCoordinates[0]][snakeCoordinates[1] - 1] == symb) {
                            DeleteSnakeSegments(snakeCoordinates[0], snakeCoordinates[1] - 1);
                            MoveAllSegments(snakeCoordinates[0], snakeCoordinates[1] - 1);
                        } else if (field[snakeCoordinates[0]][snakeCoordinates[1] - 1] == '@') {
                            AddSegment(snakeCoordinates[0],snakeCoordinates[1] - 1);
                        } else {
                            MoveAllSegments(snakeCoordinates[0], snakeCoordinates[1] - 1);
                        }
                    }
                    break;
                case 's':
                case 'S':
                    if (snakeCoordinates[0] + 1 < sizeY) {
                        if (field[snakeCoordinates[0] + 1][snakeCoordinates[1]] == ' ') {
                            ex = false;
                        } else if (field[snakeCoordinates[0] + 1][snakeCoordinates[1]] == 'E' ) {
                            win = true;
                        } else if (field[snakeCoordinates[0] + 1][snakeCoordinates[1]] == symb) {
                            DeleteSnakeSegments(snakeCoordinates[0] + 1, snakeCoordinates[1]);
                            MoveAllSegments(snakeCoordinates[0] + 1, snakeCoordinates[1]);
                        } else if (field[snakeCoordinates[0] + 1][snakeCoordinates[1]] == '@') {
                            AddSegment(snakeCoordinates[0] + 1, snakeCoordinates[1]);
                        } else {
                            MoveAllSegments(snakeCoordinates[0] + 1, snakeCoordinates[1]);
                        }
                    }
                    break;
                case 'd':
                case 'D':
                    if (snakeCoordinates[1] + 1 < sizeX) {
                        if (field[snakeCoordinates[0]][snakeCoordinates[1] + 1] == ' ') {
                            ex = false;
                        } else if (field[snakeCoordinates[0]][snakeCoordinates[1] + 1] == 'E') {
                            win = true;
                        } else if (field[snakeCoordinates[0]][snakeCoordinates[1] + 1] == symb) {
                            DeleteSnakeSegments(snakeCoordinates[0], snakeCoordinates[1] + 1);
                            MoveAllSegments(snakeCoordinates[0], snakeCoordinates[1] + 1);
                        } else if (field[snakeCoordinates[0]][snakeCoordinates[1] + 1] == '@') {
                            AddSegment(snakeCoordinates[0], snakeCoordinates[1] + 1);
                        } else {
                            MoveAllSegments(snakeCoordinates[0], snakeCoordinates[1] + 1);
                        }
                        
                    }
                    break;
                default:
                    Console.WriteLine("\nWrong symbol");
                    Console.Beep();
                    Thread.Sleep(1000);
                    break;
            }
            if (!ex) {
                Console.WriteLine("\nGAME OVER!!!");
                Console.WriteLine("You fall into a trap!!!");
            } else if (win && foodAmount == 0) {
                ex = false;
                Console.WriteLine("\nYou are the winner!!!");
                Console.WriteLine($"Your score is {snakeCoordinates.Count / 2}");
            }
            return ex;
        }
        
        public void DeleteSnakeSegments(int newPosY, int newPosX) {
            for (int i = 2; i < snakeCoordinates.Count; i += 2) {
                if (snakeCoordinates[i] == newPosY && snakeCoordinates[i + 1] == newPosX) {
                    while (i < snakeCoordinates.Count) {
                        field[snakeCoordinates[i]][snakeCoordinates[i + 1]] = '*';
                        snakeCoordinates.RemoveRange(i, 2);
                    }
                }
            }
            return;
        }
        
        public void AddSegment(int posY, int posX) {
            snakeCoordinates.Add(0);
            snakeCoordinates.Add(0);

            for (int i = snakeCoordinates.Count - 1; i >=2 ; i -= 2) {
                snakeCoordinates[i - 1] = snakeCoordinates[i - 3];
                snakeCoordinates[i] = snakeCoordinates[i - 2];
            }

            snakeCoordinates[0] = posY;
            snakeCoordinates[1] = posX;
            field[posY][posX] = symb;
            foodAmount--;
            return;
        }
        
        public void MoveAllSegments(int newPosY, int newPosX) {
            field[snakeCoordinates[snakeCoordinates.Count - 2]][snakeCoordinates[snakeCoordinates.Count - 1]] = '*';

            for (int i = snakeCoordinates.Count - 1; i >= 2; i -= 2) {
                snakeCoordinates[i - 1] = snakeCoordinates[i - 3];
                snakeCoordinates[i] = snakeCoordinates[i - 2];
            }

            snakeCoordinates[0] = newPosY;
            snakeCoordinates[1] = newPosX;
            field[newPosY][newPosX] = symb;
            return;
        }
    }

    class Program {
        static void Main() {
            Console.WriteLine("Use the WASD keys to move your snake.");
            Console.WriteLine("Find all @ and don't fall into traps ' '");
            Console.WriteLine("Than use E to leave the game (you can leave only when you will find all @)!!!");
            Console.WriteLine("Press enter to start...");
            Thread.Sleep(1000);

            if (Console.ReadKey().KeyChar == 13) {
                Snake sn = new Snake(10, 10);
                Console.Clear();
                sn.ShowField();

                while (sn.MoveSnake()) {
                    Console.Clear();
                    sn.ShowField();
                }
            }
        }
    }
}
