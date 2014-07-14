using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineSweeper{

	public class MineSweeper
	{
        public const int MAX_POINTS = 35;

		public class Score
		{
			string name;
			int points;

			public string Name
			{
				get { return name; }
				set { name = value; }
			}

			public int Points
			{
				get { return points; }
				set { points = value; }
			}

			public Score() { }

			public Score(string name, int points)
			{
				this.Name = name;
				this.Points = points;
			}
		}

		static void Main(string[] args)
		{
			string command = string.Empty;
            char[,] playField = CreatePlayField();
            char[,] bombs = PutBombs();
			int pointsCounter = 0;
			bool isExploded = false;
            List<Score> champions = new List<Score>(6);
			int row = 0;
			int column = 0;
			bool isNewGame = true;
			bool isVictory = false;

			do
			{
				if (isNewGame)
				{
					Console.WriteLine("Let's play MineSweeper." +
					" The command 'top' shows the rank, 'restart' starts a new game, 'exit' exits the game");
					PrintField(playField);
					isNewGame = false;
				}
				Console.Write("Enter row and column: ");
				command = Console.ReadLine().Trim();
				if (command.Length >= 3)
				{
					if (int.TryParse(command[0].ToString(), out row) &&
					int.TryParse(command[2].ToString(), out column) &&
						row <= playField.GetLength(0) && column <= playField.GetLength(1))
					{
						command = "turn";
					}
				}
				switch (command)
				{
					case "top":
					    PrintRanking(champions);
						break;
					case "restart":
						playField = CreatePlayField();
						bombs = PutBombs();
						PrintField(playField);
						isExploded = false;
						isNewGame = false;
						break;
					case "exit":
						Console.WriteLine("Bye, Bye, Bye!");
						break;
					case "turn":
						if (bombs[row, column] != '*')
						{
							if (bombs[row, column] == '-')
							{
                                StoreCurrentMove(playField, bombs, row, column);
								pointsCounter++;
							}
							if (MAX_POINTS == pointsCounter)
							{
								isVictory = true;
							}
							else
							{
								PrintField(playField);
							}
						}
						else
						{
							isExploded = true;
						}
						break;
					default:
						Console.WriteLine("\nError! Invalid command\n");
						break;
				}
				if (isExploded)
				{
					PrintField(bombs);
					Console.Write("\nGame Over! Your points: {0}. " +
						"Enter your nickName: ", pointsCounter);
					string nickName = Console.ReadLine();
                    Score playerScore = new Score(nickName, pointsCounter);
					if (champions.Count < 5)
					{
						champions.Add(playerScore);
					}
					else
					{
						for (int i = 0; i < champions.Count; i++)
						{
							if (champions[i].Points < playerScore.Points)
							{
								champions.Insert(i, playerScore);
								champions.RemoveAt(champions.Count - 1);
								break;
							}
						}
					}
                    champions.Sort((Score firstPlayer, Score secondPlayer) => secondPlayer.Name.CompareTo(firstPlayer.Name));
                    champions.Sort((Score firstPlayer, Score secondPlayer) => secondPlayer.Points.CompareTo(firstPlayer.Points));
					PrintRanking(champions);

					playField = CreatePlayField();
					bombs = PutBombs();
					pointsCounter = 0;
					isExploded = false;
					isNewGame = true;
				}
				if (isVictory)
				{
					Console.WriteLine("\nGood game! You won!");
					PrintField(bombs);
					Console.WriteLine("Enter your nick name: ");
					string nickName = Console.ReadLine();
                    Score points = new Score(nickName, pointsCounter);
					champions.Add(points);
					PrintRanking(champions);
					playField = CreatePlayField();
					bombs = PutBombs();
					pointsCounter = 0;
					isVictory = false;
					isNewGame = true;
				}
			}
			while (command != "exit");
		}

        private static void PrintRanking(List<Score> points)
		{
			Console.WriteLine("\nPoints:");
            if (points.Count > 0)
			{
                for (int i = 0; i < points.Count; i++)
				{
					Console.WriteLine("{0}. {1} --> {2} boxes",
                        i + 1, points[i].Name, points[i].Points);
				}
				Console.WriteLine();
			}
			else
			{
				Console.WriteLine("Empty rating!\n");
			}
		}

		private static void StoreCurrentMove(char[,] field,
			char[,] bombs, int row, int column)
		{
            char minesCount = GetMinesCount(bombs, row, column);
            bombs[row, column] = minesCount;
            field[row, column] = minesCount;
		}

		private static void PrintField(char[,] board)
		{
			int rows = board.GetLength(0);
			int cols = board.GetLength(1);
			Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
			Console.WriteLine("   ---------------------");
            for (int i = 0; i < rows; i++)
			{
				Console.Write("{0} | ", i);
                for (int j = 0; j < cols; j++)
				{
					Console.Write(string.Format("{0} ", board[i, j]));
				}
				Console.Write("|");
				Console.WriteLine();
			}
			Console.WriteLine("   ---------------------\n");
		}

		private static char[,] CreatePlayField()
		{
			int boardRows = 5;
			int boardColumns = 10;
			char[,] board = new char[boardRows, boardColumns];
			for (int i = 0; i < boardRows; i++)
			{
				for (int j = 0; j < boardColumns; j++)
				{
					board[i, j] = '?';
				}
			}

			return board;
		}

		private static char[,] PutBombs()
		{
			int rows = 5;
			int cols = 10;
			char[,] playingField = new char[rows, cols];

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
                    playingField[i, j] = '-';
				}
			}

			List<int> randomNumbers = new List<int>();

            while (randomNumbers.Count < 15)
			{
				Random random = new Random();
				int generatedNumber = random.Next(50);
                if (!randomNumbers.Contains(generatedNumber))
				{
                    randomNumbers.Add(generatedNumber);
				}
			}

            foreach (int number in randomNumbers)
			{
                int column = (number / cols);
                int row = (number % cols);
                if (row == 0 && number != 0)
				{
					column--;
					row = cols;
				}
				else
				{
					row++;
				}
				playingField[column, row - 1] = '*';
			}

            return playingField;
		}

		private static char GetMinesCount(char[,] field, int column, int row)
		{
			int minesCounter = 0;
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            if (column - 1 >= 0)
			{
                if (field[column - 1, row] == '*')
				{
                    minesCounter++; 
				}
			}
            if (column + 1 < rows)
			{
                if (field[column + 1, row] == '*')
				{
                    minesCounter++; 
				}
			}
            if (row - 1 >= 0)
			{
                if (field[column, row - 1] == '*')
				{
                    minesCounter++;
				}
			}
            if (row + 1 < cols)
			{
                if (field[column, row + 1] == '*')
				{
                    minesCounter++;
				}
			}
            if ((column - 1 >= 0) && (row - 1 >= 0))
			{
                if (field[column - 1, row - 1] == '*')
				{
                    minesCounter++; 
				}
			}
            if ((column - 1 >= 0) && (row + 1 < cols))
			{
                if (field[column - 1, row + 1] == '*')
				{
                    minesCounter++; 
				}
			}
            if ((column + 1 < rows) && (row - 1 >= 0))
			{
                if (field[column + 1, row - 1] == '*')
				{
                    minesCounter++; 
				}
			}
            if ((column + 1 < rows) && (row + 1 < cols))
			{
                if (field[column + 1, row + 1] == '*')
				{
                    minesCounter++; 
				}
			}
            return char.Parse(minesCounter.ToString());
		}
	}
}
