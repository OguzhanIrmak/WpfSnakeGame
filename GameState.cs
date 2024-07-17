using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfSnakeGame
{
    public class GameState
    {
        public int Rows { get; }
        public int Cols { get; }
        public GridValue[,] Grid { get; }
        public Direction Dir { get; private set; }
        public int Score { get; private set;}
        public bool GameOver {  get; private set; }

        private readonly LinkedList<Position> snakePositions = new LinkedList<Position>();
        private readonly Random random = new Random();

        public GameState(int rows,int cols)
        {
            Rows = rows;
            Cols = cols;
            Grid = new GridValue[rows, cols];
            Dir = Direction.Right;

            AddSnake();
            AddFood();
        }
        private void AddSnake()
        {
            int row = Rows / 2;
            for(int col=1; col<=3; col++)
            {
                Grid[row, col] = GridValue.Snake;
                snakePositions.AddFirst(new Position(row, col));
            }
        }

        private IEnumerable<Position> EmptyPositions()
        {
            for(int row=0; row<Rows; row++)
            {
                for(int col=0; col<Cols; col++)
                {
                    if (Grid[row, col] == GridValue.Empty)
                    {
                        yield return new Position(row, col);
                    }
                }
            }

        }

        private void AddFood()
        {
            var emptyPositions = new List<Position>(EmptyPositions());
            if (emptyPositions.Count == 0)
            {
                return;
            }

            var foodPosition = emptyPositions[random.Next(emptyPositions.Count)];
            Grid[foodPosition.Row, foodPosition.Column] = GridValue.Food;
        }
        public Position HeadPosition()
        {
            return snakePositions.First.Value;
        }

        public Position TailPosition()
        {
            return snakePositions.Last.Value;
        }
        public IEnumerable<Position> SnakePositions()
        {
            return snakePositions;
        }
        private void AddHead(Position pos) 
        {
            snakePositions.AddFirst(pos);
            Grid[pos.Row, pos.Column] = GridValue.Snake;
        }
        private void RemoveTail()
        {
            var tail= snakePositions.Last.Value;
            Grid[tail.Row,tail.Column] = GridValue.Empty;
            snakePositions.RemoveLast();
        }
        public void ChangeDirection(Direction dir)
        {
            if ((Dir == Direction.Left && dir == Direction.Right) ||
                (Dir == Direction.Right && dir == Direction.Left) ||
                (Dir == Direction.Up && dir == Direction.Down) ||
                (Dir == Direction.Down && dir == Direction.Up))
            {
                
                return;
            }
            Dir = dir;
        }
        private bool OutsideGrid(Position pos)
        {
            return pos.Row<0 || pos.Row>=Rows || pos.Column<0 || pos.Column>=Cols;
        }
        private GridValue WillHit(Position newHeadpos)
        {
            if (OutsideGrid(newHeadpos))
            { 
                return GridValue.Outside;
            }
           
            return Grid[newHeadpos.Row,newHeadpos.Column];
        }

        public void Move()
        {
            Position newHeadPos = HeadPosition().Translate(Dir);
            GridValue hit = WillHit(newHeadPos);

            if(hit==GridValue.Outside || hit==GridValue.Snake)
            {
                GameOver = true;
            }
            else if (hit == GridValue.Empty)
            {
                RemoveTail();
                AddHead(newHeadPos);
            }
            else if(hit == GridValue.Food)
            {
                AddHead(newHeadPos);
                Score++;
                AddFood();
            }
        }
        
    }
}
