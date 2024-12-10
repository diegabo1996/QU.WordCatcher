using QU.WordCatcher.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QU.WordCatcher.Domain.Entities
{
    public class Matrix
    {
        private const int MaxRows = 64;
        private const int MaxColumns = 64;

        private readonly char[,] _grid;

        public int Rows => _grid.GetLength(0);
        public int Columns => _grid.GetLength(1);

        public Matrix(IEnumerable<string> rows)
        {
            if (rows == null || !rows.Any())
                throw new ArgumentException("Matrix cannot be null or empty.");

            var rowArray = rows.ToArray();
            int rowCount = rowArray.Length;
            int columnCount = rowArray[0].Length;

            if (rowCount > MaxRows || columnCount > MaxColumns)
                throw new ArgumentException($"Matrix size cannot exceed {MaxRows}x{MaxColumns}.");

            if (rowArray.Any(row => row.Length != columnCount))
                throw new ArgumentException("All rows in the matrix must have the same number of characters.");

            _grid = new char[rowCount, columnCount];

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    _grid[i, j] = rowArray[i][j];
                }
            }
        }

        public char GetCharacterAt(Position position)
        {
            if (!IsValidPosition(position))
                throw new ArgumentOutOfRangeException("Position is outside the matrix bounds.");

            return _grid[position.Row, position.Column];
        }

        public bool IsValidPosition(Position position)
        {
            return position.Row >= 0 && position.Row < Rows &&
                   position.Column >= 0 && position.Column < Columns;
        }
    }

}
