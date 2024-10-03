
Game game = new Game();
game.Run();

class Game
{

    private void Turn(Player player, Board board)
    {
        Console.WriteLine($"Player {player.Name}'s turn :");
        board.UpdateBoard(player);
        Console.WriteLine(board);
      
    }
    public void Run()
    {
        Console.WriteLine("Welcome to Tic-Tac-Toe!");
        
        
        Board board = new Board(BoardConstants.BoardSize);
        Console.WriteLine("Enter Player's name with X : ");
        Player player1 = new Player(Console.ReadLine() ?? "1", BoardConstants.Symbols[0]);
        Console.WriteLine("Enter Player's name with O : ");
        Player player2 = new Player(Console.ReadLine() ?? "2",BoardConstants.Symbols[1]);
        
        for (int turn = 0; turn < Math.Pow(BoardConstants.SymbolLineSize,2); turn++)
        {
            Turn(player1,board);
            if (player1.CheckWin(board))
            {
                Console.WriteLine($"{player1.Name} won!");
                return;
            }
            Turn(player2,board);
            if (player2.CheckWin(board))
            {
                Console.WriteLine($"{player2.Name} won!");
                return;
            }
        }
        Console.WriteLine("It was a draw.");
        
    }
}

static class BoardConstants
{

    public static int BoardSize { get; } = 5;
    public static int SymbolLineSize { get; } = 4;
    public static char[] Symbols { get; } = ['X','O'];
}

class Board
{
    public char[][] BoardState { get; }

    public Board(int size)
    {
        //Making a string size x size 2D array for the Tic-Tac-Toe Board.
        BoardState = new char[size][];
        for (int i = 0; i < size; i++)
        {
            BoardState[i] = new char[size];
        }
        
        // Initialising individual string values to " " 
        for(int i = 0; i < size; i++)
            for(int j = 0; j < size; j++)
            {
                BoardState[i][j] = ' ';
            }
    }
    
    private int GetRow(int squareNumber) // it gives the row from the bottom like in a num pad
    {
        return BoardState.Length - (squareNumber - 1)/ BoardState.Length - 1 ; 
    } 
    
    private int GetColumn(int squareNumber)
    {

        return ((squareNumber -1) % BoardState.Length); 
    }

    public bool IsOccupied(int squareNumber)
    {
        int row = GetRow(squareNumber);
        int column = GetColumn(squareNumber);
        return (BoardState[row][column] != ' ');
    }
    

    public void UpdateBoard(Player player)
    {
        
        int moveSquareNumber = player.MoveInput(this);
        BoardState[GetRow(moveSquareNumber)][GetColumn(moveSquareNumber)] = player.Symbol;
    }

    public override string ToString()
    {
        string boardDisplayString = "";
        for (int i = 0; i < BoardState.Length; i++)
        {
            for (int j = 0; j < BoardState[i].Length; j++)
            {
                {
                    boardDisplayString += $" {BoardState[i][j]} "; // Displaying symbol with spaces around it

                    if (j != (BoardState.Length - 1)) // Check to avoid an extra | at end of row
                    {
                        boardDisplayString += "|";
                    }
                }
            }

            boardDisplayString += "\n"; // Moving to next row after displaying symbols
            if (i != (BoardState.Length - 1)) // Check to avoid an extra grid row at the end
            {
                for (int j = 0; j < BoardState[i].Length; j++)
                {
                    boardDisplayString += "---";
                    if (j != (BoardState.Length - 1)) // Check to avoid extra + at end of grid row
                    {
                        boardDisplayString += "+";
                    }
                }

            }
            boardDisplayString += "\n"; // Moving to next row after displaying grid row etc.
        
        }
        
        return boardDisplayString;
    }
}

class Player
{
    
    public string Name { get;  }
    public char Symbol {get;}
    
    public Player(string name, char symbol)
    {
        Name = name;
        Symbol = symbol;
    }

    public int MoveInput(Board board)
    {
        while (true)
        {
            Console.WriteLine($"Player {Name}, Please enter your move :"); //Gets input for the board in a manner similar to a Num Pad
            int moveSquareNumber = Convert.ToInt32(Console.ReadLine());
            if (!board.IsOccupied(moveSquareNumber))
            {
                return moveSquareNumber;
            }
            Console.WriteLine($"Player {Name}, That square is already occupied");
            
        }
    }
    
    public  bool CheckWin( Board board)
    {
        return CheckRows(board) || CheckColumns(board)|| CheckDiagonals(board);
    }
    private  bool CheckRows(Board board)
    {

        for (int i = 0; i < board.BoardState.Length; i++)
        {
            int count = 0;
            for (int j = 0; j < board.BoardState.Length; j++)
            {
                if (board.BoardState[i][j] == Symbol)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }

            if (count == BoardConstants.SymbolLineSize)
            {
                return true;
            }
        }

        return false;
    }

    private bool CheckColumns( Board board)
    {
        for (int i = 0; i < board.BoardState.Length; i++)
        {
            int count = 0;
            for (int j = 0; j < board.BoardState.Length; j++)
            {
                if (board.BoardState[j][i] == Symbol)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }

            if (count == BoardConstants.SymbolLineSize)
            {
                return true;
            }
        }

        return false;
    }

    private  bool CheckDiagonals(Board board)
    {
        for (int i = 0; i <= board.BoardState.Length - BoardConstants.SymbolLineSize; i++)
        {
            
            for (int j = 0; j <= board.BoardState[i].Length - BoardConstants.SymbolLineSize; j++)
            {
                int countMajorDiagonal = 0;
              
                for (int k = 0; k < BoardConstants.SymbolLineSize; k++)
                {
                    if (board.BoardState[i+k][j+k] == Symbol)
                    {
                        countMajorDiagonal++;
                    }
                }
                
                if (countMajorDiagonal == BoardConstants.SymbolLineSize)
                {
                    return true;
                }
            }

            for (int j = board.BoardState[i].Length - 1; j >=  BoardConstants.SymbolLineSize - 1; j--)
            {
                int countMinorDiagonal = 0;
                for (int k = 0; k < BoardConstants.SymbolLineSize; k++)
                {
                    if (board.BoardState[i + k][j - k] == Symbol)
                    {
                        countMinorDiagonal++;
                    }
                }

                if (countMinorDiagonal == BoardConstants.SymbolLineSize)
                {
                    return true;
                }

            }
        }
        return false;
    }

   

}
