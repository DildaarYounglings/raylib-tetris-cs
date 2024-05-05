using PositionClass;
using Raylib_cs;
using UtilsClass;

namespace BlockClass;

public class Block
{
    public Dictionary<int, List<Position>> cells;
    public int id;
    int cellSize;
    int rotationState;
    int rowOffset;
    int columnOffset;
    public List<Color> colors;
    public Block()
    {
        rowOffset = 0;
        columnOffset = 0;
        cells = new Dictionary<int, List<Position>>();
        cellSize = 30;
        rotationState = 0;
        colors = Utils.GetCellColors();
    }
    public void Draw()
    {
        List<Position> tiles = GetCellPositions();
        foreach (Position item in tiles)
        {
            Raylib.DrawRectangle(item.column * cellSize + 1, item.row * cellSize + 1, cellSize - 1, cellSize - 1, colors[id]);
        }
    }
    public void Rotate()
    {
        rotationState++;
        if (rotationState == cells.Count) 
        { 
            rotationState = 0;
        }
    }
    public void UndoRotation()
    {
        rotationState--;
        if (rotationState == -1)
        {
            rotationState = cells.Count - 1;
        }
    }
    public void Move(int rows, int columns)
    {
        rowOffset += rows;
        columnOffset += columns;
    }
    public List<Position> GetCellPositions()
    {
        List<Position> tiles = cells[rotationState];
        List<Position> movedTiles = new();
        foreach (var item in tiles)
        {
            Position newPosition = new Position(item.row + rowOffset, item.column + columnOffset);
            movedTiles.Add(newPosition);
        }
        return movedTiles;
    }
}
