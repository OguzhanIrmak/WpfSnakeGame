using System.Collections.Generic;

namespace WpfSnakeGame
{
    public class Position
    {
        public int Row { get; }
        public int Column { get; }

        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }

        // Yöne göre pozisyonu çeviren metot.
        public Position Translate(Direction dir)
        {
            return new Position(Row + dir.RowOffset, Column + dir.ColumnOffset);
        }
    }
}

