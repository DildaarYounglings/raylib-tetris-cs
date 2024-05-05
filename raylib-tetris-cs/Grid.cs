using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilsClass;

namespace GridClass;
public class Grid
{
    List<Color> colors = new List<Color>() { };
    public int[,] grid = new int[20, 10];

    private int numRows, numCols, cellSize;
    public Grid()
    {
        numRows = 20; numCols = 10; cellSize = 30;
        Initialize();
        colors = Utils.GetCellColors();
    }
    void Initialize()
    {
        for (int row = 0; row < numRows; row++)
        {
            for (int column = 0; column < numCols; column++)
            {
                grid[row, column] = 0;
            }
        }
    }
    public void Print()
    {
        for (int row = 0; row < numRows; row++)
        {
            for (int column = 0; column < numCols; column++)
            {
                Console.Write("" + grid[row, column]);
            }
        }
    }
    public bool IsCellOutside(int row, int column)
    {
        if(row >=0 && row<numRows && column>=0 && column < numCols)
        {
            return false;
        }
        return true;
    }
    public bool IsCellEmpty(int row, int column)
    {
        if (grid[row,column] == 0)
        {
            return true;
        }
        return false;
    }
    public void Draw()
    {
        for (int row = 0; row < numRows; row++)
        {
            for (int column = 0; column < numCols; column++)
            {
                int cellValue = grid[row, column];
                Raylib.DrawRectangle(column * cellSize + 1, row * cellSize + 1, cellSize - 1, cellSize - 1, colors[cellValue]);
            }
        }
    }
}
