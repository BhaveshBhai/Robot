namespace ToyRobotSimulator
{
    public class Robot
    {
        private int _x = 0;

        private int _y = 0;

        public int CoorinateY { get => _y; set => _y = value; }

        public int CoorinateX { get => _x; set => _x = value; }

        public Direction Direction { get => _direction; set => _direction = value; }

        public bool IsOnBoard { get => _onBoard; set => _onBoard = value; }

        public Board Board { get => _board; set => _board = value; }

        private bool _onBoard = false;

        private Board _board;

        private Direction _direction;

        public Robot(Board board)
        {
            this.Board = board ?? null;
        }

        public void MoveForword()
        {
            if (this.IsOnBoard)
            {
                int x = CoorinateX;
                int y = CoorinateY;

                switch (_direction)
                {
                    case Direction.NORTH:
                        y = CoorinateY + 1;
                        break;
                    case Direction.EAST:
                        x = CoorinateX + 1;
                        break;
                    case Direction.SOUTH:
                        y = CoorinateY - 1;
                        break;
                    case Direction.WEST:
                        x = CoorinateX - 1;
                        break;
                }

                if (this.Board.IsValidPosition(x, y))
                {
                    CoorinateX = x;
                    CoorinateY = y;
                }
            }
        }

        public void TurnLeft()
        {
            if (this.IsOnBoard)
            {
                switch (this._direction)
                {
                    case Direction.NORTH:
                        Direction = Direction.WEST;
                        break;
                    case Direction.WEST:
                        Direction = Direction.SOUTH;
                        break;
                    case Direction.SOUTH:
                        Direction = Direction.EAST;
                        break;
                    case Direction.EAST:
                        Direction = Direction.NORTH;
                        break;
                }
            }
        }

        public void TurnRight()
        {
            if (this.IsOnBoard)
            {
                switch (this._direction)
                {
                    case Direction.NORTH:
                        Direction = Direction.EAST;
                        break;
                    case Direction.EAST:
                        Direction = Direction.SOUTH;
                        break;
                    case Direction.SOUTH:
                        Direction = Direction.WEST;
                        break;
                    case Direction.WEST:
                        Direction = Direction.NORTH;
                        break;
                }
            }
        }

        public string GetReportData() 
        {
            return $"{_x} {_y} {_direction.ToString()}";
        }
    }

    public class Board
    {
        private int _width;

        private int _height;

        public Board(int width, int height)
        {
            this._width = width;
            this._height = height;
        }

        public bool IsValidXCoordinate(int x)
        {
            return x >= 0 && x < this._width;
        }


        public bool IsValidYCoordinate(int y)
        {
            return y >= 0 && y < this._height;
        }

        public bool IsValidPosition(int x, int y)
        {
            return IsValidXCoordinate(x) && IsValidYCoordinate(y);
        }
    }

    public enum Direction
    {
        NORTH,
        EAST,
        SOUTH,
        WEST
    }

    public class HelperClass 
    {
        public static Direction GetEnumFromString(string enumStr) 
        {
            System.Enum.TryParse<Direction>(enumStr, true, out Direction direction);
            return direction;
        }
    }
}
