//using System.Collections.Generic;

//namespace WpfSnakeGame
//{
//    public class Direction
//    {
//        public readonly static Direction Left = new Direction(0, -1);
//        public readonly static Direction Right = new Direction(0, 1);
//        public readonly static Direction Up = new Direction(-1, 0);
//        public readonly static Direction Down = new Direction(1, 0);

//        public int RowOffset { get; }
//        public int ColumnOffset { get; }

//        private Direction(int rowOffset, int colOffset)
//        {
//            RowOffset = rowOffset;
//            ColumnOffset = colOffset;
//        }
//        public override bool Equals(object obj)
//        {
//            if (obj is Direction direction)
//            {
//                return RowOffset == direction.RowOffset && ColumnOffset == direction.ColumnOffset;
//            }
//            return false;
//        }

//        public static bool operator ==(Direction left, Direction right)
//        {
//            if (ReferenceEquals(left, right))
//            {
//                return true;
//            }

//            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
//            {
//                return false;
//            }

//            return left.Equals(right);
//        }


//        public static bool operator !=(Direction left, Direction right)
//        {
//            return !(left == right);
//        }
//    }
//}






