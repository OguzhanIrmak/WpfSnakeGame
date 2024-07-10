using System.Collections.Generic;

namespace WpfSnakeGame
{
    public class Direction
    {
        // Yılanın hareket edebileceği dört yön tanımlanıyor.
        public readonly static Direction Left = new Direction(0, -1);
        public readonly static Direction Right = new Direction(0, 1);
        public readonly static Direction Up = new Direction(-1, 0);
        public readonly static Direction Down = new Direction(1, 0);

        // Satır ve sütun ofsetlerini belirleyen özellikler.
        public int RowOffset { get; }
        public int ColumnOffset { get; }

        private Direction(int rowOffset, int colOffset)
        {
            RowOffset = rowOffset;
            ColumnOffset = colOffset;
        }

       
    }
}
