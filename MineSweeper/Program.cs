using System;

public class MineSweeper
{
    private readonly int[,] _grid;
    private readonly bool[,] _revealed;
    private readonly int _size;
    private readonly int _mines;

    public MineSweeper(int size, int mines)
    {
        _size = size;
        _mines = mines;
        _grid = new int[size, size];
        _revealed = new bool[size, size];

        GenerateMines();
        CalculateNumbers();
    }

    private void GenerateMines()
    {
        var random = new Random();
        for (int i = 0; i < _mines; i++)
        {
            int x, y;
            do
            {
                x = random.Next(_size);
                y = random.Next(_size);
            } while (_grid[x, y] == -1);

            _grid[x, y] = -1;
        }
    }

    private void CalculateNumbers()
    {
        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                if (_grid[i, j] == -1)
                {
                    for (int dx = -1; dx <= 1; dx++)
                    {
                        for (int dy = -1; dy <= 1; dy++)
                        {
                            int nx = i + dx, ny = j + dy;
                            if (nx >= 0 && nx < _size && ny >= 0 && ny < _size && _grid[nx, ny] != -1)
                            {
                                _grid[nx, ny]++;
                            }
                        }
                    }
                }
            }
        }
    }

    public bool Reveal(int x, int y)
    {
        if (x < 0 || x >= _size || y < 0 || y >= _size)
        {
            throw new ArgumentOutOfRangeException();
        }

        _revealed[x, y] = true;

        if (_grid[x, y] == -1)
        {
            return false;
        }

        if (_grid[x, y] == 0)
        {
            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    int nx = x + dx, ny = y + dy;
                    if (nx >= 0 && nx < _size && ny >= 0 && ny < _size && !_revealed[nx, ny])
                    {
                        Reveal(nx, ny);
                    }
                }
            }
        }

        return true;
    }

    public void Print()
    {
        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                if (!_revealed[i, j])
                {
                    Console.Write('.');
                }
                else if (_grid[i, j] == -1)
                {
                    Console.Write('*');
                }
                else
                {
                    Console.Write(_grid[i, j]);
                }
            }
            Console.WriteLine();
        }
    }
}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Welcome to Minesweeper!");

        int size;
        do
        {
            Console.Write("Enter the size of the grid (e.g. 4 for a 4x4 grid): ");
            if (!int.TryParse(Console.ReadLine(), out size) || size < 2 || size > 10)
            {
                Console.WriteLine("Invalid input. Please enter a number between 2 and 10.");
            }
        } while (size < 2 || size > 10);

        int mines;
        do
        {
            Console.Write("Enter the number of mines to place on the grid (maximum is 35% of the total squares): ");
            if (!int.TryParse(Console.ReadLine(), out mines) || mines < 1 || mines > size * size * 0.35)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and " + (size * size * 0.35));
            }
        } while (mines < 1 || mines > size * size * 0.35);

        var game = new MineSweeper(size, mines);
        game.Print();

        while (true)
        {
            Console.Write("Select a square to reveal (e.g. A1): ");
            string input = Console.ReadLine().ToUpper();
            if (input.Length != 2 || input[0] < 'A' || input[0] >= 'A' + size || input[1] < '1' || input[1] >= '1' + size)
            {
                Console.WriteLine("Invalid input. Please enter a valid square.");
                continue;
            }

            int x = input[0] - 'A';
            int y = input[1] - '1';
            if (!game.Reveal(x, y))
            {
                Console.WriteLine("Oh no, you detonated a mine! Game over.");
                break;
            }

            game.Print();
        }
    }
}
