using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QU.WordCatcher.Domain.ValueObject
{
    public class Position
    {
        public int Row { get; }
        public int Column { get; }

        public Position(int row, int column)
        {
            if (row < 0 || column < 0)
                throw new ArgumentOutOfRangeException("Row and column values must be non-negative.");

            Row = row;
            Column = column;
        }

        public Position Move(int rowDelta, int columnDelta)
        {
            return new Position(Row + rowDelta, Column + columnDelta);
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Position other) return false;
            return Row == other.Row && Column == other.Column;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Row, Column);
        }
    }

}
